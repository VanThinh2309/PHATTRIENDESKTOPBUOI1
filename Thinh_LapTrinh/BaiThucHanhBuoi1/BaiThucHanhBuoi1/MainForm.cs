using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanhBuoi1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var tenNhap = txtHoTen.Text;
            MessageBox.Show($"Xin chào bạn {tenNhap} nhe. Rất vui khi được gặp bạn","Thông báo chào mừng");
        }

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            txtSaoChep.Text = txtHoTen.Text;
        }

       

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            txtSaoChep.Text = txtHoTen.Text;
        }
    }
}
