using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SHUtils
{
    public class SuccesParse
    {
        public static bool TooIpAddress(string ipaddress)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ipaddress);
                if (ip.ToString() == ipaddress) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
