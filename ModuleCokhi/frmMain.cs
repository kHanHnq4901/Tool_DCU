using DCU_Cuong_Tool;
using NPOI.OpenXmlFormats.Dml;
using NPOI.SS.Formula.Eval;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection.Emit;
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
                    displayLog("serial " + serial + "|| tầng " + level);
                    AddDataToBatch(serial, level);
                }
                else
                {
                    displayLog(recv);
                    string countString = (dataReceivedCount - 1).ToString();
                    displayLog("Send" + " Tổng số node đang online ------> " + countString);
                    dataReceivedCount = 0;
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
                    displayLog("serial " + serial + " || Never config  " + config + "|| Never eixts");
                    AddDataToBatchHisOffLine(serial, config);
                }
                else
                {
                    displayLog(recv);
                    string countString = (dataReceivedCount - 1).ToString();
                    displayLog("Send" + " Tổng số node đang offline ------>" + countString);
                    dataReceivedCount = 0;
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
                    displayLog("serial " + serial);
                    AddDataToBatchHisBlackList(serial);
                }
                else
                {
                    displayLog(recv);
                    string countString = (dataReceivedCount - 1).ToString();
                    displayLog("Send" + " Tổng số node đang black list ------>" + countString);
                    dataReceivedCount = 0;
                    Thread executeThread = new Thread(ExecuteBatchInsert);
                    executeThread.Start();
                }
                
            }
            // Nhận dữ liệu hoá đơn ngày
            if (recv.Length >= 22)
            {
                if (recv.Substring(0, 5) == "FE FE" && recv.Substring(12, 5) == "11 03" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
                {
                    try
                    {
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
                        AddDataToBatchHisDaiLy(serial,dateTime,dActive);
                        Thread executeThread = new Thread(ExecuteBatchInsert);
                        executeThread.Start();
                        // clsSQLite.ExecuteSql("insert into HIS_DAILY (SERIAL, DATA_TIME, V180, CREATED) values (" + serial + ", '" + dateTime + "', " + dActive + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
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

        void AddDataToBatchHisOffLine(string serial,string config)
        {
            string data = $"INSERT INTO HIS_OFFLINE (SERIAL, CONFIG, CREATED) VALUES ('{serial}', '{config}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }

        void AddDataToBatchHisBlackList(string serial)
        {
            string data = $"INSERT INTO HIS_BLACK_LIST (SERIAL, CREATED) VALUES ('{serial}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
            dataToWriteBatch.Add(data);
        }
        void AddDataToBatchHisDaiLy(string serial,string dateTime, double dActive)
        {
            string data = $"INSERT INTO HIS_DAILY (SERIAL, DATA_TIME, V180, CREATED) VALUES ('{serial}','{dateTime}','{dActive}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
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
                btnRefresh.Enabled = true;
                pnlSeri.Visible = true;
                pnlComand.Visible = true;

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
                displayLog("End "+ "Đã ngắt kết nối với cổng COM " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                btnRefresh.Enabled = false;
                pnlSeri.Visible = false;
                pnlComand.Visible = false;
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
            catch {
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
            pnlSeri.Visible = false;
            pnlComand.Visible = true ;
            if (ports.Length > 0)
            {
                for (int i = 0; i < ports.Length; i++)
                {
                    cmbPortList.DisplayMember = "Text";
                    cmbPortList.ValueMember = "Value";
                    cmbPortList.Items.Add(new { Text = ports[i], Value = ports[i] });
                }
            }
                btnRefresh.Enabled=false;
          
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
                if(msg.IndexOf("Send") > -1)
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
                rtbOutput.AppendText( msg + Environment.NewLine);
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
                result += s.Substring(10, 2) + s.Substring(8, 2) + s.Substring(6, 2) + s.Substring(4, 2) + s.Substring(2, 2) + s.Substring(0, 2)+"\r\n";
            }
            displayLog(result);
        }
        //private void btnNodeOnline_Click(object sender, EventArgs e)
        //{
        //    displayLog("Send"+"Lấy toàn bộ các node online /" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    SendOnly("FE FE 06 00 01 07 FF FF FF FF FF FF 0A 0D");
        //}

        //private void btnBlackList_Click(object sender, EventArgs e)
        //{
        //    displayLog("Send" + "Lấy toàn bộ các node blacklist /" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    SendOnly("FE FE 06 00 01 06 FF FF FF FF FF FF 0A 0D");
        //}

        //private void btnNodeOffline_Click(object sender, EventArgs e)
        //{
        //    displayLog("Send" + "Lấy toàn bộ các node offline /" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        //    SendOnly("FE FE 06 00 01 08 FF FF FF FF FF FF 0A 0D");
        //}
        const int CommandId_AddNewMeter = 1;
        const int CommandId_DeleteOneNode = 2;
        const int CommandId_GetDataOfOneNode = 3;
        const int CommandId_GetStateOfOneNode = 4;
        const int CommandId_ClearBlackList = 5;
        const int CommandId_ResponeBlackList = 6;
        const int CommandId_ResponeAllNodeOnline = 7;
        const int CommandId_ResponeAllNodeOffline = 8;
        const int CommandID_Ask = 9;
        const int CommnadID_GetInfomationOfNode = 10;
        const int CommnadID_AutoPushAllInfomationsOfNode = 11;
        const int CommandID_GetGraph = 12;
        const int CommandID_GetNeighoburOfOneNode = 13;
        private void btnNodeOnline_Click(object sender, EventArgs e)
        {
            int commandId = CommandId_ResponeAllNodeOnline;
            SendCommandAndLog(commandId, "Lấy toàn bộ các node online");
        }

        private void btnBlackList_Click(object sender, EventArgs e)
        {
            int commandId = CommandId_ResponeBlackList;
            SendCommandAndLog(commandId, "Lấy toàn bộ các node blacklist");
        }

        private void btnNodeOffline_Click(object sender, EventArgs e)
        {
            int commandId = CommandId_ResponeAllNodeOffline;
            SendCommandAndLog(commandId, "Lấy toàn bộ các node offline");
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            int commandId = CommandId_GetDataOfOneNode;
            SendCommandAndLog(commandId, "Lấy dữ liệu của các node");
        }

        private void SendCommandAndLog(int commandId, string logMessage)
        {
            string command = "FE FE 06 00 01 " + commandId.ToString("X2") + " FF FF FF FF FF FF 0A 0D";
            displayLog("Send: " + logMessage +" /" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
        private bool executedOnce = false; // Biến kiểm tra xem hành động đã được thực hiện một lần hay chưa

        async Task PerformClicksWithDelay()
        {

            btnBlackList.PerformClick();
            await Task.Delay(10000); // Đợi 10 giây

            btnNodeOffline.PerformClick();
            await Task.Delay(20000); // Đợi 20 giây

            btnNodeOnline.PerformClick();
            await Task.Delay(30000); // Đợi 30 giây


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

            // Chuyển đổi giá trị của textBox1 thành số nguyên
            if (int.TryParse(txtTimeGet.Text, out int number) && int.TryParse(textBox1.Text, out int number1))
            {
                if (number == 0)
                {
                    getTime = 1;
                } else
                {
                    getTime = number;
                }
                DateTime currentTime = DateTime.Now;
                if ( number1 == 0)
                {
                    
                    this.currentHour = currentTime.Hour ;
                }else
                {
                    this.currentHour = currentTime.Hour + number1;
                }
               
                // Chuyển đổi thành công, số nguyên được lưu trong biến "number"
                // Bạn có thể sử dụng giá trị số nguyên ở đây

                button1.BackColor = Color.Lime;
                button1.Enabled = false;
                button2.Enabled = true;
                button2.BackColor = Color.Red;
                txtTimeGet.Enabled = false;
                textBox1 .Enabled = false;
                timer4.Start();
                displayLog("Recv" + " Tự động lấy dữ liệu lần đầu tiền sau " + textBox1.Text + " h  những lần sau " + txtTimeGet.Text +" h ");
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
            button1.BackColor = SystemColors.Window;
            button2.BackColor = SystemColors.Window;
            timer4.Stop();
            button1.Enabled = true;
            txtTimeGet.Enabled = true;
            button2.Enabled = false;
            textBox1.Enabled = true;
            displayLog("End" + " Kết thúc lấy dữ liệu tự động");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCompare fCompare = new frmCompare();
            fCompare.Show();
        }
        //Đóng tool
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng chương trình?", "Cảnh báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

            if (result == DialogResult.Cancel)
            {
                e.Cancel = true; // Ngăn không cho form đóng
            }
        }
    }
}