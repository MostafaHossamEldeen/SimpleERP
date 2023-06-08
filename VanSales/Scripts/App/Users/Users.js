function setuserproperty(s, e) {
        let datamodel = {
            userid: cmbuserproperty_userid.GetValue()
        }
        let tokenval="";
        let tokentext="";
        let tokenccid="";
        let tokenccname="";
            let udiscperitem="";
            let yearid="";
            let year = "";
            let rlevel = "";
            let rlevelname = "";
            let empid = "";
            let empname = "";
        let res = getAction("/VanSalesService/users/GetUserProperty", datamodel)
        if (res.length != 0) {
            for (let i = 0; i < res.length; i++) {
                if (nullToEmpty(tokenval) == "") {
                    tokenval = res[i].branchid;
                   // tokenccid = res[i].ccid;
                    yearid = res[i].uyearid;
                    rlevel = res[i].rlevel;
                    empid = res[i].empid;

                }
                else {
                    tokenval += "," + res[i].branchid;
                   // tokenccid += "," + res[i].ccid;
                    yearid = res[i].uyearid;
                    rlevel = res[i].rlevel;
                    empid = res[i].empid;
                }
                if (nullToEmpty(tokenccid) == "") {
                    
                    tokenccid = res[i].ccid;
                 

                }
                else {
                   
                    tokenccid += "," + res[i].ccid;
                 
                }
                if (nullToEmpty(tokentext) == "") {
                    tokentext = res[i].branchname;
                  //  tokenccname = res[i].ccname;
                    udiscperitem = res[i].udiscperitem;
                    year = res[i].uyear;
                    rlevelname = res[i].rlevelname;
                    empname = res[i].empname;

                }
                else {
                    tokentext += "," + res[i].branchname;
                    //tokenccname += "," + res[i].ccname;
                    udiscperitem = res[i].udiscperitem;
                    year = res[i].uyear;
                    rlevelname = res[i].rlevelname;
                    empname = res[i].empname;
                }

                if (nullToEmpty(tokenccname) == "") {
                   
                     tokenccname = res[i].ccname;
                    

                }
                else {
                    
                    tokenccname += "," + res[i].ccname;
                 
                }


            }
           
        }
        if (nullToEmpty(tokenval) == "") {
            tokentbox_userbranchs.SetValue(null)
            tokentbox_userbranchs.SetText(null)
        }
        else {
            tokentbox_userbranchs.SetValue(tokenval)
            tokentbox_userbranchs.SetText(tokentext)
        }
        if (nullToEmpty(tokenccid) == "")
        {
            tokentbox_usercc.SetValue(null)
            tokentbox_usercc.SetText(null)
        }
        else {
            tokentbox_usercc.SetValue(tokenccid)
            tokentbox_usercc.SetText(tokenccname)
        }
        if (nullToEmpty(udiscperitem) == "")
        {
            txt_udiscperitem.SetValue(null)
           
        }
        else {
            txt_udiscperitem.SetValue(udiscperitem)
            
            }

            if (nullToEmpty(yearid) == "")
        {
                cmb_uyearid.SetValue(null)
                cmb_uyearid.SetText(null)
           
        }
        else {
                cmb_uyearid.SetValue(yearid)
                cmb_uyearid.SetText(year)
            
            }

            if (nullToEmpty(rlevel) == "")
        {
                cmb_rlevel.SetValue(null)
                cmb_rlevel.SetText(null)
           
        }
        else {
                cmb_rlevel.SetValue(rlevel)
                cmb_rlevel.SetText(rlevelname)
            
            }
            if (nullToEmpty(empid) == "")
        {
                txt_empid.SetValue(null)
                $("#hf_empid").val("")
           
        }
        else {
                txt_empid.SetValue(empname)
                $("#hf_empid").val(empid)
            
            }


         
    };
    function deldata() {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: true
        })
        swalWithBootstrapButtons.fire({
            title: 'تأكيد الحذف',
            text: "هل تريد حذف البيانات",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: ' نعم, تأكيد',
            cancelButtonText: 'لا, إلغاء ',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                gvusers.PerformCallback(null);
            } else if (
                result.dismiss === Swal.DismissReason.cancel
            ) {
                swalWithBootstrapButtons.fire(
                    'إلغاء',
                    'تم إلغاء عملية الحذف',
                    'error'
                )
            }
        })
    };
    function sweetexception(x) {
        Swal.fire({
            icon: 'warning',
            title: x,
        })
    };
    function sweetnonselect() {
        Swal.fire({
            icon: 'warning',
            title: 'لم تقم باختيار اى بيانات',
        })
    };
    function sweetsuccess(x) {
        Swal.fire({
            icon: 'success',
            title: x,
            showConfirmButton: false,
            timer: 1500,
        })
    };
