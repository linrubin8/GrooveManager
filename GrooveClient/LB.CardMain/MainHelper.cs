using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LB.CardMain
{
    public class MainHelper
    {
        static Dictionary<string, string> _ArgsValue = new Dictionary<string, string>();
        public static void SetArgsValue(string[] args)
        {
            string strss = "";
            foreach(string str in args)
            {
                if (str.Contains("="))
                {
                    string strKey = str.Substring(0, str.IndexOf('='));
                    string strValue = str.Substring(str.IndexOf('=') + 1, str.Length - strKey.Length - 1);

                    if (!_ArgsValue.ContainsKey(strKey))
                    {
                        _ArgsValue.Add(strKey, strValue);
                    }
                }
            }
        }

        public static string GetValue(string strKey)
        {
            if (_ArgsValue.ContainsKey(strKey))
            {
                return _ArgsValue[strKey];
            }
            return "";
        }
    }
}
