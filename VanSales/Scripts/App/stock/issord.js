/// <reference path="../base/helperjs.js" />

function bind(s, e) {

    s.GetRowValues(s.focusedRowIndex, 'itemcode;itemname;unitname;qty;unitid;transdtlid;itemid;factor;cost;value', function (values) {
        // alert(values[5])

        txt_itemid.SetValue(nullToEmpty(values[0])),
            txt_item_name.SetValue(nullToEmpty(values[1])),
            txt_unitname.SetValue(nullToEmpty(values[2])),
            txt_qty.SetValue(nullToDecimalZero(values[3])),
            document.getElementById("HF_unitid").value = nullToIntZero(values[4]),
            document.getElementById("HF_transdtlid").value = nullToIntZero(values[5]),
            document.getElementById("HF_itemid").value = nullToIntZero(values[6]),
            document.getElementById("HF_factor").value = nullToIntZero(values[7]),
            //$('#HF_factor').val(nullToIntZero(values[7])),
            $('#HF_cost').val(nullToIntZero(values[8])),
            $('#HF_value').val(nullToIntZero(values[9]))

        //   HF_itemunitid.SetValue(values[4]),

        //HF_itemid.SetValue(values[6])


    });

}
function validate(s, e) {


    if (txt_trandate.GetValue() == "" || txt_trandate.GetValue() == null) {
        txt_trandate.Focus();
        e.txt_trandate.Focus();
        return;
    }
    if (ddl_branchid.GetValue() == "" || ddl_branchid.GetValue() == null) {
        ddl_branchid.Focus();
        e.ddl_branchid.Focus();
        return;
    }

}
function clear_item() {
    txt_itemid.SetValue("");
    txt_item_name.SetValue("");
    txt_qty.SetValue(1);
    txt_unitname.SetValue("");
    $('#HF_transdtlid').val("");
    $('#HF_unitid').val("");
    $('#HF_itemid').val("");
    $('#HF_cost').val("");

    $('#HF_factor').val("");
    lbl_qtyinf.SetValue("");
}


$(function () {



})
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "nav":
                if (nullToEmpty(txt_transno.GetValue()) != "تلقائى") {
                    ddl_branchid.GetInputElement().readOnly = true;
                    clear_item();
                    if ($('#hf_postst').val() == false) {
                        btn_Save.SetEnabled(true);
                        btn_delete.SetEnabled(true);
                        //btn_addnew.enabled = false;
                        btn_save_dtls.SetEnabled(true);
                        // btn_new_dtls.enabled = false;
                        btn_delete_dtls.SetEnabled(true);
                        btn_fastinsert.SetEnabled(true);
                    }
                    gvs_transdtls.PerformCallback($('#hf_postst').val() + "," + $('#hf_postacc').val() + "," + txt_vochrid.GetValue())


                }
                else {
                    clear_item();
                    $('#PDetiles').hide()
                }
                break;
            // case "itm":
            //     txt_qty.Focus();
            //    let searchmodel = { itemid: $('#HF_itemid').val(), branchid: ddl_branchid.GetValue() };

            //lbl_qtyinf.SetValue(data[0]) 
            //   let data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
            // if (data.length != 0) {
            //      lbl_qtyinf.SetValue(data[0].qty)
            //  }

            //    break
            default:
        }
    }

});



$('#popupModal').on('hidden.bs.modal', function () {

    //if (nullToEmpty(txt_transno.GetValue()) != "تلقائى") {
    //    $('#HiddenField1').val("true");

    //}
    txt_qty.Focus();

    let searchmodel = { itemid: $('#HF_itemid').val(), branchid: ddl_branchid.GetValue() };

    //lbl_qtyinf.SetValue(data[0]) 
    let data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
    if (data.length != 0) {
        lbl_qtyinf.SetValue(data[0].qty)
    }
    else {
        lbl_qtyinf.SetValue("")
    }

    //}

});
function getgvrow() {

    var index = gvs_transdtls.GetFocusedRowIndex();


    var id = gvs_transdtls.GetRowKey(index);
    HF_transdtlid.value = id;
}


