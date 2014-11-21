namespace Sites.Nurses.Manage_windows
{
    partial class frmNurseManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNurseManage));
            this.dgvNurse = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.picNurse = new System.Windows.Forms.PictureBox();
            this.txtNurseName = new System.Windows.Forms.TextBox();
            this.txtNurseID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvSiteList = new System.Windows.Forms.DataGridView();
            this.dgvAssigned = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNurse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNurse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiteList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNurse
            // 
            this.dgvNurse.AllowUserToAddRows = false;
            this.dgvNurse.AllowUserToDeleteRows = false;
            this.dgvNurse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNurse.Location = new System.Drawing.Point(14, 35);
            this.dgvNurse.Name = "dgvNurse";
            this.dgvNurse.ReadOnly = true;
            this.dgvNurse.RowTemplate.Height = 24;
            this.dgvNurse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNurse.Size = new System.Drawing.Size(245, 272);
            this.dgvNurse.TabIndex = 0;
            this.dgvNurse.SelectionChanged += new System.EventHandler(this.dgvNurse_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "護士列表";
            // 
            // picNurse
            // 
            this.picNurse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNurse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picNurse.Location = new System.Drawing.Point(127, 327);
            this.picNurse.Name = "picNurse";
            this.picNurse.Size = new System.Drawing.Size(132, 156);
            this.picNurse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNurse.TabIndex = 2;
            this.picNurse.TabStop = false;
            // 
            // txtNurseName
            // 
            this.txtNurseName.Location = new System.Drawing.Point(14, 362);
            this.txtNurseName.Name = "txtNurseName";
            this.txtNurseName.ReadOnly = true;
            this.txtNurseName.Size = new System.Drawing.Size(107, 29);
            this.txtNurseName.TabIndex = 3;
            this.txtNurseName.Text = "姓名";
            // 
            // txtNurseID
            // 
            this.txtNurseID.Location = new System.Drawing.Point(14, 327);
            this.txtNurseID.Name = "txtNurseID";
            this.txtNurseID.ReadOnly = true;
            this.txtNurseID.Size = new System.Drawing.Size(107, 29);
            this.txtNurseID.TabIndex = 4;
            this.txtNurseID.Text = "編號";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(45, 492);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 40);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "加入";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(112, 492);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 40);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(180, 492);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 40);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvSiteList
            // 
            this.dgvSiteList.AllowUserToAddRows = false;
            this.dgvSiteList.AllowUserToDeleteRows = false;
            this.dgvSiteList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiteList.Location = new System.Drawing.Point(325, 46);
            this.dgvSiteList.Name = "dgvSiteList";
            this.dgvSiteList.ReadOnly = true;
            this.dgvSiteList.RowTemplate.Height = 24;
            this.dgvSiteList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSiteList.Size = new System.Drawing.Size(245, 272);
            this.dgvSiteList.TabIndex = 16;
            // 
            // dgvAssigned
            // 
            this.dgvAssigned.AllowUserToAddRows = false;
            this.dgvAssigned.AllowUserToDeleteRows = false;
            this.dgvAssigned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssigned.Location = new System.Drawing.Point(6, 46);
            this.dgvAssigned.Name = "dgvAssigned";
            this.dgvAssigned.ReadOnly = true;
            this.dgvAssigned.RowTemplate.Height = 24;
            this.dgvAssigned.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssigned.Size = new System.Drawing.Size(245, 272);
            this.dgvAssigned.TabIndex = 15;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(262, 189);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(52, 40);
            this.btnRemove.TabIndex = 14;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(262, 120);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(52, 40);
            this.btnJoin.TabIndex = 13;
            this.btnJoin.Text = "排程";
            this.btnJoin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAssigned);
            this.groupBox1.Controls.Add(this.dgvSiteList);
            this.groupBox1.Controls.Add(this.btnJoin);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(280, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 361);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "負責站點修改";
            // 
            // frmNurseManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNurseID);
            this.Controls.Add(this.txtNurseName);
            this.Controls.Add(this.picNurse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNurse);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNurseManage";
            this.ShowInTaskbar = false;
            this.Text = "護士資訊管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNurseManage_FormClosing);
            this.Load += new System.EventHandler(this.frmNurseManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNurse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNurse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiteList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssigned)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNurse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picNurse;
        private System.Windows.Forms.TextBox txtNurseName;
        private System.Windows.Forms.TextBox txtNurseID;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvSiteList;
        private System.Windows.Forms.DataGridView dgvAssigned;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}