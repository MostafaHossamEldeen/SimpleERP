/// <reference path="../base/helperjs.js" />

//const { debug } = require("request");

//function openModal() {
//    $('#myAlert').modal('show');
//    setTimeout(function () {
//        $('#myAlert').hide('fade');
//    }, 2000);
//    $('#linkClose').click(function () {
//        $('#myAlert').hide('fade');
//    });
//}
//function showpo() {


//}
//function check_payvalue() {
//    if (txt_payvalue.GetValue() == null)
//        txt_payvalue.SetValue(0);
//}
$(function () {  
})
function preventwrite1(s, e) {
    
 

    ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);

}
function clear_dtl() {

    txt_itemcode.SetValue(""),
        txtitem_name.SetValue(""),
        txt_unit.SetValue(""),
        txt_qty.SetValue(1),
        $('#hf_qty').val(""),
        $('#HF_unitid').val(""),
        $('#HF_invdtlid').val(""),
        $('#HF_itemid').val(""),
        $('#HF_factor').val(""),
        $('#HF_cost').val(""),
        txt_value.SetValue(0),
        txt_discp.SetValue(0),
        txt_discvalue.SetValue(0),
        txt_netvalue.SetValue(0),
        txt_itemvatvalue.SetValue(0),
        $('#Hf_vat').val(""),
        txt_itemnotes.SetValue(""),
        txt_price.SetValue(0)
}
function Clear_pay() {
    cmb_paytype.SetSelectedIndex(0),
        txt_payno.SetValue(""),
        txt_payref.SetValue(""),
        txt_payvalue.SetValue(0),
        cmb_paychartid.SetValue("");
    $('#Hf_invpayid').val("")

}
function delete_dtl() {

    let datamodel = $('#HF_invdtlid').val()
    let res = deleteAction("/VanSalesService/invoice/DeleteInvdtl1", datamodel)
    if (res.errorid == 0) {
        txt_netbvat.SetValue(res.outputparams.netbvat),
            txt_vatvalue.SetValue(res.outputparams.vatval),
            txt_netavat.SetValue(res.outputparams.netbvat)
        gvs_invdtls.PerformCallback()
    }
}

function Gvs_Bind_dtl(s, e) {
    clear_dtl();

    s.GetRowValues(s.focusedRowIndex, 'itemcode;itemname;unitname;qty;unitid;invdtlid;itemid;factor;cost;value;discp;discvalue;netvalue;vatvalue;itemnotes;price', function (values) {


        txt_itemcode.SetValue(nullToEmpty(values[0])),
            txtitem_name.SetValue(nullToEmpty(values[1])),
            txt_unit.SetValue(nullToEmpty(values[2])),
            txt_qty.SetValue(nullToDecimalZero(values[3])),
            document.getElementById("hf_qty").value = nullToDecimalZero(values[3]),
            $("#HF_unitid").val(nullToIntZero(values[4])),
            $("#HF_invdtlid").val(nullToIntZero(values[5])),
            $("#HF_itemid").val(nullToIntZero(values[6])),
            $("#HF_factor").val(nullToDecimalZero(values[7])),
            $('#HF_cost').val(nullToDecimalZero(values[8])),
            txt_value.SetValue(nullToDecimalZero(values[9])),
            txt_discp.SetValue(nullToDecimalZero(values[10])),
            $('#hf_disc').val(nullToDecimalZero(values[11])),
            txt_discvalue.SetValue(nullToDecimalZero(values[11])),
            txt_netvalue.SetValue(nullToDecimalZero(values[12])),
            txt_itemvatvalue.SetValue(nullToDecimalZero(values[13])),
            //  $('#Hf_vat').val(nullToDecimalZero(values[13])),
            txt_itemnotes.SetValue(nullToEmpty(values[14])),
            txt_price.SetValue(nullToDecimalZero(values[15]))

        //   HF_itemunitid.SetValue(values[4]),

        //HF_itemid.SetValue(values[6])


    });

}
function Gvs_Bind_Pay(s, e) {
    //Clear_pay();
    s.GetRowValues(s.focusedRowIndex, 'payno;payref;payvalue;paytypeid;invpayid;payname;paychartid;chartname', function (values) {


        txt_payno.SetValue(nullToEmpty(values[0])),
            txt_payref.SetValue(nullToEmpty(values[1])),
            txt_payvalue.SetValue(nullToDecimalZero(values[2])),
            cmb_paytype.SetValue(nullToDecimalZero(values[3])),
            cmb_paytype.SetText(nullToEmpty(values[5])),
            $('#Hf_invpayid').val(nullToIntZero(values[4]),)
        cmb_paychartid.SetValue(nullToDecimalZero(values[6]))
        cmb_paychartid.SetText(nullToEmpty(values[7]))

    });

}
function getgvrow() {

    var index = gvs_invdtls.GetFocusedRowIndex();


    var id = gvs_invdtls.GetRowKey(index);
    HF_invdtlid.value = id;
}

