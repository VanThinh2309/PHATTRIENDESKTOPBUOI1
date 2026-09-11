using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaLoai { get; set; }
        public string MaXuatXu { get; set; }
        public string MaDoTuoi { get; set; }
        public decimal DonGia { get; set; }
        public int TonKho { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }

        public SanPham()
        {

        }
        public SanPham(
            string maSP,
            string tenSP,
            string maLoai,
            string maXuatXu,
            string maDoTuoi,
            decimal donGia,
            int tonKho,
            string hinhAnh,
            bool trangThai)
        {
            MaSP = maSP;
            TenSP = tenSP;
            MaLoai = maLoai;
            MaXuatXu = maXuatXu;
            MaDoTuoi = maDoTuoi;
            DonGia = donGia;
            TonKho = tonKho;
            HinhAnh = hinhAnh;
            TrangThai = trangThai;
        }
    }
}
