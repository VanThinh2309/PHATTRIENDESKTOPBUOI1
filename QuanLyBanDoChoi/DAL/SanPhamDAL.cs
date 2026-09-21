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
    public class SanPhamDAL
    {
        /// <summary>
        /// Lấy danh sách toàn bộ sản phẩm (mặc định lấy tất cả hoặc chỉ còn kinh doanh)
        /// </summary>
        public List<SanPhamDTO> LayDanhSach(bool chiLayConBan = false)
        {
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            string query = "SELECT MaSP, MaLoai, TenSP, DoTuoi, TenXuatXu, Hang, DonGia, TonKho, HinhAnh, TrangThai FROM SanPham";
            if (chiLayConBan)
            {
                query += " WHERE TrangThai = 1";
            }

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(DocSanPhamTuReader(reader));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy thông tin chi tiết một sản phẩm theo mã
        /// </summary>
        public SanPhamDTO LayChiTiet(string maSP)
        {
            string query = "SELECT MaSP, MaLoai, TenSP, DoTuoi, TenXuatXu, Hang, DonGia, TonKho, HinhAnh, TrangThai FROM SanPham WHERE MaSP = @MaSP";
            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return DocSanPhamTuReader(reader);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Thêm sản phẩm mới vào CSDL
        /// </summary>
        public bool Them(SanPhamDTO sp)
        {
            string query = @"INSERT INTO SanPham (MaSP, MaLoai, TenSP, DoTuoi, TenXuatXu, Hang, DonGia, TonKho, HinhAnh, TrangThai)
                             VALUES (@MaSP, @MaLoai, @TenSP, @DoTuoi, @TenXuatXu, @Hang, @DonGia, @TonKho, @HinhAnh, @TrangThai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", sp.MaSP ?? (object)DBNull.Value),
                new SqlParameter("@MaLoai", string.IsNullOrEmpty(sp.MaLoai) ? (object)DBNull.Value : sp.MaLoai),
                new SqlParameter("@TenSP", sp.TenSP ?? string.Empty),
                new SqlParameter("@DoTuoi", string.IsNullOrEmpty(sp.DoTuoi) ? (object)DBNull.Value : sp.DoTuoi),
                new SqlParameter("@TenXuatXu", string.IsNullOrEmpty(sp.TenXuatXu) ? (object)DBNull.Value : sp.TenXuatXu),
                new SqlParameter("@Hang", string.IsNullOrEmpty(sp.Hang) ? (object)DBNull.Value : sp.Hang),
                new SqlParameter("@DonGia", sp.DonGia),
                new SqlParameter("@TonKho", sp.TonKho),
                new SqlParameter("@HinhAnh", string.IsNullOrEmpty(sp.HinhAnh) ? (object)DBNull.Value : sp.HinhAnh),
                new SqlParameter("@TrangThai", sp.TrangThai)
            };

            return Database.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        public bool CapNhat(SanPhamDTO sp)
        {
            string query = @"UPDATE SanPham 
                             SET MaLoai = @MaLoai,
                                 TenSP = @TenSP,
                                 DoTuoi = @DoTuoi,
                                 TenXuatXu = @TenXuatXu,
                                 Hang = @Hang,
                                 DonGia = @DonGia,
                                 TonKho = @TonKho,
                                 HinhAnh = @HinhAnh,
                                 TrangThai = @TrangThai
                             WHERE MaSP = @MaSP";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSP", sp.MaSP),
                new SqlParameter("@MaLoai", string.IsNullOrEmpty(sp.MaLoai) ? (object)DBNull.Value : sp.MaLoai),
                new SqlParameter("@TenSP", sp.TenSP ?? string.Empty),
                new SqlParameter("@DoTuoi", string.IsNullOrEmpty(sp.DoTuoi) ? (object)DBNull.Value : sp.DoTuoi),
                new SqlParameter("@TenXuatXu", string.IsNullOrEmpty(sp.TenXuatXu) ? (object)DBNull.Value : sp.TenXuatXu),
                new SqlParameter("@Hang", string.IsNullOrEmpty(sp.Hang) ? (object)DBNull.Value : sp.Hang),
                new SqlParameter("@DonGia", sp.DonGia),
                new SqlParameter("@TonKho", sp.TonKho),
                new SqlParameter("@HinhAnh", string.IsNullOrEmpty(sp.HinhAnh) ? (object)DBNull.Value : sp.HinhAnh),
                new SqlParameter("@TrangThai", sp.TrangThai)
            };

            return Database.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Xóa sản phẩm (mặc định xóa mềm TrangThai = 0)
        /// </summary>
        public bool Xoa(string maSP, bool xoaMem = true)
        {
            if (xoaMem)
            {
                string query = "UPDATE SanPham SET TrangThai = 0 WHERE MaSP = @MaSP";
                SqlParameter[] parameters = { new SqlParameter("@MaSP", maSP) };
                return Database.ExecuteNonQuery(query, parameters) > 0;
            }
            else
            {
                string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                SqlParameter[] parameters = { new SqlParameter("@MaSP", maSP) };
                return Database.ExecuteNonQuery(query, parameters) > 0;
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo mã, tên hoặc hãng sản xuất
        /// </summary>
        public List<SanPhamDTO> TimKiem(string tuKhoa)
        {
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            string query = @"SELECT MaSP, MaLoai, TenSP, DoTuoi, TenXuatXu, Hang, DonGia, TonKho, HinhAnh, TrangThai 
                             FROM SanPham 
                             WHERE MaSP LIKE @TuKhoa OR TenSP LIKE @TuKhoa OR Hang LIKE @TuKhoa";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(DocSanPhamTuReader(reader));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Kiểm tra sản phẩm đã tồn tại theo mã chưa
        /// </summary>
        public bool KiemTraTonTai(string maSP)
        {
            string query = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";
            SqlParameter[] parameters = { new SqlParameter("@MaSP", maSP) };
            object res = Database.ExecuteScalar(query, parameters);
            return res != null && Convert.ToInt32(res) > 0;
        }

        /// <summary>
        /// Lấy DataTable sản phẩm phục vụ DataSource
        /// </summary>
        public DataTable LayDataTable()
        {
            string query = "SELECT MaSP, MaLoai, TenSP, DoTuoi, TenXuatXu, Hang, DonGia, TonKho, HinhAnh, TrangThai FROM SanPham";
            return Database.GetData(query);
        }

        private SanPhamDTO DocSanPhamTuReader(SqlDataReader reader)
        {
            return new SanPhamDTO
            {
                MaSP = reader["MaSP"].ToString().Trim(),
                MaLoai = reader["MaLoai"] != DBNull.Value ? reader["MaLoai"].ToString().Trim() : string.Empty,
                TenSP = reader["TenSP"].ToString(),
                DoTuoi = reader["DoTuoi"] != DBNull.Value ? reader["DoTuoi"].ToString() : string.Empty,
                TenXuatXu = reader["TenXuatXu"] != DBNull.Value ? reader["TenXuatXu"].ToString() : string.Empty,
                Hang = reader["Hang"] != DBNull.Value ? reader["Hang"].ToString() : string.Empty,
                DonGia = reader["DonGia"] != DBNull.Value ? Convert.ToDecimal(reader["DonGia"]) : 0,
                TonKho = reader["TonKho"] != DBNull.Value ? Convert.ToInt32(reader["TonKho"]) : 0,
                HinhAnh = reader["HinhAnh"] != DBNull.Value ? reader["HinhAnh"].ToString() : string.Empty,
                TrangThai = reader["TrangThai"] != DBNull.Value && Convert.ToBoolean(reader["TrangThai"])
            };
        }
    }
}
