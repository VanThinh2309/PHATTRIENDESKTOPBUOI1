using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapWindowForm3
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        

        private void btTachChuoi_Click(object sender, EventArgs e)
        {
            string ho;
            string ten;
            ConLaiCau3.TachChuoi(txtHoTen.Text, out ho, out ten);
            lblHo.Text = "Họ" + ho;
            lblTen.Text = "Tên" + ten;
        }

        private void btKT_Click(object sender, EventArgs e)
        {
            int n1 = int.Parse(txtN1.Text);
            int n2 = int.Parse(txtN2.Text);
            
            bool kq = ConLaiCau3.ThuTu(n1, n2);
            if(kq)             {
                lblKQ.Text = "Số thứ tự: " + n1 + " < " + n2;
            }
            else
            {
                lblKQ.Text = "Số thứ tự: " + n1 + " > " + n2;
            }
        }
    }
}
