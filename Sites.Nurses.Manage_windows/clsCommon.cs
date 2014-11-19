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
    public class clsSites
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
    /// <param name="PicturePath">�Ӥ����|</param>
    public class clsNurse
    {
        private string strID;
        private string strName;
        private string strPicPath;

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
        public String PicturePath
        {
            get { return strPicPath; }  // Getter
            set { strPicPath = value; } // Setter
        }
    }

    /// <summary>
    /// SQL�\��
    /// </summary>
    public class clsSQLFunction
    {
        SQLiteConnection sqlite_conn=new SQLiteConnection("Data source=sites.nurse.schedule.s3db");
        
        /// <summary>
        /// �}�Ҹ�Ʈw
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
        /// ������Ʈw
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
