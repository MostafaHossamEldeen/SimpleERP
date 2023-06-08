using DevExpress.Web;
using Emax.Dal;
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
    public partial class PopUpControl : System.Web.UI.UserControl
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
        public string ApiUrl { get; set; }
        DataTable dataTable; 
        protected  void Page_Load(object sender, EventArgs e)
        {

           
           




        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            HiddenField fields_search = new HiddenField();
            fields_search.ID = "fields_search";
            fields_search.ClientIDMode = ClientIDMode.Static;

            this.Controls.Add(fields_search);
            HiddenField hf_params_search = new HiddenField();
            hf_params_search.ID = "hf_params_search";
            hf_params_search.ClientIDMode = ClientIDMode.Static;
            Controls.Add(hf_params_search);
            HiddenField controlstodisplay_search = new HiddenField();
            controlstodisplay_search.ID = "controlstodisplay_search";
            controlstodisplay_search.ClientIDMode = ClientIDMode.Static;
            Controls.Add(controlstodisplay_search);
            HiddenField fieldshidden_search = new HiddenField();
            fieldshidden_search.ID = "fieldshidden_search";
            fieldshidden_search.ClientIDMode = ClientIDMode.Static;
            Controls.Add(fieldshidden_search);
            HiddenField fieldscaption_search = new HiddenField();
            fieldscaption_search.ID = "fieldscaption_search";
            fieldscaption_search.ClientIDMode = ClientIDMode.Static;
            Controls.Add(fieldscaption_search);
            HiddenField tablename_hf_search = new HiddenField();
            tablename_hf_search.ID = "tablename_hf_search";
            tablename_hf_search.ClientIDMode = ClientIDMode.Static;
            Controls.Add(tablename_hf_search);
            HiddenField apiurl_hf_search = new HiddenField();
            apiurl_hf_search.ID = "apiurl_hf_search";
            apiurl_hf_search.ClientIDMode = ClientIDMode.Static;
            Controls.Add(apiurl_hf_search);
            HiddenField hf_bindefields_search = new HiddenField();
            hf_bindefields_search.ID = "hf_bindefields_search";
            hf_bindefields_search.ClientIDMode = ClientIDMode.Static;
            Controls.Add(hf_bindefields_search);

            fields_search.Value = DisplayFields;

            controlstodisplay_search.Value = BindControls;

            tablename_hf_search.Value = TableName;
            fieldshidden_search.Value = DisplayFieldsHidden;
            fieldscaption_search.Value = DisplayFieldsCaption;
            apiurl_hf_search.Value = ApiUrl;
            hf_params_search.Value = ParamaterNames;
            hf_bindefields_search.Value = BindFields;
            btn_search.JSProperties["cpshowmodal"] = "1";
            // btn_search.SetClientSideEventHandler("Click","function(s,e){createPopUp(s,e)}");
         

        }

        protected void btn_search_Load(object sender, EventArgs e)
        {
           // btn_search.ClientSideEvents.Click = "createPopUp()";
        }
    }
}