using LB.Web.Base.Base.Helper;
using LB.Web.Base.Factory;
using LB.Web.Base.Helper;
using LB.Web.Contants.DBType;
using LB.Web.IBLL.IBLL.IBLLDB;
using LB.Web.IBLL.IBLL.IBLLMI;
using LB.Web.IBLL.IBLL.IBLLRP;
using LB.Web.IBLL.IBLL.IBLLSM;
using LB.Web.SM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace LB.Web.SM.BLL
{
    public class BLLSaleCarInOutBill : IBLLFunction,IBLLSaleCarInOutBill
    {
        private DALSaleCarInOutBill _DALSaleCarInOutBill = null;
        private IBLLDbCarWeight _IBLLDbCarWeight=null;
        private IBLLRPReceiveBillHeader _IBLLRPReceiveBillHeader = null;
        private IBLLDbErrorLog _IBLLDbErrorLog = null;
        public BLLSaleCarInOutBill()
        {
            _DALSaleCarInOutBill = new DAL.DALSaleCarInOutBill();
            _IBLLDbCarWeight= (IBLLDbCarWeight)DBHelper.GetFunctionMethod(20400);
            _IBLLRPReceiveBillHeader = (IBLLRPReceiveBillHeader)DBHelper.GetFunctionMethod(13300);
            _IBLLDbErrorLog = (IBLLDbErrorLog)DBHelper.GetFunctionMethod(20000);
        }

        public override string GetFunctionName(int iFunctionType)
        {

            string strFunName = "";
            switch (iFunctionType)
            {
                case 14100:
                    strFunName = "InsertInBill";
                    break;

                case 14101:
                    strFunName = "UpdateInBill";
                    break;

                case 14103:
                    strFunName = "GetCameraImage";
                    break;

                case 14104:
                    strFunName = "Approve";
                    break;

                case 14105:
                    strFunName = "UnApprove";
                    break;

                case 14106:
                    strFunName = "Cancel";
                    break;

                case 14107:
                    strFunName = "UnCancel";
                    break;

                case 14108:
                    strFunName = "GetSaleCarPriceInfo";
                    break;
                    
                case 14111:
                    strFunName = "SaveInSalesCameraImage";
                    break;
                    
                case 14113:
                    strFunName = "ReadSaleInfo";
                    break;
                    
            }
            return strFunName;
        }

        //InBillFrom入场单据来源：0手工单 1系统自动生成单
        public void InsertInBill(FactoryArgs args, out t_BigID SaleCarInBillID, out t_String SaleCarInBillCode, ref t_DTSmall BillDate, 
            t_BigID CarID,t_BigID ItemID,t_Float CarTare, t_BigID SupplierID, t_String Description,
            t_String CardCode,t_Float TotalWeight,t_Float SuttleWeight)
        {
            SaleCarInBillID = new t_BigID();
            SaleCarInBillCode = new t_String();
            if(BillDate.Value==null)
                BillDate = new t_DTSmall(DateTime.Now);
            SupplierID.NullIfZero();

            //if (CarID.Value == 0)
            //{
            //    throw new Exception("车牌号不能为空！");
            //}

            //if (SupplierID.Value == 0)
            //{
            //    throw new Exception("供应商不能为空！");
            //}

            #region --  生成编码 --
            string strBillFont = "RC" + DateTime.Now.ToString("yyyyMM")+"-";
            using (DataTable dtBillCode = _DALSaleCarInOutBill.GetMaxInBillCode(args, strBillFont))
            {
                if (dtBillCode.Rows.Count > 0)
                {
                    DataRow drBillCode = dtBillCode.Rows[0];
                    int iIndex = 1;
                    string strIndex = "";
                    if (drBillCode["SaleCarInBillCode"].ToString().TrimEnd().Contains(strBillFont))
                    {
                        iIndex = Convert.ToInt32(drBillCode["SaleCarInBillCode"].ToString().TrimEnd().Replace(strBillFont, ""));
                        iIndex += 1;
                        if (iIndex < 10)
                        {
                            strIndex = "0000" + iIndex.ToString();
                        }
                        else if (iIndex < 100)
                        {
                            strIndex = "000" + iIndex.ToString();
                        }
                        else if (iIndex < 1000)
                        {
                            strIndex = "00" + iIndex.ToString();
                        }
                        else if (iIndex < 10000)
                        {
                            strIndex = "0" + iIndex.ToString();
                        }
                        else
                        {
                            strIndex = iIndex.ToString();
                        }
                        SaleCarInBillCode.SetValueWithObject(strBillFont + strIndex);
                    }
                    else
                    {
                        SaleCarInBillCode.SetValueWithObject(strBillFont + "-00001");
                    }
                }
                else
                {
                    SaleCarInBillCode.SetValueWithObject(strBillFont + "00001");
                }
            }
            #endregion --  生成编码 --

            t_BigID SaleCarInBillID_temp = new t_BigID();
            t_String SaleCarInBillCode_temp = new t_String(SaleCarInBillCode.Value);
            t_DTSmall BillDate_temp = new t_DTSmall(BillDate.Value);
            DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
            {
                _DALSaleCarInOutBill.InsertInBill(argsInTrans, out SaleCarInBillID_temp, SaleCarInBillCode_temp, CarID, ItemID,
                    BillDate_temp,  CarTare, SupplierID, Description, CardCode, TotalWeight, SuttleWeight);

                //this.Approve(argsInTrans, SaleCarInBillID_temp);
            };
            DBHelper.ExecInTrans(args, exec);
            SaleCarInBillID.Value = SaleCarInBillID_temp.Value;
        }

        public void UpdateInBill(FactoryArgs args, t_BigID SaleCarInBillID, t_BigID CarID, t_BigID SupplierID,
            t_Float CarTare,  t_Float SuttleWeight)
        {
            _DALSaleCarInOutBill.UpdateInBill(args, SaleCarInBillID, CarID, SupplierID, CarTare,SuttleWeight);
        }

        public void GetCarNotOutBill(FactoryArgs args, t_BigID CarID,
            out t_DTSmall BillDateIn, out t_ID CalculateType, out t_BigID ItemID, out t_BigID CustomerID,
            out t_Decimal CarTare, out t_String Description, out t_ID ReceiveType, out t_String SaleCarInBillCode,
            out t_BigID SaleCarInBillID, out t_ID BillStatus, out t_Bool IsReaded)
        {
            IsReaded = new t_Bool(0);
            BillDateIn = new t_DTSmall();
            CalculateType = new t_ID();
            ItemID = new t_BigID();
            CustomerID = new t_BigID();
            CarTare = new t_Decimal();
            Description = new t_String();
            ReceiveType = new t_ID();
            SaleCarInBillCode = new t_String();
            SaleCarInBillID = new t_BigID();
            BillStatus = new t_ID();
            using (DataTable dtInBill = _DALSaleCarInOutBill.GetCarNotOutBill(args, CarID))
            {
                if (dtInBill.Rows.Count > 0)
                {
                    DataRow drInBill = dtInBill.Rows[0];
                    IsReaded.SetValueWithObject(1);
                    BillDateIn.SetValueWithObject(drInBill["BillDate"]);
                    ItemID.SetValueWithObject(drInBill["ItemID"]);
                    CustomerID.SetValueWithObject(drInBill["CustomerID"]);
                    CarTare.SetValueWithObject(drInBill["CarTare"]);
                    Description.SetValueWithObject(drInBill["Description"]);
                    SaleCarInBillCode.SetValueWithObject(drInBill["SaleCarInBillCode"]);
                    SaleCarInBillID.SetValueWithObject(drInBill["SaleCarInBillID"]);
                    BillStatus.SetValueWithObject(drInBill["BillStatus"]);

                    GetSaleCarPriceInfo(args, CarID, CustomerID, ItemID, out CalculateType, out ReceiveType);
                }
            }
        }

        //public void InsertOnlyOutBill(FactoryArgs args, out t_BigID SaleCarOutBillID, out t_DTSmall BillDate, t_BigID CarID,
        //    t_BigID ItemID, t_BigID CustomerID, t_Float CarTare,
        //    t_ID ReceiveType, t_ID CalculateType, t_Decimal Price, t_Decimal Amount, t_Decimal TotalWeight,
        //    t_Decimal SuttleWeight,t_Decimal CustomerPayAmount, t_String Description)
        //{
        //    BillDate = new t_DTSmall();
        //    t_DTSmall BillDate_temp = new t_DTSmall(DateTime.Now);
        //    t_BigID SaleCarInBillID = new t_BigID();
        //    t_String SaleCarInBillCode = new t_String();
        //    t_String SaleCarOutBillCode = new t_String();
        //    t_BigID SaleCarOutBillID_temp = new t_BigID();
        //    SaleCarOutBillID = new t_BigID();
        //    DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
        //    {
        //        this.InsertInBill(argsInTrans, out SaleCarInBillID,out SaleCarInBillCode,out BillDate_temp, CarID, ItemID, ReceiveType,CalculateType,
        //            CarTare,CustomerID,Description,new t_Image(),new t_Image(),new t_Image(),new t_Image(),new t_ID(1));

        //        //自动审核出场订单
        //        this.InsertOutBill(argsInTrans, out SaleCarOutBillID_temp,out SaleCarOutBillCode, out BillDate_temp, SaleCarInBillID,
        //            CarID, ReceiveType, CalculateType, Price, Amount, TotalWeight, SuttleWeight, CustomerPayAmount, Description,new t_ID(0));
        //    };
        //    DBHelper.ExecInTrans(args, exec);
        //    BillDate.Value = BillDate_temp.Value;
        //    SaleCarOutBillID.Value = SaleCarOutBillID_temp.Value;
        //}

        public void InsertOutBill(FactoryArgs args, out t_BigID SaleCarOutBillID,out t_String SaleCarOutBillCode, out t_DTSmall BillDate, t_BigID SaleCarInBillID, t_BigID CarID,
            t_ID ReceiveType, t_ID CalculateType, t_Decimal Price, t_Decimal Amount, t_Decimal TotalWeight,
            t_Decimal SuttleWeight, t_Decimal CustomerPayAmount, t_String Description, t_ID IsEmptyOut)
        {
            IsEmptyOut.IsNullToZero();//是否空车出
            bool bolIsNeedCancel = false;//是否自动作废，空车入空车出的情况需要作废
            if(IsEmptyOut.Value==1 || (Amount.Value==0 && SuttleWeight.Value<1000))
            {
                bolIsNeedCancel = true;
            }
            SaleCarOutBillCode = new t_String();
            t_BigID CustomerID = new t_BigID();
            t_String CarNum = new t_String();
            SaleCarOutBillID = new t_BigID();
            BillDate = new t_DTSmall(DateTime.Now);
            if (SaleCarInBillID.Value == null && SaleCarInBillID.Value == 0)
            {
                throw new Exception("该车辆未匹配到入场订单，请重新选择入场订单！");
            }
            if (CarID.Value == null || CarID.Value == 0)
            {
                throw new Exception("车牌号码不存在或者车牌号码为空，请重新选择车牌号码！");
            }
            //校验该入场单是否已出场
            using (DataTable dtOut = _DALSaleCarInOutBill.GetCarOutBillByInBillID(args, SaleCarInBillID))
            {
                if (dtOut.Rows.Count > 0)
                {
                    DataRow drOut = dtOut.Rows[0];
                    DateTime dtOutBillDate = Convert.ToDateTime(drOut["BillDate"]);
                    throw new Exception("该入场订单已生成出场记录，出场时间为【" + dtOutBillDate.ToString("yyyy-MM-dd HH:mm") + "】,请重新选择入场订单！");
                }
            }
            //校验该入场订单记录的车牌号码与当前输入的车牌是否一致
            using (DataTable dtInBill = _DALSaleCarInOutBill.GetSaleCarInBill(args, SaleCarInBillID))
            {
                if (dtInBill.Rows.Count > 0)
                {
                    DataRow drInBill = dtInBill.Rows[0];
                    long InCarID = LBConverter.ToInt64(drInBill["CarID"]);
                    CustomerID.SetValueWithObject(drInBill["CustomerID"]);
                    CarNum.SetValueWithObject(drInBill["CarNum"]);
                    if (CarID.Value != InCarID)
                    {
                        throw new Exception("输入的车牌号码与入场订单车牌号码不一致！");
                    }
                }
            }

            //校验该车辆是否存在多张入场未出场的订单
            using (DataTable dtExistsNotOut = _DALSaleCarInOutBill.ExistsNotOut(args, CarID))
            {
                if (dtExistsNotOut.Rows.Count > 1)
                {
                    throw new Exception("该车辆存在【" + dtExistsNotOut.Rows.Count + "】张入场但是未出场的订单！无法出场！");
                }
            }

            //生成编码
            string strBillFont = "XS" + DateTime.Now.ToString("yyyyMM") + "-";
            using (DataTable dtBillCode = _DALSaleCarInOutBill.GetMaxOutBillCode(args, strBillFont))
            {
                if (dtBillCode.Rows.Count > 0)
                {
                    DataRow drBillCode = dtBillCode.Rows[0];
                    int iIndex = 1;
                    string strIndex = "";
                    if (drBillCode["SaleCarOutBillCode"].ToString().TrimEnd().Contains(strBillFont))
                    {
                        iIndex = Convert.ToInt32(drBillCode["SaleCarOutBillCode"].ToString().TrimEnd().Replace(strBillFont, ""));
                        iIndex += 1;
                        if (iIndex < 10)
                        {
                            strIndex = "0000" + iIndex.ToString();
                        }
                        else if (iIndex < 100)
                        {
                            strIndex = "000" + iIndex.ToString();
                        }
                        else if (iIndex < 1000)
                        {
                            strIndex = "00" + iIndex.ToString();
                        }
                        else if (iIndex < 10000)
                        {
                            strIndex = "0" + iIndex.ToString();
                        }
                        else
                        {
                            strIndex = iIndex.ToString();
                        }
                        SaleCarOutBillCode.SetValueWithObject(strBillFont + strIndex);
                    }
                    else
                    {
                        SaleCarOutBillCode.SetValueWithObject(strBillFont + "-00001");
                    }
                }
                else
                {
                    SaleCarOutBillCode.SetValueWithObject(strBillFont + "00001");
                }
            }

            t_String SaleCarOutBillCode_temp = new t_String(SaleCarOutBillCode.Value);
            t_BigID SaleCarOutBillID_temp = new t_BigID();
            t_DTSmall BillDate_temp = new t_DTSmall(BillDate.Value);
            DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
            {
                _DALSaleCarInOutBill.InsertOutBill(argsInTrans, out SaleCarOutBillID_temp, SaleCarOutBillCode_temp, SaleCarInBillID, CarID, BillDate_temp,
                    TotalWeight, SuttleWeight, Price, Amount, ReceiveType, CalculateType, Description);
                
                if (CustomerPayAmount.Value > 0)
                {
                    t_BigID ReceiveBillHeaderID;
                    t_String ReceiveBillCode;
                    _IBLLRPReceiveBillHeader.Insert(argsInTrans, out ReceiveBillHeaderID, out ReceiveBillCode, BillDate_temp, CustomerID,
                        CustomerPayAmount, new t_String("来源：司机支付磅单现金，车号：" + CarNum.Value + " 磅单号：" + SaleCarOutBillCode_temp.Value),
                        SaleCarInBillID,new t_BigID(),new t_ID(0));
                    if (bolIsNeedCancel)
                    {
                        this.Cancel(argsInTrans, SaleCarInBillID, new t_String("空车入空车出"));
                    }
                    else
                    {
                        _IBLLRPReceiveBillHeader.Approve(argsInTrans, ReceiveBillHeaderID);//审核收款单
                    }
                }
                
                //自动审核出场订单
                this.Approve(argsInTrans, SaleCarInBillID);
            };
            DBHelper.ExecInTrans(args, exec);
            SaleCarOutBillID.Value = SaleCarOutBillID_temp.Value;
            SaleCarOutBillCode.Value = SaleCarOutBillCode_temp.Value;
        }

        public void UpdateInOutBill(FactoryArgs args, t_BigID SaleCarInBillID,t_BigID ItemID,t_BigID CustomerID,t_Decimal Price,
            t_Decimal Amount)
        {
            _DALSaleCarInOutBill.UpdateInOutBill(args, SaleCarInBillID, ItemID, CustomerID, Price, Amount);
        }

        public void SaveInSalesCameraImage(FactoryArgs args, t_BigID SaleCarInBillID,
            t_Image MonitoreImg1, t_Image MonitoreImg2, t_Image MonitoreImg3, t_Image MonitoreImg4)
        {
            try
            {
                string strDatePath = GetPicturePath(enImagePathType.InBillPath, DateTime.Now);

                if (MonitoreImg1.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image1.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg1.Value);
                }
                if (MonitoreImg2.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image2.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg2.Value);
                }
                if (MonitoreImg3.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image3.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg3.Value);
                }
                if (MonitoreImg4.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image4.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg4.Value);
                }
            }
            catch (Exception ex)
            {
                this._IBLLDbErrorLog.Insert(args,
                    new t_String("服务器端，保存入场图片时报错，入场单号：" + SaleCarInBillID.Value.ToString() + "\n错误信息：" + ex.Message),new t_ID(1));
                throw ex;
            }
        }

        public void SaveOutSalesCameraImage(FactoryArgs args, t_BigID SaleCarOutBillID,
            t_Image MonitoreImg1, t_Image MonitoreImg2, t_Image MonitoreImg3, t_Image MonitoreImg4)
        {
            try
            {
                string strDatePath = GetPicturePath(enImagePathType.OutBillPath, DateTime.Now);

                if (MonitoreImg1.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image1.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg1.Value);
                }
                if (MonitoreImg2.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image2.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg2.Value);
                }
                if (MonitoreImg3.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image3.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg3.Value);
                }
                if (MonitoreImg4.Value != null)
                {
                    string strImagePath = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image4.jpg");
                    CommonHelper.SaveFile(strImagePath, MonitoreImg4.Value);
                }
            }
            catch (Exception ex)
            {
                this._IBLLDbErrorLog.Insert(args,
                    new t_String("服务器端，保存出场图片时报错，出场单号：" + SaleCarOutBillID.Value.ToString() + "\n错误信息：" + ex.Message), new t_ID(1));
                throw ex;
            }
        }

        public void GetCameraImage(FactoryArgs args, t_BigID SaleCarInBillID,
            out t_Image InMonitoreImg1, out t_Image InMonitoreImg2, out t_Image InMonitoreImg3, out t_Image InMonitoreImg4,
            out t_Image OutMonitoreImg1, out t_Image OutMonitoreImg2, out t_Image OutMonitoreImg3, out t_Image OutMonitoreImg4)
        {
            InMonitoreImg1 = new t_Image();
            InMonitoreImg2 = new t_Image();
            InMonitoreImg3 = new t_Image();
            InMonitoreImg4 = new t_Image();
            OutMonitoreImg1 = new t_Image();
            OutMonitoreImg2 = new t_Image();
            OutMonitoreImg3 = new t_Image();
            OutMonitoreImg4 = new t_Image();

            t_BigID SaleCarOutBillID = new t_BigID();
            t_DTSmall BillDateIn = new t_DTSmall();
            using (DataTable dtBill = _DALSaleCarInOutBill.GetGetSaleCarInOutBill(args, SaleCarInBillID))
            {
                if (dtBill.Rows.Count > 0)
                {
                    DataRow drBill = dtBill.Rows[0];
                    BillDateIn.SetValueWithObject(drBill["BillDateIn"]);
                }
            }

            //读取入场图片
            if (BillDateIn.Value != null)
            {
                string strInPath = GetPicturePath(enImagePathType.InBillPath, (DateTime)BillDateIn.Value);
                string strPathImg1 = Path.Combine(strInPath, SaleCarInBillID.Value.ToString() + "_Image1.jpg");
                string strPathImg2 = Path.Combine(strInPath, SaleCarInBillID.Value.ToString() + "_Image2.jpg");
                string strPathImg3 = Path.Combine(strInPath, SaleCarInBillID.Value.ToString() + "_Image3.jpg");
                string strPathImg4 = Path.Combine(strInPath, SaleCarInBillID.Value.ToString() + "_Image4.jpg");

                if (File.Exists(strPathImg1))
                {
                    InMonitoreImg1.SetValueWithObject(CommonHelper.ReadFile(strPathImg1));
                }
                if (File.Exists(strPathImg2))
                {
                    InMonitoreImg2.SetValueWithObject(CommonHelper.ReadFile(strPathImg2));
                }
                if (File.Exists(strPathImg3))
                {
                    InMonitoreImg3.SetValueWithObject(CommonHelper.ReadFile(strPathImg3));
                }
                if (File.Exists(strPathImg4))
                {
                    InMonitoreImg4.SetValueWithObject(CommonHelper.ReadFile(strPathImg4));
                }
            }
        }

        private string GetPicturePath(enImagePathType pathType, DateTime dtDate)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory;
            string strCameraPath = Path.Combine(strPath, "LBCameraPicture");
            if (!Directory.Exists(strCameraPath))
            {
                Directory.CreateDirectory(strCameraPath);
            }

            string strPicFile = pathType == enImagePathType.InBillPath ? "InBillPicture" : "OutBillPicture";
            string strInBillPath = Path.Combine(strCameraPath, strPicFile);
            if (!Directory.Exists(strInBillPath))
            {
                Directory.CreateDirectory(strInBillPath);
            }
            string strDatePath = Path.Combine(strInBillPath, dtDate.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(strDatePath))
            {
                Directory.CreateDirectory(strDatePath);
            }
            return strDatePath;
        }

        public void Approve(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            t_BigID CustomerID = new t_BigID();
            t_Decimal Amount = new t_Decimal(0);
            t_ID ReceiveType = new t_ID(0);
            //using (DataTable dtOutBill = _DALSaleCarInOutBill.GetCarOutBillByInBillID(args, SaleCarInBillID))
            //{
            //    if (dtOutBill.Rows.Count == 0)//校验是否已生成出场订单
            //    {
            //        throw new Exception("该订单未有出场记录，无法审核！");
            //    }
            //    else
            //    {
            //        Amount.SetValueWithObject(dtOutBill.Rows[0]["Amount"]);
            //    }
            //}

            using (DataTable dtInBill = _DALSaleCarInOutBill.GetSaleCarInBill(args, SaleCarInBillID))
            {
                if (dtInBill.Rows.Count > 0)//校验是否已审核或者已作废
                {
                    DataRow drBill = dtInBill.Rows[0];
                    //CustomerID.SetValueWithObject(drBill["CustomerID"]);
                    //ReceiveType.SetValueWithObject(drBill["ReceiveType"]);
                    int iBillStatus = LBConverter.ToInt32(drBill["BillStatus"]);
                    bool bolIsCancel = LBConverter.ToBoolean(drBill["IsCancel"]);
                    if (iBillStatus == 2)
                    {
                        throw new Exception("该订单已审核，无法再执行审核！");
                    }
                    if (bolIsCancel)
                    {
                        throw new Exception("该订单已作废，无法审核！");
                    }
                }
            }

            //bool bolVerifyCredit = true;
            ////判断当前单据是现金支付还是挂账
            //if (ReceiveType.Value == 0)//现金
            //{

            //}
            //else if (ReceiveType.Value == 1|| ReceiveType.Value == 2)//预付和挂账
            //{
            //    bolVerifyCredit = VerifyIsOverRangeCredut(args, CustomerID, Amount);//校验信用额度
            //}

            DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
            {
                _DALSaleCarInOutBill.Approve(argsInTrans, SaleCarInBillID);

                //if (ReceiveType.Value == 1 || ReceiveType.Value == 2)//预付或者挂账情况下需求更新客户信息的冲销金额
                //{
                //    _DALSaleCarInOutBill.UpdateCustomerSalesAmount(argsInTrans, CustomerID, Amount);
                //}
            };
            DBHelper.ExecInTrans(args, exec);
        }

        public void UnApprove(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            t_BigID CustomerID = new t_BigID();
            t_Decimal Amount = new t_Decimal(0);
            t_ID ReceiveType = new t_ID(0);
            //using (DataTable dtOutBill = _DALSaleCarInOutBill.GetCarOutBillByInBillID(args, SaleCarInBillID))
            //{
            //    if (dtOutBill.Rows.Count > 0)
            //    {
            //        Amount.SetValueWithObject(dtOutBill.Rows[0]["Amount"]);
            //    }
            //}

            using (DataTable dtInBill = _DALSaleCarInOutBill.GetSaleCarInBill(args, SaleCarInBillID))
            {
                if (dtInBill.Rows.Count > 0)//校验是否已审核或者已作废
                {
                    DataRow drBill = dtInBill.Rows[0];
                    //CustomerID.SetValueWithObject(drBill["CustomerID"]);
                    //ReceiveType.SetValueWithObject(drBill["ReceiveType"]);
                    int iBillStatus = LBConverter.ToInt32(drBill["BillStatus"]);
                    bool bolIsCancel = LBConverter.ToBoolean(drBill["IsCancel"]);
                    if (iBillStatus == 1)
                    {
                        throw new Exception("该订单未审核，无法取消审核！");
                    }
                    if (bolIsCancel)
                    {
                        throw new Exception("该订单已作废，无法取消审核！");
                    }
                }
            }
            DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
            {
                _DALSaleCarInOutBill.UnApprove(argsInTrans, SaleCarInBillID);

                //if (ReceiveType.Value == 1 || ReceiveType.Value == 2)//挂账情况下需求退回重新金额
                //{
                //    Amount.SetValueWithObject(-Amount.Value);
                //    _DALSaleCarInOutBill.UpdateCustomerSalesAmount(argsInTrans, CustomerID, Amount);
                //}
            };
            DBHelper.ExecInTrans(args, exec);
        }

        public void Cancel(FactoryArgs args, t_BigID SaleCarInBillID,t_String CancelDesc)
        {
            using (DataTable dtInBill = _DALSaleCarInOutBill.GetSaleCarInBill(args, SaleCarInBillID))
            {
                if (dtInBill.Rows.Count > 0)//校验是否已审核或者已作废
                {
                    DataRow drBill = dtInBill.Rows[0];
                    int iBillStatus = LBConverter.ToInt32(drBill["BillStatus"]);
                    bool bolIsCancel = LBConverter.ToBoolean(drBill["IsCancel"]);
                    if (iBillStatus == 2)
                    {
                        throw new Exception("该订单已审核，无法执行作废！");
                    }
                    if (bolIsCancel)
                    {
                        throw new Exception("该订单已作废，无法再执行作废！");
                    }
                }
            }
            _DALSaleCarInOutBill.Cancel(args, SaleCarInBillID, CancelDesc);
        }

        public void UnCancel(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            t_DTSmall CancelByDate = new t_DTSmall(DateTime.Now);
            using (DataTable dtInBill = _DALSaleCarInOutBill.GetSaleCarInBill(args, SaleCarInBillID))
            {
                if (dtInBill.Rows.Count > 0)//校验是否已审核或者已作废
                {
                    DataRow drBill = dtInBill.Rows[0];
                    int iBillStatus = LBConverter.ToInt32(drBill["BillStatus"]);
                    bool bolIsCancel = LBConverter.ToBoolean(drBill["IsCancel"]);
                    CancelByDate = drBill["CancelByDate"] == DBNull.Value ?
                       new t_DTSmall(drBill["BillDate"]) : new t_DTSmall(drBill["CancelByDate"]);
                    CancelByDate.Value = ((DateTime)CancelByDate.Value).AddHours(1);//自动延长一个小时的作废期限
                    if (iBillStatus == 2)
                    {
                        throw new Exception("该订单已审核，无法执行取消作废！");
                    }
                    if (!bolIsCancel)
                    {
                        throw new Exception("该订单未作废，无法执行取消作废！");
                    }
                }
            }
            _DALSaleCarInOutBill.UnCancel(args, SaleCarInBillID, CancelByDate);
        }

        //校验是否超出信用额度
        public bool VerifyIsOverRangeCredut(FactoryArgs args, t_BigID CustomerID, t_Decimal SalesAmount)
        {
            bool bolIsPass = true;
            using (DataTable dtCustomer = _DALSaleCarInOutBill.GetCustomer(args, CustomerID))
            {
                if (dtCustomer.Rows.Count > 0)
                {
                    DataRow drCustomer = dtCustomer.Rows[0];
                    t_Decimal TotalReceivedAmount = new t_Decimal(drCustomer["TotalReceivedAmount"]);//预收总金额
                    TotalReceivedAmount.IsNullToZero();
                    t_Decimal SalesReceivedAmount = new t_Decimal(drCustomer["SalesReceivedAmount"]);//预收已冲销金额
                    SalesReceivedAmount.IsNullToZero();
                    t_Decimal CreditAmount = new t_Decimal(drCustomer["CreditAmount"]);//信用额度金额
                    CreditAmount.IsNullToZero();
                    t_Bool IsAllowOverFul = new t_Bool(drCustomer["IsAllowOverFul"]);//是否允许超额提货
                    t_Bool IsForbid = new t_Bool(drCustomer["IsForbid"]);
                    t_ID ReceiveType = new t_ID();
                    ReceiveType.SetValueWithObject(drCustomer["ReceiveType"]);

                    if (ReceiveType.Value == 1)//预付
                    {
                        if (TotalReceivedAmount.Value < SalesReceivedAmount.Value + SalesAmount.Value)
                        {
                            throw new Exception("该余额不足，请及时充值，否则无法生成磅单！");
                        }
                    }
                    else
                    {
                        if (IsForbid.Value == 1)//车辆是否限制
                        {
                            if (IsAllowOverFul.Value == 1)//允许超额提货
                            {
                                //判断是否已超出信用额度
                                if (SalesReceivedAmount.Value + SalesAmount.Value - TotalReceivedAmount.Value > CreditAmount.Value)
                                {
                                    bolIsPass = false;
                                    throw new Exception("该用户扣除当前车款[" + ((decimal)SalesAmount.Value).ToString("0.00") + "]元后，已经超出信用额度，请及时充值，否则无法生成磅单！");
                                }
                                else
                                {
                                    bolIsPass = true;
                                }
                            }
                            else
                            {
                                //不允许超额提货，只要余额不足，就不能提货
                                if (SalesReceivedAmount.Value + SalesAmount.Value > TotalReceivedAmount.Value)
                                {
                                    bolIsPass = false;
                                    throw new Exception("该用户当前车款为[" + ((decimal)SalesAmount.Value).ToString("0.00") + "]元，而充值余额为[" + ((decimal)(TotalReceivedAmount.Value - SalesReceivedAmount.Value)).ToString("0.00") + "]，请及时充值，否则无法生成磅单！");
                                }
                                else
                                {
                                    bolIsPass = true;
                                }
                            }
                        }
                        else
                        {
                            // 判断是否已超出信用额度
                            if (SalesReceivedAmount.Value + SalesAmount.Value - TotalReceivedAmount.Value > CreditAmount.Value)
                            {
                                bolIsPass = false;
                                throw new Exception("该用户扣除当前车款[" + ((decimal)SalesAmount.Value).ToString("0.00") + "]元后，已经超出信用额度，请及时充值，否则无法生成磅单！");
                            }
                            else
                            {
                                bolIsPass = true;
                            }
                            //不允许超额提货，只要余额不足，就不能提货
                            /*if (SalesReceivedAmount.Value + SalesAmount.Value > TotalReceivedAmount.Value)
                            {
                                bolIsPass = false;
                                throw new Exception("该用户当前车款为[" + ((decimal)SalesAmount.Value).ToString("0.00") + "]元，而充值余额为[" + ((decimal)(TotalReceivedAmount.Value - SalesReceivedAmount.Value)).ToString("0.00") + "]，请及时充值，否则无法生成磅单！");
                            }
                            else
                            {
                                bolIsPass = true;
                            }*/
                        }
                    }
                }
            }
            return bolIsPass;
        }

        //通过车牌号、物料名称以及客户名称读取默认的计价方式、收款方式
        public void GetSaleCarPriceInfo(FactoryArgs args, t_BigID CarID, t_BigID CustomerID, t_BigID ItemID, out t_ID CalculateType, out t_ID ReceiveType)
        {
            CalculateType = new t_ID(0);//默认按重量计算
            ReceiveType = new t_ID(0);//默认现金支付

            //_DALSaleCarInOutBill.ReadCarID(args, CarNum, out CarID);
            //_DALSaleCarInOutBill.ReadCustomerID(args, CustomerName, out CustomerID);
            //_DALSaleCarInOutBill.ReadItemID(args, ItemName, out ItemID);

            //读取客户默认收款方式
            if (CustomerID.Value > 0)
            {
                _DALSaleCarInOutBill.ReadReceiveType(args, CustomerID, out ReceiveType);
            }

            //读取计价方式
            using (DataTable dtDetailCar = _DALSaleCarInOutBill.ReadModifyDetailByCar(args, CarID, CustomerID, ItemID))
            {
                if (dtDetailCar.Rows.Count > 0)
                {
                    DataRow drDetailCar = dtDetailCar.Rows[0];
                    CalculateType.SetValueWithObject(drDetailCar["CalculateType"]);
                }
                else
                {
                    using (DataTable dtDetail = _DALSaleCarInOutBill.ReadModifyDetailByItem(args, CustomerID, ItemID))
                    {
                        if (dtDetail.Rows.Count > 0)
                        {
                            DataRow drDetail = dtDetail.Rows[0];
                            CalculateType.SetValueWithObject(drDetail["CalculateType"]);
                        }
                    }
                }
            }
        }

        //记录小票打印次数
        public void UpdateInPrintCount(FactoryArgs args, t_BigID SaleCarInBillID)
        {
            _DALSaleCarInOutBill.UpdateInPrintCount(args, SaleCarInBillID);
        }

        //记录磅单打印次数
        public void UpdateOutPrintCount(FactoryArgs args, t_BigID SaleCarOutBillID)
        {
            _DALSaleCarInOutBill.UpdateOutPrintCount(args, SaleCarOutBillID);
        }

        public void ReadSaleInfo(FactoryArgs args,
            out t_Decimal SalesTotalWeight,out t_ID TotalCar)
        {
            //_DALSaleCarInOutBill.GetInsideCarCount(args, out InsideCarCount);
            _DALSaleCarInOutBill.GetTodayTotalWeight(args,out SalesTotalWeight,out TotalCar);
        }

        //public void InsertChangeBill(FactoryArgs args, out t_BigID SaleCarChangeBillID,
        //    t_BigID SaleCarInBillID,  t_String ChangeDesc,
        //    t_String ChangeDetail, t_Bool IsPayMoney, t_Decimal PayMoney,
        //    t_BigID NewCustomerID, t_BigID NewItemID, t_ID NewReceiveType, t_ID NewCalculateType,
        //    t_Decimal NewPrice, t_Decimal NewAmount)
        //{
        //    t_DTSmall ChangeDate = new t_DTSmall(DateTime.Now);
        //    t_String ChangeBy = new t_String(args.LoginName);
        //    SaleCarChangeBillID = new t_BigID();
        //    t_BigID TempSaleCarChangeBillID=new t_BigID();
        //    DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
        //    {
        //        t_BigID SaleCarOutBillID = new t_BigID(0);
        //        using (DataTable dtBill = _DALSaleCarInOutBill.GetGetSaleCarInOutBill(argsInTrans, SaleCarInBillID))
        //        {
        //            DataRow drBill = dtBill.Rows[0];
        //            t_ID BillStatus = new t_ID(drBill["BillStatus"]);
        //            SaleCarOutBillID.SetValueWithObject(drBill["SaleCarOutBillID"]);
        //            if (BillStatus.Value == 2)
        //            {
        //                //先反审核磅单
        //                _DALSaleCarInOutBill.UnApprove(argsInTrans, SaleCarInBillID);
        //            }
        //            t_ID IsCancel = new t_ID(drBill["IsCancel"]);
        //            if (IsCancel.Value==0)
        //            {
        //                //作废磅单
        //                _DALSaleCarInOutBill.Cancel(argsInTrans, SaleCarInBillID, ChangeDesc);
        //            }
        //        }

        //        t_Decimal CustomerPayAmount = new t_Decimal(0);
        //        //磅单是否存在现金充值单，如果存在则作废
        //        using (DataTable dtBill = _DALSaleCarInOutBill.GetRPReceiveBillHeader(argsInTrans, SaleCarInBillID))
        //        {
        //            foreach (DataRow drBill in dtBill.Rows)
        //            {
        //                t_BigID ReceiveBillHeaderID = new t_BigID(drBill["ReceiveBillHeaderID"]);
        //                t_Bool IsApprove = new t_Bool(drBill["IsApprove"]);
        //                t_Bool IsCancel = new t_Bool(drBill["IsCancel"]);
        //                CustomerPayAmount.SetValueWithObject(drBill["ReceiveAmount"]);
        //                if (IsApprove.Value == 1)//反审核
        //                {
        //                    _IBLLRPReceiveBillHeader.UnApprove(argsInTrans, ReceiveBillHeaderID);
        //                }
        //                if (IsCancel.Value == 0)//反作废
        //                {
        //                    _IBLLRPReceiveBillHeader.Cancel(argsInTrans, ReceiveBillHeaderID);
        //                }
        //            }
        //        }
                
        //        using (DataTable dtBill = _DALSaleCarInOutBill.GetGetSaleCarInOutBill(argsInTrans, SaleCarInBillID))
        //        {
        //            DataRow drBill = dtBill.Rows[0];

        //            //生成新的入场记录
        //            t_BigID NewSaleCarInBillID;
        //            t_String NewSaleCarInBillCode;
        //            t_String NewSaleCarOutBillCode;
        //            t_DTSmall NewBillDate;
        //            this.InsertInBill(argsInTrans, out NewSaleCarInBillID, out NewSaleCarInBillCode, out NewBillDate,
        //                new t_BigID(drBill["CarID"]), NewItemID, NewReceiveType,
        //                NewCalculateType, new t_Float(drBill["CarTare"]), NewCustomerID,
        //                new t_String(drBill["Description"]), new t_Image(), new t_Image(), new t_Image(), new t_Image(), new t_ID());

        //            if (SaleCarOutBillID.Value > 0)//有出场磅单
        //            {
        //                t_BigID NewSaleCarOutBillID;
        //                if (IsPayMoney.Value == 1 && PayMoney.Value > 0)
        //                {
        //                    t_BigID ReceiveBillHeaderID;
        //                    t_String ReceiveBillCode;
        //                    _IBLLRPReceiveBillHeader.Insert(argsInTrans, out ReceiveBillHeaderID, out ReceiveBillCode,
        //                            new t_DTSmall(DateTime.Now), NewCustomerID, PayMoney, new t_String("充值来源：车号" + drBill["CarNum"].ToString().TrimEnd() + "现金充值"),
        //                            NewSaleCarInBillID, new t_BigID(), new t_ID(0));
        //                    _IBLLRPReceiveBillHeader.Approve(argsInTrans, ReceiveBillHeaderID);
        //                }

        //                //生成出场记录
        //                this.InsertOutBill(argsInTrans, out NewSaleCarOutBillID,out NewSaleCarOutBillCode, out NewBillDate, NewSaleCarInBillID, new t_BigID(drBill["CarID"]),
        //                   NewReceiveType, NewCalculateType, NewPrice, NewAmount, new t_Decimal(drBill["TotalWeight"]), new t_Decimal(drBill["SuttleWeight"]),
        //                   CustomerPayAmount, new t_String(drBill["Description"]),new t_ID(0));
        //            }
        //        }
                
        //        _DALSaleCarInOutBill.InsertChangeBill(argsInTrans, out TempSaleCarChangeBillID, SaleCarInBillID,
        //                ChangeDate, ChangeBy, ChangeDesc, ChangeDetail);
                
        //    };
        //    DBHelper.ExecInTrans(args, exec);
        //    SaleCarChangeBillID.Value = TempSaleCarChangeBillID.Value;
        //}

        //public void CopySaleBill(FactoryArgs args, t_BigID SaleCarInBillID, t_Decimal NewTotalWeight,
        //    out t_BigID NewSaleCarInBillID, out t_BigID NewSaleCarOutBillID, out t_String NewSaleCarInBillCode,out t_String NewSaleCarOutBillCode)
        //{
        //    NewSaleCarOutBillID = new t_BigID();
        //    NewSaleCarInBillID = new t_BigID();
        //    NewSaleCarInBillCode = new t_String();
        //    NewSaleCarOutBillCode = new t_String();
        //    t_String NewSaleCarInBillCode_temp = new t_String();
        //    t_String NewSaleCarOutBillCode_temp = new t_String();
        //    t_BigID NewSaleCarInBillID_temp = new t_BigID();
        //    t_BigID NewSaleCarOutBillID_temp = new t_BigID();
        //    DBHelper.ExecInTransDelegate exec = delegate (FactoryArgs argsInTrans)
        //    {
        //        t_Decimal CustomerPayAmount = new t_Decimal(0);
        //        using (DataTable dtBill = _DALSaleCarInOutBill.GetGetSaleCarInOutBill(argsInTrans, SaleCarInBillID))
        //        {
        //            DataRow drBill = dtBill.Rows[0];
        //            t_BigID SaleCarOutBillID = new t_BigID(drBill["SaleCarOutBillID"]);
        //            t_DTSmall BillDateIn = new t_DTSmall(drBill["BillDateIn"]);
        //            t_DTSmall BillDateOut = new t_DTSmall(drBill["BillDateOut"]);

        //            //生成新的入场记录
                    
        //            t_DTSmall NewBillDate;
        //            this.InsertInBill(argsInTrans, out NewSaleCarInBillID_temp, out NewSaleCarInBillCode_temp, out NewBillDate,
        //                new t_BigID(drBill["CarID"]), new t_BigID(drBill["ItemID"]),new t_ID(drBill["ReceiveType"]),
        //                new t_ID(drBill["CalculateType"]), new t_Float(drBill["CarTare"]), new t_BigID(drBill["CustomerID"]),
        //                new t_String(drBill["Description"]), new t_Image(), new t_Image(), new t_Image(), new t_Image(), new t_ID());

        //            #region -- 复制原单的入场图片 --
        //            string strDatePath = GetPicturePath(enImagePathType.InBillPath, (DateTime)BillDateIn.Value);
        //            string strInBillImage1_Old = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image1.jpg");
        //            string strInBillImage2_Old = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image2.jpg");
        //            string strInBillImage3_Old = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image3.jpg");
        //            string strInBillImage4_Old = Path.Combine(strDatePath, SaleCarInBillID.Value.ToString() + "_Image4.jpg");

        //            string strDatePath_New = GetPicturePath(enImagePathType.InBillPath, (DateTime)NewBillDate.Value);
        //            string strInBillImage1_New = Path.Combine(strDatePath_New, NewSaleCarInBillID_temp.Value.ToString() + "_Image1.jpg");
        //            string strInBillImage2_New = Path.Combine(strDatePath_New, NewSaleCarInBillID_temp.Value.ToString() + "_Image2.jpg");
        //            string strInBillImage3_New = Path.Combine(strDatePath_New, NewSaleCarInBillID_temp.Value.ToString() + "_Image3.jpg");
        //            string strInBillImage4_New = Path.Combine(strDatePath_New, NewSaleCarInBillID_temp.Value.ToString() + "_Image4.jpg");

        //            if (File.Exists(strInBillImage1_Old)&& !File.Exists(strInBillImage1_New))
        //            {
        //                File.Copy(strInBillImage1_Old, strInBillImage1_New);
        //            }
        //            if (File.Exists(strInBillImage2_Old) && !File.Exists(strInBillImage2_New))
        //            {
        //                File.Copy(strInBillImage2_Old, strInBillImage2_New);
        //            }
        //            if (File.Exists(strInBillImage3_Old) && !File.Exists(strInBillImage3_New))
        //            {
        //                File.Copy(strInBillImage3_Old, strInBillImage3_New);
        //            }
        //            if (File.Exists(strInBillImage4_Old) && !File.Exists(strInBillImage4_New))
        //            {
        //                File.Copy(strInBillImage4_Old, strInBillImage4_New);
        //            }

        //            #endregion -- 复制原单的入场图片 --

        //            if (SaleCarOutBillID.Value > 0)//有出场磅单
        //            {
        //                decimal decPrice = LBConverter.ToDecimal(drBill["Price"]);
        //                decimal decTare = LBConverter.ToDecimal(drBill["CarTare"]);
        //                decimal decSuttleWeight =(decimal)NewTotalWeight.Value- decTare;
        //                decimal decNewAmount = decPrice * decSuttleWeight;
        //                //生成出场记录
        //                this.InsertOutBill(argsInTrans, out NewSaleCarOutBillID_temp, out NewSaleCarOutBillCode_temp, out NewBillDate, NewSaleCarInBillID_temp, new t_BigID(drBill["CarID"]),
        //                   new t_ID(drBill["ReceiveType"]), new t_ID(drBill["CalculateType"]),new t_Decimal( drBill["Price"] ), new t_Decimal(decNewAmount), NewTotalWeight, new t_Decimal(decSuttleWeight),
        //                   CustomerPayAmount, new t_String(drBill["Description"]),new t_ID(0));

        //                #region -- 复制原单的入场图片 --
        //                string strDateOutPath = GetPicturePath(enImagePathType.OutBillPath, (DateTime)BillDateOut.Value);
        //                string strOutBillImage1_Old = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image1.jpg");
        //                string strOutBillImage2_Old = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image2.jpg");
        //                string strOutBillImage3_Old = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image3.jpg");
        //                string strOutBillImage4_Old = Path.Combine(strDatePath, SaleCarOutBillID.Value.ToString() + "_Image4.jpg");

        //                string strDateOutPath_New = GetPicturePath(enImagePathType.OutBillPath, (DateTime)NewBillDate.Value);
        //                string strOutBillImage1_New = Path.Combine(strDateOutPath_New, NewSaleCarOutBillID_temp.Value.ToString() + "_Image1.jpg");
        //                string strOutBillImage2_New = Path.Combine(strDateOutPath_New, NewSaleCarOutBillID_temp.Value.ToString() + "_Image2.jpg");
        //                string strOutBillImage3_New = Path.Combine(strDateOutPath_New, NewSaleCarOutBillID_temp.Value.ToString() + "_Image3.jpg");
        //                string strOutBillImage4_New = Path.Combine(strDateOutPath_New, NewSaleCarOutBillID_temp.Value.ToString() + "_Image4.jpg");

        //                if (File.Exists(strOutBillImage1_Old) && !File.Exists(strOutBillImage1_New))
        //                {
        //                    File.Copy(strOutBillImage1_Old, strOutBillImage1_New);
        //                }
        //                if (File.Exists(strOutBillImage2_Old) && !File.Exists(strOutBillImage2_New))
        //                {
        //                    File.Copy(strOutBillImage2_Old, strOutBillImage2_New);
        //                }
        //                if (File.Exists(strOutBillImage3_Old) && !File.Exists(strOutBillImage3_New))
        //                {
        //                    File.Copy(strOutBillImage3_Old, strOutBillImage3_New);
        //                }
        //                if (File.Exists(strOutBillImage4_Old) && !File.Exists(strOutBillImage4_New))
        //                {
        //                    File.Copy(strOutBillImage4_Old, strOutBillImage4_New);
        //                }

        //                #endregion -- 复制原单的入场图片 --
        //            }
        //        }
        //    };
        //    DBHelper.ExecInTrans(args, exec);
        //    NewSaleCarInBillCode.Value = NewSaleCarInBillCode_temp.Value;
        //    NewSaleCarOutBillCode.Value = NewSaleCarOutBillCode_temp.Value;
        //    NewSaleCarInBillID.Value = NewSaleCarInBillID_temp.Value;
        //    NewSaleCarOutBillID.Value = NewSaleCarOutBillID_temp.Value;
        //}

        //改单情况1处理方式：仅金额发生变更
        //public void ChangeBillDealAmount1(FactoryArgs args, t_BigID SaleCarInBillID, t_BigID CustomerID,t_String CarNum,
        //    t_Decimal NewPrice, t_Decimal NewAmount, t_Decimal OldPrice, t_Decimal OldAmount,
        //    t_Bool IsPayMoney,t_Decimal PayMoney)
        //{
        //    //新金额大于旧金额
        //    if (NewAmount.Value > OldAmount.Value)
        //    {
        //        if (IsPayMoney.Value == 1)//现金支付
        //        {
        //            if (PayMoney.Value <= 0)
        //            {
        //                throw new Exception("现金支付金额不能为0！");
        //            }

        //            t_BigID ReceiveBillHeaderID;
        //            t_String ReceiveBillCode;
        //            _IBLLRPReceiveBillHeader.Insert(args, out ReceiveBillHeaderID, out ReceiveBillCode,
        //                    new t_DTSmall(DateTime.Now), CustomerID, PayMoney, new t_String("充值来源：车号" + CarNum.Value + "现金充值"));
        //            _IBLLRPReceiveBillHeader.Approve(args, ReceiveBillHeaderID);

        //            //现金不足部分右客户账户扣除
        //            _DALSaleCarInOutBill.UpdateOutBillAmount(args, SaleCarInBillID, NewPrice, NewAmount);
        //        }
        //        else
        //        {
        //            _DALSaleCarInOutBill.UpdateOutBillAmount(args, SaleCarInBillID, NewPrice, NewAmount);
        //        }
        //    }
        //    else
        //    {
        //        //新金额小于旧金额，返还至客户账户
        //        _DALSaleCarInOutBill.UpdateOutBillAmount(args, SaleCarInBillID, NewPrice, NewAmount);
        //    }
        //}
        ////改单情况2处理方式：仅客户名称修改
        //public void ChangeBillDealAmount2(FactoryArgs args, t_BigID SaleCarInBillID, t_BigID NewCustomerID, t_BigID OldCustomerID)
        //{
        //    _DALSaleCarInOutBill.UpdateOutBillCustomer(args, SaleCarInBillID, NewCustomerID);
        //}

        ////改单改单情况3处理方式：客户名称以及金额发生变更
        //public void ChangeBillDealAmount3(FactoryArgs args, t_BigID SaleCarInBillID, t_BigID NewCustomerID, t_BigID OldCustomerID)
        //{
        //    _DALSaleCarInOutBill.UpdateOutBillCustomer(args, SaleCarInBillID, NewCustomerID);

        //}
    }

    public enum enImagePathType
    {
        InBillPath,
        OutBillPath
    }
}
