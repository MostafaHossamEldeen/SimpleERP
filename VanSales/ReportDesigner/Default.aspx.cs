using DevExpress.Web;
using System;
using System.Collections.Generic;

namespace VanSales.ReportDesginer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cmb_SelectModule.DataSource = GetDir();
            Cmb_SelectModule.TextField = "ModuleName";
            Cmb_SelectModule.ValueField = "DirValue";
            Cmb_SelectModule.DataBind();
        }
        List<ReportDirectory> GetDir()
        {
            return new List<ReportDirectory>() { new ReportDirectory { DirValue = "Sales", ModuleName = "Sales" } ,
                new ReportDirectory { DirValue = "Purchase", ModuleName = "Purchase" },new ReportDirectory { DirValue = "Stock", ModuleName = "Stock" }
               ,new ReportDirectory { DirValue = "GL", ModuleName = "GL" },new ReportDirectory { DirValue = "pay_rec", ModuleName = "pay_rec" }
               ,new ReportDirectory { DirValue = "Sys", ModuleName = "Sys" } ,new ReportDirectory { DirValue = "HR", ModuleName = "HR" }};
        }

        protected void Cmb_SelectModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ASPxComboBox;
            Session["storagepath"] = @"~\ReportFiles\" + cmb.Value;
        }
    }
    public class ReportDirectory
    {
        public string ModuleName { get; set; }
        public string DirValue { get; set; }
    }
}