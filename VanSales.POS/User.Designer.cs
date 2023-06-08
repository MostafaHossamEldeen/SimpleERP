
using System;
using System.Drawing;

namespace VanSales.POS
{
    partial class User
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_respass = new DevExpress.XtraEditors.SimpleButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_notmatched = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_discper = new DevExpress.XtraEditors.SpinEdit();
            this.ts_rwinv = new DevExpress.XtraEditors.ToggleSwitch();
            this.ts_utype = new DevExpress.XtraEditors.ToggleSwitch();
            this.ts_acreadit = new DevExpress.XtraEditors.ToggleSwitch();
            this.ts_adisc = new DevExpress.XtraEditors.ToggleSwitch();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_smanid = new DevExpress.XtraEditors.LookUpEdit();
            this.txt_password = new DevExpress.XtraEditors.TextEdit();
            this.txt_newpassword = new DevExpress.XtraEditors.TextEdit();
            this.cmb_username = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_home = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_discper.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_rwinv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_utype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_acreadit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_adisc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_smanid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_newpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_username.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1339, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "كلمة المرور الحالية:\r\nCurrent Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(662, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "المندوب:\r\nSalesMan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(570, 524);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 48);
            this.label6.TabIndex = 0;
            this.label6.Text = "نسبة الخصم:\r\nDiscount Percentage";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(1385, 655);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 48);
            this.label7.TabIndex = 0;
            this.label7.Text = "البيع آجل:\r\nAllow Credit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(546, 655);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 48);
            this.label5.TabIndex = 0;
            this.label5.Text = "إرجاع بدون فاتورة:\r\nReturn Without Invoice";
            // 
            // btn_respass
            // 
            this.btn_respass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_respass.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_respass.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_respass.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.btn_respass.Appearance.Options.UseBackColor = true;
            this.btn_respass.Appearance.Options.UseFont = true;
            this.btn_respass.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_respass.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_respass.AppearanceHovered.Options.UseBackColor = true;
            this.btn_respass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_respass.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_respass.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.btn_respass;
            this.btn_respass.Location = new System.Drawing.Point(652, 18);
            this.btn_respass.Name = "btn_respass";
            this.btn_respass.Size = new System.Drawing.Size(200, 68);
            this.btn_respass.TabIndex = 11;
            this.btn_respass.Text = "تغيير كلمة المرور\r\nChange Password ";
            this.btn_respass.ToolTip = "Change Password";
            this.btn_respass.Click += new System.EventHandler(this.btn_respass_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(599, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 48);
            this.label8.TabIndex = 0;
            this.label8.Text = "كلمة المرور الجديدة:\r\nNew Password";
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_save.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_save.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_save.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Appearance.Options.UseBackColor = true;
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_save.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_save.AppearanceHovered.Options.UseBackColor = true;
            this.btn_save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_save.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_save.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.btn_save;
            this.btn_save.Location = new System.Drawing.Point(858, 18);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(200, 68);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "حفظ End\r\nSave ";
            this.btn_save.ToolTip = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(1385, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 48);
            this.label9.TabIndex = 0;
            this.label9.Text = "نوع المستخدم:\r\nUser Type";
            // 
            // lbl_notmatched
            // 
            this.lbl_notmatched.Location = new System.Drawing.Point(0, 0);
            this.lbl_notmatched.Name = "lbl_notmatched";
            this.lbl_notmatched.Size = new System.Drawing.Size(0, 13);
            this.lbl_notmatched.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1380, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "إسم المستخدم:\r\nUsername";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.16854F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.73783F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.07491F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.20599F));
            this.tableLayoutPanel1.Controls.Add(this.txt_discper, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.ts_rwinv, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ts_utype, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.ts_acreadit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ts_adisc, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmb_smanid, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_password, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_newpassword, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmb_username, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1502, 918);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // txt_discper
            // 
            this.txt_discper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_discper.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_discper.Location = new System.Drawing.Point(3, 527);
            this.txt_discper.Name = "txt_discper";
            this.txt_discper.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txt_discper.Properties.Appearance.Options.UseFont = true;
            this.txt_discper.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_discper.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txt_discper.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_discper.Size = new System.Drawing.Size(523, 26);
            this.txt_discper.TabIndex = 7;
            // 
            // ts_rwinv
            // 
            this.ts_rwinv.Location = new System.Drawing.Point(388, 658);
            this.ts_rwinv.Name = "ts_rwinv";
            this.ts_rwinv.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.ts_rwinv.Properties.Appearance.Options.UseFont = true;
            this.ts_rwinv.Properties.OffText = "غير مسموح";
            this.ts_rwinv.Properties.OnText = "مسموح";
            this.ts_rwinv.Size = new System.Drawing.Size(138, 24);
            this.ts_rwinv.TabIndex = 9;
            // 
            // ts_utype
            // 
            this.ts_utype.Location = new System.Drawing.Point(1127, 396);
            this.ts_utype.Name = "ts_utype";
            this.ts_utype.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.ts_utype.Properties.Appearance.Options.UseFont = true;
            this.ts_utype.Properties.OffText = "موظف";
            this.ts_utype.Properties.OnText = "مدير";
            this.ts_utype.Size = new System.Drawing.Size(145, 24);
            this.ts_utype.TabIndex = 4;
            // 
            // ts_acreadit
            // 
            this.ts_acreadit.Location = new System.Drawing.Point(1131, 658);
            this.ts_acreadit.Name = "ts_acreadit";
            this.ts_acreadit.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.ts_acreadit.Properties.Appearance.Options.UseFont = true;
            this.ts_acreadit.Properties.OffText = "غير مسموح";
            this.ts_acreadit.Properties.OnText = "مسموح";
            this.ts_acreadit.Size = new System.Drawing.Size(141, 24);
            this.ts_acreadit.TabIndex = 8;
            // 
            // ts_adisc
            // 
            this.ts_adisc.Location = new System.Drawing.Point(1135, 527);
            this.ts_adisc.Name = "ts_adisc";
            this.ts_adisc.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.ts_adisc.Properties.Appearance.Options.UseFont = true;
            this.ts_adisc.Properties.OffText = "غير مسموح";
            this.ts_adisc.Properties.OnText = "مسموح";
            this.ts_adisc.Size = new System.Drawing.Size(137, 24);
            this.ts_adisc.TabIndex = 6;
            this.ts_adisc.EditValueChanged += new System.EventHandler(this.ts_adisc_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(1362, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 48);
            this.label4.TabIndex = 0;
            this.label4.Text = "السماح بالخصم:\r\nAllow Discount";
            // 
            // cmb_smanid
            // 
            this.cmb_smanid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_smanid.Location = new System.Drawing.Point(3, 396);
            this.cmb_smanid.Name = "cmb_smanid";
            this.cmb_smanid.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_smanid.Properties.Appearance.Options.UseFont = true;
            this.cmb_smanid.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_smanid.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_smanid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_smanid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("smanname", "Name4", 19, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmb_smanid.Properties.DropDownRows = 3;
            this.cmb_smanid.Properties.NullText = "";
            this.cmb_smanid.Properties.ShowHeader = false;
            this.cmb_smanid.Size = new System.Drawing.Size(523, 26);
            this.cmb_smanid.TabIndex = 5;
            // 
            // txt_password
            // 
            this.txt_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_password.Location = new System.Drawing.Point(758, 265);
            this.txt_password.Name = "txt_password";
            this.txt_password.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txt_password.Properties.Appearance.Options.UseFont = true;
            this.txt_password.Properties.UseSystemPasswordChar = true;
            this.txt_password.Size = new System.Drawing.Size(514, 26);
            this.txt_password.TabIndex = 2;
            // 
            // txt_newpassword
            // 
            this.txt_newpassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_newpassword.Location = new System.Drawing.Point(3, 265);
            this.txt_newpassword.Name = "txt_newpassword";
            this.txt_newpassword.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txt_newpassword.Properties.Appearance.Options.UseFont = true;
            this.txt_newpassword.Properties.UseSystemPasswordChar = true;
            this.txt_newpassword.Size = new System.Drawing.Size(523, 26);
            this.txt_newpassword.TabIndex = 3;
            // 
            // cmb_username
            // 
            this.cmb_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_username.Location = new System.Drawing.Point(758, 134);
            this.cmb_username.Name = "cmb_username";
            this.cmb_username.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cmb_username.Properties.Appearance.Options.UseFont = true;
            this.cmb_username.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cmb_username.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_username.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_username.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("username", "Name1", 19, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmb_username.Properties.DropDownRows = 3;
            this.cmb_username.Properties.Name = "cmb_username";
            this.cmb_username.Properties.NullText = "";
            this.cmb_username.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cmb_username.Properties.ShowHeader = false;
            this.cmb_username.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmb_username.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_username.Size = new System.Drawing.Size(514, 30);
            this.cmb_username.TabIndex = 1;
            this.cmb_username.EditValueChanged += new System.EventHandler(this.cmb_username_EditValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.labelControl10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1496, 100);
            this.panel1.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(184)))), ((int)(((byte)(107)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(708, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 41);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Users";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(184)))), ((int)(((byte)(107)))));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(678, 9);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(147, 41);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "المستخدمين";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.btn_save);
            this.panel2.Controls.Add(this.btn_respass);
            this.panel2.Controls.Add(this.btn_home);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 815);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1496, 100);
            this.panel2.TabIndex = 15;
            // 
            // btn_home
            // 
            this.btn_home.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_home.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_home.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_home.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.btn_home.Appearance.Options.UseBackColor = true;
            this.btn_home.Appearance.Options.UseFont = true;
            this.btn_home.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_home.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_home.AppearanceHovered.Options.UseBackColor = true;
            this.btn_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_home.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_home.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.home;
            this.btn_home.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btn_home.Location = new System.Drawing.Point(446, 18);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(200, 68);
            this.btn_home.TabIndex = 11;
            this.btn_home.Text = "الرئيسية Esc\r\nHome ";
            this.btn_home.ToolTip = "Home Page";
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // User
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 918);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbl_notmatched);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "User";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "المستخدمين - Users";
            this.Load += new System.EventHandler(this.User_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_discper.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_rwinv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_utype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_acreadit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_adisc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_smanid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_newpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_username.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SpinEdit txt_discper;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.LookUpEdit cmb_smanid;
        private DevExpress.XtraEditors.ToggleSwitch ts_adisc;
        private DevExpress.XtraEditors.ToggleSwitch ts_acreadit;
        private DevExpress.XtraEditors.ToggleSwitch ts_rwinv;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txt_password;
        private DevExpress.XtraEditors.SimpleButton btn_respass;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txt_newpassword;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.ToggleSwitch ts_utype;
        private DevExpress.XtraEditors.LabelControl lbl_notmatched;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit cmb_username;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_home;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}