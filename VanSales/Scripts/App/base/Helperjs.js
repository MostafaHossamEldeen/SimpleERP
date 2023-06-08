



let settingobj = { baseurl:"http://localhost:44368"}
let webmetodobj = { baseurl2: "http://localhost:44368/" }
let popupurl = "";

var modalClosingMethod = "Programmatically";

$(document).ready(function () {

    // Variable to be set on click on the modal... Then used when the modal hidden event fires

    // On modal click, determine where the click occurs and set the variable accordingly
    $('#popupModalsearchdef').on('click', function (e) {
        if ($(e.target).parent().attr("data-dismiss")) {
            modalClosingMethod = "bx";
        }

        else {
            modalClosingMethod = "by Background Overlay";
        }

        // Restore the variable "default" value

    });

    $("#popupModalsearchdef").on('shown.bs.modal', function () {
        modalClosingMethod = "Programmatically";
    });

})

//function openviewer(url) {
   
//    window.open(url, "_blank");
//}
function openviewer() {

    window.open('/ReportViewer/Viewer.aspx', "_blank");
}
function showpdf(pg) {
    window.open("/reportviewer/viewrep?p=" + pg, "_blank")
}
//function pageLoad(sender, args) {
//    var prm = Sys.WebForms.PageRequestManager.getInstance();
//    prm.add_beginRequest(BeginRequestHandler);
//    prm.add_endRequest(EndRequestHandler);
//}

//function BeginRequestHandler(sender, args) {
//    showLoadingUI();
//}

//function EndRequestHandler(sender, args) {
//    $.unblockUI();
//}

//function showLoadingUI() {
//    $.blockUI({
//        message: '<h3><img src="../img/icon/poststock.svg" /> <br /> <span style="font-family: Tahoma,Verdana,Arial, Sans-Serif; font-size: 12px; color: #1390c6;"> Loading...</span></h3>',
//        showOverlay: true,
//        css: {
//            width: '130px', height: '110px',
//            border: 'none',
//            padding: '10px',
//            '-webkit-border-radius': '10px',
//            '-moz-border-radius': '10px',
//            opacity: .9
//        }
//    });

//}
    //for decimale 3 number 
//function
 //sada
//class
//    $('.decimale3num').keypress(function (event) {
//         
//        var $this = $(this);
//        if ((event.which != 46 || $this.val().indexOf('.') != -1) &&
//            ((event.which < 48 || event.which > 57) &&
//                (event.which != 0 && event.which != 8))) {
//            event.preventDefault();
//        }

//        var text = $(this).val();
//        if ((event.which == 46) && (text.indexOf('.') == -1)) {
//            setTimeout(function () {
//                if ($this.val().substring($this.val().indexOf('.')).length > 3) {
//                    $this.val($this.val().substring(0, $this.val().indexOf('.') + 3));
//                }
//            }, 1);
//        }

//        if ((text.indexOf('.') != -1) &&
//            (text.substring(text.indexOf('.')).length > 3) &&
//            (event.which != 0 && event.which != 8) &&
//            ($(this)[0].selectionStart >= text.length - 3)) {
//            event.preventDefault();
//        }
//    });

//    $('.decimale3num').bind("paste", function (e) {
//         
//        var text = e.originalEvent.clipboardData.getData('Text');
//        if ($.isNumeric(text)) {
//            if ((text.substring(text.indexOf('.')).length > 3) && (text.indexOf('.') > -1)) {
//                e.preventDefault();
//                $(this).val(text.substring(0, text.indexOf('.') + 3));
//            }
//        }
//        else {
//            e.preventDefault();
//        }
//    });


//    // number 
////function

////class
//    $('.numonly').keypress(function (evt) {
//        var $this = $(this);
//        var text = $(this).val();
//        alert(text)
//        var charCode = (evt.which) ? evt.which : event.keyCode

//        if (

//            (charCode != 45 || text.indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.

//            (charCode < 48 || charCode > 57))

//            return false;

//        return true


//    })
//    //positive number integer
////function

////class
//    $('.positivenumonly').keypress(function (evt) {
//        var charCode = (evt.which) ? evt.which : event.keyCode
//        parseFloat(e).toFixed(3)
//        if (
//            (charCode < 48 || charCode > 57))
//            return false;

//        return true
//    })

//    //multipli
//    $(".multi").keyup(multInputsonly);
//    function Normal_multInputsonly() {
//        var total = 0;
//        var currentval = [];
//        $('.multi').each(function (i) {

