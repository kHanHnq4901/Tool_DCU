﻿namespace DCU_Cuong_Tool
{
    partial class frmChar
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChar));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb180 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeOffSet = new System.Windows.Forms.TextBox();
            this.cbBlackList = new System.Windows.Forms.CheckBox();
            this.cbOffline = new System.Windows.Forms.CheckBox();
            this.cbOnline = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1422, 626);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1422, 567);
            this.panel3.TabIndex = 5;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Lime,
        System.Drawing.Color.Red,
        System.Drawing.Color.Black,
        System.Drawing.Color.Aqua};
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Online";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Offline";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "BlackList";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "180";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1422, 567);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Biểu đồ thống kê các node online và offline trong ngày ";
            this.chart1.Titles.Add(title1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb180);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTimeOffSet);
            this.panel1.Controls.Add(this.cbBlackList);
            this.panel1.Controls.Add(this.cbOffline);
            this.panel1.Controls.Add(this.cbOnline);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1422, 59);
            this.panel1.TabIndex = 3;
            // 
            // cb180
            // 
            this.cb180.AutoSize = true;
            this.cb180.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb180.Location = new System.Drawing.Point(578, 16);
            this.cb180.Name = "cb180";
            this.cb180.Size = new System.Drawing.Size(91, 24);
            this.cb180.TabIndex = 43;
            this.cb180.Text = "Hóa đơn";
            this.cb180.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "Giờ";
            // 
            // txtTimeOffSet
            // 
            this.txtTimeOffSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeOffSet.Location = new System.Drawing.Point(272, 15);
            this.txtTimeOffSet.Name = "txtTimeOffSet";
            this.txtTimeOffSet.Size = new System.Drawing.Size(100, 26);
            this.txtTimeOffSet.TabIndex = 40;
            this.txtTimeOffSet.Text = "1";
            // 
            // cbBlackList
            // 
            this.cbBlackList.AutoSize = true;
            this.cbBlackList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBlackList.Location = new System.Drawing.Point(708, 16);
            this.cbBlackList.Name = "cbBlackList";
            this.cbBlackList.Size = new System.Drawing.Size(98, 24);
            this.cbBlackList.TabIndex = 5;
            this.cbBlackList.Text = "Black List";
            this.cbBlackList.UseVisualStyleBackColor = true;
            // 
            // cbOffline
            // 
            this.cbOffline.AutoSize = true;
            this.cbOffline.Checked = true;
            this.cbOffline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOffline.Location = new System.Drawing.Point(475, 15);
            this.cbOffline.Name = "cbOffline";
            this.cbOffline.Size = new System.Drawing.Size(76, 24);
            this.cbOffline.TabIndex = 4;
            this.cbOffline.Text = "Offline";
            this.cbOffline.UseVisualStyleBackColor = true;
            // 
            // cbOnline
            // 
            this.cbOnline.AutoSize = true;
            this.cbOnline.Checked = true;
            this.cbOnline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbOnline.Location = new System.Drawing.Point(378, 16);
            this.cbOnline.Name = "cbOnline";
            this.cbOnline.Size = new System.Drawing.Size(75, 24);
            this.cbOnline.TabIndex = 3;
            this.cbOnline.Text = "Online";
            this.cbOnline.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(832, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xem ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(59, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // frmChar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 626);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmChar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WM03Soft";
            this.Load += new System.EventHandler(this.frmChar_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cbOffline;
        private System.Windows.Forms.CheckBox cbOnline;
        private System.Windows.Forms.CheckBox cbBlackList;
        private System.Windows.Forms.TextBox txtTimeOffSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb180;
    }
}