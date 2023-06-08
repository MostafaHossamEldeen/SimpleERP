<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="item_search.aspx.cs" Inherits="VanSales.item_search" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>بحث الاصنــــاف</title>
</head>
<body>
    <form id="form1" runat="server" >
        <div dir="rtl">
            <table>
                <tr>
                    <td>
                       بحث بــــــــ :</td>
                    <td>
                
                        <dx:ASPxTextBox ID="txt_search" runat="server" Width="453px" Theme="MaterialCompact">
                            <ClientSideEvents Init="function(s, e) {
	s.Focus();
}" />
                        </dx:ASPxTextBox>

                    </td>
                    <td>
                        <asp:ImageButton ID="btnsearch" runat="server"   ToolTip="بحث" ImageUrl="~/img/icon/search.svg" Height="33px" Width="40px" OnClick="btnsearch_Click"/>
                    </td>
                </tr>
            </table>
        </div>
          <div>
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="st_items_sel_search" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txt_search" DefaultValue="-1" Name="itemid" PropertyName="Text" Type="String" ConvertEmptyStringToNull="false" />
                    <asp:ControlParameter ControlID="txt_search"  Name="item" PropertyName="Text" Type="String" ConvertEmptyStringToNull="false" />
      
                   
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div dir="rtl">

            <dx:ASPxGridView ID="gv_items" runat="server" ClientInstanceName="gv_items" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="itemid" Theme="MaterialCompact"  RightToLeft="True" SettingsBehavior-AllowFocusedRow="true" OnHtmlRowCreated="gv_items_HtmlRowCreated" KeyboardSupport="True"  >
                <Settings ShowFilterRow="True" />
                
                  <ClientSideEvents RowDblClick="function(s, e) {
	s.GetRowValues(e.visibleIndex, 'itemid', Done);
                     
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
                    <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="0" ReadOnly="True" Visible="false">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="1" Caption="كود الصنف">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="2" Caption="الصنف">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="3" Caption="الوحده">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="unitid" VisibleIndex="5" Visible="false" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="fprice" VisibleIndex="4" Caption="السعر">
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
        window.opener.Updateitems(values);
        window.close();
    }

</script>
