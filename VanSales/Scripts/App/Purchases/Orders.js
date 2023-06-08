function validate(s, e) {
    if (txt_podate.GetValue() == "" || txt_podate.GetValue() == null) {
        sweetinfo("برجاء ادخال تاريخ أمر الشراء");
        txt_podate.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
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
function SetSuppData(s, e) {
    let searchmodel = {
        suppid: s.GetValue()
    }
    let data = getAction("/VanSalesService/P_inv/GetSuppSingalData", searchmodel)
    if (data.length != 0) {
        searchmodel["suppid"] = data[0].suppid;
        txt_suppname.SetValue(data[0].suppname);
    }
    else {
        txt_suppid.SetValue("");
        txt_suppname.SetValue("");
    }
    SuppValidate();
};
function SuppValidate() {
    if (nullToEmpty(txt_suppid.GetValue()) != "") {
        txt_suppname.GetInputElement().readOnly = true;
    }
    else {
        txt_suppname.GetInputElement().readOnly = false;
    }
};
function clear_dtl() {
    txt_itemcode.SetValue(""),
        txt_itemname.SetValue(""),
        txt_unitname.SetValue(""),
        txt_qty.SetValue(1),
        txt_pprice.SetValue(0),
        txt_pvalue.SetValue(0),
        txt_descp.SetValue(0),
        txt_descv.SetValue(0),
        txt_pnet.SetValue(0),
        txt_itemnotes.SetValue(""),
        $('#HF_itemid').val(""),
        $('#HF_unitid').val(""),
        $('#HF_factor').val(""),
        $('#Hf_vat').val(""),
        $('#HF_podtlid').val("0")
};
function multiply() {
    var text1 = txt_qty.GetValue();
    var text2 = txt_pprice.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    txt_pvalue.SetValue((parseFloat(t1 * 1).toFixed(2) * parseFloat(t2 * 1).toFixed(2)).toFixed(2));
    Subtract();
};
function multiplydis() {
    var text1 = txt_descp.GetValue();
    var text2 = txt_pvalue.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1 / 100;
    if (text2 != "") t2 = text2;
    if (txt_descp.GetValue() == null)
        txt_descp.SetValue(0);
    if (t1 > 1) {
        sweetinfo(" الخصم اكبر من 100%");
        txt_descp.SetValue(0);
        return;
    }
    txt_descv.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
    Subtract();
};
function Subtract() {
    var text1 = txt_pvalue.GetValue();
    var text2 = txt_descv.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    txt_pnet.SetValue((parseFloat(t1).toFixed(2) - parseFloat(t2).toFixed(2)).toFixed(2));
    calac_vat();
};
function calac_desc() {
    var text1 = txt_descv.GetValue();
    var text2 = txt_pvalue.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    if (txt_descv.GetValue() == null)
        txt_descv.SetValue(0);
    txt_pnet.SetValue((parseFloat(t2 * 1).toFixed(2) - parseFloat(t1 * 1).toFixed(2)).toFixed(2));
    Subtract();
};
function setItemData(s, e) {
    let searchmodel = {
        itemcode: s.GetValue(),
        barcode1: s.GetValue(),
        barcode2: s.GetValue(),
        itemid: $('#HF_itemid').val()
    }
    let data = getAction("/VanSalesService/items/GetItemSingalData", searchmodel)
    if (data.length != 0) {
        $('#HF_podtlid').val("0");
        searchmodel["itemid"] = data[0].itemid;
        txt_itemname.SetValue(data[0].itemname);
        txt_unitname.SetValue(data[0].unitname);
        txt_pprice.SetValue(data[0].pprice);
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
function validate_dtl(s, e) {
    if (nullToEmpty(txt_itemcode.GetValue()) == "") {
        sweetinfo("برجاء إختيار الصنف اولا");
        txt_itemcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (nullToIntZero(txt_qty.GetValue()) == "0") {
        sweetinfo("برجاء إضافة كمية للصنف");
        txt_qty.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
    if (nullToIntZero(txt_pprice.GetValue()) == "0") {
        sweetinfo("برجاء إضافة سعر للصنف");
        txt_qty.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function calac_vat() {
    ////شامل
    token = GetToken();
    if (rbl_vattype.GetValue() == 1) {
        if (txt_itemvatvalue.GetValue() == 0 || txt_itemvatvalue.GetValue() == null) {

            if (document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
                var text1 = txt_pnet.GetValue();
                var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;
                txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
            }
            else {
                txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_descv.GetValue() != hf_disc) {
                    var text1 = txt_pnet.GetValue();
                    var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;
                    txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
                }
            }
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
            let searchmodel = {
                itemcode: txt_itemcode.GetValue(),
                barcode1: txt_itemcode.GetValue(),
                barcode2: txt_itemcode.GetValue(),

            }
            let data = getAction("/VanSalesService/items/GetItemSingalData", searchmodel)
            if (data.length != 0) {
                $('#Hf_vat').val(data[0].vat);
            }
            var text1 = txt_pnet.GetValue();
            var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;
            txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_pnet.GetValue();
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
                var text1 = txt_pnet.GetValue();
                var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;
                txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
            }
            else {
                txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_descv.GetValue() != hf_disc) {
                    var text1 = txt_pnet.GetValue();
                    var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;
                    txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
                }
            }
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
            let searchmodel = {
                itemcode: txt_itemcode.GetValue(),
                barcode1: txt_itemcode.GetValue(),
                barcode2: txt_itemcode.GetValue(),
            }
            let data = getAction("/VanSalesService/items/GetItemSingalData", searchmodel)
            if (data.length != 0) {
                $('#Hf_vat').val(data[0].vat);
            }
            var text1 = txt_pnet.GetValue();
            var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;
            txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_pnet.GetValue();
            var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;
            txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
        }
    }
};
function gv_Bind_dtl(s, e) {
    s.GetRowValues(s.focusedRowIndex, 'podtlid;itemid;itemname;unitid;unitname;qty;factor;pprice;pvalue;descp;descv;pnet;itemnotes;itemcode;vatvalue',
        function (values) {
            $('#HF_podtlid').val(nullToIntZero(values[0])),
                $('#HF_itemid').val(nullToIntZero(values[1])),
                txt_itemname.SetValue(values[2]),
                $('#HF_unitid').val(nullToIntZero(values[3])),
                txt_unitname.SetValue(values[4]),
                txt_qty.SetValue(values[5]),
                $('#hf_factor').val(nullToIntZero(values[6])),
                txt_pprice.SetValue(values[7]),
                txt_pvalue.SetValue(values[8]),
                txt_descp.SetValue(values[9]),
                txt_descv.SetValue(values[10]),
                txt_pnet.SetValue(values[11]),
                txt_itemnotes.SetValue(values[12]),
                txt_itemcode.SetValue(values[13]),
                txt_itemvatvalue.SetValue(values[14])
        })
};
function getgvdtlrow() {
    var index = gv_orderdtls.GetFocusedRowIndex();
    var id = gv_orderdtls.GetRowKey(index);
    document.getElementById("HF_podtlid").value = id;
};
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "ord":
                if (nullToEmpty(txt_pono.GetValue()) != "تلقائى") {
                    gv_orderdtls.PerformCallback(popupres["podocno"] + "," + popupres["pinvc"]);
                }
                else {
                    clear_dtl();
                    $('#PDetiles').hide();
                }
                break;
            case "supp":
                SuppValidate();
                break;
            case "items":
                txt_qty.SetValue(1);
                txt_qty.Focus();
                multiply();
                $('#HF_podtlid').val("0")
                break;
            default:
        }
    }
});