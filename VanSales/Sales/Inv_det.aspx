<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Inv_det.aspx.cs" Inherits="VanSales.Sales.Inv_det" %>

<%@ Register Src="~/Controls/PopUpControl.ascx" TagPrefix="uc1" TagName="PopUpControl" %>

<html>
<head>
    <%--<link rel="stylesheet" href="../assets/plugins/bootstrap/css/bootstrap.min.css">--%>
   


                <link rel="stylesheet" href="../assets/plugins/bootstrap/css/bootstrap.min.css">
    <script src="../VanSalesThemsFile/js/vendor/jquery-3.3.1.min.js"></script>
    <script src="../assets/js/popper.js"></script>
    <script src="../assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="../Scripts/jquery.cookie.js"></script>
    
    <script src="../Scripts/App/base/Helperjs.js"></script>
    <script src="../Scripts/App/base/ApiHelper.js"></script>
    <script src="../Scripts/App/base/DevExpressJsHelper.js"></script>
   <link href="../Content/dx.light.css" rel="stylesheet" />
    <link href="../Content/dx.common.css" rel="stylesheet" />
        <script src="../Scripts/App/base/DevExpressJsHelper.js"></script>
      <script src="../Scripts/dx.all.js"></script>
    <%--         <script src="../assets/plugins/jquery/dist/jquery.min.js"></script>
     <script src="../assets/plugins/bootstrap/js/bootstrap.min.js"></script>--%>
    <style>
         .btnsearchpopup{
         padding: 6px 13px 4px;
         background-color:white;
         -webkit-box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
        /* height:30px;
         width:30px*/
            height: 25px;
    width: 45px;

 }
 .btnsearchpopup:before {
   content: url(../img/icon/search.svg);
   width: 20px;
   float: left;
     margin-top: -3px;
    margin-left: 5px;
 }

              .btnsearchpopupgrd{
         padding: 6px 13px 4px;
         background-color:white;
         -webkit-box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
        /* height:30px;
         width:30px*/
            height: 37px;
    width: 48px;

 }
 .btnsearchpopupgrd:before {
   content: url(../img/icon/search.svg);
   width: 20px;
   float: left;
     /*margin-top: 5px;*/
    margin-left: -3px;
 }
    </style>
</head>
    <body>
          <div class="modal" onkeydown="navigategrd(event)"  id="popupModalsearchdef" style="z-index:999999999;" data-name="aaa" tabindex="-1" role="dialog" aria-labelledby="popupModalsearchdefLabel" aria-hidden="true" dir="rtl">
    <div class="modal-dialog" role="document">
        <div class="modal-content"  >
        <div class="modal-header">
        <h5 class="modal-title" id="popupModalsearchdefLabel">بحث</h5>
        <button type="button" class="close float-right" data-dismiss="modal" data-type="aa" aria-label="Close">
        <span aria-hidden="true">&times;</span>
        </button>
        </div>
        <div class="modal-body" >
       <div class="container-fluid">
     
       <div class="form-group row">
        <input type="text" id="txt_search" onkeydown="searchitm(event)" autocomplete="off"   placeholder="بحث" class="form-control" style="width:80%" />
  
      
        
        <button type="button"onclick="searchItmPopUp()" style="width:10%;margin-right:10px" class="btn btn-sm btnsearchpopupgrd form-control"></button>
       </div>
   
          </div>
        <div   style="margin-top:10px">
        <div id="grd_search"></div>


        </div>
       
       </div>
     </div>

  </div>
      </div>
        <form runat="server">
<%--            <div class="alert alert-success alert-dismissible fade " role="alert">
  <strong>Success</strong> DataDeleted.
  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
    <span aria-hidden="true">&times;</span>
  </button>
</div>--%>
            <asp:TextBox ID="chckedit" ClientIDMode="Static" OnTextChanged="chckedit_ValueChanged" runat="server" Visible="false" AutoPostBack="true" />
         <asp:HiddenField ID="invnum" ClientIDMode="Static"  runat="server" />
             <asp:HiddenField ID="invid" ClientIDMode="Static"  runat="server" />
             <asp:HiddenField ID="vatval" ClientIDMode="Static"  runat="server" />
               <asp:HiddenField ID="netval" ClientIDMode="Static"  runat="server" />
