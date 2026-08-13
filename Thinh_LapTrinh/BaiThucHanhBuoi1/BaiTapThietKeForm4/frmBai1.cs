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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            sp.MaSanPham = "SP001";
            sp.TenSanPham = "Sản phẩm 1";
            sp.LoaiSanPham = "Loại 1";
            sp.NgaySanXuat = new DateTime(2026, 1, 1);
            
            lblThongTin.Text = sp.HienThi();
        }
    }
}
