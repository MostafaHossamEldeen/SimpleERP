
function onKeyPress1(s, e) {
    if (e.htmlEvent.keyCode == 13)
        gvs_invdtls.GetEditor('txt_item').Focus();
}
function cus_validate(s, e) {
    if (ch_inv.GetValue() == false || ch_inv.GetValue() == null) {



        txt_cusid.GetInputElement().readOnly = true;
        ctname.GetInputElement().readOnly = true;
        txt_custadd.GetInputElement().readOnly = true;
        txt_custvat.GetInputElement().readOnly = true;
        txt_custmobile.GetInputElement().readOnly = true;
        document.querySelector("#puop_cust").disabled = true;
    }
    else {
        if (txt_cusid.GetValue() == "" || Hf_cusid.value == "") {
            txt_cusid.GetInputElement().readOnly = false;
            ctname.GetInputElement().readOnly = false;
            txt_custadd.GetInputElement().readOnly = false;
            txt_custvat.GetInputElement().readOnly = false;
            txt_custmobile.GetInputElement().readOnly = false;
            document.querySelector("#puop_cust").disabled = false;
        }
        else {
            /*txt_cusid.GetInputElement().readOnly = true;*/
            ctname.GetInputElement().readOnly = true;
            txt_custadd.GetInputElement().readOnly = true;
            txt_custvat.GetInputElement().readOnly = true;
            txt_custmobile.GetInputElement().readOnly = true;
        }

    }

}
function validate_withoutinv(s, e) {
    if (ch_inv.valueChecked == true) {
        txt_invno.GetInputElement().readOnly = true;
        document.querySelector("#btn_search_inv").disabled = true;
       /* btn_search_inv.SetEnabled(false);*/
        chk_rtnall.SetEnabled(false);
        chk_rtnall.valueChecked = false;
        txt_invno.SetValue("");
        $('#HF_invid').val("");
      /*  txt_cusid.SetValue("");
        ctname.SetValue("");
        txt_custvat.SetValue("");
        txt_custadd.SetValue("");
        txt_custmobile.SetValue("");
        cmb_smanid.SetValue("");
       */
    }
    else {
        txt_invno.GetInputElement().readOnly = false;
        document.querySelector("#btn_search_inv").disabled = false;
       /* btn_search_inv.SetEnabled(true);*/
        chk_rtnall.SetEnabled(true);
    }
}
function validate(s, e) {
    if (nullToEmpty(txt_invno.GetValue()) == "" && (ch_inv.GetValue() == false || ch_inv.GetValue() == null)) {

        sweetinfo('برجاء ادخال رقم الفاتوره او الاختيار بدون فاتوره');
        txt_invno.Focus();
        e.txt_invno.Focus();
        return
    }
    if (dll_sinvpay.GetValue() == 2 || dll_sinvpay.GetValue == "أجل") {
        if (txt_cusid.GetValue() == null) {
            sweetinfo("برجاء إختيار العميل لكون نوع سداد الفاتورة أجل");
            txt_cusid.Focus();
            e.txt_cusid.Focus();
            return;
        }
    }
    if (ctname.GetValue() == "" || ctname.GetValue() == null) {
        // alert("برجاء ادخال اسم العميل");
        sweetinfo("برجاء ادخال اسم العميل");

        //document.myForm.Name.focus();
        ctname.Focus();
        e.ctname.Focus();


        return;
    }
    if (sinvdata.GetValue() == "" || sinvdata.GetValue() == null) {
        sinvdata.Focus();
        e.sinvdata.Focus();
        return;
    }
    if (cmb_branchid.GetValue() == "" || cmb_branchid.GetValue() == null) {
        cmb_branchid.Focus();
        e.cmb_branchid.Focus();
        return;
    }

}
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
    //qty_rtn_chk(s,e)
}
function validate_other_inv()
{
    txt_invno.GetInputElement().readOnly = true;
    document.querySelector("#btn_search_inv").disabled = true;
}

