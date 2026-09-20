using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanDoChoi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowUserControl(uC_BanHang1);
        }
        private void HienThiNoiDung(UserControl control)
        {
            pnlContent.Controls.Clear();

            control.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(control);
        }
        private void ShowUserControl(UserControl uc)
        {
            // Ẩn tất cả các UserControl hiện có
            uC_BanHang1.Visible = false;
            uC_SanPham1.Visible = false;
            ucKhachHang1.Visible = false;
           

            // Đưa UserControl được chọn lên trên cùng và hiển thị
            uc.BringToFront();
            uc.Visible = true;
        }
        private void ptb1_Click(object sender, EventArgs e)
        {
            ShowUserControl(uC_BanHang1);
        }

        private void ptb2_Click(object sender, EventArgs e)
        {
            ShowUserControl(uC_SanPham1);
        }

        private void ptb3_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucKhachHang1);
        }

        private void ptb4_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucThongKe1);
        }

        private void pct5_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
