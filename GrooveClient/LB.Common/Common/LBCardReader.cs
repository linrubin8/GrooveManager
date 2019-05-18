using LB.WinFunction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB.Common
{
    public class LBCardReader
    {
        private static bool IsReading = false;//是否正在读卡（读本地文件）
        private static Timer mTimerSteady = null;
        private static Timer timer = null;
        private static string strReadCardKey = "";
        private static int ReadCount = 0;//已读卡次数
        private static System.Diagnostics.Process process = null;

        public static string ReadProcessCard(string ip,string port,string rate)
        {
            string strCardCode = "";
            try
            {
                if (!IsReading)
                {
                    KillProcess(); 
                    ReadCount = 0;
                    strReadCardKey = DateTime.Now.ToString("yyMMddHHmmss");//生成Key

                    process = new System.Diagnostics.Process();
                    process.StartInfo.Arguments = string.Format(@"IP={0}&Port={1}&Rate={2}&Key={3}", ip, port, rate, strReadCardKey);
                    process.StartInfo.FileName = "LB.ReadCard.exe";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                    process.Start();
                    IsReading = true;
                }
                else
                {
                    strCardCode = ReadCard();
                    if (strCardCode != "" || ReadCount == 10)
                    {
                        DeleteCardFile();
                        strReadCardKey = "";
                        KillProcess();
                        process = null;
                        IsReading = false;
                    }
                    ReadCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return strCardCode;
        }

        private static string ReadCard()
        {
            string strCardCode = "";
            string strFolder = Path.Combine(Application.StartupPath, "CardReader");
            string strReaderFile = Path.Combine(strFolder, strReadCardKey + ".ini");
            if (File.Exists(strReaderFile))
            {
                IniClass iniClass = new IniClass(strReaderFile);
                strCardCode = iniClass.ReadValue("Reader", "Card");
            }
            return strCardCode;
        }

        private static void DeleteCardFile()
        {
            string strFolder = Path.Combine(Application.StartupPath, "CardReader");
            string strReaderFile = Path.Combine(strFolder, strReadCardKey + ".ini");
            if (File.Exists(strReaderFile))
            {
                File.Delete(strReaderFile);
            }
        }

        private static void KillProcess()
        {
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("LB.ReadCard");
            System.Diagnostics.Process[] ps1 = System.Diagnostics.Process.GetProcessesByName("LB.ReadCard.exe");
            List<System.Diagnostics.Process> lstProcess = new List<System.Diagnostics.Process>();
            lstProcess.AddRange(ps);
            lstProcess.AddRange(ps1);
            if (lstProcess.Count > 0)
            {
                foreach (System.Diagnostics.Process p in lstProcess)
                    p.Kill();
            }

        }
    }
}
