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
                if (rbNodeOnline.Checked == true)
                {
                    query = "SELECT * FROM HIS_ONLINE WHERE CREATED LIKE '%" + date + "%' ORDER BY ID DESC";
                }
                else if (rbNodeOffline.Checked == true)
                {
                    query = "SELECT * FROM HIS_OFFLINE WHERE CREATED LIKE '%" + date + "%' ORDER BY ID DESC";
                }
                else if (rbNodeBlackList.Checked == true)
                {
                    query = "SELECT * FROM HIS_BLACK_LIST WHERE CREATED LIKE '%" + date + "%' ORDER BY ID DESC";
                }
                else if (rdDaiLy.Checked == true)
                {
                    query = "SELECT * FROM HIS_DAILY WHERE CREATED LIKE '%" + date + "%' ORDER BY ID DESC";
                }

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    dtgvData.DataSource = dataTable;
                    int rowCount = dataTable.Rows.Count;
                    lbCount.Text = "Số lượng : " + rowCount.ToString();
                }

                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ExportToWord(string outputPath)
        {
            if (dtgvData.DataSource != null)
            {
                try
                {
                    // Sử dụng reflection để tạo đối tượng Microsoft.Office.Interop.Word.Application
                    Type wordAppType = Type.GetTypeFromProgID("Word.Application");
                    dynamic wordApp = Activator.CreateInstance(wordAppType);

                    // Tạo một tài liệu Word mới
                    dynamic wordDoc = wordApp.Documents.Add();

                    // Lấy dữ liệu từ DataGridView
                    System.Data.DataTable dataTable = dtgvData.DataSource as System.Data.DataTable;

                    if (dataTable != null)
                    {
                        // Thêm dữ liệu vào tài liệu Word
                        foreach (DataRow row in dataTable.Rows)
                        {
                            dynamic wordParagraph = wordDoc.Content.Paragraphs.Add();
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                string cellData = row[i].ToString();
                                wordParagraph.Range.Text += cellData + "\t";
                            }
                        }

                        // Lưu tài liệu Word
                        wordDoc.SaveAs2(outputPath);
                        wordDoc.Close();

                        // Đóng ứng dụng Word
                        wordApp.Quit();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu trong DataGridView không phải là một đối tượng DataTable.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xuất ra tệp Word: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất ra tệp Word.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Đường dẫn và tên tệp Word đích
            string outputPath = "path/to/output.docx";

            ExportToWord(outputPath);
        }

    }
}
