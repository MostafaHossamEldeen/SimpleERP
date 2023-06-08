using DevExpress.Web;
using Emax.Dal;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
namespace Emax.SharedLib
{
   public class Util
    {
        public static GridViewDataComboBoxColumn GenerateGridViewCmb(ASPxGridView aSPxGridView, string spname, string fieldname
            ,string textfieldname="",string valuefieldname="",string nulltext="",Dictionary<object,object> param=null
            )

        {
            GridViewDataComboBoxColumn combo = aSPxGridView.Columns[fieldname] as GridViewDataComboBoxColumn;
            //combo.PropertiesComboBox.ValueType = typeof(int);
            combo.PropertiesComboBox.IncrementalFilteringMode = IncrementalFilteringMode.Contains;
            combo.PropertiesComboBox.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname,param).dataTable;
            combo.PropertiesComboBox.TextField =textfieldname==string.Empty?fieldname:textfieldname;
            combo.PropertiesComboBox.ValueField = valuefieldname == string.Empty ? fieldname : valuefieldname;
           
           // combo.PropertiesComboBox.TextFormatString = "{1}";
            combo.PropertiesComboBox.NullText = nulltext;
            combo.PropertiesComboBox.ClearButton.DisplayMode = ClearButtonDisplayMode.OnHover;
            
            return combo;
        }
        public static GridViewDataComboBoxColumn GenerateGridViewCmb(ASPxGridView aSPxGridView, string fieldname, string[] items, string[] values=null
         , string textfieldname = "", string valuefieldname = "", string nulltext = "", Dictionary<object, object> param = null
         )

        {
            GridViewDataComboBoxColumn combo = aSPxGridView.Columns[fieldname] as GridViewDataComboBoxColumn;
            //combo.PropertiesComboBox.ValueType = typeof(int);
            combo.PropertiesComboBox.IncrementalFilteringMode = IncrementalFilteringMode.Contains;

            combo.PropertiesComboBox.TextField = textfieldname == string.Empty ? fieldname : textfieldname;
            combo.PropertiesComboBox.ValueField = valuefieldname == string.Empty ? fieldname : valuefieldname;
            for (int i = 0; i < items.Length; i++)
            {
                combo.PropertiesComboBox.Items.Add(items[i], values != null ? values[i] : items[i]);
            }
          
            // combo.PropertiesComboBox.TextFormatString = "{1}";
            combo.PropertiesComboBox.NullText = nulltext;
            combo.PropertiesComboBox.ClearButton.DisplayMode = ClearButtonDisplayMode.OnHover;

            return combo;
        }
        public static void GenerateGridViewCmb( string spname, string fieldname, ASPxGridView aSPxGridView
        , string textfieldname = "", string valuefieldname = "", string nulltext = ""
        ,Dictionary<string,string> columns=null)