function function_save() {
    // alert("تم الحفظ بنجاح");
    sweetsuccess("تم الحفظ بنجاح");
}
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
        txtitem_vatvalue.SetValue(0),
        $('#Hf_vat').val(""),
        txt_itemnotes.SetValue(""),
        txt_price.SetValue(0)
}
function Clear_pay() {
    cmb_paytype.SetSelectedIndex(0),
        txt_payno.SetValue(""),
        txt_payref.SetValue(""),
        txt_payvalue.SetValue(0),
        cmb_paychartid.SetValue("");
    $('#Hf_payid').val("")

}
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
}
function function_delete() {
    // alert("برجاء اختيار الصنف المراد حذفه");
    sweetinfo("برجاء اختيار الصنف المراد حذفه");
}
function getgvrow() {

    var index = gvs_invdtls.GetFocusedRowIndex();


    var id = gvs_invdtls.GetRowKey(index);
    HF_invdtlid.value = id;
}

function getrow() {

    var index = gv_invpay.GetFocusedRowIndex();


    var id = gv_invpay.GetRowKey(index);
    document.getElementById("Hf_payid").value = id;

}
function getrow_dtlinv() {

    var index = gvs_invdtls.GetFocusedRowIndex();


    var id = gvs_invdtls.GetRowKey(index);
    document.getElementById("HFsinviddtl").value = id;
}

function isFloatNumber(e, t) {
    var n;
    var r;
    if (navigator.appName == "Microsoft Internet Explorer" || navigator.appName == "Netscape") {
        n = t.keyCode;
        r = 1;
        if (navigator.appName == "Netscape") {
            n = t.charCode;
            r = 0
        }
    } else {
        n = t.charCode;
        r = 0
    }
    if (r == 1) {
        if (!(n >= 48 && n <= 57 || n == 46)) {
            t.returnValue = false
        }
    } else {
        if (!(n >= 48 && n <= 57 || n == 0 || n == 46)) {

            t.preventDefault()
        }
    }
}

