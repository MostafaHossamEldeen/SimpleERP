function preventwrite1(s, e) {
    ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
}
function setEmpData(s, e) {
    let searchmodel = {
        empcode: s.GetValue()

    }
    let data = getAction("/VanSalesService/hr_vactions/GetempSingalData", searchmodel)

    if (data.length != 0) {
        searchmodel["empcode"] = data[0].empcode;
        txt_empname.SetValue(data[0].empname);
        $('#HF_empid').val(data[0].empid);
    }
    else {
        txt_empid.SetValue("");
        txt_empname.SetValue("");
        $('#HF_empid').val("");
    }
}

function validate(s, e) {

    if (nullToEmpty(txt_empid.GetValue()) == "") {
        sweetinfo("برجاء أختيار الموظف");
        txt_empid.Focus();
        e.txt_empid.Focus();
        return;
    }

    if (nullToEmpty(txt_vvalue.GetValue()) == "") {
        sweetinfo("برجاء تحديد قيمة المتغير");
        txt_vvalue.Focus();
        e.txt_vvalue.Focus();
        return;
    }
};

function vvalue_day_calc() {
    if (nullToEmpty(txt_salary.GetValue()) == "") {
        sweetinfo("برجاء تحديد الراتب أولاً");
        txt_ratio.SetValue(null);
        txt_days.SetValue(null);
        txt_vvalue.SetValue(null);
        txt_empid.Focus();
        e.txt_empid.Focus();
        return;
    }
    txt_ratio.SetValue(null);
    txt_vvalue.SetValue(null);
    txt_vvalue.SetValue(((txt_salary.GetValue() / 30) * txt_days.GetValue()).toFixed(2));
};

function vvalue_ratio_calc() {
    if (nullToEmpty(txt_salary.GetValue()) == "") {
        sweetinfo("برجاء تحديد الراتب أولاً");
        txt_ratio.SetValue(null)
        txt_days.SetValue(null)
        txt_vvalue.SetValue(null)
        txt_empid.Focus();
        e.txt_empid.Focus();
        return;
    }
    txt_days.SetValue(null);
    txt_vvalue.SetValue(null);
    txt_vvalue.SetValue(((txt_salary.GetValue() * txt_ratio.GetValue()) /100).toFixed(2));
};

function getempsalary(s, e) {
    let searchmodel = {
        svnatuleid: cmb_svnatuleid.GetValue(),
        empid: $("#HF_empid").val()
    }
    let data = getAction("/VanSalesService/HR/GetsalarySingalData", searchmodel)
    if (data.length != 0) {
        txt_salary.SetValue(data[0].salary);
    }
    else {
        txt_salary.SetValue("");
    }
};

$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "emp":
                getempsalary();
                break;
            case "var":
                cmb_svnatuleid.PerformCallback("selectindex,"+popupres["svnatuleid"]);
                break;
            default:
        }
    }
});

var varnum = null;
function OnsvnatuleidChanged(cmbCountry) {
    if (cmb_svtype.InCallback())
        varnum = cmb_svtype.GetValue().toString()
    else
        cmb_svnatuleid.PerformCallback(cmb_svtype.GetValue().toString());
}
function OnEndCallback(s, e) {
    if (varnum) {
        cmb_svnatuleid.PerformCallback(varnum);
        varnum = null;
    }
};