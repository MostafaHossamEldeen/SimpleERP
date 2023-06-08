<%@ Page Title="طباعة الباركود" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="print_barcode.aspx.cs" Inherits="VanSales.Stock.print_barcode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/stock/print_barcode.js"></script>
    <table class="dx-justification" style="width: 100%">
        <tr>
            <td style="background-color: #dcdcdc;" class="text-center">
                <dx:ASPxLabel ID="lbltitle" runat="server" Text="طباعة الباركود" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12" dir="rtl">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="8" GroupBoxDecoration="box" Caption="الصنف" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف" ParentContainerStyle-Paddings-PaddingLeft="1" ParentContainerStyle-Paddings-PaddingRight="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemcode" runat="server" ClientInstanceName="txt_itemcode" Theme="MaterialCompact" AutoPostBack="false">
                                                    <ClientSideEvents TextChanged="function(s,e){setItemData(s,e); }" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Width="5%" Paddings-PaddingTop="15" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="5" Paddings-PaddingBottom="13">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <button type="button" id="puop_item" data-name="items" onclick="createPopUp($(this))" data-tablename="st_itemunit_sel_pop_barcodeprint"
                                                    data-displayfields="itemcode,itemname,unitname" data-displayfieldshidden="unitid,itemid"
                                                    data-displayfieldscaption="كود الصنف,اسم الصنف,الوحده"
                                                    data-bindcontrols="txt_itemcode;txt_barcode;txt_itemname;txt_unitname;HF_itemunitid"
                                                    data-bindfields="itemcode;barcode1;itemname;unitname;itemunitid" data-pkfield="itemunitid"
                                                    data-apiurl="/VanSalesService/items/FillPopup" style="margin-top: 10px" class="btn btn-sm btnsearchpopup">
                                                </button>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصنف" Width="20%" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
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
                                    <dx:LayoutItem Caption="الباركود" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_barcode" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_barcode">
                                                    <ClientSideEvents Init="function(s, e) {txt_barcode.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="العدد" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxSpinEdit ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Number="1" MinValue="1" MaxValue="9999">
                                                    <ClientSideEvents GotFocus="function(s, e) {txt_qty.SelectAll();}" />
                                                </dx:ASPxSpinEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="النوع" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_labelsize" runat="server" ClientInstanceName="cmb_labelsize" SelectedIndex="0">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Width="5%" Paddings-PaddingTop="10" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="5" Paddings-PaddingBottom="13">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" Height="20px" RenderMode="Secondary" Width="20px" ToolTip="طباعه" OnClick="btn_print_Click">
                                                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>
                    <asp:HiddenField ID="HF_itemunitid" runat="server" ClientIDMode="Static" />
                </div>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
</asp:Content>
