function validate(s, e) {
    if (nullToEmpty(txt_paychartname.GetValue()) == "") {
        sweetinfo("برجاء إختيار الحساب اولا");
        txt_itemcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function gv_Bind(s, e) {
    s.GetRowValues(s.focusedRowIndex, 'accpayid;paytypeid;branchid;paychartid;paychartname',
        function (values) {
                $('#hf_accpayid').val(nullToIntZero(values[0])),
                cmb_paytypeid.SetValue(nullToIntZero(values[1])),
                cmb_branchid.SetValue(nullToIntZero(values[2])),
                $('#hf_paychartid').val(nullToIntZero(values[3])),
                txt_paychartname.SetValue(values[4])

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            let searchmodel = {
                chartid: (nullToIntZero(values[3]))
            }
            let data = getAction("/VanSalesService/Chart/GetChartSingalData", searchmodel)
            if (data.length != 0) {
                txt_paychartcode.SetValue(data[0].chartcode);
            }
            else {
                txt_paychartcode.SetValue("");
            }
        });
};
