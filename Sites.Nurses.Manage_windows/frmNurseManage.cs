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
            return -1;
        }

        private void frmNurseManage_Load(object sender, EventArgs e)
        {
            sqlFunction.open();
            refreshNurseList();
            refreshSiteList();
        }

        /// <summary>
        /// ��s�@�h�C��
        /// </summary>
        private void refreshNurseList()
        {
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
            sqlFunction.getNurseList(out lsNurse);

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
        }

        /// <summary>
        /// ��s���@���C��
        /// </summary>
        private void refreshSiteList()
        {
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
            sqlFunction.getSiteList(out lsSite);

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
        }

        private void dgvNurse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNurse.SelectedRows.Count > 0)
            {
                txtNurseID.Text = dgvNurse.SelectedRows[0].Cells[0].Value.ToString();
                txtNurseName.Text = dgvNurse.SelectedRows[0].Cells[1].Value.ToString();                
                
                String fileName = dgvNurse.SelectedRows[0].Cells[2].Value.ToString();
                if (fileName!="" && File.Exists(imagePath + fileName))
                {
                    picNurse.Load(imagePath + fileName);
                }
                else
                    picNurse.Load(Application.StartupPath + "\\NoImage.jpg");
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

            refreshNurseList();
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
            data.ID = txtNurseID.Text;
            data.Name = txtNurseName.Text;
            data.Image = "";

            frmNurseUpdate frmUpdate = new frmNurseUpdate();
            frmUpdate.NMForm = this;
            frmUpdate.EditData = data;
            frmUpdate.ShowDialog();

            refreshNurseList();
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

            if (sqlFunction.deleteNurse(txtNurseID.Text) == -1)
                MessageBox.Show("�R���ɵo�Ϳ��~");

            refreshNurseList();
        }

        private void frmNurseManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlFunction.close();
        }
    }
}