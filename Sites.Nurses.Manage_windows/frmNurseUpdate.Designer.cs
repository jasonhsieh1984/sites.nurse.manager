namespace Sites.Nurses.Manage_windows
{
    partial class frmNurseUpdate
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
            this.txtNurseName = new System.Windows.Forms.TextBox();
            this.txtNurseID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.picNurse = new System.Windows.Forms.PictureBox();
            this.btnImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picNurse)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNurseName
            // 
            this.txtNurseName.Location = new System.Drawing.Point(4, 47);
            this.txtNurseName.Name = "txtNurseName";
            this.txtNurseName.Size = new System.Drawing.Size(141, 29);
            this.txtNurseName.TabIndex = 32;
            this.txtNurseName.Text = "姓名";
            // 
            // txtNurseID
            // 
            this.txtNurseID.Location = new System.Drawing.Point(4, 12);
            this.txtNurseID.Name = "txtNurseID";
            this.txtNurseID.Size = new System.Drawing.Size(141, 29);
            this.txtNurseID.TabIndex = 31;
            this.txtNurseID.Text = "編號";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 184);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 38);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(66, 184);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(79, 38);
            this.btnConfirm.TabIndex = 29;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // picNurse
            // 
            this.picNurse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNurse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picNurse.Location = new System.Drawing.Point(174, 12);
            this.picNurse.Name = "picNurse";
            this.picNurse.Size = new System.Drawing.Size(132, 156);
            this.picNurse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNurse.TabIndex = 33;
            this.picNurse.TabStop = false;
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(66, 137);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(98, 31);
            this.btnImage.TabIndex = 34;
            this.btnImage.Text = "選擇照片";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // frmNurseUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 236);
            this.Controls.Add(this.btnImage);
            this.Controls.Add(this.picNurse);
            this.Controls.Add(this.txtNurseName);
            this.Controls.Add(this.txtNurseID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmNurseUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "護士資訊變更";
            this.Load += new System.EventHandler(this.frmNurseUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picNurse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNurseName;
        private System.Windows.Forms.TextBox txtNurseID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.PictureBox picNurse;
        private System.Windows.Forms.Button btnImage;
    }
}