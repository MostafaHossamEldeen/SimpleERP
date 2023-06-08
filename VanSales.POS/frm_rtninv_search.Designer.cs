
namespace VanSales.POS
{
    partial class frm_rtninv_search
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
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txt_search = new DevExpress.XtraEditors.TextEdit();
            this.gridControlsearch = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.sinvno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sinvdata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.custid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.custname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.custmobile = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txt_search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(575, 24);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(112, 17);
            this.labelControl11.TabIndex = 31;
            this.labelControl11.Text = "بحث بـــــــــــــــــ:";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(180, 12);
            this.txt_search.Name = "txt_search";
            this.txt_search.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txt_search.Properties.Appearance.Options.UseFont = true;
            this.txt_search.Size = new System.Drawing.Size(386, 38);
            this.txt_search.TabIndex = 30;
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // gridControlsearch
            // 
            this.gridControlsearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControlsearch.Location = new System.Drawing.Point(0, 56);
            this.gridControlsearch.MainView = this.gridView1;
            this.gridControlsearch.Name = "gridControlsearch";
            this.gridControlsearch.Size = new System.Drawing.Size(969, 535);
            this.gridControlsearch.TabIndex = 32;
            this.gridControlsearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControlsearch.DoubleClick += new System.EventHandler(this.gridControlsearch_DoubleClick);
            this.gridControlsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControlsearch_KeyDown);
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
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
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
            this.sinvno,
            this.sinvdata,
            this.custid,
            this.custname,
            this.custmobile});
            this.gridView1.GridControl = this.gridControlsearch;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Web";
            // 
            // sinvno
            // 
            this.sinvno.Caption = "رقم الفاتوره";
            this.sinvno.FieldName = "sinvno";
            this.sinvno.Name = "sinvno";
            this.sinvno.OptionsColumn.AllowEdit = false;
            this.sinvno.OptionsColumn.AllowFocus = false;
            this.sinvno.Visible = true;
            this.sinvno.VisibleIndex = 0;
            // 
            // sinvdata
            // 
            this.sinvdata.Caption = "التاريخ";
            this.sinvdata.FieldName = "sinvdata";
            this.sinvdata.Name = "sinvdata";
            this.sinvdata.OptionsColumn.AllowEdit = false;
            this.sinvdata.OptionsColumn.AllowFocus = false;
            this.sinvdata.Visible = true;
            this.sinvdata.VisibleIndex = 1;
            // 
            // custid
            // 
            this.custid.Caption = "كود العميل";
            this.custid.FieldName = "custid";
            this.custid.Name = "custid";
            this.custid.OptionsColumn.AllowEdit = false;
            this.custid.OptionsColumn.AllowFocus = false;
            this.custid.Visible = true;
            this.custid.VisibleIndex = 2;
            // 
            // custname
            // 
            this.custname.Caption = "اسم العميل";
            this.custname.FieldName = "custname";
            this.custname.Name = "custname";
            this.custname.OptionsColumn.AllowEdit = false;
            this.custname.OptionsColumn.AllowFocus = false;
            this.custname.Visible = true;
            this.custname.VisibleIndex = 3;
            // 
            // custmobile
            // 
            this.custmobile.Caption = "الجوال";
            this.custmobile.FieldName = "custmobile";
            this.custmobile.Name = "custmobile";
            this.custmobile.OptionsColumn.AllowEdit = false;
            this.custmobile.OptionsColumn.AllowFocus = false;
            this.custmobile.Visible = true;
            this.custmobile.VisibleIndex = 4;
            // 
            // frm_rtninv_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 591);
            this.Controls.Add(this.gridControlsearch);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txt_search);
            this.Name = "frm_rtninv_search";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بحث فواتــــير المرتــجع";
            this.Load += new System.EventHandler(this.frm_rtninv_search_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_rtninv_search_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txt_search;
        private DevExpress.XtraGrid.GridControl gridControlsearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn sinvno;
        private DevExpress.XtraGrid.Columns.GridColumn sinvdata;
        private DevExpress.XtraGrid.Columns.GridColumn custid;
        private DevExpress.XtraGrid.Columns.GridColumn custname;
        private DevExpress.XtraGrid.Columns.GridColumn custmobile;
    }
}