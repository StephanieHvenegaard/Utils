using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHUtils.Mathematics
{
    public class NumberConvertion
    {
        public static int RoundToLowerInt(double Value)
        {
            string s = Value.ToString();
            string[] ss = s.Split(new char[] { '.', ',' });
            int i = Convert.ToInt32(ss[0]);
            return i;
        }
        public static int RoundToHighestInt(double Value)
        {
            string s = Value.ToString();
            string[] ss = s.Split(new char[] { '.', ',' });
            int i = Convert.ToInt32(ss[0]);
            if (ss.Length != 1)
            {
                if (Convert.ToInt32(ss[1]) > 0)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
