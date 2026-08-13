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
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {
           NhanVien nv = new NhanVien();
            nv.MaNV = "NV01";
            nv.HoTen = "Nguyen Van A";
            nv.NgaySinh = new DateTime(1990, 1, 1);
            nv.LuongCoBan = 10000000;
            nv.HeSoLuong = 2.5;
            double tongLuong = nv.TongLuong();
            lblThongTin.Text = nv.HienThi();
        }
    }
}
