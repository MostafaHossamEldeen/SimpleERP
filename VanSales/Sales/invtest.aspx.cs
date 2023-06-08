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
using System.Text;
using Emax.Dal;
using System.Collections.Specialized;

namespace VanSales
{
    public partial class invtest : EmaxBasepage
    {
        SalesInv ms = new SalesInv();
        //int unitid;
        protected override void OnInit(EventArgs e)
        {
            pageid = "4";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // btn_print.Attributes.Add("onclick", "this.form.target='_blank'");
            //lbl_msg.Text = "";

            if (!IsPostBack)
            {

                HF_inv_id.Value = Request.Params["sinvid"];
                sinvdata.Date = DateTime.Now;
                dll_sinvpay.SelectedIndex = 0;
                txt_suser.Text = Context.User.Identity.Name;
                //lbl_msg.Text = "";
            }
            
            //ClientScript.RegisterOnSubmitStatement(btn_delete.GetType(), "confirm", "return confirm('هل تريدالحذف؟');");
            // );
        }
        void clear()
        {

            txt_item.Text = string.Empty;
            txt_unit.Text = string.Empty;
            txt_qty.Text = "1";
            txt_price.Text = "0";
            txt_value.Text = "0";
            txt_discp.Text = "0";
            txt_discvalue.Text = "0";
            txt_netvalue.Text = "0";
            txt_itemvatvalue.Text = "0";
            txt_itemnotes.Text = string.Empty;
            txt_item_name.Text = string.Empty;
            HFsinviddtl.Value = "";
            HfItemID.Value = "";
            Hfvat.Value = "";
            hf_qty.Value = "";
            hf_disc.Value = "";
            //lbl_msg.Text = string.Empty;
           
        }
        void clear_inv()
        {
            clear();
            Clear_pay();
            txt_sinvno.Text = string.Empty;
            txt_sinvno.Text = "تلقائى";
            txt_sinvdocno.Text = string.Empty;

            sinvdata.Text = string.Empty;
            txt_sinvtime.Text = string.Empty;
            dll_sinvpay.Text = string.Empty;
            dll_sinvpay.Value = string.Empty;
            dll_sman.Text = string.Empty;
            dll_sman.Value = string.Empty;
            // dll_sinvpay.Items.Clear();
            //dll_snature.Items.Clear();
           // txt_cus_id_req.Enabled = false;
            txt_cusid.Text = string.Empty;
            txt_custvat.Text = string.Empty;
            txt_cusname.Text = string.Empty;
            txt_custadd.Text = string.Empty;
            txt_suser.Text = Context.User.Identity.Name;
            txt_snotes.Text = string.Empty;
            txt_restvalue.Text = "0";
            txt_netbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_netavat.Text = "0";
            HF_inv_id.Value = "";
            sinvdata.Date = DateTime.Now;
            dll_sinvpay.SelectedIndex = 0;
            lbl_filename.Text = string.Empty;
            gvs_invdtls.DataBind();
            gv_invpay.DataBind();
            //lbl_msg.Text = string.Empty;
        }
        void Clear_pay()
        {
            txt_payno.Text = string.Empty;
            txt_payref.Text = string.Empty;
            txt_payvalue.Text = 0.ToString();
            dll_paytype.Text = string.Empty;
            dll_paytype.Value = string.Empty;
            dll_paytype.SelectedIndex = 0;
            Hfpayid.Value = "";
          //lbl_msg.Text = string.Empty;
        }
        void bind()
        {

            DataTable dt = ms.s_inv_sel_id(Convert.ToInt32(HF_inv_id.Value));
            txt_sinvno.Text = dt.Rows[0]["sinvno"].ToString();
            txt_sinvdocno.Text = dt.Rows[0]["sinvdocno"].ToString();
            dll_sinvpay.Text = dt.Rows[0]["sinvpayname"].ToString();
            dll_sinvpay.Value = dt.Rows[0]["sinvpay"].ToString();
            dll_sman.Text = dt.Rows[0]["smanname"].ToString();
            dll_sman.Value = dt.Rows[0]["smanid"].ToString();
            if (dll_sman.Text == "0" || dll_sman.Text == "")
            {
                dll_sman.Text = null;
            }
            sinvdata.Date = Convert.ToDateTime(dt.Rows[0]["sinvdata"].ToString());
            txt_sinvtime.Text = dt.Rows[0]["sinvtime"].ToString();
            txt_cusid.Text = dt.Rows[0]["custid"].ToString();
            txt_cusname.Text = dt.Rows[0]["custname"].ToString();
            txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
            txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
            txt_suser.Text = dt.Rows[0]["suser"].ToString();
            txt_snotes.Text = dt.Rows[0]["snotes"].ToString();
            txt_netbvat.Text = dt.Rows[0]["netbvat"].ToString();
            txt_vatvalue.Text = dt.Rows[0]["vatvalue"].ToString();
            txt_netavat.Text = dt.Rows[0]["netavat"].ToString();
            lbl_filename.Text = dt.Rows[0]["invdoc"].ToString();//.Replace("~/Files/","");
            //HFsInvid.Value = sinvid;
            Visible();
           // PDetiles.Visible = true;
          //  p_invpay.Visible = true;
            // accordion.Visible = true;
            //h11.Visible = true;
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
                Hfvat.Value = dt.Rows[0]["vat"].ToString();
                // HfItemID.Value = dt.Rows[0]["itemid"].ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
                clear();
            }
        }
        void Visible()
        {
            PDetiles.Visible = true;
            p_invpay.Visible = true;
            dll_paytype.SelectedIndex = 0;
        }
        void clear_gvinvpay_select()
        {
            int row = gv_invpay.FocusedRowIndex;
            gv_invpay.Selection.UnselectRow(row);
        }
        void clear_gvs_invdtls_select()
        {
            int row = gvs_invdtls.FocusedRowIndex;
            gvs_invdtls.Selection.UnselectRow(row);
        }
        protected void txt_netvalue_TextChanged(object sender, EventArgs e)
        {

        }


       
        //protected void btn_Save_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        //if (!Directory.Exists(@"~\Files"))
        //        //{
        //        //    Directory.CreateDirectory(@"~\Files");
        //        //}

