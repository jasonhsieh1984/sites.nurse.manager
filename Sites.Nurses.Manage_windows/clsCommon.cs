using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Sites.Nurses.Manage_windows
{
    /// <summary>
    /// ���I���
    /// </summary>
    /// <param name="ID">ID</param>
    /// <param name="Name">�W��</param>
    /// <param name="Memo">�Ƶ�</param>
    public class clsSite
    {
        private string strID;
        private string strName;
        private string strMemo;

        /// <summary>
        /// �s��
        /// </summary>
        public String ID
        {
            get { return strID; }  // Getter
            set { strID = value; } // Setter
        }

        /// <summary>
        /// �W��
        /// </summary>
        public String Name
        {
            get { return strName; }  // Getter
            set { strName = value; } // Setter
        }

        /// <summary>
        /// �Ƶ�
        /// </summary>
        public String Memo
        {
            get { return strMemo; }  // Getter
            set { strMemo = value; } // Setter
        }
    }

    /// <summary>
    /// �@�h���
    /// </summary>
    /// <param name="ID">ID</param>
    /// <param name="Name">�W��</param>
    /// <param name="Image">�Ӥ��ɦW</param>
    public class clsNurse
    {
        private string strID;
        private string strName;
        private string strImage;

        /// <summary>
        /// �s��
        /// </summary>
        public String ID
        {
            get { return strID; }  // Getter
            set { strID = value; } // Setter
        }

        /// <summary>
        /// �m�W
        /// </summary>
        public String Name
        {
            get { return strName; }  // Getter
            set { strName = value; } // Setter
        }

        /// <summary>
        /// �Ӥ����|
        /// </summary>
        public String Image
        {
            get { return strImage; }  // Getter
            set { strImage = value; } // Setter
        }
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <param name="NurseID">�@�h�s��</param>
    /// <param name="SiteID">�@�z���s��</param>
    public class clsSchedule
    {
        private string strNurseID;
        private string strSiteID;

        /// <summary>
        /// �@�h�s��
        /// </summary>
        public String NurseID
        {
            get { return strNurseID; }  // Getter
            set { strNurseID = value; } // Setter
        }

        /// <summary>
        /// �@�z���s��
        /// </summary>
        public String SiteID
        {
            get { return strSiteID; }  // Getter
            set { strSiteID = value; } // Setter
        }        
    }

    /// <summary>
    /// SQL�\��
    /// </summary>
    public class clsSQLFunction
    {
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data source=sites.nurse.schedule.s3db");

        /// <summary>
        /// �}�Ҹ�Ʈw
        /// </summary>
        public int open()
        {
            try
            {
                sqlite_conn.Open();
                return 0;
            }
            catch
            {              
                return -1;
            }
        }

        /// <summary>
        /// ������Ʈw
        /// </summary>
        public int close()
        {
            try
            {
                sqlite_conn.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �s�W�@���@�h���
        /// </summary>
        /// <param name="data">�@�h���</param>
        public int addNurse(clsNurse data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command

                sqlite_cmd.CommandText = "INSERT INTO nurse VALUES ('" + data.ID + "','" + data.Name + "','" + data.Image + "');";
                sqlite_cmd.ExecuteNonQuery();//using behind every write cmd

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// ��s�@���@�h���
        /// </summary>
        /// <param name="data">�@�h���</param>
        public int updateNurse(clsNurse data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command

                sqlite_cmd.CommandText = "UPDATE nurse SET name='" + data.Name + "', path='" + data.Image + "' WHERE id='" + data.ID + "';";
                sqlite_cmd.ExecuteNonQuery();//using behind every write cmd

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �R���@���@�h���
        /// </summary>
        /// <param name="id">�@�hID</param>
        public int deleteNurse(String id)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command

                sqlite_cmd.CommandText = "DELETE FROM nurse WHERE id='" + id + "';";
                sqlite_cmd.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �s�W�@���@�z�����
        /// </summary>
        /// <param name="data">�@�z�����</param>
        public int addSite(clsSite data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command

                sqlite_cmd.CommandText = "INSERT INTO site VALUES ('"+data.ID+"','"+data.Name+"','"+data.Memo+"');";
                sqlite_cmd.ExecuteNonQuery();//using behind every write cmd
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// ��s�@���@�z�����
        /// </summary>
        /// <param name="data">�@�z�����</param>
        public int updateSite(clsSite data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command

                sqlite_cmd.CommandText = "UPDATE site SET name='" + data.Name + "', memo='" + data.Memo + "' WHERE id='" + data.ID + "';";
                sqlite_cmd.ExecuteNonQuery();//using behind every write cmd
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �R���@���@�z�����
        /// </summary>
        /// <param name="id">�@�z��ID</param>
        public int deleteSite(String id)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command

                sqlite_cmd.CommandText = "DELETE FROM site WHERE id='" + id + "';";
                sqlite_cmd.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �s�W�@���������
        /// </summary>
        /// <param name="data">�������</param>
        public int addSchedule(clsSchedule data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command

                sqlite_cmd.CommandText = "INSERT INTO schedule VALUES ('" + data.NurseID + "','" + data.SiteID + "');";
                sqlite_cmd.ExecuteNonQuery();//using behind every write cmd
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �R���@���������
        /// </summary>
        /// <param name="data">�������</param>
        public virtual int deleteSchedule(clsSchedule data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command
                sqlite_cmd.CommandText = "DELETE FROM schedule WHERE nurse_id='" + data.NurseID + "' AND site_id='" + data.SiteID + "';";
                sqlite_cmd.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �R���Ҧ������I���������
        /// </summary>
        /// <param name="data">���I���</param>
        public virtual int deleteSchedule(clsSite data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command
                sqlite_cmd.CommandText = "DELETE FROM schedule WHERE site_id='" + data.ID + "';";
                sqlite_cmd.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// �R���Ҧ����@�h���������
        /// </summary>
        /// <param name="data">�@�h���</param>
        public virtual int deleteSchedule(clsNurse data)
        {
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd = sqlite_conn.CreateCommand();//create command
                sqlite_cmd.CommandText = "DELETE FROM schedule WHERE nurse_id='" + data.ID + "';";
                sqlite_cmd.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        ///���@�h�s�����o�����C��
        /// </summary>
        /// <param name="nurseID">nurseID</param>
        /// <param name="listSchedule">listSchedule</param>
        public int getSscheduleListByNurse(string nurseID,out List<clsSchedule> listSchedule)
        {
            List<clsSchedule> ls = new List<clsSchedule>();
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM schedule WHERE nurse_id='" + nurseID + "' ORDER BY nurse_id, site_id ASC;";
                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read()) //read data
                {
                    clsSchedule tmpSchedule = new clsSchedule();
                    tmpSchedule.NurseID = sqlite_datareader["nurse_id"].ToString();
                    tmpSchedule.SiteID = sqlite_datareader["site_id"].ToString();
                    ls.Add(tmpSchedule);
                }
                listSchedule = ls;
                return 0;
            }
            catch
            {
                ls.Clear();
                listSchedule = ls;
                return -1;
            }
        }

        /// <summary>
        ///���@�z���s�����o�����C��
        /// </summary>
        /// <param name="siteID">siteID</param>
        /// <param name="listSchedule">listSchedule</param>
        public int getSscheduleListBySite(string siteID, out List<clsSchedule> listSchedule)
        {
            List<clsSchedule> ls = new List<clsSchedule>();
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM schedule WHERE site_id='" + siteID + "' ORDER BY site_id, nurse_id ASC;";
                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read()) //read data
                {
                    clsSchedule tmpSchedule = new clsSchedule();
                    tmpSchedule.NurseID = sqlite_datareader["nurse_id"].ToString();
                    tmpSchedule.SiteID = sqlite_datareader["site_id"].ToString();
                    ls.Add(tmpSchedule);
                }
                listSchedule = ls;
                return 0;
            }
            catch
            {
                ls.Clear();
                listSchedule = ls;
                return -1;
            }
        }

        /// <summary>
        ///�j�M�S�w�@�z��
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="searchString">searchString</param>
        /// <param name="listSite">listSite</param>
        public int searchSite(String column,String searchString, out List<clsSite> listSite)
        {
            List<clsSite> ls = new List<clsSite>();
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                if (column == "" || searchString == "")
                    sqlite_cmd.CommandText = "SELECT * FROM site ORDER BY id ASC;";
                else
                    sqlite_cmd.CommandText = "SELECT * FROM site WHERE " + column + " LIKE '%" + searchString + "%' ORDER BY id ASC;";
                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read()) //read data
                {
                    clsSite tmpSite = new clsSite();
                    tmpSite.ID = sqlite_datareader["id"].ToString();
                    tmpSite.Name = sqlite_datareader["name"].ToString();
                    tmpSite.Memo = sqlite_datareader["memo"].ToString();
                    ls.Add(tmpSite);
                }
                listSite = ls;
                return 0;
            }
            catch
            {
                ls.Clear();
                listSite = ls;
                return -1;
            }
        }

        /// <summary>
        ///�j�M�S�w�@�h
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="searchString">searchString</param>
        /// <param name="listSite">listSite</param>
        public int searchNurse(String column, String searchString, out List<clsNurse> listNurse)
        {
            List<clsNurse> ls = new List<clsNurse>();
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                if (column == "" || searchString == "")
                    sqlite_cmd.CommandText = "SELECT * FROM nurse ORDER BY id ASC;";
                else
                    sqlite_cmd.CommandText = "SELECT * FROM nurse WHERE " + column + " LIKE '%" + searchString + "%' ORDER BY id ASC;";
                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read()) //read data
                {
                    clsNurse tmpNurse = new clsNurse();
                    tmpNurse.ID = sqlite_datareader["id"].ToString();
                    tmpNurse.Name = sqlite_datareader["name"].ToString();
                    tmpNurse.Image = sqlite_datareader["path"].ToString();
                    ls.Add(tmpNurse);
                }
                listNurse = ls;
                return 0;
            }
            catch
            {
                ls.Clear();
                listNurse = ls;
                return -1;
            }
        }
    }
}
