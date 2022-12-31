using System.Net;
using System.Net.Sockets;

namespace MiniServer
{
    public class Program
    {
        public static  void Main()
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
                    // Receive message.
                    var buffer = new byte[1024];
                    int? bytes = client?.Receive(buffer, SocketFlags.None);
                    if (bytes > 0)
                    {
                        client?.Send(buffer, 0);
                    }
                    else if (bytes == 0)
                    {
                        Console.WriteLine("client:" + client?.RemoteEndPoint?.ToString() + " has disconnected");
                        break;
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {
                client?.Close();
                throw;
            }
        }
    }
}
