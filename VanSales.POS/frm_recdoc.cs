using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Emax.SharedLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanSales.POS.Models;

namespace VanSales.POS
{
    public partial class frm_recdoc : DevExpress.XtraEditors.XtraForm
    {
        public frm_recdoc()
        {
            InitializeComponent();
        }
        void clear()
        {
           // txt_fromchartid.Text = string.Empty;
           // txt_fromchartname.Text = string.Empty;
            txt_paynotes.Text = string.Empty;
            txt_payref.Text = string.Empty;
            //txt_recdate.Text = string.Empty;
            txt_recdocno.Text = string.Empty;
            txt_recno.Text = string.Empty;
            txt_recnotes.Text = string.Empty;
            // txt_recuser.Text = string.Empty;
            txt_recvalue.Text = string.Empty;
            cmb_paytypeid.Text = string.Empty;
            cmb_paytypeid.EditValue = null;
            cmb_rectype.Text = string.Empty;
            cmb_rectype.EditValue = null;
            cmb_paytypeid.ItemIndex = 0;
            cmb_rectype.ItemIndex = 0;
           // lbl_fromchartid.Text = string.Empty;
            lbl_recid.Text = string.Empty;
            lbl_postacc.Text = " ";
            pictureEdit1.Text = string.Empty;
            txt_custname.Text = string.Empty;
            lbl_custid.Text = string.Empty;
            lbl_fromchartid.Text = TokenResult.GetLoginData("advancedpaymentchartid").ToString();
            txt_fromchartid.Text = TokenResult.GetLoginData("advancedpaymentchartcode").ToString();
            txt_fromchartname.Text = TokenResult.GetLoginData("advancedpaymentchartname").ToString();
        }
        async Task< string >ConvertToObject()
        {
            var res = await UploadAsync(xtraOpenFileDialog1.FileName, ConfigurationManager.AppSettings["apiroot"] + "/VanSalesService/Rec/UploadFiles", DateTime.Now.Ticks.ToString());
            if (res.Length != 0 || (res.Length==0 && xtraOpenFileDialog1.FileName.Length==0))
            {
                rec_doc rec_Doc = new rec_doc
                {
                    recdocno = txt_recdocno.Text,
                    recbranchid = EmaxGlobals.NullToIntZero(TokenResult.GetLoginData("branchid")),
                    branchname = TokenResult.GetLoginData("branchname").ToString(),
                    recdate = Convert.ToDateTime(txt_recdate.Text),
                    recman = txt_recuser.Text,
                    recvalue = EmaxGlobals.NullToZero(txt_recvalue.Text),
                    ccid = EmaxGlobals.NullToIntZero(TokenResult.GetLoginData("ccid")),
                    ccname = TokenResult.GetLoginData("ccname"),
                    recnotes = txt_recnotes.Text,
                    recuser = txt_recuser.Text,
                    recdocimg=res,
                    paytypeid = EmaxGlobals.NullToIntZero(cmb_paytypeid.EditValue),
                    paytypename = cmb_paytypeid.Text,
                    paychartid = -1,
                    payref = txt_payref.Text,
                    fromchartid = EmaxGlobals.NullToIntZero(lbl_fromchartid.Text),
                    paynotes = txt_paynotes.Text,
                    rectype = EmaxGlobals.NullToIntZero(cmb_rectype.EditValue),
                    rectypename = cmb_rectype.Text,
                    custid = EmaxGlobals.NullToIntZero(lbl_custid.Text),
                    custname=txt_custname.Text

                    //recdocimg=,

                };
                var recjson = JObject.Parse(JsonConvert.SerializeObject(rec_Doc));

                return JsonConvert.SerializeObject(recjson);
            }
            else
            {

                return null;
            }
        }
        private void Inv_pos_ConnectionError(object sender, ConnectionErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Inv_pos_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            e.ConnectionParameters = new MsSqlConnectionParameters(ConfigurationManager.AppSettings["sever"], ConfigurationManager.AppSettings["dbname"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"], MsSqlAuthorizationType.SqlServer);
        }
        private void frm_recdoc_Load(object sender, EventArgs e)
        {
            txt_recdate.Text = DateTime.Now.ToShortDateString();
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_rectype, "compid,table_name", "16,sys_fillcomp", "citemid", "citemname");
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_paytypeid, "compid,table_name,model", "0,sys-paytype,2", "paytypeid", "paytname");
            cmb_rectype.ItemIndex = 0;
            cmb_paytypeid.ItemIndex = 0;
            this.KeyPreview = true;
            txt_recuser.Text = TokenResult.GetLoginData("username").ToString();
          lbl_fromchartid.Text= TokenResult.GetLoginData("advancedpaymentchartid").ToString();
          txt_fromchartid.Text= TokenResult.GetLoginData("advancedpaymentchartcode").ToString();
          txt_fromchartname.Text= TokenResult.GetLoginData("advancedpaymentchartname").ToString();


        }

