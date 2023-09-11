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
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=LocalDB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                for (int hour = 1; hour <= 24; hour++)
                {
                    string time = hour.ToString("D2") + ":00";
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
                    if(cbOffline.Checked == true)
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
                   
                }

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Online"].Points.Clear();
            chart1.Series["Offline"].Points.Clear();
            LoadData();
        }

        private void frmChar_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
