<%@ Page Title="مرتـجع المشتريات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rtn_P_Inv.aspx.cs" Inherits="VanSales.Purchases.Rtn_P_Inv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Purchases/Rtn_PInv.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="مرتـجع المشتريات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_addnew_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/P_inv/RtnInvDelMaster', 'HF_pinvid') }" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <button type="button" id="PopUpControlSearch" data-name="inv" data-tablename="p_rtn_inv_sel_search" data-displayfields="pinvno,pinvdocno,pinvdate"
                    data-displayfieldshidden="pinvpay,branchid,ccid,suppid,suppname,supptvat,puser,pnotes,netbvat,vatvalue,netavat,invpic,docid,docno,pinvid,vattype,withoutinv,postst,postacc"
                    data-displayfieldscaption="رقم الفاتوره,الرقم اليدوى,التاريخ"
                    data-bindcontrols="txt_pinvno;txt_pinvdocno;txt_pinvdate;cmb_branchid;cmb_pinvpay;cmb_ccid;txt_suppid;txt_suppname;txt_supptvat;txt_puser;txt_pnotes;txt_netbvat;txt_vatvalue;txt_netavat;lbl_invpic;txt_docno;HF_pinvid;HF_docid;ch_inv;rbl_vattype;hf_postst;hf_postacc;hf_vochrno"
                    data-bindfields="pinvno;pinvdocno;pinvdate;branchid;pinvpay;ccid;suppid;suppname;supptvat;puser;pnotes;netbvat;vatvalue;netavat;invpic;docno;pinvid;docid;withoutinv;vattype;postst;postacc;vochrno"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="pinvid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postst" runat="server" ClientInstanceName="btn_postst" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل مستودعات">
                    <Image Height="20px" Url="~/img/icon/poststock.svg" Width="20px"></Image>
                    <ClientSideEvents Click="function(s,e){postp_rtn_InvStock(s,e);}" />
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل حسابات">
                    <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                    <ClientSideEvents Click="function(s,e){postp_rtn_InvAcc(s,e);}" />
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه" OnClick="btn_print_Click">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
            </div>
            <br />
            <div dir="rtl">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                    <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="5" GroupBoxDecoration="None">
                                <Items>
                                    <dx:LayoutItem Caption="رقم المرتجع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_pinvno" ClientInstanceName="txt_pinvno" runat="server" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">
                                                    <ClientSideEvents Init="function(s, e) {txt_pinvno.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="رقم يدوى للمرتجع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_pinvdocno" ClientInstanceName="txt_pinvdocno" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="نوع سداد المرتجع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_pinvpay" runat="server" ClientInstanceName="cmb_pinvpay" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false"></dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
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
                                                <dx:ASPxDateEdit ID="txt_pinvdate" runat="server" RightToLeft="True" Theme="MaterialCompact" ClientInstanceName="txt_pinvdate">
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="مراكز التكلفه">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_ccid" runat="server" ClientInstanceName="cmb_ccid" RightToLeft="True" TextField="ccname" Theme="MaterialCompact" ValueField="ccid" AutoPostBack="false">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="رقم الفاتوره">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_docno" ClientInstanceName="txt_docno" runat="server" Theme="MaterialCompact">
                                                    <ClientSideEvents TextChanged="function(s, e) {setInvData(s, e)}"></ClientSideEvents>
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 5px;">
                                                            <button type="button" id="btn_search_inv" data-name="inv" data-tablename="p_inv_sel_search"
                                                                data-displayfields="pinvno,pinvdocno,pinvdate"
                                                                data-displayfieldscaption="رقم الفاتوره,الرقم اليدوى,التاريخ"
                                                                data-displayfieldshidden="suppid,suppname,suppvat,pinvid,vattype"
                                                                data-bindcontrols="txt_docno;txt_suppid;txt_suppname;txt_suppvat;HF_docid;rbl_vattype"
                                                                data-bindfields="pinvno;suppid;suppname;suppvat;pinvid;vattype"
                                                                data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="pinvid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                                                            </button>
                                                        </td>
                                                        <td style="padding: 5px;">
                                                            <dx:ASPxCheckBox ID="chk_rtnall" runat="server" Text="ارجاع الكل" AutoPostBack="True" ClientInstanceName="chk_rtnall"></dx:ASPxCheckBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxCheckBox ID="ch_withoutinv" runat="server" Text="بدون فاتوره" ClientInstanceName="ch_inv" CheckState="Unchecked" AutoPostBack="true" OnCheckedChanged="ch_withoutinv_CheckedChanged" >
                                                                <ClientSideEvents Init="function(s, e) {supp_validate(s, e), validate_withoutinv(s, e)}" />
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                    </tr>
                                                </table>
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
                                                  <ClientSideEvents ValueChanged="function(s, e) {SetSuppData(s, e);}" Init="function(s, e) {supp_validate();}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <button type="button" id="puop_supp" title="بحث" data-name="supp" onclick="createPopUp($(this),'popupModalsearch')" data-tablename="p_supplier_sel_search" data-displayfields="suppid,suppname,suppvatno,country"
                                                data-displayfieldshidden="" data-displayfieldscaption="كود المورد,إسم المورد,الرقم الضريبي,المدينة" data-bindcontrols="txt_suppid;txt_suppname;txt_suppvat"
                                                data-bindfields="suppid;suppname;suppvatno" data-pkfield="suppid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
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
                                <dx:LayoutItem Caption="الرقم الضريبى للمورد">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_suppvat" ClientInstanceName="txt_suppvat" runat="server" Theme="MaterialCompact">
                                                <ClientSideEvents KeyDown="function(s, e) {preventwrite(s, e);}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                            <dx:LayoutGroup ColCount="6" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                                <Paddings PaddingTop="10px" />
                                <Items>
                                    <dx:LayoutItem Caption="المستخدم">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_puser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_puser">
                                                    <ClientSideEvents Init="function(s, e) {txt_puser.GetInputElement().readOnly = true; }" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملاحظات"  ColumnSpan="3" Width="32%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxMemo ID="txt_pnotes" ClientInstanceName="txt_pnotes" runat="server" Theme="MaterialCompact" Width="100%">
                                                </dx:ASPxMemo>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="المستند" Paddings-PaddingTop="10">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="fub_invpic" runat="server" />
                                                <dx:ASPxLabel ID="lbl_invpic" ClientInstanceName="lbl_invpic" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="80%">
                                                </dx:ASPxLabel>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_upload" runat="server" OnClick="btn_upload_Click" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="رفع ملف">
                                                    <Image Height="20px" Url="~/img/icon/import.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_download" runat="server" OnClick="btn_download_Click" AutoPostBack="False" Height="30px" RenderMode="Secondary" Theme="MaterialCompact" Width="30px" ToolTip="تحميل">
                                                    <Image Height="20px" Url="~/img/icon/download.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                            <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
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
                                                <dx:ASPxTextBox ID="txt_vatvalue" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_vatvalue" Font-Size="Medium" ForeColor="Black">
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
                                    <dx:LayoutItem Caption="الباقى">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_restvalue" runat="server" Font-Bold="True" Text="0" Theme="MaterialCompact" Width="80%" ClientInstanceName="txt_restvalue" Font-Size="Medium" ForeColor="Black">
                                                    <ClientSideEvents Init="function(s, e) {txt_restvalue.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
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
                                    <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxHyperLink ID="lbl_vochrno" runat="server" ClientInstanceName="lbl_vochrno" Font-Bold="True" ForeColor="#009933" Font-Size="Medium">
                                                <ClientSideEvents Click='function(s, e) {
	window.open("/GL/Vouchers.aspx?vchrno="+lbl_vochrno.GetValue(),"_blank")
}'></ClientSideEvents>
                                            </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>
                    <br />
                </asp:Panel>
            </div>
            <asp:HiddenField ID="HF_pinvid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hf_postst" ClientIDMode="Static" runat="server" Value="0"/>
            <asp:HiddenField ID="hf_postacc" ClientIDMode="Static" runat="server" Value="0"/>
            <asp:HiddenField ID="HF_docid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_invid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hf_qty" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hf_disc" runat="server" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_vochrno" />
            <br />
            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" Font-Bold="true" Direction="RightToLeft" Style="text-align: right; display: none">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="14" GroupBoxDecoration="box" Caption="اصناف الفاتوره" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف" Width="10%" ParentContainerStyle-Paddings-PaddingLeft="1" ParentContainerStyle-Paddings-PaddingRight="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_item" runat="server" ClientInstanceName="txt_itemcode" Theme="MaterialCompact" AutoPostBack="false" TabIndex="0">
                                                    <ClientSideEvents Init="function(s,e){item_readonly()}" TextChanged="function(s,e){setItemData(s,e); }" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="15" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2" Paddings-PaddingBottom="13">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <button type="button" id="puop_item" data-name="items" onclick="createPopUp($(this))" data-tablename="p_rtn_invdtls_search_sel" data-displayfields="itemcode,itemname,unitname" data-displayfieldshidden="unitid,vat,factor,itemid,pprice"
                                                    data-displayfieldscaption="كود الصنف,اسم الصنف,الوحده" data-bindcontrols="txt_itemcode;txtitem_name;txt_unit;HF_itemid;HF_unitid;txt_price;Hf_vat;HF_factor;HF_invdtlid"
                                                    data-bindfields="itemcode;itemname;unitname;itemid;unitid;pprice;vat;factor;''" data-pkfield="itemunitid" data-paramaternames="HF_docid" data-apiurl="/VanSalesService/P_inv/ItemsPRtn" style="margin-top: 10px" class="btn btn-sm btnsearchpopup" tabindex="1" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصنف" Width="15%" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txtitem_name" runat="server" Theme="MaterialCompact" ClientInstanceName="txtitem_name">
                                                    <ClientSideEvents Init="function(s, e) {txtitem_name.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الوحدة" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_unit" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_unit">
                                                    <ClientSideEvents Init="function(s, e) {txt_unit.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الكميه" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact" TabIndex="2">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiply();}" GotFocus="function(s, e) {txt_qty.SelectAll();}" KeyPress="function(s, e) {decimale3num(s, e);}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="السعر" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_price" runat="server" Text="0" CssClass="auto-style2" Theme="MaterialCompact" ClientInstanceName="txt_price">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiply();}" GotFocus="function(s, e) {txt_price.SelectAll();}" KeyPress="function(s, e) {decimale3num(s, e);}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الاجمالى" Width="8%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_value" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_value" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {txt_value.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم%" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discp" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discp" TabIndex="3">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiplydis()}" KeyPress="function(s, e) {decimale3num(s, e);}" GotFocus="function(s, e) {txt_discp.SelectAll();}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discvalue" TabIndex="4">
                                                    <ClientSideEvents KeyUp="function(s, e) {calac_disc();txt_discp.SetValue(0);}" KeyPress="function(s, e) {decimale3num(s, e);}" GotFocus="function(s, e) {txt_discvalue.SelectAll();}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصافى" Width="9%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_netvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_netvalue" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {Subtract(); txt_netvalue.GetInputElement().readOnly = true;}" TextChanged="function(s, e){calac_vat()}" />
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
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_dtls" runat="server" ClientInstanceName="btn_save_dtls" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click" TabIndex="5">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {validate_dtl(s, e);}" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px">
                                                    <ClientSideEvents Click="function(s, e) {clear_dtl()}" />
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                                                    <ClientSideEvents Click="function(s, e) {getgvrow();delData_Detail('/VanSalesService/P_inv/gRtnInvDtl', 'invdtlid', 'HF_invdtlid',gv_invdtls); }" />
                                                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملاحظات"  ColumnSpan="6" CaptionSettings-Location="Left" Width="32%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
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
                                                <dx:ASPxButton ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
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
                    <asp:HiddenField ID="Hf_vat" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_factor" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_invdtlid" ClientIDMode="Static" runat="server" />
                    <dx:ASPxGridView ID="gv_invdtls" runat="server" ClientInstanceName="gv_invdtls" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="True" AccessKey=" " Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" OnDataBinding="gv_invdtls_DataBinding" OnCustomCallback="gv_invdtls_CustomCallback" ClientSideEvents-RowDblClick="function(s,e){gv_Bind_dtl(s, e)}" OnDataBound="gv_invdtls_DataBound">
                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="invdtlid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="1" Visible="false">
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
                            <dx:GridViewDataTextColumn FieldName="price" VisibleIndex="6" Caption="السعر">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="icost" VisibleIndex="7" Caption="التكلفه" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="value" VisibleIndex="8" Caption="الاجمالى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discp" VisibleIndex="9" Caption="نسبه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discvalue" VisibleIndex="10" Caption="قيمه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="netvalue" VisibleIndex="11" Caption="الصافى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="12" Caption="الضريبه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="13" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="14" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                        <ClientSideEvents RowClick="function(s, e) {onKeyPress1(s, e)}" />
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
                            <dx:ASPxSummaryItem FieldName="price" ShowInColumn="السعر" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="netvalue" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="{0}" />
                            <dx:ASPxSummaryItem FieldName="value" ShowInColumn="value" SummaryType="Sum" DisplayFormat="{0}" />
                        </TotalSummary>
                          <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="gvitemsExporter" runat="server" FileName="اصناف الفاتوره" GridViewID="gv_invdtls" PaperKind="A4" PaperName="اصناف الفاتوره" RightToLeft="True" Landscape="True">
                        <PageHeader Center="أصناف الفاتوره" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>
                </asp:Panel>
            </div>
            <br />
            <asp:Panel ID="p_invpay" runat="server" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none">
                <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="6" GroupBoxDecoration="box" Caption="طرق الدفــع" UseDefaultPaddings="false" Paddings-PaddingTop="10" CellStyle-Font-Bold="true">
                            <Items>
                                <dx:LayoutItem Caption="طريقه الدفع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_paytype" runat="server" ClientInstanceName="cmb_paytype" AutoPostBack="true" Theme="MaterialCompact" TextField="paytname" ValueField="paytypeid" RightToLeft="True"></dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="اسم الحساب">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_paychartid" runat="server" ClientInstanceName="cmb_paychartid" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="القيمه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_payvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txt_payvalue">
                                                <ClientSideEvents GotFocus="function(s, e) {txt_payvalue.SelectAll();}" KeyPress="function(s, e) {decimale3num(s, e)}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="رقم مرجعى">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_payno" ClientInstanceName="txt_payno" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="بيانات">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_payref" ClientInstanceName="txt_payref" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_pay_Click">
                                                <Image Height="20px" Url="~/Img/Icon/save.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="brn_new_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" OnClick="brn_new_pay_Click">
                                                <ClientSideEvents Click="function(s, e) {Clear_pay();}"></ClientSideEvents>
                                                <Image Height="20px" Url="~/Img/Icon/add-new.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px">
                                                <ClientSideEvents Click="function(s, e) {getrow();delData_Detail('/VanSalesService/P_inv/gRtnInvPay', 'invpayid', 'Hf_payid',gv_invpay)}" />
                                                <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
                <asp:HiddenField ID="Hf_payid" runat="server" ClientIDMode="Static" />
                <dx:ASPxGridView ID="gv_invpay" runat="server" ClientInstanceName="gv_invpay" AutoGenerateColumns="False" EnableCallBacks="False" Width="100%" KeyFieldName="invpayid" Theme="MaterialCompact" RightToLeft="True" ClientSideEvents-RowDblClick="function(s,e){gv_Bind_Pay(s,e)}" OnCustomCallback="gv_invpay_CustomCallback" OnDataBinding="gv_invpay_DataBinding" OnDataBound="gv_invpay_DataBound" CssClass="grid">
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="invpayid" ReadOnly="True" VisibleIndex="0" Visible="false">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="pinvid" VisibleIndex="1" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="paytypeid" VisibleIndex="2" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payname" VisibleIndex="3" Caption="طريقه الدفع">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="paychartid" VisibleIndex="4" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="paychartname" VisibleIndex="5" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payvalue" VisibleIndex="6" Caption="القيمه">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payno" VisibleIndex="7" Caption="الرقم المرجعي">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payref" VisibleIndex="8" Caption="البيانات">
                        </dx:GridViewDataTextColumn>
                    </Columns>
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
                        <dx:ASPxSummaryItem FieldName="payvalue" ShowInColumn="القيمه" SummaryType="Sum" DisplayFormat=" {0}" />
                    </TotalSummary>
                      <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                </dx:ASPxGridView>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Panel1$formLayout$btn_download" />
            <asp:PostBackTrigger ControlID="Panel1$formLayout$btn_upload" />
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_attach" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
