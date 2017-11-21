using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LB.Controls;
using LB.WinFunction;
using LB.Common;

namespace LB.MI
{
    public partial class frmCarEdit : LBUIPageBase
    {
        //long mlCustomerID;
        private System.Windows.Forms.Timer mTimerFrare = null;
        long mlCarID;
        public frmCarEdit(long lCarID)
        {
            InitializeComponent();

            mlCarID = lCarID;
            //mlCustomerID = lCustomerID;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            DataTable dtSupplier = ExecuteSQL.CallView(139);//读取供应商信息
            DataRow drNew = dtSupplier.NewRow();
            drNew["SupplierName"] = "";
            dtSupplier.Rows.InsertAt(drNew, 0);

            DataTable dtCard = ExecuteSQL.CallView(138);//读取卡片信息
            drNew = dtCard.NewRow();
            drNew["CardName"] = "";
            dtCard.Rows.InsertAt(drNew, 0);

            this.txtSupplierID.DataSource = dtSupplier.DefaultView;//读取客户信息
            this.txtSupplierID.DisplayMember = "SupplierName";
            this.txtSupplierID.ValueMember = "SupplierID";

            this.txtCardID.DataSource = dtCard.DefaultView;//读取客户信息
            this.txtCardID.DisplayMember = "CardCode";
            this.txtCardID.ValueMember = "CardID";
            //if(mlCustomerID>0)
            //    this.txtSupplierID.SelectedValue = mlCustomerID;

            ReadFieldValue();

            SetButtonStatus();

            mTimerFrare = new System.Windows.Forms.Timer();
            mTimerFrare.Interval = 100;
            mTimerFrare.Enabled = true;
            mTimerFrare.Tick += mTimerFrare_Tick;
        }

        private void mTimerFrare_Tick(object sender, EventArgs e)
        {
            try
            {
                
                this.lblWeight.Text = LBSerialHelper.WeightValue.ToString();
            }
            catch (Exception ex)
            {

            }
        }
        

        #region -- 根据客户状态显示或者隐藏相关按钮 --

        private void SetButtonStatus()
        {
            this.btnSave.Visible = true;
            this.btnDelete.Visible = true;
            this.btnAdd.Visible = true;

            if (mlCarID == 0)
            {
                this.btnSave.Visible = true;
                this.btnDelete.Visible = false;
                this.btnAdd.Visible = false;

                ClearFieldValue();
            }
        }

