using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.SM.DAL
{
    public class DALSalesCarWeightLog
    {
        public void Insert(FactoryArgs args, out t_BigID WeightLogID)
        {
            WeightLogID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("WeightLogID", WeightLogID, true));

            string strSQL = @"
insert into SalesCarWeightLog(  InWeightTime,CarWeightStatus)
values( datetime('now','localtime'),0);

select last_insert_rowid() as WeightLogID;
";
            if (args.DBType == 1)
            {
                strSQL = @"
insert into SalesCarWeightLog(  InWeightTime,CarWeightStatus)
values(getdate(),0)

select @@identity as WeightLogID
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            WeightLogID.Value = Convert.ToInt64(parms["WeightLogID"].Value);
        }

        public void UpdateSteadyTime(FactoryArgs args, t_BigID WeightLogID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("WeightLogID", WeightLogID));

            string strSQL = @"
update SalesCarWeightLog
set SteadyWeightTime = datetime('now','localtime'),
    CarWeightStatus = 1
where WeightLogID = @WeightLogID;
";
            if (args.DBType == 1)
            {
                strSQL = @"
update SalesCarWeightLog
set SteadyWeightTime = getdate(),
    CarWeightStatus = 1
where WeightLogID = @WeightLogID
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void UpdateOutTime(FactoryArgs args, t_BigID WeightLogID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("WeightLogID", WeightLogID));

            string strSQL = @"
update SalesCarWeightLog
set OutWeightTime = datetime('now','localtime'),
    CarWeightStatus = 2
where WeightLogID = @WeightLogID;
";
            if (args.DBType == 1)
            {
                strSQL = @"
update SalesCarWeightLog
set OutWeightTime = getdate(),
    CarWeightStatus = 2
where WeightLogID = @WeightLogID
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public DataTable GetSalesCarWeightLog(FactoryArgs args, t_BigID WeightLogID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("WeightLogID", WeightLogID));

            string strSQL = @"
select *
from dbo.SalesCarWeightLog
where WeightLogID = @WeightLogID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }
    }
}
