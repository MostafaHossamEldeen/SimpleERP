
namespace VanSales.POS
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.lbl_logopath = new System.Windows.Forms.Label();
            this.btn_upload_logo = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_compname = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_vattypeid = new DevExpress.XtraEditors.LookUpEdit();
            this.cmb_ccid = new DevExpress.XtraEditors.LookUpEdit();
            this.cmb_branchid = new DevExpress.XtraEditors.LookUpEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_vatno = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ts_conntype = new DevExpress.XtraEditors.ToggleSwitch();
            this.txt_printno = new DevExpress.XtraEditors.TextEdit();
            this.img_complogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_getdata = new DevExpress.XtraEditors.SimpleButton();
            this.btn_home = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_compname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_vattypeid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ccid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_branchid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_vatno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_conntype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_printno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_complogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            this.xtraOpenFileDialog1.Filter = "Image (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";
            this.xtraOpenFileDialog1.Location = new System.Drawing.Point(0, 29);
            // 
            // lbl_logopath
            // 
            this.lbl_logopath.AutoSize = true;
            this.lbl_logopath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_logopath.Location = new System.Drawing.Point(328, 357);
            this.lbl_logopath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_logopath.Name = "lbl_logopath";
            this.lbl_logopath.Size = new System.Drawing.Size(122, 24);
            this.lbl_logopath.TabIndex = 0;
            this.lbl_logopath.Text = "رفع شعار الشركة";
            // 
            // btn_upload_logo
            // 
            this.btn_upload_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_upload_logo.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btn_upload_logo.Appearance.Options.UseFont = true;
            this.btn_upload_logo.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btn_upload_logo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btn_upload_logo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_upload_logo.ImageOptions.SvgImage")));
            this.btn_upload_logo.Location = new System.Drawing.Point(458, 361);
            this.btn_upload_logo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_upload_logo.Name = "btn_upload_logo";
            this.btn_upload_logo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_upload_logo.Size = new System.Drawing.Size(55, 50);
            this.btn_upload_logo.TabIndex = 15;
            this.btn_upload_logo.ToolTip = "Upload Logo";
            this.btn_upload_logo.Click += new System.EventHandler(this.btn_upload_logo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.16854F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.73783F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.07491F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.20599F));
            this.tableLayoutPanel1.Controls.Add(this.txt_compname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmb_vattypeid, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmb_ccid, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_upload_logo, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmb_branchid, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_vatno, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl_logopath, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.ts_conntype, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_printno, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.img_complogo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1288, 833);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // txt_compname
            // 
            this.txt_compname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_compname.Location = new System.Drawing.Point(651, 123);
            this.txt_compname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_compname.Name = "txt_compname";
            this.txt_compname.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txt_compname.Properties.Appearance.Options.UseFont = true;
            this.txt_compname.Size = new System.Drawing.Size(438, 30);
            this.txt_compname.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(1145, 238);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 62);
            this.label13.TabIndex = 0;
            this.label13.Text = "الرقم الضريبي:\r\nVat Number";
            // 
            // cmb_vattypeid
            // 
            this.cmb_vattypeid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_vattypeid.Location = new System.Drawing.Point(651, 599);
            this.cmb_vattypeid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_vattypeid.Name = "cmb_vattypeid";
            this.cmb_vattypeid.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_vattypeid.Properties.Appearance.Options.UseFont = true;
            this.cmb_vattypeid.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_vattypeid.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_vattypeid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_vattypeid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("citemname", "Name3", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmb_vattypeid.Properties.DropDownRows = 3;
            this.cmb_vattypeid.Properties.NullText = "";
            this.cmb_vattypeid.Properties.ShowHeader = false;
            this.cmb_vattypeid.Size = new System.Drawing.Size(438, 30);
            this.cmb_vattypeid.TabIndex = 28;
            // 
            // cmb_ccid
            // 
            this.cmb_ccid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_ccid.Location = new System.Drawing.Point(651, 480);
            this.cmb_ccid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_ccid.Name = "cmb_ccid";
            this.cmb_ccid.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_ccid.Properties.Appearance.Options.UseFont = true;
            this.cmb_ccid.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_ccid.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_ccid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_ccid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ccname", "Name2", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmb_ccid.Properties.DropDownRows = 3;
            this.cmb_ccid.Properties.NullText = "";
            this.cmb_ccid.Properties.ShowHeader = false;
            this.cmb_ccid.Size = new System.Drawing.Size(438, 30);
            this.cmb_ccid.TabIndex = 27;
            // 
            // cmb_branchid
            // 
            this.cmb_branchid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmb_branchid.Location = new System.Drawing.Point(651, 361);
            this.cmb_branchid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_branchid.Name = "cmb_branchid";
            this.cmb_branchid.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_branchid.Properties.Appearance.Options.UseFont = true;
            this.cmb_branchid.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.cmb_branchid.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_branchid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_branchid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("branchname", "Name1", 27, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmb_branchid.Properties.DropDownRows = 3;
            this.cmb_branchid.Properties.NullText = "";
            this.cmb_branchid.Properties.ShowHeader = false;
            this.cmb_branchid.Size = new System.Drawing.Size(438, 30);
            this.cmb_branchid.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(1107, 119);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(177, 62);
            this.label16.TabIndex = 0;
            this.label16.Text = "إسم الشركة:\r\nCompany Name";
            // 
            // txt_vatno
            // 
            this.txt_vatno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_vatno.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_vatno.Location = new System.Drawing.Point(651, 242);
            this.txt_vatno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_vatno.Name = "txt_vatno";
            this.txt_vatno.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txt_vatno.Properties.Appearance.Options.UseFont = true;
            this.txt_vatno.Properties.BeepOnError = false;
            this.txt_vatno.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txt_vatno.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_vatno.Properties.MaskSettings.Set("autoHideDecimalSeparator", false);
            this.txt_vatno.Properties.MaskSettings.Set("mask", "d");
            this.txt_vatno.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txt_vatno.Size = new System.Drawing.Size(438, 30);
            this.txt_vatno.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(1200, 357);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 62);
            this.label5.TabIndex = 14;
            this.label5.Text = "الفرع:\r\nBranch";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(1149, 476);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 62);
            this.label10.TabIndex = 28;
            this.label10.Text = "مركز التكلفة:\r\nCost Center";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(458, 595);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 62);
            this.label9.TabIndex = 0;
            this.label9.Text = "نوع الإتصال:\r\nConnection Type";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(1163, 595);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 62);
            this.label11.TabIndex = 29;
            this.label11.Text = "نوع الضريبة:\r\nVat Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(466, 476);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 62);
            this.label12.TabIndex = 31;
            this.label12.Text = "عدد مرات الطباعة:\r\nPrinting Count";
            // 
            // ts_conntype
            // 
            this.ts_conntype.EditValue = true;
            this.ts_conntype.Location = new System.Drawing.Point(271, 599);
            this.ts_conntype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ts_conntype.Name = "ts_conntype";
            this.ts_conntype.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.ts_conntype.Properties.Appearance.Options.UseFont = true;
            this.ts_conntype.Properties.OffText = "غير متصل";
            this.ts_conntype.Properties.OnText = "متصل";
            this.ts_conntype.Size = new System.Drawing.Size(179, 29);
            this.ts_conntype.TabIndex = 30;
            // 
            // txt_printno
            // 
            this.txt_printno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_printno.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_printno.Location = new System.Drawing.Point(4, 480);
            this.txt_printno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_printno.Name = "txt_printno";
            this.txt_printno.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txt_printno.Properties.Appearance.Options.UseFont = true;
            this.txt_printno.Properties.BeepOnError = false;
            this.txt_printno.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.txt_printno.Properties.MaskSettings.Set("mask", "d");
            this.txt_printno.Properties.MaskSettings.Set("autoHideDecimalSeparator", false);
            this.txt_printno.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_printno.Size = new System.Drawing.Size(446, 30);
            this.txt_printno.TabIndex = 6;
            // 
            // img_complogo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.img_complogo, 2);
            this.img_complogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img_complogo.ErrorImage = global::VanSales.POS.Properties.Resources.noimage;
            this.img_complogo.Location = new System.Drawing.Point(4, 123);
            this.img_complogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.img_complogo.Name = "img_complogo";
            this.tableLayoutPanel1.SetRowSpan(this.img_complogo, 2);
            this.img_complogo.Size = new System.Drawing.Size(639, 230);
            this.img_complogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_complogo.TabIndex = 16;
            this.img_complogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.labelControl10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 111);
            this.panel1.TabIndex = 32;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(184)))), ((int)(((byte)(107)))));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(508, 59);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(274, 51);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "System Settings";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(184)))), ((int)(((byte)(107)))));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(539, 11);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(215, 51);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "إعدادات النظام";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Controls.Add(this.btn_getdata);
            this.panel2.Controls.Add(this.btn_home);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 718);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 111);
            this.panel2.TabIndex = 33;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.simpleButton1.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.simpleButton1.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton1.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.btn_save;
            this.simpleButton1.Location = new System.Drawing.Point(784, 17);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(267, 81);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "حفظ End\r\nSave ";
            this.simpleButton1.ToolTip = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_getdata
            // 
            this.btn_getdata.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_getdata.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_getdata.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_getdata.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.btn_getdata.Appearance.Options.UseBackColor = true;
            this.btn_getdata.Appearance.Options.UseFont = true;
            this.btn_getdata.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_getdata.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_getdata.AppearanceHovered.Options.UseBackColor = true;
            this.btn_getdata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_getdata.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_getdata.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.server2;
            this.btn_getdata.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btn_getdata.Location = new System.Drawing.Point(509, 17);
            this.btn_getdata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_getdata.Name = "btn_getdata";
            this.btn_getdata.Size = new System.Drawing.Size(267, 81);
            this.btn_getdata.TabIndex = 11;
            this.btn_getdata.Text = "مزامنة البيانات\r\nSynce Data";
            this.btn_getdata.ToolTip = "Change Password";
            this.btn_getdata.Click += new System.EventHandler(this.btn_getdata_Click);
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
            this.btn_home.Location = new System.Drawing.Point(235, 17);
            this.btn_home.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(267, 81);
            this.btn_home.TabIndex = 11;
            this.btn_home.Text = "الرئيسية Esc\r\nHome ";
            this.btn_home.ToolTip = "Home Page";
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 833);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::VanSales.POS.Properties.Resources.logo;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إعدادات النظام - System Settings";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_compname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_vattypeid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ccid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_branchid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_vatno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_conntype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_printno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_complogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txt_compname;
        private DevExpress.XtraEditors.SimpleButton btn_upload_logo;
        private System.Windows.Forms.PictureBox img_complogo;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private System.Windows.Forms.Label lbl_logopath;
        private DevExpress.XtraEditors.LookUpEdit cmb_ccid;
        private DevExpress.XtraEditors.LookUpEdit cmb_vattypeid;
        private DevExpress.XtraEditors.ToggleSwitch ts_conntype;
        private DevExpress.XtraEditors.TextEdit txt_vatno;
        private DevExpress.XtraEditors.TextEdit txt_printno;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btn_home;
        private DevExpress.XtraEditors.SimpleButton btn_getdata;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.LookUpEdit cmb_branchid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}