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
    public partial class frmThemSP : Form
    {
        private readonly SanPhamBUS _sanPhamBUS = new SanPhamBUS();
        private readonly LoaiDoChoiBUS _loaiDoChoiBUS = new LoaiDoChoiBUS();

        public frmThemSP()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.Load += frmThemSP_Load;
            this.btnThemDongBo.Click += btnThemDongBo_Click;
            this.btnThoat.Click += btnThoat_Click;

            // Xóa placeholder khi focus vào txtTenSP và textBox1 (Mã SKU)
            txtTenSP.Enter += (s, e) =>
            {
                if (txtTenSP.Text == "Nhập tên sản phẩm...")
                {
                    txtTenSP.Text = "";
                    txtTenSP.ForeColor = Color.Black;
                }
            };
            txtTenSP.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    txtTenSP.Text = "Nhập tên sản phẩm...";
                    txtTenSP.ForeColor = Color.DarkGray;
                }
            };
        }

        private void frmThemSP_Load(object sender, EventArgs e)
        {
            // Tải danh mục loại đồ chơi từ CSDL thông qua LoaiDoChoiBUS
            try
            {
                var dsLoai = _loaiDoChoiBUS.LayDanhSach();
                if (dsLoai != null && dsLoai.Count > 0)
                {
                    cbDanhMuc.DataSource = dsLoai;
                    cbDanhMuc.DisplayMember = "TenLoai";
                    cbDanhMuc.ValueMember = "MaLoai";
                }
                else
                {
                    cbDanhMuc.Items.Clear();
                    cbDanhMuc.Items.AddRange(new object[] { "L001", "L002", "L003", "L004", "L005" });
                    cbDanhMuc.SelectedIndex = 0;
                }
            }
            catch
            {
                cbDanhMuc.Items.Clear();
                cbDanhMuc.Items.AddRange(new object[] { "L001", "L002", "L003", "L004", "L005" });
                cbDanhMuc.SelectedIndex = 0;
            }

            // Nạp độ tuổi mẫu
            cbDoTuoi.Items.Clear();
            cbDoTuoi.Items.AddRange(new object[] { "0-3 tuổi", "3-6 tuổi", "6-12 tuổi", "Trên 12 tuổi" });
            if (cbDoTuoi.Items.Count > 0) cbDoTuoi.SelectedIndex = 1;
        }

        private void btnThemDongBo_Click(object sender, EventArgs e)
        {
            string maSP = textBox1.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            if (tenSP == "Nhập tên sản phẩm...")
            {
                tenSP = string.Empty;
            }

            string maLoai = cbDanhMuc.SelectedValue?.ToString() ?? cbDanhMuc.Text.Trim();
            string doTuoi = cbDoTuoi.SelectedItem != null ? cbDoTuoi.SelectedItem.ToString() : cbDoTuoi.Text.Trim();
            string hang = txtThuongHieu.Text.Trim();
            string xuatXu = txtViTriKho.Text.Trim();

            // Đóng gói DTO
            SanPhamDTO sp = new SanPhamDTO
            {
                MaSP = maSP,
                TenSP = tenSP,
                MaLoai = maLoai,
                DoTuoi = doTuoi,
                Hang = hang,
                TenXuatXu = xuatXu,
                DonGia = 0,
                TonKho = 0,
                HinhAnh = "",
                TrangThai = true
            };

            // Gọi SanPhamBUS để xử lý nghiệp vụ và lưu vào CSDL
            if (_sanPhamBUS.Them(sp, out string error))
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(error, "Lỗi kiểm tra nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
