using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
//using Emax.CoreCore;
using Emax.SharedLib;
using Emax.Dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VanSales.POS.Models;
using DevExpress.XtraGrid.Views.Grid;

namespace VanSales.POS
{
    public partial class rtninv_pay : DevExpress.XtraEditors.XtraForm
    {
        public rtninv_pay()
        {
            InitializeComponent();
        }
        string mastr_data;
        decimal valuespechail = 0;
        public rtninv_pay(string jobject, Frm_Rtn_Inv rtninv)
        {

            InitializeComponent();

            mastr_data = jobject;

            txt_total.Text = rtninv.txt_netavat.Text;
            txt_rest.Text = txt_total.Text;

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
        public void Paying(int index)
        {
            try
            {
                if (index == 0)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)

                    {

                        DataRow row1 = gridView1.GetDataRow(i);
                        if (row1["paytypeid"].ToString() != "9")

                        {
                            gridView1.SetRowCellValue(i, "value", "0.0");
                            row1["value"] = "0.0";
                            valuespechail = EmaxGlobals.NullToZero(txt_paid.Text);
                        }


                    }


                }
                else if (index == 2)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)

                    {

                        DataRow row1 = gridView1.GetDataRow(i);
                        if (row1["paytypeid"].ToString() != "9")

                        {
                            gridView1.SetRowCellValue(i, "value", "0.0");
                            row1["value"] = "0.0";
                            valuespechail = EmaxGlobals.NullToZero(txt_paid.Text);
                        }

                    }

                }
                System.Data.DataRow row = gridView1.GetDataRow(index);
                row["value"] = EmaxGlobals.NullToZero(txt_total.Text) - valuespechail;
                valuespechail = 0;
                // row["value"] = txt_total.Text;
                //lblinvpaid.Text = row[4].ToString();
                txt_paid.Text = gridView1.Columns["value"].SummaryItem.SummaryValue.ToString();
                decimal rest = EmaxGlobals.NullToZero(txt_paid.Text) - EmaxGlobals.NullToZero(txt_total.Text);
                txt_rest.Text = rest.ToString();
                //this.gridView1.FocusedRowHandle = index;
                //System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                //row["value"] = txt_total.Text;
                ////lblinvpaid.Text = row[4].ToString();
                //txt_paid.Text = gridView1.Columns["value"].SummaryItem.SummaryValue.ToString();
                //decimal rest = EmaxGlobals.NullToZero(txt_paid.Text) - EmaxGlobals.NullToZero(txt_total.Text);
                //txt_rest.Text = rest.ToString();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void delete()
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)

                {
                    gridView1.SetRowCellValue(i, "value", "0.0");
                    DataRow row = gridView1.GetDataRow(i);
                    row["value"] = "0.0";

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //// isescape = true;
        }
        void calac_value()
        {

            int row = gridView1.FocusedRowHandle;
            decimal value = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "value"));

            gridView1.SetRowCellValue(row, "Value", value);

            gridView1.UpdateCurrentRow();
            try
            {
                txt_paid.Text = gridView1.Columns["value"].SummaryItem.SummaryValue.ToString();
            }
            catch { }
            txt_rest.Text = (EmaxGlobals.NullToZero(txt_total.Text) - EmaxGlobals.NullToZero(txt_paid.Text)).ToString();


        }
        void SavePayMent()
        {
            try
            {
                if (EmaxGlobals.NullToZero(txt_total.Text) > EmaxGlobals.NullToZero(txt_paid.Text))
                {
                    XtraMessageBox.Show("اجمالى المبلغ المدفوع اقل من قيمة الفاتورة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    var invslst = JsonConvert.DeserializeObject<s_invs>(mastr_data);
                    if (EmaxGlobals.NullToZero(txt_paid.Text) >= EmaxGlobals.NullToZero(txt_total.Text))
                    {
                        invslst.restvalue = 0;
                    }
                    invslst.s_invpay = new List<s_invpays>();
                    //  { //new s_invpays() { paytype = invslst.sinvpay, payvalue = EmaxGlobals.NullToZero(txt_paid.Text), payno = DBNull.Value.ToString(), payref = DBNull.Value.ToString(), paychartid=-1,branchid= Emax.SharedLib.EmaxGlobals.NullToNullInt( TokenResult.GetLoginData("branchid")) } };
                    for (int i = 0; i < gridView1.RowCount; i++)

                    {

                        DataRow row = gridView1.GetDataRow(i);
                        if (row["value"].ToString() == "0.0")
                        {
                            continue;
                        }
                        invslst.s_invpay.Add(new s_invpays
                        {
                            paytype = EmaxGlobals.NullToNullInt(row["paytypeid"]),
                            payvalue = EmaxGlobals.NullToZero(row["value"]),
                            payno = DBNull.Value.ToString(),
                            payref = DBNull.Value.ToString(),
                            paychartid = -1,
                            branchid = EmaxGlobals.NullToNullInt(TokenResult.GetLoginData("branchid"))
                        });
                    }

                    var all_list = JsonConvert.SerializeObject(invslst);
                    RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
                    RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addnewrtninv");
                    restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                    restRequest.AddHeader("compvatno", TokenResult.GetLoginData("compvatno").ToString());
                    restRequest.AddJsonBody(all_list);
                    RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                    if (restResponse.StatusCode == HttpStatusCode.OK)
                    {


                        string ReportPath = Application.StartupPath + @"\report\s_rtn_inv_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                        XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                        string sinvid = JObject.Parse(restResponse.Content)["sinvid"].ToString();
                        string qrdata = JObject.Parse(restResponse.Content)["qrdata"].ToString();
                        ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                        ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                        var sub = xtraReport.AllControls<XRSubreport>();
                        xtraReport.Parameters["sinvid"].Value = sinvid;
                        xtraReport.Parameters["qrdata"].Value = qrdata;
                        foreach (XRSubreport item in sub)
                        {

                            ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;
                            item.ReportSource = XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;

                            ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConnectionError += Inv_pos_ConnectionError;
                            ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;

                        }
                        for (int i = 0; i < EmaxGlobals.NullToNullInt(TokenResult.GetLoginData("printno")); i++)
                        {
                            xtraReport.Print();
                        }
                        this.Close();
                    }
                    else
                    {
                        var res = JObject.Parse(restResponse.Content);
                        string msg = EmaxGlobals.NullToEmpty(res["Message"]);
                        XtraMessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void rtninv_pay_Load(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("table_name", "sys-paytype");
            dict.Add("compid", 0);
            dict.Add("model", "5");
            var res = SqlCommandHelper.ExcecuteToDataTable("sys_fillcomp_sel", dict, true);
            gridControl1.DataSource = res.dataTable;
            this.KeyPreview = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SavePayMent();
        }

        private void btn_visa_Click(object sender, EventArgs e)
        {
            Paying(2);
        }

        private void btn_cach_Click(object sender, EventArgs e)
        {
            Paying(0);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            delete();
        }
        public static bool isescape;
        private void rtninv_pay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                SavePayMent();

            }
            else if (e.KeyCode == Keys.Escape)
            {
                isescape = true;
                this.Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                btn_cach.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btn_visa.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btn_delete.PerformClick();
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            calac_value();
        }

        private void gridControl1_EditorKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    int rows = gridView1.FocusedRowHandle;
                    gridView1.FocusedRowHandle = rows + 1;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}