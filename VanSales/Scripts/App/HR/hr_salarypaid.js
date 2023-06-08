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
            case "master": {
                if ($('#hf_postacc').val() == "true") {
                    lbl_postacc.SetValue('مرحل حسابات');
                } else {
                    lbl_postacc.SetValue('');
                }
                cmb_monyrid.SetReadOnly(true);
                cmb_branchid.SetReadOnly(true);
                txt_spaiddate.SetReadOnly(true);
                $('#PDetiles').css("display", "block");
                $('#PEmpIns').css("display", "block");
                gvhr_salarydtls.PerformCallback();
                break;
            }
            default:
        }
    }
});