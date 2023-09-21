namespace DCU_Cuong_Tool
{
    partial class frmCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompare));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTimeLeft = new System.Windows.Forms.ComboBox();
            this.dateTimeRight = new System.Windows.Forms.DateTimePicker();
            this.rdDaiLy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeLeft = new System.Windows.Forms.DateTimePicker();
            this.rbNodeBlackList = new System.Windows.Forms.RadioButton();
            this.rbNodeOffline = new System.Windows.Forms.RadioButton();
            this.rbNodeOnline = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbCountDiff = new System.Windows.Forms.Label();
            this.lbCountLeft = new System.Windows.Forms.Label();
            this.lbCountRight = new System.Windows.Forms.Label();
            this.dtgvLeft = new System.Windows.Forms.DataGridView();
            this.dtgvRight = new System.Windows.Forms.DataGridView();
            this.cbTimeRight = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRight)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbTimeRight);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbTimeLeft);
            this.panel1.Controls.Add(this.dateTimeRight);
            this.panel1.Controls.Add(this.rdDaiLy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimeLeft);
            this.panel1.Controls.Add(this.rbNodeBlackList);
            this.panel1.Controls.Add(this.rbNodeOffline);
            this.panel1.Controls.Add(this.rbNodeOnline);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1422, 104);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(706, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Khung giờ";
            // 
            // cbTimeLeft
            // 
            this.cbTimeLeft.FormattingEnabled = true;
            this.cbTimeLeft.Location = new System.Drawing.Point(418, 52);
            this.cbTimeLeft.Name = "cbTimeLeft";
            this.cbTimeLeft.Size = new System.Drawing.Size(121, 28);
            this.cbTimeLeft.TabIndex = 15;
            // 
            // dateTimeRight
            // 
            this.dateTimeRight.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeRight.Location = new System.Drawing.Point(786, 56);
            this.dateTimeRight.Name = "dateTimeRight";
            this.dateTimeRight.Size = new System.Drawing.Size(119, 26);
            this.dateTimeRight.TabIndex = 13;
            // 
            // rdDaiLy
            // 
            this.rdDaiLy.AutoSize = true;
            this.rdDaiLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdDaiLy.Location = new System.Drawing.Point(481, 12);
            this.rdDaiLy.Name = "rdDaiLy";
            this.rdDaiLy.Size = new System.Drawing.Size(96, 24);
            this.rdDaiLy.TabIndex = 11;
            this.rdDaiLy.TabStop = true;
            this.rdDaiLy.Text = "Hóa Đơn";
            this.rdDaiLy.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ngày";
            // 
            // dateTimeLeft
            // 
            this.dateTimeLeft.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLeft.Location = new System.Drawing.Point(169, 55);
            this.dateTimeLeft.Name = "dateTimeLeft";
            this.dateTimeLeft.Size = new System.Drawing.Size(119, 26);
            this.dateTimeLeft.TabIndex = 8;
            // 
            // rbNodeBlackList
            // 
            this.rbNodeBlackList.AutoSize = true;
            this.rbNodeBlackList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNodeBlackList.Location = new System.Drawing.Point(313, 12);
            this.rbNodeBlackList.Name = "rbNodeBlackList";
            this.rbNodeBlackList.Size = new System.Drawing.Size(142, 24);
            this.rbNodeBlackList.TabIndex = 6;
            this.rbNodeBlackList.TabStop = true;
            this.rbNodeBlackList.Text = "Node Black List";
            this.rbNodeBlackList.UseVisualStyleBackColor = true;
            // 
            // rbNodeOffline
            // 
            this.rbNodeOffline.AutoSize = true;
            this.rbNodeOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNodeOffline.Location = new System.Drawing.Point(169, 12);
            this.rbNodeOffline.Name = "rbNodeOffline";
            this.rbNodeOffline.Size = new System.Drawing.Size(120, 24);
            this.rbNodeOffline.TabIndex = 5;
            this.rbNodeOffline.TabStop = true;
            this.rbNodeOffline.Text = "Node Offline";
            this.rbNodeOffline.UseVisualStyleBackColor = true;
            // 
            // rbNodeOnline
            // 
            this.rbNodeOnline.AutoSize = true;
            this.rbNodeOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNodeOnline.Location = new System.Drawing.Point(32, 12);
            this.rbNodeOnline.Name = "rbNodeOnline";
            this.rbNodeOnline.Size = new System.Drawing.Size(119, 24);
            this.rbNodeOnline.TabIndex = 4;
            this.rbNodeOnline.TabStop = true;
            this.rbNodeOnline.Text = "Node Online";
            this.rbNodeOnline.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(595, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lbCountDiff);
            this.panel3.Controls.Add(this.lbCountLeft);
            this.panel3.Controls.Add(this.lbCountRight);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 559);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1422, 67);
            this.panel3.TabIndex = 18;
            // 
            // lbCountDiff
            // 
            this.lbCountDiff.AutoSize = true;
            this.lbCountDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountDiff.Location = new System.Drawing.Point(539, 42);
            this.lbCountDiff.Name = "lbCountDiff";
            this.lbCountDiff.Size = new System.Drawing.Size(0, 25);
            this.lbCountDiff.TabIndex = 11;
            // 
            // lbCountLeft
            // 
            this.lbCountLeft.AutoSize = true;
            this.lbCountLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountLeft.Location = new System.Drawing.Point(123, 14);
            this.lbCountLeft.Name = "lbCountLeft";
            this.lbCountLeft.Size = new System.Drawing.Size(98, 25);
            this.lbCountLeft.TabIndex = 10;
            this.lbCountLeft.Text = "Số lượng";
            // 
            // lbCountRight
            // 
            this.lbCountRight.AutoSize = true;
            this.lbCountRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountRight.Location = new System.Drawing.Point(974, 14);
            this.lbCountRight.Name = "lbCountRight";
            this.lbCountRight.Size = new System.Drawing.Size(98, 25);
            this.lbCountRight.TabIndex = 9;
            this.lbCountRight.Text = "Số lượng";
            // 
            // dtgvLeft
            // 
            this.dtgvLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLeft.Location = new System.Drawing.Point(52, 110);
            this.dtgvLeft.Name = "dtgvLeft";
            this.dtgvLeft.RowHeadersWidth = 62;
            this.dtgvLeft.RowTemplate.Height = 28;
            this.dtgvLeft.Size = new System.Drawing.Size(591, 443);
            this.dtgvLeft.TabIndex = 19;
            // 
            // dtgvRight
            // 
            this.dtgvRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvRight.Location = new System.Drawing.Point(669, 110);
            this.dtgvRight.Name = "dtgvRight";
            this.dtgvRight.RowHeadersWidth = 62;
            this.dtgvRight.RowTemplate.Height = 28;
            this.dtgvRight.Size = new System.Drawing.Size(591, 443);
            this.dtgvRight.TabIndex = 20;
            // 
            // cbTimeRight
            // 
            this.cbTimeRight.FormattingEnabled = true;
            this.cbTimeRight.Location = new System.Drawing.Point(1014, 52);
            this.cbTimeRight.Name = "cbTimeRight";
            this.cbTimeRight.Size = new System.Drawing.Size(121, 28);
            this.cbTimeRight.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(928, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Khung giờ";
            // 
            // frmCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 626);
            this.Controls.Add(this.dtgvRight);
            this.Controls.Add(this.dtgvLeft);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WM03Soft";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimeRight;
        private System.Windows.Forms.RadioButton rdDaiLy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeLeft;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbNodeBlackList;
        private System.Windows.Forms.RadioButton rbNodeOffline;
        private System.Windows.Forms.RadioButton rbNodeOnline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTimeLeft;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbCountRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtgvLeft;
        private System.Windows.Forms.DataGridView dtgvRight;
        private System.Windows.Forms.Label lbCountLeft;
        private System.Windows.Forms.Label lbCountDiff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTimeRight;
    }
}