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
using LB.Page.Helper;
using LB.Controls.Args;
using LB.Controls.Report;

namespace LB.MI.MI
{
    public partial class frmSaleCarInOutBillManager : LBUIPageBase
    {
        public frmSaleCarInOutBillManager()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.grdMain.LBLoadConst();
            InitData();
            LoadAllSalesBill();//磅单清单

            this.grdMain.CellDoubleClick += GrdMain_CellDoubleClick;
        }

        private void InitData()
        {
            DataTable dtCustom = ExecuteSQL.CallView(139, "", "", "SupplierName asc");
            this.txtSupplierID.TextBox.LBViewType = 139;
            this.txtSupplierID.TextBox.LBSort = "SupplierName asc";
            this.txtSupplierID.TextBox.IDColumnName = "SupplierID";
            this.txtSupplierID.TextBox.TextColumnName = "SupplierName";
            this.txtSupplierID.TextBox.PopDataSource = dtCustom.DefaultView;

            DataTable dtCar = ExecuteSQL.CallView(113, "", "", "SortLevel desc,CarNum asc");
            this.txtCarID.TextBox.LBViewType = 113;
            this.txtCarID.TextBox.LBSort = "SortLevel desc,CarNum asc";
            this.txtCarID.TextBox.IDColumnName = "CarID";
            this.txtCarID.TextBox.TextColumnName = "CarNum";
            this.txtCarID.TextBox.PopDataSource = dtCar.DefaultView;
            
            this.txtBillTimeFrom.Text = "00:00:00";
            this.txtBillTimeTo.Text = "23:59:59";

            this.grdMain.Visible = true;
            this.grdMain.Dock = DockStyle.Fill;
            this.grdSumMain.Visible = false;
        }

        #region -- 双击打开清单  --

        private void GrdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    long lSaleCarInBillID = LBConverter.ToInt64(this.grdMain["SaleCarInBillID", e.RowIndex].Value);
                    if (lSaleCarInBillID > 0)
                    {
                        frmSaleCarInOutEdit frmEdit = new frmSaleCarInOutEdit(lSaleCarInBillID);
                        LBShowForm.ShowDialog(frmEdit);
                        LoadAllSalesBill();//磅单清单
                    }
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        #endregion -- 双击打开清单  --

        #region -- 查询磅单清单 --

