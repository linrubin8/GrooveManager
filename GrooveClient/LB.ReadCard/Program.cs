using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LB.ReadCard
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string strIP = "";
            string strPort = "";
            string strRate = "";
            string strKey = "";
            if (args.Length > 0)
            {
                string strParms = args[0];
                string[] strSplits = strParms.Split('&');
                foreach (string str in strSplits)
                {
                    if (str.Contains("IP"))
                    {
                        strIP = str.Substring(3, str.Length - 3);
                    }
                    if (str.Contains("Port"))
                    {
                        strPort = str.Substring(5, str.Length - 5);
                    }
                    if (str.Contains("Rate"))
                    {
                        strRate = str.Substring(5, str.Length - 5);
                    }
                    if (str.Contains("Key"))
                    {
                        strKey = str.Substring(4, str.Length - 4);
                    }
                }
            }
            Application.Run(new Form1(strKey, strIP, strPort, strRate));
        }
    }
}
