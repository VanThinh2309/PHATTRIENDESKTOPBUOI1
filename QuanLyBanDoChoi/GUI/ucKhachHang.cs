using QuanLyBanDoChoi.BUS;
using QuanLyBanDoChoi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoChoi.GUI
{
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (frmThemKH frm = new frmThemKH())
            {
                // Hiển thị dạng Pop-up Dialog
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu lưu thành công, thực hiện load lại bảng DataGridView để hiện khách hàng mới
                    // LoadDanhSachKhachHang(); 
                }
            }
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xem lịch sử!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ma = txtMaKH.Text;
            string ten = txtHoTen.Text;
            using (frmLichSu frm = new frmLichSu(ma, ten))
            {
                frm.ShowDialog();
            }
        }
    }
}
