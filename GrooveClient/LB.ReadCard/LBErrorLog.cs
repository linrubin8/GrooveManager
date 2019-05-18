using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB.ReadCard
{
    public class LBErrorLog
    {
        //public static void InsertErrorLog(string strlog, int iLogType)
        //{
        //    try
        //    {
        //        LBDbParameterCollection parms = new LBDbParameterCollection();
        //        parms.Add(new LBParameter("ErrorLogMsg", enLBDbType.String, strlog));
        //        parms.Add(new LBParameter("LogType", enLBDbType.Int32, iLogType));
        //        DataSet dsReturn;
        //        Dictionary<string, object> dictResult;
        //        ExecuteSQL.CallSP(20000, parms, out dsReturn, out dictResult);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private static int _InsertRowCount = 0;
        private static string _LogFileName = "";
        public static void InsertFileLog(string strMsg)
        {
            //FileStream fs = null;
            string logPath = Path.Combine(Application.StartupPath, "AppLogProcess");
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            if (_LogFileName == "" || _InsertRowCount == 10000)
            {
                _LogFileName = Path.Combine(logPath, "Log" + DateTime.Now.ToString("yyMMddHHmmss") + ".txt");
                _InsertRowCount = 0;
            }

            //将待写的入数据从字符串转换为字节数组  
            //Encoding encoder = Encoding.UTF8;
            //byte[] bytes = encoder.GetBytes(DateTime.Now.ToString("yyMMdd HHmmss")+"---"+ strMsg+"\n");
            try
            {
                File.AppendAllText(_LogFileName, DateTime.Now.ToString("yyMMdd HHmmss") + "---" + strMsg + "\r\n");
                _InsertRowCount++;
                //fs = File.OpenWrite(filePath);
                ////设定书写的开始位置为文件的末尾  
                //fs.Position = fs.Length;
                ////将待写入内容追加到文件末尾  
                //fs.Write(bytes, 0, bytes.Length);

            }
            catch (Exception ex)
            {
                //Console.WriteLine("文件打开失败{0}", ex.ToString());
            }
            finally
            {
                //fs.Close();
            }
        }
    }
}
