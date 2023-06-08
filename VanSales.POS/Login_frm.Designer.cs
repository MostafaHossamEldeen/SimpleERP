
namespace VanSales.POS
{
    partial class Login_frm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.txt_UserName = new DevExpress.XtraEditors.TextEdit();
            this.ckb_onlineconn = new DevExpress.XtraEditors.CheckEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_onlineconn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(440, 305);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(109, 24);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "إسم المستخدم:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(465, 376);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 24);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "كلمه المرور:";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(149, 374);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txt_Password.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txt_Password.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Password.Properties.Appearance.Options.UseFont = true;
            this.txt_Password.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_Password.Properties.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(239, 30);
            this.txt_Password.TabIndex = 2;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(149, 302);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txt_UserName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txt_UserName.Properties.Appearance.Options.UseBackColor = true;
            this.txt_UserName.Properties.Appearance.Options.UseFont = true;
            this.txt_UserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_UserName.Size = new System.Drawing.Size(239, 30);
            this.txt_UserName.TabIndex = 1;
            // 
            // ckb_onlineconn
            // 
            this.ckb_onlineconn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckb_onlineconn.EditValue = true;
            this.ckb_onlineconn.Location = new System.Drawing.Point(318, 445);
            this.ckb_onlineconn.Name = "ckb_onlineconn";
            this.ckb_onlineconn.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.ckb_onlineconn.Properties.Appearance.Options.UseFont = true;
            this.ckb_onlineconn.Properties.Caption = "إتصال مباشر";
            this.ckb_onlineconn.Size = new System.Drawing.Size(119, 28);
            this.ckb_onlineconn.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(216)))), ((int)(((byte)(151)))));
            this.btn_login.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.btn_login.Appearance.Options.UseBackColor = true;
            this.btn_login.Appearance.Options.UseFont = true;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Location = new System.Drawing.Point(243, 505);
            this.btn_login.Name = "btn_login";
            this.btn_login.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_login.Size = new System.Drawing.Size(253, 40);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "تسجيل دخول";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(288, 188);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(228, 48);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Circles POS";
            // 
            // Login_frm
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::VanSales.POS.Properties.Resources.login_pos;
            this.ClientSize = new System.Drawing.Size(1131, 723);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.ckb_onlineconn);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HtmlText = "تسجيل الدخول";
            this.IconOptions.Image = global::VanSales.POS.Properties.Resources.logo;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login_frm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_onlineconn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_UserName;
        private DevExpress.XtraEditors.CheckEdit ckb_onlineconn;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        public DevExpress.XtraEditors.TextEdit txt_Password;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}