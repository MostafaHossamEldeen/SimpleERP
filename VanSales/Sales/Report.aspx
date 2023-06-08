<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="VanSales.Report.Report" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server" ColorScheme="dark" AllowURLsWithJSContent="true"></dx:ASPxWebDocumentViewer>
        </div>
    </form>
</body>
</html>
