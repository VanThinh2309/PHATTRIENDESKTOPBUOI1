using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class ChiTietPhieuNhapDTO
    {
        public string MaPN { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; } // Thuộc tính bổ trợ hiển thị trên DataGridView
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }

        // Thành tiền tự động tính bằng Số lượng * Đơn giá
        public decimal ThanhTien
        {
            get { return SoLuongNhap * DonGiaNhap; }
        }

        public ChiTietPhieuNhapDTO()
        {
            MaPN = string.Empty;
            MaSP = string.Empty;
            TenSP = string.Empty;
            SoLuongNhap = 0;
            DonGiaNhap = 0;
        }

        public ChiTietPhieuNhapDTO(string maPN, string maSP, string tenSP, int soLuongNhap, decimal donGiaNhap)
        {
            MaPN = maPN;
            MaSP = maSP;
            TenSP = tenSP;
            SoLuongNhap = soLuongNhap;
            DonGiaNhap = donGiaNhap;
        }
    }
}
