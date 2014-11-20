using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sites.Nurses.Manage_windows
{
    public partial class frmSitesManage : Form
    {
        private clsSQLFunction sqlFunction = new clsSQLFunction();    
        private List<clsSite> lsSite = new List<clsSite>();

        public frmSitesManage()
        {
            InitializeComponent();
        }

        public int addSite(clsSite data)
        {
            foreach (clsSite tmpSite in lsSite)
            {
                if (tmpSite.ID == data.ID)
                {
                    MessageBox.Show("醫護站編號不可重覆，請重新確認。");
                    return -1;
                }
            }

            try
            {
                Application.DoEvents();
                //write into db
                if (sqlFunction.addSite(data) == 0)
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return -1;
        }

        public int updateSite(clsSite data)
        {
            try
            {
                //write into db
                Application.DoEvents();
                if (sqlFunction.updateSite(data) == 0)
                    return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            return -1;
        }

        private void frmSitesManage_Load(object sender, EventArgs e)
        {
            sqlFunction.open();
            refreshSiteList();            
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        private void refreshSiteList()
        {
            Application.DoEvents();
            dgvSite.DataSource = null;
            DataTable dtbGroup = new DataTable();
            #region "資料欄位"
            dtbGroup.Columns.Add(new DataColumn("編號", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("名稱", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("備註", Type.GetType("System.String")));
            #endregion
            
            Application.DoEvents();   
            lsSite.Clear();
            sqlFunction.getSiteList(out lsSite);

            Application.DoEvents();
            foreach (clsSite st in lsSite)
            {
                DataRow drGroup = dtbGroup.NewRow();
                drGroup["編號"] = st.ID;
                drGroup["名稱"] = st.Name;
                drGroup["備註"] = st.Memo;
                dtbGroup.Rows.Add(drGroup);
                drGroup = null;
            }

            dgvSite.DataSource = dtbGroup.DefaultView;
            dgvSite.Columns[0].Width = 100;
            dgvSite.Columns[1].Width = 150;
            dgvSite.Columns[2].Width = 150;
        }

        private void dgvSite_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSite.SelectedRows.Count > 0)
            {
                txtSiteID.Text = dgvSite.SelectedRows[0].Cells[0].Value.ToString();
                txtSiteName.Text = dgvSite.SelectedRows[0].Cells[1].Value.ToString();
                txtSiteMemo.Text = dgvSite.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        /// <summary>
        /// 新增站點
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSiteUpdate frmUpdate = new frmSiteUpdate();
            frmUpdate.SMForm = this;
            frmUpdate.ShowDialog();

            refreshSiteList();
        }

        /// <summary>
        /// 更新站點
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSite.SelectedRows.Count <= 0)
            {
                MessageBox.Show("請選擇欲修改的項目.");
                return;
            }

            clsSite data = new clsSite();
            data.ID = txtSiteID.Text;
            data.Name = txtSiteName.Text;
            data.Memo = txtSiteMemo.Text;

            frmSiteUpdate frmUpdate = new frmSiteUpdate();
            frmUpdate.SMForm = this;
            frmUpdate.EditData = data;
            frmUpdate.ShowDialog();

            refreshSiteList();
        }

        /// <summary>
        /// 刪除站點
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSite.SelectedRows.Count <= 0)
            {
                MessageBox.Show("請選擇欲刪除的項目.");
                return;
            }

            string msg = "ID:" + txtSiteID.Text +"\r\n"+
                         "Name:" + txtSiteName.Text + "\r\n"+
                         "是否確認刪除?";

            if (MessageBox.Show(msg, "請確認", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Application.DoEvents();

            if (sqlFunction.deleteSite(txtSiteID.Text) == -1)
                MessageBox.Show("刪除時發生錯誤");

            refreshSiteList();
        }
        
        private void frmSitesManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlFunction.close();
        }
    }
}