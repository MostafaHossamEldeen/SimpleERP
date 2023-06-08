<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="import_excel.aspx.cs" Inherits="VanSales.import_excel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
     <dx:ASPxButton ID="btn_upload" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_upload_Click"  RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="رفع ملف">
                    <Image Height="20px" Url="~/img/icon/import.png" Width="20px"></Image>
                </dx:ASPxButton>
</asp:Content>