function GetError(s, e) {
    if (s.cperrors != undefined || s.cperrors!=null) {
        if (s.cperrors != 'undefined' && s.cperrors != null && s.cperrors.length != 0) {
            Swal.fire({
                icon: s.cpicon,
                title: s.cperrors,
            })
            s.cperrors = "";
        }
    }
        
    };
    function validateuersprep(s, e) {
        if (cmbuserproperty_userid.GetValue() == null || cmbuserproperty_userid.GetValue() == "") {
            sweetinfo("برجاء إختيار المستخدم");
            cmbuserproperty_userid.Focus();
            ASPxClientUtils.PreventEvent(e.htmlEvent);
            return;
        }
        if (tokentbox_userbranchs.GetValue() == null || tokentbox_userbranchs.GetValue() == "") {
            sweetinfo("برجاء إختيار فروع المستخدم");
            tokentbox_userbranchs.Focus();
            ASPxClientUtils.PreventEvent(e.htmlEvent);
            return;
        }
        //if (tokentbox_usercc.GetValue() == null || tokentbox_usercc.GetValue() == "") {
        //    sweetinfo("برجاء إختيار مراكز تكلفة المستخدم");
        //    cmbuserproperty_userid.Focus();
        //    ASPxClientUtils.PreventEvent(e.htmlEvent);
        //    return;
        //}
        if (txt_udiscperitem.GetValue() > 100 || txt_udiscperitem.GetValue() < 0) {
            sweetinfo("لا يمكن أن تكون نسبة الخصم أقل من 0 و أكبر من 100");
            txt_udiscperitem.Focus();
            ASPxClientUtils.PreventEvent(e.htmlEvent);
            return;
        }
        //if (txt_empid.GetValue() == null || txt_empid.GetValue() == "") {
        //    sweetinfo("برجاء إختيار الموظف التابع للمستخدم ");
        //    txt_empid.Focus();
        //    ASPxClientUtils.PreventEvent(e.htmlEvent);
        //    return;
        //}
    }
    function validateuersprepcmb_rlevel(s, e) {
        if (cmbuserproperty_userid.GetValue() == null || cmbuserproperty_userid.GetValue() == "") {
            sweetinfo("برجاء إختيار المستخدم");
            cmbuserproperty_userid.Focus();
            ASPxClientUtils.PreventEvent(e.htmlEvent);
            return;
        }
}


   //<dx:GridViewDataTextColumn FieldName="hasnew" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
   //                                                             <dx:GridViewDataTextColumn FieldName="hassave" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
   //                                                             <dx:GridViewDataTextColumn FieldName="hasdelete" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
   //                                                             <dx:GridViewDataTextColumn FieldName="hasopen" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
   //                                                             <dx:GridViewDataTextColumn FieldName="haspostacc" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
   //                                                              <dx:GridViewDataTextColumn FieldName="haspoststock" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
   //                                                               <dx:GridViewDataCheckColumn FieldName="addnew" VisibleIndex="4" Caption="جديد" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
   //                                                                 <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
   //                                                             </dx:GridViewDataCheckColumn>
   //                                                               <dx:GridViewDataCheckColumn FieldName="savedata" VisibleIndex="4" Caption="حفظ" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
   //                                                                 <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
   //                                                             </dx:GridViewDataCheckColumn>
   //                                                               <dx:GridViewDataCheckColumn FieldName="deletedata" VisibleIndex="4" Caption="حذف" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
   //                                                                 <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
   //                                                             </dx:GridViewDataCheckColumn>
   //                                                               <dx:GridViewDataCheckColumn FieldName="poststock" VisibleIndex="4" Caption="ترحيل مستودع" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
   //                                                                 <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
   //                                                             </dx:GridViewDataCheckColumn>
   //                                                               <dx:GridViewDataCheckColumn FieldName="postacc" VisibleIndex="4" Caption="ترحيل حسابات" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
   //                                                                 <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
   //                                                             </dx:GridViewDataCheckColumn>
function batchEditStart(s, e) {
    switch (e.focusedColumn.fieldName) {
        case "addnew": {
            e.cancel = (s.batchEditApi.GetCellValue(e.visibleIndex, "hasnew") == -1)
        }
            break;
        case "savedata": {
            e.cancel = (s.batchEditApi.GetCellValue(e.visibleIndex, "hassave") == -1)
        }
            break;
        case "deletedata": {
            e.cancel = (s.batchEditApi.GetCellValue(e.visibleIndex, "hasdelete") == -1)
        }
            break;
        case "poststock": {
            e.cancel = (s.batchEditApi.GetCellValue(e.visibleIndex, "haspoststock") == -1)
        }
            break;
        case "postacc": {
            e.cancel = (s.batchEditApi.GetCellValue(e.visibleIndex, "haspostacc") == -1)
        }
            break;
        case "allow": {
            e.cancel = (s.batchEditApi.GetCellValue(e.visibleIndex, "hasopen") == -1)
        }
            break;
     
        default:
    }
  /*  s.batchEditHelper.EndEdit()*/
   

}