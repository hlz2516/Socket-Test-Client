namespace TestClient.Pages.FuncTest
{
    partial class TCPSendFirstPage
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_datahead = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.cbb_content_type = new System.Windows.Forms.ComboBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_IPChoose = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ConnState = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_send_clear = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.rtxt_send = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_recv_clear = new System.Windows.Forms.Button();
            this.rtxt_recv = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_OneTripTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_SendTxtChTotal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_datahead);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Disconnect);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.cbb_content_type);
            this.groupBox1.Controls.Add(this.txt_Port);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbb_IPChoose);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // cbb_datahead
            // 
            this.cbb_datahead.FormattingEnabled = true;
            this.cbb_datahead.Items.AddRange(new object[] {
            "",
            "Int16",
            "Int32",
            "Int64",
            "string"});
            this.cbb_datahead.Location = new System.Drawing.Point(13, 173);
            this.cbb_datahead.Name = "cbb_datahead";
            this.cbb_datahead.Size = new System.Drawing.Size(133, 25);
            this.cbb_datahead.TabIndex = 7;
            this.cbb_datahead.SelectionChangeCommitted += new System.EventHandler(this.cbb_datahead_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "固定包头(代表内容长度)";
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(15, 359);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(131, 30);
            this.btn_Disconnect.TabIndex = 5;
            this.btn_Disconnect.Text = "断开连接";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(15, 308);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(131, 30);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // cbb_content_type
            // 
            this.cbb_content_type.FormattingEnabled = true;
            this.cbb_content_type.Items.AddRange(new object[] {
            "UTF-8",
            "ASCII",
            "Unicode"});
            this.cbb_content_type.Location = new System.Drawing.Point(15, 243);
            this.cbb_content_type.Name = "cbb_content_type";
            this.cbb_content_type.Size = new System.Drawing.Size(131, 25);
            this.cbb_content_type.TabIndex = 1;
            this.cbb_content_type.Text = "Unicode";
            this.cbb_content_type.SelectionChangeCommitted += new System.EventHandler(this.cbb_content_type_SelectionChangeCommitted);
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(63, 105);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(100, 23);
            this.txt_Port.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "内容文本类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "本地端口";
            // 
            // cbb_IPChoose
            // 
            this.cbb_IPChoose.FormattingEnabled = true;
            this.cbb_IPChoose.Location = new System.Drawing.Point(13, 58);
            this.cbb_IPChoose.Name = "cbb_IPChoose";
            this.cbb_IPChoose.Size = new System.Drawing.Size(153, 25);
            this.cbb_IPChoose.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地IP选择";
            // 
            // lbl_ConnState
            // 
            this.lbl_ConnState.AutoSize = true;
            this.lbl_ConnState.Location = new System.Drawing.Point(68, 488);
            this.lbl_ConnState.Name = "lbl_ConnState";
            this.lbl_ConnState.Size = new System.Drawing.Size(44, 17);
            this.lbl_ConnState.TabIndex = 7;
            this.lbl_ConnState.Text = "未连接";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 488);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "当前状态：";
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
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送";
            // 
            // btn_send_clear
            // 
            this.btn_send_clear.Location = new System.Drawing.Point(623, 191);
            this.btn_send_clear.Name = "btn_send_clear";
            this.btn_send_clear.Size = new System.Drawing.Size(80, 30);
            this.btn_send_clear.TabIndex = 5;
            this.btn_send_clear.Text = "清空";
            this.btn_send_clear.UseVisualStyleBackColor = true;
            this.btn_send_clear.Click += new System.EventHandler(this.btn_send_clear_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(524, 191);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(80, 30);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // rtxt_send
            // 
            this.rtxt_send.Location = new System.Drawing.Point(98, 34);
            this.rtxt_send.Name = "rtxt_send";
            this.rtxt_send.Size = new System.Drawing.Size(606, 144);
            this.rtxt_send.TabIndex = 3;
            this.rtxt_send.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "文本内容";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_recv_clear);
            this.groupBox3.Controls.Add(this.rtxt_recv);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(194, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(770, 240);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收";
            // 
            // btn_recv_clear
            // 
            this.btn_recv_clear.Location = new System.Drawing.Point(622, 195);
            this.btn_recv_clear.Name = "btn_recv_clear";
            this.btn_recv_clear.Size = new System.Drawing.Size(80, 30);
            this.btn_recv_clear.TabIndex = 6;
            this.btn_recv_clear.Text = "清空";
            this.btn_recv_clear.UseVisualStyleBackColor = true;
            this.btn_recv_clear.Click += new System.EventHandler(this.btn_recv_clear_Click);
            // 
            // rtxt_recv
            // 
            this.rtxt_recv.Location = new System.Drawing.Point(98, 36);
            this.rtxt_recv.Name = "rtxt_recv";
            this.rtxt_recv.Size = new System.Drawing.Size(606, 144);
            this.rtxt_recv.TabIndex = 4;
            this.rtxt_recv.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "文本内容";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "单次往返用时(ms)：";
            // 
            // lbl_OneTripTime
            // 
            this.lbl_OneTripTime.AutoSize = true;
            this.lbl_OneTripTime.Location = new System.Drawing.Point(269, 488);
            this.lbl_OneTripTime.Name = "lbl_OneTripTime";
            this.lbl_OneTripTime.Size = new System.Drawing.Size(15, 17);
            this.lbl_OneTripTime.TabIndex = 8;
            this.lbl_OneTripTime.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(730, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "预发送文本字符统计(Byte)：";
            // 
            // lbl_SendTxtChTotal
            // 
            this.lbl_SendTxtChTotal.AutoSize = true;
            this.lbl_SendTxtChTotal.Location = new System.Drawing.Point(881, 488);
            this.lbl_SendTxtChTotal.Name = "lbl_SendTxtChTotal";
            this.lbl_SendTxtChTotal.Size = new System.Drawing.Size(15, 17);
            this.lbl_SendTxtChTotal.TabIndex = 12;
            this.lbl_SendTxtChTotal.Text = "0";
            // 
            // TCPSendFirstPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 511);
            this.Controls.Add(this.lbl_SendTxtChTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_OneTripTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbl_ConnState);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "TCPSendFirstPage";
            this.Text = "TCPSendFirstPage";
            this.Load += new System.EventHandler(this.TCPSendFirstPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_Disconnect;
        private Button btn_Connect;
        private TextBox txt_Port;
        private Label label2;
        private ComboBox cbb_IPChoose;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label lbl_ConnState;
        private Label label5;
        private Label label6;
        private Label lbl_OneTripTime;
        private Label label8;
        private Label lbl_SendTxtChTotal;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cbb_datahead;
        private Label label3;
        private ComboBox cbb_content_type;
        private Label label4;
        private Button btn_send_clear;
        private Button btn_send;
        private RichTextBox rtxt_send;
        private Label label9;
        private Button btn_recv_clear;
        private RichTextBox rtxt_recv;
        private Label label10;
    }
}