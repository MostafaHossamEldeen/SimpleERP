function validate(s, e) {
    if (txt_qty.GetValue() == "0" || txt_qty.GetValue() == "" || txt_qty.GetValue() == null) {
        sweetinfo("لا يمكن أن تكون الكمية 0 او فارغة");
        txt_qty.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
};

function clear_item() {
    txt_itemid.SetValue("");
    txt_item_name.SetValue("");
    txt_unitname.SetValue("");
    txt_qty.SetValue("1");
    txt_itemnotes.SetValue("");
    $('#HF_itemid').val("");
    $('#HF_unitid').val("");
    $('#HF_factor').val("");
};

function bind(s, e) {
    s.GetRowValues(s.focusedRowIndex, 'reqdtlis;itemid;itemname;unitname;qty;itemnotes;itemcode',
        function (values) {
            $('#HF_reqdtlis').val(nullToIntZero(values[0])),
                $('#HF_itemid').val(nullToIntZero(values[1])),
                txt_item_name.SetValue(nullToEmpty(values[2])),
                txt_unitname.SetValue(nullToEmpty(values[3])),
                txt_qty.SetValue(nullToDecimalZero(values[4])),
                txt_itemnotes.SetValue(nullToEmpty(values[5])),
                txt_itemid.SetValue(nullToEmpty(values[6]))
        })
};

function setItemData(s, e) {
    let searchmodel = {
        itemcode: s.GetValue(),
        barcode1: s.GetValue(),
        barcode2: s.GetValue(),
        itemid: $('#HF_itemid').val()
    }
    let data = getAction("/VanSalesService/items/GetItemRow_request", searchmodel)
    if (data.length != 0) {
        $('#HF_reqdtlis').val("0");
        searchmodel["itemid"] = data[0].itemid;
        txt_item_name.SetValue(data[0].itemname);
        txt_unitname.SetValue(data[0].unitname);
        $('#HF_unitid').val(data[0].unitid);
        $('#HF_factor').val(data[0].factor);
        $('#HF_itemid').val(data[0].itemid);
        txt_qty.SetValue(1);
        txt_qty.Focus();
    }
    else {
        clear_item();
        txt_itemid.Focus();
    }
};

function getgvdtlrow() {
    var index = gv_reqdtls.GetFocusedRowIndex();
    var id = gv_reqdtls.GetRowKey(index);
    document.getElementById("HF_reqdtlis").value = id;
};

$('#popupModalsearchdef').on('hidden.bs.modal', function () {

    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "nav":
                if (nullToEmpty(txt_reqno.GetValue()) != "تلقائى") {
                    gv_reqdtls.PerformCallback((popupres["reqcase"]) + "," + nullToEmpty(popupres["reqaction"]));
                }
                else {
                    clear_item();
                    $('#PDetiles').hide()
                }
                break;
            case "itm":
                txt_qty.Focus();
                break
            default:
        }
    }
});

function transfer() {
    $('#popupModaltransfer').modal("show");
    fill_cmb_frombranchid();
}
function fill_cmb_frombranchid() {
    let res = getAction("/VanSalesService/Pinv/Getbranchtransferfrom");
    if (res.length != 0) {
        $('#cmb_frombranchid').empty();
        for (var i = 0; i < res.length; i++) {
            $('#cmb_frombranchid').append('<option value=' + res[i].branchid + '>' + res[i].branchname + '</option>')
        }
    }
}
function req_trans() {
    let trans = {
        reqid: $('#HF_reqid').val(),
        frombranchid: cmb_frombranchid.GetValue()
    }
    if (cmb_frombranchid.GetValue() == null) {
        sweetexception("برجاء ادخال الفرع المحول منه اولا");
        return;
    }
    let res = postaction("/VanSalesService/Pinv/req_trans", trans);
    if (res.errorid == 0) {
        $('#popupModaltransfer').modal('hide');
        rbl_reqcase.SetSelectedIndex(1);
        rbl_reqcase.GetInputElement().ClientReadOnly = true;
        txt_reqno.GetInputElement().ClientReadOnly = true;
        txt_reqdate.GetInputElement().ClientReadOnly = true;
        cmb_branchid.GetInputElement().ClientReadOnly = true;
        txt_userreq.GetInputElement().ClientReadOnly = true;
        txt_item_name.GetInputElement().ClientReadOnly = true;
        txt_unitname.GetInputElement().ClientReadOnly = true;
        txt_qty.GetInputElement().ClientReadOnly = true;
        txt_itemnotes.GetInputElement().ClientReadOnly = true;

        lbl_reqaction.SetValue(res.outputparams.reqaction);

        btn_Save.SetEnabled(false);
        btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' disableclint');
        btn_delete.SetEnabled(false);
        btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' disableclint');
        btn_save_dtls.SetEnabled(false);
        btn_save_dtls.GetMainElement().className = btn_save_dtls.GetMainElement().className.concat(' disableclint');
        btn_transfer.SetEnabled(false);
        btn_transfer.GetMainElement().className = btn_transfer.GetMainElement().className.concat(' disableclint');
        btn_delete_dtls.SetEnabled(false);
        btn_delete_dtls.GetMainElement().className = btn_delete_dtls.GetMainElement().className.concat(' disableclint');
        btn_new_dtls.SetEnabled(false);
        btn_new_dtls.GetMainElement().className = btn_new_dtls.GetMainElement().className.concat(' disableclint');
        btn_pinv.SetEnabled(false);
        btn_pinv.GetMainElement().className = btn_pinv.GetMainElement().className.concat(' disableclint');

        sweetsuccess(res.errormsg);
    }
    else {
        sweetinfo(res.errormsg);
        $('#cmb_frombranchid').Focus();
        $('#popupModaltransfer').modal('show');
    }
}