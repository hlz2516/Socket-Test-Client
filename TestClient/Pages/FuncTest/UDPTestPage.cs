using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestClient.Interfaces;

namespace TestClient.Pages.FuncTest
{
    public partial class UDPTestPage : Form, ICloseThreads
    {
        private IPEndPoint remotePoint;
        private Thread? RecvThread;
        private Socket client = null;
        private string? contentType;
        private bool breakRecv = false;//控制socket接收线程是否结束，窗体关闭时结束
        private bool canRecv = false;  //控制是否接收，断开socket连接时无法接收
        private int _switch = 0;
        private EndPoint senderRemote;

        /// <summary>
        /// 1:可发送状态  0:不可发送状态
        /// </summary>
        public int Switch
        {
            set
            {
                _switch = value;
                if (_switch == 1)
                {
                    btn_send.Enabled = true;
                }
                else if (_switch == 0)
                {
                    btn_send.Enabled = false;
                }
            }
            get { return _switch; }
        }

        public UDPTestPage()
        {
            InitializeComponent();
            Switch = 1;
        }

        private void UDPTestPage_Load(object sender, EventArgs e)
        {
            //远程IP极有可能与TCP设置的IP一致，因此默认值为common中的一致
            txt_remoteIP.Text = Common.RemoteAddress.Address.ToString();
            //默认文本类型
            contentType = "Unicode";
            //创建监听者
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
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint serverEp = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint endPoibnt = new(ipAddress, 12000);
            senderRemote = (EndPoint)serverEp;
            //设置线程并开始运行
            RecvThread = new Thread(new ThreadStart(ReceiveMessage));
            RecvThread.IsBackground = true;
            RecvThread.Start();
            canRecv = true;
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                if (canRecv)
                {
                    try
                    {
                        //接收信息
                        byte[] recvBytes = new byte[1024];
                        int count = client.ReceiveFrom(recvBytes, SocketFlags.None, ref senderRemote);
                        string recvContent = "";
                        switch (contentType)
                        {
                            case "UTF-8":
                                recvContent = Encoding.UTF8.GetString(recvBytes,0,count);
                                break;
                            case "ASCII":
                                recvContent = Encoding.ASCII.GetString(recvBytes, 0, count);
                                break;
                            case "Unicode":
                                recvContent = Encoding.Unicode.GetString(recvBytes, 0, count);
                                break;
                            case "":
                                recvContent = Encoding.Default.GetString(recvBytes, 0, count);
                                break;
                            default:
                                break;
                        }
                        //更新UI
                        this.Invoke(new Action(() =>
                        {
                            rtxt_recv.Text = recvContent;
                        }));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog("接收UDP消息并更新UI错误", ex);
                    }
                }
                if (breakRecv)
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }

        private void cbb_content_type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            contentType = cbb_content_type.Items[cbb_content_type.SelectedIndex].ToString();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //int localPort;
            //if (!int.TryParse(txt_local_port.Text, out localPort))
            //{
            //    MessageBox.Show("请设置本地端口！");
            //    return;
            //}
            int remotePort;
            if (!int.TryParse(txt_remote_port.Text, out remotePort))
            {
                MessageBox.Show("请设置远程服务器端口！");
                return;
            }
            IPAddress remoteIp;
            if (!IPAddress.TryParse(txt_remoteIP.Text, out remoteIp))
            {
                MessageBox.Show("请设置远程服务器IP！");
                return;
            }
            remotePoint = new IPEndPoint(remoteIp, remotePort);
            byte[] sendBytes = new byte[0];
            switch (contentType)
            {
                case "UTF-8":
                    sendBytes = Encoding.UTF8.GetBytes(rtxt_send.Text);
                    break;
                case "ASCII":
                    sendBytes = Encoding.ASCII.GetBytes(rtxt_send.Text);
                    break;
                case "Unicode":
                    sendBytes = Encoding.Unicode.GetBytes(rtxt_send.Text);
                    break;
                case "":
                    sendBytes = Encoding.Default.GetBytes(rtxt_send.Text);
                    break;
                default:
                    break;
            }

            try
            {
                client?.SendTo(sendBytes, remotePoint);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("发送UDP消息错误", ex);
            }
        }

        public void CloseThreads()
        {
            canRecv = false;
            breakRecv = true;
        }

        private void btn_send_clear_Click(object sender, EventArgs e)
        {
            rtxt_send.Text = "";
        }

        private void btn_recv_clear_Click(object sender, EventArgs e)
        {
            rtxt_recv.Text = "";
        }
        //private void btn_Connect_Click(object sender, EventArgs e)
        //{
        //    int localPort;
        //    if (!int.TryParse(txt_local_port.Text, out localPort))
        //    {
        //        MessageBox.Show("请设置本地端口！");
        //        return;
        //    }
        //    int remotePort;
        //    if (!int.TryParse(txt_remote_port.Text, out remotePort))
        //    {
        //        MessageBox.Show("请设置远程服务器端口！");
        //        return;
        //    }
        //    IPAddress remoteIp;
        //    if (!IPAddress.TryParse(txt_remoteIP.Text, out remoteIp))
        //    {
        //        MessageBox.Show("请设置远程服务器IP！");
        //        return;
        //    }
        //    remotePoint = new IPEndPoint(remoteIp, remotePort);
        //    client = new UdpClient(localPort);
        //    client.Connect(remoteIp, remotePort);
        //    canRecv = true;
        //    Switch = 1;
        //}

        //private void btn_Disconnect_Click(object sender, EventArgs e)
        //{
        //    canRecv = false;
        //    client?.Close();
        //    client = null;
        //    Switch = 0;
        //}
    }
}