//            const numval = $(this).val()
//            currentval.push(numval)
//        })
//        var currentvalt;
//        for (i = 0; i < currentval.length; i++) {
//            if (i == 0) {
//                currentvalt = currentval[i]
//            }
//            else {
//                currentvalt = currentval[i] * currentvalt;
//            }
//        }
//        $(".total").val(currentvalt.toFixed(3));
//    }

//    //total and net after tax and dis
//    $(".multiwithdis_tax").keyup(multInputs);

//    $("#vattax").keyup(multInputs)
//    $('#disprcnt').keyup(multInputs)
//    function normal_MultInputs() {
//        var total = 0;
//        var currentval = [];
//        $('.multiwithdis_tax').each(function (i) {

//            const numval = $(this).val()
//            currentval.push(numval)

//        })
//        var currentvalt;
//        for (i = 0; i < currentval.length; i++) {
//            if (i == 0) {
//                currentvalt = currentval[i]
//            }
//            else {
//                currentvalt = currentval[i] * currentvalt;
//            }

//        }

//        const tax = currentvalt.toFixed(3) * ($('#vattax').val() == "" ? 0 : (parseFloat($('#vattax').val()) / 100))
//        const currentvalaftervat = tax + currentvalt;
//        const dis = currentvalaftervat.toFixed(3) * ($('#disprcnt').val() == "" ? 0 : (parseFloat($('#disprcnt').val()) / 100))
//        const currentvalafterdis = currentvalaftervat - dis;
//        $("#total").val(currentvalt.toFixed(3));
//        $("#net").val(currentvalafterdis.toFixed(3));
//    } 
//#region ValueHelper
function isNull(val) {
    if (val == null || val == "" || val == undefined)
        return true
    else
        return false;
}

function isNullOrZero(val) {
    if (val == null || val == "" || val == undefined || val=="0")
        return true
    else
        return false;
}
function nullToIntZero(val) {

    if (val == null || val == "" || val == undefined)
        return 0
    else
        return parseInt(val);
}
function netValAfterDisPercentValue(prcntval, value = 0, sumnet = false) {
    let res=0
    if (value==0) {
        res = 0;
    }
    else {
        res= nullToDecimalZero(value * (nullToDecimalZero(prcntval / 100)))
    }
     
    if (sumnet==true) {
        res = nullToDecimalZero(value - res);
    }
    return nullToDecimalZero(res);
}

function percentValue(prcntval, value = 0) {
    let res = 0
    if (value == 0) {
        res = 0
    }
    else {
        res = nullToDecimalZero(value * (nullToDecimalZero(prcntval / 100)))
    }
  
    return res;
}
function vatVal(val, vatpercent = 0) {
    let res = 0;
    if (vatpercent == 0) {
        res = nullToDecimalZero(val * .15);
    }
    else {
        res=nullToDecimalZero(val/(vatpercent/100))
    }
    return res;
}
function nullToDecimalZero(val) {
     
    if (val == null || val == "" || val == undefined)
        return 0.0
    else
        return parseFloat(val).toFixed(3);
}
function nullToEmpty(val) {

    if (val == null || val == "" || val == undefined)
        return ""
    else
        return val;
}
//#endregion
//#region api
//function resolveresult(url, data) {
    
//    postaction(url,data).then(function (date) {
//        return data;

//    }).catch(function (error) {
//        return error;
//    })
//}

function postaction_webservice(url, datamodel) {
 
    //new Promise(function (resolveresult, rejectresult) {
       let jqXHR= $.ajax({
            type: "POST",
            async: false,
            cache: false,
            timeout:3000,
            contentType: "application/json",
            url: url,
            dataType: "json",
           data: datamodel,
           
        })
            //.done(function (data) {
            //    //
            //    //return JSON.parse(data.d);
            //    //if (JSON.parse(data.d).errorid != 0) {
            //    //    alert(JSON.parse(data.d).errormsg)
            //    //}
            //    //else {

            //    //    if (redirecturl!="") {
            //    //    location.href = redirecturl
            //    //    }

            //    //}

            //    //console.log("success");
            //    // console.log(data); // This returns the whole html page's markup
            //})
            //.fail(function (jqXHR, textStatus, c) {
            //    //return false;
            //    //console.log("failure");
            //    //console.log(textStatus);
     //});
     
     return JSON.parse(jqXHR.responseJSON.d)
 

     //})
}

//function postaction(url, datamodel) {
    
//    //new Promise(function (resolveresult, rejectresult) {
//    let jqXHR = $.ajax({
//        type: "post",
//        async: false,
//        cache: false,
//        timeout: 3000,
//        contentType: "application/json; charset=utf-8",
//        url: settingobj.baseurl+url,
//        dataType: "json",
//        data:JSON.stringify(datamodel),

