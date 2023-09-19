using DCU_Cuong_Tool;
using NPOI.SS.Formula.Functions;
using NPOI.XWPF.UserModel;
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
using static NPOI.HSSF.Util.HSSFColor;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Diagnostics;

namespace DCU_Cuong_Tool
{
    public partial class frmCompare : Form
    {
        public frmCompare()
        {
            InitializeComponent();
            // Định nghĩa danh sách các giờ trong ngày
            List<string> hours = new List<string>();
            for (int hour = 0; hour < 24; hour++)
            {
                hours.Add(hour.ToString("00"));
            }

            // Thêm dữ liệu vào ComboBox
            cbTime.Items.AddRange(hours.ToArray());
            cbTime.SelectedIndex = 0;
        }
        private void LoadData()
        {
            string dateLeft = dateTimeLeft.Value.ToString("yyyy-MM-dd");
            string dateRight = dateTimeRight.Value.ToString("yyyy-MM-dd");
            string hour = cbTime.SelectedItem.ToString(); // Sử dụng SelectedItem thay vì ValueMember

            string connectionString = "Data Source=LocalDB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string queryleft = "";
                string queryRight = "";

                if (rbNodeOnline.Checked == true)
                {
                    queryleft = "SELECT * FROM HIS_ONLINE WHERE datetime(CREATED) LIKE '" + dateLeft + " " + hour + "%' ORDER BY ID DESC";
                    queryRight = "SELECT * FROM HIS_ONLINE WHERE datetime(CREATED) LIKE '" + dateRight + " " + hour + "%' ORDER BY ID DESC";
                }
                else if (rbNodeOffline.Checked == true)
                {
                    queryleft = "SELECT SERIAL,CONFIG FROM HIS_OFFLINE WHERE datetime(CREATED) LIKE '" + dateLeft + " " + hour + "%' ORDER BY ID DESC";
                    queryRight = "SELECT SERIAL,CONFIG FROM HIS_OFFLINE WHERE datetime(CREATED) LIKE '" + dateRight + " " + hour + "%' ORDER BY ID DESC";
                }
                else if (rbNodeBlackList.Checked == true)
                {
                    queryleft = "SELECT * FROM HIS_BLACK_LIST WHERE datetime(CREATED) LIKE '" + dateLeft + " " + hour + "%' ORDER BY ID DESC";
                    queryRight = "SELECT * FROM HIS_BLACK_LIST WHERE datetime(CREATED) LIKE '" + dateRight + " " + hour + "%' ORDER BY ID DESC";
                }
                else if (rdDaiLy.Checked == true)
                {
                    queryleft = "SELECT * FROM HIS_DAILY WHERE datetime(CREATED) LIKE '" + dateLeft + " " + hour + "%' ORDER BY ID DESC";
                    queryRight = "SELECT * FROM HIS_DAILY WHERE datetime(CREATED) LIKE '" + dateRight + " " + hour + "%' ORDER BY ID DESC";
                }

                int rowCountLeft;
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryleft, connection))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    dtgvLeft.DataSource = dataTable;
                    rowCountLeft = dataTable.Rows.Count;
                    lbCountLeft.Text = "Số lượng: " + rowCountLeft.ToString();
                }

                int rowCountRight;
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryRight, connection))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    dtgvRight.DataSource = dataTable;
                    rowCountRight = dataTable.Rows.Count;
                    lbCountRight.Text = "Số lượng: " + rowCountRight.ToString();
                }

                int diffRowCount = Math.Abs(rowCountLeft - rowCountRight);
                lbCountDiff.Text = "Chênh lệch: " + diffRowCount.ToString();
                connection.Close();
            }
        }
        private void CompareData()
        {
            int rowCountLeft = dtgvLeft.Rows.Count;
            int rowCountRight = dtgvRight.Rows.Count;
            List<bool> matchFlags = new List<bool>(rowCountRight);

            for (int rowRight = 0; rowRight < rowCountRight; rowRight++)
            {
                DataGridViewRow rightRow = dtgvRight.Rows[rowRight];
                DataGridViewCell rightSerialCell = rightRow.Cells["Serial"];
                DataGridViewCell rightConfigCell = rightRow.Cells["Config"];
                if (rightSerialCell.Value == null || rightConfigCell.Value == null)
                {
                    continue; // Bỏ qua hàng nếu ô "Serial" hoặc "Config" là null
                }
                string rightSerial = rightSerialCell.Value.ToString();
                string rightConfig = rightConfigCell.Value.ToString();

                bool hasData = !string.IsNullOrEmpty(rightSerial) || !string.IsNullOrEmpty(rightConfig);
                if (hasData)
                {
                    rightRow.DefaultCellStyle.BackColor = Color.Red;
                    matchFlags.Add(false);
                }
                else
                {
                    matchFlags.Add(true); // Bỏ qua hàng không có dữ liệu trong cột right
                }
            }

            for (int rowLeft = 0; rowLeft < rowCountLeft; rowLeft++)
            {
                DataGridViewRow leftRow = dtgvLeft.Rows[rowLeft];
                DataGridViewCell leftSerialCell = leftRow.Cells["Serial"];
                DataGridViewCell leftConfigCell = leftRow.Cells["Config"];
                if (leftSerialCell.Value == null || leftConfigCell.Value == null)
                {
                    continue; // Bỏ qua hàng nếu ô "Serial" hoặc "Config" là null
                }
                string leftSerial = leftSerialCell.Value.ToString();
                string leftConfig = leftConfigCell.Value.ToString();
                bool isMatched = false;

                for (int rowRight = 0; rowRight < rowCountRight; rowRight++)
                {
                    if (rowRight < matchFlags.Count && matchFlags[rowRight])
                    {
                        continue; // Bỏ qua nếu hàng này đã có kết quả khớp với hàng trong cột left hoặc không có dữ liệu
                    }

                    DataGridViewRow rightRow = dtgvRight.Rows[rowRight];
                    DataGridViewCell rightSerialCell = rightRow.Cells["Serial"];
                    DataGridViewCell rightConfigCell = rightRow.Cells["Config"];
                    if (rightSerialCell.Value == null || rightConfigCell.Value == null)
                    {
                        continue; // Bỏ qua hàng nếu ô "Serial" hoặc "Config" là null
                    }
                    string rightSerial = rightSerialCell.Value.ToString();
                    string rightConfig = rightConfigCell.Value.ToString();

                    if (leftSerial == rightSerial && leftConfig == rightConfig)
                    {
                        isMatched = true;
                        leftRow.DefaultCellStyle.BackColor = Color.Green;
                        rightRow.DefaultCellStyle.BackColor = Color.Green;
                        if (rowRight < matchFlags.Count)
                        {
                            matchFlags[rowRight] = true;
                        }
                        break;
                    }
                }

                if (!isMatched)
                {
                    leftRow.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
            if (rbNodeOffline.Checked)
            {
                CompareData();

            }

        }
    }
}
