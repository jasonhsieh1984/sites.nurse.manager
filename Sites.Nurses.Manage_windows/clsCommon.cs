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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        ///���o�@�h�C��
        /// </summary>
        /// <param name="listNurse">listNurse</param>
        public int getNurseList(out List<clsNurse> listNurse)
        {
            List<clsNurse> ls = new List<clsNurse>();
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM nurse;";
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
            catch (Exception ex)
            {
                listNurse = ls;
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return -1;
            }
        }

       /// <summary>
        ///���o�@�z���C��
        /// </summary>
        /// <param name="listSite">listSite</param>
        public int getSiteList(out List<clsSite> listSite)
        {
            List<clsSite> ls = new List<clsSite>();
            try
            {
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM site;";
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
            catch (Exception ex)
            {
                listSite = ls;
                return -1;
            }
        }
    }
}
