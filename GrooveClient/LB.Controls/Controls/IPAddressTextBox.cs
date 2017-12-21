using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;

namespace LB.Controls
{
    public enum IPType : byte { A, B, C, D, E };
    public partial class IPAddressTextBox : UserControl
    {
       

        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region 组件设计器生成的代码

        #endregion

        public IPAddressTextBox()
        {
            InitializeComponent();
        }

        private void IPv4TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char KeyChar = e.KeyChar;
            int TextLength = ((TextBox)sender).TextLength;

            if (KeyChar == '.' || KeyChar == '。' || KeyChar == ' ')
            {
                if ((((TextBox)sender).SelectedText.Length == 0) && (TextLength > 0) && (((TextBox)sender) != textBox4))
                {   // 进入下一个文本框
                    SendKeys.Send("{Tab}");
                }

                e.Handled = true;
            }

            if (Regex.Match(KeyChar.ToString(), "[0-9]").Success)
            {
                if (TextLength == 2)
                {
                    if (int.Parse(((TextBox)sender).Text + e.KeyChar.ToString()) > 255)
                    {
                        e.Handled = true;
                    }
                }
                else if (TextLength == 0)
                {
                    if (KeyChar == '0')
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {   // 回删操作
                if (KeyChar == '\b')
                {
                    if (TextLength == 0)
                    {
                        if (((TextBox)sender) != textBox1)
                        {   // 回退到上一个文本框 Shift+Tab
                            SendKeys.Send("+{TAB}{End}");
                        }
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// string类型的IP地址
        /// </summary>
        override public string Text
        {
            get
            {
                return this.Value.ToString();
            }
            set
            {
                IPAddress address;
                if (IPAddress.TryParse(value, out address))
                {
                    byte[] bytes = address.GetAddressBytes();
                    for (int i = 1; i <= 4; i++)
                    {
                        this.Controls["textBox" + i.ToString()].Text = bytes[i - 1].ToString("D");
                    }
                }
            }
        }

        /// <summary>
        /// IP地址
        /// </summary>
        public IPAddress Value
        {
            get
            {
                IPAddress address;
                string ipString = textBox1.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text;

                if (IPAddress.TryParse(ipString, out address))
                {
                    return address;
                }
                else
                {
                    return new IPAddress(0);
                }
            }
            set
            {
                byte[] bytes = value.GetAddressBytes();
                for (int i = 1; i <= 4; i++)
                {
                    this.Controls["textBox" + i.ToString()].Text = bytes[i - 1].ToString("D");
                }
            }
        }

        /// <summary>
        /// IP地址分类
        /// </summary>
        public IPType Type
        {
            get
            {
                byte[] bytes = this.Value.GetAddressBytes();
                int FirstByte = bytes[0];

                if (FirstByte < 128)
                {
                    return IPType.A;
                }
                else if (FirstByte < 192)
                {
                    return IPType.B;
                }
                else if (FirstByte < 224)
                {
                    return IPType.C;
                }
                else if (FirstByte < 240)
                {
                    return IPType.D;
                }
                else
                {
                    return IPType.E;    // 保留做研究用 
                }
            }
        }

        public bool ValidateIP()
        {
            IPAddress address;
            string ipString = textBox1.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text;

            return IPAddress.TryParse(ipString, out address);
        }

        /// <summary>
        /// 控件的边框样式
        /// </summary>
        //new public BorderStyle BorderStyle
        //{
        //    get
        //    {
        //        return this.textBox1.BorderStyle;
        //    }
        //    set
        //    {
        //        for (int i = 1; i <= 4; i++)
        //        {
        //            ((TextBox)this.Controls["textBox" + i.ToString()]).BorderStyle = value;
        //        }
        //    }
        //}
    }
}
