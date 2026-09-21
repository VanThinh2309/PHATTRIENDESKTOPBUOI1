using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class ChiTietHoaDonDTO
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        // Thuộc tính tiện ích tính thành tiền
        public decimal ThanhTien => SoLuong * DonGia;

        // Thuộc tính tiện ích để hiển thị tên sản phẩm trên Grid nếu join
        public string TenSP { get; set; }

        public ChiTietHoaDonDTO()
        {
            SoLuong = 1;
            DonGia = 0;
        }

        public ChiTietHoaDonDTO(string maHD, string maSP, int soLuong, decimal donGia, string tenSP = null)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
            TenSP = tenSP;
        }
    }
}
