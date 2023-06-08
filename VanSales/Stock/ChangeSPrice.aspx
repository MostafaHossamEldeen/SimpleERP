<%@ Page Title="أسعار البيع و خصومات الأصناف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeSPrice.aspx.cs" Inherits="VanSales.Stock.ChangeSPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="أسعار البيع و خصومات الأصناف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <br />
                    <div class="col-md-12"  dir="rtl">
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
    <table class="w-100" style="width: 100%">
        <tr>
            <td style="text-align: center"></td>
            <td>
                <asp:Panel ID="Panel1" runat="server" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                    <dx:ASPxFormLayout runat="server" AlignItemCaptions="true" AlignItemCaptionsInAllGroups="true" SettingsItemCaptions-HorizontalAlign="Right" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                            <Items>
                                <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem Caption="المجموعة">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_groupid" ClientInstanceName="cmb_groupid" runat="server" RightToLeft="True" ClearButton-DisplayMode="Always" NullText="الكل">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="نسبة الخصم ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxSpinEdit ID="txt_descp" runat="server" ClientInstanceName="txt_descp" DisplayFormatString="{0}%" NumberFormat="Percent" MaxValue="100">
                                                    </dx:ASPxSpinEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="سعر البيع">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_sprice" ClientInstanceName="txt_sprice" runat="server">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_apply" runat="server" Height="20px" Width="20px" ToolTip="تطبيق" Image-Url="~/Img/Icon/save.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_apply_Click"></dx:ASPxButton>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                    </asp:Panel>
                <dx:ASPxGridView ID="gvchangeprice" OnDataBinding="gvchangeprice_DataBinding" OnBatchUpdate="gvchangeprice_BatchUpdate" KeyFieldName="itemunitid" ClientInstanceName="gvchangeprice" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                    <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
                    <SettingsEditing Mode="Batch" BatchEditSettings-EditMode="Cell" UseFormLayout="False"></SettingsEditing>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowGroupPanel="True" ShowFooter="True" ShowPreview="True" UseFixedTableLayout="True" ShowTitlePanel="True"></Settings>

                    <SettingsBehavior AllowEllipsisInText="true" />
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
                    <SettingsSearchPanel Visible="True" ShowClearButton="True"></SettingsSearchPanel>

                    <SettingsFilterControl ShowAllDataSourceColumns="True">
                    </SettingsFilterControl>
                    <SettingsExport PaperKind="A4" FileName="أسعار الأصناف" PaperName="أسعار الأصناف" RightToLeft="True">
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
                        <dx:GridViewDataTextColumn FieldName="itemunitid" ReadOnly="True" VisibleIndex="1" Visible="False">
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
                        <dx:GridViewDataTextColumn FieldName="barcode1" VisibleIndex="3" Caption="باركود الصنف" ReadOnly="true">
                            <Settings ShowEditorInBatchEditMode="false"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="4" Caption="إسم الصنف" ReadOnly="true">
                            <Settings ShowEditorInBatchEditMode="false"></Settings>
                        </dx:GridViewDataTextColumn>
<%--                        <dx:GridViewDataTextColumn FieldName="groupname" VisibleIndex="5" Caption="المجموعة" ReadOnly="true">
                            <Settings ShowEditorInBatchEditMode="false" AllowGroup="True"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="itemtypename" VisibleIndex="6" Caption="النوع" ReadOnly="true">
                            <Settings ShowEditorInBatchEditMode="false" AllowGroup="True"></Settings>
                        </dx:GridViewDataTextColumn>--%>
                        <dx:GridViewDataTextColumn FieldName="suppname" VisibleIndex="7" Caption="المورد" ReadOnly="true">
                            <Settings ShowEditorInBatchEditMode="false" AllowGroup="True"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="8" Caption="الوحدة" ReadOnly="true">
                            <Settings ShowEditorInBatchEditMode="false" AllowGroup="True"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="sprice" VisibleIndex="9" Caption="سعر البيع">
                            <Settings ShowEditorInBatchEditMode="true"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="10" Caption="معامل التحويل">
                            <Settings ShowEditorInBatchEditMode="false"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="descp" Caption="نسبة الخصم" VisibleIndex="11">
                            <PropertiesSpinEdit DisplayFormatString="{0}%" NumberFormat="Percent" MaxValue="100"></PropertiesSpinEdit>
                        </dx:GridViewDataSpinEditColumn>

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
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:VanSales %>' SelectCommand="st_itemschaneprice_sel" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <dx:ASPxGridViewExporter ID="gvchangepriceExporter" runat="server" FileName="أسعار الأصناف" GridViewID="gvchangeprice" PaperKind="A4" PaperName="أسعار الأصناف" RightToLeft="True" Landscape="True">
                </dx:ASPxGridViewExporter>
            </td>
        </tr>
    </table>
            </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_docexport" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
            <asp:PostBackTrigger ControlID="btn_printexport" />
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>
