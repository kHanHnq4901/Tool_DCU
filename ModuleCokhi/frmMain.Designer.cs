namespace WM03Soft
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbPortList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlSeri = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDCUNo = new System.Windows.Forms.TextBox();
            this.pnlComand = new System.Windows.Forms.Panel();
            this.btnChar = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnNodeOnline = new System.Windows.Forms.Button();
            this.btnBlackList = new System.Windows.Forms.Button();
            this.btnNodeOffline = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCurrentTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.btnEnd = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlSeri.SuspendLayout();
            this.pnlComand.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbOutput
            // 
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(1080, 626);
            this.rtbOutput.TabIndex = 17;
            this.rtbOutput.Text = "";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbOutput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(342, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 626);
            this.panel2.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbPortList);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnRead);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 100);
            this.panel3.TabIndex = 30;
            // 
            // cmbPortList
            // 
            this.cmbPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortList.FormattingEnabled = true;
            this.cmbPortList.Location = new System.Drawing.Point(88, 13);
            this.cmbPortList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPortList.Name = "cmbPortList";
            this.cmbPortList.Size = new System.Drawing.Size(148, 28);
            this.cmbPortList.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cổng";
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.SystemColors.Window;
            this.btnRead.Image = global::DCU_Cuong_Tool.Properties.Resources.connect_line_icon_236099;
            this.btnRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRead.Location = new System.Drawing.Point(21, 51);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(136, 49);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Mở COM";
            this.btnRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::DCU_Cuong_Tool.Properties.Resources.disconnect_line_icon_236081;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(173, 51);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(149, 49);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Đóng COM";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button4_Click);
            // 
            // pnlSeri
            // 
            this.pnlSeri.Controls.Add(this.label5);
            this.pnlSeri.Controls.Add(this.txtDCUNo);
            this.pnlSeri.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeri.Location = new System.Drawing.Point(0, 100);
            this.pnlSeri.Name = "pnlSeri";
            this.pnlSeri.Size = new System.Drawing.Size(342, 51);
            this.pnlSeri.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Seri DCU";
            // 
            // txtDCUNo
            // 
            this.txtDCUNo.Location = new System.Drawing.Point(109, 8);
            this.txtDCUNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDCUNo.Name = "txtDCUNo";
            this.txtDCUNo.Size = new System.Drawing.Size(197, 26);
            this.txtDCUNo.TabIndex = 24;
            this.txtDCUNo.Text = "665544332211";
            // 
            // pnlComand
            // 
            this.pnlComand.Controls.Add(this.btnEnd);
            this.pnlComand.Controls.Add(this.btnChar);
            this.pnlComand.Controls.Add(this.btnList);
            this.pnlComand.Controls.Add(this.btnStart);
            this.pnlComand.Controls.Add(this.btnNodeOnline);
            this.pnlComand.Controls.Add(this.btnBlackList);
            this.pnlComand.Controls.Add(this.btnNodeOffline);
            this.pnlComand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComand.Location = new System.Drawing.Point(0, 151);
            this.pnlComand.Name = "pnlComand";
            this.pnlComand.Size = new System.Drawing.Size(342, 239);
            this.pnlComand.TabIndex = 35;
            // 
            // btnChar
            // 
            this.btnChar.Location = new System.Drawing.Point(172, 60);
            this.btnChar.Name = "btnChar";
            this.btnChar.Size = new System.Drawing.Size(140, 52);
            this.btnChar.TabIndex = 37;
            this.btnChar.Text = "Biểu đồ";
            this.btnChar.UseVisualStyleBackColor = true;
            this.btnChar.Click += new System.EventHandler(this.btnChar_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(17, 118);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(140, 52);
            this.btnList.TabIndex = 36;
            this.btnList.Text = "Danh sách";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(174, 118);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(139, 52);
            this.btnStart.TabIndex = 35;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnNodeOnline
            // 
            this.btnNodeOnline.Location = new System.Drawing.Point(17, 6);
            this.btnNodeOnline.Name = "btnNodeOnline";
            this.btnNodeOnline.Size = new System.Drawing.Size(140, 48);
            this.btnNodeOnline.TabIndex = 32;
            this.btnNodeOnline.Text = "Node online ";
            this.btnNodeOnline.UseVisualStyleBackColor = true;
            this.btnNodeOnline.Click += new System.EventHandler(this.btnNodeOnline_Click);
            // 
            // btnBlackList
            // 
            this.btnBlackList.Location = new System.Drawing.Point(173, 6);
            this.btnBlackList.Name = "btnBlackList";
            this.btnBlackList.Size = new System.Drawing.Size(139, 48);
            this.btnBlackList.TabIndex = 33;
            this.btnBlackList.Text = "Black list ";
            this.btnBlackList.UseVisualStyleBackColor = true;
            this.btnBlackList.Click += new System.EventHandler(this.btnBlackList_Click);
            // 
            // btnNodeOffline
            // 
            this.btnNodeOffline.Location = new System.Drawing.Point(17, 60);
            this.btnNodeOffline.Name = "btnNodeOffline";
            this.btnNodeOffline.Size = new System.Drawing.Size(140, 52);
            this.btnNodeOffline.TabIndex = 34;
            this.btnNodeOffline.Text = "Node offline";
            this.btnNodeOffline.UseVisualStyleBackColor = true;
            this.btnNodeOffline.Click += new System.EventHandler(this.btnNodeOffline_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbCurrentTime);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnClearLog);
            this.panel1.Controls.Add(this.pnlComand);
            this.panel1.Controls.Add(this.pnlSeri);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 626);
            this.panel1.TabIndex = 30;
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.AutoSize = true;
            this.lbCurrentTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentTime.Location = new System.Drawing.Point(83, 421);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(0, 26);
            this.lbCurrentTime.TabIndex = 38;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DCU_Cuong_Tool.Properties.Resources.clock_time_time_9949;
            this.pictureBox1.Location = new System.Drawing.Point(21, 415);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.LightCoral;
            this.btnClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.Image = global::DCU_Cuong_Tool.Properties.Resources.clear_icon_155649;
            this.btnClearLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearLog.Location = new System.Drawing.Point(73, 564);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(174, 50);
            this.btnClearLog.TabIndex = 36;
            this.btnClearLog.Text = "Xóa Log ";
            this.btnClearLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.SystemColors.Window;
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(17, 176);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(139, 52);
            this.btnEnd.TabIndex = 38;
            this.btnEnd.Text = "Kết Thúc";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WM03Soft";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlSeri.ResumeLayout(false);
            this.pnlSeri.PerformLayout();
            this.pnlComand.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbPortList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlSeri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDCUNo;
        private System.Windows.Forms.Panel pnlComand;
        private System.Windows.Forms.Button btnChar;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnNodeOnline;
        private System.Windows.Forms.Button btnBlackList;
        private System.Windows.Forms.Button btnNodeOffline;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbCurrentTime;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button btnEnd;
    }
}

