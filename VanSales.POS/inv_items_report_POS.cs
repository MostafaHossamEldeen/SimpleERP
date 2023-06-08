using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class inv_items_report_POS : DevExpress.XtraBars.TabForm
    {
        public inv_items_report_POS()
        {
            InitializeComponent();
        }

        private void inv_items_report_POS_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            e.ConnectionParameters = new MsSqlConnectionParameters(ConfigurationManager.AppSettings["sever"], ConfigurationManager.AppSettings["dbname"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"], MsSqlAuthorizationType.SqlServer);
        }
        private void inv_items_report_POS_Load(object sender, EventArgs e)
        {
            Util.GenerateCombobox1("pos_online_user_sel", cmb_username, "", "", "username", "username");
            Util.GenerateCombobox1("sman_sel_pos", cmb_smanid, "", "", "smanid", "smanname");

            Date_from.DateTime = DateTime.Now.Date;
            Date_to.DateTime = DateTime.Now.Date;
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_username.EditValue == null )
                {
                    XtraMessageBox.Show("برجاء اختيار  المستخدم اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Date_from.EditValue == null)
                {
                    XtraMessageBox.Show("برجاء اختيار  بداية المدة اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (Date_to.EditValue == null)
                {
                    XtraMessageBox.Show("برجاء اختيار  نهاية المدة اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                
                string ReportPath = Application.StartupPath + @"\report\s_invdtl_sel_report_POS.repx";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                var username = cmb_username.EditValue;
                var fromdate = Date_from.EditValue;
                var todate = Date_to.EditValue;
                var smanid = cmb_smanid.EditValue;
                var smanname = cmb_smanid.Text;
                var branchid = Convert.ToInt32(TokenResult.GetLoginData("branchid").ToString());
                var userid = TokenResult.GetLoginData("userid").ToString();
                
                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += inv_items_report_POS_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += inv_items_report_POS_ConnectionError; ; ;

                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["username"].Value = username;
                xtraReport.Parameters["userid"].Value = userid;
                xtraReport.Parameters["fromdate"].Value = fromdate;
                xtraReport.Parameters["todate"].Value = todate;
                xtraReport.Parameters["branchid"].Value = branchid;
                xtraReport.Parameters["sman"].Value = smanname;

                foreach (XRSubreport item in sub)
                {

                    ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += inv_items_report_POS_ConfigureDataConnection;
                    item.ReportSource = XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConnectionError += inv_items_report_POS_ConnectionError;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += inv_items_report_POS_ConfigureDataConnection;

                }
                xtraReport.Print();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void inv_items_report_POS_ConnectionError(object sender, ConnectionErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void  inv_items_report_POS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                btn_print.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_home.PerformClick();
            }
        }
        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_sman_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmb_username_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmb_sman_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void cmb_sman_EditValueChanged_2(object sender, EventArgs e)
        {
            
        }

        private void cmb_sman_EditValueChanged_3(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
           

        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            string ReportPath = Application.StartupPath + @"\report\s_invdtl_sel_report_POS.repx";
            XtraReport xtraReport = XtraReport.FromFile(ReportPath);

            var username = cmb_username.EditValue;
            var fromdate = Date_from.EditValue;
            var todate = Date_to.EditValue;
            var smanid = cmb_smanid.EditValue;
            var smanname = cmb_smanid.Text;
            var branchid = Convert.ToInt32(TokenResult.GetLoginData("branchid").ToString());
            var userid = TokenResult.GetLoginData("userid").ToString();

            var sub = xtraReport.AllControls<XRSubreport>();
            xtraReport.Parameters["username"].Value = username;
            xtraReport.Parameters["userid"].Value = userid;
            xtraReport.Parameters["fromdate"].Value = fromdate;
            xtraReport.Parameters["todate"].Value = todate;
            xtraReport.Parameters["branchid"].Value = branchid;
            xtraReport.Parameters["sman"].Value = smanname;

            ReportPrintTool printool = new ReportPrintTool(xtraReport);
            printool.ShowPreview();
        }
    }
}
