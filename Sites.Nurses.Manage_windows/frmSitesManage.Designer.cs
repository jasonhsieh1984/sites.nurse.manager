namespace Sites.Nurses.Manage_windows
{
    partial class frmSitesManage
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSitesManage));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSite = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvAssigned = new System.Windows.Forms.DataGridView();
            this.txtNurseID = new System.Windows.Forms.TextBox();
            this.txtNurseName = new System.Windows.Forms.TextBox();
            this.picNurse = new System.Windows.Forms.PictureBox();
            this.txtSiteID = new System.Windows.Forms.TextBox();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtSiteMemo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.txtSiteSearch = new System.Windows.Forms.TextBox();
            this.btnSiteSearch = new System.Windows.Forms.Button();
            this.btnShowAllSite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNurse)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "護理站列表";
            // 
            // dgvSite
            // 
            this.dgvSite.AllowUserToAddRows = false;
            this.dgvSite.AllowUserToDeleteRows = false;
            this.dgvSite.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSite.Location = new System.Drawing.Point(7, 75);
            this.dgvSite.MultiSelect = false;
            this.dgvSite.Name = "dgvSite";
            this.dgvSite.ReadOnly = true;
            this.dgvSite.RowTemplate.Height = 24;
            this.dgvSite.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSite.Size = new System.Drawing.Size(341, 153);
            this.dgvSite.TabIndex = 10;
            this.dgvSite.SelectionChanged += new System.EventHandler(this.dgvSite_SelectionChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(258, 364);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 40);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "刪除站點";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 365);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 40);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "加入站點";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(130, 365);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 40);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "修改站點";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvAssigned
            // 
            this.dgvAssigned.AllowUserToAddRows = false;
            this.dgvAssigned.AllowUserToDeleteRows = false;
            this.dgvAssigned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssigned.Location = new System.Drawing.Point(6, 26);
            this.dgvAssigned.MultiSelect = false;
            this.dgvAssigned.Name = "dgvAssigned";
            this.dgvAssigned.ReadOnly = true;
            this.dgvAssigned.RowTemplate.Height = 24;
            this.dgvAssigned.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssigned.Size = new System.Drawing.Size(245, 295);
            this.dgvAssigned.TabIndex = 20;
            this.dgvAssigned.SelectionChanged += new System.EventHandler(this.dgvAssigned_SelectionChanged);
            // 
            // txtNurseID
            // 
            this.txtNurseID.Location = new System.Drawing.Point(257, 64);
            this.txtNurseID.Name = "txtNurseID";
            this.txtNurseID.ReadOnly = true;
            this.txtNurseID.Size = new System.Drawing.Size(132, 29);
            this.txtNurseID.TabIndex = 21;
            this.txtNurseID.Text = "編號";
            // 
            // txtNurseName
            // 
            this.txtNurseName.Location = new System.Drawing.Point(257, 109);
            this.txtNurseName.Name = "txtNurseName";
            this.txtNurseName.ReadOnly = true;
            this.txtNurseName.Size = new System.Drawing.Size(132, 29);
            this.txtNurseName.TabIndex = 22;
            this.txtNurseName.Text = "姓名";
            // 
            // picNurse
            // 
            this.picNurse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picNurse.Location = new System.Drawing.Point(257, 165);
            this.picNurse.Name = "picNurse";
            this.picNurse.Size = new System.Drawing.Size(132, 156);
            this.picNurse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNurse.TabIndex = 23;
            this.picNurse.TabStop = false;
            // 
            // txtSiteID
            // 
            this.txtSiteID.Location = new System.Drawing.Point(7, 234);
            this.txtSiteID.Name = "txtSiteID";
            this.txtSiteID.ReadOnly = true;
            this.txtSiteID.Size = new System.Drawing.Size(164, 29);
            this.txtSiteID.TabIndex = 24;
            this.txtSiteID.Text = "編號";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(177, 234);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.ReadOnly = true;
            this.txtSiteName.Size = new System.Drawing.Size(171, 29);
            this.txtSiteName.TabIndex = 25;
            this.txtSiteName.Text = "站點名稱";
            // 
            // txtSiteMemo
            // 
            this.txtSiteMemo.Location = new System.Drawing.Point(7, 269);
            this.txtSiteMemo.Multiline = true;
            this.txtSiteMemo.Name = "txtSiteMemo";
            this.txtSiteMemo.ReadOnly = true;
            this.txtSiteMemo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSiteMemo.Size = new System.Drawing.Size(341, 81);
            this.txtSiteMemo.TabIndex = 26;
            this.txtSiteMemo.Text = "備註";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAssigned);
            this.groupBox1.Controls.Add(this.txtNurseID);
            this.groupBox1.Controls.Add(this.txtNurseName);
            this.groupBox1.Controls.Add(this.picNurse);
            this.groupBox1.Location = new System.Drawing.Point(367, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 329);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "護士資訊";
            // 
            // cmbSite
            // 
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(30, 41);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(68, 28);
            this.cmbSite.TabIndex = 28;
            this.cmbSite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSite_KeyPress);
            // 
            // txtSiteSearch
            // 
            this.txtSiteSearch.Location = new System.Drawing.Point(104, 41);
            this.txtSiteSearch.Name = "txtSiteSearch";
            this.txtSiteSearch.Size = new System.Drawing.Size(90, 29);
            this.txtSiteSearch.TabIndex = 29;
            // 
            // btnSiteSearch
            // 
            this.btnSiteSearch.Location = new System.Drawing.Point(200, 40);
            this.btnSiteSearch.Name = "btnSiteSearch";
            this.btnSiteSearch.Size = new System.Drawing.Size(60, 29);
            this.btnSiteSearch.TabIndex = 30;
            this.btnSiteSearch.Text = "搜尋";
            this.btnSiteSearch.UseVisualStyleBackColor = true;
            this.btnSiteSearch.Click += new System.EventHandler(this.btnSiteSearch_Click);
            // 
            // btnShowAllSite
            // 
            this.btnShowAllSite.Location = new System.Drawing.Point(266, 40);
            this.btnShowAllSite.Name = "btnShowAllSite";
            this.btnShowAllSite.Size = new System.Drawing.Size(82, 29);
            this.btnShowAllSite.TabIndex = 31;
            this.btnShowAllSite.Text = "所有資料";
            this.btnShowAllSite.UseVisualStyleBackColor = true;
            this.btnShowAllSite.Click += new System.EventHandler(this.btnShowAllSite_Click);
            // 
            // frmSitesManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 411);
            this.Controls.Add(this.btnShowAllSite);
            this.Controls.Add(this.btnSiteSearch);
            this.Controls.Add(this.txtSiteSearch);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSiteMemo);
            this.Controls.Add(this.txtSiteName);
            this.Controls.Add(this.txtSiteID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvSite);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSitesManage";
            this.ShowInTaskbar = false;
            this.Text = "護理站點管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSitesManage_FormClosing);
            this.Load += new System.EventHandler(this.frmSitesManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNurse)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSite;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvAssigned;
        private System.Windows.Forms.TextBox txtNurseID;
        private System.Windows.Forms.TextBox txtNurseName;
        private System.Windows.Forms.PictureBox picNurse;
        private System.Windows.Forms.TextBox txtSiteID;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtSiteMemo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.TextBox txtSiteSearch;
        private System.Windows.Forms.Button btnSiteSearch;
        private System.Windows.Forms.Button btnShowAllSite;
    }
}