namespace LB.MI
{
    partial class frmAddInBill
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
            this.txtCarID = new LB.Controls.LBTextBox.CoolTextBox();
            this.skinLabel8 = new CCWin.SkinControl.SkinLabel();
            this.txtSupplierID = new LB.Controls.LBTextBox.CoolTextBox();
            this.skinLabel10 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.txtSaleCarInBillCode = new System.Windows.Forms.TextBox();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.txtAddReason = new System.Windows.Forms.TextBox();
            this.txtBillTimeIn = new System.Windows.Forms.DateTimePicker();
            this.txtBillDateIn = new System.Windows.Forms.DateTimePicker();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.txtSuttleWeight = new System.Windows.Forms.TextBox();
            this.skinLabel15 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.txtCarTare = new System.Windows.Forms.TextBox();
            this.btnSaveAndAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.txtCarID.Location = new System.Drawing.Point(137, 26);
            this.txtCarID.Margin = new System.Windows.Forms.Padding(0);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.PopupWidth = 120;
            this.txtCarID.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.txtCarID.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtCarID.Size = new System.Drawing.Size(188, 34);
            this.txtCarID.TabIndex = 49;
            // 
            // skinLabel8
            // 
            this.skinLabel8.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel8.BorderColor = System.Drawing.Color.White;
            this.skinLabel8.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel8.Location = new System.Drawing.Point(69, 26);
            this.skinLabel8.Name = "skinLabel8";
            this.skinLabel8.Size = new System.Drawing.Size(55, 30);
            this.skinLabel8.TabIndex = 52;
            this.skinLabel8.Text = "车 号";
            this.skinLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtSupplierID.Location = new System.Drawing.Point(137, 66);
            this.txtSupplierID.Margin = new System.Windows.Forms.Padding(0);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.PopupWidth = 120;
            this.txtSupplierID.SelectedItemBackColor = System.Drawing.SystemColors.Highlight;
            this.txtSupplierID.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtSupplierID.Size = new System.Drawing.Size(188, 34);
            this.txtSupplierID.TabIndex = 51;
            // 
            // skinLabel10
            // 
            this.skinLabel10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel10.BorderColor = System.Drawing.Color.White;
            this.skinLabel10.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel10.Location = new System.Drawing.Point(9, 66);
            this.skinLabel10.Name = "skinLabel10";
            this.skinLabel10.Size = new System.Drawing.Size(123, 29);
            this.skinLabel10.TabIndex = 54;
            this.skinLabel10.Text = "供应商名称";
            this.skinLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel5
            // 
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel5.Location = new System.Drawing.Point(366, 27);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(66, 29);
            this.skinLabel5.TabIndex = 62;
            this.skinLabel5.Text = "单 号";
            this.skinLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSaleCarInBillCode
            // 
            this.txtSaleCarInBillCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleCarInBillCode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtSaleCarInBillCode.Location = new System.Drawing.Point(444, 26);
            this.txtSaleCarInBillCode.Multiline = true;
            this.txtSaleCarInBillCode.Name = "txtSaleCarInBillCode";
            this.txtSaleCarInBillCode.ReadOnly = true;
            this.txtSaleCarInBillCode.Size = new System.Drawing.Size(199, 30);
            this.txtSaleCarInBillCode.TabIndex = 63;
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Font = new System.Drawing.Font("楷体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveAndClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveAndClose.Location = new System.Drawing.Point(371, 214);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(120, 29);
            this.btnSaveAndClose.TabIndex = 64;
            this.btnSaveAndClose.Text = "保存并关闭";
            this.btnSaveAndClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel1.Location = new System.Drawing.Point(4, 165);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(127, 29);
            this.skinLabel1.TabIndex = 68;
            this.skinLabel1.Text = "手工录入原因";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddReason
            // 
            this.txtAddReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddReason.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtAddReason.Location = new System.Drawing.Point(137, 165);
            this.txtAddReason.Multiline = true;
            this.txtAddReason.Name = "txtAddReason";
            this.txtAddReason.Size = new System.Drawing.Size(506, 30);
            this.txtAddReason.TabIndex = 69;
            // 
            // txtBillTimeIn
            // 
            this.txtBillTimeIn.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.txtBillTimeIn.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBillTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtBillTimeIn.Location = new System.Drawing.Point(558, 74);
            this.txtBillTimeIn.Name = "txtBillTimeIn";
            this.txtBillTimeIn.Size = new System.Drawing.Size(85, 26);
            this.txtBillTimeIn.TabIndex = 71;
            // 
            // txtBillDateIn
            // 
            this.txtBillDateIn.CalendarFont = new System.Drawing.Font("宋体", 10F);
            this.txtBillDateIn.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBillDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtBillDateIn.Location = new System.Drawing.Point(444, 74);
            this.txtBillDateIn.Name = "txtBillDateIn";
            this.txtBillDateIn.Size = new System.Drawing.Size(106, 26);
            this.txtBillDateIn.TabIndex = 70;
            // 
            // skinLabel3
            // 
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel3.Location = new System.Drawing.Point(337, 73);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(95, 29);
            this.skinLabel3.TabIndex = 72;
            this.skinLabel3.Text = "入场时间";
            this.skinLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSuttleWeight
            // 
            this.txtSuttleWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuttleWeight.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtSuttleWeight.Location = new System.Drawing.Point(533, 113);
            this.txtSuttleWeight.Multiline = true;
            this.txtSuttleWeight.Name = "txtSuttleWeight";
            this.txtSuttleWeight.ReadOnly = true;
            this.txtSuttleWeight.Size = new System.Drawing.Size(110, 34);
            this.txtSuttleWeight.TabIndex = 80;
            // 
            // skinLabel15
            // 
            this.skinLabel15.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel15.BorderColor = System.Drawing.Color.White;
            this.skinLabel15.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel15.Location = new System.Drawing.Point(467, 114);
            this.skinLabel15.Name = "skinLabel15";
            this.skinLabel15.Size = new System.Drawing.Size(60, 30);
            this.skinLabel15.TabIndex = 79;
            this.skinLabel15.Text = "净 重";
            this.skinLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabel2
            // 
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel2.Location = new System.Drawing.Point(63, 113);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(60, 30);
            this.skinLabel2.TabIndex = 78;
            this.skinLabel2.Text = "毛 重";
            this.skinLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalWeight.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtTotalWeight.Location = new System.Drawing.Point(137, 113);
            this.txtTotalWeight.Multiline = true;
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.Size = new System.Drawing.Size(110, 34);
            this.txtTotalWeight.TabIndex = 77;
            // 
            // skinLabel4
            // 
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.skinLabel4.Location = new System.Drawing.Point(265, 114);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(60, 30);
            this.skinLabel4.TabIndex = 76;
            this.skinLabel4.Text = "皮 重";
            this.skinLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCarTare
            // 
            this.txtCarTare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarTare.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.txtCarTare.Location = new System.Drawing.Point(331, 114);
            this.txtCarTare.Multiline = true;
            this.txtCarTare.Name = "txtCarTare";
            this.txtCarTare.ReadOnly = true;
            this.txtCarTare.Size = new System.Drawing.Size(114, 33);
            this.txtCarTare.TabIndex = 75;
            // 
            // btnSaveAndAdd
            // 
            this.btnSaveAndAdd.Font = new System.Drawing.Font("楷体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveAndAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveAndAdd.Location = new System.Drawing.Point(191, 214);
            this.btnSaveAndAdd.Name = "btnSaveAndAdd";
            this.btnSaveAndAdd.Size = new System.Drawing.Size(150, 29);
            this.btnSaveAndAdd.TabIndex = 81;
            this.btnSaveAndAdd.Text = "保存并继续添加";
            this.btnSaveAndAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveAndAdd.UseVisualStyleBackColor = true;
            this.btnSaveAndAdd.Click += new System.EventHandler(this.btnSaveAndAdd_Click);
            // 
            // frmAddInBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveAndAdd);
            this.Controls.Add(this.txtSuttleWeight);
            this.Controls.Add(this.skinLabel15);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.txtTotalWeight);
            this.Controls.Add(this.skinLabel4);
            this.Controls.Add(this.txtCarTare);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.txtBillTimeIn);
            this.Controls.Add(this.txtBillDateIn);
            this.Controls.Add(this.txtAddReason);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.txtSaleCarInBillCode);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.txtCarID);
            this.Controls.Add(this.skinLabel8);
            this.Controls.Add(this.txtSupplierID);
            this.Controls.Add(this.skinLabel10);
            this.LBPageTitle = "手工录入入场单";
            this.Name = "frmAddInBill";
            this.Size = new System.Drawing.Size(659, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.LBTextBox.CoolTextBox txtCarID;
        private CCWin.SkinControl.SkinLabel skinLabel8;
        private Controls.LBTextBox.CoolTextBox txtSupplierID;
        private CCWin.SkinControl.SkinLabel skinLabel10;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private System.Windows.Forms.TextBox txtSaleCarInBillCode;
        private System.Windows.Forms.Button btnSaveAndClose;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.TextBox txtAddReason;
        private System.Windows.Forms.DateTimePicker txtBillTimeIn;
        private System.Windows.Forms.DateTimePicker txtBillDateIn;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private System.Windows.Forms.TextBox txtSuttleWeight;
        private CCWin.SkinControl.SkinLabel skinLabel15;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private System.Windows.Forms.TextBox txtCarTare;
        private System.Windows.Forms.Button btnSaveAndAdd;
    }
}
