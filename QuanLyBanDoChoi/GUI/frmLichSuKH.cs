using QuanLyBanDoChoi.BUS;
using QuanLyBanDoChoi.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanDoChoi.GUI
{
    public partial class frmLichSuKH : Form
    {
        private string maKH;
        private string tenKH;
        public frmLichSuKH()
        {
            InitializeComponent();
        }
        public frmLichSuKH(string ma, string ten)
        {
            InitializeComponent();

            // Lưu dữ liệu được truyền sang vào biến cục bộ
            this.maKH = ma;
            this.tenKH = ten;
        }
    }
}