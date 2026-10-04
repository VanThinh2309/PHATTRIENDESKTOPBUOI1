using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class PhieuNhapDTO
    {
        public string MaPN { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNCC { get; set; }
        public string NhaCungCap { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public string NguoiLap { get; set; }

        // Danh sách các sản phẩm chi tiết trong phiếu nhập
        public List<ChiTietPhieuNhapDTO> DanhSachChiTiet { get; set; }

        // Tổng số lượng các sản phẩm trong phiếu nhập
        public int TongSoLuong
        {
            get
            {
                if (DanhSachChiTiet == null || DanhSachChiTiet.Count == 0)
                    return _tongSoLuong;
                return DanhSachChiTiet.Sum(c => c.SoLuongNhap);
            }
            set
            {
                _tongSoLuong = value;
            }
        }
        private int _tongSoLuong;

        public PhieuNhapDTO()
        {
            MaPN = string.Empty;
            NgayNhap = DateTime.Now;
            MaNCC = string.Empty;
            NhaCungCap = string.Empty;
            TongTien = 0;
            GhiChu = string.Empty;
            NguoiLap = "Quản trị viên";
            DanhSachChiTiet = new List<ChiTietPhieuNhapDTO>();
            _tongSoLuong = 0;
        }

        public PhieuNhapDTO(string maPN, DateTime ngayNhap, string maNCC, string nhaCungCap, decimal tongTien, string ghiChu = "", string nguoiLap = "Quản trị viên")
        {
            MaPN = maPN;
            NgayNhap = ngayNhap;
            MaNCC = maNCC;
            NhaCungCap = nhaCungCap;
            TongTien = tongTien;
            GhiChu = ghiChu;
            NguoiLap = string.IsNullOrWhiteSpace(nguoiLap) ? "Quản trị viên" : nguoiLap;
            DanhSachChiTiet = new List<ChiTietPhieuNhapDTO>();
            _tongSoLuong = 0;
        }
    }
}
