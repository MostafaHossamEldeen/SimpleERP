using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using Emax.Dal;
using Emax.SharedLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using VanSales.POS.Models;

namespace VanSales.POS
{
    public partial class frm_invpos : DevExpress.XtraEditors.XtraForm
    {
        public frm_invpos()
        {
            InitializeComponent();
            txt_barcode.Focus();
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

            if (txt_barcode.Text.Length == 13 && (txt_barcode.Text.StartsWith("99") || txt_barcode.Text.StartsWith("55")))
            {
                if (TokenResult.GetLoginData("wpitem").ToString() == "False")//price
                {
                    rec.itemcode = EmaxGlobals.NullToEmpty(res["itemcode"]); //txt_barcode.Text.Substring(0, 7);
                    rec.price = EmaxGlobals.NullToZero(txt_barcode.Text.Substring(7, 3) + '.' + txt_barcode.Text.Substring(9, 2));
                    rec.qty = 1;
                }
                else if (TokenResult.GetLoginData("wpitem").ToString() == "True")
                {
                    rec.itemcode = EmaxGlobals.NullToEmpty(res["itemcode"]);
                    rec.price = EmaxGlobals.NullToZero(res["fprice"]);
                    rec.qty = EmaxGlobals.NullToZero(txt_barcode.Text.Substring(7, 2) + '.' + txt_barcode.Text.Substring(9, 3));
                }
            }
            else
            {
                rec.price = EmaxGlobals.NullToZero(res["fprice"]);
                rec.qty = 1;
                rec.itemcode = txt_barcode.Text;
                if (txt_barcode.Text == "")
                {
                    rec.itemcode = EmaxGlobals.NullToEmpty(res["itemcode"]);
                }
                if (res["itemcode"].ToString() != txt_barcode.Text)
                {
                    rec.itemcode = EmaxGlobals.NullToEmpty(res["itemcode"]);
                }

            }
            rec.value = EmaxGlobals.NullToZero(rec.price * rec.qty);
            rec.itemname = EmaxGlobals.NullToEmpty(res["itemname"]);

            rec.itemid = EmaxGlobals.NullToIntZero(res["itemid"]);
            rec.unitid = EmaxGlobals.NullToIntZero(res["unitid"]);
            rec.factor = EmaxGlobals.NullToIntZero(res["factor"]);


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
            try
            {
                int row = gridView1.FocusedRowHandle;
                decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                decimal price = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "price"));
                gridView1.SetRowCellValue(row, "value", qty * price);
                decimal value = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "value"));
                decimal discvalue = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "discvalue"));
                gridView1.SetRowCellValue(row, "netvalue", value - discvalue);
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
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //  gridView1.SetRowCellValue(row, "vatvalue", Math.Round((EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "netvalue")) * vat / (100 + vat)),2));
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
            lbl_sinvid.Text = string.Empty;
            lbl_imeasurid.Text = string.Empty;
            textEdit1.Text = string.Empty;
            textEdit2.Text = string.Empty;
            textEdit3.Text = string.Empty;
            textEdit4.Text = string.Empty;
            textEdit5.Text = string.Empty;
            for (int i = 0; i < gridView1.RowCount;)
            {
                gridView1.DeleteRow(i);

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
                netbvat = EmaxGlobals.NullToZero(txt_netbvat.Text),
                vatvalue = EmaxGlobals.NullToZero(txt_vatvalue.Text),
                netavat = EmaxGlobals.NullToZero(txt_netavat.Text),
                restvalue = EmaxGlobals.NullToZero(txt_netavat.Text),
                smanid = EmaxGlobals.NullToNullInt(cmb_smanid.EditValue),
                smanname = cmb_smanid.Text,
                invchk = 1,
                compneyname = TokenResult.GetLoginData("compneyname"),
                s_invdtls = new List<s_invdtl>(),
                s_invmeasures = new List<s_invmeasures>()
            };
            foreach (DsPos.s_invdtls_selRow item in (gridControl1.DataSource as DsPos.s_invdtls_selDataTable).Rows)
            {

                sinv.s_invdtls.Add(new s_invdtl
                {
                    itemid = item.itemid,
                    unitid = item.unitid,
                    qty = item.qty,
                    price = item.price,
                    value = item.value,
                    discp = item.discp,
                    discvalue = item.discvalue,
                    netvalue = item.netvalue,
                    vatvalue = item.vatvalue,
                    factor = item.factor,
                    userid = TokenResult.GetLoginData("userid")
                });
            }
            sinv.s_invmeasures.Add(new s_invmeasures
            {
                imeasurid = EmaxGlobals.NullToIntZero(lbl_imeasurid.Text),
                rsphd = textEdit1.Text,
                rclyd = textEdit2.Text,
                raxisd = textEdit3.Text,
                lsphd = textEdit4.Text,
                lclyd = textEdit5.Text
            });
            //foreach (DsPos. item in (gridControl1.DataSource as DsPos.s_invdtls_selDataTable).Rows)
            //{
            //    Invs.s_invdtls.Add(new s_invdtl { icost = item.icost });
            //}
            var sinvjson = JObject.Parse(JsonConvert.SerializeObject(sinv));

            return JsonConvert.SerializeObject(sinvjson);



        }

        private void frm_invpos_Load(object sender, EventArgs e)
        {
            var res = SqlCommandHelper.ExcecuteToDataTable("pos_additional_fields");
            if (res.dataTable.Rows.Count != 0)
            {
                if (Convert.ToBoolean(res.dataTable.Rows[0]["show"]) == true)
                {
                    layout_Additional_txt1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_txt2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_txt3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_txt4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_note_txt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_lbl2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_lbl3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_lbl4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_note_lbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layout_Additional_txt1.Text = res.dataTable.Rows[0]["feild1"].ToString();
                    layout_Additional_txt2.Text = res.dataTable.Rows[0]["feild2"].ToString();
                    layout_Additional_txt3.Text = res.dataTable.Rows[0]["feild3"].ToString();
                    layout_Additional_txt4.Text = res.dataTable.Rows[0]["feild4"].ToString();
                    layout_note_txt.Text = res.dataTable.Rows[0]["notefeild"].ToString();
                    layout_Additional_lbl1.Text = res.dataTable.Rows[0]["feild1e"].ToString();
                    layout_Additional_lbl2.Text = res.dataTable.Rows[0]["feild2e"].ToString();
                    layout_Additional_lbl3.Text = res.dataTable.Rows[0]["feild3e"].ToString();
                    layout_Additional_lbl4.Text = res.dataTable.Rows[0]["feild4e"].ToString();
                    layout_note_lbl.Text = res.dataTable.Rows[0]["notefeilde"].ToString();
                }
                else
                {
                    layout_Additional_txt1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_Additional_txt2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_Additional_txt3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_Additional_txt4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_note_txt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_Additional_lbl1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_Additional_lbl2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_Additional_lbl3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_Additional_lbl4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layout_note_lbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }

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
            //.Select();
            //layoutControlItem10.Selected = true;
            txt_barcode.Focus();

        }
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_barcode.Text == "+" || txt_barcode.Text == "-")
                {
                    txt_barcode.EditValue = "";
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
                    if (txt_barcode.Text.Length == 13 && (txt_barcode.Text.StartsWith("99") || txt_barcode.Text.StartsWith("55")))
                    {
                        var newbarcode = EmaxGlobals.NullToZero(txt_barcode.Text.Substring(0, 7));
                        dict.Add("itemcode", newbarcode);
                        dict.Add("barcode1", newbarcode);
                        dict.Add("barcode2", newbarcode);
                    }
                    else
                    {
                        dict.Add("itemcode", txt_barcode.Text);
                        dict.Add("barcode1", txt_barcode.Text);
                        dict.Add("barcode2", txt_barcode.Text);
                    }
                    //  var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code", dict, true);
                    var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code_group", dict, true); //شركه الاحساس
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


                frm_items_search frm_Items_Search = new frm_items_search();
                frm_Items_Search.ShowDialog();
                additmgrid(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, frm_items_search.rec);

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
                if (frm_Cus.cus_code != null)
                {
                    txt_custid.Text = frm_Cus.cus_code;
                    txt_custname.Text = frm_Cus.cus_name;
                    txt_custvat.Text = frm_Cus.cus_vat;
                    txt_custmobile.Text = frm_Cus.cus_mobile;
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frm_invpos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btn_barcodsearch.PerformClick();

            }
            else if (e.KeyCode == Keys.F2)
            {
                btn_custsearch.PerformClick();

            }
            else if (e.KeyCode == Keys.F1)
            {
                btn_inv_search.PerformClick();

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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
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
                        RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addnewinv");
                        restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                        restRequest.AddHeader("userid", TokenResult.GetLoginData("userid").ToString());
                        restRequest.AddHeader("compvatno", TokenResult.GetLoginData("compvatno").ToString());
                        restRequest.AddJsonBody(ConvertToObject());
                        RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                        if (restResponse.StatusCode == HttpStatusCode.OK)
                        {
                            string ReportPath = Application.StartupPath + @"\report\s_inv_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
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
                    inv_pay pay = new inv_pay(ConvertToObject(), this);
                    pay.ShowDialog();
                    if (!inv_pay.isescape == true)
                    {

                        clear();

                    }
                    inv_pay.isescape = false;
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
        //public int sinvid;
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
                clear();
                // additmgrid(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, inv_search.rec_search);
                txt_sinvno.Text = inv_search.rec_search["sinvno"].ToString();
                txt_sinvdata.Text = Convert.ToDateTime(inv_search.rec_search["sinvdata"].ToString()).ToShortDateString();
                lbl_time.Text = Convert.ToDateTime(inv_search.rec_search["sinvtime"].ToString()).ToLongTimeString();
                txt_custid.Text = inv_search.rec_search["custid"].ToString();
                txt_custname.Text = inv_search.rec_search["custname"].ToString();
                txt_custvat.Text = inv_search.rec_search["custvat"].ToString();
                txt_custmobile.Text = inv_search.rec_search["custmobile"].ToString();
                cmb_smanid.EditValue = inv_search.rec_search["smanid"].ToString();
                cmb_smanid.Text = inv_search.rec_search["smanname"].ToString();
                rdo_sinvpay.SelectedIndex = 0;
                rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value = inv_search.rec_search["sinvpay"];
                rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].AccessibleName = inv_search.rec_search["sinvpayname"].ToString();
                rdo_sinvpay.SelectedIndex = EmaxGlobals.NullToIntZero(rdo_sinvpay.Properties.Items[rdo_sinvpay.SelectedIndex].Value) - 1;
                txt_netavat.Text = inv_search.rec_search["netavat"].ToString();
                txt_netbvat.Text = inv_search.rec_search["netbvat"].ToString();
                txt_vatvalue.Text = inv_search.rec_search["vatvalue"].ToString();
                lbl_sinvid.Text = EmaxGlobals.NullToEmpty(inv_search.rec_search["sinvid"]);
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sinvid", lbl_sinvid.Text);
                var res = SqlCommandHelper.ExcecuteToDataTable("s_invdtls_sel", dict, true);
                foreach (DataRow item in res.dataTable.Rows)
                {
                    additmgrid_search(gridControl1.DataSource as DsPos.s_invdtls_selDataTable, item);
                }

                var resmeasure = SqlCommandHelper.ExcecuteToDataTable("s_invmeasure_sel", dict, true);
                if (resmeasure.dataTable.Rows.Count > 0)
                {


                    lbl_imeasurid.Text = resmeasure.dataTable.Rows[0]["imeasurid"].ToString();
                    textEdit1.Text = resmeasure.dataTable.Rows[0]["rsphd"].ToString();
                    textEdit2.Text = resmeasure.dataTable.Rows[0]["rclyd"].ToString();
                    textEdit3.Text = resmeasure.dataTable.Rows[0]["raxisd"].ToString();
                    textEdit4.Text = resmeasure.dataTable.Rows[0]["lsphd"].ToString();
                    textEdit5.Text = resmeasure.dataTable.Rows[0]["lclyd"].ToString();
                }
                else
                {
                    lbl_imeasurid.Text = string.Empty;
                    textEdit1.Text = string.Empty;
                    textEdit2.Text = string.Empty;
                    textEdit3.Text = string.Empty;
                    textEdit4.Text = string.Empty;
                    textEdit5.Text = string.Empty;
                }

                inv_search.rec_search = null;

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

                    int row = gridView1.FocusedRowHandle;
                    if (row < 0)
                    {
                        XtraMessageBox.Show("لايوجد اصناف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal qty = EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty"));
                    gridView1.SetRowCellValue(row, "qty", EmaxGlobals.NullToZero(gridView1.GetRowCellValue(row, "qty")) + 1);

                    txt_barcode.Text = string.Empty;

                    //btn_add.PerformClick();
                    //txt_barcode.Text = string.Empty;


                }
                else if (e.KeyCode == Keys.Subtract)
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
                    //btn_Subtract.PerformClick();
                    //txt_barcode.Text = string.Empty;

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

        private void reprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_sinvno.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء اختيار  فاتوره اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ReportPath = Application.StartupPath + @"\report\s_inv_receipt_pos.repx";// @"E:\Project Repo\Circle\VanSales\VanSales.POS\Report\s_inv_receipt_pos.repx"; //Application.StartupPath + "\\Report\\s_inv_receipt_pos.repx ";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                string sinvid = lbl_sinvid.Text;
                var qrdata = EmaxGlobals.GetQrCodeDateData(TokenResult.GetLoginData("compneyname").ToString(),
                            TokenResult.GetLoginData("compvatno").ToString(),txt_sinvdata.Text, lbl_time.Text, Convert.ToDouble(txt_netavat.Text),
                             Convert.ToDouble(txt_vatvalue.Text));
                //string qrdata = JObject.Parse(restResponse.Content)["qrdata"].ToString();
                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += Inv_pos_ConnectionError; ; ;
                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["sinvid"].Value = sinvid;
                xtraReport.Parameters["qrdata"].Value = qrdata;
                xtraReport.Parameters["reprint"].Value = "نسخه من فاتوره";
                foreach (XRSubreport item in sub)
                {

                    ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;
                    item.ReportSource = XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;

                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConnectionError += Inv_pos_ConnectionError;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += Inv_pos_ConfigureDataConnection;

                }


                xtraReport.Print();

               // clear();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddCust_Click(object sender, EventArgs e)
        {
            FrmAddCust addCust = new FrmAddCust();
            addCust.ShowDialog();
            txt_custid.Text = addCust.cus_code;
            txt_custname.Text = addCust.cus_name;
            txt_custvat.Text = addCust.cus_vat;
            txt_custmobile.Text = addCust.cus_mobile;
        }

        private void btn_warranty_certificate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_sinvno.Text == string.Empty)
                {
                    XtraMessageBox.Show("برجاء اختيار  فاتوره اولا", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string ReportPath = Application.StartupPath + @"\report\pos_warranty_certificate_repo.repx";
                XtraReport xtraReport = XtraReport.FromFile(ReportPath);

                string sinvid = lbl_sinvid.Text;

                ((SqlDataSource)xtraReport.DataSource).ConfigureDataConnection += warranty_certificate_ConfigureDataConnection; ;
                ((SqlDataSource)xtraReport.DataSource).ConnectionError += warranty_certificate_ConnectionError; ; ;
                var sub = xtraReport.AllControls<XRSubreport>();
                xtraReport.Parameters["sinvid"].Value = sinvid;
                foreach (XRSubreport item in sub)
                {
                    ((SqlDataSource)item.Report.Report.DataSource).ConfigureDataConnection += warranty_certificate_ConfigureDataConnection;
                    item.ReportSource = XtraReport.FromFile(Application.StartupPath + @"\report\" + item.Name + ".repx"); ;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConnectionError += warranty_certificate_ConnectionError;
                    ((SqlDataSource)((XtraReport)item.ReportSource).DataSource).ConfigureDataConnection += warranty_certificate_ConfigureDataConnection;

                }
                xtraReport.Print();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void warranty_certificate_ConnectionError(object sender, ConnectionErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void warranty_certificate_ConfigureDataConnection(object sender, ConfigureDataConnectionEventArgs e)
        {
            e.ConnectionParameters = new MsSqlConnectionParameters(ConfigurationManager.AppSettings["sever"], ConfigurationManager.AppSettings["dbname"], ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"], MsSqlAuthorizationType.SqlServer);
        }
    }
}