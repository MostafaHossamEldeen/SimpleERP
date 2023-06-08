<%@ Page Title="كشف حساب" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepAccStatment.aspx.cs" Inherits="VanSales.RepAccStatment" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="كشف حساب" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />
            <div class="col-md-12" style="direction: rtl; border: 1px Solid #DFDFDF; padding-top: 10px;">
                <div class="" style="text-align: center; padding-bottom: 3%;">
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="عرض">
                        <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                        </Image>
                        <ClientSideEvents Click="function(s,e){ASPxGridView1.PerformCallback()}" />
                    </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_clear_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>
                </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="ASPxButton2_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">
                        <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                        </Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" OnClick="btn_xlsxexport_Click" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" OnClick="btn_docexport_Click" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" OnClick="btn_pdfexport_Click" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                    </div>
                    <dx:ASPxFormLayout AlignItemCaptionsInAllGroups="true" AlignItemCaptions="true" SettingsItemCaptions-HorizontalAlign="right" runat="server" ID="formLayout" RightToLeft="True">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                            <Items>
                                <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem Caption="كود الحساب ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_chartid" runat="server" ClientInstanceName="txt_chartid" Font-Bold="True"></dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem ShowCaption="False" Paddings-PaddingLeft="0">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <button type="button" id="PopUpchartid" style="margin-right: 10px; margin-left: 10px" title="بحث" data-name="chart" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldscaption="كود الحساب,إسم الحساب"
                                                        data-displayfieldshidden="chartid" data-bindcontrols="hf_chartid;txt_chartid;lbl_chartname" data-bindfields="chartid;chartcode;chartname"
                                                        data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class=" btn btn-sm btnsearchpopup">
                                                    </button>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="إسم الحساب " ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="lbl_chartname" runat="server" ClientInstanceName="lbl_chartname" Font-Bold="True"></dx:ASPxTextBox>
                                                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_chartid" />
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="من" ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtefrom" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="الى " ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dteto" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="حالة القيود " ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_posted" runat="server">
                                                        <Items>
                                                            <dx:ListEditItem Value="0" Text="الكل" />
                                                            <dx:ListEditItem Value="1" Text="مرحل" Selected="true" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="مركز التكلفة " ColumnSpan="2">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_ccid" runat="server" ClientInstanceName="cmb_ccid" ClearButton-DisplayMode="Always">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                        </dx:ASPxFormLayout>
                    <dx:ASPxGridView ID="ASPxGridView1" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" ClientInstanceName="ASPxGridView1" OnCustomSummaryCalculate="ASPxGridView1_CustomSummaryCalculate" runat="server" OnAfterPerformCallback="ASPxGridView1_AfterPerformCallback" OnCustomCallback="ASPxGridView1_CustomCallback" AutoGenerateColumns="False" KeyFieldName="itemunitid" OnDataBinding="ASPxGridView1_DataBinding">
                        <SettingsPager Visible="true"></SettingsPager>
                        <Settings ShowFilterRow="True" ShowFooter="true"></Settings>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="debit" Tag="debit" ShowInColumn="debit" SummaryType="Sum" DisplayFormat="اجمالى مدين {0}" />
                            <dx:ASPxSummaryItem FieldName="credit" Tag="credit" ShowInColumn="credit" SummaryType="Sum" DisplayFormat="اجمالى دائن {0}" />
                            <dx:ASPxSummaryItem FieldName="descp" ShowInColumn="descp" SummaryType="Custom" Tag="tot" />
                        </TotalSummary>
                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                        <Columns>
                            <dx:GridViewDataHyperLinkColumn FieldName="vchrno" Caption="رقم القيد" VisibleIndex="1" Width="10%">
                                <PropertiesHyperLinkEdit Target="_blank" NavigateUrlFormatString="~/GL/Vouchers.aspx?id={0}"></PropertiesHyperLinkEdit>
                            </dx:GridViewDataHyperLinkColumn>
                            <dx:GridViewDataTextColumn FieldName="debit" VisibleIndex="2" Caption="مدين" Width="5%"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="credit" VisibleIndex="3" Caption="دائن" Width="5%"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vchtdate" VisibleIndex="4" Caption="التاريخ" Width="10%">
                                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="balance" VisibleIndex="5" Caption="الرصيد" Width="10%"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ref" VisibleIndex="5" Caption="رقم المستند" Width="10%"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="descp" VisibleIndex="6" Caption="شرح الحركه" Width="40%"></dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn FieldName="refno" VisibleIndex="7" Caption="رقم الحركة" Width="10%"></dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="8" Caption="مركز التكلفه" Width="10%"></dx:GridViewDataTextColumn>
                        </Columns>
                        <Styles>
                            <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                            <Footer BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Footer>
                        </Styles>
                    </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server" FileName=" كشف حساب" GridViewID="ASPxGridView1" PaperKind="A4" PaperName=" رقم الصفحه" RightToLeft="True" Landscape="True">
                    <PageHeader Center=" كشف حساب" Font-Bold="true">
                    </PageHeader>
                    <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                    </PageFooter>
                </dx:ASPxGridViewExporter>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_addnew" />
            <asp:PostBackTrigger ControlID="btn_docexport" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>