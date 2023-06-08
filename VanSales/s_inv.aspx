<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="s_inv.aspx.cs" Inherits="VanSales.s_inv" %>
<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>فواتــــير البيــــــع</title>
    <style type="text/css">
        .auto-style2 {
            margin-right: 0px;
        }

        .auto-style3 {
            width: 383px;
        }

        .auto-style4 {
            width: 173px;
        }

        .auto-style21 {
            width: 144px;
        }

        .auto-style26 {
            width: 130px;
        }

        .auto-style27 {
            width: 104px;
        }

        .auto-style28 {
            width: 97px;
        }

        .auto-style29 {
            width: 41px;
        }

        .auto-style31 {
            width: 177px;
        }

        .auto-style32 {
            width: 35px;
        }
    </style>
</head>
<script type="text/javascript">
    function function_save() {
        alert("تم الحفظ بنجاح");
    }
    function multiply(s, e) {


        var text1 = txt_qty.GetValue();
        var text2 = txt_price.GetValue();

        var t1 = 0, t2 = 0;
        if (text1 != "") t1 = text1;
        if (text2 != "") t2 = text2;

        txt_value.SetValue(parseFloat(t1) * parseFloat(t2));

        Subtract(s, e);
    }
    function multiplydis(s, e) {


        var text1 = txt_discp.GetValue();
        var text2 = txt_value.GetValue();

        var t1 = 0, t2 = 0;
        if (text1 != "") t1 = text1 / 100;
        if (text2 != "") t2 = text2;

        txt_discvalue.SetValue(parseFloat(t1) * parseFloat(t2));
        Subtract(s, e);
    }
    function Subtract(s, e) {



        var text1 = txt_value.GetValue();
        var text2 = txt_discvalue.GetValue();
        var t1 = 0, t2 = 0;
        if (text1 != "") t1 = text1;
        if (text2 != "") t2 = text2;

        txt_netvalue.SetValue(parseFloat(t1) - parseFloat(t2));
        calac_vat(s, e);
    }
    function calac_vat(s, e) {



        var text1 = txt_netvalue.GetValue();
        var text2 = 15 / 115;
        var t1 = 0, t2 = 0;
        if (text1 != "") t1 = text1;
        if (text2 != "") t2 = text2;

        txt_itemvatvalue.SetValue(parseFloat(t1).toFixed(2) * parseFloat(t2).toFixed(2));

    }
    function sumdata(s, e) {
        
        var sum = 0;
        var indices = gvs_invdtls.GetVisibleRowsOnPage();//.GetRowVisibleIndices();//GridHR_Op_d.batchEditApi.GetRowVisibleIndices();
        for (i = 0; i < indices; i++) {

            // gvs_invdtls.GetRowValues(i, "netvalue", OnGetRowValues)
            gvs_invdtls.GetRowValues(i, "vatvalue", OnGetRowValuesval);

        }

    }
    function calac_disc(s, e) {


        var text1 = txt_discvalue.GetValue();
        var text2 = txt_value.GetValue();
        var t1 = 0, t2 = 0;
        if (text1 != "") t1 = text1;
        if (text2 != "") t2 = text2;

        txt_discp.SetValue((parseFloat(t1).toFixed(2) / parseFloat(t2).toFixed(2))*100);

    }
    function OnGetRowValues(value) {
        alert(value)
    }
    function OnGetRowValuesval(value) {
        alert(value)

    }
    function invsearch() {
        var rc = window.open('inv_search.aspx', '', 'width=600,height=500');
    }
    function itemsearch() {
        var rc = window.open('item_search.aspx', '', 'width=600,height=500');
    }
    function cus_search() {
        var rc = window.open('cust_search.aspx', '', 'width=600,height=500');
    }
    function UpdateReal(x) {
        document.getElementById("<%=HF_inv_id.ClientID%>").value = x;
        __doPostBack('<%= HF_inv_id.ClientID %>', "<%=HF_inv_id.ClientID%>");


    }
    function Updateitems(x) {
        document.getElementById("<%=HfItemID.ClientID%>").value = x;
        __doPostBack('<%= HfItemID.ClientID %>', "<%=HfItemID.ClientID%>");


    }
    function Updatecus(x) {
        document.getElementById("<%=Hfcusid.ClientID%>").value = x;
        __doPostBack('<%= Hfcusid.ClientID %>', "<%=Hfcusid.ClientID%>");


    }