        {
            GridViewDataComboBoxColumn combo = aSPxGridView.Columns[fieldname] as GridViewDataComboBoxColumn;
            //combo.PropertiesComboBox.ValueType = typeof(int);
            combo.PropertiesComboBox.IncrementalFilteringMode = IncrementalFilteringMode.Contains;
            combo.PropertiesComboBox.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname);
            combo.PropertiesComboBox.TextField = textfieldname == string.Empty ? fieldname : textfieldname;
            combo.PropertiesComboBox.ValueField = valuefieldname == string.Empty ? fieldname : valuefieldname;
            combo.PropertiesComboBox.CallbackPageSize = 5;
            combo.PropertiesComboBox.DropDownRows = 5;
            // combo.PropertiesComboBox.TextFormatString = "{1}";
            combo.PropertiesComboBox.NullDisplayText = nulltext;
            combo.PropertiesComboBox.ClearButton.DisplayMode = ClearButtonDisplayMode.OnHover;
            combo.PropertiesComboBox.EnableCallbackMode = true;
        }

        #region comboboxnoramal
        public static ASPxComboBox GenerateCombobox(string spname,ASPxComboBox aSPxComboBox,string paramname,string paramvalue,string valuefieldname,string textfieldname="")
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            if (paramname.Contains(","))
            {
                var paraval = paramvalue.Split(',');
                var _paramname = paramname.Split(',');
                for (int i = 0; i < _paramname.Length; i++)
                {
                    dict.Add(_paramname[i], paraval[i]);
                }
            }
            if (dict.Count!=0)
            {
                aSPxComboBox.DataSource= SqlCommandHelper.ExcecuteToDataTable(spname, dict).dataTable;
            }
            else
            {
                aSPxComboBox.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname, paramname, paramvalue).dataTable;
            }
            aSPxComboBox.SelectedIndex = 0;
            aSPxComboBox.TextField = textfieldname.Length != 0 ? textfieldname : valuefieldname;
            aSPxComboBox.ValueField = valuefieldname;
            aSPxComboBox.DataBind();
            return aSPxComboBox;
        }
        public static ASPxRadioButtonList GenerateRadioButtonList(string spname, ASPxRadioButtonList ASPxRadioButtonList, string paramname, string paramvalue, string valuefieldname, string textfieldname = "", string RepeatDirection = "H")
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            if (paramname.Contains(","))
            {
                var paraval = paramvalue.Split(',');
                var _paramname = paramname.Split(',');
                for (int i = 0; i < _paramname.Length; i++)
                {
                    dict.Add(_paramname[i], paraval[i]);
                }
            }
            if (dict.Count != 0)
            {
                ASPxRadioButtonList.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname, dict).dataTable;
            }
            else
            {
                ASPxRadioButtonList.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname, paramname, paramvalue).dataTable;
            }
            ASPxRadioButtonList.SelectedIndex = 0;
            ASPxRadioButtonList.Cursor = "pointer";
            ASPxRadioButtonList.RepeatLayout = System.Web.UI.WebControls.RepeatLayout.Flow;
            ASPxRadioButtonList.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            if (RepeatDirection == "H")
            {
                ASPxRadioButtonList.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
            }
            else if(RepeatDirection == "V")
            {
                ASPxRadioButtonList.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Vertical;
            }
            ASPxRadioButtonList.TextField = textfieldname.Length != 0 ? textfieldname : valuefieldname;
            ASPxRadioButtonList.ValueField = valuefieldname;
            ASPxRadioButtonList.DataBind();
            return ASPxRadioButtonList;
        }
        public static ASPxTokenBox GenerateTokenBox(string spname, ASPxTokenBox aSPxTokenBox, string paramname, string paramvalue, string valuefieldname, string textfieldname = "")
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            if (paramname.Contains(","))
            {
                var paraval = paramvalue.Split(',');
                var _paramname = paramname.Split(',');
                for (int i = 0; i < _paramname.Length; i++)
                {
                    dict.Add(_paramname[i], paraval[i]);
                }
            }
            if (dict.Count != 0)
            {
                aSPxTokenBox.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname, dict).dataTable;
            }
            else
            {
                aSPxTokenBox.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname, paramname, paramvalue).dataTable;
            }
            
            aSPxTokenBox.TextField = textfieldname.Length != 0 ? textfieldname : valuefieldname;
            aSPxTokenBox.ValueField = valuefieldname;
            aSPxTokenBox.DataBind();
            return aSPxTokenBox;
        }
        public static ASPxComboBox GenerateCombobox(string spname, ASPxComboBox aSPxComboBox, string valuefieldname, string textfieldname = "")
        {

            aSPxComboBox.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname).dataTable;
            aSPxComboBox.TextField = textfieldname.Length != 0 ? textfieldname : valuefieldname;
            aSPxComboBox.ValueField = valuefieldname;
            aSPxComboBox.SelectedIndex = 0;
            aSPxComboBox.ValueType = typeof(string);
            aSPxComboBox.DataBind();
            return aSPxComboBox;
        }
        public static ASPxComboBox GenerateComboboxTypeInt(string spname, ASPxComboBox aSPxComboBox, string valuefieldname, string textfieldname = "")
        {

            aSPxComboBox.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname).dataTable;
            aSPxComboBox.TextField = textfieldname.Length != 0 ? textfieldname : valuefieldname;
            aSPxComboBox.ValueField = valuefieldname;
            aSPxComboBox.ValueType = typeof(System.Int32);
            aSPxComboBox.SelectedIndex = 0;
            aSPxComboBox.DataBind();
            return aSPxComboBox;
        }

        #endregion
        #region dectop
              public static LookUpEdit GenerateCombobox1(string spname, LookUpEdit lookupedit, string paramname,string paramvalue,string valuefieldname,string textfieldname="",string connectionstr="")
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            if (paramname.Contains(","))
            {
                var paraval = paramvalue.Split(',');
                var _paramname = paramname.Split(',');
                for (int i = 0; i < _paramname.Length; i++)
                {
                    dict.Add(_paramname[i], paraval[i]);
                }
            }
            if (dict.Count!=0)
            {
                lookupedit.Properties.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname, dict,false, connectionstr).dataTable;
            }
            else
            {
                lookupedit.Properties.DataSource = SqlCommandHelper.ExcecuteToDataTable(spname, paramname, paramvalue, false, connectionstr).dataTable;
            }
           
            lookupedit.Properties.DisplayMember = textfieldname.Length != 0 ? textfieldname : valuefieldname;
            lookupedit.Properties.ValueMember = valuefieldname;
           // lookupedit.ItemIndex = 0;
            return lookupedit;
        }
        #endregion

    }
}
