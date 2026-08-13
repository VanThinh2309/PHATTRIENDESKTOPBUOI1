using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapWindowForm3
{
    internal class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public double HeSoLuong { get; set; }
        public double HeSoPhuCap { get; set; }
        public int LuongCoBan { get; internal set; }

        public NhanVien()
        {
        }

        public NhanVien(string maNV, string hoTen,
                        DateTime ngaySinh,
                        double heSoLuong,
                        double heSoPhuCap)
        {
            MaNV = maNV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            HeSoLuong = heSoLuong;
            HeSoPhuCap = heSoPhuCap;
        }

        public double TongLuong()
        {
            return (HeSoLuong + HeSoPhuCap) * 1150000;
        }
        public string HienThi()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", MaNV, HoTen, NgaySinh.ToString("dd/MM/yyyy"), HeSoLuong, HeSoPhuCap, TongLuong());
        }
    }
}
