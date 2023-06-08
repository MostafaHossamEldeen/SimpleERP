
namespace VanSales.POS
{
    partial class rtninv_pay
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
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_visa = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cach = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_rest = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_paid = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_total = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.paytname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paytename = new DevExpress.XtraGrid.Columns.GridColumn();
            this.value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paytypeid = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_delete
            // 
            this.btn_delete.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.btn_delete;
            this.btn_delete.Location = new System.Drawing.Point(564, 444);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(117, 52);
            this.btn_delete.TabIndex = 54;
            this.btn_delete.Text = "مسح (Delete)\r\nDelete";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_visa
            // 
            this.btn_visa.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.visa;
            this.btn_visa.Location = new System.Drawing.Point(238, 444);
            this.btn_visa.Name = "btn_visa";
            this.btn_visa.Size = new System.Drawing.Size(117, 52);
            this.btn_visa.TabIndex = 53;
            this.btn_visa.Text = "فيزا (F2)\r\nVisa";
            this.btn_visa.Click += new System.EventHandler(this.btn_visa_Click);
            // 
            // btn_cach
            // 
            this.btn_cach.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.money;
            this.btn_cach.Location = new System.Drawing.Point(413, 444);
            this.btn_cach.Name = "btn_cach";
            this.btn_cach.Size = new System.Drawing.Size(117, 52);
            this.btn_cach.TabIndex = 52;
            this.btn_cach.Text = "نقدى (F1)\r\nCach";
            this.btn_cach.Click += new System.EventHandler(this.btn_cach_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.btn_save;
            this.btn_Save.Location = new System.Drawing.Point(55, 444);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(120, 52);
            this.btn_Save.TabIndex = 51;
            this.btn_Save.Text = "طباعه & حفظ (End)\r\nSave & Print\r\n";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_rest
            // 
            this.txt_rest.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txt_rest.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_rest.Appearance.Options.UseFont = true;
            this.txt_rest.Appearance.Options.UseForeColor = true;
            this.txt_rest.Location = new System.Drawing.Point(73, 376);
            this.txt_rest.Name = "txt_rest";
            this.txt_rest.Size = new System.Drawing.Size(10, 19);
            this.txt_rest.TabIndex = 50;
            this.txt_rest.Text = "0";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(179, 399);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 49;
            this.labelControl5.Text = "Rest";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(167, 376);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(47, 17);
            this.labelControl7.TabIndex = 48;
            this.labelControl7.Text = "الباقى:";
            // 
            // txt_paid
            // 
            this.txt_paid.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txt_paid.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_paid.Appearance.Options.UseFont = true;
            this.txt_paid.Appearance.Options.UseForeColor = true;
            this.txt_paid.Location = new System.Drawing.Point(277, 379);
            this.txt_paid.Name = "txt_paid";
            this.txt_paid.Size = new System.Drawing.Size(10, 19);
            this.txt_paid.TabIndex = 47;
            this.txt_paid.Text = "0";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(387, 402);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 14);
            this.labelControl2.TabIndex = 46;
            this.labelControl2.Text = "Paid";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(371, 379);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 17);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "المدفوع:";
            // 
            // txt_total
            // 
            this.txt_total.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txt_total.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txt_total.Appearance.Options.UseFont = true;
            this.txt_total.Appearance.Options.UseForeColor = true;
            this.txt_total.Location = new System.Drawing.Point(496, 376);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(10, 19);
            this.txt_total.TabIndex = 44;
            this.txt_total.Text = "0";
            // 
            // labelControl20
            // 
            this.labelControl20.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl20.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl20.Appearance.Options.UseFont = true;
            this.labelControl20.Appearance.Options.UseForeColor = true;
            this.labelControl20.Location = new System.Drawing.Point(612, 399);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(28, 14);
            this.labelControl20.TabIndex = 43;
            this.labelControl20.Text = "Total";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(590, 376);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 17);
            this.labelControl6.TabIndex = 42;
            this.labelControl6.Text = "الاجمالى:";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(779, 293);
            this.gridControl1.TabIndex = 41;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.EditorKeyUp += new System.Windows.Forms.KeyEventHandler(this.gridControl1_EditorKeyUp);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gridView1.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(158)))), ((int)(((byte)(64)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(253)))), ((int)(((byte)(246)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.gridView1.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.paytname,
            this.paytename,
            this.value,
            this.paytypeid});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.EditFormColumnCount = 2;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Web";
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // paytname
            // 
            this.paytname.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.paytname.AppearanceCell.Options.UseFont = true;
            this.paytname.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.paytname.AppearanceHeader.Options.UseFont = true;
            this.paytname.Caption = "طريقه الدفع";
            this.paytname.FieldName = "paytname";
            this.paytname.Name = "paytname";
            this.paytname.OptionsColumn.AllowFocus = false;
            this.paytname.OptionsColumn.ReadOnly = true;
            this.paytname.OptionsColumn.TabStop = false;
            this.paytname.Visible = true;
            this.paytname.VisibleIndex = 0;
            this.paytname.Width = 243;
            // 
            // paytename
            // 
            this.paytename.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.paytename.AppearanceCell.Options.UseFont = true;
            this.paytename.Caption = "pay type";
            this.paytename.FieldName = "paytename";
            this.paytename.Name = "paytename";
            this.paytename.OptionsColumn.AllowEdit = false;
            this.paytename.OptionsColumn.AllowFocus = false;
            this.paytename.OptionsColumn.ReadOnly = true;
            this.paytename.Visible = true;
            this.paytename.VisibleIndex = 1;
            this.paytename.Width = 244;
            // 
            // value
            // 
            this.value.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.value.AppearanceCell.Options.UseFont = true;
            this.value.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.value.AppearanceHeader.Options.UseFont = true;
            this.value.Caption = "المبلغ";
            this.value.FieldName = "value";
            this.value.Name = "value";
            this.value.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:0.##}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.value.Visible = true;
            this.value.VisibleIndex = 2;
            this.value.Width = 279;
            // 
            // paytypeid
            // 
            this.paytypeid.FieldName = "paytypeid";
            this.paytypeid.Name = "paytypeid";
            this.paytypeid.OptionsColumn.AllowEdit = false;
            this.paytypeid.OptionsColumn.AllowFocus = false;
            // 
            // rtninv_pay
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 521);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_visa);
            this.Controls.Add(this.btn_cach);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_rest);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txt_paid);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.labelControl20);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = global::VanSales.POS.Properties.Resources.logo;
            this.Name = "rtninv_pay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "طريقه الدفع";
            this.Load += new System.EventHandler(this.rtninv_pay_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtninv_pay_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_delete;
        private DevExpress.XtraEditors.SimpleButton btn_visa;
        private DevExpress.XtraEditors.SimpleButton btn_cach;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.LabelControl txt_rest;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl txt_paid;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl txt_total;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn paytname;
        private DevExpress.XtraGrid.Columns.GridColumn paytename;
        private DevExpress.XtraGrid.Columns.GridColumn value;
        private DevExpress.XtraGrid.Columns.GridColumn paytypeid;
    }
}