</script>
<body>
    <form id="form1" runat="server">
        <div dir="rtl">
            <table style="width: 100%;">
                <tr>
                    <td class="dx-ac" style="background-color: #dcdcdc">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="فواتـــــير البيـــــع" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div dir="rtl" style="text-align: center;">

            <asp:ImageButton ID="btn_Save" runat="server" ImageUrl="~/img/icon/save.png" Height="33px" OnClick="btn_Save_Click" Width="40px" ToolTip="حفظ" />
            <asp:ImageButton ID="btn_addnew" runat="server" ImageUrl="~/img/icon/add-new.png" Height="33px" Width="40px" OnClick="btn_addnew_Click" ToolTip="جديد" />
            <asp:ImageButton ID="btn_delete" runat="server" ImageUrl="~/img/icon/delete.png" Height="33px" Width="40px" OnClick="btn_delete_Click" OnClientClick='return confirm ("هل تريد الحذف")' ToolTip="حذف" />
            <asp:ImageButton ID="btn_search" runat="server" ImageUrl="~/img/icon/search.png" Height="33px" Width="40px" OnClientClick="invsearch();return false;" ToolTip="بحث" />

        </div>

        <div dir="rtl">
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black">
                <table style="width: 100%;">
                    <tr>
                         <td style="text-align: right">&nbsp;</td>
                        <td class="auto-style31">
                            <dx:ASPxLabel ID="lbl_sinvno" runat="server" Text="رقم الفاتوره" Theme="MaterialCompact"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_sinvno" runat="server" Width="170px" Theme="MaterialCompact" Enabled="False" Font-Bold="True" ForeColor="Black" Text="تلقائى"></dx:ASPxTextBox>
                        </td>
                        <td class="auto-style32">&nbsp;</td>
                         <td style="text-align: right">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="رقم يدوى للفاتوره" Theme="MaterialCompact"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_sinvdocno" runat="server" Theme="MaterialCompact" Width="170px">
                            </dx:ASPxTextBox>
                        </td>
                         <td style="text-align: right">
                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="نوع سداد الفاتوره"></dx:ASPxLabel>
                            <dx:ASPxComboBox ID="dll_sinvpay" runat="server" DataSourceID="SqlDataSource1" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid">
                            </dx:ASPxComboBox>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="9" Name="compid" Type="Int32" />
                                    <asp:Parameter DefaultValue="sys_fillcomp" Name="table_name" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td class="auto-style3">
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="التاريخ"></dx:ASPxLabel>
                            <dx:ASPxDateEdit ID="sinvdata" runat="server" RightToLeft="True" Theme="MaterialCompact">
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxDateEdit>
                        </td>

                         <td style="text-align: right">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="الوقت">
                            </dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_sinvtime" runat="server" CssClass="auto-style2" Enabled="False" Theme="MaterialCompact" Width="170px">
                            </dx:ASPxTextBox>
                        </td>

                    </tr>

                    <tr>

                         <td style="text-align: right">&nbsp;</td>
                        <td class="auto-style31">
                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="العميل"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_cusid" runat="server" Width="170px" Theme="MaterialCompact" Text="0"></dx:ASPxTextBox>

                        </td>
                        <td class="auto-style32">
                            <br />
                            <asp:ImageButton ID="btn_cus" runat="server" CssClass="auto-style2" Height="28px" ImageUrl="~/img/icon/search.png" OnClientClick="cus_search();return false;" ToolTip="بحث" Width="32px" />
                        </td>
                         <td style="text-align: right">
                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="اسم العميل"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_cusname" runat="server" Width="170px" Theme="MaterialCompact"></dx:ASPxTextBox>
                        </td>
                         <td style="text-align: right">
                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="الرقم الضريبى للعميل"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_custvat" runat="server" Width="170px" Theme="MaterialCompact"></dx:ASPxTextBox>
                        </td>
                        <td colspan="2">
                            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="عنوان العميل">
                            </dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_custadd" runat="server" Height="16px" Theme="MaterialCompact" Width="557px">
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                         <td style="text-align: right">&nbsp;</td>
                        <td class="auto-style31">
                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="المستخدم"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_suser" runat="server" Theme="MaterialCompact" Width="170px">
                                <ClientSideEvents Init="function(s, e) {
	txt_suser.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style32">&nbsp;</td>
                        <td colspan="2">
                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="الملاحظات"></dx:ASPxLabel>
                            <dx:ASPxMemo ID="txt_snotes" runat="server" Height="71px" Theme="MaterialCompact" Width="537px">
                            </dx:ASPxMemo>
                        </td>

                        <td class="auto-style3">
                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="المستند">
                            </dx:ASPxLabel>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <dx:ASPxLabel ID="lbl_filename" runat="server" Theme="MaterialCompact" ForeColor="#009933">
                            </dx:ASPxLabel>
                        </td>

                         <td style="text-align: right">
                            <asp:ImageButton ID="btn_download" runat="server" Height="33px" ImageUrl="~/img/icon/download.png" OnClick="btn_download_Click" ToolTip="تحميل" Width="40px" />
                        </td>

                    </tr>
                    <tr>

                         <td style="text-align: right">&nbsp;</td>
                        <td class="auto-style31">
                            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="الصافى بدون الضريبه"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_netbvat" runat="server" Width="170px" Text="0" Theme="MaterialCompact" Font-Bold="True">
                                <ClientSideEvents Init="function(s, e) {
	txt_netbvat.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style32">&nbsp;</td>
                         <td style="text-align: right">
                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="قيمه الضريبه"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_vatvalue" runat="server" Width="170px" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_vatvalue">
                                <ClientSideEvents Init="function(s, e) {
	txt_vatvalue.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>

                         <td style="text-align: right">
                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="الصافى شامل الضريبه"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_netavat" runat="server" Width="170px" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_netavat">
                                <ClientSideEvents Init="function(s, e) {
	txt_netavat.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>

                        </td>
                        <td class="auto-style3">
                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="الباقى">
                            </dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_restvalue" runat="server" Font-Bold="True" Text="0" Theme="MaterialCompact" Width="170px">
                                <ClientSideEvents Init="function(s, e) {
	txt_restvalue.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
        </div>
        <asp:HiddenField ID="HF_inv_id" runat="server" OnValueChanged="HF_inv_id_ValueChanged" />
        <asp:HiddenField ID="HfItemID" runat="server" OnValueChanged="HfItemID_ValueChanged" />
        <asp:HiddenField ID="Hfuntid" runat="server" />
        <asp:HiddenField ID="Hfcusid" runat="server" OnValueChanged="Hfcusid_ValueChanged" />
        <br />
        <div dir="rtl">
            <asp:Panel ID="PDetiles" runat="server" Visible="false" BorderStyle="Groove" GroupingText="اصناف الفاتوره" Font-Bold="True">
                <table class="dx-justification">
                    <tr>
                        <td class="auto-style28">
                            <dx:ASPxLabel ID="ASPxLabel35" runat="server" Text="كود الصنف"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_item" runat="server" Width="91px" Height="26px" Theme="MaterialCompact" OnTextChanged="txt_item_TextChanged" AutoPostBack="True">
                                <ClientSideEvents KeyDown="function(s, e) {
	if(e.htmlEvent.keyCode == 13) {
document.getElementById('ctl00$ASPxRoundPanel2$ContentPlaceHolder1$PDetiles$btn_items').focus();}
}"></ClientSideEvents>
                            </dx:ASPxTextBox>

                        </td>
                        <td class="auto-style29">
                            <br />
                            <asp:ImageButton ID="btn_items" runat="server" CssClass="auto-style2" Height="28px" ImageUrl="~/img/icon/search.png" Width="32px" OnClientClick="itemsearch();return false;" ToolTip="بحث" />
                        </td>
                        <td class="auto-style21">
                            <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="الصنف"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_item_name" runat="server" Width="133px" Height="20px" Theme="MaterialCompact"></dx:ASPxTextBox>
                        </td>

                        <td class="auto-style26">
                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="وحده القياس"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_unit" runat="server" Width="120px" Height="16px" Theme="MaterialCompact">
                                 <ClientSideEvents Init="function(s, e) {
	txt_unit.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style27">
                            <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="الكميه"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Width="95px" Text="0" Height="22px" Theme="MaterialCompact">

                                <ClientSideEvents KeyUp="multiply" />

                            </dx:ASPxTextBox>

                        </td>
                        <td class="auto-style27">
                            <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="السعر"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_price" runat="server" Width="95px" Text="0" CssClass="auto-style2" Height="22px" Theme="MaterialCompact" ClientInstanceName="txt_price">
                                <ClientSideEvents Init="function(s, e) {
	txt_price.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style27">
                            <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="الاجمالى"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_value" runat="server" Width="95px" Text="0" Height="22px" Theme="MaterialCompact" ClientInstanceName="txt_value" Font-Bold="True">
                                <ClientSideEvents Init="function(s, e) {
	txt_value.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style27">
                            <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="الخصم%"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_discp" runat="server" Width="95px" Text="0" Height="22px" Theme="MaterialCompact" ClientInstanceName="txt_discp">
                                <ClientSideEvents KeyUp="multiplydis" />
                            </dx:ASPxTextBox>

                        </td>
                        <td class="auto-style27">
                            <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="الخصم"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_discvalue" runat="server" Width="95px" Text="0" Height="16px" Theme="MaterialCompact" ClientInstanceName="txt_discvalue">
                                <ClientSideEvents Init="function(s, e) {
	//txt_discvalue.GetInputElement().readOnly = true; 
}" KeyUp="calac_disc
" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style27">
                            <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="الصافى"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_netvalue" runat="server" Width="95px" Text="0" OnTextChanged="txt_netvalue_TextChanged" Height="22px" Theme="MaterialCompact" ClientInstanceName="txt_netvalue" Font-Bold="True">
                                <ClientSideEvents Init="function(s, e) {
