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
    public partial class WeightFormCalcalute : LBForm
    {
        private LB.MainForm.CtlBaseInfoSelection _ctlBaseInfo;
        public bool bolIsCancel = false;
        LB.MainForm.frmAutoPrint frmPrint = null;//打印等待界面
        //private enWeightType _WeightType;
        private System.Windows.Forms.Timer mAutoComputeTimer = null;
        private System.Windows.Forms.Timer mTimerCamera = null;
        private System.Windows.Forms.Timer mTimerCard = null;
        private System.Windows.Forms.Timer mSpeakTimer = null;
        private long mlSaleCarInBillID;
        //private frmSalesReturnBill _frmReturnBill = null;

        private string _CurrentReadCardCode = "";//当前读卡的卡号
        private string _PreviousReadCardCode = "";//记录已成功生成入槽单的卡号
        private DateTime _PreviousReadCardTime = DateTime.Now;//记录已成功生成入槽单的时间
        private decimal _PreviousWeightValue = 0;

        private bool _HeaderIsClosed = true;//车头红外线对射是否通畅（无遮挡）
        private bool _TailIsClosed = true;//车尾红外线对射是否通畅（无遮挡）

        public WeightFormCalcalute()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

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
            //LBSerialHelper.StartSerial();//启动串口
            LBInFrareHelper.StartSerial();//红外线对射串口
            LBCardHelper.StartSerial(enCardType.ReadCard);//开启打开器端口

            InitCameraPanel();
            SetButtonReadOnlyByPermission();
            this.grdMain.CellDoubleClick += GrdMain_CellDoubleClick;

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
            SystemConfigValue.ReadAllConfigValue();
            LBLog.AssemblyStart();

            this.grdMain.LBLoadConst();
        }

        #endregion

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

                strCardCode = LBCardHelper.ReadCardDirect();
                lblCardNum.Text = strCardCode;

                #region -- 读取卡号 --
                if (strCardCode != "")//读取返回信息
                {
                    this.lblCardSteady.Text = "稳定";
                    this.lblCardSteady.ForeColor = Color.Green;
                    this.pnlReadCardStatus.BackColor = Color.Green;

                    long lInBillID = 0;
                    _CurrentReadCardCode = strCardCode;//读取卡号

                    if (_CurrentReadCardCode != "")//卡号读取成功
                    {
                        bool bolIsSameCardCode = false;

                        #region -- 判断是否重复打开 --
                        DateTime previousReadCardTime = DateTime.MinValue;
                        string strPreviousCardCodeTime = GetLastTimeByCode(_CurrentReadCardCode);
                        if (strPreviousCardCodeTime != "")
                        {
                            DateTime.TryParse(strPreviousCardCodeTime, out previousReadCardTime);
                        }
                        //判断依据为如果本次打开与上次打卡(已成功生成单据)一致，以及本次称重值与上次称重值一致时，认为是重复打开
                        if (DateTime.Now.Subtract(previousReadCardTime).TotalMinutes < SystemConfigValue.SysReadCardLimit)
                        {
                            bolIsSameCardCode = true;
                        }

                        #endregion

                        if (!bolIsSameCardCode)
                        {
                            //读取该卡对应的车辆以及供应商信息
                            DataTable dtCarInfo = ExecuteSQL.CallView(117, "CarID,CarNum,SupplierID", "CardCode='" + _CurrentReadCardCode + "'", "");
                            if (dtCarInfo.Rows.Count > 0)
                            {
                                DataRow drCarInfo = dtCarInfo.Rows[0];
                                long lCarID = LBConverter.ToInt64(drCarInfo["CarID"]);
                                long lSupplierID = LBConverter.ToInt64(drCarInfo["SupplierID"]);
                                this.txtCarID.TextBox.Text = drCarInfo["CarNum"].ToString();

                                lInBillID = SaveBillAction(_CurrentReadCardCode);
                                if (lInBillID > 0)
                                {
                                    iSpeakTimes = 0;
                                }
                            }
                            else
                            {
                                throw new Exception("卡号无效！");
                            }
                        }
                        //else
                        //{
                        //    //mReadCardFailTimes = 0;
                        //    SendStatus(enAlermStatus.Fail);
                        //    LBSpeakHelper.SpeakString = "记录无效请离开！";
                        //}
                    }

                    //LBCardHelper.LstCardCode.Clear();
                    LBCardHelper.CardCode = "";
                }
                else
                {
                    lblCardNum.Text = "";
                }
                #endregion -- 读取卡号 --

            }
            catch (Exception ex)
            {
                SendStatus(enAlermStatus.Fail);
                LBSpeakHelper.SpeakString = ex.Message;
            }
            finally
            {
                LBCardHelper.CardCode = "";
                _CurrentReadCardCode = "";
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
                    if (dictValue.ContainsKey("TotalCar"))
                    {
                        iTotalCarCount = LBConverter.ToInt32(dictValue["TotalCar"]);
                    }
                }
                this.lblAllCar.Text = iTotalCarCount.ToString();
            }
            catch (Exception ex)
            {
                //LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }

        int iSpeakTimes = 0;//报读次数，只会报读5次，5次后自动停止
        private void MSpeakTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (LBSpeakHelper.SpeakString != "")
                {
                    
                    bool bolIsCompleted = LBSpeakHelper.Speak(LBSpeakHelper.SpeakString);
                    if(bolIsCompleted)
                        iSpeakTimes++;
                    if (iSpeakTimes >= 5)
                    {
                        LBSpeakHelper.SpeakString = "";
                        iSpeakTimes = 0;
                    }
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
            
            if (this.txtFilter.Text.TrimEnd() != "")
            {
                strFilter += " and ";
                strFilter += "(CarNum like '%" + this.txtFilter.Text.TrimEnd() + "%' or ";
                strFilter += "SupplierName like '%" + this.txtFilter.Text.TrimEnd() + "%') ";
            }
            DataTable dtBill = ExecuteSQL.CallView(128, "", strFilter, strSort);
            this.grdMain.DataSource = dtBill.DefaultView;
        }

        private string GetLastTimeByCode(string strCardCode)
        {
            string strBillDate = "";
            LBDbParameterCollection parmCol = new LBDbParameterCollection();
            parmCol.Add(new LBParameter("CardCode", enLBDbType.String, strCardCode));
            parmCol.Add(new LBParameter("BillDate", enLBDbType.DateTime, DateTime.Now));

            DataSet dsReturn;
            Dictionary<string, object> dictValue;
            ExecuteSQL.CallSP(14114, parmCol, out dsReturn, out dictValue);
            if (dictValue.ContainsKey("BillDate"))
            {
                strBillDate = dictValue["BillDate"].ToString(); ;
            }
            return strBillDate;
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
                }
                else
                {
                    this.txtSupplierID.TextBox.Text = "";
                }
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
        
        //保存并打印
        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                LBPermission.VerifyUserPermission("保存", "WeightSalesOutBill_Save");

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
                LBSpeakHelper.Speak(enSpeakType.ReadCardSuccess);
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
            decimal decCarTare = 0;
            decimal decTotalWeight= 0;
            decimal decSuttleWeight = 0;

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
            this.txtSupplierID.TextBox.Text = "";
        }

        #endregion

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (LB.WinFunction.LBCommonHelper.ConfirmMessage("是否确认退出系统？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
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
                    return true;
                }
                catch (Exception ex)
                {
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

        private void btnSQLBuilder_Click(object sender, EventArgs e)
        {
            ExportSQLConfig.ExportAction();
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmSysConfig frm = new frmSysConfig();
                LBShowForm.ShowDialog(frm);
            }
            catch (Exception ex)
            {
                LB.WinFunction.LBCommonHelper.DealWithErrorMessage(ex);
            }
        }
    }
}
