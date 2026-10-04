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
    public partial class UC_SanPham : UserControl
    {
        // Khởi tạo tầng nghiệp vụ BUS
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();

        // Danh sách dữ liệu gốc lấy từ Database
        private List<SanPhamDTO> _danhSachHienTai = new List<SanPhamDTO>();

        // Text gợi ý tìm kiếm
        private const string PLACEHOLDER_TEXT = "Tìm theo mã, tên sản phẩm...";

        // Mã danh mục đang được lọc trên panel5 ("ALL" là tất cả)
        private string _maLoaiDangChon = "ALL";

        // Bộ lọc nâng cao hiện tại
        private FilterModel _currentFilter = new FilterModel();

        public UC_SanPham()
        {
            InitializeComponent();

        }

        

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            CauHinhDataGridView();
            ChuanHoaFontVaNut();
            CapNhatTagNutDanhMuc();
            DangKySuKienLocLoai();
            LoadDanhSachSanPham();
        }

        /// <summary>
        /// Chuẩn hóa toàn bộ Font chữ sang Times New Roman và nút bấm phẳng góc vuông
        /// </summary>
        private void ChuanHoaFontVaNut()
        {
            this.Font = new Font("Times New Roman", 10F, FontStyle.Regular);

            // Nút thao tác chính (Height = 35px, Top = 46px, Times New Roman 10pt Bold, Flat)
            Button[] mainButtons = { btnThem, btnNhapHang, btnLichSuNhap, btnLoc };
            foreach (var btn in mainButtons)
            {
                if (btn != null)
                {
                    btn.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Height = 35;
                    btn.Top = 46;
                }
            }

            // Nút Sửa / Xóa nhanh trên panel Quick Access (Height = 35px)
            if (btnSuaNhanh != null)
            {
                btnSuaNhanh.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
                btnSuaNhanh.FlatStyle = FlatStyle.Flat;
                btnSuaNhanh.FlatAppearance.BorderSize = 0;
                btnSuaNhanh.Height = 35;
            }
            if (btnXoaNhanh != null)
            {
                btnXoaNhanh.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
                btnXoaNhanh.FlatStyle = FlatStyle.Flat;
                btnXoaNhanh.FlatAppearance.BorderSize = 0;
                btnXoaNhanh.Height = 35;
            }

            // Hàng nút lọc danh mục trên panel5 (Height = 30px, Top = 8px, Times New Roman 9.75pt, Flat)
            if (panel5 != null)
            {
                foreach (Control ctrl in panel5.Controls)
                {
                    if (ctrl is Button btn)
                    {
                        btn.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 1;
                        btn.Height = 30;
                        btn.Top = 8;
                    }
                }
            }
        }

        /// <summary>
        /// Tự động gán Mã Loại (Tag) dựa vào Tên chữ hiển thị trên mặt nút bấm
        /// Giúp khắc phục triệt để lỗi bấm Xe cộ ra Trí tuệ L001
        /// </summary>
        private void CapNhatTagNutDanhMuc()
        {
            if (panel5 == null) return;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl is Button btn)
                {
                    string tenNut = btn.Text.Trim().ToLower();

                    if (tenNut.Contains("tất cả"))
                        btn.Tag = "ALL";
                    else if (tenNut.Contains("xe"))
                        btn.Tag = "L003"; // Xe cộ & Mô hình điều khiển
                    else if (tenNut.Contains("búp bê"))
                        btn.Tag = "L005"; // Búp bê
                    else if (tenNut.Contains("xếp hình"))
                        btn.Tag = "L004"; // Lắp ráp & Xếp hình
                    else if (tenNut.Contains("trí tuệ"))
                        btn.Tag = "L001"; // Đồ chơi giáo dục & Trí tuệ
                    else if (tenNut.Contains("vận động"))
                        btn.Tag = "L006"; // Vận động ngoài trời
                    else if (tenNut.Contains("điện tử"))
                        btn.Tag = "L007"; // Nhạc cụ & Điện tử
                    else if (tenNut.Contains("mô hình"))
                        btn.Tag = "L008"; // Hướng nghiệp & Mô hình
                }
            }
        }

        /// <summary>
        /// 1. Cấu hình DataGridView: Map các cột chính xác với thuộc tính của SanPhamDTO
        /// </summary>
        private void CauHinhDataGridView()
        {
            if (dgvSanPham == null) return;

            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DefaultCellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Regular);
            dgvSanPham.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);

            // Cột Mã SP
            if (colMaSP != null)
            {
                colMaSP.DataPropertyName = nameof(SanPhamDTO.MaSP);
                colMaSP.HeaderText = "Mã SP";
            }

            // Cột Tên SP
            if (colTenSP != null)
            {
                colTenSP.DataPropertyName = nameof(SanPhamDTO.TenSP);
                colTenSP.HeaderText = "Tên Sản Phẩm";
            }

            // Cột Danh Mục chính (Hiển thị tên tiếng Việt TenLoai)
            if (colLoai != null)
            {
                colLoai.DataPropertyName = nameof(SanPhamDTO.TenLoai);
                colLoai.HeaderText = "Danh Mục";
                colLoai.Visible = true;
            }

            // Ẩn cột trùng colTenLoai nếu có
            if (colTenLoai != null && colTenLoai != colLoai)
            {
                colTenLoai.Visible = false;
            }

            // Cột Độ Tuổi
            if (colDoTuoi != null)
            {
                colDoTuoi.DataPropertyName = nameof(SanPhamDTO.DoTuoi);
                colDoTuoi.HeaderText = "Độ Tuổi";
                colDoTuoi.Visible = true;
            }

            // Cột Giá Bán (format N0)
            if (colDonGia != null)
            {
                colDonGia.DataPropertyName = nameof(SanPhamDTO.DonGia);
                colDonGia.HeaderText = "Giá Bán";
                colDonGia.DefaultCellStyle.Format = "N0";
                colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Cột Giá Nhập (format N0)
            if (colGiaNhap != null)
            {
                colGiaNhap.DataPropertyName = nameof(SanPhamDTO.GiaNhap);
                colGiaNhap.HeaderText = "Giá Nhập";
                colGiaNhap.DefaultCellStyle.Format = "N0";
                colGiaNhap.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Cột Tồn Kho (format N0 và căn phải)
            if (colTonKho != null)
            {
                colTonKho.DataPropertyName = nameof(SanPhamDTO.TonKho);
                colTonKho.HeaderText = "Tồn Kho";
                colTonKho.DefaultCellStyle.Format = "N0";
                colTonKho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Cột Kênh Bán Đang Bán (Shopee, TikTok, Tại quầy...)
            if (colKenhBan != null)
            {
                colKenhBan.DataPropertyName = nameof(SanPhamDTO.DanhSachKenhBan);
                colKenhBan.HeaderText = "Kênh Đang Bán";
            }

            // Cột Trạng Thái
            if (colTrangThai != null)
            {
                colTrangThai.DataPropertyName = nameof(SanPhamDTO.TrangThai);
                colTrangThai.HeaderText = "Trạng Thái";
                colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Cột Hãng & Xuất xứ bổ trợ
            if (colHang != null)
            {
                colHang.DataPropertyName = nameof(SanPhamDTO.Hang);
                colHang.Visible = false;
            }
            if (colXuatXu != null)
            {
                colXuatXu.DataPropertyName = nameof(SanPhamDTO.TenXuatXu);
                colXuatXu.Visible = false;
            }
        }

        /// <summary>
        /// Định dạng hiển thị trực quan cho các cột Trạng Thái, Cảnh báo Tồn Kho, và loại bỏ Facebook khỏi Kênh bán
        /// </summary>
        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham == null || e.RowIndex < 0 || e.RowIndex >= dgvSanPham.Rows.Count)
                return;

            DataGridViewColumn col = dgvSanPham.Columns[e.ColumnIndex];

            // 1. Hiển thị chữ tiếng Việt cho cột Trạng Thái
            if (col == colTrangThai && e.Value != null)
            {
                if (bool.TryParse(e.Value.ToString(), out bool trangThai))
                {
                    if (trangThai)
                    {
                        e.Value = "Đang kinh doanh";
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
                    }
                    else
                    {
                        e.Value = "Ngừng kinh doanh";
                        e.CellStyle.ForeColor = Color.Gray;
                        e.CellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Regular);
                    }
                    e.FormattingApplied = true;
                }
            }

            // 2. Cảnh báo màu sắc cho cột Tồn kho
            if (col == colTonKho && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int tonKho))
                {
                    if (tonKho <= 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
                    }
                    else if (tonKho <= 5)
                    {
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        e.CellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.Font = new Font("Times New Roman", 10F, FontStyle.Regular);
                    }
                }
            }
        }

        /// <summary>
        /// 2. Đăng ký sự kiện Click cho tất cả nút danh mục trên panel5 dựa vào Tag (ALL, L001->L008)
        /// </summary>
        private void DangKySuKienLocLoai()
        {
            if (panel5 == null) return;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Click += (s, e) =>
                    {
                        _maLoaiDangChon = btn.Tag != null ? btn.Tag.ToString().Trim() : "ALL";
                        CapNhatGiaoDienNutLoai(btn);
                        LocDuLieu();
                    };
                }
            }
        }

        /// <summary>
        /// Làm nổi bật nút danh mục đang được chọn trên panel5
        /// </summary>
        private void CapNhatGiaoDienNutLoai(Button activeBtn)
        {
            if (panel5 == null) return;

            foreach (Control ctrl in panel5.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    if (btn == activeBtn)
                    {
                        btn.BackColor = Color.FromArgb(0, 122, 255);
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 255);
                        btn.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold);
                    }
                    else
                    {
                        btn.BackColor = Color.White;
                        btn.ForeColor = Color.Black;
                        btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
                        btn.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular);
                    }
                }
            }
        }

        
       
        /// <summary>
        /// Tải toàn bộ danh sách sản phẩm từ cơ sở dữ liệu qua lớp SanPhamBUS
        /// </summary>
        public void LoadDanhSachSanPham()
        {
            try
            {
                // Chỉ lấy các sản phẩm còn đang kinh doanh
                _danhSachHienTai = _sanPhamBUS.LayDanhSach(chiLayConBan: false) ?? new List<SanPhamDTO>();

                // Lọc và hiển thị dữ liệu trực tiếp
                LocDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kiểm tra mã loại của sản phẩm có khớp với Tag lọc của nút hay không
        /// Hỗ trợ linh hoạt cả định dạng L01 và L001
        /// </summary>
        private bool KhopMaLoai(string maLoaiSP, string tagLoai)
        {
            if (string.IsNullOrEmpty(tagLoai) || tagLoai.Equals("ALL", StringComparison.OrdinalIgnoreCase))
                return true;

            if (string.IsNullOrEmpty(maLoaiSP))
                return false;

            maLoaiSP = maLoaiSP.Trim();
            tagLoai = tagLoai.Trim();

            // So sánh chuỗi trực tiếp
            if (maLoaiSP.Equals(tagLoai, StringComparison.OrdinalIgnoreCase))
                return true;

            // Chuẩn hóa theo số đuôi (VD: L01 khớp với L001)
            string digitsSP = new string(maLoaiSP.Where(char.IsDigit).ToArray()).TrimStart('0');
            string digitsTag = new string(tagLoai.Where(char.IsDigit).ToArray()).TrimStart('0');

            if (!string.IsNullOrEmpty(digitsSP) && !string.IsNullOrEmpty(digitsTag))
            {
                return digitsSP == digitsTag;
            }

            return false;
        }

        /// <summary>
        /// 2. Thực hiện Lọc & Tìm Kiếm đa tiêu chí bằng LINQ
        /// </summary>
        public void LocDuLieu()
        {
            if (_danhSachHienTai == null) return;

            string rawText = (txtTim != null) ? txtTim.Text : string.Empty;
            string tuKhoa = rawText.Trim();
            bool hasSearchText = !string.IsNullOrEmpty(tuKhoa) &&
                                 !string.Equals(tuKhoa, PLACEHOLDER_TEXT.Trim(), StringComparison.OrdinalIgnoreCase);

            IEnumerable<SanPhamDTO> query = _danhSachHienTai;

            // 1. Lọc theo Danh mục Loại (panel5)
            if (!string.IsNullOrEmpty(_maLoaiDangChon) && !_maLoaiDangChon.Equals("ALL", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(sp => KhopMaLoai(sp.MaLoai, _maLoaiDangChon));
            }

            // 2. Tìm kiếm nhanh realtime (Mã SP, Tên SP, Hãng)
            if (hasSearchText)
            {
                string tuKhoaLower = tuKhoa.ToLower();
                query = query.Where(sp => (!string.IsNullOrEmpty(sp.MaSP) && sp.MaSP.ToLower().Contains(tuKhoaLower)) ||
                                          (!string.IsNullOrEmpty(sp.TenSP) && sp.TenSP.ToLower().Contains(tuKhoaLower)) ||
                                          (!string.IsNullOrEmpty(sp.Hang) && sp.Hang.ToLower().Contains(tuKhoaLower)));
            }

            // 3. Lọc nâng cao từ FilterModel
            if (_currentFilter != null)
            {
                if (_currentFilter.GiaTu.HasValue) query = query.Where(sp => sp.DonGia >= _currentFilter.GiaTu.Value);
                if (_currentFilter.GiaDen.HasValue) query = query.Where(sp => sp.DonGia <= _currentFilter.GiaDen.Value);
                if (_currentFilter.TonKhoTu.HasValue) query = query.Where(sp => sp.TonKho >= _currentFilter.TonKhoTu.Value);
                if (_currentFilter.TonKhoDen.HasValue) query = query.Where(sp => sp.TonKho <= _currentFilter.TonKhoDen.Value);

                if (!string.IsNullOrEmpty(_currentFilter.ThuongHieu) && _currentFilter.ThuongHieu != "Tất cả")
                {
                    query = query.Where(sp => !string.IsNullOrEmpty(sp.Hang) &&
                                              sp.Hang.IndexOf(_currentFilter.ThuongHieu, StringComparison.OrdinalIgnoreCase) >= 0);
                }

                if (!string.IsNullOrEmpty(_currentFilter.DoTuoi) && _currentFilter.DoTuoi != "Tất cả")
                {
                    query = query.Where(sp => !string.IsNullOrEmpty(sp.DoTuoi) &&
                                              (sp.DoTuoi.IndexOf(_currentFilter.DoTuoi, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                               _currentFilter.DoTuoi.IndexOf(sp.DoTuoi, StringComparison.OrdinalIgnoreCase) >= 0));
                }

                if (_currentFilter.KenhBan != null && _currentFilter.KenhBan.Count > 0)
                {
                    query = query.Where(sp => !string.IsNullOrEmpty(sp.DanhSachKenhBan) &&
                                              _currentFilter.KenhBan.Any(kb => sp.DanhSachKenhBan.IndexOf(kb, StringComparison.OrdinalIgnoreCase) >= 0));
                }

                switch (_currentFilter.TrangThaiTonKho)
                {
                    case "Còn hàng": query = query.Where(sp => sp.TonKho > 0); break;
                    case "Sắp hết": query = query.Where(sp => sp.TonKho > 0 && sp.TonKho <= 5); break;
                    case "Hết hàng": query = query.Where(sp => sp.TonKho <= 0); break;
                }

                switch (_currentFilter.SapXepTheo)
                {
                    case "Tên A-Z": query = query.OrderBy(sp => sp.TenSP); break;
                    case "Giá tăng dần": query = query.OrderBy(sp => sp.DonGia); break;
                    case "Giá giảm dần": query = query.OrderByDescending(sp => sp.DonGia); break;
                    case "Tồn kho thấp": query = query.OrderBy(sp => sp.TonKho); break;
                    case "Mới nhất": default: query = query.OrderByDescending(sp => sp.MaSP); break;
                }
            }

            var ketQua = query.ToList();
            HienThiDuLieu(ketQua);
        }

        private void HienThiDuLieu(List<SanPhamDTO> list)
        {
            if (dgvSanPham == null) return;

            dgvSanPham.DataSource = null;
            dgvSanPham.DataSource = list;

            int tongSP = list != null ? list.Count : 0;
            int sapHetHang = list != null ? list.Count(sp => sp.TonKho > 0 && sp.TonKho <= 5) : 0;

            if (lblTongSanPham != null) lblTongSanPham.Text = tongSP.ToString();
            if (lblSapHetHang != null) lblSapHetHang.Text = sapHetHang.ToString();

            if (list != null && list.Count > 0)
            {
                HienThiThongTinNhanh(list[0]);
            }
            else
            {
                XoaThongTinNhanh();
            }
        }

        private void HienThiThongTinNhanh(SanPhamDTO sp)
        {
            if (sp == null) { XoaThongTinNhanh(); return; }

            if (lblMaSPInfo != null) lblMaSPInfo.Text = sp.MaSP ?? "...";
            if (lblTenSPInfo != null) lblTenSPInfo.Text = sp.TenSP ?? "...";
            if (lblHangInfo != null) lblHangInfo.Text = !string.IsNullOrWhiteSpace(sp.Hang) ? sp.Hang : "Chưa có";
            if (lblTonKhoInfo != null) lblTonKhoInfo.Text = sp.TonKho.ToString("N0");
            if (lblXuatXuInfo != null) lblXuatXuInfo.Text = !string.IsNullOrWhiteSpace(sp.TenXuatXu) ? sp.TenXuatXu : "Kệ 01";

            // Hiển thị ảnh lớn xem trước bằng MemoryStream để không khóa file gốc
            LoadHinhAnhXemTruoc(sp.HinhAnh);
        }

        /// <summary>
        /// Nạp hình ảnh lớn vào picXemTruoc bằng MemoryStream tránh lock file
        /// </summary>
        private void LoadHinhAnhXemTruoc(string hinhAnh)
        {
            if (picXemTruoc == null) return;

            if (picXemTruoc.Image != null)
            {
                picXemTruoc.Image.Dispose();
                picXemTruoc.Image = null;
            }

            if (string.IsNullOrWhiteSpace(hinhAnh)) return;

            try
            {
                string path1 = System.IO.Path.Combine(Application.StartupPath, "Images", hinhAnh);
                string path2 = System.IO.Path.Combine(Application.StartupPath, @"..\..\Images", hinhAnh);
                string fullPath = System.IO.File.Exists(path1) ? path1 : (System.IO.File.Exists(path2) ? path2 : null);

                if (fullPath != null && System.IO.File.Exists(fullPath))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(fullPath);
                    using (var ms = new System.IO.MemoryStream(bytes))
                    {
                        picXemTruoc.Image = Image.FromStream(ms);
                    }
                }
            }
            catch { }
        }

        private void XoaThongTinNhanh()
        {
            if (lblMaSPInfo != null) lblMaSPInfo.Text = "...";
            if (lblTenSPInfo != null) lblTenSPInfo.Text = "...";
            if (lblHangInfo != null) lblHangInfo.Text = "...";
            if (lblTonKhoInfo != null) lblTonKhoInfo.Text = "0";
            if (lblXuatXuInfo != null) lblXuatXuInfo.Text = "...";

            if (picXemTruoc != null && picXemTruoc.Image != null)
            {
                picXemTruoc.Image.Dispose();
                picXemTruoc.Image = null;
            }
        }

        private void CapNhatTrangThaiNutLoc()
        {
            if (btnLoc != null)
            {
                btnLoc.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
                btnLoc.FlatStyle = FlatStyle.Flat;
                btnLoc.FlatAppearance.BorderSize = 0;
                btnLoc.Height = 35;
                btnLoc.Top = 46;

                if (_currentFilter != null && !_currentFilter.IsDefault())
                {
                    btnLoc.BackColor = Color.FromArgb(255, 152, 0);
                    btnLoc.ForeColor = Color.White;
                    btnLoc.Text = "⚙ Đang Lọc...";
                }
                else
                {
                    btnLoc.BackColor = Color.FromArgb(0, 122, 255);
                    btnLoc.ForeColor = Color.White;
                    btnLoc.Text = "⚙ Lọc nâng cao";
                }
            }
        }

        #region Event Handlers

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSanPham != null && e.RowIndex >= 0 && e.RowIndex < dgvSanPham.Rows.Count)
            {
                if (dgvSanPham.Rows[e.RowIndex].DataBoundItem is SanPhamDTO sp)
                {
                    HienThiThongTinNhanh(sp);
                }
            }
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham != null && dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index >= 0)
            {
                if (dgvSanPham.CurrentRow.DataBoundItem is SanPhamDTO sp)
                {
                    HienThiThongTinNhanh(sp);
                }
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e) => LocDuLieu();

        private void TxtTim_Enter(object sender, EventArgs e)
        {
            if (txtTim != null && string.Equals(txtTim.Text.Trim(), PLACEHOLDER_TEXT.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                txtTim.Text = "";
                txtTim.ForeColor = Color.Black;
            }
        }

        private void TxtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim != null && string.IsNullOrWhiteSpace(txtTim.Text))
            {
                txtTim.Text = PLACEHOLDER_TEXT;
                txtTim.ForeColor = Color.Gray;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmThemSP formThem = new frmThemSP())
            {
                if (formThem.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachSanPham();
                }
            }
        }

        public void btnLoc_Click(object sender, EventArgs e)
        {
            var dsThuongHieu = _danhSachHienTai?.Where(sp => !string.IsNullOrWhiteSpace(sp.Hang)).Select(sp => sp.Hang.Trim()).Distinct().ToList();
            var dsDoTuoi = _danhSachHienTai?.Where(sp => !string.IsNullOrWhiteSpace(sp.DoTuoi)).Select(sp => sp.DoTuoi.Trim()).Distinct().ToList();

            using (frmLoc frm = new frmLoc(_currentFilter, dsThuongHieu, dsDoTuoi))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _currentFilter = frm.FilterData ?? new FilterModel();
                    CapNhatTrangThaiNutLoc();
                    LocDuLieu();
                }
            }
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            using (frmNhapHang frm = new frmNhapHang())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachSanPham();
                }
            }
        }

        private void btnLichSuNhap_Click(object sender, EventArgs e)
        {
            using (frmLichSuNhapHang frm = new frmLichSuNhapHang())
            {
                frm.ShowDialog();
            }
        }

        private void btnSuaNhanh_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.DataBoundItem is SanPhamDTO sp)
            {
                using (frmThemSP frm = new frmThemSP(sp))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDanhSachSanPham();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trên danh sách!", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaNhanh_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.DataBoundItem is SanPhamDTO sp)
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{sp.TenSP}' (Mã SKU: {sp.MaSP}) không?",
                                             "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    if (_sanPhamBUS.Xoa(sp.MaSP, out string error, xoaMem: true))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trên danh sách!", "Nhắc Nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion
    }
}
