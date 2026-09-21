using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanDoChoi.DAL;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.BUS
{
    public class LoaiDoChoiBUS
    {
        private readonly LoaiDoChoiDAL _loaiDoChoiDAL;

        public LoaiDoChoiBUS()
        {
            _loaiDoChoiDAL = new LoaiDoChoiDAL();
        }

        public List<LoaiDoChoiDTO> LayDanhSach()
        {
            return _loaiDoChoiDAL.LayDanhSach();
        }

        public LoaiDoChoiDTO LayTheoMa(string maLoai)
        {
            if (string.IsNullOrWhiteSpace(maLoai)) return null;
            return _loaiDoChoiDAL.LayTheoMa(maLoai.Trim());
        }

        public bool Them(LoaiDoChoiDTO loai, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (loai == null || string.IsNullOrWhiteSpace(loai.MaLoai))
            {
                errorMessage = "Mã loại đồ chơi không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(loai.TenLoai))
            {
                errorMessage = "Tên loại đồ chơi không được để trống!";
                return false;
            }
            if (_loaiDoChoiDAL.KiemTraTonTai(loai.MaLoai.Trim()))
            {
                errorMessage = $"Mã loại '{loai.MaLoai}' đã tồn tại!";
                return false;
            }

            try
            {
                return _loaiDoChoiDAL.Them(loai);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thêm loại đồ chơi: " + ex.Message;
                return false;
            }
        }

        public bool CapNhat(LoaiDoChoiDTO loai, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (loai == null || string.IsNullOrWhiteSpace(loai.MaLoai))
            {
                errorMessage = "Mã loại đồ chơi không hợp lệ!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(loai.TenLoai))
            {
                errorMessage = "Tên loại không được để trống!";
                return false;
            }

            try
            {
                return _loaiDoChoiDAL.CapNhat(loai);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật loại đồ chơi: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(string maLoai, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(maLoai))
            {
                errorMessage = "Mã loại đồ chơi không hợp lệ!";
                return false;
            }

            try
            {
                return _loaiDoChoiDAL.Xoa(maLoai.Trim());
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa loại đồ chơi (có thể do đang có sản phẩm thuộc loại này): " + ex.Message;
                return false;
            }
        }
    }
}
