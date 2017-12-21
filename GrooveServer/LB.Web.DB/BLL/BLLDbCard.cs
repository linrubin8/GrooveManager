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
    public class BLLDbCard : IBLLFunction
    {
        private DALDbCard _DALDbCardn = null;
        public BLLDbCard()
        {
            _DALDbCardn = new DAL.DALDbCard();
        }

        public override string GetFunctionName(int iFunctionType)
        {

            string strFunName = "";
            switch (iFunctionType)
            {
                case 20500:
                    strFunName = "Insert";
                    break;
                case 20501:
                    strFunName = "Update";
                    break;
                case 20502:
                    strFunName = "Delete";
                    break;

                case 20503:
                    strFunName = "CardConfig";
                    break;
            }
            return strFunName;
        }

        public void Insert(FactoryArgs args, out t_BigID CardID, t_String CardCode, t_String CardName)
        {
            using (DataTable dtExists = _DALDbCardn.GetCardCode(args,new t_BigID(0), CardCode))
            {
                if (dtExists.Rows.Count == 0)
                {
                    _DALDbCardn.Insert(args, out CardID, CardCode, CardName);
                }
                else
                {
                    throw new Exception("该卡号已存在，请输入新的卡号！");
                }
            }
        }

        public void Update(FactoryArgs args, t_BigID CardID, t_String CardCode, t_String CardName)
        {
            using (DataTable dtExists = _DALDbCardn.GetCardCode(args, CardID, CardCode))
            {
                if (dtExists.Rows.Count == 0)
                {
                    _DALDbCardn.Update(args, CardID, CardCode, CardName);
                }
                else
                {
                    throw new Exception("该卡号已存在，请输入新的卡号！");
                }
            }
        }

        public void Delete(FactoryArgs args,
           t_BigID CardID)
        {
            _DALDbCardn.Delete(args, CardID);
        }

        public void CardConfig(FactoryArgs args,t_String ReadCardSerialCOM,t_String WriteCardSerialCOM,
            t_ID ReadCardBaud,t_String MachineName,t_ID UseReadCard, t_ID UseWriteCard,
            t_ID ConnectType,t_String IPAddress,t_ID IPPort)
        {
            _DALDbCardn.CardConfig(args, ReadCardSerialCOM, WriteCardSerialCOM, ReadCardBaud, MachineName,
                    UseReadCard, UseWriteCard, ConnectType, IPAddress, IPPort);
        }
    }
}
