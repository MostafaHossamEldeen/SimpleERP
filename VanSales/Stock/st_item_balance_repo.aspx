<%@ Page Title="تقرير حركة صنف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="st_item_balance_repo.aspx.cs" Inherits="VanSales.Stock.st_item_balance_repo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script src="../Scripts/App/Public/Messages.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير حركة صنف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_preview" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="استعراض" OnClick="btn_preview_Click">
                    <ClientSideEvents Click="function(s, e) {
if ($(&#39;#HF_itemid&#39;).val() == &quot;&quot; || $(&#39;#HF_itemid&#39;).val() == null) {
        sweetinfo(&quot;برجاء إختيار الصنف&quot;);
        txt_itemcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
}"></ClientSideEvents>

                    <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه" OnClick="btn_print_Click">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                    <ClientSideEvents Click="function(s, e) {
if ($(&#39;#HF_itemid&#39;).val() == &quot;&quot; || $(&#39;#HF_itemid&#39;).val() == null) {
        sweetinfo(&quot;برجاء إختيار الصنف&quot;);
        txt_itemcode.Focus();
        ASPxClientUtils.PreventEvent(e.htmlEvent);
        return;
    }
}"></ClientSideEvents>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد" OnClick="btn_clear_Click">
                    <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gv_itembalance.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gv_itembalance.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="الفرع ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" TextField="branchname" NullText="الكل" NullTextDisplayMode="UnfocusedAndFocused" NullTextStyle-ForeColor="Black" Theme="MaterialCompact" ValueField="branchid" SelectedIndex="0">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                            <NullTextStyle ForeColor="Black">
                                            </NullTextStyle>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="من ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_fromdate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_fromdate" ClearButton-DisplayMode="Always">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption=" الى">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_todate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_todate" ClearButton-DisplayMode="Always">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="كود الصنف " Paddings-PaddingTop="15">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_itemcode" runat="server" ClientInstanceName="txt_itemcode" Theme="MaterialCompact" AutoPostBack="false">
                                            <ClientSideEvents TextChanged="function(s,e){setItemData(s,e); }" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <Paddings PaddingTop="15px" />
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="إسم الصنف " Paddings-PaddingTop="15">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_itemname">
                                                    <ClientSideEvents Init="function(s, e) {txt_itemname.GetInputElement().readOnly = true;}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                        <Paddings PaddingTop="15px" />
                                    </dx:LayoutItem>
                            <dx:LayoutItem ShowCaption="False" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <button type="button" id="puop_item" data-name="items" onclick="createPopUp($(this))" data-tablename="st_item_sel_pop"
                                            data-displayfields="itemcode,itemname" data-displayfieldshidden="itemid"
                                            data-displayfieldscaption="كود الصنف,اسم الصنف"
                                            data-bindcontrols="txt_itemcode;txt_itemname;HF_itemid"
                                            data-bindfields="itemcode;itemname;itemid" data-pkfield="itemid"
                                            data-apiurl="/VanSalesService/items/FillPopup" style="margin-top: 10px" class="btn btn-sm btnsearchpopup">
                                        </button>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="2px" PaddingRight="2px" />
                                </ParentContainerStyle>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="HF_itemid" runat="server" ClientIDMode="Static" />
            <dx:ASPxGridView ID="gv_itembalance" ClientInstanceName="gv_itembalance" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" "   Width="100%" CssClass="grid" KeyFieldName="itemid" OnDataBinding="gv_itembalance_DataBinding">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" ShowGroupPanel="True" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="branchname" Visible="false" GroupIndex="0" SortIndex="0" ReadOnly="True" Caption=" " VisibleIndex="0" SortOrder="Ascending" Settings-AllowDragDrop="False">
                        <EditFormSettings Visible="False" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="typename" VisibleIndex="1" Caption="الحركة">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="typeno" VisibleIndex="2" Caption="الرقم">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="actiondate" Caption="التاريخ" VisibleIndex="3">
                        <PropertiesDateEdit DisplayFormatString="{0:yyyy-MM-dd}"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="incoming" VisibleIndex="4" Caption="الكمية الواردة">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="outcoming" VisibleIndex="5" Caption="الكمية المصروفة">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="pinvno" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="رقم الفاتوره"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الاجمالى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الصافى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Sum" DisplayFormat="{0}" ShowInGroupFooterColumn="الضريبه"></dx:ASPxSummaryItem>
                </GroupSummary>
                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>
                <SettingsBehavior AllowEllipsisInText="true" />
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                </EditFormLayoutProperties>
                <SettingsPopup>
                    <EditForm Width="730">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                    </EditForm>
                </SettingsPopup>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="pinvno" SummaryType="Count" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Custom" DisplayFormat="{0}" />
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server" FileName=" الفاتوره" GridViewID="gvs_inv" PaperKind="A4" PaperName=" الفاتوره" RightToLeft="True" Landscape="True">
                <PageHeader Center=" الفاتوره" Font-Bold="true">
                </PageHeader>
                <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                </PageFooter>
            </dx:ASPxGridViewExporter>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_docexport" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
        </Triggers>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>