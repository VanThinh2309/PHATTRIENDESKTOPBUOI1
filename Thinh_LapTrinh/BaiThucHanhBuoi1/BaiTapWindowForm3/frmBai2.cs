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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(txtSoN.Text);
            int kq = 0;
            if (n < 0)
            {
                MessageBox.Show("N phải lớn hơn hoặc bằng 0!");
                return;
            }
            if (rdTT.Checked)
            {
                int tong = 0;

                for (int i = 1; i <= n; i++)
                {
                    tong += i;
                }

                lblKQ.Text ="" + tong;
            }
            else if (rdGT.Checked)
            {
                int giaiThua = 1;
                for (int i = 1; i <= n; i++)
                {
                    giaiThua *= i;
                }
                lblKQ.Text =  "" + giaiThua;
            }

        }
    }
}
