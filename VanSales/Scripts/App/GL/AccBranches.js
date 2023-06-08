$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod== "bygrid") {


    switch ($('#popupModalsearchdef').data("name")) {
        case "chart":
            gv_accbranchs.batchEditApi.SetCellValue(gv_accbranchs.focusedRowIndex, "bchartid", popupres["chartid"], null, true);
            gv_accbranchs.batchEditApi.SetCellValue(gv_accbranchs.focusedRowIndex, "chartcode", popupres["chartcode"], null, true);
            gv_accbranchs.batchEditApi.SetCellValue(gv_accbranchs.focusedRowIndex, "chartname", popupres["chartname"], null, true);
            
            //let searchmodel = {
            //    chartid: $('#hf_chartid').val()
            //}
            //let data = getAction("/VanSalesService/Chart/GetChartSingalData", searchmodel)
            //if (data.length != 0) {
            //    searchmodel["chartid"] = data[0].chartid;
            //    $('#hf_chartid').val(data[0].chartid);
            //    txt_chartcode.SetValue(data[0].chartcode);
            //    txt_chartname.SetValue(data[0].chartname);
            //    txt_chartename.SetValue(data[0].chartename);
            //    $('#hf_nodeid').val(data[0].nodeid);
            //    txt_nodecode.SetValue(data[0].chartnamedisplay);
            //    cmb_acctype.SetValue(data[0].acctype);
            //    cmb_accnature.SetValue(data[0].accnature);
            //    cmb_levelno.SetValue(data[0].levelno);
            //    txt_balance.SetValue(data[0].balance);
            //    $('#hf_chartid_tr').val(data[0].chartid);
            //    $('#hf_sys_chartlvl').val(data[0].sys_chartlvl);
            //    trlchart.PerformCallback(data[0].chartid)
            //}
            //else {
            //    $('#hf_chartid').val(0);
            //    txt_chartcode.SetValue("");
            //    txt_chartname.SetValue("");
            //    txt_chartename.SetValue("");
            //    $('#hf_nodeid').val("");
            //    txt_nodecode.SetValue("");
            //    cmb_acctype.SetValue("");
            //    cmb_accnature.SetValue("");
            //    cmb_levelno.SetValue("");
            //    txt_balance.SetValue("");
            //    $('#hf_chartid_tr').val("");
            //    //trlchart.SetFocusedNodeKey(0)
            //}
            //if ($('#hf_sys_chartlvl').val() == cmb_levelno.GetValue()) {
            //    lblfinallevel.SetValue("(حساب نهائي)")
            //}
            //else {
            //    lblfinallevel.SetValue("");
            //}
            //NodeValidate();
            break;
      
        default:
        }
    }
});