function cus_validate() {
    if (nullToEmpty(Hf_cusid.value) != "" || nullToEmpty(txt_cusid.GetValue()) != "") {
        ctname.GetInputElement().readOnly = true;
        txt_custadd.GetInputElement().readOnly = true;
        txt_custvat.GetInputElement().readOnly = true;
        txt_custmobile.GetInputElement().readOnly = true;
        // cmb_smanid.GetInputElement().readOnly = true;
        //cmb_smanid.SetEnabled(false);
    }
    else {
        ctname.GetInputElement().readOnly = false;
        txt_custadd.GetInputElement().readOnly = false;
        txt_custvat.GetInputElement().readOnly = false;
        txt_custmobile.GetInputElement().readOnly = false;
        cmb_smanid.GetInputElement().readOnly = false;
        // cmb_smanid.SetEnabled(true);
    }

}
function validate(s, e) {

    if (cmb_sinvpay.GetValue() == 2 || cmb_sinvpay.GetValue == "أجل") {
        if (txt_cusid.GetValue() == null) {
            sweetinfo("برجاء إختيار العميل لكون نوع سداد الفاتورة أجل");
            txt_cusid.Focus();
            e.txt_cusid.Focus();
            return;
        }
    }
    if (ctname.GetValue() == "" || ctname.GetValue() == null) {
        // alert("برجاء ادخال اسم العميل");
        sweetinfo("برجاء ادخال اسم العميل");
        //document.myForm.Name.focus();
        ctname.Focus();
        e.ctname.Focus();

        return;
    }
    if (sinvdata.GetValue() == "" || sinvdata.GetValue() == null) {
        sinvdata.Focus();
        e.sinvdata.Focus();
        return;
    }
    if (nullToEmpty(cmb_branchid.GetValue()) == "") {
        cmb_branchid.Focus();
        e.cmb_branchid.Focus();
        return;
    }


}
function validate_dtl(s, e) {
    if (nullToEmpty(txt_itemcode.GetValue()) == "") {
        sweetinfo("برجاء ادخال كود الصنف اولا");
        txt_itemcode.Focus();
        e.txt_itemcode.Focus();
        return;
    }
    if (nullToDecimalZero(txt_qty.GetValue()) == 0) {
        sweetinfo("لايمكن ادخال كميه صفر او فارغه");
        txt_qty.Focus();
        e.txt_qty.Focus();
        return;
    }
}
function validatePay(s, e) {


    if (nullToDecimalZero(txt_payvalue.GetValue() == "0")) {
        sweetexception('برجاء ادخال القيمه اولا')
        txt_payvalue.Focus();
        e.txt_payvalue.Focus();
        return;
    }


}

//function Confirm() {

//    var confirm_value = document.createElement("INPUT");
//    confirm_value.type = "hidden";
//    confirm_value.name = "confirm_value";
//    if (confirm("هل تريد الحذف؟")) {
//        confirm_value.value = "نعم";
//    } else {
//        confirm_value.value = "No";
//    }
//    document.forms[0].appendChild(confirm_value);
//}
//function function_delete() {
//    //alert("برجاء اختيار الصنف المراد حذفه");
//    sweetinfo("برجاء اختيار الصنف المراد حذفه");
//}
function getrow() {

    var index = gv_invpay.GetFocusedRowIndex();


    var id = gv_invpay.GetRowKey(index);
    document.getElementById("Hf_invpayid").value = id;
}
//function getrow_dtlinv() {

