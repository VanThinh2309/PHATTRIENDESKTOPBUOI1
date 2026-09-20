using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi
{
    internal class Database
    {
        // Chuỗi kết nối đến SQL Server
        private static string connectionString = @"Data Source=DESKTOP-0J2K7F9\SQLEXPRESS;Initial Catalog=QuanLyBanDoChoi;Integrated Security=True";

        /// <summary>
        /// Lấy dữ liệu trả về dạng DataTable (SELECT)
        /// </summary>
        public static DataTable GetData(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Thực thi các lệnh INSERT, UPDATE, DELETE (Trả về số dòng bị ảnh hưởng)
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }

        /// <summary>
        /// Thực thi lấy về giá trị đơn duy nhất (COUNT, SUM, MAX, MIN, Hoặc lấy ID vừa tạo)
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }
    }
}
