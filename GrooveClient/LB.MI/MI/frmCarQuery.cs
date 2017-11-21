﻿using System;
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

namespace LB.MI.MI
{
    public partial class frmCarQuery : LBUIPageBase
    {
        public List<DataRow> LstReturn = new List<DataRow>();
        private long mlCustomerID;
        public frmCarQuery(long lCustomerID)
        {
            InitializeComponent();
            mlCustomerID = lCustomerID;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (mlCustomerID > 0)
            {
                this.txtCustomerID.TextBox.SelectedItemID = mlCustomerID;
            }

            LoadDataSource();

            this.txtCustomerID.TextBox.TextChanged += TextBox_TextChanged;
            this.txtCarNum.SkinTxt.TextChanged += SkinTxt_TextChanged;
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
            if (this.txtCustomerID.TextBox.Text.TrimEnd() != "")
            {
                strFilter = "CustomerName like '%"+ this.txtCustomerID.TextBox.Text.TrimEnd() + "%'";
            }
            if (this.txtCarNum.Text.TrimEnd() != "")
            {
                if (strFilter != "")
                    strFilter += " and ";
                strFilter += "CarNum like '%" + this.txtCarNum.Text.TrimEnd() + "%'";
            }
            DataTable dtDetail = ExecuteSQL.CallView(117, "", strFilter, "");
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
                PerformReturn();
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
    }
}
