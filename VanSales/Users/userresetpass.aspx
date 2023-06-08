<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userresetpass.aspx.cs" Inherits="VanSales.userresetpass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <table class="dx-justification" style="width: 100%">
                <tr>
                    <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تغير كلمه المرور" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <table class="w-100" style="width: 100%; direction:rtl">
                            <tr>
                                <td style="text-align: center">
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="كلمة المرور الحالية" Theme="MaterialCompact">
                                    </dx:ASPxLabel>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcurrentpassword" Display="Dynamic" ErrorMessage="برجاء إدخال كلمة المرور" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="resetpass"></asp:RequiredFieldValidator>
                                </td>
                                <td style="text-align: right">
                                    <dx:ASPxTextBox ID="txtcurrentpassword" runat="server" NullText="كلمة المرور الحالية" Password="True" Theme="MaterialCompact">
                                    </dx:ASPxTextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="كلمة المرور الجديدة" Theme="MaterialCompact">
                                    </dx:ASPxLabel>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpassword" Display="Dynamic" ErrorMessage="برجاء إدخال كلمة المرور" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="resetpass"></asp:RequiredFieldValidator>
                                </td>
                                <td style="text-align: right">
                                    <dx:ASPxTextBox ID="txtnewpassword" runat="server" NullText="كلمة المرور الجديدة" Password="True" Theme="MaterialCompact">
                                    </dx:ASPxTextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="تأكيد كلمة المرور" Theme="MaterialCompact">
                                    </dx:ASPxLabel>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnewpassword" ControlToValidate="txtresetconfirmpassword" Display="Dynamic" ErrorMessage="كلمة المرور غير متطابقة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="resetpass"></asp:CompareValidator>
                                </td>
                                <td style="text-align: right">
                                    <dx:ASPxTextBox ID="txtresetconfirmpassword" runat="server" NullText="تأكيد كلمة المرور" Password="True" Theme="MaterialCompact">
                                    </dx:ASPxTextBox>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="resetpass" />
                                    <dx:ASPxLabel ID="lblmsg" runat="server" Theme="MaterialCompact" Font-Bold="True">
                                    </dx:ASPxLabel>
                                    <br />
                                    <dx:ASPxButton ID="btnresetpass" runat="server" OnClick="btnresetpass_Click" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" CausesValidation="true" ValidationGroup="resetpass">
                                    </dx:ASPxButton>
                                    <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <script type="text/javascript">
                function sweetexception(x) {
                    Swal.fire({
                        icon: 'error',
                        title: x,
                showConfirmButton: false,
                timer: 1500,
                //showClass: {
                //    popup: 'animate__animated animate__fadeInDown'
                //},
                //hideClass: {
                //    popup: 'animate__animated animate__fadeOutUp'
                //}
            })
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
