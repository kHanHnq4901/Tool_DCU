﻿namespace DCU_Cuong_Tool
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
            this.rdList = new System.Windows.Forms.RadioButton();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.rdNeighbohur = new System.Windows.Forms.RadioButton();
            this.rdInfomation = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.rdDaiLy = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.rbNodeBlackList = new System.Windows.Forms.RadioButton();
            this.rbNodeOffline = new System.Windows.Forms.RadioButton();
            this.rbNodeOnline = new System.Windows.Forms.RadioButton();
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
            this.panel1.Controls.Add(this.rdList);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.rdNeighbohur);
            this.panel1.Controls.Add(this.rdInfomation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimeEnd);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.rdDaiLy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbCount);
            this.panel1.Controls.Add(this.dateTimeStart);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.rbNodeBlackList);
            this.panel1.Controls.Add(this.rbNodeOffline);
            this.panel1.Controls.Add(this.rbNodeOnline);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1422, 81);
            this.panel1.TabIndex = 0;
            // 
            // rdList
            // 
            this.rdList.AutoSize = true;
            this.rdList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdList.Location = new System.Drawing.Point(418, 11);
            this.rdList.Name = "rdList";
            this.rdList.Size = new System.Drawing.Size(166, 24);
            this.rdList.TabIndex = 18;
            this.rdList.TabStop = true;
            this.rdList.Text = "Danh sách công tơ";
            this.rdList.UseVisualStyleBackColor = true;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Location = new System.Drawing.Point(1261, 44);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(131, 36);
            this.btnExportExcel.TabIndex = 17;
            this.btnExportExcel.Text = "Xuất file excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // rdNeighbohur
            // 
            this.rdNeighbohur.AutoSize = true;
            this.rdNeighbohur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdNeighbohur.Location = new System.Drawing.Point(314, 42);
            this.rdNeighbohur.Name = "rdNeighbohur";
            this.rdNeighbohur.Size = new System.Drawing.Size(63, 24);
            this.rdNeighbohur.TabIndex = 16;
            this.rdNeighbohur.TabStop = true;
            this.rdNeighbohur.Text = "Vị trí";
            this.rdNeighbohur.UseVisualStyleBackColor = true;
            // 
            // rdInfomation
            // 
            this.rdInfomation.AutoSize = true;
            this.rdInfomation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdInfomation.Location = new System.Drawing.Point(314, 11);
            this.rdInfomation.Name = "rdInfomation";
            this.rdInfomation.Size = new System.Drawing.Size(98, 24);
            this.rdInfomation.TabIndex = 15;
            this.rdInfomation.TabStop = true;
            this.rdInfomation.Text = "Thông tin";
            this.rdInfomation.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(679, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Đến";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeEnd.Location = new System.Drawing.Point(745, 52);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(119, 26);
            this.dateTimeEnd.TabIndex = 13;
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(1261, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(131, 36);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Xuất file world";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // rdDaiLy
            // 
            this.rdDaiLy.AutoSize = true;
            this.rdDaiLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdDaiLy.Location = new System.Drawing.Point(166, 42);
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
            this.label1.Location = new System.Drawing.Point(679, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Từ";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCount.Location = new System.Drawing.Point(1022, 26);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(0, 25);
            this.lbCount.TabIndex = 9;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStart.Location = new System.Drawing.Point(745, 6);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(119, 26);
            this.dateTimeStart.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(885, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Xem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbNodeBlackList
            // 
            this.rbNodeBlackList.AutoSize = true;
            this.rbNodeBlackList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbNodeBlackList.Location = new System.Drawing.Point(166, 12);
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
            this.rbNodeOffline.Location = new System.Drawing.Point(32, 42);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1422, 545);
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
            this.dtgvData.Size = new System.Drawing.Size(1422, 545);
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
        private System.Windows.Forms.RadioButton rbNodeBlackList;
        private System.Windows.Forms.RadioButton rbNodeOffline;
        private System.Windows.Forms.RadioButton rbNodeOnline;
        private System.Data.SQLite.SQLiteCommandBuilder sqLiteCommandBuilder1;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdDaiLy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.RadioButton rdNeighbohur;
        private System.Windows.Forms.RadioButton rdInfomation;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.RadioButton rdList;
    }
}