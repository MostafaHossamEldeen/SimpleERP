<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rtn_search.aspx.cs" Inherits="VanSales.Sales.Rtn_search" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnsearch">
        <div dir="rtl">
            <table>
                <tr>
                    <td>
                       بحث بــــــــ :</td>
                    <td>
                       <%-- <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>--%>
                        <dx:ASPxTextBox ID="txt_search" runat="server" Width="485px" Theme="MaterialCompact">
                            <ClientSideEvents Init="function(s, e) {
	s.Focus();
}" />
                        </dx:ASPxTextBox>

                    </td>
                    <td>
                        <asp:ImageButton ID="btnsearch" runat="server"  ToolTip="بحث" ImageUrl="~/img/icon/search.svg" Height="33px" Width="40px"/>
                    </td>
                </tr>
            </table>
        </div>
        <div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_rtn_inv_sel_search" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txt_search" DefaultValue="-1" Name="sinvid" PropertyName="Text" Type="String" ConvertEmptyStringToNull="False" />
                     
                   <asp:ControlParameter ControlID="txt_search" ConvertEmptyStringToNull="False"  Name="inv" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div dir="rtl">

            <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="gv_rtninv" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="sinvid" Theme="MaterialCompact"  RightToLeft="True" SettingsBehavior-AllowFocusedRow="true" OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated" KeyboardSupport="True" >
              <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowHeaderFilterButton="True" />
                
                <SettingsSearchPanel Visible="True" />
                  <ClientSideEvents RowDblClick="function(s, e) {
	s.GetRowValues(e.visibleIndex, 'sinvid', Done);
}" />
                  <settingsediting mode="PopupEditForm" popupeditformwidth="750px" popupeditformhorizontalalign="WindowCenter" popupeditformverticalalign="WindowCenter"></settingsediting>
                
                                    <settingspager pagesize="20" alwaysshowpager="True" ellipsismode="OutsideNumeric">
<FirstPageButton Visible="True"></FirstPageButton>

<LastPageButton Visible="True"></LastPageButton>

<Summary Position="Right" Text="صفحة {0} من {1} "></Summary>
</settingspager>

                <settings showtitlepanel="True" showfilterrow="True" showfooter="True"></settings>
<SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
                  <Columns>
                    <dx:GridViewDataTextColumn FieldName="sinvno" VisibleIndex="0" Caption="رقم الفاتوره">
                        <Settings AllowHeaderFilter="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sinvdocno" VisibleIndex="1" Caption="الرقم اليدوى">
                        <Settings AllowHeaderFilter="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="sinvdata" VisibleIndex="2" Caption="التاريخ">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="sinvid" VisibleIndex="3" ReadOnly="True" Visible="false">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                </Columns>
                 <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="750px" PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormVerticalAlign="WindowCenter"></SettingsEditing>
            </dx:ASPxGridView>
        </div>
    </form>
</body>
</html>


<script type="text/javascript">
    function Done(values) {
        window.opener.UpdateRtn(values);
        window.close();
    }

</script>
<%--<script src="../Scripts/App/sales/Rtn_inv.js"></script>--%>
