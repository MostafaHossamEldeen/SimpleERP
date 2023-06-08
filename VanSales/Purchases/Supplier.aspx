<%@ Page Title="الموردين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="VanSales.Supplier.Supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table class="dx-justification" style="width:100%">
        <tr>
            <td style="background-color:#dcdcdc;" class="text-center">
      
                  <dx:ASPxLabel ID="lbltitle" runat="server" Text="الــمــورديــن" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>

            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12"  dir="ltr">
                    <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip = "اظهار الكل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvsuppliers.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvsuppliers.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexport" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnprint_Click"></dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnpdf_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtndocexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btndoc_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexport" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnxlsx_Click">
                    </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف المحدد" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function (s,e){deldata()}" ClientSideEvents="function(s, e) {AddDistributionList(s, e);}">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {gvsuppliers.AddNewRow();}" />
                    </dx:ASPxButton>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <dx:ASPxGridView  ID="gvsuppliers" ClientInstanceName="gvsuppliers" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" OnCustomCallback="gvsuppliers_CustomCallback" KeyFieldName="suppid" OnInitNewRow="gvsuppliers_InitNewRow" OnDataBinding="gvsuppliers_DataBinding" OnRowInserting="gvsuppliers_RowInserting" OnRowUpdating="gvsuppliers_RowUpdating" OnCellEditorInitialize="gvsuppliers_CellEditorInitialize"  OnEditFormLayoutCreated="gvsuppliers_EditFormLayoutCreated">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                    <SettingsPager AlwaysShowPager="True" PageSize="20">
                        <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                    </SettingsPager>
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
                    <SettingsExport PaperKind="A4" FileName="supplier" PaperName="supplier" RightToLeft="True">
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
                        <dx:GridViewDataTextColumn FieldName="suppid" VisibleIndex="1" ReadOnly="True" ShowInCustomizationForm="True" Visible="true" Caption="الكود">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="suppname" VisibleIndex="2" ShowInCustomizationForm="True" Caption="الإسم">
                            <PropertiesTextEdit MaxLength="100">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="Contains" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="suppename" VisibleIndex="3" ShowInCustomizationForm="True" Caption="الإسم E" Visible="false">
                            <PropertiesTextEdit MaxLength="100"></PropertiesTextEdit>
                            <EditFormSettings Visible="true" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="pgrpid" VisibleIndex="4" ShowInCustomizationForm="True" Caption="المجموعة">
                            <PropertiesComboBox>
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                </ValidationSettings>
                            </PropertiesComboBox>
                            <Settings FilterMode="DisplayText" AutoFilterCondition="Contains" />
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataMemoColumn Caption="العنوان" FieldName="suppadd" VisibleIndex="5">
                            <PropertiesMemoEdit MaxLength="100"></PropertiesMemoEdit>
                            <Settings AutoFilterCondition="Contains" />
                        </dx:GridViewDataMemoColumn>
                        <dx:GridViewDataTextColumn FieldName="supptel" VisibleIndex="6" ShowInCustomizationForm="True" Caption="تليفون/فاكس">
                            <PropertiesTextEdit MaxLength="100">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^[0-9]*$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="suppmob" VisibleIndex="7" ShowInCustomizationForm="True" Caption="الجوال">
                            <PropertiesTextEdit MaxLength="100">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^[0-9]*$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="suppvatno" VisibleIndex="8" ShowInCustomizationForm="True" Caption="الملف الضريبي">
                            <PropertiesTextEdit MaxLength="50">
                                <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                    <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^[0-9]*$" />
                                </ValidationSettings>
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="country" VisibleIndex="9" ShowInCustomizationForm="True" Caption="المدينة">
                            <PropertiesTextEdit MaxLength="100">
                            </PropertiesTextEdit>
                            <Settings AutoFilterCondition="BeginsWith" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn FieldName="suppchartid" Name="suppchartid" Caption="حساب المورد" VisibleIndex="10">
                            <PropertiesComboBox MaxLength="50" DropDownStyle="DropDown">
                            </PropertiesComboBox>
                            <Settings AutoFilterCondition="BeginsWith" FilterMode="DisplayText"></Settings>
                               <EditItemTemplate>
                                   <div class="row" style="margin-left: 2px; margin-right: 2px;">
                                       <dx:ASPxComboBox ClientInstanceName="cmb_suppchartid" ID="cmb_suppchartid" OnInit="cmb_suppchartid_Init" CssClass="col-md-8" runat="server" IncrementalFilteringMode="None" style="padding-right: 0px;padding-left: 0px;" ClearButton-DisplayMode="Always">
                                           <DropDownButton Enabled="false" ClientVisible="false"></DropDownButton>
                                       </dx:ASPxComboBox>
                                       <%--<button type="button" style="margin-right: 15px;" id="Pop_suppchartid" data-name="Pop_suppchart" onclick="createPopUp($(this))" data-tablename="gl_chart_sel_search" data-displayfields="chartname,chartcode" data-displayfieldshidden="chartid"
                                           data-displayfieldscaption="إسم الحساب,رقم الحساب" data-bindcontrols=""
                                           data-bindfields="chartcode;chartid" data-pkfield="chartid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup"></button>--%>
                                       <button type="button" id="PopUpchartid" title="بحث" data-name="chart" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldscaption="كود الحساب,إسم الحساب"
                                            data-displayfieldshidden="chartid"data-bindcontrols="hf_paychartid;txt_paychartname;txt_paychartcode" data-bindfields="chartid;chartname;chartcode"
                                            data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                                        </button>
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
                        <dx:ASPxSummaryItem FieldName="suppname" ShowInColumn="suppname" ShowInGroupFooterColumn="suppname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="suppname" SummaryType="Count" />
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
    <dx:ASPxGridViewExporter ID="gvsuppliersExporter" runat="server" FileName="الموردين" GridViewID="gvsuppliers" PaperKind="A4" PaperName="suppliers"
        RightToLeft="True" Landscape="True">
        <PageHeader Center="الــمــورديــن">
        </PageHeader>
        <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
    <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />
    <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
    <script src="../Scripts/App/supplier/supplier.js"></script>
</asp:Content>
