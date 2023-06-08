function preventwrite1(s, e) {



    ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);

}
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    OnCountryChanged(cmb_lnature);
});
var lastCountry = null;
function OnCountryChanged(cmbCountry) {
    if (cmb_lnature.InCallback())
        lastCountry = cmb_ltype.GetValue().toString()
    else
        cmb_lnature.PerformCallback(cmb_ltype.GetValue().toString() );
}
function OnEndCallback(s, e) {
    if (lastCountry) {
        cmbCity.PerformCallback(lastCountry);
        lastCountry = null;
    }
};
function clear_varchrt() {
    txt_chartid.SetValue("");
    txt_chartname.SetValue("");
    $('#HF_lcrditcahrtid').val("");

}

function setchartData(s, e) {
    let searchmodel = {

        chartcode: s.GetValue()


    }
    let data = getAction("/VanSalesService/Vouchers/voucherscode", searchmodel)


    if (data.length != 0) {
        clear_varchrt()
        searchmodel["chartid"] = data[0].chartid;
        txt_chartname.SetValue(data[0].chartname);
        txt_chartid.SetValue(data[0].chartcode);
        $('#HF_lcrditcahrtid').val(data[0].chartid);

       
    }
    else {

        clear_varchrt()
        txt_chartid.Focus();
    }


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
        txt_empid.Focus();
    }
}