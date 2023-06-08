$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    switch ($('#popupModalsearchdef').data("name")) {
        case "items":
            txt_qty.SetValue(1);
            txt_qty.Focus();
            break;
        default:
    }
});
function setItemData(s, e) {
    let searchmodel = {
        itemcode: s.GetValue(),
        barcode1: s.GetValue(),
        barcode2: s.GetValue(),
        itemid: $('#HF_itemid').val()
    }
    let data = getAction("/VanSalesService/items/GetItemSingalData_printbarcode", searchmodel)
    if (data.length != 0) {
        searchmodel["itemid"] = data[0].itemid;
        txt_itemname.SetValue(data[0].itemname);
        txt_unitname.SetValue(data[0].unitname);
        txt_barcode.SetValue(data[0].barcode1);
        $('#HF_unitid').val(data[0].unitid);
        $('#HF_itemunitid').val(data[0].itemunitid);
        txt_qty.SetValue(1);
        txt_qty.Focus();
    }
    else {
        txt_itemcode.Focus();
    }
};