//    })
//    //.done(function (data) {
//    //    //
//    //    //return JSON.parse(data.d);
//    //    //if (JSON.parse(data.d).errorid != 0) {
//    //    //    alert(JSON.parse(data.d).errormsg)
//    //    //}
//    //    //else {

//    //    //    if (redirecturl!="") {
//    //    //    location.href = redirecturl
//    //    //    }

//    //    //}

//    //    //console.log("success");
//    //    // console.log(data); // This returns the whole html page's markup
//    //})
//    //.fail(function (jqXHR, textStatus, c) {
//    //    //return false;
//    //    //console.log("failure");
//    //    //console.log(textStatus);
//    //});

//    return jqXHR.responseJSON.Data


//    //})
//}
//function deleteAction(url, datamodel) {
    
//    //new Promise(function (resolveresult, rejectresult) {
//    let jqXHR = $.ajax({
//        type: "Delete",
//        async: false,
//        cache: false,
//        timeout: 3000,
//        contentType: "application/json; charset=utf-8",
//        url: settingobj.baseurl + url,
//        dataType: "json",
//        data:JSON.stringify( datamodel),

//    })
//    //.done(function (data) {
//    //    //
//    //    //return JSON.parse(data.d);
//    //    //if (JSON.parse(data.d).errorid != 0) {
//    //    //    alert(JSON.parse(data.d).errormsg)
//    //    //}
//    //    //else {

//    //    //    if (redirecturl!="") {
//    //    //    location.href = redirecturl
//    //    //    }

//    //    //}

//    //    //console.log("success");
//    //    // console.log(data); // This returns the whole html page's markup
//    //})
//    //.fail(function (jqXHR, textStatus, c) {
//    //    //return false;
//    //    //console.log("failure");
//    //    //console.log(textStatus);
//    //});

//    return jqXHR.responseJSON.Data


//    //})
//}


//#endregion

function delData(url, id, hf) {
    let hf_val = 0;
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
            if ($("#" + hf + "").val() == "") {
                $("#" + hf + "").val(0)
           
            }
            else {
                hf_val = $("#" + hf + "").val();
            }
            let res = postaction_webservice(webmetodobj.baseurl2 + url, '{ ' + id + ':' + hf_val + '}')
            if (res.errorid == 0) {
                swalWithBootstrapButtons.fire(
                    'الحذف',
                    'تم الحذف بنجاح',
                    'success'
                )
                window.setTimeout(function () { window.location.reload() }, 900);
            }
            else {
                sweetexception(res.errormsg);
            };
        }
        else if (result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire(
                'إلغاء',
                'تم إلغاء عملية الحذف',
                'error'
            )
        }
    })
}
function DelData_Master(url, hf) {
    let hf_val = 0;
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
            if ($("#" + hf + "").val() == "") {
                $("#" + hf + "").val(0)

            }
            else {
                hf_val = $("#" + hf + "").val();
            }
            let res = deleteAction(url,hf_val )
            if (res.errorid == 0) {
                swalWithBootstrapButtons.fire(
                    'الحذف',
                    'تم الحذف بنجاح',
                    'success'
                )
                window.setTimeout(function () { window.location.reload() }, 900);
            }
            else {
                sweetexception(res.errormsg);
            };
        }
        else if (result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire(
                'إلغاء',
                'تم إلغاء عملية الحذف',
                'error'
            )
        }
    })
}
/////////// delete data from grid  mano
function delData_Dtl(url, id, hf,gvname) {
    let hf_val = 0;
    let swalWithBootstrapButtons = Swal.mixin({
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
        
         
            if (nullToEmpty( $("#" + hf + "").val()) == "") {
                $("#" + hf + "").val(0)
             
            }
            else {
                hf_val = $("#" + hf + "").val();
            }
            let res = postaction_webservice(webmetodobj.baseurl2 + url, '{ ' + id + ':' + hf_val + '}')

            if (res.errorid == 0) {

                //alert("تم الحذف")
                //var gv = gvname;
                gvname.PerformCallback();
                
               // gvs_transdtls.remove();
               // swalWithBootstrapButtons.fire(
               //     'الحذف',
               //     'تم الحذف بنجاح',
               //     'success'
               // )
               //// window.setTimeout(function () { window.location.reload() }, 1000);
              
            }
            else {


                sweetexception(res.errormsg);

            }
            ;
            // location.href=PageName

        }
        else if (

            result.dismiss === Swal.DismissReason.cancel
        ) {

            swalWithBootstrapButtons.fire(
                'إلغاء',
                'تم إلغاء عملية الحذف',
                'error'
            )
            // return false;
        }
    })
}
function delData_Detail(url, id, hf, gvname) {
    let hf_val = 0;
    let swalWithBootstrapButtons = Swal.mixin({
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


            if (nullToEmpty($("#" + hf + "").val()) == "") {
                $("#" + hf).val(0)

            }
            else {
                hf_val = $("#" + hf).val();
            }
       

            let res = deleteAction(url, hf_val)
            
            if (res.errorid == 0) {

                //alert("تم الحذف")
                //var gv = gvname;
                $("#" + hf).val(0)
                gvname.PerformCallback();

                // gvs_transdtls.remove();
                // swalWithBootstrapButtons.fire(
                //     'الحذف',
                //     'تم الحذف بنجاح',
                //     'success'
                // )
                //// window.setTimeout(function () { window.location.reload() }, 1000);

            }
            else {


                sweetexception(res.errormsg);

            }
            ;
            // location.href=PageName

        }
        else if (

            result.dismiss === Swal.DismissReason.cancel
        ) {

            swalWithBootstrapButtons.fire(
                'إلغاء',
                'تم إلغاء عملية الحذف',
                'error'
            )
            // return false;
        }
    })
}
let serachmodel = {
    TableName: (typeof(obj))!="undefined"?$(obj).data("tablename"):null
    , SearchVal: null
}
var popupres = {};

