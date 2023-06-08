
using System;
using System.Drawing;

namespace VanSales.POS
{
    partial class closing_shift
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
            this.lbl_notmatched = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gv_closing_shift = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.payment_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.payment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.s_inv_count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.s_inv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.s_rtn_inv_count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.s_rtn_inv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.net_sales = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pay_doc_count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pay_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rec_doc_count = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rec_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.total_net = new DevExpress.XtraGrid.Columns.GridColumn();
            this.date_to = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ts_conntype = new DevExpress.XtraEditors.ToggleSwitch();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_username = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_preview = new DevExpress.XtraEditors.SimpleButton();
            this.btn_print = new DevExpress.XtraEditors.SimpleButton();
            this.btn_export = new DevExpress.XtraEditors.SimpleButton();
            this.btn_home = new DevExpress.XtraEditors.SimpleButton();
            this.date_from = new DevExpress.XtraEditors.DateEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_closing_shift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_to.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_to.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_conntype.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_username.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date_from.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_from.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(688, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "إسم المستخدم:\r\nUsername";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.date_to, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ts_conntype, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmb_username, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.date_from, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.888889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1618, 918);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // gridControl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gridControl, 4);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Appearance.Options.UseTextOptions = true;
            this.gridControl.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.gridControl.Location = new System.Drawing.Point(3, 255);
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gv_closing_shift;
            this.gridControl.Name = "gridControl";
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(1612, 548);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_closing_shift});
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // gv_closing_shift
            // 
            this.gv_closing_shift.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_closing_shift.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_closing_shift.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_closing_shift.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.Empty.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_closing_shift.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gv_closing_shift.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.EvenRow.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_closing_shift.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_closing_shift.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gv_closing_shift.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.FilterPanel.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gv_closing_shift.Appearance.FixedLine.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gv_closing_shift.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gv_closing_shift.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gv_closing_shift.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.FooterPanel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv_closing_shift.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.FooterPanel.Options.UseFont = true;
            this.gv_closing_shift.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gv_closing_shift.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_closing_shift.Appearance.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gv_closing_shift.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_closing_shift.Appearance.GroupButton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.gv_closing_shift.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.GroupButton.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.GroupButton.Options.UseFont = true;
            this.gv_closing_shift.Appearance.GroupButton.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_closing_shift.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_closing_shift.Appearance.GroupFooter.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.gv_closing_shift.Appearance.GroupFooter.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.GroupFooter.Options.UseFont = true;
            this.gv_closing_shift.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.gv_closing_shift.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_closing_shift.Appearance.GroupFooter.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gv_closing_shift.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_closing_shift.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gv_closing_shift.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_closing_shift.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_closing_shift.Appearance.GroupRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gv_closing_shift.Appearance.GroupRow.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.GroupRow.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.GroupRow.Options.UseFont = true;
            this.gv_closing_shift.Appearance.GroupRow.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_closing_shift.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_closing_shift.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gv_closing_shift.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_closing_shift.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gv_closing_shift.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(158)))), ((int)(((byte)(64)))));
            this.gv_closing_shift.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_closing_shift.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gv_closing_shift.Appearance.HorzLine.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.gv_closing_shift.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gv_closing_shift.Appearance.OddRow.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.OddRow.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(253)))), ((int)(((byte)(246)))));
            this.gv_closing_shift.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gv_closing_shift.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gv_closing_shift.Appearance.Preview.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.Preview.Options.UseFont = true;
            this.gv_closing_shift.Appearance.Preview.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.gv_closing_shift.Appearance.Row.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.gv_closing_shift.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gv_closing_shift.Appearance.Row.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.Row.Options.UseFont = true;
            this.gv_closing_shift.Appearance.Row.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.Row.Options.UseTextOptions = true;
            this.gv_closing_shift.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gv_closing_shift.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gv_closing_shift.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_closing_shift.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.gv_closing_shift.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.gv_closing_shift.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gv_closing_shift.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gv_closing_shift.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gv_closing_shift.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gv_closing_shift.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gv_closing_shift.Appearance.VertLine.Options.UseBackColor = true;
            this.gv_closing_shift.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.payment_type,
            this.payment,
            this.s_inv_count,
            this.s_inv,
            this.s_rtn_inv_count,
            this.s_rtn_inv,
            this.net_sales,
            this.pay_doc_count,
            this.pay_doc,
            this.rec_doc_count,
            this.rec_doc,
            this.total_net});
            this.gv_closing_shift.GridControl = this.gridControl;
            this.gv_closing_shift.GroupCount = 1;
            this.gv_closing_shift.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_inv_count", this.s_inv_count, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_inv", this.s_inv, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_rtn_inv_count", this.s_rtn_inv_count, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_rtn_inv", this.s_rtn_inv, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "net_sales", this.net_sales, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pay_doc_count", this.pay_doc_count, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pay_doc", this.pay_doc, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rec_doc_count", this.rec_doc_count, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rec_doc", this.rec_doc, "{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_net", this.total_net, "{0:0.##}")});
            this.gv_closing_shift.Name = "gv_closing_shift";
            this.gv_closing_shift.OptionsEditForm.EditFormColumnCount = 2;
            this.gv_closing_shift.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gv_closing_shift.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_closing_shift.OptionsView.EnableAppearanceOddRow = true;
            this.gv_closing_shift.OptionsView.RowAutoHeight = true;
            this.gv_closing_shift.OptionsView.ShowFooter = true;
            this.gv_closing_shift.OptionsView.ShowGroupPanel = false;
            this.gv_closing_shift.PaintStyleName = "Web";
            this.gv_closing_shift.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.payment_type, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // payment_type
            // 
            this.payment_type.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.payment_type.AppearanceCell.Options.UseFont = true;
            this.payment_type.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.payment_type.AppearanceHeader.Options.UseFont = true;
            this.payment_type.Caption = " ";
            this.payment_type.FieldName = "payment_type";
            this.payment_type.Name = "payment_type";
            this.payment_type.OptionsColumn.AllowEdit = false;
            this.payment_type.OptionsColumn.AllowFocus = false;
            this.payment_type.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.payment_type.OptionsColumn.ReadOnly = true;
            this.payment_type.OptionsColumn.TabStop = false;
            this.payment_type.Visible = true;
            this.payment_type.VisibleIndex = 0;
            this.payment_type.Width = 39;
            // 
            // payment
            // 
            this.payment.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.payment.AppearanceCell.Options.UseFont = true;
            this.payment.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.payment.AppearanceHeader.Options.UseFont = true;
            this.payment.Caption = "طريقه الدفع";
            this.payment.FieldName = "payment";
            this.payment.Name = "payment";
            this.payment.OptionsColumn.AllowEdit = false;
            this.payment.OptionsColumn.AllowFocus = false;
            this.payment.OptionsColumn.ReadOnly = true;
            this.payment.OptionsColumn.TabStop = false;
            this.payment.Visible = true;
            this.payment.VisibleIndex = 0;
            this.payment.Width = 145;
            // 
            // s_inv_count
            // 
            this.s_inv_count.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_inv_count.AppearanceCell.Options.UseFont = true;
            this.s_inv_count.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_inv_count.AppearanceHeader.Options.UseFont = true;
            this.s_inv_count.Caption = "عدد فواتير البيع";
            this.s_inv_count.FieldName = "s_inv_count";
            this.s_inv_count.Name = "s_inv_count";
            this.s_inv_count.OptionsColumn.AllowEdit = false;
            this.s_inv_count.OptionsColumn.AllowFocus = false;
            this.s_inv_count.OptionsColumn.ReadOnly = true;
            this.s_inv_count.OptionsColumn.TabStop = false;
            this.s_inv_count.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_inv_count", "{0:0.##}", "0")});
            this.s_inv_count.Visible = true;
            this.s_inv_count.VisibleIndex = 1;
            this.s_inv_count.Width = 145;
            // 
            // s_inv
            // 
            this.s_inv.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_inv.AppearanceCell.Options.UseFont = true;
            this.s_inv.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_inv.AppearanceHeader.Options.UseFont = true;
            this.s_inv.Caption = "قيمة فواتير البيع";
            this.s_inv.FieldName = "s_inv";
            this.s_inv.Name = "s_inv";
            this.s_inv.OptionsColumn.AllowEdit = false;
            this.s_inv.OptionsColumn.AllowFocus = false;
            this.s_inv.OptionsColumn.ReadOnly = true;
            this.s_inv.OptionsColumn.TabStop = false;
            this.s_inv.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_inv", "{0:0.##}", "0")});
            this.s_inv.Visible = true;
            this.s_inv.VisibleIndex = 2;
            this.s_inv.Width = 145;
            // 
            // s_rtn_inv_count
            // 
            this.s_rtn_inv_count.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_rtn_inv_count.AppearanceCell.Options.UseFont = true;
            this.s_rtn_inv_count.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_rtn_inv_count.AppearanceHeader.Options.UseFont = true;
            this.s_rtn_inv_count.Caption = "عدد مرتجع البيع";
            this.s_rtn_inv_count.FieldName = "s_rtn_inv_count";
            this.s_rtn_inv_count.Name = "s_rtn_inv_count";
            this.s_rtn_inv_count.OptionsColumn.AllowEdit = false;
            this.s_rtn_inv_count.OptionsColumn.AllowFocus = false;
            this.s_rtn_inv_count.OptionsColumn.ReadOnly = true;
            this.s_rtn_inv_count.OptionsColumn.TabStop = false;
            this.s_rtn_inv_count.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_rtn_inv_count", "{0:0.##}", "0")});
            this.s_rtn_inv_count.Visible = true;
            this.s_rtn_inv_count.VisibleIndex = 3;
            this.s_rtn_inv_count.Width = 145;
            // 
            // s_rtn_inv
            // 
            this.s_rtn_inv.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_rtn_inv.AppearanceCell.Options.UseFont = true;
            this.s_rtn_inv.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.s_rtn_inv.AppearanceHeader.Options.UseFont = true;
            this.s_rtn_inv.Caption = "قيمة مرتجع البيع";
            this.s_rtn_inv.FieldName = "s_rtn_inv";
            this.s_rtn_inv.Name = "s_rtn_inv";
            this.s_rtn_inv.OptionsColumn.AllowEdit = false;
            this.s_rtn_inv.OptionsColumn.AllowFocus = false;
            this.s_rtn_inv.OptionsColumn.ReadOnly = true;
            this.s_rtn_inv.OptionsColumn.TabStop = false;
            this.s_rtn_inv.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "s_rtn_inv", "{0:0.##}", new decimal(new int[] {
                            0,
                            0,
                            0,
                            0}))});
            this.s_rtn_inv.Visible = true;
            this.s_rtn_inv.VisibleIndex = 4;
            this.s_rtn_inv.Width = 145;
            // 
            // net_sales
            // 
            this.net_sales.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.net_sales.AppearanceCell.Options.UseFont = true;
            this.net_sales.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.net_sales.AppearanceHeader.Options.UseFont = true;
            this.net_sales.Caption = "صافي المبيعات";
            this.net_sales.FieldName = "net_sales";
            this.net_sales.Name = "net_sales";
            this.net_sales.OptionsColumn.AllowEdit = false;
            this.net_sales.OptionsColumn.AllowFocus = false;
            this.net_sales.OptionsColumn.ReadOnly = true;
            this.net_sales.OptionsColumn.TabStop = false;
            this.net_sales.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "net_sales", "{0:0.##}", "0")});
            this.net_sales.Visible = true;
            this.net_sales.VisibleIndex = 5;
            this.net_sales.Width = 145;
            // 
            // pay_doc_count
            // 
            this.pay_doc_count.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.pay_doc_count.AppearanceCell.Options.UseFont = true;
            this.pay_doc_count.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.pay_doc_count.AppearanceHeader.Options.UseFont = true;
            this.pay_doc_count.Caption = "عدد سندات صرف";
            this.pay_doc_count.FieldName = "pay_doc_count";
            this.pay_doc_count.Name = "pay_doc_count";
            this.pay_doc_count.OptionsColumn.AllowEdit = false;
            this.pay_doc_count.OptionsColumn.AllowFocus = false;
            this.pay_doc_count.OptionsColumn.ReadOnly = true;
            this.pay_doc_count.OptionsColumn.TabStop = false;
            this.pay_doc_count.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pay_doc_count", "{0:0.##}", "0")});
            this.pay_doc_count.Visible = true;
            this.pay_doc_count.VisibleIndex = 6;
            this.pay_doc_count.Width = 145;
            // 
            // pay_doc
            // 
            this.pay_doc.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.pay_doc.AppearanceCell.Options.UseFont = true;
            this.pay_doc.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.pay_doc.AppearanceHeader.Options.UseFont = true;
            this.pay_doc.Caption = "قيمة سندات صرف";
            this.pay_doc.FieldName = "pay_doc";
            this.pay_doc.Name = "pay_doc";
            this.pay_doc.OptionsColumn.AllowEdit = false;
            this.pay_doc.OptionsColumn.AllowFocus = false;
            this.pay_doc.OptionsColumn.ReadOnly = true;
            this.pay_doc.OptionsColumn.TabStop = false;
            this.pay_doc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pay_doc", "{0:0.##}", "0")});
            this.pay_doc.Visible = true;
            this.pay_doc.VisibleIndex = 7;
            this.pay_doc.Width = 145;
            // 
            // rec_doc_count
            // 
            this.rec_doc_count.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rec_doc_count.AppearanceCell.Options.UseFont = true;
            this.rec_doc_count.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rec_doc_count.AppearanceHeader.Options.UseFont = true;
            this.rec_doc_count.Caption = "عدد سندات قبض";
            this.rec_doc_count.FieldName = "rec_doc_count";
            this.rec_doc_count.Name = "rec_doc_count";
            this.rec_doc_count.OptionsColumn.AllowEdit = false;
            this.rec_doc_count.OptionsColumn.AllowFocus = false;
            this.rec_doc_count.OptionsColumn.ReadOnly = true;
            this.rec_doc_count.OptionsColumn.TabStop = false;
            this.rec_doc_count.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rec_doc_count", "{0:0.##}", "0")});
            this.rec_doc_count.Visible = true;
            this.rec_doc_count.VisibleIndex = 8;
            this.rec_doc_count.Width = 143;
            // 
            // rec_doc
            // 
            this.rec_doc.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rec_doc.AppearanceCell.Options.UseFont = true;
            this.rec_doc.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.rec_doc.AppearanceHeader.Options.UseFont = true;
            this.rec_doc.Caption = "قيمة سندات قبض";
            this.rec_doc.FieldName = "rec_doc";
            this.rec_doc.Name = "rec_doc";
            this.rec_doc.OptionsColumn.AllowEdit = false;
            this.rec_doc.OptionsColumn.AllowFocus = false;
            this.rec_doc.OptionsColumn.ReadOnly = true;
            this.rec_doc.OptionsColumn.TabStop = false;
            this.rec_doc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rec_doc", "{0:0.##}", "0")});
            this.rec_doc.Visible = true;
            this.rec_doc.VisibleIndex = 9;
            this.rec_doc.Width = 145;
            // 
            // total_net
            // 
            this.total_net.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.total_net.AppearanceCell.Options.UseFont = true;
            this.total_net.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.total_net.AppearanceHeader.Options.UseFont = true;
            this.total_net.Caption = "الإجمالي";
            this.total_net.FieldName = "total_net";
            this.total_net.Name = "total_net";
            this.total_net.OptionsColumn.AllowEdit = false;
            this.total_net.OptionsColumn.AllowFocus = false;
            this.total_net.OptionsColumn.ReadOnly = true;
            this.total_net.OptionsColumn.TabStop = false;
            this.total_net.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_net", "{0:0.##}", "0")});
            this.total_net.Visible = true;
            this.total_net.VisibleIndex = 10;
            this.total_net.Width = 145;
            // 
            // date_to
            // 
            this.date_to.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_to.EditValue = null;
            this.date_to.Location = new System.Drawing.Point(3, 183);
            this.date_to.Name = "date_to";
            this.date_to.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.date_to.Properties.Appearance.Options.UseFont = true;
            this.date_to.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.date_to.Properties.AppearanceDropDown.Options.UseFont = true;
            this.date_to.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_to.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_to.Size = new System.Drawing.Size(400, 30);
            this.date_to.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(774, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "الى:\r\nTo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1562, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "من:\r\nFrom";
            // 
            // ts_conntype
            // 
            this.ts_conntype.EditValue = true;
            this.ts_conntype.Location = new System.Drawing.Point(1077, 112);
            this.ts_conntype.Name = "ts_conntype";
            this.ts_conntype.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.ts_conntype.Properties.Appearance.Options.UseFont = true;
            this.ts_conntype.Properties.OffText = "غير متصل";
            this.ts_conntype.Properties.OnText = "متصل";
            this.ts_conntype.Size = new System.Drawing.Size(134, 24);
            this.ts_conntype.TabIndex = 1;
            this.ts_conntype.EditValueChanged += new System.EventHandler(this.ts_conntype_EditValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(1465, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 48);
            this.label9.TabIndex = 0;
            this.label9.Text = "نوع الإتصال:\r\nConnection Type";
            // 
            // cmb_username
            // 
            this.cmb_username.Location = new System.Drawing.Point(3, 112);
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
            this.cmb_username.Size = new System.Drawing.Size(400, 30);
            this.cmb_username.TabIndex = 2;
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
            this.panel1.Size = new System.Drawing.Size(1612, 99);
            this.panel1.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(184)))), ((int)(((byte)(107)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(734, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(172, 41);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Closing Shift";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(184)))), ((int)(((byte)(107)))));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(736, 8);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(168, 41);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "إغلاق الشيفت";
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.btn_preview);
            this.panel2.Controls.Add(this.btn_print);
            this.panel2.Controls.Add(this.btn_export);
            this.panel2.Controls.Add(this.btn_home);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 815);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1612, 100);
            this.panel2.TabIndex = 15;
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
            this.btn_preview.Location = new System.Drawing.Point(1013, 23);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(200, 68);
            this.btn_preview.TabIndex = 5;
            this.btn_preview.Text = "عرض Enter\r\nPreview";
            this.btn_preview.ToolTip = "Preview";
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
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
            this.btn_print.Location = new System.Drawing.Point(807, 23);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(200, 68);
            this.btn_print.TabIndex = 6;
            this.btn_print.Text = "طباعة End\r\nPrint ";
            this.btn_print.ToolTip = "Print";
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_export
            // 
            this.btn_export.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_export.Appearance.BackColor = System.Drawing.Color.White;
            this.btn_export.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btn_export.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.btn_export.Appearance.Options.UseBackColor = true;
            this.btn_export.Appearance.Options.UseFont = true;
            this.btn_export.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_export.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_export.AppearanceHovered.Options.UseBackColor = true;
            this.btn_export.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_export.ImageOptions.SvgImage = global::VanSales.POS.Properties.Resources.pdf;
            this.btn_export.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btn_export.Location = new System.Drawing.Point(601, 23);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(200, 68);
            this.btn_export.TabIndex = 7;
            this.btn_export.Text = "تصدير\r\nExport";
            this.btn_export.ToolTip = "Export";
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
            this.btn_home.Location = new System.Drawing.Point(395, 23);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(200, 68);
            this.btn_home.TabIndex = 8;
            this.btn_home.Text = "الرئيسية Esc\r\nHome ";
            this.btn_home.ToolTip = "Home Page";
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // date_from
            // 
            this.date_from.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_from.EditValue = null;
            this.date_from.Location = new System.Drawing.Point(813, 183);
            this.date_from.Name = "date_from";
            this.date_from.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.date_from.Properties.Appearance.Options.UseFont = true;
            this.date_from.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.date_from.Properties.AppearanceDropDown.Options.UseFont = true;
            this.date_from.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_from.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_from.Size = new System.Drawing.Size(398, 30);
            this.date_from.TabIndex = 3;
            // 
            // closing_shift
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1618, 918);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbl_notmatched);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "closing_shift";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "المستخدمين - Users";
            this.Load += new System.EventHandler(this.closing_shift_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.closing_shift_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_closing_shift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_to.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_to.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ts_conntype.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_username.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date_from.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_from.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lbl_notmatched;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit cmb_username;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.ToggleSwitch ts_conntype;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btn_print;
        private DevExpress.XtraEditors.SimpleButton btn_export;
        private DevExpress.XtraEditors.SimpleButton btn_home;
        private DevExpress.XtraEditors.DateEdit date_to;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.DateEdit date_from;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_closing_shift;
        private DevExpress.XtraGrid.Columns.GridColumn payment_type;
        private DevExpress.XtraGrid.Columns.GridColumn payment;
        private DevExpress.XtraGrid.Columns.GridColumn s_inv;
        private DevExpress.XtraGrid.Columns.GridColumn s_rtn_inv;
        private DevExpress.XtraGrid.Columns.GridColumn net_sales;
        private DevExpress.XtraGrid.Columns.GridColumn pay_doc;
        private DevExpress.XtraGrid.Columns.GridColumn rec_doc;
        private DevExpress.XtraGrid.Columns.GridColumn total_net;
        private DevExpress.XtraGrid.Columns.GridColumn s_inv_count;
        private DevExpress.XtraGrid.Columns.GridColumn s_rtn_inv_count;
        private DevExpress.XtraGrid.Columns.GridColumn pay_doc_count;
        private DevExpress.XtraGrid.Columns.GridColumn rec_doc_count;
        private DevExpress.XtraEditors.SimpleButton btn_preview;
    }
}