        private void frm_recdoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btn_custsearch.PerformClick();

            }
            else if (e.KeyCode == Keys.End)
            {
                btn_Save.PerformClick();
            }
            else if (e.KeyCode == Keys.F1)
            {
                btn_recdoc_search.PerformClick();
            }
            else if (e.KeyCode == Keys.F5)
            {
                reprint.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btn_custsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_CustChart custChart = new Frm_CustChart();
                custChart.ShowDialog();
                txt_fromchartid.Text = custChart.chart_code;
                txt_fromchartname.Text = custChart.chart_name;
                lbl_fromchartid.Text = custChart.chart_id.ToString();
       
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_recvalue.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء ادخال المبلغ اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txt_fromchartid.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء ادخال حساب العميل اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                if (cmb_paytypeid.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء ادخال طريقه الدفع اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmb_rectype.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء ادخال نوع القبض اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
                RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/rec/addnewrecdoc");
                restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                var res = await ConvertToObject();
                if (res == null)
                {
                    XtraMessageBox.Show("تعذر تحميل الملف");
                    return;
                }
                restRequest.AddJsonBody(res);
                RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    string ReportPath = Application.StartupPath + @"\report\rec_doc_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                    XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                    string recid = JObject.Parse(restResponse.Content)["recid"].ToString();

                    ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                    ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                    var sub = xtraReport.AllControls<XRSubreport>();
                    xtraReport.Parameters["recid"].Value = recid;
                    for (int i = 0; i < EmaxGlobals.NullToNullInt(TokenResult.GetLoginData("printno")); i++)
                    {
                        xtraReport.Print();
                    }
                    clear();
                    txt_recdocno.Focus();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_recdoc_search_Click(object sender, EventArgs e)
        {
            try
            {
                frm_recdoc_search _Search = new frm_recdoc_search();
                _Search.ShowDialog();

                if (frm_recdoc_search.rec_search == null || frm_recdoc_search.rec_search.Table.Rows.Count == 0)
                {
                    return;
                }
                clear();
                txt_recno.Text = frm_recdoc_search.rec_search["recno"].ToString();
                txt_recdocno.Text = frm_recdoc_search.rec_search["recdocno"].ToString();
                txt_recdate.Text = Convert.ToDateTime(frm_recdoc_search.rec_search["recdate"].ToString()).ToShortDateString();
                txt_recvalue.Text = frm_recdoc_search.rec_search["recvalue"].ToString();
                txt_recnotes.Text = frm_recdoc_search.rec_search["recnotes"].ToString();
                txt_payref.Text = frm_recdoc_search.rec_search["payref"].ToString();
                txt_paynotes.Text = frm_recdoc_search.rec_search["paynotes"].ToString();
                cmb_paytypeid.EditValue = frm_recdoc_search.rec_search["paytypeid"].ToString();
                cmb_paytypeid.Text = frm_recdoc_search.rec_search["paytypename"].ToString();
                cmb_rectype.EditValue = frm_recdoc_search.rec_search["rectype"].ToString();
                cmb_rectype.Text = frm_recdoc_search.rec_search["rectypename"].ToString(); 
               lbl_recid.Text= frm_recdoc_search.rec_search["recid"].ToString();
                lbl_fromchartid.Text = frm_recdoc_search.rec_search["fromchartid"].ToString();
                txt_fromchartid.Text= frm_recdoc_search.rec_search["chartcode"].ToString();
                txt_fromchartname.Text= frm_recdoc_search.rec_search["chartname"].ToString();
                lbl_custid.Text= frm_recdoc_search.rec_search["custid"].ToString();
                txt_custname.Text= frm_recdoc_search.rec_search["custname"].ToString();
                pictureEdit1.Text = frm_recdoc_search.rec_search["recdocimg"].ToString();
                int post= EmaxGlobals.NullToIntZero( frm_recdoc_search.rec_search["postacc"]);
                if (post == 1)
                {
                    lbl_postacc.Text = "مرحل حسابات";
                }
                else 
                {
                    lbl_postacc.Text = " ";
                }
                frm_recdoc_search.rec_search = null;
                btn_delete.Enabled = false;
                btn_Save.Enabled = false;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            clear();
            btn_Save.Enabled = true;
            btn_delete.Enabled = true;
        }

        private void reprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_recno.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء اختيار  السند اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string ReportPath = Application.StartupPath + @"\report\rec_doc_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                int recid = EmaxGlobals.NullToIntZero(lbl_recid.Text);

                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["recid"].Value = recid;
                // xtraReport.Parameters["reprint"].Value = "نسخه من فاتوره";
                foreach (XRSubreport item in sub)
                {

                    ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;
                    item.ReportSource = XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;

                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConnectionError += Inv_pos_ConnectionError;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;

                }


                xtraReport.Print();

                clear();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result = xtraOpenFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                //Do whatever you want
                //openFileDialog1.FileName .....
                pictureEdit1.Text = xtraOpenFileDialog1.FileName;
           
              //  xtraOpenFileDialog1.InitialDirectory = Application.StartupPath + @"\report\" + pictureEdit1.Text;
            }
        }
        private async Task<string> UploadAsync(string filepath, string url, string uploadtime)
        {
            if (filepath.Length==0)
            {
                return "";
            }
            string value = "";
            using (var fileStream = File.Open(filepath, FileMode.Open))
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);
                    request.AddFile("file", memoryStream.ToArray(), Path.GetFileName(filepath).Split('.')[0] + uploadtime + Path.GetExtension(filepath));
                    request.AlwaysMultipartFormData = true;

                    var result = await client.ExecuteAsync(request);// client.ExecuteAsync(request, (response, handle) =>
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        value = JObject.Parse(result.Content)["Data"].ToString();

                    }

                    //{
                    //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    //    {
                    //        dynamic json = JsonConvert.DeserializeObject(response.Content);
                    //        value = json.fileName;
                    //    }
                    //});
                }
            }
            return value;
        }

        private void btn_AddCust_Click(object sender, EventArgs e)
        {
            FrmAddCust addCust = new FrmAddCust();
            addCust.ShowDialog();
          //  txt_fromchartname.Text = addCust.cus_name;
          //txt_fromchartid.Text=  addCust.chartcode;
            //lbl_fromchartid.Text = addCust.chartid;
            txt_custname.Text = addCust.cus_name;
            lbl_custid.Text = addCust.cus_code;
        }
    }
}