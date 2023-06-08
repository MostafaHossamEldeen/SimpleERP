using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emax.SharedLib;
using Emax.Dal;
using Repository.Ado;
using Emax.Core.Utility;
using DevExpress.XtraGrid.Views.Grid;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using VanSales.POS.Models;
using System.Configuration;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;

namespace VanSales.POS
{
    public partial class Frm_Rtn_Inv : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Rtn_Inv()
        {
            InitializeComponent();
            if (TokenResult.GetLoginData("sprice").ToString() == "True") //شركه الاحساس
            {
                gridView1.Columns["price"].OptionsColumn.AllowEdit = true;
                gridView1.Columns["price"].OptionsColumn.AllowFocus = true;
            }
            else
            {
                gridView1.Columns["price"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["price"].OptionsColumn.AllowFocus = false;
            }
        }
        decimal vat;
        void additmgrid(DsPos.s_invdtls_selDataTable dt, DataRow res)
        {

            if (res == null)
            {
                return;
            }

            var rec = ((DsPos.s_invdtls_selDataTable)dt).News_invdtls_selRow();
            // dt.ImportRow(res.dataTable.Rows[0]);
            // rec.itembarcode = txt_barcode.Text;
            vat = 0;
            rec.itemname = EmaxGlobals.NullToEmpty(res["itemname"]);
            rec.price = EmaxGlobals.NullToZero(res["fprice"]);
            rec.qty = 1;
            rec.itemid = EmaxGlobals.NullToIntZero(res["itemid"]);
            rec.unitid = EmaxGlobals.NullToIntZero(res["unitid"]);
            rec.factor = EmaxGlobals.NullToIntZero(res["factor"]);
            rec.itemcode = txt_barcode.Text;
            if (txt_barcode.Text == "")
            {
                rec.itemcode = EmaxGlobals.NullToEmpty(res["itemcode"]);
            }
            if (res["itemcode"].ToString() != txt_barcode.Text)
            {
                rec.itemcode = EmaxGlobals.NullToEmpty(res["itemcode"]);
            }
            rec.value = EmaxGlobals.NullToZero(rec.price * rec.qty);

            rec.discvalue = 0;

            rec.netvalue = EmaxGlobals.NullToZero(rec.value - rec.discvalue);
            if (TokenResult.GetLoginData("vattype").ToString() == "1") ///// شامل الضريبه 1
            {
                rec.vatvalue = Math.Round(((EmaxGlobals.NullToZero(rec.netvalue) * EmaxGlobals.NullToZero(res["vat"])) / (100 + EmaxGlobals.NullToZero(res["vat"]))), 2);
            }
            else if (TokenResult.GetLoginData("vattype").ToString() == "2")
            {
                rec.vatvalue = Math.Round((EmaxGlobals.NullToZero(rec.netvalue) * (EmaxGlobals.NullToZero(res["vat"]) / 100)), 2);
            }
            else if (TokenResult.GetLoginData("vattype").ToString() == "3")
            {
                rec.vatvalue = 0;
            }

            // rec.vatvalue = (EmaxGlobals.NullToZero(rec.netvalue) * EmaxGlobals.NullToZero(res["vat"])) / (100 + EmaxGlobals.NullToZero(res["vat"]));
            vat = EmaxGlobals.NullToZero(res["vat"]);

            dt.Adds_invdtls_selRow(rec);
            calac();
            clac_qty_disc();

        }
        void additmgrid_search(DsPos.s_invdtls_selDataTable dt, DataRow res)
        {
            if (res == null)
            {
                return;
            }
            var rec = ((DsPos.s_invdtls_selDataTable)dt).News_invdtls_selRow();
            // dt.ImportRow(res.dataTable.Rows[0]);
            // rec.itembarcode = txt_barcode.Text;

            rec.itemname = EmaxGlobals.NullToEmpty(res["itemname"]);
            rec.price = EmaxGlobals.NullToZero(res["price"]);
            rec.qty = EmaxGlobals.NullToZero(res["qty"]);
            rec.itemid = EmaxGlobals.NullToIntZero(res["itemid"]);
            rec.unitid = EmaxGlobals.NullToIntZero(res["unitid"]);
            rec.factor = EmaxGlobals.NullToIntZero(res["factor"]);
            rec.itemcode = txt_barcode.Text;
            if (txt_barcode.Text == "")
            {
                rec.itemcode = EmaxGlobals.NullToEmpty(res["itemcode"]);
            }
            if (EmaxGlobals.NullToZero(res["value"]) == 0)
            {
                rec.value = EmaxGlobals.NullToZero(rec.price * rec.qty);
            }
            else
            {
                rec.value = EmaxGlobals.NullToZero(res["value"]);
            }

            if (EmaxGlobals.NullToZero(res["discvalue"]) == 0)
            {
                rec.discvalue = 0;
            }
            else
            {
                rec.discvalue = EmaxGlobals.NullToZero(res["discvalue"]);
            }

            if (EmaxGlobals.NullToZero(res["netvalue"]) == 0)
            {
                rec.netvalue = EmaxGlobals.NullToZero(rec.value - rec.discvalue);
            }
            else
            {
                rec.netvalue = EmaxGlobals.NullToZero(res["netvalue"]);
            }

            //if (EmaxGlobals.NullToZero(res["vatvalue"]) == 0)
            //{
            //    rec.vatvalue = (EmaxGlobals.NullToZero(rec.netvalue) * EmaxGlobals.NullToZero(res["vat"])) / (100 + EmaxGlobals.NullToZero(res["vat"]));
            //    vat = EmaxGlobals.NullToZero(res["vat"]);
            //}
            //else
            //{
            rec.vatvalue = EmaxGlobals.NullToZero(res["vatvalue"].ToString());
            // }



            dt.Adds_invdtls_selRow(rec);

            //calac();


        }
        void calac()
        {
            try
            {

                if (TokenResult.GetLoginData("vattype").ToString() == "1") ///// شامل الضريبه 1
                {
                    txt_netavat.Text = gridView1.Columns["netvalue"].SummaryItem.SummaryValue.ToString();
                    txt_vatvalue.Text = gridView1.Columns["vatvalue"].SummaryItem.SummaryValue.ToString();

                    txt_netbvat.Text = Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();
                }

                else if (TokenResult.GetLoginData("vattype").ToString() == "2") /*غير شامل الضريبه*/
                {
                    txt_netbvat.Text = gridView1.Columns["netvalue"].SummaryItem.SummaryValue.ToString();
                    txt_vatvalue.Text = gridView1.Columns["vatvalue"].SummaryItem.SummaryValue.ToString();
                    txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();

                }
                else if (TokenResult.GetLoginData("vattype").ToString() == "3")
                {
                    txt_netbvat.Text = gridView1.Columns["netvalue"].SummaryItem.SummaryValue.ToString();
                    txt_vatvalue.Text = gridView1.Columns["vatvalue"].SummaryItem.SummaryValue.ToString();
                    txt_netavat.Text = gridView1.Columns["netvalue"].SummaryItem.SummaryValue.ToString();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        void clac_qty_disc()
        {
            //Dictionary<object, object> dict = new Dictionary<object, object>();
            //dict.Add("itemcode", "");
            //dict.Add("barcode1", txt_barcode.Text);
            //dict.Add("barcode2", txt_barcode.Text);
            //var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code", dict, true);
            int row = gridView1.FocusedRowHandle;
            decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
            decimal price = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "price"));
            gridView1.SetRowCellValue(row, "value", qty * price);
            decimal value = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "value"));
            decimal discvalue = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "discvalue"));
            gridView1.SetRowCellValue(row, "netvalue", value - discvalue);
            if (vat == 0)
            {
                vat = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "vat"));

            }
            if (TokenResult.GetLoginData("vattype").ToString() == "2") ///// شامل الضريبه 1
            {
                gridView1.SetRowCellValue(row, "vatvalue", Math.Round((EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "netvalue")) * (vat / 100)), 2));
            }
            else if (TokenResult.GetLoginData("vattype").ToString() == "1")
            {

                gridView1.SetRowCellValue(row, "vatvalue", Math.Round((EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "netvalue")) * vat / (100 + vat)), 2));
            }
            else if (TokenResult.GetLoginData("vattype").ToString() == "3")
            {
                gridView1.SetRowCellValue(row, "vatvalue", 0);
            }
            //EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"])
            //vat = EmaxGlobals.NullToZero(dataTable.Rows[0]["vat"]);
        }
        void clear()
        {
            txt_barcode.Text = string.Empty;
            txt_custid.Text = string.Empty;
            txt_custmobile.Text = string.Empty;
            txt_custname.Text = "نقدى";
            txt_custvat.Text = string.Empty;
            txt_netavat.Text = string.Empty;
            txt_netbvat.Text = string.Empty;
            txt_sinvno.Text = string.Empty;
            txt_rtnsinvno.Text = string.Empty;
            chk_rtnall.Checked = false;
            chk_withoutinv.Checked = false;
            txt_vatvalue.Text = string.Empty;
            rdo_sinvpay.SelectedIndex = 0;
            cmb_smanid.Text = string.Empty;
            cmb_smanid.EditValue = null;
            lbl_sinvid.Text = string.Empty;
            for (int i = 0; i < gridView1.RowCount;)
            {
                gridView1.DeleteRow(i);

            }

        }
        void inv_data()
        {

            txt_sinvno.Text = inv_search.rec_search["sinvno"].ToString();

            txt_custid.Text = inv_search.rec_search["custid"].ToString();
            txt_custname.Text = inv_search.rec_search["custname"].ToString();
            txt_custvat.Text = inv_search.rec_search["custvat"].ToString();
            txt_custmobile.Text = inv_search.rec_search["custmobile"].ToString();
            cmb_smanid.EditValue = inv_search.rec_search["smanid"].ToString();
            cmb_smanid.Text = inv_search.rec_search["smanname"].ToString();

            lbl_sinvid.Text = EmaxGlobals.NullToEmpty(inv_search.rec_search["sinvid"]);

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

        internal string ConvertToObject()
        {

            s_invs sinv = new s_invs
            {
                sinvdata = Convert.ToDateTime(txt_sinvdata.Text),
                sinvdocno = DBNull.Value.ToString(),
                sinvpay = EmaxGlobals.NullToIntZero(rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value),
                sinvpayname = rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Description,
                branchid = EmaxGlobals.NullToIntZero(TokenResult.GetLoginData("branchid")),
                branchname = TokenResult.GetLoginData("branchname").ToString(),
                custid = EmaxGlobals.NullToNullInt(txt_custid.Text),
                custname = txt_custname.Text,
                custvat = txt_custvat.Text,
                custmobile = txt_custmobile.Text,
                suser = txt_suser.Text,
                invid = EmaxGlobals.NullToNullInt(lbl_sinvid.Text),
                invno = EmaxGlobals.NullToEmpty(txt_sinvno.Text),
                netbvat = EmaxGlobals.NullToZero(txt_netbvat.Text),
                vatvalue = EmaxGlobals.NullToZero(txt_vatvalue.Text),
                netavat = EmaxGlobals.NullToZero(txt_netavat.Text),
                restvalue = EmaxGlobals.NullToZero(txt_netavat.Text),
                smanid = EmaxGlobals.NullToNullInt(cmb_smanid.EditValue),
                smanname = cmb_smanid.Text,
                invchk = 1,
                withoutinv = chk_withoutinv.Checked,
                compneyname = TokenResult.GetLoginData("compneyname"),
                s_invdtls = new List<s_invdtl>()
            };
            foreach (DataRow item in (gridControl1.DataSource as DataTable).Rows)
            {

                sinv.s_invdtls.Add(new s_invdtl
                {
                    itemid = EmaxGlobals.NullToNullInt(item["itemid"]),
                    unitid = EmaxGlobals.NullToNullInt(item["unitid"]),
                    qty = EmaxGlobals.NullToZero(item["qty"]),
                    price = EmaxGlobals.NullToZero(item["price"]),
                    value = EmaxGlobals.NullToZero(item["value"]),
                    discp = EmaxGlobals.NullToZero(item["discp"]),
                    discvalue = EmaxGlobals.NullToZero(item["discvalue"]),
                    netvalue = EmaxGlobals.NullToZero(item["netvalue"]),
                    vatvalue = EmaxGlobals.NullToZero(item["vatvalue"]),
                    factor = EmaxGlobals.NullToZero(item["factor"])
                });
            }
            //foreach (DsPos. item in (gridControl1.DataSource as DsPos.s_invdtls_selDataTable).Rows)
            //{
            //    Invs.s_invdtls.Add(new s_invdtl { icost = item.icost });
            //}
            var sinvjson = JObject.Parse(JsonConvert.SerializeObject(sinv));

            return JsonConvert.SerializeObject(sinvjson);



        }
        private void Frm_Rtn_Inv_Load(object sender, EventArgs e)
        {
            txt_sinvdata.Text = DateTime.Now.ToShortDateString();
            var dt = new DsPos.s_invdtls_selDataTable();
            gridControl1.DataSource = dt;
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman", "smanid", "smanname");
            cmb_smanid.ItemIndex = -1;
            this.KeyPreview = true;
            txt_suser.Text = TokenResult.GetLoginData("username").ToString();
            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            layoutControl1.OptionsFocus.AllowFocusControlOnLabelClick = true;
            layoutControl1.Focus();

            txt_barcode.Focus();

        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_barcode.Text == "+" || txt_barcode.Text == "-")
                {
                    txt_barcode.Text = "";
                    return;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    if (txt_sinvno.Text == string.Empty && chk_withoutinv.Checked == false)
                    {
                        XtraMessageBox.Show("برجاء اختيار بدون فاتوره او ادخال رقم اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txt_barcode.Text == string.Empty)
                    {
                        XtraMessageBox.Show("برجاء اختيار ادخال باركود الصنف اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("itemcode", txt_barcode.Text);
                    dict.Add("barcode1", txt_barcode.Text);
                    dict.Add("barcode2", txt_barcode.Text);
                    var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code_group", dict, true); //شركه الاحساس
                    //var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code", dict, true);
                    if (res.dataTable.Rows.Count == 0)
                    {
                        XtraMessageBox.Show("كود الصنف غير مسجل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    var dt = gridControl1.DataSource as DsPos.s_invdtls_selDataTable;
                    //var dt = new DsPos.s_invdtls_selDataTable();
                    //gridControl1.DataSource = dt;
                    var itemingrid = dt.Where(i => i.itemcode == txt_barcode.Text).FirstOrDefault();
                    if (itemingrid != null)
                    {
                        var msgres = XtraMessageBox.Show("لزياده الكميه Y لاضافه سطر جديد N", "inf", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (msgres == DialogResult.Yes || e.KeyCode == Keys.Y)
                        {
                            itemingrid.qty++;
                            itemingrid.value = EmaxGlobals.NullToZero(itemingrid.price * itemingrid.qty);
                            itemingrid.netvalue = EmaxGlobals.NullToZero(itemingrid.value - itemingrid.discvalue);
                            if (TokenResult.GetLoginData("vattype").ToString() == "1") ///// شامل الضريبه 1
                            {
                                itemingrid.vatvalue = Math.Round(((EmaxGlobals.NullToZero(itemingrid.netvalue) * EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"])) / (100 + EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"]))), 2);
                            }
                            else if (TokenResult.GetLoginData("vattype").ToString() == "2")
                            {
                                itemingrid.vatvalue = Math.Round((EmaxGlobals.NullToZero(itemingrid.netvalue) * (EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"]) / 100)), 2);
                            }
                            else if (TokenResult.GetLoginData("vattype").ToString() == "3")
                            {
                                itemingrid.vatvalue = 0;
                            }
                            // itemingrid.vatvalue = (EmaxGlobals.NullToZero(itemingrid.netvalue) * EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"])) / (100 + EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"]));
                            calac();
                        }
                        else
                        {
                            if (msgres == DialogResult.No || e.KeyCode == Keys.N)
                            {
                                additmgrid(dt, res.dataTable.Rows[0]);
                            }
                        }
                    }
                    else
                    {
                        additmgrid(dt, res.dataTable.Rows[0]);
                    }
                    this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;
                    txt_barcode.Text = string.Empty;


                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_barcodsearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_sinvno.Text == string.Empty && chk_withoutinv.Checked == false)
                {
                    XtraMessageBox.Show("برجاء اختيار بدون فاتوره او ادخال رقم اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frm_RtnItem_search frm_Items_Search = new frm_RtnItem_search(this);
                frm_Items_Search.ShowDialog();

                //gridControl1.DataSource = dt;
                if (frm_RtnItem_search.isescape == true)
                {
                    frm_RtnItem_search.isescape = false;
                    return;
                }
                frm_RtnItem_search.isescape = false;
                additmgrid(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, frm_RtnItem_search.rec);

                frm_items_search.rec = null;
                if (gridView1.RowCount > 0)
                    this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_custsearch_Click(object sender, EventArgs e)
        {
            try
            {
                frm_cus_search frm_Cus = new frm_cus_search();
                frm_Cus.ShowDialog();
                txt_custid.Text = frm_Cus.cus_code;
                txt_custname.Text = frm_Cus.cus_name;
                txt_custvat.Text = frm_Cus.cus_vat;
                txt_custmobile.Text = frm_Cus.cus_mobile;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_sinvno.Text == string.Empty && chk_withoutinv.Checked == false)
                {
                    XtraMessageBox.Show("برجاء اختيار بدون فاتوره او ادخال رقم اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (gridView1.RowCount == 0)
                {
                    XtraMessageBox.Show("لايوجد اصناف للحفظ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rdo_sinvpay.SelectedIndex == 1)
                {

                    using (var client = new HttpClient())
                    {
                        RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
                        RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addnewrtninv");
                        restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                        restRequest.AddHeader("compvatno", TokenResult.GetLoginData("compvatno").ToString());
                        restRequest.AddJsonBody(ConvertToObject());
                        RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                        if (restResponse.StatusCode == HttpStatusCode.OK)
                        {
                            string ReportPath = Application.StartupPath + @"\report\s_rtn_inv_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                            XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                            string sinvid = JObject.Parse(restResponse.Content)["sinvid"].ToString();
                            string qrdata = JObject.Parse(restResponse.Content)["qrdata"].ToString();
                            ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
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
                            clear();
                        }
                        else
                        {
                            var res = JObject.Parse(restResponse.Content);
                            string msg = EmaxGlobals.NullToEmpty(res["Message"]);
                            XtraMessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }


                }
                else
                {
                    if (txt_custname.Text == string.Empty)
                    {
                        XtraMessageBox.Show("برجاء ادخال اسم العميل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    rtninv_pay pay = new rtninv_pay(ConvertToObject(), this);
                    pay.ShowDialog();
                    if (!rtninv_pay.isescape == true)
                    {

                        clear();

                    }
                    rtninv_pay.isescape = false;

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int row = gridView1.FocusedRowHandle;
                gridView1.DeleteRow(row);
                calac();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                int row = gridView1.FocusedRowHandle;
                if (row < 0)
                {
                    XtraMessageBox.Show("لايوجد اصناف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) + 1);
                // clac_qty_disc();
                //  calac();
                txt_barcode.Text = string.Empty;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Subtract_Click(object sender, EventArgs e)
        {
            try
            {
                int row = gridView1.FocusedRowHandle;
                if (row < 0)
                {
                    XtraMessageBox.Show("لايوجد اصناف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                if (qty > 1)
                {
                    gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) - 1);
                    clac_qty_disc();
                    calac();
                    txt_barcode.Text = string.Empty;
                }
                else
                {
                    XtraMessageBox.Show("لايمكن ادخال الكميه صفر \n can not add Quantity zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridView1.SetRowCellValue(row, "qty", 1);
                    return;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridView1.Columns["qty"] || e.Column == gridView1.Columns["discvalue"] || e.Column == gridView1.Columns["price"])
                {

                    clac_qty_disc();
                    gridView1.UpdateCurrentRow();
                    calac();

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void gridControl1_EditorKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Add)
                {
                    //  btn_add.PerformClick();
                    int row = gridView1.FocusedRowHandle;
                    if (row < 0)
                    {
                        XtraMessageBox.Show("لايوجد اصناف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                    gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) + 1);
                    // clac_qty_disc();
                    //  calac();
                    txt_barcode.Text = string.Empty;
                }
                else if (e.KeyCode == Keys.Subtract)
                {
                    // btn_Subtract.PerformClick();
                    int row = gridView1.FocusedRowHandle;
                    if (row < 0)
                    {
                        XtraMessageBox.Show("لايوجد اصناف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                    if (qty > 1)
                    {
                        gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) - 1);
                        clac_qty_disc();
                        calac();
                        txt_barcode.Text = string.Empty;
                    }
                    else
                    {
                        XtraMessageBox.Show("لايمكن ادخال الكميه صفر \n can not add Quantity zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridView1.SetRowCellValue(row, "qty", 1);
                        return;
                    }
                }
                calac();
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

        private void chk_withoutinv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_withoutinv.Checked == true)
                {
                    txt_sinvno.Enabled = false;
                    chk_rtnall.Enabled = false;
                    chk_rtnall.Checked = false;
                    btn_inv_search.Enabled = false;
                    txt_sinvno.Text = string.Empty;
                    txt_custid.Text = string.Empty;
                    txt_custmobile.Text = string.Empty;
                    txt_custname.Text = "نقدى";
                    txt_custvat.Text = string.Empty;
                    lbl_sinvid.Text = string.Empty;
                    txt_barcode.Enabled = true;
                }
                else
                {
                    txt_sinvno.Enabled = true;
                    chk_rtnall.Enabled = true;
                    btn_inv_search.Enabled = true;
                    txt_barcode.Text = string.Empty;
                    txt_barcode.Enabled = false;


                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_inv_search_Click(object sender, EventArgs e)
        {
            try
            {
                inv_search _Search = new inv_search();
                _Search.ShowDialog();

                if (inv_search.rec_search == null || inv_search.rec_search.Table.Rows.Count == 0)
                {
                    return;
                }
                // additmgrid(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, inv_search.rec_search);
                txt_sinvno.Text = inv_search.rec_search["sinvno"].ToString();
                //txt_sinvdata.Text = Convert.ToDateTime(inv_search.rec_search["sinvdata"].ToString()).ToShortDateString();
                txt_custid.Text = inv_search.rec_search["custid"].ToString();
                txt_custname.Text = inv_search.rec_search["custname"].ToString();
                txt_custvat.Text = inv_search.rec_search["custvat"].ToString();
                txt_custmobile.Text = inv_search.rec_search["custmobile"].ToString();
                cmb_smanid.EditValue = inv_search.rec_search["smanid"].ToString();
                cmb_smanid.Text = inv_search.rec_search["smanname"].ToString();
                //rdo_sinvpay.SelectedIndex = 0;
                //rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value = inv_search.rec_search["sinvpay"];
                //rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].AccessibleName = inv_search.rec_search["sinvpayname"].ToString();
                //rdo_sinvpay.SelectedIndex = EmaxGlobals.NullToIntZero(rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value) - 1;
                //txt_netavat.Text = inv_search.rec_search["netavat"].ToString();
                //txt_netbvat.Text = inv_search.rec_search["netbvat"].ToString();
                //txt_vatvalue.Text = inv_search.rec_search["vatvalue"].ToString();
                lbl_sinvid.Text = EmaxGlobals.NullToEmpty(inv_search.rec_search["sinvid"]);
                //Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("sinvid", lbl_sinvid.Text);
                //var res = SqlCommandHelper.ExcecuteToDataTable("s_invdtls_sel", dict, true);
                //foreach (DataRow item in res.dataTable.Rows)
                //{
                //    additmgrid_search(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, item);
                //}

                inv_search.rec_search = null;

                if (gridView1.RowCount > 0)
                    this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;
                //  btn_delete.Enabled = false;
                //btn_Save.Enabled = false;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void chk_rtnall_Click(object sender, EventArgs e)
        {

        }

        private void chk_rtnall_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk_rtnall.Checked == true)
                {
                    if (lbl_sinvid.Text == string.Empty)
                    {
                        XtraMessageBox.Show("برجاء ارجاع بيانات الفاتوره اولا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
                    restRequest.AddParameter("invid", lbl_sinvid.Text);
                    RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/inv/Getrtnallitmsinv");
                    // restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                    //  restRequest.AddJsonBody(ConvertToObject());
                    RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                    if (restResponse.StatusCode == HttpStatusCode.OK)
                    {
                        var res = restResponse.Content;

                        var data = JObject.Parse(res);

                        var dataTable = JsonConvert.DeserializeObject<DataTable>(data["Data"].ToString());

                        gridControl1.DataSource = dataTable;

                    }
                    calac();
                }
                //else
                //{
                //    var msgres = XtraMessageBox.Show("هل تريد حذف الاصناف", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //    if (msgres == DialogResult.Yes)
                //    {
                //        for (int i = 0; i < gridView1.RowCount;)
                //        {
                //            gridView1.DeleteRow(i);

                //        }
                //        calac();
                //    }

                //}
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_rtninv_search_Click(object sender, EventArgs e)
        {
            try
            {
                frm_rtninv_search _Search = new frm_rtninv_search();
                _Search.ShowDialog();

                if (frm_rtninv_search.rec_search == null || frm_rtninv_search.rec_search.Table.Rows.Count == 0)
                {
                    return;
                }
                clear();
                txt_rtnsinvno.Text = frm_rtninv_search.rec_search["sinvno"].ToString();
                txt_sinvdata.Text = Convert.ToDateTime(frm_rtninv_search.rec_search["sinvdata"].ToString()).ToShortDateString();
                lbl_time.Text = Convert.ToDateTime(frm_rtninv_search.rec_search["sinvtime"].ToString()).ToLongTimeString();
                txt_custid.Text = frm_rtninv_search.rec_search["custid"].ToString();
                txt_custname.Text = frm_rtninv_search.rec_search["custname"].ToString();
                txt_custvat.Text = frm_rtninv_search.rec_search["custvat"].ToString();
                txt_custmobile.Text = frm_rtninv_search.rec_search["custmobile"].ToString();
                cmb_smanid.EditValue = frm_rtninv_search.rec_search["smanid"].ToString();
                cmb_smanid.Text = frm_rtninv_search.rec_search["smanname"].ToString();
                rdo_sinvpay.SelectedIndex = 0;
                rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value = frm_rtninv_search.rec_search["sinvpay"];
                rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].AccessibleName = frm_rtninv_search.rec_search["sinvpayname"].ToString();
                rdo_sinvpay.SelectedIndex = EmaxGlobals.NullToIntZero(rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value) - 1;
                txt_netavat.Text = frm_rtninv_search.rec_search["netavat"].ToString();
                txt_netbvat.Text = frm_rtninv_search.rec_search["netbvat"].ToString();
                txt_vatvalue.Text = frm_rtninv_search.rec_search["vatvalue"].ToString();
                lbl_rtninvid.Text = EmaxGlobals.NullToEmpty(frm_rtninv_search.rec_search["sinvid"]);
                txt_sinvno.Text = frm_rtninv_search.rec_search["docno"].ToString();
                lbl_sinvid.Text = frm_rtninv_search.rec_search["docid"].ToString();
                chk_withoutinv.Checked = EmaxGlobals.NullToBool(frm_rtninv_search.rec_search["withoutinv"]);
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sinvid", lbl_rtninvid.Text);
                var res = SqlCommandHelper.ExcecuteToDataTable("s_invdtls_sel", dict, true);
                foreach (DataRow item in res.dataTable.Rows)
                {
                    additmgrid_search(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, item);
                }

                frm_rtninv_search.rec_search = null;

                if (gridView1.RowCount > 0)
                    this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;
                btn_delete.Enabled = false;
                btn_Save.Enabled = false;
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void reprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_rtnsinvno.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء اختيار  فاتوره اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string ReportPath = Application.StartupPath + @"\report\s_rtn_inv_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                int sinvid = EmaxGlobals.NullToIntZero(lbl_rtninvid.Text);
                var qrdata = EmaxGlobals.GetQrCodeDateData(TokenResult.GetLoginData("compneyname").ToString(),
                          TokenResult.GetLoginData("compvatno").ToString(), txt_sinvdata.Text, lbl_time.Text, Convert.ToDouble(txt_netavat.Text),
                           Convert.ToDouble(txt_vatvalue.Text));
                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["sinvid"].Value = sinvid;
                xtraReport.Parameters["qrdata"].Value = qrdata;
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

        private void txt_sinvno_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("searchval", txt_sinvno.Text);
                    dict.Add("user_id", TokenResult.GetLoginData("userid").ToString());
                    var res = SqlCommandHelper.ExcecuteToDataTable("s_inv_sel_search_mobile", dict, true);
                    if (res.dataTable.Rows.Count == 0)
                    {
                        XtraMessageBox.Show("هذه الفاتوره غير موجوده برجاء مراجعه رقم الفاتوره", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    txt_sinvno.Text = res.dataTable.Rows[0]["sinvno"].ToString();
                    txt_custid.Text = res.dataTable.Rows[0]["custid"].ToString();
                    txt_custname.Text = res.dataTable.Rows[0]["custname"].ToString();
                    txt_custvat.Text = res.dataTable.Rows[0]["custvat"].ToString();
                    txt_custmobile.Text = res.dataTable.Rows[0]["custmobile"].ToString();
                    cmb_smanid.EditValue = res.dataTable.Rows[0]["smanid"].ToString();
                    cmb_smanid.Text = res.dataTable.Rows[0]["smanname"].ToString();

                    lbl_sinvid.Text = EmaxGlobals.NullToEmpty(res.dataTable.Rows[0]["sinvid"]);




                    if (gridView1.RowCount > 0)
                        this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Frm_Rtn_Inv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btn_barcodsearch.PerformClick();

            }
            else if (e.KeyCode == Keys.F6)
            {
                btn_inv_search.PerformClick();

            }
            else if (e.KeyCode == Keys.F2)
            {
                btn_custsearch.PerformClick();

            }
            else if (e.KeyCode == Keys.F1)
            {
                btn_rtninv_search.PerformClick();

            }
            else if (e.KeyCode == Keys.F5)
            {
                reprint.PerformClick();

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (gridView1.RowCount > 0)
                {
                    gridView1.Focus();

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.RowCount > 0)
                {
                    btn_delete.PerformClick();

                }
            }
            else if (e.KeyCode == Keys.Insert)
            {
                txt_barcode.Focus();
            }
            else if (e.KeyCode == Keys.End)
            {
                btn_Save.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }


        }
    }
}