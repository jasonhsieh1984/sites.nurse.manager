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
            return -1;
        }

        private void frmSitesManage_Load(object sender, EventArgs e)
        {
            sqlFunction.open();
            refreshSiteList();            
        }

        /// <summary>
        /// ��s�C��
        /// </summary>
        private void refreshSiteList()
        {
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
            sqlFunction.getSiteList(out lsSite);

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
        /// �s�W���I
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSiteUpdate frmUpdate = new frmSiteUpdate();
            frmUpdate.SMForm = this;
            frmUpdate.ShowDialog();

            refreshSiteList();
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

            refreshSiteList();
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

            if (sqlFunction.deleteSite(txtSiteID.Text) == -1)
                MessageBox.Show("�R���ɵo�Ϳ��~");

            refreshSiteList();
        }
        
        private void frmSitesManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlFunction.close();
        }
    }
}