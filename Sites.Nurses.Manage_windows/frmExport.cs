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
    public partial class frmExport : Form
    {
        private string filePath = Application.StartupPath + "\\export\\";
        private clsSQLFunction sqlFunction = new clsSQLFunction();
        private List<clsNurse> lsNurse = new List<clsNurse>();
        private List<clsSite> lsSite = new List<clsSite>();
        private List<clsSchedule> lsSchedule = new List<clsSchedule>();
        
        public frmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            CenterToParent();

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            sqlFunction.open();
            if (sqlFunction.searchNurse("", "", out lsNurse) == -1)
                MessageBox.Show("取得護士列表時發生錯誤");

            if (sqlFunction.searchSite("", "", out lsSite) == -1)
                MessageBox.Show("取得醫護站列表時發生錯誤");

        }

        private void btnExportBySite_Click(object sender, EventArgs e)
        {
            if (lsSite.Count <= 0)
            {
                MessageBox.Show("目前無站點資料");
                return;
            }

            string fileName = filePath + DateTime.Now.Ticks + ".csv";
            if (File.Exists(fileName))
                File.Delete(fileName);

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            try
            {
                foreach (clsSite siteData in lsSite)
                {
                    sw.WriteLine("醫護站編號,醫護站名稱");
                    sw.WriteLine(siteData.ID + "," + siteData.Name);
                    sw.WriteLine("備註," + siteData.Memo.Replace("\r\n","."));
                    lsSchedule.Clear();

                    if (sqlFunction.getSscheduleListBySite(siteData.ID, out lsSchedule) == -1)
                    {
                        MessageBox.Show(siteData.ID + "," + siteData.Name + "\r\n分派資料錯誤");
                        break;
                    }

                    string strIDs = "護士編號,";
                    string strNames = "護士姓名,";
                    string strImages = "照片名稱,";
                    foreach (clsSchedule schData in lsSchedule)
                    {
                        Application.DoEvents();
                        foreach (clsNurse nurseData in lsNurse)
                        {
                            if (schData.NurseID == nurseData.ID)
                            {
                                strIDs += nurseData.ID+",";
                                strNames += nurseData.Name + ",";
                                strImages += nurseData.Image + ",";
                                break;
                            }
                        }
                    }

                    sw.WriteLine(strIDs);
                    sw.WriteLine(strNames);
                    sw.WriteLine(strImages);
                    sw.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

            if (MessageBox.Show("檔案已新增，是否直接開啟?\r\n" + fileName, "請確認", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                System.Diagnostics.Process.Start(fileName);
        }

        private void btnExportByNurse_Click(object sender, EventArgs e)
        {
            if (lsNurse.Count <= 0)
            {
                MessageBox.Show("目前無護士資料");
                return;
            }

            string fileName = filePath + DateTime.Now.Ticks + ".csv";
            if (File.Exists(fileName))
                File.Delete(fileName);

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            try
            {
                foreach (clsNurse nurseData in lsNurse)
                {
                    sw.WriteLine("護士編號,護士姓名,照片名稱" );
                    sw.WriteLine(nurseData.ID + "," + nurseData.Name + "," + nurseData.Image);
                    lsSchedule.Clear();
                    if (sqlFunction.getSscheduleListByNurse(nurseData.ID, out lsSchedule) == -1)
                    {
                        MessageBox.Show(nurseData.ID + "," + nurseData.Name + "\r\n分派資料錯誤");
                        break;
                    }

                    string strIDs = "醫護站編號,";
                    string strNames = "醫護站名稱,";
                    string strMemo = "備註,";
                    foreach (clsSchedule schData in lsSchedule)
                    {
                        Application.DoEvents();
                        foreach (clsSite siteData in lsSite)
                        {
                            if (schData.SiteID == siteData.ID)
                            {
                                strIDs += siteData.ID + ",";
                                strNames += siteData.Name + ",";
                                strMemo += siteData.Memo.Replace("\r\n", ".") + ",";
                                break;
                            }
                        }
                    }

                    sw.WriteLine(strIDs);
                    sw.WriteLine(strNames);
                    sw.WriteLine(strMemo);
                    sw.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

            if (MessageBox.Show("檔案已新增，是否直接開啟?\r\n" + fileName, "請確認", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                System.Diagnostics.Process.Start(fileName);
        }

        private void frmExport_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlFunction.close();
        }
    }
}
