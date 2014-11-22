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
    public partial class frmNurseManage : Form
    {
        private string imagePath = Application.StartupPath + "\\image\\";

        private clsSQLFunction sqlFunction = new clsSQLFunction();
        private List<clsNurse> lsNurse = new List<clsNurse>();
        private List<clsSite> lsSite = new List<clsSite>();
        private List<clsSchedule> lsSchedule = new List<clsSchedule>();

        public frmNurseManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �N�@�h��Ʒs�W�ܸ�Ʈw
        /// </summary>
        public int addNurse(clsNurse data)
        {
            foreach (clsNurse tmpNurse in lsNurse)
            {
                if (tmpNurse.ID == data.ID)
                {
                    MessageBox.Show("���@���s�����i���СA�Э��s�T�{�C");
                    return -1;
                }
            }

            try
            {
                Application.DoEvents();
                //write into db
                if (sqlFunction.addNurse(data) == 0)
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
        /// �N�@�h��Ƨ�s�ܸ�Ʈw
        /// </summary>
        public int updateNurse(clsNurse data)
        {
            try
            {
                //write into db
                Application.DoEvents();
                if (sqlFunction.updateNurse(data) == 0)
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

        private void frmNurseManage_Load(object sender, EventArgs e)
        {
            CenterToParent();
            if (sqlFunction.open() == -1)
            {
                MessageBox.Show("��Ʈw�}�ҿ��~�A�нT�{��Ʈw�O�_�s�b");
                Close();
            }
            refreshNurseList("", "");
            refreshSiteList("","");
            refreshScheduleList();

            cmbNurse.Items.Clear();
            cmbNurse.Items.Add("ID");
            cmbNurse.Items.Add("�W��");
            cmbNurse.SelectedIndex = 0;
        }

        /// <summary>
        /// ��s�@�h�C��
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="searchString">searchString</param>
        private void refreshNurseList(String column,String searchString)
        {
            txtNurseID.Text = "";
            txtNurseName.Text = "";
            picNurse.Image = null;

            Application.DoEvents();
            dgvNurse.DataSource = null;
            DataTable dtbGroup = new DataTable();
            #region "������"
            dtbGroup.Columns.Add(new DataColumn("�s��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("�W��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("i", Type.GetType("System.String")));
            #endregion

            Application.DoEvents();
            lsNurse.Clear();
            if (sqlFunction.searchNurse(column, searchString, out lsNurse) == -1)
            {
                MessageBox.Show("��s�C��ɵo�Ϳ��~");
                return;
            }

            Application.DoEvents();
            foreach (clsNurse data in lsNurse)
            {
                DataRow drGroup = dtbGroup.NewRow();
                drGroup["�s��"] = data.ID;
                drGroup["�W��"] = data.Name;
                drGroup["i"] = data.Image;
                dtbGroup.Rows.Add(drGroup);
                drGroup = null;
            }

            dgvNurse.DataSource = dtbGroup.DefaultView;
            dgvNurse.Columns[0].Width = 100;
            dgvNurse.Columns[1].Width = 100;
            dgvNurse.Columns[2].Width = 5;
            dgvNurse.Sort(dgvNurse.Columns[0], ListSortDirection.Ascending);
        }

        /// <summary>
        /// ��s���@���C��
        /// </summary>
        private void refreshSiteList(String column, String searchString)
        {
            txtSiteMemo.Text = "";

            Application.DoEvents();
            dgvSiteList.DataSource = null;
            DataTable dtbGroup = new DataTable();
            #region "������"
            dtbGroup.Columns.Add(new DataColumn("�s��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("�W��", Type.GetType("System.String")));
            dtbGroup.Columns.Add(new DataColumn("m", Type.GetType("System.String")));
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
                drGroup["m"] = st.Memo;
                dtbGroup.Rows.Add(drGroup);
                drGroup = null;
            }

            dgvSiteList.DataSource = dtbGroup.DefaultView;
            dgvSiteList.Columns[0].Width = 100;
            dgvSiteList.Columns[1].Width = 100;
            dgvSiteList.Columns[2].Width = 5;
            dgvSiteList.Sort(dgvSiteList.Columns[0], ListSortDirection.Ascending);
        }

        /// <summary>
        /// ��s�����C��
        /// </summary>
        private void refreshScheduleList()
        {
            txtScheduleMemo.Text = "";
            Application.DoEvents();
            lsSchedule.Clear();
            dgvAssigned.DataSource = null;

            if (dgvNurse.SelectedRows.Count <= 0)
                return;
            if (sqlFunction.getSscheduleListByNurse(txtNurseID.Text, out lsSchedule)==-1)
            {
                MessageBox.Show("���o������Ʈɵo�Ϳ��~");
                return;
            }

            List<clsSite> lsAssigned = new List<clsSite>();
            foreach (clsSchedule Sch in lsSchedule)
            {
                foreach (clsSite st in lsSite)
                {
                    if (Sch.SiteID == st.ID)
                    {
                        lsAssigned.Add(st);
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
            dtbGroup.Columns.Add(new DataColumn("m", Type.GetType("System.String")));
            #endregion
            
            Application.DoEvents();
            foreach (clsSite st in lsAssigned)
            {
                DataRow drGroup = dtbGroup.NewRow();
                drGroup["�s��"] = st.ID;
                drGroup["�W��"] = st.Name;
                drGroup["m"] = st.Memo;
                dtbGroup.Rows.Add(drGroup);
                drGroup = null;
            }

            dgvAssigned.DataSource = dtbGroup.DefaultView;
            dgvAssigned.Columns[0].Width = 100;
            dgvAssigned.Columns[1].Width = 100;
            dgvAssigned.Columns[2].Width = 5;
            dgvAssigned.Sort(dgvAssigned.Columns[0], ListSortDirection.Ascending);
        }

        private void dgvNurse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNurse.SelectedRows.Count > 0)
            {
                txtNurseID.Text = dgvNurse.SelectedRows[0].Cells[0].Value.ToString();
                txtNurseName.Text = dgvNurse.SelectedRows[0].Cells[1].Value.ToString();                
                
                String fileName = dgvNurse.SelectedRows[0].Cells[2].Value.ToString();
                if (fileName != "" && File.Exists(imagePath + fileName))
                {
                    picNurse.Load(imagePath + fileName);
                }
                else
                {
                    if (File.Exists(Application.StartupPath + "\\NoImage.jpg"))
                        picNurse.Load(Application.StartupPath + "\\NoImage.jpg");
                }

                refreshScheduleList();
            }
        }

        /// <summary>
        /// �s�W�@�h
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNurseUpdate frmUpdate = new frmNurseUpdate();
            frmUpdate.NMForm = this;
            frmUpdate.ShowDialog();

            refreshNurseList("","");
        }

        /// <summary>
        /// �ק��@�h
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvNurse.SelectedRows.Count <= 0)
            {
                MessageBox.Show("�п�ܱ��ק諸����.");
                return;
            }

            clsNurse data = new clsNurse();
            data.ID = dgvNurse.SelectedRows[0].Cells[0].Value.ToString();
            data.Name = dgvNurse.SelectedRows[0].Cells[1].Value.ToString();
            data.Image = dgvNurse.SelectedRows[0].Cells[2].Value.ToString();
            picNurse.Image = null;

            frmNurseUpdate frmUpdate = new frmNurseUpdate();
            frmUpdate.NMForm = this;
            frmUpdate.EditData = data;
            frmUpdate.ShowDialog();

            refreshNurseList("","");
        }

        /// <summary>
        /// �R���@�h
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNurse.SelectedRows.Count <= 0)
            {
                MessageBox.Show("�п�ܱ��R��������.");
                return;
            }

            string msg = "ID:" + txtNurseID.Text + "\r\n" +
                         "Name:" + txtNurseName.Text + "\r\n" +
                         "�O�_�T�{�R��?";

            if (MessageBox.Show(msg, "�нT�{", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Application.DoEvents();

            clsNurse data = new clsNurse();
            data.ID = txtNurseID.Text;

            if (sqlFunction.deleteSchedule(data)== -1)
                MessageBox.Show("�R��������Ʈɵo�Ϳ��~");
            

            if (sqlFunction.deleteNurse(txtNurseID.Text) == -1)
                MessageBox.Show("�R���@�h��Ʈɵo�Ϳ��~");
            

            refreshNurseList("","");
            refreshScheduleList();
        }

        private void frmNurseManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlFunction.close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvNurse.SelectedRows.Count <= 0)
                return;

            if (dgvSiteList.SelectedRows.Count > 0)
            {
                foreach (clsSchedule sch in lsSchedule)
                {
                    if (sch.SiteID == dgvSiteList.SelectedRows[0].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("�����I�w�g�����A�Э��s�T�{");
                        return;
                    }
                }

                clsSchedule data = new clsSchedule();
                data.NurseID = dgvNurse.SelectedRows[0].Cells[0].Value.ToString();
                data.SiteID = dgvSiteList.SelectedRows[0].Cells[0].Value.ToString();

                if (sqlFunction.addSchedule(data) == -1)
                    MessageBox.Show("�s�W�����ɵo�Ϳ��~");

                refreshScheduleList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAssigned.SelectedRows.Count <= 0)
            {
                MessageBox.Show("�п�ܱ������������C");
                return;
            }

            clsSchedule data = new clsSchedule();
            data.NurseID = dgvNurse.SelectedRows[0].Cells[0].Value.ToString();
            data.SiteID = dgvAssigned.SelectedRows[0].Cells[0].Value.ToString();
            if (sqlFunction.deleteSchedule(data) == -1)
                MessageBox.Show("�R��������Ʈɵo�Ϳ��~");

            refreshScheduleList();
        }

        private void dgvAssigned_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAssigned.SelectedRows.Count > 0)
                txtScheduleMemo.Text = dgvAssigned.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void dgvSiteList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSiteList.SelectedRows.Count > 0)
                txtSiteMemo.Text = dgvSiteList.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void dgvNurse_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_Click(null, null);
        }

        private void dgvAssigned_DoubleClick(object sender, EventArgs e)
        {
            btnRemove_Click(null, null);
        }

        private void dgvSiteList_DoubleClick(object sender, EventArgs e)
        {
            btnAssign_Click(null, null);
        }

        private void cmbNurse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnNurseSearch_Click(object sender, EventArgs e)
        {
            String searchBy = "id";
            if (cmbNurse.SelectedIndex == 1)
                searchBy = "name";
            refreshNurseList(searchBy, txtNurseSearch.Text);
        }

        private void btnShowAllNurse_Click(object sender, EventArgs e)
        {
            txtNurseSearch.Text = "";
            refreshNurseList("", "");
        }
    }
}