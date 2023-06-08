using Emax.Core.Utility;
using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Stock
{
    public partial class Inventorys : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "21";
            IndexStored = "st_inventory_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvinventory.DataBind();
        }
        protected void gvinventory_DataBinding(object sender, EventArgs e)
        {
            gvinventory.DataSource = IndexDataTable;
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "سندات الجرد";
                ExportingDevExpressUtil.Export(gvinventoryExporter, exptitle, 1, Request.GetOwinContext().Request.User.Identity.Name, gvinventory.GetSelectedFieldValues("inventid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_docexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "سندات الجرد";
                ExportingDevExpressUtil.Export(gvinventoryExporter, exptitle, 0, Request.GetOwinContext().Request.User.Identity.Name, gvinventory.GetSelectedFieldValues("inventid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_pdfexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "سندات الجرد";
                ExportingDevExpressUtil.Export(gvinventoryExporter, exptitle, 2, Request.GetOwinContext().Request.User.Identity.Name, gvinventory.GetSelectedFieldValues("inventid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_printexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "سندات الجرد";
                ExportingDevExpressUtil.Export(gvinventoryExporter, exptitle, 2, Request.GetOwinContext().Request.User.Identity.Name, gvinventory.GetSelectedFieldValues("inventid").Count != 0, true, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
    }
}