function createPopUpQuickInsert(obj,grd,rowindx) {



    // __doPostBack('btn_search',"")
    //let popuphtml = '<div onclose="refreshData($(this))" class="modal" id="' + modalid+'" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true">'
    //popuphtml += '<div class="modal-dialog" role="alertdialog">' +
    //    '<div class="modal-content" style = "height:300px;min-height:300px" >' +
    //    '<div class="modal-header">' +
    //    '<h5 class="modal-title" id="popupModalLabel"> بحث</h5>' +
    //    '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
    //    '<span aria-hidden="true">&times;</span>' +
    //    '</button>' +
    //    '</div>' +
    //    '<div class="modal-body" >' +
    //    '<div class="form-group row">' +
    //    '<div class="col-md-10">'
    //    + '<input type="text" id="txt_search" onkeydown="searchitm(event)"   placeholder="بحث" class="form-control" />' +
    //    '</div>' +
    //    '<div class="col-md-2">' +

    //    '<button type="button" class="btn btn-md btn-outline-success col-md-12" onclick="searchItmPopUp()"><i class="fas fa-search"></i></button>' +
    //    '</div>' +
    //    '</div>' +

    //    '<div class="row" style="margin-top:10px">' +
    //    '<div id="grd_search"></div>' +


    //    '</div>' +
    //    '</div>' +
    //    '</div>' +
    //    '</div>'

    //-----------------
    //$('#contentmodal').html(popuphtml);
    

    serachmodel = {
        TableName: $(obj).data("tablename")
        , SearchVal: null
    }
    $('#popupModalsearchdef').data("name", $(obj).data('name'))
    if (nullToEmpty($(obj).data('paramaternames')) != "") {
        let paramnamessearch = $(obj).data('paramaternames').split(",");
        if (paramnamessearch != "") {


            for (var i = 0; i < paramnamessearch.length; i++) {
                var paraname = paramnamessearch[i].split("_")[1];
                let ctl = typeof (ASPxClientControl) != "undefined" ? ASPxClientControl.GetControlCollection().GetByName(paramnamessearch[i]) : null
                let paramval;
                if (ctl == null) {
                    paramval = $('#' + paramnamessearch[i]).val()
                }
                else {
                    paramval = ctl.GetValue()
                }
                serachmodel[paraname] = paramval;
            }
        }
    }
    popupurl = $(obj).data("apiurl");
    let griddatasearch = getAction(popupurl, serachmodel)

    $("#grd_search").dxDataGrid({
        dataSource: griddatasearch,
        selection: {
            mode: "single"
        },
        paging: {
            pageSize: 5
        },
        // hoverStateEnabled: true,
        columns: createColumnsearch(obj),
        showBorders: true,
           focusedRowEnabled: true
        , onRowDblClick: function (e) {

            var selectedrow = e.data
            
            let fielsname = $(obj).data("bindfields").split(';')
         
            //if (nullToEmpty($(obj).data("bindcontrols")) != "") {

           
               
                for (var i = 0; i < fielsname.length; i++) {
                  
                    grd.batchEditApi.SetCellValue(rowindx, fielsname[i], selectedrow[fielsname[i]])
                    popupres[fielsname[i]] = selectedrow[fielsname[i]];   
                                  }
            //}
            //else {
            //    for (var i = 0; i < fielsname.length; i++) {
            //        popupres[fielsname[i]] = selectedrow[fielsname[i]];
            //    }

            //}
            modalClosingMethod = "bygrid";
            $('#popupModalsearchdef').modal('hide')
        },
        onFocusedCellChanging: function (e) {
            e.isHighlighted = false;
        }
        ,
        onKeyDown: function (e) {
            alert(e.event.keyCode)
            if (e.event.keyCode == 13) {
                let selectedrow = e.component.getSelectedRowKeys()[0]
             
                let fielsname = $(obj).data("bindfields").split(';')
                if (nullToEmpty($(obj).data("bindcontrols")) != "") {



                    for (var i = 0; i < fielsname.length; i++) {

                        grd.batchEditApi.SetCellValue(rowindx, fielsname[i], selectedrow[fielsname[i]])

                    }
                }
                else {
                    for (var i = 0; i < fielsname.length; i++) {
                        popupres[fielsname[i]] = selectedrow[fielsname[i]];
                    }

                }
                modalClosingMethod = "bygrid";
                $('#popupModalsearchdef').modal('hide')
            }
            else {

                
                var selKey = e.component.getSelectedRowKeys();
                if (selKey.length) {
                    var currentKey = selKey[0];
                    var index = e.component.getRowIndexByKey(currentKey);
                    if (e.event.keyCode == 38) {
                        index--;
                        if (index >= 0) {
                            e.component.selectRowsByIndexes([index]);

                        }
                        else {
                            e.component.selectRowsByIndexes($("#grd_search").dxDataGrid('instance').getVisibleRows().length-1);
                        }
                        //   e.jQueryEvent.stopPropagation();
                    }
                    else if (e.event.keyCode == 40) {
                        index++;
                        if (index > $("#grd_search").dxDataGrid('instance').getVisibleRows().length-1) {
                            e.component.selectRowsByIndexes([0]);
                        }
                        else {
                            e.component.selectRowsByIndexes([index]);
                        }

                        // e.jQueryEvent.stopPropagation();
                    }
                }
            }
        }
        ,
        onCellPrepared: function onCellPrepared(e) {

            if (e.rowType == "header" || e.rowType == "data") {
                e.cellElement.css("text-align", "right");
            }

            // ...  
        },
    });
    //-----------------

    $('#popupModalsearchdef').modal('show')

    $('#txt_search').val(null)
    $('#txt_search').focus()
}
let objid="";
function navigategrd(e) {
    if (document.activeElement.id != "txt_search") {


        let code = (e.keyCode ? e.keyCode : e.which);


        var selKey = $("#grd_search").dxDataGrid('instance').getSelectedRowKeys();
        if (code == 13) {
            var selectedrow = $("#grd_search").dxDataGrid('instance').getSelectedRowsData()[0]
            let fielsname = $('#' + objid).data("bindfields").split(';')
            if (nullToEmpty($('#' + objid).data("bindcontrols")) != "") {


                let displaycontrols_search = $('#' + objid).data("bindcontrols").split(';')
                for (var i = 0; i < displaycontrols_search.length; i++) {
                    let ctl = typeof (ASPxClientControl) != "undefined" ? ASPxClientControl.GetControlCollection().GetByName(displaycontrols_search[i]) : null

                    if (ctl == null) {
                        $('#' + displaycontrols_search[i]).val(selectedrow[fielsname[i]])
                    }
                    else {
                        if (typeof (ASPxClientDateEdit) != "undefined" && ctl instanceof ASPxClientDateEdit) {
                            ctl.SetValue(new Date(selectedrow[fielsname[i]]));
                        }
                        else {
                            ctl.SetValue(selectedrow[fielsname[i]]);
                        }
                        //SetDxControlVal(ctl, selectedrow[fielsname[i]])
                    }
                }
            }
            else {
                for (var i = 0; i < fielsname.length; i++) {
                    popupres[fielsname[i]] = selectedrow[fielsname[i]];
                }

            }
            modalClosingMethod = "bygrid";
            $('#popupModalsearchdef').modal('hide')
        }
        else {


            if (selKey.length) {
                var currentKey = selKey[0];
                var index = $("#grd_search").dxDataGrid('instance').getRowIndexByKey(currentKey);
                if (code == 38) {
                    index--;
                    if (index >= 0) {
                        $("#grd_search").dxDataGrid('instance').selectRowsByIndexes([index]);

                    }
                    else {
                        $("#grd_search").dxDataGrid('instance').selectRowsByIndexes($("#grd_search").dxDataGrid('instance').getVisibleRows().length - 1);
                    }
                    //   e.jQueryEvent.stopPropagation();
                }
                else if (code == 40) {
                    index++;
                    if (index > $("#grd_search").dxDataGrid('instance').getVisibleRows().length - 1) {
                        $("#grd_search").dxDataGrid('instance').selectRowsByIndexes([0]);
                    }
                    else {
                        $("#grd_search").dxDataGrid('instance').selectRowsByIndexes([index]);
                    }

                    // e.jQueryEvent.stopPropagation();
                }
            }

        }
    }
}
//region popup
function createPopUp(obj) {

   

    // __doPostBack('btn_search',"")
    //let popuphtml = '<div onclose="refreshData($(this))" class="modal" id="' + modalid+'" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true">'
    //popuphtml += '<div class="modal-dialog" role="alertdialog">' +
    //    '<div class="modal-content" style = "height:300px;min-height:300px" >' +
    //    '<div class="modal-header">' +
    //    '<h5 class="modal-title" id="popupModalLabel"> بحث</h5>' +
    //    '<button type="button" class="close" data-dismiss="modal" aria-label="Close">' +
    //    '<span aria-hidden="true">&times;</span>' +
    //    '</button>' +
    //    '</div>' +
    //    '<div class="modal-body" >' +
    //    '<div class="form-group row">' +
    //    '<div class="col-md-10">'
    //    + '<input type="text" id="txt_search" onkeydown="searchitm(event)"   placeholder="بحث" class="form-control" />' +
    //    '</div>' +
    //    '<div class="col-md-2">' +

    //    '<button type="button" class="btn btn-md btn-outline-success col-md-12" onclick="searchItmPopUp()"><i class="fas fa-search"></i></button>' +
    //    '</div>' +
    //    '</div>' +

    //    '<div class="row" style="margin-top:10px">' +
    //    '<div id="grd_search"></div>' +


    //    '</div>' +
    //    '</div>' +
    //    '</div>' +
    //    '</div>'

    //-----------------
    //$('#contentmodal').html(popuphtml);
    

     serachmodel = {
        TableName: $(obj).data("tablename")
        , SearchVal: null
    }
    objid = $(obj).attr("id");
    $('#popupModalsearchdef').data("name", $(obj).data('name'))
    if (nullToEmpty($(obj).data('paramaternames')) != "") {
        let paramnamessearch = $(obj).data('paramaternames').split(",");
        if (paramnamessearch != "") {


            for (var i = 0; i < paramnamessearch.length; i++) {
                var paraname = paramnamessearch[i].split("_")[1];
                let ctl = typeof (ASPxClientControl) != "undefined" ?ASPxClientControl.GetControlCollection().GetByName(paramnamessearch[i]):null
                let paramval;
                if (ctl == null) {
                    paramval = $('#' + paramnamessearch[i]).val()
                }
                else {
                    paramval = ctl.GetValue()
                }
                serachmodel[paraname] = paramval;
            }
        }
    }
    popupurl = $(obj).data("apiurl");
    let griddatasearch = getAction(popupurl, serachmodel)

    $("#grd_search").dxDataGrid({
        dataSource: griddatasearch,
        selection: {
            mode: "single"
        },
        keyExpr: $(obj).data("pkfield"),
        paging: {
            pageSize: 10
        },
       // hoverStateEnabled: true,
        columns: createColumnsearch(obj),
        showBorders: true//,
               // focusedRowEnabled: true
        , onRowDblClick: function (e) {

            var selectedrow = e.data
            let fielsname = $(obj).data("bindfields").split(';')
            if (nullToEmpty($(obj).data("bindcontrols"))!="") {

            
            let displaycontrols_search = $(obj).data("bindcontrols").split(';')
            for (var i = 0; i < displaycontrols_search.length; i++) {
                let ctl = typeof (ASPxClientControl) != "undefined" ? ASPxClientControl.GetControlCollection().GetByName(displaycontrols_search[i]) :null

                if (ctl == null) {
                    $('#' + displaycontrols_search[i]).val(selectedrow[fielsname[i]])
                }
                else {
                    if (typeof (ASPxClientDateEdit) != "undefined" && ctl instanceof ASPxClientDateEdit) {
                        ctl.SetValue(new Date(selectedrow[fielsname[i]]));
                    }
                    else {
                        ctl.SetValue(selectedrow[fielsname[i]]);
                    }
                    //SetDxControlVal(ctl, selectedrow[fielsname[i]])
                }
                }

                for (var i = 0; i < fielsname.length; i++) {
                    popupres[fielsname[i]] = selectedrow[fielsname[i]];
                }
               
            }
            else {
               
                for (var i = 0; i < fielsname.length; i++) {
                    popupres[fielsname[i]] = selectedrow[fielsname[i]];
                } 
            }
            modalClosingMethod = "bygrid";
            $('#popupModalsearchdef').modal('hide')
        },
        onFocusedCellChanging: function (e) {
            e.isHighlighted = false;
        }  
        ,
        onKeyDown: function (e) {
          
            if (e.event.keyCode==13) {
                var selectedrow = e.component.getSelectedRowsData()[0]
                let fielsname = $(obj).data("bindfields").split(';')
                if (nullToEmpty($(obj).data("bindcontrols")) != "") {


                    let displaycontrols_search = $(obj).data("bindcontrols").split(';')
                    for (var i = 0; i < displaycontrols_search.length; i++) {
                        let ctl = typeof (ASPxClientControl) != "undefined" ? ASPxClientControl.GetControlCollection().GetByName(displaycontrols_search[i]) : null

                        if (ctl == null) {
                            $('#' + displaycontrols_search[i]).val(selectedrow[fielsname[i]])
                        }
                        else {
                            if (typeof (ASPxClientDateEdit) != "undefined" && ctl instanceof ASPxClientDateEdit) {
                                ctl.SetValue(new Date(selectedrow[fielsname[i]]));
                            }
                            else {
                                ctl.SetValue(selectedrow[fielsname[i]]);
                            }
                            //SetDxControlVal(ctl, selectedrow[fielsname[i]])
                        }
                    }
                }
                else {
                    for (var i = 0; i < fielsname.length; i++) {
                        popupres[fielsname[i]] = selectedrow[fielsname[i]];
                    }

                }
                modalClosingMethod = "bygrid";
                $('#popupModalsearchdef').modal('hide')
            }
            else {

        
                var selKey = e.component.getSelectedRowKeys();
                var currentpageindex = e.component.pageIndex();
               
            if (selKey.length) {
                var currentKey = selKey[0];
                var index = e.component.getRowIndexByKey(currentKey);
                switch (e.event.keyCode) {
                    
                    case 38:
                        index--;
                        if (index >= 0) {
                            e.component.selectRowsByIndexes([index]);

                        }
                        else {
                            e.component.selectRowsByIndexes($("#grd_search").dxDataGrid('instance').getVisibleRows().length - 1);
                        }
                        break;
                    case 40:
                        index++;
                        if (index > $("#grd_search").dxDataGrid('instance').getVisibleRows().length - 1) {
                            e.component.selectRowsByIndexes([0]);
                        }
                        else {
                            e.component.selectRowsByIndexes([index]);
                        }
                        break;

                    case 37:
                        if (currentpageindex < e.component.pageCount() - 1) {
                            e.component.pageIndex(currentpageindex + 1)
                        }
                        break;
                    case 39:
                        if (currentpageindex > 0) {
                            e.component.pageIndex(currentpageindex - 1);
                        }
                        break;
                
                    default:
                }
                if (e.event.keyCode == 38) {
                   
                 //   e.jQueryEvent.stopPropagation();
                }
                else if (e.event.keyCode == 40) {
             
                  
                   // e.jQueryEvent.stopPropagation();
                }
                }
            else {
              
                switch (e.event.keyCode) {
                  
                    case 39:
                        if (currentpageindex < e.component.pageCount - 1) {
                            e.component.pageIndex(currentpageindex + 1)
                        }
                        break;
                    case 37:
                        if (currentpageindex < 0) {
                            e.component.pageIndex(currentpageindex - 1);
                        }
                        break;
                    default:
                }
            }
            }
        }
        ,
        onCellPrepared: function onCellPrepared(e) {

            if (e.rowType == "header" || e.rowType == "data") {
                e.cellElement.css("text-align", "right");
            }

            // ...  
        },
    });
    //-----------------

    $('#popupModalsearchdef').modal('show')

    $('#txt_search').val(null)
    $('#txt_search').focus()
}
let griddatasearch;

