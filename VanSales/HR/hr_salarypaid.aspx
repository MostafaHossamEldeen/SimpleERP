<%@ Page Title="صرف الرواتب" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_salarypaid.aspx.cs" Inherits="VanSales.HR.hr_salarypaid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/HR/hr_salarypaid.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="صرف الرواتب" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" Height="20px" RenderMode="Secondary" Width="20px" ToolTip="حفظ" OnClick="btn_Save_Click">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/HR/salarypaid_del', 'HF_spaidid') }" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <button type="button" id="master" data-name="master" data-tablename="hr_salarypaid_sel_pop" data-displayfields="spaidno,monyrname,vochrid,branchname"
                    data-displayfieldshidden="empid,vdays,vfromd,vtodate,vnotes,vnameid,vnametype,vapp,vuser,vappuser,vnature,vid"
                    data-displayfieldscaption="رقم الاعداد,التاريخ,الشهر/السنة,رقم القيد,الفرع"
                    data-bindcontrols="HF_spaidid;txt_spaidno;cmb_monyrid;cmb_branchid;txt_userpaid;txt_vchrid;hf_postacc;txt_spaidnotes"
                    data-bindfields="spaidid;spaidno;monyrid;branchid;userpaid;vchrid;postacc;spaidnotes"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="spaidid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" runat="server" ClientInstanceName="btn_postacc" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل حسابات">
                    <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                </dx:ASPxButton>

                <br />
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="رقم الصرف">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_spaidno" runat="server" ClientInstanceName="txt_spaidno" Font-Bold="True" Text="تلقائى">
                                            <ClientSideEvents KeyDown="function(s,e){preventwrite1(s,e);}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الشهر / السنة">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_monyrid" runat="server" ClientInstanceName="cmb_monyrid">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الفرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchid" ClientInstanceName="cmb_branchid" runat="server" Theme="MaterialCompact" Font-Bold="True" NullText="الكل">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="المستخدم">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_userpaid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_userpaid">
                                            <ClientSideEvents Init="function(s, e) {
	txt_userpaid.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="رقم القيد">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxHyperLink ID="txt_vchrid" runat="server" ClientInstanceName="txt_vchrid" Font-Bold="True" ForeColor="#009933" Font-Size="Medium">
                                        </dx:ASPxHyperLink>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxLabel ID="lbl_postacc" runat="server" ClientInstanceName="lbl_postacc" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="التاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_spaiddate" runat="server" RightToLeft="True" ClientInstanceName="txt_spaiddate">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الملاحظات" ColumnSpan="2">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_spaidnotes" runat="server" ClientInstanceName="txt_sprepnotes" Theme="MaterialCompact" Width="100%">
                                        </dx:ASPxMemo>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <asp:Panel ID="PEmpIns" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none;" ClientIDMode="Static">
                <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="box" Caption="إضافة الموظفين" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="الجنسية">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_nationid" ClientInstanceName="cmb_nationid" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True" ClearButton-DisplayMode="Always" NullText="الكل">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الوظيفة">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_jobid" ClientInstanceName="cmb_jobid" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True" ClearButton-DisplayMode="Always" NullText="الكل">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="مركز التكلفة">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_ccid" ClientInstanceName="cmb_ccid" runat="server" Theme="MaterialCompact" Font-Bold="True" ClearButton-DisplayMode="Always" NullText="الكل">
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton ID="btn_clear" runat="server" ClientInstanceName="btn_clear" AutoPostBack="false" Height="20px" RenderMode="Secondary" Width="20px" ToolTip="تفريغ">
                                                <ClientSideEvents Click="function(s, e) {
	clearfilter()
}"></ClientSideEvents>

                                                <Image Height="20px" Url="~/Img/Icon/eraser-clear.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الموظف">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_empid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_empid" AutoPostBack="false">
                                                <ClientSideEvents ValueChanged="function(s, e) {
	setEmpData(s, e)}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <button type="button" id="puop_emp" data-name="emp" onclick="createPopUp($(this))" data-tablename="hr_employees_sel_salarypaid_search" data-paramaternames="cmb_monyrid" data-displayfields="empcode,empname,empmob,embemail"
                                                data-displayfieldshidden="empidno,empid" data-displayfieldscaption="كود الموظف,اسم الموظف,رقم الجوال,البريد الإلكتروني" data-bindcontrols="txt_empid;txt_empname;hf_empid"
                                                data-bindfields="empcode;empname;empid" data-pkfield="empid" data-apiurl="/VanSalesService/Hr/EmpPaid" class="btn btn-sm btnsearchpopup">
                                            </button>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                    <ParentContainerStyle>
                                        <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                    </ParentContainerStyle>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="اسم الموظف">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_empname" ClientInstanceName="txt_empname" runat="server" Theme="MaterialCompact">
                                                <ClientSideEvents Init="function(s, e) {
	txt_empname.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>
                                            <asp:HiddenField ID="hf_empid" ClientIDMode="Static" runat="server" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton ID="btn_userins" UseSubmitBehavior="false" runat="server" ClientInstanceName="btn_userins" Height="20px" RenderMode="Secondary" Width="20px" ToolTip="إضافة الموظف" OnClick="btn_userins_Click">
                                                <Image Height="20px" Url="~/img/icon/add-user.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
            </asp:Panel>
            <br />
            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none;" ClientIDMode="Static">
                    <dx:ASPxGridView ID="gvhr_salarydtls" ClientInstanceName="gvhr_salarydtls" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="salid" OnDataBinding="gvhr_salarydtls_DataBinding" OnRowDeleting="gvhr_salarydtls_RowDeleting" OnCustomCallback="gvhr_salarydtls_CustomCallback">
                        <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                        <SettingsPager AlwaysShowPager="True" PageSize="15">
                            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                        </SettingsPager>
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <Settings ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterRow="True" />
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
                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False"></SettingsDataSecurity>
                        <SettingsPopup>
                            <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                <SettingsAdaptivity VerticalAlign="WindowCenter" />
                            </EditForm>
                            <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                        </SettingsPopup>
                        <SettingsSearchPanel ShowClearButton="True" />
                        <SettingsExport PaperKind="A4" FileName="hr_masterfiles" PaperName="customers" RightToLeft="True">
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
                            <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0"></dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="empcode" VisibleIndex="4" Caption="كود الموظف" HeaderStyle-Font-Bold="true">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="empname" VisibleIndex="5" Caption="إسم الموظف" HeaderStyle-Font-Bold="true">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="basicsarlary" VisibleIndex="6" Caption="الاساسى" HeaderStyle-Font-Bold="true"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="hallowance" VisibleIndex="7" Caption="بدل السكن" HeaderStyle-ForeColor="Green"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="oallowance" VisibleIndex="8" Caption="البدلات لاخرى" HeaderStyle-ForeColor="Green"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="bouns" VisibleIndex="9" Caption="المكافئات" HeaderStyle-ForeColor="Green"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="additional" VisibleIndex="10" Caption="الاضافى" HeaderStyle-ForeColor="Green"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vbouns" VisibleIndex="11" Caption="متغير اضافى" HeaderStyle-ForeColor="Green"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="insureded" VisibleIndex="12" Caption="خصم التامين" HeaderStyle-ForeColor="Red"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="abs" VisibleIndex="13" Caption="الغياب" HeaderStyle-ForeColor="Red"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="delay" VisibleIndex="14" Caption="التاخير" HeaderStyle-ForeColor="Red"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="penalty" VisibleIndex="15" Caption="الجزءات" HeaderStyle-ForeColor="Red"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="loan" VisibleIndex="16" Caption="السلف" HeaderStyle-ForeColor="Red"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vded" VisibleIndex="17" Caption="متغير" HeaderStyle-ForeColor="Red"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="sumbenfit" VisibleIndex="18" Caption="اجمالى الاستحقاقات" HeaderStyle-ForeColor="Green" HeaderStyle-Font-Bold="true"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="sumdeduction" VisibleIndex="19" Caption="اجمالى الاستقطاعات" HeaderStyle-ForeColor="Red" HeaderStyle-Font-Bold="true"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="netsalary" VisibleIndex="20" Caption="الصافى" HeaderStyle-Font-Bold="true">
                                <PropertiesTextEdit ClientInstanceName="monyrname"></PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsPopup>
                            <EditForm Width="730">
                                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                            </EditForm>
                        </SettingsPopup>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="monyrname" ShowInColumn="monyrname" ShowInGroupFooterColumn="monyrname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                        </TotalSummary>
                        <GroupSummary>
                            <dx:ASPxSummaryItem FieldName="monyrname" SummaryType="Count" />
                        </GroupSummary>
                        <Styles>
                            <Header Wrap="True">
                            </Header>
                        </Styles>
                    </dx:ASPxGridView>
                </asp:Panel>
            </div>
            <asp:HiddenField ID="HF_spaidid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hf_postacc" ClientIDMode="Static" runat="server" />
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
