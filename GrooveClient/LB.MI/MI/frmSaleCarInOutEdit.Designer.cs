namespace LB.MI.MI
{
    partial class frmSaleCarInOutEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleCarInOutEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSuttleWeight = new LB.Controls.LBSkinTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarTare = new LB.Controls.LBSkinTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalWeight = new LB.Controls.LBSkinTextBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCarID = new LB.Controls.LBTextBox.CoolTextBox();
            this.txtSupplierID = new LB.Controls.LBTextBox.CoolTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new LB.Controls.LBSkinTextBox(this.components);
            this.lblBillDateIn = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaleCarInBillCode = new LB.Controls.LBSkinTextBox(this.components);
            this.skinLabel12 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel8 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel10 = new CCWin.SkinControl.SkinLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSalesIn = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.picIn4 = new System.Windows.Forms.PictureBox();
            this.picIn3 = new System.Windows.Forms.PictureBox();
            this.picIn2 = new System.Windows.Forms.PictureBox();
            this.picIn1 = new System.Windows.Forms.PictureBox();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.btnReflesh = new LB.Controls.LBToolStripButton(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancel = new LB.Controls.LBToolStripButton(this.components);
            this.btnUnCancel = new LB.Controls.LBToolStripButton(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChangeBillInfoSave = new LB.Controls.LBToolStripButton(this.components);
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpSalesIn.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn1)).BeginInit();
            this.skinToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 376);
            this.panel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSuttleWeight);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCarTare);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTotalWeight);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 171);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "重量/金额";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label6.Location = new System.Drawing.Point(409, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "净重:";
            // 
            // txtSuttleWeight
            // 
            this.txtSuttleWeight.BackColor = System.Drawing.Color.Transparent;
            this.txtSuttleWeight.CanBeEmpty = true;
            this.txtSuttleWeight.Caption = "";
            this.txtSuttleWeight.DownBack = null;
            this.txtSuttleWeight.Icon = null;
            this.txtSuttleWeight.IconIsButton = false;
            this.txtSuttleWeight.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSuttleWeight.IsPasswordChat = '\0';
            this.txtSuttleWeight.IsSystemPasswordChar = false;
            this.txtSuttleWeight.Lines = new string[0];
            this.txtSuttleWeight.Location = new System.Drawing.Point(461, 23);
            this.txtSuttleWeight.Margin = new System.Windows.Forms.Padding(0);
            this.txtSuttleWeight.MaxLength = 32767;
            this.txtSuttleWeight.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSuttleWeight.MouseBack = null;
            this.txtSuttleWeight.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSuttleWeight.Multiline = false;
            this.txtSuttleWeight.Name = "txtSuttleWeight";
            this.txtSuttleWeight.NormlBack = null;
            this.txtSuttleWeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtSuttleWeight.ReadOnly = true;
            this.txtSuttleWeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSuttleWeight.Size = new System.Drawing.Size(129, 28);
            // 
            // 
            // 
            this.txtSuttleWeight.SkinTxt.AccessibleName = "";
            this.txtSuttleWeight.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtSuttleWeight.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtSuttleWeight.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSuttleWeight.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSuttleWeight.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSuttleWeight.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSuttleWeight.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSuttleWeight.SkinTxt.Name = "BaseText";
            this.txtSuttleWeight.SkinTxt.ReadOnly = true;
            this.txtSuttleWeight.SkinTxt.Size = new System.Drawing.Size(119, 18);
            this.txtSuttleWeight.SkinTxt.TabIndex = 0;
            this.txtSuttleWeight.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSuttleWeight.SkinTxt.WaterText = "";
            this.txtSuttleWeight.TabIndex = 43;
            this.txtSuttleWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSuttleWeight.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSuttleWeight.WaterText = "";
            this.txtSuttleWeight.WordWrap = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(229, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "皮重:";
            // 
            // txtCarTare
            // 
            this.txtCarTare.BackColor = System.Drawing.Color.Transparent;
            this.txtCarTare.CanBeEmpty = true;
            this.txtCarTare.Caption = "";
            this.txtCarTare.DownBack = null;
            this.txtCarTare.Icon = null;
            this.txtCarTare.IconIsButton = false;
            this.txtCarTare.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCarTare.IsPasswordChat = '\0';
            this.txtCarTare.IsSystemPasswordChar = false;
            this.txtCarTare.Lines = new string[0];
            this.txtCarTare.Location = new System.Drawing.Point(278, 23);
            this.txtCarTare.Margin = new System.Windows.Forms.Padding(0);
            this.txtCarTare.MaxLength = 32767;
            this.txtCarTare.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtCarTare.MouseBack = null;
            this.txtCarTare.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCarTare.Multiline = false;
            this.txtCarTare.Name = "txtCarTare";
            this.txtCarTare.NormlBack = null;
            this.txtCarTare.Padding = new System.Windows.Forms.Padding(5);
            this.txtCarTare.ReadOnly = true;
            this.txtCarTare.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCarTare.Size = new System.Drawing.Size(116, 28);
            // 
            // 
            // 
            this.txtCarTare.SkinTxt.AccessibleName = "";
            this.txtCarTare.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtCarTare.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtCarTare.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCarTare.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCarTare.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCarTare.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtCarTare.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtCarTare.SkinTxt.Name = "BaseText";
            this.txtCarTare.SkinTxt.ReadOnly = true;
            this.txtCarTare.SkinTxt.Size = new System.Drawing.Size(106, 18);
            this.txtCarTare.SkinTxt.TabIndex = 0;
            this.txtCarTare.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCarTare.SkinTxt.WaterText = "";
            this.txtCarTare.TabIndex = 41;
            this.txtCarTare.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCarTare.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCarTare.WaterText = "";
            this.txtCarTare.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "毛重:";
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalWeight.CanBeEmpty = true;
            this.txtTotalWeight.Caption = "";
            this.txtTotalWeight.DownBack = null;
            this.txtTotalWeight.Icon = null;
            this.txtTotalWeight.IconIsButton = false;
            this.txtTotalWeight.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtTotalWeight.IsPasswordChat = '\0';
            this.txtTotalWeight.IsSystemPasswordChar = false;
            this.txtTotalWeight.Lines = new string[0];
            this.txtTotalWeight.Location = new System.Drawing.Point(92, 23);
            this.txtTotalWeight.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalWeight.MaxLength = 32767;
            this.txtTotalWeight.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtTotalWeight.MouseBack = null;
            this.txtTotalWeight.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtTotalWeight.Multiline = false;
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.NormlBack = null;
            this.txtTotalWeight.Padding = new System.Windows.Forms.Padding(5);
            this.txtTotalWeight.ReadOnly = true;
            this.txtTotalWeight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalWeight.Size = new System.Drawing.Size(125, 28);
            // 
            // 
            // 
            this.txtTotalWeight.SkinTxt.AccessibleName = "";
            this.txtTotalWeight.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtTotalWeight.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtTotalWeight.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTotalWeight.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalWeight.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalWeight.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtTotalWeight.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtTotalWeight.SkinTxt.Name = "BaseText";
            this.txtTotalWeight.SkinTxt.ReadOnly = true;
            this.txtTotalWeight.SkinTxt.Size = new System.Drawing.Size(115, 18);
            this.txtTotalWeight.SkinTxt.TabIndex = 0;
            this.txtTotalWeight.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtTotalWeight.SkinTxt.WaterText = "";
            this.txtTotalWeight.TabIndex = 39;
            this.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTotalWeight.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtTotalWeight.WaterText = "";
            this.txtTotalWeight.WordWrap = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCarID);
            this.groupBox1.Controls.Add(this.txtSupplierID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblBillDateIn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSaleCarInBillCode);
            this.groupBox1.Controls.Add(this.skinLabel12);
            this.groupBox1.Controls.Add(this.skinLabel8);
            this.groupBox1.Controls.Add(this.skinLabel10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 195);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "磅单详细信息";
            // 
            // txtCarID
            // 
            this.txtCarID.BackColor = System.Drawing.Color.Transparent;
            this.txtCarID.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtCarID.CanBeEmpty = false;
            this.txtCarID.Caption = "车号";
            this.txtCarID.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtCarID.LBTitle = "  ";
            this.txtCarID.LBTitleVisible = false;
            this.txtCarID.Location = new System.Drawing.Point(402, 61);
            this.txtCarID.Margin = new System.Windows.Forms.Padding(0);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.PopupWidth = 120;
            this.txtCarID.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.txtCarID.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtCarID.Size = new System.Drawing.Size(188, 34);
            this.txtCarID.TabIndex = 57;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BackColor = System.Drawing.Color.Transparent;
            this.txtSupplierID.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.txtSupplierID.CanBeEmpty = false;
            this.txtSupplierID.Caption = "客户名称";
            this.txtSupplierID.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtSupplierID.LBTitle = "  ";
            this.txtSupplierID.LBTitleVisible = false;
            this.txtSupplierID.Location = new System.Drawing.Point(109, 104);
            this.txtSupplierID.Margin = new System.Windows.Forms.Padding(0);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.PopupWidth = 120;
            this.txtSupplierID.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.txtSupplierID.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtSupplierID.Size = new System.Drawing.Size(481, 34);
            this.txtSupplierID.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "过 磅 时 间:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.CanBeEmpty = true;
            this.txtDescription.Caption = "";
            this.txtDescription.DownBack = null;
            this.txtDescription.Icon = null;
            this.txtDescription.IconIsButton = false;
            this.txtDescription.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDescription.IsPasswordChat = '\0';
            this.txtDescription.IsSystemPasswordChar = false;
            this.txtDescription.Lines = new string[0];
            this.txtDescription.Location = new System.Drawing.Point(109, 150);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(0);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtDescription.MouseBack = null;
            this.txtDescription.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.NormlBack = null;
            this.txtDescription.Padding = new System.Windows.Forms.Padding(5);
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.Size = new System.Drawing.Size(481, 31);
            // 
            // 
            // 
            this.txtDescription.SkinTxt.AccessibleName = "";
            this.txtDescription.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtDescription.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtDescription.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDescription.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtDescription.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtDescription.SkinTxt.Multiline = true;
            this.txtDescription.SkinTxt.Name = "BaseText";
            this.txtDescription.SkinTxt.ReadOnly = true;
            this.txtDescription.SkinTxt.Size = new System.Drawing.Size(471, 21);
            this.txtDescription.SkinTxt.TabIndex = 0;
            this.txtDescription.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDescription.SkinTxt.WaterText = "";
            this.txtDescription.TabIndex = 46;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtDescription.WaterText = "";
            this.txtDescription.WordWrap = true;
            // 
            // lblBillDateIn
            // 
            this.lblBillDateIn.AutoSize = true;
            this.lblBillDateIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBillDateIn.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lblBillDateIn.Location = new System.Drawing.Point(109, 18);
            this.lblBillDateIn.Name = "lblBillDateIn";
            this.lblBillDateIn.Size = new System.Drawing.Size(47, 23);
            this.lblBillDateIn.TabIndex = 3;
            this.lblBillDateIn.Text = "       ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(8, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "入 槽  单 号:";
            // 
            // txtSaleCarInBillCode
            // 
            this.txtSaleCarInBillCode.BackColor = System.Drawing.Color.Transparent;
            this.txtSaleCarInBillCode.CanBeEmpty = true;
            this.txtSaleCarInBillCode.Caption = "";
            this.txtSaleCarInBillCode.DownBack = null;
            this.txtSaleCarInBillCode.Icon = null;
            this.txtSaleCarInBillCode.IconIsButton = false;
            this.txtSaleCarInBillCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSaleCarInBillCode.IsPasswordChat = '\0';
            this.txtSaleCarInBillCode.IsSystemPasswordChar = false;
            this.txtSaleCarInBillCode.Lines = new string[0];
            this.txtSaleCarInBillCode.Location = new System.Drawing.Point(109, 61);
            this.txtSaleCarInBillCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtSaleCarInBillCode.MaxLength = 32767;
            this.txtSaleCarInBillCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSaleCarInBillCode.MouseBack = null;
            this.txtSaleCarInBillCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSaleCarInBillCode.Multiline = false;
            this.txtSaleCarInBillCode.Name = "txtSaleCarInBillCode";
            this.txtSaleCarInBillCode.NormlBack = null;
            this.txtSaleCarInBillCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtSaleCarInBillCode.ReadOnly = true;
            this.txtSaleCarInBillCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSaleCarInBillCode.Size = new System.Drawing.Size(188, 28);
            // 
            // 
            // 
            this.txtSaleCarInBillCode.SkinTxt.AccessibleName = "";
            this.txtSaleCarInBillCode.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtSaleCarInBillCode.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtSaleCarInBillCode.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSaleCarInBillCode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSaleCarInBillCode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSaleCarInBillCode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSaleCarInBillCode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSaleCarInBillCode.SkinTxt.Name = "BaseText";
            this.txtSaleCarInBillCode.SkinTxt.ReadOnly = true;
            this.txtSaleCarInBillCode.SkinTxt.Size = new System.Drawing.Size(178, 18);
            this.txtSaleCarInBillCode.SkinTxt.TabIndex = 0;
            this.txtSaleCarInBillCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSaleCarInBillCode.SkinTxt.WaterText = "";
            this.txtSaleCarInBillCode.TabIndex = 37;
            this.txtSaleCarInBillCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSaleCarInBillCode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSaleCarInBillCode.WaterText = "";
            this.txtSaleCarInBillCode.WordWrap = true;
            // 
            // skinLabel12
            // 
            this.skinLabel12.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel12.BorderColor = System.Drawing.Color.White;
            this.skinLabel12.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.skinLabel12.Location = new System.Drawing.Point(27, 154);
            this.skinLabel12.Name = "skinLabel12";
            this.skinLabel12.Size = new System.Drawing.Size(79, 21);
            this.skinLabel12.TabIndex = 52;
            this.skinLabel12.Text = "备     注:";
            this.skinLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel8
            // 
            this.skinLabel8.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel8.BorderColor = System.Drawing.Color.White;
            this.skinLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.skinLabel8.Location = new System.Drawing.Point(330, 64);
            this.skinLabel8.Name = "skinLabel8";
            this.skinLabel8.Size = new System.Drawing.Size(77, 21);
            this.skinLabel8.TabIndex = 48;
            this.skinLabel8.Text = "车      号:";
            this.skinLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // skinLabel10
            // 
            this.skinLabel10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel10.BorderColor = System.Drawing.Color.White;
            this.skinLabel10.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.skinLabel10.Location = new System.Drawing.Point(2, 109);
            this.skinLabel10.Name = "skinLabel10";
            this.skinLabel10.Size = new System.Drawing.Size(104, 21);
            this.skinLabel10.TabIndex = 50;
            this.skinLabel10.Text = "供应商名称:";
            this.skinLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 10);
            this.panel3.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(605, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 376);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(615, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 376);
            this.panel2.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSalesIn);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(302, 376);
            this.tabControl1.TabIndex = 0;
            // 
            // tpSalesIn
            // 
            this.tpSalesIn.Controls.Add(this.tableLayoutPanel1);
            this.tpSalesIn.Location = new System.Drawing.Point(4, 22);
            this.tpSalesIn.Name = "tpSalesIn";
            this.tpSalesIn.Padding = new System.Windows.Forms.Padding(3);
            this.tpSalesIn.Size = new System.Drawing.Size(294, 350);
            this.tpSalesIn.TabIndex = 0;
            this.tpSalesIn.Text = "入槽称重图片";
            this.tpSalesIn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.picIn4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picIn3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.picIn2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picIn1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 344);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // picIn4
            // 
            this.picIn4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIn4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIn4.Location = new System.Drawing.Point(147, 175);
            this.picIn4.Name = "picIn4";
            this.picIn4.Size = new System.Drawing.Size(138, 166);
            this.picIn4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIn4.TabIndex = 3;
            this.picIn4.TabStop = false;
            // 
            // picIn3
            // 
            this.picIn3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIn3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIn3.Location = new System.Drawing.Point(3, 175);
            this.picIn3.Name = "picIn3";
            this.picIn3.Size = new System.Drawing.Size(138, 166);
            this.picIn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIn3.TabIndex = 2;
            this.picIn3.TabStop = false;
            // 
            // picIn2
            // 
            this.picIn2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIn2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIn2.Location = new System.Drawing.Point(147, 3);
            this.picIn2.Name = "picIn2";
            this.picIn2.Size = new System.Drawing.Size(138, 166);
            this.picIn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIn2.TabIndex = 1;
            this.picIn2.TabStop = false;
            // 
            // picIn1
            // 
            this.picIn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picIn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIn1.Location = new System.Drawing.Point(3, 3);
            this.picIn1.Name = "picIn1";
            this.picIn1.Size = new System.Drawing.Size(138, 166);
            this.picIn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIn1.TabIndex = 0;
            this.picIn1.TabStop = false;
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
            this.btnReflesh,
            this.toolStripSeparator1,
            this.btnCancel,
            this.btnUnCancel,
            this.toolStripSeparator2,
            this.btnChangeBillInfoSave,
            this.toolStripSeparator3});
            this.skinToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(917, 40);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 8;
            this.skinToolStrip1.Text = "skinToolStrip1";
            this.skinToolStrip1.TitleAnamorphosis = true;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.LBPermissionCode = "";
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 37);
            this.btnClose.Text = "关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReflesh
            // 
            this.btnReflesh.Image = ((System.Drawing.Image)(resources.GetObject("btnReflesh.Image")));
            this.btnReflesh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReflesh.LBPermissionCode = "";
            this.btnReflesh.Name = "btnReflesh";
            this.btnReflesh.Size = new System.Drawing.Size(36, 37);
            this.btnReflesh.Text = "刷新";
            this.btnReflesh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::LB.MI.Properties.Resources.btnUnPostInUse;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.LBPermissionCode = "SalesManager_Cancel";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(36, 37);
            this.btnCancel.Text = "作废";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUnCancel
            // 
            this.btnUnCancel.Image = global::LB.MI.Properties.Resources.btnReset;
            this.btnUnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnCancel.LBPermissionCode = "SalesManager_UnCancel";
            this.btnUnCancel.Name = "btnUnCancel";
            this.btnUnCancel.Size = new System.Drawing.Size(60, 37);
            this.btnUnCancel.Text = "取消作废";
            this.btnUnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUnCancel.Click += new System.EventHandler(this.btnUnCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnChangeBillInfoSave
            // 
            this.btnChangeBillInfoSave.Image = global::LB.MI.Properties.Resources.btnNewSave31;
            this.btnChangeBillInfoSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeBillInfoSave.LBPermissionCode = "SalesManager_ChangeDirect";
            this.btnChangeBillInfoSave.Name = "btnChangeBillInfoSave";
            this.btnChangeBillInfoSave.Size = new System.Drawing.Size(60, 37);
            this.btnChangeBillInfoSave.Text = "保存修改";
            this.btnChangeBillInfoSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChangeBillInfoSave.Click += new System.EventHandler(this.btnChangeBillInfoSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // frmSaleCarInOutEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.skinToolStrip1);
            this.Name = "frmSaleCarInOutEdit";
            this.Size = new System.Drawing.Size(917, 416);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpSalesIn.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIn1)).EndInit();
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private Controls.LBToolStripButton btnClose;
        private Controls.LBToolStripButton btnReflesh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.LBToolStripButton btnCancel;
        private Controls.LBToolStripButton btnUnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSalesIn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBillDateIn;
        private System.Windows.Forms.Label label4;
        private Controls.LBSkinTextBox txtSaleCarInBillCode;
        private Controls.LBSkinTextBox txtDescription;
        private CCWin.SkinControl.SkinLabel skinLabel12;
        private CCWin.SkinControl.SkinLabel skinLabel10;
        private CCWin.SkinControl.SkinLabel skinLabel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picIn4;
        private System.Windows.Forms.PictureBox picIn3;
        private System.Windows.Forms.PictureBox picIn2;
        private System.Windows.Forms.PictureBox picIn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private Controls.LBSkinTextBox txtTotalWeight;
        private System.Windows.Forms.Label label5;
        private Controls.LBSkinTextBox txtCarTare;
        private System.Windows.Forms.Label label6;
        private Controls.LBSkinTextBox txtSuttleWeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Controls.LBToolStripButton btnChangeBillInfoSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Controls.LBTextBox.CoolTextBox txtSupplierID;
        private Controls.LBTextBox.CoolTextBox txtCarID;
    }
}
