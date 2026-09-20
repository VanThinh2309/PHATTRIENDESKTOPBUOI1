using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public int DiemTichLuy { get; set; }
        public string HangKhachHang { get; set; }
        public bool TrangThai { get; set; }

        public KhachHang()
        {
            DiemTichLuy = 0;
            HangKhachHang = "Đồng"; // Đồng bộ với DEFAULT N'Đồng' trong SQL
            TrangThai = true;
        }

        public KhachHang(
            string maKH,
            string tenKH,
            string sDT,
            int diemTichLuy,
            string hangKhachHang,
            bool trangThai)
        {
            MaKH = maKH;
            TenKH = tenKH;
            SDT = sDT;
            DiemTichLuy = diemTichLuy;
            HangKhachHang = hangKhachHang;
            TrangThai = trangThai;
        }
    }
}
