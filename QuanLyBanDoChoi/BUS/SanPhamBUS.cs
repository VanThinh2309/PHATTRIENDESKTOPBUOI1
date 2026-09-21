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
    public class SanPhamBUS
    {
        private readonly SanPhamDAL _sanPhamDAL;

        public SanPhamBUS()
        {
            _sanPhamDAL = new SanPhamDAL();
        }

        public SanPhamBUS(SanPhamDAL sanPhamDAL)
        {
            _sanPhamDAL = sanPhamDAL ?? new SanPhamDAL();
        }

        /// <summary>
        /// Lấy toàn bộ danh sách sản phẩm
        /// </summary>
        public List<SanPhamDTO> LayDanhSach(bool chiLayConBan = false)
        {
            return _sanPhamDAL.LayDanhSach(chiLayConBan);
        }

        /// <summary>
        /// Lấy thông tin chi tiết một sản phẩm theo mã
        /// </summary>
        public SanPhamDTO LayChiTiet(string maSP)
        {
            if (string.IsNullOrWhiteSpace(maSP))
            {
                return null;
            }
            return _sanPhamDAL.LayChiTiet(maSP.Trim());
        }

        /// <summary>
        /// Lấy DataTable sản phẩm phục vụ DataSource
        /// </summary>
        public DataTable LayDataTable()
        {
            return _sanPhamDAL.LayDataTable();
        }

        /// <summary>
        /// Thêm sản phẩm mới kèm kiểm tra logic nghiệp vụ
        /// </summary>
        public bool Them(SanPhamDTO sp, out string errorMessage)
        {
            errorMessage = string.Empty;

            // 1. Kiểm tra đối tượng null
            if (sp == null)
            {
                errorMessage = "Thông tin sản phẩm không hợp lệ!";
                return false;
            }

            // 2. Validate Mã sản phẩm
            if (string.IsNullOrWhiteSpace(sp.MaSP))
            {
                errorMessage = "Mã sản phẩm không được để trống!";
                return false;
            }
            sp.MaSP = sp.MaSP.Trim();
            if (sp.MaSP.Length > 10)
            {
                errorMessage = "Mã sản phẩm không được vượt quá 10 ký tự!";
                return false;
            }

            // 3. Validate Tên sản phẩm
            if (string.IsNullOrWhiteSpace(sp.TenSP))
            {
                errorMessage = "Tên sản phẩm không được để trống!";
                return false;
            }
            sp.TenSP = sp.TenSP.Trim();

            // 4. Validate Đơn giá
            if (sp.DonGia < 0)
            {
                errorMessage = "Đơn giá sản phẩm phải lớn hơn hoặc bằng 0!";
                return false;
            }

            // 5. Validate Số lượng tồn kho
            if (sp.TonKho < 0)
            {
                errorMessage = "Số lượng tồn kho không được âm!";
                return false;
            }

            // 6. Kiểm tra trùng mã sản phẩm
            if (_sanPhamDAL.KiemTraTonTai(sp.MaSP))
            {
                errorMessage = $"Mã sản phẩm '{sp.MaSP}' đã tồn tại trong hệ thống!";
                return false;
            }

            // 7. Gọi DAL để lưu vào CSDL
            try
            {
                bool ketQua = _sanPhamDAL.Them(sp);
                if (!ketQua)
                {
                    errorMessage = "Không thể thêm sản phẩm vào cơ sở dữ liệu!";
                }
                return ketQua;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thêm sản phẩm: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm kèm kiểm tra nghiệp vụ
        /// </summary>
        public bool CapNhat(SanPhamDTO sp, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (sp == null || string.IsNullOrWhiteSpace(sp.MaSP))
            {
                errorMessage = "Mã sản phẩm không hợp lệ!";
                return false;
            }

            sp.MaSP = sp.MaSP.Trim();

            if (string.IsNullOrWhiteSpace(sp.TenSP))
            {
                errorMessage = "Tên sản phẩm không được để trống!";
                return false;
            }

            if (sp.DonGia < 0)
            {
                errorMessage = "Đơn giá sản phẩm phải lớn hơn hoặc bằng 0!";
                return false;
            }

            if (sp.TonKho < 0)
            {
                errorMessage = "Số lượng tồn kho không được âm!";
                return false;
            }

            if (!_sanPhamDAL.KiemTraTonTai(sp.MaSP))
            {
                errorMessage = $"Không tìm thấy mã sản phẩm '{sp.MaSP}' để cập nhật!";
                return false;
            }

            try
            {
                bool ketQua = _sanPhamDAL.CapNhat(sp);
                if (!ketQua)
                {
                    errorMessage = "Cập nhật sản phẩm thất bại!";
                }
                return ketQua;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật sản phẩm: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa sản phẩm (mặc định xóa mềm)
        /// </summary>
        public bool Xoa(string maSP, out string errorMessage, bool xoaMem = true)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(maSP))
            {
                errorMessage = "Mã sản phẩm không hợp lệ!";
                return false;
            }

            maSP = maSP.Trim();

            if (!_sanPhamDAL.KiemTraTonTai(maSP))
            {
                errorMessage = $"Sản phẩm có mã '{maSP}' không tồn tại!";
                return false;
            }

            try
            {
                bool ketQua = _sanPhamDAL.Xoa(maSP, xoaMem);
                if (!ketQua)
                {
                    errorMessage = "Thao tác xóa sản phẩm không thành công!";
                }
                return ketQua;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa sản phẩm: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo từ khóa
        /// </summary>
        public List<SanPhamDTO> TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return LayDanhSach();
            }
            return _sanPhamDAL.TimKiem(tuKhoa.Trim());
        }
    }
}
