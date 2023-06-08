<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VanSales.ReportDesginer.Default" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Designer</title>
</head>
<body>
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <dx:ASPxFormLayout runat="server" ID="formLayout" RightToLeft="False">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="Box" Caption="Report Designer">
                            <Items>
                                <dx:LayoutItem Caption="Module" HorizontalAlign="Center" VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="Cmb_SelectModule" runat="server" ClientInstanceName="Cmb_SelectModule" ValueType="System.String" OnSelectedIndexChanged="Cmb_SelectModule_SelectedIndexChanged" NullText="Module Name" NullTextDisplayMode="UnfocusedAndFocused" AutoPostBack="true" RightToLeft="False"></dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False" VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton ID="btn_design" runat="server" AutoPostBack="False" RenderMode="Secondary" ToolTip="DESIGN" Image-Url="~/Img/Icon/edit.svg" Image-Height="20px" Image-Width="20px" UseSubmitBehavior="false" RightToLeft="False" VerticalAlign="Middle" HorizontalAlign="Center" Text="Design">
                                                <ClientSideEvents Click="function(s, e) { location.href = &#39;XrReportDesginer.aspx&#39;;}"></ClientSideEvents>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center" VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxImage ID="img_emaxlogo" runat="server" ImageUrl="~/VanSalesThemsFile/img/logo512.svg" AlternateText="E-MaxIT International" Height="100px"></dx:ASPxImage>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center" VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxImage ID="img_circleslogo" runat="server" ImageUrl="../VanSalesThemsFile/img/emax.png" AlternateText="Circles" Height="100px"></dx:ASPxImage>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
