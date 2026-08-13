using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapWindowForm3
{
    internal class ConLaiCau3
    {
        public static void TachChuoi (string s, out string ho, out string ten)
        {
            int vt = s.IndexOf(" ");
            ho = s.Substring(0, vt);
            ten = s.Substring(vt + 1);
        }
        public static bool ThuTu(int n1, int n2)
        {
            if (n2 == n1 + 1)
            {
                return true;
            }

            return false;
        }

    }
}
