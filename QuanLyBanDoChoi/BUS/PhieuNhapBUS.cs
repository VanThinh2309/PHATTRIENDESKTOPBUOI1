using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanDoChoi.DAL;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.BUS
{
    public class PhieuNhapBUS
    {
        private readonly PhieuNhapDAL _phieuNhapDAL;

        public PhieuNhapBUS()
        {
            _phieuNhapDAL = new PhieuNhapDAL();
        }

        public PhieuNhapBUS(PhieuNhapDAL phieuNhapDAL)
        {
            _phieuNhapDAL = phieuNhapDAL ?? new PhieuNhapDAL();
        }

        /// <summary>
        /// Sinh mã phiếu nhập tự động theo định dạng PNyyyyMMddHHmmss
        /// </summary>
        public string TaoMaPhieuNhapMoi()
        {
            return _phieuNhapDAL.TaoMaPhieuNhapTheoThoiGian();
        }

        /// <summary>
        /// Validate logic nghiệp vụ và lưu phiếu nhập kèm danh sách chi tiết
        /// </summary>
        public bool ThemPhieuNhap(PhieuNhapDTO pn, List<ChiTietPhieuNhapDTO> listCT, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (pn == null)
            {
                errorMessage = "Thông tin phiếu nhập không hợp lệ!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(pn.MaPN))
            {
                errorMessage = "Mã phiếu nhập không được để trống!";
                return false;
            }

            if (listCT == null || listCT.Count == 0)
            {
                listCT = pn.DanhSachChiTiet;
            }

            if (listCT == null || listCT.Count == 0)
            {
                errorMessage = "Vui lòng chọn ít nhất 1 sản phẩm vào danh sách chờ nhập!";
                return false;
            }

            // Validate từng mặt hàng nhập
            foreach (var item in listCT)
            {
                if (string.IsNullOrWhiteSpace(item.MaSP))
                {
                    errorMessage = "Mã sản phẩm trong chi tiết không hợp lệ!";
                    return false;
                }

                if (item.SoLuongNhap <= 0)
                {
                    errorMessage = $"Số lượng nhập của sản phẩm '{item.TenSP}' phải lớn hơn 0!";
                    return false;
                }

                if (item.DonGiaNhap < 0)
                {
                    errorMessage = $"Đơn giá nhập của sản phẩm '{item.TenSP}' không được âm!";
                    return false;
                }
            }

            // Gán lại danh sách chi tiết vào DTO
            pn.DanhSachChiTiet = listCT;
            pn.TongTien = listCT.Sum(c => c.ThanhTien);

            // Gọi DAL thực thi lưu vào CSDL
            return _phieuNhapDAL.ThemPhieuNhap(pn, listCT, out errorMessage);
        }

        /// <summary>
        /// Validate logic nghiệp vụ và lưu phiếu nhập
        /// </summary>
        public bool ThemPhieuNhap(PhieuNhapDTO pn, out string errorMessage)
        {
            return ThemPhieuNhap(pn, pn?.DanhSachChiTiet, out errorMessage);
        }

        /// <summary>
        /// Lấy toàn bộ danh sách phiếu nhập
        /// </summary>
        public List<PhieuNhapDTO> LayDanhSach()
        {
            return _phieuNhapDAL.LayDanhSach();
        }

        /// <summary>
        /// Lấy danh sách phiếu nhập theo bộ lọc
        /// </summary>
        public List<PhieuNhapDTO> LayDanhSachPhieuNhap(DateTime tuNgay, DateTime denNgay, string maNCC, string keyword)
        {
            return _phieuNhapDAL.LayDanhSachPhieuNhap(tuNgay, denNgay, maNCC, keyword);
        }

        /// <summary>
        /// Lấy chi tiết các sản phẩm trong phiếu nhập
        /// </summary>
        public List<ChiTietPhieuNhapDTO> LayChiTietPhieuNhap(string maPN)
        {
            if (string.IsNullOrWhiteSpace(maPN))
            {
                return new List<ChiTietPhieuNhapDTO>();
            }
            return _phieuNhapDAL.LayChiTietPhieuNhap(maPN);
        }
    }
}
