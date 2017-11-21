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

namespace LB.SysConfig
{
    public partial class frmCardLogManager : LBUIPageBase
    {
        public frmCardLogManager()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.txtLogTimeFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txtLogTimeTo.Text = DateTime.Now.ToString("yyyy-MM-dd");

            LoadDataSource();
        }

        private void LoadDataSource()
        {
            string strFilter = "";
            
            if (this.txtLogTimeFrom.Text.TrimEnd() != "")
            {
                DateTime dtFrom = Convert.ToDateTime(this.txtLogTimeFrom.Text.TrimEnd());
                if (strFilter != "")
                    strFilter += " and ";
                strFilter += " SteadyWeightTime >= '" + dtFrom.ToString("yyyy-MM-dd") + "'";
            }

            if (this.txtLogTimeTo.Text.TrimEnd() != "")
            {
                DateTime dtTo = Convert.ToDateTime(this.txtLogTimeTo.Text.TrimEnd());
                if (strFilter != "")
                    strFilter += " and ";
                strFilter += " SteadyWeightTime< '" + dtTo.AddDays(1).ToString("yyyy-MM-dd") + "'";
            }
            DataTable dtLog = ExecuteSQL.CallView(141,"", strFilter, "SteadyWeightTime asc");
            this.grdMain.DataSource = dtLog.DefaultView;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDataSource();
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
                if(this.grdMain.SelectedRows!=null&& this.grdMain.SelectedRows.Count > 0)
                {
                    string strSysLogID = "";
                    foreach (DataGridViewRow dgvr in this.grdMain.SelectedRows)
                    {
                        long lSysLogID = dgvr.Cells["SysLogID"].Value==DBNull.Value?
                            0:Convert.ToInt64(dgvr.Cells["SysLogID"].Value);
                        if (lSysLogID > 0)
                        {
                            if (strSysLogID != "")
                                strSysLogID += ",";
                            strSysLogID += lSysLogID;
                        }
                    }

                    if (strSysLogID != "")
                    {
                        if (LB.WinFunction.LBCommonHelper.ConfirmMessage("确认删除日志？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            LBDbParameterCollection parmCol = new LBDbParameterCollection();
                            parmCol.Add(new LBParameter("SysLogIDStr", enLBDbType.String, strSysLogID));
                            DataSet dsReturn;
                            Dictionary<string, object> dictValue;
                            ExecuteSQL.CallSP(13001, parmCol, out dsReturn, out dictValue);
                            LoadDataSource();
                        }
                    }
                }
                else
                {
                    LB.WinFunction.LBCommonHelper.ShowCommonMessage("请删除需要删除的日志行！");
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

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
    }
}