        private void LoadAllSalesBill()
        {
            string strFilter = "";

            if (this.txtSupplierID.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "SupplierName like '%"+ this.txtSupplierID.Text + "%'";
            }

            if (this.txtCarID.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "CarNum like '%" + this.txtCarID.Text + "%'";
            }
            
            if (this.txtBillCode.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "SaleCarInBillCode like '%" + this.txtBillCode.Text + "%'";
            }

            if (this.txtOutBillCraeteBy.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "CreateByIn like '%" + this.txtOutBillCraeteBy.Text + "%'";
            }

            if (this.txtBillDateFrom.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "CreateTimeIn >= '" +Convert.ToDateTime( this.txtBillDateFrom.Text).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(this.txtBillTimeFrom.Text).ToString("HH:mm:ss") + "'";
            }

            if (this.txtBillDateTo.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "CreateTimeIn <= '" + Convert.ToDateTime(this.txtBillDateTo.Text).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(this.txtBillTimeTo.Text).ToString("HH:mm:ss") + "'";
            }
            
            if (rbCanceled.Checked)//已作废
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "IsCancel =1";
            }
            if (rbUnCancel.Checked)//未作废
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "isnull(IsCancel,0) =0";
            }
            
            // strFilter += "(BillDateIn>='" + dtBillDateFrom.ToString("yyyy-MM-dd") + "' and BillDateIn<='" + dtBillDateTo.AddDays(1).ToString("yyyy-MM-dd") + "')";
            DataTable dtBill = ExecuteSQL.CallView(128, "", strFilter, "SaleCarInBillID desc");

            decimal decTotalWeight = 0;
            decimal decCarTare = 0;
            decimal decSuttleWeight = 0;
            decimal decAmount = 0;
            foreach (DataRow dr in dtBill.Rows)
            {
                decTotalWeight += LBConverter.ToDecimal(dr["TotalWeight"]);
                decCarTare += LBConverter.ToDecimal(dr["CarTare"]);
                decSuttleWeight += LBConverter.ToDecimal(dr["SuttleWeight"]);
            }

            this.txtTotalWeight.Text = (decTotalWeight / 1000).ToString("0.000");
            this.txtTareWeight.Text = (decCarTare / 1000).ToString("0.000");
            this.txtStuffWeight.Text = (decSuttleWeight / 1000).ToString("0.000");
            this.txtTotalAmount.Text = decAmount.ToString("0.00");
            this.txtTotalCar.Text = dtBill.Rows.Count.ToString();

            this.grdMain.DataSource = dtBill.DefaultView;

            string strSelectField = "sum(TotalWeight) as TotalWeight,sum(CarTare) as CarTare,sum(SuttleWeight) as SuttleWeight,count(1) as CarCount";
            string strGroupBy = "";

            if (this.cbSumCar.Checked)
            {
                if (strGroupBy != "")
                {
                    strGroupBy += ",";
                }
                strGroupBy += "CarNum";
                strSelectField += ",CarNum";
                //strSelectField += ",count(CarNum) as CarCount";
            }
            if (this.cbSumSupplier.Checked)
            {
                if (strGroupBy != "")
                {
                    strGroupBy += ",";
                }
                strGroupBy += "SupplierName";
                strSelectField += ",SupplierName";
            }
            
            this.grdSumMain.Columns["CarNumSum"].Visible = this.cbSumCar.Checked;
            this.grdSumMain.Columns["SupplierNameSum"].Visible = this.cbSumSupplier.Checked;

            DataTable dtSumBill = ExecuteSQL.CallDirectSQL("select "+ strSelectField + " from View_SaleCarInBill "+
                (strFilter==""?"":"where "+ strFilter)+
                (strGroupBy==""?"":" group by "+ strGroupBy));

            this.grdSumMain.DataSource = dtSumBill;
        }

        #endregion

        #region -- 按钮事件 --

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataRow> lstSelected = ReadSelectedRows();

            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnUnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnUnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                
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
                LoadAllSalesBill();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.grdMain.Visible = true;
                this.grdMain.Dock = DockStyle.Fill;
                this.grdSumMain.Visible = false;
                LoadAllSalesBill();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnSumSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.grdMain.Visible = false;
                this.grdSumMain.Visible = true;
                this.grdSumMain.Dock = DockStyle.Fill;
                LoadAllSalesBill();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        #endregion -- 按钮事件 --

        private List<DataRow> ReadSelectedRows()
        {
            List<DataRow> lstSelected = new List<DataRow>();
            foreach(DataGridViewRow dgvr in this.grdMain.SelectedRows)
            {
                DataRow dr = ((DataRowView)dgvr.DataBoundItem).Row;
                lstSelected.Add(dr);
            }
            return lstSelected;
        }

        #region -- 报表 --

        protected override void OnInitToolStripControl(ToolStripReportArgs args)
        {
            args.LBToolStrip = skinToolStrip1;
            args.ReportTypeID = 9;//磅单查询清单
            base.OnInitToolStripControl(args);

        }

        protected override void OnReportRequest(ReportRequestArgs args)
        {
            base.OnReportRequest(args);
            DataTable dtSource = ((DataView)this.grdMain.DataSource).Table.Copy();
            dtSource.TableName = "T009";
            DataSet dsSource = new DataSet("Report");
            dsSource.Tables.Add(dtSource);
            args.DSDataSource = dsSource;
        }

        #endregion

        private void btnAddInBill_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddInBill frm = new LB.MI.frmAddInBill();
                LBShowForm.ShowDialog(frm);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnAddOutBill_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddOutBill frm = new LB.MI.frmAddOutBill();
                LBShowForm.ShowDialog(frm);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dvResult = this.grdMain.DataSource as DataView;
                //ExcelHelper.DataSetToExcel(dvResult.ToTable(), true);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
    }
}
