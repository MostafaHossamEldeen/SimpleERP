using DevExpress.XtraEditors;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;


namespace VanSales.POS
{
    public partial class Setting : DevExpress.XtraEditors.XtraForm
    {
        public Setting()
        {
            InitializeComponent();
        }
        string constr = ConfigurationManager.ConnectionStrings["VanSales_pos"].ConnectionString;
        private void Setting_Load(object sender, EventArgs e)
        {
            respath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            txt_compname.Focus();
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "1,sys_costcenter", "ccid", "ccname");
            Util.GenerateCombobox1("sys_fillcomp_sel", cmb_vattypeid, "compid,table_name", "3,sys_fillcomp", "citemid", "citemname");
            try
            {
                var res = SqlCommandHelper.ExcecuteToDataTable("sys_setting_sel", null, true,constr);
                if (res.dataTable.Rows.Count != 0)
                {
                    txt_compname.Text = res.dataTable.Rows[0]["compname"].ToString();
                    txt_vatno.Text = res.dataTable.Rows[0]["vatno"].ToString();
                    cmb_branchid.EditValue = res.dataTable.Rows[0]["branchid"];
                    cmb_ccid.EditValue = res.dataTable.Rows[0]["ccid"];
                    txt_printno.Text = res.dataTable.Rows[0]["printno"].ToString();
                    ts_conntype.IsOn = Convert.ToBoolean(EmaxGlobals.NullToIntZero(res.dataTable.Rows[0]["conntype"]));
                    cmb_vattypeid.EditValue = res.dataTable.Rows[0]["vattypeid"];
                    if (File.Exists(respath + "\\complogo\\" + res.dataTable.Rows[0]["complogo"]))
                    {
                        img_complogo.Image = System.Drawing.Image.FromFile(respath + "\\complogo\\" + res.dataTable.Rows[0]["complogo"]);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string filename;
        string fullfilename;
        string respath;
        private void btn_upload_logo_Click(object sender, EventArgs e)
        {
            DialogResult result = xtraOpenFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                 filename = System.IO.Path.GetFileNameWithoutExtension(xtraOpenFileDialog1.FileName);
                 fullfilename = xtraOpenFileDialog1.FileName;
                if (filename == null)
                {
                    XtraMessageBox.Show("ملف غير صالح" + xtraOpenFileDialog1.FileName, "تم إختيار ملف غير صالح برجار إختيار ملف صالح للرفع", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lbl_logopath.Text = fullfilename;
                    img_complogo.Image = System.Drawing.Image.FromFile(fullfilename);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                respath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                filename = Path.GetFileNameWithoutExtension(fullfilename) + Path.GetExtension(fullfilename);
                
                if (File.Exists(respath + "\\complogo\\" + filename))
                {
                    XtraMessageBox.Show("برجاء تغير إسم الشعار نظراً لوجود شعار آخر يحمل نفس الإسم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (filename.Length >0)
                    {
                        System.IO.File.Copy(fullfilename, respath + "\\complogo\\" + filename, true);
                    }
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("compname", txt_compname.Text);
                    dict.Add("vatno", txt_vatno.Text);
                    dict.Add("branchid", cmb_branchid.EditValue);
                    dict.Add("branchname", cmb_branchid.Text);
                    dict.Add("ccid", cmb_ccid.EditValue);
                    dict.Add("ccname", cmb_ccid.Text);
                    dict.Add("complogo", filename);
                    dict.Add("printno", txt_printno.Text);
                    dict.Add("conntype", ts_conntype.EditValue);
                    dict.Add("vattypeid", cmb_vattypeid.EditValue);
                    dict.Add("vattypename", cmb_vattypeid.Text);
                    var res = SqlCommandHelper.ExecuteNonQuery("sys_setting_upd", dict, true,null, constr);
                    if (res.errorid == 0)
                    {
                        if (fullfilename != null)
                        {
                            img_complogo.Image = System.Drawing.Image.FromFile(respath + "\\complogo\\" + filename);
                            lbl_logopath.Text = null;
                        }
                        XtraMessageBox.Show("تم تحديث البيانات بنجاح", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show(res.errormsg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_getdata_Click(object sender, EventArgs e)
        {
            try
            {
                Util.GenerateCombobox1("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox1("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "1,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox1("sys_fillcomp_sel", cmb_vattypeid, "compid,table_name", "3,sys_fillcomp", "citemid", "citemname");

                var res = SqlCommandHelper.ExcecuteToDataTable("pos_setting_sel", null, true);
                if (res.dataTable.Rows.Count != 0)
                {
                    txt_compname.Text = res.dataTable.Rows[0]["compname"].ToString();
                    txt_vatno.Text = res.dataTable.Rows[0]["compvatno"].ToString();
                    cmb_vattypeid.EditValue = res.dataTable.Rows[0]["vattype"];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}