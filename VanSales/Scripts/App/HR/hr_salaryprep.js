function preventwrite1(s, e) {
    ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
};

function validate(s, e) {
    if (nullToEmpty(cmb_monyrid.GetValue()) == "") {
        sweetinfo("برجاء إختيار الشهر / السنة");
        cmb_monyrid.Focus();
        e.cmb_monyrid.Focus();
        return;
    }
};

function clearfilter() {
    cmb_nationid.SetSelectedIndex(-1);
    cmb_jobid.SetSelectedIndex(-1);
    cmb_ccid.SetSelectedIndex(-1);
    txt_empid.SetValue(null);
    txt_empname.SetValue(null);
    $('#hf_empid').val("");
}

$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "emp": {
                cmb_nationid.SetSelectedIndex(-1);
                cmb_jobid.SetSelectedIndex(-1);
                cmb_ccid.SetSelectedIndex(-1);
                break;
            }
            case "master": {
                if ($('#hf_postacc').val() == "True" || $('#hf_postacc').val() == "true") {
                    lbl_postacc.SetValue('مرحل حسابات');
                    btn_Save.SetEnabled(false);
                    btn_delete.SetEnabled(false);
                    btn_prep.SetEnabled(false);
                    btn_postacc.SetEnabled(false);
                    btn_userins.SetEnabled(false);
                } else {
                    lbl_postacc.SetValue('');
                    btn_Save.SetEnabled(true);
                    btn_delete.SetEnabled(true);
                    btn_prep.SetEnabled(true);
                    btn_postacc.SetEnabled(true);
                    btn_userins.SetEnabled(true);
                }                
                cmb_monyrid.SetReadOnly(true);
                cmb_branchid.SetReadOnly(true);
                txt_sprepdate.SetReadOnly(true);
                $('#PDetiles').css("display", "block");
                $('#PEmpIns').css("display", "block");
                gvhr_salarydtls.PerformCallback();
                break;
            }
            default:
        }
    }
});

function PostSalaryPrep(s, e) {
    let postmodel = { sprepid: $('#HF_sprepid').val() };

    let res = postaction("/VanSalesService/Hr/postSalaryPrepAcc", postmodel);

    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        btn_Save.SetEnabled(false);
        btn_delete.SetEnabled(false);
        btn_prep.SetEnabled(false);
        btn_postacc.SetEnabled(false);
        btn_userins.SetEnabled(false);
        $('#hf_postacc').val(true)
        lbl_postacc.SetValue("مرحل حسابات")
        gvhr_salarydtls.PerformCallback();
    }
};