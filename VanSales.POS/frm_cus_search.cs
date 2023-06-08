using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emax.Dal;

namespace VanSales.POS
{
    public partial class frm_cus_search : DevExpress.XtraEditors.XtraForm
    {
        public frm_cus_search()
        {
            InitializeComponent();

        }
        public string cus_code;
        public string cus_name;
        public string cus_vat;
        public string cus_mobile;
        private void frm_cus_search_Load(object sender, EventArgs e)
        {
            txt_search.Focus();
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("searchval", txt_search.Text);
            // var res = SqlCommandHelper.ExcecuteToDataTable("s_customers_sel_search", dict, true);
            var res = SqlCommandHelper.ExcecuteToDataTable("s_customers_sel_search_pos", dict, true);
            gridControl1.DataSource = res.dataTable;
            gridControl1.Refresh();
            this.KeyPreview = true;

        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var grd = sender as DevExpress.XtraGrid.GridControl;
                var currentselected = ((DevExpress.XtraGrid.Views.Grid.GridView)grd.Views[0]).GetFocusedDataRow();
                cus_code = currentselected.ItemArray[1].ToString();
                cus_name = currentselected.ItemArray[2].ToString();
                cus_vat = currentselected.ItemArray[5].ToString();
                cus_mobile = currentselected.ItemArray[7].ToString();
                this.Close();
            }
        }

        private void frm_cus_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (gridView1.RowCount > 0)
                {
                    gridView1.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("searchval", txt_search.Text);
            //  var res = SqlCommandHelper.ExcecuteToDataTable("s_customers_sel_search", dict, true);
            var res = SqlCommandHelper.ExcecuteToDataTable("s_customers_sel_search_pos", dict, true);
            gridControl1.DataSource = res.dataTable;
            gridControl1.Refresh();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var grd = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            cus_code = grd.GetFocusedRowCellValue("custcode").ToString();
            cus_name = grd.GetFocusedRowCellValue("custname").ToString();
            cus_vat = grd.GetFocusedRowCellValue("custvat").ToString();
            cus_mobile = grd.GetFocusedRowCellValue("custmob").ToString();
            //var grd = sender as DevExpress.XtraGrid.GridControl;
            //var currentselected = ((DevExpress.XtraGrid.Views.Grid.GridView)grd.Views[0]).GetFocusedDataRow();
            //cus_code = currentselected.ItemArray[1].ToString();
            //cus_name = currentselected.ItemArray[2].ToString();
            //cus_vat = currentselected.ItemArray[5].ToString();
            //cus_mobile = currentselected.ItemArray[7].ToString();
            this.Close();
        }
    }
}