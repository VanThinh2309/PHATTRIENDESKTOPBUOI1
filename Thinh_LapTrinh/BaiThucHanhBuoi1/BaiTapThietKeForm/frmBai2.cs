using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeForm
{
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void btnChonHang_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            listBox2.Items.Add(item);
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int SoTien = 0;
            foreach (string hang in listBox2.Items)
            {
                switch(hang)
                {
                    case "Chuột":
                        SoTien += 100000;
                        break;
                    case "Bàn phím":
                        SoTien += 150000;
                        break;
                    case "Máy in":
                        SoTien += 2000000;
                        break;  
                    case "USB Kingmax":
                        SoTien += 200000;
                        break;

                }
                lblSoTien.Text = SoTien + " đồng";
            }    

        }
    }
}
