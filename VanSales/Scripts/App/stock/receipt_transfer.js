function setTransData(s, e) {
    let searchmodel = {
        transferno: s.GetValue()

    }
    let data = getAction("/VanSalesService/Stock/Receipt_trans", searchmodel)


    if (data.length != 0) {
        //searchmodel["transid"] = data[0].transid;
        txt_trandocno.SetValue(data[0].trandocno);
        txt_trandate.SetValue(new Date(data[0].trandate));
        cmb_branchid.SetValue(data[0].branchid);
        cmb_branchid.SetText(data[0].branchname);
        cmb_ccid.SetValue(data[0].ccid);
        cmb_ccid.SetValue(data[0].ccname);
        cmb_branchtoid.SetValue(data[0].branchtoid);
        cmb_branchtoid.SetText(data[0].branchtoname);
        cmb_cctoid.SetValue(data[0].cctoid);
        cmb_cctoid.SetValue(data[0].cctoname);
        txt_trannotes.SetValue(data[0].trannotes);
        lbl_postacc.SetValue(data[0].postacc);
        txt_vochrid.SetValue(data[0].vochrid);
        txt_issordno.SetValue(data[0].transno);
        $('#HF_transid').val(data[0].transid);
        //document.getElementById("HF_transid").value = data[0].transid;
      
        $('#PDetiles').show();
        gvs_transdtls.PerformCallback();
        
       // txt_issordno.SetValue(data[0].issordno);
        //txt_resev.SetValue(data[0].issordno);

        
       // $('#HF_factor').val(data[0].factor);
       // $('#HF_cost').val(data[0].cprice);
      //  $('#HF_itemid').val(data[0].itemid);
       // data = getAction("/VanSalesService/items/ItemQtyBalance", searchmodel)
       // if (data.length != 0) {
       //     lbl_qtyinf.SetValue(data[0].qty)
      //  }
    }
    else {
        
        clear_Data();
        //$('#PDetiles').hide();
    }
}
function clear_Data()
{
  
    txt_transno.SetValue("");
    txt_trandocno.SetValue("");
    txt_trannotes.SetValue("");
   
//   // txt_trandate.Date = new Date(DateTime.Now);
    btn_Save.SetEnabled(true);
     cmb_branchid.SetValue("");
     cmb_branchtoid.SetValue("");
     cmb_ccid.SetValue("");
     cmb_cctoid.SetValue("");
     $('#HF_transid').val("");
    $('#HF_recepitid').val("");
    $('#HF_isreceipt').val("");
    $('#hf_postst').val("");
    $('#hf_postacc').val("");
     lbl_postacc.SetValue("");
     lbl_postst.SetValue("");
     txt_issordno.SetValue("");
    txt_resev.SetValue("");
    //btn_Save.SetEnabled(true);
//    //txt_issordno.Visible = false;
//    // txt_resev.Visible = false;
//    //  ddl_branchid.Enabled = true;
   // if ($('#hf_postst').val() == true || $('#hf_postst').val() == 'مرحل مستودعات') {

    //    //btn_delete.SetEnabled(false);
    //    //btn_addnew.enabled = false;
    //    //  btn_save_dtls.SetEnabled(false);
    //    // btn_new_dtls.enabled = false;
    //    // btn_delete_dtls.SetEnabled(false);
    //    //  btn_fastinsert.SetEnabled(false);
  //}
    //else {
       
    //}
    $('#PDetiles').hide();
  
// gvs_transdtls.PerformCallback();
}
function validate(s, e) {

    if (txt_transno.GetValue() == "" || txt_transno.GetValue() == null)
    {
        txt_transno.Focus();
        e.txt_transno.Focus();
        return;
    }
    if (txt_trandate.GetValue() == "" || txt_trandate.GetValue() == null) {
        txt_trandate.Focus();
        e.txt_trandate.Focus();
        return;
    }
    if (cmb_branchid.GetValue() == null) {
        cmb_branchid.Focus();
        e.cmb_branchid.Focus();
        return;
    }
    if (cmb_branchtoid.GetValue() == null) {
        cmb_branchtoid.Focus();
        e.cmb_branchtoid.Focus();
        return;
    }

}
$('#popupModalsearch').on('hidden.bs.modal', function () {
    if (nullToEmpty(txt_transno.GetValue()) != "") {
        //ddl_branchid.GetInputElement().readOnly = true;
        
        if ($('#hf_postst').val() == false) {
         //   btn_Save.SetEnabled(true);

        }
        else {
           // btn_Save.SetEnabled(false);
        }
        gvs_transdtls.PerformCallback($('#hf_postst').val() + "," + $('#hf_postacc').val() + "," + $('#HF_isreceipt').val())

      
    }
    else {
       // clear_item();
        $('#PDetiles').hide()
    }
});
//function pageLoad(sender, args) {
//    $(function () {
//        if (lbl_postst.GetValue() =="مرحل مستودعات") {
//            btn_Save.SetEnabled(false);
//        }
//        else {
//            btn_Save.SetEnabled(true);
//        }
//    })
//}
$('#popupModal').on('hidden.bs.modal', function () {
    if (nullToEmpty(txt_transno.GetValue()) != "") {
        //ddl_branchid.GetInputElement().readOnly = true;
      //  btn_Save.SetEnabled(false);
      
        gvs_transdtls.PerformCallback($('#hf_postst').val() + "," + $('#hf_postacc').val()+","+ $('#HF_isreceipt').val())
        
        

    }
    else {
        // clear_item();
        $('#PDetiles').hide()
    }
});

function postReceiptOrderStock(s, e) {
    let postmodel = {
        //branchid: ddl_branchid.GetValue(),
        transid: $('#HF_recepitid').val(),
        username: null,

    };

    let res = postaction("/VanSalesService/Stock/PostReceiptOrderStock", postmodel);
    if (res.errorid != 0) {
        sweetexception(res.errormsg)
        btn_Save.SetEnabled(true);
    }
    else {
        sweetsuccess(res.errormsg)
        btn_Save.SetEnabled(false);
        //btn_delete.SetEnabled(false);
        //btn_addnew.enabled = false;
       // btn_save_dtls.SetEnabled(false);
        // btn_new_dtls.enabled = false;
       // btn_delete_dtls.SetEnabled(false);
        //btn_fastinsert.SetEnabled(false);
        lbl_postst.SetValue("مرحل مستودعات");
    }
    // console.log(res)
}