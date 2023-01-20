using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MiniServer
{
    public class Program
    {
        private static readonly string PREFIX = "||";

        public static void Main()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Loopback;
            foreach (var ip in ipHostInfo.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip;
                    break;
                }
            }
            IPEndPoint ipEndPoint = new(ipAddress, 11000);
            //Console.WriteLine("server ip:" + ipEndPoint.ToString());
            Socket listener = new(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(100);
            while (true)
            {
                ThreadPool.QueueUserWorkItem(echo, listener.Accept());
            }
        }

        private static void echo(object? obj)
        {
            Socket client = obj as Socket;
            Console.WriteLine("client:" + client?.RemoteEndPoint?.ToString() + " has connected");
            try
            {
                while (true)
                {
                    int? bufCnt = client?.Available;
                    if (bufCnt.HasValue)
                    {
                        #region logic
                        if (bufCnt > 0)
                        {
                            //message,ex:"10helloworld"
                            //10 means content length,it has 8 bytes
                            byte[] lenBuf = new byte[8];
                            int? length = client?.Receive(lenBuf, SocketFlags.None);
                            if (length > 0)
                            {
                                //string prefix = Encoding.UTF8.GetString(prefixBuf);
                                //if (prefix == PREFIX)
                                //{
                                long len = BitConverter.ToInt64(lenBuf);
                                long received = 0;
                                byte[] buffer = new byte[len];
                                while (len > 0)
                                {
                                    int? tmpLen = client?.Receive(buffer, (int)received, (int)(len - received), SocketFlags.None);
                                    received += (int)tmpLen;
                                    len -= (int)tmpLen;
                                }
                                Console.WriteLine("len:" + received + ",content:" + Encoding.Unicode.GetString(buffer));
                                byte[] sendBuf = lenBuf.Concat(buffer).ToArray();
                                client?.Send(sendBuf,SocketFlags.None);
                                //}
                                //else
                                //{
                                //    //clear receive buffer
                                //    while (client?.Available > 0)
                                //    {
                                //        byte[]? tmpbuf = new byte[10240];
                                //        client?.Receive(tmpbuf, SocketFlags.None);
                                //        tmpbuf = null;
                                //    }
                                //}
                            }
                            else if (length == 0)
                            {
                                Console.WriteLine("client:" + client?.RemoteEndPoint?.ToString() + " has disconnected");
                                break;
                            }
                        }
                        else
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        #endregion
                        //byte[] buf = new byte[1024];
                        //client?.Receive(buf, SocketFlags.None);
                        //client?.Send(buf, SocketFlags.None);
                    }
                }
                client?.Close();
            }
            catch (Exception)
            {
                client?.Close();
                throw;
            }
        }
    }
}
