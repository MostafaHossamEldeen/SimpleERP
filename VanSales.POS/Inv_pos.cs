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
    public partial class Inv_pos : DevExpress.XtraEditors.XtraForm
    {
        public Inv_pos()
        {
            InitializeComponent();
        }
        private void Inv_pos_Load(object sender, EventArgs e)
        {
            txt_barcode.Focus();
            txt_sinvdata.Text = DateTime.Now.ToShortDateString();
            var dt = new DsPos.s_invdtls_selDataTable();
            gridControl1.DataSource = dt;
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman", "smanid", "smanname");
            cmb_smanid.ItemIndex = -1;
            this.KeyPreview = true;
            txt_suser.Text = TokenResult.GetLoginData("username").ToString();


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

            rec.value = EmaxGlobals.NullToZero(rec.price * rec.qty);

            rec.discvalue = 0;

            rec.netvalue = EmaxGlobals.NullToZero(rec.value - rec.discvalue);

            rec.vatvalue = (EmaxGlobals.NullToZero(rec.netvalue) * EmaxGlobals.NullToZero(res["vat"])) / (100 + EmaxGlobals.NullToZero(res["vat"]));
            vat = EmaxGlobals.NullToZero(res["vat"]);

            dt.Adds_invdtls_selRow(rec);
            calac();


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
            //if () ///// شامل الضريبه 1
            //{
            //   txt_netavat.Text = gridView1.Columns["netvalue"].SummaryItem.SummaryValue.ToString();
            //  txt_vatvalue.Text = gridView1.Columns["vatvalue"].SummaryItem.SummaryValue.ToString();

            //   txt_netbvat.Text= Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();
            //  }

            //  else if (HF_vattype.Value == "2") غير شامل الضريبه
            // {
            txt_netbvat.Text = gridView1.Columns["netvalue"].SummaryItem.SummaryValue.ToString();
            txt_vatvalue.Text = gridView1.Columns["vatvalue"].SummaryItem.SummaryValue.ToString();
            txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();

            //   }

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
            gridView1.SetRowCellValue(row, "vatvalue", (EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "netvalue")) * vat / (100 + vat)));
            //EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"])
           
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
            txt_vatvalue.Text = string.Empty;
            rdo_sinvpay.SelectedIndex = 0;
            cmb_smanid.Text = string.Empty;
            cmb_smanid.EditValue = null;
            for (int i = 0; i < gridView1.RowCount;)
            {
                gridView1.DeleteRow(i);

            }

        }
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_barcode.Text == "+" || txt_barcode.Text == "-")
            {
                txt_barcode.EditValue ="";
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_barcode.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء اختيار ادخال باركود الصنف اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemcode", "");
                dict.Add("barcode1", txt_barcode.Text);
                dict.Add("barcode2", txt_barcode.Text);
                var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code", dict, true);
                if (res.dataTable.Rows.Count == 0)
                {
                    XtraMessageBox.Show("كود الصنف غير مسجل", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                var dt = gridControl1.DataSource as DsPos.s_invdtls_selDataTable;
                var itemingrid = dt.Where(i => i.itemcode == txt_barcode.Text).FirstOrDefault();
                if (itemingrid != null)
                {
                    var msgres = XtraMessageBox.Show("لزياده الكميه Y لاضافه سطر جديد N", "inf", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (msgres == DialogResult.Yes || e.KeyCode == Keys.Y)
                    {
                        itemingrid.qty++;
                        itemingrid.value = EmaxGlobals.NullToZero(itemingrid.price * itemingrid.qty);
                        itemingrid.netvalue = EmaxGlobals.NullToZero(itemingrid.value - itemingrid.discvalue);
                        itemingrid.vatvalue = (EmaxGlobals.NullToZero(itemingrid.netvalue) * EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"])) / (100 + EmaxGlobals.NullToZero(res.dataTable.Rows[0]["vat"]));
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
                // gridView1.FocusedRowHandle = gridView1.RowCount ;
                this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;
                txt_barcode.Text = string.Empty;

                // txt_barcode.Focus();
            }
        }

        private void btn_brcode_search_Click(object sender, EventArgs e)
        {
            frm_items_search frm_Items_Search = new frm_items_search();
            frm_Items_Search.ShowDialog();
            additmgrid(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, frm_items_search.rec);
            frm_items_search.rec = null;
            if (gridView1.RowCount > 0)
                this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;


        }


        private void btn_cus_search_Click(object sender, EventArgs e)
        {
            frm_cus_search frm_Cus = new frm_cus_search();
            frm_Cus.ShowDialog();
            txt_custid.Text = frm_Cus.cus_code;
            txt_custname.Text = frm_Cus.cus_name;
            txt_custvat.Text = frm_Cus.cus_vat;
            txt_custmobile.Text = frm_Cus.cus_mobile;
        }

        private void Inv_pos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btn_brcode_search.PerformClick();
                //frm_items_search frm_Items_Search = new frm_items_search();
                //frm_Items_Search.ShowDialog();
                //additmgrid(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, frm_items_search.rec);
                //frm_items_search.rec = null;
            }
            else if (e.KeyCode == Keys.F2)
            {
                btn_cus_search.PerformClick();
                //frm_cus_search frm_Cus = new frm_cus_search();
                //frm_Cus.ShowDialog();
                //txt_custid.Text = frm_Cus.cus_code;
                //txt_custname.Text = frm_Cus.cus_name;
                //txt_custvat.Text = frm_Cus.cus_vat;
                //txt_custmobile.Text = frm_Cus.cus_mobile;
            }
            else if (e.KeyCode == Keys.F1)
            {
                btn_inv_search.PerformClick();
                
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
                    //int row = gridView1.FocusedRowHandle;
                    //gridView1.DeleteRow(row);
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
            //else if (e.KeyCode == Keys.Add)
            //{
            //    btn_add.PerformClick();
            //    txt_barcode.Text = string.Empty;
            //    return;
            //    //int row = gridView1.FocusedRowHandle;
            //    //decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
            //    //gridView1.SetRowCellValue(row, "qty", qty++);
            //}
            //else if (e.KeyCode == Keys.Subtract)
            //{
            //    btn_Subtract.PerformClick();
            //    txt_barcode.Text = string.Empty;
            //    //int row = gridView1.FocusedRowHandle;
            //    //decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
            //    //gridView1.SetRowCellValue(row, "qty", qty++);
            //}
            //txt_barcode.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (rdo_sinvpay.SelectedIndex == 1)
            {

                using (var client = new HttpClient())
                {
                    RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
                    RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addnewinv");
                    restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                    restRequest.AddJsonBody(ConvertToObject());
                    RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                    if (restResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string ReportPath = Application.StartupPath + @"\report\s_inv_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                        XtraReport xtraReport =  XtraReport.FromFile(ReportPath);
                        
                        string sinvid  = JObject.Parse(restResponse.Content)["sinvid"].ToString();

                        ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                        ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                        var sub = xtraReport.AllControls<XRSubreport>();
                        xtraReport.Parameters["sinvid"].Value = sinvid;
                        foreach (XRSubreport item in sub)
                        {
                            
                            ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;
                           item.ReportSource= XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;
                        
                            ((SqlDataSource)((XtraReport) item.ReportSource).DataSource).ConnectionError += Inv_pos_ConnectionError;
                            ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;
                         
                        }
                        xtraReport.ShowPreview();
                        
                        //clear();
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
                //inv_pay pay = new inv_pay(ConvertToObject(),this);
                //pay.ShowDialog();
                clear();
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

        internal string ConvertToObject()
        {
            s_invs sinv = new s_invs { sinvdata = Convert.ToDateTime(txt_sinvdata.Text), sinvdocno = DBNull.Value.ToString(), sinvpay = EmaxGlobals.NullToIntZero(rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value), sinvpayname = rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Description, branchid = EmaxGlobals.NullToIntZero(TokenResult.GetLoginData("branchid")), branchname = TokenResult.GetLoginData("branchname").ToString(), custid = EmaxGlobals.NullToNullInt(txt_custid.Text), custname = txt_custname.Text, custvat = txt_custvat.Text, custmobile = txt_custmobile.Text, suser = txt_suser.Text
                , netbvat = EmaxGlobals.NullToZero(txt_netbvat.Text), vatvalue = EmaxGlobals.NullToZero(txt_vatvalue.Text), netavat = EmaxGlobals.NullToZero(txt_netavat.Text), restvalue = EmaxGlobals.NullToZero(txt_netavat.Text), smanid = EmaxGlobals.NullToNullInt(cmb_smanid.EditValue), smanname = cmb_smanid.Text,invchk=1, s_invdtls = new List<s_invdtl>() };
            foreach (DsPos.s_invdtls_selRow item in (gridControl1.DataSource as DsPos.s_invdtls_selDataTable).Rows)
            {

                sinv.s_invdtls.Add(new s_invdtl { itemid = item.itemid, unitid = item.unitid, qty = item.qty,
                    price = item.price, value = item.value, discp = item.discp, discvalue = item.discvalue, netvalue = item.netvalue, vatvalue = item.vatvalue,
                    factor = item.factor });
            }
            //foreach (DsPos. item in (gridControl1.DataSource as DsPos.s_invdtls_selDataTable).Rows)
            //{
            //    Invs.s_invdtls.Add(new s_invdtl { icost = item.icost });
            //}
            var sinvjson = JObject.Parse(JsonConvert.SerializeObject(sinv));
        
            return JsonConvert.SerializeObject(sinvjson);



        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //inv_pay inv_Pay = new inv_pay(this);

            int row = gridView1.FocusedRowHandle;
            gridView1.DeleteRow(row);
            calac();
        }



      



        private void btn_add_Click(object sender, EventArgs e)
        {
            int row = gridView1.FocusedRowHandle;
            decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
            gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) + 1);
           // clac_qty_disc();
          //  calac();
            txt_barcode.Text = string.Empty;
        }

        private void btn_Subtract_Click(object sender, EventArgs e)
        {
            int row = gridView1.FocusedRowHandle;
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
                return;
            }
        }

        private void btn_inv_search_Click(object sender, EventArgs e)
        {
            inv_search _Search = new inv_search();
            _Search.ShowDialog();
            clear();
            if (inv_search.rec_search.Table.Rows.Count == 0)
            {
                return;
            }
            // additmgrid(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, inv_search.rec_search);
            txt_sinvno.Text = inv_search.rec_search.Table.Rows[0]["sinvno"].ToString();
            txt_sinvdata.Text = Convert.ToDateTime(inv_search.rec_search.Table.Rows[0]["sinvdata"].ToString()).ToShortDateString();
            txt_custid.Text = inv_search.rec_search.Table.Rows[0]["custid"].ToString();
            txt_custname.Text = inv_search.rec_search.Table.Rows[0]["custname"].ToString();
            txt_custvat.Text = inv_search.rec_search.Table.Rows[0]["custvat"].ToString();
            txt_custmobile.Text = inv_search.rec_search.Table.Rows[0]["custmobile"].ToString();
            cmb_smanid.EditValue = inv_search.rec_search.Table.Rows[0]["smanid"].ToString();
            cmb_smanid.Text = inv_search.rec_search.Table.Rows[0]["smanname"].ToString();
            rdo_sinvpay.SelectedIndex = 0;
            rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value = inv_search.rec_search.Table.Rows[0]["sinvpay"];
            rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].AccessibleName = inv_search.rec_search.Table.Rows[0]["sinvpayname"].ToString();
            rdo_sinvpay.SelectedIndex = EmaxGlobals.NullToIntZero(rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value) - 1;
            txt_netavat.Text = inv_search.rec_search.Table.Rows[0]["netavat"].ToString();
            txt_netbvat.Text = inv_search.rec_search.Table.Rows[0]["netbvat"].ToString();
            txt_vatvalue.Text = inv_search.rec_search.Table.Rows[0]["vatvalue"].ToString();
            int sinvid = EmaxGlobals.NullToIntZero(inv_search.rec_search.Table.Rows[0]["sinvid"]);
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("sinvid", sinvid);
            var res = SqlCommandHelper.ExcecuteToDataTable("s_invdtls_sel", dict, true);
            foreach (DataRow item in res.dataTable.Rows)
            {
                additmgrid_search(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, item);
            }
          
            inv_search.rec_search = null;
            sinvid = 0;
            if (gridView1.RowCount > 0)
                this.gridView1.FocusedRowHandle = (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo[0].RowHandle + (this.gridView1.GetViewInfo() as GridViewInfo).RowsInfo.Count;

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridView1.Columns["qty"] || e.Column == gridView1.Columns["discvalue"])
            {
                
                clac_qty_disc();
                gridView1.UpdateCurrentRow();

            }
        }
 
        private void gridControl1_EditorKeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                int row = gridView1.FocusedRowHandle;
                decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) + 1);
                txt_barcode.Text = string.Empty;

                //int row = gridView1.FocusedRowHandle;
                //decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                //gridView1.SetRowCellValue(row, "qty", qty++);
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                int row = gridView1.FocusedRowHandle;
                decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                if (qty > 1)
                {
                    gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) - 1);
                    //clac_qty_disc();
                    //calac();
                    txt_barcode.Text = string.Empty;
                }
                else
                {
                    XtraMessageBox.Show("لايمكن ادخال الكميه صفر \n can not add Quantity zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txt_barcode.Text = string.Empty;
               
            }
            calac();
        }
    }
}