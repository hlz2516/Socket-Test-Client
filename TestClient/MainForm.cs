using TestClient.Pages.FuncTest;
using TestClient.Pages.PressTest;

namespace TestClient
{
    public partial class MainForm : Form
    {
        private TestForm testForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ServerSetup_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Hide();
            var serverSetupForm = new ServerSetupForm();
            serverSetupForm.MdiParent = this;
            serverSetupForm.Show();
        }

        private void SendFirst_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Hide();
            if (testForm == null)
            {
                testForm = new TestForm();
                testForm.MdiParent = this;
            }
            else
            {
                //新建一个TCPSendFirstPage添加进去
                var tabPage = new TabPage();
                tabPage.Location = new Point(4, 26);
                tabPage.Name = "TCPSendFirstPage";
                tabPage.Padding = new Padding(3);
                tabPage.Text = "先发后接(TCP)";
                tabPage.UseVisualStyleBackColor = true;
                tabPage.Dock = DockStyle.Fill;

                var testPageContainer = new Panel();
                testPageContainer.Location = new Point(0, 0);
                testPageContainer.Dock = DockStyle.Fill;
                tabPage.Controls.Add(testPageContainer);

                var tcpSendFirstPage = new TCPSendFirstPage();
                tcpSendFirstPage.Location = new Point(0, 0);
                tcpSendFirstPage.Dock = DockStyle.Fill;
                tcpSendFirstPage.FormBorderStyle = FormBorderStyle.None;
                tcpSendFirstPage.ControlBox = false;
                tcpSendFirstPage.TopLevel = false;
                tcpSendFirstPage.Visible = true;
                testPageContainer.Controls.Add(tcpSendFirstPage);

                testForm.AddPage(tabPage);
            }
            testForm.Show();
        }

        private void Item_Setup_Personal_Click(object sender, EventArgs e)
        {

        }

        private void Test_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testForm != null)
            {
                testForm.Show();
            }
        }

        private void TCPTest_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Hide();
            var TCPTestForm = new TCP_SetupPage();
            TCPTestForm.MdiParent = this;
            TCPTestForm.Show();
        }
    }
}