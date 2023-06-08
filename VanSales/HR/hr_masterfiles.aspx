<%@ Page Title="الملفات الرئيسية للموارد البشرية" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_masterfiles.aspx.cs" Inherits="VanSales.HR.hr_masterfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/HR/hr_masterfiles.js"></script>
    <table class="dx-justification" style="width: 100%">
        <tr>
            <td style="background-color: #dcdcdc;" class="text-center">
                <dx:ASPxLabel ID="lbltitle" runat="server" Text="الملفات الرئيسية للموارد البشرية" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td>
                <%--nations--%>
                <dx:ASPxGridView ID="gvhr_masterfiles_nations" ClientIDMode="Static" ClientInstanceName="gvhr_masterfiles_nations" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="mersid" OnRowInserting="gvhr_masterfiles_nations_RowInserting" OnDataBinding="gvhr_masterfiles_nations_DataBinding" OnRowDeleting="gvhr_masterfiles_nations_RowDeleting" Settings-ShowTitlePanel="true" SettingsText-Title="الجــنــســيــات">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" CustomButtonClick="function(s,e){OnCustomButtonClick_gvhr_masterfiles_nations(s,e)}" />
                    <SettingsPager AlwaysShowPager="True" PageSize="5">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterRow="True" />
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
                    <SettingsSearchPanel ShowClearButton="True" />
                    <SettingsExport PaperKind="A4" FileName="hr_masterfiles" PaperName="customers" RightToLeft="True">
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
                        <dx:GridViewCommandColumn  VisibleIndex="0" ShowNewButtonInHeader="True">
                                    <CustomButtons>
                                         <dx:GridViewCommandColumnCustomButton ID="deleteButton1" Text=" " Image-Url="~/Img/Icon/delete.svg" Image-Width="20" Image-Height="20" Image-ToolTip="حذف"/>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                        <%--<dx:GridViewCommandColumn VisibleIndex="1" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowClearFilterButton="True"></dx:GridViewCommandColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="mersid" ReadOnly="True" VisibleIndex="0" Visible="False">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemcode" VisibleIndex="2" Caption="كود">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemname" VisibleIndex="3" Caption="إسم">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorText="" Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPopup>
                        <EditForm Width="730">
                            <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                        </EditForm>
                    </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" ShowInColumn="mitemname" ShowInGroupFooterColumn="mitemname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                        <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        <GroupPanel HorizontalAlign="Right" Font-Bold="true">
                        </GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
                <%--jobs--%>
                <dx:ASPxGridView ID="gvhr_masterfiles_jobs" ClientInstanceName="gvhr_masterfiles_jobs" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="mersid" OnRowInserting="gvhr_masterfiles_jobs_RowInserting" OnDataBinding="gvhr_masterfiles_jobs_DataBinding" OnRowDeleting="gvhr_masterfiles_jobs_RowDeleting" Settings-ShowTitlePanel="true" SettingsText-Title="الـوظـائـف">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" CustomButtonClick="function(s,e){OnCustomButtonClick_gvhr_masterfiles_jobs(s,e)}" />
                    <SettingsPager AlwaysShowPager="True" PageSize="5">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterRow="True" />
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
                    <SettingsSearchPanel ShowClearButton="True" />
                    <SettingsExport PaperKind="A4" FileName="hr_masterfiles" PaperName="customers" RightToLeft="True">
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
                        <dx:GridViewCommandColumn  VisibleIndex="0" ShowNewButtonInHeader="True">
                                    <CustomButtons>
                                         <dx:GridViewCommandColumnCustomButton ID="deleteButton2" Text=" " Image-Url="~/Img/Icon/delete.svg" Image-Width="20" Image-Height="20" Image-ToolTip="حذف"/>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                        <%--<dx:GridViewCommandColumn VisibleIndex="1" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowClearFilterButton="True"></dx:GridViewCommandColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="mersid" ReadOnly="True" VisibleIndex="0" Visible="False">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemcode" VisibleIndex="2" Caption="كود">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemname" VisibleIndex="3" Caption="إسم">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorText="" Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPopup>
                        <EditForm Width="730">
                            <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                        </EditForm>
                    </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" ShowInColumn="mitemname" ShowInGroupFooterColumn="mitemname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                        <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        <GroupPanel HorizontalAlign="Right" Font-Bold="true">
                        </GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
                <%--document type--%>
                <dx:ASPxGridView ID="gvhr_masterfiles_doctype" ClientInstanceName="gvhr_masterfiles_doctype" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="mersid" OnRowInserting="gvhr_masterfiles_doctype_RowInserting" OnDataBinding="gvhr_masterfiles_doctype_DataBinding" OnRowDeleting="gvhr_masterfiles_doctype_RowDeleting" Settings-ShowTitlePanel="true" SettingsText-Title="انـواع الـوثـائـق">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" CustomButtonClick="function(s,e){OnCustomButtonClick_gvhr_masterfiles_doctype(s,e)}" />
                    <SettingsPager AlwaysShowPager="True" PageSize="5">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterRow="True" />
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
                    <SettingsSearchPanel ShowClearButton="True" />
                    <SettingsExport PaperKind="A4" FileName="hr_masterfiles" PaperName="customers" RightToLeft="True">
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
                        <dx:GridViewCommandColumn  VisibleIndex="0" ShowNewButtonInHeader="True">
                                    <CustomButtons>
                                         <dx:GridViewCommandColumnCustomButton ID="deleteButton3" Text=" " Image-Url="~/Img/Icon/delete.svg" Image-Width="20" Image-Height="20" Image-ToolTip="حذف"/>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                        <%--<dx:GridViewCommandColumn VisibleIndex="1" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowClearFilterButton="True"></dx:GridViewCommandColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="mersid" ReadOnly="True" VisibleIndex="0" Visible="False">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemcode" VisibleIndex="2" Caption="كود">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemname" VisibleIndex="3" Caption="إسم">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorText="" Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="mitemtype" Caption="النوع" VisibleIndex="4">
                            <PropertiesComboBox>
                                <ValidationSettings Display="Dynamic" ErrorText="">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل"></RequiredField>
                                </ValidationSettings>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                    <SettingsPopup>
                        <EditForm Width="730">
                            <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                        </EditForm>
                    </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" ShowInColumn="mitemname" ShowInGroupFooterColumn="mitemname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                        <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        <GroupPanel HorizontalAlign="Right" Font-Bold="true">
                        </GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
                <%--vactions--%>
                <dx:ASPxGridView ID="gvhr_masterfiles_vactions" ClientInstanceName="gvhr_masterfiles_vactions" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="mersid" OnRowInserting="gvhr_masterfiles_vactions_RowInserting" OnDataBinding="gvhr_masterfiles_vactions_DataBinding" OnRowDeleting="gvhr_masterfiles_vactions_RowDeleting" Settings-ShowTitlePanel="true" SettingsText-Title="الاجــازات">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" CustomButtonClick="function(s,e){OnCustomButtonClick_gvhr_masterfiles_vactions(s,e)}" />
                    <SettingsPager AlwaysShowPager="True" PageSize="5">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterRow="True" />
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
                    <SettingsSearchPanel ShowClearButton="True" />
                    <SettingsExport PaperKind="A4" FileName="hr_masterfiles" PaperName="customers" RightToLeft="True">
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
                        <dx:GridViewCommandColumn  VisibleIndex="0" ShowNewButtonInHeader="True">
                                    <CustomButtons>
                                         <dx:GridViewCommandColumnCustomButton ID="deleteButton4" Text=" " Image-Url="~/Img/Icon/delete.svg" Image-Width="20" Image-Height="20" Image-ToolTip="حذف"/>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                        <%--<dx:GridViewCommandColumn VisibleIndex="1" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowClearFilterButton="True"></dx:GridViewCommandColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="mersid" ReadOnly="True" VisibleIndex="0" Visible="False">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemcode" VisibleIndex="2" Caption="كود">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="mitemname" VisibleIndex="3" Caption="إسم">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorText="" Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPopup>
                        <EditForm Width="730">
                            <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                        </EditForm>
                    </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" ShowInColumn="mitemname" ShowInGroupFooterColumn="mitemname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="mitemname" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                        <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        <GroupPanel HorizontalAlign="Right" Font-Bold="true">
                        </GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
            </td>
            </tr>
        </table>
</asp:Content>