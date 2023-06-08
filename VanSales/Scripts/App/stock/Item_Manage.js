$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        gvitemunit.PerformCallback($('#hf_itemid.Value').val());
        gv_itemwh.PerformCallback();
        tkb_branchid.PerformCallback();
        img_itempic.SetImageUrl($('#hf_imgpath').val() == "" ? null : '../' + $('#hf_imgpath').val().replace('~/', ''));
    }
});
function getPathFromUrl(url) {
    return url.split("?")[0];
}
function cleardata() {
    getPathFromUrl('http://localhost:44317/Stock/Item_Manage.aspx?itemid')
    if (GetToken().autoitem =="False") {
        txt_itemcode.SetValue(null);
    }
    else {
        txt_itemcode.SetValue('تلقائي');
    }
   
    txt_itemcode2.SetValue(null);
    txt_itemcode3.SetValue(null);
    txt_itembarcode.SetValue(null);
    txt_itembarcode2.SetValue(null);
    txt_itemname.SetValue(null);
    txt_itemename.SetValue(null);
    txt_itemdesc.SetValue(null);
    cmb_unitid.SetSelectedIndex(0);
    cmb_groupid.SetSelectedIndex(0);
    cmb_itemtypeid.SetSelectedIndex(0);
    cmb_suppid.SetSelectedIndex(-1);
    cmb_itemstop.SetSelectedIndex(0);
    txt_minqty.SetValue(null);
    txt_maxqty.SetValue(null);
    txt_pprice.SetValue(null);
    txt_cprice.SetValue(null);
    txt_sprice.SetValue(null);
    txt_vat.SetValue($('#hf_sysvatvalue').val());
    txt_vprice.SetValue(null);
    txt_fprice.SetValue(null);
    img_itempic.SetImageUrl(null);
    img_itempic.SetSize(150, 150);
    $('#hf_itemid').val("0");
    $('#hf_imgpath').val("");
    txt_itemfield1.SetValue(null);
    txt_itemfield2.SetValue(null);
    cmb_itemcat1.SetSelectedIndex(-1);
    cmb_itemcat2.SetSelectedIndex(-1);
    $('#RequiredFieldValidatortxt_itemname').hide();
    $('#RequiredFieldValidatorcmb_unitid').hide();
    $('#RequiredFieldValidatorcmb_groupid').hide();
    $('#RequiredFieldValidatorcmb_itemtypeid').hide();
    $('#RequiredFieldValidatorcmb_itemstop').hide();
    $('#RequiredFieldValidatortxt_pprice').hide();
    $('#RequiredFieldValidatortxt_sprice').hide();
    $('#RequiredFieldValidatortxt_vat').hide();
    $('#RequiredFieldValidatortxt_vprice').hide();
    $('#RequiredFieldValidatortxt_fprice').hide();
    $('#ValidationSummary').hide();
    gvitemunit.PerformCallback($('#hf_itemid.Value').val());
    gv_itemwh.PerformCallback();
    tkb_branchid.PerformCallback();
};

 function refreshpage() {
        document.location.href = "Item_Manage.aspx?itemid=" + $('#hf_itemid').val();
};

function mastercalcVat(s, e) {
    let vattype = GetToken();
    if (vattype.vattype == "1") {
        const sum = parseFloat(txt_sprice.GetValue()) * parseFloat(txt_vat.GetValue())
        txt_vprice.SetValue(parseFloat((parseFloat(sum) / 100) + parseFloat(txt_sprice.GetValue())).toFixed(2))
        //if (isNaN(txt_vprice.GetValue())) {
        //    txt_vprice.SetValue(0);
        //}
        txt_fprice.SetValue(parseFloat(txt_vprice.GetValue()).toFixed(2))
    }
    else {
        const sum = parseFloat(txt_sprice.GetValue()) * parseFloat(txt_vat.GetValue())
        txt_vprice.SetValue(parseFloat((parseFloat(sum) / 100) + parseFloat(txt_sprice.GetValue())).toFixed(2))
        //if (isNaN(txt_vprice.GetValue())) {
        //    txt_vprice.SetValue(0);
        //}
        txt_fprice.SetValue(parseFloat(txt_sprice.GetValue()).toFixed(2))
    }
};

