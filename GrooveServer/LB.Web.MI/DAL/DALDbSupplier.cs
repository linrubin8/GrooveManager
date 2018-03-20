using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.MI.DAL
{
    public class DALDbSupplier
    {
        public void Supplier_Insert(FactoryArgs args, out t_BigID SupplierID, t_String SupplierName, t_String SupplierCode, t_ID IsForbidden)
        {
            SupplierID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SupplierID", SupplierID, true));
            parms.Add(new LBDbParameter("SupplierName", SupplierName));
            parms.Add(new LBDbParameter("SupplierCode", SupplierCode));
            parms.Add(new LBDbParameter("IsForbidden", IsForbidden));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("ChangeTime", new t_DTSmall(DateTime.Now)));

            string strSQL = @"
insert into dbo.DbSupplier(SupplierName,SupplierCode,IsForbidden, ChangeBy, ChangeTime)
values( @SupplierName,@SupplierCode,@IsForbidden, @ChangeBy, @ChangeTime);

select last_insert_rowid() as SupplierID;
";
            if (args.DBType == 1)
            {
                strSQL = @"
insert into dbo.DbSupplier(SupplierName,SupplierCode,IsForbidden, ChangeBy, ChangeTime)
values( @SupplierName,@SupplierCode,@IsForbidden, @ChangeBy, @ChangeTime)

select @@identity as SupplierID
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            SupplierID.Value = Convert.ToInt64(parms["SupplierID"].Value);
        }

        public void Supplier_Update(FactoryArgs args, t_BigID SupplierID, t_String SupplierName, t_ID IsForbidden)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SupplierID", SupplierID));
            parms.Add(new LBDbParameter("SupplierName", SupplierName));
            parms.Add(new LBDbParameter("IsForbidden", IsForbidden));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("ChangeTime", new t_DTSmall(DateTime.Now)));

            string strSQL = @"
update dbo.DbSupplier
set SupplierName = @SupplierName,
    IsForbidden = @IsForbidden,
    ChangeBy = @ChangeBy,
    ChangeTime = @ChangeTime
where SupplierID  =@SupplierID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void Supplier_Delete(FactoryArgs args, t_BigID SupplierID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SupplierID", SupplierID));

            string strSQL = @"
delete dbo.DbSupplier
where SupplierID = @SupplierID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }
        
        public void GetMaxCarCode(FactoryArgs args,out t_String MaxCode)
        {
            MaxCode = new t_String();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("MaxCode", MaxCode,true));
            string strSQL = @"
    select SupplierCode as MaxCode
    from dbo.DbSupplier
    order by SupplierCode desc limit 1
";
            if (args.DBType == 1)
            {
                strSQL = @"
 select top 1 SupplierCode as MaxCode
    from dbo.DbSupplier
    order by SupplierCode desc
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            MaxCode.SetValueWithObject(parms["MaxCode"].Value);
        }

        public DataTable GetSupplierByName(FactoryArgs args, t_BigID SupplierID, t_String SupplierName)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SupplierID", SupplierID));
            parms.Add(new LBDbParameter("SupplierName", SupplierName));
            string strSQL = @"";
            if (SupplierID.Value == 0)
            {
                strSQL = @"select SupplierName
    from dbo.DbSupplier
    where SupplierName=@SupplierName";
            }
            else
            {
                strSQL = @"select SupplierName
    from dbo.DbSupplier
    where SupplierName=@SupplierName and SupplierID<>@SupplierID";
            }
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }
    }
}
