namespace TestClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerSetup_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendFirst_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReceiveFirst_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendFirstUDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReceiveFirstUDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.Test_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerSetup_ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // ServerSetup_ToolStripMenuItem
            // 
            this.ServerSetup_ToolStripMenuItem.Name = "ServerSetup_ToolStripMenuItem";
            this.ServerSetup_ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.ServerSetup_ToolStripMenuItem.Text = "远程服务器设置";
            this.ServerSetup_ToolStripMenuItem.Click += new System.EventHandler(this.ServerSetup_ToolStripMenuItem_Click);
            // 
            // Test_ToolStripMenuItem
            // 
            this.Test_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SendFirst_ToolStripMenuItem,
            this.ReceiveFirst_ToolStripMenuItem,
            this.SendFirstUDPToolStripMenuItem,
            this.ReceiveFirstUDPToolStripMenuItem});
            this.Test_ToolStripMenuItem.Name = "Test_ToolStripMenuItem";
            this.Test_ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.Test_ToolStripMenuItem.Text = "测试";
            // 
            // SendFirst_ToolStripMenuItem
            // 
            this.SendFirst_ToolStripMenuItem.Name = "SendFirst_ToolStripMenuItem";
            this.SendFirst_ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.SendFirst_ToolStripMenuItem.Text = "先发后收(TCP)";
            this.SendFirst_ToolStripMenuItem.Click += new System.EventHandler(this.SendFirst_ToolStripMenuItem_Click);
            // 
            // ReceiveFirst_ToolStripMenuItem
            // 
            this.ReceiveFirst_ToolStripMenuItem.Name = "ReceiveFirst_ToolStripMenuItem";
            this.ReceiveFirst_ToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ReceiveFirst_ToolStripMenuItem.Text = "先收后发(TCP)";
            // 
            // SendFirstUDPToolStripMenuItem
            // 
            this.SendFirstUDPToolStripMenuItem.Name = "SendFirstUDPToolStripMenuItem";
            this.SendFirstUDPToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.SendFirstUDPToolStripMenuItem.Text = "先发后收(UDP)";
            // 
            // ReceiveFirstUDPToolStripMenuItem
            // 
            this.ReceiveFirstUDPToolStripMenuItem.Name = "ReceiveFirstUDPToolStripMenuItem";
            this.ReceiveFirstUDPToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ReceiveFirstUDPToolStripMenuItem.Text = "先收后发(UDP)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SEM测试工具";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem ServerSetup_ToolStripMenuItem;
        private ToolStripMenuItem Test_ToolStripMenuItem;
        private ToolStripMenuItem SendFirst_ToolStripMenuItem;
        private ToolStripMenuItem ReceiveFirst_ToolStripMenuItem;
        private ToolStripMenuItem SendFirstUDPToolStripMenuItem;
        private ToolStripMenuItem ReceiveFirstUDPToolStripMenuItem;
    }
}