using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using sqlQuery.Resources;
using Configuration = System.Configuration.Configuration;

namespace sqlQuery
{
    internal struct TConnHis
    {
        public string sHost;
        public string sUser;
        public string sPassword;
    }

    public partial class FrmConnect : Form
    {
        public string DBHost { get; private set; }
        public string DBUser { get; private set; }
        public string DBPassword { get; private set; }

        private IDictionary<string, TConnHis> mConnHises;

        public FrmConnect()
        {
            InitializeComponent();
            InitHostComplete();

//for test only    
//#if DEBUG
//            tboxHost.Text = "10.165.1.231";
//            tboxUser.Text = "sa";
//            tboxPassword.Text = "super.123";
//#endif  
        }

        private void InitHostComplete()
        {
            //this.tboxHost.AutoCompleteCustomSource.AddRange(new string[] {"127.0.0.1"});
            AutoCompleteStringCollection dataColl = new AutoCompleteStringCollection();
            
            bool bSaveLast = LoadRecentHistory();
            foreach (var his in mConnHises)
            {
                dataColl.Add(his.Value.sHost);
            }

            chkSavePassword.Checked = bSaveLast;
            tboxHost.AutoCompleteCustomSource = dataColl;
        }

        
        private static FrmConnect m_sIns;
        public static FrmConnect GetInstance()
        {
            if (m_sIns == null)
                m_sIns = new FrmConnect();
            return m_sIns;
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            //validate 
            // the controls collection can be the whole form or just a panel or group
            if (Validation.hasValidationErrors(this.Controls))
                return;
            DBHost = this.tboxHost.Text.Trim();
            DBUser = this.tboxUser.Text.Trim();
            DBPassword = this.tboxPassword.Text;

            this.DialogResult = DialogResult.OK;
            SaveRecentHistory();
            this.Close();
        }

        /// <summary>
        /// 加载最近保存的登录信息
        /// </summary>
        /// <returns>上次是否保存密码</returns>
        private bool LoadRecentHistory()
        {
            mConnHises = new Dictionary<string, TConnHis>();
            //object oMyConfig = ConfigurationSettings.GetConfig("Historys"); //same as next
            HistoryConfSection historys = (HistoryConfSection)System.Configuration.ConfigurationManager.GetSection("Historys");
            bool bSavePassword = historys.SaveInfo;
            foreach (HistoryElement his in historys.Historys)
            {
                try
                {
                    var sHost = his.Host.Trim();
                    mConnHises.Add(sHost, new TConnHis { sHost = sHost, sUser = his.User, sPassword = his.Password });
                }
                catch (ArgumentException ex)
                {
                }
            }
            return bSavePassword;
        }

        private void SaveRecentHistory()
        {
            bool bSaveInfo = chkSavePassword.Checked;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            HistoryConfSection historys = (HistoryConfSection)config.GetSection("Historys");
            historys.SaveInfo = bSaveInfo;
            historys.Historys.Clear();
            
            if (bSaveInfo)
            {
                try
                {
                    var sHost = tboxHost.Text.Trim();
                    var sUser = tboxUser.Text.Trim();
                    var sPassword = tboxPassword.Text;
                    var newHis = new TConnHis {sHost = sHost, sUser = sUser, sPassword = sPassword};
                    if (mConnHises.ContainsKey(sHost))
                    {
                        mConnHises[sHost]=newHis;
                    }
                    else
                    {
                        mConnHises.Add(sHost, newHis);
                    }
                }
                catch (ArgumentException ex)
                {
                }

                //System.Configuration.ConfigurationManager;
                //save history
                int i = 0;
                foreach(var item in mConnHises)
                {
                    var his = new HistoryElement();
                    his.Host = item.Value.sHost;
                    his.User = item.Value.sUser;
                    his.Password = item.Value.sPassword;
                    historys.Historys[i++] = his;
                }
                Debug.Print("write rec:{0}", i);
                try
                {
                    config.Save(ConfigurationSaveMode.Modified);
                }
                //catch (System.Configuration.ConfigurationErrorsException ex)
                //{
                //    FrmMain.PromptError(ex.Message);
                //}
                catch (Exception ex)
                {
                    FrmMain.PromptError(MyRes.Err_WritePriv);
                }
            }
            else if (mConnHises.Count>0)
            {
                //清空列表
                mConnHises.Clear(); 
                tboxHost.AutoCompleteCustomSource = null;
                try
                {
                    config.Save(ConfigurationSaveMode.Modified);
                }
                catch (Exception ex)
                {
                    FrmMain.PromptError(MyRes.Err_WritePriv);
                }
            }
        }

        private void OnHostValidating(object sender, CancelEventArgs e)
        {
            if (this.tboxHost.Text.Trim().Length <= 0)
            {
                errorProvider1.SetError(tboxHost, MyRes.Err_DBHost);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tboxHost, "");
            }
        }

        private void OnUsernameValidating(object sender, CancelEventArgs e)
        {
            if (this.tboxUser.Text.Trim().Length <= 0)
            {
                errorProvider1.SetError(tboxUser, MyRes.Err_Username);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tboxUser, "");
            }
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            var sHost = tboxHost.Text.Trim();
            if (mConnHises.ContainsKey(sHost))
            {
                var tHis = mConnHises[sHost];
                tboxUser.Text = tHis.sUser;
                tboxPassword.Text = tHis.sPassword;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (!chkSavePassword.Checked)
            {
                tboxHost.Text = "";
                tboxUser.Text = "";
                tboxPassword.Text = "";    
            }
        }
    }
}