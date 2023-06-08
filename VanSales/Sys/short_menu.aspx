<%@ Page Title="القائمه المختصره" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="short_menu.aspx.cs" Inherits="VanSales.Sys.short_menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/sys/short_menu.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>

    <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="القائمه المختصره" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
    <dx:ASPxGridView ID="gvshortmenu" OnDataBinding="gvshortmenu_DataBinding" OnBatchUpdate="gvshortmenu_BatchUpdate" KeyFieldName="pageid" ClientInstanceName="gvshortmenu" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
        <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}"   />
        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
        <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
        <SettingsPager AlwaysShowPager="True" PageSize="20">
            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
        </SettingsPager>
        <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Row" UseFormLayout="False"></SettingsEditing>
        <SettingsBehavior AllowEllipsisInText="true" AllowGroup="False" />
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
            <UpdateButton RenderMode="Image" >
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
        <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
        <SettingsPopup>
            <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                <SettingsAdaptivity VerticalAlign="WindowCenter" />
            </EditForm>
            <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
        </SettingsPopup>
        <SettingsFilterControl ShowAllDataSourceColumns="True">
        </SettingsFilterControl>
        <SettingsExport PaperKind="A4" FileName="permissions" PaperName="permissions" RightToLeft="True">
            <PageHeader>
                <Font Bold="True" Size="Medium"></Font>
            </PageHeader>
        </SettingsExport>
        <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
        <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="pageid" ReadOnly="True" VisibleIndex="2" Visible="false"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="pmodid" ReadOnly="True" VisibleIndex="1" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="pmodname" ReadOnly="True" VisibleIndex="4" Visible="false" Caption="التابعيه"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="pagenamer" ReadOnly="True" VisibleIndex="3" Caption="الشاشة"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="pagetype" ReadOnly="True" VisibleIndex="5" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="shortmenu" VisibleIndex="6" Caption="القائمه المختصره"  PropertiesCheckEdit-ValueType="System.Boolean">
                <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
            </dx:GridViewDataCheckColumn>
        </Columns>
        <Styles>
            <Footer Font-Bold="True">
            </Footer>
            <GroupFooter Font-Bold="False">
            </GroupFooter>
            <GroupPanel HorizontalAlign="Right"></GroupPanel>
            <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>
