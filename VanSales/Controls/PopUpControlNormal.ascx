<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopUpControlNormal.ascx.cs" Inherits="VanSales.Controls.PopUpControlNormal" %>



 <style>
   
     .modal-header .close {
    padding: 0;
    margin: 0;
}

    .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > tr > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused):hover > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused):hover > tr > td {
    background-color: #35B86B;
    color: white;
}
    /*h*/
    .dx-datagrid-headers  
{  
    text-align: center;
}  

    .dx-datagrid-headers .dx-datagrid-text-content  
    {  
        text-align: center;  
    }  

        .dx-pager .dx-page-sizes .dx-selection, .dx-pager .dx-pages .dx-selection {
    cursor: inherit;
    text-shadow: none;
    color: #ddd;
    border-color: transparent;
    background-color: #35B86B;
}
 </style>
  <div class="modal" id="popupModal" dir="rtl" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="alertdialog">
    <div class="modal-content" style="height:300px;min-height:300px">
      <div class="modal-header">
        <h5 class="modal-title" id="popupModalLabel">    بحث</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
        <input type="hidden" id="gridrowindex" />
      <div class="modal-body" >
     <div class="row"> 
          
                    
      <div class="col-md-10">     <dx:ASPxTextBox runat="server"  ClientIDMode="Static" AutoPostBack="false"   ID="txt_itemsearch" CssClass="col-md-12 form-control" ClientSideEvents-KeyDown="function(s,e){searchitem(s,e)}"></dx:ASPxTextBox>
                        
                           
                        </div>
         <div class="col-md-2">
             <button type="button" class="btn btn-sm btnsearchpopup col-md-12" onclick="searchitembtn()"></button>
         </div>
          </div>  
         
           <div class="row" style="margin-top:10px">
                <div id="grd"></div>
          <asp:HiddenField ID="hf_params" runat="server" ClientIDMode="Static" />
          <asp:HiddenField ID="fields" runat="server" ClientIDMode="Static" />
          <asp:HiddenField ID="controlstodisplay" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="fieldshidden" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="fieldscaption" runat="server" ClientIDMode="Static" />
                   <asp:HiddenField ID="tablename_hf" runat="server" ClientIDMode="Static" />
                  <asp:HiddenField ID="apiurl_hf" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hf_bindefields" runat="server" ClientIDMode="Static" />
                  
               </div>
      </div>
      <%--<div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Send message</button>
      </div>--%>
    </div>
  </div>
</div>
<script>
    let griddata;
    $(function () {

    })
    $('#popupModal').on('show.bs.modal', function (e) {

        txt_itemsearch.SetValue(null)
        let serachmodel = {
            TableName: $("#tablename_hf").val()
            , SearchVal: nullToEmpty(txt_itemsearch.GetValue())
        }
        if (nullToEmpty($('#hf_params_search').val()) != "") {
        let paramnames = $('#hf_params_search').val().split(",");
       // if (paramnames!="") {
            for (var i = 0; i < paramnames.length; i++) {
                var paraname = paramnames[i].split("_")[1];
                let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnames[i])
                let paramval;
                if (ctl == null) {
                    paramval = $('#' + paramnames[i]).val()
                }
                else {
                    paramval = ctl.GetValue()
                }
                serachmodel[paraname] = paramval;
            }
        }
       

        let griddata = getAction($("#apiurl_hf").val(), serachmodel)

        $("#grd").dxDataGrid({
            dataSource: griddata,
            selection: {
                mode: "single"
            },
            paging: {
                pageSize: 5
            },
            hoverStateEnabled: true,
            columns: createColumn(),
            showBorders: true
            , onRowDblClick: function (e) {


                var selectedrow = e.data
                let fielsname = $('#hf_bindefields').val().split(';')
                let displaycontrols = $('#controlstodisplay').val().split(';')
                
                for (var i = 0; i < displaycontrols.length; i++) {
                    let ctl = ASPxClientControl.GetControlCollection().GetByName(displaycontrols[i])

                    if (ctl == null) {
                        $('#' + displaycontrols[i]).val(selectedrow[fielsname[i]])
                    }
                    else {
                        if (typeof (ASPxClientDateEdit) != "undefined" &&  ctl instanceof ASPxClientDateEdit) {
                            ctl.SetValue(new Date(selectedrow[fielsname[i]]));
                        }
                        else {
                            ctl.SetValue(selectedrow[fielsname[i]]);
                        }
                        //SetDxControlVal(ctl, selectedrow[fielsname[i]])
                    }
                }
                $('#popupModal').modal('hide')
            },
            onCellPrepared: function onCellPrepared(e) {

                if (e.rowType == "header" || e.rowType == "data") {
                    e.cellElement.css("text-align", "right");
                }

                // ...  
            },
        });
    });

    function createColumn() {
        let columns = []
        let displaycontrols = $('#fields').val().split(',')
        
        for (var i = 0; i < displaycontrols.length; i++) {
            let columndetails = {};

            let captioncolumn = $('#fieldscaption').val().split(",");



            columndetails["caption"] = captioncolumn[i];

            columndetails["dataField"] = displaycontrols[i]

            //columndetails["dataField"] = fields[i]
            columns.push(columndetails)
        }
        let hiddencolumn = $('#fieldshidden').val().split(",");
        for (var i = 0; i < hiddencolumn.length; i++) {
            let columndetails = {};
            columndetails["dataField"] = hiddencolumn[i]
            columndetails["visible"] = false
            columns.push(columndetails)
        }

        return columns;
    }
 <%--   function clickedf() {
        
        var ff = $('#fields').val();
        var f =ff.split(",")
        for (var i = 0; i < f.length; i++) {
          $('#' + f[i]).val('كنترول '+i)
        }
        $('#<%= ValueControle %>').val(1);
    }--%>


    function searchitem(s, event) {

        //  var keycode = (event. event.keyCode ? event.keyCode : event.which);
        if (event.htmlEvent.keyCode == '13') {
            let serachmodel = {
                TableName: $("#tablename_hf").val()
                , SearchVal: nullToEmpty(txt_itemsearch.GetValue())
            }
            let paramnames = $('#hf_params').val().split(",");
            if (paramnames != "") {
                for (var i = 0; i < paramnames.length; i++) {
                    var paraname = paramnames[i].split("_")[1];
                    let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnames[i])
                    let paramval;
                    if (ctl == null) {
                        paramval = $('#' + paramnames[i]).val()
                    }
                    else {
                        paramval = ctl.GetValue()
                    }
                    serachmodel[paraname] = paramval;
                }
            }
            let griddata = getAction($("#apiurl_hf").val(), serachmodel)
            $("#grd").dxDataGrid('instance').option('dataSource', griddata)
        }
    }

    function searchitembtn() {

        //  var keycode = (event. event.keyCode ? event.keyCode : event.which);

        let serachmodel = {
            TableName: $("#tablename_hf").val()
            , SearchVal: nullToEmpty(txt_searchitem.GetValue())
        }
        let paramnames = $('#hf_params').val().split(",");
        if (paramnames != "") {
            for (var i = 0; i < paramnames.length; i++) {
                var paraname = paramnames[i].split("_")[1];
                let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnames[i])
                let paramval;
                if (ctl == null) {
                    paramval = $('#' + paramnames[i]).val()
                }
                else {
                    paramval = ctl.GetValue()
                }
                serachmodel[paraname] = paramval;
            }
        }
        let griddata = getAction($("#apiurl_hf").val(), serachmodel)
        $("#grd").dxDataGrid('instance').option('dataSource', griddata)

    }
</script>