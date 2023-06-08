<%@ Page Title="أصناف الفروع" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="st_itemwh.aspx.cs" Inherits="VanSales.Stock.st_itemwh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="اصناف الفروع" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <br />
                    <div class="col-md-12"  dir="rtl">
                         <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                            <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                            </Image>
                        </dx:ASPxButton>
                         <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف المحدد" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function (s,e){deldata()}">
                        </dx:ASPxButton>
                         <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                         <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                         <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>
                         <dx:ASPxButton UseSubmitBehavior="false" ID="btn_printexport" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_printexport_Click"></dx:ASPxButton>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:HiddenField ID="HF_itemwhid" ClientIDMode="Static" runat="server" />
    <asp:Panel ID="Panel1" runat="server" BorderStyle="None" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
        <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
            <Items>
                <dx:LayoutGroup ColCount="3" GroupBoxDecoration="box" Caption="" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                    <CellStyle Font-Bold="True">
                    </CellStyle>
                    <Items>
                        <dx:LayoutItem Caption="الفرع">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="ddl_branchid" runat="server" ClientInstanceName="dll_branchname" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid">
                                        <ClientSideEvents SelectedIndexChanged="function(s,e){gv_itemwh.PerformCallback('fillgrid,'+s.GetValue()+','+ddl_groupid.GetValue())}" />
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="المجموعات">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxComboBox ID="ddl_groupid" runat="server" ClientInstanceName="ddl_groupid" Theme="MaterialCompact"  RightToLeft="True" TextField="groupname" ValueField="groupid">
                                         <ClientSideEvents SelectedIndexChanged="function(s,e){gv_itemwh.PerformCallback('fillgrid,'+s.GetValue()+','+ddl_groupid.GetValue())}" />
                                        <ClearButton DisplayMode="Always"></ClearButton>
                                    </dx:ASPxComboBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
            <SettingsItemCaptions Location="Top" />
        </dx:ASPxFormLayout>
    </asp:Panel>
    <table class="w-100" style="width: 100%">
        <tr>
            <td style="text-align: center"></td>
            <td>
                <dx:ASPxGridView ID="gv_itemwh" OnDataBinding="gv_itemwh_DataBinding" OnBatchUpdate="gv_itemwh_BatchUpdate" OnCustomCallback="gv_itemwh_CustomCallback" KeyFieldName="itemwhid" ClientInstanceName="gv_itemwh" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
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
                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="itemwhid" ReadOnly="True" VisibleIndex="1" Visible="false">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataHyperLinkColumn FieldName="itemid" ReadOnly="True" VisibleIndex="2" Caption=" كود الصنف">
                                <PropertiesHyperLinkEdit NullDisplayText="تلقائي" NavigateUrlFormatString="~\Stock\Item_Manage.aspx?itemid={0}" Target="_blank" TextField="itemcode">
                                    <Style Font-Bold="True"></Style>
                                </PropertiesHyperLinkEdit>
                                <Settings AllowGroup="False" SortMode="DisplayText" FilterMode="DisplayText" AutoFilterCondition="BeginsWith" ShowEditorInBatchEditMode="false"></Settings>
                                <EditFormSettings Visible="False"></EditFormSettings>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataHyperLinkColumn>
                        <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="3" Caption="اسم الصنف" ReadOnly="true">
                            <Settings ShowEditorInBatchEditMode="false"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="4" Visible="false">
                            <Settings ShowEditorInBatchEditMode="true"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="5" Caption="الوحدة">
                            <Settings ShowEditorInBatchEditMode="false"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="6" Caption="الكميه">
                            <PropertiesTextEdit>
                                <ClientSideEvents KeyDown="function(s, e) {decimale3num(s, e)}"></ClientSideEvents>
                            </PropertiesTextEdit>
                            <Settings ShowEditorInBatchEditMode="false"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="whminqty" VisibleIndex="7" Caption="اقل كميه" PropertiesTextEdit-ClientInstanceName="whminqty">
                            <PropertiesTextEdit>
                                <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e)}" ></ClientSideEvents>
                            </PropertiesTextEdit>
                            <Settings ShowEditorInBatchEditMode="true"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="whmaxqty" VisibleIndex="8" Caption="اكثر كميه" PropertiesTextEdit-ClientInstanceName="whmaxqty">
                            <PropertiesTextEdit>
                                <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e)}"></ClientSideEvents>
                            </PropertiesTextEdit>
                            <Settings ShowEditorInBatchEditMode="true"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="whplase" VisibleIndex="9" Caption="مكان التخزين">
                            <Settings ShowEditorInBatchEditMode="true"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="transcount" VisibleIndex="10" Visible="false">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="itemname" ShowInColumn="itemname" ShowInGroupFooterColumn="itemname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                        <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="qty" ShowInGroupFooterColumn="qty" SummaryType="Sum" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                    </TotalSummary>
                    <Styles>
                        <Footer Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle"  Font-Size="Medium" ForeColor="#009933">
                        </Footer>
                        <GroupFooter Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle">
                        </GroupFooter>
                        <GroupPanel HorizontalAlign="Right"></GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="gv_itemwhExporter" runat="server" FileName="أصناف الفروع" GridViewID="gv_itemwh" PaperKind="A4" PaperName="ItemsWh" RightToLeft="True" Landscape="True">
                </dx:ASPxGridViewExporter>
            </td>
        </tr>
    </table>
    <script>
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
                    gv_itemwh.PerformCallback(null);
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
        function GetError(s, e) {
            if (s.cperrors != 'undefined' && s.cperrors != null && s.cperrors.length != 0) {
                Swal.fire({
                    icon: s.cpicon,
                    title: s.cperrors,
                })
                s.cperrors = "";
            }
        }
    </script>
</asp:Content>