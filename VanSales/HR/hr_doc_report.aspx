<%@ Page Title="تقرير الوثائق الرسمية" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_doc_report.aspx.cs" Inherits="VanSales.HR.hr_doc_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
        <style>
        .zoom {
            transition: transform .3s; /* Animation */
        }
            .zoom:hover {
                -ms-transform: scale(2.5); /* IE 9 */
                -webkit-transform: scale(2.5); /* Safari 3-8 */
                transform: scale(2.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
            }
    </style>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير الوثائق الرسمية" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" ForeColor="#35B86B"></dx:ASPxLabel>
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
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gv_doc.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gv_doc.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
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

                            <dx:LayoutItem Caption="" ColumnSpan="2">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxRadioButtonList ID="rbl_doctynature" ClientInstanceName="rbl_doctynature" runat="server" Border-BorderStyle="None" RepeatDirection="Horizontal" AutoPostBack="true" OnValueChanged="rbl_doctynature_ValueChanged">
                                        </dx:ASPxRadioButtonList>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="نوع المستند">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_doctypeid" runat="server" ClientInstanceName="cmb_doctypeid" RightToLeft="True" NullText="نوع المستند">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="تاريخ الإنتهاء من">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_datefrom" ClientInstanceName="txt_datefrom" runat="server" NullText="من تاريخ">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="تاريخ الإنتهاء الى">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_dateto" runat="server" ClientInstanceName="txt_dateto" RightToLeft="True" NullText="حتى تاريخ">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <dx:ASPxGridView ID="gv_doc" ClientInstanceName="gv_doc" SettingsText-Title="تقرير الوثائق الرسمية" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnDataBinding="gv_doc_DataBinding" Width="100%" RightToLeft="True" CssClass="grid" OnHtmlRowPrepared="gv_doc_HtmlRowPrepared">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                </Columns>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="empcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="empcode"></dx:ASPxSummaryItem>
                </GroupSummary>

                <SettingsBehavior AllowFocusedRow="true" AllowSelectByRowClick="true" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true"></SettingsAdaptivity>
                <SettingsBehavior AllowEllipsisInText="true" />
                <EditFormLayoutProperties>
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                </EditFormLayoutProperties>
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="empid" VisibleIndex="0" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="empcode" VisibleIndex="1" Caption="كود الموظف"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="empname" VisibleIndex="2" Caption="إسم الموظف"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="doctynatname" VisibleIndex="3" Caption="نوع المستند"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="doctypname" VisibleIndex="4" Caption="طبيعة المستند"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="datetypename" VisibleIndex="5" Caption="نوع التاريخ"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="docexpiredate" VisibleIndex="6" Caption="تاريخ الإنتهاء"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="remainingday" VisibleIndex="7" Caption="الأيام المتبية"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn FieldName="docimg" VisibleIndex="8" Caption="صورة المستند" CellStyle-CssClass="zoom">
                        <PropertiesImage AlternateTextField="doctynatname" DescriptionUrlField="doctypname" ImageAlign="Middle" ImageHeight="50px" ImageWidth="50px" ShowLoadingImage="True">
                                </PropertiesImage>
                                <Settings AllowGroup="False" AllowAutoFilter="False" ShowFilterRowMenu="False" />
                                <CellStyle CssClass="zoom"></CellStyle>
                    </dx:GridViewDataImageColumn>
                </Columns>
                <SettingsPopup>
                    <EditForm Width="730">
                        <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                    </EditForm>
                </SettingsPopup>
                <TotalSummary>
                    <dx:ASPxSummaryItem FieldName="empcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="empcode"></dx:ASPxSummaryItem>
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvempsalaryvarExporter" runat="server" FileName="الوثائق الرسمية" GridViewID="gv_doc" PaperKind="A4" PaperName="الوثائق الرسمية" RightToLeft="True" Landscape="True">
                <PageHeader Center="الوثائق الرسمية" Font-Bold="true">
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