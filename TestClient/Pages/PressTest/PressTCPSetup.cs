using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace TestClient.Pages.PressTest
{
    public partial class PressTCPSetup : Form
    {
        event System.EventHandler Received;

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
        //public int Switch
        //{
        //    set
        //    {
        //        _switch = value;
        //        if (_switch == 1)
        //        {
        //            btn_Connect.Enabled = false;
        //            btn_Disconnect.Enabled = true;
        //        }
        //        else if (_switch == 0)
        //        {
        //            btn_Connect.Enabled = true;
        //            btn_Disconnect.Enabled = false;
        //        }
        //    }
        //    get { return _switch; }
        //}

        public PressTCPSetup()
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
        }

        private void TCPSendFirstPage_Load(object sender, EventArgs e)
        {
           
        }

        private void ReceiveMessage()
        {

        }

        private void btn_SendMSG_Click(object sender, EventArgs e)
        {

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

        }

        private void rbtn_Continly_Click(object sender, EventArgs e)
        {

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
        }

        private byte[] ConvertDataHeadValueToBytes(string type, string text,int length=20)
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
        /// 获取用户指定哪个数据头项作为数据长度
        /// </summary>
        /// <param name="direction">0：发送方向；1：接收方向</param>
        /// <returns>0：未指定  1：第一项  2：第二项  3：第三项</returns>
        private int GetChoosedDataHeadOfContentLength(int direction)
        {
            int choosedDataHead = 0;
            if (direction == 0)
            {
                if (rbtn_DataLen_Send1.Checked)
                {
                    choosedDataHead = 1;
                }
                else if (rbtn_DataLen_Send2.Checked)
                {
                    choosedDataHead = 2;
                }
                else if (rbtn_DataLen_Send3.Checked)
                {
                    choosedDataHead = 3;
                }
            }
            else if (direction == 1)
            {
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
            }
            return choosedDataHead;
        }
    }
}