//$('#popupModalsearchdef').on('show.bs.modal', function (e) {
//
//    txt_search.SetValue(null)
//    let serachmodel = {
//        TableName: $(obj).data("tablename")
//        , SearchVal: nullToEmpty(txt_search.GetValue())
//    }
//    if (nullToEmpty( $(obj).data("paramaternames"))!="") {

    
//    let paramnamessearch = $(obj).data("paramaternames").split(",");
//    if (paramnamessearch != "") {
//        for (var i = 0; i < paramnamessearch.length; i++) {
//            var paraname = paramnamessearch[i].split("_")[1];
//            let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnamessearch[i])
//            let paramval;
//            if (ctl == null) {
//                paramval = $('#' + paramnamessearch[i]).val()
//            }
//            else {
//                paramval = ctl.GetValue()
//            }
//            serachmodel[paraname] = paramval;
//        }
//    }
//}

//    let griddatasearch = getAction($(obj).data("apiurl"), serachmodel)

//    $("#grd_search").dxDataGrid({
//        dataSource: griddatasearch,
//        selection: {
//            mode: "single"
//        },
//        paging: {
//            pageSize: 5
//        },
//        hoverStateEnabled: true,
//        columns: createColumnsearch(),
//        showBorders: true
//        , onRowDblClick: function (e) {


