namespace LB.SysConfig.SysConfig
{
    partial class frmCardDeviceConfig
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new LB.Controls.LBToolStripButton(this.components);
            this.btnSave = new LB.Controls.LBToolStripButton(this.components);
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.txtReadSerialName = new LB.Controls.LBMetroComboBox(this.components);
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.txtReadSerialBaud = new LB.Controls.LBMetroComboBox(this.components);
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.txtWriteSerialName = new LB.Controls.LBMetroComboBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.cbUseReadCard = new System.Windows.Forms.CheckBox();
            this.cbUseWriteCard = new System.Windows.Forms.CheckBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(329, 40);
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
            this.btnSave.LBPermissionCode = "";
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 37);
            this.btnSave.Text = "保存";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // skinLabel5
            // 
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(17, 54);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(116, 32);
            this.skinLabel5.TabIndex = 25;
            this.skinLabel5.Text = "读卡面板串口";
            this.skinLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReadSerialName
            // 
            this.txtReadSerialName.CanBeEmpty = true;
            this.txtReadSerialName.Caption = "";
            this.txtReadSerialName.DM_UseSelectable = true;
            this.txtReadSerialName.FormattingEnabled = true;
            this.txtReadSerialName.ItemHeight = 24;
            this.txtReadSerialName.Location = new System.Drawing.Point(139, 56);
            this.txtReadSerialName.Name = "txtReadSerialName";
            this.txtReadSerialName.Size = new System.Drawing.Size(165, 30);
            this.txtReadSerialName.TabIndex = 26;
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(32, 97);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(80, 32);
            this.skinLabel1.TabIndex = 27;
            this.skinLabel1.Text = "频率";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReadSerialBaud
            // 
            this.txtReadSerialBaud.CanBeEmpty = true;
            this.txtReadSerialBaud.Caption = "";
            this.txtReadSerialBaud.DM_UseSelectable = true;
            this.txtReadSerialBaud.FormattingEnabled = true;
            this.txtReadSerialBaud.ItemHeight = 24;
            this.txtReadSerialBaud.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.txtReadSerialBaud.Location = new System.Drawing.Point(139, 97);
            this.txtReadSerialBaud.Name = "txtReadSerialBaud";
            this.txtReadSerialBaud.Size = new System.Drawing.Size(165, 30);
            this.txtReadSerialBaud.TabIndex = 28;
            // 
            // skinLabel2
            // 
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(17, 51);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(116, 32);
            this.skinLabel2.TabIndex = 29;
            this.skinLabel2.Text = "写卡器串口";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWriteSerialName
            // 
            this.txtWriteSerialName.CanBeEmpty = true;
            this.txtWriteSerialName.Caption = "";
            this.txtWriteSerialName.DM_UseSelectable = true;
            this.txtWriteSerialName.FormattingEnabled = true;
            this.txtWriteSerialName.ItemHeight = 24;
            this.txtWriteSerialName.Location = new System.Drawing.Point(139, 54);
            this.txtWriteSerialName.Name = "txtWriteSerialName";
            this.txtWriteSerialName.Size = new System.Drawing.Size(165, 30);
            this.txtWriteSerialName.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUseReadCard);
            this.groupBox1.Controls.Add(this.skinLabel3);
            this.groupBox1.Controls.Add(this.skinLabel5);
            this.groupBox1.Controls.Add(this.txtReadSerialName);
            this.groupBox1.Controls.Add(this.skinLabel1);
            this.groupBox1.Controls.Add(this.txtReadSerialBaud);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 137);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读卡面板设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbUseWriteCard);
            this.groupBox2.Controls.Add(this.skinLabel4);
            this.groupBox2.Controls.Add(this.skinLabel2);
            this.groupBox2.Controls.Add(this.txtWriteSerialName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(329, 100);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "写卡器设置";
            // 
            // skinLabel3
            // 
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(17, 17);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(116, 32);
            this.skinLabel3.TabIndex = 29;
            this.skinLabel3.Text = "启用读卡器";
            this.skinLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbUseReadCard
            // 
            this.cbUseReadCard.AutoSize = true;
            this.cbUseReadCard.Location = new System.Drawing.Point(139, 29);
            this.cbUseReadCard.Name = "cbUseReadCard";
            this.cbUseReadCard.Size = new System.Drawing.Size(15, 14);
            this.cbUseReadCard.TabIndex = 30;
            this.cbUseReadCard.UseVisualStyleBackColor = true;
            // 
            // cbUseWriteCard
            // 
            this.cbUseWriteCard.AutoSize = true;
            this.cbUseWriteCard.Location = new System.Drawing.Point(139, 29);
            this.cbUseWriteCard.Name = "cbUseWriteCard";
            this.cbUseWriteCard.Size = new System.Drawing.Size(15, 14);
            this.cbUseWriteCard.TabIndex = 32;
            this.cbUseWriteCard.UseVisualStyleBackColor = true;
            // 
            // skinLabel4
            // 
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(17, 17);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(116, 32);
            this.skinLabel4.TabIndex = 31;
            this.skinLabel4.Text = "启用写卡器";
            this.skinLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCardDeviceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.LBPageTitle = "红外线对射器设置";
            this.Name = "frmCardDeviceConfig";
            this.Size = new System.Drawing.Size(329, 288);
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private Controls.LBToolStripButton btnClose;
        private Controls.LBToolStripButton btnSave;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private Controls.LBMetroComboBox txtReadSerialName;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private Controls.LBMetroComboBox txtReadSerialBaud;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private Controls.LBMetroComboBox txtWriteSerialName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private System.Windows.Forms.CheckBox cbUseReadCard;
        private System.Windows.Forms.CheckBox cbUseWriteCard;
        private CCWin.SkinControl.SkinLabel skinLabel4;
    }
}
