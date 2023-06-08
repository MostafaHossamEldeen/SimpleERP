<%@ Page Title="تقرير الأجازات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_vactions_report.aspx.cs" Inherits="VanSales.HR.hr_vactions_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير الأجازات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Review" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Review_Click" RenderMode="Secondary" Width="20px" ToolTip="استعراض">
                    <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Width="20px" ToolTip="طباعه">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_clear_Click" RenderMode="Secondary" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gv_vactions.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gv_vactions.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
<dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="Box" Caption="">
                        <Items>

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
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <button type="button" id="puop_emp" data-name="emp" onclick="createPopUp($(this))" data-tablename="hr_employees_sel_salaryprep_search" data-paramaternames="cmb_monyrid" data-displayfields="empcode,empname,empmob,embemail"
                                                data-displayfieldshidden="empidno,empid" data-displayfieldscaption="كود الموظف,اسم الموظف" data-bindcontrols="txt_empid;txt_empname;hf_empid"
                                                data-bindfields="empcode;empname;empid" data-pkfield="empid" data-apiurl="/VanSalesService/Hr/EmpPrep"" class="btn btn-sm btnsearchpopup">
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
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="من تاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_datefrom" ClientInstanceName="txt_datefrom" runat="server" NullText="من تاريخ">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="حتى تاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_dateto" runat="server" ClientInstanceName="txt_dateto" RightToLeft="True" NullText="حتى تاريخ">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="نوع الأجازة">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_vnameid" runat="server" ClientInstanceName="cmb_vnameid" RightToLeft="True" NullText="نوع الأجازة">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <dx:ASPxGridView ID="gv_vactions" ClientInstanceName="gv_vactions" SettingsText-Title="تقرير الأجازات" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gv_vactions_CustomSummaryCalculate" OnDataBinding="gv_vactions_DataBinding" Width="100%" RightToLeft="True" CssClass="grid" OnHtmlRowPrepared="gv_vactions_HtmlRowPrepared">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                </Columns>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="empcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="empcode"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vadd" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="vadd"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vreq" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="vreq"></dx:ASPxSummaryItem>
                </GroupSummary>

                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>
                <SettingsBehavior AllowEllipsisInText="true" />
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                </EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="empcode" VisibleIndex="0" Caption="كود الموظف">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="empname" VisibleIndex="1" Caption="إسم الموظف" GroupIndex="0" SortIndex="0" ReadOnly="True" SortOrder="Ascending"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vno" VisibleIndex="2" Caption="رقم الأجازة"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="vdate" VisibleIndex="3" Caption="التاريخ"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="vnaturenmae" VisibleIndex="4" Caption="طبيعة الأجازة"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vname" VisibleIndex="5" Caption="نوع الأجازة"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vadd" VisibleIndex="6" Caption="الرصيد"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vreq" VisibleIndex="7" Caption="عدد الأيام"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="vfromd" VisibleIndex="8" Caption="من تاريخ"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn FieldName="vtodate" VisibleIndex="9" Caption="حتى تاريخ"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="vnotes" VisibleIndex="10" Caption="ملاحظات"></dx:GridViewDataTextColumn>
                </Columns>
                <SettingsPopup>
                    <EditForm Width="730">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                    </EditForm>
                </SettingsPopup>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="empcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="empcode"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vadd" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="vadd"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vreq" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="vreq"></dx:ASPxSummaryItem>
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvempsalaryvarExporter" runat="server" FileName="الأجازات" GridViewID="gv_vactions" PaperKind="A4" PaperName="الأجازات" RightToLeft="True" Landscape="True">
                <PageHeader Center="الأجازات" Font-Bold="true">
                </PageHeader>
                <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                </PageFooter>


            </dx:ASPxGridViewExporter>

        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <%--<asp:PostBackTrigger ControlID="btn_print" />--%>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>