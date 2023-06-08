using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Emax.SharedLib;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class Inv_Report_POS : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Inv_Report_POS()
        {
            InitializeComponent();
        }


        private void Inv_Report_POS_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            e.ConnectionParameters = new MsSqlConnectionParameters(ConfigurationManager.AppSettings["sever"], ConfigurationManager.AppSettings["dbname"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"], MsSqlAuthorizationType.SqlServer);
        }


        private void Inv_Report_POS_Load(object sender, EventArgs e)
        {
            Util.GenerateCombobox1("pos_online_user_sel", cmb_username, "", "", "username", "username");
            Util.GenerateCombobox1("sman_sel_pos", cmb_sman, "", "", "smanid", "smanname");


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

                string ReportPath = Application.StartupPath + @"\report\s_inv_report_pos.repx";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                var username = cmb_username.EditValue;
                var fromdate = Date_from.EditValue;
                var todate   = Date_to.EditValue;
                var smanid   = cmb_sman.EditValue;
                var smanname = cmb_sman.Text;
                var branchid = Convert.ToInt32(TokenResult.GetLoginData("branchid").ToString());
                var userid   = TokenResult.GetLoginData("userid").ToString();

                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_Report_POS_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_Report_POS_ConnectionError; ; ;

                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["username"].Value = username;
                xtraReport.Parameters["fromdate"].Value = fromdate;
                xtraReport.Parameters["todate"].Value = todate;
                xtraReport.Parameters["smanid"].Value = smanid;
                xtraReport.Parameters["smanname"].Value = smanname;
                xtraReport.Parameters["branchid"].Value = branchid;
                xtraReport.Parameters["userid"].Value = userid;
               

                foreach (XRSubreport item in sub)
                {

                    ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += Inv_Report_POS_ConfigureDataConnection;
                    item.ReportSource = XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConnectionError += Inv_Report_POS_ConnectionError;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += Inv_Report_POS_ConfigureDataConnection;

                }
                xtraReport.Print();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Inv_Report_POS_KeyDown(object sender, KeyEventArgs e)
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

        private void Inv_Report_POS_ConnectionError(object sender, ConnectionErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_sman_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
           
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            string ReportPath = Application.StartupPath + @"\report\s_inv_report_pos.repx";
            XtraReport xtraReport = XtraReport.FromFile(ReportPath);

            var username = cmb_username.EditValue;
            var fromdate = Date_from.EditValue;
            var todate = Date_to.EditValue;
            var smanid = cmb_sman.EditValue;
            var smanname = cmb_sman.Text;
            var branchid = Convert.ToInt32(TokenResult.GetLoginData("branchid").ToString());
            var userid = TokenResult.GetLoginData("userid").ToString();


            xtraReport.Parameters["username"].Value = username;
            xtraReport.Parameters["fromdate"].Value = fromdate;
            xtraReport.Parameters["todate"].Value = todate;
            xtraReport.Parameters["smanid"].Value = smanid;
            xtraReport.Parameters["smanname"].Value = smanname;
            xtraReport.Parameters["branchid"].Value = branchid;
            xtraReport.Parameters["userid"].Value = userid;

            ReportPrintTool printool = new ReportPrintTool(xtraReport);
            printool.ShowPreview();
        }
    }
}
