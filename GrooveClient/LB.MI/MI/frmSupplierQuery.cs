using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LB.Controls;
using LB.Common;
using LB.WinFunction;
using LB.Page.Helper;

namespace LB.MI.MI
{
    public partial class frmSupplierQuery : LBUIPageBase
    {
        public List<DataRow> LstReturn = new List<DataRow>();
        public frmSupplierQuery()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadDataSource();

            this.grdMain.CellDoubleClick += GrdMain_CellDoubleClick;
        }

        private void SkinTxt_TextChanged(object sender, EventArgs e)
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

        private void TextBox_TextChanged(object sender, EventArgs e)
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

        private void LoadDataSource()
        {
            string strFilter = "";
            DataTable dtDetail = ExecuteSQL.CallView(139, "", strFilter, "");
            this.grdMain.DataSource = dtDetail.DefaultView;
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                PerformReturn();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void GrdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataRowView drvSelect = this.grdMain.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    long lSupplierID = drvSelect["SupplierID"] == DBNull.Value ?
                        0 : Convert.ToInt64(drvSelect["SupplierID"]);
                    if (lSupplierID > 0)
                    {
                        frmSupplierEdit frmCar = new frmSupplierEdit(lSupplierID);
                        LBShowForm.ShowDialog(frmCar);

                        LoadDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void PerformReturn()
        {

            if (this.grdMain.SelectedCells.Count == 0)
            {
                throw new Exception("请选择有效的物料行！");
            }
            else
            {
                DataGridViewCell dgvc = this.grdMain.SelectedCells[0];
                DataRowView drv = this.grdMain.Rows[dgvc.RowIndex].DataBoundItem as DataRowView;
                LstReturn.Add(drv.Row);
            }

            this.Close();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupplierEdit frmCar = new frmSupplierEdit(0);
                LBShowForm.ShowDialog(frmCar);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
    }
}
