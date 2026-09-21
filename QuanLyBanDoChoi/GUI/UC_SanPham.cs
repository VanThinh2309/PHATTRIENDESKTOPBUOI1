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
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private List<SanPhamDTO> _danhSachHienTai = new List<SanPhamDTO>();

        public UC_SanPham()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += UC_SanPham_Load;
            this.btnThem.Click += btnThem_Click;
            this.txtTim.TextChanged += txtTim_TextChanged;
            this.dgvSanPham.CellClick += dgvSanPham_CellClick;

            // Xử lý placeholder ô tìm kiếm
            this.txtTim.Enter += (s, e) =>
            {
                if (txtTim.Text == "Tìm theo mã, tên sản phẩm...")
                {
                    txtTim.Text = "";
                    txtTim.ForeColor = Color.Black;
                }
            };
            this.txtTim.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTim.Text))
                {
                    txtTim.Text = "Tìm theo mã, tên sản phẩm...";
                    txtTim.ForeColor = Color.Gray;
                }
            };
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            CauHinhDataGridView();
            LoadDanhSachSanPham();
        }

        /// <summary>
        /// Cấu hình các cột trong DataGridView để khớp với thuộc tính SanPhamDTO
        /// </summary>
        private void CauHinhDataGridView()
        {
            dgvSanPham.AutoGenerateColumns = false;
            Column2.DataPropertyName = nameof(SanPhamDTO.MaSP);
            Column3.DataPropertyName = nameof(SanPhamDTO.TenSP);
            Column4.DataPropertyName = nameof(SanPhamDTO.MaLoai);
            Column5.DataPropertyName = nameof(SanPhamDTO.DoTuoi);
            Column6.DataPropertyName = nameof(SanPhamDTO.DonGia);
            Column7.DataPropertyName = nameof(SanPhamDTO.TonKho);
            Column1.DataPropertyName = nameof(SanPhamDTO.HinhAnh);
            Column8.DataPropertyName = nameof(SanPhamDTO.TrangThai);

            // Format hiển thị số tiền cho cột đơn giá
            Column6.DefaultCellStyle.Format = "N0";
        }

        /// <summary>
        /// Gọi SanPhamBUS để tải danh sách sản phẩm và hiển thị lên giao diện
        /// </summary>
        public void LoadDanhSachSanPham()
        {
            try
            {
                _danhSachHienTai = _sanPhamBUS.LayDanhSach();
                HienThiDuLieu(_danhSachHienTai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gán dữ liệu vào DataGridView và cập nhật các nhãn thống kê nhanh
        /// </summary>
        private void HienThiDuLieu(List<SanPhamDTO> list)
        {
            dgvSanPham.DataSource = null;
            dgvSanPham.DataSource = list;

            // Thống kê nhanh
            int tongSP = list != null ? list.Count : 0;
            int sapHetHang = list != null ? list.Count(sp => sp.TonKho > 0 && sp.TonKho <= 5) : 0;

            lblTongSanPham.Text = tongSP.ToString();
            lblSapHetHang.Text = sapHetHang.ToString();

            // Nếu có dữ liệu, chọn dòng đầu tiên để hiển thị chi tiết
            if (list != null && list.Count > 0)
            {
                HienThiThongTinNhanh(list[0]);
            }
            else
            {
                XoaThongTinNhanh();
            }
        }

        /// <summary>
        /// Hiển thị thông tin sản phẩm lên panel xem nhanh bên phải
        /// </summary>
        private void HienThiThongTinNhanh(SanPhamDTO sp)
        {
            if (sp == null)
            {
                XoaThongTinNhanh();
                return;
            }

            lblMaSanPham.Text = sp.MaSP ?? "...";
            lblTenSanPham.Text = sp.TenSP ?? "...";
            lblThuongHieu.Text = !string.IsNullOrEmpty(sp.Hang) ? sp.Hang : "Chưa có";
            lblTonKho.Text = sp.TonKho.ToString();
            lblViTri.Text = !string.IsNullOrEmpty(sp.TenXuatXu) ? sp.TenXuatXu : "Kệ 01";
        }

        private void XoaThongTinNhanh()
        {
            lblMaSanPham.Text = "...";
            lblTenSanPham.Text = "...";
            lblThuongHieu.Text = "...";
            lblTonKho.Text = "0";
            lblViTri.Text = "...";
        }

        /// <summary>
        /// Xử lý click chọn một dòng trên DataGridView
        /// </summary>
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSanPham.Rows.Count > e.RowIndex)
            {
                SanPhamDTO sp = dgvSanPham.Rows[e.RowIndex].DataBoundItem as SanPhamDTO;
                if (sp != null)
                {
                    HienThiThongTinNhanh(sp);
                }
            }
        }

        /// <summary>
        /// Xử lý tìm kiếm thông qua SanPhamBUS
        /// </summary>
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTim.Text.Trim();
            if (tuKhoa == "Tìm theo mã, tên sản phẩm..." || string.IsNullOrEmpty(tuKhoa))
            {
                HienThiDuLieu(_sanPhamBUS.LayDanhSach());
            }
            else
            {
                List<SanPhamDTO> ketQua = _sanPhamBUS.TimKiem(tuKhoa);
                HienThiDuLieu(ketQua);
            }
        }

        /// <summary>
        /// Mở form thêm sản phẩm và load lại dữ liệu nếu thêm thành công
        /// </summary>
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

        // Các event handler có sẵn trong Designer để tránh lỗi null event
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
    }
}
