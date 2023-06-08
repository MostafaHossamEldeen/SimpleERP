function validate(s, e) {


    if (nullToEmpty(txt_custname.GetValue()) == "") {
        sweetinfo("برجاء ادخال اسم العميل");
        txt_custname.Focus();
        e.txt_custname.Focus();
        return;
    }
    if (nullToEmpty(txt_sodate.GetValue()) == "") {
        txt_sodate.Focus();
        e.txt_sodate.Focus();
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

}
function validateInv(s, e) {


    if (nullToEmpty($('#HF_soid').val()) == "") {
        sweetinfo("برجاء أختيار عرض الاسعار اولا");
        ASPxClientUtils.PreventEvent(e.htmlEvent);


    }

}

function clear_dtl() {

    txt_itemcode.SetValue(""),
        txtitem_name.SetValue(""),
        txt_unit.SetValue(""),
        txt_qty.SetValue(1),
        //$('#hf_qty').val(""),
        $('#HF_unitid').val(""),
        $('#HF_sodtlid').val(""),
        $('#HF_itemid').val(""),
        $('#HF_factor').val(""),
       // $('#HF_cost').val(""),
        txt_value.SetValue(0),
        txt_discp.SetValue(0),
        txt_discvalue.SetValue(0),
        txt_netvalue.SetValue(0),
        txt_itemvatvalue.SetValue(0),
        $('#Hf_vat').val(""),
        txt_itemnotes.SetValue(""),
        txt_price.SetValue(0)
}
function getgvrow() {

    var index = gvs_orderdtls.GetFocusedRowIndex();


    var id = gvs_orderdtls.GetRowKey(index);
    HF_sodtlid.value = id;
}
function Gvs_Bind_dtl(s, e) {

    clear_dtl();
    s.GetRowValues(s.focusedRowIndex, 'itemcode;itemname;unitname;qty;unitid;sodtlid;itemid;factor;svalue;discp;discv;snet;vatvalue;itemnotes;sprice', function (values) {


        txt_itemcode.SetValue(nullToEmpty(values[0])),
            txtitem_name.SetValue(nullToEmpty(values[1])),
            txt_unit.SetValue(nullToEmpty(values[2])),
            txt_qty.SetValue(nullToDecimalZero(values[3])),
            //document.getElementById("hf_qty").value = nullToDecimalZero(values[3]),
            $("#HF_unitid").val(nullToIntZero(values[4])),
            $("#HF_sodtlid").val(nullToIntZero(values[5])),
            $("#HF_itemid").val(nullToIntZero(values[6])),
            $("#HF_factor").val(nullToDecimalZero(values[7])),
            // $('#HF_cost').val(nullToDecimalZero(values[8])),
            txt_value.SetValue(nullToDecimalZero(values[8])),
            txt_discp.SetValue(nullToDecimalZero(values[9])),
            $('#hf_disc').val(nullToDecimalZero(values[10])),
            txt_discvalue.SetValue(nullToDecimalZero(values[10])),
            txt_netvalue.SetValue(nullToDecimalZero(values[11])),
            txt_itemvatvalue.SetValue(nullToDecimalZero(values[12])),
           // $('#Hf_vat').val(nullToDecimalZero(values[12])),
            txt_itemnotes.SetValue(nullToEmpty(values[13])),
            txt_price.SetValue(nullToDecimalZero(values[14]))



    });

}
function cus_validate() {
    if (nullToEmpty(Hf_cusid.value) != "" || nullToEmpty(txt_custid.GetValue()) != "") {
        txt_custname.GetInputElement().readOnly = true;
        //txt_custadd.GetInputElement().readOnly = true;
        //txt_custvat.GetInputElement().readOnly = true;
        //txt_custmobile.GetInputElement().readOnly = true;
        // cmb_smanid.GetInputElement().readOnly = true;
        //cmb_smanid.SetEnabled(false);
    }
    else {
        txt_custname.GetInputElement().readOnly = false;
        // txt_custadd.GetInputElement().readOnly = false;
        // txt_custvat.GetInputElement().readOnly = false;
        //   txt_custmobile.GetInputElement().readOnly = false;
        // cmb_smanid.GetInputElement().readOnly = false;
        // cmb_smanid.SetEnabled(true);
    }

}
function setCustData(s, e) {
    
    let searchmodel = {
        custcode: s.GetValue()

    }
    let data = getAction("/VanSalesService/inv/GetcustSingalData", searchmodel)

    if (data.length != 0) {

        searchmodel["custcode"] = data[0].custcode;
        txt_custname.SetValue(data[0].custname);
        // txt_custname.SetValue(data[0].custadd);
        // txt_custvat.SetValue(data[0].custvat);
        // txt_custmobile.SetValue(data[0].custmob);
        // cmb_smanid.SetValue(data[0].smanid);
        $('#Hf_cusid').val(data[0].custid);


    }
    else {
        txt_custid.SetValue("");
        txt_custname.SetValue("");
        // txt_custadd.SetValue("");
        // txt_custvat.SetValue("");
        //  txt_custmobile.SetValue("");
        // cmb_smanid.SetValue("");
        $('#Hf_cusid').val("");
    }
    cus_validate();
}
function add_cus() {

        $('#popupModaladdcust').modal("show");
    fill_cmb_cusgroup();

    $('#popupModaladdcust').on('shown.bs.modal', function () {
      

        $('#txt_cusname').val(null);
        $('#txt_cusadd').val(null);
        $('#txt_cusmob').val(null);
        $('#txt_cusvat').val(null);

        $('#txt_cusname').focus()
        $('#txt_cusname').Focus()
    });
    return;
}

function QuoteCustData() {
    
    let cust = {
        custname: txt_cusname.value,
        custadd: txt_cusadd.value,
        custmob: txt_cusmob.value,
        custvat: txt_cusvat.value,
        sgrpid: $('#cmb_cusgroup').val(),
    }
    if ($('#cmb_cusgroup').val() == null) {
        sweetexception("برجاء ادخال مجموعه العملاء اولا");
        return;
    }
    let res = postaction("/VanSalesService/invoice/addcust", cust);

    if (res.errorid == 0) {

        txt_custid.SetValue(res.outputparams.custcode);

        txt_custname.SetValue(txt_cusname.value);
        //txt_custadd.SetValue(txt_cusadd.value);
        //txt_custvat.SetValue(txt_cusvat.value);
        //txt_custmobile.SetValue(txt_cusmob.value);
        cus_validate();

        $('#popupModaladdcust').modal('hide');

    }


    else {
        sweetinfo(res.errormsg);
        $('#txt_cusname').focus();
        $('#popupModaladdcust').modal('show');


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
        $('#HF_sodtlid').val("")
        searchmodel["itemid"] = data[0].itemid;
        txtitem_name.SetValue(data[0].itemname);
        txt_unit.SetValue(data[0].unitname);
        txt_price.SetValue(data[0].fprice);
        $('#HF_unitid').val(data[0].unitid);
        $('#HF_factor').val(data[0].factor);
        // $('#HF_cost').val(data[0].cprice);
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
        clear_dtl()
        txt_itemcode.Focus();
    }
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
///////////calc
function multiply() {
    var text1 = txt_qty.GetValue();
    var text2 = txt_price.GetValue();

    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;

    txt_value.SetValue((parseFloat(t1 * 1).toFixed(2) * parseFloat(t2 * 1).toFixed(2)).toFixed(2));


    Subtract();
    // calac_vat();
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
        sweetinfo(" الخصم اكبر من 100%");
    //alert(" الخصم اكبر من 100%");
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
        if (txt_itemvatvalue.GetValue() == 0 || txt_itemvatvalue.GetValue() == null) {

            if (nullToEmpty( document.getElementById("Hf_vat").value) != "" ) {
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
            //txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
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
    else if ($("#HF_vattype").val() == 2) {
        if (txt_itemvatvalue.GetValue() == 0 || txt_itemvatvalue.GetValue() == null) {

            if (nullToEmpty(document.getElementById("Hf_vat").value != "") ) {
                var text1 = txt_netvalue.GetValue();
                var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;

                txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));

            }
            else {

                txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
                if ((txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) ) {
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
            var text2 = document.getElementById("Hf_vat").value/100;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;

            txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2)).toFixed(2));
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
}
function calac_disc() {



    var text1 = txt_discvalue.GetValue();
    var text2 = txt_value.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    if (txt_discvalue.GetValue() == null) {

        txt_discvalue.SetValue(0);
    }
    else {
        txt_discp.SetValue(0);
    }
    txt_netvalue.SetValue((parseFloat(t2 * 1).toFixed(2) - parseFloat(t1 * 1).toFixed(2)).toFixed(2));
    //txt_discp.SetValue((parseFloat(t1).toFixed(2) / parseFloat(t2).toFixed(2))*100);
    calac_vat();
}

$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        if (nullToEmpty(txt_sono.GetValue()) != "تلقائى") {

            if (nullToEmpty(txt_custid.GetValue() != "")) {
                cus_validate();
            }
            if (nullToEmpty($('#HF_itemid').val() != "")) {
                multiply();
            }

            gvs_orderdtls.PerformCallback()


        }
        else {
            if (nullToEmpty($('#Hf_cusid').val() != "")) {
                cus_validate();
            }
            clear_dtl();
            $('#PDetiles').hide()
        }
    }

});
function fill_cmb_cusgroup() {
    let res = getAction("/VanSalesService/inv/GetCustgroupData");
    if (res.length != 0) {
        $('#cmb_cusgroup').empty();
        for (var i = 0; i < res.length; i++) {
            $('#cmb_cusgroup').append('<option value=' + res[i].sgrpid + '>' + res[i].sgrpname + '</option>')
        }
    }
}