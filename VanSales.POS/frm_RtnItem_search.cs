using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Emax.CoreCore;
using Emax.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class frm_RtnItem_search : DevExpress.XtraEditors.XtraForm
    {
        public frm_RtnItem_search()
        {
            InitializeComponent();
        }
        string invid = "";
        public frm_RtnItem_search(Frm_Rtn_Inv frm_Rtn_Inv)
        {
            InitializeComponent();
            invid =  frm_Rtn_Inv.lbl_sinvid.Text;
        }
       // Frm_Rtn_Inv Rtn_Inv = new Frm_Rtn_Inv();
        private void frm_RtnItem_search_Load(object sender, EventArgs e)
        {
            txt_search.Focus();
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("invid",invid);
            dict.Add("searchval", txt_search.Text);
            //var res = SqlCommandHelper.ExcecuteToDataTable("s_rtn_invdtls_search_sel", dict, true);
            var res = SqlCommandHelper.ExcecuteToDataTable("s_rtn_invdtls_search_group_sel", dict, true);//شركه الاحساس
            gridControlsearch.DataSource = res.dataTable;
            gridControlsearch.Refresh();
            this.KeyPreview = true;
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("invid", invid);
                dict.Add("searchval", txt_search.Text);
                var res = SqlCommandHelper.ExcecuteToDataTable("s_rtn_invdtls_search_group_sel", dict, true); //شركه الاحساس
               // var res = SqlCommandHelper.ExcecuteToDataTable("s_rtn_invdtls_search_sel", dict, true);
                gridControlsearch.DataSource = res.dataTable;

                gridControlsearch.Refresh();
                gridControlsearch.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public static DataRow rec;
        private void gridControlsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                var grd = sender as DevExpress.XtraGrid.GridControl;
                rec = ((GridView)grd.Views[0]).GetFocusedDataRow();


                this.Close();

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public static bool isescape;
        private void frm_RtnItem_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (gv_search.RowCount > 0)
                {
                    gv_search.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                isescape = true;
                this.Close();
            }
        }

        private void gridControlsearch_DoubleClick(object sender, EventArgs e)
        {
            var grd = sender as DevExpress.XtraGrid.GridControl;
            rec = ((GridView)grd.Views[0]).GetFocusedDataRow();


            this.Close();
        }
    }
}