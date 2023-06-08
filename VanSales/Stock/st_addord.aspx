<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="st_addord.aspx.cs" Inherits="VanSales.Stock.st_addord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
                <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="أذون الأضـــــافــه" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
    <br />
    <div dir="rtl" style="text-align: center;" >
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_new_Click">
                        <%--<ClientSideEvents Click="function(s, e) {gvitems.AddNewRow();}" />--%>
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_multidel" runat="server" Height="20px" Width="20px" ToolTip="حذف المحدد" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function (s,e){deldata()}">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsx_export" runat="server" Height="20px" Width="20px" ToolTip="Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsx_export_Click">
                    </dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_doc_export" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_doc_export_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdf_export" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdf_export_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print_export" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_print_export_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_expand_collapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvitems.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvitems.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
    <dx:ASPxGridView ID="gv_add_ord" ClientInstanceName="gv_add_ord"  runat="server" AutoGenerateColumns="False" KeyFieldName="transid"  RightToLeft="True" Width="100%"  EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" OnDataBinding="gv_add_ord_DataBinding" OnCustomCallback="gv_add_ord_CustomCallback"  >
                        
                        <SettingsPager AlwaysShowPager="True" PageSize="20">
                            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                        </SettingsPager>
                       <%-- <SettingsEditing Mode="EditForm"></SettingsEditing>--%>
                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" ShowFilterBar="Hidden" />
                        <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" AllowFixedGroups="True" />
                      <%--  <SettingsCommandButton RenderMode="Image">                       
                            <EditButton RenderMode="Image">
                                <Image ToolTip="تعديل" Url="~/Img/Icon/edit.svg" Width="20" Height="20" AlternateText="تعديل" />
                            </EditButton>   
                        </SettingsCommandButton>--%>
                      <%--  <SettingsPopup>
                            <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                <SettingsAdaptivity VerticalAlign="WindowCenter" />
                            </EditForm>
                            <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                        </SettingsPopup>--%>
                        <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                        <SettingsFilterControl ShowAllDataSourceColumns="True">
                        </SettingsFilterControl>
                        <SettingsExport PaperKind="A4" FileName="أذون الاضافه" PaperName="أذن الاضافه" RightToLeft="True">
                            <PageHeader>
                                <Font Bold="True" Size="Medium"></Font>
                            </PageHeader>
                        </SettingsExport>
                        <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                        <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                        <Columns>
                            <%--<dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" > </dx:GridViewCommandColumn>--%>
                            <%-- <dx:GridViewDataHyperLinkColumn FieldName="" ShowInCustomizationForm="True" VisibleIndex="0"  ReadOnly="True" ToolTip="تعديل" >

                                <PropertiesHyperLinkEdit  NavigateUrlFormatString="~\Stock\st_Edit_add_ord.aspx?add_transid={0}" Target="_blank" TextField="transid" ImageHeight="20px" ImageUrl="~/Img/Icon/edit.svg" ImageWidth="20px" Text="تعديل"></PropertiesHyperLinkEdit>
                                <Settings AllowGroup="False" AutoFilterCondition="BeginsWith"> </Settings>
                            </dx:GridViewDataHyperLinkColumn>--%>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>
                            <dx:GridViewDataHyperLinkColumn FieldName="transid" ReadOnly="True" VisibleIndex="1" Caption=" ">
                                <PropertiesHyperLinkEdit  NavigateUrlFormatString="~\Stock\st_Edit_add_ord.aspx?transid={0}" Target="_blank" TextField="transid" ImageUrl="~/Img/Icon/edit.svg" ImageWidth="20px"></PropertiesHyperLinkEdit>
                                <Settings AllowGroup="True" AutoFilterCondition="BeginsWith" AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowCellMerge="False" AllowDragDrop="False" AllowEllipsisInText="False" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" AllowSort="False" ShowEditorInBatchEditMode="False" ShowFilterRowMenu="False" ShowFilterRowMenuLikeItem="False" ShowInFilterControl="False" SortMode="DisplayText"></Settings>
                                <EditFormSettings Visible="False"></EditFormSettings>
                                <CellStyle HorizontalAlign="Center"></CellStyle>
                            </dx:GridViewDataHyperLinkColumn>
                            <dx:GridViewDataTextColumn FieldName="transid" ReadOnly="True" VisibleIndex="2" Visible="false">
                                
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="transno" VisibleIndex="3" Caption="رقم الأذن">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="trandocno" VisibleIndex="4" Caption="الرقم اليدوى">
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataDateColumn FieldName="trandate" VisibleIndex="5" Caption="التاريخ">
                                <Settings AllowHeaderFilter="True" />
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="6" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="7" Caption="الفرع">
                            </dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn FieldName="transtype" VisibleIndex="8" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="transtypename" VisibleIndex="9" Caption="نوع الأذن">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ccid" VisibleIndex="10" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="11" Caption="مركز التكلفه">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                   <%--    <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>--%>
                      <%--  <EditFormLayoutProperties>
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                        </EditFormLayoutProperties>--%>
                     <%--   <SettingsPopup>
                         <EditForm Width="730">
                                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                            </EditForm>
                        </SettingsPopup>--%>
                        <Styles>
                            <Footer Font-Bold="True">
                            </Footer>
                            <GroupFooter Font-Bold="False">
                            </GroupFooter>
                            <GroupPanel HorizontalAlign="Right"></GroupPanel>
                            <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                        </Styles>
                    </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="gv_add_ord_Exporter"  runat="server" FileName="أذون الاضافه" GridViewID="gv_add_ord" PaperKind="A4" PaperName="أذون الاضافه" RightToLeft="True" Landscape="True" >
        <PageHeader Center="أذون الاضافه">
        </PageHeader>
        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
        </PageFooter>
    </dx:ASPxGridViewExporter>
   
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="st_transaction_sel" SelectCommandType="StoredProcedure"></asp:SqlDataSource>--%>
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
                    gv_add_ord.PerformCallback(null);
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
  </script>
</asp:Content>
