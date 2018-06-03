using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.SM.DAL
{
    public class DALSaleCarInOutBill
    {
        //判断该车辆是否已出磅
        public DataTable ExistsNotOut(FactoryArgs args, t_BigID CarID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));
            string strSQL = @"
    select BillDate
    from dbo.SaleCarInBill
    where CarID=@CarID and isnull(IsCancel,0)=0 and 
        SaleCarInBillID not in (select SaleCarInBillID from dbo.SaleCarOutBill)
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable GetMaxOutBillCode(FactoryArgs args,string strBillFont)
        {

            string strSQL = @"
select SaleCarOutBillCode
from dbo.SaleCarOutBill
where SaleCarOutBillCode like '" + strBillFont + @"%'
order by SaleCarOutBillCode desc limit 1
";
            if (args.DBType == 1)
            {
                strSQL = @"
select top 1 SaleCarOutBillCode
from dbo.SaleCarOutBill
where SaleCarOutBillCode like '" + strBillFont + @"%'
order by SaleCarOutBillCode desc
";
            }
            return DBHelper.ExecuteQuery(args, strSQL);
        }

        public DataTable GetMaxInBillCode(FactoryArgs args, string strBillFont)
        {

            string strSQL = @"
select SaleCarInBillCode
from dbo.SaleCarInBill
where SaleCarInBillCode like '" + strBillFont + @"%'
order by SaleCarInBillCode desc limit 1
";
            if (args.DBType == 1)
            {
                strSQL = @"
select top 1 SaleCarInBillCode
from dbo.SaleCarInBill
where SaleCarInBillCode like '" + strBillFont + @"%'
order by SaleCarInBillCode desc
";
            }
            return DBHelper.ExecuteQuery(args, strSQL);
        }

        public void ReadTopBillDateByCardCode(FactoryArgs args, t_String CardCode,
            out t_String BillDate)
        {
            BillDate = new t_String("");
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CardCode", CardCode));

            string strSQL = @"
select BillDate
from dbo.SaleCarInBill
where CardCode = @CardCode
order by BillDate desc  limit 1
";
            if (args.DBType == 1)
            {
                strSQL = @"
select top 1 BillDate
from dbo.SaleCarInBill
where CardCode = @CardCode
order by BillDate desc
";
            }

            DataTable dt = DBHelper.ExecuteQuery(args, strSQL, parms);
            if (dt.Rows.Count > 0)
            {
                BillDate.Value = dt.Rows[0]["BillDate"].ToString().TrimEnd();
            }
        }

        public void InsertInBill(FactoryArgs args, out t_BigID SaleCarInBillID, t_String SaleCarInBillCode, t_BigID CarID,
            t_BigID ItemID, t_DTSmall BillDate, t_Float CarTare, t_BigID SupplierID, t_String Description,
            t_String CardCode, t_Float TotalWeight, t_Float SuttleWeight)
        {
            SaleCarInBillID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID, true));
            parms.Add(new LBDbParameter("SaleCarInBillCode", SaleCarInBillCode));
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("ItemID", ItemID));
            parms.Add(new LBDbParameter("BillDate", BillDate));
            parms.Add(new LBDbParameter("CarTare", CarTare));
            parms.Add(new LBDbParameter("SupplierID", SupplierID));
            parms.Add(new LBDbParameter("Description", Description));
            parms.Add(new LBDbParameter("CardCode", CardCode));
            parms.Add(new LBDbParameter("TotalWeight",TotalWeight));
            parms.Add(new LBDbParameter("SuttleWeight", SuttleWeight));
            parms.Add(new LBDbParameter("CreateBy", new t_String(args.LoginName)));

            string strSQL = @"
insert into dbo.SaleCarInBill(  SaleCarInBillCode, CarID,PrintCount,
            ItemID, BillDate, BillStatus, CarTare, SupplierID,Description,
            IsCancel, CreateBy, CreateTime,CancelByDate,CardCode,TotalWeight,SuttleWeight)
