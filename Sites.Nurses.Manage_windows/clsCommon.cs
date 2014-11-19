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
    public class clsSites
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
    /// <param name="PicturePath">照片路徑</param>
    public class clsNurse
    {
        private string strID;
        private string strName;
        private string strPicPath;

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
        public String PicturePath
        {
            get { return strPicPath; }  // Getter
            set { strPicPath = value; } // Setter
        }
    }

    /// <summary>
    /// SQL功能
    /// </summary>
    public class clsSQLFunction
    {
        SQLiteConnection sqlite_conn=new SQLiteConnection("Data source=sites.nurse.schedule.s3db");
        
        /// <summary>
        /// 開啟資料庫
        /// </summary>
        public string open()
        {
            try
            {                
                sqlite_conn.Open();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            
        }

        /// <summary>
        /// 關閉資料庫
        /// </summary>
        public string close()
        {
            try
            {
                sqlite_conn.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            } 
        }
    }
}
