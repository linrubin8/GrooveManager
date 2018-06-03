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

namespace LB.SysConfig.SysConfig
{
    public partial class frmSysConfig : LBUIPageBase
    {
        public frmSysConfig()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ReadSysConfigValue();

        }

        private void ReadSysConfigValue()
        {
            SystemConfigValue.ReadAllConfigValue();
            this.txtSysReadCardLimit.Text = SystemConfigValue.SysReadCardLimit.ToString();
        }

        private void SaveSysConfigValue()
        {
            DataTable dtSPIN = new DataTable();
            dtSPIN.Columns.Add("SysConfigFieldName", typeof(string));
            dtSPIN.Columns.Add("SysConfigValue", typeof(string));
            
            DataRow drNew = dtSPIN.NewRow();
            drNew["SysConfigFieldName"] = "SysReadCardLimit";
            drNew["SysConfigValue"] = this.txtSysReadCardLimit.Text;
            dtSPIN.Rows.Add(drNew);
            DataSet dsReturn;
            DataTable dtResult;
            ExecuteSQL.CallSP(14300, dtSPIN, out dsReturn, out dtResult);

            ReadSysConfigValue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSysConfigValue();

                LB.WinFunction.LBCommonHelper.ShowCommonMessage("保存成功");
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
    }
}
