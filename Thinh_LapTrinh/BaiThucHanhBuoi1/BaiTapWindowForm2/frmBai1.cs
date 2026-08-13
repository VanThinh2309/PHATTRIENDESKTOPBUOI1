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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            ThietBi tb = new ThietBi();
            tb.MaThietBi = "TB001";
            tb.TenThietBi = "Máy tính xách tay";
            tb.DonViTinh = "Cái";
            tb.SoLuong = 5;
            tb.DonGia = 15000000;

            lblThongTin.Text = tb.HienThi();
        }
    }
}
