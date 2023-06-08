<%@ Page Title="فك ترحيل الحسابات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="acc_unpost.aspx.cs" Inherits="VanSales.GL.acc_unpost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="فك ترحيل الحسابات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_btn_save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="فك الترحيل">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
            </div>
            <br />
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                            <Items>
                                <dx:LayoutItem Caption="نوع المستند">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_typeid" runat="server" ClientInstanceName="cmb_typeid"></dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="رقم المستند">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_docno" ClientInstanceName="txt_docno" runat="server" NullText="رقم المستند"></dx:ASPxTextBox>
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
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script type="text/javascript">
        function validate(s, e) {
            if (txt_docno.GetValue() == "" || txt_docno.GetValue() == null) {
                sweetinfo("برجاء ادخال رقم المستند");
                txt_docno.Focus();
                e.txt_docno.Focus();
                return;
            }
        }
    </script>
</asp:Content>
