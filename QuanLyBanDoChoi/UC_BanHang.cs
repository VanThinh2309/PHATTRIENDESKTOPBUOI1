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
    public partial class UC_BanHang : UserControl
    {
        private bool rdTTTMDaChon;
        private bool rdTTCKDaChon;
        public UC_BanHang()
        {
            InitializeComponent();
        }
        private void UC_BanHang_Load(object sender, EventArgs e)
        {
            rdTTTM.FlatStyle = FlatStyle.Flat;
            rdTTCK.FlatStyle = FlatStyle.Flat;
            cbbHinhThuc.SelectedItem = "_Tất cả_";
            CapNhatBoLoc();
            DatLaiNgay();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void CapNhatBoLoc()
        {
            string hinhThuc = cbbHinhThuc.Text.Trim();

            Color mauKhoa = Color.FromArgb(190, 190, 190);
            Color mauBinhThuong = Color.Black;

            if (hinhThuc == "_Tất cả_")
            {
                // Radio vẫn Enabled để mình điều khiển màu
                rdTTTM.Enabled = true;
                rdTTCK.Enabled = true;

                // Khóa nền tảng thật
                cbbNenTangLS.Enabled = false;

                // Màu nhạt
                rdTTTM.ForeColor = mauKhoa;
                rdTTCK.ForeColor = mauKhoa;
                lblTT.ForeColor = mauKhoa;
                lblNT.ForeColor = mauKhoa;

                // Không chọn gì
                rdTTTM.Checked = false;
                rdTTCK.Checked = false;

                rdTTTM.Text = "Tiền mặt";
            }
            else if (hinhThuc == "Tại quầy")
            {
                rdTTTM.Enabled = true;
                rdTTCK.Enabled = true;

                cbbNenTangLS.Enabled = false;

                rdTTTM.ForeColor = mauBinhThuong;
                rdTTCK.ForeColor = mauBinhThuong;

                lblTT.ForeColor = mauBinhThuong;
                lblNT.ForeColor = mauKhoa;

                rdTTTM.Text = "Tiền mặt";
            }
            else if (hinhThuc == "Online")
            {
                rdTTTM.Enabled = true;
                rdTTCK.Enabled = true;

                cbbNenTangLS.Enabled = true;

                rdTTTM.ForeColor = mauBinhThuong;
                rdTTCK.ForeColor = mauBinhThuong;

                lblTT.ForeColor = mauBinhThuong;
                lblNT.ForeColor = mauBinhThuong;

                rdTTTM.Text = "Thu hộ";
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Chọn màu viền và độ dày của viền (ở đây để độ dày là 3 pixel)
            int borderWidth = 2;
            using (Pen pColor = new Pen(Color.Black, borderWidth))
            {
                // Vẽ khung viền đè lên Panel
                e.Graphics.DrawRectangle(pColor, 0, 0, p.ClientRectangle.Width, p.ClientRectangle.Height);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Chọn màu viền và độ dày của viền (ở đây để độ dày là 3 pixel)
            int borderWidth = 2;
            using (Pen pColor = new Pen(Color.Black, borderWidth))
            {
                // Vẽ khung viền đè lên Panel
                e.Graphics.DrawRectangle(pColor, 0, 0, p.ClientRectangle.Width , p.ClientRectangle.Height );
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Chọn màu viền và độ dày của viền (ở đây để độ dày là 3 pixel)
            int borderWidth = 2;
            using (Pen pColor = new Pen(Color.Black, borderWidth))
            {
                // Vẽ khung viền đè lên Panel
                e.Graphics.DrawRectangle(pColor, 0, 0, p.ClientRectangle.Width , p.ClientRectangle.Height );
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Chọn màu viền và độ dày của viền (ở đây để độ dày là 3 pixel)
            int borderWidth = 2;
            using (Pen pColor = new Pen(Color.Black, borderWidth))
            {
                // Vẽ khung viền đè lên Panel
                e.Graphics.DrawRectangle(pColor, 0, 0, p.ClientRectangle.Width , p.ClientRectangle.Height );
            }
        }
        private void DatLaiNgay()
        {
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = " ";

            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = " ";
        }
        private void lblEmpty_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbbHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatBoLoc();
        }

        private void rdTTTM_Click(object sender, EventArgs e)
        {
            if (cbbHinhThuc.Text.Trim() == "_Tất cả_")
            {
                rdTTTM.Checked = false;
                return;
            }

            if (rdTTTMDaChon)
                rdTTTM.Checked = false;

            rdTTTMDaChon = false;
        }

        private void rdTTTM_MouseDown(object sender, MouseEventArgs e)
        {
            rdTTTMDaChon = rdTTTM.Checked;
        }

        private void rdTTCK_MouseDown(object sender, MouseEventArgs e)
        {
            rdTTCKDaChon = rdTTCK.Checked;
        }

        private void rdTTCK_Click(object sender, EventArgs e)
        {
            if (cbbHinhThuc.Text.Trim() == "_Tất cả_")
            {
                rdTTCK.Checked = false;
                return;
            }

            if (rdTTCKDaChon)
                rdTTCK.Checked = false;

            rdTTCKDaChon = false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

            Panel p = sender as Panel;
            // Chọn màu viền và độ dày của viền (ở đây để độ dày là 3 pixel)
            int borderWidth = 2;
            using (Pen pColor = new Pen(Color.Black, borderWidth))
            {
                // Vẽ khung viền đè lên Panel
                e.Graphics.DrawRectangle(pColor, 0, 0, p.ClientRectangle.Width, p.ClientRectangle.Height);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Chọn màu viền và độ dày của viền (ở đây để độ dày là 3 pixel)
            int borderWidth = 2;
            using (Pen pColor = new Pen(Color.Black, borderWidth))
            {
                // Vẽ khung viền đè lên Panel
                e.Graphics.DrawRectangle(pColor, 0, 0, p.ClientRectangle.Width, p.ClientRectangle.Height);
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        }
    }
}
