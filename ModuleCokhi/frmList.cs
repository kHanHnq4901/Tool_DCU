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

    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string dateStart = dateTimeStart.Value.ToString("yyyy-MM-dd");
            string dateEnd = dateTimeEnd.Value.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=LocalDB.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                string query = "";
                if (rbNodeOnline.Checked == true)
                {
                    query = "SELECT * FROM HIS_ONLINE WHERE datetime(CREATED) BETWEEN date('" + dateStart + "') AND date('" + dateEnd + "', '+1 day') ORDER BY ID DESC";
                }
                else if (rbNodeOffline.Checked == true)
                {
                    query = "SELECT * FROM HIS_OFFLINE WHERE datetime(CREATED) BETWEEN date('" + dateStart + "') AND date('" + dateEnd + "', '+1 day') ORDER BY ID DESC";
                }
                else if (rbNodeBlackList.Checked == true)
                {
                    query = "SELECT * FROM HIS_BLACK_LIST WHERE datetime(CREATED) BETWEEN date('" + dateStart + "') AND date('" + dateEnd + "', '+1 day') ORDER BY ID DESC";
                }
                else if (rdDaiLy.Checked == true)
                {
                    query = "SELECT * FROM HIS_DAILY WHERE datetime(CREATED) BETWEEN date('" + dateStart + "') AND date('" + dateEnd + "', '+1 day') ORDER BY ID DESC";
                }
                else if (rdInfomation.Checked == true)
                {
                    query = "SELECT * FROM HIS_INFOMATION WHERE datetime(CREATED) BETWEEN date('" + dateStart + "') AND date('" + dateEnd + "', '+1 day') ORDER BY ID DESC";
                }
                else if (rdNeighbohur.Checked == true)
                {
                    query = "SELECT * FROM HIS_NEIGHOBUR WHERE datetime(CREATED) BETWEEN date('" + dateStart + "') AND date('" + dateEnd + "', '+1 day') ORDER BY ID DESC";
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

        private void ExportToWord()
        {
            if (dtgvData.DataSource != null)
            {
                try
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Word Document (*.docx)|*.docx";
                    saveFileDialog.Title = "Save Word File";
                    saveFileDialog.FileName = "output.docx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputPath = saveFileDialog.FileName;

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
                            dynamic wordParagraph = wordDoc.Content.Paragraphs.Add();

                            // Tạo bảng trong tài liệu Word
                            dynamic wordTable = wordDoc.Tables.Add(wordParagraph.Range, dataTable.Rows.Count + 1, dataTable.Columns.Count);

                            // Đặt tiêu đề cho các cột
                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                wordTable.Cell(1, i + 1).Range.Text = dataTable.Columns[i].ColumnName;
                            }

                            // Đặt giá trị cho các ô trong bảng
                            for (int row = 0; row < dataTable.Rows.Count; row++)
                            {
                                for (int col = 0; col < dataTable.Columns.Count; col++)
                                {
                                    wordTable.Cell(row + 2, col + 1).Range.Text = dataTable.Rows[row][col].ToString();
                                }
                            }

                            // Chèn tiêu đề trên đầu trang
                            dynamic titleRange = wordApp.Selection.Range;
                            titleRange.Paragraphs.Add();

                            if (rbNodeBlackList.Checked)
                            {
                                titleRange.Text = "Danh sách các node Blacklist Từ ngày " + dateTimeStart.Value.ToString("yyyy-MM-dd") + " đến ngày " + dateTimeEnd.Value.ToString("dd-MM-yyyy");
                            }
                            else if (rbNodeOnline.Checked)
                            {
                                titleRange.Text = "Danh sách các node Online Từ ngày " + dateTimeStart.Value.ToString("yyyy-MM-dd") + " đến ngày " + dateTimeEnd.Value.ToString("yyyy-MM-dd");
                            }
                            else if (rbNodeOffline.Checked)
                            {
                                titleRange.Text = "Danh sách các node Offline Từ ngày " + dateTimeStart.Value.ToString("yyyy-MM-dd") + " đến ngày " + dateTimeEnd.Value.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                titleRange.Text = "Danh sách hóa đơn từ ngày " + dateTimeStart.Value.ToString("yyyy-MM-dd") + " đến ngày " + dateTimeEnd.Value.ToString("yyyy-MM-dd");
                            }

                            titleRange.Bold = 1;
                            titleRange.ParagraphFormat.Alignment = 1; // Căn giữa

                            // Di chuyển con trỏ văn bản xuống dòng mới
                            wordApp.Selection.MoveDown();

                            // Lưu tài liệu Word
                            wordDoc.SaveAs(outputPath);
                            wordDoc.Close();

                            // Đóng ứng dụng Word
                            wordApp.Quit();

                            MessageBox.Show("Xuất file Word thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Process.Start(outputPath);
                        }
                        else
                        {
                            MessageBox.Show("Dữ liệu trong DataGridView không phải là một đối tượng DataTable.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            //string outputPath = "\\Downloads\\output.docx";

            ExportToWord();
          
            //string uniqueFilePath = GetUniqueFileName(outputPath);

        }
        private string GetUniqueFileName(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);

            int counter = 1;
            string uniqueFilePath = filePath;

            while (File.Exists(uniqueFilePath))
            {
                string newFileName = $"{fileNameWithoutExtension}_{counter}{fileExtension}";
                uniqueFilePath = Path.Combine(directory, newFileName);
                counter++;
            }

            return uniqueFilePath;
           
        }

        //private void btnExportExcel_Click(object sender, EventArgs e)
        //{
        //    string connectionString = "Data Source=LocalDB.db;Version=3;"; // Thay đổi đường dẫn và tên database SQLite của bạn
        //    string query = "SELECT * FROM HIS_BLACKLIST"; // Thay đổi your_table thành tên bảng SQLite của bạn

        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
        //    saveFileDialog.FilterIndex = 2;
        //    saveFileDialog.RestoreDirectory = true;

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string filePath = saveFileDialog.FileName;

        //        try
        //        {
        //            FileInfo file = new FileInfo(filePath);
        //            using (ExcelPackage package = new ExcelPackage(file))
        //            {
        //                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

        //                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        //                {
        //                    connection.Open();

        //                    SQLiteCommand command = new SQLiteCommand(query, connection);
        //                    SQLiteDataReader reader = command.ExecuteReader();

        //                    int row = 1;
        //                    int col = 1;

        //                    // Ghi tiêu đề cột
        //                    for (int i = 0; i < reader.FieldCount; i++)
        //                    {
        //                        worksheet.Cells[row, col].Value = reader.GetName(i);
        //                        col++;
        //                    }

        //                    // Ghi dữ liệu từ SQLite vào Excel
        //                    row++;
        //                    while (reader.Read())
        //                    {
        //                        col = 1;
        //                        for (int i = 0; i < reader.FieldCount; i++)
        //                        {
        //                            worksheet.Cells[row, col].Value = reader[i];
        //                            col++;
        //                        }
        //                        row++;
        //                    }

        //                    reader.Close();
        //                    connection.Close();
        //                }

        //                package.Save();
        //            }

        //            MessageBox.Show("Xuất dữ liệu thành công!");
        //        }
        //        catch (IOException ex)
        //        {
        //            MessageBox.Show("Có lỗi xảy ra khi ghi file: " + ex.Message);
        //        }
        //    }
        //}
    }
}
