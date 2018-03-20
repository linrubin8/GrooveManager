
using LB.WinFunction;
using ReaderB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LB.Common
{
    public class LBCardHelper
    {
        private static byte fComAdr = Convert.ToByte("FF", 16); // $FF;
        static int frmcomportindex;//串口号：当串口为COM1时值为1
        private static byte fBaud;//波特率
        public static bool COMIsOpen = false;//是否已开启
        private static byte powerDbm = 1;//功率
        public static bool IsUseReadCard = false;//是否启用读卡器或者写卡器
        public static bool ReadCardIsReady = false;//是否正在读卡（打卡）
        
        private static System.Windows.Forms.Timer mTimer = null;
        private static System.Windows.Forms.Timer mTimerVerify = null;
        private static List<string> mLstCard = new List<string>();
        private static int _PreReadCardLinesCount = 0;

        private static string _Com="";
        private static string _NetIPAddress = "";
        private static int _NetPort = 0;
        private static bool _IsUseNet = false;

        private static Thread mThread = null;
        //public static List<CardInfo> LstCardCode = new List<CardInfo>();
        public static string CardCode = "";
        public static bool BeginReadCard = false;

        public static string COM
        {
            get
            {
                return _Com;
            }
        }

        public static string NetIPAddress
        {
            get
            {
                return _NetIPAddress;
            }
            set
            {
                _NetIPAddress = value;
            }
        }

        public static int NetPort
        {
            get
            {
                return _NetPort;
            }
            set
            {
                _NetPort = value;
            }
        }

        public static bool IsUseNet
        {
            get
            {
                return _IsUseNet;
            }
            set
            {
                _IsUseNet = value;
            }
        }

        public static void CloseThread()
        {
            if(mThread!=null && mThread.IsAlive)
            {
                mThread.Abort();
            }
        }

        public static void StartSerial(enCardType cardType)
        {
            //bool bolIsUse = false;//是否启用读卡器或者写卡器
            try
            {
                DataTable dtDesc = ExecuteSQL.CallView(140, "", "MachineName='" + LoginInfo.MachineName + "'", "");
                if (dtDesc.Rows.Count > 0)
                {
                    if (cardType == enCardType.ReadCard)
                    {
                        _Com = dtDesc.Rows[0]["ReadCardSerialCOM"].ToString().TrimEnd();
                        IsUseReadCard = LBConverter.ToBoolean(dtDesc.Rows[0]["UseReadCard"]);
                        _IsUseNet = LBConverter.ToInt32(dtDesc.Rows[0]["ConnectType"].ToString().TrimEnd()) == 1 ? true : false;
                        _NetIPAddress = dtDesc.Rows[0]["IPAddress"].ToString().TrimEnd();
                        _NetPort = LBConverter.ToInt32(dtDesc.Rows[0]["IPPort"].ToString().TrimEnd());
                    }
                    else
                    {
                        _Com = dtDesc.Rows[0]["WriteCardSerialCOM"].ToString().TrimEnd();
                        IsUseReadCard = LBConverter.ToBoolean(dtDesc.Rows[0]["UseWriteCard"]);
                    }
                    powerDbm = LBConverter.ToByte(dtDesc.Rows[0]["ReadCardBaud"]);
                }

                //if (mTimer == null)
                //{
                //    mTimer = new System.Windows.Forms.Timer();
                //    mTimer.Interval = 500;
                //    mTimer.Tick += MTimer_Tick;
                //    mTimer.Enabled = true;
                //}

                if (mTimerVerify == null)
                {
                    mTimerVerify = new System.Windows.Forms.Timer();
                    mTimerVerify.Interval = 2000;
                    mTimerVerify.Tick += mTimerVerify_Tick;
                    mTimerVerify.Enabled = true;
                }
            }
            catch(Exception ex)
            {

            }

            try
            {
                if (COMIsOpen)
                {
                    ClosePort();
                }
                if (IsUseReadCard && !COMIsOpen)
                {
                    COMIsOpen = OpenPort();
                }

                //if (IsUseReadCard)
                //{
                //    if (mThread == null)
                //    {
                //        mThread = new Thread(ReadCardAction);
                //        mThread.Start();
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
        }

        //private static void MTimer_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

            
        private static void mTimerVerify_Tick(object sender, EventArgs e)
        {
            try
            {
                lock (mLstCard)
                {
                    if (_PreReadCardLinesCount>0 && _PreReadCardLinesCount != mLstCard.Count)
                    {
                        ReadCardIsReady = true;
                    }
                    else
                    {
                        ReadCardIsReady = false;
                    }

                    _PreReadCardLinesCount = mLstCard.Count;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //private static void ReadCardAction()
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            string strCode = ReadCardCode();
        //            if (strCode != "")
        //            {
        //                CardCode = strCode;
        //                //CardInfo cardInfo = new CardInfo(strCode, "", true);
        //                //lock (LBCardHelper.LstCardCode)
        //                //    LstCardCode.Add(cardInfo);
        //            }
        //            Thread.Sleep(500);
        //        }
        //        catch(Exception ex)
        //        {
        //            LBErrorLog.InsertFileLog("ReadCardAction:" + ex.Message);
        //        }
        //    }
        //}

        public static string ReadCardDirect()
        {
            string strCode = "";
            try
            {
                if (IsUseReadCard)
                {
                    strCode = ReadCardCode();
                }
            }
            catch (Exception ex)
            {
                LBErrorLog.InsertFileLog("ReadCardAction:" + ex.Message);
            }
            return strCode;
        }
        
        private static bool OpenPort()
        {
            bool ComOpen = false;
            int port = 0;
            int openresult, i;
            openresult = 30;
            if (!_IsUseNet)
                port = Convert.ToInt32(_Com.Substring(3, _Com.Length - 3));
            int fOpenComIndex = 0;
            for (i = 6; i >= 0; i--)
            {
                fBaud = Convert.ToByte(i);
                if (fBaud == 3)
                    continue;

                if (!_IsUseNet)
                {
                    openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                }
                else
                {
                    openresult = StaticClassReaderB.OpenNetPort(_NetPort, _NetIPAddress, ref fComAdr, ref frmcomportindex);
                }
                
                fOpenComIndex = frmcomportindex;
                if (openresult == 0x35)
                {
                    throw new Exception("串口已打开");
                }
                if (openresult == 0)
                {
                    ComOpen = true;

                    byte[] TrType = new byte[2];
                    byte[] VersionInfo = new byte[2];
                    byte ReaderType = 0;
                    byte ScanTime = 0;
                    byte dmaxfre = 0;
                    byte dminfre = 0;
                    byte powerdBm = 0;
                    int fCmdRet = StaticClassReaderB.GetReaderInformation(ref fComAdr, VersionInfo, ref ReaderType, TrType, ref dmaxfre, ref dminfre, ref powerdBm, ref ScanTime, frmcomportindex);

                    if ((fCmdRet == 0x35) || (fCmdRet == 0x30))
                    {
                        ComOpen = false;
                        StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                        throw new Exception("串口通讯错误");
                    }

                    fCmdRet = StaticClassReaderB.SetPowerDbm(ref fComAdr, powerDbm, frmcomportindex);//设置功率
                    break;
                }
            }
            
            if ((fOpenComIndex == -1) && (openresult == 0x30))
                throw new Exception("串口通讯错误");
            return ComOpen;
        }

        public static void ClosePort()
        {
            try
            {
                if (frmcomportindex > 0)
                {
                    if(_IsUseNet)
                        StaticClassReaderB.CloseNetPort(frmcomportindex);
                    else
                        StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                    
                    COMIsOpen = false;
                }
            }
            finally
            {

            }
        }
        
        public static string ReadCardCode()
        {
            if (!IsUseReadCard)
                return "";

            string bolCardCode="";
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            bool fIsInventoryScan = true;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            int fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                //fInventory_EPC_List = temps;            //存贮记录
                m = 0;

                if (CardNum == 0)
                {
                    string strMsg = GetReturnCodeDesc(fCmdRet);
                    //LBErrorLog.InsertFileLog("卡号为空："+ strMsg);
                    fIsInventoryScan = false;
                    return "";
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)
                {
                    EPClen = daw[m];
                    if (temps.Length >= m * 2 + 2 + EPClen * 2)
                    {
                        bolCardCode = temps.Substring(m * 2 + 2, EPClen * 2);
                    }
                    else
                    {
                        bolCardCode = "";
                        LBErrorLog.InsertFileLog("解析卡号Substring异常");
                        break;
                    }
                }

                if (bolCardCode != "")
                {
                    lock (mLstCard)
                    {
                        if (mLstCard.Count < 100)
                        {
                            mLstCard.Add(bolCardCode);
                        }
                        else
                        {
                            mLstCard.Clear();
                        }
                    }
                    LBErrorLog.InsertFileLog("读卡S：" + bolCardCode);
                }
            }
            else
            {
                string strMsg = GetReturnCodeDesc(fCmdRet);
                LBErrorLog.InsertFileLog("读卡F：" + strMsg);
                //LBErrorLog.InsertErrorLog("读卡错误："+strMsg, 0);
                switch (fCmdRet)
                {
                    case 0x30://通讯错误
                    case 0x36://端口已关闭
                    case 0xEE://返回指令错误
                        if (IsUseReadCard )
                        {
                            try
                            {
                                ClosePort();
                                COMIsOpen = OpenPort();

                                LBErrorLog.InsertFileLog("读卡F后重开：" + (COMIsOpen?"成功":"失败"));
                            }
                            catch (Exception ex)
                            {
                                LBErrorLog.InsertFileLog("读卡F后重开报错：" + ex.Message);
                            }
                        }
                        break;
                    default:
                        //CardInfo cardInfo = new CardInfo("", strMsg, false);
                        //lock (LBCardHelper.LstCardCode)
                        //    LstCardCode.Add(cardInfo);
                        break;
                }
            }
            return bolCardCode;
        }

        public static bool WriteCardCode(string strCardCode, out string strMsg)
        {
            if (!IsUseReadCard)
            {
                strMsg = "未启用写卡器";
                return false;
            }

            if (!COMIsOpen)
            {
                COMIsOpen = OpenPort();
                if (!COMIsOpen)
                {
                    throw new Exception("读卡器异常！");
                }
            }

            strMsg = "";
            byte[] WriteEPC = new byte[100];
            byte WriteEPClen;
            byte ENum;

            if ((strCardCode.Length % 4) != 0)
            {
                int left =4- strCardCode.Length % 4;
                if (left == 1)
                    strCardCode += "0";
                if (left == 2)
                    strCardCode += "00";
                if (left == 3)
                    strCardCode += "000";
            }
            WriteEPClen = Convert.ToByte(strCardCode.Length / 2);
            ENum = Convert.ToByte(strCardCode.Length / 4);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(strCardCode);
            byte[] fPassWord = HexStringToByteArray("00000000");
            int ferrorcode=0;
            int fCmdRet = StaticClassReaderB.WriteEPC_G2(ref fComAdr, fPassWord, EPC, WriteEPClen, ref ferrorcode, frmcomportindex);
            if(fCmdRet!= 0x00)
            {
                strMsg = GetReturnCodeDesc(fCmdRet);
                return false;
            }
            return true;
        }

        private static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        private static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        private static string GetReturnCodeDesc(int cmdRet)
        {
            switch (cmdRet)
            {
                case 0x00:
                    return "操作成功";
                case 0x01:
                    return "询查时间结束前返回";
                case 0x02:
                    return "指定的询查时间溢出";
                case 0x03:
                    return "本条消息之后，还有消息";
                case 0x04:
                    return "读写模块存储空间已满";
                case 0x05:
                    return "访问密码错误";
                case 0x09:
                    return "销毁密码错误";
                case 0x0a:
                    return "销毁密码不能为全0";
                case 0x0b:
                    return "电子标签不支持该命令";
                case 0x0c:
                    return "对该命令，访问密码不能为全0";
                case 0x0d:
                    return "电子标签已经被设置了读保护，不能再次设置";
                case 0x0e:
                    return "电子标签没有被设置读保护，不需要解锁";
                case 0x10:
                    return "有字节空间被锁定，写入失败";
                case 0x11:
                    return "不能锁定";
                case 0x12:
                    return "已经锁定，不能再次锁定";
                case 0x13:
                    return "参数保存失败,但设置的值在读写模块断电前有效";
                case 0x14:
                    return "无法调整";
                case 0x15:
                    return "询查时间结束前返回";
                case 0x16:
                    return "指定的询查时间溢出";
                case 0x17:
                    return "本条消息之后，还有消息";
                case 0x18:
                    return "读写模块存储空间已满";
                case 0x19:
                    return "电子不支持该命令或者访问密码不能为0";
                case 0xFA:
                    return "有电子标签，但通信不畅，无法操作";
                case 0xFB:
                    return "无电子标签可操作";
                case 0xFC:
                    return "电子标签返回错误代码";
                case 0xFD:
                    return "命令长度错误";
                case 0xFE:
                    return "不合法的命令";
                case 0xFF:
                    return "参数错误";
                case 0x30:
                    return "通讯错误";
                case 0x31:
                    return "CRC校验错误";
                case 0x32:
                    return "返回数据长度有错误";
                case 0x33:
                    return "通讯繁忙，设备正在执行其他指令";
                case 0x34:
                    return "繁忙，指令正在执行";
                case 0x35:
                    return "端口已打开";
                case 0x36:
                    return "端口已关闭";
                case 0x37:
                    return "无效句柄";
                case 0x38:
                    return "无效端口";
                case 0xEE:
                    return "返回指令错误";
                default:
                    return "";
            }
        }
        private static string GetErrorCodeDesc(int cmdRet)
        {
            switch (cmdRet)
            {
                case 0x00:
                    return "其它错误";
                case 0x03:
                    return "存储器超限或不被支持的PC值";
                case 0x04:
                    return "存储器锁定";
                case 0x0b:
                    return "电源不足";
                case 0x0f:
                    return "非特定错误";
                default:
                    return "";
            }
        }
    }

    public enum enCardType
    {
        WriteCard,

        ReadCard
    }


    public class CardInfo
    {
        public string CardCode { get; set; }
        public string ErrorMsg { get; set; }
        public bool IsSuccess { get; set; }
        public CardInfo(string strCardCode,string strErrorMsg,bool bolIsSuccess)
        {
            CardCode = strCardCode;
            ErrorMsg = strErrorMsg;
            IsSuccess = bolIsSuccess;
        }
    }
}
