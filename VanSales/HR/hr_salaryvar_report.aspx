<%@ Page Title="تقرير متغيرات رواتب الموظفين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_salaryvar_report.aspx.cs" Inherits="VanSales.HR.hr_salaryvar_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/HR/hr_salaryvar_report.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير متغيرات رواتب الموظفين" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Review" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Width="20px" ToolTip="استعراض">
                    <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Width="20px" ToolTip="طباعه">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_addnew_Click" RenderMode="Secondary" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gv_empsalaryvar.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gv_empsalaryvar.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
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

                            <dx:LayoutItem Caption="شهور الرواتب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_monyrid" runat="server" ClientInstanceName="cmb_monyrid" RightToLeft="True" NullText="الشهر / السنة">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>

                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="Box" Caption="اعمده التقرير" Name="checkboxs">
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_empcode" runat="server" OnCheckedChanged="chk_empcode_CheckedChanged" Text="كود الموظف" AutoPostBack="true" Checked="true" ClientInstanceName="chk_empcode" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_empname" runat="server" Text="إسم الموظف" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_empname" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_svno" runat="server" Text="الرقم" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_svno" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_svdate" runat="server" Text="التاريخ" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_svdate"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_svname" runat="server" Text="النوع" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_svname" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_monyrname" runat="server" Text="شهر الراتب" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_monyrname" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_stopped" runat="server" Text="الإيقاف" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_stopped"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" FieldName="checkb">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_addbsalary" runat="server" Text="يضاف للراتب الأساسي" AutoPostBack="true" Checked="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_addbsalary"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" FieldName="checkb">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_salary" runat="server" Text="الراتب المحسوب منة" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_salary"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vvalue" runat="server" Text="القيمة" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_vvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vnotes" runat="server" Text="الملاحظات" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="vnotes"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_all" runat="server" Text="تحديد الكل" AutoPostBack="true" Font-Bold="true" OnCheckedChanged="chk_all_CheckedChanged" ClientInstanceName="chk_snotes"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <dx:ASPxGridView ID="gv_empsalaryvar" ClientInstanceName="gv_empsalaryvar" SettingsText-Title="تقرير رواتب الموظفين" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gv_empsalaryvar_CustomSummaryCalculate" OnDataBinding="gv_empsalaryvar_DataBinding" Width="100%" RightToLeft="True" CssClass="grid" KeyFieldName="svid">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                </Columns>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="empcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="empcode"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vvalue" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="vvalue"></dx:ASPxSummaryItem>
                </GroupSummary>

                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>
                <SettingsBehavior AllowEllipsisInText="true" />
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                </EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="empcode" VisibleIndex="1" Caption="كود الموظف"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="empname" VisibleIndex="2" Visible="false" Caption="إسم الموظف"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="svno" VisibleIndex="3" Caption="الرقم"  ></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="svnaturename" VisibleIndex="4" Caption="المتغير"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="svdate" VisibleIndex="5" Caption="التاريخ"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="svname" GroupIndex="0" SortIndex="0" ReadOnly="True" SortOrder="Ascending" VisibleIndex="6" Caption="النوع">
                        <EditFormSettings Visible="False" />
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />

                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="monyrname" VisibleIndex="7" Caption="شهر الراتب"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="stopped" VisibleIndex="8" Caption="الإيقاف" Visible="false"></dx:GridViewDataCheckColumn>
                    <dx:GridViewDataCheckColumn FieldName="addbsalary" VisibleIndex="9" Caption="يضاف للراتب الأساسي"></dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="salary" VisibleIndex="10" Caption="الراتب المحسوب منة" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vvalue" VisibleIndex="11" Caption="القيمة"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vnotes" VisibleIndex="12" Caption="الملاحظات" Visible="false"></dx:GridViewDataTextColumn>
                </Columns>
                <SettingsPopup>
                    <EditForm Width="730">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                    </EditForm>
                </SettingsPopup>
                <TotalSummary>
                    <%--<dx:ASPxSummaryItem FieldName="svnaturename" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="svnaturename"></dx:ASPxSummaryItem>--%>
                    <%--<dx:ASPxSummaryItem FieldName="vvalue" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="vvalue"></dx:ASPxSummaryItem>--%>
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvempsalaryvarExporter" runat="server" FileName="متغيرات رواتب الموظفين" GridViewID="gv_empsalaryvar" PaperKind="A4" PaperName="متغيرات رواتب الموظفين" RightToLeft="True" Landscape="True">
                <PageHeader Center=" متغيرات رواتب الموظفين" Font-Bold="true">
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
