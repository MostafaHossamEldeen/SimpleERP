<%@ Page Title="الميزانية العمومية" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepBalanceSheetStatment.aspx.cs" Inherits="VanSales.GL.RepBalanceSheetStatment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="الميزانية العمومية" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
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
                        <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px"></Image>
                        <ClientSideEvents Click="function(s,e){ASPxGridView1.PerformCallback()}" />
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
                                <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem  Caption="مستوي الحساب ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_levelno" runat="server"></dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                <dx:LayoutItem ShowCaption="false">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="من ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dtefrom" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy"  runat="server"></dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="الى ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="dteto" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy"  runat="server"></dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                    </dx:ASPxFormLayout>
                <dx:ASPxGridView ID="ASPxGridView1" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" ClientInstanceName="ASPxGridView1" OnCustomSummaryCalculate="ASPxGridView1_CustomSummaryCalculate" runat="server" OnAfterPerformCallback="ASPxGridView1_AfterPerformCallback" OnCustomCallback="ASPxGridView1_CustomCallback" AutoGenerateColumns="False" KeyFieldName="recnum" OnDataBinding="ASPxGridView1_DataBinding" Width="100%">
                    <SettingsPager Visible="false" Mode="ShowAllRecords"></SettingsPager>
                    <Settings ShowFilterRow="false" ShowFooter="true"></Settings>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="false" ShowGroupPanel="false" ShowGroupFooter="VisibleAlways" />
                    <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False" ></SettingsDataSecurity>
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="recnum" SortOrder="Ascending" Visible="false" VisibleIndex="4" Caption="" >
                                
                                </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="acctype" VisibleIndex="4" Caption="" Visible="false">
                                
                                </dx:GridViewDataTextColumn>
                      <dx:GridViewDataTextColumn  FieldName="chartid"  VisibleIndex="0" Caption="كود الحساب" Width="5%" ></dx:GridViewDataTextColumn>
                                    
                                <dx:GridViewDataTextColumn  FieldName="chartname"   VisibleIndex="1" Caption="اسم الحساب" Width="50%" ></dx:GridViewDataTextColumn>    

                                 
                                <dx:GridViewDataTextColumn FieldName="Total" VisibleIndex="4" Caption="جزئي">
                                
                                </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="TotalOfTotal" VisibleIndex="5" Caption="كلي" ></dx:GridViewDataTextColumn>
                    </Columns>
                    <FormatConditions>
                        <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[acctype] = 110" Format="Custom" FieldName="acctype">
                            <RowStyle BackColor="#CCFFFF"></RowStyle>
                        </dx:GridViewFormatConditionHighlight>
                        <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[acctype] = 120" Format="Custom" FieldName="acctype">
                            <RowStyle BackColor="AntiqueWhite"></RowStyle>
                        </dx:GridViewFormatConditionHighlight>
                        <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[acctype] = 220" Format="Custom" FieldName="acctype">
                            <RowStyle BackColor="#99CCFF"></RowStyle>
                        </dx:GridViewFormatConditionHighlight>
                        <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[acctype] = 210" Format="LightGreenFill"></dx:GridViewFormatConditionHighlight>
                     <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[acctype] = 310" Format="YellowFillWithDarkYellowText"></dx:GridViewFormatConditionHighlight>
            <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[acctype] = 121" Format="GreenFillWithDarkGreenText"></dx:GridViewFormatConditionHighlight>
                                    <dx:GridViewFormatConditionHighlight ApplyToRow="True" Expression="[acctype] = 211" Format="GreenFillWithDarkGreenText"></dx:GridViewFormatConditionHighlight>

                        </FormatConditions>

                    <Styles>
                        <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                        <Footer BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Footer>
                    </Styles>
                </dx:ASPxGridView>
                <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server" FileName=" المزيانية العمومية" GridViewID="ASPxGridView1" PaperKind="A4" PaperName=" رقم الصفحه" RightToLeft="True" Landscape="True">
                    <PageHeader Center=" المزانية العمومية" Font-Bold="true">
                    </PageHeader>
                    <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                    </PageFooter>
                </dx:ASPxGridViewExporter>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_search" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
            <asp:PostBackTrigger ControlID="btn_print" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
        </Triggers>
    </asp:UpdatePanel>
    <script>
</script>
</asp:Content>