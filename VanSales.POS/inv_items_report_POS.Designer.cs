
namespace VanSales.POS
{
    partial class inv_items_report_POS
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
            this.tabFormPage1 = new DevExpress.XtraBars.TabFormPage();
            this.dsPos = new VanSales.POS.DsPos();
            this.sinvdtlsselBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.cmb_smanid = new DevExpress.XtraEditors.LookUpEdit();
            this.Date_to = new DevExpress.XtraEditors.DateEdit();
            this.btn_preview = new DevExpress.XtraEditors.SimpleButton();
            this.cmb_username = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.Date_from = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.btn_home = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dsPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinvdtlsselBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_smanid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_to.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_from.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_from.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFormPage1
            // 
            this.tabFormPage1.Name = "tabFormPage1";
            this.tabFormPage1.Text = "Page 0";
            // 
            // dsPos
            // 
            this.dsPos.DataSetName = "DsPos";
            this.dsPos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sinvdtlsselBindingSource
            // 
            this.sinvdtlsselBindingSource.DataMember = "s_invdtls_sel";
            this.sinvdtlsselBindingSource.DataSource = this.dsPos;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.Name = "sqlDataSource1";
            // 
            // cmb_smanid
            // 
            this.cmb_smanid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmb_smanid.Location = new System.Drawing.Point(257, 83);
            this.cmb_smanid.Name = "cmb_smanid";
            this.cmb_smanid.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmb_smanid.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_smanid.Properties.Appearance.Options.UseFont = true;
            this.cmb_smanid.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.cmb_smanid.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_smanid.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_smanid.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("smanname", "اسم المندوب")});
            this.cmb_smanid.Properties.DisplayMember = "smanname";
            this.cmb_smanid.Properties.DropDownRows = 5;
            this.cmb_smanid.Properties.NullText = "";
            this.cmb_smanid.Properties.PopupSizeable = false;
            this.cmb_smanid.Properties.ValueMember = "smanid";
            this.cmb_smanid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_smanid.Size = new System.Drawing.Size(490, 32);
            this.cmb_smanid.TabIndex = 12;
            // 
            // Date_to
            // 
            this.Date_to.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Date_to.EditValue = null;
            this.Date_to.Location = new System.Drawing.Point(456, 280);
            this.Date_to.Name = "Date_to";
            this.Date_to.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.Date_to.Properties.Appearance.Options.UseFont = true;
            this.Date_to.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.Date_to.Properties.AppearanceDropDown.Options.UseFont = true;
            this.Date_to.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Date_to.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Date_to.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Date_to.Size = new System.Drawing.Size(291, 30);
            this.Date_to.TabIndex = 15;
            // 
            // btn_preview
            // 
            this.btn_preview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_preview.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_preview.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_preview.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_preview.Appearance.Options.UseBackColor = true;
            this.btn_preview.Appearance.Options.UseFont = true;
            this.btn_preview.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_preview.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_preview.AppearanceHovered.Options.UseBackColor = true;
            this.btn_preview.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_preview.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.Btn_book;
            this.btn_preview.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btn_preview.Location = new System.Drawing.Point(872, 38);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(194, 70);
            this.btn_preview.TabIndex = 27;
            this.btn_preview.Text = "عرض Enter\r\nPreview";
            this.btn_preview.ToolTip = "Preview";
            // 
            // cmb_username
            // 
            this.cmb_username.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmb_username.Location = new System.Drawing.Point(966, 83);
            this.cmb_username.Name = "cmb_username";
            this.cmb_username.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_username.Properties.Appearance.Options.UseFont = true;
            this.cmb_username.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_username.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmb_username.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_username.Properties.DropDownRows = 5;
            this.cmb_username.Properties.NullText = "";
            this.cmb_username.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_username.Size = new System.Drawing.Size(490, 32);
            this.cmb_username.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(816, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 48);
            this.label4.TabIndex = 3;
            this.label4.Text = " : الى فترة \r\nTo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Date_from
            // 
            this.Date_from.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Date_from.EditValue = null;
            this.Date_from.Location = new System.Drawing.Point(1165, 280);
            this.Date_from.Name = "Date_from";
            this.Date_from.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.Date_from.Properties.Appearance.Options.UseFont = true;
            this.Date_from.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.Date_from.Properties.AppearanceDropDown.Options.UseFont = true;
            this.Date_from.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Date_from.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Date_from.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Date_from.Size = new System.Drawing.Size(291, 30);
            this.Date_from.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(799, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 48);
            this.label2.TabIndex = 3;
            this.label2.Text = ": اسم المندوب\r\nSalesman";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btn_print
            // 
            this.btn_print.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_print.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_print.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_print.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.Appearance.Options.UseBackColor = true;
            this.btn_print.Appearance.Options.UseFont = true;
            this.btn_print.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_print.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_print.AppearanceHovered.Options.UseBackColor = true;
            this.btn_print.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_print.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.btn_print;
            this.btn_print.Location = new System.Drawing.Point(672, 38);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(194, 70);
            this.btn_print.TabIndex = 25;
            this.btn_print.Text = "طباعة End\r\nPrint ";
            this.btn_print.ToolTip = "Print";
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
            this.btn_home.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_home.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.home;
            this.btn_home.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btn_home.Location = new System.Drawing.Point(472, 38);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(194, 70);
            this.btn_home.TabIndex = 26;
            this.btn_home.Text = "الرئيسية Esc\r\nHome ";
            this.btn_home.ToolTip = "Home Page";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1501, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 48);
            this.label3.TabIndex = 1;
            this.label3.Text = ": من فترة\r\nFrom";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1475, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = ": اسم المستخدم\r\nUsername\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(679, 46);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(232, 37);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "تقارير اصناف المبيعات\r\n";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1616, 666);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.01858F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.98142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 498F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel1.Controls.Add(this.cmb_username, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Date_from, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmb_smanid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Date_to, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.63613F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.36387F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1616, 393);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.btn_home);
            this.panel2.Controls.Add(this.btn_preview);
            this.panel2.Controls.Add(this.btn_print);
            this.panel2.Location = new System.Drawing.Point(0, 665);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1616, 253);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.labelControl10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1616, 138);
            this.panel3.TabIndex = 17;
            // 
            // inv_items_report_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1616, 917);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "inv_items_report_POS";
            this.Text = "inv_items_report_POS";
            this.Load += new System.EventHandler(this.inv_items_report_POS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinvdtlsselBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_smanid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_to.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_from.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_from.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.TabFormPage tabFormPage1;
        private DsPos dsPos;
        private System.Windows.Forms.BindingSource sinvdtlsselBindingSource;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraEditors.LookUpEdit cmb_smanid;
        private DevExpress.XtraEditors.DateEdit Date_to;
        private DevExpress.XtraEditors.SimpleButton btn_preview;
        private DevExpress.XtraEditors.LookUpEdit cmb_username;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit Date_from;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btn_print;
        private DevExpress.XtraEditors.SimpleButton btn_home;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}