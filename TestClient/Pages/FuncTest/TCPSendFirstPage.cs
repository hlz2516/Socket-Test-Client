using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace TestClient.Pages.FuncTest
{
    public partial class TCPSendFirstPage : Form
    {
        private readonly int RECV_BUF_SIZE = 1024;

        private Thread TcpThread;  //实时监控socket是否处于连接状态
        private Thread RecvThread;
        private Socket? client = null;
        private bool canRecv = true;  //控制socket接收线程是否结束
        private int _switch;
        private string dataHead;
        private string contentType;
        /// <summary>
        /// 1:连接状态  0:断开连接状态
        /// </summary>
        public int Switch
        {
            set
            {
                _switch = value;
                if (_switch == 1)
                {
                    btn_Connect.Enabled = false;
                    btn_Disconnect.Enabled = true;
                    cbb_datahead.Enabled = false;
                }
                else if (_switch == 0)
                {
                    btn_Connect.Enabled = true;
                    btn_Disconnect.Enabled = false;
                    cbb_datahead.Enabled = true;
                }
            }
            get { return _switch; }
        }

        public TCPSendFirstPage()
        {
            InitializeComponent();
        }

        private void TCPSendFirstPage_Load(object sender, EventArgs e)
        {
            //加载本地可选IP(IPv4)
            var ips = Common.GetLocal_IPv4_Addresses();
            foreach (var ip in ips)
            {
                cbb_IPChoose.Items.Add(ip.ToString());
            }
            if (ips.Any())
            {
                cbb_IPChoose.Text = ips.First().ToString();
            }
            //选择本地默认端口
            txt_Port.Text = 8888.ToString();
            dataHead = "";
            contentType = "Unicode";
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            //先检查要使用的本地端口是否被占用，若被占用，则提示用户切换一下
            int port = int.Parse(txt_Port.Text);
            if (Common.PortHasOccupied(port))
            {
                MessageBox.Show("此端口已被占用，请选择其他端口");
                txt_Port.Text = "";
                return;
            }
            if (Common.RemoteAddress == null)
            {
                MessageBox.Show("请先设置远程服务器IP与端口");
                return;
            }
            try
            {
                client = new Socket(
                    Common.RemoteAddress.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );
                client.Connect(Common.RemoteAddress);
                Switch = 1;
                TcpThread = new Thread(new ThreadStart(TCP_CheckState));
                TcpThread.Name = "TcpCheckState";
                TcpThread.IsBackground = true;
                TcpThread.Start();

                RecvThread = new Thread(new ThreadStart(ReceiveMessage));
                RecvThread.IsBackground = true;
                RecvThread.Name = "RecvMsg";
                RecvThread.Start();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("请检查远程服务器设置与本地设置是否合理", ex);
                client?.Close();
            }
        }

        private void TCP_CheckState()
        {
            try
            {
                while (client != null && client.Connected)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            lbl_ConnState.Text = "已连接";
                            Switch = 1;
                        }));
                    }
                    Thread.Sleep(1000);
                }
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        lbl_ConnState.Text = "未连接";
                        Switch = 0;
                    }));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Socket发生错误", ex);
                client?.Close();
                client = null;
                return;
            }
        }

        private void ReceiveMessage()
        {
            while (canRecv)
            {
                RecvAndUpdateUI();
                Thread.Sleep(100);
            }
        }

        private void RecvAndUpdateUI()
        {
            long recvBufSize = 0;
            //检查是否有数据包头
            if (!string.IsNullOrEmpty(dataHead))
            {
                //如果不为空，接收包头里的数据，用该数据覆盖默认接收缓冲区大小
                var bytes = Common.ConvertDataHeadValueToBytes(dataHead, "");
                try
                {
                    client?.Receive(bytes, SocketFlags.None);
                    string size = Common.ConvertBytesToDataHeadValue(dataHead, bytes);
                    long.TryParse(size, out recvBufSize);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("接收数据包头失败", ex);
                }
            }
            else
            {
                recvBufSize = RECV_BUF_SIZE;
            }

            try
            {
                byte[] recvBuf = new byte[recvBufSize];
                client?.Receive(recvBuf, SocketFlags.None);
                this.Invoke(new Action(() =>
                {
                    switch (contentType)
                    {
                        case "UTF-8":
                            rtxt_recv.Text = Encoding.UTF8.GetString(recvBuf);
                            break;
                        case "Unicode":
                            rtxt_recv.Text = Encoding.Unicode.GetString(recvBuf);
                            break;
                        case "ASCII":
                            rtxt_recv.Text = Encoding.ASCII.GetString(recvBuf);
                            break;
                        case "":
                            rtxt_recv.Text = Encoding.Default.GetString(recvBuf);
                            break;
                        default:
                            break;
                    }
                }));
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("接收数据错误", ex);
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (client?.Connected == true)
            {
                DeleteReceivedDescribed();
                //Thread.Sleep(200);
                client.Close();
                client = null;
                Switch = 0;
            }
        }

        private void DeleteReceivedDescribed()
        {

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //检查是否有固定包头，如果有，则先发送包头
            if (!string.IsNullOrEmpty(cbb_datahead.Text))
            {
                //计算文本长度，根据选择的文本类型计算
                int contentLen = 0;
                switch (cbb_content_type.Text)
                {
                    case "UTF-8":
                        contentLen = Encoding.UTF8.GetByteCount(rtxt_send.Text);
                        break;
                    case "ASCII":
                        contentLen = Encoding.ASCII.GetByteCount(rtxt_send.Text);
                        break;
                    case "Unicode":
                        contentLen = Encoding.Unicode.GetByteCount(rtxt_send.Text);
                        break;
                    default:
                        break;
                }
                var bytes = Common.ConvertDataHeadValueToBytes(cbb_datahead.Text, contentLen.ToString());
                try
                {
                    client?.SendAsync(bytes, SocketFlags.None);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("发送数据包头错误", ex);
                }
            }
            //根据文本类型转换字节然后发送
            byte[] content = new byte[0];
            switch (cbb_content_type.Text)
            {
                case "UTF-8":
                    content = Encoding.UTF8.GetBytes(rtxt_send.Text);
                    break;
                case "ASCII":
                    content = Encoding.ASCII.GetBytes(rtxt_send.Text);
                    break;
                case "Unicode":
                    content = Encoding.Unicode.GetBytes(rtxt_send.Text);
                    break;
                default:
                    break;
            }
            try
            {
                client?.SendAsync(content, SocketFlags.None);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("发送数据错误", ex);
            }
        }

        private void btn_send_clear_Click(object sender, EventArgs e)
        {
            rtxt_send.Text = "";
        }

        private void btn_recv_clear_Click(object sender, EventArgs e)
        {
            rtxt_recv.Text = "";
        }

        private void cbb_datahead_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataHead = cbb_datahead.Items[cbb_datahead.SelectedIndex].ToString();
        }

        private void cbb_content_type_SelectionChangeCommitted(object sender, EventArgs e)
        {
            contentType = cbb_content_type.Items[cbb_content_type.SelectedIndex].ToString();
        }
    }
}
