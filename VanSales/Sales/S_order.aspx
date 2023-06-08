<%@ Page Title="أمر البيع" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="S_order.aspx.cs" Inherits="VanSales.Sales.S_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .custname {
            width: 500px;
            position: absolute;
        }

        .custinfo {
            width: 500px;
            position: absolute;
            left: 125px;
            margin-top: 80px;
        }

        .custgroup {
            margin-top: 30px;
            padding-right: 5px;
            background-color: white;
        }
    </style>
    <script src="../Scripts/App/sales/order.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="أمـــر البيـــــع" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) {
	validate(s, e);
}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_addnew_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">

                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/orders/orderDel', 'HF_soid') }" />
                    <%--   <ClientSideEvents Click="function(s, e) {delData('/Sales/S_order.aspx/Deletedata' ,'soid','HF_soid') }" />--%>


                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <button type="button" id="PopUpControlSearch" data-name="order" data-tablename="s_order_sel_search" data-displayfields="sono,sodocno,sodate"
                    data-displayfieldshidden="branchid,custid,custname,ouser,sonotes,netbvat,vatvalue,netavat,soid,sinvc"
                    data-displayfieldscaption="رقم أمر البيع,الرقم اليدوى,التاريخ"
                    data-bindcontrols="txt_sono;txt_sodocno;txt_sodate;cmb_branchid;txt_custid;txt_custname;txt_ouser;txt_sonotes;txt_netbvat;txt_vatvalue;txt_netavat;HF_soid;HF_sinvc"
                    data-bindfields="sono;sodocno;sodate;branchid;custid;custname;ouser;sonotes;netbvat;vatvalue;netavat;soid;sinvc"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="soid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_createinv" runat="server" AutoPostBack="False" OnClick="btn_createinv_Click" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="انشاء فاتوره">
                    <ClientSideEvents Click="function(s, e) {validateInv(s, e)}" />
                    <Image Height="20px" Url="~/img/icon/paid.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" OnClick="btn_print_Click" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">

                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />

            </div>

            <br />
            <%--class="dx-justification"--%>
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="Box" Caption="البيانات الاساسيه">
                            <Items>
                                <dx:LayoutItem Caption="رقم امر البيع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sono" runat="server" ClientInstanceName="txt_sono" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">
                                                <ClientSideEvents KeyDown="function(s,e){preventwrite(s,e)}" />

                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="رقم يدوى لأمر البيع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sodocno" runat="server" ClientInstanceName="txt_sodocno" Theme="MaterialCompact" Style="margin-right: 0px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <%-- <dx:LayoutItem Caption="نوع سداد الفاتوره">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_sinvpay" runat="server" ClientInstanceName="cmb_sinvpay" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                            </dx:ASPxComboBox>                                        
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                                <dx:LayoutItem Caption="الفرع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" TextField="branchname" Theme="MaterialCompact" ValueField="branchid" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="التاريخ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxDateEdit ID="txt_sodate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_sodate">
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <%-- <dx:LayoutItem Caption="مراكز التكلفه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_ccid" runat="server" ClientInstanceName="cmb_ccid" RightToLeft="True" TextField="ccname" Theme="MaterialCompact" ValueField="ccid" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                                <%-- <dx:LayoutItem Caption="امر البيع/عرض اسعار">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxHyperLink ID="txt_docid" runat="server" ClientInstanceName="txt_docid" NavigateUrl="#">
                                            </dx:ASPxHyperLink>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                                <%--  <dx:LayoutItem Caption="" ColumnSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                                <%-- <dx:LayoutItem Caption="الوقت">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sinvtime" ClientInstanceName="txt_sinvtime" runat="server" CssClass="auto-style2" Theme="MaterialCompact">
                                                <ClientSideEvents Init="function(s, e) {
	txt_sinvtime.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="box" Caption="بيانات العميل" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="كود العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_custid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_custid" AutoPostBack="false">
                                                <ClientSideEvents ValueChanged="function(s, e) {
	setCustData(s, e)
}"
                                                    Init="function(s, e) {cus_validate()}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <button type="button" id="puop_cust" data-name="cust" onclick="createPopUp($(this))" data-tablename="s_customers_sel_search" data-displayfields="custcode,custname,custadd,custmob" data-displayfieldshidden="custid"
                                                data-displayfieldscaption="كود العميل,إسم العميل,العنوان,التليفون" data-bindcontrols="txt_custid;txt_custname;Hf_cusid"
                                                data-bindfields="custcode;custname;custid" data-pkfield="custid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                            </button>

                                            <%-- <dx:ASPxButton UseSubmitBehavior="false" ID="ctn_add_cus" runat="server" AutoPostBack="False" Height="20px"  RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="اضافه عميل">
                                                <ClientSideEvents Click="function(s, e) {add_cus();return false;}" />
                                                <Image Height="20px" Url="~/Img/Icon/add-user.svg" Width="20px">
                                                </Image>
                                            </dx:ASPxButton>--%>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ctn_add_cus" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="اضافه عميل">

                                                <ClientSideEvents Click="function(s, e) {add_cus();}" />
                                                <Image Height="20px" Url="~/Img/Icon/add-user.svg" Width="20px">
                                                </Image>

                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="اسم العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custname" ClientInstanceName="txt_custname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <%--<dx:LayoutItem Caption="الرقم الضريبى للعميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custvat" ClientInstanceName="txt_custvat" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="عنوان العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custadd" ClientInstanceName="txt_custadd" runat="server" Theme="MaterialCompact">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="تليفون العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custmobile" ClientInstanceName="txt_custmobile" runat="server" Theme="MaterialCompact">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="المندوب">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_smanid" runat="server" ClientInstanceName="cmb_smanid" RightToLeft="True" TextField="smanname" Theme="MaterialCompact" ValueField="smanid" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                            </Items>
                        </dx:LayoutGroup>

                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false">

                            <Items>
                                <dx:LayoutItem Caption="المستخدم">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_ouser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_ouser">
                                                <ClientSideEvents Init="function(s, e) {
	txt_ouser.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الملاحظات" Width="50%">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxMemo ID="txt_sonotes" runat="server" ClientInstanceName="txt_sonotes" Theme="MaterialCompact" Width="100%">
                                            </dx:ASPxMemo>


                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <%--<dx:LayoutItem Caption="المستند">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <dx:ASPxLabel ID="lbl_invdoc" ClientInstanceName="lbl_invdoc" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="50%">
                                            </dx:ASPxLabel>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <asp:ImageButton ID="upload" runat="server" OnClick="upload_Click" ImageUrl="~/img/icon/import.svg" Height="30px" Width="30px" ToolTip="رفع ملف" />

                                            <asp:ImageButton ID="btn_download" runat="server" Height="30px" ImageUrl="~/img/icon/download.svg" OnClick="btn_download_Click" ToolTip="تحميل" Width="30px" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                            </Items>
                        </dx:LayoutGroup>


                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="الصافى بدون الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_netbvat" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_netbvat" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
	txt_netbvat.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="قيمه الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_vatvalue" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_vatvalue" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
	txt_vatvalue.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الصافى شامل الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_netavat" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_netavat" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
	txt_netavat.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <%--   <dx:LayoutItem Caption="الباقى">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_restvalue" runat="server" Font-Bold="True" Text="0" Theme="MaterialCompact" Width="80%" ClientInstanceName="txt_restvalue" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
                            
	txt_restvalue.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>--%>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>


                <br />
            </asp:Panel>
            <asp:HiddenField ID="HF_soid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_sinvc" ClientIDMode="Static" runat="server" />

            <asp:HiddenField ID="Hf_cusid" ClientIDMode="Static" runat="server" />

            <asp:HiddenField ID="HF_vattype" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hf_netbvat" ClientIDMode="Static" runat="server" />
            <br />
            <%--    <div style="text-align: right" id="accordion">
        <h1 dir="rtl">اصناف الفاتوره</h1>--%>

            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" ClientIDMode="Static" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none;">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="14" GroupBoxDecoration="box" Caption="اصناف أمر البيع" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف" Width="10%" ParentContainerStyle-Paddings-PaddingLeft="1" ParentContainerStyle-Paddings-PaddingRight="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_item" runat="server" ClientInstanceName="txt_itemcode" Theme="MaterialCompact" AutoPostBack="false" TabIndex="0">
                                                    <ClientSideEvents TextChanged="function(s,e){setItemData(s,e); }" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="15" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2" Paddings-PaddingBottom="13">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <button type="button" id="puop_item" data-name="items" onclick="createPopUp($(this))" data-tablename="st_itemunit_inv_sel_pop" data-displayfields="itemcode,itemname,unitname" data-displayfieldshidden="unitid,vat,factor,fprice,itemid,cprice"
                                                    data-displayfieldscaption="كود الصنف,اسم الصنف,الوحده,سعر التكلفه" data-bindcontrols="txt_itemcode;txtitem_name;txt_unit;HF_itemid;HF_unitid;txt_price;Hf_vat;HF_factor;HF_sodtlid"
                                                    data-bindfields="itemcode;itemname;unitname;itemid;unitid;fprice;vat;factor;''" data-pkfield="itemunitid" data-apiurl="/VanSalesService/items/FillPopup" style="margin-top: 10px" class="btn btn-sm btnsearchpopup" tabindex="1" />

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="الصنف" Width="15%" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txtitem_name" runat="server" Theme="MaterialCompact" ClientInstanceName="txtitem_name">
                                                    <ClientSideEvents Init="function(s, e) {
	txtitem_name.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="وحده القياس" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_unit" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_unit">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_unit.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="الكميه" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact" TabIndex="2">

                                                    <ClientSideEvents KeyUp="function(s, e) {multiply()}" GotFocus="function(s, e) {
	txt_qty.SelectAll();
}"
                                                        KeyPress="function(s, e) {
	isFloatNumber(this,event)
}" />

                                                </dx:ASPxTextBox>


                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="السعر" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_price" runat="server" Text="0" CssClass="auto-style2" Theme="MaterialCompact" ClientInstanceName="txt_price">
                                                    <ClientSideEvents Init="function(s, e) {
