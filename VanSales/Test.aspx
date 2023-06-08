<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="VanSales.Test" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>
    <link href="Content/animate.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxTimer ID="ASPxTimer1" runat="server" ClientInstanceName="ASPxTimer1" Interval="3000">
                <ClientSideEvents Init="function(s, e) {
	ASPxTimer1.Start();
}"
                    Tick="function(s, e) {
	sweetsuccess(&#39;Done&#39;);
}"></ClientSideEvents>
            </dx:ASPxTimer>
        </div>
    </form>
    <script src="Scripts/sweetalert2.js"></script>
    <script src="Scripts/App/Public/Messages.js"></script>
</body>
</html>