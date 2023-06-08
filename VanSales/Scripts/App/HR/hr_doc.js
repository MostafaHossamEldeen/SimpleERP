$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    switch ($('#popupModalsearchdef').data("name")) {
        case "doc":
            cmb_doctypeid.PerformCallback();
            img_docimg.SetImageUrl('../' + $('#hf_imgpath').val().replace('~/', ''));

            break;
        default:
    }
});

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

    if (nullToEmpty(txt_docno.GetValue()) == "") {
        sweetinfo("برجاء ادخال رقم المستند");
        txt_vdate.Focus();
        e.txt_vdate.Focus();
        return;
    }

    if (nullToEmpty(txt_docexpiredate.GetValue()) == "") {
        sweetinfo("برجاء ادخال تاريخ إنتهاء المستند");
        txt_vdate.Focus();
        e.txt_vdate.Focus();
        return;
    }

    if (nullToEmpty(txt_empid.GetValue()) == "") {
        sweetinfo("برجاء ادخال الموظف");
        txt_empid.Focus();
        e.txt_empid.Focus();
        return;
    }
};

function cleardata() {
    $('#hf_empid').val("0");
    $('#HF_docid').val("0");
    txt_docno.SetValue(null);
    txt_empid.SetValue(null);
    txt_empname.SetValue(null);
    txt_docexpiredate.SetValue(null);
    rbl_doctynature.SetSelectedIndex(0);
    cmb_doctypeid.SetSelectedIndex(0);
    rbl_datetype.SetSelectedIndex(0);
    img_docimg.SetImageUrl(null);
    img_docimg.SetSize(150, 150);
};