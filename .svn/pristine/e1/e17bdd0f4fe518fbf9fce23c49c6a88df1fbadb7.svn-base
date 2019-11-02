using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SHUtils.Networking
{
    /**********************************
        * Used in
        * ProeventServer2.Communications
       *********************************/
    public static class NetInfo
    {
        public static IPAddress[] GetIps()
        {
            string hostname = Dns.GetHostName();
            IPHostEntry ipEntrey = Dns.GetHostEntry(hostname);
            IPAddress[] addresses = ipEntrey.AddressList;
            return addresses;
        }
        public static IPAddress GetIp(EndPoint endPoint)
        {
            return ((IPEndPoint)endPoint).Address;
        } 
        public static string[] GetIpList()
        {
            IPAddress[] addresses = GetIps();
            List<string> listofaddresses = new List<string>();
            foreach (IPAddress ip in addresses)
            {
                listofaddresses.Add(ip.ToString());
            }
            return listofaddresses.ToArray();
        }
        public static string DNSResolveHostName(EndPoint endPoint)
        {
            IPAddress address = GetIp(endPoint);
            return DNSResolveHostName(address);
        }
        public static string DNSResolveHostName(IPAddress Ip)
        {
            return DNSResolveHostName(Ip.ToString());
        }
        public static string DNSResolveHostName(string Ip)
        {
            return Dns.GetHostEntry(Ip).HostName;
        }
        public static int Getport(EndPoint endPoint)
        {
            return ((IPEndPoint)endPoint).Port;
        }

    }
}