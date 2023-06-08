function NodeValidate() {
    if (nullToEmpty(txt_nodecode.GetValue()) != "" || $('#hf_chartid').val() != "0") {
        cmb_acctype.enabled = false;
    }
    else {        
        cmb_acctype.enabled = true;
    }
    if ($('#hf_sys_chartlvl').val() == cmb_levelno.GetValue()) {
        lblfinallevel.SetValue("(حساب نهائي)")
        cmb_accnature.SelectedIndex = 0;
        cmb_accnature.enabled = true;
    }
    else {
        lblfinallevel.SetValue("")
        cmb_accnature.SelectedIndex = -1;
        cmb_accnature.enabled = false;
    }
};
function validate(s, e) {
    if (txt_chartcode.GetValue() == "" || txt_chartcode.GetValue() == null) {
        sweetinfo("برجاء إدخال كود الحساب");
        txt_chartcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (txt_chartname.GetValue() == "" || txt_chartname.GetValue() == null) {
        sweetinfo("برجاء إدخال إسم الحساب");
        txt_chartname.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if ($('#hf_sys_chartlvl').val() == cmb_levelno.GetValue() && nullToEmpty(cmb_accnature.GetValue()) == "" ) {
        sweetinfo("برجاء إختيار طبيعة الحساب");
        cmb_accnature.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function trlchart_Bind_dtl(s, e) {
    let searchmodel = {
        chartid: s.GetFocusedNodeKey()
    }
    let data = getAction("/VanSalesService/Chart/GetChartSingalData", searchmodel)
    if (data.length != 0) {
        searchmodel["chartid"] = data[0].chartid;
        $('#hf_chartid').val(data[0].chartid);
        txt_chartcode.SetValue(data[0].chartcode);
        txt_chartname.SetValue(data[0].chartname);
        txt_chartename.SetValue(data[0].chartename);
        $('#hf_nodeid').val(data[0].nodeid);
        txt_nodecode.SetValue(data[0].chartnamedisplay);
        cmb_acctype.SetValue(data[0].acctype);
        cmb_accnature.SetValue(data[0].accnature);
        cmb_levelno.SetValue(data[0].levelno);
        txt_balance.SetValue(data[0].balance);
        $('#hf_chartid_tr').val(data[0].chartid);
        $('#hf_sys_chartlvl').val(data[0].sys_chartlvl);
    }
    else {
        $('#hf_chartid').val(0);
        txt_chartcode.SetValue("");
        txt_chartname.SetValue("");
        txt_chartename.SetValue("");
        $('#hf_nodeid').val("");
        txt_nodecode.SetValue("");
        cmb_acctype.SetValue("");
        cmb_accnature.SetValue("");
        cmb_levelno.SetValue("");
        txt_balance.SetValue("");
        $('#hf_chartid_tr').val("");
    }
    if ($('#hf_sys_chartlvl').val() == cmb_levelno.GetValue()) {
        lblfinallevel.SetValue("(حساب نهائي)")
    }
    else {
        lblfinallevel.SetValue("");
    }
    NodeValidate();
};
function delchart() {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: true
    })

    swalWithBootstrapButtons.fire({
        title: 'تأكيد الحذف',
        text: "هل تريد حذف البيانات",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'نعم',
        cancelButtonText: 'لا',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            trlchart.PerformCallback()
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'إلغاء',
                'تم إلغاء عملية الحذف',
                'error'
            )
        }
    })
};

$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "chart":
                let searchmodel = {
                    chartid: $('#hf_chartid').val()
                }
                let data = getAction("/VanSalesService/Chart/GetChartSingalData", searchmodel)
                if (data.length != 0) {
                    searchmodel["chartid"] = data[0].chartid;
                    $('#hf_chartid').val(data[0].chartid);
                    txt_chartcode.SetValue(data[0].chartcode);
                    txt_chartname.SetValue(data[0].chartname);
                    txt_chartename.SetValue(data[0].chartename);
                    $('#hf_nodeid').val(data[0].nodeid);
                    txt_nodecode.SetValue(data[0].chartnamedisplay);
                    cmb_acctype.SetValue(data[0].acctype);
                    cmb_accnature.SetValue(data[0].accnature);
                    cmb_levelno.SetValue(data[0].levelno);
                    txt_balance.SetValue(data[0].balance);
                    $('#hf_chartid_tr').val(data[0].chartid);
                    $('#hf_sys_chartlvl').val(data[0].sys_chartlvl);
                    trlchart.PerformCallback(data[0].chartid)
                }
                else {
                    $('#hf_chartid').val(0);
                    txt_chartcode.SetValue("");
                    txt_chartname.SetValue("");
                    txt_chartename.SetValue("");
                    $('#hf_nodeid').val("");
                    txt_nodecode.SetValue("");
                    cmb_acctype.SetValue("");
                    cmb_accnature.SetValue("");
                    cmb_levelno.SetValue("");
                    txt_balance.SetValue("");
                    $('#hf_chartid_tr').val("");
                }
                if ($('#hf_sys_chartlvl').val() == cmb_levelno.GetValue()) {
                    lblfinallevel.SetValue("(حساب نهائي)")
                }
                else {
                    lblfinallevel.SetValue("");
                }
                NodeValidate();
                break;
            case "node":
                NodeValidate();
                if ($('#hf_sys_chartlvl').val() == cmb_levelno.GetValue()) {
                    lblfinallevel.SetValue("(حساب نهائي)")
                    cmb_accnature.enabled = true;
                }
                else {
                    lblfinallevel.SetValue("")
                    cmb_accnature.SelectedIndex = -1;
                    cmb_accnature.enabled = false;
                }
                break;
            default:
        }
    }
});