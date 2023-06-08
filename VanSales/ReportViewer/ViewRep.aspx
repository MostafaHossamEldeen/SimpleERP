<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="ViewRep.aspx.cs" Inherits="VanSales.ReportViewer.ViewRep" %>

<%@ Register Src="~/Controls/PdfViewer.ascx" TagPrefix="uc1" TagName="PdfViewer" %>

<html>
    <head>

    </head>
    <body>
        <form runat="server">
<uc1:PdfViewer runat="server" id="PdfViewer" />
            </form>
    </body>
</html>
    

