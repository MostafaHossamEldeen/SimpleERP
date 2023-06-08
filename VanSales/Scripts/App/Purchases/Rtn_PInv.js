function onKeyPress1(s, e) {
    if (e.htmlEvent.keyCode == 13)
        gv_invdtls.GetEditor('txt_item').Focus();
};
function supp_validate(s, e) {
    if (ch_inv.GetValue() == false || ch_inv.GetValue() == null) {
        txt_suppid.GetInputElement().readOnly = true;
        txt_suppname.GetInputElement().readOnly = true;
        txt_suppvat.GetInputElement().readOnly = true;
        document.querySelector("#puop_supp").disabled = true;
    }
    else {
        if (nullToEmpty(txt_suppid.GetValue()) == "") {
            txt_suppname.GetInputElement().readOnly = false;
            txt_suppvat.GetInputElement().readOnly = false;
            document.querySelector("#puop_supp").disabled = false;
        }
        else {
            txt_suppname.GetInputElement().readOnly = true;
            txt_suppvat.GetInputElement().readOnly = true;
        }
    }
};
function validate_withoutinv(s, e) {
    if (ch_inv.GetValue() == true) {
        txt_docno.GetInputElement().readOnly = true;
        document.querySelector("#btn_search_inv").disabled = true;
        chk_rtnall.SetEnabled(false);
        chk_rtnall.valueChecked = false;
        txt_docno.SetValue("");
        $('#HF_docid').val("");
    }
    else {
        txt_docno.GetInputElement().readOnly = false;
        document.querySelector("#btn_search_inv").disabled = false;
        chk_rtnall.SetEnabled(true);
    }
};
function validate(s, e) {
    if (nullToEmpty(txt_docno.GetValue()) == "" && (ch_inv.GetValue() == false || ch_inv.GetValue() == null)) {
        sweetinfo('برجاء ادخال رقم الفاتوره او الاختيار بدون فاتوره');
        txt_docno.Focus();
        e.txt_docno.Focus();
        return
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
    if (txt_pinvdate.GetValue() == "" || txt_pinvdate.GetValue() == null) {
        sweetinfo("برجاء ادخال تاريخ الفاتورة");
        txt_pinvdate.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};
function validate_dtl(s, e) {
    if (nullToEmpty(txt_itemcode.GetValue()) == "") {
        sweetinfo("برجاء ادخال كود الصنف اولا");
        txt_itemcode.Focus();
        e.txt_itemcode.Focus();
        return;
    }
    if (nullToDecimalZero(txt_qty.GetValue()) == 0) {
        sweetinfo("لايمكن ادخال كميه صفر او فارغه");
        txt_qty.Focus();
        e.txt_qty.Focus();
        return;
    }
};
function validate_other_inv() {
    txt_docno.GetInputElement().readOnly = true;
    document.querySelector("#btn_search_inv").disabled = true;
};
function function_save() {
    sweetsuccess("تم الحفظ بنجاح");
};
function clear_dtl() {
    txt_itemcode.SetValue(""),
        txtitem_name.SetValue(""),
        txt_unit.SetValue(""),
        txt_qty.SetValue(1),
        $('#hf_qty').val(""),
        $('#HF_unitid').val(""),
        $('#HF_invdtlid').val(""),
        $('#HF_itemid').val(""),
        $('#HF_factor').val(""),
        $('#HF_cost').val(""),
        txt_value.SetValue(0),
        txt_discp.SetValue(0),
        txt_discvalue.SetValue(0),
        txt_netvalue.SetValue(0),
        txt_itemvatvalue.SetValue(0),
        $('#Hf_vat').val(""),
        txt_itemnotes.SetValue(""),
        txt_price.SetValue(0)
};
function Clear_pay() {
    cmb_paytype.SetSelectedIndex(0),
        txt_payno.SetValue(""),
        txt_payref.SetValue(""),
        txt_payvalue.SetValue(0),
        cmb_paychartid.SetValue("");
    $('#Hf_payid').val("")
};
function Confirm() {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";
    if (confirm("هل تريد الحذف؟")) {
        confirm_value.value = "نعم";
    } else {
        confirm_value.value = "No";
    }
    document.forms[0].appendChild(confirm_value);
};
function function_delete() {
    sweetinfo("برجاء اختيار الصنف المراد حذفه");
};
function getgvrow() {
    var index = gv_invdtls.GetFocusedRowIndex();
    var id = gv_invdtls.GetRowKey(index);
    HF_invdtlid.value = id;
};
function getrow() {
    var index = gv_invpay.GetFocusedRowIndex();
    var id = gv_invpay.GetRowKey(index);
    document.getElementById("Hf_payid").value = id;
};
function getrow_dtlinv() {
    var index = gv_invdtls.GetFocusedRowIndex();
    var id = gv_invdtls.GetRowKey(index);
    document.getElementById("HFpinviddtl").value = id;
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
    if (t1 > 1)
        sweetinfo(" الخصم اكبر من 100%");
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
function sumdata() {
    var sum = 0;
    var indices = gv_invdtls.GetVisibleRowsOnPage();//.GetRowVisibleIndices();//GridHR_Op_d.batchEditApi.GetRowVisibleIndices();
    for (i = 0; i < indices;) {
        gv_invdtls.GetRowValues(i, "vatvalue", OnGetRowValuesval);
    }
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
function item_readonly() {
    if (chk_rtnall.GetValue() == true || ch_inv.GetValue() == false) {
        txt_itemcode.GetInputElement().readOnly = true;
    }
};
function OnGetRowValues(value) {
    alert(value)
};
function OnGetRowValuesval(value) {
    alert(value)
};
function print_newtab() {
    var x = document.getElementById("HF_inv_id").value;
    if (x == "") {
        sweetinfo('لم يتم اختيار فاتوره للطباعه');
        return;
    }
    window.open("/Sales/Report.aspx?pinvid=" + x + "&page=inv", null, "dialogHeight:600px; dialogWidth:920px,status=no,toolbar=no,titlebar=no,scrollbars=1,menubar=no,location=no");
};
function invsearch() {
    var rc = window.open('inv_search.aspx', '', 'width=600,height=500');
};
function Rtn_search() {
    var rc = window.open('Rtn_search.aspx', '', 'width=600,height=500');
};
function itemsearch() {
    var rc = window.open('item_search.aspx', '', 'top=200,left=700,width=600,height=500');
};
function item_invsearch() {
    var ivn_id = document.getElementById("HF_inv_id").value;
    var rc = window.open('items_inv_search.aspx?inv_no=' + ivn_id, '', 'top=200,left=700,width=600,height=500');
};
function cus_search() {
    var rc = window.open('cust_search.aspx', '', 'top=200,left=700,width=600,height=500');
};
function add_cus() {
    var rc = window.open('/Customers/customers.aspx', '', 'top=200,left=290,width=1000,height=500');
};
function UpdateReal(x) {
    document.getElementById("HF_inv_id").value = x;
    __doPostBack('HF_inv_id', "HF_inv_id");
};
function UpdateRtn(x) {
    document.getElementById("HF_rtn_inv_id").value = x;
    __doPostBack('HF_rtn_inv_id', "HF_rtn_inv_id");
};
function Updateitems(x) {
    document.getElementById("HfItemID").value = x;
    __doPostBack('HfItemID', "HfItemID");
};
function Invitems(x) {
    document.getElementById("Hf_invdtlID").value = x;
    __doPostBack('Hf_invdtlID', "Hf_invdtlID");
};
function Updatecus(x) {
    document.getElementById("Hf_cusid").value = x;
    __doPostBack('Hf_cusid', "Hf_cusid");
};
function addcus(x) {
    document.getElementById("Hf_cusid").value = x;
    __doPostBack('Hf_cusid', "Hf_cusid");
};
function qty_rtn_chk(s, e) {
    if (ch_inv.GetValue() == false) {
        if (txt_qty.GetValue() > hf_qty.value) {
            sweetinfo("كميه المرتجع اكبر من كميه الفاتوره");
            ASPxClientUtils.PreventEvent(evt.htmlEvent);
        }
        else {
            if (nullToDecimalZero(txt_qty.GetValue()) == 0) {
                sweetinfo("لايمكن ادخال الكميه صفر");
                return;
            }
            ASPxClientUtils.PreventEvent(evt.htmlEvent);
            btn_save_dtls.SetEnabled(true);
        }
    }
};
function fillData(s, e) {

    if (ch_inv.GetValue() == true) {
        itemsearch(); return false;
    }
    else {
        item_invsearch(); return false;
    }
};
function gv_Bind_dtl(s, e) {
    clear_dtl();
    s.GetRowValues(s.focusedRowIndex, 'itemcode;itemname;unitname;qty;unitid;invdtlid;itemid;factor;cost;value;discp;discvalue;netvalue;vatvalue;itemnotes;price', function (values) {
        txt_itemcode.SetValue(nullToEmpty(values[0])),
            txtitem_name.SetValue(nullToEmpty(values[1])),
            txt_unit.SetValue(nullToEmpty(values[2])),
            txt_qty.SetValue(nullToDecimalZero(values[3])),
            $("#HF_unitid").val(nullToIntZero(values[4])),
            $("#HF_invdtlid").val(nullToIntZero(values[5])),
            $("#HF_itemid").val(nullToIntZero(values[6])),
            $("#HF_factor").val(nullToDecimalZero(values[7])),
            $('#HF_cost').val(nullToDecimalZero(values[8])),
            txt_value.SetValue(nullToDecimalZero(values[9])),
            txt_discp.SetValue(nullToDecimalZero(values[10])),
            txt_discvalue.SetValue(nullToDecimalZero(values[11])),
            txt_netvalue.SetValue(nullToDecimalZero(values[12])),
            txt_itemvatvalue.SetValue(nullToDecimalZero(values[13])),
            txt_itemnotes.SetValue(nullToEmpty(values[14])),
            txt_price.SetValue(nullToDecimalZero(values[15]))
    });
};
function gv_Bind_Pay(s, e) {
    Clear_pay();
    s.GetRowValues(s.focusedRowIndex, 'payno;payref;payvalue;paytypeid;invpayid;payname;paychartid;paychartname', function (values) {
        txt_payno.SetValue(nullToEmpty(values[0])),
            txt_payref.SetValue(nullToEmpty(values[1])),
            txt_payvalue.SetValue(nullToDecimalZero(values[2])),
            cmb_paytype.SetValue(nullToIntZero(values[3])),
            cmb_paytype.SetText(nullToEmpty(values[5])),
            cmb_paychartid.SetValue(nullToEmpty(values[6])),
            cmb_paychartid.SetText(nullToEmpty(values[7])),
            $('#Hf_payid').val(nullToIntZero(values[4]))
    });
};
function SetSuppData(s, e) {
    let searchmodel = {
        suppid: s.GetValue()
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
function setInvData(s, e) {
    let searchmodel = {
        docno: s.GetValue()
    }
    let data = getAction("/VanSalesService/P_inv/GetRtninvCodeSingalData", searchmodel)
    if (nullToEmpty(data.length) != 0) {
        searchmodel["pinvid"] = data[0].pinvid;
        txt_suppid.SetValue(data[0].suppid);
        txt_suppname.SetValue(data[0].suppname);
        txt_suppvat.SetValue(data[0].suppvat);
        rbl_vattype.SetSelectedIndex(data[0].vattype);
        rbl_vattype.SetEnabled(false);
        $('#HF_docid').val(data[0].pinvid);
    }
    else {
        sweetinfo('هذه الفاتوره غير موجوده ');
        txt_docno.SetValue("");
        txt_suppid.SetValue("");
        txt_suppname.SetValue("");
        txt_suppvat.SetValue("");
        rbl_vattype.SetSelectedIndex(0);
        rbl_vattype.SetEnabled(true);
        $('#HF_docid').val("");
    }
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
        $('#HF_invdtlid').val("")
        searchmodel["itemid"] = data[0].itemid;
        txtitem_name.SetValue(data[0].itemname);
        txt_unit.SetValue(data[0].unitname);
        txt_price.SetValue(data[0].fprice);
        $('#HF_unitid').val(data[0].unitid);
        $('#HF_factor').val(data[0].factor);
        $('#HF_cost').val(data[0].cprice);
        $('#HF_itemid').val(data[0].itemid);
        $('#Hf_vat').val(data[0].vat);
        multiply();
    }
    else {
        clear_dtl();
        txt_itemcode.Focus();
    }
};
function setRtnInvdtlsQty(s, e) {
    let searchmodel = {
        rtn_sinvno: s.GetValue(),
        sinvno: s.GetValue(),
        actiontype: s.GetValue(),
        itemid: $('#HF_itemid').val(),
        invdtlid: $('#HF_invdtlid').val()
    }
    let data = getAction("/VanSalesService/items/RtnInvdtlsQty", searchmodel)
    if (data.length != 0) {
        $('#hf_qty').val(data[0].qty);
    }
    else {
        $('#hf_qty').val("");
    }
};
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        if (nullToEmpty(txt_pinvno.GetValue()) != "تلقائى") {
            if (nullToEmpty($('#HF_itemid').val() != "")) {
                txt_qty.Focus();
                multiply();
            }
            gv_invdtls.PerformCallback(lbl_invpic.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_postacc').val())
            if (ch_inv.GetChecked() == true) {
                txt_docno.GetInputElement().readOnly = true;
                document.querySelector("#btn_search_inv").disabled = true;
                txt_docno.SetValue("0");
                chk_rtnall.SetEnabled(false);
                chk_rtnall.valueChecked = false;
                txt_docno.SetValue("");
                $('#HF_docid').val("");
            }
            else {
                txt_docno.GetInputElement().readOnly = false;

                ch_inv.SetChecked(false)
                document.querySelector("#btn_search_inv").disabled = false;
                chk_rtnall.SetEnabled(false);
            }
        }
        else {
            if (nullToEmpty(txt_suppid.GetValue() != "")) {
                supp_validate();
            }
            clear_dtl();
            $('#PDetiles').hide()
            $('#p_invpay').hide()
        }
        if (nullToEmpty(txt_docno.GetValue() != "")) {
            rbl_vattype.SetEnabled(false);
        }
        else {
            rbl_vattype.SetEnabled(true);
        }
    }
});



function postp_rtn_InvStock(s, e) {
    let postmodel = {
        // branchid: ddl_branchid.GetValue(),
        sinvid: $('#HF_pinvid').val(),
        username: null,

    };

    let res = postaction("/VanSalesService/P_inv/postrtnInvStock", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postst.value = true;
        gv_invdtls.PerformCallback(lbl_invpic.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_postacc').val() + "," + lbl_vochrno.GetValue())
        lbl_postst.SetValue("مرحل مستودعات");
    }
    // console.log(res)
}
function postp_rtn_InvAcc(s, e) {
    let postmodel = {
        sinvid: $('#HF_pinvid').val(),
        username:  GetToken().userName

    };

    let res = postaction("/VanSalesService/P_inv/postrtnInvacc", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postacc.value = true;
        gv_invdtls.PerformCallback(lbl_invpic.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_postacc').val() + "," + (res.outputparams["voucher_no"]))
        lbl_postacc.SetValue("مرحل حـسابـات");
    }
}
