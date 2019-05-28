
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB.ReadCard
{
    public partial class Form1 : Form
    {
        string strIP = "";
        string strPort = "";
        string strRate = "";
        string strKey = "";
        int ReadCount = 0;
        Timer timer = null;

        public Form1(string strKey, string strIP, string strPort, string strRate)
        {
            InitializeComponent();
            int port;
            int.TryParse(strPort, out port);
            byte rate;
            byte.TryParse(strRate, out rate);

            this.strKey = strKey;
            LBCardHelper.IsUseNet = true;
            LBCardHelper.NetIPAddress = strIP;
            LBCardHelper.NetPort = port;
            LBCardHelper.Rate = rate;
            LBCardHelper.IsUseReadCard = true;
            LBErrorLog.InsertFileLog("Form1:" + strKey+"_" + strIP + "_" + strPort + "_"+strRate);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = FormWindowState.Minimized;
            LBCardHelper.StartSerial();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string strCard = LBCardHelper.ReadCardCode();

                //string strCard = ReadCardTemp();//测试模拟读卡时用
                ReadCount++;
                if (strCard != "" )
                {
                    this.richTextBox1.AppendText(strCard);
                    this.richTextBox1.AppendText(Environment.NewLine);
                    WriteCardCode(strCard);
                    timer.Enabled = false;
                    this.Close();
                }
                if (ReadCount == 6)//超过6次未读卡成功就自动关闭
                {
                    timer.Enabled = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LBErrorLog.InsertFileLog("LB.ReadCard Timer_Tick:" + ex.Message);
                this.Close();
            }
        }

        private void WriteCardCode(string strCard)
        {
            string strFolder = Path.Combine(Application.StartupPath, "CardReader");
            if (!Directory.Exists(strFolder))
            {
                Directory.CreateDirectory(strFolder);
            }
            string strReaderFile = Path.Combine(strFolder, strKey + ".ini");
            IniClass iniClass = new IniClass(strReaderFile);
            iniClass.WriteValue("Reader", "Card", strCard);
        }

        private string ReadCardTemp()
        {
            string strCardNum = "";
            string strTxt = Path.Combine(Application.StartupPath, "CardMain", "TempCard.txt");
            LBErrorLog.InsertFileLog("LB.ReadCard ReadCardTemp:" + strTxt);
            if (File.Exists(strTxt))
            {
                string[] files = File.ReadAllLines(strTxt);
                if (files.Length > 0)
                {
                    List<string> lstCard = new List<string>();
                    lstCard.AddRange(files);
                    strCardNum = lstCard[0];
                    lstCard.RemoveAt(0);

                    StringBuilder strBuild = new StringBuilder();
                    if (lstCard.Count > 0)
                    {
                        foreach(string str in lstCard)
                        {
                            strBuild.AppendLine(str);
                        }
                    }
                    File.WriteAllText(strTxt, strBuild.ToString());
                }
            }
            return strCardNum;
        }
    }
}