        private void ClearFieldValue()
        {
            this.txtCarNum.Text = "";
            this.txtCarCode.Text = "";
            this.txtDefaultCarWeight.Text = "0";
            this.txtDescription.Text = "";
            this.txtSupplierID.Text = "";
            this.txtCardID.Text = "";
            mlCarID = 0;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFieldValue();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.VerifyTextBoxIsEmpty();//校验控件是否为空

                long lSupplierID = LBConverter.ToInt64(this.txtSupplierID.SelectedValue);
                long lCardID = LBConverter.ToInt64(this.txtCardID.SelectedValue);
                //先判断该卡片是否已绑定了其他车辆，提示用户是否取消绑定
                if (lCardID > 0)
                {
                    string strBindCarNum;
                    bool bolExists = this.GetCardRefCarInfo(lCardID, out strBindCarNum);
                    if (bolExists)
                    {
                        if(LB.WinFunction.LBCommonHelper.ConfirmMessage("该卡号已关联车牌【"+ strBindCarNum+"】，是否取消与该车牌的关联？","提示", MessageBoxButtons.YesNo)!= DialogResult.Yes)
                        {
                            return;
                        }
                    }
                }

                int iSPType = 13500;
                if (mlCarID > 0)
                {
                    iSPType = 13501;
                }

                LBDbParameterCollection parmCol = new LBDbParameterCollection();
                parmCol.Add(new LBParameter("SupplierID", enLBDbType.Int64, lSupplierID));
                parmCol.Add(new LBParameter("CardID", enLBDbType.Int64, lCardID));
                parmCol.Add(new LBParameter("CarID", enLBDbType.Int64, mlCarID));
                parmCol.Add(new LBParameter("CarNum", enLBDbType.String, this.txtCarNum.Text));
                parmCol.Add(new LBParameter("CarCode", enLBDbType.String, this.txtCarCode.Text));
                parmCol.Add(new LBParameter("Description", enLBDbType.String, this.txtDescription.Text));
                parmCol.Add(new LBParameter("DefaultCarWeight", enLBDbType.Decimal, LBConverter.ToDecimal(this.txtDefaultCarWeight.Text)));

                DataSet dsReturn;
                Dictionary<string, object> dictValue;
                ExecuteSQL.CallSP(iSPType, parmCol, out dsReturn, out dictValue);
                if (dictValue.ContainsKey("CarID"))
                {
                    mlCarID = LBConverter.ToInt64(dictValue["CarID"]);
                }
                if (dictValue.ContainsKey("CarCode"))
                {
                    this.txtCarCode.Text = dictValue["CarCode"].ToString();
                }
                LB.WinFunction.LBCommonHelper.ShowCommonMessage("保存成功！");
                SetButtonStatus();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (LB.WinFunction.LBCommonHelper.ConfirmMessage("是否确认删除该车辆？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (mlCarID > 0)
                    {
                        LBDbParameterCollection parmCol = new LBDbParameterCollection();
                        parmCol.Add(new LBParameter("CarID", enLBDbType.Int64, mlCarID));
                        DataSet dsReturn;
                        Dictionary<string, object> dictValue;
                        ExecuteSQL.CallSP(13502, parmCol, out dsReturn, out dictValue);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        #region --  读取界面参数值 --

        private void ReadFieldValue()
        {
            if (mlCarID > 0)
            {
                DataTable dtCar = ExecuteSQL.CallView(113, "", "CarID=" + mlCarID, "");
                if (dtCar.Rows.Count > 0)
                {
                    DataRow drCar = dtCar.Rows[0];

                    this.txtCarNum.Text = drCar["CarNum"].ToString();
                    this.txtCarCode.Text = drCar["CarCode"].ToString();
                    this.txtDescription.Text = drCar["Description"].ToString();
                    this.txtDefaultCarWeight.Text = drCar["DefaultCarWeight"].ToString();
                    this.txtCardID.SelectedValue = drCar["CardID"];
                    this.txtSupplierID.SelectedValue = drCar["SupplierID"];
                }
            }
        }

        #endregion --  读取界面参数值 --

        bool GetCardRefCarInfo(long lCardID,out string strBindCarNum)
        {
            bool bolExists = false;
            strBindCarNum = "";
            string strFilter = "";
            if (mlCarID > 0)
            {
                strFilter = "CardID = " + lCardID.ToString() + " and CarID<>" + mlCarID.ToString();
            }
            else
            {
                strFilter = "CardID = " + lCardID.ToString();
            }

            DataTable dtCar = ExecuteSQL.CallView(113, "", strFilter, "");
            if (dtCar.Rows.Count > 0)
            {
                bolExists = true;
                strBindCarNum = dtCar.Rows[0]["CarNum"].ToString().TrimEnd();
            }
            return bolExists;
        }


        private bool ReadTareWeight()
        {
            VerifyDeviceIsSteady();//校验地磅数值是否稳定以及红外线对射是否正常

            decimal decWeight = LBConverter.ToDecimal(lblWeight.Text);//读皮重
            if (decWeight == 0)
            {
                throw new Exception("当前【皮重】读数值为0！");
            }
            else
            {
                this.txtDefaultCarWeight.Text = decWeight.ToString("0");
                return true;
            }
        }

        //判断地磅数值是否稳定以及红外线设备是否报警
        private void VerifyDeviceIsSteady()
        {
            if (!LBSerialHelper.IsSteady)
            {
                throw new Exception("地数值未稳定！");
            }
        }

        private void lbToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ReadTareWeight();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
    }
}