//    var index = gvs_invdtls.GetFocusedRowIndex();


//    var id = gvs_invdtls.GetRowKey(index);
//    document.getElementById("HFsinviddtl").value = id;
//}

//if ((text.indexOf('.') != -1) &&
//    (text.substring(text.indexOf('.')).length > 3) &&
//    (event.htmlEvent.keyCode != 0 && event.htmlEvent.keyCode != 8)// &&
//    //($(this)[0].selectionStart >= text.length - 3)
//)
//{
//    ASPxClientUtils.PreventEvent(event.htmlEvent);
//}

function isFloatNumber(e, t) {
    var n;
    var r;
    if (navigator.appName == "Microsoft Internet Explorer" || navigator.appName == "Netscape") {
        n = t.keyCode;
        r = 1;
        if (navigator.appName == "Netscape") {
            n = t.charCode;
            r = 0
        }
    } else {
        n = t.charCode;
        r = 0
    }
    if (r == 1) {
        if (!(n >= 48 && n <= 57 || n == 46)) {
            t.returnValue = false
        }
    } else {
        if (!(n >= 48 && n <= 57 || n == 0 || n == 46)) {

            t.preventDefault()
        }
        
    }
}

///////////calc
function multiply() {

    var text1 = txt_qty.GetValue();
    var text2 = txt_price.GetValue();

    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;

    txt_value.SetValue((parseFloat(t1 * 1).toFixed(2) * parseFloat(t2 * 1).toFixed(2)).toFixed(2));


    Subtract();
    // calac_vat();
}
function multiplydis() {
        var text1 = txt_discp.GetValue();
        var text2 = txt_value.GetValue();

        var t1 = 0, t2 = 0;
        if (text1 != "") t1 = text1 / 100;
        if (text2 != "") t2 = text2;
    if (txt_discp.GetValue() == null)
        txt_discp.SetValue(0);

        if (t1 > 1)
            sweetinfo(" الخصم اكبر من 100%");
        txt_discvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
    Subtract();

    if (txt_discp.GetValue() > parseFloat(GetToken().udiscperitem)) {
        
        txt_discp.SetValue(0);
        txt_discvalue.SetValue(0);
        txt_discvalue.SetValue(parseFloat(t2).toFixed(2));
        }
    
}
function Subtract() {


    var text1 = txt_value.GetValue();
    var text2 = txt_discvalue.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;

    txt_netvalue.SetValue((parseFloat(t1).toFixed(2) - parseFloat(t2).toFixed(2)).toFixed(2));
    calac_vat();
}
function calac_vat() {
    
    ////شامل
    token = GetToken();
    if ($("#HF_vattype").val() == 1) {
        if (txt_itemvatvalue.GetValue() == 0 || txt_itemvatvalue.GetValue() == null) {

            if (document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
                var text1 = txt_netvalue.GetValue();
                var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;

                txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));

            }
            else {

                txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) {
                    var text1 = txt_netvalue.GetValue();
                    var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;

                    txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
                }
            }
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
            // txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
            let searchmodel = {
                // itemcode: txt_itemcode.GetValue(),
                // barcode1: txt_itemcode.GetValue(),
                //  barcode2: txt_itemcode.GetValue(),
                unitid: $("#HF_unitid").val(),
                SearchVal: txt_itemcode.GetValue()
            }
            let data = getAction("/VanSalesService/items/GetItemunitData", searchmodel)
            if (data.length != 0) {
                $('#Hf_vat').val(data[0].vat);
            }
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;

            txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));


        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;

            txt_itemvatvalue.SetValue(((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)) / (parseInt(100) + parseFloat(t2)).toFixed(2)).toFixed(2));
        }
    }
    /////////غير شامل
    else if ($("#HF_vattype").val() == 2) {
        if (txt_itemvatvalue.GetValue() == 0 || txt_itemvatvalue.GetValue() == null) {

            if (document.getElementById("Hf_vat").value != "" || document.getElementById("Hf_vat").value != null) {
                var text1 = txt_netvalue.GetValue();
                var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115; new (+)
                var t1 = 0, t2 = 0;
                if (text1 != "") t1 = text1;
                if (text2 != "") t2 = text2;

                txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));

            }
            else {

                txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
                if (txt_qty.GetValue() != hf_qty.value || txt_discvalue.GetValue() != hf_disc) {
                    var text1 = txt_netvalue.GetValue();
                    var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
                    var t1 = 0, t2 = 0;
                    if (text1 != "") t1 = text1;
                    if (text2 != "") t2 = text2;

                    txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
                }
            }
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value == "") {
            // txt_itemvatvalue.SetValue(txt_itemvatvalue.GetValue());
            let searchmodel = {
               // itemcode: txt_itemcode.GetValue(),
               // barcode1: txt_itemcode.GetValue(),
                //  barcode2: txt_itemcode.GetValue(),
                unitid: $("#HF_unitid").val(),
                SearchVal: txt_itemcode.GetValue()
            }
            let data = getAction("/VanSalesService/items/GetItemunitData", searchmodel)
            if (data.length != 0) {
                $('#Hf_vat').val(data[0].vat);
            }
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value/100;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;

            txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
        }
        else if (txt_itemvatvalue.GetValue() != 0 && document.getElementById("Hf_vat").value != "") {
            var text1 = txt_netvalue.GetValue();
            var text2 = document.getElementById("Hf_vat").value / 100;  //0.13;//15 / 115;
            var t1 = 0, t2 = 0;
            if (text1 != "") t1 = text1;
            if (text2 != "") t2 = text2;

            txt_itemvatvalue.SetValue((parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2)).toFixed(2));
        }
    }
}
function calac_disc() {

    
    var text1 = txt_discvalue.GetValue();
    var text2 = txt_value.GetValue();
    var t1 = 0, t2 = 0;
    if (text1 != "") t1 = text1;
    if (text2 != "") t2 = text2;
    if (txt_discvalue.GetValue() == null)
        txt_discvalue.SetValue(0);
    txt_discvalue.SetValue((parseFloat(t2 * 1).toFixed(2) * parseFloat(t1 * 1).toFixed(2)).toFixed(2)/100);
    txt_netvalue.SetValue((parseFloat(t2 * 1).toFixed(2) - parseFloat(t1 * 1).toFixed(2)).toFixed(2));
    
    //txt_discp.SetValue((parseFloat(t1).toFixed(2) / parseFloat(t2).toFixed(2))*100);
    calac_vat();
}
function sumdata() {

    var sum = 0;
    var indices = gvs_invdtls.GetVisibleRowsOnPage();//.GetRowVisibleIndices();//GridHR_Op_d.batchEditApi.GetRowVisibleIndices();
    for (i = 0; i < indices; i++) {

        // gvs_invdtls.GetRowValues(i, "netvalue", OnGetRowValues)
        gvs_invdtls.GetRowValues(i, "vatvalue", OnGetRowValuesval);

    }

}

