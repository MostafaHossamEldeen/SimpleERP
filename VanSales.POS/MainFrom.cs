using System;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class MainFrom : DevExpress.XtraEditors.XtraForm
    {
        public MainFrom()
        {
            InitializeComponent();
            home_page H = new home_page();
            H.MdiParent = this;
            H.Dock = DockStyle.Fill;
            H.Show();
            if (Login_frm.localusername == null)
            {
                barStaticItem_username.Caption = TokenResult.GetLoginData("username") + " : المستخدم";
            }
            else
            {
                if (Login_frm.localusertype == false)
                {
                    NavBarGroup_settings.Visible = false;
                }
                else
                {
                    NavBarGroup_settings.Visible = false;
                }
                barStaticItem_username.Caption = Login_frm.localusername + " : المستخدم";
            }
            timer.Start();
            barStaticItem_date.Caption = DateTime.Now.ToShortDateString() + " : التاريخ";
            barStaticItem_time.Caption = DateTime.Now.ToLongTimeString() + " : الوقت";
        }
        private void MainFrom_Load(object sender, EventArgs e)
        {
            if (Login_frm.localusername == null)
            {
                barStaticItem_username.Caption = TokenResult.GetLoginData("username") + " : المستخدم";
            }
            else
            {
                if (Login_frm.localusertype == false)
                {
                    NavBarGroup_settings.Visible = false;
                }
                else
                {
                    NavBarGroup_settings.Visible = false;
                }
                barStaticItem_username.Caption = Login_frm.localusername + " : المستخدم";
            }
            timer.Start();
            barStaticItem_date.Caption = DateTime.Now.ToShortDateString() + " : التاريخ";
            barStaticItem_time.Caption = DateTime.Now.ToLongTimeString() + " : الوقت";
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            barStaticItem_date.Caption = DateTime.Now.ToShortDateString() + " : التاريخ";
            barStaticItem_time.Caption = DateTime.Now.ToLongTimeString() + " : الوقت";
        }
        private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void btn_inv_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_invpos I = new frm_invpos();
            I.MdiParent = this;
            I.Dock = DockStyle.Fill;
            I.Show();
        }

        private void btn_users_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            User U = new User();
            U.MdiParent = this;
            U.Dock = DockStyle.Fill;
            U.Show();
        }
        private void btn_system_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Setting S = new Setting();
            S.MdiParent = this;
            S.Dock = DockStyle.Fill;
            S.Show();
        }
        private void btn_rtninv_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Frm_Rtn_Inv R = new Frm_Rtn_Inv();
            R.MdiParent = this;
            R.Dock = DockStyle.Fill;
            R.Show();
        }
        private void btn_closing_shift_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            closing_shift C = new closing_shift();
            C.MdiParent = this;
            C.Dock = DockStyle.Fill;
            C.Show();
        }

        private void btn_rec_doc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_recdoc recdoc = new frm_recdoc();
            recdoc.MdiParent = this;
             recdoc.Dock = DockStyle.Fill;
            recdoc.Show();
        }

        private void btn_pay_doc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_paydoc frm_Paydoc = new frm_paydoc();
            frm_Paydoc.MdiParent = this;
            frm_Paydoc.Dock = DockStyle.Fill;
            frm_Paydoc.Show();
        }

        private void btn_rep1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Inv_Report_POS Inv_Report = new Inv_Report_POS();
            Inv_Report.MdiParent = this;
            Inv_Report.Dock = DockStyle.Fill;
            Inv_Report.Show();
        }

        private void btn_rep2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            inv_items_report_POS inv_items = new inv_items_report_POS();
            inv_items.MdiParent = this;
            inv_items.Dock = DockStyle.Fill;
            inv_items.Show();
        }
    }
}