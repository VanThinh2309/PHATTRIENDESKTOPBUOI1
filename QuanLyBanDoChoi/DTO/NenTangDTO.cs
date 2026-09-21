using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class NenTangDTO
    {
        public string MaNenTang { get; set; }
        public string TenNenTang { get; set; }

        public NenTangDTO()
        {
        }

        public NenTangDTO(string maNenTang, string tenNenTang)
        {
            MaNenTang = maNenTang;
            TenNenTang = tenNenTang;
        }

        public override string ToString()
        {
            return TenNenTang;
        }
    }
}
