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
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

                for (int showChart = 0; showChart < 24; showChart++)
                {
                    try
                    {
                        if (showChart % intTimeOffSet == 0)
                        {
                            string time = showChart.ToString("D2") + ":00";
                            string startTime = date + " " + time;

                            string timeV180 = time.Split(':')[0];
                            string startTimeV180 = date + " " + time;

                            int totalOnlineCount = 0; // Tổng HIS_ONLINE trong mỗi vòng lặp
                            int totalOfflineCount = 0; // Tổng HIS_OFFLINE trong mỗi vòng lặp
                            int totalCount = 0; // Tổng chung trong mỗi vòng lặp

                            if (cbOnline.Checked)
                            {
                                string query = "SELECT COUNT(*) FROM HIS_ONLINE WHERE substr(CREATED, 1, 16) = @startDate";
                                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@startDate", startTime);

                                    int count = Convert.ToInt32(command.ExecuteScalar());
                                    totalOnlineCount += count;
                                    totalCount += count;

                                    // Thêm điểm dữ liệu vào biểu đồ
                                    DataPoint dataPoint = new DataPoint();
                                    dataPoint.SetValueXY(time + " h", count);
                                    if (count > 0)
                                    {
                                        dataPoint.Label = count.ToString();
                                    }
                                    chart1.Series["Online"].Points.Add(dataPoint);
                                }
                            }

                            if (cbOffline.Checked)
                            {
                                string query = "SELECT COUNT(*) FROM HIS_OFFLINE WHERE substr(CREATED, 1, 16) = @startDate";
                                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@startDate", startTime);

                                    int count = Convert.ToInt32(command.ExecuteScalar());
                                    totalOfflineCount += count;
                                    totalCount += count;

                                    // Thêm điểm dữ liệu vào biểu đồ
                                    DataPoint dataPoint = new DataPoint();
                                    dataPoint.SetValueXY(time + " h", count);
                                    if (count > 0)
                                    {
                                        dataPoint.Label = count.ToString();
                                    }
                                    chart1.Series["Offline"].Points.Add(dataPoint);
                                }
                            }

                            if (cbBlackList.Checked)
                            {
                                string query = "SELECT COUNT(*) FROM HIS_BLACK_LIST WHERE substr(CREATED, 1, 16) = @startDate";
                                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@startDate", startTime);

                                    int count = Convert.ToInt32(command.ExecuteScalar());

                                    // Thêm điểm dữ liệu vào biểu đồ
                                    DataPoint dataPoint = new DataPoint();
                                    dataPoint.SetValueXY(time + " h", count);
                                    if (count > 0)
                                    {
                                        dataPoint.Label = count.ToString();
                                    }

                                    chart1.Series["BlackList"].Points.Add(dataPoint);
                                }
                            }

                            if (cb180.Checked)
                            {
                                string query = "SELECT COUNT(*) FROM HIS_DAILY WHERE substr(CREATED, 1, 16) = @startDate";
                                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@startDate", startTimeV180);

                                    int count = Convert.ToInt32(command.ExecuteScalar());

                                    // Thêm điểm dữ liệu vào biểu đồ
                                    DataPoint dataPoint = new DataPoint();
                                    dataPoint.SetValueXY(time + " h", count);
                                    if (count > 0)
                                    {
                                        dataPoint.Label = count.ToString();
                                    }

                                    chart1.Series["V180"].Points.Add(dataPoint);
                                }
                            }

                            // Hiển thị số lượng và phần trăm (nếu cả hai checkbox đều được chọn)
                            if (cbOnline.Checked && cbOffline.Checked)
                            {
                                // Tính phần trăm
                                if (totalCount > 0)
                                {
                                    double onlinePercentage = (totalOnlineCount / (double)totalCount) * 100;
                                    double offlinePercentage = (totalOfflineCount / (double)totalCount) * 100;
                                    int total = totalOnlineCount + totalOfflineCount;
                                    chart1.Series["Online"].Points.Last().Label = string.Format("{0}/{1} \n({2:0.00}%)", totalOnlineCount, total, onlinePercentage);
                                    chart1.Series["Offline"].Points.Last().Label = string.Format("{0}/{1} \n({2:0.00}%)", totalOfflineCount, total, offlinePercentage);
                                }
                            }
                            else
                            {
                                // Chỉ hiển thị số lượng
                                if (cbOnline.Checked)
                                {
                                    chart1.Series["Online"].Points.Last().Label = totalOnlineCount.ToString();
                                }
                                if (cbOffline.Checked)
                                {
                                    chart1.Series["Offline"].Points.Last().Label = totalOfflineCount.ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý ngoại lệ nếu cần thiết
                    }
                }
    
                if (cbOnline.Checked && cbOffline.Checked)
                {
                    chart1.ChartAreas[0].AxisY.Maximum = 419;
                }
                else if (cbOnline.Checked || cbOffline.Checked)
                { 
                   chart1.ChartAreas[0].AxisY.Maximum = 419;
                }else
                {

                }
                chart1.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.All;
                chart1.ChartAreas[0].AxisX.Maximum = 25;
                chart1.ChartAreas[0].AxisY.Title = "Số Công Tớ";
                chart1.ChartAreas[0].AxisX.Title = "Thời Gian";
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Online"].Points.Clear();
            chart1.Series["Offline"].Points.Clear();
            chart1.Series["BlackList"].Points.Clear();
            chart1.Series["V180"].Points.Clear();
            LoadData();
        }

        private void frmChar_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