        //        if (txt_sinvno.Text == "تلقائى")
        //        {
        //           // string pathfile = "";
        //            try
        //            {
                       
        //              //  FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
        //               // pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                        
        //            }
        //            catch { }

        //            (int erro_id, string inv_no, string time) = ms.s_inv_ins("فاتوره", txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, txt_cusid.Text.Length==0?0: Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_filename.Text);

        //            if (erro_id == 0)
        //            {
        //                txt_sinvno.Text = inv_no;
        //                txt_sinvtime.Text = time.ToString();
        //                Visible();
        //               // PDetiles.Visible = true;
        //               // p_invpay.Visible = true;
        //                //  accordion.Visible = true;
        //                //  h11.Visible = true;
        //            }
        //        }
        //        else
        //        {
        //            Visible();
        //            //PDetiles.Visible = true;
        //           // p_invpay.Visible = true;
        //            // accordion.Visible = true;
        //            //  h11.Visible = true;
        //            //string pathfile = null;
        //            //if (FileUpload1.HasFile == true)
        //            //{
        //            //    FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
        //            //    pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
        //            //    lbl_filename.Text = pathfile;
        //            //}

        //            //else if (FileUpload1.HasFile == false && lbl_filename.Text != null || lbl_filename.Text != "")
        //            //{
        //            //    pathfile = lbl_filename.Text;
        //            //}
        //            if (HF_inv_id.Value == "")
        //            {
        //                DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
        //                HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();
        //            }
        //            int erro_id = ms.s_inv_upd(int.Parse(HF_inv_id.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_filename.Text);
        //            if (erro_id == 0)
        //            {
        //                ms.s_invdtls_upd(0, Convert.ToInt16(HF_inv_id.Value), 0, 0, 0, 0,0,0,0, 0, 0, "", 1, 11, Convert.ToDateTime(sinvdata.Text), Convert.ToInt32(txt_cusid.Text), txt_sinvno.Text, "",0);
        //                ms.s_invpay_upd(0, Convert.ToInt16(HF_inv_id.Value), 0, 0, "", "", sinvdata.Date, Convert.ToInt32(txt_cusid.Text), txt_sinvno.Text, "",0);

