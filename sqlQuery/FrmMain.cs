using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using sqlQuery.Resources;

namespace sqlQuery
{
    internal delegate void DelegateNotifyInfo(string strTip, bool bInfo);

    public partial class FrmMain : Form
    {
        private bool m_bIsConnected;
        private SqlConnUtil m_connector;
        private static DelegateNotifyInfo fnNotifyInfo = null;
        private FrmConnect frmConn;

        #region LeftTree
        System.Windows.Forms.TreeNode rootNode = new System.Windows.Forms.TreeNode(MyRes.TXT_TREE_ROOT);
        //private SqlConnUtil m_connector;
        //private Action<string, DataTable> fnShowData;

        private const int IMG_IND_DB = 1;
        private const int IMG_IND_TAB = 2;
        private const int IMG_IND_COL = 3;
        private const int IMG_IND_CUR = 4;

        private const string STR_QUERYING = "Querying...";

        #endregion

        #region RightQueryWin
        //卡号列
        private const string msRegCardNum = @"\s*card_num\s*";
        private Regex mRegCardNum = new Regex(msRegCardNum, RegexOptions.IgnoreCase);
        #endregion

        public FrmMain()
        {
            InitializeComponent();

            this.Icon = MyRes.Icon1;
            this.notifyIcon1.Icon = MyRes.Icon1;
            this.notifyIcon1.Text = MyRes.TXT_APP;
            this.notifyIcon1.Visible = true;
            fnNotifyInfo = this.NotifyInfo;

            LeftTree_Init();
            
            m_connector = new SqlConnUtil(this);
            m_connector.SetRefreshTreeDelegate(LeftTree_Refresh);
            m_connector.SetClearTreeDelegate(LeftTree_Clear);

            //frmLeft.SetShowDataDelegate(frmQueryRes.ShowData);
            
            //MakeConn();
        }

        #region LeftTree
        private void LeftTree_Init()
        {
            rootNode.Name = "treeRoot";
            rootNode.Text = MyRes.TXT_TREE_ROOT;
            rootNode.ImageIndex = 0;
            this.treeObj.Nodes.Add(rootNode);
        }

        public void LeftTree_Refresh(IList<string> ls)
        {
            LeftTree_Clear();

            foreach (var db in ls)
            {
                var nodeDB = rootNode.Nodes.Add(db);
                nodeDB.ImageIndex = IMG_IND_DB;
                nodeDB.SelectedImageIndex = IMG_IND_CUR;
                var nodeTab = nodeDB.Nodes.Add(MyRes.TXT_ALL_TABLE);
                nodeTab.ImageIndex = IMG_IND_TAB;
                nodeTab.SelectedImageIndex = IMG_IND_CUR;
                nodeTab.Nodes.Add(STR_QUERYING);
            }
            rootNode.Expand();
        }

        public void LeftTree_Clear()
        {
            rootNode.Nodes.Clear();
        }

        private void LeftTree_OnAfterExpand(object sender, TreeViewEventArgs e)
        {
            //根据名字来处理节点单击
            var clkNode = e.Node;
            if (0 == string.CompareOrdinal(clkNode.Text, MyRes.TXT_ALL_TABLE))
            {
                LeftTree_FillNodeTables(clkNode);
            }
            if (0 == string.CompareOrdinal(clkNode.Text, MyRes.TXT_ALL_COL))
            {
                LeftTree_FillNodeCols(clkNode);
            }
        }

