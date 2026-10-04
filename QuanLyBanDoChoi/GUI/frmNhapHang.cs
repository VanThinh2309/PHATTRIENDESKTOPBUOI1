using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanDoChoi.BUS;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.GUI
{
    public partial class frmNhapHang : Form
    {
        private readonly PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private readonly NhaCungCapBUS _nhaCungCapBUS = new NhaCungCapBUS();

        // Danh sách sản phẩm nguồn từ CSDL
        private List<SanPhamDTO> _danhSachSanPham = new List<SanPhamDTO>();

        // Danh sách chi tiết các mặt hàng chờ nhập trong phiếu hiện tại
        private BindingList<ChiTietPhieuNhapDTO> _danhSachChoNhap = new BindingList<ChiTietPhieuNhapDTO>();

        public frmNhapHang()
        {
            InitializeComponent();
            InitFormEvents();
        }

        private void InitFormEvents()
        {
            this.Load += frmNhapHang_Load;

            // Sự kiện chọn sản phẩm để gợi ý giá nhập
            this.cboSanPham.SelectedIndexChanged += cboSanPham_SelectedIndexChanged;

            // Sự kiện thay đổi số lượng hoặc đơn giá -> cập nhật tạm tính
            this.numSoLuong.ValueChanged += CapNhatTamTinh_Event;
            this.numGiaNhap.ValueChanged += CapNhatTamTinh_Event;

            // Nút thêm sản phẩm vào bảng
            this.btnThemDong.Click += btnThemDong_Click;

            // Nút bấm xóa sản phẩm trong DataGridView
            this.dgvChiTiet.CellContentClick += dgvChiTiet_CellContentClick;

            // Nút xác nhận nhập hàng
            this.button2.Click += btnXacNhanNhap_Click;

            // Nút hủy / đóng
            this.btnHuyNhapHang.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            // 1. Tự động sinh Mã phiếu nhập theo định dạng PNyyyyMMddHHmmss
            txtMaPN.Text = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            dtpNgayNhap.Value = DateTime.Now;

            // 2. Nạp danh sách Nhà cung cấp vào cboNhaCungCap
            LoadNhaCungCap();

            // 3. Nạp danh sách Sản phẩm vào cboSanPham
            LoadSanPham();

            // 4. Cấu hình DataGridView danh sách chờ nhập
            CauHinhDataGridView();

            // 5. Cập nhật nhãn tạm tính ban đầu
            CapNhatTamTinh();
            CapNhatTongKet();
        }

        /// <summary>
        /// Nạp danh sách Nhà cung cấp từ CSDL/BUS
        /// </summary>
        private void LoadNhaCungCap()
        {
            try
            {
                var dsNCC = _nhaCungCapBUS.LayDanhSach();
                cboNhaCungCap.DataSource = dsNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "MaNCC"; // ĐÃ SỬA: Lấy MaNCC thay vì TenNCC

                if (cboNhaCungCap.Items.Count > 0)
                {
                    cboNhaCungCap.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Nạp danh sách Sản phẩm hiện có từ CSDL/BUS
        /// </summary>
        private void LoadSanPham()
        {
            try
            {
                _danhSachSanPham = _sanPhamBUS.LayDanhSach() ?? new List<SanPhamDTO>();
                cboSanPham.DataSource = _danhSachSanPham;
                cboSanPham.DisplayMember = "TenSP";
                cboSanPham.ValueMember = "MaSP";

                if (cboSanPham.Items.Count > 0)
                {
                    cboSanPham.SelectedIndex = 0;
                    CapNhatGiaNhapGoiY();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Cấu hình hiển thị và mapping cột DataGridView
        /// </summary>
        private void CauHinhDataGridView()
        {
            dgvChiTiet.AutoGenerateColumns = false;
            colMaSP.DataPropertyName = nameof(ChiTietPhieuNhapDTO.MaSP);
            colTenSP.DataPropertyName = nameof(ChiTietPhieuNhapDTO.TenSP);
            colSoLuong.DataPropertyName = nameof(ChiTietPhieuNhapDTO.SoLuongNhap);
            colDonGiaNhap.DataPropertyName = nameof(ChiTietPhieuNhapDTO.DonGiaNhap);
            colThanhTien.DataPropertyName = nameof(ChiTietPhieuNhapDTO.ThanhTien);

            dgvChiTiet.DataSource = _danhSachChoNhap;
        }

        /// <summary>
        /// Gợi ý giá nhập tự động khi chọn sản phẩm
        /// Ưu tiên giá nhập cũ, nếu bằng 0 thì lấy 70% giá bán
        /// </summary>
        private void CapNhatGiaNhapGoiY()
        {
            if (cboSanPham.SelectedItem is SanPhamDTO sp)
            {
                decimal giaGoiY = 0;
                if (sp.GiaNhap > 0)
                {
                    giaGoiY = sp.GiaNhap;
                }
                else if (sp.DonGia > 0)
                {
                    giaGoiY = Math.Round(sp.DonGia * 0.7m, 0);
                }

                numGiaNhap.Value = giaGoiY;
                CapNhatTamTinh();
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatGiaNhapGoiY();
        }

        private void CapNhatTamTinh_Event(object sender, EventArgs e)
        {
            CapNhatTamTinh();
        }

        /// <summary>
        /// Cập nhật nhãn hiển thị thành tiền tạm tính = Số lượng * Giá nhập
        /// </summary>
        private void CapNhatTamTinh()
        {
            decimal tamTinh = numSoLuong.Value * numGiaNhap.Value;
            lblTamTinh.Text = $"Tạm tính: {tamTinh:N0} đ";
        }

        /// <summary>
        /// Thêm hoặc cộng dồn mặt hàng vào danh sách chờ nhập
        /// </summary>
        private void btnThemDong_Click(object sender, EventArgs e)
        {
            if (!(cboSanPham.SelectedItem is SanPhamDTO sp))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần nhập!", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = (int)numSoLuong.Value;
            decimal donGiaNhap = numGiaNhap.Value;

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0!", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (donGiaNhap < 0)
            {
                MessageBox.Show("Đơn giá nhập không được âm!", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem sản phẩm đã có trong danh sách chờ nhập chưa
            var existing = _danhSachChoNhap.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (existing != null)
            {
                existing.SoLuongNhap += soLuong;
                existing.DonGiaNhap = donGiaNhap; // Cập nhật đơn giá mới nhất
                _danhSachChoNhap.ResetBindings();
            }
            else
            {
                _danhSachChoNhap.Add(new ChiTietPhieuNhapDTO
                {
                    MaPN = txtMaPN.Text.Trim(),
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    SoLuongNhap = soLuong,
                    DonGiaNhap = donGiaNhap
                });
            }

            // Reset số lượng về 1 để nhập tiếp
            numSoLuong.Value = 1;

            CapNhatTongKet();
        }

        /// <summary>
        /// Xử lý bấm nút Xóa (❌) trên từng dòng sản phẩm thêm nhầm
        /// </summary>
        private void dgvChiTiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colXoa.Index)
            {
                if (e.RowIndex < _danhSachChoNhap.Count)
                {
                    var item = _danhSachChoNhap[e.RowIndex];
                    var confirm = MessageBox.Show($"Bạn có chắc chắn muốn bỏ sản phẩm '{item.TenSP}' khỏi danh sách chờ nhập?",
                                                 "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        _danhSachChoNhap.RemoveAt(e.RowIndex);
                        CapNhatTongKet();
                    }
                }
            }
        }

        /// <summary>
        /// Tính tổng số lượng và tổng tiền hàng dưới Footer
        /// </summary>
        private void CapNhatTongKet()
        {
            int tongSL = _danhSachChoNhap.Sum(x => x.SoLuongNhap);
            decimal tongTien = _danhSachChoNhap.Sum(x => x.ThanhTien);

            lblTongSoLuong.Text = tongSL.ToString("N0");
            lblTongTien.Text = $"{tongTien:N0} đ";
        }

        /// <summary>
        /// Xác nhận nhập hàng: kiểm tra danh sách, lưu vào CSDL, cộng dồn kho và đóng form
        /// </summary>
        private void btnXacNhanNhap_Click(object sender, EventArgs e)
        {
            if (_danhSachChoNhap == null || _danhSachChoNhap.Count == 0)
            {
                MessageBox.Show("Danh sách chờ nhập đang rỗng! Vui lòng thêm ít nhất 1 sản phẩm.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ĐÃ SỬA: Lấy chính xác Mã NCC và Tên NCC
            string maNCC = cboNhaCungCap.SelectedValue != null ? cboNhaCungCap.SelectedValue.ToString() : "";
            string tenNCC = cboNhaCungCap.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNCC))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập nhà cung cấp!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhaCungCap.Focus();
                return;
            }

            string maPN = txtMaPN.Text.Trim();
            if (string.IsNullOrWhiteSpace(maPN))
            {
                maPN = "PN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }

            // Đóng gói đối tượng phiếu nhập
            PhieuNhapDTO pn = new PhieuNhapDTO
            {
                MaPN = maPN,
                NgayNhap = dtpNgayNhap.Value,
                MaNCC = maNCC,          // ĐÃ SỬA: Gán Mã NCC ("NCC01") vào MaNCC
                NhaCungCap = tenNCC,    // ĐÃ SỬA: Gán Tên NCC ("Công ty TNHH Lego Việt Nam") vào NhaCungCap
                TongTien = _danhSachChoNhap.Sum(x => x.ThanhTien),
                GhiChu = txtGhiChu.Text.Trim(),
                NguoiLap = "Quản trị viên",
                DanhSachChiTiet = _danhSachChoNhap.ToList()
            };

            // Gọi BUS thực thi transaction
            if (_phieuNhapBUS.ThemPhieuNhap(pn, out string errorMessage))
            {
                MessageBox.Show("Nhập hàng thành công! Đã tự động cộng dồn tồn kho và cập nhật giá nhập cho các sản phẩm.",
                                "Thông Báo Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nhập hàng thất bại: " + errorMessage, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}