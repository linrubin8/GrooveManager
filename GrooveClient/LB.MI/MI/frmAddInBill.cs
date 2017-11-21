using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LB.WinFunction;
using LB.Common;
using LB.Controls;
using System.Threading;

namespace LB.MI
{
    public partial class frmAddInBill : LBUIPageBase
    {
        public frmAddInBill()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitTextDataSource();
        }

        #region -- Init TextBox DataSource --

        private void InitTextDataSource()
        {
            DataTable dtCustom = ExecuteSQL.CallView(139, "", "", "");
            this.txtSupplierID.TextBox.LBViewType = 139;
            this.txtSupplierID.TextBox.IDColumnName = "SupplierID";
            this.txtSupplierID.TextBox.TextColumnName = "SupplierName";
            this.txtSupplierID.TextBox.PopDataSource = dtCustom.DefaultView;

            DataTable dtCar = ExecuteSQL.CallView(113, "", "", "SortLevel desc,CarNum asc");
            this.txtCarID.TextBox.LBViewType = 113;
            this.txtCarID.TextBox.LBSort = "SortLevel desc,CarNum asc";
            this.txtCarID.TextBox.IDColumnName = "CarID";
            this.txtCarID.TextBox.TextColumnName = "CarNum";
            this.txtCarID.TextBox.PopDataSource = dtCar.DefaultView;

            this.txtSupplierID.TextBox.IsAllowNotExists = true;
            this.txtCarID.TextBox.IsAllowNotExists = true;

            this.txtCarID.TextBox.TextChanged += CarTextBox_TextChanged;
            this.txtCarTare.TextChanged += TxtCarTare_TextChanged;
            this.txtTotalWeight.TextChanged += TxtCarTare_TextChanged;
        }

        private void TxtCarTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalWeight();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void CalWeight()
        {
            decimal decTotalWeight = LBConverter.ToDecimal(this.txtTotalWeight.Text);
            decimal decCarTare = LBConverter.ToDecimal(this.txtCarTare.Text);
            this.txtSuttleWeight.Text = (decTotalWeight - decCarTare).ToString("0");
        }

        //选择车辆触发事件
        private void CarTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strCarNum = this.txtCarID.TextBox.Text.ToString();
                long lCarID = 0;
                decimal decDefaultCarWeight = 0;
                #region -- 读取车辆ID号 --
                using (DataTable dtCar = ExecuteSQL.CallView(117, "CarID,SupplierID,DefaultCarWeight", "CarNum='" + strCarNum + "'", ""))
                {
                    if (dtCar.Rows.Count > 0)
                    {
                        lCarID = LBConverter.ToInt64(dtCar.Rows[0]["CarID"]);
                        decDefaultCarWeight = LBConverter.ToInt64(dtCar.Rows[0]["DefaultCarWeight"]);
                    }
                }
                #endregion -- 读取车辆ID号 --

                if (lCarID > 0)//如果存在该车辆
                {
                    this.txtCarTare.Text = LBConverter.ToString(decDefaultCarWeight);
                }
                else
                {
                    this.txtCarTare.Text = "";
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        #endregion

        private long SaveInBill()
        {
            Dictionary<string, double> dictTest = new Dictionary<string, double>();
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            long lSaleCarInBillID = 0;
            long lCarID = LBConverter.ToInt64(this.txtCarID.TextBox.SelectedItemID);
            long lSupplierID = LBConverter.ToInt64(this.txtSupplierID.TextBox.SelectedItemID);
            decimal decCarTare = LBConverter.ToDecimal(this.txtCarTare.Text);
            decimal decTotalWeight = LBConverter.ToDecimal(this.txtTotalWeight.Text);
            decimal decSuttleWeight = LBConverter.ToDecimal(this.txtSuttleWeight.Text);
            DateTime dtDate = Convert.ToDateTime(txtBillDateIn.Text+" "+this.txtBillTimeIn.Text);
            if (decCarTare == 0)
            {
                throw new Exception("当前【皮重】值为0，无法保存！");
            }
            if (decTotalWeight == 0)
            {
                throw new Exception("当前【毛重】值为0，无法保存！");
            }
            if (decSuttleWeight <= 0)
            {
                throw new Exception("当前【净重】值为0，无法保存！");
            }

            LBDbParameterCollection parmCol = new LBDbParameterCollection();
            parmCol.Add(new LBParameter("SaleCarInBillID", enLBDbType.Int64, 0));
            parmCol.Add(new LBParameter("SaleCarInBillCode", enLBDbType.String, ""));
            parmCol.Add(new LBParameter("BillDate", enLBDbType.DateTime, dtDate));
            parmCol.Add(new LBParameter("CarID", enLBDbType.Int64, lCarID));
            parmCol.Add(new LBParameter("SupplierID", enLBDbType.Int64, lSupplierID));
            parmCol.Add(new LBParameter("CarTare", enLBDbType.Decimal, decCarTare));
            parmCol.Add(new LBParameter("TotalWeight", enLBDbType.Decimal, decTotalWeight));
            parmCol.Add(new LBParameter("SuttleWeight", enLBDbType.Decimal, decTotalWeight - decCarTare));
            parmCol.Add(new LBParameter("CardCode", enLBDbType.String, ""));

            DataSet dsReturn;
            Dictionary<string, object> dictValue;
            ExecuteSQL.CallSP(14100, parmCol, out dsReturn, out dictValue);
            if (dictValue.ContainsKey("SaleCarInBillID"))
            {
                lSaleCarInBillID = LBConverter.ToInt64(dictValue["SaleCarInBillID"]);
            }

            return lSaleCarInBillID;
        }

        private void VerifyTextBoxIsEmpty()
        {
            long lCarID = LBConverter.ToInt64(this.txtCarID.TextBox.SelectedItemID);
            long lSupplierID = LBConverter.ToInt64(this.txtSupplierID.TextBox.SelectedItemID);

            if (lCarID == 0)
            {
                throw new Exception("车号不能为空或者该车号不存在！");
            }
            if (lSupplierID == 0)
            {
                throw new Exception("供应商不能为空或者该供应商不存在！");
            }

            if (this.txtAddReason.Text.TrimEnd() == "")
            {
                throw new Exception("手工录入原因不能为空！");
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                VerifyTextBoxIsEmpty();

                long lSaleCarInBillID= SaveInBill();

                if (lSaleCarInBillID > 0)
                {
                    LB.WinFunction.LBCommonHelper.ShowCommonMessage("入场记录生成成功！");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnSaveAndAdd_Click(object sender, EventArgs e)
        {
            try
            {
                VerifyTextBoxIsEmpty();

                long lSaleCarInBillID = SaveInBill();

                if (lSaleCarInBillID > 0)
                {
                    this.txtTotalWeight.Text = "";
                    this.txtCarTare.Text = "";
                    this.txtCarID.TextBox.Text = "";
                    this.txtSupplierID.TextBox.Text = "";
                    this.txtSaleCarInBillCode.Text = "";
                    this.txtAddReason.Text = "";
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
    }
}
