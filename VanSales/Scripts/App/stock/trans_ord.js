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
    if ( cmb_branchid.GetValue() == null)
    {
        cmb_branchid.Focus();
        e.cmb_branchid.Focus();
        return;
    }
    if (cmb_branchtoid.GetValue() == null)
    {
        cmb_branchtoid.Focus();
        e.cmb_branchtoid.Focus();
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

function print_newtab() {

    var x = document.getElementById("HF_transid").value;
    if (x == "") {

        sweetinfo('لم يتم اختيار اذن للطباعه');
        ASPxClientUtils.PreventEvent(evt.htmlEvent);

    }
}
$('#popupModalsearch').on('hidden.bs.modal', function () {
    if (nullToEmpty(txt_transno.GetValue()) != "تلقائى") {
        //ddl_branchid.GetInputElement().readOnly = true;
        clear_item();
        gvs_transdtls.PerformCallback($('#hf_postst').val() + "," + $('#hf_postacc').val() + "," + txt_vochrid.GetValue())


    }
    else {
        clear_item();
        $('#PDetiles').hide()
    }
});

$('#popupModal').on('hidden.bs.modal', function () {
    //if (nullToEmpty(txt_transno.GetValue()) != "تلقائى") {
    //    $('#HiddenField1').val("true");


    //}
    txt_qty.Focus();
    let searchmodel = { itemid: $('#HF_itemid').val(), branchid: cmb_branchid.GetValue() };

    //lbl_qtyinf.SetValue(data[0]) 
    let data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
    if (data.length != 0) {
        lbl_qtyinf.SetValue(data[0].qty )
    }
    else {
        lbl_qtyinf.SetValue("")
    }

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
        barcode2: s.GetValue(),
        itemid: $('#HF_itemid').val(),
        branchid: cmb_branchid.GetValue()

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
        data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
        if (data.length != 0) {
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
        clear_item();
    }
}

function postTransOrderStock(s, e) {
    let postmodel = {
        //branchid: ddl_branchid.GetValue(),
        transid: $('#HF_transid').val(),
        username: null,

    };

    let res = postaction("/VanSalesService/Stock/PostTransOrderStock", postmodel);
    if (res.errorid != 0) {
        sweetexception(res.errormsg)
        btn_Save.SetEnabled(true);
        btn_delete.SetEnabled(true);
        //btn_addnew.enabled = false;
        btn_save_dtls.SetEnabled(true);
        // btn_new_dtls.enabled = false;
        btn_delete_dtls.SetEnabled(true);
        btn_fastinsert.SetEnabled(true);
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

function postTransOrderAcc(s, e) {
    let postmodel = {
        //branchid: ddl_branchid.GetValue(),
        transid: $('#HF_transid').val(),
        username: GetToken().userName,

    };

    let res = postaction("/VanSalesService/Stock/PostTransOrderAcc", postmodel);
    if (res.errorid != 0) {
        sweetexception(res.errormsg)
        //btn_Save.SetEnabled(true);
        //btn_delete.SetEnabled(true);
        ////btn_addnew.enabled = false;
        //btn_save_dtls.SetEnabled(true);
        //// btn_new_dtls.enabled = false;
        //btn_delete_dtls.SetEnabled(true);
        //btn_fastinsert.SetEnabled(true);
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postacc.value = true;
        gvs_transdtls.PerformCallback($('#hf_postst').val() + "," + $('#hf_postacc').val()+"," + (res.outputparams["voucher_no"]))

        lbl_postacc.SetValue("مرحل حسابات");
    }

}
 