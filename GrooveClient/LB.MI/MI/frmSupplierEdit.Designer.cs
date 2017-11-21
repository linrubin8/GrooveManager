namespace LB.MI
{
    partial class frmSupplierEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierEdit));
            this.txtSupplierName = new LB.Controls.LBSkinTextBox(this.components);
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.txtSupplierCode = new LB.Controls.LBSkinTextBox(this.components);
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.btnAdd = new LB.Controls.LBToolStripButton(this.components);
            this.btnSave = new LB.Controls.LBToolStripButton(this.components);
            this.btnDelete = new LB.Controls.LBToolStripButton(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbIsForbidden = new System.Windows.Forms.CheckBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.Color.Transparent;
            this.txtSupplierName.CanBeEmpty = false;
            this.txtSupplierName.Caption = "供应商名称";
            this.txtSupplierName.DownBack = null;
            this.txtSupplierName.Icon = null;
            this.txtSupplierName.IconIsButton = false;
            this.txtSupplierName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSupplierName.IsPasswordChat = '\0';
            this.txtSupplierName.IsSystemPasswordChar = false;
            this.txtSupplierName.Lines = new string[0];
            this.txtSupplierName.Location = new System.Drawing.Point(130, 96);
            this.txtSupplierName.Margin = new System.Windows.Forms.Padding(0);
            this.txtSupplierName.MaxLength = 32767;
            this.txtSupplierName.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSupplierName.MouseBack = null;
            this.txtSupplierName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSupplierName.Multiline = false;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.NormlBack = null;
            this.txtSupplierName.Padding = new System.Windows.Forms.Padding(5);
            this.txtSupplierName.ReadOnly = false;
            this.txtSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupplierName.Size = new System.Drawing.Size(204, 28);
            // 
            // 
            // 
            this.txtSupplierName.SkinTxt.AccessibleName = "";
            this.txtSupplierName.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtSupplierName.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtSupplierName.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSupplierName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplierName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSupplierName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSupplierName.SkinTxt.Name = "BaseText";
            this.txtSupplierName.SkinTxt.Size = new System.Drawing.Size(194, 18);
            this.txtSupplierName.SkinTxt.TabIndex = 0;
            this.txtSupplierName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSupplierName.SkinTxt.WaterText = "";
            this.txtSupplierName.TabIndex = 14;
            this.txtSupplierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSupplierName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSupplierName.WaterText = "";
            this.txtSupplierName.WordWrap = true;
            // 
            // skinLabel2
            // 
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(3, 96);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(97, 32);
            this.skinLabel2.TabIndex = 16;
            this.skinLabel2.Text = "供应商名称";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel5
            // 
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(14, 52);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(77, 32);
            this.skinLabel5.TabIndex = 22;
            this.skinLabel5.Text = "自动编码";
            this.skinLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.Color.Transparent;
            this.txtSupplierCode.CanBeEmpty = true;
            this.txtSupplierCode.Caption = "";
            this.txtSupplierCode.DownBack = null;
            this.txtSupplierCode.Icon = null;
            this.txtSupplierCode.IconIsButton = false;
            this.txtSupplierCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSupplierCode.IsPasswordChat = '\0';
            this.txtSupplierCode.IsSystemPasswordChar = false;
            this.txtSupplierCode.Lines = new string[0];
            this.txtSupplierCode.Location = new System.Drawing.Point(130, 56);
            this.txtSupplierCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtSupplierCode.MaxLength = 32767;
            this.txtSupplierCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSupplierCode.MouseBack = null;
            this.txtSupplierCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSupplierCode.Multiline = false;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.NormlBack = null;
            this.txtSupplierCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtSupplierCode.ReadOnly = true;
            this.txtSupplierCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSupplierCode.Size = new System.Drawing.Size(204, 28);
            // 
            // 
            // 
            this.txtSupplierCode.SkinTxt.AccessibleName = "";
            this.txtSupplierCode.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtSupplierCode.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtSupplierCode.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSupplierCode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierCode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSupplierCode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSupplierCode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSupplierCode.SkinTxt.Name = "BaseText";
            this.txtSupplierCode.SkinTxt.ReadOnly = true;
            this.txtSupplierCode.SkinTxt.Size = new System.Drawing.Size(194, 18);
            this.txtSupplierCode.SkinTxt.TabIndex = 0;
            this.txtSupplierCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSupplierCode.SkinTxt.WaterText = "";
            this.txtSupplierCode.TabIndex = 15;
            this.txtSupplierCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSupplierCode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSupplierCode.WaterText = "";
            this.txtSupplierCode.WordWrap = true;
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
            this.btnSave,
            this.btnDelete,
            this.toolStripSeparator1});
            this.skinToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(382, 40);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 5;
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
            this.btnAdd.LBPermissionCode = "";
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 37);
            this.btnAdd.Text = "继续添加";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.LBPermissionCode = "";
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 37);
            this.btnSave.Text = "保存";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.LBPermissionCode = "";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(36, 37);
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // cbIsForbidden
            // 
            this.cbIsForbidden.AutoSize = true;
            this.cbIsForbidden.Location = new System.Drawing.Point(130, 151);
            this.cbIsForbidden.Name = "cbIsForbidden";
            this.cbIsForbidden.Size = new System.Drawing.Size(15, 14);
            this.cbIsForbidden.TabIndex = 23;
            this.cbIsForbidden.UseVisualStyleBackColor = true;
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(3, 138);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(97, 32);
            this.skinLabel1.TabIndex = 24;
            this.skinLabel1.Text = "是否禁用";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSupplierEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.cbIsForbidden);
            this.Controls.Add(this.txtSupplierCode);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.skinToolStrip1);
            this.LBPageTitle = "编辑供应商信息";
            this.Name = "frmSupplierEdit";
            this.Size = new System.Drawing.Size(382, 185);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private Controls.LBToolStripButton btnClose;
        private Controls.LBToolStripButton btnAdd;
        private Controls.LBToolStripButton btnSave;
        private Controls.LBToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.LBSkinTextBox txtSupplierName;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private Controls.LBSkinTextBox txtSupplierCode;
        private System.Windows.Forms.CheckBox cbIsForbidden;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}
