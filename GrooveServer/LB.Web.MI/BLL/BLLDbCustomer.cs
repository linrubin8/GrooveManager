﻿using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using LB.Web.MI.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.MI.BLL
{
    public class BLLDbCustomer: IBLLFunction
    {
        private DALDbCustomer _DALDbCustomer = null;
        private DALDbCar _DALDbCar = null;
        public BLLDbCustomer()
        {
            _DALDbCar = new DAL.DALDbCar();
            _DALDbCustomer = new DAL.DALDbCustomer();
        }

        public override string GetFunctionName(int iFunctionType)
        {
            string strFunName = "";
            switch (iFunctionType)
            {
                case 13400:
                    strFunName = "Customer_Insert";
                    break;

                case 13401:
                    strFunName = "Customer_Update";
                    break;

                case 13402:
                    strFunName = "Customer_Delete";
                    break;
            }
            return strFunName;
        }

        public void Customer_Insert(FactoryArgs args, out t_BigID CustomerID,out t_String CustomerCode, t_String CustomerName, t_String Contact, t_String Phone, t_String Address,
            t_Bool CarIsLimit, t_ID AmountType, t_String LicenceNum, t_String Description, t_Bool IsForbid, t_ID ReceiveType,
            t_Decimal CreditAmount, t_Bool IsDisplayPrice, t_Bool IsDisplayAmount, t_Bool IsPrintAmount, t_Bool IsAllowOverFul,
            t_Bool IsAllowEmptyIn)
        {
            CustomerCode = new t_String();
            CustomerID = new t_BigID();
            IsAllowEmptyIn.IsNullToZero();

            using (DataTable dtCustomer = _DALDbCustomer.GetCustomerByName(args, CustomerID, CustomerName))
            {
                if (dtCustomer.Rows.Count > 0)
                {
                    throw new Exception("该客户名称已存在！");
                }
            }

            t_String MaxCode;
            _DALDbCustomer.GetMaxCode(args, out MaxCode);
            int CodeIndex = LBConverter.ToInt32(MaxCode.Value.Replace("K", ""));
            CodeIndex++;
            if (CodeIndex < 10)
                CustomerCode.SetValueWithObject("K000" + CodeIndex.ToString());
            else if (CodeIndex < 100)
                CustomerCode.SetValueWithObject("K00" + CodeIndex.ToString());
            else if (CodeIndex < 1000)
                CustomerCode.SetValueWithObject("K0" + CodeIndex.ToString());
            else
                CustomerCode.SetValueWithObject("K"+CodeIndex.ToString());

            _DALDbCustomer.Customer_Insert(args, out CustomerID, CustomerCode, CustomerName, Contact, Phone, Address, CarIsLimit, AmountType, LicenceNum, Description,
                IsForbid, ReceiveType, CreditAmount, IsDisplayPrice, IsDisplayAmount, IsPrintAmount, IsAllowOverFul, IsAllowEmptyIn);
        }

        public void Customer_Update(FactoryArgs args, t_BigID CustomerID, t_String CustomerName, t_String Contact, t_String Phone, t_String Address,
            t_Bool CarIsLimit, t_ID AmountType, t_String LicenceNum, t_String Description, t_Bool IsForbid, t_ID ReceiveType,
            t_Decimal CreditAmount, t_Bool IsDisplayPrice, t_Bool IsDisplayAmount, t_Bool IsPrintAmount, t_Bool IsAllowOverFul,
            t_Bool IsAllowEmptyIn)
        {
            IsAllowEmptyIn.IsNullToZero();
            using (DataTable dtCustomer = _DALDbCustomer.GetCustomerByName(args, CustomerID, CustomerName))
            {
                if (dtCustomer.Rows.Count > 0)
                {
                    throw new Exception("该客户名称已存在！");
                }
            }

            _DALDbCustomer.Customer_Update(args, CustomerID, CustomerName, Contact, Phone, Address, CarIsLimit, AmountType, LicenceNum, Description,
                IsForbid, ReceiveType, CreditAmount, IsDisplayPrice, IsDisplayAmount, IsPrintAmount, IsAllowOverFul, IsAllowEmptyIn);
        }

        public void Customer_Delete(FactoryArgs args, t_BigID CustomerID)
        {
            using (DataTable dtCar = _DALDbCustomer.GetCarByCustomer(args, CustomerID))
            {
                if (dtCar.Rows.Count > 0)
                {
                    throw new Exception("该客户已关联车辆，无法删除！");
                }
            }
            DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
            {
                _DALDbCar.DeleteCustomerCarByCustomerID(argsInTrans, CustomerID);

                _DALDbCustomer.Customer_Delete(args, CustomerID);
            };
            DBHelper.ExecInTrans(args, exec);
            
        }
    }
}
