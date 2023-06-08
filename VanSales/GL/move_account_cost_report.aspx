<%@ Page Title="تقرير حركه الحسابات ومراكز التكلفه" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="move_account_cost_report.aspx.cs" Inherits="VanSales.GL.move_account_cost_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="../Scripts/App/Public/Messages.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير حركه الحسابات ومراكز التكلفه" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_preview" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_preview_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="استعراض">

                    <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">

                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_clear_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>

                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvs_vocher.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvs_vocher.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="5" GroupBoxDecoration="Box" Caption="">
                        <Items>

                            <dx:LayoutItem Caption="كود الحساب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_chartid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_chartid" AutoPostBack="false">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <button type="button" id="Pop_chart" data-name="chart" onclick="createPopUp($(this))" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldshidden="chartid"
                                            data-displayfieldscaption="كود الحساب,اسم الحساب" data-bindcontrols="txt_chartid;txt_chartname;HF_chartid"
                                            data-bindfields="chartcode;chartname;chartid" data-pkfield="chartid" data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype"  class="btn btn-sm btnsearchpopup" tabindex="1" />
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                </ParentContainerStyle>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="اسم الحساب" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxTextBox ID="txt_chartname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_chartname" AutoPostBack="false">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="مركز التكلفه" ParentContainerStyle-Paddings-PaddingLeft="5" ParentContainerStyle-Paddings-PaddingRight="5">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxTextBox ID="txt_ccname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_ccname" AutoPostBack="false">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>


                                        <button type="button" id="puop_ccid" data-name="cust" onclick="createPopUp($(this))" data-tablename="sys_costcenter_sel_search" data-displayfields="ccid,ccname" data-displayfieldshidden="ccnotes"
                                            data-displayfieldscaption="كود مركز التكلفه,إسم مركز التكلفه" data-bindcontrols="txt_ccname;HF_ccid"
                                            data-bindfields="ccname;ccid" data-pkfield="ccid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                        </button>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                </ParentContainerStyle>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="من">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxDateEdit ID="txt_fromdate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_fromdate">
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
                            <dx:LayoutItem Caption="الى">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxDateEdit ID="txt_todate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_todate">
                                        </dx:ASPxDateEdit>


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
                                        <dx:ASPxCheckBox ID="chk_chartcode" runat="server" OnCheckedChanged="chk_chartcode_CheckedChanged" Text="كود الحساب" AutoPostBack="true" Checked="true" ClientInstanceName="chk_chartcode"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_chartname" runat="server" Text="اسم الحساب" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" Checked="true" ClientInstanceName="chk_chartname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_ccname" runat="server" Text="مركز التكلفه" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" ClientInstanceName="chk_ccname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vchrno" runat="server" Text="رقم القيد" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" Checked="true" ClientInstanceName="chk_vchrno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vchtdate" runat="server" Text="تاريخ القيد" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" Checked="true" ClientInstanceName="chk_vchtdate"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_descp" runat="server" Text="شرح الحركه" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" Checked="true" ClientInstanceName="chk_descp"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_debit" runat="server" Text="مدين" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" Checked="true" ClientInstanceName="chk_debit"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_credit" runat="server" Text="دائن" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" Checked="true" ClientInstanceName="chk_credit"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_balance" runat="server" Text="الرصيد" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" Checked="true" ClientInstanceName="chk_balance"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vchrtypename" runat="server" Text="نوع القيد" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" ClientInstanceName="chk_vchrtypename"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_post" runat="server" Text="مرحل" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" ClientInstanceName="chk_post"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_ref" runat="server" Text="المستند" AutoPostBack="true" OnCheckedChanged="chk_chartcode_CheckedChanged" ClientInstanceName="chk_ref"></dx:ASPxCheckBox>
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
            <asp:HiddenField ID="HF_chartid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_ccid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_legertype" ClientIDMode="Static" runat="server" Value="1" />

            <dx:ASPxGridView ID="gvs_vocher" ClientInstanceName="gvs_vocher" SettingsText-Title="تقرير حركه الحسابات ومراكز التكلفه" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gvs_vocher_CustomSummaryCalculate" OnDataBinding="gvs_vocher_DataBinding" Width="100%" KeyFieldName="sinvid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid">



                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="chartcode" VisibleIndex="1" Caption="كود الحساب"  Width="10%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="chartname" VisibleIndex="2" Caption="اسم الحساب">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="3" Visible="false" Caption="مركز التكلفه" Width="11%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataHyperLinkColumn FieldName="vchrno"  VisibleIndex="4" Caption="رقم القيد"  Width="8%">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="~\GL\Vouchers.aspx?vchrno={0}" Target="_parent" TextField="vchrno" >
                            <Style Font-Bold="True"></Style>
                            
                        </PropertiesHyperLinkEdit>
                        
                    </dx:GridViewDataHyperLinkColumn>

                    <dx:GridViewDataTextColumn FieldName="vchtdate" VisibleIndex="5" Caption="التاريخ" PropertiesTextEdit-DisplayFormatString="{0:d}" Width="8%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="descp" VisibleIndex="10" Caption="شرح الحركه">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="debit" VisibleIndex="7" Caption="مدين"  Width="10%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="credit" VisibleIndex="8" Caption="دائن"  Width="10%">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="balance" VisibleIndex="9" Caption="الرصيد"  Width="10%">
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="vchrtypename" VisibleIndex="11" Visible="false" Caption="نوع القيد">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="post" VisibleIndex="12" Visible="false" Caption="الترحيل">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ref" VisibleIndex="13" Visible="false" Caption="المستند"  Width="10%">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vchrid" VisibleIndex="14" Visible="false" Caption=""  Width="10%">
                    </dx:GridViewDataTextColumn>
                </Columns>

            <%--    <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="chartcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="كود الحساب"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="debit" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="مدين"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="credit" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="دائن"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="balance" SummaryType="Sum" DisplayFormat="{0}" ShowInGroupFooterColumn="الرصيد"></dx:ASPxSummaryItem>
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
                <TotalSummary>
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="chartcode" DisplayFormat="العدد= 0" />
                    <dx:ASPxSummaryItem FieldName="debit" SummaryType="Sum" DisplayFormat=" {0}" ShowInColumn="مدين" />
                    <dx:ASPxSummaryItem FieldName="credit" SummaryType="Sum" DisplayFormat=" {0}" ShowInColumn="دائن" />
                    <dx:ASPxSummaryItem FieldName="balance" SummaryType="Custom" DisplayFormat="{0}" ShowInColumn="الرصيد" />
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>

            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server" FileName=" الفاتوره" GridViewID="gvs_vocher" PaperKind="A4" PaperName=" الفاتوره" RightToLeft="True" Landscape="True">
                <PageHeader Center=" الفاتوره" Font-Bold="true">
                </PageHeader>
                <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                </PageFooter>


            </dx:ASPxGridViewExporter>

        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_docexport" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
            <%--<asp:PostBackTrigger ControlID="btn_print" />--%>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
