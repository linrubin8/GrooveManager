namespace LB.SysConfig.SysConfig
{
    partial class frmInfraredDeviceConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfraredDeviceConfig));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlCarTail = new System.Windows.Forms.Panel();
            this.pnlCarHeader = new System.Windows.Forms.Panel();
            this.txtHeaderXType = new DMSkin.Metro.Controls.MetroComboBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.txtTailXType = new DMSkin.Metro.Controls.MetroComboBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.chkTailEffect = new System.Windows.Forms.CheckBox();
            this.chkHeaderEffect = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.btnSave = new LB.Controls.LBToolStripButton(this.components);
            this.btnDisplay = new LB.Controls.LBToolStripButton(this.components);
            this.txtSuccessYType = new DMSkin.Metro.Controls.MetroComboBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.txtFailYType = new DMSkin.Metro.Controls.MetroComboBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.txtSerialName = new LB.Controls.LBMetroComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStopTestY = new System.Windows.Forms.Button();
            this.btnTestFailY = new System.Windows.Forms.Button();
            this.btnTestSuccessY = new System.Windows.Forms.Button();
            this.chkAlermEffect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LB.SysConfig.Properties.Resources._001;
            this.pictureBox1.Location = new System.Drawing.Point(103, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlCarTail
            // 
            this.pnlCarTail.BackColor = System.Drawing.Color.White;
            this.pnlCarTail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCarTail.Location = new System.Drawing.Point(87, 14);
            this.pnlCarTail.Name = "pnlCarTail";
            this.pnlCarTail.Size = new System.Drawing.Size(10, 124);
            this.pnlCarTail.TabIndex = 1;
            // 
            // pnlCarHeader
            // 
            this.pnlCarHeader.BackColor = System.Drawing.Color.White;
            this.pnlCarHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCarHeader.Location = new System.Drawing.Point(387, 14);
            this.pnlCarHeader.Name = "pnlCarHeader";
            this.pnlCarHeader.Size = new System.Drawing.Size(10, 124);
            this.pnlCarHeader.TabIndex = 2;
            // 
            // txtHeaderXType
            // 
            this.txtHeaderXType.DM_UseSelectable = true;
            this.txtHeaderXType.FormattingEnabled = true;
            this.txtHeaderXType.ItemHeight = 24;
            this.txtHeaderXType.Location = new System.Drawing.Point(318, 181);
            this.txtHeaderXType.Name = "txtHeaderXType";
            this.txtHeaderXType.Size = new System.Drawing.Size(128, 30);
            this.txtHeaderXType.TabIndex = 15;
            // 
            // skinLabel4
            // 
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(7, 181);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(82, 32);
            this.skinLabel4.TabIndex = 14;
            this.skinLabel4.Text = "光耦输入";
            this.skinLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTailXType
            // 
            this.txtTailXType.DM_UseSelectable = true;
            this.txtTailXType.FormattingEnabled = true;
            this.txtTailXType.ItemHeight = 24;
            this.txtTailXType.Location = new System.Drawing.Point(95, 181);
            this.txtTailXType.Name = "txtTailXType";
            this.txtTailXType.Size = new System.Drawing.Size(129, 30);
            this.txtTailXType.TabIndex = 17;
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(230, 181);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(82, 32);
            this.skinLabel1.TabIndex = 16;
            this.skinLabel1.Text = "光耦输入";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkTailEffect
            // 
            this.chkTailEffect.AutoSize = true;
            this.chkTailEffect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chkTailEffect.Location = new System.Drawing.Point(6, 150);
            this.chkTailEffect.Name = "chkTailEffect";
            this.chkTailEffect.Size = new System.Drawing.Size(141, 25);
            this.chkTailEffect.TabIndex = 18;
            this.chkTailEffect.Text = "启用尾部对射器";
            this.chkTailEffect.UseVisualStyleBackColor = true;
            // 
            // chkHeaderEffect
            // 
            this.chkHeaderEffect.AutoSize = true;
            this.chkHeaderEffect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chkHeaderEffect.Location = new System.Drawing.Point(240, 150);
            this.chkHeaderEffect.Name = "chkHeaderEffect";
            this.chkHeaderEffect.Size = new System.Drawing.Size(141, 25);
            this.chkHeaderEffect.TabIndex = 19;
            this.chkHeaderEffect.Text = "启用头部对射器";
            this.chkHeaderEffect.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnSave,
            this.btnDisplay});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(882, 40);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
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
            this.btnSave.LBPermissionCode = "WeightFactorySave";
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 37);
            this.btnSave.Text = "保存";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplay.Image")));
            this.btnDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisplay.LBPermissionCode = "";
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(72, 37);
            this.btnDisplay.Text = "查看接线图";
            this.btnDisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // txtSuccessYType
            // 
            this.txtSuccessYType.DM_UseSelectable = true;
            this.txtSuccessYType.FormattingEnabled = true;
            this.txtSuccessYType.ItemHeight = 24;
            this.txtSuccessYType.Location = new System.Drawing.Point(192, 57);
            this.txtSuccessYType.Name = "txtSuccessYType";
            this.txtSuccessYType.Size = new System.Drawing.Size(117, 30);
            this.txtSuccessYType.TabIndex = 22;
            // 
            // skinLabel2
            // 
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(5, 57);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(181, 32);
            this.skinLabel2.TabIndex = 21;
            this.skinLabel2.Text = "称重成功继电器输出口";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFailYType
            // 
            this.txtFailYType.DM_UseSelectable = true;
            this.txtFailYType.FormattingEnabled = true;
            this.txtFailYType.ItemHeight = 24;
            this.txtFailYType.Location = new System.Drawing.Point(192, 108);
            this.txtFailYType.Name = "txtFailYType";
            this.txtFailYType.Size = new System.Drawing.Size(117, 30);
            this.txtFailYType.TabIndex = 24;
            // 
            // skinLabel3
            // 
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(6, 108);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(180, 32);
            this.skinLabel3.TabIndex = 23;
            this.skinLabel3.Text = "称重失败继电器输出口";
            this.skinLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel5
            // 
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(12, 54);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(127, 32);
            this.skinLabel5.TabIndex = 25;
            this.skinLabel5.Text = "4进4出串口名称";
            this.skinLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerialName
            // 
            this.txtSerialName.CanBeEmpty = true;
            this.txtSerialName.Caption = "";
            this.txtSerialName.DM_UseSelectable = true;
            this.txtSerialName.FormattingEnabled = true;
            this.txtSerialName.ItemHeight = 24;
            this.txtSerialName.Location = new System.Drawing.Point(145, 56);
            this.txtSerialName.Name = "txtSerialName";
            this.txtSerialName.Size = new System.Drawing.Size(201, 30);
            this.txtSerialName.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pnlCarTail);
            this.groupBox1.Controls.Add(this.pnlCarHeader);
            this.groupBox1.Controls.Add(this.skinLabel4);
            this.groupBox1.Controls.Add(this.txtHeaderXType);
            this.groupBox1.Controls.Add(this.skinLabel1);
            this.groupBox1.Controls.Add(this.txtTailXType);
            this.groupBox1.Controls.Add(this.chkTailEffect);
            this.groupBox1.Controls.Add(this.chkHeaderEffect);
            this.groupBox1.Location = new System.Drawing.Point(3, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 239);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "红外线对射设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStopTestY);
            this.groupBox2.Controls.Add(this.btnTestFailY);
            this.groupBox2.Controls.Add(this.btnTestSuccessY);
            this.groupBox2.Controls.Add(this.chkAlermEffect);
            this.groupBox2.Controls.Add(this.skinLabel2);
            this.groupBox2.Controls.Add(this.txtSuccessYType);
            this.groupBox2.Controls.Add(this.skinLabel3);
            this.groupBox2.Controls.Add(this.txtFailYType);
            this.groupBox2.Location = new System.Drawing.Point(475, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 239);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "警报输出设置";
            // 
            // btnStopTestY
            // 
            this.btnStopTestY.Location = new System.Drawing.Point(285, 19);
            this.btnStopTestY.Name = "btnStopTestY";
            this.btnStopTestY.Size = new System.Drawing.Size(71, 30);
            this.btnStopTestY.TabIndex = 28;
            this.btnStopTestY.Text = "停止测试";
            this.btnStopTestY.UseVisualStyleBackColor = true;
            this.btnStopTestY.Click += new System.EventHandler(this.btnStopTestY_Click);
            // 
            // btnTestFailY
            // 
            this.btnTestFailY.Location = new System.Drawing.Point(315, 108);
            this.btnTestFailY.Name = "btnTestFailY";
            this.btnTestFailY.Size = new System.Drawing.Size(59, 30);
            this.btnTestFailY.TabIndex = 27;
            this.btnTestFailY.Text = "测试";
            this.btnTestFailY.UseVisualStyleBackColor = true;
            this.btnTestFailY.Click += new System.EventHandler(this.btnTestFailY_Click);
            // 
            // btnTestSuccessY
            // 
            this.btnTestSuccessY.Location = new System.Drawing.Point(315, 57);
            this.btnTestSuccessY.Name = "btnTestSuccessY";
            this.btnTestSuccessY.Size = new System.Drawing.Size(59, 30);
            this.btnTestSuccessY.TabIndex = 26;
            this.btnTestSuccessY.Text = "测试";
            this.btnTestSuccessY.UseVisualStyleBackColor = true;
            this.btnTestSuccessY.Click += new System.EventHandler(this.btnTestSuccessY_Click);
            // 
            // chkAlermEffect
            // 
            this.chkAlermEffect.AutoSize = true;
            this.chkAlermEffect.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.chkAlermEffect.Location = new System.Drawing.Point(19, 20);
            this.chkAlermEffect.Name = "chkAlermEffect";
            this.chkAlermEffect.Size = new System.Drawing.Size(125, 25);
            this.chkAlermEffect.TabIndex = 25;
            this.chkAlermEffect.Text = "启用警报设置";
            this.chkAlermEffect.UseVisualStyleBackColor = true;
            // 
            // frmInfraredDeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.txtSerialName);
            this.Controls.Add(this.toolStrip1);
            this.LBPageTitle = "红外线对射器设置";
            this.Name = "frmInfraredDeviceConfig";
            this.Size = new System.Drawing.Size(882, 355);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlCarTail;
        private System.Windows.Forms.Panel pnlCarHeader;
        private DMSkin.Metro.Controls.MetroComboBox txtHeaderXType;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private DMSkin.Metro.Controls.MetroComboBox txtTailXType;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.CheckBox chkTailEffect;
        private System.Windows.Forms.CheckBox chkHeaderEffect;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.LBToolStripButton btnClose;
        private Controls.LBToolStripButton btnSave;
        private DMSkin.Metro.Controls.MetroComboBox txtSuccessYType;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private DMSkin.Metro.Controls.MetroComboBox txtFailYType;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private Controls.LBMetroComboBox txtSerialName;
        private Controls.LBToolStripButton btnDisplay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAlermEffect;
        private System.Windows.Forms.Button btnStopTestY;
        private System.Windows.Forms.Button btnTestFailY;
        private System.Windows.Forms.Button btnTestSuccessY;
    }
}
