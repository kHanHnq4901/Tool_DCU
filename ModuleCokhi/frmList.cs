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

    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=LocalDB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string query = "";
                if (btnNodeOnline.Checked == true)
                {
                    query = "SELECT * FROM HIS_ONLINE WHERE CREATED LIKE '%" + date + "%' ORDER BY CREATED DESC";
                }
                else if (btnNodeOffline.Checked == true)
                {
                    query = "SELECT * FROM HIS_OFFLINE WHERE CREATED LIKE '%" + date + "%' ORDER BY CREATED DESC";
                }
                else if (btnNodeBlackList.Checked == true)
                {
                    query = "SELECT * FROM HIS_BLACK_LIST WHERE CREATED LIKE '%" + date + "%' ORDER BY CREATED DESC";
                }

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dtgvData.DataSource = dataTable;
                }


                connection.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
