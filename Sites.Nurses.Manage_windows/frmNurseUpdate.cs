using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sites.Nurses.Manage_windows
{
    public partial class frmNurseUpdate : Form
    {
        private string imagePath = Application.StartupPath + "\\image\\";

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
            CenterToParent();
            if (editData.ID == null)
                return;

            bEdit = true;
            txtNurseID.ReadOnly = true;
            txtNurseID.Text = editData.ID;
            txtNurseName.Text = editData.Name;
            if (File.Exists(imagePath + editData.Image))
                picNurse.Load(imagePath + editData.Image);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否確認新增/修改?\r\n" + "※編號一旦新增即無法修改.", "請確認", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (checkFormat() == -1)
                return;

            clsNurse data = new clsNurse();
            editData.ID = txtNurseID.Text;
            editData.Name = txtNurseName.Text;
            if (editData.Image == null)
                editData.Image = "";

            if (bEdit)
            {
                if (nmform.updateNurse(editData) == 0)
                {
                    Close();
                }
            }
            else
            {
                if (nmform.addNurse(editData) == 0)
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

            if (txtNurseID.Text == "" || txtNurseName.Text == "")
            {
                string msg = "格式有誤，請重新確認.\r\n" + "ID與名稱皆不可空白";
                MessageBox.Show(msg);
                return -1;
            }
            return 0;
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                picNurse.Image = null;
                Application.DoEvents();

                OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.FileName = "選擇圖片";
                ofd.Filter = "圖片檔|*.jpg;*.png;*.bmp;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.Cancel)
                    return;
                                
                if (bEdit)
                {
                    string previousPath = editData.Image;
                    string tmpFileName = DateTime.Now.Ticks.ToString();
                    File.Copy(ofd.FileName, imagePath + tmpFileName + Path.GetExtension(ofd.FileName));
                    editData.Image = tmpFileName + Path.GetExtension(ofd.FileName);

                    picNurse.Load(imagePath + editData.Image);

                    //if (File.Exists(imagePath + previousPath))
                        //File.Delete(imagePath + previousPath);                    
                }
                else
                {
                    string tmpFileName = DateTime.Now.Ticks.ToString();
                    File.Copy(ofd.FileName, imagePath + tmpFileName + Path.GetExtension(ofd.FileName));
                    editData.Image = tmpFileName + Path.GetExtension(ofd.FileName);
                    picNurse.Load(imagePath + editData.Image);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtNurseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z')) ||
                (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == '-'))
                e.Handled = false;
        }
    }
}
