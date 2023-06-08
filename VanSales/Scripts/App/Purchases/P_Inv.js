function validate(s, e) {
    if (txt_pinvdate.GetValue() == "" || txt_pinvdate.GetValue() == null) {
        sweetinfo("برجاء ادخال تاريخ الفاتورة");
        txt_pinvdate.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (cmb_pinvpay.GetValue() == 2 || cmb_pinvpay.GetValue == "أجل") {
        if (txt_suppid.GetValue() == null) {
            sweetinfo("برجاء إختيار المورد لكون نوع سداد الفاتورة أجل");
            txt_suppid.Focus();
            ASPxClientUtils.PreventEvent(e.htmlEvent);
            return;
        }
    }
    if (txt_suppname.GetValue() == "" || txt_suppname.GetValue() == null) {
        sweetinfo("برجاء ادخال اسم المورد");
        txt_suppname.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (nullToEmpty(cmb_branchid.GetValue()) == "") {
        cmb_branchid.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function validate_dtl(s, e) {
    if (nullToEmpty(txt_itemcode.GetValue()) == "") {
        sweetinfo("برجاء إختيار الصنف اولا");
        txt_itemcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (nullToDecimalZero(txt_qty.GetValue()) == "0") {
        sweetinfo("برجاء إضافة كمية للصنف");
        txt_qty.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function clear_dtl() {
    txt_itemcode.SetValue(""),
        txt_itemname.SetValue(""),
        txt_unitname.SetValue(""),
        txt_qty.SetValue(1),
        txt_price.SetValue(0),
        txt_value.SetValue(0),
        txt_discp.SetValue(0),
        txt_discvalue.SetValue(0),
        txt_netvalue.SetValue(0),
        txt_itemvatvalue.SetValue(0),
        txt_itemnotes.SetValue(""),
        $('#HF_itemid').val(""),
        $('#HF_unitid').val(""),
        $('#HF_factor').val(""),
        $('#Hf_vat').val(""),
        $('#HF_invdtlid').val("0")
};
function Clear_pay() {
    cmb_paytypeid.SetSelectedIndex(0),
        cmb_paychartid.SetValue(""),
        txt_payvalue.SetValue(0),
        txt_payno.SetValue(""),
        txt_payref.SetValue(""),
        $('#Hf_invpayid').val("")
};
function Clear_exp() {
    cmb_expid.SetSelectedIndex(-1),
        txt_expvalue.SetValue(""),
        txt_chartcode.SetValue(""),
        txt_chartename.SetValue(""),
        txt_chartename.SetValue(""),
        $('#hf_accpaidid').val(""),
        $('#hf_invexpid').val("")
};
function validatePay(s, e) {
    if (nullToDecimalZero(txt_payvalue.GetValue() == "0")) {
        sweetexception('برجاء ادخال القيمه اولا')
        txt_payvalue.Focus();
        ASPxClientUtils.PreventEvent(evt.htmlEvent);
        return;
    }
};
function validateexp(s, e) {
    if (nullToDecimalZero(cmb_expid.GetValue()) == "0") {
        sweetinfo("برجاء اختيار المصروف اولا");
        cmb_expid.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (nullToIntZero(txt_expvalue.GetValue()) == "0") {
        sweetinfo("برجاء ادخال القيمه اولا");
        txt_expvalue.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (nullToDecimalZero(txt_chartcode.GetValue()) == "0") {
        sweetinfo("برجاء اختيار الحساب اولا");
        txt_chartcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function multiply() {
    var text1 = txt_qty.GetValue();
    var text2 = txt_price.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    txt_value.SetValue((parseFloat(t1 * 1).toFixed(2) * parseFloat(t2 * 1).toFixed(2)).toFixed(2));
    Subtract();
};
function multiplydis() {
    var text1 = txt_discp.GetValue();
    var text2 = txt_value.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1 / 100;
    if (text2 != "") t2 = text2;
    if (txt_discp.GetValue() == null)
        txt_discp.SetValue(0);
    if (t1 > 1) {
        sweetinfo(" الخصم اكبر من 100%");
        txt_discp.SetValue(0);
        return;
    }
    txt_discvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
    Subtract();
};
function Subtract() {
    var text1 = txt_value.GetValue();
    var text2 = txt_discvalue.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    txt_netvalue.SetValue((parseFloat(t1).toFixed(2) - parseFloat(t2).toFixed(2)).toFixed(2));
    calac_vat();
};
function calac_disc() {
    var text1 = txt_discvalue.GetValue();
    var text2 = txt_value.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    if (txt_discvalue.GetValue() == null)
        txt_discvalue.SetValue(0);
    txt_netvalue.SetValue((parseFloat(t2 * 1).toFixed(2) - parseFloat(t1 * 1).toFixed(2)).toFixed(2));
    calac_vat();
};
function gv_Bind_dtl(s, e) {
    s.GetRowValues(s.focusedRowIndex, 'invdtlid;itemid;itemname;unitid;unitname;qty;factor;price;value;discp;discvalue;netvalue;itemnotes;itemcode;vatvalue',
        function (values) {
            $('#HF_invdtlid').val(nullToIntZero(values[0])),
                $('#HF_itemid').val(nullToIntZero(values[1])),
                txt_itemname.SetValue(values[2]),
                $('#HF_unitid').val(nullToIntZero(values[3])),
                txt_unitname.SetValue(values[4]),
                txt_qty.SetValue(values[5]),
                $('#HF_factor').val(nullToIntZero(values[6])),
                txt_price.SetValue(values[7]),
                txt_value.SetValue(values[8]),
                txt_discp.SetValue(values[9]),
                txt_discvalue.SetValue(values[10]),
                txt_netvalue.SetValue(values[11]),
                txt_itemnotes.SetValue(values[12]),
                txt_itemcode.SetValue(values[13]),
                txt_itemvatvalue.SetValue(values[14])
        })
};
function gv_Bind_Pay(s, e) {
    Clear_pay();
    s.GetRowValues(s.focusedRowIndex, 'payno;payref;payvalue;paytypeid;invpayid;payname;paychartid;paychartname', function (values) {
        txt_payno.SetValue(nullToEmpty(values[0])),
            txt_payref.SetValue(nullToEmpty(values[1])),
            txt_payvalue.SetValue(nullToDecimalZero(values[2])),
            cmb_paytypeid.SetValue(nullToIntZero(values[3])),
            cmb_paytypeid.SetText(nullToEmpty(values[5])),
            cmb_paychartid.SetValue(nullToEmpty(values[6])),
            cmb_paychartid.SetText(nullToEmpty(values[7])),
            $('#Hf_invpayid').val(nullToIntZero(values[4]))
    });
};
function gv_Bind_exp(s, e) {
    Clear_exp();
    s.GetRowValues(s.focusedRowIndex, 'invexpid;expid;pinvid;expname;expvalue;accpaidid;chartcode;chartname', function (values) {
        $('#hf_invexpid').val(nullToIntZero(values[0])),
            cmb_expid.SetValue(nullToEmpty(values[1])),
            txt_expvalue.SetValue(nullToDecimalZero(values[4])),
            $('#hf_accpaidid').val(nullToIntZero(values[5])),
            txt_chartcode.SetText(nullToEmpty(values[6])),
            txt_chartename.SetValue(nullToEmpty(values[7]))
    });
};
function SetSuppData(s, e) {
    let searchmodel = {
         suppid : s.GetValue()
    }
    let data = getAction("/VanSalesService/P_inv/GetSuppSingalData", searchmodel)
    if (data.length != 0) {
        searchmodel["suppid"] = data[0].suppid;
        txt_suppname.SetValue(data[0].suppname);
        txt_suppvat.SetValue(data[0].suppvatno);
    }
    else {
        txt_suppid.SetValue("");
        txt_suppname.SetValue("");
        txt_suppvat.SetValue("");
    }
    SuppValidate();
};
function SuppValidate() {
    if (nullToEmpty(txt_suppid.GetValue()) != "") {
        txt_suppname.GetInputElement().readOnly = true;
        txt_suppvat.GetInputElement().readOnly = true;
    }
    else {
        txt_suppname.GetInputElement().readOnly = false;
        txt_suppvat.GetInputElement().readOnly = false;
    }
};
function setItemData(s, e) {
    let searchmodel = {
        itemcode: s.GetValue(),
        barcode1: s.GetValue(),
        barcode2: s.GetValue(),
        itemid: $('#HF_itemid').val()
    }
    let data = getAction("/VanSalesService/items/GetItemSingalData_pinv", searchmodel)
    if (data.length != 0) {
        $('#HF_invdtlid').val("0");
        searchmodel["itemid"] = data[0].itemid;
        txt_itemname.SetValue(data[0].itemname);
        txt_unitname.SetValue(data[0].unitname);
        txt_price.SetValue(data[0].pprice);
        $('#HF_unitid').val(data[0].unitid);
        $('#HF_factor').val(data[0].factor);
        $('#HF_itemid').val(data[0].itemid);
        $('#Hf_vat').val(data[0].vat);
        txt_qty.SetValue(1);
        multiply();
        txt_qty.Focus();
    }
    else {
        clear_dtl();
        txt_itemcode.Focus();
    }
};
function getgvpayrow() {
    var index = gv_invpay.GetFocusedRowIndex();
    var id = gv_invpay.GetRowKey(index);
    document.getElementById("Hf_invpayid").value = id;
};
function getgvdtlrow() {
    var index = gv_pinvdtls.GetFocusedRowIndex();
    var id = gv_pinvdtls.GetRowKey(index);
    document.getElementById("HF_invdtlid").value = id;
};
function calac_vat() {
    ////شامل
    token = GetToken();
    if (rbl_vattype.GetValue() == 1) {
        if (txt_itemvatvalue.GetValue() == 0 || txt_itemvatvalue.GetValue() == null) {

            if (document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
                var text1 = txt_netvalue.GetValue();
                var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;
                txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
            }
            else {
                txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) {
                    var text1 = txt_netvalue.GetValue();
                    var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;
                    txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
                }
            }
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
            // txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
            let searchmodel = {
                //itemcode: txt_itemcode.GetValue(),
                //barcode1: txt_itemcode.GetValue(),
                //barcode2: txt_itemcode.GetValue(),
                unitid: $("#HF_unitid").val(),
                SearchVal: txt_itemcode.GetValue()
            }
            let data = getAction("/VanSalesService/items/GetItemunitData", searchmodel)
            if (data.length != 0) {
                $('#Hf_vat').val(data[0].vat);
            }
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;
            txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;
            txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
        }
    }
    /////////غير شامل
    else if (rbl_vattype.GetValue() == 2) {
        if (txt_itemvatvalue.GetValue() == 0 || txt_itemvatvalue.GetValue() == null) {
            if (document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
                var text1 = txt_netvalue.GetValue();
                var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;
                txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
            }
            else {
                txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) {
                    var text1 = txt_netvalue.GetValue();
                    var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;
                    txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
                }
            }
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
            // txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
            let searchmodel = {
                //itemcode: txt_itemcode.GetValue(),
                //barcode1: txt_itemcode.GetValue(),
                //barcode2: txt_itemcode.GetValue(),
                unitid: $("#HF_unitid").val(),
                SearchVal: txt_itemcode.GetValue()
            }
            let data = getAction("/VanSalesService/items/GetItemunitData", searchmodel)
            if (data.length != 0) {
                $('#Hf_vat').val(data[0].vat);
            }
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;
            txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;
            txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
        }
    }
};
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    switch ($('#popupModalsearchdef').data("name")) {
        case "inv":
            if (nullToEmpty(txt_pinvno.GetValue()) != "تلقائى") {
                gv_pinvdtls.PerformCallback(popupres["postst"] + "," + popupres["docno"] + "," + popupres["invpic"] + "," + popupres["postacc"]);
            }
            else {
                clear_dtl();
                $('#PDetiles').hide();
                $('#p_invpay').hide();
                $('#p_invexp').hide();
            }
            break;
        case "supp":
            SuppValidate();
            break;
        case "items":
            txt_qty.SetValue(1);
            txt_qty.Focus();
            multiply();
            $('#HF_invdtlid').val("0")
            break;
        default:
    }
});
function postp_InvStock(s, e) {
    let postmodel = {
        sinvid: $('#HF_pinvid').val(),
        username: null,
    };
    let res = postaction("/VanSalesService/P_inv/postInvStock", postmodel);
    if (res.errorid != 0) {
        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postst.value = true;
        gv_pinvdtls.PerformCallback($('#hf_postst').val() + "," + txt_docno.GetValue() + "," + lbl_invpic.GetValue() + "," + $('#hf_postacc').val() + "," + lbl_vochrno.GetValue())
        lbl_postst.SetValue("مرحل مستودعات");
    }
}
function postp_InvAcc(s, e) {
    let postmodel = {
        sinvid: $('#HF_pinvid').val(),
        username: GetToken().userName
    };
    let res = postaction("/VanSalesService/P_inv/postInvacc", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postacc.value = true;
        gv_pinvdtls.PerformCallback($('#hf_postst').val() + "," + txt_docno.GetValue() + "," + lbl_invpic.GetValue() + "," + $('#hf_postacc').val() + "," + (res.outputparams["voucher_no"]))
        lbl_postacc.SetValue("مرحل حـسابـات");
    }
}
