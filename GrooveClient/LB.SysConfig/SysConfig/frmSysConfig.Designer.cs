namespace LB.SysConfig.SysConfig
{
    partial class frmSysConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysConfig));
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.btnSave = new LB.Controls.LBToolStripButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.txtSysReadCardLimit = new LB.Controls.LBSkinTextBox(this.components);
            this.skinToolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.btnSave});
            this.skinToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(501, 40);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 1;
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
            // btnSave
            // 
            this.btnSave.Image = global::LB.SysConfig.Properties.Resources.btnNewSave3;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.LBPermissionCode = "btnDbSysConfig_Save";
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 37);
            this.btnSave.Text = "保存";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skinLabel1);
            this.groupBox1.Controls.Add(this.skinLabel2);
            this.groupBox1.Controls.Add(this.txtSysReadCardLimit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销售订单系统设置";
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel1.Location = new System.Drawing.Point(215, 23);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(32, 32);
            this.skinLabel1.TabIndex = 11;
            this.skinLabel1.Text = "分钟";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel2
            // 
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel2.Location = new System.Drawing.Point(6, 21);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(140, 32);
            this.skinLabel2.TabIndex = 10;
            this.skinLabel2.Text = "刷卡时间间隔限制";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSysReadCardLimit
            // 
            this.txtSysReadCardLimit.BackColor = System.Drawing.Color.Transparent;
            this.txtSysReadCardLimit.CanBeEmpty = false;
            this.txtSysReadCardLimit.Caption = "方案名称";
            this.txtSysReadCardLimit.DownBack = null;
            this.txtSysReadCardLimit.Icon = null;
            this.txtSysReadCardLimit.IconIsButton = false;
            this.txtSysReadCardLimit.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSysReadCardLimit.IsPasswordChat = '\0';
            this.txtSysReadCardLimit.IsSystemPasswordChar = false;
            this.txtSysReadCardLimit.Lines = new string[0];
            this.txtSysReadCardLimit.Location = new System.Drawing.Point(149, 23);
            this.txtSysReadCardLimit.Margin = new System.Windows.Forms.Padding(0);
            this.txtSysReadCardLimit.MaxLength = 32767;
            this.txtSysReadCardLimit.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtSysReadCardLimit.MouseBack = null;
            this.txtSysReadCardLimit.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtSysReadCardLimit.Multiline = false;
            this.txtSysReadCardLimit.Name = "txtSysReadCardLimit";
            this.txtSysReadCardLimit.NormlBack = null;
            this.txtSysReadCardLimit.Padding = new System.Windows.Forms.Padding(5);
            this.txtSysReadCardLimit.ReadOnly = false;
            this.txtSysReadCardLimit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSysReadCardLimit.Size = new System.Drawing.Size(63, 28);
            // 
            // 
            // 
            this.txtSysReadCardLimit.SkinTxt.AccessibleName = "";
            this.txtSysReadCardLimit.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtSysReadCardLimit.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtSysReadCardLimit.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSysReadCardLimit.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSysReadCardLimit.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSysReadCardLimit.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtSysReadCardLimit.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtSysReadCardLimit.SkinTxt.Name = "BaseText";
            this.txtSysReadCardLimit.SkinTxt.Size = new System.Drawing.Size(53, 18);
            this.txtSysReadCardLimit.SkinTxt.TabIndex = 0;
            this.txtSysReadCardLimit.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSysReadCardLimit.SkinTxt.WaterText = "";
            this.txtSysReadCardLimit.TabIndex = 9;
            this.txtSysReadCardLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSysReadCardLimit.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtSysReadCardLimit.WaterText = "";
            this.txtSysReadCardLimit.WordWrap = true;
            // 
            // frmSysConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.skinToolStrip1);
            this.LBPageTitle = "系统设置";
            this.Name = "frmSysConfig";
            this.Size = new System.Drawing.Size(501, 113);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private Controls.LBToolStripButton btnClose;
        private Controls.LBToolStripButton btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private Controls.LBSkinTextBox txtSysReadCardLimit;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}
