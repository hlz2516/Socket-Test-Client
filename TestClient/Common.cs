using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

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
        /// <summary>
        ///  根据给定的数据类型得到其所占用的内存(字节)大小
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] GetDataHeadBytes(string type, string value, int length = 20)
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
                    if (short.TryParse(value, out sVal))
                    {
                        bytes = BitConverter.GetBytes(sVal);
                    }
                    else bytes = new byte[2];
                    break;
                case "Int32":
                    int iVal;
                    if (int.TryParse(value, out iVal))
                    {
                        bytes = BitConverter.GetBytes(iVal);
                    }
                    else bytes = new byte[4];
                    break;
                case "Int64":
                    long lVal;
                    if (long.TryParse(value, out lVal))
                    {
                        bytes = BitConverter.GetBytes(lVal);
                    }
                    else bytes = new byte[8];
                    break;
                case "float":
                    float fVal;
                    if (float.TryParse(value, out fVal))
                    {
                        bytes = BitConverter.GetBytes(fVal);
                    }
                    else bytes = new byte[Marshal.SizeOf(fVal)];
                    break;
                case "double":
                    double dVal;
                    if (double.TryParse(value, out dVal))
                    {
                        bytes = BitConverter.GetBytes(dVal);
                    }
                    else bytes = new byte[Marshal.SizeOf(dVal)];
                    break;
                case "bool":
                    bool bVal;
                    if (bool.TryParse(value, out bVal))
                    {
                        bytes = BitConverter.GetBytes(bVal);
                    }
                    else bytes = new byte[1];
                    break;
                case "char":
                    if (!string.IsNullOrEmpty(value))
                    {
                        char cVal = value[0];
                        bytes = BitConverter.GetBytes(cVal);
                    }
                    else bytes = new byte[1];
                    break;
                case "string":
                    bytes = new byte[length];
                    if (!string.IsNullOrEmpty(value))
                    {
                        Encoding.ASCII.GetBytes(value, bytes);
                    }
                    break;
                case "DateTime":
                    if (!string.IsNullOrEmpty(value))
                    {
                        //先转换为Unix时间戳(long)，再转换为字节数组
                        DateTime time = DateTime.Parse(value);
                        long timeStamp = (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                        bytes = BitConverter.GetBytes(timeStamp);
                    }
                    else bytes = new byte[64];
                    break;
                default:
                    break;
            }
            return bytes;
        }
        /// <summary>
        /// 根据数据类型将字节数组转换为具体的对应的值
        /// </summary>
        /// <param name="type">数据类型</param>
        /// <param name="bytes">字节数组</param>
        /// <returns></returns>
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
                    case "float":
                        res = BitConverter.ToSingle(bytes).ToString("#.##");
                        break;
                    case "double":
                        res = BitConverter.ToDouble(bytes).ToString("#.##");
                        break;
                    case "bool":
                        res = BitConverter.ToBoolean(bytes).ToString();
                        break;
                    case "char":
                    case "string":
                        res = Encoding.ASCII.GetString(bytes);
                        break;
                    case "DateTime":
                        //先把字节数组转为long即Unix时间戳，再换回当前时间显示
                        long timeStamp = BitConverter.ToInt64(bytes);
                        long ticks = timeStamp * 10000000 + 621355968000000000;
                        DateTime t = new DateTime(ticks);
                        res = t.ToString("G");
                        break;
                }
                return res;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "";
            }
        }
    }
}
