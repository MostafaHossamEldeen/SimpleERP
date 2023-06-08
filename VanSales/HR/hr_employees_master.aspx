<%@ Page Title="الموظفين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_employees_master.aspx.cs" Inherits="VanSales.HR.hr_employees_master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .zoom {
            transition: transform .3s; /* Animation */
        }
            .zoom:hover {
                -ms-transform: scale(2.5); /* IE 9 */
                -webkit-transform: scale(2.5); /* Safari 3-8 */
                transform: scale(2.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
            }
    </style>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/HR/hr_employees_master.js"></script>
    <table class="dx-justification" style="width: 100%">
        <tr>
            <td class="text-center pagetitletd">
                
                    <dx:ASPxLabel ID="lbltitle" CssClass="pagetitlelable" runat="server" Text="الـمـوظـفـيـن" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12" dir="rtl">
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnnew" runat="server" ToolTip="جديد" AutoPostBack="False"  Height="35px" Width="50px" CssClass="btn_new">
                        <ClientSideEvents Click="function(s, e) { window.open('hr_employees.aspx','_self' );}" />
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnmultidel" runat="server" ToolTip="حذف المحدد" AutoPostBack="False"  Height="35px" Width="50px" CssClass="btn_delete" ClientSideEvents-Click="function (s,e){empdeldata()}">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexport" runat="server" ToolTip="Excel" AutoPostBack="False"  Height="35px" Width="50px" CssClass="btn_excel" OnClick="ASPxbtnxlsxexport_Click">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtndocexport" runat="server" ToolTip="Word" AutoPostBack="False" Height="35px" Width="50px" CssClass="btn_word" OnClick="ASPxbtndocexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexport" runat="server" ToolTip="PDF" AutoPostBack="False"  Height="35px" Width="50px" CssClass="btn_pdf" OnClick="ASPxbtnpdfexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexport" runat="server" ToolTip="طباعة" AutoPostBack="False"  Height="35px" Width="50px" CssClass="btn_print" OnClick="ASPxbtnprintexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" ToolTip="إظهار التفاصيل" AutoPostBack="False"  Height="35px" Width="50px" CssClass="btn_expand">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gv_hr_employees.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gv_hr_employees.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <div style="margin: 20PX;">
                    <dx:ASPxGridView ID="gv_hr_employees" ClientInstanceName="gv_hr_employees" runat="server" AutoGenerateColumns="False" KeyFieldName="empid" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" OnCustomCallback="gv_hr_employees_CustomCallback" OnDataBinding="gv_hr_employees_DataBinding">
                        <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                        <SettingsPager AlwaysShowPager="True" PageSize="20">
                            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                        </SettingsPager>
                        <SettingsEditing Mode="PopupEditForm"></SettingsEditing>
                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterBar="Visible" />
                        <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" AllowFixedGroups="True" />
                        <SettingsCommandButton RenderMode="Image">
                            <CustomizationDialogCloseButton>
                                <Image ToolTip="إغلاق" SpriteProperties-CssClass="btn_cancel_grid" Width="20" Height="20" AlternateText="إغلاق" />
                            </CustomizationDialogCloseButton>
                            <NewButton RenderMode="Image">
                                <Image ToolTip="جديد" SpriteProperties-CssClass="btn_new_grid" Width="20" Height="20" AlternateText="جديد" />
                            </NewButton>
                            <EditButton RenderMode="Image" >
                                <Image ToolTip="تعديل" SpriteProperties-CssClass="btn_edit_grid" Width="20" Height="20" AlternateText="تعديل" />
                            </EditButton>
                            <UpdateButton RenderMode="Image">
                                <Image ToolTip="حفظ" SpriteProperties-CssClass="btn_save_grid" Width="20" Height="20" AlternateText="حفظ" />
                            </UpdateButton>
                            <CancelButton RenderMode="Image">
                                <Image ToolTip="إلغاء" SpriteProperties-CssClass="btn_cancel_grid" Width="20" Height="20" AlternateText="إلغاء" />
                            </CancelButton>
                            <DeleteButton RenderMode="Image">
                                <Image ToolTip="حذف" SpriteProperties-CssClass="btn_delete_grid" Width="20" Height="20" AlternateText="حذف" />
                            </DeleteButton>
                            <ClearFilterButton RenderMode="Image">
                                <Image ToolTip="تفريغ" SpriteProperties-CssClass="btn_clear_grid" Width="20" Height="20" AlternateText="تفريغ" />
                            </ClearFilterButton>
                            <SearchPanelClearButton RenderMode="Image">
                                <Image ToolTip="تفريغ" SpriteProperties-CssClass="btn_clear_grid" Width="20" Height="20" AlternateText="تفريغ" />
                            </SearchPanelClearButton>
                        </SettingsCommandButton>
                        <SettingsPopup>
                            <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                <SettingsAdaptivity VerticalAlign="WindowCenter" />
                            </EditForm>
                            <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                        </SettingsPopup>
                        <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                        <SettingsFilterControl ShowAllDataSourceColumns="True">
                        </SettingsFilterControl>
                        <SettingsExport PaperKind="A4" FileName="employees" PaperName="employees" RightToLeft="True">
                            <PageHeader>
                                <Font Bold="True" Size="Medium"></Font>
                            </PageHeader>
                        </SettingsExport>
                        <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                        <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="AllPages" ShowSelectCheckbox="True"></dx:GridViewCommandColumn>
                            <dx:GridViewDataHyperLinkColumn FieldName="empid" ReadOnly="True" VisibleIndex="1" Caption="كود الموظف">
                                <PropertiesHyperLinkEdit NullDisplayText="تلقائي" NavigateUrlFormatString="~\HR/hr_employees.aspx?empid={0}" Target="_parent" TextField="empcode">
                                    <Style Font-Bold="True"></Style>
                                </PropertiesHyperLinkEdit>
                                <Settings AllowGroup="False" SortMode="DisplayText" FilterMode="DisplayText" AutoFilterCondition="BeginsWith"></Settings>
                                <EditFormSettings Visible="False"></EditFormSettings>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataHyperLinkColumn>
                            <dx:GridViewDataTextColumn FieldName="empcode" VisibleIndex="2" Visible="False" Caption="كود الموظف">
                                <PropertiesTextEdit NullText="تلقائي" MaxLength="50" ClientSideEvents-KeyDown="function(s,e){preventwriteitemcode(s, e);}" NullDisplayText="تلقائي" ClientInstanceName="empcode">
                                </PropertiesTextEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith"></Settings>
                                <EditFormSettings Visible="True"></EditFormSettings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="empname" VisibleIndex="3" Caption="إسم الموظف"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="empmob" VisibleIndex="8" Caption="رقم الجوال"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="embemail" VisibleIndex="10" Caption="البريد الإلكتروني"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="empadd" VisibleIndex="13" Caption="العنوان"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="empbdate" VisibleIndex="14" Caption="تاريخ الميلاد"></dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="empidno" VisibleIndex="9" Caption="رقم الهوية"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataImageColumn FieldName="emppic" VisibleIndex="12" Caption="الصورة" CellStyle-CssClass="zoom">
                                <PropertiesImage AlternateTextField="emppic" DescriptionUrlField="empname" ImageAlign="Middle" ImageHeight="50px" ImageWidth="50px" ShowLoadingImage="True">
                                </PropertiesImage>
                                <Settings AllowGroup="False" AllowAutoFilter="False" ShowFilterRowMenu="False" />
                                <CellStyle CssClass="zoom"></CellStyle>
                            </dx:GridViewDataImageColumn>
                            <dx:GridViewDataTextColumn FieldName="empnotes" VisibleIndex="15" Caption="ملاحظات"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="eduname" VisibleIndex="16" Caption="المؤهل الدراسي"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="branchid" VisibleIndex="5" Caption="الفرع"></dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="ccid" VisibleIndex="6" Caption="مركز التكلفة"></dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="nationid" VisibleIndex="4" Caption="الجنسية"></dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="jobid" VisibleIndex="7" Caption="الوظيفة"></dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="empstatus" VisibleIndex="11" Caption="حالة الموظف"></dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="basicsalary" VisibleIndex="24" Caption="الراتب الأساسي"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="insursalary" VisibleIndex="27" Caption="راتب التأمينات"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="empworkdate" VisibleIndex="28" Caption="تاريخ بداية العمل"></dx:GridViewDataDateColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="paytypeid" VisibleIndex="29" Caption="طريقة صرف الراتب"></dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="paychartid" VisibleIndex="31" Caption="رقم حساب طريقة صرف الراتب"></dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="empbankname" VisibleIndex="32" Caption="بنك الموظف"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="empbankid" VisibleIndex="33" Caption="رقم حساب بنك الموظف"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="annualvaction" VisibleIndex="34" Caption="رصيد الأجازات السنوية"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="chartcodename" VisibleIndex="35" Caption="حساب الموظف"></dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
                        <EditFormLayoutProperties>
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                        </EditFormLayoutProperties>
                        <SettingsPopup>
                            <EditForm Width="730">
                                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                            </EditForm>
                        </SettingsPopup>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="empcode" ShowInColumn="empcode" ShowInGroupFooterColumn="empcode" SummaryType="Count" DisplayFormat="العدد : {0}" />
                        </TotalSummary>
                        <GroupSummary>
                            <dx:ASPxSummaryItem FieldName="empid" SummaryType="Count" />
                        </GroupSummary>
                        <Styles>
                            <Footer Font-Bold="True">
                            </Footer>
                            <GroupFooter Font-Bold="False">
                            </GroupFooter>
                            <GroupPanel HorizontalAlign="Right"></GroupPanel>
                            <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                        </Styles>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:VanSales %>' SelectCommand="hr_employees_sel" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </td>
        </tr>
    </table>
    <dx:ASPxGridViewExporter ID="gv_hr_employeesExporter"  runat="server" FileName="الموظفين" GridViewID="gv_hr_employees" PaperKind="A4" PaperName="employees" RightToLeft="True" Landscape="True">
        <PageHeader Center="الموظفين">
        </PageHeader>
        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
</asp:Content>
