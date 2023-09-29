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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pn2 = new Guna.UI.WinForms.GunaElipsePanel();
            this.prgLoad = new Guna.UI2.WinForms.Guna2ProgressIndicator();
            this.dtgvNode = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnLocation = new Guna.UI2.WinForms.Guna2Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReadInfomationNode = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.txtSerialNode = new Guna.UI2.WinForms.Guna2TextBox();
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbRatiov180 = new System.Windows.Forms.Label();
            this.lbV180 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbRatioOffline = new System.Windows.Forms.Label();
            this.lbOffline = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbRatioOnline = new System.Windows.Forms.Label();
            this.lbOnline = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbPortList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlSeri = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDCUNo = new System.Windows.Forms.TextBox();
            this.pnlComand = new System.Windows.Forms.Panel();
            this.btnInfomation = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeGet = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnChar = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnNodeOnline = new System.Windows.Forms.Button();
            this.btnBlackList = new System.Windows.Forms.Button();
            this.btnNodeOffline = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.panel2.SuspendLayout();
            this.pn2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNode)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.gunaElipsePanel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlSeri.SuspendLayout();
            this.pnlComand.SuspendLayout();
            this.panel1.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pn2);
            this.panel2.Controls.Add(this.gunaElipsePanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(279, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(741, 626);
            this.panel2.TabIndex = 31;
            // 
            // pn2
            // 
            this.pn2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn2.BackColor = System.Drawing.Color.Transparent;
            this.pn2.BaseColor = System.Drawing.Color.White;
            this.pn2.Controls.Add(this.prgLoad);
            this.pn2.Controls.Add(this.dtgvNode);
            this.pn2.Controls.Add(this.guna2CustomGradientPanel1);
            this.pn2.Location = new System.Drawing.Point(0, 145);
            this.pn2.Name = "pn2";
            this.pn2.Size = new System.Drawing.Size(741, 526);
            this.pn2.TabIndex = 20;
            // 
            // prgLoad
            // 
            this.prgLoad.AnimationSpeed = 90;
            this.prgLoad.AutoStart = true;
            this.prgLoad.Location = new System.Drawing.Point(340, 156);
            this.prgLoad.Name = "prgLoad";
            this.prgLoad.Size = new System.Drawing.Size(46, 50);
            this.prgLoad.TabIndex = 54;
            this.prgLoad.Visible = false;
            // 
            // dtgvNode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgvNode.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvNode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvNode.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvNode.ColumnHeadersHeight = 30;
            this.dtgvNode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvNode.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvNode.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgvNode.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvNode.Location = new System.Drawing.Point(0, 64);
            this.dtgvNode.Name = "dtgvNode";
            this.dtgvNode.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgvNode.RowHeadersVisible = false;
            this.dtgvNode.RowHeadersWidth = 62;
            this.dtgvNode.RowTemplate.Height = 28;
            this.dtgvNode.Size = new System.Drawing.Size(741, 462);
            this.dtgvNode.TabIndex = 51;
            this.dtgvNode.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvNode.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgvNode.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgvNode.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgvNode.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgvNode.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgvNode.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvNode.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgvNode.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgvNode.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgvNode.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgvNode.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgvNode.ThemeStyle.HeaderStyle.Height = 30;
            this.dtgvNode.ThemeStyle.ReadOnly = false;
            this.dtgvNode.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvNode.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvNode.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgvNode.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgvNode.ThemeStyle.RowsStyle.Height = 28;
            this.dtgvNode.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvNode.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgvNode.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNode_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Serial";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Trạng thái";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Dữ liệu";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.btnLocation);
            this.guna2CustomGradientPanel1.Controls.Add(this.label10);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnReadInfomationNode);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnReset);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtSerialNode);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(741, 64);
            this.guna2CustomGradientPanel1.TabIndex = 50;
            // 
            // btnLocation
            // 
            this.btnLocation.BorderRadius = 10;
            this.btnLocation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLocation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLocation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLocation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLocation.ForeColor = System.Drawing.Color.White;
            this.btnLocation.Location = new System.Drawing.Point(502, 11);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(89, 45);
            this.btnLocation.TabIndex = 4;
            this.btnLocation.Text = "Vị trí";
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 32);
            this.label10.TabIndex = 3;
            this.label10.Text = "Serial";
            // 
            // btnReadInfomationNode
            // 
            this.btnReadInfomationNode.BorderRadius = 10;
            this.btnReadInfomationNode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReadInfomationNode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReadInfomationNode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReadInfomationNode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReadInfomationNode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReadInfomationNode.ForeColor = System.Drawing.Color.White;
            this.btnReadInfomationNode.Location = new System.Drawing.Point(391, 11);
            this.btnReadInfomationNode.Name = "btnReadInfomationNode";
            this.btnReadInfomationNode.Size = new System.Drawing.Size(89, 45);
            this.btnReadInfomationNode.TabIndex = 2;
            this.btnReadInfomationNode.Text = "Xem";
            this.btnReadInfomationNode.Click += new System.EventHandler(this.btnReadInfomationNode_Click);
            // 
            // btnReset
            // 
            this.btnReset.BorderRadius = 13;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::DCU_Cuong_Tool.Properties.Resources.reset_undo_arrow_icon_149006;
            this.btnReset.Location = new System.Drawing.Point(628, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(46, 43);
            this.btnReset.TabIndex = 1;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // txtSerialNode
            // 
            this.txtSerialNode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSerialNode.DefaultText = "";
            this.txtSerialNode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSerialNode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSerialNode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSerialNode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSerialNode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSerialNode.Location = new System.Drawing.Point(98, 13);
            this.txtSerialNode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSerialNode.Name = "txtSerialNode";
            this.txtSerialNode.PasswordChar = '\0';
            this.txtSerialNode.PlaceholderText = "";
            this.txtSerialNode.SelectedText = "";
            this.txtSerialNode.Size = new System.Drawing.Size(286, 43);
            this.txtSerialNode.TabIndex = 0;
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.BaseColor = System.Drawing.SystemColors.ActiveCaption;
            this.gunaElipsePanel1.Controls.Add(this.guna2Panel3);
            this.gunaElipsePanel1.Controls.Add(this.guna2Panel2);
            this.gunaElipsePanel1.Controls.Add(this.guna2Panel1);
            this.gunaElipsePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaElipsePanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Size = new System.Drawing.Size(741, 145);
            this.gunaElipsePanel1.TabIndex = 19;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.Controls.Add(this.pictureBox3);
            this.guna2Panel3.Controls.Add(this.lbRatiov180);
            this.guna2Panel3.Controls.Add(this.lbV180);
            this.guna2Panel3.Controls.Add(this.label9);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel3.Location = new System.Drawing.Point(477, 12);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(225, 110);
            this.guna2Panel3.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DCU_Cuong_Tool.Properties.Resources.tick_good_accept_ok_complete_icon_208164;
            this.pictureBox3.Location = new System.Drawing.Point(175, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 53;
            this.pictureBox3.TabStop = false;
            // 
            // lbRatiov180
            // 
            this.lbRatiov180.AutoSize = true;
            this.lbRatiov180.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRatiov180.Location = new System.Drawing.Point(16, 74);
            this.lbRatiov180.Name = "lbRatiov180";
            this.lbRatiov180.Size = new System.Drawing.Size(0, 25);
            this.lbRatiov180.TabIndex = 53;
            // 
            // lbV180
            // 
            this.lbV180.AutoSize = true;
            this.lbV180.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbV180.Location = new System.Drawing.Point(58, 39);
            this.lbV180.Name = "lbV180";
            this.lbV180.Size = new System.Drawing.Size(0, 25);
            this.lbV180.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 25);
            this.label9.TabIndex = 51;
            this.label9.Text = "Dữ liệu";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel2.Controls.Add(this.pictureBox2);
            this.guna2Panel2.Controls.Add(this.lbRatioOffline);
            this.guna2Panel2.Controls.Add(this.lbOffline);
            this.guna2Panel2.Controls.Add(this.label8);
            this.guna2Panel2.FillColor = System.Drawing.Color.IndianRed;
            this.guna2Panel2.Location = new System.Drawing.Point(241, 12);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(220, 110);
            this.guna2Panel2.TabIndex = 4;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DCU_Cuong_Tool.Properties.Resources.button_blank_red;
            this.pictureBox2.Location = new System.Drawing.Point(162, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // lbRatioOffline
            // 
            this.lbRatioOffline.AutoSize = true;
            this.lbRatioOffline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRatioOffline.Location = new System.Drawing.Point(22, 74);
            this.lbRatioOffline.Name = "lbRatioOffline";
            this.lbRatioOffline.Size = new System.Drawing.Size(0, 25);
            this.lbRatioOffline.TabIndex = 52;
            // 
            // lbOffline
            // 
            this.lbOffline.AutoSize = true;
            this.lbOffline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOffline.Location = new System.Drawing.Point(75, 39);
            this.lbOffline.Name = "lbOffline";
            this.lbOffline.Size = new System.Drawing.Size(0, 25);
            this.lbOffline.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 25);
            this.label8.TabIndex = 50;
            this.label8.Text = "Offline";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.lbRatioOnline);
            this.guna2Panel1.Controls.Add(this.lbOnline);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.FillColor = System.Drawing.Color.MediumSpringGreen;
            this.guna2Panel1.Location = new System.Drawing.Point(15, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(220, 110);
            this.guna2Panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DCU_Cuong_Tool.Properties.Resources.button_blank_green;
            this.pictureBox1.Location = new System.Drawing.Point(162, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // lbRatioOnline
            // 
            this.lbRatioOnline.AutoSize = true;
            this.lbRatioOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRatioOnline.Location = new System.Drawing.Point(21, 74);
            this.lbRatioOnline.Name = "lbRatioOnline";
            this.lbRatioOnline.Size = new System.Drawing.Size(0, 25);
            this.lbRatioOnline.TabIndex = 48;
            // 
            // lbOnline
            // 
            this.lbOnline.AutoSize = true;
            this.lbOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOnline.Location = new System.Drawing.Point(59, 39);
            this.lbOnline.Name = "lbOnline";
            this.lbOnline.Size = new System.Drawing.Size(0, 25);
            this.lbOnline.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 46;
            this.label3.Text = "Online";
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
            this.panel3.Size = new System.Drawing.Size(279, 100);
            this.panel3.TabIndex = 30;
            // 
            // cmbPortList
            // 
            this.cmbPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPortList.FormattingEnabled = true;
            this.cmbPortList.Location = new System.Drawing.Point(88, 13);
            this.cmbPortList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPortList.Name = "cmbPortList";
            this.cmbPortList.Size = new System.Drawing.Size(148, 28);
            this.cmbPortList.TabIndex = 1;
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
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Image = global::DCU_Cuong_Tool.Properties.Resources.connect_line_icon_236099;
            this.btnRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRead.Location = new System.Drawing.Point(1, 51);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(139, 49);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Mở COM";
            this.btnRead.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::DCU_Cuong_Tool.Properties.Resources.disconnect_line_icon_236081;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(140, 51);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(139, 49);
            this.btnRefresh.TabIndex = 3;
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
            this.pnlSeri.Size = new System.Drawing.Size(279, 51);
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
            this.txtDCUNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDCUNo.Location = new System.Drawing.Point(109, 8);
            this.txtDCUNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDCUNo.Name = "txtDCUNo";
            this.txtDCUNo.Size = new System.Drawing.Size(138, 26);
            this.txtDCUNo.TabIndex = 4;
            this.txtDCUNo.Text = "665544332211";
            // 
            // pnlComand
            // 
            this.pnlComand.Controls.Add(this.btnInfomation);
            this.pnlComand.Controls.Add(this.label7);
            this.pnlComand.Controls.Add(this.label6);
            this.pnlComand.Controls.Add(this.label4);
            this.pnlComand.Controls.Add(this.textBox1);
            this.pnlComand.Controls.Add(this.button2);
            this.pnlComand.Controls.Add(this.label1);
            this.pnlComand.Controls.Add(this.txtTimeGet);
            this.pnlComand.Controls.Add(this.button1);
            this.pnlComand.Controls.Add(this.btnChar);
            this.pnlComand.Controls.Add(this.btnList);
            this.pnlComand.Controls.Add(this.btnNodeOnline);
            this.pnlComand.Controls.Add(this.btnBlackList);
            this.pnlComand.Controls.Add(this.btnNodeOffline);
            this.pnlComand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlComand.Location = new System.Drawing.Point(0, 151);
            this.pnlComand.Name = "pnlComand";
            this.pnlComand.Size = new System.Drawing.Size(279, 358);
            this.pnlComand.TabIndex = 35;
            // 
            // btnInfomation
            // 
            this.btnInfomation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfomation.Location = new System.Drawing.Point(140, 111);
            this.btnInfomation.Name = "btnInfomation";
            this.btnInfomation.Size = new System.Drawing.Size(140, 52);
            this.btnInfomation.TabIndex = 50;
            this.btnInfomation.Text = "Thông tin";
            this.btnInfomation.UseVisualStyleBackColor = true;
            this.btnInfomation.Click += new System.EventHandler(this.btnInfomation_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "Lần đầu tiên ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Giờ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "Giờ";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(136, 232);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "1";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 52);
            this.button2.TabIndex = 13;
            this.button2.Text = "Kết Thúc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "Lần tiếp theo";
            // 
            // txtTimeGet
            // 
            this.txtTimeGet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeGet.Location = new System.Drawing.Point(136, 273);
            this.txtTimeGet.Name = "txtTimeGet";
            this.txtTimeGet.Size = new System.Drawing.Size(100, 26);
            this.txtTimeGet.TabIndex = 16;
            this.txtTimeGet.Text = "1";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(140, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 52);
            this.button1.TabIndex = 14;
            this.button1.Text = "Bắt đầu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChar
            // 
            this.btnChar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChar.Location = new System.Drawing.Point(140, 15);
            this.btnChar.Name = "btnChar";
            this.btnChar.Size = new System.Drawing.Size(140, 48);
            this.btnChar.TabIndex = 8;
            this.btnChar.Text = "Biểu đồ";
            this.btnChar.UseVisualStyleBackColor = true;
            this.btnChar.Click += new System.EventHandler(this.btnChar_Click);
            // 
            // btnList
            // 
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Location = new System.Drawing.Point(0, 15);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(140, 48);
            this.btnList.TabIndex = 11;
            this.btnList.Text = "Danh sách";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnNodeOnline
            // 
            this.btnNodeOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNodeOnline.Location = new System.Drawing.Point(140, 61);
            this.btnNodeOnline.Name = "btnNodeOnline";
            this.btnNodeOnline.Size = new System.Drawing.Size(140, 50);
            this.btnNodeOnline.TabIndex = 5;
            this.btnNodeOnline.Text = "Node online ";
            this.btnNodeOnline.UseVisualStyleBackColor = true;
            this.btnNodeOnline.Click += new System.EventHandler(this.btnNodeOnline_Click);
            // 
            // btnBlackList
            // 
            this.btnBlackList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlackList.Location = new System.Drawing.Point(0, 111);
            this.btnBlackList.Name = "btnBlackList";
            this.btnBlackList.Size = new System.Drawing.Size(140, 52);
            this.btnBlackList.TabIndex = 6;
            this.btnBlackList.Text = "Black list ";
            this.btnBlackList.UseVisualStyleBackColor = true;
            this.btnBlackList.Click += new System.EventHandler(this.btnBlackList_Click);
            // 
            // btnNodeOffline
            // 
            this.btnNodeOffline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNodeOffline.Location = new System.Drawing.Point(0, 63);
            this.btnNodeOffline.Name = "btnNodeOffline";
            this.btnNodeOffline.Size = new System.Drawing.Size(140, 48);
            this.btnNodeOffline.TabIndex = 7;
            this.btnNodeOffline.Text = "Node offline";
            this.btnNodeOffline.UseVisualStyleBackColor = true;
            this.btnNodeOffline.Click += new System.EventHandler(this.btnNodeOffline_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClearLog);
            this.panel1.Controls.Add(this.pnlComand);
            this.panel1.Controls.Add(this.pnlSeri);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 626);
            this.panel1.TabIndex = 30;
            // 
            // btnClearLog
            // 
            this.btnClearLog.BackColor = System.Drawing.Color.LightCoral;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.Image = global::DCU_Cuong_Tool.Properties.Resources.clear_icon_155649;
            this.btnClearLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearLog.Location = new System.Drawing.Point(59, 539);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(177, 50);
            this.btnClearLog.TabIndex = 17;
            this.btnClearLog.Text = "Xóa Log ";
            this.btnClearLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Hành động";
            this.dataGridViewImageColumn1.Image = global::DCU_Cuong_Tool.Properties.Resources.zenmap_104119;
            this.dataGridViewImageColumn1.MinimumWidth = 8;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 289;
            // 
            // rtbOutput
            // 
            this.rtbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(402, 626);
            this.rtbOutput.TabIndex = 51;
            this.rtbOutput.Text = "";
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.rtbOutput);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(1020, 0);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(402, 626);
            this.guna2Panel4.TabIndex = 52;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 626);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WM03Soft";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.pn2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNode)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.gunaElipsePanel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlSeri.ResumeLayout(false);
            this.pnlSeri.PerformLayout();
            this.pnlComand.ResumeLayout(false);
            this.pnlComand.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
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
        private System.Windows.Forms.Button btnNodeOnline;
        private System.Windows.Forms.Button btnBlackList;
        private System.Windows.Forms.Button btnNodeOffline;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimeGet;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        private Guna.UI.WinForms.GunaElipsePanel pn2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbV180;
        private System.Windows.Forms.Label lbOffline;
        private System.Windows.Forms.Label lbOnline;
        private System.Windows.Forms.Label lbRatiov180;
        private System.Windows.Forms.Label lbRatioOffline;
        private System.Windows.Forms.Label lbRatioOnline;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dtgvNode;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2TextBox txtSerialNode;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnInfomation;
        private Guna.UI2.WinForms.Guna2ProgressIndicator prgLoad;
        private Guna.UI2.WinForms.Guna2Button btnReadInfomationNode;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button btnLocation;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

