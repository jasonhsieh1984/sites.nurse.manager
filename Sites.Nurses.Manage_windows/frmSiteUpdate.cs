using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sites.Nurses.Manage_windows
{
    public partial class frmSiteUpdate : Form
    {
        private frmSitesManage smform = null;
        public frmSitesManage SMForm
        {
            get { return smform; }
            set { smform = value; }
        }

        private clsSite editData = new clsSite();
        public clsSite EditData
        {
            get { return editData; }
            set { editData = value; }
        }
        
        private Boolean bEdit = false;

        public frmSiteUpdate()
        {
            InitializeComponent();
        }

        private void frmSiteUpdate_Load(object sender, EventArgs e)
        {
            CenterToParent();
            if (editData.ID == null)
                return;

            bEdit = true;
            txtSiteID.ReadOnly = true;
            txtSiteID.Text = editData.ID;
            txtSiteName.Text = editData.Name;
            txtSiteMemo.Text = editData.Memo;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否確認新增/修改?\r\n" + "※編號一旦新增即無法修改.", "請確認", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (checkFormat() == -1)
                return;

            clsSite data = new clsSite();
            data.ID = txtSiteID.Text;
            data.Name = txtSiteName.Text;
            data.Memo = txtSiteMemo.Text;

            if (bEdit)
            {
                if (smform.updateSite(data) == 0)
                {
                    Close();
                }
            }
            else
            {
                if (smform.addSite(data) == 0)
                {                   
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private int checkFormat() 
        {
            if (txtSiteID.Text.Length > 10 || txtSiteName.Text.Length > 10)
            {
                string msg = "格式有誤，請重新確認.\r\n" + "ID最長為10個字元\r\n" + "名稱最長為10個字元\r\n";
                MessageBox.Show(msg);
                return -1;
            }

            if (txtSiteID.Text=="" || txtSiteName.Text=="")
            {
                string msg = "格式有誤，請重新確認.\r\n" + "ID與名稱皆不可空白";
                MessageBox.Show(msg);
                return -1;
            }
            return 0;
        }

        private void txtSiteID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z')) ||
                (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == '-'))
                e.Handled = false;
        }
    }
}
