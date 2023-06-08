<%@ Page Title="شهور الرواتب" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_monthyear.aspx.cs" Inherits="VanSales.HR.hr_monthyear" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/HR/hr_monthyear.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="شهور الرواتب" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
            <tr>
            <td>
                <dx:ASPxGridView ID="gvhr_monthyear" ClientInstanceName="gvhr_monthyear" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="monyrid" OnRowInserting="gvhr_monthyear_RowInserting" OnDataBinding="gvhr_monthyear_DataBinding" OnRowDeleting="gvhr_monthyear_RowDeleting" OnRowUpdating="gvhr_monthyear_RowUpdating" OnInitNewRow="gvhr_monthyear_InitNewRow">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" CustomButtonClick ="function(s,e){OnCustomButtonClick_gvhr_monthyear(s,e)}" />
                    <SettingsPager AlwaysShowPager="True" PageSize="5">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterRow="True" ShowGroupPanel="True" />
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
                                        <%--<dx:GridViewCommandColumnCustomButton ID="editButton1" Text=" " Image-Url="~/Img/Icon/edit.svg" Image-Width="20" Image-Height="20" Image-ToolTip="تعديل"/>--%>
                                         <dx:GridViewCommandColumnCustomButton ID="deleteButton1" Text=" " Image-Url="~/Img/Icon/delete.svg" Image-Width="20" Image-Height="20" Image-ToolTip="حذف"/>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                        <%--<dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="monyrid" ReadOnly="True" VisibleIndex="1" Visible="false">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="monthsal" VisibleIndex="2" PropertiesSpinEdit-ClientInstanceName="monthsal" Caption="الشهر">
                            <PropertiesSpinEdit MaxValue="12" MinValue="1" ShowOutOfRangeWarning="false">
                                <ClientSideEvents NumberChanged="function(s, e) {monyrname.SetValue(monthsal.GetValue() + '/' + yearsal.GetValue());}"></ClientSideEvents>
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="yearsal" VisibleIndex="3" PropertiesSpinEdit-ClientInstanceName="yearsal" Caption="السنة">
                            <PropertiesSpinEdit MaxValue="2050" MinValue="1900" ShowOutOfRangeWarning="false">
                                 <ClientSideEvents NumberChanged="function(s, e) {monyrname.SetValue(monthsal.GetValue() + '/' + yearsal.GetValue());}"></ClientSideEvents>
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataTextColumn FieldName="monyrname" VisibleIndex="4" PropertiesTextEdit-ClientInstanceName="monyrname" Caption="الإسم">
                            <PropertiesTextEdit ClientInstanceName="monyrname">
                                <ClientSideEvents Init="function(s, e) {monyrname.SetValue(monthsal.GetValue() + '/' + yearsal.GetValue());}" KeyPress="function(s, e) {preventwrite(s, e)}"></ClientSideEvents>
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="startdate" VisibleIndex="5" PropertiesDateEdit-ClientInstanceName="startdate" Caption="تاريخ البداية">
                            <PropertiesDateEdit>
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataDateColumn FieldName="enddate" VisibleIndex="6" PropertiesDateEdit-ClientInstanceName="enddate" Caption="تاريخ النهاية">
                            <PropertiesDateEdit>
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ هذا الحقل" />
                                </ValidationSettings>
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                    </Columns>
                    <SettingsPopup>
                        <EditForm Width="730">
                            <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                        </EditForm>
                    </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="monyrname" ShowInColumn="monyrname" ShowInGroupFooterColumn="monyrname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="monyrname" SummaryType="Count" />
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