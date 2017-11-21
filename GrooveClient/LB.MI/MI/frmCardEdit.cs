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
    public partial class frmCardEdit : LBUIPageBase
    {
        long mlCardID;
        public frmCardEdit(long lCardID)
        {
            InitializeComponent();

            mlCardID = lCardID;
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

            if (mlCardID == 0)
            {
                this.btnSave.Visible = true;
                this.btnDelete.Visible = false;
                this.btnAdd.Visible = false;

                ClearFieldValue();
            }
        }

        private void ClearFieldValue()
        {
            this.txtCardName.Text = "";

            mlCardID = 0;
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

                string strCrrentCardCode= LBCardHelper.ReadCardCode();
                if (strCrrentCardCode == "")
                {
                    throw new Exception("请将卡片放置读卡器上，否则无法保存！");
                }

                if (strCrrentCardCode != this.txtCardCode.Text)
                {
                    if(LB.WinFunction.LBCommonHelper.ConfirmMessage("当前设置的卡号为【"+ strCrrentCardCode+"】，是否确认改写为【"+ this.txtCardCode.Text + "】?","提示", MessageBoxButtons.YesNo)==
                         DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        //将卡号写入卡片
                        string strMsg;
                        bool bolSuccess = LBCardHelper.WriteCardCode(this.txtCardCode.Text, out strMsg);
                        if (!bolSuccess)
                        {
                            throw new Exception("卡号写入失败，失败原因：" + strMsg);
                        }

                    }
                }

                
                int iSPType = 20500;
                if (mlCardID > 0)
                {
                    iSPType = 20501;
                }

                LBDbParameterCollection parmCol = new LBDbParameterCollection();
                parmCol.Add(new LBParameter("CardID", enLBDbType.Int64, mlCardID));
                parmCol.Add(new LBParameter("CardName", enLBDbType.String, this.txtCardName.Text));
                parmCol.Add(new LBParameter("CardCode", enLBDbType.String, this.txtCardCode.Text));
                DataSet dsReturn;
                Dictionary<string, object> dictValue;
                ExecuteSQL.CallSP(iSPType, parmCol, out dsReturn, out dictValue);
                if (dictValue.ContainsKey("CardID"))
                {
                    mlCardID = LBConverter.ToInt64(dictValue["CardID"]);
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
                if (LB.WinFunction.LBCommonHelper.ConfirmMessage("是否确认删除该卡片？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (mlCardID > 0)
                    {
                        LBDbParameterCollection parmCol = new LBDbParameterCollection();
                        parmCol.Add(new LBParameter("CardID", enLBDbType.Int64, mlCardID));
                        DataSet dsReturn;
                        Dictionary<string, object> dictValue;
                        ExecuteSQL.CallSP(20502, parmCol, out dsReturn, out dictValue);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtSourceCardCode.Text = LBCardHelper.ReadCardCode();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        #region --  读取界面参数值 --

        private void ReadFieldValue()
        {
            if (mlCardID > 0)
            {
                DataTable dtCard = ExecuteSQL.CallView(138, "", "CardID=" + mlCardID, "");
                if (dtCard.Rows.Count > 0)
                {
                    DataRow drCard = dtCard.Rows[0];

                    this.txtCardName.Text = drCard["CardName"].ToString();
                    this.txtCardCode.Text = drCard["CardCode"].ToString();
                }
            }
        }

        #endregion --  读取界面参数值 --

    }
}
