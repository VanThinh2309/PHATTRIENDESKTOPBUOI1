using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapWindowForm2
{
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;

            ConLai.NoiChuoi(txtHo.Text, txtTen.Text, out s);

            lblHT.Text = "" + s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtSoN.Text);
            if(n <= 0)
            {
                MessageBox.Show("N phải là số nguyên dương hoặc lớn hơn 0!");
                return;
            }
            long kq = ConLai.GiaiThua(n);
            lblKQ.Text = "" + kq;

        }
    }
}