txt_price.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الاجمالى" Width="8%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_value" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_value" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_value.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم%" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discp" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discp" TabIndex="3">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiplydis()}" KeyPress="function(s, e) {isFloatNumber(this,event)}" GotFocus="function(s, e) {
	txt_discp.SelectAll();
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discvalue" TabIndex="4">
                                                    <ClientSideEvents TextChanged="function(s,e){txt_discp.SetValue(0)}"  KeyUp="function(s, e) {calac_disc();}" KeyPress="function(s, e) {isFloatNumber(this,event)}" GotFocus="function(s, e) {
	txt_discvalue.SelectAll();
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصافى" Width="9%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_netvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_netvalue" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {Subtract(); txt_netvalue.GetInputElement().readOnly = true;  }" TextChanged="function(s, e){calac_vat()}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الضريبه" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemvatvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txt_itemvatvalue">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_itemvatvalue.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="2" Paddings-PaddingTop="11" Paddings-PaddingBottom="13" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click" TabIndex="5">
                                                    <ClientSideEvents Click="function(s, e) {
	validate_dtl(s, e);
}" />
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px">
                                                    <ClientSideEvents Click="function(s, e) {clear_dtl()}" />
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">


                                                    <ClientSideEvents Click="function(s, e) {getgvrow();delData_Detail('/VanSalesService/orders/gorderDtl', 'sodtlid', 'HF_sodtlid',gvs_orderdtls) }" />


                                                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملاحظات" CaptionSettings-Location="Left" Width="32%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemnotes" ClientInstanceName="txt_itemnotes" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملف" CaptionSettings-Location="Left" Paddings-PaddingBottom="20" Width="35%" ParentContainerStyle-Paddings-PaddingLeft="5" ParentContainerStyle-Paddings-PaddingRight="5">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="FileUpload2" runat="server" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="" ColumnSpan="4" CaptionSettings-Location="Left" ParentContainerStyle-Paddings-PaddingLeft="10" ParentContainerStyle-Paddings-PaddingRight="176">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>

                                                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="ادخال سريع" Height="20px" Width="20px">
                                                    <Image Height="20px" Url="~/img/icon/bookmark.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {
                                       loadinv()}" />

                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>


                    <asp:HiddenField ID="HF_itemid" ClientIDMode="Static" runat="server" />

                    <asp:HiddenField ID="HF_unitid" runat="server" ClientIDMode="Static" />
                    <span class="mb-0 ">
                        <asp:HiddenField ID="Hf_vat" runat="server" ClientIDMode="Static" />
                        <%--<asp:HiddenField ID="hf_qty" runat="server" ClientIDMode="Static" />--%>
                        <%-- <asp:HiddenField ID="HF_cost" runat="server" ClientIDMode="Static" />--%>
                        <asp:HiddenField ID="HF_factor" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hf_disc" runat="server" ClientIDMode="Static" />
                    </span>
                    <asp:HiddenField ID="HF_sodtlid" runat="server" ClientIDMode="Static" />
                    <dx:ASPxGridView ID="gvs_orderdtls" ClientInstanceName="gvs_orderdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " Width="100%" KeyFieldName="sodtlid" Theme="MaterialCompact" RightToLeft="True" ClientSideEvents-RowDblClick="function(s,e){Gvs_Bind_dtl(s,e)}" OnDataBinding="gvs_orderdtls_DataBinding" OnDataBound="gvs_orderdtls_DataBound" OnCustomCallback="gvs_orderdtls_CustomCallback" CssClass="grid">



                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <Columns>
                            <%-- <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="sodtlid" ReadOnly="True" VisibleIndex="1" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="2" Caption="كود الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="3" Caption="اسم الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitid" VisibleIndex="4" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="5" Caption="الوحده">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="6" Caption="الكميه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="sprice" VisibleIndex="7" Caption="السعر">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="svalue" VisibleIndex="8" Caption="الاجمالى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discp" VisibleIndex="9" Caption="نسبه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discv" VisibleIndex="10" Caption="قيمه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="snet" VisibleIndex="11" Caption="الصافى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="12" Caption="الضريبه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="13" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="14" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="15" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
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
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="الكميه" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="svalue" ShowInColumn="الاجمالى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="snet" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="{0}" />
                        </TotalSummary>
                        <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="gvitemsExporter" runat="server" FileName="اصناف أمر البيع" GridViewID="gvs_orderdtls" PaperKind="A4" PaperName="اصناف امر البيع" RightToLeft="True" Landscape="True">
                        <PageHeader Center="أصناف امر البيع" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>

                </asp:Panel>
            </div>

        </ContentTemplate>
        <Triggers>
            <%--  <asp:PostBackTrigger ControlID="Panel1$formLayout$btn_download" />
            <asp:PostBackTrigger ControlID="Panel1$formLayout$upload" />--%>
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_attach" />
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_xlsxexport" />

        </Triggers>
    </asp:UpdatePanel>
    <style>
        .addcustpopup {
            width: 35px;
            height: 35px;
            padding: 5px 5px 5px;
            background-color: white;
            -webkit-box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
            margin-top: 20px;
    margin-right: 90%;
        }
    </style>
    <div class="modal" id="popupModaladdcust" style="z-index: 999999999;" data-name="aaa" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true" dir="rtl">
        <div class="modal-dialog" role="alertdialog" style="width: 100%">
            <div class="modal-content" style="height: 100%; min-height: 300px; width: 650px">
                <div class="modal-header">
                    <h5 class="modal-title" id="popupModalLabel">اضافه عميل</h5>
                    <button type="button" class="close float-left" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" >
    <%--    <div class="form-group row">
       <%-- <div class="col-md-10">
        <%--<input type="text" id="txt_search" onkeydown="searchitm(event)" autocomplete="off"   placeholder="بحث" class="form-control" />
        </div>
        <div class="col-md-2">

        </div>
        </div>--%>
           
                
           

     <div class="custgroup row">

                   <%-- <h6>كود العميل</h6>
                   
                    <input  type="text" id="txt_custcode"/>--%>
             <%--   <div class="custname col-md-6">--%>
                    <div class="col-md-6" style="float:right;">
                        <label class="form-label">اسم العميل</label>
                        <input  type="text" id="txt_cusname" class="form-control form-control-sm"  />
                    </div>
                    <div  class="col-md-6"  style="float:left;">
                        <label class="form-label">عنوان العميل</label>
                        <input  type="text" id="txt_cusadd" class="form-control form-control-sm"  />
                    </div>
           
                     <div class="col-md-6" style="float:right;">
                    
                           <label class="form-label">تليفون العميل</label>
                        <input  type="text" id="txt_cusmob" class="form-control form-control-sm"  />
                    </div>
                    <div class="col-md-6" style="float:left;">
                   
                        <label class="form-label">الرقم الضريبى</label>
                        <input  type="text" id="txt_cusvat" class="form-control form-control-sm"  />
                    </div>
                    <div class="col-md-6"  style="float:left;">
                        <label>المجموعه</label>
                        <select id="cmb_cusgroup" class="form-control form-control-sm" ></select>
                    </div>
                          
        <div   class="col-md-6 " >
     
            <button type="button" class="btn btn-sm addcustpopup " onclick="postCustData()" >
                <img src="../img/icon/save.svg" />
            </button>    
            
        </div>
         
        
       </div>
                </div>
            </div>

        </div>
        </div>
</asp:Content>
