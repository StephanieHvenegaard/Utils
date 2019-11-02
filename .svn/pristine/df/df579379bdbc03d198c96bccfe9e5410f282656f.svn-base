using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHUtils.Util.IAIMathematics
{
    public class NumberConvertion
    {
        public int RoundToLowerInt(double Value)
        {
            string s = Value.ToString();
            string[] ss = s.Split(new char[] { '.', ',' });
            int i = Convert.ToInt32(ss[0]);
            return i;
        }
        public int RoundToHighestInt(double Value)
        {
            string s = Value.ToString();
            string[] ss = s.Split(new char[] { '.', ',' });
            int i = Convert.ToInt32(ss[0]);
            if (Convert.ToInt32(ss[1]) > 0)
            {
                i++;
            }
            return i;
        }
    }
}
