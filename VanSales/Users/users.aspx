<%@ Page Title="المستخدمين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="VanSales.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td class="text-center" style="background-color: #dcdcdc">
                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="إعدادات الـمـسـتـخـدمـيـن" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxPageControl ID="ASPxTabControl" Width="100%" runat="server" CssClass="dxtcFixed" ActiveTabIndex="0" RightToLeft="True" Theme="MaterialCompact">
                            <TabPages>
                                <dx:TabPage Text="المستخدمين">
                                    <ActiveTabStyle  Font-Bold="True" ForeColor="#45B96B">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </ActiveTabStyle>
                                    <TabStyle Font-Bold="True">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </TabStyle>
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl1" runat="server">
                                            <table class="w-100" style="width: 100%;">
                                                <tr>
                                                    <td>
                                                        <table class="dx-justification" style="width: 100%">
                                                            <tr>

                                                                <td style="text-align: center">
                                                                    <div class="col-md-12" dir="rtl">
                                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save" runat="server" OnClick="btnsave_Click" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" CausesValidation="true" ValidationGroup="User">
                                                                        </dx:ASPxButton> 
                                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexportgvusers" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnxlsxexportgvusers_Click">
                                                                            <Image Height="20px" Width="20px" Url="~/Img/Icon/excel.svg"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton  UseSubmitBehavior="false" ID="ASPxbtndocexportgvusers" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtndocexportgvusers_Click">
                                                                            <Image Height="20px" Width="20px" Url="~/Img/Icon/word.svg"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexportgvusers" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnpdfexportgvusers_Click">
                                                                            <Image Height="20px" Width="20px" Url="~/Img/Icon/pdf.svg"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexportgvusers" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnprintexportgvusers_Click">
                                                                            <Image Height="20px" Width="20px" Url="~/Img/Icon/print.svg"></Image>
                                                                        </dx:ASPxButton>
                                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapsegvusers" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnexpandcollapsegvusers_Click">
                                                                            <Image Height="20px" Width="20px" Url="~/Img/Icon/expand.svg"></Image>
                                                                        </dx:ASPxButton>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <br />
                                                                    <table class="w-100">
                                                                        <tr>
                                                                            <td class="text-center">
                                                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="إسم المستخدم" Theme="MaterialCompact"></dx:ASPxLabel>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" Text="*" ForeColor="Red" ErrorMessage="برجاء إدخال إسم المستخدم" SetFocusOnError="True" Display="Dynamic" ValidationGroup="User"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxTextBox ID="txtusername" runat="server" Theme="MaterialCompact" NullText="إسم المستخدم"></dx:ASPxTextBox>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="كلمة المرور" Theme="MaterialCompact">
                                                                                </dx:ASPxLabel>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpassword" Display="Dynamic" ErrorMessage="برجاء إدخال كلمة المرور" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="User"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxTextBox ID="txtpassword" runat="server" NullText="كلمة المرور" Password="True" Theme="MaterialCompact">
                                                                                </dx:ASPxTextBox>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="تأكيد كلمة المرور" Theme="MaterialCompact">
                                                                                </dx:ASPxLabel>
                                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword" Display="Dynamic" ErrorMessage="كلمة المرور غير متطابقة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="User"></asp:CompareValidator>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxTextBox ID="txtconfirmpassword" runat="server" NullText="تأكيد كلمة المرور" Password="True" Theme="MaterialCompact">
                                                                                </dx:ASPxTextBox>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="text-center">
                                                                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="البريد الإلكتروني" Theme="MaterialCompact">
                                                                                </dx:ASPxLabel>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxTextBox ID="txtmail" runat="server" NullText="البريد الإلكتروني" Theme="MaterialCompact">
                                                                                </dx:ASPxTextBox>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="التليفون" Theme="MaterialCompact">
                                                                                </dx:ASPxLabel>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxTextBox ID="txtphone" runat="server" NullText="التليفون" Theme="MaterialCompact">
                                                                                </dx:ASPxTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:ValidationSummary ID="ValidationSummary" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="User" />
                                                                                <br />
                                                                                <dx:ASPxLabel ID="lblmsg" runat="server" Theme="MaterialCompact">
                                                                                </dx:ASPxLabel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <div class="text-right" dir="rtl">
                                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnunlockgvusers" runat="server" AutoPostBack="False" CausesValidation="False" Height="20px" OnClick="ASPxbtnunlockgvusers_Click" RenderMode="Secondary" ToolTip="تفعيل" Width="20px">
                                                                <Image Height="20px" Url="~/Img/Icon/lock.svg" Width="20px">
                                                                </Image>
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnlockgvusers" runat="server" AutoPostBack="False" CausesValidation="False" Height="20px" OnClick="ASPxbtnlockgvusers_Click" RenderMode="Secondary" ToolTip="إيقاف" Width="20px">
                                                                <Image Height="20px" Url="~/Img/Icon/unlock.svg" Width="20px">
                                                                </Image>
                                                            </dx:ASPxButton>
                                                        </div>
                                                        <dx:ASPxGridView ID="gvusers" ClientInstanceName="gvusers" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="UserName">
                                                            <TotalSummary>
                                                                <dx:ASPxSummaryItem FieldName="UserName" ShowInColumn="UserName" ShowInGroupFooterColumn="UserName" SummaryType="Count" DisplayFormat="العدد : {0}" />
                                                            </TotalSummary>
                                                            <GroupSummary>
                                                                <dx:ASPxSummaryItem FieldName="UserName" SummaryType="Count" />
                                                            </GroupSummary>
                                                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                                                            <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                                                            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
                                                            <SettingsPopup>
                                                                <EditForm Width="730">
                                                                    <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                                                                </EditForm>
                                                            </SettingsPopup>
                                                            <SettingsPager AlwaysShowPager="True" PageSize="20">
                                                                <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                                                            </SettingsPager>
                                                            <SettingsEditing Mode="PopupEditForm">
                                                            </SettingsEditing>
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
                                                            <SettingsPopup>
                                                                <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                                                    <SettingsAdaptivity VerticalAlign="WindowCenter" />
                                                                </EditForm>
                                                                <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            </SettingsPopup>
                                                            <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                                                            <SettingsFilterControl ShowAllDataSourceColumns="True">
                                                            </SettingsFilterControl>
                                                            <SettingsExport PaperKind="A4" FileName="Users" PaperName="Users" RightToLeft="True">
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
                                                                <dx:GridViewCommandColumn SelectAllCheckboxMode="AllPages" ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0">
                                                                </dx:GridViewCommandColumn>
                                                                <dx:GridViewDataTextColumn FieldName="Email" ShowInCustomizationForm="True" VisibleIndex="2" Caption="البريد الإلكتروني">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="UserName" ShowInCustomizationForm="True" VisibleIndex="1" Caption="إسم المستخدم" UnboundType="String"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="PhoneNumber" ShowInCustomizationForm="True" VisibleIndex="3" Caption="رقم التليفون">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="تاريخ الإنشاء" FieldName="createdate" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                    <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="yyyy/MM/dd">
                                                                    </PropertiesTextEdit>
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="آخر تسجيل دخول" FieldName="lastlogin" ShowInCustomizationForm="True" VisibleIndex="5">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataCheckColumn Caption="الإيقاف" FieldName="lockaccount" ShowInCustomizationForm="True" VisibleIndex="6">
                                                                    <PropertiesCheckEdit DisplayTextChecked="موقوف" DisplayTextGrayed="فعال" DisplayTextUnchecked="فعال" DisplayTextUndefined="فعال" ValueGrayed="False">
                                                                    </PropertiesCheckEdit>
                                                                </dx:GridViewDataCheckColumn>
                                                            </Columns>
                                                            <Styles>
                                                                <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                                                                <GroupFooter Font-Bold="false">
                                                                </GroupFooter>
                                                                <GroupPanel HorizontalAlign="Right" Font-Bold="true"></GroupPanel>
                                                                <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                                                            </Styles>
                                                        </dx:ASPxGridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="خصائص المستخدم">
                                    <ActiveTabStyle Font-Bold="True" ForeColor="#45B96B">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </ActiveTabStyle>
                                    <TabStyle Font-Bold="True">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </TabStyle>
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl4" runat="server">
                                            <div class="row form-group">
                                                <dx:ASPxLabel CssClass="col-md-2 text-right  col-form-label" ID="ASPxLabel5" runat="server" Text="إسم المستخدم" Theme="MaterialCompact">
                                                </dx:ASPxLabel>
                                                <dx:ASPxComboBox ID="cmbuserproperty_userid" CssClass="col-md-3" ClientInstanceName="cmbuserproperty_userid" ClientSideEvents-ValueChanged="function(s,e){setuserproperty(s,e)}" runat="server" Font-Bold="True" MaxLength="50" NullText="إسم المستخدم" RightToLeft="True" TextField="Username" Theme="MaterialCompact" ValueField="Id">
                                                </dx:ASPxComboBox>
                                            </div>
                                            <div class="row form-group">
                                                <dx:ASPxLabel ID="ASPxLabel105" runat="server" CssClass="col-md-2 text-right  col-form-label" Text="الفروع" Theme="MaterialCompact">
                                                </dx:ASPxLabel>
                                                <dx:ASPxTokenBox ID="tokentbox_userbranchs" ClientInstanceName="tokentbox_userbranchs" CssClass="col-md-3 " AllowCustomTokens="false" runat="server" Width="100%">
                                                </dx:ASPxTokenBox>
                                            </div>
                                            <div class="row form-group">
                                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" CssClass="col-md-2 text-right  col-form-label" Text="مراكز التكلفة" Theme="MaterialCompact">
                                                </dx:ASPxLabel>
                                                <dx:ASPxTokenBox ID="tokentbox_usercc" ClientInstanceName="tokentbox_usercc" CssClass="col-md-3" AllowCustomTokens="false" runat="server" Width="100%">
                                                </dx:ASPxTokenBox>
                                            </div>
                                            <div class="row form-group">
                                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" CssClass="col-md-2 text-right  col-form-label" Text="نسبة الخصم المسموحة على الأصناف" Theme="MaterialCompact">
                                                </dx:ASPxLabel>
                                                <dx:ASPxTextBox ID="txt_udiscperitem" ClientInstanceName="txt_udiscperitem" runat="server" CssClass="col-md-3" MaxLength="5">
                                                </dx:ASPxTextBox>
                                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" CssClass="col-md-2 text-right  col-form-label" Text="%" Font-Size="Large" Theme="MaterialCompact" Font-Bold="true"></dx:ASPxLabel>
                                            </div>
                                            <div class="row form-group">
                                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" CssClass="col-md-2 text-right  col-form-label" Text="السنة المالية" Theme="MaterialCompact">
                                                </dx:ASPxLabel>
                                                <dx:ASPxComboBox ID="cmb_uyearid" CssClass="col-md-3" ClientInstanceName="cmb_uyearid" runat="server" NullText="السنة المالية">
                                                </dx:ASPxComboBox>
                                            </div>
                                            <div class="row form-group">
                                                <dx:ASPxLabel ID="ASPxLabel13" runat="server" CssClass="col-md-2 text-right  col-form-label" Text="الموظف" Theme="MaterialCompact">
                                                </dx:ASPxLabel>
                                                <dx:ASPxTextBox ID="txt_empid" ClientInstanceName="txt_empid" runat="server" CssClass="col-md-3"></dx:ASPxTextBox>
                                                <button type="button" id="PopUpempid" title="بحث" data-name="empid" data-tablename="hr_employees_sel_pop_userprep" data-displayfields="empcode,empname" data-displayfieldscaption="كود الموظف,إسم الموظف"
                                                    data-displayfieldshidden="empid" data-bindcontrols="hf_empid;txt_empid" data-bindfields="empid;namedisplay"
                                                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="empid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                                                </button>
                                                <asp:HiddenField ID="hf_empid" runat="server" ClientIDMode="Static"   />
                                            </div>
                                            <div class="row form-group">
                                                <dx:ASPxLabel ID="ASPxLabel14" runat="server" CssClass="col-md-2 text-right  col-form-label" Text="مستوى الصلاحيات" Theme="MaterialCompact">
                                                </dx:ASPxLabel>
                                                <dx:ASPxComboBox ID="cmb_rlevel" CssClass="col-md-3" ClientInstanceName="cmb_rlevel" runat="server" NullText="مستوى الصلاحيات">
                                                    <ClearButton DisplayMode="Always"></ClearButton>
                                                </dx:ASPxComboBox>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btnsave_cmb_rlevel" runat="server" CausesValidation="false" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnsave_cmb_rlevel_Click">
                                                    <ClientSideEvents Click="function(s, e) {validateuersprepcmb_rlevel(s, e);}" />
                                                </dx:ASPxButton>
                                            </div>
                                            <div>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btnsave_userproperty" runat="server" OnClick="btnsave_userproperty_Click" CssClass="col-md-3" CausesValidation="true" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ValidationGroup="userprep">
                                                    <ClientSideEvents Click="function(s, e) {validateuersprep(s, e);}" />
                                                </dx:ASPxButton>
                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" DisplayMode="List" CssClass="col-md-3" Font-Bold="True" ForeColor="Red" ValidationGroup="userprep" />
                                            </div>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="الصلاحيات">
                                    <ActiveTabStyle Font-Bold="True" ForeColor="#45B96B">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </ActiveTabStyle>
                                    <TabStyle Font-Bold="True">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </TabStyle>
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl2" runat="server">
                                            <table class="dx-justification" style="width: 100%" allowellipsisintext="False">
                                                <tr>
                                                    <td style="text-align: center" dir="rtl">
                                                        <div class="col-md-12">
                                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexportgvpermissions" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnxlsxexportgvpermissions_Click">
                                                                <Image Height="20px" Width="20px" Url="~/Img/Icon/excel.svg"></Image>
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtndocexportgvpermissions" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtndocexportgvpermissions_Click">
                                                                <Image Height="20px" Width="20px" Url="~/Img/Icon/word.svg"></Image>
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexportgvpermissions" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnpdfexportgvpermissions_Click">
                                                                <Image Height="20px" Width="20px" Url="~/Img/Icon/pdf.svg"></Image>
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexportgvpermissions" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnprintexportgvpermissions_Click">
                                                                <Image Height="20px" Width="20px" Url="~/Img/Icon/print.svg"></Image>
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapsegvpermissions" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnexpandcollapsegvpermissions_Click">
                                                                <Image Height="20px" Width="20px" Url="~/Img/Icon/expand.svg"></Image>
                                                            </dx:ASPxButton>
                                                            <dx:ASPxButton ID="btnuser_prep_ins_all" runat="server" Height="20px" Width="20px" ToolTip="إضافة كل الصلاحيات" Image-Url="~/Img/Icon/select-all.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btnuser_prep_ins_all_Click"></dx:ASPxButton>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <br />
                                                        <table class="w-100" style="width: 100%;">
                                                            <tr>
                                                                <td>
                                                                    <dx:ASPxComboBox ID="ASPxuserspermissions" CssClass="col-md-5" OnValueChanged="ASPxuserspermissions_ValueChanged" runat="server" Font-Bold="True" MaxLength="50" NullText="إسم المستخدم" RightToLeft="True" TextField="Username" Theme="MaterialCompact" ValueField="Username" Width="100%" AutoPostBack="True">
                                                                    </dx:ASPxComboBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger col-md-3" ControlToValidate="ASPxuserspermissions" Text="برجاء إختيار المستخدم" ForeColor="Red" ErrorMessage="برجاء إختيار المستخدم" SetFocusOnError="True" Display="Dynamic" ValidationGroup="permissions"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>&nbsp;</td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="permissions" />
                                                                    <br />
                                                                    <dx:ASPxLabel ID="lblmsg2" runat="server" Theme="MaterialCompact">
                                                                    </dx:ASPxLabel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <dx:ASPxGridView ID="gvpermissions"  OnDataBinding="gvpermissions_DataBinding" OnBatchUpdate="gvpermissions_BatchUpdate" KeyFieldName="pageid" ClientInstanceName="gvpermissions" runat="server"  AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
                                                            <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" BatchEditStartEditing="function(s,e){batchEditStart(s,e)}"/>
                                                            <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                                                            <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                                                            <%--<SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>--%>
                                                            <SettingsPager AlwaysShowPager="True" PageSize="20">
                                                                <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                                                            </SettingsPager>
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
                                                                <dx:GridViewDataTextColumn  FieldName="pageid" ReadOnly="True" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="pagenamer" ReadOnly="True" VisibleIndex="1" Caption="الشاشة"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="pmodid" ReadOnly="True" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="pmodname" ReadOnly="True" VisibleIndex="3" Caption="التابعية"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataCheckColumn FieldName="allow" VisibleIndex="4" Caption="فتح" >
                                                                    
                                                                    <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
                                                                </dx:GridViewDataCheckColumn>
                                                                  <dx:GridViewDataTextColumn FieldName="hasnew" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="hassave" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="hasdelete" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="hasopen" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="haspostacc" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
                                                                 <dx:GridViewDataTextColumn FieldName="haspoststock" Width="0" ReadOnly="true" Caption="new"></dx:GridViewDataTextColumn>
                                                                  <dx:GridViewDataCheckColumn FieldName="addnew" VisibleIndex="4" Caption="جديد" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
                                                                    <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
                                                                </dx:GridViewDataCheckColumn>
                                                                  <dx:GridViewDataCheckColumn FieldName="savedata" VisibleIndex="4" Caption="حفظ" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
                                                                    <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
                                                                </dx:GridViewDataCheckColumn>
                                                                  <dx:GridViewDataCheckColumn FieldName="deletedata" VisibleIndex="4" Caption="حذف" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
                                                                    <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
                                                                </dx:GridViewDataCheckColumn>
                                                                  <dx:GridViewDataCheckColumn FieldName="poststock" VisibleIndex="4" Caption="ترحيل مستودع" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
                                                                    <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
                                                                </dx:GridViewDataCheckColumn>
                                                                  <dx:GridViewDataCheckColumn FieldName="postacc" VisibleIndex="4" Caption="ترحيل حسابات" PropertiesCheckEdit-ValueType="System.Boolean">
                                                                    
                                                                    <PropertiesCheckEdit ValueGrayed="False" DisplayTextUndefined="Unchecked" DisplayTextGrayed="Unchecked"></PropertiesCheckEdit>
                                                                </dx:GridViewDataCheckColumn>

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
                                                    </td>
                                                </tr>
                                            </table>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                                <dx:TabPage Text="تغيير كلمة المرور">
                                    <ActiveTabStyle Font-Bold="True" ForeColor="#45B96B">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </ActiveTabStyle>
                                    <TabStyle Font-Bold="True">
                                        <HoverStyle BackColor="#E6E6E6">
                                        </HoverStyle>
                                    </TabStyle>
                                    <ContentCollection>
                                        <dx:ContentControl ID="ContentControl3" runat="server">
                                            <table class="w-100" style="width: 100%;">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="إسم المستخدم" Theme="MaterialCompact">
                                                        </dx:ASPxLabel>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ASPxusersresetpass" Text="*" ForeColor="Red" ErrorMessage="برجاء إختيار المستخدم" SetFocusOnError="True" Display="Dynamic" ValidationGroup="resetpass"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <dx:ASPxComboBox ID="ASPxusersresetpass" runat="server" Font-Bold="True" MaxLength="50" NullText="إسم المستخدم" RightToLeft="True" TextField="Username" Theme="MaterialCompact" ValueField="Id">
                                                        </dx:ASPxComboBox>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="كلمة المرور" Theme="MaterialCompact">
                                                        </dx:ASPxLabel>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtresetpassword" Display="Dynamic" ErrorMessage="برجاء إدخال كلمة المرور" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="resetpass"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <dx:ASPxTextBox ID="txtresetpassword" runat="server" NullText="كلمة المرور" Password="True" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="تأكيد كلمة المرور" Theme="MaterialCompact">
                                                        </dx:ASPxLabel>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtresetpassword" ControlToValidate="txtresetconfirmpassword" Display="Dynamic" ErrorMessage="كلمة المرور غير متطابقة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="resetpass"></asp:CompareValidator>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <dx:ASPxTextBox ID="txtresetconfirmpassword" runat="server" NullText="تأكيد كلمة المرور" Password="True" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="btnresetpass" runat="server" OnClick="btnresetpass_Click" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" CausesValidation="true" ValidationGroup="resetpass">
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="resetpass" />
                                                        <br />
                                                        <dx:ASPxLabel ID="lblmsg3" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxLabel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:TabPage>
                            </TabPages>
                        </dx:ASPxPageControl>
                    </td>
                </tr>
            </table>
            <dx:ASPxGridViewExporter ID="gvusersExporter" runat="server" FileName="المستخدمين" GridViewID="gvusers" PaperKind="A4" PaperName="Users"
                RightToLeft="True" Landscape="True">
                <PageHeader Center="المستخدمين">
                </PageHeader>
                <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
                </PageFooter>
            </dx:ASPxGridViewExporter>
            <dx:ASPxGridViewExporter ID="gvpermissionsExporter" runat="server" FileName="صلاحيات المستخدمين" GridViewID="gvpermissions" PaperKind="A4" PaperName="gvpermissions"
                RightToLeft="True" Landscape="True">
                <PageHeader Center="صلاحيات المستخدمين">
                </PageHeader>
                <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
                </PageFooter>
            </dx:ASPxGridViewExporter>
            <dx:ASPxGridViewExporter ID="gvpropertiesExporter" runat="server" FileName="خصائص صلاحيات المستخدمين" GridViewID="gvproperties" PaperKind="A4" PaperName="gvproperties"
                RightToLeft="True" Landscape="True">
                <PageHeader Center="خصائص صلاحيات المستخدمين">
                </PageHeader>
                <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
                </PageFooter>
            </dx:ASPxGridViewExporter>
            <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../Scripts/sweetalert2.js" type="text/javascript"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/Users/Users.js"></script>
    <link href="../Content/animate.css" rel="stylesheet" />
</asp:Content>