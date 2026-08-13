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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double DiemLT = double.Parse(txtLT.Text);
            double DiemTH = double.Parse(txtTH.Text);

            if(DiemLT < 0 || DiemLT > 10 || DiemTH < 0 || DiemTH > 10)
            {
                MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10.");
                return;
            }

          double diemTB = (DiemLT + DiemTH) / 2;

            string xepLoai;

            if (DiemLT < 5 || DiemTH < 5)
            {
                xepLoai = "Yếu";
            }
            else if (diemTB < 7)
            {
                xepLoai = "Trung bình";
            }
            else if (diemTB >= 7 & diemTB < 8)
            {
                xepLoai = "Khá";
            }
            else if (diemTB >= 8 & diemTB < 9)
            {
                xepLoai = "Giỏi";
            }
            else
            {
                xepLoai = "Xuất sắc";
            }

         

            lblXepLoai.Text =  xepLoai;
        }
    }
}
