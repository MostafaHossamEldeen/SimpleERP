<%@ Page Title="أعدادات النظام" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sys_settings.aspx.cs" Inherits="VanSales.Sys.sys_settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="أعدادات النظام" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_cancel" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_cancel_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="إلغاء">
                    <Image Height="20px" Url="~/img/icon/cancel.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
            </div>
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                            <Items>
                                <dx:LayoutItem Caption="مستويات شجره الحسابات">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxSpinEdit ID="txt_chartlvl" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_chartlvl" MinValue="0" MaxValue="50" Number="0">
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="نسبه الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_vat" ClientInstanceName="txt_vat" runat="server" CssClass="auto-style2" Theme="MaterialCompact">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="نوع الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_vattype" runat="server" ClientInstanceName="cmb_vattype" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="طريقه حساب التكلفه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_costcalc" runat="server" ClientInstanceName="cmb_costcalc" RightToLeft="True" Theme="MaterialCompact" SelectedIndex="0">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_allowing" runat="server" Text="الصرف بدون رصيد" AutoPostBack="True" ClientInstanceName="chk_allowing"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_autoemp" runat="server" Text="رقم تلقائى للموظف" AutoPostBack="True" ClientInstanceName="chk_autoemp"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_autoitem" runat="server" Text="رقم تلقائى للاصناف" AutoPostBack="True" ClientInstanceName="chk_autoitem"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="عدد مرات الطباعه في نقطه البيع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxSpinEdit ID="txt_printno" ClientInstanceName="txt_printno" runat="server" CssClass="auto-style2" Theme="MaterialCompact" MinValue="0" MaxValue="9" Number="0">
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_sprice" runat="server" Text="تعديل سعر الصنف بالفاتورة" AutoPostBack="True" ClientInstanceName="chk_sprice"></dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="أصناف الميزان" CaptionCellStyle-Paddings-PaddingTop="10">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxRadioButtonList ID="rbl_wpitem" ClientInstanceName="rbl_wpitem" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None">
                                                <Items>
                                                    <dx:ListEditItem Text="سعر" Value="False" Selected="true"></dx:ListEditItem>
                                                    <dx:ListEditItem Text="وزن" Value="True"></dx:ListEditItem>
                                                </Items>
                                            </dx:ASPxRadioButtonList>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="بداية باركود أصناف الميزان" Visible="false">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_wpitemdigit" ClientInstanceName="txt_wpitemdigit" runat="server" CssClass="auto-style2" MaxLength="2">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>