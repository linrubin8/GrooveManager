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
using LB.Controls.Args;
using LB.Controls.Report;
using LB.Page.Helper;

namespace LB.MI
{
    public partial class frmCustomerManager : LBUIPageBase
    {
        public frmCustomerManager()
        {
            InitializeComponent();
            this.grdMain.CellDoubleClick += GrdMain_CellDoubleClick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadDataSource();
            this.ctlSearcher1.SetGridView(this.grdMain, "CustomerName");
        }

        private void LoadDataSource()
        {
            string strFilter = this.ctlSearcher1.GetFilter();
            DataTable dtUser = ExecuteSQL.CallView(112, "", strFilter, "");
            this.grdMain.DataSource = dtUser.DefaultView;
        }

        private void GrdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataRowView drvSelect = this.grdMain.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    long lCustomerID = drvSelect["CustomerID"] == DBNull.Value ?
                        0 : Convert.ToInt64(drvSelect["CustomerID"]);
                    if (lCustomerID > 0)
                    {
                        frmCustomerEdit frm = new frmCustomerEdit(lCustomerID);
                        LBShowForm.ShowDialog(frm);

                        LoadDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        #region -- 添加用户 --

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerEdit frmEdit = new frmCustomerEdit(0);
                LBShowForm.ShowDialog(frmEdit);
                LoadDataSource();
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

        private void btnReflesh_Click(object sender, EventArgs e)
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

        private void btnOpenEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        #endregion -- 添加用户 --

        #region -- 报表 --

        protected override void OnInitToolStripControl(ToolStripReportArgs args)
        {
            args.LBToolStrip = skinToolStrip1;
            args.ReportTypeID = 3;//客户管理
            base.OnInitToolStripControl(args);

        }

        protected override void OnReportRequest(ReportRequestArgs args)
        {
            base.OnReportRequest(args);
            DataTable dtSource = ((DataView)this.grdMain.DataSource).Table.Copy();
            dtSource.TableName = "T003";
            DataSet dsSource = new DataSet("Report");
            dsSource.Tables.Add(dtSource);
            args.DSDataSource = dsSource;
        }

        #endregion
    }
}
