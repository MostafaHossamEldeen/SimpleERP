<%@ Page Title="ربط الحسابات الرئيسيه" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccBranchs.aspx.cs" Inherits="VanSales.GL.AccBranchs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/GL/AccBranches.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="Lbl_Tittle" runat="server" Text="الحسابات الرئيسية" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsx" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsx_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_word" runat="server" Height="20px" Width="20px" ToolTip="تصدير وورد" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_word_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdf" runat="server" Height="20px" Width="20px" ToolTip="تصدير PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdf_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_print_Click"></dx:ASPxButton>
                <br />
            </div>
            <br />
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
                                        <dx:ASPxComboBox ID="cmb_branchid" AutoPostBack="true" ClientInstanceName="cmb_branchid" runat="server" MaxLength="50" NullText="عام" TextField="branchname" ValueField="branchid" ClearButton-DisplayMode="Always"></dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
                <SettingsItemCaptions Location="Top" />
            </dx:ASPxFormLayout>
            <dx:ASPxGridView ID="gv_accbranchs"  OnDataBinding="gv_accbranchs_DataBinding"   OnBatchUpdate="gv_accbranchs_BatchUpdate" KeyFieldName="abid" ClientInstanceName="gv_accbranchs" SettingsBehavior-AllowFocusedRow="true" runat="server" AutoGenerateColumns="False" RightToLeft="True" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
                <Settings  ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True"  />
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
                <SettingsExport PaperKind="A4" FileName="الحسابات الرئيسية" PaperName="الحسابات الرئيسية" RightToLeft="True">
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
                    <dx:GridViewDataTextColumn  FieldName="abid" ReadOnly="True" VisibleIndex="1" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn FieldName="abname" Caption="اسم الحساب المطلوب ربطه" VisibleIndex="3" Width="150px">
                        <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                        <Settings ShowEditorInBatchEditMode="False"></Settings>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="chartcode" Caption="كود الحساب المربوط عليه" VisibleIndex="4" Width="100px">
                       <%-- <PropertiesComboBox MaxLength="50" DropDownStyle="DropDown">
                        </PropertiesComboBox>
                        <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />--%>
                        <Settings ShowEditorInBatchEditMode="false"></Settings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="chartname" Caption="الحساب المربوط عليه" VisibleIndex="5" Width="150px">
                       <%-- <PropertiesComboBox MaxLength="50" DropDownStyle="DropDown">
                        </PropertiesComboBox>
                        <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />--%>
                        <Settings ShowEditorInBatchEditMode="false"></Settings>
                    </dx:GridViewDataTextColumn>
                       <dx:GridViewDataTextColumn FieldName="bchartid" Caption="" VisibleIndex="6" Width="0">
                       <%-- <PropertiesComboBox MaxLength="50" DropDownStyle="DropDown">
                        </PropertiesComboBox>
                        <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />--%>
                        <Settings ShowEditorInBatchEditMode="false"></Settings>
                    </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataColumn Caption=" " VisibleIndex="5" Settings-ShowEditorInBatchEditMode="false"  Width="30px">
                <DataItemTemplate>
                         <button type="button" id="PopUpchartid" title="بحث" data-name="chart" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldscaption="كود الحساب,إسم الحساب"
                    data-displayfieldshidden="chartid" data-bindcontrols="hf_chartid" data-bindfields="chartid;chartcode;chartname"
                    data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
                    <dx:GridViewDataTextColumn FieldName="notes" VisibleIndex="5" Width="150px" Caption="ملاحظات">
                        <Settings ShowEditorInBatchEditMode="true"></Settings>
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gv_accbranchsExporter" runat="server" FileName="الحسابات الرئيسية" GridViewID="gv_accbranchs" PaperKind="A4" PaperName="الحسابات الرئيسية" RightToLeft="True" Landscape="True">
            </dx:ASPxGridViewExporter>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_word" />
            <asp:PostBackTrigger ControlID="btn_pdf" />
            <asp:PostBackTrigger ControlID="btn_xlsx" />
            <asp:PostBackTrigger ControlID="btn_print" />
        </Triggers>
    </asp:UpdatePanel>
     <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />
</asp:Content>