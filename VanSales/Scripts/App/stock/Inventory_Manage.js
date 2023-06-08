function calc(s, e) {
    let pqty = e.rowValues[s.GetColumnByField("pqty").index].value;
    let tqty = e.rowValues[s.GetColumnByField("tqty").index].value;
    let cost = e.rowValues[s.GetColumnByField("cost").index].value;
    let diffcost = e.rowValues[s.GetColumnByField("diffcost").index].value;
    let diffqty = pqty - tqty;
    diffcost = cost * diffqty;
    s.batchEditApi.SetCellValue(e.visibleIndex, "diffqty", diffqty);
    s.batchEditApi.SetCellValue(e.visibleIndex, "diffcost", diffcost);
};

function PostInventory(s, e) {
    let postmodel = { inventid: $('#HF_inventid').val() };

    let res = postaction("/VanSalesService/Stock/PostInventory", postmodel);

    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        $('#hf_postst').val(true)
        btn_save.SetEnabled(false);
        btn_save.GetMainElement().className = btn_save.GetMainElement().className.concat(' disableclint');
        btn_delete.SetEnabled(false);
        btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' disableclint');
        btn_poststock.SetEnabled(false);
        btn_poststock.GetMainElement().className = btn_poststock.GetMainElement().className.concat(' disableclint');
        lbl_postst.SetValue("مرحل مستودع")
        gv_inventdlts.allowEdit = false;
    }
};

function batchEditStart(s, e) {
    if ($('#hf_postst').val() == true) {
        e.cancel = true;
    }
}

$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    switch ($('#popupModalsearchdef').data("name")) {
        case "inventory":
            if (nullToEmpty(txt_inventno.GetValue()) != "تلقائى") {
                gv_inventdlts.PerformCallback(popupres["postst"]);
            }
            else {
                clear_dtl();
                $('#Panel2').hide();
            }
            break;
        default:
    }
});