        //                Visible();
                       
        //              //  ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
        //            }
        //        }
       
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //        if (msg == "Input string was not in a correct format.")
        //            msg = "برجاء التأكد من البيانات المدخله";
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        //    }
        //}
        protected void btn_Save_Click(object sender, EventArgs e)
        {

            try
            {

                //if (txt_cusname.Text == ""|| dll_sinvpay.SelectedIndex==1 && txt_cusid.Text==""||sinvdata.Text=="")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "validate(s, e);", true);
                //    return;
                //}
                if (dll_sman.Value == null)
                {
                    dll_sman.Value = 0;
                    dll_sman.Text = null;
                }
                if (txt_sinvno.Text == "تلقائى")
                {
                    //// string pathfile = "";
                    //try
                    //{

                    //    //  FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                    //    // pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);

                    //}
                    //catch { }

                    (int erro_id, string inv_no, string time,string error_msg) = ms.s_inv_ins("فاتوره", txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_filename.Text, Convert.ToInt16(dll_sman.Value), dll_sman.Text,11,"");

                    if (erro_id == 0)
                    {
                        txt_sinvno.Text = inv_no;
                        txt_sinvtime.Text = time.ToString();
                        Visible();
                        
                      
                    }
                }
                else
                {
                    Visible();
                    
                  
                    if (HF_inv_id.Value == "")
                    {
                        DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
                        HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();
                    }
                    (int erro_id,string err_msg) = ms.s_inv_upd(int.Parse(HF_inv_id.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_filename.Text, Convert.ToInt16(dll_sman.Value), dll_sman.Text);
                    if (erro_id == 0)
                    {
                        (int erro_id_dtl, string err_msg_dtl) = ms.s_invdtls_upd(0, Convert.ToInt16(HF_inv_id.Value), 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 1, 11, Convert.ToDateTime(sinvdata.Text), txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_sinvno.Text, "", 0);
                        (int erro_id_pay, string err_msg_pay) = ms.s_invpay_upd(0, Convert.ToInt16(HF_inv_id.Value), 0, 0, "", "", sinvdata.Date, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_sinvno.Text, "", 0);

                        Visible();
                      //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pop", "openModal();", true);
                      //  UpdatePanel1.Update();
                         // lbl_msg.Text = err_msg;
                       

                          ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('"+ err_msg + "');", true);
                    }
                }

            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg == "Input string was not in a correct format.")
                    msg = "برجاء التأكد من البيانات المدخله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }
        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear_inv();
            PDetiles.Visible = false;
            p_invpay.Visible = false; 
         
             //Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
         
        
            try
            {

                //  ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Form submitted.');", true);
                //string confirmValue = Request.Form["conf"];
                //if (confirmValue == "نعم")
                //{
              
                if (HF_inv_id.Value == "")
                {
                    DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
                    HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();                
                }

                (int erro_id, string error_msg) = ms.s_inv_del(Convert.ToInt32(HF_inv_id.Value));
                    clear_inv();
                    PDetiles.Visible = false;
                    p_invpay.Visible = false;
                //}
                //else
                //{
                //}
            }
            catch (Exception ex)
            {
                if (HF_inv_id.Value == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا توجد فاتوره للحذف')", true);
                    return;
                }
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
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
            try
            {
                clear();
                if (gvs_invdtls.GetSelectedFieldValues("itemcode").Count != 0)
                {


                    txt_item.Text = gvs_invdtls.GetSelectedFieldValues("itemcode")[0].ToString();
                    txt_item_name.Text = gvs_invdtls.GetSelectedFieldValues("itemname")[0].ToString();
                    txt_unit.Text = gvs_invdtls.GetSelectedFieldValues("unitname")[0].ToString();
                    Hfuntid.Value = gvs_invdtls.GetSelectedFieldValues("unitid")[0].ToString();
                    hf_qty.Value = gvs_invdtls.GetSelectedFieldValues("qty")[0].ToString();
                    txt_qty.Text = gvs_invdtls.GetSelectedFieldValues("qty")[0].ToString();
                    txt_price.Text = gvs_invdtls.GetSelectedFieldValues("price")[0].ToString();
                    txt_value.Text = gvs_invdtls.GetSelectedFieldValues("value")[0].ToString();
                    txt_discp.Text = gvs_invdtls.GetSelectedFieldValues("discp")[0].ToString();
                    hf_disc.Value = gvs_invdtls.GetSelectedFieldValues("discvalue")[0].ToString();
                    txt_discvalue.Text = gvs_invdtls.GetSelectedFieldValues("discvalue")[0].ToString();
                    txt_netvalue.Text = gvs_invdtls.GetSelectedFieldValues("netvalue")[0].ToString();
                    txt_itemvatvalue.Text = gvs_invdtls.GetSelectedFieldValues("vatvalue")[0].ToString();
                    txt_itemnotes.Text = gvs_invdtls.GetSelectedFieldValues("itemnotes")[0].ToString();
                    HFsinviddtl.Value = gvs_invdtls.GetSelectedFieldValues("invdtlid")[0].ToString();
                }
                DataTable dt = ms.st_items_sel_item_code(txt_item.Text);
                if (dt.Rows.Count > 0)
                {
                    Hfvat.Value = dt.Rows[0]["vat"].ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + ex + "')", true);
            }
        }

        //protected void btn_save_dtls_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (HFsinviddtl.Value == "" || HFsinviddtl.Value == "0")
        //    {
        //        try
        //        {
        //            DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
        //            HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();
        //            //, txt_unit.Text
        //            int error_id = ms.s_invdtls_ins(Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(HfItemID.Value), Convert.ToInt16(Hfuntid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txt_itemvatvalue.Text), txt_itemnotes.Text, 1, 11, sinvdata.Date, Convert.ToInt32(txt_cusid.Text), txt_sinvno.Text, "");
        //            gvs_invdtls.DataBind();
        //            ////// update  vatvalue,netavat,netavat
        //            update_inv_vatvalue();
        //            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
        //            clear();
        //            clear_gvs_invdtls_select();
        //        }
        //        catch (Exception ex)
        //        {
        //            string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //            if (msg == "Input string was not in a correct format.")
        //                msg = "برجاء التأكد من البيانات المدخله";
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            DataTable dt = ms.st_items_sel_item_code(txt_item.Text);

        //            HfItemID.Value = dt.Rows[0]["itemid"].ToString();
        //            //Hfuntid.Value =  dt.Rows[0]["unitid"].ToString());


        //            ms.s_invdtls_upd(Convert.ToInt16(HFsinviddtl.Value), Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(HfItemID.Value), Convert.ToInt16(Hfuntid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txt_itemvatvalue.Text), txt_itemnotes.Text, 1, 11, Convert.ToDateTime(sinvdata.Text), Convert.ToInt32(txt_cusid.Text), txt_sinvno.Text, "",1);
        //            gvs_invdtls.DataBind();
        //            ////// update  vatvalue,netavat,netavat
        //            update_inv_vatvalue();
        //            // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
        //            clear();
        //            clear_gvs_invdtls_select();

        //        }
        //        catch (Exception ex)
        //        {

        //            string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //            if (msg == "Input string was not in a correct format.")
        //                msg = "برجاء التأكد من البيانات المدخله";
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);

        //        }

        //    }
        //}
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
         
            if (txt_item.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء التأكد من البيانات المدخله')", true);
            }
            if (HFsinviddtl.Value == "" || HFsinviddtl.Value == "0")
            {
                try
                {
                    DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
                    HF_inv_id.Value = dt.Rows[0]["sinvid"].ToString();
                    //, txt_unit.Text
                    
                   ( int error_id, string error_msg) = ms.s_invdtls_ins(Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(HfItemID.Value), Convert.ToInt16(Hfuntid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txt_itemvatvalue.Text), txt_itemnotes.Text, 1, 11, sinvdata.Date, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_sinvno.Text, "");
                    gvs_invdtls.DataBind();
                    ////// update  vatvalue,netavat,netavat
                    update_inv_vatvalue();
                    //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    clear();
                    clear_gvs_invdtls_select();
                }
                catch (Exception ex)
                {
                    string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                    if (msg == "Input string was not in a correct format.")
                        msg = "برجاء التأكد من البيانات المدخله";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
                }
            }
            else
            {
                try
                {
                    DataTable dt = ms.st_items_sel_item_code(txt_item.Text);

                    HfItemID.Value = dt.Rows[0]["itemid"].ToString();
                    //Hfuntid.Value =  dt.Rows[0]["unitid"].ToString());


                    (int erro_id, string err_msg) = ms.s_invdtls_upd(Convert.ToInt16(HFsinviddtl.Value), Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(HfItemID.Value), Convert.ToInt16(Hfuntid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txt_itemvatvalue.Text), txt_itemnotes.Text, 1, 11, Convert.ToDateTime(sinvdata.Text), txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_sinvno.Text, "", 1);
                    gvs_invdtls.DataBind();
                    ////// update  vatvalue,netavat,netavat
                    update_inv_vatvalue();
                    // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    clear();
                    clear_gvs_invdtls_select();

                }
                catch (Exception ex)
                {

                    string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                    if (msg == "Input string was not in a correct format.")
                        msg = "برجاء التأكد من البيانات المدخله";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);

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
                    Hfuntid.Value = dt.Rows[0]["unitid"].ToString();
                    HfItemID.Value = dt.Rows[0]["itemid"].ToString();
                    Hfvat.Value = dt.Rows[0]["vat"].ToString();
                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('هذا الكود غير موجود ')", true);
                    clear();
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }

        protected void btn_download_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (lbl_filename.Text == "") 
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('لا يوجد ملف')", true);
                //    return;
                //}
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
                if (msg.Contains( "لا يمكن أن يكون StartIndex أقل من الصفر.\\r\\nاسم المعلمة: startIndex") || msg.Contains("StartIndex cannot be less than zero.\\r\\nParameter name: startIndex"))
                    msg = "لا يوجد ملف لتحميله";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetinfo('" + msg + "')", true);
            }
        }
        protected void btn_new_dtls_Click(object sender, EventArgs e)
        {
            clear_gvs_invdtls_select();
            clear();
          
        }
        //protected void btn_new_dtls_Click(object sender, ImageClickEventArgs e)
        //{
        //    clear();
        //    gvs_invdtls.Selection.CancelSelection();
        //    gvs_invdtls.DataBind();
        //    clear_gvs_invdtls_select();
        //}

        //protected void btn_delete_dtls_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        if (HFsinviddtl.Value == "" || HFsinviddtl.Value == null)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('برجاء اختيار الصنف للحذف')", true);

        //        }
        //        else
        //        {
        //            ms.s_invdtls_del(Convert.ToInt16(HFsinviddtl.Value));
        //            gvs_invdtls.Selection.CancelSelection();
        //            gvs_invdtls.DataBind();
        //            ////// update  vatvalue,netavat,netavat
        //            update_inv_vatvalue();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        //    }


        //}
        protected void btn_delete_dtls_Click(object sender, EventArgs e)
        {
            try
            {
                if (HFsinviddtl.Value == "" || HFsinviddtl.Value == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء اختيار الصنف للحذف')", true);

                }
                else
                {
                    (int erro_id, string error_msg) = ms.s_invdtls_del(Convert.ToInt16(HFsinviddtl.Value));
                    gvs_invdtls.Selection.CancelSelection();
                    gvs_invdtls.DataBind();
                    ////// update  vatvalue,netavat,netavat
                    update_inv_vatvalue();
                }
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
                //string pathfile = null;
                //if (FileUpload1.HasFile == true)
                //{
                //    FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                //    pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                //    lbl_filename.Text = pathfile;
                //}

                //else if (FileUpload1.HasFile == false && lbl_filename.Text != null || lbl_filename.Text != "")
                //{
                //    pathfile = lbl_filename.Text;
                //}
                (int erro_id,string err_msg) = ms.s_inv_upd(int.Parse(HF_inv_id.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(sinvdata.Text), Convert.ToInt16(dll_sinvpay.SelectedItem.Value), dll_sinvpay.SelectedItem.Text, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_cusname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_filename.Text, Convert.ToInt16(dll_sman.Value), dll_sman.Text);
                if (erro_id == 0)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                    // PDetiles.Visible = true;
                }
                clear();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
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
            if (txt_restvalue.Text == "0")
                txt_restvalue.Text = txt_netavat.Text;
            else
            {
                decimal rest = Convert.ToDecimal(gv_invpay.GetTotalSummaryValue(gv_invpay.TotalSummary["payvalue"]).ToString());

                txt_restvalue.Text = (Convert.ToDecimal(txt_netavat.Text) - rest).ToString();
            }
        }

        protected void HfItemID_ValueChanged(object sender, EventArgs e)
        {
            if (HfItemID.Value != "")
            {
                txt_item.Text = string.Empty;
                txt_unit.Text = string.Empty;
                txt_qty.Text = "1";
                txt_price.Text = "0";
                txt_value.Text = "0";
                txt_discp.Text = "0";
                txt_discvalue.Text = "0";
                txt_netvalue.Text = "0";

                txt_itemvatvalue.Text = "0";
                txt_itemnotes.Text = string.Empty;
                txt_item_name.Text = string.Empty;
                HFsinviddtl.Value = "";

                Hfvat.Value = "";
                bind_items();
            }
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
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('هذا الكود غير موجود ')", true);
                    //txt_cusid.Text = "0";
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "cus_validate();", true);
            }
        }

        //protected void dll_sinvpay_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //if (dll_sinvpay.SelectedIndex == 1)
        //    //{
        //    //  //  txt_cusid.Text = "";
        //    //    //txt_cus_id_req.Enabled = true;
        //    //  //  return;
        //    //}
        //}

        protected void ctn_add_cus_Click(object sender, EventArgs e)
        {
            // Response.Redirect("customers.aspx");
        }
        protected void gv_invpay_SelectionChanged(object sender, EventArgs e)
        {
            //OrderedDictionary orderedDictionary = new OrderedDictionary();
            //orderedDictionary.Add()
            //Clear_pay();
            if (gv_invpay.GetSelectedFieldValues("payno").Count != 0)
            {

                txt_payno.Text = gv_invpay.GetSelectedFieldValues("payno")[0].ToString();
            txt_payref.Text = gv_invpay.GetSelectedFieldValues("payref")[0].ToString();
            txt_payvalue.Text = gv_invpay.GetSelectedFieldValues("payvalue")[0].ToString();

            dll_paytype.Text = gv_invpay.GetSelectedFieldValues("payname")[0].ToString();
            dll_paytype.Value = gv_invpay.GetSelectedFieldValues("paytypeid")[0].ToString();

            Hfpayid.Value = gv_invpay.GetSelectedFieldValues("invpayid")[0].ToString();
              }
        }
        protected void btn_save_pay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_payvalue.Text == ""|| txt_payvalue.Text == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء ادخال القيمه اولا')", true);
                }
                if (Hfpayid.Value == "")
                {
                  
                    (int error_id,string error_msg) = ms.s_invpay_ins(Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(dll_paytype.SelectedItem.Value), Convert.ToDouble(txt_payvalue.Text), txt_payno.Text, txt_payref.Text, sinvdata.Date, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_sinvno.Text, "");
                    if (error_id == 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                    }
                    else
                    {
                        gv_invpay.DataBind();
                        update_inv_vatvalue();
                        Clear_pay();
                        clear_gvinvpay_select();

                    }
                }
                else
                {
                    (int error_id, string error_msg)  = ms.s_invpay_upd(Convert.ToInt32(Hfpayid.Value), Convert.ToInt16(HF_inv_id.Value), Convert.ToInt16(dll_paytype.SelectedItem.Value), Convert.ToDouble(txt_payvalue.Text), txt_payno.Text, txt_payref.Text, sinvdata.Date, txt_cusid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_cusid.Text), txt_sinvno.Text, "",1);
                    if (error_id == 1)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                    }
                    else
                    {
                        gv_invpay.Selection.CancelSelection();
                        gv_invpay.DataBind();
                        update_inv_vatvalue();
                        Clear_pay();
                        clear_gvinvpay_select();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg == "Input string was not in a correct format.")
                    msg = "برجاء التأكد من البيانات المدخله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }

        protected void brn_new_pay_Click(object sender, EventArgs e)
        {
            Clear_pay();
            dll_paytype.SelectedIndex = 0;
            clear_gvinvpay_select();

        }

        protected void btn_delete_pay_Click(object sender, EventArgs e)
        {
            try
            {
                if ( Hfpayid.Value == "" || Hfpayid.Value == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء الاختيار  للحذف')", true);

                }
                else
                {

                    (int erro_id, string error_msg) = ms.s_invpay_del(Convert.ToInt32(Hfpayid.Value));
                    gv_invpay.DataBind();
                    update_inv_vatvalue();
                    Clear_pay();
                   
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }

        protected void gv_invpay_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView1 = sender as ASPxGridView;
            
            if (gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]) == null || gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]).ToString() == "")
            {
                return;
            }
            decimal rest =Convert.ToDecimal( gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]).ToString());
           
            txt_restvalue.Text = (Convert.ToDecimal(txt_netavat.Text) - rest).ToString();
        }

       

        protected void upload_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

            
            if (!Directory.Exists(Server.MapPath("~/Files/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Files/"));
            }

                if (txt_sinvno.Text == "تلقائى")
            {
                    if (FileUpload1.HasFile == false &&  lbl_filename.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                        return;
                    }
                FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                string pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                //Session["pathfile"] = pathfile;
                lbl_filename.Text = pathfile;
            }
            else
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
                        if (lbl_filename.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                            return;
                        }
                        pathfile = lbl_filename.Text;
                    }
                }
            }
            catch (Exception ex)
            {

                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }

        protected void txt_cusid_TextChanged(object sender, EventArgs e)
        {
         DataTable dt=  ms.s_customers_sel_custcode(txt_cusid.Text);
            if (dt.Rows.Count > 0)
            {
                txt_cusname.Text = dt.Rows[0]["custname"].ToString();
                txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
                txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
                Hfcusid.Value = dt.Rows[0]["custid"].ToString();
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('هذا العميل غير موجود ')", true);
                txt_cusid.Text = string.Empty;
                txt_cusname.Text = string.Empty;
                txt_custadd.Text = string.Empty;
                txt_custvat.Text = string.Empty;
               
            }
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "cus_validate();", true);
        }

        protected void gvs_invdtls_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            var f = e.NewValues["discp"];
            
            ((ASPxGridView)sender).CancelEdit();
        }











        //protected void txt_cusid_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dt = ms.s_customers_sel_custcode(txt_cusid.Text);
        //        if (dt.Rows.Count > 0)
        //        {
        //            txt_cusname.Text = dt.Rows[0]["custname"].ToString();
        //            txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
        //            txt_custadd.Text = dt.Rows[0]["custadd"].ToString();

        //            Hfcusid.Value = dt.Rows[0]["custid"].ToString();
        //        }
        //        else
        //        {
        //            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
        //            //clear();

        //            txt_cusname.Text = "";
        //            txt_custvat.Text = "";
        //            txt_custadd.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        //    }
        //}
    }

}