function setItemData(s, e) {

    let searchmodel = {
        itemcode: s.GetValue(),
        barcode1: s.GetValue(),
        barcode2: s.GetValue()
        , itemid: $('#HF_itemid').val(),
        branchid: ddl_branchid.GetValue()
    }
    let data = getAction("/VanSalesService/items/GetItemSingalData", searchmodel)


    if (data.length != 0) {
        $('#HF_transdtlid').val("");
        searchmodel["itemid"] = data[0].itemid;
        txt_item_name.SetValue(data[0].itemname);
        txt_unitname.SetValue(data[0].unitname);
        $('#HF_unitid').val(data[0].unitid);
        $('#HF_factor').val(data[0].factor);
        $('#HF_cost').val(data[0].cprice);
        $('#HF_itemid').val(data[0].itemid);
        //lbl_qtyinf.SetValue(data[0]) 
        data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
        if (data.length != 0) {
            // lbl_qtyinf.SetValue(" الرصيد بالمخزن" + data[0].qty + "حبه ")
            lbl_qtyinf.SetValue(data[0].qty)
        }
        else {
            lbl_qtyinf.SetValue("")
        }
        txt_qty.Focus();
    }
    else {
        //txt_item_name.SetValue("");
        //txt_unitname.SetValue("");
        //$('#HF_itemid').val("");
        //$('#HF_unitid').val("");
        //$('#HF_factor').val("");
        //$('#HF_cost').val("");
        //lbl_qtyinf.SetValue("");
        clear_item();
    }


}
function print_newtab() {

    var x = document.getElementById("HF_transid").value;
    if (x == "") {
        
        sweetinfo('لم يتم اختيار اذن للطباعه');
        ASPxClientUtils.PreventEvent(evt.htmlEvent);

    }
    }
//function postAddOrderStock(s, e) {
//    let postmodel = {
//        // branchid: ddl_branchid.GetValue(),
//        transid: $('#HF_transid').val(),
//        username: null,

//    };

//    let res = postaction("/VanSalesService/Stock/PostAddOrderStock", postmodel);
//    if (res.errorid != 0) {

//        sweetexception(res.errormsg)
//    }
//    else {
//        sweetsuccess(res.errormsg)
//        btn_Save.SetEnabled(false);
//        btn_delete.SetEnabled(false);
//        //btn_addnew.enabled = false;
//        btn_save_dtls.SetEnabled(false);
//        // btn_new_dtls.enabled = false;
//        btn_delete_dtls.SetEnabled(false);
//        btn_fastinsert.SetEnabled(false);
//        lbl_postst.SetValue("مرحل مستودعات");
//    }
//    // console.log(res)
//}


function postIssOrderStock(s, e) {
    let postmodel = {
        //  branchid: ddl_branchid.GetValue(),
        transid: $('#HF_transid').val(),
        username: null,

    };

    let res = postaction("/VanSalesService/Stock/PostIssOrderStock", postmodel);
    if (res.errorid != 0) {
        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postst.value = true;
        gvs_transdtls.PerformCallback($('#hf_postst').val() + "," + $('#hf_postacc').val())
        //btn_Save.SetEnabled(false);
        //btn_delete.SetEnabled(false);
        ////btn_addnew.enabled = false;
        //btn_save_dtls.SetEnabled(false);
        //// btn_new_dtls.enabled = false;
        //btn_delete_dtls.SetEnabled(false);
        //btn_fastinsert.SetEnabled(false);
        lbl_postst.SetValue("مرحل مستودعات");
    }
    // console.log(res)
}
function add_charts() {

    $('#popupModaladdchart').modal("show");



    $('#txt_chartfrom').val(null);
    $('#txt_chartto').val(null);
    $("#hf_chartidfrom").val(null);
    $("#hf_chartidto").val(null);
    $('#txt_chartto').focus();

}
function postIssOrderAcc() {
    if ($("#hf_chartidto").val() == "" || $("#hf_chartidfrom").val() == "") {
        sweetinfo("برجاء اختيار الحسبات اولا");
        return
    }
    let postmodel = {
        chartidto: $("#hf_chartidto").val(),
        chartidfrom: $("#hf_chartidfrom").val(),
        transid: $('#HF_transid').val(),
        user_name: GetToken().userName,


    }
    let res = postaction("/VanSalesService/Stock/PostIssOrderAcc", postmodel);

    if (res.errorid == 0) {

        txt_vochrid.SetValue(res.outputparams.voucher_no);

        $('#popupModaladdchart').modal('hide');
        sweetsuccess(res.errormsg);
        hf_postacc.value = true;
        gvs_transdtls.PerformCallback($('#hf_postst').val() + "," + $('#hf_postacc').val() + "," + (res.outputparams["voucher_no"]))
        lbl_postacc.SetValue("مرحل حسابات");


    }


    else {
        sweetinfo(res.errormsg);
        $('#txt_chartfrom').Focus();
        $('#popupModaladdchart').modal('show');


    }

}
//function isFloatNumber(e, t) {
//    var n;
//    var r;
//    if (navigator.appName == "Microsoft Internet Explorer" || navigator.appName == "Netscape") {
//        n = t.keyCode;
//        r = 1;
//        if (navigator.appName == "Netscape") {
//            n = t.charCode;
//            r = 0
//        }
//    } else {
//        n = t.charCode;
//        r = 0
//    }
//    if (r == 1) {
//        if (!(n >= 48 && n <= 57 || n == 46)) {
//            t.returnValue = false
//        }
//    } else {
//        if (!(n >= 48 && n <= 57 || n == 0 || n == 46)) {

//            t.preventDefault()
//        }
//    }

//}