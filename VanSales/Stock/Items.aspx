<%@ Page Title="الأصـــــــــنــاف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="VanSales.Items" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
    <table class="dx-justification" style="width: 100%">
        <tr>
            <td class="text-center pagetitletd">
                
                    <dx:ASPxLabel ID="lbltitle" CssClass="pagetitlelable" runat="server" Text="الأصـــــــــنــاف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12" dir="rtl">
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" ToolTip="جديد" AutoPostBack="False" CssClass="btn_new" Height="35px" Width="50px">
                        <ClientSideEvents Click="function(s, e) { window.open('item_manage.aspx','_self');}" />
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" ToolTip="حذف المحدد" AutoPostBack="False" CssClass="btn_delete" Height="35px" Width="50px" ClientSideEvents-Click="function (s,e){deldata()}">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexport" runat="server" ToolTip="Excel"  AutoPostBack="False" CssClass="btn_excel" Height="35px" Width="50px" OnClick="btnxlsx_Click">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtndocexport" runat="server" ToolTip="Word" AutoPostBack="False" CssClass="btn_word" Height="35px" Width="50px" OnClick="btndoc_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexport" runat="server"  ToolTip="PDF" CssClass="btn_pdf" Height="35px" Width="50px" AutoPostBack="False" OnClick="btnpdf_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexport" runat="server"  ToolTip="طباعة" CssClass="btn_print" Height="35px" Width="50px" AutoPostBack="False" OnClick="btnprint_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server"  ToolTip="إظهار التفاصيل" AutoPostBack="False" CssClass="btn_expand" Height="35px" Width="50px">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvitems.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvitems.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <div style="margin: 20PX;">
                    <dx:ASPxGridView  ClientSideEvents-BatchEditStartEditing="function(s,e){CheckStatucs(s,e)}"  ID="gvitems"  ClientInstanceName="gvitems" OnInitNewRow="gvitems_InitNewRow" OnRowDeleting="gvitems_RowDeleting" runat="server" AutoGenerateColumns="False" KeyFieldName="itemid" OnRowInserting="gvitems_RowInserting" RightToLeft="True" Width="100%" OnRowUpdating="gvitems_RowUpdating" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" OnCustomCallback="gvitems_CustomCallback" OnDataBinding="gvitems_DataBinding">
                        <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" BeginCallback="function(s,e){CheckStatucs(s,e)}"/>
                        <SettingsPager AlwaysShowPager="True" PageSize="20">
                            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                        </SettingsPager>
                        <SettingsEditing Mode="PopupEditForm" BatchEditSettings-EditMode="Cell"></SettingsEditing>
                        <Settings  ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterBar="Visible" />
                        <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" AllowFixedGroups="True" />
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
                        <SettingsExport PaperKind="A4" FileName="Items" PaperName="Items" RightToLeft="True">
                            <PageHeader>
                                <Font Bold="True" Size="Medium"></Font>
                            </PageHeader>
                        </SettingsExport>
                        <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                        <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                        <Columns>
                            <dx:GridViewDataHyperLinkColumn FieldName="itemid" ReadOnly="True" VisibleIndex="1" Caption=" كود الصنف">
                                <PropertiesHyperLinkEdit NullDisplayText="تلقائي" NavigateUrlFormatString="~\Stock\Item_Manage.aspx?itemid={0}" Target="_parent" TextField="itemcode">
                                    <Style Font-Bold="True"></Style>
                                </PropertiesHyperLinkEdit>
                                <Settings AllowGroup="False" SortMode="DisplayText" FilterMode="DisplayText" AutoFilterCondition="BeginsWith"></Settings>
                                <EditFormSettings Visible="False"></EditFormSettings>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataHyperLinkColumn>
                            <dx:GridViewDataTextColumn FieldName="itemcode" Caption="كود الصنف" VisibleIndex="2" Visible="False">
                                <PropertiesTextEdit NullText="تلقائي" MaxLength="50" ClientSideEvents-KeyDown="function(s,e){preventwriteitemcode(s, e);}" NullDisplayText="تلقائي" ClientInstanceName="itemcode">
                                </PropertiesTextEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith"></Settings>
                                <EditFormSettings Visible="True"></EditFormSettings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowEditButton="True" VisibleIndex="0" ShowClearFilterButton="True" ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="itemcode2" VisibleIndex="3" Visible="false" Caption="كود الصنف 2">
                                <PropertiesTextEdit MaxLength="50" ClientInstanceName="itemcode2"></PropertiesTextEdit>
                                <EditFormSettings Visible="True" />
                                <CellStyle Font-Bold="True"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemcode3" VisibleIndex="4" Caption="كود المورد" Visible="False">
                                <PropertiesTextEdit MaxLength="50">
                                </PropertiesTextEdit>
                                <EditFormSettings Visible="True"></EditFormSettings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itembarcode" VisibleIndex="5" Caption="باركود الصنف">
                                <PropertiesTextEdit MaxLength="50" ClientInstanceName="itembarcode">
                                </PropertiesTextEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith"></Settings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itembarcode2" VisibleIndex="6" Caption="باركود الصنف 2" Visible="False">
                                <PropertiesTextEdit MaxLength="50">
                                </PropertiesTextEdit>
                                <EditFormSettings Visible="True"></EditFormSettings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="7" Caption="إسم الصنف">
                                <PropertiesTextEdit MaxLength="100">
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                        <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                    </ValidationSettings>
                                    <Style Font-Bold="True"></Style>
                                </PropertiesTextEdit>
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <CellStyle Font-Bold="True"></CellStyle>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemename" VisibleIndex="8" Caption="إسم الصنف E" Visible="False">
                                <PropertiesTextEdit MaxLength="100">
                                </PropertiesTextEdit>
                                <EditFormSettings Visible="True"></EditFormSettings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataMemoColumn Caption="الوصف" FieldName="itemdesc" VisibleIndex="9">
                                <PropertiesMemoEdit MaxLength="200">
                                </PropertiesMemoEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="Contains" />
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="unitid" VisibleIndex="10" Caption="الوحدة">
                                <PropertiesComboBox>
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesComboBox>
                                <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="groupid" VisibleIndex="11" Caption="المجموعة">
                                <PropertiesComboBox DropDownRows="5" TextField="groupname" ValueField="groupid">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" SetFocusOnError="True">
                                        <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesComboBox>
                                <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="itemtypeid" VisibleIndex="12" Caption="نوع الصنف">
                                <PropertiesComboBox TextField="citemname" ValueField="citemid" DropDownRows="5">
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesComboBox>
                                <Settings AutoFilterCondition="Contains"></Settings>
                                <EditFormSettings Visible="True"></EditFormSettings>
                                <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="suppid" VisibleIndex="13" Caption="المورد">
                                <PropertiesComboBox DropDownRows="5" TextField="suppname" ValueField="suppid">
                                </PropertiesComboBox>
                                <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="minqty" VisibleIndex="14" Caption="أقل كمية">
                                <PropertiesTextEdit MaxLength="12">
                                    <ClientSideEvents KeyPress="function(s, e) {