//            var selectedrow = e.data
//            let fielsname = $(obj).data("bindfields").split(';')
//            let displaycontrols_search = $(obj).data("bindcontrols").split(';')
//            for (var i = 0; i < displaycontrols_search.length; i++) {
//                let ctl = ASPxClientControl.GetControlCollection().GetByName(displaycontrols_search[i])

//                if (ctl == null) {
//                    $('#' + displaycontrols_search[i]).val(selectedrow[fielsname[i]])
//                }
//                else {
//                    if (typeof (ASPxClientDateEdit) != "undefined" && ctl instanceof ASPxClientDateEdit) {
//                        ctl.SetValue(new Date(selectedrow[fielsname[i]]));
//                    }
//                    else {
//                        ctl.SetValue(selectedrow[fielsname[i]]);
//                    }
//                    //SetDxControlVal(ctl, selectedrow[fielsname[i]])
//                }
//            }
//            $('#popupModalsearchdef').modal('hide')
//        },
//        onCellPrepared: function onCellPrepared(e) {

//            if (e.rowType == "header" || e.rowType == "data") {
//                e.cellElement.css("text-align", "right");
//            }

//            // ...  
//        },
//    });
//});


function searchitm(e) {

    let code = (e.keyCode ? e.keyCode : e.which);
    if (code==13) {

    
    serachmodel["SearchVal"] = nullToEmpty($('#txt_search').val())
    let griddatasearch = getAction(popupurl, serachmodel)
    $("#grd_search").dxDataGrid('instance').option('dataSource', griddatasearch)
    }
    else if (code == 9) {
      //  $("#grd_search").dxDataGrid('instance').selectRowsByIndexes(0)
        $("#grd_search").dxDataGrid('instance').focusedRowIndex = 0
    }
}
function createColumnsearch(obj) {
    let columns = []
    let displaycontrols_search = $(obj).data("displayfields").split(',')

    for (var i = 0; i < displaycontrols_search.length; i++) {
        let columndetails = {};

        let captioncolumn = $(obj).data('displayfieldscaption').split(",");



        columndetails["caption"] = captioncolumn[i];

        columndetails["dataField"] = displaycontrols_search[i]

        //columndetails["dataField"] = fields[i]
        columns.push(columndetails)
    }
    let hiddencolumn = $(obj).data('displayfieldshidden').split(",");
    for (var i = 0; i < hiddencolumn.length; i++) {
        let columndetails = {};
        columndetails["dataField"] = hiddencolumn[i]
        columndetails["visible"] = false
        columns.push(columndetails)
    }

    return columns;
}

