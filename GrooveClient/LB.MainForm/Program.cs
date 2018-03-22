using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LB.WinFunction;
using System.IO;
using System.Diagnostics;

namespace LB.MainForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //先开启服务

            bool bolExists = false;
            Process[] processAry = Process.GetProcesses();
            foreach(Process peo in processAry)
            {
                if (peo.ProcessName.Contains("LB.Web.ServerTool"))
                {
                    bolExists = true;
                    break;
                }
            }
            if (!bolExists)
            {
                DirectoryInfo directInfo = new DirectoryInfo(Application.StartupPath);
                if (directInfo.Parent != null)
                {
                    string strServerPath = directInfo.Parent.FullName;
                    string strServerName = Path.Combine(strServerPath, "LB.Web.ServerTool.exe");
                    if (File.Exists(strServerName))
                    {
                        Process.Start(strServerName);
                    }
                }
            }

            while (true)
            {
                using (LB.Login.frmLogin login = new Login.frmLogin())
                {
                    Application.Run(login);
                    if (LoginInfo.IsVerifySuccess)
                    {
                        if (login.ProductType == 1)
                        {
                            using (WeightForm2 mainForm = new WeightForm2())
                            {
                                Application.Run(mainForm);
                                if (!mainForm.bolIsCancel)
                                {
                                    break;
                                }
                            }
                        }
                        else if (login.ProductType == 2)
                        {
                            using (WeightFormCalcalute mainForm = new WeightFormCalcalute())
                            {
                                Application.Run(mainForm);
                                if (!mainForm.bolIsCancel)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

    }
}