        private void LeftTree_FillNodeTables(TreeNode clkNode)
        {
            Cursor.Current = System.Windows.Forms.Cursors.AppStarting;
            clkNode.Nodes.Clear();
            var dbNode = clkNode.Parent;
            var sDBName = dbNode.Text;
            m_connector.CurDBName = sDBName;
            using (
                var dbConn = new NativeDBHelper(m_connector.DBHost, m_connector.DBUser, m_connector.DBPassword, sDBName)
                )
            {
                var lsTabs = dbConn.GetTables();
                foreach (var sTab in lsTabs)
                {
                    var nodeTab = clkNode.Nodes.Add(sTab);
                    nodeTab.ImageIndex = IMG_IND_TAB;
                    nodeTab.SelectedImageIndex = IMG_IND_CUR;

                    var nodeCol = nodeTab.Nodes.Add(MyRes.TXT_ALL_COL);
                    nodeCol.ImageIndex = IMG_IND_COL;
                    nodeCol.SelectedImageIndex = IMG_IND_CUR;

                    nodeCol.Nodes.Add(STR_QUERYING); //
                }
            }
            clkNode.Expand();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// 取表的所有列信息
        /// </summary>
        /// <param name="clkNode"></param>
        private void LeftTree_FillNodeCols(TreeNode clkNode)
        {
            Cursor.Current = System.Windows.Forms.Cursors.AppStarting;
            clkNode.Nodes.Clear();
            var dbNode = clkNode.Parent;
            var sTabName = dbNode.Text;
            var sDBName = LeftTree_GetDBNameFromPath(clkNode.FullPath);
            m_connector.CurDBName = sDBName;
            using (
                var dbConn = new NativeDBHelper(m_connector.DBHost, m_connector.DBUser, m_connector.DBPassword, sDBName)
                )
            {
                //var lsCols = dbConn.GetColumnsEx(sTabName);
                var lsCols = dbConn.GetColumns(sTabName);
                StringBuilder sb = new StringBuilder(100);
                foreach (var sCol in lsCols)
                {
                    sb.AppendFormat("{0},{1},{2}", sCol.Item1.ToString(), sCol.Item2.ToString(), sCol.Item3.ToUpper());
                    var nodeTab = clkNode.Nodes.Add(sb.ToString());
                    nodeTab.ImageIndex = IMG_IND_COL;
                    nodeTab.SelectedImageIndex = IMG_IND_CUR;
                    sb.Clear();
                }
            }
            clkNode.Expand();
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// 树列表右键处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftTree_OnNodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView tv = sender as TreeView;
                Point pt = new Point(e.X, e.Y);
                var curNode = tv.GetNodeAt(pt);
                var nodeParent = (null == curNode) ? null : curNode.Parent;
                tv.SelectedNode = curNode;
                if (null != nodeParent)
                {
                    if (0 == string.CompareOrdinal(nodeParent.Text, MyRes.TXT_ALL_TABLE))
                    {
                        ctxMenuQuery.Visible = true;
                    }
                }
                else
                {
                    ctxMenuQuery.Visible = false;
                }
                contextMenuTree.Show(tv, pt);
            }
        }


        /// <summary>
        /// 从树结点路径提取数据库名
        /// </summary>
        /// <param name="fullPath">树结点路径</param>
        /// <returns></returns>
        /// <example>数据库\P2014001\所有表\tab_BaseInfo_PostCode_Config</example>
        /// <example>return: P2014001</example>
        private string LeftTree_GetDBNameFromPath(string fullPath)
        {
            String sRet = string.Empty;
            const char SPLIT = '\\';
            int iBegin = -1;
            int iEnd = -1;
            iBegin = fullPath.IndexOf(SPLIT);
            if (iBegin < 0)
            {
                return sRet;
            }
            iEnd = fullPath.IndexOf(SPLIT, iBegin + 1);
            if (iEnd < 0)
            {
                return sRet;
            }
            return fullPath.Substring(iBegin + 1, iEnd - iBegin - 1);
        }


        private Tuple<string, DataTable> LeftTree_QueryDataByNode(int nLimit = -1)
        {
            var curNode = this.treeObj.SelectedNode;
            var sDBName = LeftTree_GetDBNameFromPath(curNode.FullPath);
            Tuple<string, DataTable> retQuery = new Tuple<string, DataTable>(null, null);
            m_connector.CurDBName = sDBName;
            var sTabName = curNode.Text;
            using (
                var dbConn = new NativeDBHelper(m_connector.DBHost, m_connector.DBUser, m_connector.DBPassword, sDBName)
                )
            {
                StringBuilder sb = new StringBuilder();
                if (nLimit < 0)
                {
                    sb.AppendFormat("select * from {0}", sTabName);
                }
                else
                {
                    sb.AppendFormat("select top {0} * from {1}", nLimit, sTabName);
                }
                var sSql = sb.ToString();
                var dt = dbConn.Execute(sb.ToString());
                retQuery = new Tuple<string, DataTable>(sSql, dt);
                return retQuery;
                //return (nLimit < 0) ? dbConn.GetDataFromTable(sTabName) : dbConn.GetDataFromTableTopN(sTabName, 100);
            }
        }

        private void ctxMenuQueryTop100_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.AppStarting;
            var rQuery = LeftTree_QueryDataByNode(100);
            ShowData(rQuery.Item1, rQuery.Item2);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void ctxMenuQueryAll_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.AppStarting;
            var rQuery = LeftTree_QueryDataByNode(-1);
            ShowData(rQuery.Item1, rQuery.Item2);
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        private void ctxMenuCopyName_Click(object sender, EventArgs e)
        {
            var curNode = this.treeObj.SelectedNode;
            Clipboard.SetText(curNode.Text);
        }
        #endregion


