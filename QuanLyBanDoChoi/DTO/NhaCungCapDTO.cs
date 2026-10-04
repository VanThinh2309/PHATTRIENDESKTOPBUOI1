using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class NhaCungCapDTO
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }

        public NhaCungCapDTO()
        {
            MaNCC = string.Empty;
            TenNCC = string.Empty;
            SDT = string.Empty;
            DiaChi = string.Empty;
        }

        public NhaCungCapDTO(string maNCC, string tenNCC, string sdt = "", string diaChi = "")
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sdt;
            DiaChi = diaChi;
        }

        public override string ToString()
        {
            return TenNCC;
        }
    }
}
