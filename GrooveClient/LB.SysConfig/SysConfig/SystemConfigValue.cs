using LB.WinFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LB.SysConfig.SysConfig
{
    public class SystemConfigValue
    {
        public static int SysReadCardLimit = 0;//刷卡有效时间间隔(分钟)

        public static void ReadAllConfigValue()
        {
            DataTable dtConfigValue = ExecuteSQL.CallView(129, "", "", "");
            foreach (DataRow dr in dtConfigValue.Rows)
            {
                string strSysConfigFieldName = dr["SysConfigFieldName"].ToString().TrimEnd();
                int iSysConfigDataType = Convert.ToInt16(dr["SysConfigDataType"]);
                string strSysConfigDefaultValue = dr["SysConfigDefaultValue"].ToString().TrimEnd();
                string strSysConfigValue = dr["SysConfigValue"].ToString().TrimEnd();

                string strConfigValue = strSysConfigValue == "" ? strSysConfigDefaultValue : strSysConfigValue;
                int iValue;
                switch (strSysConfigFieldName)
                {
                    case "SysReadCardLimit"://刷卡有效时间间隔(分钟)
                        int.TryParse(strConfigValue, out iValue);
                        SysReadCardLimit = iValue;
                        break;
                }
            }
        }
    }
}
