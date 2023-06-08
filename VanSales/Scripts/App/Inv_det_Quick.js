/// <reference path="base/devexpressjshelper.js" />

//#region grid
$(function () {
    token = GetToken();
})
function setCellValueByIndex(res) {
    rowindex=  gvs_invdtlsquick.focusedRowIndex
    if (rowindex < 0) {
        gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "qty", 1, null, true);
        gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "discp", 0, null, true);
        gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "discvalue", 0, null, true);
    }
    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "unitid", res["unitid"], null, true);
    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "unitname", res["unitname"], null, true);
    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "itemcode", res["itemcode"], null, true);
    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "itemname", res["itemname"], null, true);
    debugger
    if (token.vattype="1") {
        gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "price", (res["fprice"] * 100) /  (parseFloat( token.vat)+ 100), null, true);
    }
    else {
        gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "price", res["fprice"] , null, true);
    }

    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "factor", res["factor"], null, true);
    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "itemid", res["itemid"], null, true);
    gvs_invdtlsquick.batchEditApi.StartEdit(rowindex, gvs_invdtlsquick.GetColumnByField("qty").index)
    let qty = nullToDecimalZero(gvs_invdtlsquick.batchEditApi.GetCellValue(rowindex, gvs_invdtlsquick.GetColumnByField("qty")));
    let price =nullToDecimalZero(gvs_invdtlsquick.batchEditApi.GetCellValue(rowindex, gvs_invdtlsquick.GetColumnByField("price")));
    
    let disc = nullToDecimalZero(gvs_invdtlsquick.batchEditApi.GetCellValue(rowindex, gvs_invdtlsquick.GetColumnByField("disc")));
    let discval = 0;
    let val = 0;
    let netval = 0;
    let vatval = 0;
   

 
        val = qty * price;
 
    if (disc != 0 && disc != null && disc != undefined) {

        discval = val * nullToDecimalZero(disc / 100);
        gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "discvalue", discval, null, true);
        vatval = nullToDecimalZero(nullToDecimalZero(token.vat / 100) * (parseFloat(val) - parseFloat(discval)))
        netval = parseFloat(val) - parseFloat(discval) + (token.vattype == 1 ? 0 : parseFloat(vatval))
    }
    else {
        val = qty * price;
        discval = nullToDecimalZero(gvs_invdtlsquick.batchEditApi.GetCellValue(rowindex, gvs_invdtlsquick.GetColumnByField("discvalue")));
        vatval = nullToDecimalZero(nullToDecimalZero(token.vat / 100) * (val - discval))
        netval = parseFloat(val) - parseFloat(discval) +(token.vattype==1?0: parseFloat(vatval))
    }

    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "value", val, null, true);
    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "netvalue", netval, null, true);
    gvs_invdtlsquick.batchEditApi.SetCellValue(rowindex, "vatvalue", vatval, null, true);

}
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        setCellValueByIndex(popupres);
       
    }
})
let rowindex;
function OnValidation(s, e) {
  
    var grid = ASPxClientGridView.Cast(s);
    var cellInfo1 = e.validationInfo[grid.GetColumnByField("qty").index];
  //  var cellInfo2 = e.validationInfo[grid.GetColumnByField("HireDate").index];
  //  var years = CheckYears(cellInfo1.value, cellInfo2.value);
    if (nullToDecimalZero( cellInfo1.value)==0) {
        cellInfo1.isValid = false;
      //  cellInfo2.isValid = false;
      //  cellInfo2.errorText = "Invalid difference between Hire Date and Birth Date";
        cellInfo1.errorText = "";
    } else {
        cellInfo1.isValid = true;
        //cellInfo2.isValid = true;
    }
}
function initnewval(s, e) {
    //var columninvid = s.GetColumnByField("invdtlid");
    if (!isgridvalid) {
        ecancel = true;
    }
    rowindex=e.visibleIndex
    //let columnpriceIndex = columninvid.index;

    //e.rowValues[columnpriceIndex].value = 0;
    //s.batchEditApi.SetCellValue(e.visibleIndex, "invdtlid", 0, null, true);
    //s.batchEditApi.SetCellValue(e.visibleIndex, "qty", 0, null, true);
    //s.batchEditApi.SetCellValue(e.visibleIndex, "price", 0, null, true);
}
function batchEditStart(s, e) {
    rowindex = e.visibleIndex;
    if (e.focusedColumn.fieldName == "" || e.focusedColumn.fieldName == "vatvalue" ||
        e.focusedColumn.fieldName == "netvalue" || e.focusedColumn.fieldName == "value" || e.focusedColumn.fieldName == "unitname"
        || e.focusedColumn.fieldName == "discvalue" || e.focusedColumn.fieldName == "invdtlid" || e.focusedColumn.fieldName == "itemname"){
        e.cancel = true;
    }

}
$(function () {
    
    let indices = gvs_invdtlsquick.batchEditApi.GetRowVisibleIndices()
    for (let i = 0; i < indices.length; i++) {
        let netval = gvs_invdtlsquick.batchEditApi.GetCellValue(i, "netvalue")
        let vatval = gvs_invdtlsquick.batchEditApi.GetCellValue(i, "vatvalue");
        let vatprcnt =nullToDecimalZero( nullToDecimalZero(vatval / netval));
        gvs_invdtlsquick.batchEditApi.SetCellValue(i, "vatprcnt", vatprcnt, null, true);
    }

})
function setCellSumition(s,e)
{
    let indx = rowindex;
    let columnqty = gvs_invdtlsquick.GetColumnByField("qty");
    let columnprice = gvs_invdtlsquick.GetColumnByField("price");
    let columndisprcnt = gvs_invdtlsquick.GetColumnByField("discp");
    let columndisval = gvs_invdtlsquick.GetColumnByField("discvalue");


    let columnqtyIndex = columnqty.index;
    let columnpriceIndex = columnprice.index;
    let columndisprcntIndex = columndisprcnt.index;

    let qu = e.rowValues[columnqtyIndex].value
    let prc = e.rowValues[columnpriceIndex].value

    let disprcntval_col = e.rowValues[columndisprcntIndex].value
    let totalval = totalPrice(qu, prc)
    gvs_invdtlsquick.batchEditApi.SetCellValue(indx, "value", totalval, null, true);
    let disval = percentValue(disprcntval_col, totalval)
    gvs_invdtlsquick.batchEditApi.SetCellValue(indx, "discvalue", disval, null, true);
    let netafterdiscount = netValAfterDisPercentValue(disprcntval_col, totalval, true)
 

    let columnvatprcnt = gvs_invdtlsquick.GetColumnByField("vatprcnt");
    let columnvatprcntindx = columnvatprcnt.index;
    let columnvatprcntval =token.vat/100// e.rowValues[columnvatprcntindx].value
    let vatval = nullToDecimalZero(netafterdiscount * nullToDecimalZero(columnvatprcntval))
    gvs_invdtlsquick.batchEditApi.SetCellValue(indx, "netvalue", token.vattype == 1 ? netafterdiscount :parseFloat( netafterdiscount + vatval), null, true);
    gvs_invdtlsquick.batchEditApi.SetCellValue(indx, "vatvalue", vatval, null, true);
}
function savedata(s, e) {
    let urlproc = "";
    let invdetlst = [];
    let invdetrecord = {};
    //s.batchEditHelper.EndEdit()
    ['itemid', 'invdtlid', 'unitname', 'itemcode', 'unitid', 'itemname', 'factor', 'qty', 'price', 'value', 'discp', 'discvalue', 'netvalue','vatvalue'].forEach(function (column) {
        if (column == e.focusedColumn.fieldName) {
            let column_c = s.GetColumnByField(column);
            let column_Index = column_c.index;
            invdetrecord[column] = e.rowValues[column_Index].value
        }
        else {
            invdetrecord[column] = s.batchEditApi.GetCellValue(e.visibleIndex, s.GetColumnByField(column));;
        }
        
        //if (GridHR_C_TypeOp_d.batchEditApi.IsDeletedRow(indices[i])) {
        //    HR_Op_dList.push(newHR_C_TypeOp_d);

    })
    invdetrecord["sinvno"] = $('#invnum').val();
    invdetrecord["sinvid"] = $('#invid').val();
    invdetlst.push(invdetrecord)

    //let jsondata = JSON.stringify(invdetrecord);

    urlproc = postaction("/VanSalesService/invoice/addnewinvdet", invdetrecord);
   // alert(urlproc.invdetid)
    if (urlproc.Success == true && urlproc.outputparams.length!=0) {
        s.batchEditApi.SetCellValue(e.visibleIndex, "invdtlid", urlproc.outputparams["invdetid"], null, true);
    }
    //$.ajax({
    //    url: urlproc,
    //    method: "post",

    //    success: function (ss) {
    //        // alert(s)
    //        if (ss.success) {
            
    //            s.batchEditApi.SetCellValue(e.visibleIndex, "invdtlid", ss.invdetid, null, true);
    //        }

    //    }
    //})
}
function batchEditEndEditing(s, e) {
    

    //window.setTimeout(function () {
    if (e.focusedColumn.fieldName == "itemcode") {
        
        let columnitemcode = s.GetColumnByField("itemcode");
        let columnitemcodeindex = columnitemcode.index;
        let itemcodeval = e.rowValues[columnitemcodeindex].value
        let datamodel = { itemcode: itemcodeval, barcode1: itemcodeval, barcode2:itemcodeval}
        var res = getAction("/VanSalesService/items/GetItemSingalData", datamodel)
  
          
          

                if (res.length!=0) {
              
                    setCellValueByIndex(res[0])
                   
                   
       
                
                    
        }
                else {

                }

           
       
    }
    else {
        setCellSumition(s,e)
    }
    //setCellvalues(s, e)
    //if (isgridvalid) {

        savedata(s, e);
    //}

   
  



}
function deldata(s, e) {
  
    let res = deleteAction("/VanSalesService/invoice/DelinvDetail", e.key)
    if (res.Success == true) {


    }
    //$.ajax({
    //    url: "http://192.168.1.254:35/VanSalesService/invoice/DelinvDetail?key=" + e.key
    //    , method: "post",

    //    success: function (s) {
           
            
    //        if (s.success) {
    //          //  $('.alert').alert()
    //        }

    //    }
    //})
}
let isgridvalid = true;
function batchEditRowValidating(s, e) {

    //window.setTimeout(function () {
    //let indx = gvs_invdtlsquick.focusedRowIndex;
    //var qu = s.batchEditApi.GetCellValue(indx, "qty")
    //let prc = s.batchEditApi.GetCellValue(indx, "price")
    var grid = ASPxClientGridView.Cast(s);
    var cellInfo1 = e.validationInfo[grid.GetColumnByField("qty").index];
    var cellInfo2 = e.validationInfo[grid.GetColumnByField("itemcode").index];
    //  var cellInfo2 = e.validationInfo[grid.GetColumnByField("HireDate").index];
    //  var years = CheckYears(cellInfo1.value, cellInfo2.value);
    if (nullToDecimalZero(cellInfo1.value) == 0 ) {
        cellInfo1.isValid = isgridvalid=false;
        //  cellInfo2.isValid = false;
        //  cellInfo2.errorText = "Invalid difference between Hire Date and Birth Date";
        cellInfo1.errorText = "";
    } else {
        cellInfo1.isValid = isgridvalid=true;
        //cellInfo2.isValid = true;
    }

    if (isNull(cellInfo2.value)) {
        cellInfo2.isValid = isgridvalid = false;
        //  cellInfo2.isValid = false;
        //  cellInfo2.errorText = "Invalid difference between Hire Date and Birth Date";
        cellInfo2.errorText = "";
    } else {
        cellInfo2.isValid = isgridvalid = true;
        //cellInfo2.isValid = true;
    }
    //s.batchEditApi.SetCellValue(indx, "value", qu * prc)
}
//function ItemData(s, e) {
    

    
//    gvs_invdtlsquick.batchEditApi.SetCellValue(gvs_invdtlsquick.batchEditApi.GetEditCellInfo().rowVisibleIndex, "itemcode", s.GetSelectedItem().GetColumnText("itemcode"), null, true);
//    gvs_invdtlsquick.batchEditApi.SetCellValue(gvs_invdtlsquick.batchEditApi.GetEditCellInfo().rowVisibleIndex, "itemname", s.GetSelectedItem().GetColumnText("itemname"), null, true);
//    gvs_invdtlsquick.batchEditApi.SetCellValue(gvs_invdtlsquick.batchEditApi.GetEditCellInfo().rowVisibleIndex, "unitid", s.GetSelectedItem().GetColumnText("unitid"), null, true);
//    gvs_invdtlsquick.batchEditApi.SetCellValue(gvs_invdtlsquick.batchEditApi.GetEditCellInfo().rowVisibleIndex, "unitname", s.GetSelectedItem().GetColumnText("unitname"), null, true);
//    gvs_invdtlsquick.batchEditApi.SetCellValue(gvs_invdtlsquick.batchEditApi.GetEditCellInfo().rowVisibleIndex, "price", s.GetSelectedItem().GetColumnText("fprice"), null, true);
//    gvs_invdtlsquick.batchEditApi.SetCellValue(gvs_invdtlsquick.batchEditApi.GetEditCellInfo().rowVisibleIndex, "vatprcnt",nullToDecimalZero(s.GetSelectedItem().GetColumnText("vat")), null, true);
//  //let vatval =nullToDecimalZero( gvs_invdtlsquick.batchEditApi.GetCellValue(gvs_invdtlsquick.batchEditApi.GetEditCellInfo().rowVisibleIndex, "netvalue")) *
//  //      (nullToDecimalZero(s.GetSelectedItem().GetColumnText("vat"))/100)
//  //  
//  //  gvs_invdtlsquick.batchEditApi.SetCellValue(gvs_invdtlsquick.focusedRowIndex, "vatvalue", vatval)
//    //gvs_invdtlsquick.batchEditApi.SetCellValue(indx, "itemname", s.GetSelectedItem().GetColumnText("itemname"), null, true);
//}
//#endregion
//#region publice
function totalPrice(qu, price) {
    return nullToDecimalZero(qu * price);
}
function totalafterdiscount(totalval,  disval ) {
    return nullToDecimalZero( totalval-disval)
   
}


