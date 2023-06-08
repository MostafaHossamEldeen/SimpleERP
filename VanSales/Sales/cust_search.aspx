<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cust_search.aspx.cs" Inherits="VanSales.cust_search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>بحث العملاء</title>
    <style type="text/css">
        .auto-style1 {
            width: 15px;
        }
        .auto-style2 {
            width: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div dir="rtl">
            <table>
                <tr>
                    <td class="auto-style2">بحث : </td>
                    <td>
                       <%-- <asp:TextBox ID="txt_search" runat="server"></asp:TextBox>  --%>
                        <dx:ASPxTextBox ID="txt_search" runat="server" Width="453px" Theme="MaterialCompact">
                            <ClientSideEvents Init="function(s, e) {
	s.Focus();
}" />
                        </dx:ASPxTextBox>
                    </td>
                    <td class="auto-style1"></td>
                    <td>
                        <asp:ImageButton ID="btnsearch" runat="server" ToolTip="بحث" ImageUrl="~/img/icon/search.svg" Height="25px" Width="35px" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:SqlDataSource     ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_customers_sel_search" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="-1" Name="custcode" Type="Int32" />
                    <asp:ControlParameter ControlID="txt_search" DefaultValue=" " PropertyName="Text" Name="txtsearch" Type="String"></asp:ControlParameter>
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div dir="rtl">
            <dx:ASPxGridView    ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="custid" Theme="MaterialCompact" RightToLeft="True" SettingsBehavior-AllowFocusedRow="true" OnHtmlRowCreated="ASPxGridView1_HtmlRowCreated" KeyboardSupport="True">
                <Settings ShowTitlePanel="True" ShowGroupPanel="True"></Settings>
                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="750px" PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormVerticalAlign="WindowCenter"></SettingsEditing>
                <ClientSideEvents RowDblClick="function(s, e) {
	s.GetRowValues(e.visibleIndex, 'custid', Done);
}" />
                <SettingsPager PageSize="20" AlwaysShowPager="True" EllipsisMode="OutsideNumeric">
                    <FirstPageButton Visible="True"></FirstPageButton>
                    <LastPageButton Visible="True"></LastPageButton>
                    <Summary Position="Right" Text="صفحة {0} من {1} "></Summary>
                </SettingsPager>
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="750px" PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormVerticalAlign="WindowCenter"></SettingsEditing>
                <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                <SettingsText CommandSelect="تحديد" EmptyDataRow="لا توجد بيانات لعرضها" GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." />
                <Settings ShowFilterRow="True" ShowGroupPanel="false" />
                <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                <Columns>
                    <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="custid" VisibleIndex="0" ReadOnly="True" Visible="false">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custcode" VisibleIndex="1" Caption="كود العميل">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custname" VisibleIndex="2" Caption="إسم العميل">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sgrpid" VisibleIndex="3" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sgrpname" VisibleIndex="4" Caption="المجموعة" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custvat" VisibleIndex="5" Caption="رقم الملف الضريبي" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custadd" VisibleIndex="6" Caption="العنوان">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
        </div>
    </form>
</body>
</html>
<script lang = "Javascript" src="../js/ExpandImage.js">
</script>
<script type="text/javascript">
    function Done(values) {
        //ctname.SetValue(values)
      //  alert(values)
        window.opener.Updatecus(values);
        window.close();
        
    }
</script>