        #region 右边的查询窗口

        public void ShowData(string sSql, DataTable dt)
        {
            if (null != sSql)
            {
                this.tboxSql.Text = sSql;
            }
            try
            {
                this.dgView.DataSource = dt;
            }
            catch (Exception e)
            {
                FrmMain.PromptError(e.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strSql = this.tboxSql.Text.Trim();
            if (string.IsNullOrEmpty(strSql))
            {
                return;
            }
            if (!CheckValid(strSql))
            {
                FrmMain.PromptError(MyRes.Err_QueryInvalid);
                return;
            }

            Cursor.Current = System.Windows.Forms.Cursors.AppStarting;
            using (
                var dbConn = new NativeDBHelper(m_connector.DBHost, m_connector.DBUser, m_connector.DBPassword,
                    m_connector.CurDBName)
                )
            {
                var dt = dbConn.Execute(strSql);
                ShowData(null, dt);
            }

            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }

        /// <summary>
        /// 简单安全性检查
        /// </summary>
        private static readonly string[] mInvalidSqls = new[]
        {
            "insert",
            "update",
            "delete",
            "truncate",
            "grant",
            "call"
        };
        private bool CheckValid(string strSql)
        {
            var sBadReg = string.Join(@"|", mInvalidSqls);
            sBadReg = String.Format(@"[^a-zA-Z_]?({0})\s+", sBadReg);
            var reg = new Regex(sBadReg, RegexOptions.IgnoreCase);
            if (reg.IsMatch(strSql))
            {
                return false;
            }
            reg = new Regex(@"^\s*select\s+", RegexOptions.IgnoreCase);
            if (!reg.IsMatch(strSql))
            {
                return false;
            }
            return true;
        }

        //public void SetDBConnector(SqlConnUtil mConntor)
        //{
        //    m_connector = mConntor;
        //}

        private void OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //FrmMain.PromptError(e.Exception.Message);
            if (e.Context == DataGridViewDataErrorContexts.Commit)
                Debug.Print("Commit error: {0}", e.ToString());
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
                Debug.Print("Cell change: {0}", e.ToString());
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
                Debug.Print("parsing error: {0}", e.ToString());
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
                Debug.Print("leave control error: {0}", e.ToString());
            if (e.Exception is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";
                e.ThrowException = false;
                FrmMain.PromptError("约束有问题");
            }
        }


        private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (mRegCardNum.IsMatch(dgView.Columns[e.ColumnIndex].Name))
            {
                //chage to base64 string
                string sCardNum = e.Value as string;
                sCardNum = MyCrypt.Encode(sCardNum, 0x21); //简单加一加密码
                byte[] bytes = Encoding.ASCII.GetBytes(sCardNum ?? string.Empty);
                string sBase64 = Convert.ToBase64String(bytes);
                e.Value = sBase64;
            }
        }
        #endregion


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnDisConn(object sender, EventArgs e)
        {
            m_connector.DisConnect();
            m_bIsConnected = false;
            SwitchMenu();
            ShowData("",null);
        }

        private void OnConn(object sender, EventArgs e)
        {
            MakeConn();
        }
        
        private void MakeConn()
        {
            if (!m_bIsConnected)
            {
                frmConn = FrmConnect.GetInstance();
                //frmConn.Parent = this;
                if (DialogResult.OK == frmConn.ShowDialog(this))
                {
                    m_connector.SetConnectInfo(frmConn.DBHost, frmConn.DBUser, frmConn.DBPassword);
                    m_bIsConnected = m_connector.TryConnect();
                    SwitchMenu();
                }
            }
        }

        private void SwitchMenu()
        {
            connMenu.Enabled = !m_bIsConnected;
            disConnMenu.Enabled = m_bIsConnected;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //RePosChild();
            MakeConn();
        }


        public void NotifyInfo(string strTip, bool bInfo)
        {
            if (bInfo)
            {
                this.notifyIcon1.ShowBalloonTip(600, "Info", strTip, ToolTipIcon.Info);
            }
            else
            {
                this.notifyIcon1.ShowBalloonTip(600, "出错", strTip, ToolTipIcon.Error);
            }
            
        }

        public static void PromptError(string sErr)
        {
            if (null != fnNotifyInfo)
            {
                fnNotifyInfo(sErr, false);
            }
        }
    }
}
