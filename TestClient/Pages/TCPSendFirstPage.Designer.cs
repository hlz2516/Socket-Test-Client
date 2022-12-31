namespace TestClient.Pages
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_continly = new System.Windows.Forms.Button();
            this.rbtn_Continly = new System.Windows.Forms.RadioButton();
            this.rbtn_OneStep = new System.Windows.Forms.RadioButton();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_IPChoose = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ConnState = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Clear1 = new System.Windows.Forms.Button();
            this.btn_SendMSG = new System.Windows.Forms.Button();
            this.rtxt_Send = new System.Windows.Forms.RichTextBox();
            this.rbtn_HEX_Send = new System.Windows.Forms.RadioButton();
            this.rbtn_UTF16_Send = new System.Windows.Forms.RadioButton();
            this.rbtn_UTF8_Send = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Clear2 = new System.Windows.Forms.Button();
            this.rtxt_Receive = new System.Windows.Forms.RichTextBox();
            this.rbtn_HEX_Recv = new System.Windows.Forms.RadioButton();
            this.rbtn_UTF16_Recv = new System.Windows.Forms.RadioButton();
            this.rbtn_UTF8_Recv = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_OneTripTime = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_continly);
            this.groupBox1.Controls.Add(this.rbtn_Continly);
            this.groupBox1.Controls.Add(this.rbtn_OneStep);
            this.groupBox1.Controls.Add(this.btn_Disconnect);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.txt_Port);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbb_IPChoose);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 468);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // btn_continly
            // 
            this.btn_continly.Location = new System.Drawing.Point(28, 346);
            this.btn_continly.Name = "btn_continly";
            this.btn_continly.Size = new System.Drawing.Size(113, 36);
            this.btn_continly.TabIndex = 10;
            this.btn_continly.Text = "开始";
            this.btn_continly.UseVisualStyleBackColor = true;
            this.btn_continly.Visible = false;
            this.btn_continly.Click += new System.EventHandler(this.btn_continly_Click);
            // 
            // rbtn_Continly
            // 
            this.rbtn_Continly.AutoSize = true;
            this.rbtn_Continly.Location = new System.Drawing.Point(46, 300);
            this.rbtn_Continly.Name = "rbtn_Continly";
            this.rbtn_Continly.Size = new System.Drawing.Size(74, 21);
            this.rbtn_Continly.TabIndex = 9;
            this.rbtn_Continly.Text = "连发模式";
            this.rbtn_Continly.UseVisualStyleBackColor = true;
            this.rbtn_Continly.Click += new System.EventHandler(this.rbtn_Continly_Click);
            // 
            // rbtn_OneStep
            // 
            this.rbtn_OneStep.AutoSize = true;
            this.rbtn_OneStep.Checked = true;
            this.rbtn_OneStep.Location = new System.Drawing.Point(46, 259);
            this.rbtn_OneStep.Name = "rbtn_OneStep";
            this.rbtn_OneStep.Size = new System.Drawing.Size(74, 21);
            this.rbtn_OneStep.TabIndex = 8;
            this.rbtn_OneStep.TabStop = true;
            this.rbtn_OneStep.Text = "单发模式";
            this.rbtn_OneStep.UseVisualStyleBackColor = true;
            this.rbtn_OneStep.Click += new System.EventHandler(this.rbtn_OneStep_Click);
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(23, 196);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(123, 30);
            this.btn_Disconnect.TabIndex = 5;
            this.btn_Disconnect.Text = "断开连接";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(23, 148);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(123, 30);
            this.btn_Connect.TabIndex = 4;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(63, 105);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(100, 23);
            this.txt_Port.TabIndex = 3;
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
            this.lbl_ConnState.Location = new System.Drawing.Point(68, 477);
            this.lbl_ConnState.Name = "lbl_ConnState";
            this.lbl_ConnState.Size = new System.Drawing.Size(44, 17);
            this.lbl_ConnState.TabIndex = 7;
            this.lbl_ConnState.Text = "未连接";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 477);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "当前状态：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Clear1);
            this.groupBox2.Controls.Add(this.btn_SendMSG);
            this.groupBox2.Controls.Add(this.rtxt_Send);
            this.groupBox2.Controls.Add(this.rbtn_HEX_Send);
            this.groupBox2.Controls.Add(this.rbtn_UTF16_Send);
            this.groupBox2.Controls.Add(this.rbtn_UTF8_Send);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(194, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 222);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送";
            // 
            // btn_Clear1
            // 
            this.btn_Clear1.Location = new System.Drawing.Point(630, 182);
            this.btn_Clear1.Name = "btn_Clear1";
            this.btn_Clear1.Size = new System.Drawing.Size(75, 30);
            this.btn_Clear1.TabIndex = 6;
            this.btn_Clear1.Text = "清空";
            this.btn_Clear1.UseVisualStyleBackColor = true;
            this.btn_Clear1.Click += new System.EventHandler(this.btn_Clear1_Click);
            // 
            // btn_SendMSG
            // 
            this.btn_SendMSG.Location = new System.Drawing.Point(530, 182);
            this.btn_SendMSG.Name = "btn_SendMSG";
            this.btn_SendMSG.Size = new System.Drawing.Size(75, 30);
            this.btn_SendMSG.TabIndex = 5;
            this.btn_SendMSG.Text = "发送";
            this.btn_SendMSG.UseVisualStyleBackColor = true;
            this.btn_SendMSG.Click += new System.EventHandler(this.btn_SendMSG_Click);
            // 
            // rtxt_Send
            // 
            this.rtxt_Send.Location = new System.Drawing.Point(18, 62);
            this.rtxt_Send.Name = "rtxt_Send";
            this.rtxt_Send.Size = new System.Drawing.Size(736, 115);
            this.rtxt_Send.TabIndex = 4;
            this.rtxt_Send.Text = "";
            // 
            // rbtn_HEX_Send
            // 
            this.rbtn_HEX_Send.AutoSize = true;
            this.rbtn_HEX_Send.Location = new System.Drawing.Point(328, 27);
            this.rbtn_HEX_Send.Name = "rbtn_HEX_Send";
            this.rbtn_HEX_Send.Size = new System.Drawing.Size(57, 21);
            this.rbtn_HEX_Send.TabIndex = 3;
            this.rbtn_HEX_Send.Text = "ASCII";
            this.rbtn_HEX_Send.UseVisualStyleBackColor = true;
            // 
            // rbtn_UTF16_Send
            // 
            this.rbtn_UTF16_Send.AutoSize = true;
            this.rbtn_UTF16_Send.Checked = true;
            this.rbtn_UTF16_Send.Location = new System.Drawing.Point(214, 28);
            this.rbtn_UTF16_Send.Name = "rbtn_UTF16_Send";
            this.rbtn_UTF16_Send.Size = new System.Drawing.Size(74, 21);
            this.rbtn_UTF16_Send.TabIndex = 2;
            this.rbtn_UTF16_Send.TabStop = true;
            this.rbtn_UTF16_Send.Text = "Unicode";
            this.rbtn_UTF16_Send.UseVisualStyleBackColor = true;
            // 
            // rbtn_UTF8_Send
            // 
            this.rbtn_UTF8_Send.AutoSize = true;
            this.rbtn_UTF8_Send.Location = new System.Drawing.Point(108, 29);
            this.rbtn_UTF8_Send.Name = "rbtn_UTF8_Send";
            this.rbtn_UTF8_Send.Size = new System.Drawing.Size(60, 21);
            this.rbtn_UTF8_Send.TabIndex = 1;
            this.rbtn_UTF8_Send.Text = "UTF-8";
            this.rbtn_UTF8_Send.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "文本字符类型：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Clear2);
            this.groupBox3.Controls.Add(this.rtxt_Receive);
            this.groupBox3.Controls.Add(this.rbtn_HEX_Recv);
            this.groupBox3.Controls.Add(this.rbtn_UTF16_Recv);
            this.groupBox3.Controls.Add(this.rbtn_UTF8_Recv);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(194, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(770, 241);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收";
            // 
            // btn_Clear2
            // 
            this.btn_Clear2.Location = new System.Drawing.Point(630, 186);
            this.btn_Clear2.Name = "btn_Clear2";
            this.btn_Clear2.Size = new System.Drawing.Size(75, 30);
            this.btn_Clear2.TabIndex = 7;
            this.btn_Clear2.Text = "清空";
            this.btn_Clear2.UseVisualStyleBackColor = true;
            this.btn_Clear2.Click += new System.EventHandler(this.btn_Clear2_Click);
            // 
            // rtxt_Receive
            // 
            this.rtxt_Receive.Location = new System.Drawing.Point(18, 63);
            this.rtxt_Receive.Name = "rtxt_Receive";
            this.rtxt_Receive.Size = new System.Drawing.Size(733, 115);
            this.rtxt_Receive.TabIndex = 5;
            this.rtxt_Receive.Text = "";
            // 
            // rbtn_HEX_Recv
            // 
            this.rbtn_HEX_Recv.AutoSize = true;
            this.rbtn_HEX_Recv.Location = new System.Drawing.Point(325, 32);
            this.rbtn_HEX_Recv.Name = "rbtn_HEX_Recv";
            this.rbtn_HEX_Recv.Size = new System.Drawing.Size(57, 21);
            this.rbtn_HEX_Recv.TabIndex = 4;
            this.rbtn_HEX_Recv.Text = "ASCII";
            this.rbtn_HEX_Recv.UseVisualStyleBackColor = true;
            // 
            // rbtn_UTF16_Recv
            // 
            this.rbtn_UTF16_Recv.AutoSize = true;
            this.rbtn_UTF16_Recv.Checked = true;
            this.rbtn_UTF16_Recv.Location = new System.Drawing.Point(211, 32);
            this.rbtn_UTF16_Recv.Name = "rbtn_UTF16_Recv";
            this.rbtn_UTF16_Recv.Size = new System.Drawing.Size(74, 21);
            this.rbtn_UTF16_Recv.TabIndex = 3;
            this.rbtn_UTF16_Recv.TabStop = true;
            this.rbtn_UTF16_Recv.Text = "Unicode";
            this.rbtn_UTF16_Recv.UseVisualStyleBackColor = true;
            // 
            // rbtn_UTF8_Recv
            // 
            this.rbtn_UTF8_Recv.AutoSize = true;
            this.rbtn_UTF8_Recv.Location = new System.Drawing.Point(113, 32);
            this.rbtn_UTF8_Recv.Name = "rbtn_UTF8_Recv";
            this.rbtn_UTF8_Recv.Size = new System.Drawing.Size(60, 21);
            this.rbtn_UTF8_Recv.TabIndex = 2;
            this.rbtn_UTF8_Recv.Text = "UTF-8";
            this.rbtn_UTF8_Recv.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "文本字符类型：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(160, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "单次往返用时(ms)：";
            // 
            // lbl_OneTripTime
            // 
            this.lbl_OneTripTime.AutoSize = true;
            this.lbl_OneTripTime.Location = new System.Drawing.Point(269, 477);
            this.lbl_OneTripTime.Name = "lbl_OneTripTime";
            this.lbl_OneTripTime.Size = new System.Drawing.Size(15, 17);
            this.lbl_OneTripTime.TabIndex = 8;
            this.lbl_OneTripTime.Text = "0";
            // 
            // TCPSendFirstPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 501);
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
        private Button btn_Clear1;
        private Button btn_SendMSG;
        private RichTextBox rtxt_Send;
        private RadioButton rbtn_HEX_Send;
        private RadioButton rbtn_UTF16_Send;
        private RadioButton rbtn_UTF8_Send;
        private Label label3;
        private GroupBox groupBox3;
        private Button btn_Clear2;
        private RichTextBox rtxt_Receive;
        private RadioButton rbtn_HEX_Recv;
        private RadioButton rbtn_UTF16_Recv;
        private RadioButton rbtn_UTF8_Recv;
        private Label label4;
        private Label lbl_ConnState;
        private Label label5;
        private RadioButton rbtn_Continly;
        private RadioButton rbtn_OneStep;
        private Label label6;
        private Label lbl_OneTripTime;
        private Button btn_continly;
    }
}