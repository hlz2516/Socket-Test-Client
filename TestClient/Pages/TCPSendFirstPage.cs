using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace TestClient.Pages
{
    public partial class TCPSendFirstPage : Form
    {
        event System.EventHandler Received;

        private Thread TcpThread;
        private Thread RecvThread;
        private Socket? client = null;
        private Stopwatch stopwatch;
        /// <summary>
        /// 开始为true，停止为false
        /// </summary>
        private bool continFlag = false;
        private bool CanRecv = true;
        private int _switch;
        /// <summary>
        /// 1:连接状态  0：断开连接状态
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
                }
                else if (_switch == 0)
                {
                    btn_Connect.Enabled = true;
                    btn_Disconnect.Enabled = false;
                }
            }
            get { return _switch; }
        }

        public TCPSendFirstPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            Switch = 0;
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
            catch (Exception)
            {
                MessageBox.Show("请检查远程服务器设置与本地设置是否合理", "连接远程服务器失败！");
                client = null;
            }
        }

        private void TCP_CheckState()
        {
            try
            {
                //RecvFlag = true;
                while (client is not null && client.Connected)
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
                        Switch=0;
                    }));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Socket发生错误");
                client?.Close();
                client = null;
                return;
            }
        }

        private void ReceiveMessage()
        {
            while (CanRecv)
            {
                int? bufSize = client?.Available;
                if (bufSize.HasValue)
                {
                    if (bufSize > 0)
                    {
                        byte[] bytes = new byte[(int)bufSize];
                        client?.Receive(bytes, SocketFlags.None);
                        Invoke(new Action(() =>
                        {
                            stopwatch.Stop();
                        }));
                        string textType = GetSelectedRbtnText(groupBox3);
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                lbl_OneTripTime.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("#.##");
                                if (textType == "UTF-8")
                                {
                                    rtxt_Receive.Text = Encoding.UTF8.GetString(bytes);
                                }
                                else if (textType == "Unicode")
                                {
                                    rtxt_Receive.Text = Encoding.Unicode.GetString(bytes);
                                }
                                else if (textType == "ASCII")
                                {
                                    rtxt_Receive.Text = Encoding.ASCII.GetString(bytes);
                                }
                                Received?.Invoke(this,EventArgs.Empty);
                            }));
                        }
                    }
                }
                Thread.Sleep(50);
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (client?.Connected == true)
            {
                DeleteReceivedDescribed();
                rbtn_OneStep.Checked = true;
                Thread.Sleep(200);
                client.Close();
                client = null;
                Switch = 0;
            }
        }

        private void btn_SendMSG_Click(object sender, EventArgs e)
        {
            if (rtxt_Send.Text == "")
            {
                return;
            }

            if (client?.Connected == true)
            {
                string textType = GetSelectedRbtnText(groupBox2);
                byte[] buf = new byte[1];
                if (textType == "UTF-8")
                {
                    buf = Encoding.UTF8.GetBytes(rtxt_Send.Text);
                }
                else if (textType == "Unicode")
                {
                    buf = Encoding.Unicode.GetBytes(rtxt_Send.Text);
                }
                else if (textType == "ASCII")
                {
                    buf = Encoding.ASCII.GetBytes(rtxt_Send.Text);
                }
                client.SendAsync(buf, SocketFlags.None);
                stopwatch.Restart();
            }
        }

        private string GetSelectedRbtnText(GroupBox gb)
        {
            string res = "";
            foreach (Control ctrl in gb.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rbtn = (RadioButton)ctrl;
                    if (rbtn.Checked)
                    {
                        res = rbtn.Text;
                        break;
                    }
                }
            }
            return res;
        }

        private void btn_Clear1_Click(object sender, EventArgs e)
        {
            rtxt_Send.Text = "";
        }

        private void btn_Clear2_Click(object sender, EventArgs e)
        {
            rtxt_Receive.Text = "";
        }

        private void rbtn_OneStep_Click(object sender, EventArgs e)
        {
            if (btn_SendMSG.Visible)
            {
                return;
            }
            btn_continly.Visible = false;
            btn_SendMSG.Visible = true;

            DeleteReceivedDescribed();
        }

        private void rbtn_Continly_Click(object sender, EventArgs e)
        {
            if (btn_continly.Visible)
            {
                return;
            }
            btn_continly.Visible = true;
            btn_SendMSG.Visible = false;
            continFlag = false;
        }

        private void DeleteReceivedDescribed()
        {
            if (Received != null)
            {
                foreach (var del in Received.GetInvocationList())
                {
                    if (del.Method.Name.Contains("btn_SendMSG_Click"))
                    {
                        Received -= btn_SendMSG_Click;
                        break;
                    }
                }
            }
        }

        private void btn_continly_Click(object sender, EventArgs e)
        {
            if (!continFlag)
            {
                if (rtxt_Send.Text == "")
                {
                    MessageBox.Show("请指定发送内容");
                    return;
                }
                bool hasDescribed = false;
                if (Received != null)
                {
                    foreach (var del in Received.GetInvocationList())
                    {
                        if (del.Method.Name.Contains("btn_SendMSG_Click"))
                        {
                            hasDescribed = true;
                            break;
                        }
                    }
                }

                if (!hasDescribed)
                {
                    //订阅接收数据完成事件
                    Received += btn_SendMSG_Click;
                }
                //触发第一次发送消息，之后会接收发送无限循环
                btn_SendMSG_Click(sender, e);

                btn_continly.Text = "终止";
                continFlag = !continFlag;
            }
            else
            {
                DeleteReceivedDescribed();
                btn_continly.Text = "开始";
                continFlag = !continFlag;
            }
        }
    }
}