//////////calc
function multiply() {


    var text1 = txt_qty.GetValue();
    var text2 = txt_price.GetValue();

    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;

    txt_value.SetValue((parseFloat(t1 * 1).toFixed(2) * parseFloat(t2 * 1).toFixed(2)).toFixed(2));


    Subtract();
}
function multiplydis() {


    var text1 = txt_discp.GetValue();
    var text2 = txt_value.GetValue();

    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1 / 100;
    if (text2 != "") t2 = text2;
    if (txt_discp.GetValue() == null)
        txt_discp.SetValue(0);
    if (t1 > 1)

        //alert(" الخصم اكبر من 100%");
        sweetinfo(" الخصم اكبر من 100%");
    txt_discvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
    Subtract();
}
function Subtract() {



    var text1 = txt_value.GetValue();
    var text2 = txt_discvalue.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;

    txt_netvalue.SetValue((parseFloat(t1).toFixed(2) - parseFloat(t2).toFixed(2)).toFixed(2));

    calac_vat();
}
function calac_vat() {
    ////شامل
    if ($("#HF_vattype").val() == 1) {
        if (txtitem_vatvalue.GetValue() == 0 || txtitem_vatvalue.GetValue() == null) {

            if ( document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
                var text1 = txt_netvalue.GetValue();
                var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;

                txtitem_vatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2))).toFixed(2));

            }
            else {

                txtitem_vatvalue.SetValue(txtitem_vatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) {
                    var text1 = txt_netvalue.GetValue();
                    var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;

                    txtitem_vatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2))).toFixed(2));
                }
            }
        }
        else if (txtitem_vatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
          //  txtitem_vatvalue.SetValue(txtitem_vatvalue.GetValue());
            let searchmodel = {
                // itemcode: txt_itemcode.GetValue(),
                // barcode1: txt_itemcode.GetValue(),
                //  barcode2: txt_itemcode.GetValue(),
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

            txtitem_vatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
        }
        else if (txtitem_vatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;

            txtitem_vatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2))).toFixed(2));
        }
    }
    /////////غير شامل
    else if ($("#HF_vattype").val() == 2) {
        if (txtitem_vatvalue.GetValue() == 0 || txtitem_vatvalue.GetValue() == null) {

            if (document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
                var text1 = txt_netvalue.GetValue();
                var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;

                txtitem_vatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));

            }
            else {

                txtitem_vatvalue.SetValue(txtitem_vatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) {
                    var text1 = txt_netvalue.GetValue();
                    var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;

                    txtitem_vatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
                }
            }
        }
        else if (txtitem_vatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
          //  txtitem_vatvalue.SetValue(txtitem_vatvalue.GetValue());
            let searchmodel = {
                // itemcode: txt_itemcode.GetValue(),
                // barcode1: txt_itemcode.GetValue(),
                //  barcode2: txt_itemcode.GetValue(),
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

            txtitem_vatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2)).toFixed(2));
        }
        else if (txtitem_vatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;

            txtitem_vatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
        }
    }
    /* if (txtitem_vatvalue.GetValue() == 0 || txtitem_vatvalue.GetValue() == null) {

         if (document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
             var text1 = txt_netvalue.GetValue();
             var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
             var t1 = 0, t2 = 0;
             if (text1 != "") t1 = text1;
             if (text2 != "") t2 = text2;

             txtitem_vatvalue.SetValue(parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2));

         }
         else {

 txtitem_vatvalue.SetValue(txtitem_vatvalue.GetValue());
             if (txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) {
                 var text1 = txt_netvalue.GetValue();
                 var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
                 var t1 = 0, t2 = 0;
                 if (text1 != "") t1 = text1;
                 if (text2 != "") t2 = text2;

                 txtitem_vatvalue.SetValue(parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2));
             }
         }
     }
     else if (txtitem_vatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
 txtitem_vatvalue.SetValue(txtitem_vatvalue.GetValue());

     }
     else if (txtitem_vatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
         var text1 = txt_netvalue.GetValue();
         var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
         var t1 = 0, t2 = 0;
         if (text1 != "") t1 = text1;
         if (text2 != "") t2 = text2;

         txtitem_vatvalue.SetValue(parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2));
     }*/
}
function sumdata() {

    var sum = 0;
    var indices = gvs_invdtls.GetVisibleRowsOnPage();//.GetRowVisibleIndices();//GridHR_Op_d.batchEditApi.GetRowVisibleIndices();
    for (i = 0; i < indices;) {

        // gvs_invdtls.GetRowValues(i, "netvalue", OnGetRowValues)
        gvs_invdtls.GetRowValues(i, "vatvalue", OnGetRowValuesval);

    }

}
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
}


function item_readonly() {

    if (chk_rtnall.GetValue() == true || ch_inv.GetValue() == false) {
        txt_itemcode.GetInputElement().readOnly = true;
    }
}
function OnGetRowValues(value) {
    alert(value)
}
function OnGetRowValuesval(value) {
    alert(value)

}
function print_newtab() {

    var x = document.getElementById("HF_inv_id").value;
    if (x == "") {

        // alert('لم يتم اختيار فاتوره للطباعه');
        sweetinfo('لم يتم اختيار فاتوره للطباعه');
        return;
    }
    window.open("/Sales/Report.aspx?sinvid=" + x + "&page=inv", null, "dialogHeight:600px; dialogWidth:920px,status=no,toolbar=no,titlebar=no,scrollbars=1,menubar=no,location=no");
}
function invsearch() {
    var rc = window.open('inv_search.aspx', '', 'width=600,height=500');

}
function Rtn_search() {
    var rc = window.open('Rtn_search.aspx', '', 'width=600,height=500');

}

function itemsearch() {
    var rc = window.open('item_search.aspx', '', 'top=200,left=700,width=600,height=500');
}

