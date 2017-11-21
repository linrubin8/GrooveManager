namespace LB.SysConfig
{
    partial class frmLogManager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogManager));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new LB.Controls.LBSkinButton(this.components);
            this.grdMain = new LB.Controls.LBDataGridView(this.components);
            this.WeightLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InWeightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SteadyWeightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutWeightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pbOutScreen = new System.Windows.Forms.PictureBox();
            this.pbOutCamera = new System.Windows.Forms.PictureBox();
            this.pbSteadyScreen = new System.Windows.Forms.PictureBox();
            this.pbSteadyCamera = new System.Windows.Forms.PictureBox();
            this.pbInScreen = new System.Windows.Forms.PictureBox();
            this.pbInCamera = new System.Windows.Forms.PictureBox();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtBillTimeTo = new System.Windows.Forms.DateTimePicker();
            this.txtBillDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtBillTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.txtBillDateFrom = new System.Windows.Forms.DateTimePicker();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSteadyScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSteadyCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInCamera)).BeginInit();
            this.skinToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.skinLabel7);
            this.panel1.Controls.Add(this.txtBillTimeTo);
            this.panel1.Controls.Add(this.txtBillDateTo);
            this.panel1.Controls.Add(this.txtBillTimeFrom);
            this.panel1.Controls.Add(this.txtBillDateFrom);
            this.panel1.Controls.Add(this.skinLabel6);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1317, 45);
            this.panel1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BaseColor = System.Drawing.Color.LightGray;
            this.btnSearch.BorderColor = System.Drawing.Color.Gray;
            this.btnSearch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSearch.DownBack = null;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSearch.LBPermissionCode = "";
            this.btnSearch.Location = new System.Drawing.Point(631, 9);
            this.btnSearch.MouseBack = null;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormlBack = null;
            this.btnSearch.Size = new System.Drawing.Size(75, 31);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.grdMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.grdMain.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdMain.ColumnFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WeightLogID,
            this.InWeightTime,
            this.SteadyWeightTime,
            this.OutWeightTime});
            this.grdMain.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMain.DefaultCellStyle = dataGridViewCellStyle15;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMain.EnableHeadersVisualStyles = false;
            this.grdMain.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdMain.HeadFont = null;
            this.grdMain.HeadForeColor = System.Drawing.Color.Empty;
            this.grdMain.HeadSelectBackColor = System.Drawing.Color.Empty;
            this.grdMain.HeadSelectForeColor = System.Drawing.Color.Empty;
            this.grdMain.LineNumberForeColor = System.Drawing.Color.MidnightBlue;
            this.grdMain.Location = new System.Drawing.Point(0, 0);
            this.grdMain.Name = "grdMain";
            this.grdMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdMain.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.grdMain.RowTemplate.Height = 23;
            this.grdMain.Size = new System.Drawing.Size(699, 362);
            this.grdMain.TabIndex = 4;
            this.grdMain.TitleBack = null;
            this.grdMain.TitleBackColorBegin = System.Drawing.Color.White;
            this.grdMain.TitleBackColorEnd = System.Drawing.SystemColors.ActiveBorder;
            this.grdMain.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdMain_CellMouseClick);
            // 
            // WeightLogID
            // 
            this.WeightLogID.DataPropertyName = "WeightLogID";
            this.WeightLogID.HeaderText = "流水号";
            this.WeightLogID.Name = "WeightLogID";
            this.WeightLogID.ReadOnly = true;
            this.WeightLogID.Visible = false;
            // 
            // InWeightTime
            // 
            this.InWeightTime.DataPropertyName = "InWeightTime";
            this.InWeightTime.HeaderText = "进磅时间";
            this.InWeightTime.Name = "InWeightTime";
            this.InWeightTime.ReadOnly = true;
            this.InWeightTime.Width = 200;
            // 
            // SteadyWeightTime
            // 
            this.SteadyWeightTime.DataPropertyName = "SteadyWeightTime";
            this.SteadyWeightTime.HeaderText = "地磅稳定时间";
            this.SteadyWeightTime.Name = "SteadyWeightTime";
            this.SteadyWeightTime.ReadOnly = true;
            this.SteadyWeightTime.Width = 200;
            // 
            // OutWeightTime
            // 
            this.OutWeightTime.DataPropertyName = "OutWeightTime";
            this.OutWeightTime.HeaderText = "离开地磅时间";
            this.OutWeightTime.Name = "OutWeightTime";
            this.OutWeightTime.ReadOnly = true;
            this.OutWeightTime.Width = 200;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdMain);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1317, 362);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.splitter2);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(699, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 362);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pbInScreen);
            this.panel4.Controls.Add(this.pbInCamera);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(618, 138);
            this.panel4.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 138);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(618, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pbSteadyScreen);
            this.panel5.Controls.Add(this.pbSteadyCamera);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 141);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(618, 138);
            this.panel5.TabIndex = 2;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 279);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(618, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pbOutScreen);
            this.panel6.Controls.Add(this.pbOutCamera);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 282);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(618, 80);
            this.panel6.TabIndex = 4;
            // 
            // pbOutScreen
            // 
            this.pbOutScreen.BackColor = System.Drawing.Color.White;
            this.pbOutScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOutScreen.Location = new System.Drawing.Point(347, 0);
            this.pbOutScreen.Name = "pbOutScreen";
            this.pbOutScreen.Size = new System.Drawing.Size(271, 80);
            this.pbOutScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOutScreen.TabIndex = 3;
            this.pbOutScreen.TabStop = false;
            // 
            // pbOutCamera
            // 
            this.pbOutCamera.BackColor = System.Drawing.Color.White;
            this.pbOutCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbOutCamera.Location = new System.Drawing.Point(0, 0);
            this.pbOutCamera.Name = "pbOutCamera";
            this.pbOutCamera.Size = new System.Drawing.Size(347, 80);
            this.pbOutCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOutCamera.TabIndex = 2;
            this.pbOutCamera.TabStop = false;
            // 
            // pbSteadyScreen
            // 
            this.pbSteadyScreen.BackColor = System.Drawing.Color.White;
            this.pbSteadyScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSteadyScreen.Location = new System.Drawing.Point(347, 0);
            this.pbSteadyScreen.Name = "pbSteadyScreen";
            this.pbSteadyScreen.Size = new System.Drawing.Size(271, 138);
            this.pbSteadyScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSteadyScreen.TabIndex = 2;
            this.pbSteadyScreen.TabStop = false;
            // 
            // pbSteadyCamera
            // 
            this.pbSteadyCamera.BackColor = System.Drawing.Color.White;
            this.pbSteadyCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbSteadyCamera.Location = new System.Drawing.Point(0, 0);
            this.pbSteadyCamera.Name = "pbSteadyCamera";
            this.pbSteadyCamera.Size = new System.Drawing.Size(347, 138);
            this.pbSteadyCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSteadyCamera.TabIndex = 1;
            this.pbSteadyCamera.TabStop = false;
            // 
            // pbInScreen
            // 
            this.pbInScreen.BackColor = System.Drawing.Color.White;
            this.pbInScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbInScreen.Location = new System.Drawing.Point(347, 0);
            this.pbInScreen.Name = "pbInScreen";
            this.pbInScreen.Size = new System.Drawing.Size(271, 138);
            this.pbInScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbInScreen.TabIndex = 1;
            this.pbInScreen.TabStop = false;
            // 
            // pbInCamera
            // 
            this.pbInCamera.BackColor = System.Drawing.Color.White;
            this.pbInCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbInCamera.Location = new System.Drawing.Point(0, 0);
            this.pbInCamera.Name = "pbInCamera";
            this.pbInCamera.Size = new System.Drawing.Size(347, 138);
            this.pbInCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbInCamera.TabIndex = 0;
            this.pbInCamera.TabStop = false;
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Arrow = System.Drawing.Color.Black;
            this.skinToolStrip1.Back = System.Drawing.Color.White;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseForeAnamorphosis = false;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.BaseItemAnamorphosis = true;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemBorderShow = true;
            this.skinToolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemDown")));
            this.skinToolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemMouse")));
            this.skinToolStrip1.BaseItemNorml = null;
            this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemRadius = 4;
            this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BindTabControl = null;
            this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip1.Fore = System.Drawing.Color.Black;
            this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.ItemAnamorphosis = true;
            this.skinToolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemBorderShow = true;
            this.skinToolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemRadius = 4;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator1});
            this.skinToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(1317, 40);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 3;
            this.skinToolStrip1.Text = "skinToolStrip1";
            this.skinToolStrip1.TitleAnamorphosis = true;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::LB.SysConfig.Properties.Resources.btnClose;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.LBPermissionCode = "";
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 37);
            this.btnClose.Text = "关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // txtBillTimeTo
            // 
            this.txtBillTimeTo.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.txtBillTimeTo.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBillTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtBillTimeTo.Location = new System.Drawing.Point(540, 11);
            this.txtBillTimeTo.Name = "txtBillTimeTo";
            this.txtBillTimeTo.Size = new System.Drawing.Size(85, 26);
            this.txtBillTimeTo.TabIndex = 61;
            // 
            // txtBillDateTo
            // 
            this.txtBillDateTo.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.txtBillDateTo.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBillDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtBillDateTo.Location = new System.Drawing.Point(409, 11);
            this.txtBillDateTo.Name = "txtBillDateTo";
            this.txtBillDateTo.Size = new System.Drawing.Size(125, 26);
            this.txtBillDateTo.TabIndex = 60;
            // 
            // txtBillTimeFrom
            // 
            this.txtBillTimeFrom.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.txtBillTimeFrom.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBillTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtBillTimeFrom.Location = new System.Drawing.Point(270, 10);
            this.txtBillTimeFrom.Name = "txtBillTimeFrom";
            this.txtBillTimeFrom.Size = new System.Drawing.Size(96, 26);
            this.txtBillTimeFrom.TabIndex = 59;
            // 
            // txtBillDateFrom
            // 
            this.txtBillDateFrom.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.txtBillDateFrom.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBillDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtBillDateFrom.Location = new System.Drawing.Point(141, 10);
            this.txtBillDateFrom.Name = "txtBillDateFrom";
            this.txtBillDateFrom.Size = new System.Drawing.Size(123, 26);
            this.txtBillDateFrom.TabIndex = 58;
            // 
            // skinLabel6
            // 
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.skinLabel6.Location = new System.Drawing.Point(370, 13);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(28, 21);
            this.skinLabel6.TabIndex = 57;
            this.skinLabel6.Text = "至";
            this.skinLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel7
            // 
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.skinLabel7.Location = new System.Drawing.Point(3, 11);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(132, 21);
            this.skinLabel7.TabIndex = 62;
            this.skinLabel7.Text = "地磅稳定时间";
            this.skinLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLogManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.skinToolStrip1);
            this.LBPageTitle = "操作日志";
            this.Name = "frmLogManager";
            this.Size = new System.Drawing.Size(1317, 447);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSteadyScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSteadyCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInCamera)).EndInit();
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.LBToolStripButton btnClose;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private Controls.LBDataGridView grdMain;
        private Controls.LBSkinButton btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn InWeightTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SteadyWeightTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutWeightTime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbOutScreen;
        private System.Windows.Forms.PictureBox pbOutCamera;
        private System.Windows.Forms.PictureBox pbSteadyScreen;
        private System.Windows.Forms.PictureBox pbSteadyCamera;
        private System.Windows.Forms.PictureBox pbInScreen;
        private System.Windows.Forms.PictureBox pbInCamera;
        private System.Windows.Forms.DateTimePicker txtBillTimeTo;
        private System.Windows.Forms.DateTimePicker txtBillDateTo;
        private System.Windows.Forms.DateTimePicker txtBillTimeFrom;
        private System.Windows.Forms.DateTimePicker txtBillDateFrom;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinLabel skinLabel7;
    }
}
