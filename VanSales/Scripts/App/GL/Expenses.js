function validate(s, e) {
    if (nullToEmpty(txt_paychartname.GetValue()) == "") {
        sweetinfo("برجاء إختيار الحساب اولا");
        txt_itemcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function gv_BindExpenses(s, e) {
    s.GetRowValues(s.focusedRowIndex, 'expid;expname;accid;exptype;chartname;chartcode',
        function (values) {
            $('#hf_expid').val(nullToIntZero(values[0])),
                txt_expname.SetValue((values[1])),
                $('#hf_paychartid').val((values[2])),
                txt_paychartname.SetValue((values[4])),
                txt_paychartcode.SetValue((values[5]))
                

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



