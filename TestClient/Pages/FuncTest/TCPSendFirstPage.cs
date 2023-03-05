using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace TestClient.Pages.FuncTest
{
    public partial class TCPSendFirstPage : Form
    {
        event EventHandler Received;

        private readonly int ONE_TRIP_AVG_CYCLE = 100;

        private Thread TcpThread;
        private Thread RecvThread;
        private Socket? client = null;
        private Stopwatch stopwatch;
        /// <summary>
        /// 开始为true，停止为false
        /// </summary>
        private bool continFlag = false;
        private bool canRecv = true;
        private int _switch;
        private double accumMillsecs = 0;
        private int count = 0;
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

            cbb_DHType1.SelectedIndexChanged += (o, e) =>
            {
                numericUpDown1.Visible = cbb_DHType1.Text == "string" ? true : false;
            };
            cbb_DHType2.SelectedIndexChanged += (o, e) =>
            {
                numericUpDown2.Visible = cbb_DHType2.Text == "string" ? true : false;
            };
            cbb_DHType3.SelectedIndexChanged += (o, e) =>
            {
                numericUpDown3.Visible = cbb_DHType3.Text == "string" ? true : false;
            };
            cbb_DHType4.SelectedIndexChanged += (o, e) =>
            {
                numericUpDown4.Visible = cbb_DHType4.Text == "string" ? true : false;
            };
            cbb_DHType5.SelectedIndexChanged += (o, e) =>
            {
                numericUpDown5.Visible = cbb_DHType5.Text == "string" ? true : false;
            };
            cbb_DHType6.SelectedIndexChanged += (o, e) =>
            {
                numericUpDown6.Visible = cbb_DHType6.Text == "string" ? true : false;
            };

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
                        Switch = 0;
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
            while (canRecv)
            {
                int? bufSize = client?.Available;
                if (bufSize.HasValue)
                {
                    if (bufSize == 0)
                    {
                        Thread.Sleep(30);
                        continue;
                    }
                    string cbb_DHType4Text = "", cbb_DHType5Text = "", cbb_DHType6Text = "";
                    int numUpDown4 = 0, numUpDown5 = 0, numUpDown6 = 0;
                    Invoke(new Action(() =>
                    {
                        cbb_DHType4Text = cbb_DHType4.Text;
                        cbb_DHType5Text = cbb_DHType5.Text;
                        cbb_DHType6Text = cbb_DHType6.Text;
                        numUpDown4 = (int)numericUpDown4.Value;
                        numUpDown5 = (int)numericUpDown5.Value;
                        numUpDown6 = (int)numericUpDown6.Value;
                    }));
                    //检查用户是否设置了数据头1，如果有则按照设置接收固定字节并显示。同理对于数据头2，3
                    byte[] dhBytes1 = ConvertDataHeadValueToBytes(cbb_DHType4Text, "", numUpDown4);
                    if (dhBytes1.Length > 0)
                    {
                        client?.Receive(dhBytes1, SocketFlags.None);
                    }
                    byte[] dhBytes2 = ConvertDataHeadValueToBytes(cbb_DHType5Text, "", numUpDown5);
                    if (dhBytes2.Length > 0)
                    {
                        client?.Receive(dhBytes2, SocketFlags.None);
                    }
                    byte[] dhBytes3 = ConvertDataHeadValueToBytes(cbb_DHType6Text, "", numUpDown6);
                    if (dhBytes3.Length > 0)
                    {
                        client?.Receive(dhBytes3, SocketFlags.None);
                    }

                    Invoke(new Action(() =>
                    {
                        if (dhBytes1.Length > 0)
                        {
                            txt_DHVal4.Text = ConvertBytesToDataHeadValue(cbb_DHType4.Text, dhBytes1);
                        }
                        if (dhBytes2.Length > 0)
                        {
                            txt_DHVal5.Text = ConvertBytesToDataHeadValue(cbb_DHType5.Text, dhBytes2);
                        }
                        if (dhBytes3.Length > 0)
                        {
                            txt_DHVal6.Text = ConvertBytesToDataHeadValue(cbb_DHType6.Text, dhBytes3);
                        }
                    }));
                    int dataLen = client.Available;
                    int dataLenHead = GetChoosedDataHeadOfContentLength();
                    if (dataLenHead > 0)
                    {
                        if (dataLenHead == 1)
                        {
                            dataLen = (int)BitConverter.ToInt64(dhBytes1);
                        }
                        else if (dataLenHead == 2)
                        {
                            dataLen = (int)BitConverter.ToInt64(dhBytes2);
                        }
                        else if (dataLenHead == 3)
                        {
                            dataLen = (int)BitConverter.ToInt64(dhBytes3);
                        }
                    }
                    else
                    {
                        break;
                    }

                    byte[] bytes = new byte[dataLen];
                    int? len = client?.Receive(bytes, SocketFlags.None);
                    if (len == 0)
                    {
                        break;
                    }
                    Invoke(new Action(() =>
                    {
                        stopwatch.Stop();
                    }));

                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            double elapsedMsecs = stopwatch.Elapsed.TotalMilliseconds;
                            //显示单次往返用时
                            lbl_OneTripTime.Text = elapsedMsecs.ToString("#.##");
                            //更新平均往返用时累计
                            accumMillsecs += elapsedMsecs;
                            count++;
                            //如果达到累计周期则计算并显示平均往返用时
                            if (count == ONE_TRIP_AVG_CYCLE)
                            {
                                double avgElaMsecs = accumMillsecs / count;
                                lbl_AvgOneTripTime.Text = avgElaMsecs.ToString("#.##");
                                accumMillsecs = 0;
                                count = 0;
                            }
                            string textType = GetSelectedRbtnText(groupBox3);
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
                            Received?.Invoke(this, EventArgs.Empty);
                        }));
                    }
                }
                //如果bufSize没有值，说明client为空，网络连接中断，所以直接停止该线程
                else break;
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
            if (client?.Connected == true)
            {
                //分析组装数据头
                byte[] dataHead1 = ConvertDataHeadValueToBytes(cbb_DHType1.Text, txt_DHVal1.Text, (int)numericUpDown1.Value);
                byte[] dataHead2 = ConvertDataHeadValueToBytes(cbb_DHType2.Text, txt_DHVal2.Text, (int)numericUpDown2.Value);
                byte[] dataHead3 = ConvertDataHeadValueToBytes(cbb_DHType3.Text, txt_DHVal3.Text, (int)numericUpDown3.Value);

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
                byte[] sendBuf = dataHead1.Concat(dataHead2).Concat(dataHead3).Concat(buf).ToArray();
                client.SendAsync(sendBuf, SocketFlags.None);
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

        private void rtxt_Send_TextChanged(object sender, EventArgs e)
        {
            string textType = GetSelectedRbtnText(groupBox2);
            byte[] bytes = new byte[1];
            if (textType == "UTF-8")
            {
                bytes = Encoding.UTF8.GetBytes(rtxt_Send.Text);
            }
            else if (textType == "Unicode")
            {
                bytes = Encoding.Unicode.GetBytes(rtxt_Send.Text);
            }
            else if (textType == "ASCII")
            {
                bytes = Encoding.ASCII.GetBytes(rtxt_Send.Text);
            }
            lbl_SendTxtChTotal.Text = bytes.Length.ToString();
        }

        private byte[] ConvertDataHeadValueToBytes(string type, string text, int length = 20)
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
                case "float":
                    float fVal;
                    if (float.TryParse(text, out fVal))
                    {
                        bytes = BitConverter.GetBytes(fVal);
                    }
                    else bytes = new byte[Marshal.SizeOf(fVal)];
                    break;
                case "double":
                    double dVal;
                    if (double.TryParse(text, out dVal))
                    {
                        bytes = BitConverter.GetBytes(dVal);
                    }
                    else bytes = new byte[Marshal.SizeOf(dVal)];
                    break;
                case "bool":
                    bool bVal;
                    if (bool.TryParse(text, out bVal))
                    {
                        bytes = BitConverter.GetBytes(bVal);
                    }
                    else bytes = new byte[1];
                    break;
                case "char":
                    if (!string.IsNullOrEmpty(text))
                    {
                        char cVal = text[0];
                        bytes = BitConverter.GetBytes(cVal);
                    }
                    else bytes = new byte[1];
                    break;
                case "string":
                    bytes = new byte[length];
                    if (!string.IsNullOrEmpty(text))
                    {
                        Encoding.ASCII.GetBytes(text, bytes);
                    }
                    break;
                case "DateTime":
                    if (!string.IsNullOrEmpty(text))
                    {
                        //先转换为Unix时间戳(long)，再转换为字节数组
                        DateTime time = DateTime.Parse(text);
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

        private string ConvertBytesToDataHeadValue(string type, byte[] bytes)
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
        /// <summary>
        /// 获取用户指定哪个数据头项作为数据长度，仅在设置接收数据头时有效
        /// </summary>
        /// <returns>0：未指定  1：第一项  2：第二项  3：第三项</returns>
        private int GetChoosedDataHeadOfContentLength()
        {
            int choosedDataHead = 0;
            if (rbtn_DataLen_Recv1.Checked)
            {
                choosedDataHead = 1;
            }
            else if (rbtn_DataLen_Recv2.Checked)
            {
                choosedDataHead = 2;
            }
            else if (rbtn_DataLen_Recv3.Checked)
            {
                choosedDataHead = 3;
            }
            return choosedDataHead;
        }

        private void cbb_DHType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_DHType4.SelectedIndex = cbb_DHType1.SelectedIndex;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown4.Value = numericUpDown1.Value;
        }

        private void cbb_DHType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_DHType5.SelectedIndex = cbb_DHType2.SelectedIndex;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown5.Value = numericUpDown2.Value;
        }

        private void cbb_DHType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_DHType6.SelectedIndex = cbb_DHType3.SelectedIndex;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown6.Value = numericUpDown3.Value;
        }
    }
}
