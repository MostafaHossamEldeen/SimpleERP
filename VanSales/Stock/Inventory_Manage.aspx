<%@ Page Title="إدارة سند جرد" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory_Manage.aspx.cs" Inherits="VanSales.Stock.Inventory_Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/stock/Inventory_Manage.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="إدارة سند جرد" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="buttons" dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save" runat="server" ClientInstanceName="btn_save" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" AutoPostBack="true" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_save_Click">
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" ClientInstanceName="btn_new" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_new_Click">
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" ClientInstanceName="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/Stock/DeleteInventory', 'HF_inventid') }" />
                </dx:ASPxButton>
                <button type="button" title="بحث" id="PopUpControlSearch" data-name="inventory" data-tablename="st_inventory_sel" data-displayfields="inventno,inventdocno,inventdate,branchname"
                    data-displayfieldshidden="inventid,branchid,notes,inventuser,postst"
                    data-displayfieldscaption="رقم السند,الرقم اليدوي,التاريخ,الفرع"
                    data-bindcontrols="HF_inventid;txt_inventno;txt_inventdocno;dt_inventdate;cmb_branchid;txt_notes;txt_inventuser;hf_postst"
                    data-bindfields="inventid;inventno;inventdocno;inventdate;branchid;notes;inventuser;postst;"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="inventid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_printexport" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_printexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_poststock" ClientInstanceName="btn_poststock" runat="server" Height="20px" Width="20px" ToolTip="ترحيل مستودع" Image-Url="~/Img/Icon/poststock.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s,e){PostInventory(s,e)}" />
                </dx:ASPxButton>
            </div>
            <br />
            <asp:Panel ID="Panel1" runat="server" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                            <Items>
                                <dx:LayoutItem Caption="رقم الجرد ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_inventno" ClientInstanceName="txt_inventno" runat="server" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى" ReadOnly="true">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="الرقم اليدوي ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_inventdocno" ClientInstanceName="txt_inventdocno" runat="server" Theme="MaterialCompact">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="التاريخ ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxDateEdit ID="dt_inventdate" runat="server" RightToLeft="True" Theme="MaterialCompact" ClientInstanceName="dt_inventdate">
                                            </dx:ASPxDateEdit>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dt_inventdate" Display="Dynamic" ErrorMessage="برجاء إختيار تاريخ الجرد" ForeColor="Red" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                            <Items>
                                <dx:LayoutItem Caption="الفرع ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_branchid" runat="server" ValueType="System.String" ClientInstanceName="cmb_branchid" RightToLeft="True" Theme="MaterialCompact" SelectedIndex="0"></dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="الكمية الفعلية ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_pqty" runat="server" ValueType="System.String" ClientInstanceName="cmb_pqty" RightToLeft="True" Theme="MaterialCompact"></dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="ملاحظات ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxMemo ID="txt_notes" runat="server" RightToLeft="True" Theme="MaterialCompact" ClientInstanceName="inventdate">
                                            </dx:ASPxMemo>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="المستخدم ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_inventuser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_inventuser" ClientReadOnly="true">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_postst" />
                                            <dx:ASPxLabel ID="lbl_postst" runat="server" ClientInstanceName="lbl_postst" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
                <asp:HiddenField ID="HF_inventid" ClientIDMode="Static" runat="server" Value="0" OnValueChanged="HF_inventid_ValueChanged" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Font-Bold="True" ForeColor="Black" Direction="RightToLeft" Style="text-align: right; display: none;">
                <dx:ASPxGridView ID="gv_inventdlts" ClientInstanceName="gv_inventdlts" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" ClientSideEvents-BatchEditStartEditing="function(s,e){batchEditStart(s,e)}" OnDataBinding="gv_inventdlts_DataBinding" OnBatchUpdate="gv_inventdlts_BatchUpdate" KeyFieldName="invtdtlsid" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" ClientSideEvents-BatchEditEndEditing="function(s,e){calc(s, e);}" OnCustomCallback="gv_inventdlts_CustomCallback">
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
                        <dx:GridViewDataTextColumn FieldName="invtdtlsid" ReadOnly="True" VisibleIndex="1" Visible="False">
                            <EditFormSettings Visible="False"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="inventid" VisibleIndex="2" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="itemid" Caption="الصنف" VisibleIndex="4">
                            <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                            <Settings ShowEditorInBatchEditMode="False"></Settings>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="unitid" Caption="الوحدة" VisibleIndex="5">
                            <Settings ShowEditorInBatchEditMode="False"></Settings>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="6" Caption="معامل التحويل" Visible="false">
                            <Settings ShowEditorInBatchEditMode="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="tqty" VisibleIndex="7" Caption="الكمية الدفترية">
                            <PropertiesTextEdit ClientInstanceName="tqty"></PropertiesTextEdit>
                            <Settings ShowEditorInBatchEditMode="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="pqty" VisibleIndex="8" Caption="الكمية الفعلية">
                            <PropertiesTextEdit ClientInstanceName="pqty"></PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="diffqty" VisibleIndex="9" Caption="فرق الكمية">
                            <PropertiesTextEdit ClientInstanceName="diffqty"></PropertiesTextEdit>
                            <Settings ShowEditorInBatchEditMode="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="cost" VisibleIndex="10" Caption="التكلفة">
                            <PropertiesTextEdit ClientInstanceName="cost"></PropertiesTextEdit>
                            <Settings ShowEditorInBatchEditMode="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="diffcost" VisibleIndex="11" Caption="فرق التكلفة">
                            <PropertiesTextEdit ClientInstanceName="diffcost"></PropertiesTextEdit>
                            <Settings ShowEditorInBatchEditMode="False"></Settings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="itemcode" Caption="كود الصنف" VisibleIndex="3"></dx:GridViewDataTextColumn>
                    </Columns>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="itemid" ShowInColumn="itemid" ShowInGroupFooterColumn="itemid" SummaryType="Count" DisplayFormat="{0}" />
                        <dx:ASPxSummaryItem FieldName="tqty" ShowInColumn="tqty" ShowInGroupFooterColumn="tqty" SummaryType="Sum" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem FieldName="pqty" ShowInColumn="pqty" ShowInGroupFooterColumn="pqty" SummaryType="Sum" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem FieldName="diffqty" ShowInColumn="diffqty" ShowInGroupFooterColumn="diffqty" SummaryType="Sum" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem FieldName="diffcost" ShowInColumn="diffcost" ShowInGroupFooterColumn="diffcost" SummaryType="Sum" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                    </TotalSummary>

                    <Styles>
                        <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        <GroupFooter Font-Bold="False">
                        </GroupFooter>
                        <GroupPanel HorizontalAlign="Right"></GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="gv_inventdltsExporter" runat="server" FileName="سندات الجرد" GridViewID="gv_inventdlts" PaperKind="A4" PaperName="inventdlts" RightToLeft="True" Landscape="True">
                </dx:ASPxGridViewExporter>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_docexport" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
            <%--<asp:PostBackTrigger ControlID="btn_printexport" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>