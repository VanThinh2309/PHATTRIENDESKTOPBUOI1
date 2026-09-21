using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class HoaDonDTO
    {
        public string MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaKH { get; set; }
        public string MaNenTang { get; set; }
        public string GhiChu { get; set; }
        public decimal TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public string TrangThai { get; set; }
        public string DiaChi { get; set; }
        public string DonViVanChuyen { get; set; }

        public HoaDonDTO()
        {
            NgayLap = DateTime.Now;
            TongTien = 0;
            PhuongThucThanhToan = "Tiền mặt";
            TrangThai = "Đang xử lý";
        }

        public HoaDonDTO(
            string maHD,
            DateTime ngayLap,
            string maKH,
            string maNenTang,
            string ghiChu,
            decimal tongTien,
            string phuongThucThanhToan,
            string trangThai,
            string diaChi = null,
            string donViVanChuyen = null)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            MaKH = maKH;
            MaNenTang = maNenTang;
            GhiChu = ghiChu;
            TongTien = tongTien;
            PhuongThucThanhToan = phuongThucThanhToan;
            TrangThai = trangThai;
            DiaChi = diaChi;
            DonViVanChuyen = donViVanChuyen;
        }
    }
}
