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
    public partial class frmSupplierEdit : LBUIPageBase
    {
        //long mlCustomerID;
        long mlSupplierID;
        public frmSupplierEdit(long lSupplierID)
        {
            InitializeComponent();

            mlSupplierID = lSupplierID;
            //mlCustomerID = lCustomerID;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            ReadFieldValue();

            SetButtonStatus();
        }

        #region -- 根据客户状态显示或者隐藏相关按钮 --

        private void SetButtonStatus()
        {
            this.btnSave.Visible = true;
            this.btnDelete.Visible = true;
            this.btnAdd.Visible = true;

            if (mlSupplierID == 0)
            {
                this.btnSave.Visible = true;
                this.btnDelete.Visible = false;
                this.btnAdd.Visible = false;

                ClearFieldValue();
            }
        }

        private void ClearFieldValue()
        {
            this.txtSupplierCode.Text = "";
            this.txtSupplierName.Text = "";
            this.cbIsForbidden.Checked = false;
            mlSupplierID = 0;
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
                
                int iSPType = 20600;
                if (mlSupplierID > 0)
                {
                    iSPType = 20601;
                }

                LBDbParameterCollection parmCol = new LBDbParameterCollection();
                parmCol.Add(new LBParameter("SupplierID", enLBDbType.Int64, mlSupplierID));
                parmCol.Add(new LBParameter("SupplierName", enLBDbType.String, this.txtSupplierName.Text));
                parmCol.Add(new LBParameter("IsForbidden", enLBDbType.Int16, (this.cbIsForbidden.Checked?1:0)));

                DataSet dsReturn;
                Dictionary<string, object> dictValue;
                ExecuteSQL.CallSP(iSPType, parmCol, out dsReturn, out dictValue);
                if (dictValue.ContainsKey("SupplierID"))
                {
                    mlSupplierID = LBConverter.ToInt64(dictValue["SupplierID"]);
                }
                if (dictValue.ContainsKey("SupplierCode"))
                {
                    this.txtSupplierCode.Text = dictValue["SupplierCode"].ToString();
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
                if (LB.WinFunction.LBCommonHelper.ConfirmMessage("是否确认删除该供应商？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (mlSupplierID > 0)
                    {
                        LBDbParameterCollection parmCol = new LBDbParameterCollection();
                        parmCol.Add(new LBParameter("SupplierID", enLBDbType.Int64, mlSupplierID));
                        DataSet dsReturn;
                        Dictionary<string, object> dictValue;
                        ExecuteSQL.CallSP(20602, parmCol, out dsReturn, out dictValue);
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
            if (mlSupplierID > 0)
            {
                DataTable dtSupplier = ExecuteSQL.CallView(139, "", "SupplierID=" + mlSupplierID, "");
                if (dtSupplier.Rows.Count > 0)
                {
                    DataRow drSupplier = dtSupplier.Rows[0];

                    this.txtSupplierName.Text = drSupplier["SupplierName"].ToString();
                    this.txtSupplierCode.Text = drSupplier["SupplierCode"].ToString();
                    this.cbIsForbidden.Checked = LBConverter.ToBoolean(drSupplier["IsForbidden"]);
                }
            }
        }

        #endregion --  读取界面参数值 --

    }
}
