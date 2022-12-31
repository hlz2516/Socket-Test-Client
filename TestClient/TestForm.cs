using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient
{
    public partial class TestForm : Form
    {
        private TabPage tabPage;
        private Panel testPageContainer;
        private Pages.TCPSendFirstPage tcpSendFirstPage;

        public TestForm()
        {
            InitializeComponent();
            tabPage = new TabPage();
            tabPage.Location = new Point(4, 26);
            tabPage.Name = "TCPSendFirstPage_1";
            tabPage.Padding = new Padding(3);
            tabPage.Text = "先发后接(TCP)_1";
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Dock = DockStyle.Fill;
            
            testPageContainer = new Panel();
            testPageContainer.Location = new Point(0, 0);
            testPageContainer.Dock = DockStyle.Fill;
            tabPage.Controls.Add(testPageContainer);

            tcpSendFirstPage = new Pages.TCPSendFirstPage();
            tcpSendFirstPage.Location = new Point(0, 0);
            tcpSendFirstPage.Dock = DockStyle.Fill;
            tcpSendFirstPage.FormBorderStyle = FormBorderStyle.None;
            tcpSendFirstPage.ControlBox = false;
            tcpSendFirstPage.TopLevel = false;
            tcpSendFirstPage.Visible = true;
            testPageContainer.Controls.Add(tcpSendFirstPage);

            tabControl1.TabPages.Add(tabPage);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debug.WriteLine("curindex:" + tabControl1.SelectedIndex);
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            
        }

        public void AddPage(TabPage page)
        {
            //page的name属性以及text属性可能会重复，这里做一下处理
            List<TabPage> TCPsfPages = new List<TabPage>();
            foreach (TabPage p in tabControl1.TabPages)
            {
                if (p.Name.StartsWith("TCPSendFirstPage"))
                {
                    TCPsfPages.Add(p);
                }
            }
            TabPage? lastTPCsfPage = TCPsfPages.MaxBy((p) =>
            {
                var splitArr = p.Name.Split('_');
                if (splitArr.Length == 2)
                {
                    return int.Parse(splitArr[1]);
                }
                return -1;
            });
            if (lastTPCsfPage != null)
            {
                int newPageIndex = int.Parse(lastTPCsfPage.Name.Split('_')[1]) + 1;
                page.Name = page.Name + '_' + newPageIndex;
                page.Text = page.Text + '_' + newPageIndex;
            }
            tabControl1.TabPages.Add(page);
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1 ;
        }

        private void Item_DelPage_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 1)
            {
                return;
            }
            int curIndex = tabControl1.SelectedIndex;
            tabControl1.TabPages.RemoveAt(curIndex);
            tabControl1.Update();
        }
    }
}