function item_invsearch() {
    var ivn_id = document.getElementById("HF_inv_id").value;
    var rc = window.open('items_inv_search.aspx?inv_no=' + ivn_id, '', 'top=200,left=700,width=600,height=500');
}
function cus_search() {
    var rc = window.open('cust_search.aspx', '', 'top=200,left=700,width=600,height=500');
}
function add_cus() {
    var rc = window.open('/Customers/customers.aspx', '', 'top=200,left=290,width=1000,height=500');
}
function UpdateReal(x) {
    document.getElementById("HF_inv_id").value = x;
    __doPostBack('HF_inv_id', "HF_inv_id");


}
function UpdateRtn(x) {
    document.getElementById("HF_rtn_inv_id").value = x;
    __doPostBack('HF_rtn_inv_id', "HF_rtn_inv_id");


}

function Updateitems(x) {
    document.getElementById("HfItemID").value = x;
    __doPostBack('HfItemID', "HfItemID");


}

function Invitems(x) {
    document.getElementById("Hf_invdtlID").value = x;
    __doPostBack('Hf_invdtlID', "Hf_invdtlID");


}
function Updatecus(x) {
    document.getElementById("Hf_cusid").value = x;
    __doPostBack('Hf_cusid', "Hf_cusid");


}
function addcus(x) {
    document.getElementById("Hf_cusid").value = x;
    __doPostBack('Hf_cusid', "Hf_cusid");


}
function qty_rtn_chk(s, e) {
    if (ch_inv.GetValue() == false) {
        if (txt_qty.GetValue() > hf_qty.value) {
     
            sweetinfo("كميه المرتجع اكبر من كميه الفاتوره");
            return;
            //btn_save_dtls.SetEnabled(false);
           // ASPxClientUtils.PreventEvent(e.htmlEvent);
        }
        else {
            if (nullToDecimalZero(txt_qty.GetValue()) == 0)
            {
                sweetinfo("لايمكن ادخال الكميه صفر");
                return;
            }
            ASPxClientUtils.PreventEvent(e.htmlEvent);
            btn_save_dtls.SetEnabled(true);
        }
    }
}


