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
    public class LoaiDoChoiDAL
    {
        public List<LoaiDoChoiDTO> LayDanhSach()
        {
            List<LoaiDoChoiDTO> list = new List<LoaiDoChoiDTO>();
            string query = "SELECT MaLoai, TenLoai, MoTa FROM LoaiDoChoi ORDER BY MaLoai";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LoaiDoChoiDTO
                        {
                            MaLoai = reader["MaLoai"].ToString().Trim(),
                            TenLoai = reader["TenLoai"].ToString(),
                            MoTa = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : string.Empty
                        });
                    }
                }
            }
            return list;
        }

        public LoaiDoChoiDTO LayTheoMa(string maLoai)
        {
            string query = "SELECT MaLoai, TenLoai, MoTa FROM LoaiDoChoi WHERE MaLoai = @MaLoai";
            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new LoaiDoChoiDTO
                        {
                            MaLoai = reader["MaLoai"].ToString().Trim(),
                            TenLoai = reader["TenLoai"].ToString(),
                            MoTa = reader["MoTa"] != DBNull.Value ? reader["MoTa"].ToString() : string.Empty
                        };
                    }
                }
            }
            return null;
        }

        public bool Them(LoaiDoChoiDTO loai)
        {
            string query = "INSERT INTO LoaiDoChoi (MaLoai, TenLoai, MoTa) VALUES (@MaLoai, @TenLoai, @MoTa)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLoai", loai.MaLoai),
                new SqlParameter("@TenLoai", loai.TenLoai),
                new SqlParameter("@MoTa", (object)loai.MoTa ?? DBNull.Value)
            };
            return Database.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool CapNhat(LoaiDoChoiDTO loai)
        {
            string query = "UPDATE LoaiDoChoi SET TenLoai = @TenLoai, MoTa = @MoTa WHERE MaLoai = @MaLoai";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLoai", loai.MaLoai),
                new SqlParameter("@TenLoai", loai.TenLoai),
                new SqlParameter("@MoTa", (object)loai.MoTa ?? DBNull.Value)
            };
            return Database.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Xoa(string maLoai)
        {
            string query = "DELETE FROM LoaiDoChoi WHERE MaLoai = @MaLoai";
            SqlParameter[] parameters = { new SqlParameter("@MaLoai", maLoai) };
            return Database.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool KiemTraTonTai(string maLoai)
        {
            string query = "SELECT COUNT(*) FROM LoaiDoChoi WHERE MaLoai = @MaLoai";
            SqlParameter[] parameters = { new SqlParameter("@MaLoai", maLoai) };
            object res = Database.ExecuteScalar(query, parameters);
            return res != null && Convert.ToInt32(res) > 0;
        }
    }
}
