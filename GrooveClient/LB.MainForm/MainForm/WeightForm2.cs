using LB.Common;
using LB.Common.Camera;
using LB.Common.Enum;
using LB.Controls;
using LB.Controls.Report;
using LB.Login;
using LB.MainForm.MainForm;
using LB.MainForm.Permission;
using LB.MI;
using LB.MI.MI;
using LB.Page.Helper;
using LB.SysConfig;
using LB.SysConfig.SysConfig;
using LB.WinFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LB.MainForm
{
    public partial class WeightForm2 : LBForm
    {
        private LB.MainForm.CtlBaseInfoSelection _ctlBaseInfo;
        public bool bolIsCancel = false;
        LB.MainForm.frmAutoPrint frmPrint = null;//打印等待界面
        private enWeightType _WeightType;
        private System.Windows.Forms.Timer mTimerFrare = null;
        private System.Windows.Forms.Timer mAutoComputeTimer = null;
        private System.Windows.Forms.Timer mTimerCamera = null;
        private System.Windows.Forms.Timer mTimerCard = null;
        private System.Windows.Forms.Timer mSpeakTimer = null;
        private long mlSaleCarInBillID;
        private int mReadCardFailTimes = 0;//地磅稳定后，读卡失败持续时间
        //private frmSalesReturnBill _frmReturnBill = null;

        private string _CurrentReadCardCode = "";//当前读卡的卡号
        private string _PreviousReadCardCode = "";//记录已成功生成入槽单的卡号
        private DateTime _PreviousReadCardTime = DateTime.Now;//记录已成功生成入槽单的时间
        private decimal _PreviousWeightValue = 0;

        private bool _HeaderIsClosed = true;//车头红外线对射是否通畅（无遮挡）
        private bool _TailIsClosed = true;//车尾红外线对射是否通畅（无遮挡）

        private enWeightStatus _WeightStatus = enWeightStatus.None;
        public enWeightDeviceStatus PreWeightDeviceStatus = enWeightDeviceStatus.Zero;//上一次地磅状态

        public WeightForm2()
        {
            InitializeComponent();
            this.pnlSteadyStatus.Paint += PnlSteadyStatus_Paint;
        }

        private void PnlSteadyStatus_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                float fwidth = 20;
                
                Pen pen = new Pen(Brushes.Black);
                Brush brush = Brushes.Green;
                if (LBSerialHelper.IsSteady)
                {
                    brush = Brushes.Green;
                    this.lblSteady.Text = "稳定";
                    this.lblSteady.ForeColor = Color.Green;
                }
                else
                {
                    brush = Brushes.Red;
                    this.lblSteady.Text = "不稳定";
                    this.lblSteady.ForeColor = Color.Red;
                }
                
                e.Graphics.FillEllipse(brush, new RectangleF((pnlSteadyStatus.Width- fwidth)/2, (pnlSteadyStatus.Height - fwidth) / 2, fwidth, fwidth));
                e.Graphics.DrawEllipse(pen, new RectangleF((pnlSteadyStatus.Width - fwidth) / 2, (pnlSteadyStatus.Height - fwidth) / 2, fwidth, fwidth));
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            mTimerFrare = new System.Windows.Forms.Timer();
            mTimerFrare.Interval = 100;
            mTimerFrare.Enabled = true;
            mTimerFrare.Tick += mTimerFrare_Tick;

            mTimerCard = new System.Windows.Forms.Timer();
            mTimerCard.Interval = 500;
            mTimerCard.Enabled = true;
            mTimerCard.Tick += MTimerCard_Tick;

            mAutoComputeTimer = new System.Windows.Forms.Timer();
            mAutoComputeTimer.Interval = 2000;
            mAutoComputeTimer.Enabled = true;
            mAutoComputeTimer.Tick += MAutoComputeTimer_Tick;

            mSpeakTimer = new System.Windows.Forms.Timer();
            mSpeakTimer.Interval = 1000;
            mSpeakTimer.Enabled = true;
            mSpeakTimer.Tick += MSpeakTimer_Tick;

            InitTextDataSource();//初始化控件数据源

            LoadAllSalesBill();//磅单清单
            InitData();
            LBSerialHelper.StartSerial();//启动串口
            LBInFrareHelper.StartSerial();//红外线对射串口
            LBCardHelper.StartSerial(enCardType.ReadCard);//开启打开器端口

            InitCameraPanel();
            SetButtonReadOnlyByPermission();
            this.grdMain.CellDoubleClick += GrdMain_CellDoubleClick;
            this.rbAutoMode.CheckedChanged += RbAutoMode_CheckedChanged;

            mTimerCamera = new System.Windows.Forms.Timer();
            mTimerCamera.Interval = 100;
            mTimerCamera.Enabled = true;
            mTimerCamera.Tick += MTimerCamera_Tick;

            _TailIsClosed = LBInFrareHelper.TailClosed;
            _HeaderIsClosed = LBInFrareHelper.HeaderClosed;

            this.lblLoginName.Text = LoginInfo.LoginName;
        }

        #region -- InitData 读取全局数据 --

        private void InitData()
        {
            LBPermission.ReadAllPermission();//加载所有权限信息

            LBLog.AssemblyStart();

            this.grdMain.LBLoadConst();

            //读取下单模式
            bool bolMode;
            SysConfigValue.GetSysConfig("IsAutoMode", out bolMode);
            this.rbAutoMode.Checked = bolMode;
        }

        #endregion

        //下单模式切换
        private void RbAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int iMode = this.rbAutoMode.Checked ? 1 : 0;
                SysConfigValue.SaveSysConfig("IsAutoMode", iMode);
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
                    DataGridViewCell cell = this.grdMain[e.ColumnIndex, e.RowIndex];
                    DataRowView drvSelected = this.grdMain.Rows[cell.RowIndex].DataBoundItem as DataRowView;

                    long lSaleCarInBillID = LBConverter.ToInt64(drvSelected["SaleCarInBillID"]) ;

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

        private void MTimerCard_Tick(object sender, EventArgs e)
        {
            try
            {
                string strCardCode = "";
                
                if (LBSerialHelper.WeightValue <= 1000)
                {
                    this.lblCardSteady.Text = "不稳定";
                    this.lblCardSteady.ForeColor = Color.Red;
                    this.pnlReadCardStatus.BackColor = Color.Red;
                    SendStatus(enAlermStatus.None);
                    //lock (LBCardHelper.LstCardCode)
                    //{
                    //    LBCardHelper.LstCardCode.Clear();
                    //}
                    LBCardHelper.BeginReadCard = false;
                    PreWeightDeviceStatus = enWeightDeviceStatus.Zero;
                    lblWeightMsg.Text = "";
                    mReadCardFailTimes = 0;
                    lblCardNum.Text = "";

                    if (_eCarWeightStatus == enCarWeightStatus.CarSteady)
                    {
                        SaveWeightLogThread();//记录出磅的相关图片信息
                    }
                    return;
                }
                //皮重少于23吨时不记录
                if (LBSerialHelper.WeightValue < 23000)
                {
                    this.lblCardSteady.Text = "不稳定";
                    this.lblCardSteady.ForeColor = Color.Red;
                    this.pnlReadCardStatus.BackColor = Color.Red;
                    LBCardHelper.BeginReadCard = false;
                    PreWeightDeviceStatus = enWeightDeviceStatus.Zero;
                    mReadCardFailTimes = 0;
                    lblCardNum.Text = "";

                    if (_eCarWeightStatus == enCarWeightStatus.None)
                    {
                        SaveWeightLogThread();//记录入磅或者出磅的相关图片信息
                    }
                    return;
                }

                if (!LBSerialHelper.IsSteady)
                {
                    LBCardHelper.BeginReadCard = false;
                    mReadCardFailTimes = 0;
                }

                if (this.rbAutoMode.Checked)//自动模式
                {
                    if (LBSerialHelper.IsSteady)//地磅数值已稳定
                    {
                        if (_eCarWeightStatus == enCarWeightStatus.CarBeginIn)
                        {
                            SaveWeightLogThread();//记录地磅稳定后的相关图片信息
                        }

                        //LBCardHelper.BeginReadCard = true;
                        if (PreWeightDeviceStatus == enWeightDeviceStatus.Zero)
                        {
                            strCardCode = LBCardHelper.ReadCardDirect();
                            lblCardNum.Text = strCardCode;
                            
                        }

                        if (strCardCode == "")//读卡失败
                        {
                            this.lblCardSteady.Text = "不稳定";
                            this.lblCardSteady.ForeColor = Color.Red;
                            this.pnlReadCardStatus.BackColor = Color.Red;
                            mReadCardFailTimes += mTimerCard.Interval;

                            if (mReadCardFailTimes > 12000)//超过10秒还没有打开成功的，自动生成入槽单
                            {
                                decimal decWeight = LBConverter.ToDecimal(lblWeight.Text);//读皮重

                                if (PreWeightDeviceStatus == enWeightDeviceStatus.Zero)
                                {
                                    this.txtTotalWeight.Text = decWeight.ToString();
                                    VerifyDeviceIsSteady();//校验地磅数值是否稳定以及红外线对射是否正常

                                    long lInBillID = SaveBillAction("");
                                    if (lInBillID > 0)
                                    {
                                        mReadCardFailTimes = 0;
                                        PreWeightDeviceStatus = enWeightDeviceStatus.InWeight;
                                        LBErrorLog.InsertFileLog("生成无车辆入槽单：" + lInBillID.ToString()+ "-PreWeightDeviceStatus="+ PreWeightDeviceStatus.ToString());
                                    }
                                }
                                else
                                {
                                    SendStatus(enAlermStatus.Success);
                                    LBSpeakHelper.SpeakString = "称重完毕，请离开！";
                                }
                            }
                        }
                    }

                    #region -- 读取卡号 --
                    //lock (LBCardHelper.LstCardCode)
                    {
                        if (strCardCode != "")//读取返回信息
                        {
                            this.lblCardSteady.Text = "稳定";
                            this.lblCardSteady.ForeColor =Color.Green;
                            this.pnlReadCardStatus.BackColor =Color.Green;

                            long lInBillID = 0;
                            //List<string> lstRead = new List<string>();
                            //foreach (CardInfo cInfo in LBCardHelper.LstCardCode)
                            {

                                //if (cInfo.IsSuccess)//读卡成功记录
                                {
                                    //if (lstRead.Contains(cInfo.CardCode))
                                    //{
                                    //    continue;
                                    //}
                                    //lstRead.Add(cInfo.CardCode);

                                    _CurrentReadCardCode = strCardCode;//读取卡号

                                    if (_CurrentReadCardCode != "")//卡号读取成功
                                    {
                                        bool bolIsSameCardCode = false;

                                        #region -- 判断是否重复打开 --
                                        //判断依据为如果本次打开与上次打卡(已成功生成单据)一致，以及本次称重值与上次称重值一致时，认为是重复打开
                                        decimal decWeight = LBConverter.ToDecimal(lblWeight.Text);//读皮重
                                        if (_CurrentReadCardCode == _PreviousReadCardCode &&
                                            (DateTime.Now.Subtract(_PreviousReadCardTime).TotalMinutes < 15 ||
                                            Math.Abs(decWeight - _PreviousWeightValue) < 100))
                                        {
                                            bolIsSameCardCode = true;
                                        }

                                        #endregion

                                        if (PreWeightDeviceStatus == enWeightDeviceStatus.Zero && !bolIsSameCardCode)
                                        {
                                            //读取该卡对应的车辆以及供应商信息
                                            DataTable dtCarInfo = ExecuteSQL.CallView(117, "CarID,CarNum,SupplierID", "CardCode='" + _CurrentReadCardCode + "'", "");
                                            if (dtCarInfo.Rows.Count > 0)
                                            {
                                                DataRow drCarInfo = dtCarInfo.Rows[0];
                                                long lCarID = LBConverter.ToInt64(drCarInfo["CarID"]);
                                                long lSupplierID = LBConverter.ToInt64(drCarInfo["SupplierID"]);

                                                this.txtCarID.TextBox.Text = drCarInfo["CarNum"].ToString();

                                                bool bolReadWeight = ReadTareWeight();//地磅重量读取成功
                                                if (bolReadWeight)
                                                {
                                                    lInBillID = SaveBillAction(_CurrentReadCardCode);
                                                    if (lInBillID > 0)
                                                    {
                                                        PreWeightDeviceStatus = enWeightDeviceStatus.InWeight;
                                                        mReadCardFailTimes = 0;
                                                        //break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("该卡号为绑定车辆！");
                                            }
                                        }
                                        else
                                        {
                                            mReadCardFailTimes = 0;
                                            SendStatus(enAlermStatus.Success);
                                            LBSpeakHelper.SpeakString = "称重完毕，请离开！";
                                        }
                                    }
                                }
                                //else
                                //{
                                //    //读卡失败内容
                                //    continue;
                                //}
                            }

                            //LBCardHelper.LstCardCode.Clear();
                            LBCardHelper.CardCode = "";
                        }
                        else
                        {
                            lblCardNum.Text = "";
                        }
                    }
                    #endregion -- 读取卡号 --
                }
            }
            catch (Exception ex)
            {
                SendStatus(enAlermStatus.Fail);
                LBSpeakHelper.SpeakString = ex.Message;
                lblWeightMsg.ForeColor = Color.Red;
                lblWeightMsg.Text = ex.Message;
                //LBSpeakHelper.Speak(ex.Message);
                //LBErrorLog.InsertErrorLog("称重失败："+ex.Message, 1);
            }
            finally
            {
                //    lock (LBCardHelper.LstCardCode)
                //    {
                //        LBCardHelper.LstCardCode.Clear();
                //    }
                LBCardHelper.CardCode = "";
                _CurrentReadCardCode = "";
            }
        }

        private void mTimerFrare_Tick(object sender, EventArgs e)
        {
            try
            {
                this.lblCurrentTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                lblWeightUnConnect.Visible = LBSerialHelper.IsUnConnected ? true : false;
                this.lblWeight.Text = LBSerialHelper.WeightValue.ToString();
                this.pnlSteadyStatus.Invalidate();
                this.pnlCarHeader.BackColor = LBInFrareHelper.HeaderClosed ? Color.Green : Color.Red;
                this.pnlCarTail.BackColor = LBInFrareHelper.TailClosed ? Color.Green : Color.Red;

                if (_TailIsClosed && !LBInFrareHelper.TailClosed)//如果车尾对射器受到遮挡，说明有车进入
                {
                    LBSpeakHelper.SpeakString="请上秤";
                    _WeightStatus = enWeightStatus.CarIn;
                }

                if (_HeaderIsClosed && !LBInFrareHelper.HeaderClosed)//如果车头对射器受到遮挡，说明有车出磅
                {
                    LBSpeakHelper.SpeakString = "请下秤";
                }

                _HeaderIsClosed = LBInFrareHelper.HeaderClosed;
                _TailIsClosed = LBInFrareHelper.TailClosed;

                if(_WeightStatus== enWeightStatus.CarIn)
                {
                    if (LBSerialHelper.WeightValue>0 && !LBSerialHelper.IsSteady)
                    {
                        _WeightStatus = enWeightStatus.CarInUnSteady;
                    }
                }

                if(_WeightStatus == enWeightStatus.CarInUnSteady)
                {
                    if (LBSerialHelper.WeightValue > 0 && LBSerialHelper.IsSteady&&
                        LBInFrareHelper.HeaderClosed && LBInFrareHelper.TailClosed)
                    {
                        _WeightStatus = enWeightStatus.WeightSteady;
                        LBSpeakHelper.SpeakString = "请刷卡";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        private void MAutoComputeTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                int iCarCount = 0;
                decimal decWeight = 0;
                int iTotalCarCount = 0;
                LBDbParameterCollection parmCol = new LBDbParameterCollection();
                parmCol.Add(new LBParameter("SalesTotalWeight", enLBDbType.Decimal, true));
                parmCol.Add(new LBParameter("TotalCar", enLBDbType.Int32, true));

                DataSet dsReturn;
                Dictionary<string, object> dictValue;
                ExecuteSQL.CallSP(14113, parmCol, out dsReturn, out dictValue);
                if (dictValue != null && dictValue.Keys.Count > 0)
                {
                    if (dictValue.ContainsKey("SalesTotalWeight"))
                    {
                        decWeight = LBConverter.ToDecimal(dictValue["SalesTotalWeight"]);
                    }
                    if (dictValue.ContainsKey("TotalCar"))
                    {
                        iTotalCarCount = LBConverter.ToInt32(dictValue["TotalCar"]);
                    }
                }
                this.lblSalesWeight.Text = decWeight.ToString("0.00");
                this.lblAllCar.Text = iTotalCarCount.ToString();
            }
            catch (Exception ex)
            {
                //LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void MSpeakTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (LBSerialHelper.WeightValue <= 1000)
                {
                    LBSpeakHelper.SpeakString = "";
                }

                if (LBSpeakHelper.SpeakString != "")
                {
                    LBSpeakHelper.Speak(LBSpeakHelper.SpeakString);
                }
            }
            catch (Exception ex)
            {
                //LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        #region -- 查询磅单清单 --

        private void LoadAllSalesBill()
        {
            string strFilter = "IsCancel <> 1 and BillDateIn>='"+DateTime.Now.ToString("yyyy-MM-dd")+ " 00:00:00' and BillDateIn<='"+ DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59'";
            string strSort = "SaleCarInBillID desc";
            //if (this.cbFilterType.SelectedIndex == 0)
            //{
            //    strFilter = "SaleCarOutBillID is null and isnull(IsCancel,0) = 0";
            //    this.grdMain.Columns["SaleCarOutBillCode"].Visible = false;
            //    this.grdMain.Columns["SaleCarInBillCode"].Visible = true;
            //    strSort = "SaleCarInBillCode asc";
            //}
            //else if (this.cbFilterType.SelectedIndex == 1)
            //{
            //    strFilter = "SaleCarOutBillID is not null and isnull(IsCancel,0) = 0 and BillDateOut>='" + DateTime.Now.ToString("yyyy-MM-dd")+"'";

            //    this.grdMain.Columns["SaleCarOutBillCode"].Visible = true;
            //    this.grdMain.Columns["SaleCarInBillCode"].Visible = false;
            //    strSort = "SaleCarOutBillCode asc";
            //}
            //else if (this.cbFilterType.SelectedIndex == 2)
            //{
            //    strFilter = "isnull(IsCancel,0) = 1 and BillDateIn>='" + DateTime.Now.AddHours(-12).ToString("yyyy-MM-dd HH:mm") + "'";
            //    //strFilter = "SaleCarOutBillID is null and isnull(IsCancel,0) = 1";

            //    this.grdMain.Columns["SaleCarOutBillCode"].Visible = true;
            //    this.grdMain.Columns["SaleCarInBillCode"].Visible = true;
            //}

            if (this.txtFilter.Text.TrimEnd() != "")
            {
                strFilter += " and ";
                strFilter += "(CarNum like '%" + this.txtFilter.Text.TrimEnd() + "%' or ";
                strFilter += "SupplierName like '%" + this.txtFilter.Text.TrimEnd() + "%') ";
            }
            DataTable dtBill = ExecuteSQL.CallView(128, "", strFilter, strSort);
            this.grdMain.DataSource = dtBill.DefaultView;
        }

        #endregion

        #region -- Init TextBox DataSource --

        private void InitTextDataSource()
        {
            DataTable dtSupplier = ExecuteSQL.CallView(139,"","", "SupplierName asc");
            this.txtSupplierID.TextBox.LBViewType = 139;
            this.txtSupplierID.TextBox.LBSort = "SupplierName asc";
            this.txtSupplierID.TextBox.IDColumnName = "SupplierID";
            this.txtSupplierID.TextBox.TextColumnName = "SupplierName";
            this.txtSupplierID.TextBox.PopDataSource = dtSupplier.DefaultView;

            DataTable dtCar = ExecuteSQL.CallView(113, "", "", "SortLevel desc,CarNum asc");
            this.txtCarID.TextBox.LBViewType = 113;
            this.txtCarID.TextBox.LBSort = "SortLevel desc,CarNum asc";
            this.txtCarID.TextBox.IDColumnName = "CarID";
            this.txtCarID.TextBox.TextColumnName = "CarNum";
            this.txtCarID.TextBox.PopDataSource = dtCar.DefaultView;
            
            this.txtSupplierID.TextBox.IsAllowNotExists = true;
            this.txtCarID.TextBox.IsAllowNotExists = true;

            //this.txtCarID.TextBox.GotFocus += CoolText_GotFocus;
            //this.txtSupplierID.TextBox.GotFocus += CoolText_GotFocus;

            //this.txtCarID.TextBox.LostFocus += CoolText_LostFocus;
            //this.txtSupplierID.TextBox.LostFocus += CoolText_LostFocus;
            
            this.txtCarID.TextBox.TextChanged += CarTextBox_TextChanged;

            this.txtTotalWeight.TextChanged += TxtCalAmount_TextChanged;
            this.txtSuttleWeight.TextChanged += TxtCalAmount_TextChanged;
            this.txtCarTare.TextChanged += TxtCalAmount_TextChanged;

        }

        #endregion

        #region -- 客户、车号、物料 控件选中事件 --
        
        //选择车辆触发事件
        private void CarTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strCarNum = this.txtCarID.TextBox.Text.ToString();
                long lCarID = 0;
                long lSupplierID = 0;
                decimal decDefaultCarWeight = 0;
                #region -- 读取车辆ID号 --
                using (DataTable dtCar = ExecuteSQL.CallView(117, "CarID,SupplierID,DefaultCarWeight", "CarNum='" + strCarNum + "'", ""))
                {
                    if (dtCar.Rows.Count > 0)
                    {
                        lCarID = LBConverter.ToInt64(dtCar.Rows[0]["CarID"]);
                        lSupplierID = LBConverter.ToInt64(dtCar.Rows[0]["SupplierID"]);
                        decDefaultCarWeight = LBConverter.ToInt64(dtCar.Rows[0]["DefaultCarWeight"]);
                    }
                }
                #endregion -- 读取车辆ID号 --

                if (lCarID > 0)//如果存在该车辆
                {
                    this.txtSupplierID.TextBox.SelectedItemID = lSupplierID;
                    this.txtCarTare.Text = LBConverter.ToString(decDefaultCarWeight);
                }
                else
                {
                    this.txtSupplierID.TextBox.Text = "";
                    this.txtCarTare.Text = "";
                }
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        
        private void TxtCalAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalWeight();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        #endregion

        #region -- 查询磅单清单 --

        private void btnFilter_Click(object sender, EventArgs e)
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

        #endregion -- 查询磅单清单 --

        #region -- 磅单操作按钮事件 --

        //读取称重
        private void btnReadTareWeight_Click(object sender, EventArgs e)
        {
            try
            {
                ReadTareWeight();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private bool ReadTareWeight()
        {
            VerifyDeviceIsSteady();//校验地磅数值是否稳定以及红外线对射是否正常
            VerifyTextBoxIsEmpty();//判断相关控件值是否为空
            long lCarID = LBConverter.ToInt64(this.txtCarID.TextBox.SelectedItemID);
            long lCustomerID = LBConverter.ToInt64(this.txtSupplierID.TextBox.SelectedItemID);

            decimal decWeight = LBConverter.ToDecimal(lblWeight.Text);//读皮重
            this.txtTotalWeight.Text = decWeight.ToString("0");
            if (decWeight == 0)
            {
                if (this.rbAutoMode.Checked)
                {
                    //Speach sp = new Speach();
                    //sp.Rate = -5;
                    //sp.AnalyseSpeak("地磅值为零");
                    throw new Exception("地磅值为零！");
                }
                else
                {
                    throw new Exception("当前【毛重】值为0！");
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        //保存并打印
        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                LBPermission.VerifyUserPermission("保存", "WeightSalesOutBill_Save");
                VerifyDeviceIsSteady();//校验地磅数值是否稳定以及红外线对射是否正常

                SaveBillAction("");
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
       
        private void VerifyTextBoxIsEmpty()
        {
            long lCarID = LBConverter.ToInt64(this.txtCarID.TextBox.SelectedItemID);
            long lSupplierID = LBConverter.ToInt64(this.txtSupplierID.TextBox.SelectedItemID);

            if (lCarID == 0)
            {
                throw new Exception("车号不能为空或者该车号不存在！");
            }
            if (lSupplierID == 0)
            {
                throw new Exception("供应商不能为空或者该客户不存在！");
            }
        }

        //判断地磅数值是否稳定以及红外线设备是否报警
        private void VerifyDeviceIsSteady()
        {
            if (!LBSerialHelper.IsSteady)
            {
                throw new Exception("数值未稳定！");
            }

            if (LBInFrareHelper.IsHeaderEffect && !LBInFrareHelper.HeaderClosed)
            {
                throw new Exception("请停到秤台中间！");
            }
            if (LBInFrareHelper.IsTailEffect && !LBInFrareHelper.TailClosed)
            {
                throw new Exception("请停到秤台中间！");
            }
        }
        
        private void btnClearValue_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAllBillInfo();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        
        private void btnViewSalesBill_Click(object sender, EventArgs e)
        {
            try
            {
                frmSaleCarInOutBillManager frmBill = new frmSaleCarInOutBillManager();
                frmBill.PageAutoSize = true;
                LBShowForm.ShowDialog(frmBill);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        
        #endregion -- 磅单操作按钮事件 --

        #region-- 保存入槽磅单记录 --

        private long SaveBillAction(string strCardCode)
        {
            long lSaleCarInBillID = SaveInBill(strCardCode);
            if (lSaleCarInBillID > 0)
            {
                this.ClearAllBillInfo();
                LBSpeakHelper.Speak(enSpeakType.FinishWeight);
                SendStatus(enAlermStatus.Success);
            }

            LoadAllSalesBill();
            return lSaleCarInBillID;
        }

        private long SaveInBill(string strCardCode)
        {
            Dictionary<string, double> dictTest = new Dictionary<string, double>();
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            long lSaleCarInBillID=0;
            long lCarID = LBConverter.ToInt64(this.txtCarID.TextBox.SelectedItemID);
            long lSupplierID = LBConverter.ToInt64(this.txtSupplierID.TextBox.SelectedItemID);
            decimal decCarTare = LBConverter.ToDecimal(this.txtCarTare.Text);
            decimal decTotalWeight= LBConverter.ToDecimal(this.txtTotalWeight.Text);
            decimal decSuttleWeight = LBConverter.ToDecimal(this.txtSuttleWeight.Text);
            
            if (strCardCode!="" && decCarTare == 0)
            {
                throw new Exception("当前【皮重】值为0，无法保存！");
            }
            if (decTotalWeight == 0)
            {
                throw new Exception("当前【毛重】值为0，无法保存！");
            }
            if (decSuttleWeight <= 0)
            {
                throw new Exception("当前【净重】值为0，无法保存！");
            }

            LBDbParameterCollection parmCol = new LBDbParameterCollection();
            parmCol.Add(new LBParameter("SaleCarInBillID", enLBDbType.Int64, 0));
            parmCol.Add(new LBParameter("SaleCarInBillCode", enLBDbType.String, ""));
            parmCol.Add(new LBParameter("BillDate", enLBDbType.DateTime, DateTime.Now));
            parmCol.Add(new LBParameter("CarID", enLBDbType.Int64, lCarID));
            parmCol.Add(new LBParameter("SupplierID", enLBDbType.Int64, lSupplierID));
            parmCol.Add(new LBParameter("CarTare", enLBDbType.Decimal, decCarTare));
            parmCol.Add(new LBParameter("TotalWeight", enLBDbType.Decimal, decTotalWeight));
            parmCol.Add(new LBParameter("SuttleWeight", enLBDbType.Decimal, decTotalWeight- decCarTare));
            parmCol.Add(new LBParameter("CardCode", enLBDbType.String, strCardCode));

            DataSet dsReturn;
            Dictionary<string, object> dictValue;
            ExecuteSQL.CallSP(14100, parmCol, out dsReturn, out dictValue);
            if (dictValue.ContainsKey("SaleCarInBillID"))
            {
                lSaleCarInBillID = LBConverter.ToInt64(dictValue["SaleCarInBillID"]);
                Thread threadSavePic = new Thread(SaveInSalesPicture);
                threadSavePic.Start(dictValue["SaleCarInBillID"]);

                _PreviousWeightValue = decTotalWeight;
                _PreviousReadCardCode = _CurrentReadCardCode;//生成入场单成功后，记录当前卡号，防止同一张卡因多次打卡，生成重复入槽单
                _PreviousReadCardTime = DateTime.Now;
                _CurrentReadCardCode = "";//将当前卡号清空
            }
            dt2 = DateTime.Now;
            dictTest.Add("CallSP", dt2.Subtract(dt1).TotalMilliseconds);
            dt1 = dt2;

            LoadAllSalesBill(); //刷新磅单清单

            dt2 = DateTime.Now;
            dictTest.Add("LoadAllSalesBill", dt2.Subtract(dt1).TotalMilliseconds);
            dt1 = dt2;
            
            return lSaleCarInBillID;
        }

        private void SaveInSalesPicture(object objSaleCarInBillID)
        {
            long lSaleCarInBillID = LBConverter.ToInt64(objSaleCarInBillID);
            try
            {
                byte[] bImg1 = null;
                byte[] bImg2 = null;
                byte[] bImg3 = null;
                byte[] bImg4 = null;

                foreach (KeyValuePair<ViewCamera, bool> keyvalue in dictIsOpen)
                {
                    if (bImg1 == null)
                        bImg1 = keyvalue.Key.CapturePic();
                    else if (bImg2 == null)
                        bImg2 = keyvalue.Key.CapturePic();
                    else if (bImg3 == null)
                    {
                        bImg3 = keyvalue.Key.CapturePic();
                    }
                    else if (bImg4 == null)
                        bImg4 = keyvalue.Key.CapturePic();
                }

                if (bImg3 == null)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            Bitmap map = GetCurrentScreenImg();
                            map.Save(ms, ImageFormat.Jpeg);
                            if (ms != null)
                            {
                                bImg3 = new byte[ms.Length];
                                ms.Seek(0, SeekOrigin.Begin);
                                ms.Read(bImg3, 0, bImg3.Length);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                LBDbParameterCollection parmCol = new LBDbParameterCollection();
                parmCol.Add(new LBParameter("SaleCarInBillID", enLBDbType.Int64, lSaleCarInBillID));
                parmCol.Add(new LBParameter("MonitoreImg1", enLBDbType.Bytes, bImg1));
                parmCol.Add(new LBParameter("MonitoreImg2", enLBDbType.Bytes, bImg2));
                parmCol.Add(new LBParameter("MonitoreImg3", enLBDbType.Bytes, bImg3));
                parmCol.Add(new LBParameter("MonitoreImg4", enLBDbType.Bytes, bImg4));
                DataSet dsReturn;
                Dictionary<string, object> dictValue;
                ExecuteSQL.CallSP(14111, parmCol, out dsReturn, out dictValue);
            }
            catch (Exception ex)
            {
                LBErrorLog.InsertErrorLog("保存入场图片时报错，入场单号：" + lSaleCarInBillID.ToString() + "\n错误信息：" + ex.Message,0);
            }
        }

        //读取当前电脑截屏
        private Bitmap GetCurrentScreenImg()
        {
            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics imgGraphics = Graphics.FromImage(image);
            //设置截屏区域 柯乐义
            imgGraphics.CopyFromScreen(0, 0, 0, 0, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            image.Save("d://ooo.jpg", ImageFormat.Jpeg);
            //imgGraphics.Dispose();
            return image;
        }

        private void ClearAllBillInfo()
        {
            this.txtCarID.TextBox.Text = "";
            this.txtTotalWeight.Text = "0";
            this.txtSupplierID.TextBox.Text = "";
            this.txtCarTare.Text = "0";
        }

        #endregion
        
        #region -- 计算 金额=净重*单价 --

        private void CalWeight()
        {
            decimal decTotalWeight = LBConverter.ToDecimal(this.txtTotalWeight.Text);
            decimal decCarTare = LBConverter.ToDecimal(this.txtCarTare.Text);
            this.txtSuttleWeight.Text = (decTotalWeight - decCarTare).ToString("0");
        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (LB.WinFunction.LBCommonHelper.ConfirmMessage("是否确认退出系统？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
        //        private System.Windows.Forms.Timer mTimerFrare = null;
        //private System.Windows.Forms.Timer mAutoComputeTimer = null;
        //private System.Windows.Forms.Timer mTimerCamera = null;
        //private System.Windows.Forms.Timer mTimerCard = null;
        //private System.Windows.Forms.Timer mSpeakTimer = null;
                e.Cancel = true;

                
                return;
            }

            foreach(KeyValuePair<ViewCamera,Panel> keyvalue in dictCamera)
            {
                if (keyvalue.Key != null)
                {
                    try
                    {
                        keyvalue.Key.CloseCamera();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            if (mTimerCard != null)
                mTimerCard.Enabled = false;
            if (mTimerCamera != null)
                mTimerCamera.Enabled = false;
            if (mTimerFrare != null)
                mTimerFrare.Enabled = false;
            if (mAutoComputeTimer != null)
                mAutoComputeTimer.Enabled = false;
            if (mSpeakTimer != null)
                mSpeakTimer.Enabled = false;
            LBCardHelper.CloseThread();
        }
        
        #region -- 工具栏按钮事件 --

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                LB.SysConfig.frmChangePassword frmChangePW = new SysConfig.frmChangePassword();
                frmChangePW.ShowDialog();
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
                bolIsCancel = true;
                this.Close();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnDeviceConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmWeightDecive frmDevice = new frmWeightDecive();
                LBShowForm.ShowDialog(frmDevice);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnCameraConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmCameraConfig frmDevice = new frmCameraConfig();
                LBShowForm.ShowDialog(frmDevice);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }


        private void btnInfraredDeviceConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmInfraredDeviceConfig frmConfig = new frmInfraredDeviceConfig();
                LBShowForm.ShowDialog(frmConfig);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnWeightReportSet_Click(object sender, EventArgs e)
        {
            try
            {
                //WeightReportConfig();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnCardConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmCardDeviceConfig frmConfig = new frmCardDeviceConfig();
                LBShowForm.ShowDialog(frmConfig);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
        #endregion -- 工具栏按钮事件 --

        #region -- 摄像头 --

        private DataTable _DTCamera = null;
        Dictionary<ViewCamera, Panel> dictCamera = new Dictionary<ViewCamera, Panel>();
        Dictionary<ViewCamera, bool> dictIsOpen = new Dictionary<ViewCamera, bool>();
        Dictionary<ViewCamera, CameraConfig> dictCameraSet = new Dictionary<ViewCamera, CameraConfig>();

        private void InitCameraPanel()
        {
            //读取启用了摄像头的数量
            _DTCamera = ExecuteSQL.CallView(122, "", "MachineName='" + LoginInfo.MachineName + "'", "");
            if (_DTCamera.Rows.Count > 0)
            {
                bool bolUseCamera1 = false;
                bool bolUseCamera2 = false;
                bool bolUseCamera3 = false;
                bool bolUseCamera4 = false;

                DataRow dr = _DTCamera.Rows[0];
                bolUseCamera1 = LBConverter.ToBoolean(dr["UseCamera1"]);
                bolUseCamera2 = LBConverter.ToBoolean(dr["UseCamera2"]);
                bolUseCamera3 = LBConverter.ToBoolean(dr["UseCamera3"]);
                bolUseCamera4 = LBConverter.ToBoolean(dr["UseCamera4"]);

                int iUseCount = 0;
                iUseCount += bolUseCamera1 ? 1 : 0;
                iUseCount += bolUseCamera2 ? 1 : 0;
                iUseCount += bolUseCamera3? 1 : 0;
                iUseCount += bolUseCamera4 ? 1 : 0;

                if (bolUseCamera1)
                {
                    Panel pnlCamera = new Panel();
                    pnlCamera.Dock = DockStyle.Top;
                    pnlCamera.Height = this.pnlRight.Height / iUseCount;
                    this.pnlRight.Controls.Add(pnlCamera);

                    ViewCamera viewCamera1 = new ViewCamera();
                    viewCamera1.Account = "";
                    viewCamera1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    viewCamera1.Dock = System.Windows.Forms.DockStyle.Fill;
                    viewCamera1.IPAddress = "";
                    viewCamera1.Name = "viewCamera1";
                    viewCamera1.Password = "";
                    viewCamera1.Port = 0;
                    viewCamera1.MouseDoubleClick += ViewCamera_MouseDoubleClick;
                    frmShowMaxCameral frmCamera1 = new frmShowMaxCameral(viewCamera1);
                    frmCamera1.TopLevel = false; // 不是最顶层窗体
                    frmCamera1.ControlBox = false;
                    frmCamera1.FormBorderStyle = FormBorderStyle.None;
                    frmCamera1.Dock = DockStyle.Fill;
                    pnlCamera.Controls.Add(frmCamera1);
                    frmCamera1.Show();

                    dictCamera.Add(viewCamera1,pnlCamera );
                    dictIsOpen.Add(viewCamera1, false);

                    CameraConfig camera = new CameraConfig(
                        dr["IPAddress1"].ToString().TrimEnd(),
                        LBConverter.ToInt32(dr["Port1"]),
                        dr["Account1"].ToString().TrimEnd(),
                        dr["Password1"].ToString().TrimEnd());
                    dictCameraSet.Add(viewCamera1, camera);
                }

                if (bolUseCamera2)
                {
                    Panel pnlCamera = new Panel();
                    pnlCamera.Dock = DockStyle.Top;
                    pnlCamera.Height = this.pnlRight.Height / iUseCount;
                    this.pnlRight.Controls.Add(pnlCamera);

                    ViewCamera viewCamera1 = new ViewCamera();
                    viewCamera1.Account = "";
                    viewCamera1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    viewCamera1.Dock = System.Windows.Forms.DockStyle.Fill;
                    viewCamera1.IPAddress = "";
                    viewCamera1.Name = "viewCamera2";
                    viewCamera1.Password = "";
                    viewCamera1.Port = 0;
                    viewCamera1.MouseDoubleClick += ViewCamera_MouseDoubleClick;
                    frmShowMaxCameral frmCamera1 = new frmShowMaxCameral(viewCamera1);
                    frmCamera1.TopLevel = false; // 不是最顶层窗体
                    frmCamera1.ControlBox = false;
                    frmCamera1.FormBorderStyle = FormBorderStyle.None;
                    frmCamera1.Dock = DockStyle.Fill;
                    pnlCamera.Controls.Add(frmCamera1);
                    frmCamera1.Show();

                    dictCamera.Add(viewCamera1, pnlCamera);
                    dictIsOpen.Add(viewCamera1, false);

                    CameraConfig camera = new CameraConfig(
                        dr["IPAddress2"].ToString().TrimEnd(),
                        LBConverter.ToInt32(dr["Port2"]),
                        dr["Account2"].ToString().TrimEnd(),
                        dr["Password2"].ToString().TrimEnd());
                    dictCameraSet.Add(viewCamera1, camera);
                }

                if (bolUseCamera3)
                {
                    Panel pnlCamera = new Panel();
                    pnlCamera.Dock = DockStyle.Top;
                    pnlCamera.Height = this.pnlRight.Height / iUseCount;
                    this.pnlRight.Controls.Add(pnlCamera);

                    ViewCamera viewCamera1 = new ViewCamera();
                    viewCamera1.Account = "";
                    viewCamera1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    viewCamera1.Dock = System.Windows.Forms.DockStyle.Fill;
                    viewCamera1.IPAddress = "";
                    viewCamera1.Name = "viewCamera3";
                    viewCamera1.Password = "";
                    viewCamera1.Port = 0;
                    viewCamera1.MouseDoubleClick += ViewCamera_MouseDoubleClick;
                    frmShowMaxCameral frmCamera1 = new frmShowMaxCameral(viewCamera1);
                    frmCamera1.TopLevel = false; // 不是最顶层窗体
                    frmCamera1.ControlBox = false;
                    frmCamera1.FormBorderStyle = FormBorderStyle.None;
                    frmCamera1.Dock = DockStyle.Fill;
                    pnlCamera.Controls.Add(frmCamera1);
                    frmCamera1.Show();

                    dictCamera.Add(viewCamera1, pnlCamera);
                    dictIsOpen.Add(viewCamera1, false);

                    CameraConfig camera = new CameraConfig(
                        dr["IPAddress3"].ToString().TrimEnd(),
                        LBConverter.ToInt32(dr["Port3"]),
                        dr["Account3"].ToString().TrimEnd(),
                        dr["Password3"].ToString().TrimEnd());
                    dictCameraSet.Add(viewCamera1, camera);
                }
                
                if (bolUseCamera4)
                {
                    Panel pnlCamera = new Panel();
                    pnlCamera.Dock = DockStyle.Top;
                    pnlCamera.Height = this.pnlRight.Height / iUseCount;
                    this.pnlRight.Controls.Add(pnlCamera);

                    ViewCamera viewCamera1 = new ViewCamera();
                    viewCamera1.Account = "";
                    viewCamera1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    viewCamera1.Dock = System.Windows.Forms.DockStyle.Fill;
                    viewCamera1.IPAddress = "";
                    viewCamera1.Name = "viewCamera4";
                    viewCamera1.Password = "";
                    viewCamera1.Port = 0;
                    viewCamera1.MouseDoubleClick += ViewCamera_MouseDoubleClick;
                    frmShowMaxCameral frmCamera1 = new frmShowMaxCameral(viewCamera1);
                    frmCamera1.TopLevel = false; // 不是最顶层窗体
                    frmCamera1.ControlBox = false;
                    frmCamera1.FormBorderStyle = FormBorderStyle.None;
                    frmCamera1.Dock = DockStyle.Fill;
                    pnlCamera.Controls.Add(frmCamera1);
                    frmCamera1.Show();

                    dictCamera.Add(viewCamera1, pnlCamera);
                    dictIsOpen.Add(viewCamera1, false);

                    CameraConfig camera = new CameraConfig(
                        dr["IPAddress4"].ToString().TrimEnd(),
                        LBConverter.ToInt32(dr["Port4"]),
                        dr["Account4"].ToString().TrimEnd(),
                        dr["Password4"].ToString().TrimEnd());
                    dictCameraSet.Add(viewCamera1, camera);
                }
            }
        }

        private void MTimerCamera_Tick(object sender, EventArgs e)
        {
            try
            {
                mTimerCamera.Interval = 30000;
                List<ViewCamera> lstConnectedPnl = new List<ViewCamera>();
                foreach(KeyValuePair<ViewCamera, bool> keyvalue in dictIsOpen)
                {
                    if (!keyvalue.Value)
                    {
                        string strIPAddress1 = dictCameraSet[keyvalue.Key].Address;
                        int iPort1 = dictCameraSet[keyvalue.Key].Port;
                        PingCamera ping = new PingCamera();
                        bool bolConnected = ping.Connect(strIPAddress1, iPort1, 200);
                        if (bolConnected)
                        {
                            lstConnectedPnl.Add(keyvalue.Key);
                            keyvalue.Key.IPAddress = strIPAddress1;
                            keyvalue.Key.Port = iPort1;
                            keyvalue.Key.Account = dictCameraSet[keyvalue.Key].Account;
                            keyvalue.Key.Password = dictCameraSet[keyvalue.Key].Password;
                            keyvalue.Key.OpenCamera(1);
                        }
                    }
                }
                
                foreach(ViewCamera vc in lstConnectedPnl)
                {
                    dictIsOpen[vc] = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ViewCamera_MouseDoubleClick(object sender, EventArgs e)
        {
            ViewCamera vc = (ViewCamera)sender;
            Panel pnl = dictCamera[vc];
            try
            {
                vc.MouseDoubleClick -= ViewCamera_MouseDoubleClick;
                vc.MouseClick += Vc_MouseClick;
                Form frm = vc.FindForm();
                frm.Hide();
                pnl.Controls.Remove(frm);
                frm.WindowState = FormWindowState.Maximized;
                frm.TopLevel = true;
                frm.TopMost = true;
                frm.Show();
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
            finally
            {
                vc.MouseDoubleClick += ViewCamera_MouseDoubleClick;
            }
        }

        private void Vc_MouseClick(object sender, MouseEventArgs e)
        {
            ViewCamera vc = (ViewCamera)sender;
            vc.MouseClick -= Vc_MouseClick;

            Panel pnl = dictCamera[vc];

            Form frm = vc.FindForm();
            frm.Hide();

            frm.WindowState = FormWindowState.Normal;
            frm.TopLevel = false; // 不是最顶层窗体
            frm.ControlBox = false;
            frm.Dock = DockStyle.Fill;
            frm.TopMost = false;
            pnl.Controls.Add(frm);
            frm.Show();
        }

        #endregion

        #region -- 工具栏按钮事件 --

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                //frmCustomerEdit frmCustomer = new frmCustomerEdit(0);
                //LBShowForm.ShowDialog(frmCustomer);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnCustomerManager_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerManager frmCustomer = new frmCustomerManager();
                frmCustomer.PageAutoSize = true;
                LBShowForm.ShowDialog(frmCustomer);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCarEdit frmCar = new frmCarEdit(0);
                LBShowForm.ShowDialog(frmCar);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnCarQuery_Click(object sender, EventArgs e)
        {
            try
            {
                frmCarManager frmCar = new frmCarManager();
                frmCar.PageAutoSize = true;
                LBShowForm.ShowDialog(frmCar);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
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

        private void btnSupplierQuery_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupplierQuery frmCar = new frmSupplierQuery();
                LBShowForm.ShowDialog(frmCar);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            try
            {
                string strActionType = "ActionType="+ (int)enActionType.CardEdit;
                string strIpAddress = "Url=" + RemotingObject.GetIPAddress();
                string strCardID = "CardID=0";

                string strPath = Path.Combine(Application.StartupPath, "CardMain", "LB.CardMain.exe");
                Process proc = Process.Start(strPath, strActionType+" "+ strIpAddress+" "+ strCardID);
                if (proc != null)
                {
                    proc.WaitForExit();
                    
                }

                //frmCardEdit frmCard = new frmCardEdit(0);
                //LBShowForm.ShowDialog(frmCard);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnCardManager_Click(object sender, EventArgs e)
        {
            try
            {
                frmCardManager frmCardManager = new frmCardManager();
                LBShowForm.ShowDialog(frmCardManager);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnRPReceive_Click(object sender, EventArgs e)
        {
            try
            {
                //frmEditReceiveBill frmReceive = new frmEditReceiveBill(0);
                //LBShowForm.ShowDialog(frmReceive);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnRPReceiveList_Click(object sender, EventArgs e)
        {
            try
            {
                //frmReceiveBillQuery frmQuery = new frmReceiveBillQuery();
                //frmQuery.PageAutoSize = true;
                //LBShowForm.ShowDialog(frmQuery);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnItemBaseManager_Click(object sender, EventArgs e)
        {
            try
            {
                //frmItemBaseManager frmItemBaseMag = new frmItemBaseManager();
                //frmItemBaseMag.PageAutoSize = true;
                //LBShowForm.ShowMainPage(frmItemBaseMag);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnAddChangePriceBill_Click(object sender, EventArgs e)
        {
            try
            {
                //frmModifyBillHeaderEdit frm = new frmModifyBillHeaderEdit(0);
                //frm.PageAutoSize = true;
                //LBShowForm.ShowDialog(frm);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnChangePriceManager_Click(object sender, EventArgs e)
        {
            try
            {
                //frmModifyBillHeaderQuery frmModify = new frmModifyBillHeaderQuery();
                //frmModify.PageAutoSize = true;
                //LBShowForm.ShowDialog(frmModify);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        #endregion -- 工具栏按钮事件 --

        #region -- 根据权限设置按钮的只读属性 --

        private void SetButtonReadOnlyByPermission()
        {
            //this.btnReadTareWeight.Enabled = LBPermission.GetUserPermission("WeightSalesOutBill_TareValue");
            //this.btnSaveAndPrint.Enabled = LBPermission.GetUserPermission("SalesManager_ChangeDirect");
            //this.btnViewSalesBill.Enabled= LBPermission.GetUserPermission("SalesManager_Query");
        }


        #endregion -- 根据权限设置按钮的只读属性 --

        private void btnY3_Click(object sender, EventArgs e)
        {
            //LBInFrareHelper.SendY((byte)3);
        }

        private void btnY2_Click(object sender, EventArgs e)
        {

            //LBInFrareHelper.SendY((byte)2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LBInFrareHelper.SendY(-1);
        }

        private void SendStatus(enAlermStatus eStatus)
        {
            LBInFrareHelper.SendAlermStatus(eStatus);
            if(eStatus== enAlermStatus.Success)
            {
                lblWeightMsg.ForeColor = Color.Green;
                lblWeightMsg.Text = "称重成功！";
            }
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            try
            {
                SysConfig.frmUserManager frmUserMag = new SysConfig.frmUserManager();
                LBShowForm.ShowDialog(frmUserMag);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnPermissionConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmPermissionConfig frmView = new frmPermissionConfig();
                LBShowForm.ShowDialog(frmView);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                frmLogManager frmLog = new frmLogManager();
                frmLog.PageAutoSize = true;
                LBShowForm.ShowDialog(frmLog);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private void btnExportConfigSQL_Click(object sender, EventArgs e)
        {
            try
            {
                //ExportSQLConfig.ExportAction();
                StringBuilder builder = new StringBuilder();
                string strSelectSQL = "select * from DbPermissionData";
                DataTable dtPermission = ExecuteSQL.CallDirectSQL(strSelectSQL);
                foreach(DataRow dr in dtPermission.Rows)
                {
                    long lID = LBConverter.ToInt64(dr["PermissionDataID"]);
                    string PermissionCode = dr["PermissionCode"].ToString();
                    string PermissionDataName = dr["PermissionDataName"].ToString();
                    string PermissionSPType = dr["PermissionSPType"].ToString();
                    string Forbid = dr["Forbid"].ToString()==""?"0": dr["Forbid"].ToString();

                    string strSQL = @"
update DbPermissionData
set PermissionCode = '{0}',
    PermissionDataName = '{1}',
    PermissionSPType = {2},
    Forbid = {3}
where PermissionDataID = {4};
";
                    strSQL = string.Format(strSQL, PermissionCode, PermissionDataName, PermissionSPType, Forbid, lID);
                    builder.AppendLine(strSQL);
                }

                CreateSQLFile(builder.ToString(), "SQL更新");
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        private bool CreateSQLFile(string strText, string strFileName)
        {
            try
            {
                string strPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + DateTime.Now.ToString("yyyyMMdd") + @"\窗型资料";
                string strPathTable = strPath + @"\" + strFileName + ".sql";
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                if (File.Exists(strPathTable))
                {
                    File.Delete(strPathTable);
                }
                try
                {
                    //操作表

                    System.IO.FileStream fileTable = new System.IO.FileStream(strPathTable, System.IO.FileMode.Create);
                    System.IO.StreamWriter writerTable = new System.IO.StreamWriter(fileTable, System.Text.Encoding.Default);

                    writerTable.Write(strText);
                    writerTable.Flush();
                    fileTable.Close();

                    //listView1.Invoke((MethodInvoker)delegate
                    //{
                    //    ListViewItem item = new ListViewItem(strFileName);
                    //    item.SubItems.Add(strPathTable);
                    //    item.SubItems.Add("生成成功！");
                    //    this.listView1.Items.Add(item);
                    //});
                    return true;
                }
                catch (Exception ex)
                {
                    //listView1.Invoke((MethodInvoker)delegate
                    //{
                    //    ListViewItem item = new ListViewItem(strFileName);
                    //    item.SubItems.Add(strPathTable);
                    //    item.SubItems.Add(ex.Message);
                    //    this.listView1.Items.Add(item);
                    //});
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region -- 车辆进出地磅日志 --

        private void SaveWeightLogThread()
        {
            return;
            Thread thread = new Thread(SaveWeightLog);
            thread.Start();
        }

        enCarWeightStatus _eCarWeightStatus = enCarWeightStatus.None;
        long _WeightLogID=0;
        private void SaveWeightLog()
        {
            try {
                byte[] ImageBuffer;
                byte[] ScreenBuffer;

                GetCameraBuffer(out ImageBuffer, out ScreenBuffer);
                if (_eCarWeightStatus == enCarWeightStatus.None)
                {
                    LBDbParameterCollection parmCol = new LBDbParameterCollection();
                    parmCol.Add(new LBParameter("WeightLogID", enLBDbType.Int64, 0));
                    parmCol.Add(new LBParameter("CameraBuffer", enLBDbType.Bytes, ImageBuffer));
                    parmCol.Add(new LBParameter("ScreenBuffer", enLBDbType.Bytes, ScreenBuffer));

                    DataSet dsReturn;
                    Dictionary<string, object> dictValue;
                    ExecuteSQL.CallSP(14900, parmCol, out dsReturn, out dictValue);
                    if (dictValue.ContainsKey("WeightLogID"))
                    {
                        _WeightLogID = LBConverter.ToInt64(dictValue["WeightLogID"]);
                    }
                    _eCarWeightStatus = enCarWeightStatus.CarBeginIn;
                }
                else if (_WeightLogID > 0 && _eCarWeightStatus == enCarWeightStatus.CarBeginIn)
                {
                    LBDbParameterCollection parmCol = new LBDbParameterCollection();
                    parmCol.Add(new LBParameter("WeightLogID", enLBDbType.Int64, _WeightLogID));
                    parmCol.Add(new LBParameter("CameraBuffer", enLBDbType.Bytes, ImageBuffer));
                    parmCol.Add(new LBParameter("ScreenBuffer", enLBDbType.Bytes, ScreenBuffer));

                    DataSet dsReturn;
                    Dictionary<string, object> dictValue;
                    ExecuteSQL.CallSP(14901, parmCol, out dsReturn, out dictValue);
                    _eCarWeightStatus = enCarWeightStatus.CarSteady;
                }
                else if (_WeightLogID > 0 && _eCarWeightStatus == enCarWeightStatus.CarSteady)
                {
                    LBDbParameterCollection parmCol = new LBDbParameterCollection();
                    parmCol.Add(new LBParameter("WeightLogID", enLBDbType.Int64, _WeightLogID));
                    parmCol.Add(new LBParameter("CameraBuffer", enLBDbType.Bytes, ImageBuffer));
                    parmCol.Add(new LBParameter("ScreenBuffer", enLBDbType.Bytes, ScreenBuffer));

                    DataSet dsReturn;
                    Dictionary<string, object> dictValue;
                    ExecuteSQL.CallSP(14902, parmCol, out dsReturn, out dictValue);
                    _eCarWeightStatus = enCarWeightStatus.None;
                    _WeightLogID = 0;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void GetCameraBuffer(out byte[] ImageBuffer,out byte[] ScreenBuffer)
        {
            ImageBuffer = null;
            ScreenBuffer = null;
            try
            {
                foreach (KeyValuePair<ViewCamera, bool> keyvalue in dictIsOpen)
                {
                    ImageBuffer = keyvalue.Key.CapturePic();
                    if (ImageBuffer != null)
                    {
                        break;
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap map = GetCurrentScreenImg();
                    map.Save(ms, ImageFormat.Jpeg);
                    if (ms != null)
                    {
                        ScreenBuffer = new byte[ms.Length];
                        ms.Seek(0, SeekOrigin.Begin);
                        ms.Read(ScreenBuffer, 0, ScreenBuffer.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        #endregion

    }



    internal class CameraConfig
    {
        public string Address="";
        public int Port = 0;
        public string Account = "";
        public string Password = "";

        public CameraConfig(string Address, int Port, string Account, string Password)
        {
            this.Address = Address;
            this.Port = Port;
            this.Account = Account;
            this.Password = Password;
        }
    }

    public enum enStatus
    {
        Success,

        Fail,

        None
    }

    public enum enWeightStatus
    {
        /// <summary>
        /// 地磅闲置
        /// </summary>
        None,
        /// <summary>
        /// 有车辆进入
        /// </summary>
        CarIn,
        /// <summary>
        /// 有车辆进入但未稳定
        /// </summary>
        CarInUnSteady,
        /// <summary>
        /// 有车在地磅上，且地磅稳定
        /// </summary>
        WeightSteady
    }

    public enum enCarWeightStatus
    {
        None,

        CarBeginIn,

        CarSteady
    }
}
