<%@ Page Title="سندات الجرد" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventorys.aspx.cs" Inherits="VanSales.Stock.Inventorys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="dx-justification" style="width: 100%">
        <tr>
            <td style="background-color: #dcdcdc;" class="text-center">
                <asp:Label ID="lbltitle" runat="server" Font-Bold="True" Font-Size="25pt" ForeColor="#35B86B" Text="سـنــدات الـجـرد"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12"  dir="rtl">
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) { window.open('Inventory_Manage.aspx');}" />
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexport" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtndocexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexport" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_printexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvinventory.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvinventory.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvinventory" ClientInstanceName="gvinventory" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="inventid" OnDataBinding="gvinventory_DataBinding">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                    <SettingsPager AlwaysShowPager="True" PageSize="20">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                    <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                    <SettingsCommandButton RenderMode="Image">
                        <CustomizationDialogCloseButton>
                            <Image ToolTip="إغلاق" Url="~/Img/Icon/close.svg" Width="20" Height="20" AlternateText="إغلاق" />
                        </CustomizationDialogCloseButton>
                        <NewButton RenderMode="Image">
                            <Image ToolTip="جديد" Url="~/Img/Icon/add-new.svg" Width="20" Height="20" AlternateText="جديد" />
                        </NewButton>
                        <EditButton RenderMode="Image">
                            <Image ToolTip="تعديل" Url="~/Img/Icon/edit.svg" Width="20" Height="20" AlternateText="تعديل" />
                        </EditButton>
                        <UpdateButton RenderMode="Image">
                            <Image ToolTip="حفظ" Url="~/Img/Icon/save.svg" Width="20" Height="20" AlternateText="حفظ" />
                        </UpdateButton>
                        <CancelButton RenderMode="Image">
                            <Image ToolTip="إلغاء" Url="~/Img/Icon/cancel.svg" Width="20" Height="20" AlternateText="إلغاء" />
                        </CancelButton>
                        <DeleteButton RenderMode="Image">
                            <Image ToolTip="حذف" Url="~/Img/Icon/delete.svg" Width="20" Height="20" AlternateText="حذف" />
                        </DeleteButton>
                        <ClearFilterButton RenderMode="Image">
                            <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                        </ClearFilterButton>
                        <SearchPanelClearButton RenderMode="Image">
                            <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                        </SearchPanelClearButton>
                    </SettingsCommandButton>
                    <SettingsPopup>
                        <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                            <SettingsAdaptivity VerticalAlign="WindowCenter" />
                        </EditForm>
                        <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                    </SettingsPopup>
                    <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                    <SettingsExport PaperKind="A4" FileName="customers" PaperName="customers" RightToLeft="True">
                        <PageHeader>
                            <Font Bold="True" Size="Medium"></Font>
                        </PageHeader>
                    </SettingsExport>
                    <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                    <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                    <StylesPopup>
                        <HeaderFilter>
                            <Footer HorizontalAlign="Center">
                            </Footer>
                        </HeaderFilter>
                    </StylesPopup>
                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
                    <SettingsBehavior AllowEllipsisInText="true" />
                    <EditFormLayoutProperties>
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                    </EditFormLayoutProperties>
                    <Columns>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>
                        <dx:GridViewDataHyperLinkColumn FieldName="inventid" ReadOnly="True" VisibleIndex="1" Caption="رقم سند الجرد">
                            <PropertiesHyperLinkEdit NullDisplayText="تلقائي" NavigateUrlFormatString="~\Stock\Inventory_Manage.aspx?inventid={0}" Target="_blank" TextField="inventno">
                                <Style Font-Bold="True"></Style>
                            </PropertiesHyperLinkEdit>
                            <Settings AllowGroup="False" SortMode="DisplayText" FilterMode="DisplayText" AutoFilterCondition="BeginsWith"></Settings>
                            <EditFormSettings Visible="False"></EditFormSettings>
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                        </dx:GridViewDataHyperLinkColumn>
                        <dx:GridViewDataTextColumn FieldName="inventid" ReadOnly="True" VisibleIndex="2" Visible="False">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="inventno" VisibleIndex="3" PropertiesTextEdit-NullDisplayText="تلقائي" PropertiesTextEdit-NullText="تلقائي" Caption="رقم سند الجرد" Visible="False"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="inventdocno" VisibleIndex="4" Caption="الرقم اليدوي"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="inventdate" VisibleIndex="5" Caption="التاريخ">
                            <PropertiesDateEdit DisplayFormatString="yyyy/MM/dd"></PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="6" Caption="الفرع"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="notes" VisibleIndex="7" Caption="ملاحظات"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="inventuser" VisibleIndex="8" Caption="المستخدم"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="postst" VisibleIndex="9" Caption="ترحيل المستودع">
                            <PropertiesCheckEdit ValueGrayed="False" DisplayTextChecked="مرحل" DisplayTextUnchecked="غير مرحل" DisplayTextUndefined="غير مرحل" DisplayTextGrayed="غير مرحل"></PropertiesCheckEdit>
                        </dx:GridViewDataCheckColumn>
                        <dx:GridViewDataTextColumn FieldName="fyear" VisibleIndex="10" Caption="السنة المالية">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPopup>
                        <EditForm Width="730">
                            <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                        </EditForm>
                    </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="groupid" ShowInColumn="groupid" ShowInGroupFooterColumn="groupid" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="groupid" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                        <Footer Font-Bold="True">
                        </Footer>
                        <GroupPanel HorizontalAlign="Right">
                        </GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
            </td>
        </tr>
        </table>
    <dx:ASPxGridViewExporter ID="gvinventoryExporter" runat="server" FileName="المجموعات" GridViewID="gvinventory" PaperKind="A4" PaperName="Group"
        RightToLeft="True" Landscape="True">
        <PageHeader Center="المجموعات">
        </PageHeader>
        <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
    <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
    <script src="sweetalert2.js" type="text/javascript"></script>
    <link href="animate.css" rel="stylesheet" />
</asp:Content>