function fillData(s, e) {

    if (ch_inv.GetValue() == true) {
        itemsearch(); return false;
    }
    else {
        item_invsearch(); return false;
    }
}
function Gvs_Bind_dtl(s, e) {

    clear_dtl();
    s.GetRowValues(s.focusedRowIndex, 'itemcode;itemname;unitname;qty;unitid;invdtlid;itemid;factor;cost;value;discp;discvalue;netvalue;vatvalue;itemnotes;price', function (values) {


        txt_itemcode.SetValue(nullToEmpty(values[0])),
            txtitem_name.SetValue(nullToEmpty(values[1])),
            txt_unit.SetValue(nullToEmpty(values[2])),
            txt_qty.SetValue(nullToDecimalZero(values[3])),
            //document.getElementById("hf_qty").value = nullToDecimalZero(values[3]),
            $("#HF_unitid").val(nullToIntZero(values[4])),
            $("#HF_invdtlid").val(nullToIntZero(values[5])),
            $("#HF_itemid").val(nullToIntZero(values[6])),
            $("#HF_factor").val(nullToDecimalZero(values[7])),
            $('#HF_cost').val(nullToDecimalZero(values[8])),
            txt_value.SetValue(nullToDecimalZero(values[9])),
            txt_discp.SetValue(nullToDecimalZero(values[10])),
            txt_discvalue.SetValue(nullToDecimalZero(values[11])),
            txt_netvalue.SetValue(nullToDecimalZero(values[12])),
            txtitem_vatvalue.SetValue(nullToDecimalZero(values[13])),
           // $('#Hf_vat').val(nullToDecimalZero(values[13])),
            txt_itemnotes.SetValue(nullToEmpty(values[14])),
            txt_price.SetValue(nullToDecimalZero(values[15]))

        //   HF_itemunitid.SetValue(values[4]),

        //HF_itemid.SetValue(values[6])


    });
    /*setRtnInvdtlsQty(s, e);*/
}
function Gvs_Bind_Pay(s, e) {

    Clear_pay
    s.GetRowValues(s.focusedRowIndex, 'payno;payref;payvalue;paytypeid;invpayid;payname', function (values) {


        txt_payno.SetValue(nullToEmpty(values[0])),
            txt_payref.SetValue(nullToEmpty(values[1])),
            txt_payvalue.SetValue(nullToDecimalZero(values[2])),
            cmb_paytype.SetValue(nullToDecimalZero(values[3])),
            cmb_paytype.SetText(nullToEmpty(values[5])),
            $('#Hf_payid').val(nullToIntZero(values[4]))

    });

}
function setCustData(s, e) {
    let searchmodel = {
        custcode: s.GetValue()

    }
    let data = getAction("/VanSalesService/inv/GetcustSingalData", searchmodel)

    if (data.length != 0) {

        searchmodel["custcode"] = data[0].custcode;
        ctname.SetValue(data[0].custname);
        txt_custadd.SetValue(data[0].custadd);
        txt_custvat.SetValue(data[0].custvat);
        txt_custmobile.SetValue(data[0].custmob);
        cmb_smanid.SetValue(data[0].smanid);
        $('#Hf_cusid').val(data[0].custid);


    }
    else {
        txt_cusid.SetValue("");
        ctname.SetValue("");
        txt_custadd.SetValue("");
        txt_custvat.SetValue("");
        txt_custmobile.SetValue("");
        cmb_smanid.SetValue("");
        $('#Hf_cusid').val("");
    }
    cus_validate();
}
function setInvData(s, e) {
    let searchmodel = {
        sinvno: s.GetValue()
    }
    let data = getAction("/VanSalesService/inv/GetRtninvCodeSingalData", searchmodel)

    if (nullToEmpty(data.length) != 0) {

        searchmodel["sinvid"] = data[0].sinvid;
        txt_cusid.SetValue(data[0].custid);
        ctname.SetValue(data[0].custname);
        txt_custvat.SetValue(data[0].custvat);
        txt_custadd.SetValue(data[0].custadd);
        txt_custmobile.SetValue(data[0].custmobile);
        cmb_smanid.SetValue(data[0].smanid);
        cmb_smanid.SetText(data[0].smanname);

        $('#HF_invid').val(data[0].sinvid);



    }
    else {
        sweetinfo('هذه الفاتوره غير موجوده ');
        txt_invno.SetValue("");
        txt_cusid.SetValue("");
        ctname.SetValue("");
        txt_custvat.SetValue("");
        txt_custadd.SetValue("");
        txt_custmobile.SetValue("");
        cmb_smanid.SetValue("");
        $('#HF_invid').val("");
    }
}
function setItemData(s, e) {
    let searchmodel = {
        itemcode: s.GetValue(),
        barcode1: s.GetValue(),
        barcode2: s.GetValue(),
        itemid: $('#HF_itemid').val()
        //  branchid: cmb_branchid.GetValue()
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
        //lbl_qtyinf.SetValue(data[0]) 
        //data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
        //if (data.length != 0) {

        //    lbl_qtyinf.SetValue(data[0].qty)
        //} 
        txt_qty.Focus();
    }
    else {
        clear_dtl();
        txt_itemcode.Focus();
    }
}
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
}
function preventwrite(s, e) {
    ASPxClientUtils.PreventEventAndBubble(e);
}
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        if (nullToEmpty(txt_rtn_sinvno.GetValue()) != "تلقائى") {

            if (nullToEmpty($('#Hf_cusid').val() != "")) {
                cus_validate();
            }

            if (nullToEmpty($('#HF_itemid').val() != "")) {
          //  if( ch_inv.GetChecked() == true)
              //  {
                    multiply();
               // }
            }
            debugger
            if (ch_inv.GetChecked() == true) {
                //ch_inv.SetChecked(true);
                //ch_inv.SetValue(true);

                txt_invno.GetInputElement().readOnly = true;
                document.querySelector("#btn_search_inv").disabled = true;
                /*  btn_search_inv.SetEnabled(false);*/
                txt_invno.SetValue("0");
                chk_rtnall.SetEnabled(false);
                chk_rtnall.valueChecked = false;
                txt_invno.SetValue("");
                $('#HF_invid').val("");
                //  btn_attach.SetEnabled(true);
                /* txt_cusid.SetValue("");
                 ctname.SetValue("");
                 txt_custvat.SetValue("");
                 txt_custadd.SetValue("");
                 txt_custmobile.SetValue("");
                 cmb_smanid.SetValue("");
                 */
            }
            else {
                ch_inv.SetChecked(false);
                //ch_inv.value=false;
                txt_invno.GetInputElement().readOnly = false;
                document.querySelector("#btn_search_inv").disabled = false;
                /*  btn_search_inv.SetEnabled(true);*/
                chk_rtnall.SetEnabled(true);
               // ch_inv.SetEnabled(true);
                //ch_inv.valueChecked = true;
                // btn_attach.SetEnabled(false);
            }

          
            gvs_invdtls.PerformCallback(lbl_invdoc.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_posyacc').val() + "," + lbl_vochrno.GetValue() + ","+1)
            //if (nullToEmpty($('#Hf_payid').val() != "")) {
            //    gv_invpay.PerformCallback()
            //}
        

        }
        else {
            if (nullToEmpty($('#Hf_cusid').val() != "")) {
                cus_validate();
            }
            clear_dtl();
            $('#PDetiles').hide()
            $('#p_invpay').hide()

        }
    }

});


