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
using System.IO;
using System.Threading;
using LB.SysConfig.SysConfig;
using LB.Page.Helper;

namespace LB.SysConfig
{
    public partial class frmLogManager : LBUIPageBase
    {
        public frmLogManager()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.txtLogTimeFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //this.txtLogTimeTo.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txtBillTimeFrom.Text = "00:00:00";
            this.txtBillTimeTo.Text = "23:59:59";
            LoadDataSource();

            this.pbInCamera.DoubleClick += Pic_DoubleClick;
            this.pbInScreen.DoubleClick += Pic_DoubleClick;
            this.pbSteadyCamera.DoubleClick += Pic_DoubleClick;
            this.pbSteadyScreen.DoubleClick += Pic_DoubleClick;
            this.pbOutCamera.DoubleClick += Pic_DoubleClick;
            this.pbOutScreen.DoubleClick += Pic_DoubleClick;

            this.pbInCamera.SizeMode = this.pbInScreen.SizeMode =
            this.pbSteadyCamera.SizeMode = this.pbSteadyScreen.SizeMode =
            this.pbOutCamera.SizeMode = this.pbOutScreen.SizeMode =
                PictureBoxSizeMode.Zoom;
        }

        private void Pic_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                PictureBox pb = sender as PictureBox;
                frmDisneyBigPicture frm = new frmDisneyBigPicture(pb.Image);
                LBShowForm.ShowDialog(frm);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void LoadDataSource()
        {
            string strFilter = "";

            if (this.txtBillDateFrom.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "SteadyWeightTime >= '" + Convert.ToDateTime(this.txtBillDateFrom.Text).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(this.txtBillTimeFrom.Text).ToString("HH:mm:ss") + "'";
            }

            if (this.txtBillDateTo.Text != "")
            {
                if (strFilter != "")
                {
                    strFilter += " and ";
                }
                strFilter += "SteadyWeightTime <= '" + Convert.ToDateTime(this.txtBillDateTo.Text).ToString("yyyy-MM-dd") + " " + Convert.ToDateTime(this.txtBillTimeTo.Text).ToString("HH:mm:ss") + "'";
            }
            DataTable dtLog = ExecuteSQL.CallView(141, "", strFilter, "SteadyWeightTime asc");
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

        private void grdMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    long lWeightLogID = LBConverter.ToInt64(this.grdMain["WeightLogID", e.RowIndex].Value);
                    if (lWeightLogID > 0)
                    {
                        Thread thread = new Thread(ReadMonitoreImg);
                        thread.Start(lWeightLogID);
                    }
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void ReadMonitoreImg(object objWeightLogID)
        {
            try
            {
                long lWeightLogID = LBConverter.ToInt64(objWeightLogID);
                byte[] PicInWeightCamera = null;
                byte[] PicInWeightScreen = null;
                byte[] PicSteadyWeightCamera = null;
                byte[] PicSteadyWeightScreen = null;
                byte[] PicOutWeightCamera = null;
                byte[] PicOutWeightScreen = null;

                LBDbParameterCollection parmCol = new LBDbParameterCollection();
                parmCol.Add(new LBParameter("WeightLogID", enLBDbType.Int64, lWeightLogID));

                DataSet dsReturn;
                Dictionary<string, object> dictValue;
                ExecuteSQL.CallSP(14903, parmCol, out dsReturn, out dictValue);
                if (dictValue.ContainsKey("InWeightCamera"))
                {
                    PicInWeightCamera = dictValue["InWeightCamera"] as byte[];
                }
                if (dictValue.ContainsKey("InWeightScreen"))
                {
                    PicInWeightScreen = dictValue["InWeightScreen"] as byte[];
                }
                if (dictValue.ContainsKey("SteadyWeightCamera"))
                {
                    PicSteadyWeightCamera = dictValue["SteadyWeightCamera"] as byte[];
                }
                if (dictValue.ContainsKey("SteadyWeightScreen"))
                {
                    PicSteadyWeightScreen = dictValue["SteadyWeightScreen"] as byte[];
                }
                if (dictValue.ContainsKey("OutWeightCamera"))
                {
                    PicOutWeightCamera = dictValue["OutWeightCamera"] as byte[];
                }
                if (dictValue.ContainsKey("OutWeightScreen"))
                {
                    PicOutWeightScreen = dictValue["OutWeightScreen"] as byte[];
                }


                SetImage(pbInCamera, PicInWeightCamera);
                SetImage(pbInScreen, PicInWeightScreen);
                SetImage(pbSteadyCamera, PicSteadyWeightCamera);
                SetImage(pbSteadyScreen, PicSteadyWeightScreen);
                SetImage(pbOutCamera, PicOutWeightCamera);
                SetImage(pbOutScreen, PicOutWeightScreen);
            }
            catch (Exception ex)
            {

            }
        }

        private void SetImage(PictureBox picBox, byte[] bImage)
        {
            if (bImage != null)
            {
                MethodInvoker func = delegate ()
                {
                    MemoryStream ms = new MemoryStream(bImage);
                    Image image = System.Drawing.Image.FromStream(ms);
                    picBox.Image = image;
                };

                if (picBox.InvokeRequired)
                {
                    picBox.BeginInvoke(func);
                }
                else
                {
                    func();
                }
            }
        }
    }
}
