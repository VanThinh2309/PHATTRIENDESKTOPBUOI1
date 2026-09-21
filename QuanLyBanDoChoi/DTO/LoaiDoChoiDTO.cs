using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoChoi.DTO
{
    public class LoaiDoChoiDTO
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string MoTa { get; set; }

        public LoaiDoChoiDTO()
        {
        }

        public LoaiDoChoiDTO(string maLoai, string tenLoai, string moTa = "")
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
            MoTa = moTa;
        }

        public override string ToString()
        {
            return TenLoai;
        }
    }
}
