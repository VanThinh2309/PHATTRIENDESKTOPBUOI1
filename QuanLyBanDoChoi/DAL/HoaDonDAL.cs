using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.DAL
{
    public class HoaDonDAL
    {
        public List<HoaDonDTO> LayDanhSach(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string query = "SELECT MaHD, NgayLap, MaKH, MaNenTang, GhiChu, TongTien, PhuongThucThanhToan, TrangThai, DiaChi, DonViVanChuyen FROM HoaDon WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();
            if (tuNgay.HasValue)
            {
                query += " AND NgayLap >= @TuNgay";
                parameters.Add(new SqlParameter("@TuNgay", tuNgay.Value.Date));
            }
            if (denNgay.HasValue)
            {
                query += " AND NgayLap <= @DenNgay";
                parameters.Add(new SqlParameter("@DenNgay", denNgay.Value.Date.AddDays(1).AddTicks(-1)));
            }
            query += " ORDER BY NgayLap DESC";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(DocHoaDonTuReader(reader));
                    }
                }
            }
            return list;
        }

        public HoaDonDTO LayTheoMa(string maHD)
        {
            string query = "SELECT MaHD, NgayLap, MaKH, MaNenTang, GhiChu, TongTien, PhuongThucThanhToan, TrangThai, DiaChi, DonViVanChuyen FROM HoaDon WHERE MaHD = @MaHD";
            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return DocHoaDonTuReader(reader);
                    }
                }
            }
            return null;
        }

        public List<ChiTietHoaDonDTO> LayChiTietTheoHoaDon(string maHD)
        {
            List<ChiTietHoaDonDTO> list = new List<ChiTietHoaDonDTO>();
            string query = @"SELECT ct.MaHD, ct.MaSP, ct.SoLuong, ct.DonGia, sp.TenSP 
                             FROM ChiTietHoaDon ct
                             LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                             WHERE ct.MaHD = @MaHD";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChiTietHoaDonDTO
                        {
                            MaHD = reader["MaHD"].ToString().Trim(),
                            MaSP = reader["MaSP"].ToString().Trim(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            DonGia = Convert.ToDecimal(reader["DonGia"]),
                            TenSP = reader["TenSP"] != DBNull.Value ? reader["TenSP"].ToString() : string.Empty
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Tạo hóa đơn mới cùng danh sách chi tiết hóa đơn (sử dụng SqlTransaction)
        /// </summary>
        public bool ThemHoaDon(HoaDonDTO hd, List<ChiTietHoaDonDTO> chiTiets)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Chèn HoaDon
                        string queryHD = @"INSERT INTO HoaDon 
                                          (MaHD, NgayLap, MaKH, MaNenTang, GhiChu, TongTien, PhuongThucThanhToan, TrangThai, DiaChi, DonViVanChuyen)
                                          VALUES 
                                          (@MaHD, @NgayLap, @MaKH, @MaNenTang, @GhiChu, @TongTien, @PhuongThucThanhToan, @TrangThai, @DiaChi, @DonViVanChuyen)";

                        using (SqlCommand cmdHD = new SqlCommand(queryHD, conn, trans))
                        {
                            cmdHD.Parameters.AddWithValue("@MaHD", hd.MaHD);
                            cmdHD.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                            cmdHD.Parameters.AddWithValue("@MaKH", string.IsNullOrEmpty(hd.MaKH) ? (object)DBNull.Value : hd.MaKH);
                            cmdHD.Parameters.AddWithValue("@MaNenTang", string.IsNullOrEmpty(hd.MaNenTang) ? (object)DBNull.Value : hd.MaNenTang);
                            cmdHD.Parameters.AddWithValue("@GhiChu", (object)hd.GhiChu ?? DBNull.Value);
                            cmdHD.Parameters.AddWithValue("@TongTien", hd.TongTien);
                            cmdHD.Parameters.AddWithValue("@PhuongThucThanhToan", hd.PhuongThucThanhToan ?? "Tiền mặt");
                            cmdHD.Parameters.AddWithValue("@TrangThai", hd.TrangThai ?? "Đang xử lý");
                            cmdHD.Parameters.AddWithValue("@DiaChi", (object)hd.DiaChi ?? DBNull.Value);
                            cmdHD.Parameters.AddWithValue("@DonViVanChuyen", (object)hd.DonViVanChuyen ?? DBNull.Value);

                            cmdHD.ExecuteNonQuery();
                        }

                        // 2. Chèn từng ChiTietHoaDon và giảm tồn kho tương ứng
                        string queryCT = @"INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia)
                                           VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";

                        string queryGiamTon = @"UPDATE SanPham 
                                                SET TonKho = TonKho - @SoLuong 
                                                WHERE MaSP = @MaSP AND TonKho >= @SoLuong";

                        foreach (var item in chiTiets)
                        {
                            using (SqlCommand cmdCT = new SqlCommand(queryCT, conn, trans))
                            {
                                cmdCT.Parameters.AddWithValue("@MaHD", hd.MaHD);
                                cmdCT.Parameters.AddWithValue("@MaSP", item.MaSP);
                                cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmdCT.Parameters.AddWithValue("@DonGia", item.DonGia);
                                cmdCT.ExecuteNonQuery();
                            }

                            // Giảm tồn kho
                            using (SqlCommand cmdKho = new SqlCommand(queryGiamTon, conn, trans))
                            {
                                cmdKho.Parameters.AddWithValue("@MaSP", item.MaSP);
                                cmdKho.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                cmdKho.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool CapNhatTrangThai(string maHD, string trangThaiMoi)
        {
            string query = "UPDATE HoaDon SET TrangThai = @TrangThai WHERE MaHD = @MaHD";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@TrangThai", trangThaiMoi)
            };
            return Database.ExecuteNonQuery(query, parameters) > 0;
        }

        private HoaDonDTO DocHoaDonTuReader(SqlDataReader reader)
        {
            return new HoaDonDTO
            {
                MaHD = reader["MaHD"].ToString().Trim(),
                NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                MaKH = reader["MaKH"] != DBNull.Value ? reader["MaKH"].ToString().Trim() : string.Empty,
                MaNenTang = reader["MaNenTang"] != DBNull.Value ? reader["MaNenTang"].ToString().Trim() : string.Empty,
                GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : string.Empty,
                TongTien = Convert.ToDecimal(reader["TongTien"]),
                PhuongThucThanhToan = reader["PhuongThucThanhToan"] != DBNull.Value ? reader["PhuongThucThanhToan"].ToString() : "Tiền mặt",
                TrangThai = reader["TrangThai"] != DBNull.Value ? reader["TrangThai"].ToString() : "Đang xử lý",
                DiaChi = reader["DiaChi"] != DBNull.Value ? reader["DiaChi"].ToString() : string.Empty,
                DonViVanChuyen = reader["DonViVanChuyen"] != DBNull.Value ? reader["DonViVanChuyen"].ToString() : string.Empty
            };
        }
    }
}
