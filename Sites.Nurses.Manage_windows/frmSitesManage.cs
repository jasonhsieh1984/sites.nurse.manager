using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sites.Nurses.Manage_windows
{
    public partial class frmSitesManage : Form
    {
        private string imagePath = Application.StartupPath + "\\image\\";

        private clsSQLFunction sqlFunction = new clsSQLFunction();
        private List<clsNurse> lsNurse = new List<clsNurse>();
        private List<clsSite> lsSite = new List<clsSite>();                
        private List<clsSchedule> lsSchedule = new List<clsSchedule>();

        public frmSitesManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 將醫護站資料新增至資料庫
        /// </summary>
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
            MessageBox.Show("新增資料時發生錯誤");
            return -1;
        }

        /// <summary>
        /// 將醫護站資料更新至資料庫
        /// </summary>
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
            MessageBox.Show("更新資料時發生錯誤");
            return -1;
        }

        private void frmSitesManage_Load(object sender, EventArgs e)
        {
            CenterToParent();
            if (sqlFunction.open() == -1)
            {
                MessageBox.Show("資料庫開啟錯誤，請確認資料庫是否存在");
                Close();
            }
            refreshNurseList("", "");
            refreshSiteList("", "");
            refreshScheduleList();

            cmbSite.Items.Clear();
            cmbSite.Items.Add("ID");
            cmbSite.Items.Add("名稱");
            cmbSite.SelectedIndex = 0;
        }

        /// <summary>
        /// 更新護士列表
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="searchString">searchString</param>
        private void refreshNurseList(String column, String searchString)
        {
            Application.DoEvents();
            lsNurse.Clear();
            if (sqlFunction.searchNurse(column, searchString, out lsNurse) == -1)
            {
                MessageBox.Show("更新列表時發生錯誤");
                return;
            }
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="searchString">searchString</param>
        private void refreshSiteList(String column, String searchString)
        {
            txtSiteID.Text = "";
            txtSiteName.Text = "";
            txtSiteMemo.Text = "";

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
            if (sqlFunction.searchSite(column, searchString, out lsSite) == -1)
            {
                MessageBox.Show("更新列表時發生錯誤");
                return;
            }

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
            dgvSite.Sort(dgvSite.Columns[0], ListSortDirection.Ascending);
        }

        /// <summary>
        /// 更新分派列表
        /// </summary>
        private void refreshScheduleList()
        {
            txtNurseID.Text = "";
            txtNurseName.Text = "";
            picNurse.Image = null;

            Application.DoEvents();
            lsSchedule.Clear();
            dgvAssigned.DataSource = null;
            if (dgvSite.SelectedRows.Count <= 0)
                return;

            if (sqlFunction.getSscheduleListBySite(txtSiteID.Text, out lsSchedule) == -1)
            {
                MessageBox.Show("更新分派列表發生錯誤");
                return;
            }

            List<clsNurse> lsAssigned = new List<clsNurse>();
            foreach (clsSchedule Sch in lsSchedule)
            {
                foreach (clsNurse nurse in lsNurse)
                {
                    if (Sch.NurseID == nurse.ID)
                    {
                        lsAssigned.Add(nurse);
                        continue;
                    }
                }
            }

            Application.DoEvents();
            dgvAssigned.DataSource = null;
            DataTable dtbGroup = new DataTable();
            #region "資料欄位"
            dtbGroup.Columns.Add(new DataColumn("編號", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("名稱", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("i", Type.GetType("System.String")));
            #endregion

            Application.DoEvents();
            foreach (clsNurse data in lsAssigned)
            {
                DataRow drGroup = dtbGroup.NewRow();
                drGroup["編號"] = data.ID;
                drGroup["名稱"] = data.Name;
                drGroup["i"] = data.Image;
                dtbGroup.Rows.Add(drGroup);
                drGroup = null;
            }

            dgvAssigned.DataSource = dtbGroup.DefaultView;
            dgvAssigned.Columns[0].Width = 100;
            dgvAssigned.Columns[1].Width = 100;
            dgvAssigned.Columns[2].Width = 5;
            dgvAssigned.Sort(dgvAssigned.Columns[0], ListSortDirection.Ascending);
        }

        private void dgvSite_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSite.SelectedRows.Count > 0)
            {
                txtSiteID.Text = dgvSite.SelectedRows[0].Cells[0].Value.ToString();
                txtSiteName.Text = dgvSite.SelectedRows[0].Cells[1].Value.ToString();
                txtSiteMemo.Text = dgvSite.SelectedRows[0].Cells[2].Value.ToString();
                refreshScheduleList();
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

            refreshSiteList("","");
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

            refreshSiteList("","");
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

            clsSite data = new clsSite();
            data.ID = txtSiteID.Text;

            if (sqlFunction.deleteSchedule(data) == -1)
                MessageBox.Show("刪除分派資料時發生錯誤");

            if (sqlFunction.deleteSite(txtSiteID.Text) == -1)
                MessageBox.Show("刪除護理站資料時發生錯誤");

            refreshSiteList("","");
        }
        
        private void frmSitesManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlFunction.close();
        }

        private void dgvAssigned_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAssigned.SelectedRows.Count > 0)
            {
                picNurse.Image = null;
                txtNurseID.Text = dgvAssigned.SelectedRows[0].Cells[0].Value.ToString();
                txtNurseName.Text = dgvAssigned.SelectedRows[0].Cells[1].Value.ToString();
                if (File.Exists(imagePath + dgvAssigned.SelectedRows[0].Cells[2].Value.ToString()))
                    picNurse.Load(imagePath + dgvAssigned.SelectedRows[0].Cells[2].Value.ToString());
                else if (File.Exists(Application.StartupPath + "\\NoImage.jpg"))
                    picNurse.Load(Application.StartupPath + "\\NoImage.jpg");
            }
        }

        private void cmbSite_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnShowAllSite_Click(object sender, EventArgs e)
        {
            txtSiteSearch.Text = "";
            refreshSiteList("", "");
        }

        private void btnSiteSearch_Click(object sender, EventArgs e)
        {
            String searchBy = "id";
            if (cmbSite.SelectedIndex == 1)
                searchBy = "name";
            refreshSiteList(searchBy, txtSiteSearch.Text);
        }
    }
}