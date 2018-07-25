using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace sqlQuery
{
    /// <summary>
    /// 刷新左树
    /// </summary>
    public delegate void DelegateRefreshTree(IList<string> ls);

    public class SqlConnUtil
    {
        public string DBHost { get; private set; }
        public string DBUser { get; private set; }
        public string DBPassword { get; private set; }
        public string CurDBName { get; set; }

        /// <summary>
        /// 主界面对象
        /// </summary>
        private FrmMain m_frmMain;

        /// <summary>
        /// 用来连接master数据库
        /// </summary>
        private NativeDBHelper m_nativeDBHelper;

        private DelegateRefreshTree fnRefreshTree;
        private Action fnClearTree;
        

        public SqlConnUtil(FrmMain frmMain)
        {
            m_frmMain = frmMain;
            NativeDBHelper.FnErrorPrompt = FrmMain.PromptError; //报错方式
        }

        public void SetConnectInfo(string dbHost, string dbUser, string dbPassword)
        {
            this.DBHost = dbHost;
            this.DBUser = dbUser;
            this.DBPassword = dbPassword;
        }

        /// <summary>
        /// 尝试连接
        /// </summary>
        /// <returns>是否成功</returns>
        public bool TryConnect()
        {
            if (string.IsNullOrEmpty(DBHost) || string.IsNullOrEmpty(DBUser))
            {
                return false;
            }

            m_nativeDBHelper = new NativeDBHelper(DBHost, DBUser, DBPassword);
            bool bConn = m_nativeDBHelper.IsConnected();
            if (bConn && (null!=fnRefreshTree))
            {
                //var databases = m_nativeDBHelper.GetAllDatabases();
                var databases = m_nativeDBHelper.GetAllDatabases2(); //test
                var userDBs = from x in databases
                    where !IsSysDatabase(x)
                    select x;

                fnRefreshTree(userDBs.ToList());
            }
            return bConn;
        }

        private static readonly string[] mSysDatabases = new[]
            {
                "master",
                "model",
                "msdb",
                "tempdb",
                "distribution"
            };
        private static bool IsSysDatabase(string sDBName)
        {
            return mSysDatabases.Contains(sDBName, StringComparer.InvariantCultureIgnoreCase);
        }

        public void DisConnect()
        {
            if (null != m_nativeDBHelper)
            {
                m_nativeDBHelper.Dispose();
                m_nativeDBHelper = null;
            }
            if (null != fnClearTree)
            {
                fnClearTree();
            }
        }

        public void SetRefreshTreeDelegate(DelegateRefreshTree refreshTree)
        {
            fnRefreshTree = refreshTree;
        }

        public void SetClearTreeDelegate(Action clearTree)
        {
            fnClearTree = clearTree;
        }
    }
}