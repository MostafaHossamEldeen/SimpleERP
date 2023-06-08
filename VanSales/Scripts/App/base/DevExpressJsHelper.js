/// <reference path="../sales/inv.js" />
/// <reference path="helperjs.js" />


function decimale3num(s, event) {
  
    if ((event.htmlEvent.keyCode != 46 || s.GetValue().indexOf('.') != -1) &&
        ((event.htmlEvent.keyCode < 48 || event.htmlEvent.keyCode > 57) &&
            (event.htmlEvent.keyCode != 0 && event.htmlEvent.keyCode != 8))) {
        ASPxClientUtils.PreventEvent(event.htmlEvent);
    }
    if ((s.GetValue()!=null && s.GetValue().indexOf('.') != -1 && event.htmlEvent.keyCode==110) ||
        (event.htmlEvent.keyCode == 189 || event.htmlEvent.keyCode == 109) ||
        (event.htmlEvent.keyCode < 48 && event.htmlEvent.keyCode > 57) ||
        (event.htmlEvent.keyCode < 96 && event.htmlEvent.keyCode > 105)) {
        ASPxClientUtils.PreventEvent(event.htmlEvent);
    }
    var text = s.GetValue();
    if ((event.htmlEvent.keyCode == 46) && text!=null && (text.indexOf('.') == -1)) {
        setTimeout(function () {
            if (s.GetValue().substring(s.GetValue().indexOf('.')).length > 3) {
                s.GetValue(s.GetValue().substring(0, s.GetValue().indexOf('.') + 3));
            }
        }, 1);
    }

    //if ((text.indexOf('.') != -1) &&
    //    (text.substring(text.indexOf('.')).length > 3) &&
    //    (event.htmlEvent.keyCode != 0 && event.htmlEvent.keyCode != 8)// &&
    //    //($(this)[0].selectionStart >= text.length - 3)
    //)
    //{
    //    ASPxClientUtils.PreventEvent(event.htmlEvent);
    //}
}

function preventwrite(s, e) {
   
    //var key = e.htmlEvent.keyCode || e.htmlEvent.keyCode;
    //if (key == 8 || key == 46) {
    //    ASPxClientUtils.PreventEvent(e.htmlEvent);
    //    e.stopPropagation();
    //}

    ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
  
}

function preventwriteitemcode(s, e) {

    //var key = e.htmlEvent.keyCode || e.htmlEvent.keyCode;
    //if (key == 8 || key == 46) {
    //    ASPxClientUtils.PreventEvent(e.htmlEvent);
    //    e.stopPropagation();
    //}
    token = GetToken();
    if (token.autoitem=="True") {
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
    }
  

}