decimale3num(s, e);
}
"></ClientSideEvents>
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,3})?$" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                                <Settings AutoFilterCondition="BeginsWith" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="maxqty" VisibleIndex="15" Caption="أقصى كمية">
                                <PropertiesTextEdit MaxLength="12">
                                    <ClientSideEvents KeyPress="function(s, e) {
decimale3num(s, e);
}
"></ClientSideEvents>
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,3})?$" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                                <Settings AutoFilterCondition="BeginsWith" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="itemstop" VisibleIndex="16" Caption="إيقاف الصنف">
                                <PropertiesComboBox TextField="citemname" ValueField="citemid" DropDownRows="5">
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip">
                                        <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesComboBox>
                                <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="pprice" VisibleIndex="17" Caption="سعر الشراء">
                                <PropertiesTextEdit MaxLength="12">
                                    <ClientSideEvents KeyPress="function(s, e) {
decimale3num(s, e);
}
"></ClientSideEvents>
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,2})?$" />
                                        <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="cprice" VisibleIndex="18" Caption="سعر التكلفة" Visible="False">
                                <PropertiesTextEdit MaxLength="12">
                                    <ClientSideEvents KeyPress="function(s, e) {
decimale3num(s, e);
}
"></ClientSideEvents>
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,2})?$" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                                <EditFormSettings Visible="true" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="sprice" VisibleIndex="19" Caption="سعر البيع">
                                <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e)}" ClientInstanceName="Selprice" MaxLength="12">
                                    <ClientSideEvents KeyUp="function(s, e) {calcVat(s,e);}" KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,2})?$" />
                                        <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vprice" VisibleIndex="23" Caption="السعر شامل">
                                <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e)}" ClientInstanceName="vatprice" MaxLength="12">
                                    <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);preventwrite(s, e);}"></ClientSideEvents>
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,2})?$" />
                                        <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="fprice" VisibleIndex="20" Caption="سعر الفاتورة">
                                <PropertiesTextEdit ClientInstanceName="fpricevalue" MaxLength="12">
                                    <ClientSideEvents KeyPress="function(s, e) {
