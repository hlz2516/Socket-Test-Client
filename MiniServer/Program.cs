using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MiniServer
{
    public class Program
    {
        //private static readonly string PREFIX = "||";
        static Socket udpSock;
        static EndPoint senderRemote;

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
            Console.WriteLine("sever ip:" + ipAddress.ToString());

            //Console.WriteLine("server ip:" + ipEndPoint.ToString());
            //UDP
            udpSock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint endPoibnt = new(ipAddress, 12000);
            senderRemote = (EndPoint)sender;
            udpSock.Bind(endPoibnt);
            Thread udpThread = new Thread(new ThreadStart(echo_udp));
            udpThread.Start();
            //TCP
            IPEndPoint ipEndPoint = new(ipAddress, 11000);
            Socket listener = new Socket(
                ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            listener.Bind(ipEndPoint);
            listener.Listen(100);
            while (true)
            {
                ThreadPool.QueueUserWorkItem(echo_tcp, listener.Accept());
            }
        }

        private static void echo_udp()
        {
            while (true)
            {
                try
                {
                    byte[] recvBytes = new byte[512];
                    int count = udpSock.ReceiveFrom(recvBytes, SocketFlags.None, ref senderRemote);
                    string content = Encoding.Unicode.GetString(recvBytes, 0, count);
                    Console.WriteLine(content);
                    Console.WriteLine("remote ip:" + senderRemote.ToString());
                    udpSock.SendTo(recvBytes, senderRemote);
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    udpSock.Close();
                }
            }

        }

        private static void echo_tcp(object? obj)
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
            }
        }
    }
}
