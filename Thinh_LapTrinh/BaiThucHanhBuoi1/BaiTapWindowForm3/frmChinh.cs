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
    public partial class frmChinh : Form
    {
        public frmChinh()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            frmBai1 f = new frmBai1();
            f.ShowDialog();
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            frmBai2 f = new frmBai2();
            f.ShowDialog();
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            frmBai3 f = new frmBai3();
            f.ShowDialog();
        }
    }
}
