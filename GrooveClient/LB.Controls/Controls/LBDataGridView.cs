using CCWin.SkinControl;
using LB.Common;
using LB.WinFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace LB.Controls
{
    public partial class LBDataGridView : SkinDataGridView
    {
        public event DataGridViewCellEventHandler LBCellButtonClick;

        public LBDataGridView()
        {
            InitializeComponent();
            LBInitializeComponent();
        }

        public LBDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            LBInitializeComponent();
        }

        private void LBInitializeComponent()
        {
            this.CellClick += LBDataGridView_CellClick;
        }

        private void LBDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (this[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
                    {
                        DataGridViewColumn dc = this.Columns[e.ColumnIndex];
                        if (dc is LBDataGridViewButtonColumn)
                        {
                            LBDataGridViewButtonColumn buttonColumn = dc as LBDataGridViewButtonColumn;
                            if (buttonColumn.LBPermissionCode != "")
                            {
                                try
                                {
                                    LBPermission.VerifyUserPermission(buttonColumn.Text,buttonColumn.LBPermissionCode);
                                }
                                catch (Exception ex)
                                {
                                    LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
                                    return;
                                }
                            }
                        }
                        if (LBCellButtonClick != null)
                            LBCellButtonClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        public void LBLoadConst()
        {
            foreach(DataGridViewColumn dc in this.Columns)
            {
                if(dc is LBDataGridViewComboBoxColumn)
                {
                    LBDataGridViewComboBoxColumn lbComboBox = dc as LBDataGridViewComboBoxColumn;
                    if(lbComboBox.FieldName!=""&& lbComboBox.FieldName != null)
                    {
                        try
                        {
                            lbComboBox.DataSource = GetConstData(lbComboBox.FieldName);
                            lbComboBox.DisplayMember = "ConstText";
                            lbComboBox.ValueMember = "ConstValue";
                            lbComboBox.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        private static DataTable GetConstData(string strFieldName)
        {
            DataTable dtConst = ExecuteSQL.CallView(101, "ConstValue,ConstText", "FieldName='" + strFieldName + "'", "");
            return dtConst;
        }

        /// <summary>
        /// 隐藏相同信息的列值
        /// </summary>
        public void HiddenSaveColumnValue(params string[] columns)
        {
            List<string> lstColumns = new List<string>();
            foreach(string strColumn in columns)
            {
                if (this.Columns.Contains(strColumn))
                    lstColumns.Add(strColumn);
            }

            //bool bolIsFirst = true;//是否第一个匹配行
            string strFirshValue = "";
            foreach (DataGridViewRow dgvr in this.Rows)
            {
                string strKeyValue = "";
                foreach (string strColunn in lstColumns)
                {
                    if (strKeyValue != "")
                        strKeyValue += ";";
                    strKeyValue += dgvr.Cells[strColunn].Value.ToString().TrimEnd();
                }
                if(strFirshValue!= strKeyValue)
                {
                    strFirshValue = strKeyValue;
                    //bolIsFirst = true;
                }
                else
                {
                    foreach (string strColunn in lstColumns)
                    {
                        dgvr.Cells[strColunn].Value = DBNull.Value;
                    }
                }
            }
        }
    }
}
