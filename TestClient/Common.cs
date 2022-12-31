using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    public class Common
    {
        public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static IPEndPoint? RemoteAddress;

        static Common()
        {
            var configKeys = config.AppSettings.Settings.AllKeys;
            if (configKeys.Contains("RemoteIP") && configKeys.Contains("RemotePort"))
            {
                string remoteIP = config.AppSettings.Settings["RemoteIP"].Value;
                string remotePort = config.AppSettings.Settings["RemotePort"].Value;
                RemoteAddress = new IPEndPoint(IPAddress.Parse(remoteIP), int.Parse(remotePort));
            }
        }

        public static void ConfigSet(string key,string value)
        {
            if (config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings[key].Value = value;
            }
            else
            {
                config.AppSettings.Settings.Add(key, value);
            }
            config.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection("appSettings");
        }

        public static IEnumerable<IPAddress> GetLocal_IPv4_Addresses()
        {
            List<IPAddress> ips = new List<IPAddress>();
            string hostName = Dns.GetHostName();
            IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
            foreach (var ip in ipHostInfo.AddressList)
            {
                if (ip.AddressFamily ==AddressFamily.InterNetwork)
                {
                    ips.Add(ip);
                }
            }
            return ips;
        }

        public static bool PortHasOccupied(int port)
        {
            bool inUse = false;
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }
    }
}