$("#txt_search").on('keydown', function (e) {

    if (e.key === 'Enter' || e.keyCode === 13) {
   


            serachmodel["SearchVal"] = nullToEmpty($('#txt_search').val())
            let griddatasearch = getAction($(obj).data("apiurl"), serachmodel)
            $("#grd_search").dxDataGrid('instance').option('dataSource', griddatasearch)
        
    }
});
//function searchitm(event) {
//
//    //  var keycode = (event. event.keyCode ? event.keyCode : event.which);
//    if (event.keyCode == '13') {
//        serachmodel["SearchVal"] = nullToEmpty($('#txt_search').val())
//        let griddatasearch = getAction($(obj).data("apiurl"), serachmodel)
//        $("#grd_search").dxDataGrid('instance').option('dataSource', griddatasearch)
//    }
//}

function searchItmPopUp() {

    //  var keycode = (event. event.keyCode ? event.keyCode : event.which);

   
 serachmodel["SearchVal"]=nullToEmpty($('#txt_search').val())
   
    //if (nullToEmpty($(obj).data('paramaternames')) != "") {
    //    let paramnamessearch = $(obj).data('paramaternames').split(",");
    //    if (paramnamessearch != "") {


    //        for (var i = 0; i < paramnamessearch.length; i++) {
    //            var paraname = paramnamessearch[i].split("_")[1];
    //            let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnamessearch[i])
    //            let paramval;
    //            if (ctl == null) {
    //                paramval = $('#' + paramnamessearch[i]).val()
    //            }
    //            else {
    //                paramval = ctl.GetValue()
    //            }
    //            serachmodel[paraname] = paramval;
    //        }
    //    }
    //}
    let griddatasearch = getAction(popupurl, serachmodel)
    $("#grd_search").dxDataGrid('instance').option('dataSource', griddatasearch)

}
//end region


