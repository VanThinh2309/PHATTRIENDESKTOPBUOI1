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
    public class PhieuNhapDAL
    {
        /// <summary>
        /// Tạo mã phiếu nhập theo định dạng PNyyyyMMddHHmmss
        /// </summary>
        public string TaoMaPhieuNhapTheoThoiGian()
        {
            return "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// Tạo mã phiếu nhập tự động tăng (PN001, PN002, ...) để tương thích ngược
        /// </summary>
        public string TaoMaPhieuNhapTuDong()
        {
            return TaoMaPhieuNhapTheoThoiGian();
        }

        /// <summary>
        /// Thực thi giao dịch (Transaction) thêm phiếu nhập, danh sách chi tiết và cộng dồn tồn kho sản phẩm
        /// </summary>
        public bool ThemPhieuNhap(PhieuNhapDTO phieuNhap, List<ChiTietPhieuNhapDTO> listCT, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (phieuNhap == null)
            {
                errorMessage = "Dữ liệu phiếu nhập không hợp lệ!";
                return false;
            }

            if (listCT == null || listCT.Count == 0)
            {
                listCT = phieuNhap.DanhSachChiTiet;
            }

            if (listCT == null || listCT.Count == 0)
            {
                errorMessage = "Danh sách chi tiết nhập hàng rỗng!";
                return false;
            }

            // Tính tổng tiền nếu chưa được tính
            if (phieuNhap.TongTien <= 0)
            {
                phieuNhap.TongTien = listCT.Sum(ct => ct.ThanhTien);
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm phiếu nhập (Sử dụng cột MaNCC thay vì NhaCungCap)
                        string sqlPN = @"INSERT INTO PhieuNhap (MaPN, NgayNhap, MaNCC, TongTien, GhiChu)
                                         VALUES (@MaPN, @NgayNhap, @MaNCC, @TongTien, @GhiChu)";

                        using (SqlCommand cmdPN = new SqlCommand(sqlPN, conn, transaction))
                        {
                            cmdPN.Parameters.AddWithValue("@MaPN", phieuNhap.MaPN.Trim());
                            cmdPN.Parameters.AddWithValue("@NgayNhap", phieuNhap.NgayNhap);

                            string maNCC = !string.IsNullOrWhiteSpace(phieuNhap.MaNCC) ? phieuNhap.MaNCC.Trim() : phieuNhap.NhaCungCap;
                            if (string.IsNullOrWhiteSpace(maNCC) || maNCC.Contains("Không chọn") || maNCC == "ALL")
                            {
                                cmdPN.Parameters.AddWithValue("@MaNCC", DBNull.Value);
                            }
                            else
                            {
                                cmdPN.Parameters.AddWithValue("@MaNCC", maNCC.Trim());
                            }

                            cmdPN.Parameters.AddWithValue("@TongTien", phieuNhap.TongTien);
                            cmdPN.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(phieuNhap.GhiChu) ? (object)DBNull.Value : phieuNhap.GhiChu.Trim());
                            cmdPN.ExecuteNonQuery();
                        }

                        // 2. Lặp qua danh sách chi tiết
                        string sqlCT = @"INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap)
                                         VALUES (@MaPN, @MaSP, @SoLuongNhap, @DonGiaNhap)";

                        string sqlUpdateSP = @"UPDATE SanPham 
                                               SET TonKho = TonKho + @SoLuongNhap,
                                                   GiaNhap = @DonGiaNhap
                                               WHERE MaSP = @MaSP";

                        foreach (var ct in listCT)
                        {
                            // 2a. Thêm dòng chi tiết phiếu nhập
                            using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn, transaction))
                            {
                                cmdCT.Parameters.AddWithValue("@MaPN", phieuNhap.MaPN.Trim());
                                cmdCT.Parameters.AddWithValue("@MaSP", ct.MaSP.Trim());
                                cmdCT.Parameters.AddWithValue("@SoLuongNhap", ct.SoLuongNhap);
                                cmdCT.Parameters.AddWithValue("@DonGiaNhap", ct.DonGiaNhap);
                                cmdCT.ExecuteNonQuery();
                            }

                            // 2b. Cộng dồn tồn kho và cập nhật giá nhập mới cho sản phẩm
                            using (SqlCommand cmdSP = new SqlCommand(sqlUpdateSP, conn, transaction))
                            {
                                cmdSP.Parameters.AddWithValue("@SoLuongNhap", ct.SoLuongNhap);
                                cmdSP.Parameters.AddWithValue("@DonGiaNhap", ct.DonGiaNhap);
                                cmdSP.Parameters.AddWithValue("@MaSP", ct.MaSP.Trim());
                                cmdSP.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        errorMessage = "Lỗi giao dịch SQL: " + ex.Message;
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Overload ThemPhieuNhap tương thích
        /// </summary>
        public bool ThemPhieuNhap(PhieuNhapDTO phieuNhap, out string errorMessage)
        {
            return ThemPhieuNhap(phieuNhap, phieuNhap?.DanhSachChiTiet, out errorMessage);
        }

        /// <summary>
        /// Lấy toàn bộ danh sách phiếu nhập
        /// </summary>
        public List<PhieuNhapDTO> LayDanhSach()
        {
            return LayDanhSachPhieuNhap(DateTime.MinValue, DateTime.MaxValue, null, null);
        }

        /// <summary>
        /// Lấy danh sách phiếu nhập có lọc theo khoảng thời gian, nhà cung cấp và từ khóa
        /// </summary>
        public List<PhieuNhapDTO> LayDanhSachPhieuNhap(DateTime tuNgay, DateTime denNgay, string maNCC, string keyword)
        {
            List<PhieuNhapDTO> list = new List<PhieuNhapDTO>();

            DateTime dtFrom = tuNgay == DateTime.MinValue ? new DateTime(2000, 1, 1) : tuNgay.Date;
            DateTime dtTo = denNgay == DateTime.MaxValue ? DateTime.Now.AddYears(10) : denNgay.Date.AddDays(1).AddTicks(-1);

            StringBuilder sql = new StringBuilder();
            // JOIN với bảng NhaCungCap để lấy tên nhà cung cấp
            sql.AppendLine(@"SELECT pn.MaPN, pn.NgayNhap, pn.MaNCC, 
                                   ISNULL(ncc.TenNCC, N'Chưa chọn NCC') AS NhaCungCap,
                                   pn.TongTien, pn.GhiChu,
                                   ISNULL(SUM(ct.SoLuongNhap), 0) AS TongSoLuong
                            FROM PhieuNhap pn
                            LEFT JOIN NhaCungCap ncc ON pn.MaNCC = ncc.MaNCC
                            LEFT JOIN ChiTietPhieuNhap ct ON pn.MaPN = ct.MaPN
                            WHERE pn.NgayNhap BETWEEN @TuNgay AND @DenNgay");

            bool filterNCC = !string.IsNullOrWhiteSpace(maNCC) && maNCC != "Tất cả" && maNCC != "ALL" && !maNCC.Contains("Không chọn");
            if (filterNCC)
            {
                sql.AppendLine("  AND (pn.MaNCC = @MaNCC OR ncc.TenNCC LIKE @NCC)");
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sql.AppendLine(@"  AND (pn.MaPN LIKE @Keyword 
                                       OR ncc.TenNCC LIKE @Keyword 
                                       OR pn.GhiChu LIKE @Keyword 
                                       OR EXISTS (
                                           SELECT 1 FROM ChiTietPhieuNhap ctp 
                                           JOIN SanPham sp ON ctp.MaSP = sp.MaSP 
                                           WHERE ctp.MaPN = pn.MaPN AND (ctp.MaSP LIKE @Keyword OR sp.TenSP LIKE @Keyword)
                                       ))");
            }

            sql.AppendLine(@"GROUP BY pn.MaPN, pn.NgayNhap, pn.MaNCC, ncc.TenNCC, pn.TongTien, pn.GhiChu
                             ORDER BY pn.NgayNhap DESC");

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
                cmd.Parameters.AddWithValue("@TuNgay", dtFrom);
                cmd.Parameters.AddWithValue("@DenNgay", dtTo);

                if (filterNCC)
                {
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC.Trim());
                    cmd.Parameters.AddWithValue("@NCC", "%" + maNCC.Trim() + "%");
                }

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword.Trim() + "%");
                }

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pn = new PhieuNhapDTO
                        {
                            MaPN = reader["MaPN"].ToString().Trim(),
                            NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                            MaNCC = reader["MaNCC"] != DBNull.Value ? reader["MaNCC"].ToString().Trim() : string.Empty,
                            NhaCungCap = reader["NhaCungCap"] != DBNull.Value ? reader["NhaCungCap"].ToString().Trim() : "Chưa chọn NCC",
                            TongTien = Convert.ToDecimal(reader["TongTien"]),
                            GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString().Trim() : string.Empty,
                            NguoiLap = "Quản trị viên",
                            TongSoLuong = reader["TongSoLuong"] != DBNull.Value ? Convert.ToInt32(reader["TongSoLuong"]) : 0
                        };
                        list.Add(pn);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Lấy chi tiết các sản phẩm trong phiếu nhập theo mã phiếu
        /// </summary>
        public List<ChiTietPhieuNhapDTO> LayChiTietPhieuNhap(string maPN)
        {
            List<ChiTietPhieuNhapDTO> list = new List<ChiTietPhieuNhapDTO>();

            if (string.IsNullOrWhiteSpace(maPN))
                return list;

            string query = @"SELECT ct.MaPN, ct.MaSP, ISNULL(sp.TenSP, ct.MaSP) AS TenSP, 
                                    ct.SoLuongNhap, ct.DonGiaNhap
                             FROM ChiTietPhieuNhap ct
                             LEFT JOIN SanPham sp ON ct.MaSP = sp.MaSP
                             WHERE ct.MaPN = @MaPN
                             ORDER BY ct.MaSP ASC";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN.Trim());
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChiTietPhieuNhapDTO
                        {
                            MaPN = reader["MaPN"].ToString().Trim(),
                            MaSP = reader["MaSP"].ToString().Trim(),
                            TenSP = reader["TenSP"] != DBNull.Value ? reader["TenSP"].ToString().Trim() : string.Empty,
                            SoLuongNhap = Convert.ToInt32(reader["SoLuongNhap"]),
                            DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"])
                        });
                    }
                }
            }

            return list;
        }
    }
}