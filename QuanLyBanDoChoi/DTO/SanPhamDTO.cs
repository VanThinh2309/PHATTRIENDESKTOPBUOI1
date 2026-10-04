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
        public string TenLoai { get; set; } // Thêm thuộc tính Tên Loại đồ chơi
        public string TenSP { get; set; }
        public string DoTuoi { get; set; }
        public string TenXuatXu { get; set; }
        public string Hang { get; set; }
        public decimal GiaNhap { get; set; } // Bổ sung: Giá vốn nhập kho
        public decimal DonGia { get; set; }
        public int TonKho { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }
        public string DanhSachKenhBan { get; set; }  // Chuỗi các kênh bán (VD: "Shopee, TikTok Shop")

        public SanPhamDTO()
        {
            TrangThai = true;
            DonGia = 0;
            GiaNhap = 0;
            TonKho = 0;
            TenLoai = string.Empty;

        }

        public SanPhamDTO(
            string maSP,
            string maLoai,
            string tenSP,
            string doTuoi,
            string tenXuatXu,
            string hang,
            decimal giaNhap,
            decimal donGia,
            int tonKho,
            string hinhAnh,
            bool trangThai = true,
            string tenLoai = "",
            string danhSachKenhBan = null)
        {
            MaSP = maSP;
            MaLoai = maLoai;
            TenSP = tenSP;
            DoTuoi = doTuoi;
            TenXuatXu = tenXuatXu;
            Hang = hang;
            GiaNhap = giaNhap;
            DonGia = donGia;
            TonKho = tonKho;
            HinhAnh = hinhAnh;
            TrangThai = trangThai;
            TenLoai = tenLoai;
            DanhSachKenhBan = danhSachKenhBan;
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
            decimal giaNhap,
            decimal donGia,
            int tonKho,
            string hinhAnh,
            bool trangThai = true,
            string tenLoai = "",
            string danhSachKenhBan = null)
            : base(maSP, maLoai, tenSP, doTuoi, tenXuatXu, hang, giaNhap ,donGia, tonKho, hinhAnh, trangThai, tenLoai, danhSachKenhBan)
        {
        }
    }
}
