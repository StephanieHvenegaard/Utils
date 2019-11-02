using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SHUtils.Util.Net
{
    public class Netinfo
    {
        private IPAddress[] GetIp()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry ipEntrey = Dns.GetHostEntry(hostname);
            IPAddress[] addresses = ipEntrey.AddressList;
            return addresses;
        }
        public string[] GetIpList()
        {
            IPAddress[] addresses = GetIp();
            List<string> listofaddresses = new List<string>();
            foreach (IPAddress ip in addresses)
            {
                listofaddresses.Add(ip.ToString());
            }
            return listofaddresses.ToArray();    
        }

    }
}
