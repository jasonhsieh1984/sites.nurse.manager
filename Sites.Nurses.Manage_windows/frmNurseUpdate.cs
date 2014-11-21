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
    public partial class frmNurseUpdate : Form
    {
        private frmNurseManage nmform = null;
        public frmNurseManage NMForm
        {
            get { return nmform; }
            set { nmform = value; }
        }

        private clsNurse editData = new clsNurse();
        public clsNurse EditData
        {
            get { return editData; }
            set { editData = value; }
        }

        private Boolean bEdit = false;

        public frmNurseUpdate()
        {
            InitializeComponent();
        }

        private void frmNurseUpdate_Load(object sender, EventArgs e)
        {
            if (editData.ID == null)
                return;

            bEdit = true;
            txtNurseID.ReadOnly = true;
            txtNurseID.Text = editData.ID;
            txtNurseName.Text = editData.Name;
            //txtSiteMemo.Text = editData.Memo;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否確認新增/修改?\r\n" + "※編號一旦新增即無法修改.", "請確認", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (checkFormat() == -1)
                return;

            clsNurse data = new clsNurse();
            data.ID = txtNurseID.Text;
            data.Name = txtNurseName.Text;
            data.Image = "";

            if (bEdit)
            {
                if (nmform.updateNurse(data) == 0)
                {
                    Close();
                }
            }
            else
            {
                if (nmform.addNurse(data) == 0)
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
            if (txtNurseID.Text.Length > 10 || txtNurseName.Text.Length > 10)
            {
                string msg = "格式有誤，請重新確認.\r\n" + "ID最長為10個字元\r\n" + "名稱最長為10個字元\r\n";
                MessageBox.Show(msg);
                return -1;
            }
            return 0;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.FileName = "選擇圖片";
                ofd.Filter = "圖片檔|*.jpg;*.png;*.bmp;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
