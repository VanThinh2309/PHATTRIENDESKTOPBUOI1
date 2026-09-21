using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanDoChoi.DAL;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.BUS
{
    public class NenTangBUS
    {
        private readonly NenTangDAL _nenTangDAL;

        public NenTangBUS()
        {
            _nenTangDAL = new NenTangDAL();
        }

        public List<NenTangDTO> LayDanhSach()
        {
            return _nenTangDAL.LayDanhSach();
        }

        public NenTangDTO LayTheoMa(string maNenTang)
        {
            if (string.IsNullOrWhiteSpace(maNenTang)) return null;
            return _nenTangDAL.LayTheoMa(maNenTang.Trim());
        }
    }
}
