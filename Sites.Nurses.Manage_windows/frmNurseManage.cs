using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sites.Nurses.Manage_windows
{
    public partial class frmNurseManage : Form
    {
        private frmMain mform = null;
        public frmMain MForm
        {
            get { return mform; }
            set { mform = value; }
        }

        public frmNurseManage()
        {
            InitializeComponent();
        }

        private void frmNurseManage_Load(object sender, EventArgs e)
        {

        }
    }
}