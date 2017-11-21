﻿using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.MI.DAL
{
    public class DALDbCar
    {
        public void Car_Insert(FactoryArgs args, out t_BigID CarID,t_String CarCode, t_String CarNum, t_String Description, 
            t_Decimal DefaultCarWeight, t_BigID SupplierID, t_BigID CardID)
        {
            CarID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID, true));
            parms.Add(new LBDbParameter("CarNum", CarNum));
            parms.Add(new LBDbParameter("CarCode", CarCode));
            parms.Add(new LBDbParameter("SupplierID", SupplierID));
            parms.Add(new LBDbParameter("CardID", CardID));
            parms.Add(new LBDbParameter("Description", Description));
            parms.Add(new LBDbParameter("CreateBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("CreateTime", new t_DTSmall(DateTime.Now)));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("DefaultCarWeight", DefaultCarWeight));
            parms.Add(new LBDbParameter("ChangeTime", new t_DTSmall(DateTime.Now)));

            string strSQL = @"
insert into dbo.DbCar(CarNum,CarCode,Description,CreateBy, CreateTime, ChangeBy, ChangeTime,DefaultCarWeight,SupplierID,CardID)
values( @CarNum,@CarCode,@Description, @CreateBy, @CreateTime, @ChangeBy, @ChangeTime,@DefaultCarWeight,@SupplierID,@CardID);

select last_insert_rowid() as CarID;
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            CarID.Value = Convert.ToInt64(parms["CarID"].Value);
        }
        public void Car_Update(FactoryArgs args, t_BigID CarID, t_String CarNum, t_String Description, t_Decimal DefaultCarWeight, t_BigID SupplierID, t_BigID CardID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("CarNum", CarNum));
            parms.Add(new LBDbParameter("Description", Description));
            parms.Add(new LBDbParameter("ChangeBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("ChangeTime", new t_DTSmall(DateTime.Now)));
            parms.Add(new LBDbParameter("DefaultCarWeight", DefaultCarWeight));
            parms.Add(new LBDbParameter("SupplierID", SupplierID));
            parms.Add(new LBDbParameter("CardID", CardID));

            string strSQL = @"
update dbo.DbCar
set CarNum = @CarNum,
    Description = @Description,
    ChangeBy = @ChangeBy,
    ChangeTime = @ChangeTime,
    DefaultCarWeight = @DefaultCarWeight,
    SupplierID = @SupplierID,
    CardID = @CardID
where CarID  =@CarID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void Customer_Delete(FactoryArgs args, t_BigID CarID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));

            string strSQL = @"
delete dbo.DbCar
where CarID = @CarID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public DataTable GetCarByName(FactoryArgs args, t_BigID CarID, t_String CarNum)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("CarNum", CarNum));
            string strSQL = @"";
            if (CarID.Value == 0)
            {
                strSQL = @"select CarNum
    from dbo.DbCar
    where CarNum=@CarNum";
            }
            else
            {
                strSQL = @"select CarNum
    from dbo.DbCar
    where CarNum=@CarNum and CarID<>@CarID";
            }
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void GetMaxCarCode(FactoryArgs args,out t_String MaxCode)
        {
            MaxCode = new t_String();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("MaxCode", MaxCode,true));
            string strSQL = @"
    select CarCode as MaxCode
    from dbo.DbCar
    order by CarCode desc limit 1
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            MaxCode.SetValueWithObject(parms["MaxCode"].Value);
        }

        public bool VerifyIsRefCustomer(FactoryArgs args, t_BigID CarID, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("CustomerID", CustomerID));

            string strSQL = @"
select *
from dbo.DbCustomerCar
where CarID = @CarID and 
    CustomerID = @CustomerID
";
            DataTable dt = DBHelper.ExecuteQuery(args, strSQL, parms);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public DataTable GetRefCustomer(FactoryArgs args, t_BigID CarID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));

            string strSQL = @"
select *
from dbo.DbCustomerCar c
    inner join dbo.DbCustomer d on
        d.CustomerID = c.CustomerID
where c.CarID = @CarID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void InsertCustomerCar(FactoryArgs args, t_BigID CarID, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("CustomerID", CustomerID));

            string strSQL = @"
insert into dbo.DbCustomerCar(CarID,CustomerID)
values(@CarID,@CustomerID)
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void DeleteCustomerCar(FactoryArgs args, t_BigID CarID, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("CustomerID", CustomerID));

            string strSQL = @"
delete dbo.DbCustomerCar
where CarID = @CarID and CustomerID = @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void DeleteCustomerCarByCustomerID(FactoryArgs args,  t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));

            string strSQL = @"
delete dbo.DbCustomerCar
where CustomerID = @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void DeleteCustomerCarByCarID(FactoryArgs args, t_BigID CarID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));

            string strSQL = @"
delete dbo.DbCustomerCar
where CarID = @CarID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void CancelRefCard(FactoryArgs args, t_BigID CardID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CardID", CardID));

            string strSQL = @"
update DbCar
set CardID=null
where CardID = @CardID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }
    }
}
