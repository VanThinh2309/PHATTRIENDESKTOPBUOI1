using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeForm4
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btChaoHoi_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;

            bool gioiTinh;

            if (rdNam.Checked)
            {
                gioiTinh = true;
            }
            else
            {
                gioiTinh = false;
            }

            ConLaiCau4.ChaoHoi(hoTen, gioiTinh);
        }

        private void btTinh_Click(object sender, EventArgs e)
        {
            int m = int.Parse(txtM.Text);
            int n = int.Parse(txtN.Text);

            int kq = ConLaiCau4.USCLN(m, n);

            lblKQ.Text = " " + m + " và " + n + " là: " + kq;

        }
    }
}
