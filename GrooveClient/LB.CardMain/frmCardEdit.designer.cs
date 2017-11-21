namespace LB.CardMain
{
    partial class frmCardEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardEdit));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.txtCardName = new LB.Controls.LBSkinTextBox(this.components);
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.txtCardCode = new LB.Controls.LBSkinTextBox(this.components);
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.btnAdd = new LB.Controls.LBToolStripButton(this.components);
            this.btnSave = new LB.Controls.LBToolStripButton(this.components);
            this.btnDelete = new LB.Controls.LBToolStripButton(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.txtSourceCardCode = new LB.Controls.LBSkinTextBox(this.components);
            this.btnReadCard = new System.Windows.Forms.Button();
            this.skinToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(31, 141);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(77, 32);
            this.skinLabel1.TabIndex = 15;
            this.skinLabel1.Text = "备注";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCardName
            // 
            this.txtCardName.BackColor = System.Drawing.Color.Transparent;
            this.txtCardName.CanBeEmpty = true;
            this.txtCardName.Caption = "";
            this.txtCardName.DownBack = null;
            this.txtCardName.Icon = null;
            this.txtCardName.IconIsButton = false;
            this.txtCardName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCardName.IsPasswordChat = '\0';
            this.txtCardName.IsSystemPasswordChar = false;
            this.txtCardName.Lines = new string[0];
            this.txtCardName.Location = new System.Drawing.Point(112, 145);
            this.txtCardName.Margin = new System.Windows.Forms.Padding(0);
            this.txtCardName.MaxLength = 32767;
            this.txtCardName.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtCardName.MouseBack = null;
            this.txtCardName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCardName.Multiline = false;
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.NormlBack = null;
            this.txtCardName.Padding = new System.Windows.Forms.Padding(5);
            this.txtCardName.ReadOnly = false;
            this.txtCardName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCardName.Size = new System.Drawing.Size(240, 28);
            // 
            // 
            // 
            this.txtCardName.SkinTxt.AccessibleName = "";
            this.txtCardName.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtCardName.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtCardName.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCardName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCardName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCardName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtCardName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtCardName.SkinTxt.Name = "BaseText";
            this.txtCardName.SkinTxt.Size = new System.Drawing.Size(230, 18);
            this.txtCardName.SkinTxt.TabIndex = 0;
            this.txtCardName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCardName.SkinTxt.WaterText = "";
            this.txtCardName.TabIndex = 14;
            this.txtCardName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCardName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCardName.WaterText = "";
            this.txtCardName.WordWrap = true;
            // 
            // skinLabel5
            // 
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(32, 101);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(77, 32);
            this.skinLabel5.TabIndex = 22;
            this.skinLabel5.Text = "编辑卡号";
            this.skinLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCardCode
            // 
            this.txtCardCode.BackColor = System.Drawing.Color.Transparent;
            this.txtCardCode.CanBeEmpty = false;
            this.txtCardCode.Caption = "编辑卡号";
            this.txtCardCode.DownBack = null;
            this.txtCardCode.Icon = null;
            this.txtCardCode.IconIsButton = false;
            this.txtCardCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCardCode.IsPasswordChat = '\0';
            this.txtCardCode.IsSystemPasswordChar = false;
            this.txtCardCode.Lines = new string[0];
            this.txtCardCode.Location = new System.Drawing.Point(112, 105);
            this.txtCardCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCardCode.MaxLength = 32767;
            this.txtCardCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtCardCode.MouseBack = null;
            this.txtCardCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCardCode.Multiline = false;
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.NormlBack = null;
            this.txtCardCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtCardCode.ReadOnly = false;
            this.txtCardCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCardCode.Size = new System.Drawing.Size(240, 28);
            // 
            // 
            // 
            this.txtCardCode.SkinTxt.AccessibleName = "";
            this.txtCardCode.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtCardCode.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtCardCode.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCardCode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCardCode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCardCode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtCardCode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtCardCode.SkinTxt.Name = "BaseText";
            this.txtCardCode.SkinTxt.Size = new System.Drawing.Size(230, 18);
            this.txtCardCode.SkinTxt.TabIndex = 0;
            this.txtCardCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCardCode.SkinTxt.WaterText = "";
            this.txtCardCode.TabIndex = 15;
            this.txtCardCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCardCode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCardCode.WaterText = "";
            this.txtCardCode.WordWrap = true;
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
            this.skinToolStrip1.Size = new System.Drawing.Size(406, 40);
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
            // skinLabel2
            // 
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(32, 57);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(77, 32);
            this.skinLabel2.TabIndex = 23;
            this.skinLabel2.Text = "原卡号";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSourceCardCode
            // 
            this.txtSourceCardCode.BackColor = System.Drawing.Color.Transparent;
            this.txtSourceCardCode.CanBeEmpty = true;
            this.txtSourceCardCode.Caption = "";
            this.txtSourceCardCode.DownBack = null;
            this.txtSourceCardCode.Icon = null;
            this.txtSourceCardCode.IconIsButton = false;
            this.txtSourceCardCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSourceCardCode.IsPasswordChat = '\0';
            this.txtSourceCardCode.IsSystemPasswordChar = false;
            this.txtSourceCardCode.Lines = new string[0];
            this.txtSourceCardCode.Location = new System.Drawing.Point(112, 61);
            this.txtSourceCardCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtSourceCardCode.MaxLength = 32767;
            this.txtSourceCardCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSourceCardCode.MouseBack = null;
            this.txtSourceCardCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSourceCardCode.Multiline = false;
            this.txtSourceCardCode.Name = "txtSourceCardCode";
            this.txtSourceCardCode.NormlBack = null;
            this.txtSourceCardCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtSourceCardCode.ReadOnly = true;
            this.txtSourceCardCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSourceCardCode.Size = new System.Drawing.Size(162, 28);
            // 
            // 
            // 
            this.txtSourceCardCode.SkinTxt.AccessibleName = "";
            this.txtSourceCardCode.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtSourceCardCode.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtSourceCardCode.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSourceCardCode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSourceCardCode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourceCardCode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSourceCardCode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSourceCardCode.SkinTxt.Name = "BaseText";
            this.txtSourceCardCode.SkinTxt.ReadOnly = true;
            this.txtSourceCardCode.SkinTxt.Size = new System.Drawing.Size(152, 18);
            this.txtSourceCardCode.SkinTxt.TabIndex = 0;
            this.txtSourceCardCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSourceCardCode.SkinTxt.WaterText = "";
            this.txtSourceCardCode.TabIndex = 24;
            this.txtSourceCardCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSourceCardCode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSourceCardCode.WaterText = "";
            this.txtSourceCardCode.WordWrap = true;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(277, 61);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(75, 28);
            this.btnReadCard.TabIndex = 25;
            this.btnReadCard.Text = "读取卡号";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // frmCardEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 192);
            this.Controls.Add(this.btnReadCard);
            this.Controls.Add(this.txtSourceCardCode);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.txtCardCode);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.txtCardName);
            this.Controls.Add(this.skinToolStrip1);
            this.Name = "frmCardEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑卡片";
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
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private Controls.LBSkinTextBox txtCardName;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private Controls.LBSkinTextBox txtCardCode;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private Controls.LBSkinTextBox txtSourceCardCode;
        private System.Windows.Forms.Button btnReadCard;
    }
}
