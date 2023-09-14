namespace DCU_Cuong_Tool
{
    partial class frmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNodeBlackList = new System.Windows.Forms.RadioButton();
            this.btnNodeOffline = new System.Windows.Forms.RadioButton();
            this.btnNodeOnline = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.sqLiteCommandBuilder1 = new System.Data.SQLite.SQLiteCommandBuilder();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnNodeBlackList);
            this.panel1.Controls.Add(this.btnNodeOffline);
            this.panel1.Controls.Add(this.btnNodeOnline);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 626);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(59, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 51);
            this.button1.TabIndex = 7;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNodeBlackList
            // 
            this.btnNodeBlackList.AutoSize = true;
            this.btnNodeBlackList.Location = new System.Drawing.Point(64, 244);
            this.btnNodeBlackList.Name = "btnNodeBlackList";
            this.btnNodeBlackList.Size = new System.Drawing.Size(136, 24);
            this.btnNodeBlackList.TabIndex = 6;
            this.btnNodeBlackList.TabStop = true;
            this.btnNodeBlackList.Text = "Node black list";
            this.btnNodeBlackList.UseVisualStyleBackColor = true;
            // 
            // btnNodeOffline
            // 
            this.btnNodeOffline.AutoSize = true;
            this.btnNodeOffline.Location = new System.Drawing.Point(64, 181);
            this.btnNodeOffline.Name = "btnNodeOffline";
            this.btnNodeOffline.Size = new System.Drawing.Size(122, 24);
            this.btnNodeOffline.TabIndex = 5;
            this.btnNodeOffline.TabStop = true;
            this.btnNodeOffline.Text = "Node Offline";
            this.btnNodeOffline.UseVisualStyleBackColor = true;
            // 
            // btnNodeOnline
            // 
            this.btnNodeOnline.AutoSize = true;
            this.btnNodeOnline.Location = new System.Drawing.Point(64, 127);
            this.btnNodeOnline.Name = "btnNodeOnline";
            this.btnNodeOnline.Size = new System.Drawing.Size(121, 24);
            this.btnNodeOnline.TabIndex = 4;
            this.btnNodeOnline.TabStop = true;
            this.btnNodeOnline.Text = "Node Online";
            this.btnNodeOnline.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(293, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 626);
            this.panel2.TabIndex = 1;
            // 
            // dtgvData
            // 
            this.dtgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvData.Location = new System.Drawing.Point(0, 0);
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dtgvData.RowTemplate.Height = 28;
            this.dtgvData.Size = new System.Drawing.Size(1129, 626);
            this.dtgvData.TabIndex = 0;
            // 
            // sqLiteCommandBuilder1
            // 
            this.sqLiteCommandBuilder1.DataAdapter = null;
            this.sqLiteCommandBuilder1.QuoteSuffix = "]";
            // 
            // frmList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WM03Soft";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton btnNodeBlackList;
        private System.Windows.Forms.RadioButton btnNodeOffline;
        private System.Windows.Forms.RadioButton btnNodeOnline;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}