function OnGetRowValues(value) {
    //alert(value)
}
function OnGetRowValuesval(value) {
    //alert(value)

}
function print_newtab() {

    var x = document.getElementById("HF_sinvid").value;
    if (x == "") {
      
        sweetinfo('لم يتم اختيار فاتوره للطباعه');
        ASPxClientUtils.PreventEvent(evt.htmlEvent);
    }
    //window.open("/Sales/Report.aspx?sinvid=" + x + "&page=inv", null, "dialogHeight:600px; dialogWidth:920px,status=no,toolbar=no,titlebar=no,scrollbars=1,menubar=no,location=no");
}
function invsearch() {
    var rc = window.open('inv_search.aspx', '', 'width=600,height=500');

}

function itemsearch() {
    var rc = window.open('item_search.aspx', '', 'top=200,left=700,width=600,height=500');
}
function cus_search() {
    var rc = window.open('cust_search.aspx', '', 'top=200,left=700,width=600,height=500');
}
function add_cus() {
    /*   var rc = window.open('/Customers/customers.aspx', '', 'top=200,left=290,width=1000,height=500')*/
   // $('#cus_contante').load("../Customers/add_cus.aspx");
    //$(document).ready(function () {
        $('#popupModaladdcust').modal("show");
       
    fill_cmb_cusgroup();

    $('#txt_cusname').val(null);
    $('#txt_cusadd').val(null);
    $('#txt_cusmob').val(null);
    $('#txt_cusvat').val(null);
   
        $('#txt_cusname').focus();
 
}
function UpdateReal(x) {
    document.getElementById("HF_sinvid").value = x;
    __doPostBack('HF_sinvid', "HF_sinvid");


}

