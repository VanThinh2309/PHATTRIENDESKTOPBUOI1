using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi
{
    internal class DSKH
    {
        // Thay chuỗi kết nối phù hợp với máy của bạn
        private string connectionString = @"Data Source=.;Initial Catalog=QuanLyBanDoChoi;Integrated Security=True";

        // 1. Lấy tất cả khách hàng chưa bị xóa (Soft-Delete)
        public List<KhachHang> LayDanhSach()
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = "SELECT MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai FROM KhachHang WHERE TrangThai = 1";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KhachHang kh = new KhachHang
                    {
                        MaKH = reader["MaKH"].ToString(),
                        TenKH = reader["TenKH"].ToString(),
                        SDT = reader["SDT"].ToString(),
                        DiemTichLuy = Convert.ToInt32(reader["DiemTichLuy"]),
                        HangKhachHang = reader["HangKhachHang"].ToString(),
                        TrangThai = Convert.ToBoolean(reader["TrangThai"])
                    };
                    list.Add(kh);
                }
            }
            return list;
        }

        // 2. Thêm khách hàng mới
        public bool Them(KhachHang kh)
        {
            string query = @"INSERT INTO KhachHang (MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai) 
                            VALUES (@MaKH, @TenKH, @SDT, @DiemTichLuy, @HangKhachHang, 1)";

            using (SqlConnection conn = new SqlConnection(connectionString))
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
        public bool CapNhat(KhachHang kh)
        {
            string query = @"UPDATE KhachHang 
                            SET TenKH = @TenKH, SDT = @SDT 
                            WHERE MaKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(connectionString))
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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 5. Tìm kiếm khách hàng theo Tên, SDT hoặc Mã KH
        public List<KhachHang> TimKiem(string tuKhoa)
        {
            List<KhachHang> list = new List<KhachHang>();
            string query = @"SELECT MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai 
                            FROM KhachHang 
                            WHERE TrangThai = 1 AND (TenKH LIKE @TuKhoa OR SDT LIKE @TuKhoa OR MaKH LIKE @TuKhoa)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    KhachHang kh = new KhachHang
                    {
                        MaKH = reader["MaKH"].ToString(),
                        TenKH = reader["TenKH"].ToString(),
                        SDT = reader["SDT"].ToString(),
                        DiemTichLuy = Convert.ToInt32(reader["DiemTichLuy"]),
                        HangKhachHang = reader["HangKhachHang"].ToString(),
                        TrangThai = Convert.ToBoolean(reader["TrangThai"])
                    };
                    list.Add(kh);
                }
            }
            return list;
        }

        // 6. Lấy Lịch sử mua hàng theo Mã khách hàng (Đã cập nhật theo ERD mới)
        public DataTable LayLichSuMuaHang(string maKH)
        {
            DataTable dt = new DataTable();
            string query = @"SELECT MaHD, NgayLap, MaNenTang, GhiChu, PhuongThucThanhToan, TongTien, TrangThai, DiaChi, DonViVanChuyen 
                            FROM HoaDon 
                            WHERE MaKH = @MaKH 
                            ORDER BY NgayLap DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKH);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
