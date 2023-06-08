using VanSales.DBClass;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid;
namespace VanSales
{
    public partial class s_inv : System.Web.UI.Page
    {
        SalesInv ms = new SalesInv();
        //int unitid;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                
                HF_inv_id.Value = Request.Params["sinvid"];
                sinvdata.Date = DateTime.Now;
                dll_sinvpay.SelectedIndex = 0;
            }
        }
        void clear()
        {

            txt_item.Text = string.Empty;
            txt_unit.Text = string.Empty;
            txt_qty.Text ="0";
            txt_price.Text = "0";
            txt_value.Text ="0";
            txt_discp.Text = "0";
            txt_discvalue.Text = "0";
            txt_netvalue.Text = "0";
            txt_itemvatvalue.Text = "0";
            txt_itemnotes.Text = string.Empty;
            txt_item_name.Text = string.Empty;
            HFsinviddtl.Value = "";
            HfItemID.Value = "";

        }
        void clear_inv()
        {
            clear();
            txt_sinvno.Text = string.Empty;
            txt_sinvno.Text = "تلقائى";
            txt_sinvdocno.Text = string.Empty;

            sinvdata.Text = string.Empty;
            txt_sinvtime.Text = string.Empty;
             dll_sinvpay.Text= string.Empty;
            dll_sinvpay.Value= string.Empty;
            // dll_sinvpay.Items.Clear();
            //dll_snature.Items.Clear();
            txt_cusid.Text = string.Empty;
            txt_custvat.Text = string.Empty;
            txt_custadd.Text = string.Empty;
            txt_suser.Text = string.Empty;
            txt_snotes.Text = string.Empty;
         
            txt_netbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_netavat.Text = "0";
            HF_inv_id.Value = "";
            sinvdata.Date = DateTime.Now;
            dll_sinvpay.SelectedIndex = 0;
        }
        void bind()
        {

          DataTable dt=  ms.s_inv_sel_id(Convert.ToInt32( HF_inv_id.Value));
            txt_sinvno.Text= dt.Rows[0]["sinvno"].ToString();
            txt_sinvdocno.Text = dt.Rows[0]["sinvdocno"].ToString();
            dll_sinvpay.Text= dt.Rows[0]["sinvpayname"].ToString();
            dll_sinvpay.Value = dt.Rows[0]["sinvpay"].ToString();
            sinvdata.Date= Convert.ToDateTime(dt.Rows[0]["sinvdata"].ToString() );
            txt_sinvtime.Text = dt.Rows[0]["sinvtime"].ToString();
            txt_cusid.Text = dt.Rows[0]["custid"].ToString() ;
            txt_cusname.Text = dt.Rows[0]["custname"].ToString() ;
            txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
            txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
            txt_suser.Text = dt.Rows[0]["suser"].ToString();
            txt_snotes.Text = dt.Rows[0]["snotes"].ToString();
            txt_netbvat.Text = dt.Rows[0]["netbvat"].ToString();
            txt_vatvalue.Text = dt.Rows[0]["vatvalue"].ToString();
            txt_netavat.Text = dt.Rows[0]["netavat"].ToString();
            lbl_filename.Text = dt.Rows[0]["invdoc"].ToString();//.Replace("~/Files/","");
            //HFsInvid.Value = sinvid;
            PDetiles.Visible = true;
            //decimal x = 0;
            //for (int i = 0; i < gvs_invdtls.VisibleRowCount; i++)
            //{

            //    object value = gvs_invdtls.GetRowValues(i, "netvalue");
            //    if (value != null)
            //    {
            //        x += decimal.Parse(value.ToString());
            //    }

            //}
            //txt_netavat.Text = x.ToString();
        
    }
        void bind_items()
        {
            DataTable dt = ms.st_items_sel_itemid(HfItemID.Value);
            if (dt.Rows.Count > 0)
            {
                txt_item.Text = dt.Rows[0]["itemcode"].ToString();
                txt_item_name.Text = dt.Rows[0]["itemname"].ToString();
                txt_price.Text = dt.Rows[0]["fprice"].ToString();
                txt_unit.Text = dt.Rows[0]["unitname"].ToString();
                Hfuntid.Value = dt.Rows[0]["unitid"].ToString();
                
               // HfItemID.Value = dt.Rows[0]["itemid"].ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
                clear();
            }
        }
        protected void txt_netvalue_TextChanged(object sender, EventArgs e)
        {

        }

     

        protected void btn_Save_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txt_sinvno.Text == "تلقائى")
                {
                    string pathfile = "";
                    try
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                        pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    }
                    catch { }
                   
                    //(int erro_id, string inv_no,string time) = ms.s_inv_ins("فاتوره", txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), pathfile, Convert.ToInt16(dll_sman.SelectedItem.Value), dll_sman.SelectedItem.Text);

                    //if (erro_id == 0)
                    //{
                    //    txt_sinvno.Text = inv_no;
                    //    txt_sinvtime.Text = time.ToString();
                    //    PDetiles.Visible = true;
                    //}
                }
                else
                {
                    PDetiles.Visible = true;
                    string pathfile=null;
                    if (FileUpload1.HasFile == true)
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                        pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                        lbl_filename.Text = pathfile;
                    }
                    
                    else if (FileUpload1.HasFile == false && lbl_filename.Text != null || lbl_filename.Text != "")
                    {
                        pathfile = lbl_filename.Text;
                    }
                    if (HF_inv_id.Value == "")
                    {
                        DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
                        HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();
                    }
                    //(int erro_id,string err_msg) = ms.s_inv_upd(int.Parse(HF_inv_id.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), pathfile);
                    //    if (erro_id == 0)
                    //    {
                    //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    //        PDetiles.Visible = true;
                    //    }
                    }
                    //else
                    //{
                    //   //    pathfile = dataItem["club_log"].Text;

                    //    int erro_id = ms.s_inv_upd(int.Parse(HF_inv_id.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), pathfile);
                    //    if (erro_id == 0)
                    //    {
                            
                    //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    //        PDetiles.Visible = true;
                    //    }
                    //}
                
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg == "Input string was not in a correct format.") 
                msg = "برجاء التأكد من البيانات المدخله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_addnew_Click(object sender, ImageClickEventArgs e)
        {
            clear_inv();
            Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }

        protected void btn_delete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (HF_inv_id.Value == "")
                {
                  DataTable dt=  ms.s_inv_sel_sinvid(txt_sinvno.Text);
                    HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();
                }
                ms.s_inv_del(Convert.ToInt32(HF_inv_id.Value));
                clear_inv();
                PDetiles.Visible = false;
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void HF_inv_id_ValueChanged(object sender, EventArgs e)
        {
            if (HF_inv_id.Value != "")
            {
                bind();
            }
        }

       
        protected void gvs_invdtls_SelectionChanged(object sender, EventArgs e)
        {

            txt_item.Text = gvs_invdtls.GetSelectedFieldValues("itemcode")[0].ToString();
            txt_item_name.Text = gvs_invdtls.GetSelectedFieldValues("itemname")[0].ToString();
            txt_unit.Text = gvs_invdtls.GetSelectedFieldValues("unitname")[0].ToString();
            Hfuntid.Value = gvs_invdtls.GetSelectedFieldValues("unitid")[0].ToString();
            txt_qty.Text = gvs_invdtls.GetSelectedFieldValues("qty")[0].ToString();
            txt_price.Text = gvs_invdtls.GetSelectedFieldValues("price")[0].ToString();
            txt_value.Text = gvs_invdtls.GetSelectedFieldValues("value")[0].ToString();
            txt_discp.Text = gvs_invdtls.GetSelectedFieldValues("discp")[0].ToString();
            txt_discvalue.Text = gvs_invdtls.GetSelectedFieldValues("discvalue")[0].ToString();
            txt_netvalue.Text = gvs_invdtls.GetSelectedFieldValues("netvalue")[0].ToString();
           txt_itemvatvalue.Text = gvs_invdtls.GetSelectedFieldValues("vatvalue")[0].ToString();
            txt_itemnotes.Text = gvs_invdtls.GetSelectedFieldValues("itemnotes")[0].ToString();
            HFsinviddtl.Value = gvs_invdtls.GetSelectedFieldValues("invdtlid")[0].ToString();
           
        }

        protected void btn_save_dtls_Click(object sender, ImageClickEventArgs e)
        {
            if (HFsinviddtl.Value == "" || HFsinviddtl.Value == "0")
            {
                try
                {
                    DataTable dt =  ms.s_inv_sel_sinvid(txt_sinvno.Text) ;
                    HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();

                  //  ms.s_invdtls_ins(Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(HfItemID.Value),Convert.ToInt16( Hfuntid.Value), txt_unit.Text, Convert.ToInt32(txt_qty.Text), Convert.ToDecimal(txt_price.Text),Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txt_itemvatvalue.Text), txt_itemnotes.Text,1,11, sinvdata.Date, Convert.ToInt32(txt_cusid.Text), txt_sinvno.Text, txt_cusname.Text, "", "");
                    gvs_invdtls.DataBind();
                    ////// update  vatvalue,netavat,netavat
                    update_inv_vatvalue();
                    //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    clear();
                }
                catch (Exception ex)
                {
                    string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                }
            }
            else
            {
                try
                {
                DataTable dt= ms.st_items_sel_item_code(txt_item.Text);

                    HfItemID.Value = dt.Rows[0]["itemid"].ToString();
                    //Hfuntid.Value =  dt.Rows[0]["unitid"].ToString());


                  //  ms.s_invdtls_upd(Convert.ToInt16(HFsinviddtl.Value), Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(HfItemID.Value), Convert.ToInt16(Hfuntid.Value), txt_unit.Text, Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txt_itemvatvalue.Text), txt_itemnotes.Text, 1, 11, Convert.ToDateTime(sinvdata.Text), Convert.ToInt32(txt_cusid.Text), txt_sinvno.Text, txt_cusname.Text, "", "");
                    gvs_invdtls.DataBind();
                    ////// update  vatvalue,netavat,netavat
                    update_inv_vatvalue();
                    // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    clear();

                }
                catch (Exception ex)
                {

                    string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);

                }

            }
        }

        protected void txt_item_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ms.st_items_sel_item_code(txt_item.Text);
                if (dt.Rows.Count > 0)
                {
                    txt_item_name.Text = dt.Rows[0]["itemname"].ToString();
                    txt_price.Text = dt.Rows[0]["fprice"].ToString();
                    txt_unit.Text = dt.Rows[0]["unitname"].ToString();
                    Hfuntid.Value =  dt.Rows[0]["unitid"].ToString();
                    HfItemID.Value = dt.Rows[0]["itemid"].ToString();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
                    clear();
                }
            }
            catch(Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_download_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string fileextantion = lbl_filename.Text;
                //int statrindex = ;
                fileextantion = fileextantion.Substring(fileextantion.Length - 3, 3);
                if (fileextantion == "lsx" || fileextantion == "LSX")
                    fileextantion = "xlsx";
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "File/" + fileextantion + "";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + txt_sinvno.Text + "." + fileextantion + "");
                Response.TransmitFile(Server.MapPath(lbl_filename.Text));
                Response.Flush();
                Response.End();
            }
          
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg == "StartIndex cannot be less than zero.\\r\\nParameter name: startIndex")
                    msg = "لا يوجد ملف لتحميله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_new_dtls_Click(object sender, ImageClickEventArgs e)
        {
            clear();
            gvs_invdtls.Selection.CancelSelection();
            gvs_invdtls.DataBind();
        }

        protected void btn_delete_dtls_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ms.s_invdtls_del(Convert.ToInt16(HFsinviddtl.Value));
                gvs_invdtls.Selection.CancelSelection();
                gvs_invdtls.DataBind();
                ////// update  vatvalue,netavat,netavat
                update_inv_vatvalue();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }

           
        }

        //protected void gvs_invdtls_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        //{
        //    if (e.Column.FieldName == "netvalue")
        //    {
        //        decimal netvalue = Convert.ToDecimal(e.GetListSourceFieldValue("RISK"));
        //        //decimal mv = Convert.ToDecimal(e.GetListSourceFieldValue("MV_BERND"));
        //        //decimal ipotek = Convert.ToDecimal(e.GetListSourceFieldValue("IPOTEK"));
        //        e.Value = netvalue;
        //        txt_netavat.Text = e.Value.ToString();


        //    }

        //}
        //protected void gvs_invdtls_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        //{
        //    ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["netvalue"];
        //  //  ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
        //    Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
        //   // Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
        //    e.TotalValue = income;
        //    txt_netavat.Text = e.TotalValue.ToString();

        //}

        //protected void gvs_invdtls_CustomSummaryCalculate1(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        //{
        //    ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["netvalue"];
        //    //  ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
        //    Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
        //    // Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
        //    e.TotalValue = income;
        //    txt_netavat.Text = e.TotalValue.ToString();

        //}
        void update_inv_vatvalue()
        {
            ////// update  vatvalue,netavat,netavat
            try
            { 
            string pathfile = null;
            if (FileUpload1.HasFile == true)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                lbl_filename.Text = pathfile;
            }

            else if (FileUpload1.HasFile == false && lbl_filename.Text != null || lbl_filename.Text != "")
            {
                pathfile = lbl_filename.Text;
            }
           // (int erro_id,string err_msg) = ms.s_inv_upd(int.Parse(HF_inv_id.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), pathfile);
               // if (erro_id == 0)
               // {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    // PDetiles.Visible = true;
              //  }
                clear();
        }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
              ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        }
    }

        protected void gvs_invdtls_DataBound(object sender, EventArgs e)
        {
            
            ASPxGridView gridView = sender as ASPxGridView;
            //  gridView.JSProperties["cpSummary"] = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]);
            if (gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]) == null || gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString() == "")
            {
                return;
            }
            txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
            txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
            txt_netbvat.Text = (Convert.ToDecimal(txt_netavat.Text) - Convert.ToDecimal(txt_vatvalue.Text)).ToString();
        }

        protected void HfItemID_ValueChanged(object sender, EventArgs e)
        {
            if (HfItemID.Value != "")
            {
                bind_items();
            }
        }

        protected void btn_new_dtls_Click1(object sender, ImageClickEventArgs e)
        {
           
            clear();
        }

        protected void Hfcusid_ValueChanged(object sender, EventArgs e)
        {
            if (Hfcusid.Value != "")
            {
                DataTable dt = ms.s_customers_sel_custid(Convert.ToInt32(Hfcusid.Value));
                if (dt.Rows.Count > 0)
                {
                    txt_cusid.Text = dt.Rows[0]["custcode"].ToString();
                    txt_cusname.Text = dt.Rows[0]["custname"].ToString();
                    txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
                    txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
                   
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
                    txt_cusid.Text = "0";
                }
            }
        }
    }
    
}