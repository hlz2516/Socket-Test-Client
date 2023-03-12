namespace TestClient.Pages.FuncTest
{
    partial class UDPTestPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_local_port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_remoteIP = new System.Windows.Forms.TextBox();
            this.cbb_content_type = new System.Windows.Forms.ComboBox();
            this.txt_remote_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_send_clear = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.rtxt_send = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_recv_clear = new System.Windows.Forms.Button();
            this.rtxt_recv = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_local_port);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_remoteIP);
            this.groupBox1.Controls.Add(this.cbb_content_type);
            this.groupBox1.Controls.Add(this.txt_remote_port);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 479);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // txt_local_port
            // 
            this.txt_local_port.Location = new System.Drawing.Point(63, 163);
            this.txt_local_port.Name = "txt_local_port";
            this.txt_local_port.Size = new System.Drawing.Size(100, 23);
            this.txt_local_port.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "本地端口";
            // 
            // txt_remoteIP
            // 
            this.txt_remoteIP.Location = new System.Drawing.Point(13, 49);
            this.txt_remoteIP.Name = "txt_remoteIP";
            this.txt_remoteIP.Size = new System.Drawing.Size(150, 23);
            this.txt_remoteIP.TabIndex = 1;
            // 
            // cbb_content_type
            // 
            this.cbb_content_type.FormattingEnabled = true;
            this.cbb_content_type.Items.AddRange(new object[] {
            "UTF-8",
            "ASCII",
            "Unicode"});
            this.cbb_content_type.Location = new System.Drawing.Point(15, 240);
            this.cbb_content_type.Name = "cbb_content_type";
            this.cbb_content_type.Size = new System.Drawing.Size(131, 25);
            this.cbb_content_type.TabIndex = 7;
            this.cbb_content_type.Text = "Unicode";
            this.cbb_content_type.SelectionChangeCommitted += new System.EventHandler(this.cbb_content_type_SelectionChangeCommitted);
            // 
            // txt_remote_port
            // 
            this.txt_remote_port.Location = new System.Drawing.Point(63, 105);
            this.txt_remote_port.Name = "txt_remote_port";
            this.txt_remote_port.Size = new System.Drawing.Size(100, 23);
            this.txt_remote_port.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "内容文本类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "远程端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "远程服务器地址";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_send_clear);
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Controls.Add(this.rtxt_send);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(194, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 240);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送";
            // 
            // btn_send_clear
            // 
            this.btn_send_clear.Location = new System.Drawing.Point(623, 191);
            this.btn_send_clear.Name = "btn_send_clear";
            this.btn_send_clear.Size = new System.Drawing.Size(80, 30);
            this.btn_send_clear.TabIndex = 15;
            this.btn_send_clear.Text = "清空";
            this.btn_send_clear.UseVisualStyleBackColor = true;
            this.btn_send_clear.Click += new System.EventHandler(this.btn_send_clear_Click);
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(524, 191);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(80, 30);
            this.btn_send.TabIndex = 14;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // rtxt_send
            // 
            this.rtxt_send.Location = new System.Drawing.Point(98, 34);
            this.rtxt_send.Name = "rtxt_send";
            this.rtxt_send.Size = new System.Drawing.Size(606, 144);
            this.rtxt_send.TabIndex = 13;
            this.rtxt_send.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "文本内容";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_recv_clear);
            this.groupBox3.Controls.Add(this.rtxt_recv);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(194, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(770, 240);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收";
            // 
            // btn_recv_clear
            // 
            this.btn_recv_clear.Location = new System.Drawing.Point(622, 190);
            this.btn_recv_clear.Name = "btn_recv_clear";
            this.btn_recv_clear.Size = new System.Drawing.Size(80, 30);
            this.btn_recv_clear.TabIndex = 19;
            this.btn_recv_clear.Text = "清空";
            this.btn_recv_clear.UseVisualStyleBackColor = true;
            this.btn_recv_clear.Click += new System.EventHandler(this.btn_recv_clear_Click);
            // 
            // rtxt_recv
            // 
            this.rtxt_recv.Location = new System.Drawing.Point(98, 36);
            this.rtxt_recv.Name = "rtxt_recv";
            this.rtxt_recv.Size = new System.Drawing.Size(606, 144);
            this.rtxt_recv.TabIndex = 18;
            this.rtxt_recv.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "文本内容";
            // 
            // UDPTestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 511);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UDPTestPage";
            this.Text = "UDPTestPage";
            this.Load += new System.EventHandler(this.UDPTestPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbb_content_type;
        private TextBox txt_remote_port;
        private Label label4;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Button btn_send_clear;
        private Button btn_send;
        private RichTextBox rtxt_send;
        private Label label9;
        private GroupBox groupBox3;
        private Button btn_recv_clear;
        private RichTextBox rtxt_recv;
        private Label label10;
        private TextBox txt_remoteIP;
        private TextBox txt_local_port;
        private Label label3;
    }
}