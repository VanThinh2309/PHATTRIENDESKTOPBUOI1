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
    public class NenTangDAL
    {
        public List<NenTangDTO> LayDanhSach()
        {
            List<NenTangDTO> list = new List<NenTangDTO>();
            string query = "SELECT MaNenTang, TenNenTang FROM NenTang ORDER BY MaNenTang";

            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NenTangDTO
                        {
                            MaNenTang = reader["MaNenTang"].ToString().Trim(),
                            TenNenTang = reader["TenNenTang"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public NenTangDTO LayTheoMa(string maNenTang)
        {
            string query = "SELECT MaNenTang, TenNenTang FROM NenTang WHERE MaNenTang = @MaNenTang";
            using (SqlConnection conn = Database.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNenTang", maNenTang);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NenTangDTO
                        {
                            MaNenTang = reader["MaNenTang"].ToString().Trim(),
                            TenNenTang = reader["TenNenTang"].ToString()
                        };
                    }
                }
            }
            return null;
        }
    }
}
