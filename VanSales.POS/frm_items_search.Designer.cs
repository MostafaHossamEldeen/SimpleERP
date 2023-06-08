
namespace VanSales.POS
{
    partial class frm_items_search
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
            this.gv_search = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.itemcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chartcode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txt_search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlsearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_search)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(590, 36);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(86, 19);
            this.labelControl11.TabIndex = 27;
            this.labelControl11.Text = "كود الصنف:";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(105, 23);
            this.txt_search.Name = "txt_search";
            this.txt_search.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.txt_search.Properties.Appearance.Options.UseFont = true;
            this.txt_search.Size = new System.Drawing.Size(479, 38);
            this.txt_search.TabIndex = 28;
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // gridControlsearch
            // 
            this.gridControlsearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControlsearch.Location = new System.Drawing.Point(0, 81);
            this.gridControlsearch.MainView = this.gv_search;
            this.gridControlsearch.Name = "gridControlsearch";
            this.gridControlsearch.Size = new System.Drawing.Size(873, 581);
            this.gridControlsearch.TabIndex = 29;
            this.gridControlsearch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_search});
            this.gridControlsearch.DoubleClick += new System.EventHandler(this.gridControlsearch_DoubleClick);
            this.gridControlsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridControlsearch_KeyDown);
            // 
            // gv_search
            // 
            this.gv_search.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gv_search.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gv_search.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gv_search.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_search.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_search.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gv_search.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gv_search.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gv_search.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_search.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.gv_search.Appearance.Empty.Options.UseBackColor = true;
            this.gv_search.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_search.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gv_search.Appearance.EvenRow.Options.UseBackColor = true;
            this.gv_search.Appearance.EvenRow.Options.UseForeColor = true;
            this.gv_search.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gv_search.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gv_search.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gv_search.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_search.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_search.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.gv_search.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gv_search.Appearance.FilterPanel.Options.UseBorderColor = true;
            this.gv_search.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gv_search.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gv_search.Appearance.FixedLine.Options.UseBackColor = true;
            this.gv_search.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gv_search.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gv_search.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gv_search.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gv_search.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gv_search.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gv_search.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gv_search.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.gv_search.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gv_search.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gv_search.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gv_search.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gv_search.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.gv_search.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.GroupButton.Options.UseBackColor = true;
            this.gv_search.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gv_search.Appearance.GroupButton.Options.UseForeColor = true;
            this.gv_search.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_search.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_search.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gv_search.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gv_search.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_search.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.gv_search.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gv_search.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gv_search.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gv_search.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_search.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.gv_search.Appearance.GroupRow.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.GroupRow.Options.UseBackColor = true;
            this.gv_search.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gv_search.Appearance.GroupRow.Options.UseForeColor = true;
            this.gv_search.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_search.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.gv_search.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.gv_search.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gv_search.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gv_search.Appearance.HeaderPanel.Options.UseFont = true;
            this.gv_search.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gv_search.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(158)))), ((int)(((byte)(64)))));
            this.gv_search.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_search.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gv_search.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gv_search.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gv_search.Appearance.HorzLine.Options.UseBackColor = true;
            this.gv_search.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.gv_search.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gv_search.Appearance.OddRow.Options.UseBackColor = true;
            this.gv_search.Appearance.OddRow.Options.UseForeColor = true;
            this.gv_search.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(253)))), ((int)(((byte)(246)))));
            this.gv_search.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.gv_search.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.gv_search.Appearance.Preview.Options.UseBackColor = true;
            this.gv_search.Appearance.Preview.Options.UseFont = true;
            this.gv_search.Appearance.Preview.Options.UseForeColor = true;
            this.gv_search.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.gv_search.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gv_search.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gv_search.Appearance.Row.Options.UseBackColor = true;
            this.gv_search.Appearance.Row.Options.UseFont = true;
            this.gv_search.Appearance.Row.Options.UseForeColor = true;
            this.gv_search.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.gv_search.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.gv_search.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gv_search.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.gv_search.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.gv_search.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gv_search.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gv_search.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gv_search.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gv_search.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.gv_search.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gv_search.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.gv_search.Appearance.VertLine.Options.UseBackColor = true;
            this.gv_search.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.itemcode,
            this.itemname,
            this.unitname,
            this.fprice,
            this.vat,
            this.barcode1,
            this.chartcode});
            this.gv_search.GridControl = this.gridControlsearch;
            this.gv_search.Name = "gv_search";
            this.gv_search.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_search.OptionsView.EnableAppearanceOddRow = true;
            this.gv_search.OptionsView.ShowFooter = true;
            this.gv_search.OptionsView.ShowGroupPanel = false;
            this.gv_search.PaintStyleName = "Web";
            // 
            // itemcode
            // 
            this.itemcode.Caption = "كود الصنف";
            this.itemcode.FieldName = "itemcode";
            this.itemcode.Name = "itemcode";
            this.itemcode.OptionsColumn.AllowEdit = false;
            this.itemcode.OptionsColumn.AllowFocus = false;
            this.itemcode.Visible = true;
            this.itemcode.VisibleIndex = 0;
            // 
            // itemname
            // 
            this.itemname.Caption = "اسم الصنف";
            this.itemname.FieldName = "itemname";
            this.itemname.Name = "itemname";
            this.itemname.OptionsColumn.AllowEdit = false;
            this.itemname.OptionsColumn.AllowFocus = false;
            this.itemname.Visible = true;
            this.itemname.VisibleIndex = 1;
            // 
            // unitname
            // 
            this.unitname.Caption = "الوحده";
            this.unitname.FieldName = "unitname";
            this.unitname.Name = "unitname";
            this.unitname.OptionsColumn.AllowEdit = false;
            this.unitname.OptionsColumn.AllowFocus = false;
            this.unitname.Visible = true;
            this.unitname.VisibleIndex = 2;
            // 
            // fprice
            // 
            this.fprice.Caption = "السعر";
            this.fprice.FieldName = "fprice";
            this.fprice.Name = "fprice";
            this.fprice.OptionsColumn.AllowEdit = false;
            this.fprice.OptionsColumn.AllowFocus = false;
            this.fprice.Visible = true;
            this.fprice.VisibleIndex = 3;
            // 
            // vat
            // 
            this.vat.Caption = "الضريبه";
            this.vat.FieldName = "vat";
            this.vat.Name = "vat";
            // 
            // barcode1
            // 
            this.barcode1.Caption = "باركود الصنف";
            this.barcode1.FieldName = "barcode1";
            this.barcode1.Name = "barcode1";
            this.barcode1.OptionsColumn.AllowEdit = false;
            this.barcode1.OptionsColumn.AllowFocus = false;
            // 
            // chartcode
            // 
            this.chartcode.Caption = "كود الحساب";
            this.chartcode.FieldName = "chartcode";
            this.chartcode.Name = "chartcode";
            this.chartcode.OptionsColumn.AllowEdit = false;
            this.chartcode.OptionsColumn.AllowFocus = false;
            // 
            // frm_items_search
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 662);
            this.Controls.Add(this.gridControlsearch);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txt_search);
            this.IconOptions.Image = global::VanSales.POS.Properties.Resources.logo;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frm_items_search";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "بحث الاصناف";
            this.Load += new System.EventHandler(this.frm_items_search_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_items_search_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlsearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_search)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txt_search;
        private DevExpress.XtraGrid.GridControl gridControlsearch;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_search;
        private DevExpress.XtraGrid.Columns.GridColumn chartcode;
        private DevExpress.XtraGrid.Columns.GridColumn itemname;
        private DevExpress.XtraGrid.Columns.GridColumn unitname;
        private DevExpress.XtraGrid.Columns.GridColumn fprice;
        private DevExpress.XtraGrid.Columns.GridColumn vat;
        private DevExpress.XtraGrid.Columns.GridColumn itemcode;
        private DevExpress.XtraGrid.Columns.GridColumn barcode1;
    }
}