
namespace VanSales.POS
{
    partial class MainFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrom));
            this.navBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.NavBarGroup_inv = new DevExpress.XtraNavBar.NavBarGroup();
            this.btn_inv = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_rtninv = new DevExpress.XtraNavBar.NavBarItem();
            this.NavBarGroup_doc = new DevExpress.XtraNavBar.NavBarGroup();
            this.btn_rec_doc = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_pay_doc = new DevExpress.XtraNavBar.NavBarItem();
            this.NavBarGroup_rep = new DevExpress.XtraNavBar.NavBarGroup();
            this.btn_rep1 = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_rep2 = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_rep3 = new DevExpress.XtraNavBar.NavBarItem();
            this.NavBarGroup_data = new DevExpress.XtraNavBar.NavBarGroup();
            this.btn_closing_shift = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_getdata = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_senddata = new DevExpress.XtraNavBar.NavBarItem();
            this.NavBarGroup_settings = new DevExpress.XtraNavBar.NavBarGroup();
            this.btn_users = new DevExpress.XtraNavBar.NavBarItem();
            this.btn_system = new DevExpress.XtraNavBar.NavBarItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem_time = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_date = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_username = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl
            // 
            this.navBarControl.ActiveGroup = this.NavBarGroup_inv;
            this.navBarControl.AllowHorizontalResizing = DevExpress.Utils.DefaultBoolean.False;
            this.navBarControl.Appearance.GroupHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.navBarControl.Appearance.GroupHeader.Options.UseFont = true;
            this.navBarControl.Appearance.GroupHeaderActive.BackColor = System.Drawing.Color.Red;
            this.navBarControl.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.navBarControl.Appearance.GroupHeaderActive.Options.UseBackColor = true;
            this.navBarControl.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBarControl.Appearance.GroupHeaderHotTracked.BackColor = System.Drawing.Color.Lime;
            this.navBarControl.Appearance.GroupHeaderHotTracked.Options.UseBackColor = true;
            this.navBarControl.Appearance.Item.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.navBarControl.Appearance.Item.Options.UseFont = true;
            this.navBarControl.Appearance.ItemActive.BackColor = System.Drawing.Color.Yellow;
            this.navBarControl.Appearance.ItemActive.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.navBarControl.Appearance.ItemActive.Options.UseBackColor = true;
            this.navBarControl.Appearance.ItemActive.Options.UseFont = true;
            this.navBarControl.Appearance.ItemHotTracked.BackColor = System.Drawing.Color.LimeGreen;
            this.navBarControl.Appearance.ItemHotTracked.BackColor2 = System.Drawing.Color.LimeGreen;
            this.navBarControl.Appearance.ItemHotTracked.Options.UseBackColor = true;
            this.navBarControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.navBarControl.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold);
            this.navBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.NavBarGroup_inv,
            this.NavBarGroup_doc,
            this.NavBarGroup_rep,
            this.NavBarGroup_data,
            this.NavBarGroup_settings});
            this.navBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btn_inv,
            this.btn_rtninv,
            this.btn_rec_doc,
            this.btn_pay_doc,
            this.btn_rep1,
            this.btn_rep2,
            this.btn_rep3,
            this.btn_closing_shift,
            this.btn_getdata,
            this.btn_senddata,
            this.btn_users,
            this.btn_system});
            this.navBarControl.Location = new System.Drawing.Point(1196, 0);
            this.navBarControl.Name = "navBarControl";
            this.navBarControl.OptionsNavPane.ExpandedWidth = 198;
            this.navBarControl.OptionsNavPane.ShowGroupImageInHeader = true;
            this.navBarControl.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.navBarControl.Size = new System.Drawing.Size(198, 779);
            this.navBarControl.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.Buttons;
            this.navBarControl.TabIndex = 2;
            this.navBarControl.Text = "القائمة الرئيسية";
            this.navBarControl.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("DevExpress Style");
            // 
            // NavBarGroup_inv
            // 
            this.NavBarGroup_inv.Caption = "الفواتير";
            this.NavBarGroup_inv.Expanded = true;
            this.NavBarGroup_inv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NavBarGroup_inv.ImageOptions.SvgImage")));
            this.NavBarGroup_inv.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_inv),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_rtninv)});
            this.NavBarGroup_inv.Name = "NavBarGroup_inv";
            // 
            // btn_inv
            // 
            this.btn_inv.Caption = "فواتير البيع";
            this.btn_inv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_inv.ImageOptions.SvgImage")));
            this.btn_inv.Name = "btn_inv";
            this.btn_inv.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_inv_LinkClicked);
            // 
            // btn_rtninv
            // 
            this.btn_rtninv.Caption = "مرتجع بيع";
            this.btn_rtninv.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_rtninv.ImageOptions.SvgImage")));
            this.btn_rtninv.Name = "btn_rtninv";
            this.btn_rtninv.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_rtninv_LinkClicked);
            // 
            // NavBarGroup_doc
            // 
            this.NavBarGroup_doc.Caption = "السندات";
            this.NavBarGroup_doc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NavBarGroup_doc.ImageOptions.SvgImage")));
            this.NavBarGroup_doc.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_rec_doc),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_pay_doc)});
            this.NavBarGroup_doc.Name = "NavBarGroup_doc";
            // 
            // btn_rec_doc
            // 
            this.btn_rec_doc.Caption = "سند قبض";
            this.btn_rec_doc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_rec_doc.ImageOptions.SvgImage")));
            this.btn_rec_doc.Name = "btn_rec_doc";
            this.btn_rec_doc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_rec_doc_LinkClicked);
            // 
            // btn_pay_doc
            // 
            this.btn_pay_doc.Caption = "سند صرف";
            this.btn_pay_doc.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_pay_doc.ImageOptions.SvgImage")));
            this.btn_pay_doc.Name = "btn_pay_doc";
            this.btn_pay_doc.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_pay_doc_LinkClicked);
            // 
            // NavBarGroup_rep
            // 
            this.NavBarGroup_rep.Caption = "تقارير";
            this.NavBarGroup_rep.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NavBarGroup_rep.ImageOptions.SvgImage")));
            this.NavBarGroup_rep.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_rep1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_rep2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_rep3)});
            this.NavBarGroup_rep.Name = "NavBarGroup_rep";
            // 
            // btn_rep1
            // 
            this.btn_rep1.Caption = "فواتير";
            this.btn_rep1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_rep1.ImageOptions.SvgImage")));
            this.btn_rep1.Name = "btn_rep1";
            this.btn_rep1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_rep1_LinkClicked);
            // 
            // btn_rep2
            // 
            this.btn_rep2.Caption = "الأصناف";
            this.btn_rep2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_rep2.ImageOptions.SvgImage")));
            this.btn_rep2.Name = "btn_rep2";
            this.btn_rep2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_rep2_LinkClicked);
            // 
            // btn_rep3
            // 
            this.btn_rep3.Caption = "السندات";
            this.btn_rep3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_rep3.ImageOptions.SvgImage")));
            this.btn_rep3.Name = "btn_rep3";
            this.btn_rep3.Visible = false;
            // 
            // NavBarGroup_data
            // 
            this.NavBarGroup_data.Caption = "البيانات";
            this.NavBarGroup_data.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NavBarGroup_data.ImageOptions.SvgImage")));
            this.NavBarGroup_data.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_closing_shift),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_getdata),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_senddata)});
            this.NavBarGroup_data.Name = "NavBarGroup_data";
            // 
            // btn_closing_shift
            // 
            this.btn_closing_shift.Caption = "إغلاق الشفت";
            this.btn_closing_shift.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_closing_shift.ImageOptions.SvgImage")));
            this.btn_closing_shift.Name = "btn_closing_shift";
            this.btn_closing_shift.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_closing_shift_LinkClicked);
            // 
            // btn_getdata
            // 
            this.btn_getdata.Caption = "سحب البيانات";
            this.btn_getdata.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_getdata.ImageOptions.SvgImage")));
            this.btn_getdata.Name = "btn_getdata";
            this.btn_getdata.Visible = false;
            // 
            // btn_senddata
            // 
            this.btn_senddata.Caption = "إرسال البيانات";
            this.btn_senddata.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_senddata.ImageOptions.SvgImage")));
            this.btn_senddata.Name = "btn_senddata";
            this.btn_senddata.Visible = false;
            // 
            // NavBarGroup_settings
            // 
            this.NavBarGroup_settings.Caption = "الإعدادات";
            this.NavBarGroup_settings.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("NavBarGroup_settings.ImageOptions.SvgImage")));
            this.NavBarGroup_settings.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_users),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btn_system)});
            this.NavBarGroup_settings.Name = "NavBarGroup_settings";
            this.NavBarGroup_settings.Visible = false;
            // 
            // btn_users
            // 
            this.btn_users.Caption = "المستخدمين";
            this.btn_users.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_users.ImageOptions.SvgImage")));
            this.btn_users.Name = "btn_users";
            this.btn_users.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_users_LinkClicked);
            // 
            // btn_system
            // 
            this.btn_system.Caption = "النظام";
            this.btn_system.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_system.ImageOptions.SvgImage")));
            this.btn_system.Name = "btn_system";
            this.btn_system.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btn_system_LinkClicked);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem_time,
            this.barStaticItem_date,
            this.barStaticItem_username});
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_time),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_date),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_username)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem_time
            // 
            this.barStaticItem_time.Caption = "الوقت";
            this.barStaticItem_time.Id = 1;
            this.barStaticItem_time.Name = "barStaticItem_time";
            // 
            // barStaticItem_date
            // 
            this.barStaticItem_date.Caption = "التاريخ";
            this.barStaticItem_date.Id = 2;
            this.barStaticItem_date.Name = "barStaticItem_date";
            // 
            // barStaticItem_username
            // 
            this.barStaticItem_username.Caption = "إسم المستخدم";
            this.barStaticItem_username.Id = 3;
            this.barStaticItem_username.Name = "barStaticItem_username";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1394, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 779);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1394, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 779);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1394, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 779);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainFrom
            // 
            this.AllowMdiBar = true;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1394, 802);
            this.Controls.Add(this.navBarControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.IconOptions.Image = global::VanSales.POS.Properties.Resources.logo;
            this.IsMdiContainer = true;
            this.Name = "MainFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Circles POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrom_FormClosing);
            this.Load += new System.EventHandler(this.MainFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraNavBar.NavBarControl navBarControl;
        private DevExpress.XtraNavBar.NavBarGroup NavBarGroup_inv;
        private DevExpress.XtraNavBar.NavBarItem btn_inv;
        private DevExpress.XtraNavBar.NavBarGroup NavBarGroup_settings;
        private DevExpress.XtraNavBar.NavBarItem btn_users;
        private DevExpress.XtraNavBar.NavBarItem btn_system;
        private DevExpress.XtraNavBar.NavBarItem btn_rtninv;
        private DevExpress.XtraNavBar.NavBarGroup NavBarGroup_doc;
        private DevExpress.XtraNavBar.NavBarItem btn_rec_doc;
        private DevExpress.XtraNavBar.NavBarItem btn_pay_doc;
        private DevExpress.XtraNavBar.NavBarGroup NavBarGroup_rep;
        private DevExpress.XtraNavBar.NavBarItem btn_rep1;
        private DevExpress.XtraNavBar.NavBarItem btn_rep2;
        private DevExpress.XtraNavBar.NavBarItem btn_rep3;
        private DevExpress.XtraNavBar.NavBarGroup NavBarGroup_data;
        private DevExpress.XtraNavBar.NavBarItem btn_closing_shift;
        private DevExpress.XtraNavBar.NavBarItem btn_getdata;
        private DevExpress.XtraNavBar.NavBarItem btn_senddata;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_time;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_date;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_username;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.Timer timer;
    }
}