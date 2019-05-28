﻿using LB.WinFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB.Common
{
    public class LBSerialHelper
    {
        private static Timer mTimer = null;
        private static Timer mTimerSteady = null;//定时器判断是否稳定
        private static SerialPort _comm;
        private static bool Listening;
        private static string _SerialName = "";
        private static int _DeviceBoTeLv = 0;
        private static int _DeviceZhenChuLiFangShi = 0;
        private static int _DeviceShuJuWei = 0;
        private static int _DeviceZhenQiShiBiaoShi = 0;


        public static int WeightValue = 0;
        //public static bool IsSteady = true;
        public static bool IsUnConnected = true;
        private static int WeightCount = 0;//稳定值次数
        //private static int PreWeightValue = 0;//上次重量值
        private static DateTime mPreReceiveDataTime = DateTime.Now;//记录上一次接收地磅数据的时间
        private static StringBuilder mReceiveData = new StringBuilder();
        private static int mTimeOutInterval = 0;//地磅断开连接持续时间
        private static List<int> mLstWeightValue = new List<int>();
        public static int WeightSteadyCount = 3;//校验稳定次数
        private static bool IsDisConnected = false;//是否断开连接

        public static void StartSerial()
        {
            if (mTimer != null && mTimer.Enabled)
            {
                mTimer.Enabled = false;
            }
            mTimer = new Timer();
            mTimer.Interval = 2000;
            mTimer.Tick += MTimer_Tick;
            mTimer.Enabled = true;

            mTimerSteady = new Timer();
            mTimerSteady.Interval = 200;
            mTimerSteady.Tick += MTimerSteady_Tick;
            mTimerSteady.Enabled = true;

            string strConfig = Path.Combine(Application.StartupPath, "LBConfig.ini");
            IniClass iniClass = new IniClass(strConfig);
            string strSteadyCount = iniClass.ReadValue("Config", "WeightSteadyCount");
            int.TryParse(strSteadyCount, out WeightSteadyCount);
            if (WeightSteadyCount <= 0)
            {
                WeightSteadyCount = 3;
            }

            InitSerialPort();

            //CreateAutoWeightValue();//临时，模拟称重使用
        }

        private static void MTimerSteady_Tick(object sender, EventArgs e)
        {
            try
            {
                InsertWeightValue(WeightValue);

                //int lastWeight = WeightValue;
                //InsertWeightValue(lastWeight);

                //if (IsUnConnected)
                //{
                //    IsSteady = false;
                //    return;
                //}
                ////判断最近记录的重量值是否一样
                //int isteadyCount = 0;
                //bool bolIsSteady = false;
                //if (mLstWeightValue.Count > WeightSteadyCount)
                //{
                //    for (int i = mLstWeightValue.Count-WeightSteadyCount; i < mLstWeightValue.Count; i++)
                //    {
                //        int currentWeight = mLstWeightValue[i];
                //        if (currentWeight == lastWeight)
                //        {
                //            isteadyCount++;
                //            if (WeightSteadyCount == isteadyCount)
                //            {
                //                bolIsSteady = true;

                //                break;
                //            }
                //        }
                //        else
                //        {
                //            isteadyCount = 0;
                //        }
                //    }
                //}

                //IsSteady = bolIsSteady;
                ////只保留最新的数据
                //while (mLstWeightValue.Count > WeightSteadyCount)
                //{
                //    mLstWeightValue.RemoveRange(0, mLstWeightValue.Count - WeightSteadyCount);
                //}
            }
            catch (Exception ex)
            {
            }
        }


        public static void ClearWeightListValue()
        {
            mLstWeightValue.Clear();
        }


        private static void InsertWeightValue(int iWeight)
        {
            if (mLstWeightValue.Count == 100)
            {
                mLstWeightValue.RemoveAt(0);
            }
            mLstWeightValue.Add(iWeight);
        }

        /// <summary>
        /// 获取当前地磅的稳定状态
        /// </summary>
        /// <returns></returns>
        public static enWeightChangeType WeightStatus
        {
            get
            {
                enWeightChangeType status = enWeightChangeType.UnStable;
                if (mLstWeightValue.Count >= 10)
                {
                    int[] weightArray = mLstWeightValue.ToArray();

                    int iWeightSteadyCount = WeightSteadyCount;
                    int LastWeight = mLstWeightValue[mLstWeightValue.Count - 1];
                    while (iWeightSteadyCount > 0)
                    {
                        int CurrentWeight = mLstWeightValue[mLstWeightValue.Count - iWeightSteadyCount];
                        if(LastWeight != CurrentWeight)
                        {
                            break;
                        }
                        iWeightSteadyCount--;
                    }

                    if (iWeightSteadyCount == 0)
                    {
                        status = enWeightChangeType.WeightStable;//稳定
                    }
                    
                    if(status == enWeightChangeType.UnStable)//不稳定，则判断地磅数值在递减还是在递增，取第一个、中间值和最后一个值作比较
                    {
                        int firstWeight = weightArray[0];
                        int midWeight = weightArray[weightArray.Length / 2-1];
                        int lastWeight = weightArray[weightArray.Length - 1];

                        if(midWeight> firstWeight&& lastWeight > midWeight)
                        {
                            status = enWeightChangeType.WeightRise;
                        }
                        else if (midWeight < firstWeight && lastWeight < midWeight)
                        {
                            status = enWeightChangeType.WeightReduce;
                        }
                    }
                }
                return status;
            }
        }

        private static void MTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string strReceiveData = mReceiveData.ToString();
                mReceiveData.Clear();
                if (!string.IsNullOrEmpty(strReceiveData))
                {
                    WriteRecevieLog(strReceiveData);
                }
                
                //如果超过两秒都未接收到数据，说明地磅已断电
                if (DateTime.Now.Subtract(mPreReceiveDataTime).TotalSeconds > 2)
                {
                    WeightValue = 0;
                    mLstWeightValue.Clear();
                    IsUnConnected = true;
                }

                if (_comm!=null && _comm.IsOpen)
                {
                    mTimeOutInterval += mTimer.Interval;

                    if (mTimeOutInterval > 10000)
                    {
                        IsUnConnected = true;
                        //如果地磅10s后还没有反应，则重新打开串口
                        InitSerialPort();
                        mTimeOutInterval = 0;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void InitSerialPort()
        {
            if (_comm != null && _comm.IsOpen)
            {
                LBErrorLog.InsertFileLog("准备重新开启COM口:DiscardInBuffer");
                _comm.DiscardInBuffer();
                LBErrorLog.InsertFileLog("准备重新开启COM口:Dispose");
                _comm.Dispose();
                LBErrorLog.InsertFileLog("准备重新开启COM口:Close");
                _comm.Close();
                LBErrorLog.InsertFileLog("准备重新开启COM口:Close结束");
            }
            _comm = new SerialPort();
            _comm.DataReceived += _comm_DataReceived;

            if (!_comm.IsOpen)
            {
                GetSerialInfo(out _SerialName, out _DeviceBoTeLv, out _DeviceZhenChuLiFangShi, out _DeviceShuJuWei, out _DeviceZhenQiShiBiaoShi);

                if (_SerialName != "")
                {
                    //lstBytes = new List<byte[]>();
                    //关闭时点击，则设置好端口，波特率后打开
                    _comm.PortName = _SerialName;
                    _comm.BaudRate = _DeviceBoTeLv;

                    try
                    {
                        LBErrorLog.InsertFileLog("开启COM口:Dispose");
                        _comm.Dispose();
                        LBErrorLog.InsertFileLog("开启COM口:Close");
                        _comm.Close();
                        LBErrorLog.InsertFileLog("开启COM口:Open");
                        _comm.Open();
                        LBErrorLog.InsertFileLog("开启COM口:Open结束");
                    }
                    catch (Exception ex)
                    {
                        LBErrorLog.InsertFileLog("OpenPort错误：" + ex.Message);
                        //捕获到异常信息，创建一个新的comm对象，之前的不能用了。
                        //InitSerialPort();
                    }
                }
            }
        }

        //旧逻辑
        //private static void _comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    try
        //    {
        //        //Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。

        //        if (!_comm.IsOpen)
        //            return;
        //        int n = _comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
        //        byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据
        //        received_count += n;//增加接收计数
        //        _comm.Read(buf, 0, n);//读取缓冲数据

        //        lstBytes.Add(buf);
        //        //SetData(buf);

        //        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //        //<协议解析>
        //        bool data_1_catched = false;//缓存记录数据是否捕获到
        //        //1.缓存数据
        //        buffer.AddRange(buf);
        //        //2.完整性判断
        //        while (buffer.Count >= 2)//至少要包含头（2字节）+长度（1字节）+校验（1字节）
        //        {
        //            //请不要担心使用>=，因为>=已经和>,<,=一样，是独立操作符，并不是解析成>和=2个符号
        //            //2.1 查找数据头
        //            if (buffer[0] == 43)
        //            {
        //                if (buffer.Count >= 10)
        //                {
        //                    //2.2 探测缓存数据是否有一条数据的字节，如果不够，就不用费劲的做其他验证了
        //                    //前面已经限定了剩余长度>=4，那我们这里一定能访问到buffer[2]这个长度
        //                    int len = 8;//数据长度
        //                                //数据完整判断第一步，长度是否足够
        //                                //len是数据段长度,4个字节是while行注释的3部分长度
        //                    if (buffer.Count < len + 2) break;//数据不够的时候什么都不做
        //                                                      //这里确保数据长度足够，数据头标志找到，我们开始计算校验
        //                                                      //2.3 校验数据，确认数据正确
        //                                                      //异或校验，逐个字节异或得到校验码
        //                                                      /*byte checksum = 0;
        //                                                      for (int i = 0; i < len + 3; i++)//len+3表示校验之前的位置
        //                                                      {
        //                                                          checksum ^= buffer[i];
        //                                                      }
        //                                                      if (checksum != buffer[len + 3]) //如果数据校验失败，丢弃这一包数据
        //                                                      {
        //                                                          buffer.RemoveRange(0, len + 4);//从缓存中删除错误数据
        //                                                          continue;//继续下一次循环
        //                                                      }*/
        //                                                      //至此，已经被找到了一条完整数据。我们将数据直接分析，或是缓存起来一起分析
        //                                                      //我们这里采用的办法是缓存一次，好处就是如果你某种原因，数据堆积在缓存buffer中
        //                                                      //已经很多了，那你需要循环的找到最后一组，只分析最新数据，过往数据你已经处理不及时
        //                                                      //了，就不要浪费更多时间了，这也是考虑到系统负载能够降低。
        //                    buffer.CopyTo(0, binary_data_1, 0, len + 2);//复制一条完整数据到具体的数据缓存
        //                    data_1_catched = true;
        //                    buffer.RemoveRange(0, len + 2);//正确分析一条数据，从缓存中移除数据。

        //                    //分析数据
        //                    if (data_1_catched)
        //                    {
        //                        //我们的数据都是定好格式的，所以当我们找到分析出的数据1，就知道固定位置一定是这些数据，我们只要显示就可以了
        //                        string data = binary_data_1[1].ToString("X2") + binary_data_1[2].ToString("X2") + binary_data_1[3].ToString("X2") + binary_data_1[4].ToString("X2") +
        //                            binary_data_1[5].ToString("X2") + binary_data_1[6].ToString("X2") +
        //                            binary_data_1[7].ToString("X2") + binary_data_1[8].ToString("X2");
        //                        string m = HexToString(data, System.Text.Encoding.GetEncoding("gbk"));


        //                        //更新界面
        //                        string strValue = m.Substring(0, 6);
        //                        int.TryParse(strValue, out WeightValue);
        //                        buffer.Clear();
        //                        //this.Invoke((EventHandler)(delegate { this.lblWeight.Text = Convert.ToInt32(strValue).ToString(); }));
        //                    }
        //                }
        //                break;
        //            }
        //            else if(buffer[0] != 43)
        //            {
        //                //这里是很重要的，如果数据开始不是头，则删除数据
        //                buffer.RemoveAt(0);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
        //    }
        //}

        private static void _comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            IsUnConnected = false;
            mTimeOutInterval = 0;
            //if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环  
            try
            {
                Listening = true;
                int n = _comm.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
                byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据  
                //received_count += n;//增加接收计数  
                _comm.Read(buf, 0, n);//读取缓冲数据  

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////// 

                mReceiveData.AppendLine();
                foreach (byte b in buf)
                {
                    mReceiveData.Append(" " + b.ToString());
                }
                //解析>
                bool data_1_catched = false;//缓存记录数据是否捕获到  
                //缓存数据  
                buffer.AddRange(buf);
                //完整性判断
                int whileCount = 0;
                while (buffer.Count >= 12)
                {
                    whileCount++;
                    if (whileCount == 1000)
                    {
                        break;
                    }
                    if (buffer[0].ToString("X2") == "02" && buffer[11].ToString("X2") == "03")
                    {
                        //异或校验，逐个字节异或得到校验码  
                        byte checksum = 0;
                        for (int i = 1; i < 9; i++)
                        {
                            checksum ^= buffer[i];
                        }
                        //String ch = ((checksum >> 4) & 0x0F).ToString("X");  //高；
                        //String  cl = (checksum & 0x0F).ToString("X");  //低；
                        String verify = checksum.ToString("X2");
                        String verify1 = Encoding.ASCII.GetString(new byte[] { buffer[9], buffer[10] });
                        if (verify != verify1)
                        {
                            buffer.RemoveRange(0, 12);
                            continue;
                        }

                        buffer.CopyTo(0, binary_data_1, 0, 12);//复制一条完整数据到具体的数据缓存  
                        data_1_catched = true;
                        buffer.RemoveRange(0, 12);//正确分析一条数据，从缓存中移除数据。  
                    }
                    else
                    {
                        //这里是很重要的，如果数据开始不是头，则删除数据  
                        buffer.RemoveAt(0);
                    }
                }

                if (whileCount == 1000)
                {
                    LBErrorLog.InsertFileLog("_comm_DataReceived：循环次数太大");
                }

                //分析数据  
                if (data_1_catched)
                {
                    string data = (Convert.ToInt32(binary_data_1[2].ToString("X2")) - 30) + ""
                        + (Convert.ToInt32(binary_data_1[3].ToString("X2")) - 30) + ""
                        + (Convert.ToInt32(binary_data_1[4].ToString("X2")) - 30) + ""
                        + (Convert.ToInt32(binary_data_1[5].ToString("X2")) - 30) + ""
                        + (Convert.ToInt32(binary_data_1[6].ToString("X2")) - 30) + ""
                        + (Convert.ToInt32(binary_data_1[7].ToString("X2")) - 30) + "";

                    mReceiveData.AppendLine();
                    mReceiveData.AppendLine("-" + data + "-");
                    string strData = "";
                    int.TryParse(data, out WeightValue);
                    //if (WeightValue == PreWeightValue)
                    //{
                    //    WeightCount++;
                    //}
                    //else
                    //{
                    //    WeightCount = 0;
                    //    PreWeightValue = WeightValue;
                    //}

                    //if (WeightCount > 5)
                    //{
                    //    IsSteady = true;
                    //}
                    //else
                    //{
                    //    IsSteady = false;
                    //}
                }
            }
            catch(Exception ex)
            {
                LBErrorLog.InsertFileLog("DataReceived错误："+ex.Message);
            }
            finally
            {
                Listening = false;//我用完了，ui可以关闭串口了。 
                mPreReceiveDataTime = DateTime.Now;
            }
        }

        private static StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        private static List<byte> buffer = new List<byte>(4096);//默认分配1页内存，并始终限制不允许超过
        private static byte[] binary_data_1 = new byte[12];//AA 44 05 01 02 03 04 05 EA
        static string appPath = "";
        static int received_count = 0;
        static List<byte[]> lstBytes = new List<byte[]>();

        public static string HexToString(string HexStr, Encoding encode)
        {
            byte[] oribyte = new byte[HexStr.Length / 2];
            for (int i = 0; i < HexStr.Length; i += 2)
            {
                string str = Convert.ToInt32(HexStr.Substring(i, 2), 16).ToString().ToUpper();
                oribyte[i / 2] = Convert.ToByte(HexStr.Substring(i, 2), 16);
            }
            return encode.GetString(oribyte);//得到最
        }

        public static void CloseSerial()
        {
            if (_comm != null)
            {
                if (_comm.IsOpen)
                {
                    _comm.Close();
                    _comm.Dispose();
                }
            }
        }

        private static void GetSerialInfo(
            out string strSerialName,
            out int DeviceBoTeLv,
            out int DeviceZhenChuLiFangShi,
            out int DeviceShuJuWei,
            out int DeviceZhenQiShiBiaoShi)
        {
            strSerialName = "";
            DeviceBoTeLv = 0;
            DeviceZhenChuLiFangShi = 0;
            DeviceShuJuWei = 0;
            DeviceZhenQiShiBiaoShi = 0;

            string strMathineName = LoginInfo.MachineName;
            DataTable dtSerial = ExecuteSQL.CallView(120, "", "MachineName='" + strMathineName + "'", "");
            if (dtSerial.Rows.Count > 0)
            {
                DataRow dr = dtSerial.Rows[0];
                long lWeightDeviceUserTypeID = LBConverter.ToInt64(dr["WeightDeviceUserTypeID"]);
                strSerialName = dr["SerialName"].ToString();
                int iWeightDeviceType = LBConverter.ToInt32(dr["WeightDeviceType"]);

                if (iWeightDeviceType == 0)//自定义
                {
                    if (lWeightDeviceUserTypeID > 0)
                    {
                        DataTable dtUserConfig = ExecuteSQL.CallView(119, "", "WeightDeviceUserTypeID=" + lWeightDeviceUserTypeID, "");

                        if (dtUserConfig.Rows.Count > 0)
                        {
                            DataRow drUserConfig = dtUserConfig.Rows[0];
                            DeviceBoTeLv = LBConverter.ToInt32(drUserConfig["DeviceBoTeLv"]);
                            DeviceShuJuWei = LBConverter.ToInt32(drUserConfig["DeviceShuJuWei"]);
                            DeviceZhenChuLiFangShi = LBConverter.ToInt32(drUserConfig["DeviceZhenChuLiFangShi"]);
                            DeviceZhenQiShiBiaoShi = LBConverter.ToInt32(drUserConfig["DeviceZhenQiShiBiaoShi"]);
                        }
                    }
                }
                else
                {
                    DataTable dtSysSerial = ExecuteSQL.CallView(118, "", "WeightDeviceType=" + iWeightDeviceType, "");
                    if (dtSysSerial.Rows.Count > 0)
                    {
                        DataRow drSerial = dtSysSerial.Rows[0];
                        DeviceBoTeLv = LBConverter.ToInt32(drSerial["DeviceBoTeLv"]);
                        DeviceShuJuWei = LBConverter.ToInt32(drSerial["DeviceShuJuWei"]);
                        DeviceZhenChuLiFangShi = LBConverter.ToInt32(drSerial["DeviceZhenChuLiFangShi"]);
                        DeviceZhenQiShiBiaoShi = LBConverter.ToInt32(drSerial["DeviceZhenQiShiBiaoShi"]);
                    }
                }
            }
            //strSerialName = "COM10";
        }

        private static void WriteRecevieLog(string strMsg)
        {
            string filePath = Path.Combine(Application.StartupPath, "ReceiveDataLog.txt");

            if (File.Exists(filePath))
            {
                FileInfo fi = new FileInfo(filePath);
                if (fi.Length > 2 * 1024 * 1024)
                {
                    string filePathTemp = Path.Combine(Application.StartupPath, "ReceiveDataLog");
                    if (!Directory.Exists(filePathTemp))
                    {
                        Directory.CreateDirectory(filePathTemp);
                    }
                    string strFileTemp = Path.Combine(filePathTemp, DateTime.Now.ToString("MMdd HHmmss") + ".txt");
                    File.Move(filePath, strFileTemp);
                }
            }

            try
            {
                File.AppendAllText(filePath,"T"+ DateTime.Now.ToString("yy-MM-dd HH:mm:ss") + "\r\n" + strMsg + "\r\n");
            }
            catch(Exception ex)
            {

            }
            //FileStream fs = null;
            ////将待写的入数据从字符串转换为字节数组  
            //Encoding encoder = Encoding.UTF8;
            //byte[] bytes = encoder.GetBytes(DateTime.Now.ToString("MMdd HHmmss") + "\r\n" + strMsg + "\r\n");
            //try
            //{
            //    fs = File.OpenWrite(filePath);
            //    //设定书写的开始位置为文件的末尾  
            //    fs.Position = fs.Length;
            //    //将待写入内容追加到文件末尾  
            //    fs.Write(bytes, 0, bytes.Length);
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine("文件打开失败{0}", ex.ToString());
            //}
            //finally
            //{
            //    fs.Close();
            //}
        }

        private static Timer mTimerTemp = null;
        static List<int>  mlstTempWeight = new List<int>();
        private static void CreateAutoWeightValue()
        {
            for (int m = 0; m < 100; m++)
            {
                for (int i = 0; i <= 50; i++)
                {
                    mlstTempWeight.Add(i * 600);
                }

                for (int i = 0; i <= 40; i++)
                {
                    mlstTempWeight.Add(50 * 600);
                }

                for (int i = 50; i >= 0; i--)
                {
                    mlstTempWeight.Add(i * 600);
                }

                for (int i = 0; i <= 50; i++)
                {
                    mlstTempWeight.Add(0);
                }
            }
            mTimerTemp = new Timer();
            mTimerTemp.Interval = 200;
            mTimerTemp.Tick += MTimerTemp_Tick;
            mTimerTemp.Enabled = true;
        }

        private static void MTimerTemp_Tick(object sender, EventArgs e)
        {
            if (mlstTempWeight.Count > 0)
            {
                WeightValue = mlstTempWeight[0];
                mlstTempWeight.RemoveAt(0);
            }
            mPreReceiveDataTime = DateTime.Now;
        }
    }

    public enum enWeightDeviceStatus
    {
        Zero,

        InWeight
    }
}
