using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class SanPhamDTO
    {
        public string MaSP { get; set; }
        public string MaLoai { get; set; }
        public string TenSP { get; set; }
        public string DoTuoi { get; set; }
        public string TenXuatXu { get; set; }
        public string Hang { get; set; }
        public decimal DonGia { get; set; }
        public int TonKho { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }

        public SanPhamDTO()
        {
            TrangThai = true;
            DonGia = 0;
            TonKho = 0;
        }

        public SanPhamDTO(
            string maSP,
            string maLoai,
            string tenSP,
            string doTuoi,
            string tenXuatXu,
            string hang,
            decimal donGia,
            int tonKho,
            string hinhAnh,
            bool trangThai = true)
        {
            MaSP = maSP;
            MaLoai = maLoai;
            TenSP = tenSP;
            DoTuoi = doTuoi;
            TenXuatXu = tenXuatXu;
            Hang = hang;
            DonGia = donGia;
            TonKho = tonKho;
            HinhAnh = hinhAnh;
            TrangThai = trangThai;
        }
    }

    // Alias hỗ trợ tương thích ngược
    public class SanPham : SanPhamDTO
    {
        public SanPham() : base() { }

        public SanPham(
            string maSP,
            string maLoai,
            string tenSP,
            string doTuoi,
            string tenXuatXu,
            string hang,
            decimal donGia,
            int tonKho,
            string hinhAnh,
            bool trangThai = true)
            : base(maSP, maLoai, tenSP, doTuoi, tenXuatXu, hang, donGia, tonKho, hinhAnh, trangThai)
        {
        }
    }
}
