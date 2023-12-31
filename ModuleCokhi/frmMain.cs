﻿using DCU_Cuong_Tool;
using DCU_Cuong_Tool.Properties;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.Formula.Eval;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace WM03Soft
{
    using int8_t = System.SByte;
    using uint8_t = System.Byte;
    using uint16_t = System.UInt16;
    using uint32_t = System.UInt32;
    using int32_t = System.Int32;
    using uint64_t = System.UInt64;

    public partial class frmMain : Form
    {
        public SerialPort port;
        public string[] ports = SerialPort.GetPortNames();
        private delegate void preventCrossThreadingString(string x);
        private preventCrossThreadingString updateOutputThread;
        private SerialPort myPort = new SerialPort();
        delegate void ButtonEnableHandler();

        private string comName = "COM11";
        public string Serial = "";

        public int iIntervalTimer = 1000;   // 1s
        public int iTimeoutCOM = 1; // số giây
        public int iCounterTimeout = 0;
        public bool bEnableCouter = false;
        public bool bTimeoutFlag = false;
        public bool isListening = false;
        public List<string> meterList = new List<string>();
        public static bool bStartFrame = false;

        // Cầu hình toàn bộ
        public static Hashtable hConfig = new Hashtable();
        //Đểm số note 
        public int dataReceivedCount = 0;
        System.Timers.Timer myTimer = new System.Timers.Timer();
        private ManualResetEvent receiveDone = new ManualResetEvent(false);
        private string bBufferRecv = "";
        private void timer_Tick(object sender, EventArgs e)
        {
            if (bEnableCouter)
            {
                iCounterTimeout++;
                if (iCounterTimeout > iTimeoutCOM)
                {
                    StopCounterTimer();
                    SetEventFlag(true);
                    bTimeoutFlag = true;
                }
            }
        }

        private void initWaitRec()
        {
            bBufferRecv = "";
            StartCounterTimer();
        }

        private void InitTimer_COM()
        {
            myTimer.Enabled = true;
            myTimer.Interval = iIntervalTimer;
            myTimer.Elapsed += new ElapsedEventHandler(timer_Tick);
            myPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
        }
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;
            int bytesToRead = serialPort.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            serialPort.Read(buffer, 0, bytesToRead);
            string receivedData = MyLib.ByteArrToHexString(buffer);
            bBufferRecv += receivedData;

            int startFrameIndex = bBufferRecv.IndexOf("FEFE");
            int endFrameIndex = bBufferRecv.IndexOf("0A0D");

            while (endFrameIndex > startFrameIndex && startFrameIndex > -1)
            {
                string frameData = bBufferRecv.Substring(startFrameIndex, endFrameIndex + 4 - startFrameIndex);
                string formattedData = MyLib.FormatHexString(frameData.Replace("-", " "));
                ProcessPacket(formattedData);
                bBufferRecv = bBufferRecv.Substring(endFrameIndex + 4);
                startFrameIndex = bBufferRecv.IndexOf("FEFE");
                endFrameIndex = bBufferRecv.IndexOf("0A0D");
                this.dataReceivedCount++;
            }
        }
        void CopyStringToString(char[] strDest, char[] strSource, int startCopy, int length)
        {
            for (int i = 0; i < length; i++)
            {
                strDest[i] = strSource[startCopy + i];
            }
        }
        StringBuilder receivedDataBuffer = new StringBuilder();

        void ProcessPacket(string packetData)
        {
            string recv = packetData;
            // Nhận các công tơ online
            if (recv.Substring(0, 5) == "FE FE" && recv.Substring(15, 2) == "07" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            {
                string[] aRec = recv.Split(' ');
                string serial = aRec[12] + aRec[11] + aRec[10] + aRec[9] + aRec[8] + aRec[7];
                string level = aRec[13];

                if (serial != "FFFFFFFFFFFF")
                {
                    displayLog("online serial " + serial + "|| tầng " + level);
                    AddDataToBatch(serial, level);
                    Thread addRowThread = new Thread(() =>
                    {
                        bool isReceived = receivedSerials.Contains(serial);
                        string car = string.Empty;

                        // Thực hiện thao tác trên dtgvNode.Rows trong luồng riêng
                        Invoke(new Action(() =>
                        {
                            // Chuỗi kết nối đến cơ sở dữ liệu SQLite
                            string connectionString = "Data Source=LocalDB.db;Version=3;";

                            // Tạo kết nối
                            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                            {
                                // Mở kết nối
                                connection.Open();

                                // Chuỗi truy vấn để lấy thông tin CAR từ bảng LIST_TRANSFORMERS
                                string carQuery = "SELECT CAR FROM LIST_TRANSFORMERS WHERE SERIAL = @Serial";

                                // Tạo đối tượng Command
                                using (SQLiteCommand command = new SQLiteCommand(carQuery, connection))
                                {
                                    // Thêm tham số Serial vào truy vấn
                                    command.Parameters.AddWithValue("@Serial", serial);

                                    // Thực hiện truy vấn và đọc dữ liệu
                                    using (SQLiteDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            // Lấy giá trị từ cột CAR trong kết quả truy vấn
                                            car = reader.GetString(0);
                                        }
                                    }
                                }
                            }

                            if (isReceived)
                            {
                                // Thêm dòng vào dtgvNode.Rows với thông tin serial, car và trạng thái đã nhận
                                dtgvNode.Rows.Add(serial, DCU_Cuong_Tool.Properties.Resources.button_blank_green, "Đã nhận", car);
                            }
                            else
                            {
                                // Thêm dòng vào dtgvNode.Rows với thông tin serial, trạng thái chưa nhận và car
                                dtgvNode.Rows.Add(serial, DCU_Cuong_Tool.Properties.Resources.button_blank_green, "Chưa nhận", car);
                            }
                        }));
                    });
                    addRowThread.Start();
                }
                else
                {
                    displayLog(recv);
                    string countString = dataReceivedCount .ToString();
                    displayLog("Send" + " Tổng số node đang online ------> " + countString);

                    // Sử dụng Invoke để truy cập thành phần UI từ luồng khác
                    lbOnline.Invoke((MethodInvoker)delegate
                    {
                        // Tính toán phần trăm chênh lệch
                        double currentOnlineCount;
                        double ratio;

                        if (double.TryParse(countString, out currentOnlineCount))
                        {
                            double difference = currentOnlineCount / 419;  // So sánh với giá trị 419
                            ratio = difference * 100;  // Tính tỉ lệ chênh lệch so với giá trị 419
                        }
                        else
                        {
                            // Xử lý nếu không thể chuyển đổi thành số
                            ratio = 0;
                        }
                        lbOnline.Text = countString.ToString();
                        // Hiển thị phần trăm chênh lệch trong lbRatioOnline.Text
                        lbRatioOnline.Text = string.Format("{0:0.##}%", ratio); ;
                    });

                    // dataReceivedCount = 0;
                    Thread executeThread = new Thread(ExecuteBatchInsert);
                    executeThread.Start();
                }

            }
            // Nhận các công tơ đang offline
            if (recv.Substring(0, 5) == "FE FE" && recv.Substring(15, 2) == "08" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            {
                string[] aRec = recv.Split(' ');
                string serial = aRec[12] + aRec[11] + aRec[10] + aRec[9] + aRec[8] + aRec[7];

                if (serial != "FFFFFFFFFFFF")
                {
                    string config = aRec[13];
                    displayLog(" offline serial " + serial + " || Never config  " + config + "|| Never eixts");
                    AddDataToBatchHisOffLine(serial, config);
                    // Thêm dữ liệu vào dtgvNode.Rows trong một luồng riêng
                    Thread addRowThread = new Thread(() =>
                    {
                        string car = string.Empty;
                        // Kiểm tra nếu serial đã tồn tại trong danh sách
                        // Chuỗi kết nối đến cơ sở dữ liệu SQLite
                        string connectionString = "Data Source=LocalDB.db;Version=3;";

                        // Tạo kết nối
                        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                        {
                            // Mở kết nối
                            connection.Open();

                            // Chuỗi truy vấn để lấy thông tin CAR từ bảng LIST_TRANSFORMERS
                            string carQuery = "SELECT CAR FROM LIST_TRANSFORMERS WHERE SERIAL = @Serial";

                            // Tạo đối tượng Command
                            using (SQLiteCommand command = new SQLiteCommand(carQuery, connection))
                            {
                                // Thêm tham số Serial vào truy vấn
                                command.Parameters.AddWithValue("@Serial", serial);

                                // Thực hiện truy vấn và đọc dữ liệu
                                using (SQLiteDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Lấy giá trị từ cột CAR trong kết quả truy vấn
                                        car = reader.GetString(0);
                                    }
                                }
                            }
                        }


                        // Thực hiện thao tác trên dtgvNode.Rows trong luồng riêng
                        Invoke(new Action(() =>
                        { 
                                dtgvNode.Rows.Add(serial, DCU_Cuong_Tool.Properties.Resources.button_blank_red, "Chưa nhận",car);
                            
                        }));
                    });

                    addRowThread.Start();
                }
                else
                {
                    displayLog(recv);
                    string countString = dataReceivedCount .ToString();
                    displayLog("Send" + " Tổng số node đang offline ------>" + countString);

                    // Sử dụng Invoke để truy cập thành phần UI từ luồng khác
                    lbOffline.Invoke((MethodInvoker)delegate
                    {
                        // Tính toán phần trăm chênh lệch
                        double currentOfflineCount;
                        double ratio;

                        if (double.TryParse(countString, out currentOfflineCount))
                        {
                            double difference = currentOfflineCount / 419;  // So sánh với giá trị 419
                            ratio = difference * 100;  // Tính tỉ lệ chênh lệch so với giá trị 419
                        }
                        else
                        {
                            // Xử lý nếu không thể chuyển đổi thành số
                            ratio = 0;
                        }
                        lbOffline.Text = countString.ToString();
                        // Hiển thị phần trăm chênh lệch trong lbRatioOffline.Text
                        lbRatioOffline.Text = string.Format("{0:0.##}%", ratio);
                    });

                    //dataReceivedCount = 0;
                    Thread executeThread = new Thread(ExecuteBatchInsert);
                    executeThread.Start();
                }

            }
            // Nhận các công tơ blacklist
            if (recv.Substring(0, 5) == "FE FE" && recv.Substring(15, 2) == "06" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            {
                string[] aRec = recv.Split(' ');
                string serial = aRec[12] + aRec[11] + aRec[10] + aRec[9] + aRec[8] + aRec[7];
                if (serial != "FFFFFFFFFFFF")
                {
                    displayLog(" black list serial " + serial);
                    AddDataToBatchHisBlackList(serial);
                    // Thêm dữ liệu vào dtgvNode.Rows trong một luồng riêng

                    Thread addRowThread = new Thread(() =>
                    {
                        // Thực hiện thao tác trên dtgvNode.Rows trong luồng riêng
                        Invoke(new Action(() =>
                        {
                            dtgvNode.Rows.Add(serial, DCU_Cuong_Tool.Properties.Resources.button_blank_gray, "Chưa nhận","null");
                        }));
                    });

                    addRowThread.Start();
                }
                else
                {
                    displayLog(recv);
                    string countString = dataReceivedCount.ToString();
                    displayLog("Send" + " Tổng số node đang black list ------>" + countString);
                        // Sử dụng Invoke để truy cập thành phần UI từ luồng khác
                    lbBlackList.Invoke((MethodInvoker)delegate
                    {
                        lbBlackList.Text = countString;

                        // Tính toán phần trăm chênh lệch
                        double currentBlackListCount;
                        double ratio;

                        if (double.TryParse(countString, out currentBlackListCount))
                        {
                            double difference = currentBlackListCount / 419;  // So sánh với giá trị 419
                            ratio = difference * 100;  // Tính tỉ lệ chênh lệch so với giá trị 419
                        }
                        else
                        {
                            // Xử lý nếu không thể chuyển đổi thành số
                            ratio = 0;
                        }
                        lbBlackList.Text = countString.ToString();
                        // Hiển thị phần trăm chênh lệch trong lbRatioBlackList.Text
                        lbRatioBlackList.Text = string.Format("{0:0.##}%", ratio);
                    });

                    // dataReceivedCount = 0;
                    Thread executeThread = new Thread(ExecuteBatchInsert);
                    executeThread.Start();
                }

            }
            // Nhận các thông tin các công tơ
            if (recv.Substring(12, 5) == "00 0B" && recv.Substring(0, 5) == "FE FE" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            {
                displayLog(recv);
               
                string[] aRec = recv.Split(' ');
                if (aRec[9] != "FF")
                {
                    string location;
                    string serial;
                    string shortAddress;
                    string timeslot;
                    string layer;
                    string state;
                    string softwareVersion;
                    string hardwareVersion;
                    string stateGetDate180;
                    string pathOneSixByte;
                    string pathOneTwoByte;
                    string url;

                    try
                    {
                        location = aRec[7] + aRec[8];
                    }
                    catch
                    {
                        location = "";
                    }

                    try
                    {
                        serial = aRec[14] + aRec[13] + aRec[12] + aRec[11] + aRec[10] + aRec[9];
                    }
                    catch
                    {
                        serial = "";
                    }

                    try
                    {
                        shortAddress = aRec[15] + aRec[16];
                    }
                    catch
                    {
                        shortAddress = "";
                    }

                    try
                    {
                        timeslot = aRec[17] + aRec[18];
                    }
                    catch
                    {
                        timeslot = "";
                    }

                    try
                    {
                        layer = aRec[19];
                    }
                    catch
                    {
                        layer = "";
                    }

                    try
                    {
                        state = aRec[20];
                    }
                    catch
                    {
                        state = "";
                    }
                    try
                    {
                        softwareVersion = aRec[21] + aRec[22] + aRec[23];
                    }
                    catch
                    {
                        softwareVersion = "";
                    }

                    try
                    {
                        hardwareVersion = aRec[24] + aRec[25] + aRec[26];
                    }
                    catch
                    {
                        hardwareVersion = "";
                    }

                    try
                    {
                        stateGetDate180 = aRec[27];
                    }
                    catch
                    {
                        stateGetDate180 = "";
                    }

                    try
                    {
                        pathOneSixByte = aRec[28] + aRec[29] + aRec[30] + aRec[31] + aRec[32] + aRec[33];
                    }
                    catch
                    {
                        pathOneSixByte = "";
                    }

                    try
                    {
                        pathOneTwoByte = aRec[40] + aRec[41] + aRec[42] + aRec[43];
                    }
                    catch
                    {
                        pathOneTwoByte = "";
                    }

                    try
                    {
                        url = aRec[34] + aRec[35] + aRec[36] + aRec[37] + aRec[38] + aRec[39] + aRec[40] + aRec[41] + aRec[42] + aRec[43];
                    }
                    catch
                    {
                        url = "";
                    }
                    string logMessage = string.Format("Địa chỉ: {0,-20} Serial: {1}\n", location, serial) +
                         string.Format("Địa chỉ ngắn: {0,-17} TimeSlot: {1}\n", shortAddress, timeslot) +
                         string.Format("Layer: {0,-20} Trạng Thái: {1}\n", layer, state) +
                         string.Format("Phần mềm: {0,-19} Phần cứng: {1}\n", softwareVersion, hardwareVersion) +
                         string.Format("Lấy 180: {0,-17} Six byte: {1}\n", stateGetDate180, pathOneSixByte) +
                         string.Format("Two byte: {0,-19} URL: {1}\n", pathOneTwoByte, url);

                    displayLog(logMessage);
                    string countString = (dataReceivedCount + 1).ToString();

                    AddDataToBatchHisInfomation(serial, location, shortAddress, timeslot, layer, state, softwareVersion, hardwareVersion, stateGetDate180, pathOneSixByte, pathOneTwoByte, url);
                    Thread executeThread = new Thread(ExecuteBatchInsert);
                    executeThread.Start();

                    displayLog("Recv " + "Infomation of node, index is : " + dataReceivedCount);
                }

            }
            if (recv.Length >= 400 && recv.Substring(0, 5) == "FE FE" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            {
                displayLog(recv);
                displayLog("Neighbours list index: --------------------------->" + dataReceivedCount);
                string[] aRec = recv.Split(' ');
                string serial = "";
                string location = "";

                for (int i = 12; i >= 7; i--)
                {
                    serial += aRec[i];
                }

                for (int i = 13; i <= 419; i++)
                {
                    //if (i != 30 && i != 31 && i != 32 && i != 33 && i != 34 && i != 35 && i != 36 && i != 37 && i != 38)
                    //{
                        location += aRec[i];
                    //}
                }

                AddDataToBatchHisNeighobur(serial, location);
                Thread executeThread = new Thread(ExecuteBatchInsert);
                executeThread.Start();
            }
            // Nhận dữ liệu hoá đơn ngày
            if (recv.Length >= 22 && recv.Length < 50)
            {
                if (recv.Substring(0, 5) == "FE FE" && recv.Substring(12, 5) == "11 03" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
                {
                    try
                    {
                        displayLog("Dữ liệu 180" + recv);
                        string[] aRec = recv.Split(' ');
                        string serial = aRec[12] + aRec[11] + aRec[10] + aRec[9] + aRec[8] + aRec[7];
                        string dateTime = "20" + MyLib.HexStringToByte(aRec[18]).ToString().PadLeft(2, '0') + "-" + MyLib.HexStringToByte(aRec[17]).ToString().PadLeft(2, '0') + "-" + MyLib.HexStringToByte(aRec[16]).ToString().PadLeft(2, '0')
                            + " " + MyLib.HexStringToByte(aRec[13]).ToString().PadLeft(2, '0') + ":" + MyLib.HexStringToByte(aRec[14]).ToString().PadLeft(2, '0') + ":" + MyLib.HexStringToByte(aRec[15]).ToString().PadLeft(2, '0');
                        string tem = "";
                        for (int i = 19; i <= aRec.Length - 3; i++)
                        {
                            tem += aRec[i] + " ";
                        }
                        string temActive = MyLib.ByteArrToASCII(MyLib.HexStringToArrByte(MyLib.FormatHexString(tem)));
                        int index = temActive.IndexOf("(");
                        double dActive = Convert.ToDouble(temActive.Substring(index + 1, temActive.Length - index - 7));
                        AddDataToBatchHisDaiLy(serial, dateTime, dActive);
                        Thread executeThread = new Thread(ExecuteBatchInsert);
                        executeThread.Start();
                        clsSQLite.ExecuteSql("insert into HIS_DAILY (SERIAL, DATA_TIME, V180, CREATED) values (" + serial + ", '" + dateTime + "', " + dActive + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                    }
                    catch { }
                }
            }

        }
        string connectionString = "Data Source=LocalDB.db;Version=3;";
        List<string> dataToWriteBatch = new List<string>();

        void AddDataToBatch(string serial, string level)
        {
            string data = $"INSERT INTO HIS_ONLINE (SERIAL, LEVEL, CREATED) VALUES ('{serial}', '{level}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }

        void AddDataToBatchHisOffLine(string serial, string config)
        {
            string data = $"INSERT INTO HIS_OFFLINE (SERIAL, CONFIG, CREATED) VALUES ('{serial}', '{config}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }

        void AddDataToBatchHisBlackList(string serial)
        {
            string data = $"INSERT INTO HIS_BLACK_LIST (SERIAL, CREATED) VALUES ('{serial}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }
        void AddDataToBatchHisDaiLy(string serial, string dateTime, double dActive)
        {
            string data = $"INSERT INTO HIS_DAILY (SERIAL, DATA_TIME, V180, CREATED) VALUES ('{serial}','{dateTime}','{dActive}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }
        void AddDataToBatchHisInfomation(string serial, string location, string shortaddress, string timeslot, string layer, string state, string softwareversion, string hardwareversion, string get180, string pathsix, string url, string pathtwo)
        {
            string data = $"INSERT INTO HIS_INFOMATION (SERIAL, LOCATION, SHORTADDRESS, TIMESLOT, LAYER, STATE, SOFTWAREVERSION, HARDWAREVERSION, GET180, PATHSIX, PATHTWO, URL, CREATED) " +
                $"VALUES ('{serial}', '{location}','{shortaddress}','{timeslot}', '{layer}', '{state}', '{softwareversion}','{hardwareversion}','{get180}','{pathsix}', '{url}','{pathtwo}',  '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }

        void AddDataToBatchHisNeighobur(string serial, string location)
        {
            string data = $"INSERT INTO HIS_NEIGHOBUR (SERIAL, LOCATION, CREATED) VALUES ('{serial}','{location}' ,'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }

        private object lockObject = new object(); // Khóa đồng bộ cho việc truy cập vào danh sách dataToWriteBatch

        void ExecuteBatchInsert()
        {
            if (dataToWriteBatch.Count > 0)
            {
                lock (lockObject) // Đảm bảo chỉ một luồng có thể truy cập vào danh sách dataToWriteBatch cùng một lúc
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        using (SQLiteTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                foreach (string data in dataToWriteBatch)
                                {
                                    using (SQLiteCommand command = new SQLiteCommand(data, connection))
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                }

                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Batch insert failed: " + ex.Message);
                                transaction.Rollback();
                            }
                        }
                    }

                    dataToWriteBatch.Clear();
                }
            }
        }

        public void StartCounterTimer()
        {
            iCounterTimeout = 0;
            bEnableCouter = true;
            bTimeoutFlag = false;
        }

        public void StopCounterTimer()
        {
            iCounterTimeout = 0;
            bEnableCouter = false;
        }

        private void SetEventFlag(bool bRecieveFlag)
        {
            if (bRecieveFlag)
            {
                receiveDone.Set();
            }
            else
            {
                receiveDone.Reset();
            }
        }
        private void OpenCOM(int iBaudRate)
        {
            try
            {
                //   myPort.Close();
                myPort.BaudRate = iBaudRate;
                myPort.Open();
                displayLog("Recv" + " Đã mở cổng " + comName + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                btnRead.Enabled = false;
                cmbPortList.Enabled = false;
                btnRead.BackColor = Color.Lime;
                btnClose.Enabled = true;
                // pnlSeri.Visible = true;
                //  pnlComand.Visible = true;

            }
            catch
            {
                displayLog("End " + " Không thể mở cổng " + comName + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                return;
            }
        }

        private void CloseCOM()
        {
            // try
            //  {
            myPort.Close();
            btnRead.Enabled = true;
            cmbPortList.Enabled = true;
            btnRead.BackColor = SystemColors.Window;
            displayLog("End " + "Đã ngắt kết nối với cổng COM " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            btnClose.Enabled = false;
            //pnlSeri.Visible = false;
            //pnlComand.Visible = false;
            //   }
            //  catch { }
        }

        private string SendCOM(string strData)
        {
            string str = "NACK";

            displayLog("Send: " + MyLib.FormatHexString(strData));

            byte[] bufferOBIS = HexString2Bytes(strData.Replace(" ", ""));

            try
            {
                myPort.ReadExisting();
            }
            catch
            {
                displayLog("Xoá buffer COM lỗi");
                return "NACK";
            }

            receiveDone.Reset();

            initWaitRec();

            myPort.Write(bufferOBIS, 0, bufferOBIS.Length);

            receiveDone.WaitOne();

            if (bBufferRecv == "")
            {
                displayLog("Hết thời gian chờ");
                return "NACK";
            }

            str = bBufferRecv.Trim('-').Trim().Replace('-', ' ').Replace("  ", " ");

            displayLog("Recv: " + MyLib.FormatHexString(str));

            return str;
        }

        private string SendWait(string strData)
        {
            string str = "NACK";

            byte[] bufferOBIS = HexString2Bytes(strData.Replace(" ", ""));

            receiveDone.Reset();

            initWaitRec();

            receiveDone.WaitOne();

            if (bBufferRecv == "")
            {
                return "NACK";
            }

            str = bBufferRecv.Trim('-').Trim().Replace('-', ' ').Replace("  ", " ");

            displayLog("Recv: " + MyLib.FormatHexString(str));

            return str;
        }

        private void SendOnly(string strData)
        {

            byte[] bufferOBIS = HexString2Bytes(strData.Replace(" ", ""));
            try
            {
                myPort.Write(bufferOBIS, 0, bufferOBIS.Length);
            }
            catch
            {
            }
        }


        public string ConvertHex(string hexString)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string[] a = hexString.Trim().Split(new char[] { ' ' });
                foreach (var h in a)
                {
                    sb.Append((char)int.Parse(h, System.Globalization.NumberStyles.HexNumber));
                }
                return sb.ToString();
            }
            catch { }

            return string.Empty;
        }

        private byte[] HexString2Bytes(string hexStr)
        {
            string hexString = hexStr.ToUpper();
            hexString = hexString.Replace(" ", "");

            if (hexString == null) return null;

            int len = hexString.Length;
            if (len % 2 == 1) return null;
            int len_half = len / 2;

            byte[] bs = new byte[len_half];
            try
            {
                for (int i = 0; i != len_half; i++)
                {
                    bs[i] = (byte)Int32.Parse(hexString.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch { }
            return bs;
        }

        public frmMain()
        {
            InitializeComponent();
            updateOutputThread = displayLog;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyLib.ReadConfigConn();
            GenerateTableCRC();
            //  pnlSeri.Visible = false;
            //pnlComand.Visible = true ;
            if (ports.Length > 0)
            {
                for (int i = 0; i < ports.Length; i++)
                {
                    cmbPortList.DisplayMember = "Text";
                    cmbPortList.ValueMember = "Value";
                    cmbPortList.Items.Add(new { Text = ports[i], Value = ports[i] });
                }
            }
            btnClose.Enabled = false;
            btnEnd.Visible = false;
        }


        // Lấy cấu hình từ db từ file
        public void ReadMeterList()
        {
            meterList.Clear();
        }

        public void port_SendData(string sendForm)
        {
            byte[] bytestosend;
            bytestosend = MyLib.HexStrToByteArr(sendForm);
            port.Write(bytestosend, 0, bytestosend.Length);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CloseCOM();
        }
        public bool checkCom()
        {
            if (cmbPortList.Text == string.Empty)
            {
                displayLog("Chưa chọn cổng COM " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                return false;
            }

            InitTimer_COM();

            comName = cmbPortList.Text;

            try
            {
                myPort.PortName = comName;
                myPort.Parity = Parity.None;
                myPort.StopBits = StopBits.One;
                myPort.BaudRate = 9600;
                myPort.DataBits = 8;
                myPort.DtrEnable = true;
                myPort.RtsEnable = true;
            }
            catch
            {
            }

            return true;
        }

        public void displayLog(string msg)
        {
            if (rtbOutput.InvokeRequired)
            {
                try
                {
                    rtbOutput.Invoke(updateOutputThread, msg);
                }
                catch { }
            }
            else
            {
                Color textColor = new Color();
                if (msg.IndexOf("Send") > -1)
                {
                    textColor = Color.Blue;
                }
                else if (msg.IndexOf("Recv") > -1)
                {
                    textColor = Color.Green;
                }
                else if (msg.IndexOf("End") > -1)
                {
                    textColor = Color.Red;
                }
                else
                {
                    textColor = Color.Black;
                }
                rtbOutput.SelectionStart = rtbOutput.TextLength;
                rtbOutput.SelectionLength = 0;
                rtbOutput.SelectionColor = textColor;
                rtbOutput.AppendText(msg + Environment.NewLine);
                rtbOutput.SelectionColor = rtbOutput.ForeColor;
                rtbOutput.ScrollToCaret();
                Application.DoEvents();
            }
        }

        uint8_t[] table = new uint8_t[256];

        public uint8_t Crc8(uint8_t[] val, int len)
        {
            uint8_t c = 0xff;
            for (int i = 0; i < len; i++)
            {
                c = table[c ^ val[i]];
            }
            return c;
        }

        public void GenerateTableCRC()
        {
            int poly = 0x07;
            for (int i = 0; i < 256; ++i)
            {
                int curr = i;
                for (int j = 0; j < 8; ++j)
                {
                    if ((curr & 0x80) != 0)
                        curr = (curr << 1) ^ (int)poly;
                    else
                        curr <<= 1;
                }
                table[i] = (uint8_t)curr;
            }
        }

        public string getCRC(string hex)
        {
            byte[] arr = HexString2Bytes(hex);
            return Crc8(arr, arr.Length).ToString("X2");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (!checkCom()) return;
            OpenCOM(9600);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            while (isListening && bEnableCouter == false)
            {

            }
        }
        public string calLen(string s)
        {
            return (s.Replace(" ", "").Length / 2).ToString("X2").ToUpper();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbOutput.Text = "";
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse txt File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Text File|*.txt;",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            ReadMeterList();
        }

        private void btnCreateMeterSeri_Click(object sender, EventArgs e)
        {
            string result = "";
            foreach (string s in meterList)
            {
                result += s.Substring(10, 2) + s.Substring(8, 2) + s.Substring(6, 2) + s.Substring(4, 2) + s.Substring(2, 2) + s.Substring(0, 2) + "\r\n";
            }
            displayLog(result);
        }
        const int CommandId_AddNewMeter = 1;
        const int CommandId_DeleteOneNode = 2;
        const int CommandId_GetDataOfOneNode = 3;
        const int CommandId_GetStateOfOneNode = 4;
        const int CommandId_ClearBlackList = 5;
        const int CommandId_ResponeBlackList = 6;
        const int CommandId_ResponeAllNodeOnline = 7;
        const int CommandId_ResponeAllNodeOffline = 8;
        const int CommandID_Ask = 9;
        const int CommnadID_GetInfomationOfNode = 0x0A;
        const int CommnadID_AutoPushAllInfomationsOfNode = 0x0B;
        const int CommandID_GetGraph = 0x0C;
        const int CommandID_GetNeighoburOfOneNode = 0x0C;
        //private void btnNodeOnline_Click(object sender, EventArgs e)
        //{
        //    int commandId = CommandId_ResponeAllNodeOnline;
        //    SendCommandAndLog(commandId);
        //}

        //private void btnBlackList_Click(object sender, EventArgs e)
        //{
        //    int commandId = CommandId_ResponeBlackList;
        //    SendCommandAndLog(commandId);
        //}

        //private void btnNodeOffline_Click(object sender, EventArgs e)
        //{
        //    int commandId = CommandId_ResponeAllNodeOffline;
        //    SendCommandAndLog(commandId);
        //}
        private void btnInfomation_Click(object sender, EventArgs e)
        {
            int commandId = CommnadID_AutoPushAllInfomationsOfNode;
            SendCommandAndLog(commandId);
            this.dataReceivedCount = 0;
        }
        private void btnLocation_Click(object sender, EventArgs e)
        {
            this.dataReceivedCount = 0;
            int commandId = CommandID_GetGraph;
            SendCommandAndLog(commandId);

        }

        private void SendCommandAndLog(int commandId)
        {
            string command = "FE FE 06 00 01 " + commandId.ToString("X2") + " FF FF FF FF FF FF 0A 0D";
            displayLog("Send: " + command + " /" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            SendOnly(command);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmList flist = new frmList();
            flist.Show();
        }

        private void btnChar_Click(object sender, EventArgs e)
        {
            frmChar fChar = new frmChar();
            fChar.Show();
        }
        private List<string> receivedSerials = new List<string>(); // Khai báo danh sách tạm thời chứa các số serial đã nhận được

        private async void btnReset_Click(object sender, EventArgs e)
        {
            // Lấy ngày hôm nay
            DateTime today = DateTime.Today;
            string todayString = today.ToString("yyyy-MM-dd");
            string connectionString = "Data Source=LocalDB.db;Version=3;";

            // Thực hiện toàn bộ quá trình trong một luồng riêng
            await Task.Run(() =>
            {
                // Tạo đối tượng SQLiteConnection
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string commandText = "SELECT SERIAL FROM HIS_DAILY WHERE CREATED LIKE @todayString";

                    using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@todayString", $"{todayString}%");

                        // Thực hiện câu truy vấn và đọc kết quả
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string serialFromDB = reader.GetString(0);

                                // Thêm giá trị vào danh sách tạm thời receivedSerials
                                receivedSerials.Add(serialFromDB);
                            }
                        }
                    }
                }
            });

            // Cập nhật giao diện trên luồng UI chính
            lbV180.Invoke((MethodInvoker)delegate
            {
                int totalCount = receivedSerials.Count;
                lbV180.Text = totalCount.ToString();
                YourMethodOrEvent();
                load();
            });
        }

        private void dtgvNode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Kiểm tra người dùng đã nhấp vào hàng hợp lệ hay không
                {
                    DataGridViewRow selectedRow = dtgvNode.Rows[e.RowIndex];

                    // Lấy giá trị của cột đầu tiên trong hàng đã chọn
                    object cellValue = selectedRow.Cells[0].Value;
                    if (cellValue != null)
                    {
                        string value = cellValue.ToString();

                        // Hiển thị giá trị trong TextBox
                        txtSerialNode.Text = value;
                    }
                    else
                    {
                        // Xử lý khi giá trị là null
                        // Ví dụ: Gán giá trị mặc định cho TextBox
                        txtSerialNode.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                // Ví dụ: Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnReadInfomationNode_Click(object sender, EventArgs e)
        {
            string serial = txtSerialNode.Text;

            if (!string.IsNullOrEmpty(serial))
            {
                // Chuỗi kết nối đến cơ sở dữ liệu SQLite
                string connectionString = "Data Source=LocalDB.db;Version=3;";

                // Tạo kết nối
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Chuỗi truy vấn để lấy thông tin của serial
                    string query = "SELECT * FROM HIS_INFOMATION WHERE SERIAL = @Serial ORDER BY datetime(CREATED) DESC LIMIT 1";

                    // Tạo đối tượng Command
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Thêm tham số Serial vào truy vấn
                        command.Parameters.AddWithValue("@Serial", serial);

                        // Thực hiện truy vấn và đọc dữ liệu
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy giá trị từ cột tương ứng trong kết quả truy vấn
                                string location = reader.GetString(3);
                                string shortAddress = reader.GetString(3);
                                string timeSlot = reader.GetString(4);
                                string layer = reader.GetString(5);
                                string state = reader.GetString(6);
                                string softwareVersion = reader.GetString(7);
                                string hardwareVersion = reader.GetString(8);
                                string get180 = reader.GetString(9);
                                string pathSix = reader.GetString(10);
                                string pathTwo = reader.GetString(11);
                                string url = reader.GetString(12);
                                string created = reader.GetString(13);

                                // Hiển thị thông tin trong MessageBox
                                MessageBox.Show("Thông tin của serial: " + serial + "\nVị trí node: " + location + "\nĐịa chỉ ngắn: " + shortAddress
                                    + "\nTime slot: " + timeSlot + "\nLayer: " + layer + "\nTrạng thái: " + state + "\nPhiên bản phần mềm: " + softwareVersion
                                    + "\nPhiên bản phần cứng: " + hardwareVersion + "\nTrạng thái 180: " + get180 + "\nĐường dẫn sixbyte: " + pathSix + "\nĐường dẫn towbyte: " + pathTwo
                                    + "\nURL: " + url + "\nNgày tạo: " + created);
                            }
                            else
                            {
                                // Serial không tồn tại trong bảng serial
                                MessageBox.Show("Không có thông tin cho serial này");
                            }
                        }
                    }
                }
            }
            else
            {
                // Xử lý khi serial rỗng
                MessageBox.Show("Vui lòng nhập serial trước");
            }
        }
        private void btn_LocationSerial_Click(object sender, EventArgs e)
        {
            // Lấy giá trị của TextBox "txtSerialNode"
            string serial = txtSerialNode.Text;

            // Kiểm tra giá trị serial nếu cần thiết
            if (!string.IsNullOrEmpty(serial))
            {
                // Chuỗi kết nối đến cơ sở dữ liệu SQLite
                string connectionString = "Data Source=LocalDB.db;Version=3;";

                // Tạo kết nối
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Chuỗi truy vấn để lấy thông tin vị trí của serial
                    string locationQuery = "SELECT LOCATION FROM HIS_NEIGHOBUR WHERE SERIAL = @Serial ORDER BY CREATED DESC LIMIT 1";

                    // Tạo đối tượng Command để lấy thông tin vị trí
                    using (SQLiteCommand locationCommand = new SQLiteCommand(locationQuery, connection))
                    {
                        // Thêm tham số Serial vào truy vấn
                        locationCommand.Parameters.AddWithValue("@Serial", serial);

                        // Thực hiện truy vấn và đọc dữ liệu
                        using (SQLiteDataReader locationReader = locationCommand.ExecuteReader())
                        {
                            string location = null;

                            if (locationReader.Read())
                            {
                                // Lấy giá trị từ cột tương ứng trong kết quả truy vấn
                                location = locationReader.GetString(0);
                            }
                                  

                                    // Tạo thông báo chứa thông tin vị trí và CAR
                                    string message = "Thông tin của serial: " + serial + "\n";

                            if (!string.IsNullOrEmpty(location))
                            {
                                message += "Vị trí node ở gần: " + location + "\n";
                            }
                                    // Hiển thị thông tin trong MessageBox
                                    MessageBox.Show(message);
                                }
                            }
                        }
            }
            else
            {
                // Xử lý khi serial rỗng
                MessageBox.Show("Vui lòng nhập serial trước");
            }
        }
        private bool executedOnce = false; // Biến kiểm tra xem hành động đã được thực hiện một lần hay chưa

        async Task PerformClicksWithDelay()
        {
            this.dataReceivedCount = 0;
            await Task.Delay(1000);// Đợi 1 giây
            dtgvNode.Rows.Clear();
            SendCommandAndLog(CommandId_ResponeBlackList);
            await Task.Delay(10000); // Đợi 10 giây
            this.dataReceivedCount = 0;
            displayLog("-----------------------------");
            await Task.Delay(1000); // Đợi 1 giây
            SendCommandAndLog(CommandId_ResponeAllNodeOffline);
            await Task.Delay(20000); // Đợi 30 giây
            this.dataReceivedCount = 0;
            displayLog("-----------------------------");
            await Task.Delay(1000); // Đợi 1 giây
            SendCommandAndLog(CommandId_ResponeAllNodeOnline);
            await Task.Delay(30000); // Đợi 30 giây
            this.dataReceivedCount = 0;
            displayLog("-----------------------------");
            await Task.Delay(1000); // Đợi 1 giây
            this.bBufferRecv = "";
            displayLog("Recv" + "reset buffer");
            complete();
        }
        async void YourMethodOrEvent()
        {
            await PerformClicksWithDelay();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime.Hour == currentHour && !executedOnce)
            {
                // Thực hiện hành động chỉ chạy đúng một lần khi currentTime.Hour = 13
                YourMethodOrEvent();
                load();
                executedOnce = true; // Đánh dấu rằng hành động đã được thực hiện một lần
            }
            else if (currentTime.Hour % getTime == 0 && currentTime.Minute == 0 && currentTime.Second == 0 && executedOnce == true)
            {
                YourMethodOrEvent();
            }
        }
        private int getTime = 0;
        private int currentHour = 0;

        public static SerialPort ConnectedSerialPort { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnEnd.Visible = true;
            // Chuyển đổi giá trị của textBox1 thành số nguyên
            if (int.TryParse(txtTimeGet.Text, out int number) && int.TryParse(textBox1.Text, out int number1))
            {
                if (number == 0)
                {
                    getTime = 1;
                }
                else
                {
                    getTime = number;
                }
                DateTime currentTime = DateTime.Now;
                if (number1 == 0)
                {

                    this.currentHour = currentTime.Hour;
                }
                else
                {
                    this.currentHour = currentTime.Hour + number1;
                }

                // Chuyển đổi thành công, số nguyên được lưu trong biến "number"
                // Bạn có thể sử dụng giá trị số nguyên ở đây

                btnStart.BackColor = Color.Lime;
                btnEnd.BackColor = Color.Red;
                txtTimeGet.Enabled = false;
                textBox1.Enabled = false;
                timer4.Start();
                displayLog("Recv" + " Tự động lấy dữ liệu lần đầu tiền sau " + textBox1.Text + " h  những lần sau " + txtTimeGet.Text + " h ");
            }
            else
            {
                // Chuyển đổi không thành công, xử lý khi chuỗi không phải là một số nguyên hợp lệ
                MessageBox.Show("Giá trị không hợp lệ!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            executedOnce = false;
            timer4.Stop();
            txtTimeGet.Enabled = true;
            textBox1.Enabled = true;
            btnStart.Visible = true;
            btnEnd.Visible = false;
            displayLog("End" + " Kết thúc lấy dữ liệu tự động");
        }
        //Đóng tool
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng chương trình?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
        private void load()
        {
            prgLoad.Visible = true;
            panel1.Enabled = false;
            guna2CustomGradientPanel1.Enabled = false;
        }
        private void complete()
        {
            prgLoad.Visible = false;
            panel1.Enabled = true;
            guna2CustomGradientPanel1.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dtgvNode.Rows.Clear();
            this.dataReceivedCount = 0;
            SendCommandAndLog(CommandId_ResponeAllNodeOnline);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dtgvNode.Rows.Clear();
            this.dataReceivedCount = 0;
            SendCommandAndLog(CommandId_ResponeAllNodeOffline);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dtgvNode.Rows.Clear();
            this.dataReceivedCount = 0;

            SendCommandAndLog(CommandId_ResponeBlackList);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmCompare fCompare = new frmCompare();
            fCompare.Show();
        }
    }
}