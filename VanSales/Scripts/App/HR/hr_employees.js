$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    img_emppic.SetImageUrl($('#hf_imgpath').val()==""?null:'../' + $('#hf_imgpath').val().replace('~/', ''));
    OnCountryChanged(cmb_paychartid);
});

var lastCountry = null;
function OnCountryChanged(cmbCountry) {
    if (cmb_paychartid.InCallback())
        lastCountry = cmb_branchid.GetValue().toString() + ',' + cmb_paytypeid.GetValue().oString()
    else
        cmb_paychartid.PerformCallback(cmb_branchid.GetValue().toString() + ',' + cmb_paytypeid.GetValue().toString());
}
function OnEndCallback(s, e) {
    if (lastCountry) {
        cmbCity.PerformCallback(lastCountry);
        lastCountry = null;
    }
};

function validate(s, e) {
    if (nullToEmpty(txt_empname.GetValue()) == "") {
        sweetinfo("برجاء إدخال إسم الموظف اولا");
        txt_empname.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }

    if (nullToEmpty(cmb_branchid.GetValue()) == "") {
        sweetinfo("برجاء إدخال فرع الموظف اولا");
        cmb_branchid.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }

    if (nullToEmpty(cmb_ccid.GetValue()) == "") {
        sweetinfo("برجاء إدخال مركز تكلفة الموظف اولا");
        cmb_ccid.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }

    if (nullToEmpty(cmb_jobid.GetValue()) == "") {
         sweetinfo("برجاء إدخال وظيفة الموظف اولا");
        cmb_jobid.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }

    if (nullToEmpty(cmb_nationid.GetValue()) == "") {
        sweetinfo("برجاء إدخال جنسية الموظف اولا");
        cmb_nationid.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }

    if (token.autoemp == "False" && (txt_empcode.GetValue() == "تلقائى" || txt_empcode.GetValue() == null)) {
        sweetinfo("برجاء إدخال كود الموظف اولا");
        txt_empname.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};

function updmsg(s, e) {
    Swal.fire({
        icon: 'success',
        title: 'تم رفع صورة الموظف بنجاح',
        showConfirmButton: false,
        timer: 2000,
    })
};

function cleardata() {
    $('#hf_empid').val("0");
    $('#HF_empchatid').val(null);
    txt_empcode.SetValue(null);
    txt_empname.SetValue(null);
    txt_empmob.SetValue(null);
    txt_embemail.SetValue(null);
    txt_empadd.SetValue(null);
    txt_empidno.SetValue(null);
    txt_empbdate.SetValue(null);
    txt_eduname.SetValue(null);
    txt_empnotes.SetValue(null);
    cmb_branchid.SetSelectedIndex(-1);
    cmb_ccid.SetSelectedIndex(-1);
    cmb_nationid.SetSelectedIndex(0);
    cmb_jobid.SetSelectedIndex(-1);
    cmb_empstatus.SetSelectedIndex(0);
    txt_basicsalary.SetValue(null);
    txt_insursalary.SetValue(null);
    txt_empworkdate.SetValue(null);
    txt_empbankname.SetValue(null);
    txt_empbankid.SetValue(null);
    txt_annualvaction.SetValue(null);
    txt_empchatid.SetValue(null);
    img_emppic.SetImageUrl(null);
    img_emppic.SetSize(150, 150);
    cmb_paytypeid.SetSelectedIndex(0);
    cmb_paychartid.SetSelectedIndex(0);
};

function preventwriteempcode(s, e) {
    token = GetToken();
    if (token.autoemp == "True") {
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
    }
};

$(function () {
    token = GetToken();
    if (token.autoemp == "False" && (txt_empcode == "تلقائى" || txt_empcode == null)) {
        txt_empcode.nullText = ""
        txt_empcode.SetValue(null)
    }
})