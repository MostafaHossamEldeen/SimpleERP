$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {

            case "nav":
                if (txt_pdno.GetValue() != "تلقائى") {
                    cmb_pdbranchid.SetEnabled(false);
                
                    setpaidchartidData();
                    setpaychartidData();
                    if ($("#HF_postacc").val() == "true")
                        {    rbl_vattype.SetEnabled(false);
                        btn_Save.SetEnabled(false);
                        btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' disableclint');
                        
                        btn_delete.SetEnabled(false);
                        btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' disableclint');
                        btn_postacc.SetEnabled(false);
                        btn_postacc.GetMainElement().className = btn_postacc.GetMainElement().className.concat(' disableclint');
                        lbl_postacc.SetValue("مرحل حسابات");
                    }
                    else
                    {
                        btn_Save.SetEnabled(true);
                        btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' enableclint');
                       // btn_Save.classlist.remove("disableclint");
                      //  $("btn_Save").removeClass("disableclint")
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

function validate(s, e) {
    console.clear();
    if (nullToEmpty(txt_pddate.GetValue()) == "") {
        txt_pddate.Focus();
        e.txt_pddate.Focus();
        console.clear();
    }
    if (nullToEmpty(txt_paidchartid.GetValue()) == "") {
        sweetinfo("برجاء ادخال حساب المدفوع له ");
        txt_paidchartid.Focus();
        e.txt_paidchartid.Focus();
        console.clear();
    }
    if (nullToEmpty(txt_paychartid.GetValue()) == "") {
        sweetinfo("برجاء ادخال حساب طريقه الدفع");
        txt_paychartid.Focus();
        e.txt_paychartid.Focus();
        console.clear();
    }
    if ((nullToEmpty(txt_pdbvat.GetValue()) == "" || nullToDecimalZero(txt_pdbvat.GetValue()) == 0) || (nullToEmpty(txt_pdavat.GetValue()) == "" || nullToDecimalZero(txt_pdavat.GetValue()) == 0))
    {
        sweetinfo("برجاء ادخال السعر اولا");
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent)
      
    }
}

function setpaidchartidData(s, e) {
    let searchmodel = {
        chartid: $("#HF_paidchartid").val(),
        recno: txt_pdno.GetValue()

    }
    let data = getAction("/VanSalesService/pay/paidchartcode", searchmodel)

    if (data.length != 0) {

        //searchmodel["custcode"] = data[0].custcode;
        txt_paidchartname.SetValue(data[0].chartname);
        txt_paidchartid.SetValue(data[0].chartcode);



    }
    else {
        txt_paidchartname.SetValue("");
        txt_paidchartid.SetValue("");
        $("#HF_paidchartid").val("");
    }

}
function setpaychartidData(s, e) {
    let searchmodel = {
        chartid: $("#HF_paychartid").val(),
        recno: txt_pdno.GetValue()

    }
    let data = getAction("/VanSalesService/pay/paydocchartcode", searchmodel)

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
    if (nullToEmpty(HF_paidchartid.value) != "" || nullToEmpty(txt_paidchartid.GetValue()) != "") {
        txt_paidchartname.GetInputElement().readOnly = true;

    }
    else {
        txt_paidchartname.GetInputElement().readOnly = false;

    }

}

