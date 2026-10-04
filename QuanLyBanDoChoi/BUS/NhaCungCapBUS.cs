using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanDoChoi.DAL;
using QuanLyBanDoChoi.DTO;

namespace QuanLyBanDoChoi.BUS
{
    public class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL _dal;

        public NhaCungCapBUS()
        {
            _dal = new NhaCungCapDAL();
        }

        public List<NhaCungCapDTO> LayDanhSach()
        {
            return _dal.LayDanhSach();
        }
    }
}
