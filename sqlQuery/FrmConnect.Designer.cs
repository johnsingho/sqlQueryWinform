using System.CodeDom.Compiler;
using sqlQuery.Resources;

namespace sqlQuery
{
    public partial class FrmConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tboxHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tboxUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tboxHost);
            this.panel1.Controls.Add(this.lblHost);
            this.panel1.Location = new System.Drawing.Point(33, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 39);
            this.panel1.TabIndex = 0;
            // 
            // tboxHost
            // 
            this.tboxHost.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tboxHost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tboxHost.Location = new System.Drawing.Point(144, 8);
            this.tboxHost.MaxLength = 100;
            this.tboxHost.Name = "tboxHost";
            this.tboxHost.Size = new System.Drawing.Size(195, 21);
            this.tboxHost.TabIndex = 1;
            this.tboxHost.TextChanged += new System.EventHandler(this.OnTextChanged);
            this.tboxHost.Validating += new System.ComponentModel.CancelEventHandler(this.OnHostValidating);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(3, 11);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(113, 12);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Sql Server服务器：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tboxUser);
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Location = new System.Drawing.Point(34, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 39);
            this.panel2.TabIndex = 1;
            // 
            // tboxUser
            // 
            this.tboxUser.AutoCompleteCustomSource.AddRange(new string[] {
            "127.0.0.1"});
            this.tboxUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tboxUser.Location = new System.Drawing.Point(143, 8);
            this.tboxUser.MaxLength = 100;
            this.tboxUser.Name = "tboxUser";
            this.tboxUser.Size = new System.Drawing.Size(195, 21);
            this.tboxUser.TabIndex = 2;
            this.tboxUser.Validating += new System.ComponentModel.CancelEventHandler(this.OnUsernameValidating);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(3, 11);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(77, 12);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "登录用户名：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tboxPassword);
            this.panel3.Controls.Add(this.lblPassword);
            this.panel3.Location = new System.Drawing.Point(33, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(353, 39);
            this.panel3.TabIndex = 2;
            // 
            // tboxPassword
            // 
            this.tboxPassword.AutoCompleteCustomSource.AddRange(new string[] {
            "127.0.0.1"});
            this.tboxPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tboxPassword.CausesValidation = false;
            this.tboxPassword.Location = new System.Drawing.Point(144, 11);
            this.tboxPassword.MaxLength = 100;
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.PasswordChar = '*';
            this.tboxPassword.Size = new System.Drawing.Size(195, 21);
            this.tboxPassword.TabIndex = 3;
            this.tboxPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(3, 11);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 12);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "登录密码：";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnConn);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(53, 257);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(333, 34);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(3, 3);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 0;
            this.btnConn.Text = "连接";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(84, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(136, 19);
            this.panel4.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(226, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkSavePassword);
            this.panel5.Location = new System.Drawing.Point(33, 219);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(353, 32);
            this.panel5.TabIndex = 4;
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.AutoSize = true;
            this.chkSavePassword.Checked = true;
            this.chkSavePassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSavePassword.Location = new System.Drawing.Point(22, 9);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Size = new System.Drawing.Size(72, 16);
            this.chkSavePassword.TabIndex = 0;
            this.chkSavePassword.Text = global::sqlQuery.Resources.MyRes.TXT_CHK_SAVEPASSWORD;
            this.chkSavePassword.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::sqlQuery.Resources.MyRes.imgBannner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 75);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FrmConnect
            // 
            this.AcceptButton = this.btnConn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(413, 301);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::sqlQuery.Resources.MyRes.Icon1;
            this.MaximizeBox = false;
            this.Name = "FrmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "连接到";
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tboxHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tboxUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox chkSavePassword;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}