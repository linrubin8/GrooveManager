using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Web.DB.DAL
{
    public class DALDbErrorLog
    {
        public void Insert(FactoryArgs args, t_String ErrorLogMsg, t_ID LogType)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ErrorLogMsg", ErrorLogMsg));
            parms.Add(new LBDbParameter("CreateBy",new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("CreateTime", new t_DTSmall(DateTime.Now)));
            parms.Add(new LBDbParameter("LogType", LogType));
            string strSQL = @"
insert into dbo.SbErrorLog(ErrorLogMsg,CreateBy,CreateTime,LogType)
values(@ErrorLogMsg,@CreateBy,datetime('now','localtime'),@LogType)
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }
    }
}
