<%@ Page Title="أذون التحويل" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="st_Trans_ord.aspx.cs" Inherits="VanSales.Stock.st_Trans_ord" %>
<%@ Register Src="~/Controls/PopUpControlNormal.ascx" TagPrefix="uc1" TagName="PopUpControlNormal" %>
<%@ Register Src="~/Controls/PopUpControlSearch.ascx" TagPrefix="uc1" TagName="PopUpControlSearch" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:PopUpControlSearch runat="server" ID="PopUpControlSearch" TableName="st_transactions_trans_sel_search" DisplayFields="transferno,branchname,branchtoname,trandate" DisplayFieldsHidden="ccname,cctoname,branchid,branchtoid,trandocno,naturetran,naturename,ccid,cctoid,trannotes,transid,postst,postacc,vochrno,transno,receipt,username"
        DisplayFieldsCaption="كود الاذن,من فرع,الى فرع,التاريخ" BindControls="txt_transno;txt_trandocno;cmb_branchid;cmb_branchtoid;cmb_cctoid;txt_trandate;ddl_naturetran;cmb_ccid;txt_trannotes;HF_transid;hf_postst;hf_postacc;txt_vochrid;txt_issordno;HF_receipt;txt_username" BindFields="transferno;trandocno;branchid;branchtoid;cctoid;trandate;naturetran;ccid;trannotes;transid;postst;postacc;vochrno;transno;receipt;username" ParamaterNames="hf_transtype" ApiUrl="/VanSalesService/Stock/AddOrderSearch"  PkField="transid" />

    <uc1:PopUpControlNormal runat="server" ID="Pop_items" TableName="st_itemunit_sel_pop" DisplayFields="itemcode,itemname,unitname" DisplayFieldsHidden="unitid,vat,factor,fprice,itemid,cprice"
        DisplayFieldsCaption="كود الصنف,اسم الصنف,الوحده,سعر التكلفه" BindControls="txt_itemid;txt_item_name;txt_unitname;HF_itemid;HF_unitid;HF_factor;HF_cost;HF_transdtlid" BindFields="itemcode;itemname;unitname;itemid;unitid;factor;cprice;''" PkField="itemunitid" ApiUrl="/VanSalesService/items/FillPopup"   />
    <script src="../Scripts/App/stock/trans_ord.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="Lbl_Tittle" runat="server" Text="أذون التحويل" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">

                          <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" ClientInstanceName="btn_Save" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) {
	validate(s, e);
}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" ClientInstanceName="btn_addnew" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">
   
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>

                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" Height="20px" ClientInstanceName="btn_delete"  RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                     <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/Stock/TransordDelMaster', 'HF_transid') }" />
                     <%--<ClientSideEvents Click="function(s, e) {deldata('https://localhost:44307/Stock/st_Trans_ord.aspx/Deletedata' ,'transid','HF_transid') }" />--%>
                 

                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_search" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="بحث">

                    <ClientSideEvents Click="function(s, e) {showpopupSearch(s, e) }" />

                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px"></Image>
                </dx:ASPxButton>
                
                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postst" runat="server" ClientInstanceName="btn_postst" AutoPostBack="False" Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function(s,e){postTransOrderStock(s, e)}" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل مستودعات">
                    <Image Height="20px" Url="~/img/icon/poststock.svg" Width="20px"></Image>
                </dx:ASPxButton>
                  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_resevord" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" OnClick="btn_resevord_Click" ToolTip="استلام التحويل">
                    <Image Height="20px" Url="~/img/icon/Receiving.png" Width="20px"></Image>
                </dx:ASPxButton>
                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" ClientSideEvents-Click="function(s,e){postTransOrderAcc(s, e)}" Width="20px" ToolTip="ترحيل حسابات">
                    <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                </dx:ASPxButton>

          <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">
                                       <ClientSideEvents Click="function(s, e) {