decimale3num(s, e);
}
"></ClientSideEvents>
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithTooltip">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,2})?$" />
                                        <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataImageColumn FieldName="itempic" VisibleIndex="24" Caption="الصورة" CellStyle-CssClass="zoom">
                                <PropertiesImage AlternateTextField="itemname" DescriptionUrlField="itemdesc" ImageAlign="Middle" ImageHeight="50px" ImageWidth="50px" ShowLoadingImage="True">
                                </PropertiesImage>
                                <Settings AllowGroup="False" AllowAutoFilter="False" ShowFilterRowMenu="False" />
                                <EditItemTemplate>
                                    <dx:ASPxUploadControl ID="ASPxUploadItemPic" runat="server" UploadMode="Advanced" Width="100%" ShowProgressPanel="True" UploadStorage="FileSystem" OnFileUploadComplete="ASPxUploadItemPic_FileUploadComplete" ShowUploadButton="True" AutoStartUpload="True" FileSystemSettings-GenerateUniqueFileNamePrefix="True" RightToLeft="True" ValidationSettings-GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" ValidationSettings-MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد رفعها في وقت واحد (والذي تم تعيينه على {1})." ValidationSettings-MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" ValidationSettings-NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به" Theme="MaterialCompact" ShowTextBox="False" ToolTip="رفع صورة الصنف">
                                        <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .png" GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد تحميلها في وقت واحد (والذي تم تعيينه على {1})." MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" MultiSelectionErrorText="انتباه! {0} من الملفات غير صالحة ولن يتم رفعها. الأسباب المحتملة هي: أنها تتجاوز حجم الملف المسموح به ({1}) ، أو امتداداتها غير مسموح بها ، أو تحتوي أسماء ملفاتها على أحرف غير صالحة. تمت إزالة هذه الملفات من التحديد: {2}" NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به">
                                        </ValidationSettings>
                                        <ClientSideEvents FilesUploadComplete="function(s, e) {updmsg(s,e);ASPxUploadItemPic.SetVisible = false;}"></ClientSideEvents>
                                        <RemoveButton Text="حذف" Image-Url="~/Img/Icon/delete.svg" Image-ToolTip="حذف" Image-Width="20" Image-Height="20" Image-AlternateText="حذف">
                                        </RemoveButton>
                                        <UploadButton Text="رفع الصورة" Image-Url="~/Img/Icon/import.svg" Image-ToolTip="رفع الصورة" Image-Height="20" Image-Width="20" Image-AlternateText="رفع الصورة">
                                        </UploadButton>
                                        <CancelButton Text="إلغاء" Image-Url="~/Img/Icon/cancel.svg" Image-ToolTip="إلغاء" Image-Width="20" Image-Height="20" Image-AlternateText="إلغاء">
                                        </CancelButton>
                                        <AdvancedModeSettings DropZoneText="قم برفع الصور أو سحبها و إفلاتها هنا"></AdvancedModeSettings>
                                        <FileSystemSettings UploadFolder="~\Img\Item" />
                                    </dx:ASPxUploadControl>
                                </EditItemTemplate>
                                <CellStyle CssClass="zoom"></CellStyle>
                            </dx:GridViewDataImageColumn>
                            <dx:GridViewDataSpinEditColumn FieldName="vat" Caption="% الضريبة المضافة" VisibleIndex="22">
                                <PropertiesSpinEdit DisplayFormatString="g" MaxLength="5" ClientInstanceName="vatvalue" MaxValue="100">
                                    <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}" KeyUp="function(s, e) {calcVat(s,e);}" ValueChanged="function(s,e){calcVat(s,e)}"></ClientSideEvents>

                                    <ValidationSettings Display="Dynamic">
                                        <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,3}(\.\d{1,2})?$"></RegularExpression>

                                        <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                    </ValidationSettings>
                                </PropertiesSpinEdit>

                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith"></Settings>
                            </dx:GridViewDataSpinEditColumn>
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
                            <dx:ASPxSummaryItem FieldName="itemcode" ShowInColumn="itemcode" ShowInGroupFooterColumn="itemcode" SummaryType="Count" DisplayFormat="العدد : {0}" />
                        </TotalSummary>
                        <GroupSummary>
                            <dx:ASPxSummaryItem FieldName="itemid" SummaryType="Count" />
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
                </div>
                <div dir="rtl">
                    <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True" >
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="رفع الاكسيل">
                            <Items>
                                <dx:LayoutItem Caption="" ColumnSpan="2" CaptionSettings-Location="Left"  >
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                 <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="رفع الاصناف:" Font-Bold="true"></dx:ASPxLabel>
                                                <asp:FileUpload ID="FileUpload2" runat="server" />
 
   <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server"  ToolTip="رفع ملف" CssClass="btn_import" Height="35px" Width="50px" AutoPostBack="false" OnClick="btn_attach_Click"></dx:ASPxButton>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                    
 </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <%--<SettingsItemCaptions Location="Top" />--%>
                    </dx:ASPxFormLayout>
                </div>
            </td>
        </tr>
    </table>
    <dx:ASPxGridViewExporter ID="gvitemsExporter"  runat="server" FileName="الأصناف" GridViewID="gvitems" PaperKind="A4" PaperName="Items" RightToLeft="True" Landscape="True">
        <PageHeader Center="الأصناف">
        </PageHeader>
        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
    <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script type="text/javascript">
        var selectimg;
        function onvaluechanged(values) {
            gvitems.PerformCallback(values);
        }

        function calcVat(s, e) {
            let vattype = GetToken();
            if (vattype.vattype=="1") {
                const sum = parseFloat(Selprice.GetValue()) * parseFloat(vatvalue.GetValue())
                vatprice.SetValue(parseFloat((parseFloat(sum) / 100) + parseFloat(Selprice.GetValue())).toFixed(2))
                if (isNaN(vatprice.GetValue())) {
                    vatprice.SetValue(0);
                }
                fpricevalue.SetValue(parseFloat(vatprice.GetValue()).toFixed(2))
            }
            else {
                const sum = parseFloat(Selprice.GetValue()) * parseFloat(vatvalue.GetValue())
                vatprice.SetValue(parseFloat((parseFloat(sum) / 100) + parseFloat(Selprice.GetValue())).toFixed(2))
                if (isNaN(vatprice.GetValue())) {
                    vatprice.SetValue(0);
                }
                fpricevalue.SetValue(parseFloat(Selprice.GetValue()).toFixed(2))
            }
          
        }

        function sweetexception() {
            Swal.fire({
                icon: 'error',
                title: ("<%=hferror.Value%>"),
                //showClass: {
                //    popup: 'animate__animated animate__fadeInDown'
                //},
                //hideClass: {
                //    popup: 'animate__animated animate__fadeOutUp'
                //}
            })
        }

        function GetError(s, e) {
            if (s.cperrors != 'undefined' && s.cperrors != null && s.cperrors.length != 0) {
                Swal.fire({
                    icon: s.cpicon,
                    title: s.cperrors,
                    //showClass: {
                    //    popup: 'animate__animated animate__fadeInDown'
                    //},
                    //hideClass: {
                    //    popup: 'animate__animated animate__fadeOutUp'
                    //}
                })
                s.cperrors = "";
            }
        }

        function deldata() {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: true
            })

            swalWithBootstrapButtons.fire({
                title: 'تأكيد الحذف',
                text: "هل تريد حذف البيانات",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: ' نعم, تأكيد',
                cancelButtonText: 'لا, إلغاء ',
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                    gvitems.GetSelectedFieldValues("itempic", onvaluechanged);
                } else if (
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'إلغاء',
                        'تم إلغاء عملية الحذف',
                        'error'
                    )
                }
            })
        }

        function updmsg(s, e) {
            Swal.fire({
                icon: 'success',
                title: 'تم رفع صورة الصنف بنجاح',
                showConfirmButton: false,
                timer: 2000,
                //showClass: {
                //    popup: 'animate__animated animate__fadeInDown'
                //},
                //hideClass: {
                //    popup: 'animate__animated animate__fadeOutUp'
                //}
            })
        }
        function CheckStatucs(s, e) {
           // alert("s")

        }
    </script>
</asp:Content>