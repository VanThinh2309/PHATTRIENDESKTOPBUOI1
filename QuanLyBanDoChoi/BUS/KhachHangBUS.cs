using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanDoChoi.DAL;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.BUS
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAL _khachHangDAL;

        public KhachHangBUS()
        {
            _khachHangDAL = new KhachHangDAL();
        }

        public List<KhachHangDTO> LayDanhSach()
        {
            return _khachHangDAL.LayDanhSach();
        }

        public bool Them(KhachHangDTO kh, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (kh == null || string.IsNullOrWhiteSpace(kh.MaKH))
            {
                errorMessage = "Mã khách hàng không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(kh.TenKH))
            {
                errorMessage = "Tên khách hàng không được để trống!";
                return false;
            }

            try
            {
                return _khachHangDAL.Them(kh);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thêm khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool CapNhat(KhachHangDTO kh, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (kh == null || string.IsNullOrWhiteSpace(kh.MaKH))
            {
                errorMessage = "Mã khách hàng không hợp lệ!";
                return false;
            }

            try
            {
                return _khachHangDAL.CapNhat(kh);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(string maKH, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(maKH))
            {
                errorMessage = "Mã khách hàng không hợp lệ!";
                return false;
            }

            try
            {
                return _khachHangDAL.XoaMem(maKH.Trim());
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa khách hàng: " + ex.Message;
                return false;
            }
        }

        public List<KhachHangDTO> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return LayDanhSach();
            }
            return _khachHangDAL.TimKiem(tuKhoa.Trim());
        }

        public DataTable LayLichSuMuaHang(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH))
            {
                return new DataTable();
            }
            return _khachHangDAL.LayLichSuMuaHang(maKH.Trim());
        }
    }
}