<%--     <script src="../Scripts/App/base/Helperjs.js"></script>
       <script src="../Scripts/App/base/DevExpressJsHelper.js"></script>
       <script src="../Scripts/App/Inv_det_Quick.js"></script>--%>

      <%--EnableCallBacks="False"--%>
            <dx:ASPxGridView ID="gvs_invdtlsquick"  ClientInstanceName="gvs_invdtlsquick" runat="server" SettingsEditing-BatchEditSettings-ShowConfirmOnLosingChanges="false"
                AutoGenerateColumns="False"  KeyboardSupport="true"  OnCustomJSProperties="gvs_invdtlsquick_CustomJSProperties" 
                Width="100%" KeyFieldName="invdtlid"  OnRowInserted="gvs_invdtlsquick_RowInserted"  RightToLeft="True" ClientSideEvents-BatchEditStartEditing="function (s,e){batchEditStart(s,e)}" 
                ClientSideEvents-BatchEditEndEditing="function(s,e){batchEditEndEditing(s,e)}" ClientSideEvents-BatchEditRowValidating="function (s,e){batchEditRowValidating(s,e)}" 
              ClientSideEvents-BatchEditRowInserting="function(s,e){initnewval(s,e)}"
               Theme="MaterialCompact" OnInitNewRow="gvs_invdtlsquick_InitNewRow" OnRowUpdating="gvs_invdtlsquick_RowUpdating" 
                ClientSideEvents-BatchEditRowDeleting="function(s,e){deldata(s,e)}" OnRowUpdated="gvs_invdtlsquick_RowUpdated" 
                OnBatchUpdate="gvs_invdtlsquick_BatchUpdate" OnCellEditorInitialize="gvs_invdtlsquick_CellEditorInitialize" OnRowDeleting="gvs_invdtlsquick_RowDeleting"
                OnRowInserting="gvs_invdtlsquick_RowInserting" OnDataBinding="gvs_invdtlsquick_DataBinding">
           
             <SettingsCommandButton  NewButton-Text="جديد"  DeleteButton-Text="حذف"></SettingsCommandButton>
               <SettingsEditing BatchEditSettings-HighlightDeletedRows="false"></SettingsEditing>
                    <Settings   ShowStatusBar="Hidden"/>
                      <SettingsPager Mode="ShowAllRecords"></SettingsPager> 
                        <Columns> 
                           
                            <dx:GridViewCommandColumn Width="50px"  ShowNewButtonInHeader="true" ShowDeleteButton="true" VisibleIndex="1">
                               <%-- <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton  Styles-Style-CssClass="fa fa-search">

                                               </dx:GridViewCommandColumnCustomButton></CustomButtons>--%>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="invdtlid" Caption="م"  ReadOnly="True" VisibleIndex="2" Width="0" >
                               
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn    FieldName="itemcode"  VisibleIndex="2" Caption="كود الصنف" >
                               
                            </dx:GridViewDataTextColumn>
                           <%-- <dx:GridViewDataButtonEditColumn  VisibleIndex="4" Caption=" ">
                                  <DataItemTemplate>  
                                  <dx:ASPxButton ID="ASPxButton2" runat="server"  
                                     CssClass="fa fa-search" 
                                      AutoPostBack="False" >  
                                  </dx:ASPxButton>  
                                  </DataItemTemplate>  
                            </dx:GridViewDataButtonEditColumn>--%>
                             <dx:GridViewDataColumn Caption="" VisibleIndex="3" Width="50px">
                <DataItemTemplate>
                   <button  type="button"  id="puop_item" data-name="items" onclick="createPopUp($(this))"  data-TableName="st_itemunit_inv_sel_pop"  data-DisplayFields="itemcode,itemname,unitname" data-DisplayFieldsHidden="unitid,vat,factor,fprice,itemid,cprice"
        data-DisplayFieldsCaption="كود الصنف,اسم الصنف,الوحده,سعر التكلفه" data-BindControls="txt_itemcode;txtitem_name;txt_unit;HF_itemid;HF_unitid;txt_price;Hf_vat;HF_factor;HF_invdtlid"
        data-BindFields="itemcode;itemname;unitname;itemid;unitid;fprice;vat;factor;''" data-PkField="itemunitid" data-ApiUrl="/VanSalesService/items/FillPopup" style="margin-top: 10px"   class="btn btn-sm btnsearchpopup"   tabindex="1" />
                   
                </DataItemTemplate>
            </dx:GridViewDataColumn>
                            <dx:GridViewDataTextColumn FieldName="itemname"    VisibleIndex="4" Caption="اسم الصنف">
                                
                            </dx:GridViewDataTextColumn>
                            
                          <dx:GridViewDataTextColumn  FieldName="unitid" VisibleIndex="3" Width="0">
                              
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn  FieldName="factor" VisibleIndex="3" Width="0">
                              
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn  FieldName="itemid" VisibleIndex="3" Width="0">
                              
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitname"  VisibleIndex="5" Caption="الوحده" >
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="qty"  VisibleIndex="6" Caption="الكميه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="price" VisibleIndex="7" Caption="السعر">
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn FieldName="icost" VisibleIndex="7" Caption="التكلفه" Visible="false">
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="value" VisibleIndex="8" Caption="الاجمالى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discp" VisibleIndex="9" Caption="نسبه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discvalue" VisibleIndex="10" Caption="قيمه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="netvalue" VisibleIndex="11" Caption="الصافى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Width="0" UnboundType="Decimal" FieldName="vatprcnt" VisibleIndex="12" Caption="" >
                               
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="12" Caption="الضريبه">
                               
                           </dx:GridViewDataTextColumn>
                           <%--  <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="13" Visible="true" Caption="ملاحظات">
                            </dx:GridViewDataTextColumn>--%>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True"  AllowDragDrop="false" AllowHeaderFilter="false"/>
                        <%--<SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>--%>
                        <SettingsBehavior AllowEllipsisInText="true" />
                     
                        
                <SettingsEditing Mode="Batch"></SettingsEditing>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="الكميه" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="price" ShowInColumn="السعر" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="netvalue" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="{0}" />
                        </TotalSummary>
                
                    </dx:ASPxGridView>
      
     
 
  
</form>
    </body>
</html>
 <script src="../Scripts/App/Inv_det_Quick.js"></script>