values( @SaleCarInBillCode, @CarID,0,
        @ItemID, @BillDate, 1, @CarTare, @SupplierID,@Description,
        0,@CreateBy,@BillDate,datetime('now','localtime'),@CardCode,@TotalWeight,@SuttleWeight);

select last_insert_rowid() as SaleCarInBillID;
";
            if (args.DBType == 1)
            {
                strSQL = @"
insert into dbo.SaleCarInBill(  SaleCarInBillCode, CarID,PrintCount,
            ItemID, BillDate, BillStatus, CarTare, SupplierID,Description,
            IsCancel, CreateBy, CreateTime,CancelByDate,CardCode,TotalWeight,SuttleWeight)
values( @SaleCarInBillCode, @CarID,0,
        @ItemID, @BillDate, 1, @CarTare, @SupplierID,@Description,
        0,@CreateBy,@BillDate,getdate(),@CardCode,@TotalWeight,@SuttleWeight)

select @@identity as SaleCarInBillID
";
            }
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            SaleCarInBillID.Value = Convert.ToInt64(parms["SaleCarInBillID"].Value);
        }

        public void UpdateInBill(FactoryArgs args, t_BigID SaleCarInBillID, t_BigID CarID, t_BigID SupplierID,
            t_Float CarTare, t_Float SuttleWeight)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("SupplierID", SupplierID));
            parms.Add(new LBDbParameter("CarTare", CarTare));
            parms.Add(new LBDbParameter("SuttleWeight", SuttleWeight));
            string strSQL = @"
update dbo.SaleCarInBill
set CarID = @CarID,
    SupplierID = @SupplierID,
    SuttleWeight = @SuttleWeight,
    CarTare = @CarTare
where SaleCarInBillID  =@SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public DataTable GetCarNotOutBill(FactoryArgs args, t_BigID CarID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));

            string strSQL = @"
select *
from dbo.SaleCarInBill
where CarID = @CarID and
    SaleCarInBillID not in (
    select SaleCarInBillID
    from dbo.SaleCarOutBill
    ) and isnull(BillStatus,0)=1 and isnull(IsCancel,0)=0
order by BillDate desc
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable GetCustomer(FactoryArgs args, t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));

            string strSQL = @"
select *
from dbo.DbCustomer
where CustomerID = @CustomerID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable GetSaleCarInBill(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));

            string strSQL = @"
select *
from dbo.SaleCarInBill b
    inner join dbo.DbCar c on
        c.CarID = b.CarID
where SaleCarInBillID = @SaleCarInBillID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable GetCarOutBillByInBillID(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));

            string strSQL = @"
select *
from dbo.SaleCarOutBill
where SaleCarInBillID = @SaleCarInBillID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void InsertOutBill(FactoryArgs args, out t_BigID SaleCarOutBillID,t_String SaleCarOutBillCode, t_BigID SaleCarInBillID, t_BigID CarID, t_DTSmall BillDate,
            t_Decimal TotalWeight, t_Decimal SuttleWeight, t_Decimal Price, t_Decimal Amount, t_ID ReceiveType, t_ID CalculateType, t_String Description)
        {
            SaleCarOutBillID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarOutBillID", SaleCarOutBillID, true));
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("SaleCarOutBillCode", SaleCarOutBillCode));
            parms.Add(new LBDbParameter("BillDate", BillDate));
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("TotalWeight", TotalWeight));
            parms.Add(new LBDbParameter("SuttleWeight", SuttleWeight));
            parms.Add(new LBDbParameter("Price", Price));
            parms.Add(new LBDbParameter("Amount", Amount));
            parms.Add(new LBDbParameter("Description", Description));
            parms.Add(new LBDbParameter("ReceiveType", ReceiveType));
            parms.Add(new LBDbParameter("CalculateType", CalculateType));
            parms.Add(new LBDbParameter("CreateBy", new t_String(args.LoginName)));

            string strSQL = @"
insert into dbo.SaleCarOutBill(  SaleCarInBillID,SaleCarOutBillCode, BillDate, CarID,TotalWeight,
            SuttleWeight, Price, Amount, Description,CreateBy, CreateTime)
