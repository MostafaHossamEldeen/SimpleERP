 
$(function () {
    ChangeUrl("",window.loca)
})
function clear_varchrt() {
    txt_chartid.SetValue("");
    txt_chartname.SetValue("");
    txt_ref.SetValue("");
    txt_debit.SetValue(0);
    txt_credit.SetValue(0);
    cmb_ccid.SetText("");
    cmb_ccid.SetValue("");
    txt_descp.SetValue("");
    $('#HF_vchrdtlid').val("");
    $('#HF_chartid').val("");
 
}

function binddata() {
    
    
}
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "nav":
                if (nullToEmpty(txt_vchrno.GetValue()) != "تلقائى") {

                    clear_varchrt();

                    gvs_vchrdtls.PerformCallback($('#hf_postacc').val() + "," + $('#HF_uservchr').val() + "," + lbl_docpath.GetValue())


                }
                else {
                    clear_varchrt();
                    $('#PDetiles').hide()
                }
                break;
            case "chart":
                txt_ref.Focus();
                break

            case "usedvoch":
                if (nullToEmpty(txt_vchrno.GetValue()) != "تلقائى") {

                    clear_varchrt();

                    gvs_vchrdtls.PerformCallback($('#hf_postacc').val() + "," + $('#HF_uservchr').val() + "," + lbl_docpath.GetValue())


                }

                else {
                    $('#HF_uservchr').val("");
                    clear_varchrt();
                    $('#PDetiles').hide()
                }
                break;
            default:
        }
    }

});

function validate(s,e)
{
    if (cmb_vchrtype.GetValue() != 1 && cmb_vchrtype.GetValue() != 0)
    {
        sweetinfo("لا يمكن انشاء قيد سوى افتتاحى او قيد يوميه");
        //ASPxClientUtils.GetEventSource(evt);
        console.clear()
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
       
    }
    if (nullToEmpty( txt_vchrdate.GetValue()) == "" ) {
        txt_vchrdate.Focus();
        console.clear()
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
        
       
    }
    
}

function Gvs_Bind_dtl(s, e) {
    clear_varchrt();
    s.GetRowValues(s.focusedRowIndex, 'chartid;chartcode;chartname;ref;debit;credit;vchrdtlid;ccid;ccname;descp', function (values) {
        HF_chartid

        $("#HF_chartid").val(nullToIntZero(values[0])),
            txt_chartid.SetValue(nullToEmpty(values[1])),
            txt_chartname.SetValue(nullToEmpty(values[2])),
            txt_ref.SetValue(nullToEmpty(values[3])),
             
            txt_debit.SetValue(nullToDecimalZero(values[4])),
            txt_credit.SetValue(nullToDecimalZero(values[5])),
            $("#HF_vchrdtlid").val(nullToIntZero(values[6])),
           
            cmb_ccid.SetValue(nullToIntZero(values[7])),
            cmb_ccid.SetText(nullToEmpty(values[8])),
            txt_descp.SetValue(nullToEmpty(values[9]))

    });

}
function getgvrow() {

    var index = gvs_vchrdtls.GetFocusedRowIndex();


    var id = gvs_vchrdtls.GetRowKey(index);
    HF_vchrdtlid.value = id;
}
function validate_balnce()
{
    //interval = setInterval("calc()", 1);
    if (txt_debit.GetValue() > 0 ) {
        txt_credit.SetValue(0);
    }
    //if (txt_credit.GetValue() > 0 && txt_debit.GetValue() > 0)
    //{
    //    txt_debit.SetValue(0);
    //}
}

function calc()
{
//    if (txt_debit.GetValue() > 0 ) {
//        txt_credit.SetValue(0);
//    }
    if (txt_credit.GetValue() > 0 ) {
       txt_debit.SetValue(0);
    }
}

function setchartData(s, e) {
    let searchmodel = {
       
        chartcode: s.GetValue()
     
         
    }
    let data = getAction("/VanSalesService/Vouchers/voucherscode", searchmodel)


    if (data.length != 0) {
        clear_varchrt()
        searchmodel["chartid"] = data[0].chartid;
        txt_chartname.SetValue(data[0].chartname);
        txt_chartid.SetValue(data[0].chartcode);
        $('#HF_chartid').val(data[0].chartid);
    
        txt_ref.Focus();
    }
    else {
 
        clear_varchrt()
        txt_chartid.Focus();
    }


}
function postAcc(s, e) {
    debugger
    let postmodel = {
        // branchid: ddl_branchid.GetValue(),
        vchrid: $('#HF_vchrid').val(),
        puser: token.userName,//GetToken().username,

    };

    let res = postaction("/VanSalesService/Vouchers/postVouchersAcc", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        hf_postacc.value = true;
        txt_puser.SetValue( postmodel.puser);
        gvs_vchrdtls.PerformCallback($('#hf_postacc').val() + "," + $('#HF_uservchr').val() + "," + lbl_docpath.GetValue())

        lbl_postacc.SetValue("مرحل حسابات");
    }

}

function ChangeUrl(title, url) {
    let str = window.location.href.split("?");
    //if (typeof (history.replaceState) != "undefined") {
    //    var obj = { Title: title, Url: url };
   
    history.replaceState(str[1], "", str[0]);
   
    //} else {
    //    alert("Browser does not support HTML5.");
    //}
}  


 