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
    public class NhaCungCapDAL
    {
        /// <summary>
        /// Lấy danh sách toàn bộ nhà cung cấp từ CSDL hoặc danh sách chuẩn
        /// </summary>
        public List<NhaCungCapDTO> LayDanhSach()
        {
            List<NhaCungCapDTO> list = new List<NhaCungCapDTO>();

            // 1. Thử lấy từ bảng NhaCungCap nếu có
            try
            {
                string query = "SELECT MaNCC, TenNCC, SDT, DiaChi FROM NhaCungCap ORDER BY TenNCC ASC";
                using (SqlConnection conn = Database.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new NhaCungCapDTO
                            {
                                MaNCC = reader["MaNCC"] != DBNull.Value ? reader["MaNCC"].ToString().Trim() : "",
                                TenNCC = reader["TenNCC"] != DBNull.Value ? reader["TenNCC"].ToString().Trim() : "",
                                SDT = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString().Trim() : "",
                                DiaChi = reader["DiaChi"] != DBNull.Value ? reader["DiaChi"].ToString().Trim() : ""
                            });
                        }
                    }
                }
            }
            catch
            {
                // Bỏ qua nếu bảng chưa tồn tại
            }

            // 2. Nếu danh sách rỗng, nạp danh sách nhà cung cấp mặc định uy tín
            if (list.Count == 0)
            {
                var defaultSuppliers = new List<NhaCungCapDTO>
                {
                    new NhaCungCapDTO("NCC001", "Công ty TNHH Đồ Chơi Thông Minh", "0901234567", "Hà Nội"),
                    new NhaCungCapDTO("NCC002", "Miniso Việt Nam", "0902345678", "TP. Hồ Chí Minh"),
                    new NhaCungCapDTO("NCC003", "LEGO Trading Việt Nam", "0903456789", "Đà Nẵng"),
                    new NhaCungCapDTO("NCC004", "Tomy Japan Distribution", "0904567890", "Hải Phòng"),
                    new NhaCungCapDTO("NCC005", "WinFun & Antona Toys", "0905678901", "Bình Dương"),
                    new NhaCungCapDTO("NCC006", "Mattel Disney & Barbie VN", "0906789012", "TP. Hồ Chí Minh"),
                    new NhaCungCapDTO("NCC007", "Gund Plushies Vietnam", "0907890123", "Hà Nội")
                };

                // Thử lưu vào CSDL nếu bảng đã có
                try
                {
                    foreach (var ncc in defaultSuppliers)
                    {
                        string insertSql = "IF NOT EXISTS (SELECT 1 FROM NhaCungCap WHERE MaNCC = @MaNCC) " +
                                          "INSERT INTO NhaCungCap (MaNCC, TenNCC, SDT, DiaChi) VALUES (@MaNCC, @TenNCC, @SDT, @DiaChi)";
                        SqlParameter[] p = new SqlParameter[]
                        {
                            new SqlParameter("@MaNCC", ncc.MaNCC),
                            new SqlParameter("@TenNCC", ncc.TenNCC),
                            new SqlParameter("@SDT", ncc.SDT),
                            new SqlParameter("@DiaChi", ncc.DiaChi)
                        };
                        Database.ExecuteNonQuery(insertSql, p);
                    }
                }
                catch { }

                list.AddRange(defaultSuppliers);
            }

            return list;
        }
    }
}