function factsprice(s, e) {
    sprice.SetValue(parseFloat(txt_sprice.GetValue()));
    pprice.SetValue(parseFloat(txt_pprice.GetValue()) * parseFloat(fact.GetValue()));
    cprice.SetValue(parseFloat(txt_cprice.GetValue()) * parseFloat(fact.GetValue()));
    let factsprice = (parseFloat(sprice.GetValue()) * parseFloat(fact.GetValue())).toFixed(2)
    sprice.SetValue(parseFloat(factsprice))
    if (isNaN(sprice.GetValue()) || sprice.GetValue() == 0 || isNaN(pprice.GetValue()) || pprice.GetValue() == 0 || isNaN(cprice.GetValue()) || cprice.GetValue() == 0) {
        sprice.SetValue(parseFloat(txt_sprice.GetValue()));
        cprice.SetValue(parseFloat(txt_cprice.GetValue()));
        pprice.SetValue(parseFloat(txt_pprice.GetValue()));


    }
};

function calcVat(s, e) {

    let vattype = GetToken();
    if (vattype.vattype == "1") {
        const sum = parseFloat(sprice.GetValue()) * parseFloat(vatvalue.GetValue())
        vatprice.SetValue(parseFloat((parseFloat(sum) / 100) + parseFloat(sprice.GetValue())).toFixed(2))
        if (isNaN(vatprice.GetValue())) {
            vatprice.SetValue(0);
        }
        fpricevalue.SetValue(parseFloat(vatprice.GetValue()).toFixed(2))
    }
    else {
        const sum = parseFloat(sprice.GetValue()) * parseFloat(vatvalue.GetValue())
        vatprice.SetValue(parseFloat((parseFloat(sum) / 100) + parseFloat(sprice.GetValue())).toFixed(2))
        if (isNaN(vatprice.GetValue())) {
            vatprice.SetValue(0);
        }
        fpricevalue.SetValue(parseFloat(sprice.GetValue()).toFixed(2))
    }
}


function GetError(s, e) {
    if (s.cperrors!=undefined) {

    
        if (s.cperrors != 'undefined' && s.cperrors != null && s.cperrors.length != 0) {
        Swal.fire({
            icon: s.cpicon,
            title: s.cperrors,
        })
        s.cperrors = "";
        }
    }
};

function validate(s, e) {
    if (parseFloat(txt_minqty.GetValue()) > parseFloat(txt_maxqty.GetValue())) {
        sweetinfo("لا يمكن أن تكون أقل كمية أكبر من أقصى كمية");
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent)
    }
};
function validate_branch(s, e) {
    if (nullToIntZero($('#hf_itemid').val()) == 0) {
        sweetinfo("برجاء إختيار صنف أولاً");
        tkb_branchid.PerformCallback()
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent)
    }
    if (nullToEmpty(tkb_branchid.GetValue()) == '')
    {
        sweetinfo("برجاء إختيار الفرع أولاً");
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent)
    }
};
function updmsg(s, e) {
    Swal.fire({
        icon: 'success',
        title: 'تم رفع صورة الصنف بنجاح',
        showConfirmButton: false,
        timer: 2000,
    })
};

function preventwriteitemcode1(s, e) {
    token = GetToken();
    if (token.autoitem == "True") {
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
    }
};

$(function () {
    token = GetToken();
    if (token.autoitem == "False" && (txt_itemcode == "تلقائى" || txt_itemcode == null)) {
        txt_itemcode.nullText = ""
        txt_itemcode.SetValue(null)
    }
})