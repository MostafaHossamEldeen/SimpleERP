 
 
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {

            case "nav":
                if (txt_recno.GetValue() != "تلقائى") {
                    cmb_recbranchid.SetEnabled(false);
                    setfromchartidData();
                    setpaychartidData();
                    if ($("#HF_postacc").val() == "true") {
                        btn_Save.SetEnabled(false);
                        btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' disableclint');
                        btn_delete.SetEnabled(false);
                        btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' disableclint');
                        btn_postacc.SetEnabled(false);
                        btn_postacc.GetMainElement().className = btn_postacc.GetMainElement().className.concat(' disableclint');
                        lbl_postacc.SetValue("مرحل حسابات");
                    }
                    else {
                        btn_Save.SetEnabled(true);
                        btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' enableclint');
                        btn_delete.SetEnabled(true);
                        btn_delete.GetMainElement().className = btn_Save.GetMainElement().className.concat(' enableclint');
                        btn_postacc.SetEnabled(true);
                        btn_postacc.GetMainElement().className = btn_Save.GetMainElement().className.concat(' enableclint');
                        lbl_postacc.SetValue("");
                    }
                }
                break
            case "chart":

                chart_validate()
                break
            default:
        }

    }
});

function validate(s, e)
{
    if (nullToEmpty(txt_recdate.GetValue()) == "")
    {
        txt_recdate.Focus();
        e.txt_recdate.Focus();
        console.clear();
    }
    if (nullToEmpty(txt_fromchartid.GetValue()) == "") {
        sweetinfo("برجاء ادخال حساب المسدد ");
        txt_fromchartid.Focus();
        e.txt_fromchartid.Focus();
        console.clear();
    }
    if (nullToEmpty(txt_paychartid.GetValue()) == "") {
        sweetinfo("برجاء ادخال حساب طريقه الدفع");
        txt_paychartid.Focus();
        e.txt_paychartid.Focus();
        console.clear();
    }
    if (nullToEmpty(txt_recvalue.GetValue()) == "" ||  txt_recvalue.GetValue()==0) {
        sweetinfo("برجاء ادخال القيمه");
        txt_recvalue.Focus();
        e.txt_recvalue.Focus();
        console.clear();
    }
}

function setfromchartidData(s, e) {
    let searchmodel = {
        chartid: $("#HF_fromchartid").val(),
        recno: txt_recno.GetValue()

    }
    let data = getAction("/VanSalesService/rec/fromchartcode", searchmodel)

    if (data.length != 0) {

        //searchmodel["custcode"] = data[0].custcode;
        txt_fromchartname.SetValue(data[0].chartname);
        txt_fromchartid.SetValue(data[0].chartcode);
        


    }
    else {
        txt_fromchartname.SetValue("");
        txt_fromchartid.SetValue("");
        $("#HF_fromchartid").val("");
    }
    
}
function setpaychartidData(s, e) {
    let searchmodel = {
        chartid: $("#HF_paychartid").val(),
        recno: txt_recno.GetValue()

    }
    let data = getAction("/VanSalesService/rec/paychartcode", searchmodel)

    if (data.length != 0) {

        //searchmodel["custcode"] = data[0].custcode;
        txt_chartname.SetValue(data[0].chartname);
        txt_paychartid.SetValue(data[0].chartcode);



    }
    else {
        txt_chartname.SetValue("");
        txt_paychartid.SetValue("");
        $("#HF_paychartid").val("");
    }

}
function chart_validate() {
    if (nullToEmpty(HF_paychartid.value) != "" || nullToEmpty(txt_paychartid.GetValue()) != "") {
        txt_chartname.GetInputElement().readOnly = true;
        
    }
    else {
        txt_chartname.GetInputElement().readOnly = false;
        
    }
    if (nullToEmpty(HF_fromchartid.value) != "" || nullToEmpty(txt_fromchartid.GetValue()) != "") {
        txt_fromchartname.GetInputElement().readOnly = true;

    }
    else {
        txt_fromchartname.GetInputElement().readOnly = false;

    }

}

function setfromchartData(s, e) {
    let searchmodel = {

        chartcode: s.GetValue()


    }
    let data = getAction("/VanSalesService/Vouchers/voucherscode", searchmodel)


    if (data.length != 0) {
      
        searchmodel["chartid"] = data[0].chartid;
        txt_fromchartname.SetValue(data[0].chartname);
       // txt_chartid.SetValue(data[0].chartcode);
        $('#HF_fromchartid').val(data[0].chartid);

        txt_fromchartname.Focus();
        chart_validate()
    }
    else {
        $('#HF_fromchartid').val("");
        txt_fromchartname.SetValue("");
        txt_fromchartid.SetValue("");
        txt_fromchartid.Focus();
        chart_validate()
    }


}

function setpaychartData(s, e) {
    let searchmodel = {

        chartcode: s.GetValue()


    }
    let data = getAction("/VanSalesService/Vouchers/voucherscode", searchmodel)


    if (data.length != 0) {

        searchmodel["chartid"] = data[0].chartid;
        txt_chartname.SetValue(data[0].chartname);
        // txt_chartid.SetValue(data[0].chartcode);
        $('#HF_paychartid').val(data[0].chartid);

        txt_chartname.Focus();
        chart_validate()
    }
    else {
        $('#HF_paychartid').val("");
        txt_chartname.SetValue("");
        txt_paychartid.SetValue("");
        txt_paychartid.Focus();
        chart_validate()
    }


}

function postRecDocAcc() {
    let postmodel = {
        chartidto: $("#HF_paychartid").val(),
        chartidfrom: $("#HF_fromchartid").val(),
        recid: $('#HF_recid').val(),
        user_name: GetToken().userName,


    }
    let res = postaction("/VanSalesService/Rec/PostRecAcc", postmodel);

    if (res.errorid == 0) {

        txt_vochrid.SetValue(res.outputparams.voucher_no);

         
        sweetsuccess(res.errormsg);
        HF_postacc.value = true;
        //gvs_transdtls.PerformCallback( $('#hf_postacc').val() + "," + (res.outputparams["voucher_no"]))
        lbl_postacc.SetValue("مرحل حسابات");
        btn_Save.SetEnabled(false);
        btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' disableclint');
        btn_delete.SetEnabled(false);
        btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' disableclint');
        btn_postacc.SetEnabled(false);
        btn_postacc.GetMainElement().className = btn_postacc.GetMainElement().className.concat(' disableclint');
    }


    else {
        sweetinfo(res.errormsg);
         
    }

}