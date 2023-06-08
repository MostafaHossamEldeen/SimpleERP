<%@ Page Title="العملاء" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customers.aspx.cs" Inherits="VanSales.customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table class="dx-justification" style="width:100%">
        <tr>
            <td style="background-color:#dcdcdc;" class="text-center">
                 
                    <dx:ASPxLabel ID="lbltitle" runat="server" Text="الـــعـــــمـــلاء" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>

            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12"  dir="rtl">
                   <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {gvcustomers.AddNewRow();}" />
                    </dx:ASPxButton>
                   <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف المحدد" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function (s,e){deldata()}" ClientSideEvents="function(s, e) {AddDistributionList(s, e);}">
                    </dx:ASPxButton>
                   <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexport" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnxlsx_Click">
                    </dx:ASPxButton>
                   <dx:ASPxButton UseSubmitBehavior="false"  ID="ASPxbtndocexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btndoc_Click"></dx:ASPxButton>
                   <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnpdf_Click"></dx:ASPxButton>
                   <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexport" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnprint_Click"></dx:ASPxButton>
                   <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip = "اظهار الكل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvcustomers.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvcustomers.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <dx:ASPxGridView ID="gvcustomers" ClientInstanceName="gvcustomers" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" OnCustomCallback="gvcustomers_CustomCallback" KeyFieldName="custid" OnInitNewRow="gvcustomers_InitNewRow" OnDataBinding="gvcustomers_DataBinding" OnRowInserting="gvcustomers_RowInserting" OnRowUpdating="gvcustomers_RowUpdating" OnCellEditorInitialize="gvcustomers_CellEditorInitialize">
                    <SettingsPager AlwaysShowPager="True" PageSize="20">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
                     <ClientSideEvents RowDblClick="function(s, e) {
	s.GetRowValues(e.visibleIndex, 'custid', Done);
}" EndCallback="function(s,e){GetError(s,e)}"/>
                    <SettingsEditing Mode="PopupEditForm">
                    </SettingsEditing>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
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
                    <Columns>
                        <dx:GridViewCommandColumn SelectAllCheckboxMode="AllPages" ShowEditButton="True" ShowSelectCheckbox="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="custid" VisibleIndex="1" ReadOnly="True" ShowInCustomizationForm="True" Visible="false">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custcode" VisibleIndex="2" ShowInCustomizationForm="True" Caption="الكود" ReadOnly="true">
                            <PropertiesTextEdit MaxLength="50" NullDisplayText="تلقائي" NullText="تلقائي">
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custname" VisibleIndex="3" ShowInCustomizationForm="True" Caption="الإسم">
                            <PropertiesTextEdit MaxLength="100">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="Contains" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custename" VisibleIndex="4" ShowInCustomizationForm="True" Caption="الإسم E" Visible="false">
                            <PropertiesTextEdit MaxLength="100"></PropertiesTextEdit>
                            <EditFormSettings Visible="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn  FieldName="sgrpid" VisibleIndex="5" ShowInCustomizationForm="True" Caption="المجموعة">
                            <PropertiesComboBox>
                               <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                            <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataMemoColumn Caption="العنوان" FieldName="custadd" VisibleIndex="6">
                            <PropertiesMemoEdit MaxLength="100"></PropertiesMemoEdit>
                            <Settings AutoFilterCondition="Contains" />
                        </dx:GridViewDataMemoColumn>
                        <dx:GridViewDataTextColumn FieldName="custtel" VisibleIndex="7" ShowInCustomizationForm="True" Caption="تليفون/فاكس">
                            <PropertiesTextEdit MaxLength="100">
                                <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>

                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^[0-9]*$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custmob" VisibleIndex="8" ShowInCustomizationForm="True" Caption="الجوال">
                            <PropertiesTextEdit MaxLength="100">
                                <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>

                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^[0-9]*$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custvat" VisibleIndex="9" ShowInCustomizationForm="True" Caption="الملف الضريبي">
                            <PropertiesTextEdit MaxLength="50">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^[0-9]*$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="smanid" VisibleIndex="13" ShowInCustomizationForm="True" Caption="المندوب">
                            <PropertiesComboBox DropDownRows="5">
                            </PropertiesComboBox>
                            <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="discp" VisibleIndex="14" ShowInCustomizationForm="True" Caption="الخصم">
                            <PropertiesTextEdit MaxLength="5">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ValidationExpression="^\d{0,3}(\.\d{1,2})?$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custlimit" VisibleIndex="15" ShowInCustomizationForm="True" Caption="حد الإتمان">
                            <PropertiesTextEdit MaxLength="12">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,10}(\.\d{1,2})?$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="حد الإتمان بالأيام" FieldName="custlimitd" VisibleIndex="16">
                            <PropertiesTextEdit DisplayFormatString="g">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^[0-9]*$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings FilterMode="DisplayText" AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataCheckColumn FieldName="stopcust" VisibleIndex="17" ShowInCustomizationForm="True" Caption="الإيقاف">
                            <PropertiesCheckEdit DisplayTextChecked="موقوف" DisplayTextUnchecked="غير موقوف" ValueGrayed="False" DisplayTextGrayed="غير موقوف" DisplayTextUndefined="غير موقوف">
                            </PropertiesCheckEdit>
                            <Settings AutoFilterCondition="Equals" />
                        </dx:GridViewDataCheckColumn>
                           <dx:GridViewDataComboBoxColumn FieldName="custchartid" Name="custchartid" Caption="حساب العميل" VisibleIndex="12">
                            <PropertiesComboBox MaxLength="50" DropDownStyle="DropDown" DropDownHeight="0" >
                            </PropertiesComboBox>
                            <Settings AutoFilterCondition="BeginsWith" FilterMode="DisplayText"></Settings>
                               <EditItemTemplate>
                                   <div class="row" style="margin-left: 2px; margin-right: 2px;">
                                       <dx:ASPxComboBox ClientInstanceName="cmb_custchartid" ID="cmb_custchartid" OnInit="cmb_custchartid_Init" CssClass="col-md-8" runat="server" IncrementalFilteringMode="None" style="padding-right: 0px;padding-left: 0px;" ClearButton-DisplayMode="Always">
                                           <DropDownButton Enabled="false" ClientVisible="false"></DropDownButton>
                                       </dx:ASPxComboBox>
                                       <button type="button" id="PopUpchartid" title="بحث" data-name="chart" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldscaption="كود الحساب,إسم الحساب"
                                            data-displayfieldshidden="chartid"data-bindcontrols="hf_paychartid;txt_paychartname;txt_paychartcode" data-bindfields="chartid;chartname;chartcode"
                                            data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                                        </button>
                                       <%--<button type="button" style="margin-right: 15px;" id="Pop_CustChartid" data-name="Pop_CustChart" onclick="createPopUp($(this))" data-tablename="gl_chart_sel_search" data-displayfields="chartname,chartcode" data-displayfieldshidden="chartid"
                                           data-displayfieldscaption="إسم الحساب,رقم الحساب" data-bindcontrols=""
                                           data-bindfields="chartcode;chartid" data-pkfield="chartid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup"></button>--%>
                                   </div>
                               </EditItemTemplate>
                        </dx:GridViewDataComboBoxColumn>
                    </Columns>
                    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
            <SettingsBehavior AllowEllipsisInText="true"/>
            <EditFormLayoutProperties>
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
            </EditFormLayoutProperties>
                    <SettingsPopup>
            <EditForm Width="730">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
            </EditForm>
        </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="custcode" ShowInColumn="custcode" ShowInGroupFooterColumn="custcode" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="custid" SummaryType="Count" />
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

    <dx:ASPxGridViewExporter ID="gvcustomersExporter" runat="server" FileName="العملاء" GridViewID="gvcustomers" PaperKind="A4" PaperName="Customers"
        RightToLeft="True" Landscape="True">
        <PageHeader Center="الـــعـــــمـــلاء">
        </PageHeader>
        <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
    <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
    <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />
    <script src="../Scripts/App/customer/customer.js"></script>
</asp:Content>
