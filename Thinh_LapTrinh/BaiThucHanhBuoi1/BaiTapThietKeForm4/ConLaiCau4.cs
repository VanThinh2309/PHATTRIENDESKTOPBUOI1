using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapThietKeForm4
{
    internal class ConLaiCau4
    {
        public static void ChaoHoi(
            string hoten,
            bool gioitinh)
        {
            if (gioitinh == true)
            {
                MessageBox.Show("Chào Ông \"" + hoten + "\"");
            }
            else
            {
                MessageBox.Show("Chào Bà \"" + hoten + "\"");
            }
        }
        public static int USCLN(int m, int n)
        {
            m = Math.Abs(m);
            n = Math.Abs(n);

            while (n != 0)
            {
                int temp = m % n;
                m = n;
                n = temp;
            }

            return m;
        }
    }
}