function Updateitems(x) {
    document.getElementById("HfItemID").value = x;
    __doPostBack('HfItemID', "HfItemID");


}
function Updatecus(x) {

    document.getElementById("Hfcusid").value = x;
    __doPostBack('Hfcusid', "Hfcusid");


}
function addcus(x) {
    document.getElementById("Hfcusid").value = x;
    __doPostBack('Hfcusid', "Hfcusid");


}

//function myFunction() {
//    var txt;
//    var r = confirm("Press the button!");
//    if (r == true) {
//        txt = "You chose OK!";
//    } else {
//        txt = "You Cancelled!";
//    }
//    document.getElementById("conf").innerHTML = txt;
//}
//function sweetinfo(x) {
//    Swal.fire({
//        icon: 'info',
//        title: x,

//        //showClass: {
//        //    popup: 'animate__animated animate__fadeInDown'
//        //},
//        //hideClass: {
//        //    popup: 'animate__animated animate__fadeOutUp'
//        //}
//    })
//}
//function sweetsuccess(x) {
//    Swal.fire({
//        icon: 'success',
//        title: x,
//        showConfirmButton: false,
//        timer: 1500,
//        //showClass: {
//        //    popup: 'animate__animated animate__fadeInDown'
//        //},
//        //hideClass: {
//        //    popup: 'animate__animated animate__fadeOutUp'
//        //}
//    })
//}
//function sweetexception(x) {
//    Swal.fire({
//        icon: 'error',
//        title: x,
//        //showClass: {
//        //    popup: 'animate__animated animate__fadeInDown'
//        //},
//        //hideClass: {
//        //    popup: 'animate__animated animate__fadeOutUp'
//        //}
//    })
//}
function loadinv() {

    //$('#m_body').load("inv_det.aspx?invid=1034");

    //    $('#quickinsert').modal('show')
    if (txtinvno.GetValue() != "تلقائى") {


        popup.SetContentUrl('inv_det.aspx?invid=' + $('#HF_sinvid').val()+'&&invno='+txtinvno.GetValue());
        popup.Show();
    }
    else {
        // alert("برجاء حفظ الفاتورة اولا")
        sweetexception("برجاء حفظ الفاتورة اولا");
    }

}
function preventwrite(s, e) {
    ASPxClientUtils.PreventEventAndBubble(e);
}

function setCustData(s, e) {
    let searchmodel = {
        custcode: s.GetValue()

    }
    let data = getAction("/VanSalesService/inv/GetcustSingalData", searchmodel)

    if (data.length != 0) {

        searchmodel["custcode"] = data[0].custcode;
        ctname.SetValue(data[0].custname);
        txt_custadd.SetValue(data[0].custadd);
        txt_custvat.SetValue(data[0].custvat);
        txt_custmobile.SetValue(data[0].custmob);
        cmb_smanid.SetValue(data[0].smanid);
        $('#Hf_cusid').val(data[0].custid);


    }
    else {
        txt_cusid.SetValue("");
        ctname.SetValue("");
        txt_custadd.SetValue("");
        txt_custvat.SetValue("");
        txt_custmobile.SetValue("");
        cmb_smanid.SetValue("");
        $('#Hf_cusid').val("");
    }
    cus_validate();
}


