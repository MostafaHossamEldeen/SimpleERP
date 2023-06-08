using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;

namespace VanSales.HR
{
    public partial class hr_masterfiles : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "40";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var dict = new Dictionary<object, object>();
            dict.Add("compid", "28");
            dict.Add("table_name", "sys_fillcomp");
            cmbdoctype = Util.GenerateGridViewCmb(gvhr_masterfiles_doctype, "sys_fillcomp_sel", "mitemtype", "citemname", "citemid", "اختر", dict);
            gvhr_masterfiles_nations.DataBind();
            gvhr_masterfiles_jobs.DataBind();
            gvhr_masterfiles_doctype.DataBind();
            gvhr_masterfiles_vactions.DataBind();
        }
        public GridViewDataComboBoxColumn cmbdoctype { get; set; }

        #region nations
        protected void gvhr_masterfiles_nations_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("masterid", Convert.ToInt32("1"));
            gvhr_masterfiles_nations.DataSource = SqlCommandHelper.ExcecuteToDataTable("hr_masterfiles_sel", dict).dataTable;
        }

        protected void gvhr_masterfiles_nations_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_nations_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_nations.CancelEdit();
            }
        }

        protected void gvhr_masterfiles_nations_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("mersid", Convert.ToInt32(e.Keys[0]));
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_del", dict, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_nations.CancelEdit();
            }
        }
        #endregion

        #region jobs
        protected void gvhr_masterfiles_jobs_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_jobs_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_jobs.CancelEdit();
            }
        }

        protected void gvhr_masterfiles_jobs_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("masterid", Convert.ToInt32("2"));
            gvhr_masterfiles_jobs.DataSource = SqlCommandHelper.ExcecuteToDataTable("hr_masterfiles_sel", dict).dataTable;
        }

        protected void gvhr_masterfiles_jobs_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("mersid", Convert.ToInt32(e.Keys[0]));
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_del", dict, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_jobs.CancelEdit();
            }
        }
        #endregion

        #region document_type
        protected void gvhr_masterfiles_doctype_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_doctype_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_doctype.CancelEdit();
            }
        }

        protected void gvhr_masterfiles_doctype_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("masterid", Convert.ToInt32("3"));
            gvhr_masterfiles_doctype.DataSource = SqlCommandHelper.ExcecuteToDataTable("hr_masterfiles_sel", dict).dataTable;
        }

        protected void gvhr_masterfiles_doctype_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("mersid", Convert.ToInt32(e.Keys[0]));
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_del", dict, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_doctype.CancelEdit();
            }
        }
        #endregion

        #region vactions
        protected void gvhr_masterfiles_vactions_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_vactions_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_vactions.CancelEdit();
            }
        }

        protected void gvhr_masterfiles_vactions_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("masterid", Convert.ToInt32("4"));
            gvhr_masterfiles_vactions.DataSource = SqlCommandHelper.ExcecuteToDataTable("hr_masterfiles_sel", dict).dataTable;
        }

        protected void gvhr_masterfiles_vactions_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("mersid", Convert.ToInt32(e.Keys[0]));
            var g = SqlCommandHelper.ExecuteNonQuery("hr_masterfiles_del", dict, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_masterfiles_vactions.CancelEdit();
            }
        }
        #endregion
    }
}