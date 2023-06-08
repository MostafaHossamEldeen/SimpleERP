<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XrReportDesginer.aspx.cs" Inherits="VanSales.ReportDesginer.XrReportDesginer" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web.ClientControls" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Designer</title>
    <style type="text/css">
        body {
            margin: 0;
        }

        .fullscreen {
            position: absolute;
            top: 0;
            bottom: 0;
            right: 0;
            left: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="fullscreen">
            <dx:ASPxReportDesigner ID="ASPxReportDesigner1" runat="server" Height="100%" SettingsWizard-EnableObjectDataSource="true" DisableHttpHandlerValidation="False" >
            </dx:ASPxReportDesigner>
        </div>
    </form>
</body>
</html>