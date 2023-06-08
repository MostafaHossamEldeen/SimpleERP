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
    public partial class frm_paydoc : DevExpress.XtraEditors.XtraForm
    {
        public frm_paydoc()
        {
            InitializeComponent();
        }
      
       void clear()
        {
            txt_paidchartid.Text = string.Empty;
            txt_paidchartname.Text = string.Empty;
            txt_paynotes.Text = string.Empty;
            txt_payref.Text = string.Empty;
            //txt_recdate.Text = string.Empty;
            txt_pddocno.Text = string.Empty;
            txt_pdno.Text = string.Empty;
            txt_pdnotes.Text = string.Empty;
            // txt_recuser.Text = string.Empty;
            txt_pdbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_pdavat.Text = "0";
            cmb_paytypeid.Text = string.Empty;
            cmb_paytypeid.EditValue = null;
            cmb_paidtype.Text = string.Empty;
            cmb_paidtype.EditValue = null;
            cmb_paytypeid.ItemIndex = 0;
            cmb_paidtype.ItemIndex = 0;
            lbl_paidchartid.Text = string.Empty;
            lbl_pdid.Text = string.Empty;
            lbl_postacc.Text = " ";
            rdo_vattype.SelectedIndex = 0;
            pictureEdit1.Text = string.Empty;

        }

    async   Task<string>  ConvertToObject()
        {
            var res = await UploadAsync(xtraOpenFileDialog1.FileName, ConfigurationManager.AppSettings["apiroot"] + "/VanSalesService/Pay/UploadFiles", DateTime.Now.Ticks.ToString());
            if (res.Length != 0 || (res.Length == 0 && xtraOpenFileDialog1.FileName.Length == 0))
            {
               // XtraMessageBox.Show("Uploaded ddone");
          
            pay_doc pay_Doc = new pay_doc
            {
                pddocno = txt_pddocno.Text,
                pdbranchid = EmaxGlobals.NullToIntZero(TokenResult.GetLoginData("branchid")),
                branchname = TokenResult.GetLoginData("branchname").ToString(),
                pddate = Convert.ToDateTime(txt_pddate.Text),
                pdman = DBNull.Value.ToString(),
                vatvalue = EmaxGlobals.NullToZero(txt_vatvalue.Text),
                pdavat = EmaxGlobals.NullToZero(txt_pdavat.Text),
                pdbvat = EmaxGlobals.NullToZero(txt_pdbvat.Text),
                vattype = EmaxGlobals.NullToIntZero(rdo_vattype.Properties.Items[rdo_vattype.SelectedIndex].Value),
                vattypename = rdo_vattype.Properties.Items[rdo_vattype.SelectedIndex].AccessibleName,
                ccid = EmaxGlobals.NullToIntZero(TokenResult.GetLoginData("ccid")),
                ccname = TokenResult.GetLoginData("ccname"),
                pdnotes = txt_pdnotes.Text,
                pduser = txt_pduser.Text,
                paytypeid = EmaxGlobals.NullToIntZero(cmb_paytypeid.EditValue),
                paytypename = cmb_paytypeid.Text,
                paychartid = -1,
                pddocimg = res,
                payref = txt_payref.Text,
                paidchartid = EmaxGlobals.NullToIntZero(lbl_paidchartid.Text),
                paynotes = txt_paynotes.Text,
                paidtype = EmaxGlobals.NullToIntZero(cmb_paidtype.EditValue),
                paidtypename = cmb_paidtype.Text
                //recdocimg=,

            };
            var payjson = JObject.Parse(JsonConvert.SerializeObject(pay_Doc));

            return JsonConvert.SerializeObject(payjson);
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
        private void frm_paydoc_Load(object sender, EventArgs e)
        {
            txt_pddate.Text = DateTime.Now.ToShortDateString();
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_paidtype, "compid,table_name", "17,sys_fillcomp", "citemid", "citemname");
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_paytypeid, "compid,table_name,model", "0,sys-paytype,2", "paytypeid", "paytname");
            cmb_paidtype.ItemIndex = 0;
            cmb_paytypeid.ItemIndex = 0;
            rdo_vattype.SelectedIndex = 0;
            this.KeyPreview = true;
          lbl_vat.Text=   TokenResult.GetLoginData("vat").ToString();
            layoutControlItem14.Text = " الضريبه" + lbl_vat.Text.Replace(".00","")+"%";
            simpleLabelItem5.Text= " Vat Value" + lbl_vat.Text.Replace(".00", "") + "%";
            txt_pduser.Text = TokenResult.GetLoginData("username").ToString();
        }

        private void btn_custsearch_Click(object sender, EventArgs e)
        {
            try
            {
               // UploadAsync("", "");
                Frm_CustChart custChart = new Frm_CustChart();
                custChart.ShowDialog();
                txt_paidchartid.Text = custChart.chart_code;
                txt_paidchartname.Text = custChart.chart_name;
                lbl_paidchartid.Text = custChart.chart_id.ToString();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frm_paydoc_KeyDown(object sender, KeyEventArgs e)
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
                btn_paydoc_search.PerformClick();
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

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pdavat.Text == string.Empty|| txt_pdbvat.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء ادخال المبلغ اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
                if (txt_paidchartid.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء ادخال حساب المدفوع له اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
                RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/pay/addnewpaydoc");
                restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                var res = await ConvertToObject();
                if (res==null)
                {
                    XtraMessageBox.Show("تعذر تحميل الملف");
                    return;
                }
                restRequest.AddJsonBody(res);
                RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    string ReportPath = Application.StartupPath + @"\report\pay_doc_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                    XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                    string pdid = JObject.Parse(restResponse.Content)["pdid"].ToString();

                    ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                    ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                    var sub = xtraReport.AllControls<XRSubreport>();
                    xtraReport.Parameters["pdid"].Value = pdid;
                    for (int i = 0; i < EmaxGlobals.NullToNullInt(TokenResult.GetLoginData("printno")); i++)
                    {
                        xtraReport.Print();
                    }
                    clear();
                    txt_pddocno.Focus();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task<string> UploadAsync(string filepath, string url,string uploadtime)
        {
            if (filepath.Length == 0)
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
                    request.AddFile("file", memoryStream.ToArray(),Path.GetFileName(filepath).Split('.')[0]+ uploadtime + Path.GetExtension(filepath));
                    request.AlwaysMultipartFormData = true;

                    var result =await client.ExecuteAsync(request);// client.ExecuteAsync(request, (response, handle) =>
                    if (result.StatusCode==HttpStatusCode.OK)
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
        private void btn_paydoc_search_Click(object sender, EventArgs e)
        {
            try
            {
                frm_paydoc_search _Search = new frm_paydoc_search();
                _Search.ShowDialog();

                if (frm_paydoc_search.rec_search == null || frm_paydoc_search.rec_search.Table.Rows.Count == 0)
                {
                    return;
                }
                clear();
                txt_pdno.Text = frm_paydoc_search.rec_search["pdno"].ToString();
                txt_pddocno.Text = frm_paydoc_search.rec_search["pddocno"].ToString();
                txt_pddate.Text = Convert.ToDateTime(frm_paydoc_search.rec_search["pddate"].ToString()).ToShortDateString();
                rdo_vattype.SelectedIndex = 0;
                rdo_vattype.Properties.Items[rdo_vattype.SelectedIndex].Value = frm_paydoc_search.rec_search["vattype"];
                rdo_vattype.Properties.Items[rdo_vattype.SelectedIndex].AccessibleName = frm_paydoc_search.rec_search["vattypename"].ToString();
                rdo_vattype.SelectedIndex = EmaxGlobals.NullToIntZero(rdo_vattype.Properties.Items[rdo_vattype.SelectedIndex].Value) - 1;
                txt_vatvalue.Text = frm_paydoc_search.rec_search["vatvalue"].ToString();
                txt_pdbvat.Text = frm_paydoc_search.rec_search["pdbvat"].ToString();
                txt_pdavat.Text = frm_paydoc_search.rec_search["pdavat"].ToString();
                txt_pdnotes.Text = frm_paydoc_search.rec_search["pdnotes"].ToString();
                txt_payref.Text = frm_paydoc_search.rec_search["payref"].ToString();
                txt_paynotes.Text = frm_paydoc_search.rec_search["paynotes"].ToString();
                cmb_paytypeid.EditValue = frm_paydoc_search.rec_search["paytypeid"].ToString();
                cmb_paytypeid.Text = frm_paydoc_search.rec_search["paytypename"].ToString();
                cmb_paidtype.EditValue = frm_paydoc_search.rec_search["paidtype"].ToString();
                cmb_paidtype.Text = frm_paydoc_search.rec_search["paidtypename"].ToString();
                lbl_pdid.Text = frm_paydoc_search.rec_search["pdid"].ToString();
                lbl_paidchartid.Text = frm_paydoc_search.rec_search["paidchartid"].ToString();
                txt_paidchartid.Text = frm_paydoc_search.rec_search["chartcode"].ToString();
                txt_paidchartname.Text = frm_paydoc_search.rec_search["chartname"].ToString();
                pictureEdit1.Text = frm_paydoc_search.rec_search["pddocimg"].ToString();
                int post = EmaxGlobals.NullToIntZero(frm_paydoc_search.rec_search["postacc"]);

                if (post == 1)
                {
                    lbl_postacc.Text = "مرحل حسابات";
                }
                else
                {
                    lbl_postacc.Text = " ";
                }
                frm_paydoc_search.rec_search = null;
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
            btn_delete.Enabled = true;
            btn_Save.Enabled = true;
            txt_pdbvat.Text = "0";
            txt_pdavat.Text = "0";
             
        }

        private void reprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_pdno.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء اختيار  السند اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string ReportPath = Application.StartupPath + @"\report\pay_doc_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                int pdid = EmaxGlobals.NullToIntZero(lbl_pdid.Text);

                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["pdid"].Value = pdid;
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

        private void rdo_vattype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdo_vattype.SelectedIndex == 0)
            {

                txt_pdbvat.Enabled = false;
                txt_pdavat.Enabled = true;
                txt_pdbvat.Text = "0";
            }
            else if (rdo_vattype.SelectedIndex == 1)
            {
                txt_pdavat.Enabled = false;
                txt_pdbvat.Enabled = true;
                txt_pdavat.Text = "0";
            }
            else if (rdo_vattype.SelectedIndex == 2)
            {
                txt_pdavat.Enabled = true;
                txt_pdbvat.Enabled = true;
                txt_vatvalue.Text = "0";
               
                txt_pdavat.Text = txt_pdbvat.Text;
            }
        }

        private void txt_pdbvat_EditValueChanged(object sender, EventArgs e)
        {
            if (rdo_vattype.SelectedIndex == 1)
            {
                txt_vatvalue.Text = Math.Round((EmaxGlobals.NullToZero(txt_pdbvat.Text) * (EmaxGlobals.NullToZero(lbl_vat.Text) / 100)),2).ToString();


                txt_pdavat.Text = Math.Round(EmaxGlobals.NullToZero(txt_vatvalue.Text) + EmaxGlobals.NullToZero(txt_pdbvat.Text),2).ToString();
                
            }
            else if(rdo_vattype.SelectedIndex == 0)
            {
                txt_vatvalue.Text = Math.Round(((EmaxGlobals.NullToZero(txt_pdavat.Text) * EmaxGlobals.NullToZero(lbl_vat.Text)) / (100+ EmaxGlobals.NullToZero(lbl_vat.Text))), 2).ToString();
                txt_pdbvat.Text = Math.Round( EmaxGlobals.NullToZero(txt_pdavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text),2).ToString();
                
            }
            else if(rdo_vattype.SelectedIndex == 2)
            {
                txt_vatvalue.Text = "0";
                if (txt_pdbvat.Text != "0")
                {
                   
                    txt_pdavat.Text = txt_pdbvat.Text;
                }
                else if (txt_pdavat.Text != "0")
                {
                  
                    txt_pdbvat.Text = txt_pdavat.Text;
                }

            }
        }

        private  void pictureEdit1_Click(object sender, EventArgs e)
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
    }
}