<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPramaterSet.aspx.cs" Inherits="VanSales.ReportDesginer.ReportPramaterSet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>تقارير</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <dx:ASPxGridView ID="gv_reports" OnDataBinding="gv_reports_DataBinding" OnBatchUpdate="gv_reports_BatchUpdate" KeyFieldName="RepName" SettingsBehavior-AllowSelectByRowClick="true" 
               SettingsBehavior-AllowSelectSingleRowOnly="true" SettingsBehavior-ProcessSelectionChangedOnServer="true"  OnSelectionChanged="ASPxGridView1_SelectionChanged" 
               ClientInstanceName="gv_reports" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
            <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
            <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell" UseFormLayout="False"></SettingsEditing>
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
            <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            <SettingsPopup>
                <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                    <SettingsAdaptivity VerticalAlign="WindowCenter" />
                </EditForm>
                <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
            </SettingsPopup>
            <SettingsSearchPanel Visible="True"></SettingsSearchPanel>

            <SettingsFilterControl ShowAllDataSourceColumns="True">
            </SettingsFilterControl>
          
            <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
            <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
            <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
            <Columns>
              <%--  <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                <dx:GridViewDataTextColumn FieldName="RepName"  VisibleIndex="1" Visible="true">
                    <EditFormSettings Visible="true"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RowsCount" VisibleIndex="2" Visible="true">
                </dx:GridViewDataTextColumn>
            
            </Columns>
           
           

         
        </dx:ASPxGridView>
        </div>
        <div>
              <dx:ASPxGridView ID="ASPxGridView1" OnDataBinding="ASPxGridView1_DataBinding"  KeyFieldName="Id" 
                  ClientInstanceName="gv_reports" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" >
            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
            <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
            <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell" UseFormLayout="False"></SettingsEditing>
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
            <SettingsDataSecurity AllowInsert="true" AllowDelete="true"></SettingsDataSecurity>
            <SettingsPopup>
                <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                    <SettingsAdaptivity VerticalAlign="WindowCenter" />
                </EditForm>
                <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
            </SettingsPopup>
            <SettingsSearchPanel Visible="True"></SettingsSearchPanel>

            <SettingsFilterControl ShowAllDataSourceColumns="True">
            </SettingsFilterControl>
          
            <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
            <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
            <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
            <Columns>
              <%--  <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                <dx:GridViewDataTextColumn FieldName="Caption" Caption="العنوان"  VisibleIndex="1" Visible="true">
                    <EditFormSettings Visible="true"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Data" Caption="الكنترول" VisibleIndex="2" Visible="true">
                </dx:GridViewDataTextColumn>
                
                <dx:GridViewDataTextColumn FieldName="Rowno" Caption="رقم السطر" VisibleIndex="2" Visible="true">
                </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="DataType" Caption="تاريخ" VisibleIndex="2" Visible="true">
                </dx:GridViewDataTextColumn>
                
            
            </Columns>
           
           

         
        </dx:ASPxGridView>
        </div>
   
    </form>
</body>
</html>
