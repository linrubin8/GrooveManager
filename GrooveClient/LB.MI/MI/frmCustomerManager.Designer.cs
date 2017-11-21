namespace LB.MI
{
    partial class frmCustomerManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerManager));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.btnAdd = new LB.Controls.LBToolStripButton(this.components);
            this.btnOpenEdit = new LB.Controls.LBToolStripButton(this.components);
            this.btnCopy = new LB.Controls.LBToolStripButton(this.components);
            this.btnReflesh = new LB.Controls.LBToolStripButton(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctlSearcher1 = new LB.Controls.Searcher.CtlSearcher();
            this.txtSearchText = new LB.Controls.LBSkinTextBox(this.components);
            this.grdMain = new LB.Controls.LBDataGridView(this.components);
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemainReceivedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarIsLimit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AmountTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicenceNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsForbid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReceiveTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDisplayAmount = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsDisplayPrice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsPrintAmount = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAllowOverFul = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
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
            this.btnAdd,
            this.btnOpenEdit,
            this.btnCopy,
            this.btnReflesh,
            this.toolStripSeparator1});
            this.skinToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(819, 40);
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
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.LBPermissionCode = "";
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 37);
            this.btnClose.Text = "关闭";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.LBPermissionCode = "DBCustomer_Add";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 37);
            this.btnAdd.Text = "添加新客户";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOpenEdit
            // 
            this.btnOpenEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenEdit.Image")));
            this.btnOpenEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenEdit.LBPermissionCode = "DBCustomer_Update";
            this.btnOpenEdit.Name = "btnOpenEdit";
            this.btnOpenEdit.Size = new System.Drawing.Size(36, 37);
            this.btnOpenEdit.Text = "编辑";
            this.btnOpenEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenEdit.Click += new System.EventHandler(this.btnOpenEdit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.LBPermissionCode = "DBCustomer_Copy";
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(36, 37);
            this.btnCopy.Text = "复制";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
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
            this.btnReflesh.Click += new System.EventHandler(this.btnReflesh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // ctlSearcher1
            // 
            this.ctlSearcher1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlSearcher1.Location = new System.Drawing.Point(0, 40);
            this.ctlSearcher1.Name = "ctlSearcher1";
            this.ctlSearcher1.Size = new System.Drawing.Size(819, 47);
            this.ctlSearcher1.TabIndex = 5;
            // 
            // txtSearchText
            // 
            this.txtSearchText.BackColor = System.Drawing.Color.Transparent;
            this.txtSearchText.CanBeEmpty = true;
            this.txtSearchText.Caption = "备注";
            this.txtSearchText.DownBack = null;
            this.txtSearchText.Icon = null;
            this.txtSearchText.IconIsButton = false;
            this.txtSearchText.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSearchText.IsPasswordChat = '\0';
            this.txtSearchText.IsSystemPasswordChar = false;
            this.txtSearchText.Lines = new string[0];
            this.txtSearchText.Location = new System.Drawing.Point(349, 55);
            this.txtSearchText.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchText.MaxLength = 32767;
            this.txtSearchText.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSearchText.MouseBack = null;
            this.txtSearchText.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSearchText.Multiline = false;
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.NormlBack = null;
            this.txtSearchText.Padding = new System.Windows.Forms.Padding(5);
            this.txtSearchText.ReadOnly = false;
            this.txtSearchText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearchText.Size = new System.Drawing.Size(130, 28);
            // 
            // 
            // 
            this.txtSearchText.SkinTxt.AccessibleName = "";
            this.txtSearchText.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtSearchText.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtSearchText.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearchText.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchText.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchText.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSearchText.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSearchText.SkinTxt.Name = "BaseText";
            this.txtSearchText.SkinTxt.Size = new System.Drawing.Size(120, 18);
            this.txtSearchText.SkinTxt.TabIndex = 0;
            this.txtSearchText.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSearchText.SkinTxt.WaterText = "";
            this.txtSearchText.TabIndex = 24;
            this.txtSearchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearchText.Visible = false;
            this.txtSearchText.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSearchText.WaterText = "";
            this.txtSearchText.WordWrap = true;
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.grdMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMain.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdMain.ColumnFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerCode,
            this.CustomerName,
            this.RemainReceivedAmount,
            this.Contact,
            this.Phone,
            this.Address,
            this.CarIsLimit,
            this.AmountTypeName,
            this.LicenceNum,
            this.Description,
            this.IsForbid,
            this.ReceiveTypeName,
            this.CreditAmount,
            this.IsDisplayAmount,
            this.IsDisplayPrice,
            this.IsPrintAmount,
            this.IsAllowOverFul,
            this.CreateBy,
            this.CreateTime,
            this.ChangeBy,
            this.ChangeTime});
            this.grdMain.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdMain.EnableHeadersVisualStyles = false;
            this.grdMain.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdMain.HeadFont = null;
            this.grdMain.HeadForeColor = System.Drawing.Color.Empty;
            this.grdMain.HeadSelectBackColor = System.Drawing.Color.Empty;
            this.grdMain.HeadSelectForeColor = System.Drawing.Color.Empty;
            this.grdMain.LineNumberForeColor = System.Drawing.Color.MidnightBlue;
            this.grdMain.Location = new System.Drawing.Point(0, 87);
            this.grdMain.Name = "grdMain";
            this.grdMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdMain.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdMain.RowTemplate.Height = 23;
            this.grdMain.Size = new System.Drawing.Size(819, 223);
            this.grdMain.TabIndex = 6;
            this.grdMain.TitleBack = null;
            this.grdMain.TitleBackColorBegin = System.Drawing.Color.White;
            this.grdMain.TitleBackColorEnd = System.Drawing.SystemColors.ActiveBorder;
            // 
            // CustomerCode
            // 
            this.CustomerCode.DataPropertyName = "CustomerCode";
            this.CustomerCode.HeaderText = "编码";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            this.CustomerCode.Width = 80;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "客户名称";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // RemainReceivedAmount
            // 
            this.RemainReceivedAmount.DataPropertyName = "RemainReceivedAmount";
            this.RemainReceivedAmount.HeaderText = "客户余额";
            this.RemainReceivedAmount.Name = "RemainReceivedAmount";
            this.RemainReceivedAmount.ReadOnly = true;
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "Contact";
            this.Contact.HeaderText = "联系人名称";
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "联系人电话";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "地址";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // CarIsLimit
            // 
            this.CarIsLimit.DataPropertyName = "CarIsLimit";
            this.CarIsLimit.HeaderText = "车辆是否限制";
            this.CarIsLimit.Name = "CarIsLimit";
            this.CarIsLimit.ReadOnly = true;
            this.CarIsLimit.Width = 120;
            // 
            // AmountTypeName
            // 
            this.AmountTypeName.DataPropertyName = "AmountTypeName";
            this.AmountTypeName.HeaderText = "金额格式";
            this.AmountTypeName.Name = "AmountTypeName";
            this.AmountTypeName.ReadOnly = true;
            // 
            // LicenceNum
            // 
            this.LicenceNum.DataPropertyName = "LicenceNum";
            this.LicenceNum.HeaderText = "营业执照号";
            this.LicenceNum.Name = "LicenceNum";
            this.LicenceNum.ReadOnly = true;
            this.LicenceNum.Visible = false;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "备注";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // IsForbid
            // 
            this.IsForbid.DataPropertyName = "IsForbid";
            this.IsForbid.HeaderText = "是否禁用";
            this.IsForbid.Name = "IsForbid";
            this.IsForbid.ReadOnly = true;
            // 
            // ReceiveTypeName
            // 
            this.ReceiveTypeName.DataPropertyName = "ReceiveTypeName";
            this.ReceiveTypeName.HeaderText = "收款方式";
            this.ReceiveTypeName.Name = "ReceiveTypeName";
            this.ReceiveTypeName.ReadOnly = true;
            // 
            // CreditAmount
            // 
            this.CreditAmount.DataPropertyName = "CreditAmount";
            this.CreditAmount.HeaderText = "信用额度";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.ReadOnly = true;
            // 
            // IsDisplayAmount
            // 
            this.IsDisplayAmount.DataPropertyName = "IsDisplayAmount";
            this.IsDisplayAmount.HeaderText = "显示金额";
            this.IsDisplayAmount.Name = "IsDisplayAmount";
            this.IsDisplayAmount.ReadOnly = true;
            // 
            // IsDisplayPrice
            // 
            this.IsDisplayPrice.DataPropertyName = "IsDisplayPrice";
            this.IsDisplayPrice.HeaderText = "显示单价";
            this.IsDisplayPrice.Name = "IsDisplayPrice";
            this.IsDisplayPrice.ReadOnly = true;
            // 
            // IsPrintAmount
            // 
            this.IsPrintAmount.DataPropertyName = "IsPrintAmount";
            this.IsPrintAmount.HeaderText = "是否打印金额";
            this.IsPrintAmount.Name = "IsPrintAmount";
            this.IsPrintAmount.ReadOnly = true;
            // 
            // IsAllowOverFul
            // 
            this.IsAllowOverFul.DataPropertyName = "IsAllowOverFul";
            this.IsAllowOverFul.HeaderText = "是否允许超额提货";
            this.IsAllowOverFul.Name = "IsAllowOverFul";
            this.IsAllowOverFul.ReadOnly = true;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "创建人";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.DataPropertyName = "CreateTime";
            this.CreateTime.HeaderText = "创建时间";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            // 
            // ChangeBy
            // 
            this.ChangeBy.DataPropertyName = "ChangeBy";
            this.ChangeBy.HeaderText = "修改人";
            this.ChangeBy.Name = "ChangeBy";
            this.ChangeBy.ReadOnly = true;
            // 
            // ChangeTime
            // 
            this.ChangeTime.DataPropertyName = "ChangeTime";
            this.ChangeTime.HeaderText = "修改时间";
            this.ChangeTime.Name = "ChangeTime";
            this.ChangeTime.ReadOnly = true;
            // 
            // frmCustomerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.ctlSearcher1);
            this.Controls.Add(this.skinToolStrip1);
            this.Controls.Add(this.txtSearchText);
            this.LBPageTitle = "客户资料管理";
            this.Name = "frmCustomerManager";
            this.Size = new System.Drawing.Size(819, 310);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private Controls.LBToolStripButton btnClose;
        private Controls.LBToolStripButton btnAdd;
        private Controls.LBToolStripButton btnReflesh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.LBToolStripButton btnCopy;
        private Controls.LBToolStripButton btnOpenEdit;
        private Controls.Searcher.CtlSearcher ctlSearcher1;
        private Controls.LBSkinTextBox txtSearchText;
        private Controls.LBDataGridView grdMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemainReceivedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CarIsLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LicenceNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsForbid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiveTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDisplayAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDisplayPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsPrintAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAllowOverFul;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeTime;
    }
}
