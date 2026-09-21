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
    public class KhachHangDAL
    {
        // 1. Lấy tất cả khách hàng chưa bị xóa (Soft-Delete)
        public List<KhachHangDTO> LayDanhSach()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = "SELECT MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai FROM KhachHang WHERE TrangThai = 1";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhachHangDTO kh = new KhachHangDTO
                        {
                            MaKH = reader["MaKH"].ToString().Trim(),
                            TenKH = reader["TenKH"].ToString(),
                            SDT = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : string.Empty,
                            DiemTichLuy = reader["DiemTichLuy"] != DBNull.Value ? Convert.ToInt32(reader["DiemTichLuy"]) : 0,
                            HangKhachHang = reader["HangKhachHang"] != DBNull.Value ? reader["HangKhachHang"].ToString() : "Đồng",
                            TrangThai = reader["TrangThai"] != DBNull.Value && Convert.ToBoolean(reader["TrangThai"])
                        };
                        list.Add(kh);
                    }
                }
            }
            return list;
        }

        // 2. Thêm khách hàng mới
        public bool Them(KhachHangDTO kh)
        {
            string query = @"INSERT INTO KhachHang (MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai) 
                            VALUES (@MaKH, @TenKH, @SDT, @DiemTichLuy, @HangKhachHang, 1)";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@SDT", (object)kh.SDT ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DiemTichLuy", kh.DiemTichLuy);
                cmd.Parameters.AddWithValue("@HangKhachHang", kh.HangKhachHang ?? "Đồng");

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. Cập nhật thông tin khách hàng
        public bool CapNhat(KhachHangDTO kh)
        {
            string query = @"UPDATE KhachHang 
                            SET TenKH = @TenKH, SDT = @SDT 
                            WHERE MaKH = @MaKH";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                cmd.Parameters.AddWithValue("@TenKH", kh.TenKH);
                cmd.Parameters.AddWithValue("@SDT", (object)kh.SDT ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4. Xóa mềm khách hàng (Đổi TrangThai = 0 chứ không DELETE)
        public bool XoaMem(string maKH)
        {
            string query = "UPDATE KhachHang SET TrangThai = 0 WHERE MaKH = @MaKH";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 5. Tìm kiếm khách hàng theo Tên, SDT hoặc Mã KH
        public List<KhachHangDTO> TimKiem(string tuKhoa)
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = @"SELECT MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai 
                            FROM KhachHang 
                            WHERE TrangThai = 1 AND (TenKH LIKE @TuKhoa OR SDT LIKE @TuKhoa OR MaKH LIKE @TuKhoa)";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KhachHangDTO kh = new KhachHangDTO
                        {
                            MaKH = reader["MaKH"].ToString().Trim(),
                            TenKH = reader["TenKH"].ToString(),
                            SDT = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : string.Empty,
                            DiemTichLuy = reader["DiemTichLuy"] != DBNull.Value ? Convert.ToInt32(reader["DiemTichLuy"]) : 0,
                            HangKhachHang = reader["HangKhachHang"] != DBNull.Value ? reader["HangKhachHang"].ToString() : "Đồng",
                            TrangThai = reader["TrangThai"] != DBNull.Value && Convert.ToBoolean(reader["TrangThai"])
                        };
                        list.Add(kh);
                    }
                }
            }
            return list;
        }

        // 6. Lấy Lịch sử mua hàng theo Mã khách hàng
        public DataTable LayLichSuMuaHang(string maKH)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT MaHD, NgayLap, MaNenTang, GhiChu, PhuongThucThanhToan, TongTien, TrangThai, DiaChi, DonViVanChuyen 
                            FROM HoaDon 
                            WHERE MaKH = @MaKH 
                            ORDER BY NgayLap DESC";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }

    // Alias hỗ trợ tương thích ngược với tên lớp DSKH cũ
    public class DSKH : KhachHangDAL { }
}
