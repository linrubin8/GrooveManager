using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.DB.DAL
{
    public class DALDbInfraredDeviceConfig
    {
        public void InsertInfraredDeviceConfig(FactoryArgs args,
           t_String MachineName, t_String SerialName, t_ID HeaderXType, t_ID TailXType,
           t_ID SuccessYType, t_ID FailYType, t_Bool IsHeaderEffect, t_Bool IsTailEffect, t_Bool IsAlermEffect)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("MachineName", MachineName));
            parms.Add(new LBDbParameter("SerialName", SerialName));
            parms.Add(new LBDbParameter("HeaderXType", HeaderXType));
            parms.Add(new LBDbParameter("TailXType", TailXType));
            parms.Add(new LBDbParameter("SuccessYType", SuccessYType));
            parms.Add(new LBDbParameter("FailYType", FailYType));
            parms.Add(new LBDbParameter("IsHeaderEffect", IsHeaderEffect));
            parms.Add(new LBDbParameter("IsTailEffect", IsTailEffect));
            parms.Add(new LBDbParameter("IsAlermEffect", IsAlermEffect));

            string strSQL = @"
insert into dbo.DbInfraredDeviceConfig( MachineName,SerialName,
    HeaderXType,TailXType,SuccessYType,FailYType,IsHeaderEffect,IsTailEffect,IsAlermEffect )
values( @MachineName,@SerialName,
    @HeaderXType,@TailXType,@SuccessYType,@FailYType,@IsHeaderEffect,@IsTailEffect,@IsAlermEffect)


";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void UpdateInfraredDeviceConfig(FactoryArgs args,
           t_String MachineName, t_String SerialName, t_ID HeaderXType, t_ID TailXType,
           t_ID SuccessYType, t_ID FailYType, t_Bool IsHeaderEffect, t_Bool IsTailEffect, t_Bool IsAlermEffect)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("MachineName", MachineName));
            parms.Add(new LBDbParameter("SerialName", SerialName));
            parms.Add(new LBDbParameter("HeaderXType", HeaderXType));
            parms.Add(new LBDbParameter("TailXType", TailXType));
            parms.Add(new LBDbParameter("SuccessYType", SuccessYType));
            parms.Add(new LBDbParameter("FailYType", FailYType));
            parms.Add(new LBDbParameter("IsHeaderEffect", IsHeaderEffect));
            parms.Add(new LBDbParameter("IsTailEffect", IsTailEffect));
            parms.Add(new LBDbParameter("IsAlermEffect", IsAlermEffect));

            string strSQL = @"
update dbo.DbInfraredDeviceConfig
set SerialName = @SerialName,
    HeaderXType = @HeaderXType,
    TailXType = @TailXType,
    SuccessYType = @SuccessYType,
    FailYType = @FailYType,
    IsHeaderEffect = @IsHeaderEffect,
    IsTailEffect = @IsTailEffect,
    IsAlermEffect = @IsAlermEffect
where MachineName = @MachineName
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public DataTable GetInfraredConfig(FactoryArgs args, t_String MachineName)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("MachineName", MachineName));

            string strSQL = @"
select *
from dbo.DbInfraredDeviceConfig
where MachineName = @MachineName
";
           return DBHelper.ExecuteQuery(args, strSQL, parms);
        }
        
    }
}
