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
    public partial class User : DevExpress.XtraEditors.XtraForm
    {
        public User()
        {
            InitializeComponent();
        }
        string constr = ConfigurationManager.ConnectionStrings["VanSales_pos"].ConnectionString;
        private void User_Load(object sender, EventArgs e)
        {
            Util.GenerateCombobox1("sys_users_sel", cmb_username, "", "", "username", "username", constr);
            if (Login_frm.localusername == null)
            {
                Util.GenerateCombobox1("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman", "smanid", "smanname");
            }
            else
            {
                Util.GenerateCombobox1("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman", "smanid", "smanname");
                cmb_username.EditValue = Login_frm.localusername;
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("username", cmb_username.EditValue);
                var res = SqlCommandHelper.ExcecuteToDataTable("sys_users_username_sel", dict, true, constr);
                if (res.dataTable.Rows.Count != 0)
                {
                    cmb_smanid.EditValue = res.dataTable.Rows[0]["smanid"];
                    cmb_smanid.Text = res.dataTable.Rows[0]["smanname"].ToString();
                    ts_adisc.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["adisc"]));
                    txt_discper.Text = res.dataTable.Rows[0]["discper"].ToString();
                    ts_acreadit.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["acreadit"]));
                    ts_rwinv.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["rwinv"]));
                    ts_utype.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["utype"]));
                    if (ts_adisc.IsOn == true)
                    {
                        txt_discper.ReadOnly = false;
                    }
                    else
                    {
                        txt_discper.Text = "0";
                        txt_discper.ReadOnly = true;
                    }
                    txt_password.Text = null;
                    txt_newpassword.Text = null;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cmb_username.EditValue == null || cmb_username.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("برجاء إختيار المستخدم أولاً !؟", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_username.Focus();
                return;
            }
            string sp_case;
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("username", cmb_username.EditValue);
                dict.Add("adisc", ts_adisc.EditValue);
                dict.Add("discper", txt_discper.Text);
                dict.Add("acreadit", ts_acreadit.EditValue);
                dict.Add("rwinv", ts_rwinv.EditValue);
                dict.Add("smanid", cmb_smanid.EditValue);
                dict.Add("smanname", cmb_smanid.Text);
                dict.Add("utype", ts_utype.EditValue);
                if (cmb_username.ItemIndex != -1)
                {
                    sp_case = "sys_users_upd";
                }
                else
                {
                    dict.Add("password", txt_newpassword.Text);
                    sp_case = "sys_users_ins";
                }
                var res = SqlCommandHelper.ExecuteNonQuery(sp_case, dict, true,null, constr);
                if (res.errorid == 0)
                {
                    XtraMessageBox.Show("تم الحفظ البيانات بنجاح", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dictionary<object, object> dictbind = new Dictionary<object, object>();
                    dictbind.Add("username", cmb_username.EditValue);
                    var resbind = SqlCommandHelper.ExcecuteToDataTable("sys_users_username_sel", dictbind, true, constr);
                    if (resbind.dataTable.Rows.Count != 0)
                    {
                        cmb_smanid.EditValue = resbind.dataTable.Rows[0]["smanid"];
                        cmb_smanid.Text = resbind.dataTable.Rows[0]["smanname"].ToString();
                        ts_adisc.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(resbind.dataTable.Rows[0]["adisc"]));
                        txt_discper.Text = resbind.dataTable.Rows[0]["discper"].ToString();
                        ts_acreadit.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(resbind.dataTable.Rows[0]["acreadit"]));
                        ts_rwinv.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(resbind.dataTable.Rows[0]["rwinv"]));
                        ts_utype.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(resbind.dataTable.Rows[0]["utype"]));
                        if (ts_adisc.IsOn == true)
                        {
                            txt_discper.ReadOnly = false;
                        }
                        else
                        {
                            txt_discper.Text = "0";
                            txt_discper.ReadOnly = true;
                        }
                        txt_password.Text = null;
                        txt_newpassword.Text = null;
                    }
                }
                else
                {
                    XtraMessageBox.Show(res.errormsg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ts_adisc_EditValueChanged(object sender, EventArgs e)
        {
            if (ts_adisc.IsOn == true)
            {
                txt_discper.ReadOnly = false;
            }
            else
            {
                txt_discper.Text = "0";
                txt_discper.ReadOnly = true;
            }
        }

        private void btn_respass_Click(object sender, EventArgs e)
        {
            if (cmb_username.EditValue == null || cmb_username.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("برجاء إختيار المستخدم أولاً !؟", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmb_username.Focus();
                return;
            }
            try
            {
                if (txt_password.Text == "" || txt_newpassword.Text == "")
                {
                    XtraMessageBox.Show("برجاء إدخال كلمة المرور الحالية و كلمة المرور الجديدة", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("username", cmb_username.EditValue);
                    dict.Add("password", txt_password.Text);
                    dict.Add("newpassword", txt_newpassword.Text);
                    var res = SqlCommandHelper.ExecuteNonQuery("sys_users_changepass", dict, true, null, constr);
                    if (res.errorid == 0)
                    {
                        if (XtraMessageBox.Show("تم تغيير كلمة المرو بنجاح ... سيتم إعادة تشغيل البرنامج", "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            Application.Restart();
                        }
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

        private void cmb_username_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb_username.EditValue == null || cmb_username.EditValue.ToString() == "")
            {
                btn_respass.Enabled = false;
                btn_save.Enabled = false;
            }
            if (cmb_username.ItemIndex != -1)
            {
                btn_respass.Enabled = true;
                btn_save.Enabled = true;
                txt_password.ReadOnly = false;
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("username", cmb_username.EditValue);
                var res = SqlCommandHelper.ExcecuteToDataTable("sys_users_username_sel", dict, true, constr);
                if (res.dataTable.Rows.Count != 0)
                {
                    cmb_smanid.EditValue = res.dataTable.Rows[0]["smanid"];
                    cmb_smanid.Text = res.dataTable.Rows[0]["smanname"].ToString();
                    ts_adisc.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["adisc"]));
                    txt_discper.Text = res.dataTable.Rows[0]["discper"].ToString();
                    ts_acreadit.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["acreadit"]));
                    ts_rwinv.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["rwinv"]));
                    ts_utype.IsOn = Convert.ToBoolean(EmaxGlobals.NullToBool(res.dataTable.Rows[0]["utype"]));
                    if (ts_adisc.IsOn == true)
                    {
                        txt_discper.ReadOnly = false;
                    }
                    else
                    {
                        txt_discper.Text = "0";
                        txt_discper.ReadOnly = true;
                    }
                }
            }
            else
            {
                btn_respass.Enabled = false;
                txt_password.ReadOnly = true;
            }
        }

        private void User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.End)
            {
                btn_save.PerformClick();
            }
            else if(e.KeyCode==Keys.Escape)
            {
                btn_home.PerformClick();
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}