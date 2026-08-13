using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void rdNam_CheckedChanged_1(object sender, EventArgs e)
        {
            if(rdNam.Checked)
            MessageBox.Show($"Bạn đã chon giới tính nam", "Thông báo");
        }

      

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            if(rdNu.Checked)
            MessageBox.Show($"Bạn đã chon giới tính nữ", "Thông báo");
        }

        private void grGT_Enter(object sender, EventArgs e)
        {

        }

        private void btToMau_Click(object sender, EventArgs e)
        {
            if (rdDo.Checked)
                txtOMau.BackColor = Color.Red;
            else
                txtOMau.BackColor = Color.Green;
        }
    }
}
