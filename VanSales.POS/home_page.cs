using DevExpress.XtraEditors;
using Emax.Dal;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class home_page : DevExpress.XtraEditors.XtraForm
    {
        string constr = ConfigurationManager.ConnectionStrings["VanSales_pos"].ConnectionString;
        public home_page()
        {

            InitializeComponent();
            try
            {
                string respath;
                respath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                var res = SqlCommandHelper.ExcecuteToDataTable("sys_setting_sel", null, true, constr);
                if (res.dataTable.Rows.Count != 0)
                {
                    lbl_compname.Text = res.dataTable.Rows[0]["compname"].ToString();
                    if (File.Exists(respath + "\\complogo\\" + res.dataTable.Rows[0]["complogo"]))
                    {
                        img_complogo.Image = System.Drawing.Image.FromFile(respath + "\\complogo\\" + res.dataTable.Rows[0]["complogo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_inv_Click(object sender, EventArgs e)
        {
            frm_invpos I = new frm_invpos();
            I.MdiParent = this.MdiParent ;
            I.Dock = DockStyle.Fill;
            I.Show();
        }

        private void btn_rtn_Click(object sender, EventArgs e)
        {
            Frm_Rtn_Inv R = new Frm_Rtn_Inv();
            R.MdiParent = this.MdiParent;
            R.Dock = DockStyle.Fill;
            R.Show();
        }

        private void btn_closing_shift_Click(object sender, EventArgs e)
        {
            closing_shift C = new closing_shift();
            C.MdiParent = this.MdiParent;
            C.Dock = DockStyle.Fill;
            C.Show();
        }

        private void btn_paydoc_Click(object sender, EventArgs e)
        {
            frm_paydoc paydoc = new frm_paydoc();
            paydoc.MdiParent = this.MdiParent;
            paydoc.Dock = DockStyle.Fill;
            paydoc.Show();
        }

        private void btn_recdoc_Click(object sender, EventArgs e)
        {
            frm_recdoc recdoc = new frm_recdoc();
            recdoc.MdiParent = this.MdiParent;
            recdoc.Dock = DockStyle.Fill;
            recdoc.Show();
        }
    }
}