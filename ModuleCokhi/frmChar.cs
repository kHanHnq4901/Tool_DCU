using DCU_Cuong_Tool;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using WM03Soft;

namespace DCU_Cuong_Tool
{
    public partial class frmChar : Form
    {

        public frmChar()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            int intTimeOffSet;
            if (txtTimeOffSet.Text.Length == 0)
            {
                intTimeOffSet = 1;
            }
            else
            {
                try {
                    int intTimeIntoTextBox = int.Parse(txtTimeOffSet.Text);
                    if (intTimeIntoTextBox > 1)
                    {
                        intTimeOffSet = intTimeIntoTextBox;
                    }
                    else
                    {
                        intTimeOffSet = 1;
                    }
                }
                catch
                {
                    intTimeOffSet = 1;
                    // Chuyển đổi không thành công, xử lý khi chuỗi không phải là một số nguyên hợp lệ
                    MessageBox.Show("Giá trị không hợp lệ!");
                }
                
            }
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=LocalDB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                //frmMain frmMainSub = new frmMain();
                for(int showChart = 0; showChart < 23; showChart++)
                {
                    try
                    {
                        if (showChart % intTimeOffSet == 0)
                        {
                            string time = showChart.ToString("D2") + ":00";
                            string startTime = date + " " + time;

                            if (cbOnline.Checked == true)
                            {
                                string query = "SELECT COUNT(*) FROM HIS_ONLINE WHERE substr(CREATED, 1, 16) = @startDate";
                                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@startDate", startTime);

                                    int count = Convert.ToInt32(command.ExecuteScalar());

                                    // Thêm điểm dữ liệu vào biểu đồ
                                    chart1.Series["Online"].Points.AddXY(time + " h", count);
                                }
                            }
                            if (cbOffline.Checked == true)
                            {
                                string query1 = "SELECT COUNT(*) FROM HIS_OFFLINE WHERE substr(CREATED, 1, 16) = @startDate";
                                using (SQLiteCommand command = new SQLiteCommand(query1, connection))
                                {
                                    command.Parameters.AddWithValue("@startDate", startTime);

                                    int count = Convert.ToInt32(command.ExecuteScalar());

                                    // Thêm điểm dữ liệu vào biểu đồ
                                    chart1.Series["Offline"].Points.AddXY(time + " h", count);
                                }
                            }
                            if (cbBlackList.Checked == true)
                            {
                                string query1 = "SELECT COUNT(*) FROM HIS_BLACK_LIST WHERE substr(CREATED, 1, 16) = @startDate";
                                using (SQLiteCommand command = new SQLiteCommand(query1, connection))
                                {
                                    command.Parameters.AddWithValue("@startDate", startTime);

                                    int count = Convert.ToInt32(command.ExecuteScalar());

                                    // Thêm điểm dữ liệu vào biểu đồ
                                    chart1.Series["BlackList"].Points.AddXY(time + " h", count);
                                }
                            }
                        }
                    }
                    catch { }
                   
                }
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Online"].Points.Clear();
            chart1.Series["Offline"].Points.Clear();
            chart1.Series["BlackList"].Points.Clear();
            LoadData();
        }

        private void frmChar_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