Subtract
txt_netvalue.GetInputElement().readOnly = true; 
}"
                                    ValueChanged="calac_vat" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style27">
                            <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="الضريبه"></dx:ASPxLabel>
                            <dx:ASPxTextBox ID="txt_itemvatvalue" runat="server" Width="101px" Height="22px" Theme="MaterialCompact" Text="0">
                                <ClientSideEvents Init="function(s, e) {
	txt_itemvatvalue.GetInputElement().readOnly = true; 
}" />
                            </dx:ASPxTextBox>
                        </td>
                        <td class="auto-style4">
                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="الملاحظات"></dx:ASPxLabel>

                            <dx:ASPxTextBox ID="txt_itemnotes" runat="server" Width="170px" Theme="MaterialCompact"></dx:ASPxTextBox>
                        </td>
                         <td style="text-align: right">
                            <br />
                            <asp:ImageButton ID="btn_save_dtls" runat="server" ImageUrl="~/img/icon/save.png" Height="26px" Width="32px" OnClick="btn_save_dtls_Click" ToolTip="حفظ" />
                            <asp:ImageButton ID="btn_new_dtls" runat="server" ImageUrl="~/img/icon/add-new.png" Height="26px" Width="32px" ToolTip="جديد" OnClick="btn_new_dtls_Click1" />
                            <asp:ImageButton ID="btn_delete_dtls" runat="server" ImageUrl="~/img/icon/delete.png" Height="26px" Width="32px" OnClientClick='return confirm ("هل تريد الحذف")' ToolTip="حذف" OnClick="btn_delete_dtls_Click" />

                        </td>
                    </tr>

                </table>
                <asp:HiddenField ID="HFsinviddtl" runat="server" />
                <dx:ASPxGridView ID="gvs_invdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" DataSourceID="SqlDataSource4" Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" OnSelectionChanged="gvs_invdtls_SelectionChanged" OnDataBound="gvs_invdtls_DataBound">
    
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowFilterRowMenu="True" ShowFooter="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="invdtlid" ReadOnly="True" VisibleIndex="0" Visible="false">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="1" Caption="كود الصنف">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="2" Caption="اسم الصنف">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="unitid" VisibleIndex="3" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="4" Caption="الوحده">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="5" Caption="الكميه">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="price" VisibleIndex="6" Caption="السعر">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="icost" VisibleIndex="7" Caption="التكلفه" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="value" VisibleIndex="8" Caption="الاجمالى">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="discp" VisibleIndex="9" Caption="نسبه الخصم">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="discvalue" VisibleIndex="10" Caption="قيمه الخصم">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="netvalue" VisibleIndex="11" Caption="الصافى">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="12" Caption="الضريبه">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="13" Visible="false">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="الكميه" SummaryType="Sum" DisplayFormat="الكميه : {0}" />
                        <dx:ASPxSummaryItem FieldName="price" ShowInColumn="السعر" SummaryType="Sum" DisplayFormat="السعر : {0}" Visible="false" />
                        <dx:ASPxSummaryItem FieldName="netvalue" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat="الصافى : {0}" Visible="false" />
                        <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="الضريبه : {0}" Visible="false" />
                    </TotalSummary>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_invdtls_sel" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HF_inv_id" Name="sinvid" PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
