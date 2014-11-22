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
        /// �N���@����Ʒs�W�ܸ�Ʈw
        /// </summary>
        public int addSite(clsSite data)
        {
            foreach (clsSite tmpSite in lsSite)
            {
                if (tmpSite.ID == data.ID)
                {
                    MessageBox.Show("���@���s�����i���СA�Э��s�T�{�C");
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
            MessageBox.Show("�s�W��Ʈɵo�Ϳ��~");
            return -1;
        }

        /// <summary>
        /// �N���@����Ƨ�s�ܸ�Ʈw
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
            MessageBox.Show("��s��Ʈɵo�Ϳ��~");
            return -1;
        }

        private void frmSitesManage_Load(object sender, EventArgs e)
        {
            CenterToParent();
            if (sqlFunction.open() == -1)
            {
                MessageBox.Show("��Ʈw�}�ҿ��~�A�нT�{��Ʈw�O�_�s�b");
                Close();
            }
            refreshNurseList("", "");
            refreshSiteList("", "");
            refreshScheduleList();

            cmbSite.Items.Clear();
            cmbSite.Items.Add("ID");
            cmbSite.Items.Add("�W��");
            cmbSite.SelectedIndex = 0;
        }

        /// <summary>
        /// ��s�@�h�C��
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="searchString">searchString</param>
        private void refreshNurseList(String column, String searchString)
        {
            Application.DoEvents();
            lsNurse.Clear();
            if (sqlFunction.searchNurse(column, searchString, out lsNurse) == -1)
            {
                MessageBox.Show("��s�C��ɵo�Ϳ��~");
                return;
            }
        }

        /// <summary>
        /// ��s�C��
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
            #region "������"
            dtbGroup.Columns.Add(new DataColumn("�s��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("�W��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("�Ƶ�", Type.GetType("System.String")));
            #endregion

            Application.DoEvents();
            lsSite.Clear();
            if (sqlFunction.searchSite(column, searchString, out lsSite) == -1)
            {
                MessageBox.Show("��s�C��ɵo�Ϳ��~");
                return;
            }

            Application.DoEvents();
            foreach (clsSite st in lsSite)
            {
                DataRow drGroup = dtbGroup.NewRow();
                drGroup["�s��"] = st.ID;
                drGroup["�W��"] = st.Name;
                drGroup["�Ƶ�"] = st.Memo;
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
        /// ��s�����C��
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
                MessageBox.Show("��s�����C��o�Ϳ��~");
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
            #region "������"
            dtbGroup.Columns.Add(new DataColumn("�s��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("�W��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("i", Type.GetType("System.String")));
            #endregion

            Application.DoEvents();
            foreach (clsNurse data in lsAssigned)
            {
                DataRow drGroup = dtbGroup.NewRow();
                drGroup["�s��"] = data.ID;
                drGroup["�W��"] = data.Name;
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
        /// �s�W���I
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSiteUpdate frmUpdate = new frmSiteUpdate();
            frmUpdate.SMForm = this;
            frmUpdate.ShowDialog();

            refreshSiteList("","");
        }

        /// <summary>
        /// ��s���I
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSite.SelectedRows.Count <= 0)
            {
                MessageBox.Show("�п�ܱ��ק諸����.");
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
        /// �R�����I
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSite.SelectedRows.Count <= 0)
            {
                MessageBox.Show("�п�ܱ��R��������.");
                return;
            }

            string msg = "ID:" + txtSiteID.Text +"\r\n"+
                         "Name:" + txtSiteName.Text + "\r\n"+
                         "�O�_�T�{�R��?";

            if (MessageBox.Show(msg, "�нT�{", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Application.DoEvents();

            clsSite data = new clsSite();
            data.ID = txtSiteID.Text;

            if (sqlFunction.deleteSchedule(data) == -1)
                MessageBox.Show("�R��������Ʈɵo�Ϳ��~");

            if (sqlFunction.deleteSite(txtSiteID.Text) == -1)
                MessageBox.Show("�R���@�z����Ʈɵo�Ϳ��~");

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