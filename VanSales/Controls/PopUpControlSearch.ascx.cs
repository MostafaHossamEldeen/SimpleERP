using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Controls
{
    public partial class PopUpControlSearch : System.Web.UI.UserControl
    {
        [Browsable(true)]
        public string PkField { get; set; }
        [Browsable(true)]
        public string ValueControle { get; set; }
        [Browsable(true)]
        public string DisplayFields { get; set; }
        [Browsable(true)]
        public string DisplayFieldsHidden { get; set; }

        [Browsable(true)]
        public string BindFields { get; set; }
        [Browsable(true)]
        public string BindControls { get; set; }
        [Browsable(true)]
        public string DisplayFieldsCaption { get; set; }
        [Browsable(true)]
        public string TableName { get; set; }
        [Browsable(true)]
        public string ParamaterNames { get; set; }
        [Browsable(true)]
        public string ParamaterTypes { get; set; }
        [Browsable(true)]
        public object[] ParamaterObject { get; set; }
        [Browsable(true)]
        public string ApiUrl { get; set; }
        DataTable dataTable; 
        protected  void Page_Load(object sender, EventArgs e)
        {


            //if (EmaxGlobals.NullToEmpty( txt_search).Length==0)
            //{
            //    grdviewdata.DataSource = GetData();
            //}
            //else
            //{
            //    grdviewdata.DataSource = GetData(txt_search.Text);
            //}

            //grdviewdata.KeyFieldName = PkField;
            //    ReCreateColumns();

            //    fieldssearch.Value = BindFields;
            //    controlstodisplaysearch.Value = BindControls;

            //grdviewdata.DataBind();
            //}

            //HiddenField fields_search = new HiddenField();
            //fields_search.ID = "fields_search";

            fields_search.Value = DisplayFields;
            //HiddenField controlstodisplay_search = new HiddenField();
            //controlstodisplay_search.ID = "controlstodisplay_search";
            controlstodisplay_search.Value = BindControls;
            //HiddenField tablename_hf_search = new HiddenField();
            //tablename_hf_search.ID = "tablename_hf_search";
            //tablename_hf_search.Value = BindControls;
            tablename_hf_search.Value = TableName;
            fieldshidden_search.Value = DisplayFieldsHidden;
            fieldscaption_search.Value = DisplayFieldsCaption;
            apiurl_hf_search.Value = ApiUrl;
            hf_params_search.Value = ParamaterNames;
            hf_bindefields_search.Value = BindFields;
        }
        //DataTable GetData(string searchval="")
        //{
        //    Dictionary<object, object> dict = new Dictionary<object, object>();
        //    //var paramnames = ParamaterNames.Split(',');
        //    //var paramsval = ParamaterTypes.Split(',');
        //    ////SqlCommandHelper.GetDxObjectValue();
        //    //for (int i = 0; i < paramnames.Length; i++)
        //    //{
        //    //    dict.Add(paramnames[i], paramsval[i]);
        //    //}
        //    dict.Add("searchval", searchval);
         
        //    dataTable = SqlCommandHelper.ExcecuteToDataTable(TableName, dict).dataTable;
        //    return dataTable;
        //}
        private void ReCreateColumns()
        {
            //grdviewdata.Columns.Clear();
            //string[] displayiedcolumn = DisplayFields.Split(',');
            //string[] displayiedhiddencolumn = DisplayFieldsHidden.Split(',');
            //string[] fieldcaption = { };
            //if (DisplayFieldsCaption.Length != 0)
            //{
            //    fieldcaption = DisplayFieldsCaption.Split(',');
            //}
            //for (int i = 0; i < displayiedcolumn.Length; i++)
            //{
            //    GridViewDataTextColumn column = new GridViewDataTextColumn();
            //    column.FieldName = displayiedcolumn[i];
            //    if (i==0)
            //    {
            //        column.Width = Unit.Percentage(10);
            //    }e
            //    // set additional column properties
            //    column.Caption = fieldcaption.Length != 0 ? fieldcaption[i] : displayiedcolumn[i];
            //    grdviewdata.Columns.Add(column);
            //}

            //for (int i = 0; i < displayiedhiddencolumn.Length; i++)
            //{
            //    GridViewDataTextColumn column = new GridViewDataTextColumn();
            //    column.FieldName = displayiedhiddencolumn[i];
            //    column.Visible = false;
            //    grdviewdata.Columns.Add(column);
            //}


        }

        protected void grdviewdata_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
           
          
            //grdviewdata.KeyFieldName = PkField;
            
          
            //fields.Value = BindFields;
            //controlstodisplay.Value = BindControls;
            //ReCreateColumns(); 
            //grdviewdata.DataSource= GetData(e.Parameters.Count()!=0&&e.Parameters.Length!=0?e.Parameters:""); ;  
            //grdviewdata.DataBind();
        }

        protected void grdviewdata_DataBinding(object sender, EventArgs e)
        {
            
        }
    }
}