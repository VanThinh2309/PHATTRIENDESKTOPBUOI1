using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanDoChoi.DAL;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL _hoaDonDAL;

        public HoaDonBUS()
        {
            _hoaDonDAL = new HoaDonDAL();
        }

        public List<HoaDonDTO> LayDanhSach(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            return _hoaDonDAL.LayDanhSach(tuNgay, denNgay);
        }

        public HoaDonDTO LayTheoMa(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD)) return null;
            return _hoaDonDAL.LayTheoMa(maHD.Trim());
        }

        public List<ChiTietHoaDonDTO> LayChiTietTheoHoaDon(string maHD)
        {
            if (string.IsNullOrWhiteSpace(maHD)) return new List<ChiTietHoaDonDTO>();
            return _hoaDonDAL.LayChiTietTheoHoaDon(maHD.Trim());
        }

        public bool LapHoaDon(HoaDonDTO hd, List<ChiTietHoaDonDTO> chiTiets, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (hd == null || string.IsNullOrWhiteSpace(hd.MaHD))
            {
                errorMessage = "Mã hóa đơn không được để trống!";
                return false;
            }
            if (chiTiets == null || chiTiets.Count == 0)
            {
                errorMessage = "Hóa đơn phải có ít nhất 1 sản phẩm!";
                return false;
            }

            // Tính lại tổng tiền cho an toàn
            decimal tongTien = chiTiets.Sum(c => c.SoLuong * c.DonGia);
            hd.TongTien = tongTien;

            try
            {
                return _hoaDonDAL.ThemHoaDon(hd, chiTiets);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi lập hóa đơn: " + ex.Message;
                return false;
            }
        }

        public bool CapNhatTrangThai(string maHD, string trangThaiMoi, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(maHD))
            {
                errorMessage = "Mã hóa đơn không hợp lệ!";
                return false;
            }

            try
            {
                return _hoaDonDAL.CapNhatTrangThai(maHD.Trim(), trangThaiMoi);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật trạng thái hóa đơn: " + ex.Message;
                return false;
            }
        }
    }
}
