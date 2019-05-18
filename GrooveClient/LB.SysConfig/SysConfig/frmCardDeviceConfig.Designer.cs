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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardDeviceConfig));
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
            this.txtCardCode = new LB.Controls.LBSkinTextBox(this.components);
            this.btnReadCard = new System.Windows.Forms.Button();
            this.txtPort = new LB.Controls.LBSkinTextBox(this.components);
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.txtIPAddress = new LB.Controls.IPAddressTextBox();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.rbNet = new System.Windows.Forms.RadioButton();
            this.rbPort = new System.Windows.Forms.RadioButton();
            this.cbUseReadCard = new System.Windows.Forms.CheckBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbUseWriteCard = new System.Windows.Forms.CheckBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(647, 44);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::LB.SysConfig.Properties.Resources.btnClose;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.LBPermissionCode = "";
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 41);
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
            this.btnSave.Size = new System.Drawing.Size(36, 41);
            this.btnSave.Text = "保存";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // skinLabel5
            // 
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(220, 66);
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
            this.txtReadSerialName.Location = new System.Drawing.Point(342, 68);
            this.txtReadSerialName.Name = "txtReadSerialName";
            this.txtReadSerialName.Size = new System.Drawing.Size(125, 30);
            this.txtReadSerialName.TabIndex = 26;
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(209, 19);
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
            this.txtReadSerialBaud.Location = new System.Drawing.Point(342, 19);
            this.txtReadSerialBaud.Name = "txtReadSerialBaud";
            this.txtReadSerialBaud.Size = new System.Drawing.Size(125, 30);
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
            this.groupBox1.Controls.Add(this.txtCardCode);
            this.groupBox1.Controls.Add(this.btnReadCard);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.skinLabel7);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.skinLabel6);
            this.groupBox1.Controls.Add(this.rbNet);
            this.groupBox1.Controls.Add(this.rbPort);
            this.groupBox1.Controls.Add(this.cbUseReadCard);
            this.groupBox1.Controls.Add(this.skinLabel3);
            this.groupBox1.Controls.Add(this.skinLabel5);
            this.groupBox1.Controls.Add(this.txtReadSerialName);
            this.groupBox1.Controls.Add(this.skinLabel1);
            this.groupBox1.Controls.Add(this.txtReadSerialBaud);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 202);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "读卡面板设置";
            // 
            // txtCardCode
            // 
            this.txtCardCode.BackColor = System.Drawing.Color.Transparent;
            this.txtCardCode.CanBeEmpty = false;
            this.txtCardCode.Caption = "方案名称";
            this.txtCardCode.DownBack = null;
            this.txtCardCode.Icon = null;
            this.txtCardCode.IconIsButton = false;
            this.txtCardCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCardCode.IsPasswordChat = '\0';
            this.txtCardCode.IsSystemPasswordChar = false;
            this.txtCardCode.Lines = new string[0];
            this.txtCardCode.Location = new System.Drawing.Point(126, 158);
            this.txtCardCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCardCode.MaxLength = 32767;
            this.txtCardCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtCardCode.MouseBack = null;
            this.txtCardCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtCardCode.Multiline = false;
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.NormlBack = null;
            this.txtCardCode.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCardCode.ReadOnly = false;
            this.txtCardCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCardCode.Size = new System.Drawing.Size(71, 28);
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
            this.txtCardCode.SkinTxt.Size = new System.Drawing.Size(61, 18);
            this.txtCardCode.SkinTxt.TabIndex = 0;
            this.txtCardCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCardCode.SkinTxt.WaterText = "";
            this.txtCardCode.TabIndex = 38;
            this.txtCardCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCardCode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtCardCode.WaterText = "";
            this.txtCardCode.WordWrap = true;
            // 
            // btnReadCard
            // 
            this.btnReadCard.Location = new System.Drawing.Point(38, 158);
            this.btnReadCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(72, 28);
            this.btnReadCard.TabIndex = 37;
            this.btnReadCard.Text = "测试读卡";
            this.btnReadCard.UseVisualStyleBackColor = true;
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.CanBeEmpty = false;
            this.txtPort.Caption = "方案名称";
            this.txtPort.DownBack = null;
            this.txtPort.Icon = null;
            this.txtPort.IconIsButton = false;
            this.txtPort.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtPort.IsPasswordChat = '\0';
            this.txtPort.IsSystemPasswordChar = false;
            this.txtPort.Lines = new string[0];
            this.txtPort.Location = new System.Drawing.Point(545, 115);
            this.txtPort.Margin = new System.Windows.Forms.Padding(0);
            this.txtPort.MaxLength = 32767;
            this.txtPort.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtPort.MouseBack = null;
            this.txtPort.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtPort.Multiline = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.NormlBack = null;
            this.txtPort.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtPort.ReadOnly = false;
            this.txtPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPort.Size = new System.Drawing.Size(71, 28);
            // 
            // 
            // 
            this.txtPort.SkinTxt.AccessibleName = "";
            this.txtPort.SkinTxt.AutoCompleteCustomSource.AddRange(new string[] {
            "asdfasdf",
            "adsfasdf"});
            this.txtPort.SkinTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtPort.SkinTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPort.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPort.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPort.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtPort.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtPort.SkinTxt.Name = "BaseText";
            this.txtPort.SkinTxt.Size = new System.Drawing.Size(61, 18);
            this.txtPort.SkinTxt.TabIndex = 0;
            this.txtPort.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtPort.SkinTxt.WaterText = "";
            this.txtPort.TabIndex = 36;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPort.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtPort.WaterText = "";
            this.txtPort.WordWrap = true;
            // 
            // skinLabel7
            // 
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel7.Location = new System.Drawing.Point(473, 111);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(69, 32);
            this.skinLabel7.TabIndex = 35;
            this.skinLabel7.Text = "端口";
            this.skinLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.BackColor = System.Drawing.Color.White;
            this.txtIPAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIPAddress.Location = new System.Drawing.Point(342, 115);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(125, 28);
            this.txtIPAddress.TabIndex = 34;
            this.txtIPAddress.Value = ((System.Net.IPAddress)(resources.GetObject("txtIPAddress.Value")));
            // 
            // skinLabel6
            // 
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.Location = new System.Drawing.Point(220, 111);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(69, 32);
            this.skinLabel6.TabIndex = 33;
            this.skinLabel6.Text = "IP地址";
            this.skinLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbNet
            // 
            this.rbNet.AutoSize = true;
            this.rbNet.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbNet.Location = new System.Drawing.Point(38, 115);
            this.rbNet.Name = "rbNet";
            this.rbNet.Size = new System.Drawing.Size(156, 25);
            this.rbNet.TabIndex = 32;
            this.rbNet.TabStop = true;
            this.rbNet.Text = "使用网口通讯方式";
            this.rbNet.UseVisualStyleBackColor = true;
            // 
            // rbPort
            // 
            this.rbPort.AutoSize = true;
            this.rbPort.Checked = true;
            this.rbPort.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.rbPort.Location = new System.Drawing.Point(38, 68);
            this.rbPort.Name = "rbPort";
            this.rbPort.Size = new System.Drawing.Size(156, 25);
            this.rbPort.TabIndex = 31;
            this.rbPort.TabStop = true;
            this.rbPort.Text = "使用串口通讯方式";
            this.rbPort.UseVisualStyleBackColor = true;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbUseWriteCard);
            this.groupBox2.Controls.Add(this.skinLabel4);
            this.groupBox2.Controls.Add(this.skinLabel2);
            this.groupBox2.Controls.Add(this.txtWriteSerialName);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 100);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "写卡器设置";
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
            this.Size = new System.Drawing.Size(647, 345);
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
        private System.Windows.Forms.RadioButton rbPort;
        private System.Windows.Forms.RadioButton rbNet;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private Controls.IPAddressTextBox txtIPAddress;
        private Controls.LBSkinTextBox txtPort;
        private Controls.LBSkinTextBox txtCardCode;
        private System.Windows.Forms.Button btnReadCard;
    }
}