function setpaidchartData(s, e) {
    let searchmodel = {

        chartcode: s.GetValue()


    }
    let data = getAction("/VanSalesService/Vouchers/voucherscode", searchmodel)


    if (data.length != 0) {

        searchmodel["chartid"] = data[0].chartid;
        txt_paidchartname.SetValue(data[0].chartname);
        // txt_chartid.SetValue(data[0].chartcode);
        $('#HF_paidchartid').val(data[0].chartid);

        txt_paidchartname.Focus();
        chart_validate()
    }
    else {
        $('#HF_paidchartid').val("");
        txt_paidchartname.SetValue("");
        txt_paidchartid.SetValue("");
        txt_paidchartid.Focus();
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
function vattype()
{
   // token = GetToken().vat;
    if (rbl_vattype.GetValue() == 1) {
       // txt_vatvalue.SetValue(GetToken().vat);
        //txt_vatvalue.SetValue(0);
            txt_pdbvat.SetValue(0);
            txt_pdavat.SetValue(0);
        
        txt_pdbvat.GetInputElement().readOnly = true;
        txt_pdavat.GetInputElement().readOnly = false;
    }
    else if (rbl_vattype.GetValue() == 2) {
       // txt_vatvalue.SetValue(GetToken().vat);
        //txt_vatvalue.SetValue(0);
        
            txt_pdbvat.SetValue(0);
            txt_pdavat.SetValue(0);
        
        txt_pdavat.GetInputElement().readOnly = true;
        txt_pdbvat.GetInputElement().readOnly = false;
    }
    else if (rbl_vattype.GetValue() == 3) {
        txt_vatvalue.SetValue(0);
        txt_pdbvat.SetValue(0);
        txt_pdavat.SetValue(0);

        txt_pdbvat.GetInputElement().readOnly = false;
        txt_pdavat.GetInputElement().readOnly = true;
        txt_vatvalue.GetInputElement().readOnly = false;
    }
}

function calc()
{
    token = GetToken();
    if (rbl_vattype.GetValue() == 1) {
        
        // الصافى بدون ضريبه =الصافى شامل - الضريبه
        txt_vatvalue.SetValue(((parseFloat(txt_pdavat.GetValue()).toFixed(2) * parseFloat(token.vat).toFixed(2)).toFixed(2) / (parseInt(100) + parseFloat(token.vat)).toFixed(2)).toFixed(2));
        txt_pdbvat.SetValue((parseFloat(txt_pdavat.GetValue()) - parseFloat(txt_vatvalue.GetValue())).toFixed(2));
        txt_pdbvat.GetInputElement().readOnly = true;
        if (txt_pdavat.GetValue() == null)
        {
            txt_pdavat.SetValue(0);
            txt_pdbvat.SetValue(0);
            txt_vatvalue.SetValue(0);
        }
    }
    if (rbl_vattype.GetValue() == 2) {
        
        txt_vatvalue.SetValue((parseFloat(txt_pdbvat.GetValue()).toFixed(2) * (parseFloat(token.vat).toFixed(2) / parseInt(100)).toFixed(2)).toFixed(2))
        txt_pdavat.SetValue((parseFloat(txt_pdbvat.GetValue()) + parseFloat(txt_vatvalue.GetValue())).toFixed(2))
        txt_pdavat.GetInputElement().readOnly = true;
        if (txt_pdbvat.GetValue() == null)
        {
            txt_pdbvat.SetValue(0);
            txt_pdavat.SetValue(0);
            txt_vatvalue.SetValue(0);
        }
    }
     if (rbl_vattype.GetValue() == 3)
    {
         txt_vatvalue.SetValue(0);
         if (txt_pdbvat.GetValue() == null)
         {
             txt_pdbvat.SetValue(0);
             txt_pdavat.SetValue(0);
         }
         else if (nullToDecimalZero(txt_pdbvat.GetValue()) != null) {
            txt_pdavat.SetValue(txt_pdbvat.GetValue())
         }
         else if (nullToDecimalZero(txt_pdavat.GetValue()) != null)
        {
            txt_pdbvat.SetValue(txt_pdavat.GetValue())
        }

    }
}
function postPayDocAcc() {
    let postmodel = {
        chartidto: $("#HF_paychartid").val(),
        chartidfrom: $("#HF_paidchartid").val(),
        pdid: $('#HF_pdid').val(),
        user_name: GetToken().userName,


    }
    let res = postaction("/VanSalesService/Pay/PostPayAcc", postmodel);

    if (res.errorid == 0) {

        txt_vchrid.SetValue(res.outputparams.voucher_no);


        sweetsuccess(res.errormsg);
        HF_postacc.value = true;
        //gvs_transdtls.PerformCallback( $('#hf_postacc').val() + "," + (res.outputparams["voucher_no"]))
        lbl_postacc.SetValue("مرحل حسابات");
        btn_Save.SetEnabled(false);
        btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' disableclint');
     
        btn_delete.SetEnabled(false);
        btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' disableclint');
        btn_postacc.SetEnabled (false);
        btn_postacc.GetMainElement().className = btn_postacc.GetMainElement().className.concat(' disableclint');

    }


    else {
        sweetinfo(res.errormsg);

    }

}