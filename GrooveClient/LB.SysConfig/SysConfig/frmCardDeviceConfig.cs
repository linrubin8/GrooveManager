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
using System.IO.Ports;
using LB.Page.Helper;

namespace LB.SysConfig.SysConfig
{
    public partial class frmCardDeviceConfig : LBUIPageBase
    {
        public frmCardDeviceConfig()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            InitSerialData();
            SetFieldValue();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int iReadSerialBaud = LBConverter.ToInt32(this.txtReadSerialBaud.Text);
                string strReadSerialName = this.txtReadSerialName.SelectedValue==null?"": this.txtReadSerialName.SelectedValue.ToString();
                string strWriteSerialName = this.txtWriteSerialName.SelectedValue == null ? "" : this.txtWriteSerialName.SelectedValue.ToString();
                LBDbParameterCollection parmCol = new LBDbParameterCollection();
                parmCol.Add(new LBParameter("ReadCardSerialCOM", enLBDbType.String, strReadSerialName));
                parmCol.Add(new LBParameter("WriteCardSerialCOM", enLBDbType.String, strWriteSerialName));
                parmCol.Add(new LBParameter("ReadCardBaud", enLBDbType.Int32, iReadSerialBaud));
                parmCol.Add(new LBParameter("MachineName", enLBDbType.String, LoginInfo.MachineName));
                parmCol.Add(new LBParameter("UseReadCard", enLBDbType.Int32, (this.cbUseReadCard.Checked?1:0)));
                parmCol.Add(new LBParameter("UseWriteCard", enLBDbType.Int32, (this.cbUseWriteCard.Checked ? 1 : 0)));
                parmCol.Add(new LBParameter("ConnectType", enLBDbType.Int32, (this.rbNet.Checked ? 1 : 0)));
                parmCol.Add(new LBParameter("IPAddress", enLBDbType.String, this.txtIPAddress.Text));
                parmCol.Add(new LBParameter("IPPort", enLBDbType.Int32, LBConverter.ToInt32(this.txtPort.Text)));
                DataSet dsReturn;
                Dictionary<string, object> dictValue;
                ExecuteSQL.CallSP(20503, parmCol, out dsReturn, out dictValue);

                LBCardHelper.StartSerial(enCardType.ReadCard);
                LB.WinFunction.LBCommonHelper.ShowCommonMessage("保存成功！");
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void SetFieldValue()
        {
            DataTable dtDesc = ExecuteSQL.CallView(140, "", "MachineName='" + LoginInfo.MachineName + "'", "");
            if (dtDesc.Rows.Count > 0)
            {
                this.txtReadSerialName.SelectedValue = dtDesc.Rows[0]["ReadCardSerialCOM"].ToString().TrimEnd();
                this.txtWriteSerialName.SelectedValue = dtDesc.Rows[0]["WriteCardSerialCOM"].ToString().TrimEnd();
                this.txtReadSerialBaud.Text = LBConverter.ToInt32(dtDesc.Rows[0]["ReadCardBaud"]).ToString();
                this.cbUseReadCard.Checked = LBConverter.ToInt32(dtDesc.Rows[0]["UseReadCard"]) == 1 ? true : false;
                this.cbUseWriteCard.Checked = LBConverter.ToInt32(dtDesc.Rows[0]["UseWriteCard"]) == 1 ? true : false;
                this.rbNet.Checked = LBConverter.ToInt32(dtDesc.Rows[0]["ConnectType"]) == 1 ? true : false;
                this.txtIPAddress.Text = dtDesc.Rows[0]["IPAddress"].ToString();
                this.txtPort.Text = dtDesc.Rows[0]["IPPort"].ToString();
            }
        }

        #region-- 初始化串口数据 --

        private void InitSerialData()
        {
            DataTable dtPort = new DataTable();
            dtPort.Columns.Add("PortName", typeof(string));

            string[] ArryPort = SerialPort.GetPortNames();
            for (int i = 0; i < ArryPort.Length; i++)
            {
                DataRow drNew = dtPort.NewRow();
                drNew["PortName"] = ArryPort[i];
                dtPort.Rows.Add(drNew);
            }
            dtPort.Rows.InsertAt(dtPort.NewRow(), 0);

            this.txtReadSerialName.DataSource = dtPort.Copy().DefaultView;
            this.txtReadSerialName.DisplayMember = "PortName";
            this.txtReadSerialName.ValueMember = "PortName";

            this.txtWriteSerialName.DataSource = dtPort.Copy().DefaultView;
            this.txtWriteSerialName.DisplayMember = "PortName";
            this.txtWriteSerialName.ValueMember = "PortName";
            //if (ArryPort.Length > 0)
            //    this.txtReadSerialName.SelectedIndex = 0;


        }

        #endregion

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            frmInfraredDeviceConnectPic frmConnect = new SysConfig.frmInfraredDeviceConnectPic();
            LBShowForm.ShowDialog(frmConnect);
        }
    }
}