AddKeyboardNavigationTo(gvs_invdtlsquick);
function AddKeyboardNavigationTo(grid) {
    grid.BeginCallback.AddHandler(function (s, e) { gridPerformingCallback = true; });
    grid.EndCallback.AddHandler(function (s, e) { gridPerformingCallback = false; });
    ASPxClientUtils.AttachEventToElement(document, "keydown",
        function (evt) {
            return OnDocumentKeyDown(evt, grid);
        });
}

function OnDocumentKeyDown(evt, grid) {
    if (typeof (event) != "undefined" && event != null)
        evt = event;


    if ((evt.altKey && evt.keyCode == 65))//a || (evt.altKey && evt.keyCode == 46)
    {
     // alert("")
        grid.AddNewRow();
    }

    //if ((evt.altKey && evt.keyCode == 83) || (evt.altKey && evt.keyCode == 115))
    //    grid.UpdateEdit();

    ////if ((evt.altKey && evt.keyCode == 78) || (evt.altKey && evt.keyCode == 46))
    ////    grid.AddNewRow();

    //if ((evt.altKey && evt.keyCode == 83) || (evt.altKey && evt.keyCode == 115))
    //    grid.UpdateEdit();
    if (evt.keyCode == 13) //down
    {
  
        ASPxClientUtils.PreventEvent(evt.htmlEvent);
       
          
        
    }
    if (evt.ctrlKey && NeedProcessDocumentKeyDown(evt) && !gridPerformingCallback) {
        var currentIndex = grid.GetFocusedRowIndex();


        if (evt.keyCode == 40) //down
        {
            if (currentIndex == grid.GetVisibleRowsOnPage() - 1) {
                return ASPxClientUtils.PreventEvent(evt);
            }
            else {
                grid.SetFocusedRowIndex(currentIndex + 1);
            }
        }
        if (evt.keyCode == 38) {
            if (currentIndex == 0) {
                return ASPxClientUtils.PreventEvent(evt);
            }
            else {
                grid.SetFocusedRowIndex(currentIndex - 1);
            }
        }

    }
}


function NeedProcessDocumentKeyDown(evt) {

    var evtSrc = ASPxClientUtils.GetEventSource(evt);
    if (evtSrc.tagName == "INPUT")
        return evtSrc.type != "text" && evtSrc.type != "password";
    else
        return evtSrc.tagName != "TEXTAREA";
}
//#endregion