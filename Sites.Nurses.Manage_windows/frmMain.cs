using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Data.SQLite;

namespace Sites.Nurses.Manage_windows
{
    public partial class frmMain : Form
    {
        private string imagePath = Application.StartupPath + "\\image\\";
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            initilize();
            CenterToScreen();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void initilize()
        {         
            Application.DoEvents();
            if (!Directory.Exists(imagePath))
                Directory.CreateDirectory(imagePath);
        }

        private void btnSite_Click(object sender, EventArgs e)
        {
            try
            {
                frmSitesManage frmSites = new frmSitesManage();
                frmSites.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNurse_Click(object sender, EventArgs e)
        {
            try
            {
                frmNurseManage frmNurse = new frmNurseManage();
                frmNurse.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 從工具列圖示還原
        /// </summary>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //讓Form再度顯示，並寫狀態設為Normal
            this.Show();
            this.WindowState = FormWindowState.Normal;
            CenterToScreen();
        }

        /// <summary>
        /// 縮小至工具列圖示
        /// </summary>
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon.Visible = true;
            }
        }
    }
}