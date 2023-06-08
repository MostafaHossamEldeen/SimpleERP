<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopUpControlSearch.ascx.cs" Inherits="VanSales.Controls.PopUpControlSearch" %>


 <style>
   
     .modal-header .close {
    padding: 0;
    margin: 0;
}

    .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > tr > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused):hover > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused):hover > tr > td {
    background-color: #35B86B;
    color: white;
}

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
  <div class="modal" id="popupModalsearch" dir="rtl" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true">
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
          
                    
      <div class="col-md-10">     <dx:ASPxTextBox runat="server"  ClientIDMode="Static" AutoPostBack="false" 
          ID="txt_searchv1" CssClass="col-md-12 form-control" ClientSideEvents-KeyDown="function(s,e){searchitmv1(s,e)}"></dx:ASPxTextBox>
                        
                           
                        </div>
         <div class="col-md-2">
             <button type="button" class="btn btn-sm btnsearchpopup col-md-12" onclick="searchitmbtnv1()"></button>
         </div>
          </div>  
         
           <div class="row" style="margin-top:10px">
                <div id="grd_searchv1"></div>
          <asp:HiddenField ID="hf_params_search" runat="server" ClientIDMode="Static" />
          <asp:HiddenField ID="fields_search" runat="server" ClientIDMode="Static" />
          <asp:HiddenField ID="controlstodisplay_search" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="fieldshidden_search" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="fieldscaption_search" runat="server" ClientIDMode="Static" />
                   <asp:HiddenField ID="tablename_hf_search" runat="server" ClientIDMode="Static" />
                  <asp:HiddenField ID="apiurl_hf_search" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hf_bindefields_search" runat="server" ClientIDMode="Static" />
                  
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
   // let griddatasearch;
    $(function () {

    })
    $('#popupModalsearch').on('show.bs.modal', function (e) {
        
        txt_searchv1.SetValue(null)
        let serachmodel = {
            TableName: $("#tablename_hf_search").val()
            , SearchVal: nullToEmpty(txt_searchv1.GetValue())
        }
        let paramnamessearch = $('#hf_params_search').val().split(",");
        if (paramnamessearch!="") {
            for (var i = 0; i < paramnamessearch.length; i++) {
                var paraname = paramnamessearch[i].split("_")[1];
                let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnamessearch[i])
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
       

        let griddatasearch = getAction($("#apiurl_hf_search").val(), serachmodel)

        $("#grd_searchv1").dxDataGrid({
            dataSource: griddatasearch,
            selection: {
                mode: "single"
            },
            paging: {
                pageSize: 5
            },
            hoverStateEnabled: true,
            columns: createColumnsearch(),
            showBorders: true
            , onRowDblClick: function (e) {
                

                var selectedrow = e.data
                let fielsname = $('#hf_bindefields_search').val().split(';')
                let displaycontrols_search = $('#controlstodisplay_search').val().split(';')
                for (var i = 0; i < displaycontrols_search.length; i++) {
                    let ctl = ASPxClientControl.GetControlCollection().GetByName(displaycontrols_search[i])

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
                $('#popupModalsearch').modal('hide')
            },
            onCellPrepared: function onCellPrepared(e) {
                
                if (e.rowType == "header" || e.rowType == "data") {
                    e.cellElement.css("text-align", "right");
                }

                // ...  
            },
        });
    });

    function createColumnsearch() {
        let columns = []
        let displaycontrols_search = $('#fields_search').val().split(',')
        
        for (var i = 0; i < displaycontrols_search.length; i++) {
            let columndetails = {};
          
            let captioncolumn = $('#fieldscaption_search').val().split(",");

          
          
                columndetails["caption"] = captioncolumn[i];
            
            columndetails["dataField"] = displaycontrols_search[i]

            //columndetails["dataField"] = fields[i]
            columns.push(columndetails)
        }
        let hiddencolumn = $('#fieldshidden_search').val().split(",");
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
   

    function searchitmv1(s, event) {
        
        //  var keycode = (event. event.keyCode ? event.keyCode : event.which);
        if (event.htmlEvent.keyCode == '13') {
            let serachmodel = {
                TableName: $("#tablename_hf_search").val()
                , SearchVal: nullToEmpty(txt_searchv1.GetValue())
            }
            let paramnamessearch = $('#hf_params_search').val().split(",");
            if (paramnamessearch != "") {
                for (var i = 0; i < paramnamessearch.length; i++) {
                    var paraname = paramnamessearch[i].split("_")[1];
                    let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnamessearch[i])
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
            let griddatasearch = getAction($("#apiurl_hf_search").val(), serachmodel)
            $("#grd_searchv1").dxDataGrid('instance').option('dataSource', griddatasearch)
        }
    }

    function searchitmbtnv1() {
        
        //  var keycode = (event. event.keyCode ? event.keyCode : event.which);

        let serachmodel = {
            TableName: $("#tablename_hf_search").val()
            , SearchVal: nullToEmpty(txt_searchv1.GetValue())
        }
        let paramnamessearch = $('#hf_params_search').val().split(",");
        if (paramnamessearch!="") {

      
        for (var i = 0; i < paramnamessearch.length; i++) {
            var paraname = paramnamessearch[i].split("_")[1];
            let ctl = ASPxClientControl.GetControlCollection().GetByName(paramnamessearch[i])
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
        let griddatasearch = getAction($("#apiurl_hf_search").val(), serachmodel)
        $("#grd_searchv1").dxDataGrid('instance').option('dataSource', griddatasearch)

    }
</script>