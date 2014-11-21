using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Sites.Nurses.Manage_windows
{
    /// <summary>
    /// 站點資料
    /// </summary>
    /// <param name="ID">ID</param>
    /// <param name="Name">名稱</param>
    /// <param name="Memo">備註</param>
    public class clsSite
    {
        private string strID;
        private string strName;
        private string strMemo;

        /// <summary>
        /// 編號
        /// </summary>
        public String ID
        {
            get { return strID; }  // Getter
            set { strID = value; } // Setter
        }

        /// <summary>
        /// 名稱
        /// </summary>
        public String Name
        {
            get { return strName; }  // Getter
            set { strName = value; } // Setter
        }

        /// <summary>
        /// 備註
        /// </summary>
        public String Memo
        {
            get { return strMemo; }  // Getter
            set { strMemo = value; } // Setter
        }
    }

    /// <summary>
    /// 護士資料
    /// </summary>
    /// <param name="ID">ID</param>
    /// <param name="Name">名稱</param>
    /// <param name="Image">照片檔名</param>
    public class clsNurse
    {
        private string strID;
        private string strName;
        private string strImage;

        /// <summary>
        /// 編號
        /// </summary>
        public String ID
        {
            get { return strID; }  // Getter
            set { strID = value; } // Setter
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name
        {
            get { return strName; }  // Getter
            set { strName = value; } // Setter
        }

        /// <summary>
        /// 照片路徑
        /// </summary>
        public String Image
        {
            get { return strImage; }  // Getter
            set { strImage = value; } // Setter
        }
    }

    /// <summary>
    /// SQL功能
    /// </summary>
    public class clsSQLFunction
    {
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data source=sites.nurse.schedule.s3db");

        /// <summary>
        /// 開啟資料庫
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
        /// 關閉資料庫
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
        /// 新增一筆護士資料
        /// </summary>
        /// <param name="data">護士資料</param>
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
        /// 更新一筆護士資料
        /// </summary>
        /// <param name="data">護士資料</param>
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
        /// 刪除一筆護士資料
        /// </summary>
        /// <param name="id">護士ID</param>
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
        ///取得護士列表
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
        /// 新增一筆護理站資料
        /// </summary>
        /// <param name="data">護理站資料</param>
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
        /// 更新一筆護理站資料
        /// </summary>
        /// <param name="data">護理站資料</param>
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
        /// 刪除一筆護理站資料
        /// </summary>
        /// <param name="id">護理站ID</param>
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
        ///取得護理站列表
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
