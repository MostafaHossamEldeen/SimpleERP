<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="VanSales.ReportViewer.Viewer" %>
<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>طباعه</title>
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
    
    .dxrd-preview .dxrd-right-panel-collapse, .dxrd-preview .dxrd-right-panel, .dxrd-preview .dxrd-right-tabs {  
        display: none;  
    }  


    .dxrd-designer-wrapper .dx-shadow {
    position: initial!important;
   
}
</style>  

</head>
<body>
    <form id="form1" runat="server">
        <div class="fullscreen">
            <dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer1" runat="server" Width="100%" Height="100%" SettingsMobile-ReaderMode="true" ClientSideEvents-Init="function(s,e){OnInit(s,e)}">
            </dx:ASPxWebDocumentViewer>
        </div>
    </form>
    <script>
        function OnInit(s, e) {
            var preview = s.GetPreviewModel();
            if (preview) {
                preview.tabPanel.collapsed(true);
            }
        }
    </script>
</body>
</html>