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
    public partial class inv_pay : DevExpress.XtraEditors.XtraForm
    {
        public inv_pay()
        {
            InitializeComponent();
        }
        //public inv_pay(Inv_pos inv_Pos)
        //{

        //    InitializeComponent();

        //    var mastr = inv_Pos.ConvertToObject();
        //}
        //JObject _jobject;
        //public inv_pay(JObject jobject)
        //{

        //    InitializeComponent();
        //    _jobject = jobject;
        //}
        string mastr_data;
        decimal valuespechail = 0;
        public inv_pay(string jobject, frm_invpos inv_Pos)
        {

            InitializeComponent();

            mastr_data = jobject;

            txt_total.Text = inv_Pos.txt_netavat.Text;
            txt_rest.Text = txt_total.Text;
            RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
            // RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addcust");
            restRequest.AddParameter("custid", inv_Pos.txt_custid.Text);
            RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/Rec/GetCustRecBalanceData");


            RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {

                lbl_custbalnce.Text = JObject.Parse(restResponse.Content)["Data"][0]["balnce"].ToString();
                lbl_recno.Text = JObject.Parse(restResponse.Content)["Data"][0]["recno"].ToString();
                lbl_recvalue.Text = JObject.Parse(restResponse.Content)["Data"][0]["recvalue"].ToString();
             
                
            }
        }
        //public inv_pay(string jobject, Frm_Rtn_Inv rtninv)
        //{

        //    InitializeComponent();

        //    mastr_data = jobject;

        //    txt_total.Text = rtninv.txt_netavat.Text;
        //    txt_rest.Text = txt_total.Text;

        //}
        public void Paying(int index)
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
        void custrecbalance()
        {
           
        }
        private void inv_pay_Load(object sender, EventArgs e)
        {
            // this.ControlBox = false;

            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("table_name", "sys-paytype");
            dict.Add("compid", 0);
            dict.Add("model", "5");
            var res = SqlCommandHelper.ExcecuteToDataTable("sys_fillcomp_sel", dict, true);
            gridControl1.DataSource = res.dataTable;
            this.KeyPreview = true;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow row = gridView1.GetDataRow(i);
                if (row["paytypeid"].ToString() == "9")
                {
                    row["value"] = lbl_custbalnce.Text;
                  decimal payedfromrev= EmaxGlobals.NullToZero( gridView1.Columns["value"].SummaryItem.SummaryValue.ToString());
                    txt_paid.Text = payedfromrev.ToString();
                    decimal rest = EmaxGlobals.NullToZero(txt_paid.Text) - EmaxGlobals.NullToZero(txt_total.Text);
                    txt_rest.Text = rest.ToString();
                }

            }
            //gridView1.FocusedRowHandle = 0;
            //gridView1.FocusedColumn = gridView1.VisibleColumns[2];
            //gridView1.ShowEditor();
            //  gridView1.Focus();
            //  gridView1.FocusedColumn =gridView1.Columns["value"];
            //   gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            ////   gridView1.ShowEditorByKey(Keys.Enter);
            //   gridView1.ShowEditor();

            //gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
            //{
            //    Caption = "value",
            //    ColumnEdit = new RepositoryItemTextEdit() { },
            //    VisibleIndex = 0,
            //    FieldName = "value",
            //    UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            //});  
            //int dataRowCount = gridView1.DataRowCount;
            //// Traverse data rows and change the Price field values. 
            //for (int i = 0; i < dataRowCount; i++)
            //{

            //    // int row = gridView1.FocusedRowHandle;
            //    gridView1.SetRowCellValue(i, "المبلغ", 1);
            //    //txt_paid.Text = gridView1.Columns["payvalue"].SummaryItem.SummaryValue.ToString();
            //}


        }





        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            //int row = gridView1.FocusedRowHandle;
            //decimal value = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "value"));
            //gridView1.SetRowCellValue(row, "value", value);
            //try
            //{
            //    txt_paid.Text = gridView1.Columns["value"].SummaryItem.SummaryValue.ToString();
            //}
            //catch { }
            //txt_rest.Text = (EmaxGlobals.NullToZero(txt_total.Text) - EmaxGlobals.NullToZero(txt_paid.Text)).ToString();
        }

        private void gridControl1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            //GridView edit = sender as GridView;
            //edit.SelectCell(0, gridView1.Columns["value"]);
            //TextEdit edit = sender as TextEdit;
            //edit.SelectAll();
            // gridView1.FocusedRowHandle = 0;
            //gridView1.FocusedColumn = gridView1.VisibleColumns[2];
            //gridView1.ShowEditor();

            //if (e.KeyCode == Keys.Enter)
            //{
            //    int rows = gridView1.FocusedRowHandle;
            //    gridView1.FocusedRowHandle = rows + 1;
            //}


        }
        void SavePayMent()
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
                    if (row["value"].ToString() == "0.0" || row["value"].ToString() == "0" || row["value"].ToString() == "0.00")
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
                RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addnewinv");
                restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                restRequest.AddHeader("compvatno", TokenResult.GetLoginData("compvatno").ToString());
                restRequest.AddJsonBody(all_list);
                RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {

                 
                    string ReportPath = Application.StartupPath + @"\report\s_inv_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                    XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                    string sinvid = JObject.Parse(restResponse.Content)["sinvid"].ToString();
                    string qrdata= JObject.Parse(restResponse.Content)["qrdata"].ToString();
                    ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;
                    ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError;
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
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SavePayMent();
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
        public static bool isescape;
        private void inv_pay_KeyDown(object sender, KeyEventArgs e)
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



        private void btn_cach_Click(object sender, EventArgs e)
        {
            Paying(0);
           // SavePayMent();
        }

        private void btn_visa_Click(object sender, EventArgs e)
        {
            Paying(2);
           // SavePayMent();
        }
        void delete()
        {
            for (int i = 0; i < gridView1.RowCount; i++)

            {
                gridView1.SetRowCellValue(i, "value", "0.0");
                DataRow row = gridView1.GetDataRow(i);
                row["value"] = "0.0";

            }
            //// isescape = true;
        }


        private void btn_delete_Click(object sender, EventArgs e)
        {

            delete();
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
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            calac_value();
        }

        private void gridControl1_EditorKeyUp(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {

                int rows = gridView1.FocusedRowHandle;
                gridView1.FocusedRowHandle = rows + 1;
            }
            //if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            //{
            //    int row = gridView1.FocusedRowHandle;
            //    decimal value = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "value"));
            //    gridView1.SetRowCellValue(row, "value", value);
            //}
        }
    }
}