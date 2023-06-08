<%@ Page Title="المـنـدوبـيـن" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sman.aspx.cs" Inherits="VanSales.sman.sman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="dx-justification" style="width: 100%">
        <tr>
            <td style="background-color: #dcdcdc;" class="text-center">
                  <dx:ASPxLabel ID="lbltitle" runat="server" Text="المـنـدوبـيـن" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12" dir="rtl">
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {gvsman.AddNewRow();}" />
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف المحدد" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function (s,e){deldata()}">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexport" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnxlsxexport_Click">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtndocexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtndocexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnpdfexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexport" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnprintexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvsman.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvsman.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvsman" ClientInstanceName="gvsman" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" OnCustomCallback="gvsman_CustomCallback" KeyFieldName="smanid" OnRowInserting="gvsman_RowInserting" OnRowUpdating="gvsman_RowUpdating" OnDataBinding="gvsman_DataBinding">
                    <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}"/>
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
                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0" ShowEditButton="True"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="smanid" ReadOnly="True" VisibleIndex="1"  Caption="كود المندوب" PropertiesTextEdit-NullDisplayText="تلقائي" PropertiesTextEdit-NullText="تلقائي">
                            <EditFormSettings Visible="True"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="smanname" VisibleIndex="2" Caption="إسم المندوب">
                            <PropertiesTextEdit MaxLength="100">
                                <ValidationSettings Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="smanmob" VisibleIndex="3" Caption="رقم الجوال">
                            <PropertiesTextEdit MaxLength="100">
                                <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>

                                <ValidationSettings>
                                    <RequiredField ErrorText=""></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPopup>
            <EditForm Width="730">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
            </EditForm>
        </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="smanname" ShowInColumn="smanname" ShowInGroupFooterColumn="smanname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="smanname" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                        <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        <GroupPanel HorizontalAlign="Right" Font-Bold="true">
                        </GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
                <%--<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:VanSales %>' SelectCommand="s_sman_sel_main" DeleteCommand="s_sman_del" DeleteCommandType="StoredProcedure" InsertCommand="s_sman_ins" InsertCommandType="StoredProcedure" SelectCommandType="StoredProcedure" UpdateCommand="s_sman_upd" UpdateCommandType="StoredProcedure">
                    <DeleteParameters>
                        <asp:Parameter Name="smanid" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="smanname" Type="String"></asp:Parameter>
                        <asp:Parameter Name="smanmob" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="smanid" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="smanname" Type="String"></asp:Parameter>
                        <asp:Parameter Name="smanmob" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>--%>
            </td>
        </tr>
        </table>
    <dx:ASPxGridViewExporter ID="gvsmanExporter" runat="server" FileName="المندوبين" GridViewID="gvsman" PaperKind="A4" PaperName="sman"
        RightToLeft="True" Landscape="True">
        <PageHeader Center="المندوبين">
        </PageHeader>
        <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
    <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
    <script src="sweetalert2.js" type="text/javascript"></script>
    <link href="animate.css" rel="stylesheet" />
    <script type="text/javascript">
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
                    gvsman.PerformCallback(null);
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

        function sweetexception() {
            Swal.fire({
                icon: 'warning',
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
    </script>
</asp:Content>
