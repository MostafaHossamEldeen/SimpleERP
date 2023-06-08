<%@ Page Title="Report Designer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportDesigner.aspx.cs" Inherits="VanSales.ReportDesigner" %>
<%@ Register assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxReportDesigner ID="ASPxReportDesigner" runat="server" RightToLeft="False">
    </dx:ASPxReportDesigner>
</asp:Content>
