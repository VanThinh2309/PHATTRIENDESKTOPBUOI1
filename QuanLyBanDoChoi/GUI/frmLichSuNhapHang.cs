using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanDoChoi.BUS;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.GUI
{
    public partial class frmLichSuNhapHang : Form
    {
        private readonly PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
        private readonly NhaCungCapBUS _nhaCungCapBUS = new NhaCungCapBUS();

        private List<PhieuNhapDTO> _danhSachPhieuHienTai = new List<PhieuNhapDTO>();

        public frmLichSuNhapHang()
        {
            InitializeComponent();
            InitFormEvents();
        }

        private void InitFormEvents()
        {
            this.Load += frmLichSuNhapHang_Load;

            // Bộ lọc & thao tác
            this.btnLoc.Click += btnLoc_Click;
            this.btnTaiLai.Click += btnTaiLai_Click;
            this.btnInPhieu.Click += btnInPhieu_Click;
            this.btnXuatExcel.Click += btnXuatExcel_Click;

            // Tìm kiếm nhanh khi nhấn Enter
            this.txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLoc_Click(s, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };

            // Sự kiện chọn dòng Master để load bảng Detail
            this.dgvPhieuNhap.SelectionChanged += dgvPhieuNhap_SelectionChanged;

            // Format ngày giờ hiển thị trên bảng Master
            this.dgvPhieuNhap.CellFormatting += dgvPhieuNhap_CellFormatting;
        }

        private void frmLichSuNhapHang_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho bộ lọc ngày (30 ngày gần nhất)
            dtpTuNgay.Value = DateTime.Now.Date.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now.Date;

            // Nạp danh sách nhà cung cấp vào bộ lọc
            LoadDanhSachNhaCungCap();

            // Cấu hình DataGridView
            CauHinhMasterDataGridView();
            CauHinhDetailDataGridView();

            // Tải dữ liệu ban đầu
            TaiDuLieuPhieuNhap();
        }

        /// <summary>
        /// Nạp danh sách NCC vào ComboBox
        /// </summary>
        private void LoadDanhSachNhaCungCap()
        {
            try
            {
                var dsNCC = _nhaCungCapBUS.LayDanhSach() ?? new List<NhaCungCapDTO>();
                cboNhaCungCap.Items.Clear();
                cboNhaCungCap.Items.Add("Tất cả nhà cung cấp");

                foreach (var ncc in dsNCC)
                {
                    cboNhaCungCap.Items.Add(ncc.TenNCC);
                }

                cboNhaCungCap.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách nhà cung cấp: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CauHinhMasterDataGridView()
        {
            dgvPhieuNhap.AutoGenerateColumns = false;
            colMaPN.DataPropertyName = nameof(PhieuNhapDTO.MaPN);
            colNgayNhap.DataPropertyName = nameof(PhieuNhapDTO.NgayNhap);
            colNhaCungCap.DataPropertyName = nameof(PhieuNhapDTO.NhaCungCap);
            colNguoiLap.DataPropertyName = nameof(PhieuNhapDTO.NguoiLap);
            colTongSL.DataPropertyName = nameof(PhieuNhapDTO.TongSoLuong);
            colTongTien.DataPropertyName = nameof(PhieuNhapDTO.TongTien);
            colGhiChu.DataPropertyName = nameof(PhieuNhapDTO.GhiChu);
        }

        private void CauHinhDetailDataGridView()
        {
            dgvChiTietPhieu.AutoGenerateColumns = false;
            colDetailMaSP.DataPropertyName = nameof(ChiTietPhieuNhapDTO.MaSP);
            colDetailTenSP.DataPropertyName = nameof(ChiTietPhieuNhapDTO.TenSP);
            colDetailSoLuong.DataPropertyName = nameof(ChiTietPhieuNhapDTO.SoLuongNhap);
            colDetailDonGia.DataPropertyName = nameof(ChiTietPhieuNhapDTO.DonGiaNhap);
            colDetailThanhTien.DataPropertyName = nameof(ChiTietPhieuNhapDTO.ThanhTien);
        }

        private void dgvPhieuNhap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colNgayNhap.Index && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime dt))
                {
                    e.Value = dt.ToString("dd/MM/yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Tải danh sách phiếu nhập dựa theo các tiêu chí lọc
        /// </summary>
        private void TaiDuLieuPhieuNhap()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date;

                string ncc = cboNhaCungCap.SelectedIndex > 0 ? cboNhaCungCap.SelectedItem.ToString() : null;
                string keyword = txtTimKiem.Text.Trim();

                _danhSachPhieuHienTai = _phieuNhapBUS.LayDanhSachPhieuNhap(tuNgay, denNgay, ncc, keyword) ?? new List<PhieuNhapDTO>();

                dgvPhieuNhap.DataSource = null;
                dgvPhieuNhap.DataSource = _danhSachPhieuHienTai;

                // Cập nhật nhãn tổng kết
                int tongPhieu = _danhSachPhieuHienTai.Count;
                decimal tongTien = _danhSachPhieuHienTai.Sum(p => p.TongTien);
                int tongSL = _danhSachPhieuHienTai.Sum(p => p.TongSoLuong);
                lblTongKetPhieu.Text = $"Tổng số phiếu: {tongPhieu:N0}  |  Tổng số lượng: {tongSL:N0} SP  |  Tổng tiền: {tongTien:N0} đ";

                // Tự động load chi tiết của dòng đầu tiên nếu có
                if (_danhSachPhieuHienTai.Count > 0)
                {
                    LoadChiTietPhieuNhap(_danhSachPhieuHienTai[0].MaPN);
                }
                else
                {
                    dgvChiTietPhieu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử nhập hàng: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nạp chi tiết sản phẩm của một phiếu nhập xuống bảng Detail
        /// </summary>
        private void LoadChiTietPhieuNhap(string maPN)
        {
            if (string.IsNullOrWhiteSpace(maPN))
            {
                dgvChiTietPhieu.DataSource = null;
                return;
            }

            try
            {
                var listDetail = _phieuNhapBUS.LayChiTietPhieuNhap(maPN);
                dgvChiTietPhieu.DataSource = null;
                dgvChiTietPhieu.DataSource = listDetail;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết phiếu nhập: " + ex.Message, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null && dgvPhieuNhap.CurrentRow.DataBoundItem is PhieuNhapDTO pn)
            {
                LoadChiTietPhieuNhap(pn.MaPN);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Khoảng ngày lọc không hợp lệ (Từ ngày phải nhỏ hơn hoặc bằng Đến ngày)!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TaiDuLieuPhieuNhap();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now.Date.AddDays(-30);
            dtpDenNgay.Value = DateTime.Now.Date;
            cboNhaCungCap.SelectedIndex = 0;
            txtTimKiem.Text = string.Empty;
            TaiDuLieuPhieuNhap();
        }

        /// <summary>
        /// Xem và in phiếu nhập hàng được chọn
        /// </summary>
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow == null || !(dgvPhieuNhap.CurrentRow.DataBoundItem is PhieuNhapDTO pn))
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập trên bảng để in!", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var chiTietList = _phieuNhapBUS.LayChiTietPhieuNhap(pn.MaPN);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==========================================================================");
            sb.AppendLine("                   CỬA HÀNG ĐỒ CHƠI TRẺ EM TOYSHOP                        ");
            sb.AppendLine("                     PHIẾU NHẬP KHO HÀNG HÓA                              ");
            sb.AppendLine("==========================================================================");
            sb.AppendLine($" Mã Phiếu Nhập : {pn.MaPN}");
            sb.AppendLine($" Ngày Nhập     : {pn.NgayNhap:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($" Nhà Cung Cấp  : {pn.NhaCungCap}");
            sb.AppendLine($" Người Lập     : {pn.NguoiLap}");
            sb.AppendLine($" Ghi Chú       : {pn.GhiChu}");
            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine(string.Format("{0,-10} | {1,-28} | {2,8} | {3,12} | {4,14}", "MÃ SP", "TÊN SẢN PHẨM", "SỐ LƯỢNG", "ĐƠN GIÁ", "THÀNH TIỀN"));
            sb.AppendLine("--------------------------------------------------------------------------");

            int tongSL = 0;
            decimal tongTien = 0;

            foreach (var item in chiTietList)
            {
                tongSL += item.SoLuongNhap;
                tongTien += item.ThanhTien;
                string tenSpShort = item.TenSP.Length > 28 ? item.TenSP.Substring(0, 25) + "..." : item.TenSP;
                sb.AppendLine(string.Format("{0,-10} | {1,-28} | {2,8:N0} | {3,12:N0} | {4,14:N0} đ", 
                    item.MaSP, tenSpShort, item.SoLuongNhap, item.DonGiaNhap, item.ThanhTien));
            }

            sb.AppendLine("--------------------------------------------------------------------------");
            sb.AppendLine($" TỔNG SỐ LƯỢNG : {tongSL:N0} sản phẩm");
            sb.AppendLine($" TỔNG TIỀN     : {tongTien:N0} VNĐ");
            sb.AppendLine("==========================================================================");
            sb.AppendLine("       NGƯỜI GIAO HÀNG                        THỦ KHO KÝ NHẬN             ");
            sb.AppendLine("         (Ký, họ tên)                           (Ký, họ tên)              ");
            sb.AppendLine();

            using (Form previewForm = new Form())
            {
                previewForm.Text = $"Bản In Phiếu Nhập - {pn.MaPN}";
                previewForm.Size = new Size(720, 560);
                previewForm.StartPosition = FormStartPosition.CenterParent;
                previewForm.Font = new Font("Consolas", 10F, FontStyle.Regular);

                TextBox txtContent = new TextBox
                {
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Text = sb.ToString(),
                    BackColor = Color.White
                };

                Panel pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 50, BackColor = Color.FromArgb(245, 245, 245) };
                Button btnPrint = new Button
                {
                    Text = "In / Xuất File Text",
                    Dock = DockStyle.Right,
                    Width = 160,
                    BackColor = Color.FromArgb(0, 122, 255),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnPrint.Click += (btnS, btnE) =>
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "Text file (*.txt)|*.txt";
                        sfd.FileName = $"PhieuNhap_{pn.MaPN}.txt";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                            MessageBox.Show("Xuất bản in thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                };

                pnlBottom.Controls.Add(btnPrint);
                previewForm.Controls.Add(txtContent);
                previewForm.Controls.Add(pnlBottom);
                previewForm.ShowDialog();
            }
        }

        /// <summary>
        /// Xuất dữ liệu Master - Detail ra file Excel (CSV UTF-8 with BOM chuẩn Excel)
        /// </summary>
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (_danhSachPhieuHienTai == null || _danhSachPhieuHienTai.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu phiếu nhập để xuất file!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Chọn nơi lưu file Excel";
                sfd.Filter = "Tệp CSV (Excel) (*.csv)|*.csv|Tất cả tệp (*.*)|*.*";
                sfd.FileName = $"LichSuNhapHang_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csv = new StringBuilder();

                        // Tiêu đề báo cáo
                        csv.AppendLine("BÁO CÁO LỊCH SỬ NHẬP HÀNG KHO");
                        csv.AppendLine($"Thời gian xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        csv.AppendLine($"Khoảng thời gian: Từ {dtpTuNgay.Value:dd/MM/yyyy} Đến {dtpDenNgay.Value:dd/MM/yyyy}");
                        csv.AppendLine();

                        // Header bảng Master
                        csv.AppendLine("Mã Phiếu,Ngày Nhập,Nhà Cung Cấp,Người Lập,Tổng SL,Tổng Tiền,Ghi Chú");

                        foreach (var pn in _danhSachPhieuHienTai)
                        {
                            string ngay = pn.NgayNhap.ToString("dd/MM/yyyy HH:mm");
                            string ncc = $"\"{pn.NhaCungCap?.Replace("\"", "\"\"")}\"";
                            string nguoiLap = $"\"{pn.NguoiLap?.Replace("\"", "\"\"")}\"";
                            string ghiChu = $"\"{pn.GhiChu?.Replace("\"", "\"\"")}\"";

                            csv.AppendLine($"{pn.MaPN},{ngay},{ncc},{nguoiLap},{pn.TongSoLuong},{pn.TongTien},{ghiChu}");

                            // Đính kèm chi tiết từng sản phẩm bên dưới mỗi phiếu
                            var details = _phieuNhapBUS.LayChiTietPhieuNhap(pn.MaPN);
                            if (details != null && details.Count > 0)
                            {
                                csv.AppendLine(",,-> Chi tiết mã SP,Tên sản phẩm,Số lượng nhập,Đơn giá nhập,Thành tiền");
                                foreach (var d in details)
                                {
                                    string tenSp = $"\"{d.TenSP?.Replace("\"", "\"\"")}\"";
                                    csv.AppendLine($",,{d.MaSP},{tenSp},{d.SoLuongNhap},{d.DonGiaNhap},{d.ThanhTien}");
                                }
                                csv.AppendLine();
                            }
                        }

                        // Ghi file với UTF8 có BOM để Microsoft Excel tự nhận diện font tiếng Việt không bị lỗi font
                        File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.UTF8);

                        var res = MessageBox.Show("Xuất file Excel thành công! Bạn có muốn mở file ngay không?", 
                                                 "Thông Báo Thành Công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (res == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