function postCustData() {
    
    let cust = {
        custname: txt_cusname.value,
        custadd: txt_cusadd.value,
        custmob: txt_cusmob.value,
        custvat: txt_cusvat.value,
        sgrpid: $('#cmb_cusgroup').val(),

    }
    if ($('#cmb_cusgroup').val() == null)
    {
        sweetexception("برجاء ادخال مجموعه العملاء اولا");
        return;
    }
    let res = postaction("/VanSalesService/invoice/addcust", cust);

    if (res.errorid == 0) {

        txt_cusid.SetValue(res.outputparams.custcode);
      
        ctname.SetValue(txt_cusname.value);
        txt_custadd.SetValue(txt_cusadd.value);
        txt_custvat.SetValue(txt_cusvat.value);
        txt_custmobile.SetValue(txt_cusmob.value);
       cus_validate();
     
         $('#popupModaladdcust').modal('hide');
                  
    }

 
    else {
        sweetinfo(res.errormsg);
        $('#txt_cusname').Focus();
        $('#popupModaladdcust').modal('show');
       
   
    }
    
}
//$("#btn_cust").click(function () {
//    $('#popupModaladdcust').modal("hide");
//});
function setItemData(s, e) {

    let searchmodel = {
        itemcode: s.GetValue(),
        barcode1: s.GetValue(),
        barcode2: s.GetValue(),
        itemid: $('#HF_itemid').val()
        //  branchid: cmb_branchid.GetValue()
    }
    let data = getAction("/VanSalesService/items/GetItemSingalData", searchmodel)

    if (data.length != 0) {
        $('#HF_invdtlid').val("");
        searchmodel["itemid"] = data[0].itemid;
        txtitem_name.SetValue(data[0].itemname);
        txt_unit.SetValue(data[0].unitname);
        txt_price.SetValue(data[0].fprice);
        $('#HF_unitid').val(data[0].unitid);
        $('#HF_factor').val(data[0].factor);
        $('#HF_cost').val(data[0].cprice);
        $('#HF_itemid').val(data[0].itemid);
        $('#Hf_vat').val(data[0].vat);
        multiply();
        //lbl_qtyinf.SetValue(data[0]) 
        //data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
        //if (data.length != 0) {

        //    lbl_qtyinf.SetValue(data[0].qty)
        //} 
        txt_qty.Focus();
    }
    else {
        clear_dtl();

        txt_itemcode.Focus();
    }
}
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        if (nullToEmpty(txtinvno.GetValue()) != "تلقائى") {
            //cmb_branchid.GetInputElement().readOnly = true;
            //clear_item();
            //if ($('#hf_postst').val() == false) {
            //    btn_Save.SetEnabled(true);
            //    btn_delete.SetEnabled(true);
            //    //btn_addnew.enabled = false;
            //    btn_save_dtls.SetEnabled(true);
            //    // btn_new_dtls.enabled = false;
            //    btn_delete_dtls.SetEnabled(true);
            //    btn_fastinsert.SetEnabled(true);
            //}
            //if (nullToEmpty($('#Hf_cusid').val() != "")) {
            //    cus_validate();
            //}
            if (nullToEmpty(txt_cusid.GetValue() != "")) {
                cus_validate();
            }
            if (nullToEmpty($('#HF_itemid').val() != "")) {
                multiply();
            }
            gvs_invdtls.PerformCallback(lbl_invdoc.GetValue() + "," + txt_docid.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_posyacc').val() + "," + lbl_vochrno.GetValue() + "," + lbl_sinvstatusname.GetValue())
            if (nullToEmpty($('#Hf_invpayid').val() != "")) {
                gv_invpay.PerformCallback()
            }

          
        }
        else {
            if (nullToEmpty($('#Hf_cusid').val() != "")) {
                cus_validate();
            }
            clear_dtl();
            $('#PDetiles').hide()
            $('#p_invpay').hide()

        }
        
        //token = GetToken("sprice")
        //if (token.sprice == "False") {
        //    txt_price.readOnly = true;

        //}
    }

});

