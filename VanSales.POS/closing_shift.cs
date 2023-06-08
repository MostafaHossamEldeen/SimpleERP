using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;


namespace VanSales.POS
{
    public partial class closing_shift : DevExpress.XtraEditors.XtraForm
    {
        public closing_shift()
        {
            InitializeComponent();
        }
        string constr = ConfigurationManager.ConnectionStrings["VanSales_pos"].ConnectionString;
        private void closing_shift_Load(object sender, EventArgs e)
        {
            date_from.DateTime = DateTime.Now.Date;
            date_to.DateTime = DateTime.Now.Date;
            if (ts_conntype.IsOn == false)
            {
                Util.GenerateCombobox1("sys_users_sel", cmb_username, "", "", "username", "username", constr);
                cmb_username.EditValue = Login_frm.localusername;
            }
            else
            {
                Util.GenerateCombobox1("pos_online_user_sel", cmb_username, "", "", "username", "username");
                cmb_username.EditValue = TokenResult.GetLoginData("username");
            }
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("username", cmb_username.EditValue);
            dict.Add("from", date_from.DateTime);
            dict.Add("to", date_to.DateTime);
            var res = SqlCommandHelper.ExcecuteToDataTable("pos_closing_shift_sel", dict, true);
            gridControl.DataSource = res.dataTable;
            this.KeyPreview = true;
            gv_closing_shift.ExpandAllGroups();
        }
        private void ts_conntype_EditValueChanged(object sender, EventArgs e)
        {
            if (ts_conntype.IsOn == false)
            {
                Util.GenerateCombobox1("sys_users_sel", cmb_username, "", "", "username", "username", constr);
                cmb_username.EditValue = Login_frm.localusername;
            }
            else
            {
                Util.GenerateCombobox1("pos_online_user_sel", cmb_username, "", "", "username", "username");
                cmb_username.EditValue = Login_frm.localusername;
            }
        }
        private void closing_shift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.End)
            {
                btn_print.PerformClick();
            }
            else if(e.KeyCode==Keys.Escape)
            {
                btn_home.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btn_preview.PerformClick();
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("username", cmb_username.EditValue);
            dict.Add("from", date_from.DateTime);
            dict.Add("to", date_to.DateTime);
            var res = SqlCommandHelper.ExcecuteToDataTable("pos_closing_shift_sel", dict, true);
            gridControl.DataSource = res.dataTable;
            gv_closing_shift.ExpandAllGroups();
        }
        private void closing_shift_ConnectionError(object sender, ConnectionErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void closing_shift_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            e.ConnectionParameters = new MsSqlConnectionParameters(ConfigurationManager.AppSettings["sever"], ConfigurationManager.AppSettings["dbname"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"], MsSqlAuthorizationType.SqlServer);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_username.EditValue == null)
                {
                    XtraMessageBox.Show("برجاء اختيار  المستخدم اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(date_from.EditValue == null)
                {
                    XtraMessageBox.Show("برجاء اختيار  بداية المدة اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (date_to.EditValue == null)
                {
                    XtraMessageBox.Show("برجاء اختيار  نهاية المدة اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ReportPath = Application.StartupPath + @"\report\pos_closing_shift_sel_repo.repx";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                var username = cmb_username.EditValue;
                var from = date_from.EditValue;
                var to = date_to.EditValue;

                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += closing_shift_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += closing_shift_ConnectionError; ; ;
                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["username"].Value = username;
                xtraReport.Parameters["from"].Value = from;
                xtraReport.Parameters["to"].Value = to;
                foreach (XRSubreport item in sub)
                {

                    ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += closing_shift_ConfigureDataConnection;
                    item.ReportSource = XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConnectionError += closing_shift_ConnectionError;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += closing_shift_ConfigureDataConnection;

                }
                xtraReport.Print();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridControl_Click(object sender, EventArgs e)
        {

        }
    }
}