namespace LB.Web.ServerTemp
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemOpenForm = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "入槽软件服务";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuIcon
            // 
            this.contextMenuIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemOpenForm,
            this.btnRegister,
            this.itemExit});
            this.contextMenuIcon.Name = "contextMenuIcon";
            this.contextMenuIcon.Size = new System.Drawing.Size(153, 92);
            // 
            // itemOpenForm
            // 
            this.itemOpenForm.Name = "itemOpenForm";
            this.itemOpenForm.Size = new System.Drawing.Size(152, 22);
            this.itemOpenForm.Text = "打开窗口";
            this.itemOpenForm.Click += new System.EventHandler(this.itemOpenForm_Click);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(152, 22);
            this.itemExit.Text = "退出";
            this.itemExit.Click += new System.EventHandler(this.itemExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "入槽软件服务器已启动................";
            // 
            // btnRegister
            // 
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(152, 22);
            this.btnRegister.Text = "注册";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 61);
            this.ContextMenuStrip = this.contextMenuIcon;
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入槽软件服务";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuIcon;
        private System.Windows.Forms.ToolStripMenuItem itemOpenForm;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem btnRegister;
    }
}

