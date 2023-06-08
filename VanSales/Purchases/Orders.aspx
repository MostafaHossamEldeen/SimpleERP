<%@ Page Title="أوامـــر الــشــراء" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="VanSales.Purchases.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Purchases/Orders.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="أوامـــر الــشــراء" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ" OnClick="btn_Save_Click">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server"  AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/P_Orders/P_DelOrder','HF_poid')}" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <button type="button" title="بحث" id="PopUpControlSearch" data-name="ord" data-tablename="p_order_sel_popup" data-displayfields="pono,podocno,podate"
                    data-displayfieldshidden="poid,branchid,suppid,suppname,ouser,ponotes,netbvat,vatvalue,netavat,reqnos,vattype,pinvc"
                    data-displayfieldscaption="رقم أمر الشراء,رقم أمر الشراء اليدوي,التاريخ"
                    data-bindcontrols="txt_pono;txt_podocno;txt_podate;HF_poid;cmb_branchid;txt_suppid;txt_suppname;txt_ouser;txt_ponotes;txt_netbvat;txt_vatvalue;txt_netavat;txt_reqnos;rbl_vattype;hf_pinvc"
                    data-bindfields="pono;podocno;podate;poid;branchid;suppid;suppname;ouser;ponotes;netbvat;vatvalue;netavat;reqnos;vattype;pinvc"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="poid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه" OnClick="btn_print_Click">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_pay" runat="server" AutoPostBack="False" ClientInstanceName="btn_pay" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="فاتورة شراء" OnClick="btn_pay_Click">
                    <Image Height="20px" Url="~/img/icon/paid.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />
            </div>
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="5" GroupBoxDecoration="Box" Caption="البيانات الاساسيه">
                            <Items>
                                <dx:LayoutItem Caption="رقم أمر الشراء">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_pono" runat="server" ClientInstanceName="txt_pono" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">
                                                <ClientSideEvents KeyDown="function(s,e){preventwrite(s,e);}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="رقم أمر الشراء اليدوي">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_podocno" runat="server" ClientInstanceName="txt_podocno" Theme="MaterialCompact" Style="margin-right: 0px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="الفرع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="التاريخ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxDateEdit ID="txt_podate" runat="server" RightToLeft="True" Theme="MaterialCompact" ClientInstanceName="txt_podate">
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="طلبيات شراء" Paddings-PaddingTop="16">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxHyperLink ID="txt_reqnos" runat="server" ClientInstanceName="txt_reqnos" Font-Bold="True" ForeColor="#009933" Font-Size="Medium">
                                            </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="نوع الضريبة" ColumnSpan="3" CaptionCellStyle-Paddings-PaddingTop="10">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxRadioButtonList ID="rbl_vattype" ClientInstanceName="rbl_vattype" runat="server">
                                            </dx:ASPxRadioButtonList>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="box" Caption="بيانات المورد" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="المورد">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_suppid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_suppid" AutoPostBack="false">
                                                <ClientSideEvents ValueChanged="function(s, e) {SetSuppData(s, e);}" Init="function(s, e) {SuppValidate();}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <button type="button" id="puop_supp" title="بحث" data-name="supp" onclick="createPopUp($(this),'popupModalsearch')" data-tablename="p_supplier_sel_search" data-displayfields="suppid,suppname,suppvatno,country"
                                                data-displayfieldshidden="" data-displayfieldscaption="كود المورد,إسم المورد,الرقم الضريبي,المدينة" data-bindcontrols="txt_suppid;txt_suppname"
                                                data-bindfields="suppid;suppname" data-pkfield="suppid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                            </button>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <ParentContainerStyle>
                                        <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                    </ParentContainerStyle>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="اسم المورد">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_suppname" ClientInstanceName="txt_suppname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="المستخدم">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_ouser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_ouser">
                                                <ClientSideEvents Init="function(s, e) {txt_ouser.GetInputElement().readOnly = true;}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="الملاحظات" ColumnSpan="3" Width="32%">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxMemo ID="txt_ponotes" runat="server" ClientInstanceName="txt_ponotes" Theme="MaterialCompact" Width="100%">
                                            </dx:ASPxMemo>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="الصافى بدون الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_netbvat" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_netbvat" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {txt_netbvat.GetInputElement().readOnly = true;}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="قيمه الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_vatvalue" runat="server" Text="0" AutoPostBack="true" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_vatvalue" Font-Size="Medium" ForeColor="Black" OnTextChanged="txt_vatvalue_TextChanged">
                                                <ClientSideEvents KeyDown="function(s, e) {decimale3num(s, e);}" GotFocus="function(s, e) {txt_vatvalue.SelectAll();}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="الصافى شامل الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_netavat" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_netavat" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {txt_netavat.GetInputElement().readOnly = true;}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
                <br />
            </asp:Panel>
            <asp:HiddenField ID="HF_poid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hf_pinvc" ClientIDMode="Static" runat="server" />
            <br />
            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none;">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="13" GroupBoxDecoration="box" Caption="اصناف أمر الشراء" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف" Width="7.5%" ParentContainerStyle-Paddings-PaddingLeft="1" ParentContainerStyle-Paddings-PaddingRight="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemcode" runat="server" ClientInstanceName="txt_itemcode" Theme="MaterialCompact" AutoPostBack="false">
                                                    <ClientSideEvents TextChanged="function(s,e){setItemData(s,e); }" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="15" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2" Paddings-PaddingBottom="13">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <button type="button" id="puop_item" data-name="items" onclick="createPopUp($(this))" data-tablename="st_itemunit_sel_pop"
                                                    data-displayfields="itemcode,itemname,unitname" data-displayfieldshidden="unitid,vat,factor,pprice,itemid"
                                                    data-displayfieldscaption="كود الصنف,اسم الصنف,الوحده"
                                                    data-bindcontrols="txt_itemcode;txt_itemname;txt_unitname;HF_itemid;hf_factor;HF_unitid;txt_pprice;Hf_vat"
                                                    data-bindfields="itemcode;itemname;unitname;itemid;factor;unitid;pprice;vat" data-pkfield="itemunitid"
                                                    data-apiurl="/VanSalesService/items/FillPopup" style="margin-top: 10px" class="btn btn-sm btnsearchpopup">
                                                </button>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصنف" Width="15%" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_itemname">
                                                    <ClientSideEvents Init="function(s, e) {txt_itemname.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الوحدة" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_unitname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_unitname">
                                                    <ClientSideEvents Init="function(s, e) {txt_unitname.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الكميه" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiply();}" GotFocus="function(s, e) {txt_qty.SelectAll();}" KeyPress="function(s, e) {decimale3num(s, e);}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="السعر" Width="7.5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_pprice" runat="server" Text="0" CssClass="auto-style2" Theme="MaterialCompact" ClientInstanceName="txt_pprice">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiply();}" GotFocus="function(s, e) {txt_pprice.SelectAll();}" KeyPress="function(s, e) {decimale3num(s, e);}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الاجمالى" Width="7.5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_pvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_pvalue" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {txt_pvalue.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم%" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_descp" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_descp">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiplydis();}" KeyPress="function(s, e) {decimale3num(s, e);}" GotFocus="function(s, e) {txt_descp.SelectAll();}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_descv" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_descv">
                                                    <ClientSideEvents KeyUp="function(s, e) {calac_desc();txt_descp.SetValue(0);}" KeyPress="function(s, e) {decimale3num(s, e);}" GotFocus="function(s, e) {txt_descv.SelectAll();}"/>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصافى" Width="9%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_pnet" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_pnet" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {Subtract(); txt_pnet.GetInputElement().readOnly = true;}" TextChanged="function(s, e){calac_vat()}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الضريبه" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemvatvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txt_itemvatvalue">
                                                    <ClientSideEvents Init="function(s, e) {txt_itemvatvalue.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="2" Paddings-PaddingTop="11" Paddings-PaddingBottom="13" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {validate_dtl(s, e);}" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px">
                                                    <ClientSideEvents Click="function(s, e) {clear_dtl();}" />
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                                                    <ClientSideEvents Click="function(s, e) {getgvdtlrow();delData_Detail('/VanSalesService/P_Orders/P_DelorderDtl', 'podtlid', 'HF_podtlid',gv_orderdtls) }" />
                                                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملاحظات" ColumnSpan="6" CaptionSettings-Location="Left" Width="32%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxMemo ID="txt_itemnotes" ClientInstanceName="txt_itemnotes" runat="server" Theme="MaterialCompact"></dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملف" CaptionSettings-Location="Left" Paddings-PaddingBottom="20" Width="20%" ParentContainerStyle-Paddings-PaddingLeft="5" ParentContainerStyle-Paddings-PaddingRight="5">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="fub_dtlfile" runat="server" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="4" CaptionSettings-Location="Left" ParentContainerStyle-Paddings-PaddingLeft="10" ParentContainerStyle-Paddings-PaddingRight="176">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>
                    <asp:HiddenField ID="HF_itemid" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_unitid" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hf_factor" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="Hf_vat" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_podtlid" runat="server" ClientIDMode="Static" Value="0" />
                    <dx:ASPxGridView ID="gv_orderdtls" ClientInstanceName="gv_orderdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey="" Width="100%" KeyFieldName="podtlid" Theme="MaterialCompact" RightToLeft="True" ClientSideEvents-RowDblClick="function(s,e){gv_Bind_dtl(s,e);}" OnDataBinding="gv_orderdtls_DataBinding" OnDataBound="gv_orderdtls_DataBound" OnCustomCallback="gv_orderdtls_CustomCallback">
                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="podtlid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="1" Caption="كود الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="2" Caption="اسم الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitid" VisibleIndex="3" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="4" Caption="الوحده">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="5" Caption="الكميه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="pprice" VisibleIndex="6" Caption="السعر">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="pvalue" VisibleIndex="8" Caption="الاجمالى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="descp" VisibleIndex="9" Caption="نسبه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="descv" VisibleIndex="10" Caption="قيمه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="pnet" VisibleIndex="11" Caption="الصافى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="13" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="14" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="15" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="16" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
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
                            <dx:ASPxSummaryItem FieldName="pprice" ShowInColumn="السعر" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="pnet" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="{0}" />
                        </TotalSummary>
                          <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="gvitemsExporter" runat="server" FileName="اصناف أمر الشراء" GridViewID="gv_orderdtls" PaperKind="A4" PaperName="اصناف أمر الشراء" RightToLeft="True" Landscape="True">
                        <PageHeader Center="أصناف أمر الشراء" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_attach" />
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_xlsxexport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
