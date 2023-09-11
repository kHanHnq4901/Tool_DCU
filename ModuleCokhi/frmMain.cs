using DCU_Cuong_Tool;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
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
            int ibyte = serialPort.BytesToRead;
            byte[] myArrData = new byte[ibyte];
            serialPort.Read(myArrData, 0, ibyte);
            bBufferRecv += MyLib.ByteArrToHexString(myArrData);
            int iStartFrame = bBufferRecv.IndexOf("FEFE");
            int iEndFrame = bBufferRecv.IndexOf("0A0D");
            if (iEndFrame > iStartFrame && iStartFrame > -1)
            {
                string tembBufferRecv = bBufferRecv.Substring(iStartFrame, iEndFrame + 4 - iStartFrame);
                ProcessRecv(MyLib.FormatHexString(tembBufferRecv.Replace("-", " ")));
                bBufferRecv = bBufferRecv.Substring(iEndFrame + 4, bBufferRecv.Length - iEndFrame - 4);
                this.dataReceivedCount++;
            }
        
        }

        public void ProcessRecv (string recv)
        {
            //Nhận các công tơ đang online
            if (recv.Substring(0, 5) == "FE FE" && recv.Substring(15, 2) == "07" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
                {
                string[] aRec = recv.Split(' ');
                string serial = aRec[7] + aRec[8] + aRec[9] + aRec[10] + aRec[11] + aRec[12];
                string level = aRec[13];
                if (serial != "FFFFFFFFFFFF")
                {
                    displayLog("serial " + serial + "|| tầng " + level);
                    string query = "INSERT INTO HIS_ONLINE (SERIAL, LEVEL, CREATED) VALUES ('" + serial + "', " + level + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                    clsSQLite.ExecuteSql(query);
                }
                else
                {
                    displayLog(recv);
                    string countString = (dataReceivedCount-1) .ToString();
                    displayLog("Send" + " Tổng số node đang online ------> " + countString);
                    dataReceivedCount = 0;
                }
            }
            //Nhận các công tơ đang offline
            else if (recv.Substring(0, 5) == "FE FE" && recv.Substring(15, 2) == "08" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            {
                string[] aRec = recv.Split(' ');
                string serial = aRec[7] + aRec[8] + aRec[9] + aRec[10] + aRec[11] + aRec[12];
                if (serial != "FFFFFFFFFFFF")
                {
                    string config = aRec[13];
                    displayLog("serial " + serial + " || Never config  " + config + "|| Never eixts");

                    string query = "INSERT INTO HIS_OFFLINE (SERIAL, CREATED) VALUES ('" + serial + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    clsSQLite.ExecuteSql(query);
                }
                else 
                { 
                    displayLog(recv);
                    string countString = (dataReceivedCount-1).ToString();
                    displayLog("Send"+ " Tổng số node đang offline ------>" + countString);
                    dataReceivedCount = 0;
                };
               
            }
            //Nhận các công tơ blacklist
            else if (recv.Substring(0, 5) == "FE FE" && recv.Substring(15, 2) == "06" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            {
                string[] aRec = recv.Split(' ');
                string serial = aRec[7] + aRec[8] + aRec[9] + aRec[10] + aRec[11] + aRec[12];
                if (serial != "FFFFFFFFFFFF")


                {
                    displayLog("serial " + serial);
                    string query = "INSERT INTO HIS_BLACK_LIST (SERIAL, CREATED) VALUES ('" + serial + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

                    clsSQLite.ExecuteSql(query);
                }
                else {
                    displayLog(recv);
                   string countString = (dataReceivedCount-1).ToString();
                    displayLog("Send" + " Tổng số node đang  black list ------>" +countString);
                    dataReceivedCount = 0;
                };
            }

            if (recv == "FE FE 01 02 AA AA " + getCRC("02 AA AA") + " 0A 0D")
            {
                string lenPay = "06 "
                    + txtDCUNo.Text.Trim().PadLeft(12, '0').Substring(0, 2) + " "
                    + txtDCUNo.Text.Trim().PadLeft(12, '0').Substring(2, 2) + " "
                    + txtDCUNo.Text.Trim().PadLeft(12, '0').Substring(4, 2) + " "
                    + txtDCUNo.Text.Trim().PadLeft(12, '0').Substring(6, 2) + " "
                    + txtDCUNo.Text.Trim().PadLeft(12, '0').Substring(8, 2) + " "
                    + txtDCUNo.Text.Trim().PadLeft(12, '0').Substring(10, 2);
                SendOnly("FE FE 05 " + lenPay + " " + getCRC(lenPay) + " 0A 0D");
            }

            // Yêu cầu gửi seri công tơ
            // FE FE 02 02 00 00 FD 0A 0D
            if (recv.IndexOf("FE FE 02 02") > -1)
            {
                try
                {
                    string iMeterBytes = recv[12].ToString() + recv[13].ToString() + recv[15].ToString() + recv[16].ToString();
                    int iMeter = Convert.ToInt32(iMeterBytes, 16);

                    if (recv == "FE FE 02 02 " + iMeterBytes.Substring(0, 2) + " " + iMeterBytes.Substring(2, 2) + " " + getCRC("02 " + iMeterBytes.Substring(0, 2) + " " + iMeterBytes.Substring(2, 2)) + " 0A 0D")
                    {
                        string seri = meterList[iMeter].PadLeft(12, '0');
                        string seriBytes = meterList.Count.ToString("X4");
                        string iBytes = iMeter.ToString("X4");
                        string seriHex = seri.Substring(0, 2) + " "
                            + seri.Substring(2, 2) + " "
                            + seri.Substring(4, 2) + " "
                            + seri.Substring(6, 2) + " "
                            + seri.Substring(8, 2) + " "
                            + seri.Substring(10, 2);
                        string lenPay = "0B " + seriBytes.Substring(0, 2) + " " + seriBytes.Substring(2, 2) + " " + iBytes.Substring(0, 2) + " " + iBytes.Substring(2, 2) + " " + seriHex + " 01";
                        SendOnly("FE FE 06 " + lenPay + " " + getCRC(lenPay) + " 0A 0D");
                    }
                }
                catch { }
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
                        clsSQLite.ExecuteSql("insert into HIS_DAILY (SERIAL, DATA_TIME, V180, CREATED) values (" + serial + ", '" + dateTime + "', " + dActive + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                    }
                    catch { }
                }
            }

            // Nhận dữ liệu online
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
                        //clsSQLite.ExecuteSql("insert into HIS_DAILY (SERIAL, DATA_TIME, V180, CREATED) values (" + serial + ", '" + dateTime + "', " + dActive + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                    }
                    catch { }
                }
            }
           
            //Nhận các công tơ black list
            //if (recv.Length >= 22)
            //{
            //    if (recv.Substring(0, 5) == "FE FE" && recv.Substring(12, 5) == "11 00" && recv.Substring(recv.Length - 5, 5) == "0A 0D")
            //    {
            //        try
            //        {
            //            string[] aRec = recv.Split(' ');
            //            string serial = aRec[12] + aRec[11] + aRec[10] + aRec[9] + aRec[8] + aRec[7];
            //            string level = aRec[13];
            //            ///double dActive = Convert.ToDouble(temActive.Substring(index + 1, temActive.Length - index - 7));
            //            //clsSQLite.ExecuteSql("insert into HIS_DAILY (SERIAL, DATA_TIME, V180, CREATED) values (" + serial + ", '" + dateTime + "', " + dActive + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
            //        }
            //        catch { }
            //    }
            //}
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
                displayLog("Recv"+" Đã mở cổng " + comName + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                btnRead.Enabled = false;
                cmbPortList.Enabled = false;
                btnRead.BackColor = Color.Lime;
                btnRefresh.Enabled = true;
                pnlSeri.Visible = true;
                pnlComand.Visible = true;

            }
            catch
            {
                displayLog("End "+" Không thể mở cổng " + comName + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
               // displayLog("Send: " + MyLib.FormatHexString(strData));

            }
          //  displayLog("Send: " + MyLib.FormatHexString(strData));
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
            
            timer3.Interval = 1000; // Cập nhật mỗi giây (1000 milliseconds)
            timer3.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyLib.ReadConfigConn();
            GenerateTableCRC();
            pnlSeri.Visible = false;
            pnlComand.Visible = true;
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
          //  string strPath = txtPath.Text;

         //   FileInfo config_f = new FileInfo(strPath);
         //   foreach (string line in File.ReadAllLines(config_f.FullName))
         //   {
          //      if (line != string.Empty)
          //      {
           //         meterList.Add(line);
           //     }
          //  }
        }

        public void port_SendData(string sendForm)
        {
            byte[] bytestosend;
            bytestosend = MyLib.HexStrToByteArr(sendForm);
            port.Write(bytestosend, 0, bytestosend.Length);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MyLib.ReadConfigConn();
            //ReadMeterList();
            //ports = SerialPort.GetPortNames();
            //cmbPortList.Items.Clear();
            //try
            //{
            //    port.Close();
            //}
            //catch { }
            //if (ports.Length > 0)
            //{
            //    for (int i = 0; i < ports.Length; i++)
            //    {
            //        cmbPortList.DisplayMember = "Text";
            //        cmbPortList.ValueMember = "Value";
            //        cmbPortList.Items.Add(new { Text = ports[i], Value = ports[i] });
            //    }
            //}
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
              //  rtbOutput.AppendText("----------------\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" + msg + Environment.NewLine);
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

        //private void btnSend_Click(object sender, EventArgs e)
        //{
        //    string lenPay = calLen(txtPayload.Text.Trim()) + " " + txtPayload.Text.Trim().ToUpper();
        //    SendOnly("FE FE " + txtCMD.Text.Trim().ToUpper() + " " + lenPay + " " + getCRC(lenPay) + " 0A 0D");
        //}

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

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    txtPath.Text = openFileDialog1.FileName;
            //}

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

        private void SendCommandAndLog(int commandId, string logMessage)
        {
            string command = "FE FE 06 00 01 " + commandId.ToString("X2") + " FF FF FF FF FF FF 0A 0D";
            displayLog("Send: " + logMessage + " /" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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

        private void timer3_Tick(object sender, EventArgs e)
        {
            lbCurrentTime.Text = DateTime.Now.ToString();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.Second == 00)
            {
                btnNodeOnline.PerformClick();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.Lime;
            timer4.Enabled = true;
            displayLog("Recv" + " Đã bật tự động ghi");
            btnStart.Enabled = false;    
            btnEnd.Enabled = true;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnEnd.Enabled = false;
            displayLog("End " + "Đã kết thúc ghi");
            timer4.Enabled = false;
            btnStart.BackColor = SystemColors.Window;
        }
    }
}