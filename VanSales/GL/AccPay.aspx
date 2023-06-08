<%@ Page Title="حسابات طرق الدفع" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccPay.aspx.cs" Inherits="VanSales.GL.AccPay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/GL/AccPay.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="Lbl_Tittle" runat="server" Text="حسابات طرق الدفع" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton ID="btn_Save" runat="server" AutoPostBack="False" ClientInstanceName="btn_Save" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ" OnClick="btn_Save_Click">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_addnew" runat="server" AutoPostBack="False" ClientInstanceName="btn_addnew" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/AccPay/gl_accpay_del','hf_accpayid')}" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsx" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsx_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_word" runat="server" Height="20px" Width="20px" ToolTip="تصدير وورد" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_word_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdf" runat="server" Height="20px" Width="20px" ToolTip="تصدير PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdf_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_print_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_expand" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvaccpay.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvaccpay.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                </dx:ASPxButton>
                <br />
            </div>
            <br />
            <dx:ASPxFormLayout runat="server" ID="formlayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="5" GroupBoxDecoration="Box" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="طريقة الدفع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_paytypeid" runat="server" ClientInstanceName="cmb_paytypeid">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="الفرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <button type="button" id="PopUpchartid" title="بحث" data-name="chart" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldscaption="كود الحساب,إسم الحساب"
                                            data-displayfieldshidden="chartid"data-bindcontrols="hf_paychartid;txt_paychartname;txt_paychartcode" data-bindfields="chartid;chartname;chartcode"
                                            data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                                        </button>
                                        <%--<button type="button" id="PopUpNodeid" title="بحث" data-name="chart" data-tablename="gl_chart_sel_nodeid" data-displayfields="chartcode,chartname"
                                            data-displayfieldscaption="كود الحساب,إسم الحساب" data-displayfieldshidden="chartid"
                                            data-bindcontrols="hf_paychartid;txt_paychartname;txt_paychartcode" data-bindfields="chartid;chartname;chartcode"
                                            data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                                        </button>--%>
                                        </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="كود الحساب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <asp:HiddenField ID="hf_paychartid" runat="server" ClientIDMode="Static" Value="0" />
                                        <dx:ASPxTextBox ID="txt_paychartcode" ClientInstanceName="txt_paychartcode" runat="server" Width="100%" ClientReadOnly="true"></dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="الحساب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_paychartname" ClientInstanceName="txt_paychartname" runat="server" Width="100%">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="hf_accpayid" runat="server" ClientIDMode="Static" Value="0"/>
            <br />
            <dx:ASPxGridView ID="gvaccpay" ClientInstanceName="gvaccpay" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="accpayid" OnDataBinding="gvaccpay_DataBinding" ClientSideEvents-RowDblClick="function(s,e){gv_Bind(s,e);}">
                <SettingsPager AlwaysShowPager="True" PageSize="20">
                    <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                </SettingsPager>
                <SettingsEditing Mode="PopupEditForm">
                </SettingsEditing>
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
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
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False"></SettingsDataSecurity>
                <SettingsPopup>
                    <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                        <SettingsAdaptivity VerticalAlign="WindowCenter" />
                    </EditForm>
                    <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                </SettingsPopup>
                <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                <SettingsExport PaperKind="A4" FileName="customers" PaperName="customers" RightToLeft="True">
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
                    <dx:GridViewDataTextColumn FieldName="accpayid" ReadOnly="True" VisibleIndex="0" Visible="false">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paytypeid" VisibleIndex="1"  Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paytypename" VisibleIndex="2" Caption="طريقة الدفع"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="3" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="4" Caption="الفرع">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paychartid" VisibleIndex="5"  Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paychartname" VisibleIndex="6" Caption="الحساب">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsPopup>
                    <EditForm Width="730">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                    </EditForm>
                </SettingsPopup>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="paytypeid" ShowInColumn="paytypename" ShowInGroupFooterColumn="paytypename" SummaryType="Count" DisplayFormat="العدد : {0}" />
                </TotalSummary>
                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="paytypeid" SummaryType="Count" />
                </GroupSummary>
                <Styles>
                    <Footer Font-Bold="True">
                    </Footer>
                    <GroupPanel HorizontalAlign="Right">
                    </GroupPanel>
                    <PagerBottomPanel HorizontalAlign="Center">
                    </PagerBottomPanel>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvaccpayExporter" runat="server" FileName="حسابات طرق الدفع" GridViewID="gvaccpay" PaperKind="A4" PaperName="حساباتطرق الدفع" RightToLeft="True" Landscape="True">
                        <PageHeader Center="حسابات طرق الدفع" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>
        </ContentTemplate>
    <Triggers>
            <asp:PostBackTrigger ControlID="btn_xlsx" />
            <asp:PostBackTrigger ControlID="btn_word" />
            <asp:PostBackTrigger ControlID="btn_pdf" />
            <asp:PostBackTrigger ControlID="btn_print" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />
</asp:Content>