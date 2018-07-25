using sqlQuery.Resources;

namespace sqlQuery
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.meConn = new System.Windows.Forms.ToolStripMenuItem();
            this.connMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.disConnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeObj = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tboxSql = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.contextMenuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxMenuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuQueryTop100 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuQueryAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuCopyName = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.contextMenuTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meConn});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(742, 25);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // meConn
            // 
            this.meConn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connMenu,
            this.disConnMenu,
            this.exitMenu});
            this.meConn.Name = "meConn";
            this.meConn.Size = new System.Drawing.Size(44, 21);
            this.meConn.Text = "连接";
            // 
            // connMenu
            // 
            this.connMenu.Name = "connMenu";
            this.connMenu.Size = new System.Drawing.Size(133, 22);
            this.connMenu.Text = "建立连接...";
            this.connMenu.Click += new System.EventHandler(this.OnConn);
            // 
            // disConnMenu
            // 
            this.disConnMenu.Enabled = false;
            this.disConnMenu.Name = "disConnMenu";
            this.disConnMenu.Size = new System.Drawing.Size(133, 22);
            this.disConnMenu.Text = "断开连接";
            this.disConnMenu.Click += new System.EventHandler(this.OnDisConn);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(133, 22);
            this.exitMenu.Text = "退出(&X)";
            this.exitMenu.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Text = "my Sql query";
            this.notifyIcon1.Visible = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer1.Panel1.Controls.Add(this.treeObj);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(742, 563);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeObj
            // 
            this.treeObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeObj.FullRowSelect = true;
            this.treeObj.HideSelection = false;
            this.treeObj.ImageIndex = 0;
            this.treeObj.ImageList = this.imgList;
            this.treeObj.Location = new System.Drawing.Point(0, 0);
            this.treeObj.Name = "treeObj";
            this.treeObj.SelectedImageIndex = 0;
            this.treeObj.ShowRootLines = false;
            this.treeObj.Size = new System.Drawing.Size(186, 563);
            this.treeObj.TabIndex = 5;
            this.treeObj.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.LeftTree_OnAfterExpand);
            this.treeObj.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LeftTree_OnNodeClick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "icon_folder.ico");
            this.imgList.Images.SetKeyName(1, "icon_db.ico");
            this.imgList.Images.SetKeyName(2, "icon_tab.ico");
            this.imgList.Images.SetKeyName(3, "icon_col.ico");
            this.imgList.Images.SetKeyName(4, "icon_cur.ico");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgView);
            this.splitContainer2.Size = new System.Drawing.Size(552, 563);
            this.splitContainer2.SplitterDistance = 169;
            this.splitContainer2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tboxSql, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 169);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tboxSql
            // 
            this.tboxSql.AcceptsReturn = true;
            this.tboxSql.AcceptsTab = true;
            this.tboxSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tboxSql.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxSql.Location = new System.Drawing.Point(3, 3);
            this.tboxSql.Multiline = true;
            this.tboxSql.Name = "tboxSql";
            this.tboxSql.Size = new System.Drawing.Size(546, 123);
            this.tboxSql.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 132);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 34);
            this.panel1.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Location = new System.Drawing.Point(453, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(69, 27);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = global::sqlQuery.Resources.MyRes.TXT_QUERY;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToOrderColumns = true;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(0, 0);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowTemplate.Height = 23;
            this.dgView.Size = new System.Drawing.Size(552, 390);
            this.dgView.TabIndex = 0;
            this.dgView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OnCellFormatting);
            this.dgView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnDataError);
            // 
            // contextMenuTree
            // 
            this.contextMenuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuQuery,
            this.ctxMenuCopyName});
            this.contextMenuTree.Name = "contextMenuTree";
            this.contextMenuTree.Size = new System.Drawing.Size(153, 70);
            // 
            // ctxMenuQuery
            // 
            this.ctxMenuQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuQueryTop100,
            this.ctxMenuQueryAll});
            this.ctxMenuQuery.Name = "ctxMenuQuery";
            this.ctxMenuQuery.Size = new System.Drawing.Size(152, 22);
            this.ctxMenuQuery.Text = "查询";
            // 
            // ctxMenuQueryTop100
            // 
            this.ctxMenuQueryTop100.Name = "ctxMenuQueryTop100";
            this.ctxMenuQueryTop100.Size = new System.Drawing.Size(169, 22);
            this.ctxMenuQueryTop100.Text = "查询前100条记录";
            this.ctxMenuQueryTop100.Click += new System.EventHandler(this.ctxMenuQueryTop100_Click);
            // 
            // ctxMenuQueryAll
            // 
            this.ctxMenuQueryAll.Name = "ctxMenuQueryAll";
            this.ctxMenuQueryAll.Size = new System.Drawing.Size(169, 22);
            this.ctxMenuQueryAll.Text = "查询所有记录";
            this.ctxMenuQueryAll.Click += new System.EventHandler(this.ctxMenuQueryAll_Click);
            // 
            // ctxMenuCopyName
            // 
            this.ctxMenuCopyName.Name = "ctxMenuCopyName";
            this.ctxMenuCopyName.Size = new System.Drawing.Size(152, 22);
            this.ctxMenuCopyName.Text = "拷贝文字";
            this.ctxMenuCopyName.Click += new System.EventHandler(this.ctxMenuCopyName_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 588);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = MyRes.TXT_APP_TITLE;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoad);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.contextMenuTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem meConn;
        private System.Windows.Forms.ToolStripMenuItem connMenu;
        private System.Windows.Forms.ToolStripMenuItem disConnMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;

        private System.Windows.Forms.ContextMenuStrip contextMenuTree;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuQuery;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuQueryTop100;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuQueryAll;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuCopyName;

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeObj;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tboxSql;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.ImageList imgList;
    }
}

