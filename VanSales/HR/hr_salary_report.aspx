<%@ Page Title="تقرير رواتب الموظفين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_salary_report.aspx.cs" Inherits="VanSales.HR.hr_salary_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="../Scripts/App/Public/Messages.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير رواتب الموظفين" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" ForeColor="#35B86B"></dx:ASPxLabel>
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
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gv_empsalary.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gv_empsalary.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="">
                        <Items>

                            <dx:LayoutItem Caption="شهور الرواتب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_monyrid" runat="server" ClientInstanceName="cmb_monyrid" RightToLeft="True" NullText="الشهر / السنة">
                                            <ClientSideEvents ValueChanged="function(s, e) {
	txt_docno.SetValue(null);
}"></ClientSideEvents>

                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="طبيعة الرواتب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxComboBox ID="cmb_salarynature" runat="server" ClientInstanceName="cmb_salarynature" RightToLeft="True" SelectedIndex="0">
                                        </dx:ASPxComboBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="رقم المستند">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxTextBox ID="txt_docno" runat="server" RightToLeft="True" ClientInstanceName="txt_docno" NullText="رقم المستند">
                                            <ClientSideEvents ValueChanged="function(s, e) {
	cmb_monyrid.SetValue(null);
}"></ClientSideEvents>
                                        </dx:ASPxTextBox>


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
                                        <dx:ASPxCheckBox ID="chk_empname" runat="server" Text="إسم الموظف" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_empname" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_jobname" runat="server" Text="الوظيفة" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_jobname" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_nationname" runat="server" Text="الجنسية" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_nationname" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paytypename" runat="server" Text="طريقة الدفع" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_paytypename" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paychartid" runat="server" Text="رقم الحساب" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_paychartid"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" FieldName="checkb">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_empbankname" runat="server" Text="إسم البنك" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_empbankname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" FieldName="checkb">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_basicsarlary" runat="server" Text="الراتب الأساسي" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_basicsarlary"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_hallowance" runat="server" Text="بدل السكن" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_hallowance"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_oallowance" runat="server" Text="البدلات الأخرى" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_oallowance"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_bouns" runat="server" Text="المكافئات" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_bouns"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_additional" runat="server" Text="الإضافي" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_additional"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vbouns" runat="server" Text="متغير اضافى" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_vbouns"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sumbenfit" runat="server" Text="إجمالي المستحق" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_sumbenfit"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_insureded" runat="server" Text="خصم التأمينات" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_insureded"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_abs" runat="server" Text="خصم الغياب" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_abs"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_delay" runat="server" Text="خصم التأخير" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_delay"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_penalty" runat="server" Text="الجزاءات" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_penalty"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_loan" runat="server" Text="السلف" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_loan"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vded" runat="server" Text="خصم متغير" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged"  ClientInstanceName="chk_vded"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sumdeduction" runat="server" Text="إجمالي المستقطع" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" ClientInstanceName="chk_sumdeduction"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_netsalary" runat="server" Text="الصافي" AutoPostBack="true" OnCheckedChanged="chk_empcode_CheckedChanged" Checked="true" ClientInstanceName="chk_netsalary"></dx:ASPxCheckBox>
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
            <dx:ASPxGridView ID="gv_empsalary" ClientInstanceName="gv_empsalary" SettingsText-Title="تقرير رواتب الموظفين" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gv_empsalary_CustomSummaryCalculate" OnDataBinding="gv_empsalary_DataBinding" Width="100%" RightToLeft="True" CssClass="grid">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="empcode" Caption="كود الموظف" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="empname" Caption="إسم الموظف" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="jobname" Caption="الوظيفة" VisibleIndex="2" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="nationname" Caption="الجنسية" VisibleIndex="3" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paytypename" Caption="طريقة الدفع" VisibleIndex="4" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paychartid" Caption="رقم الحساب" VisibleIndex="5" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="empbankname" Caption="إسم البنك" VisibleIndex="6" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="basicsarlary" Caption="الاساسى" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="hallowance" Caption="بدل السكن" VisibleIndex="8" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="oallowance" Caption="البدلات لاخرى" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="bouns" Caption="المكافئات" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="additional" Caption="الاضافى" VisibleIndex="11">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vbouns" Caption="متغير اضافى" VisibleIndex="12" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sumbenfit" Caption="اجمالى الاستحقاقات" VisibleIndex="13" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="insureded" Caption="خصم التامين" VisibleIndex="14" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="abs" Caption="الغياب" VisibleIndex="15" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="delay" Caption="التاخير" VisibleIndex="16" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="penalty" Caption="الجزءات" VisibleIndex="17" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="loan" Caption="السلف" VisibleIndex="18" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vded" Caption="خصم متغير" VisibleIndex="19" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sumdeduction" Caption="اجمالى الاستقطاعات" VisibleIndex="20" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="netsalary" Caption="الصافى" VisibleIndex="21">
                    </dx:GridViewDataTextColumn>
                </Columns>

                <%--<GroupSummary>
                    <dx:ASPxSummaryItem FieldName="sinvno" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="رقم الفاتوره"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الاجمالى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الصافى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Sum" DisplayFormat="{0}" ShowInGroupFooterColumn="الضريبه"></dx:ASPxSummaryItem>
                </GroupSummary>--%>

                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>
                <SettingsBehavior AllowEllipsisInText="true" />
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                </EditFormLayoutProperties>
                <SettingsPopup>
                    <EditForm Width="730">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                    </EditForm>
                </SettingsPopup>
                <%--<TotalSummary>
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="sinvno" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Custom" DisplayFormat="{0}" />
                </TotalSummary>--%>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvempsalaryExporter" runat="server" FileName=" رواتب الموظفين" GridViewID="gv_empsalary" PaperKind="A4" PaperName=" رواتب الموظفين" RightToLeft="True" Landscape="True">
                <PageHeader Center=" رواتب الموظفين" Font-Bold="true">
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
