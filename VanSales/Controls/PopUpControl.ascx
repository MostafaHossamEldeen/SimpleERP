<%@ Control Language="C#" AutoEventWireup="true"  ClientIDMode="Static"  CodeBehind="PopUpControl.ascx.cs"  Inherits="VanSales.Controls.PopUpControl" %>


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

        <dx:ASPxButton ID="btn_search" runat="server"  ClientInstanceName="btn_search" AutoPostBack="False" Height="20px" OnLoad="btn_search_Load" RenderMode="Secondary"   Theme="MaterialCompact" Width="20px" ToolTip="بحث">

                    <ClientSideEvents Click="function(s, e) {createPopUp(s, e) }" />

                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px"></Image>
                </dx:ASPxButton>

<input id="ptn" type="button" onclick="createPopUp(this)" data-api="/VanSalesService/items/FillPopup" data-Tablename="" data-BindingField=""/>
<div id="contentmodal"></div>

<script>
  
  
  
</script>