using LB.WinFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB.Common
{
    public class LBInFrareHelper
    {
        private static System.Windows.Forms.Timer mTimer = null;
        private static SerialPort _comm;
        private static bool Listening;
        private static string _SerialName = "";

        public static bool HeaderClosed = false;//车头红外线对射正常
        public static bool TailClosed = false;//车尾红外线对射正常
        public static bool IsHeaderEffect = false;
        public static bool IsTailEffect = false;
        public static bool IsAlermEffect = false;
        private static int HeaderXType;
        private static int TailXType;
        private static int SuccessYType;
        private static int FailYType;
        private static enAlermStatus _PreAlermStatus = enAlermStatus.None;//上次亮灯状态

        // '帧头定义
        public const byte BUFF_HEX_SIZE = 9;
        public const byte BUFF_ASC_SIZE = (BUFF_HEX_SIZE * 2);

        public static byte[] SendBuffHex = new byte[BUFF_HEX_SIZE ];

        public static void StartSerial()
        {
            if (mTimer != null && mTimer.Enabled)
            {
                mTimer.Enabled = false;
            }
            mTimer = new System.Windows.Forms.Timer();
            mTimer.Interval = 1000;
            mTimer.Tick += MTimer_Tick; ;
            
            InitSerialPort();

            Test();
        }

        public static void Test()
        {
            if (_comm != null && _comm.IsOpen)
            {
                byte[] buffer = new byte[9];
                buffer[1] = 90;
                buffer[2] = 83;
                buffer[3] = 0;
                buffer[4] = 7;
                buffer[5] = 0;
                buffer[6] = 15;
                buffer[7] = 0;
                buffer[8] = 195;

                _comm.DiscardInBuffer();
                _comm.Write(buffer, 0, 9);
            }
        }

        public static void InitSerialPort()
        {
            if (_comm != null && _comm.IsOpen)
            {
                _comm.Close();
            }
            _comm = new SerialPort();
            //_comm.RtsEnable = true;
            GetSerialInfo(out _SerialName, out IsHeaderEffect, out IsTailEffect,out IsAlermEffect,
                out HeaderXType, out TailXType, out SuccessYType, out FailYType);

            if ((IsHeaderEffect || IsTailEffect|| IsAlermEffect) && _SerialName != "")
            {
                _comm.ReadTimeout = 100;
                _comm.WriteTimeout = 100;
                _comm.BaudRate = 9600;
                _comm.DataBits = 8;
                _comm.StopBits = StopBits.One;
                _comm.Parity = Parity.None;
                _comm.ReceivedBytesThreshold = 9;
                _comm.PortName = _SerialName;
                _comm.RtsEnable = true;
                //lstBytes = new List<byte[]>();
                //关闭时点击，则设置好端口，波特率后打开

                try
                {
                    _comm.Open();
                }
                catch (Exception ex)
                {
                    //捕获到异常信息，创建一个新的comm对象，之前的不能用了。
                    //InitSerialPort();
                }
            }

            _comm.DataReceived += _comm_DataReceived;
        }

        private static void _comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (IsHeaderEffect || IsTailEffect)
                {
                    Listening = true;
                    byte[] ReceiveBuff = new byte[BUFF_HEX_SIZE];
                    if (_comm.ReceivedBytesThreshold == BUFF_HEX_SIZE)
                    {
                        if (_comm.Read(ReceiveBuff, 0, BUFF_HEX_SIZE) == BUFF_HEX_SIZE)
                        {
                            AppendString(ReceiveBuff);
                        }
                    }
                    else if (_comm.ReceivedBytesThreshold == BUFF_ASC_SIZE)
                    {
                        byte[] ReceiveStr = new byte[BUFF_ASC_SIZE];
                        if (_comm.Read(ReceiveStr, 0, BUFF_ASC_SIZE) == BUFF_ASC_SIZE)
                        {
                            for (byte i = 0; i < BUFF_ASC_SIZE; i++)
                            {
                                ReceiveBuff[i] = MyAscToHex(ReceiveStr[i * 2], ReceiveStr[i * 2 + 1]);
                            }

                            AppendString(ReceiveBuff);
                        }
                    }
                }
            }
            finally
            {
                Listening = false;//我用完了，ui可以关闭串口了。  
            }
        }

        private static byte MyAscToHex(byte StrTemp0, byte StrTemp1)
        {
            string StrTemp = "";
            StrTemp = Convert.ToString(StrTemp0, 16) + Convert.ToString(StrTemp1, 16);
            return (byte)Convert.ToInt32(StrTemp);
        }

        private static void AppendString(byte[] myArray)
        {
            if (_comm.ReceivedBytesThreshold == BUFF_HEX_SIZE)
            {
                string strValue = Convert.ToString(myArray[6], 2);

                if (strValue.Length >= 4)
                {
                    byte X0 = LBConverter.ToByte(strValue.Substring(3, 1));
                    byte X1 = LBConverter.ToByte(strValue.Substring(2, 1));
                    byte X2 = LBConverter.ToByte(strValue.Substring(1, 1));
                    byte X3 = LBConverter.ToByte(strValue.Substring(0, 1));

                    if (HeaderXType == 0 && X0 == 0)
                    {
                        HeaderClosed = true;
                    }
                    else if (HeaderXType == 1 && X1 == 0)
                    {
                        HeaderClosed = true;
                    }
                    else if (HeaderXType == 2 && X2 == 0)
                    {
                        HeaderClosed = true;
                    }
                    else if (HeaderXType == 3 && X3 == 0)
                    {
                        HeaderClosed = true;
                    }
                    else
                    {
                        HeaderClosed = false;
                    }

                    if (TailXType == 0 && X0 == 0)
                    {
                        TailClosed = true;
                    }
                    else if (TailXType == 1 && X1 == 0)
                    {
                        TailClosed = true;
                    }
                    else if (TailXType == 2 && X2 == 0)
                    {
                        TailClosed = true;
                    }
                    else if (TailXType == 3 && X3 == 0)
                    {
                        TailClosed = true;
                    }
                    else
                    {
                        TailClosed = false;
                    }
                }

            }
        }

        public static string MyDecToHex(byte b)
        {
            string strReturn = "";
            string strHex = Convert.ToString(b, 16);
            if (strHex.Length == 1)
            {
                strReturn = "0" + strHex;
            }
            else
            {
                strReturn = strHex;
            }
            return strReturn;
        }

        private static int AlermTimes = 0;//警报灯持续时间
        private static void MTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //持续10秒后停止
                if (AlermTimes > 20)
                {
                    AlermTimes = 0;
                    SendY(-1);
                    mTimer.Enabled = false;
                }

                AlermTimes++;
            }
            catch (Exception ex)
            {
            }
        }

        private static void GetSerialInfo(
            out string strSerialName,
            out bool IsHeaderEffect,
            out bool IsTailEffect,
            out bool IsAlermEffect,
            out int HeaderXType,
            out int TailXType,
            out int SuccessYType,
            out int FailYType)
        {
            strSerialName = "";
            IsHeaderEffect = false;
            IsTailEffect = false;
            IsAlermEffect = false;
            HeaderXType = 0;
            TailXType = 0;
            SuccessYType = 0;
            FailYType = 0;

            string strMathineName = LoginInfo.MachineName;
            DataTable dtSerial = ExecuteSQL.CallView(134, "", "MachineName='" + strMathineName + "'", "");
            if (dtSerial.Rows.Count > 0)
            {
                DataRow dr = dtSerial.Rows[0];
                //long lWeightDeviceUserTypeID = LBConverter.ToInt64(dr["WeightDeviceUserTypeID"]);
                strSerialName = dr["SerialName"].ToString();
                IsHeaderEffect = LBConverter.ToBoolean(dr["IsHeaderEffect"]);
                IsTailEffect = LBConverter.ToBoolean(dr["IsTailEffect"]);
                IsAlermEffect= LBConverter.ToBoolean(dr["IsAlermEffect"]);
                HeaderXType = LBConverter.ToInt32(dr["HeaderXType"]);
                TailXType = LBConverter.ToInt32(dr["TailXType"]);
                SuccessYType = LBConverter.ToInt32(dr["SuccessYType"]);
                FailYType = LBConverter.ToInt32(dr["FailYType"]);
            }
        }


        public static void SendAlermStatus(enAlermStatus alermStatus)
        {
            if (IsAlermEffect)
            {
                if (alermStatus== enAlermStatus.None && _PreAlermStatus == alermStatus)
                {
                    return;
                }

                _PreAlermStatus = alermStatus;

                if (alermStatus== enAlermStatus.Success)
                {
                    if (SuccessYType > 0)
                    {
                        mTimer.Enabled = false;
                        AlermTimes = 0;
                        SendY(SuccessYType-1);
                        mTimer.Enabled = true;
                    }
                }
                else if (alermStatus == enAlermStatus.Fail)
                {
                    if (FailYType > 0)
                    {
                        mTimer.Enabled = false;
                        AlermTimes = 0;
                        SendY(FailYType-1);
                        mTimer.Enabled = true;
                    }
                }
                else
                {
                    mTimer.Enabled = false;
                    AlermTimes = 0;
                    SendY(-1);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        private static void SendY(int Y)
        {
            try
            {
                if (!_comm.IsOpen)
                {
                    LBErrorLog.InsertFileLog("COM串口已关闭，准备重启");
                    _comm.Dispose();
                    _comm.Close();
                    _comm.Open();
                }
            }
            catch (Exception ex)
            {
                LBErrorLog.InsertFileLog("OpenInFrarePort错误：" + ex.Message);
                //捕获到异常信息，创建一个新的comm对象，之前的不能用了。
                InitSerialPort();
            }

            if (_comm != null && _comm.IsOpen)
            {
                int Temp = Y == -1 ? 0 : (int)Math.Pow(2, Y);
                CommandOutPut((byte)Temp);
                _comm.DiscardInBuffer();

                LBErrorLog.InsertFileLog("开始WriteFrare");
                _comm.Write(SendBuffHex, 0, 9);
                LBErrorLog.InsertFileLog("结束WriteFrare");
            }
        }

        public const byte HEAD0 = 0;
        public const byte HEAD1 = 90;
        public const byte DEVICE_CLASS = 83;
        public const byte BoardAddress = 0;
        public const byte R_GROUP_ON = 5;
        public const byte R_OUT = 8;
        public static  void CommandOutPut(byte YByte)
        {
            SendBuffHex[0] = HEAD0;
            SendBuffHex[1] = HEAD1;
            SendBuffHex[2] = DEVICE_CLASS;
            SendBuffHex[3] = BoardAddress;
            SendBuffHex[4] = R_OUT;
            SendBuffHex[5] = YByte;
            SetCheckSum();
            DisplaySendData();
        }

        public static void SetCheckSum()
        {
            int Sum = 0;
            byte i;
            for (i = 0; i <= BUFF_HEX_SIZE - 2; i++)
            {
                Sum += SendBuffHex[i];
            }

            Sum = Sum % 256;
            SendBuffHex[BUFF_HEX_SIZE - 1] = (byte)Sum;
        }

        public static void DisplaySendData() {
            string SendStr = "";
            int i;
            for (i = 0; i <= BUFF_HEX_SIZE - 1; i++)
            {
                SendStr = SendStr + MyDecToHex(SendBuffHex[i]) + " ";
            }
    }
    }

    public enum enAlermStatus
    {
        None,

        Success,

        Fail
    }

}
