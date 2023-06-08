<%@ Page Title="الفروع" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Branch.aspx.cs" Inherits="VanSales.Branch.Branch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="dx-justification" style="width: 100%">
        <tr>
            <td style="background-color: #dcdcdc;" class="text-center">
                <%--<asp:Label ID="lbltitle" runat="server" Font-Bold="True" Font-Size="25pt" ForeColor="#35B86B" Text="الفروع"></asp:Label>--%>
                  <dx:ASPxLabel ID="lbltitle" runat="server" Text="الفروع" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <br />
                <div class="col-md-12" dir="rtl">

                     <dx:ASPxButton  UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {gvbranch.AddNewRow();}" />
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف المحدد" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function (s,e){deldata()}">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnxlsxexport" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnxlsxexport_Click">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtndocexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtndocexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnpdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnpdfexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnprintexport" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="ASPxbtnprintexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvbranch.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvbranch.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="gvbranch" ClientInstanceName="gvbranch" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" OnCustomCallback="gvbranch_CustomCallback" KeyFieldName="branchid" OnDataBinding="gvbranch_DataBinding" OnRowInserting="gvbranch_RowInserting" OnRowUpdating="gvbranch_RowUpdating">
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
                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" SelectAllCheckboxMode="AllPages" ShowSelectCheckbox="True"></dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="branchid" ReadOnly="True" VisibleIndex="1" Caption="كود الفرع" PropertiesTextEdit-NullDisplayText="تلقائي" PropertiesTextEdit-NullText="تلقائي">
                            <EditFormSettings Visible="True"></EditFormSettings>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="2" Caption="إسم الفرع">
                            <PropertiesTextEdit>
                                <ValidationSettings ErrorText="" Display="Dynamic">
                                    <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                </ValidationSettings>
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="branchtel" VisibleIndex="3" Caption="رقم التليفون">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="branchadd" VisibleIndex="4" Caption="العنوان">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="branchnotes" VisibleIndex="5" Caption="ملاحظات">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <SettingsPopup>
            <EditForm Width="730">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
            </EditForm>
        </SettingsPopup>
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="branchname" ShowInColumn="branchname" ShowInGroupFooterColumn="branchname" SummaryType="Count" DisplayFormat="العدد : {0}" />
                    </TotalSummary>
                    <GroupSummary>
                        <dx:ASPxSummaryItem FieldName="branchname" SummaryType="Count" />
                    </GroupSummary>
                    <Styles>
                          <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        <GroupPanel HorizontalAlign="Right" Font-Bold="True" >
                        </GroupPanel>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                    </Styles>
                </dx:ASPxGridView>
            </td>
        </tr>
        </table>
    <dx:ASPxGridViewExporter ID="gvbranchExporter" runat="server" FileName="الفروع" GridViewID="gvbranch" PaperKind="A4" PaperName="branch" RightToLeft="True" >
        <PageHeader Center="الفروع">
        </PageHeader>
        <PageFooter Center="[Pages #]" Left="[User Name]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
    <asp:HiddenField ID="hferror" ClientIDMode="Static" runat="server" />
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
                    gvbranch.PerformCallback(null);
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