function priceKeyPress(s, e) {
    token = GetToken('sprice')
    if (token.sprice == 'False') {
        preventwrite1(s, e)
       // txt_value.GetInputElement().readOnly = true
    }
   
}
function postInvStock(s, e) {
    let postmodel = {
        // branchid: ddl_branchid.GetValue(),
        sinvid: $('#HF_sinvid').val(),
        username: null,

    };

    let res = postaction("/VanSalesService/invoice/postInvStock", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        $('#hf_postst').val(true);
        gvs_invdtls.PerformCallback(lbl_invdoc.GetValue() + "," + txt_docid.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_posyacc').val())
        // btn_Save.SetEnabled(false);
        // btn_delete.SetEnabled(false);
        // //btn_addnew.enabled = false;
        // btn_save_dtls.SetEnabled(false);
        //// btn_new_dtls.enabled = false;
        // btn_delete_dtls.SetEnabled(false);
        // btn_fastinsert.SetEnabled(false);
        lbl_postst.SetValue("مرحل مستودعات");
    }
    // console.log(res)
}

function postInvAcc(s, e) {
    let postmodel = {
        // branchid: ddl_branchid.GetValue(),
        sinvid: $('#HF_sinvid').val(),
        username: GetToken().username,

    };
    
    let res = postaction("/VanSalesService/invoice/postInvAcc", postmodel);
    if (res.errorid != 0) {

        sweetexception(res.errormsg)
    }
    else {
        sweetsuccess(res.errormsg)
        $('#hf_posyacc').val(true)
       // hf_posyacc.value = true;
        lbl_vochrno.SetValue(res.outputparams.voucher_no);
        gvs_invdtls.PerformCallback(lbl_invdoc.GetValue() + "," + txt_docid.GetValue() + "," + $('#hf_postst').val() + "," + $('#hf_posyacc').val() + "," + lbl_vochrno.GetValue())
      
        lbl_postacc.SetValue("مرحل حسابات");
    }
 
}

function fill_cmb_cusgroup() {
    let res = getAction("/VanSalesService/inv/GetCustgroupData");
    if (res.length != 0) {
        $('#cmb_cusgroup').empty();
        for (var i = 0; i < res.length; i++) {
            $('#cmb_cusgroup').append('<option value=' + res[i].sgrpid + '>' + res[i].sgrpname+'</option>')
        }
    }
}
//function setItemData(s, e) {
//    let searchmodel = {
//        itemcode: s.GetValue(),
//        barcode1:null

//}
//    let data = getAction("/VanSalesService/items/GetItemData", searchmodel)
//    if (data.length!=0) {
//        txtitem_name.SetValue(data[0].itemname) 
//    }
//    else {
//        txtitem_name.SetValue("")
//    }

//}

//AddKeyboardNavigationTo(gv_search);
//function AddKeyboardNavigationTo(grid) {
//    grid.BeginCallback.AddHandler(function (s, e) { gridPerformingCallback = true; });
//    grid.EndCallback.AddHandler(function (s, e) { gridPerformingCallback = false; });
//    ASPxClientUtils.AttachEventToElement(document, "keydown",
//        function (evt) {
//            return OnDocumentKeyDown(evt, grid);
//        });
//}
//function Done(values) {
//    window.opener.UpdateReal(values);
//    window.close();
//}

//function OnDocumentKeyDown(evt, grid) {
//    if (typeof (event) != "undefined" && event != null)
//        evt = event;



//    if (evt.keyCode == 13) //enter
//    {
//        //alert("")
//        grid.GetRowValues(grid.focusedRowIndex, 'sinvid', Done);
//       // ASPxClientUtils.PreventEvent(evt.htmlEvent);



//    }
//    //if (evt.ctrlKey && NeedProcessDocumentKeyDown(evt) && !gridPerformingCallback) {
//    //    var currentIndex = grid.GetFocusedRowIndex();


//    //    if (evt.keyCode == 40) //down
//    //    {
//    //        if (currentIndex == grid.GetVisibleRowsOnPage() - 1) {
//    //            return ASPxClientUtils.PreventEvent(evt);
//    //        }
//    //        else {
//    //            grid.SetFocusedRowIndex(currentIndex + 1);
//    //        }
//    //    }
//    //    if (evt.keyCode == 38) {
//    //        if (currentIndex == 0) {
//    //            return ASPxClientUtils.PreventEvent(evt);
//    //        }
//    //        else {
//    //            grid.SetFocusedRowIndex(currentIndex - 1);
//    //        }
//    //    }

//    //}
//}


//function NeedProcessDocumentKeyDown(evt) {

//    var evtSrc = ASPxClientUtils.GetEventSource(evt);
//    if (evtSrc.tagName == "INPUT")
//        return evtSrc.type != "text" && evtSrc.type != "password";
//    else
//        return evtSrc.tagName != "TEXTAREA";
//}

