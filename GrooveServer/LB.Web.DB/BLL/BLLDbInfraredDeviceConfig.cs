using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using LB.Web.DB.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.Web.DB.BLL
{
    public class DbInfraredDeviceConfig : IBLLFunction
    {
        private DALDbInfraredDeviceConfig _DbInfraredDeviceConfig = null;
        public DbInfraredDeviceConfig()
        {
            _DbInfraredDeviceConfig = new DAL.DALDbInfraredDeviceConfig();
        }

        public override string GetFunctionName(int iFunctionType)
        {
            string strFunName = "";
            switch (iFunctionType)
            {
                case 14500:
                    strFunName = "InsertUpdateInfraredConfig";
                    break;
            }
            return strFunName;
        }
        
        public void InsertUpdateInfraredConfig(FactoryArgs args,
            t_String MachineName,t_String SerialName,t_ID HeaderXType,t_ID TailXType,
            t_ID SuccessYType, t_ID FailYType, t_Bool IsHeaderEffect,t_Bool IsTailEffect,t_Bool IsAlermEffect)
        {
            IsHeaderEffect.IsNullToZero();
            IsTailEffect.IsNullToZero();
            using (DataTable dtUserCofnig = _DbInfraredDeviceConfig.GetInfraredConfig(args,MachineName))
            {
                if (dtUserCofnig.Rows.Count > 0)
                {
                    DataRow drConfig = dtUserCofnig.Rows[0];
                    _DbInfraredDeviceConfig.UpdateInfraredDeviceConfig(args, MachineName, SerialName, 
                        HeaderXType, TailXType, SuccessYType, FailYType, IsHeaderEffect,IsTailEffect, IsAlermEffect);
                }
                else
                {
                    _DbInfraredDeviceConfig.InsertInfraredDeviceConfig(args, MachineName, SerialName, 
                        HeaderXType, TailXType, SuccessYType, FailYType, IsHeaderEffect, IsTailEffect, IsAlermEffect);
                }
            }
            
        }
    }
}
