using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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

        public static byte[] ConvertDataHeadValueToBytes(string type, string text, int length = 20)
        {
            byte[] bytes = new byte[0];
            if (string.IsNullOrEmpty(type))
            {
                return bytes;
            }
            switch (type)
            {
                case "Int16":
                    short sVal;
                    //若text为空或""，则自动执行else
                    if (short.TryParse(text, out sVal))
                    {
                        bytes = BitConverter.GetBytes(sVal);
                    }
                    else bytes = new byte[2];
                    break;
                case "Int32":
                    int iVal;
                    if (int.TryParse(text, out iVal))
                    {
                        bytes = BitConverter.GetBytes(iVal);
                    }
                    else bytes = new byte[4];
                    break;
                case "Int64":
                    long lVal;
                    if (long.TryParse(text, out lVal))
                    {
                        bytes = BitConverter.GetBytes(lVal);
                    }
                    else bytes = new byte[8];
                    break;
                case "string":
                    bytes = new byte[length];
                    if (!string.IsNullOrEmpty(text))
                    {
                        Encoding.ASCII.GetBytes(text, bytes);
                    }
                    break;
                default:
                    break;
            }
            return bytes;
        }

        public static string ConvertBytesToDataHeadValue(string type, byte[] bytes)
        {
            if (string.IsNullOrEmpty(type))
            {
                return "";
            }

            string res = "";
            try
            {
                switch (type)
                {
                    case "Int16":
                        res = BitConverter.ToInt16(bytes).ToString();
                        break;
                    case "Int32":
                        res = BitConverter.ToInt32(bytes).ToString();
                        break;
                    case "Int64":
                        res = BitConverter.ToInt64(bytes).ToString();
                        break;
                    case "string":
                        res = Encoding.ASCII.GetString(bytes);
                        break;
                }
                return res;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("转换失败", e);
                return "";
            }
        }
    }
}
