using DevExpress.Web;
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
    public partial class PopUpCtl : System.Web.UI.UserControl
    {
        [Browsable(true)]
        public string ValueControle { get; set; }
        [Browsable(true)]
        public string  DisplayFields { get; set; }
        [Browsable(true)]
        public string  DisplayFieldsControls { get; set; }
        [Browsable(true)]
        public string DisplayFieldsCaption { get; set; }
        [Browsable(true)]
        public string TableName { get; set; }
        [Browsable(true)]
        public string  ParamaterNames { get; set; }
        [Browsable(true)]
        public string ParamaterValues { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Vansales"].ConnectionString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec " + TableName, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            grdviewdata.DataSource = dataTable;
            string[] fieldcaption = { };
            if (DisplayFieldsCaption.Length!=0)
            {
                fieldcaption = DisplayFieldsCaption.Split(',');
            }
            foreach (GridViewColumn item in grdviewdata.Columns)
            {
                item.Visible = DisplayFields.Contains(item.Name);
                item.Caption = fieldcaption.Where(i => i.ToString() == item.Name).FirstOrDefault();
            }
        }
    }
}