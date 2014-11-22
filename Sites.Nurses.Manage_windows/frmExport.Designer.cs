namespace Sites.Nurses.Manage_windows
{
    partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.btnExportBySite = new System.Windows.Forms.Button();
            this.btnExportByNurse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportBySite
            // 
            this.btnExportBySite.Location = new System.Drawing.Point(32, 23);
            this.btnExportBySite.Name = "btnExportBySite";
            this.btnExportBySite.Size = new System.Drawing.Size(161, 62);
            this.btnExportBySite.TabIndex = 0;
            this.btnExportBySite.Text = "依護理站匯出CSV";
            this.btnExportBySite.UseVisualStyleBackColor = true;
            this.btnExportBySite.Click += new System.EventHandler(this.btnExportBySite_Click);
            // 
            // btnExportByNurse
            // 
            this.btnExportByNurse.Location = new System.Drawing.Point(32, 112);
            this.btnExportByNurse.Name = "btnExportByNurse";
            this.btnExportByNurse.Size = new System.Drawing.Size(161, 62);
            this.btnExportByNurse.TabIndex = 1;
            this.btnExportByNurse.Text = "依護士匯出CSV";
            this.btnExportByNurse.UseVisualStyleBackColor = true;
            this.btnExportByNurse.Click += new System.EventHandler(this.btnExportByNurse_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 197);
            this.Controls.Add(this.btnExportByNurse);
            this.Controls.Add(this.btnExportBySite);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.ShowInTaskbar = false;
            this.Text = "匯出CSV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExport_FormClosing);
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportBySite;
        private System.Windows.Forms.Button btnExportByNurse;
    }
}