values( @SaleCarInBillID,@SaleCarOutBillCode, @BillDate, @CarID, @TotalWeight,
        @SuttleWeight, @Price, @Amount, @Description,@CreateBy,datetime('now','localtime'))

set @SaleCarOutBillID = @@identity

update dbo.SaleCarInBill
set ReceiveType = @ReceiveType,
    CalculateType = @CalculateType
where SaleCarInBillID = @SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            SaleCarOutBillID.Value = Convert.ToInt64(parms["SaleCarOutBillID"].Value);
        }

        public void UpdateOutBillAmount(FactoryArgs args, t_BigID SaleCarInBillID,
            t_Decimal Price,t_Decimal Amount)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("Price", Price));
            parms.Add(new LBDbParameter("Amount", Amount));
            string strSQL = @"
update  dbo.SaleCarOutBill
set Price = @Price,
    Amount = @Amount
where SaleCarInBillID = @SaleCarInBillID";

        }

        public void UpdateOutBillCustomer(FactoryArgs args, t_BigID SaleCarInBillID,
            t_BigID CustomerID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            string strSQL = @"
update  dbo.SaleCarOutBill
set CustomerID = @CustomerID
where SaleCarInBillID = @SaleCarInBillID";

        }

        public DataTable GetGetSaleCarInOutBill(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));

            string strSQL = @"
select i.BillDate as BillDateIn,c.CarNum,i.*
from dbo.SaleCarInBill i
    left outer join DbCar c on 
        c.CarID = i.CarID
where i.SaleCarInBillID = @SaleCarInBillID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void Approve(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            string strSQL = @"
                update dbo.SaleCarInBill
                set BillStatus=2
                where SaleCarInBillID = @SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void UnApprove(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            string strSQL = @"
                update dbo.SaleCarInBill
                set BillStatus=1
                where SaleCarInBillID = @SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void Cancel(FactoryArgs args, t_BigID SaleCarInBillID, t_String CancelDesc)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("CancelBy", new t_String(args.LoginName)));
            parms.Add(new LBDbParameter("CancelDesc", CancelDesc));
            string strSQL = @"
                update dbo.SaleCarInBill
                set IsCancel=1,
                    CancelBy = @CancelBy,
                    CancelTime = datetime('now','localtime'),
                    CancelDesc = @CancelDesc
                where SaleCarInBillID = @SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void UnCancel(FactoryArgs args, t_BigID SaleCarInBillID, t_DTSmall CancelByDate)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("CancelByDate", CancelByDate));
            string strSQL = @"
                update dbo.SaleCarInBill
                set IsCancel=0,
                    CancelBy = '',
                    CancelTime = null,
                    CancelByDate= @CancelByDate
                where SaleCarInBillID = @SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void UpdateCustomerSalesAmount(FactoryArgs args,t_BigID CustomerID,t_Decimal SalesReceivedAmount)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("SalesReceivedAmount", SalesReceivedAmount));
            string strSQL = @"
update dbo.DbCustomer
set SalesReceivedAmount = isnull(SalesReceivedAmount,0)+isnull(@SalesReceivedAmount,0)
where CustomerID = @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }
        
        public void ReadCarID(FactoryArgs args,t_String CarNum,out t_BigID CarID)
        {
            CarID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarNum", CarNum));
            parms.Add(new LBDbParameter("CarID", CarID,true));
            string strSQL = @"
select CarID
from dbo.DbCar
where rtrim(CarNum) = rtrim(@CarNum)
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            CarID.SetValueWithObject(parms["CarID"].Value);
        }

        public void ReadItemID(FactoryArgs args, t_String ItemName, out t_BigID ItemID)
        {
            ItemID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ItemName", ItemName));
            parms.Add(new LBDbParameter("ItemID", ItemID, true));
            string strSQL = @"
select ItemID
from dbo.DbItem
where rtrim(ItemName) = rtrim(@ItemName)
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            ItemID.SetValueWithObject(parms["ItemID"].Value);
        }

        public void ReadCustomerID(FactoryArgs args, t_String CustomerName, out t_BigID CustomerID)
        {
            CustomerID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerName", CustomerName));
            parms.Add(new LBDbParameter("CustomerID", CustomerID, true));
            string strSQL = @"
select CustomerID
from dbo.DbCustomer
where rtrim(CustomerName) = rtrim(@CustomerName)
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            CustomerID.SetValueWithObject(parms["CustomerID"].Value);
        }

        public void ReadReceiveType(FactoryArgs args, t_BigID CustomerID, out t_ID ReceiveType)
        {
            ReceiveType = new t_ID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("ReceiveType", ReceiveType, true));
            string strSQL = @"
