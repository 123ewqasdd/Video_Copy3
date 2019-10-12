namespace Video_Copy3
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.b_Connect = new System.Windows.Forms.Button();
            this.b_Sender = new System.Windows.Forms.Button();
            this.tb_Send = new System.Windows.Forms.TextBox();
            this.tb_ReceiveMessage = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.b_Read_Key = new System.Windows.Forms.Button();
            this.b_SearchFile = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_Connect
            // 
            this.b_Connect.Location = new System.Drawing.Point(23, 22);
            this.b_Connect.Name = "b_Connect";
            this.b_Connect.Size = new System.Drawing.Size(87, 26);
            this.b_Connect.TabIndex = 0;
            this.b_Connect.Text = "链接服务器";
            this.b_Connect.UseVisualStyleBackColor = true;
            this.b_Connect.Click += new System.EventHandler(this.b_Connect_Click);
            // 
            // b_Sender
            // 
            this.b_Sender.Location = new System.Drawing.Point(129, 22);
            this.b_Sender.Name = "b_Sender";
            this.b_Sender.Size = new System.Drawing.Size(87, 26);
            this.b_Sender.TabIndex = 1;
            this.b_Sender.Text = "获取硬盘";
            this.b_Sender.UseVisualStyleBackColor = true;
            this.b_Sender.Click += new System.EventHandler(this.b_Sender_Click);
            // 
            // tb_Send
            // 
            this.tb_Send.Location = new System.Drawing.Point(129, 112);
            this.tb_Send.Name = "tb_Send";
            this.tb_Send.Size = new System.Drawing.Size(210, 21);
            this.tb_Send.TabIndex = 2;
            // 
            // tb_ReceiveMessage
            // 
            this.tb_ReceiveMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ReceiveMessage.Location = new System.Drawing.Point(3, 17);
            this.tb_ReceiveMessage.Name = "tb_ReceiveMessage";
            this.tb_ReceiveMessage.Size = new System.Drawing.Size(1191, 119);
            this.tb_ReceiveMessage.TabIndex = 3;
            this.tb_ReceiveMessage.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "序列化Json";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_Read_Key
            // 
            this.b_Read_Key.Location = new System.Drawing.Point(23, 67);
            this.b_Read_Key.Name = "b_Read_Key";
            this.b_Read_Key.Size = new System.Drawing.Size(87, 26);
            this.b_Read_Key.TabIndex = 5;
            this.b_Read_Key.Text = "读取值";
            this.b_Read_Key.UseVisualStyleBackColor = true;
            this.b_Read_Key.Click += new System.EventHandler(this.button2_Click);
            // 
            // b_SearchFile
            // 
            this.b_SearchFile.Location = new System.Drawing.Point(129, 67);
            this.b_SearchFile.Name = "b_SearchFile";
            this.b_SearchFile.Size = new System.Drawing.Size(87, 26);
            this.b_SearchFile.TabIndex = 6;
            this.b_SearchFile.Text = "扫描文件";
            this.b_SearchFile.UseVisualStyleBackColor = true;
            this.b_SearchFile.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.b_Connect);
            this.splitContainer1.Panel1.Controls.Add(this.tb_Send);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.b_SearchFile);
            this.splitContainer1.Panel1.Controls.Add(this.b_Sender);
            this.splitContainer1.Panel1.Controls.Add(this.b_Read_Key);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1197, 779);
            this.splitContainer1.SplitterDistance = 636;
            this.splitContainer1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ReceiveMessage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1197, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 779);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "操作界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_Connect;
        private System.Windows.Forms.Button b_Sender;
        private System.Windows.Forms.TextBox tb_Send;
        private System.Windows.Forms.RichTextBox tb_ReceiveMessage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_Read_Key;
        private System.Windows.Forms.Button b_SearchFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

