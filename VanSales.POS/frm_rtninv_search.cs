using DevExpress.XtraEditors;
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
    public partial class frm_rtninv_search : DevExpress.XtraEditors.XtraForm
    {
        public frm_rtninv_search()
        {
            InitializeComponent();
        }

        private void frm_rtninv_search_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            txt_search.Focus();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("searchval", txt_search.Text);
                dict.Add("user_id", TokenResult.GetLoginData("userid").ToString());
                var res = SqlCommandHelper.ExcecuteToDataTable("s_rtn_inv_sel_search_mobile", dict, true);
                gridControlsearch.DataSource = res.dataTable;

                gridControlsearch.Refresh();
                gridControlsearch.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_rtninv_search_KeyDown(object sender, KeyEventArgs e)
        {
            txt_search.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (gridView1.RowCount > 0)
                {
                    gridView1.Focus();
                }
            }
        }
        public static DataRow rec_search;
        private void gridControlsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                var grd = sender as DevExpress.XtraGrid.GridControl;
                rec_search = ((DevExpress.XtraGrid.Views.Grid.GridView)grd.Views[0]).GetFocusedDataRow();


                this.Close();

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridControlsearch_DoubleClick(object sender, EventArgs e)
        {
            var grd = sender as DevExpress.XtraGrid.GridControl;
            rec_search = ((DevExpress.XtraGrid.Views.Grid.GridView)grd.Views[0]).GetFocusedDataRow();


            this.Close();
        }
    }
}