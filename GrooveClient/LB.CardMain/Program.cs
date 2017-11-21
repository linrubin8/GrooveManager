using LB.Common;
using LB.Common.Enum;
using LB.Page.Helper;
using LB.WinFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LB.CardMain
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
            try
            {
                MainHelper.SetArgsValue(args);

                //args = new string[3];
                //args[0] = "ActionType=0";
                //args[1] = "Url=http://localhost:3060/LRB";
                //args[2] = "CardID=0";

                string strActionType = MainHelper.GetValue("ActionType");
                int iActionType = LBConverter.ToInt32(strActionType);
                enActionType actionType = (enActionType)iActionType;

                RemotingObject.DefaultIPAddress = MainHelper.GetValue("Url");
                if (actionType == enActionType.CardEdit)
                {
                    long lCardID = LBConverter.ToInt64(MainHelper.GetValue("CardID"));
                    Application.Run(new frmCardEdit(lCardID));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Application.Run(new MainForm());
        }

        
    }
}
