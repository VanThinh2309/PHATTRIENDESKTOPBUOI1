using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoChoi
{
    public partial class UC_ItemGioHang : UserControl
    {
        public event EventHandler OnRemoveClick;
        public event EventHandler OnQuantityChanged;

        private decimal _donGia = 0;
        public UC_ItemGioHang()
        {
            InitializeComponent();
        }
        public string TenThuoc
        {
            get => lblTenDoChoi.Text; // Sửa lblTenThuoc thành đúng (Name) Label tên thuốc của bro
            set => lblTenDoChoi.Text = value;
        }

        // 2. Property Đơn vị tính / Quy cách
        public string DonViTinh
        {
            get => lblHang.Text; // Sửa lblQuyCach thành đúng (Name) Label quy cách
            set => lblHang.Text = value;
        }

        // 3. Property Đơn giá
        public decimal DonGia
        {
            get => _donGia;
            set
            {
                _donGia = value;
                CapNhatThanhTien();
            }
        }
        public int SoLuong
        {
            get
            {
                int.TryParse(txtSoLuong.Text, out int sl); 
                return sl < 1 ? 1 : sl;
            }
            set
            {
                txtSoLuong.Text = value.ToString();
                CapNhatThanhTien();
            }
        }

        public decimal ThanhTien => DonGia * SoLuong;

        private void CapNhatThanhTien()
        {
            lblThanhTien.Text = string.Format("{0:#,##0} đ", ThanhTien); 
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            OnRemoveClick?.Invoke(this, EventArgs.Empty);
        }

        private void UC_ItemGioHang_Load(object sender, EventArgs e)
        {

        }
        public void SetData(string tenThuoc, int soLuong, decimal donGia, decimal thanhTien)
        {
            // Thay mấy chữ lbTenThuoc, lbSoLuong, lbThanhTien thành tên các Label thật trên UserControl của ông nhé
            if (lblTenDoChoi != null) lblTenDoChoi.Text = tenThuoc;
            if (txtSoLuong != null) txtSoLuong.Text = soLuong.ToString(); // Hoặc lbSoLuong.Text = soLuong.ToString();
            if (lblThanhTien != null) lblThanhTien.Text = $"{thanhTien:N0} đ";
        }

        public void CheDoXemLichSu()
        {
            // Ẩn các nút tương tác khi xem lịch sử
            if (btXoa != null) btXoa.Visible = false;
            if (btGiam != null) btGiam.Visible = false;
            if (btTang != null) btTang.Visible = false;
        }
        private void btGiam_Click(object sender, EventArgs e)
        {
            if (SoLuong > 1)
            {
                SoLuong--;
                OnQuantityChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OnRemoveClick?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btTang_Click(object sender, EventArgs e)
        {
            SoLuong++; 
            OnQuantityChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
