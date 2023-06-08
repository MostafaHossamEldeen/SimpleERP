using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data;
using System.IO;

namespace VanSales.HR
{
    public partial class hr_doc : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "45";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateRadioButtonList("sys_fillcomp_sel", rbl_doctynature, "compid,table_name", "28,sys_fillcomp", "citemid", "citemname");
                Util.GenerateRadioButtonList("sys_fillcomp_sel", rbl_datetype, "compid,table_name", "18,sys_fillcomp", "citemid", "citemname");
            }
            Util.GenerateCombobox("hr_document_type_sel", cmb_doctypeid, "mitemtype", rbl_doctynature.SelectedItem.Value.ToString(), "mitemcode", "mitemname");
        }
        List<object> getparam()
        {
            if (EmaxGlobals.NullToIntZero(HF_docid.Value) == 0)
            {
                return new List<object>
                { txt_docno,txt_empname,rbl_doctynature,cmb_doctypeid,txt_empname,rbl_datetype,txt_docexpiredate,img_docimg,HF_empid};
            }
            else
            {
                return new List<object>
                { HF_docid,txt_docno,txt_empname,rbl_doctynature,cmb_doctypeid,txt_empname,rbl_datetype,txt_docexpiredate,img_docimg,HF_empid};
            }
        }
        void BindData(DataRow rec)
        {
            img_docimg.ImageUrl = EmaxGlobals.NullToEmpty(rec["docimg"]);
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Dictionary<object, object> dictother = new Dictionary<object, object>();
            dictother.Add("docimg", Session["filePath"]);
          
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_docid.Value) == 0 ? "hr_doc_ins" : "hr_doc_upd", getparam(), null,
                EmaxGlobals.NullToIntZero(HF_docid.Value) == 0 ? new List<string>() { "docid"} : null, true, false,
                  new List<ParamObject>() { new ParamObject() { ParamName = "doctypname", ParamValue = cmb_doctypeid }},
                  dictother);
            if (res.errorid == 0)
            {
                if (res.outputparams != null && res.outputparams.Count > 0)
                {
                    HF_docid.Value = EmaxGlobals.NullToEmpty(res.outputparams["docid"]);
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                }
                else
                {
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                }
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("docid", HF_docid.Value);
                var f = SqlCommandHelper.ExcecuteToDataTable("hr_doc_sel_docid", dict).dataTable;
                BindData(f.Rows[0]);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
            }
        }
        protected void upd_docimg_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (!Directory.Exists(Server.MapPath("~/Img/Doc/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/FImgiles/Doc/"));
            }
            if (e.IsValid)
            {
                Session["fileName"] = e.UploadedFile.FileNameInStorage;
                Session["filePath"] = "~/Img/Doc/" + Session["fileName"].ToString();
                e.UploadedFile.SaveAs(MapPath(Session["filePath"].ToString()));
            }
        }
    }
}