print_newtab();
}" />
                       <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />

            </div>

            <br />
           
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="البيانات الاساسيه">
                        <Items>
                            <dx:LayoutItem Caption="رقم ألاذن">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_transno" runat="server" ClientInstanceName="txt_transno" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">

                                            <ClientSideEvents KeyDown="function(s, e) {
	 preventwrite(s, e)
}"></ClientSideEvents>
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            

                            <dx:LayoutItem Caption="رقم يدوى للاذن">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_trandocno" ClientInstanceName="txt_trandocno" runat="server" Theme="MaterialCompact" Style="margin-right: 0px">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                               <dx:LayoutItem Caption="التاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxDateEdit ID="txt_trandate" runat="server" ValidateRequestMode="Disabled" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_trandate">
                                        </dx:ASPxDateEdit>


                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                              </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="2" GroupBoxDecoration="box" Caption="اطراف التحويل" UseDefaultPaddings="false" >
                            
                            <Items>
                            <dx:LayoutItem Caption="من فرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                               <dx:LayoutItem Caption="من مركز تكلفه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_ccid" runat="server" ClientInstanceName="cmb_ccid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                <dx:LayoutItem Caption="الى فرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchtoid" runat="server" ClientInstanceName="cmb_branchtoid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
 
                         
                            <dx:LayoutItem Caption="الى مركز تكلفه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_cctoid" runat="server" ClientInstanceName="cmb_cctoid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                 </Items>
                        </dx:LayoutGroup>
                      <dx:LayoutGroup ColCount="5" GroupBoxDecoration="None" Caption="" UseDefaultPaddings="false" >
                            
                            <Items>
                            <dx:LayoutItem Caption="المستخدم">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_username" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_username">
                                            <ClientSideEvents Init="function(s, e) {
	txt_username.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الملاحظات" ColumnSpan="4">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_trannotes" ClientInstanceName="txt_trannotes" runat="server" Theme="MaterialCompact" Width="100%">
                                        </dx:ASPxMemo>


                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                      <dx:LayoutItem Caption="رقم صرف التحويل" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                   
                                       <dx:ASPxTextBox ID="txt_issordno" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_issordno" Visible="true">
                                            <ClientSideEvents Init="function(s, e) {
	txt_issordno.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                       <dx:LayoutItem Caption="رقم استلام التحويل"  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                   
                                       <dx:ASPxTextBox ID="txt_resev" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_resev" Visible="true">
                                            <ClientSideEvents Init="function(s, e) {
	txt_resev.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                 <dx:LayoutItem Caption="رقم القيد" Paddings-PaddingTop="15">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                   
                                        <dx:ASPxHyperLink ID="txt_vochrid" runat="server" ClientInstanceName="txt_vochrid" Font-Bold="True" ForeColor="#009933" Font-Size="Medium">
                                        </dx:ASPxHyperLink>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_postst" />
                                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_postacc" />
                                        <dx:ASPxLabel ID="lbl_postst" runat="server" ClientInstanceName="lbl_postst" Visible="true" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxLabel ID="lbl_postacc" runat="server" ClientInstanceName="lbl_postacc" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                           
                               
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>
                            
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="HF_transid" ClientIDMode="Static" runat="server" />
          <asp:HiddenField ID="HF_recepitid"  ClientIDMode="Static" runat="server" />
          <asp:HiddenField ID="HF_receipt"  ClientIDMode="Static" runat="server" />
            <br />
            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="display: none; text-align: right" ClientIDMode="Static">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="11" GroupBoxDecoration="box" Caption="تفاصيل أذن التحويل" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_itemid" runat="server" Theme="MaterialCompact" AutoPostBack="false" ClientInstanceName="txt_itemid" OnTextChanged="txt_itemid_TextChanged">
                                                    <ClientSideEvents TextChanged="function(s,e){setItemData(s,e)}"/>

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="11">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_items" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="1%" ToolTip="بحث">
                                                    <ClientSideEvents Click="function(s, e) {
	showpopup(s, e)
}" />
                                                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="الصنف" Width="20%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_item_name" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_item_name">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_item_name.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="وحده القياس" Width="11%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_unitname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_unitname">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_unitname.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="الكميه">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact">

                                                    <ClientSideEvents GotFocus="function(s, e) {txt_qty.SelectAll();}"
                                                        KeyPress="function(s, e) {decimale3num(s, e)}" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="11" Width="12%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="lbl_qtyinf" runat="server" Text="" ClientInstanceName="lbl_qtyinf" Font-Bold="true" ForeColor="#009933"></dx:ASPxLabel>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="" ColumnSpan="3" Paddings-PaddingTop="11">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" ClientInstanceName="btn_save_dtls" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" ClientInstanceName="btn_new_dtls" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" >
                                                    <ClientSideEvents Click="function(s, e) {
	 clear_item();
}"></ClientSideEvents>
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>

                                                </dx:ASPxButton>
                                               <%--  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" ClientInstanceName="btn_delete_dtls" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" OnClick="btn_delete_dtls_Click">
                                                    <ClientSideEvents Click="function(s, e) {getgvrow(); 
                                       e.processOnServer = confirm('هل تريد الحذف؟');}" />
                                                    <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>--%>
                                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" >
                                                    <%--<ClientSideEvents Click="function(s, e) {getgvrow(); deldata_dtl('/Stock/st_Trans_ord.aspx/Deletedatadtl' ,'transdtlid','HF_transdtlid',gvs_transdtls) }" />--%>
                                                        <ClientSideEvents Click="function(s, e) {getgvrow();delData_Detail('/VanSalesService/Stock/gTransordDtl', 'transdtlid', 'HF_transdtlid',gvs_transdtls) }" />
                                                           
                                                    <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                        <dx:LayoutItem Caption="الملف" CaptionSettings-Location="Left" Paddings-PaddingBottom="20"  Width="35%"  ParentContainerStyle-Paddings-PaddingLeft="5" ParentContainerStyle-Paddings-PaddingRight="5">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />           
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                       <dx:LayoutItem Caption="" ColumnSpan="4" CaptionSettings-Location="Left"  ParentContainerStyle-Paddings-PaddingLeft="10" ParentContainerStyle-Paddings-PaddingRight="176">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                 <%--<asp:ImageButton ID="btn_attach" runat="server" OnClick="btn_attach_Click" ImageUrl="~/img/icon/import.svg" Height="30px" Width="30px" ToolTip="رفع ملف" />--%>
                                                  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>

                                                  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_fastinsert" runat="server" AutoPostBack="False" ClientInstanceName="btn_fastinsert" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="ادخال سريع" Height="20px" Width="20px">
                                                    <Image Height="20px" Url="~/img/icon/bookmark.svg" Width="20px"></Image>
                                                </dx:ASPxButton>                                      

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" OnValueChanged="HiddenField1_ValueChanged" />
                     <asp:HiddenField runat="server" Value="-1" ClientIDMode="Static" ID="hf_transtype" />
                    <asp:HiddenField ID="HF_unitid" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_factor" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_cost" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_value" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_itemid" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_transdtlid" ClientIDMode="Static" runat="server" />
                    <dx:ASPxGridView ID="gvs_transdtls" ClientInstanceName="gvs_transdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" OnDataBinding="gvs_transdtls_DataBinding" ClientSideEvents-RowDblClick="function(s,e){bind(s,e)}" Width="100%" KeyFieldName="transdtlid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid" OnCustomCallback="gvs_transdtls_CustomCallback">


                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <SettingsPager AlwaysShowPager="True" PageSize="50">
                            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                        </SettingsPager>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="false" />
                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>
                        <SettingsBehavior AllowEllipsisInText="true" />
                        <EditFormLayoutProperties>
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                        </EditFormLayoutProperties>
                        <SettingsPopup>
                            <EditForm Width="730">
                                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                            </EditForm>
                        </SettingsPopup>
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="transdtlid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="transid" VisibleIndex="1" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="2" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="3" Caption="كود الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="4" Caption="اسم الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitid" VisibleIndex="5" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="6" Caption="الوحده">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="7" Caption="الكميه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="cost" VisibleIndex="8" Caption="التكلفه" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="value" VisibleIndex="9" Caption="القيمه" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="10" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="الكميه" SummaryType="Sum" DisplayFormat=" {0}" />
                            <%--  <dx:ASPxSummaryItem FieldName="price" ShowInColumn="السعر" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="netvalue" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="{0}" />--%>
                        </TotalSummary>
                          <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                    </dx:ASPxGridView>
                    <%--<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="st_transdtls_sel" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>--%>
                    <dx:ASPxGridViewExporter ID="gvitemsExporter" runat="server" FileName="تفاصيل اذون الاضافه" GridViewID="gvs_transdtls" PaperKind="A4" PaperName="اذون الاضافه" RightToLeft="True" Landscape="True">
                        <PageHeader Center="تفاصيل اذون الاضافه" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_xlsxexport" />
             <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_attach" />


        </Triggers>
    </asp:UpdatePanel>



    <script src="../Scripts/App/Public/Messages.js"></script>

</asp:Content>
