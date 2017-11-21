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
using LB.Common.Enum;
using System.IO;
using System.Diagnostics;

namespace LB.MI.MI
{
    public partial class frmCardManager : LBUIPageBase
    {
        public List<DataRow> LstReturn = new List<DataRow>();
        public frmCardManager()
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
            DataTable dtDetail = ExecuteSQL.CallView(138, "", strFilter, "");
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
        
        private void GrdMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataRowView drvSelect = this.grdMain.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    long lCardID = drvSelect["CardID"] == DBNull.Value ?
                        0 : Convert.ToInt64(drvSelect["CardID"]);
                    if (lCardID > 0)
                    {
                        string strActionType = "ActionType=" + (int)enActionType.CardEdit;
                        string strIpAddress = "Url=" + RemotingObject.GetIPAddress();
                        string strCardID = "CardID="+ lCardID;

                        string strPath = Path.Combine(Application.StartupPath, "CardMain", "LB.CardMain.exe");
                        Process proc = Process.Start(strPath, strActionType + " " + strIpAddress + " " + strCardID);
                        if (proc != null)
                        {
                            proc.WaitForExit();

                        }

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
        
        private void btnAddCard_Click(object sender, EventArgs e)
        {
            try
            {
                frmCardEdit frmCard = new frmCardEdit(0);
                LBShowForm.ShowDialog(frmCard);

                PerformReturn();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
    }
}