function postRtnInvStock(s, e) {
    let postmodel = {
        // branchid: ddl_branchid.GetValue(),
        sinvid: $('#HF_rtninvid').val(),
        username: null,

    };

    let res = postaction("/VanSalesService/invoice/postRtnInvStock", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postst.value = true;
        gvs_invdtls.PerformCallback(lbl_invdoc.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_posyacc').val())
       
        lbl_postst.SetValue("مرحل مستودعات");
    }
    
}
function postRtnInvAcc(s, e) {
    let postmodel = {
        
        sinvid: $('#HF_rtninvid').val(),
        username: GetToken().username,

    };

    let res = postaction("/VanSalesService/invoice/postrtnInvAcc", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_posyacc.value = true;
        lbl_vochrno.SetValue(res.outputparams.voucher_no);
        gvs_invdtls.PerformCallback(lbl_invdoc.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_posyacc').val() + "," + lbl_vochrno.GetValue())
    
        lbl_postacc.SetValue("مرحل حسابات");
    }
    
}

//AddKeyboardNavigationTo(gv_rtninv);
//function AddKeyboardNavigationTo(grid) {
//    grid.BeginCallback.AddHandler(function (s, e) { gridPerformingCallback = true; });
//    grid.EndCallback.AddHandler(function (s, e) { gridPerformingCallback = false; });
//    ASPxClientUtils.AttachEventToElement(document, "keydown",
//        function (evt) {
//            return OnDocumentKeyDown(evt, grid);
//        });
//}
//function Done(values) {
//    window.opener.UpdateRtn(values);
//    window.close();
//}

//function OnDocumentKeyDown(evt, grid) {
//    if (typeof (event) != "undefined" && event != null)
//        evt = event;



//    if (evt.keyCode == 13) //enter
//    {
//        //alert("")
//        grid.GetRowValues(grid.focusedRowIndex, 'sinvid', Done);

//        // ASPxClientUtils.PreventEvent(evt.htmlEvent);



//    }

//}


//function NeedProcessDocumentKeyDown(evt) {

//    var evtSrc = ASPxClientUtils.GetEventSource(evt);
//    if (evtSrc.tagName == "INPUT")
//        return evtSrc.type != "text" && evtSrc.type != "password";
//    else
//        return evtSrc.tagName != "TEXTAREA";
//}