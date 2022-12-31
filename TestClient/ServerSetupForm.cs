using System.Diagnostics;
using System.Net;

namespace TestClient
{
    public partial class ServerSetupForm : Form
    {
        private IPAddress? remoteIP = null;
        private int remotePort = 0;

        public ServerSetupForm()
        {
            InitializeComponent();
        }

        private void ServerSetupForm_Load(object sender, EventArgs e)
        {
            if (Common.RemoteAddress is not null)
            {
                textBox1.Text = Common.RemoteAddress.Address.ToString();
                textBox2.Text = Common.RemoteAddress.Port.ToString();
                remoteIP = Common.RemoteAddress.Address;
                remotePort = Common.RemoteAddress.Port;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            bool isParsed = IPAddress.TryParse(textBox1.Text, out remoteIP);
            if (!isParsed)
            {
                MessageBox.Show("该IP不合法，请重新输入！");
                textBox1.Text = "";
            }
            else Debug.WriteLine("ip:" + remoteIP);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            bool isParsed = int.TryParse(textBox2.Text, out remotePort);
            if (!isParsed)
            {
                MessageBox.Show("该端口不合法，请输入数字！");
                textBox2.Text = "";
            }
            else
            {
                if (remotePort < 1000 || remotePort > 65535)
                {
                    MessageBox.Show("该端口不在合理范围内，请输入1000~65535之间的端口号！");
                    textBox2.Text = "";
                }
                else Debug.WriteLine("port:" + remotePort);
            }
        }

        private void ServerSetupForm_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (remoteIP != null && remotePort >= 1000)
            {
                Common.RemoteAddress = new IPEndPoint(remoteIP, remotePort);
                Common.ConfigSet("RemoteIP", textBox1.Text);
                Common.ConfigSet("RemotePort", textBox2.Text);
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败，请检查IP与端口是否合法");
            }
        }


    }
}