function numonly(sender, evt) {

    var text = sender.GetValue();

    var charCode = (evt.htmlEvent.keyCode) ? evt.htmlEvent.keyCode : evt.htmlEvent.keyCode

    if (

        (charCode != 45 || text.indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.

        (charCode < 48 || charCode > 57)) { ASPxClientUtils.PreventEvent(evt.htmlEvent); }  




}
 


function multInputsonly(currentval,res_input) {
     
    //var controls = ASPxClientControl.GetControlCollection();
    //for (var key in controls.elements) {
    //    var control = controls.elements[key];
    //    if (control != null && ASPxIdent.IsASPxClientEdit(control)) {
    //        if (control != s) {
    //            var parent = ASPxClientUtils.GetParentByClassName(control.GetMainElement(), "multi");
    //             
    //            if (parent != null) {
    //               alert("v")
    //            }
    //        }
    //    }
    //}
    let total = 0;
    //let currentval = [];
    //$('.multi').each(function (i) {

    //    const numval = sender.GetValue()
    //    currentval.push(numval)
    //})
    var currentvalt;
    for (i = 0; i < currentval.length; i++) {
        if (i == 0) {
            currentvalt =parseFloat( currentval[i].GetValue())
        }
        else {
            currentvalt =parseFloat( currentval[i].GetValue()) *parseFloat( currentvalt);
        }
    }
    res_input.SetValue(currentvalt.toFixed(3));
}

function subtractInputsonly(currentval, res_input) {
     
    //var controls = ASPxClientControl.GetControlCollection();
    //for (var key in controls.elements) {
    //    var control = controls.elements[key];
    //    if (control != null && ASPxIdent.IsASPxClientEdit(control)) {
    //        if (control != s) {
    //            var parent = ASPxClientUtils.GetParentByClassName(control.GetMainElement(), "multi");
    //             
    //            if (parent != null) {
    //               alert("v")
    //            }
    //        }
    //    }
    //}
    let total = 0;
    //let currentval = [];
    //$('.multi').each(function (i) {

    //    const numval = sender.GetValue()
    //    currentval.push(numval)
    //})
    var currentvalt;
    for (i = 0; i < currentval.length; i++) {
        if (i == 0) {
            currentvalt = parseFloat(currentval[i].GetValue())
        }
        else {
            currentvalt = parseFloat(currentval[i].GetValue()) - parseFloat(currentvalt);
        }
    }
    res_input.SetValue(currentvalt.toFixed(3));
}

function positivenumonly(sender, evt) {
    var charCode = (evt.htmlEvent.keyCode) ? evt.htmlEvent.keyCode : evt.htmlEvent.keyCode

    if (
        (charCode < 48 || charCode > 57))
        return ASPxClientUtils.PreventEvent(evt.htmlEvent);
}




function multipleWithTaxDis(objmulti,taxprcnt=0,disprcnt=0,disval=0,totalres,netres) {
  
   
    let currentvalaftervat = 0;
    var currentval=0;
    let taxval = 0;
    let disvalue = 0;
    for (i = 0; i < objmulti.length; i++) {
        if (i == 0) {
            currentval = objmulti[i]
        }
        else {
            currentval = objmulti[i] * currentval;
        }

    }
    if (!isNullOrZero(taxprcnt.value)) {
        taxval = currentval.toFixed(3) * nullToDecimalZero((tax / 100))
    }
     currentvalaftervat = taxval + currentvalt;
    if (isNullOrZero(disval.GetValue)) {
       
        if (!isNullOrZero(disprcnt.GetValue)) {
            disvalue = nullToDecimalZero(currentvalaftervat) * nullToDecimalZero((dis / 100))
        }
        else {
            disvalue = disval;
        }

    }
   
    
    let currentvalafterdis = currentvalaftervat - disvalue;
    totalres.SetValue(nullToDecimalZero(currentval));
    netres.SetValue(nullToDecimalZero(currentvalafterdis));
}
//#region

//var editorClientId = ["txt_qty", "txt_price", "txt_value", "txt_vatvalue", "txt_price"];
function resetInputValue(editors) {
    
    editors.forEach(function (val, i) {
        
        let inpnameval = ASPxClientControl.GetControlCollection().GetByName(val)
        inpnameval.SetValue(null);
      

    })

}
function resetInputValue(editors,editorauto) {

    editors.forEach(function (val, i) {
        
        let inpnameval = ASPxClientControl.GetControlCollection().GetByName(val)
        inpnameval.SetValue(null);
        


    })
    editorauto.forEach(function (val, i) {
        
        let inpnameval = ASPxClientControl.GetControlCollection().GetByName(val)
        inpnameval.SetValue('تلقائى');



    })

}
function SetSelectedRowToText(grid,editors) {
     
    var fil = "";
    editors.forEach(function (val, i) {
        if (fil == "") {
            fil += val.replace("txt_", "");
        }
        else {
            fil += val.replace("txt_", ";");
        }

    })
    var fieldsval = [];
  var grd=  ASPxClientControl.GetControlCollection().GetByName(grid)
    grd.GetRowValues(grd.GetFocusedRowIndex(), fil, function (values) {
         
        //var valuessplit = values.split(";");
        editors.forEach(function (val, i) {
            let inpnameval = ASPxClientControl.GetControlCollection().GetByName(val)
            inpnameval.SetValue(values[i])
        })
    })

}
function showpopupp(s, e, indx) {

    $('#gridrowindex').val(indx)
    $('#popupModal').modal('show')

}
function showpopup(s, e) {
    

    $('#popupModal').modal('show')

}
function showpopupSearch(s, e) {
    
    $('#popupModalsearch').modal('show')

}
//#endregion
//#region gridutil
$(function () {
    //
    //let ctlcollection = ASPxClientControl.GetControlCollection().GetControlsByType(ASPxClientButton);
    //for (var i = 0; i < ctlcollection.length; i++) {
    //    
    //    ctlcollection[i].useSubmitBehavior = false
    //}

})
function addGridRow(grid, editors) {

    var fil = "";
    editors.forEach(function (val, i) {
        //if (fil == "") {
        //    fil += val.replace("txt_", "");
        //}
        //else {
        //    fil += val.replace("txt_", ";");
        //}

    })
    
    var fieldsval = [];
    var grd = ASPxClientControl.GetControlCollection().GetByName(grid)
    grd.AddNewRow()

    
    editors.forEach(function (val, i) {
        //if (fil == "") {
        let    fieldname = val.replace("txt_", "");
        //}
        //else {
        //    fil += val.replace("txt_", ";");
        //}
        let inputname = ASPxClientControl.GetControlCollection().GetByName(val)
        grd.SetEditValue(fieldname,inputname.GetValue())
    })
    //grd.GetRowValues(grd.GetFocusedRowIndex(), fil, function (values) {

    //    //var valuessplit = values.split(";");
    //    editors.forEach(function (val, i) {
    //        let inpnameval = ASPxClientControl.GetControlCollection().GetByName(val)
    //        inpnameval.SetValue(values[i])
    //    })
    //})

}

function SetDxControlVal(ctl, val) {
    
    if (ctl instanceof ASPxClientDateEdit) {
        ctl.SetValue(new Date(val));
    }
    else {
        ctl.SetValue(val);
    }
}
//#endregion