select ReceiveType
from dbo.DbCustomer
where CustomerID = @CustomerID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            ReceiveType.SetValueWithObject(parms["ReceiveType"].Value);
        }

        public DataTable ReadModifyDetailByCar(FactoryArgs args,t_BigID CarID,t_BigID CustomerID,t_BigID ItemID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarID", CarID));
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("ItemID", ItemID));

            string strSQL = @"
if @CustomerID > 0
begin
    select top 1 d.*
    from dbo.ModifyBillDetail d
        inner join dbo.ModifyBillHeader h on
            h.ModifyBillHeaderID = d.ModifyBillHeaderID
    where   IsApprove = 1 and
            h.CustomerID = @CustomerID and
            d.CarID = @CarID and
            d.ItemID = @ItemID
    order by h.EffectDate desc,h.ApproveTime desc
end
else
begin
    select top 1 d.*
    from dbo.ModifyBillDetail d
        inner join dbo.ModifyBillHeader h on
            h.ModifyBillHeaderID = d.ModifyBillHeaderID
    where   IsApprove = 1 and
            d.CarID = @CarID and
            d.ItemID = @ItemID
    order by h.EffectDate desc,h.ApproveTime desc
end
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable ReadModifyDetailByItem(FactoryArgs args, t_BigID CustomerID, t_BigID ItemID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("ItemID", ItemID));

            string strSQL = @"
if @CustomerID > 0
begin
    select top 1 d.*
    from dbo.ModifyBillDetail d
        inner join dbo.ModifyBillHeader h on
            h.ModifyBillHeaderID = d.ModifyBillHeaderID
    where   IsApprove = 1 and
            h.CustomerID = @CustomerID and
            d.ItemID = @ItemID
    order by h.EffectDate desc,h.ApproveTime desc
end
else
begin
    select top 1 d.*
    from dbo.ModifyBillDetail d
        inner join dbo.ModifyBillHeader h on
            h.ModifyBillHeaderID = d.ModifyBillHeaderID
    where   IsApprove = 1 and
            d.ItemID = @ItemID
    order by h.EffectDate desc,h.ApproveTime desc
end
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public DataTable ReadItem(FactoryArgs args, t_BigID ItemID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("ItemID", ItemID));

            string strSQL = @"
