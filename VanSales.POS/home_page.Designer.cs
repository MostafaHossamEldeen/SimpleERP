
namespace VanSales.POS
{
    partial class home_page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(home_page));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.img_complogo = new System.Windows.Forms.PictureBox();
            this.lbl_compname = new DevExpress.XtraEditors.LabelControl();
            this.btn_inv = new DevExpress.XtraEditors.SimpleButton();
            this.btn_rtn = new DevExpress.XtraEditors.SimpleButton();
            this.btn_recdoc = new DevExpress.XtraEditors.SimpleButton();
            this.btn_paydoc = new DevExpress.XtraEditors.SimpleButton();
            this.btn_closing_shift = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_complogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.img_complogo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_compname, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_inv, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_rtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_recdoc, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_paydoc, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_closing_shift, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 674);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // img_complogo
            // 
            this.img_complogo.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.img_complogo, 3);
            this.img_complogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img_complogo.Location = new System.Drawing.Point(3, 111);
            this.img_complogo.Name = "img_complogo";
            this.img_complogo.Size = new System.Drawing.Size(586, 295);
            this.img_complogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_complogo.TabIndex = 5;
            this.img_complogo.TabStop = false;
            // 
            // lbl_compname
            // 
            this.lbl_compname.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_compname.Appearance.Options.UseFont = true;
            this.lbl_compname.Appearance.Options.UseTextOptions = true;
            this.lbl_compname.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbl_compname.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tableLayoutPanel1.SetColumnSpan(this.lbl_compname, 3);
            this.lbl_compname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_compname.Location = new System.Drawing.Point(3, 3);
            this.lbl_compname.Name = "lbl_compname";
            this.lbl_compname.Size = new System.Drawing.Size(586, 102);
            this.lbl_compname.TabIndex = 6;
            this.lbl_compname.Text = "إسم الشركة";
            // 
            // btn_inv
            // 
            this.btn_inv.AllowFocus = false;
            this.btn_inv.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inv.Appearance.Options.UseFont = true;
            this.btn_inv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_inv.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btn_inv.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.btn_inv.Location = new System.Drawing.Point(791, 412);
            this.btn_inv.Name = "btn_inv";
            this.btn_inv.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_inv.Size = new System.Drawing.Size(190, 259);
            this.btn_inv.TabIndex = 0;
            this.btn_inv.Text = "فواتير البيع";
            this.btn_inv.Click += new System.EventHandler(this.btn_inv_Click);
            // 
            // btn_rtn
            // 
            this.btn_rtn.AllowFocus = false;
            this.btn_rtn.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.btn_rtn.Appearance.Options.UseFont = true;
            this.btn_rtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_rtn.Location = new System.Drawing.Point(595, 412);
            this.btn_rtn.Name = "btn_rtn";
            this.btn_rtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_rtn.Size = new System.Drawing.Size(190, 259);
            this.btn_rtn.TabIndex = 1;
            this.btn_rtn.Text = "مرتجع البيع";
            this.btn_rtn.Click += new System.EventHandler(this.btn_rtn_Click);
            // 
            // btn_recdoc
            // 
            this.btn_recdoc.AllowFocus = false;
            this.btn_recdoc.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.btn_recdoc.Appearance.Options.UseFont = true;
            this.btn_recdoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_recdoc.Location = new System.Drawing.Point(203, 412);
            this.btn_recdoc.Name = "btn_recdoc";
            this.btn_recdoc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_recdoc.Size = new System.Drawing.Size(190, 259);
            this.btn_recdoc.TabIndex = 2;
            this.btn_recdoc.Text = "سندات القبض";
            this.btn_recdoc.Click += new System.EventHandler(this.btn_recdoc_Click);
            // 
            // btn_paydoc
            // 
            this.btn_paydoc.AllowFocus = false;
            this.btn_paydoc.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.btn_paydoc.Appearance.Options.UseFont = true;
            this.btn_paydoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_paydoc.Location = new System.Drawing.Point(399, 412);
            this.btn_paydoc.Name = "btn_paydoc";
            this.btn_paydoc.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_paydoc.Size = new System.Drawing.Size(190, 259);
            this.btn_paydoc.TabIndex = 3;
            this.btn_paydoc.Text = "سندات الصرف";
            this.btn_paydoc.Click += new System.EventHandler(this.btn_paydoc_Click);
            // 
            // btn_closing_shift
            // 
            this.btn_closing_shift.AllowFocus = false;
            this.btn_closing_shift.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.btn_closing_shift.Appearance.Options.UseFont = true;
            this.btn_closing_shift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_closing_shift.Location = new System.Drawing.Point(3, 412);
            this.btn_closing_shift.Name = "btn_closing_shift";
            this.btn_closing_shift.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_closing_shift.Size = new System.Drawing.Size(194, 259);
            this.btn_closing_shift.TabIndex = 4;
            this.btn_closing_shift.Text = "إغلاق الشيفت";
            this.btn_closing_shift.Click += new System.EventHandler(this.btn_closing_shift_Click);
            // 
            // home_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 674);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.IconOptions.ColorizeInactiveIcon = DevExpress.Utils.DefaultBoolean.False;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "home_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_complogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_inv;
        private DevExpress.XtraEditors.SimpleButton btn_rtn;
        private DevExpress.XtraEditors.SimpleButton btn_recdoc;
        private DevExpress.XtraEditors.SimpleButton btn_paydoc;
        private DevExpress.XtraEditors.SimpleButton btn_closing_shift;
        private System.Windows.Forms.PictureBox img_complogo;
        private DevExpress.XtraEditors.LabelControl lbl_compname;
    }
}