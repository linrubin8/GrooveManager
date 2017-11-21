using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using LB.Web.MI.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.MI.BLL
{
    public class BLLDbSupplier : IBLLFunction
    {
        private DALDbSupplier _DALDbSupplier = null;
        public BLLDbSupplier()
        {
            _DALDbSupplier = new DAL.DALDbSupplier();
        }

        public override string GetFunctionName(int iFunctionType)
        {
            string strFunName = "";
            switch (iFunctionType)
            {
                case 20600:
                    strFunName = "Supplier_Insert";
                    break;

                case 20601:
                    strFunName = "Supplier_Update";
                    break;

                case 20602:
                    strFunName = "Supplier_Delete";
                    break;
            }
            return strFunName;
        }

        public void Supplier_Insert(FactoryArgs args, out t_BigID SupplierID,out t_String SupplierCode, t_String SupplierName, t_ID IsForbidden)
        {
            SupplierCode = new t_String();
            SupplierID = new t_BigID();
            IsForbidden.IsNullToZero();
            using (DataTable dtSupplier= _DALDbSupplier.GetSupplierByName(args, SupplierID, SupplierName))
            {
                if (dtSupplier.Rows.Count > 0)
                {
                    throw new Exception("该供应商名称已存在！");
                }
            }

            t_BigID SupplierID_temp = new t_BigID();
            t_String SupplierCode_temp = new t_String();
            DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
            {
                t_String MaxCode;
                _DALDbSupplier.GetMaxCarCode(argsInTrans,out MaxCode);
                int CodeIndex = MaxCode.Value == null ? 0 : LBConverter.ToInt32( MaxCode.Value.Replace("G", ""));
                CodeIndex++;
                if (CodeIndex < 10)
                    SupplierCode_temp.SetValueWithObject("G0" + CodeIndex.ToString());
                else
                    SupplierCode_temp.SetValueWithObject( "G"+CodeIndex.ToString());

                _DALDbSupplier.Supplier_Insert(argsInTrans, out SupplierID_temp, SupplierName,SupplierCode_temp,IsForbidden);
            };
            DBHelper.ExecInTrans(args, exec);
            SupplierID.Value = SupplierID_temp.Value;
            SupplierCode.Value = SupplierCode_temp.Value;
        }

        public void Supplier_Update(FactoryArgs args, t_BigID SupplierID, t_String SupplierName, t_ID IsForbidden)
        {
            IsForbidden.IsNullToZero();
            using (DataTable dtCar = _DALDbSupplier.GetSupplierByName(args, SupplierID, SupplierName))
            {
                if (dtCar.Rows.Count > 0)
                {
                    throw new Exception("该供应商名称已存在！");
                }
            }

            _DALDbSupplier.Supplier_Update(args, SupplierID, SupplierName, IsForbidden);
        }

        public void Supplier_Delete(FactoryArgs args, t_BigID SupplierID)
        {
            _DALDbSupplier.Supplier_Delete(args, SupplierID);
        }
        
    }
}