select *
from dbo.DbItemBase
where ItemID=@ItemID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void UpdateInPrintCount(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            string strSQL = @"
update dbo.SaleCarInBill
set PrintCount = isnull(PrintCount,0)+1
where SaleCarInBillID = @SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void UpdateOutPrintCount(FactoryArgs args, t_BigID SaleCarOutBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarOutBillID", SaleCarOutBillID));
            string strSQL = @"
update dbo.SaleCarOutBill
set OutPrintCount = isnull(OutPrintCount,0)+1
where SaleCarOutBillID = @SaleCarOutBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public void GetInsideCarCount(FactoryArgs args, out t_ID CarCount)
        {
            CarCount = new t_ID(0);
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("CarCount", CarCount,true));
            string strSQL = @"
select @CarCount = sum(1)
from dbo.View_SaleCarInOutBill 
where SaleCarOutBillID is null and isnull(IsCancel,0) = 0
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            CarCount.SetValueWithObject(parms["CarCount"].Value);
        }

        public void GetTodayTotalWeight(FactoryArgs args, out t_Decimal SalesTotalWeight, out t_ID TotalCar)
        {
            DateTime dtFrom = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime dtTo = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")).AddDays(1);
            SalesTotalWeight = new t_Decimal(0);
            TotalCar = new t_ID(0);
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SalesTotalWeight", SalesTotalWeight, true));
            parms.Add(new LBDbParameter("TotalCar", TotalCar, true));
            parms.Add(new LBDbParameter("DTFrom", new t_String(dtFrom.ToString("yyyy-MM-dd HH:mm:ss"))));
            parms.Add(new LBDbParameter("DTTo", new t_String(dtTo.ToString("yyyy-MM-dd HH:mm:ss"))));
            string strSQL = @"
select sum(SuttleWeight/1000.0) as SalesTotalWeight,count(1) as TotalCar
from SaleCarInBill i
where   i.IsCancel = 0 and 
        i.BillDate>=@DTFrom and i.BillDate<@DTTo
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            SalesTotalWeight.SetValueWithObject(parms["SalesTotalWeight"].Value);
            TotalCar.SetValueWithObject(parms["TotalCar"].Value);
        }

        public void InsertChangeBill(FactoryArgs args, out t_BigID SaleCarChangeBillID,
            t_BigID SaleCarInBillID, t_DTSmall ChangeDate, t_String ChangeBy, t_String ChangeDesc,
            t_String ChangeDetail)
        {
            SaleCarChangeBillID = new t_BigID();
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarChangeBillID", SaleCarChangeBillID, true));
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("ChangeDate", ChangeDate));
            parms.Add(new LBDbParameter("ChangeBy", ChangeBy));
            parms.Add(new LBDbParameter("ChangeDesc", ChangeDesc));
            parms.Add(new LBDbParameter("ChangeDetail", ChangeDetail));

            string strSQL = @"
insert dbo.SaleCarChangeBill(SaleCarInBillID,ChangeDate,ChangeBy,ChangeDesc,ChangeDetail)
values(@SaleCarInBillID,@ChangeDate,@ChangeBy,@ChangeDesc,@ChangeDetail)

set @SaleCarChangeBillID = @@identity
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
            SaleCarChangeBillID.SetValueWithObject(parms["SaleCarChangeBillID"].Value);
        }

        public DataTable GetRPReceiveBillHeader(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            string strSQL = @"
select *
from dbo.RPReceiveBillHeader
where SaleCarInBillID = @SaleCarInBillID
";
            return DBHelper.ExecuteQuery(args, strSQL, parms);
        }

        public void UpdateInOutBill(FactoryArgs args, t_BigID SaleCarInBillID, t_BigID ItemID, t_BigID CustomerID, t_Decimal Price,
            t_Decimal Amount)
        {
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SaleCarInBillID", SaleCarInBillID));
            parms.Add(new LBDbParameter("ItemID", ItemID));
            parms.Add(new LBDbParameter("CustomerID", CustomerID));
            parms.Add(new LBDbParameter("Price", Price));
            parms.Add(new LBDbParameter("Amount", Amount));

            string strSQL = @"
update dbo.SaleCarInBill
set ItemID = @ItemID,
    CustomerID = @CustomerID
where SaleCarInBillID = @SaleCarInBillID

update dbo.SaleCarOutBill
set Price = @Price,
    Amount = @Amount
where SaleCarInBillID = @SaleCarInBillID
";
            DBHelper.ExecuteNonQuery(args, System.Data.CommandType.Text, strSQL, parms, false);
        }

        public string GetDbSysConfigValue(FactoryArgs args, t_String SysConfigFieldName)
        {
            string strValue = "";
            LBDbParameterCollection parms = new LBDbParameterCollection();
            parms.Add(new LBDbParameter("SysConfigFieldName", SysConfigFieldName));

            string strSQL = @"
select *
from dbo.DbSysConfigValue
where SysConfigFieldName = @SysConfigFieldName
";
            DataTable dt = DBHelper.ExecuteQuery(args, strSQL, parms);
            if (dt.Rows.Count > 0)
            {
                strValue = dt.Rows[0]["SysConfigValue"].ToString().TrimEnd();
            }
            return strValue;
        }
    }
}
