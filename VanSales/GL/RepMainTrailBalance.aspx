﻿<%@ Page Title="ميزان المراجعه - رئيسي" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepMainTrailBalance.aspx.cs" Inherits="VanSales.GL.RepMainTrailBalance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="ميزان المراجعه - رئيسي" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" /> 
            <div class="col-md-12" style="direction: rtl; border: 1px Solid #DFDFDF; padding-top: 10px;">
                <div class="" style="text-align: center; padding-bottom: 3%;">
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_search" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="عرض">
                        <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                        </Image>
                        <ClientSideEvents Click="function(s,e){ASPxGridView1.PerformCallback()}" />
                    </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="ASPxButton2_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">
                        <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                        </Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_clear_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                        <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>
                    </dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" OnClick="btn_xlsxexport_Click" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" OnClick="btn_docexport_Click" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                    <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" OnClick="btn_pdfexport_Click" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                </div>
                <dx:ASPxFormLayout AlignItemCaptionsInAllGroups="true" AlignItemCaptions="true" SettingsItemCaptions-HorizontalAlign="right" runat="server" ID="formLayout" RightToLeft="True">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                            <Items>
                                <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem Caption="مستوي الحساب ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_levelno" runat="server"></dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="الارصدة ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_balance" runat="server">
                                                        <Items>
                                                            <dx:ListEditItem Value="1" Text="الكل"  Selected="true"/>
                                                            <dx:ListEditItem Value="2" Text="غير الصفريه" />
                                                            <dx:ListEditItem Value="3" Text="حسابات لها حركه" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="من ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtefrom" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="الى ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dteto" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                    </dx:ASPxFormLayout>
                <dx:ASPxGridView ID="ASPxGridView1" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" ClientInstanceName="ASPxGridView1" OnCustomSummaryCalculate="ASPxGridView1_CustomSummaryCalculate"
                    runat="server" OnAfterPerformCallback="ASPxGridView1_AfterPerformCallback" OnCustomCallback="ASPxGridView1_CustomCallback"
                    AutoGenerateColumns="False" KeyFieldName="chartid" OnDataBinding="ASPxGridView1_DataBinding">
                    <SettingsPager Visible="true"></SettingsPager>
                    <Settings ShowFilterRow="True" ShowFooter="true"></Settings>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="chartcode" VisibleIndex="0" Caption="كود الحساب" Width="5%"></dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="chartname" VisibleIndex="1" Caption="اسم الحساب" Width="20%"></dx:GridViewDataTextColumn>
                        <dx:GridViewBandColumn Caption="رصيد سابق" VisibleIndex="2" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="sumdebit" VisibleIndex="2" Caption="مدين" Name="balancedebit"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="sumcredit" VisibleIndex="3" Caption="دائن" Name="balancecredit"></dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:GridViewBandColumn>
                        <dx:GridViewBandColumn Caption="حركات" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="currentdebit" VisibleIndex="4" Caption="مدين" Name="currentdebit">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="currentcredit" VisibleIndex="5" Caption="دائن" Name="currentcredit"></dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:GridViewBandColumn>
                        <dx:GridViewBandColumn Caption="مجاميع" VisibleIndex="4" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="totdebit" VisibleIndex="6" Caption="مدين" Name="totaldebit"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="totcredit" Caption="دائن" VisibleIndex="7" Name="totalcredit"></dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:GridViewBandColumn>
                        <dx:GridViewBandColumn Caption=" الرصيد" VisibleIndex="5" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="endtotdebit" VisibleIndex="8" Caption="مدين" Name="endbalancedebit"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="endtotcredit" Caption="دائن" VisibleIndex="9" Name="endbalancecredit">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:GridViewBandColumn>
                    </Columns>
                    <TotalSummary>
                        <dx:ASPxSummaryItem ShowInColumn="balancedebit" SummaryType="Sum" FieldName="sumdebit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="balancecredit" SummaryType="Sum" FieldName="sumcredit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="currentdebit" SummaryType="Sum" FieldName="currentdebit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="currentcredit" SummaryType="Sum" FieldName="currentcredit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="totaldebit" SummaryType="Sum" FieldName="totdebit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="totalcredit" SummaryType="Sum" FieldName="totcredit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="endbalancedebit" SummaryType="Sum" FieldName="endtotdebit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                        <dx:ASPxSummaryItem ShowInColumn="endbalancecredit" SummaryType="Sum" FieldName="endtotcredit" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                    </TotalSummary>
                    <Styles>
                        <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                        <Footer BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Footer>
                    </Styles>
                </dx:ASPxGridView>
            </div>
            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server" FileName=" الفاتوره" GridViewID="ASPxGridView1" PaperKind="A4" PaperName=" رقم الصفحه" RightToLeft="True" Landscape="True">
                <PageHeader Center=" ميزان مراجع رئيسي" Font-Bold="true">
                </PageHeader>
                <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                </PageFooter>
            </dx:ASPxGridViewExporter>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_search" />
            <asp:PostBackTrigger ControlID="btn_print" />
            <asp:PostBackTrigger ControlID="btn_docexport" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
        </Triggers>
    </asp:UpdatePanel>
    <script>
</script>
</asp:Content>