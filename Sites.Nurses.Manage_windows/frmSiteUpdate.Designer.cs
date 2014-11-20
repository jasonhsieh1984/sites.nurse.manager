namespace Sites.Nurses.Manage_windows
{
    partial class frmSiteUpdate
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSiteMemo = new System.Windows.Forms.TextBox();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtSiteID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(68, 199);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(79, 38);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(193, 199);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSiteMemo
            // 
            this.txtSiteMemo.Location = new System.Drawing.Point(12, 48);
            this.txtSiteMemo.Multiline = true;
            this.txtSiteMemo.Name = "txtSiteMemo";
            this.txtSiteMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSiteMemo.Size = new System.Drawing.Size(341, 129);
            this.txtSiteMemo.TabIndex = 29;
            this.txtSiteMemo.Text = "備註";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(182, 13);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(171, 29);
            this.txtSiteName.TabIndex = 28;
            this.txtSiteName.Text = "站點名稱";
            // 
            // txtSiteID
            // 
            this.txtSiteID.Location = new System.Drawing.Point(12, 13);
            this.txtSiteID.Name = "txtSiteID";
            this.txtSiteID.Size = new System.Drawing.Size(164, 29);
            this.txtSiteID.TabIndex = 27;
            this.txtSiteID.Text = "編號";
            // 
            // frmSiteUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 246);
            this.Controls.Add(this.txtSiteMemo);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.txtSiteID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmSiteUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "醫護站資訊變更";
            this.Load += new System.EventHandler(this.frmSiteUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSiteMemo;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtSiteID;
    }
}