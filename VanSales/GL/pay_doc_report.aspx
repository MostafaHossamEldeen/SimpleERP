<%@ Page Title="تقرير سندات الصرف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pay_doc_report.aspx.cs" Inherits="VanSales.GL.pay_doc_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <script src="../Scripts/App/Public/Messages.js"></script>
<div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير سندات الصرف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
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
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvs_pay_doc.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvs_pay_doc.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
    
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="Box" Caption="">
                        <Items>

                            <dx:LayoutItem Caption="الفرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_pdbranchid" runat="server" ClientInstanceName="cmb_pdbranchid" RightToLeft="True" TextField="branchname" NullText="الكل" NullTextDisplayMode="UnfocusedAndFocused" NullTextStyle-ForeColor="Black" Theme="MaterialCompact" ValueField="branchid" SelectedIndex="0">
                                            <ClearButton DisplayMode="Always"></ClearButton>

                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                  
                        
                            <dx:LayoutItem Caption="نوع الصرف" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0"> 
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                      <dx:ASPxComboBox ID="cmb_paidtype" runat="server" ClientInstanceName="cmb_paidtype" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>
 
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                       
                     
                            <dx:LayoutItem Caption="من">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxDateEdit ID="txt_fromdate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_fromdate">
                                        </dx:ASPxDateEdit>


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
        
                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="Box" Caption="اعمده التقرير" Name="checkboxs" >
                      
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pdno" runat="server"  OnCheckedChanged="chk_pdno_CheckedChanged" Text="رقم السند" AutoPostBack="true" Checked="true" ClientInstanceName="chk_pdno" ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pddate" runat="server" Text="التاريخ" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" Checked="true" ClientInstanceName="chk_pddate"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paidtypename" runat="server" Text="نوع الصرف" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" Checked="true" ClientInstanceName="chk_paidtypename"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_branchname" runat="server" Text="الفرع" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" Checked="true" ClientInstanceName="chk_branchname"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                           
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paidchartno" runat="server" Text="رقم حساب المدفع له" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_paidchartno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                             <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paidchartname" runat="server" Text="حساب المدفع له" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" ClientInstanceName="chk_paidchartname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                             <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paytypename" runat="server" Text="طريقه الدفع" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_paytypename"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paychartno" runat="server" Text="رقم حساب طريقه الدفع" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_paychartno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                               <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_payname" runat="server" Text=" حساب طريقه الدفع" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_payname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption=""  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vattypename" runat="server" Text="نوع الضريبه" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_vattypename"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                             <dx:LayoutItem Caption=""  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pdbvat" runat="server" Text=" السعر بدون ضريبه" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" Checked="true" ClientInstanceName="chk_pdbvat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                             <dx:LayoutItem Caption=""  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vatvalue" runat="server" Text="قيمه الضريبه" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" Checked="true" ClientInstanceName="chk_vatvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                             <dx:LayoutItem Caption=""  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pdavat" runat="server" Text="السعر شامل الضريبه" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" Checked="true" ClientInstanceName="chk_pdavat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_recnotes" runat="server" Text="شرح الحركه" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_recnotes"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pddocno" runat="server" Text="رقم السند اليدوى" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" ClientInstanceName="chk_pddocno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_ccname" runat="server" Text="مركز التكلفه" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" Checked="true" ClientInstanceName="chk_ccname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paidto" runat="server" Text="المستفيد" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" ClientInstanceName="chk_recman"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pdman" runat="server" Text="المستلم" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" ClientInstanceName="chk_recman"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_payref" runat="server" Text="رقم مرجعى" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" ClientInstanceName="chk_payref"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_paynotes" runat="server" Text="بيانات" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged" ClientInstanceName="chk_paynotes"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pduser" runat="server" Text="اسم المستخدم" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_pduser"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_postacc" runat="server" Text="مرحل" AutoPostBack="true" OnCheckedChanged="chk_pdno_CheckedChanged"  ClientInstanceName="chk_postacc"></dx:ASPxCheckBox>
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
      
            <dx:ASPxGridView ID="gvs_pay_doc" ClientInstanceName="gvs_pay_doc" SettingsText-Title="تقرير سندات القبض" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gvs_pay_doc_CustomSummaryCalculate" OnDataBinding="gvs_pay_doc_DataBinding" Width="100%" KeyFieldName="pdid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid">



                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}"  />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False"  />
                <Columns >
                    <%--<dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" Caption=" " Width="4%"></dx:GridViewCommandColumn>--%>
                  <%--  <dx:GridViewDataTextColumn FieldName="snaturename" Visible="false" GroupIndex="0" SortIndex="0" ReadOnly="True" Caption=" " VisibleIndex="1" SortOrder="Ascending">
                        <EditFormSettings Visible="False" />
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                     
                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" ></CellStyle>
                    </dx:GridViewDataTextColumn>--%>

                    <dx:GridViewDataHyperLinkColumn FieldName="pdno" VisibleIndex="1" Caption="رقم السند" >
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="~\GL\pay_doc.aspx?pdno={0}" Target="_parent" TextField="pdno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>
                    </dx:GridViewDataHyperLinkColumn>
                    <dx:GridViewDataTextColumn FieldName="pddocno" VisibleIndex="2" Visible="false" Caption="الرقم اليدوى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pddate" VisibleIndex="3" Caption="التاريخ" PropertiesTextEdit-DisplayFormatString="{0:d}"  >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="4"  Caption="الفرع" >
                    </dx:GridViewDataTextColumn>                
                    <dx:GridViewDataTextColumn FieldName="paidtypename" VisibleIndex="5" Caption="نوع الصرف" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="6"   Caption="مركز التكلفه" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paidchartno" VisibleIndex="7" Visible="false" Caption="رقم حساب المدفوع له" >
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="paidchartname" VisibleIndex="8" Visible="false"  Caption="حساب المدفوع له" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paytypename" VisibleIndex="9" Visible="false" Caption="طريقه الدفع" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paychartno" VisibleIndex="10" Visible="false"  Caption="رقم حساب طريقه الدفع" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="payname" VisibleIndex="11" Visible="false" Caption="حساب طريقه الدفع" >
                    </dx:GridViewDataTextColumn>
                  
                    <dx:GridViewDataTextColumn FieldName="pdbvat" VisibleIndex="12" Caption="قيمه المصروف"  >
                    </dx:GridViewDataTextColumn>
                      <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="13" Caption="الضريبه"  >
                    </dx:GridViewDataTextColumn>
                       <dx:GridViewDataTextColumn FieldName="pdavat" VisibleIndex="14" Caption="الاجمالى شامل الشريبه"  >
                    </dx:GridViewDataTextColumn>
                      <dx:GridViewDataTextColumn FieldName="pdman" VisibleIndex="15" Visible="false" Caption="المستلم" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paidto" VisibleIndex="16" Visible="false" Caption="المستفيد" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="payref" VisibleIndex="17"  Visible="false" Caption="الرقم المرجعى"   >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="paynotes" VisibleIndex="18" Visible="false" Caption="بيانات" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pduser" VisibleIndex="19" Visible="false" Caption="منشئ السند" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="postacc" VisibleIndex="20" Visible="false" Caption="مرحل حسابات" >
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="pdnotes" VisibleIndex="21" Visible="false" Caption="شرح الحركه" >
                    </dx:GridViewDataTextColumn>
                </Columns>

<%--                <GroupSummary>
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
                <TotalSummary>
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="pdno" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="pdbvat" SummaryType="Sum" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Sum" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="pdavat" SummaryType="Sum" DisplayFormat=" {0}" />
                     
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white" ></Header>
                </Styles>
            </dx:ASPxGridView>

            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server"  FileName=" تقرير سندات الصرف" GridViewID="gvs_pay_doc" PaperKind="A4" PaperName=" تقرير سندات الصرف" RightToLeft="True" Landscape="True">
                <PageHeader Center=" تقرير سندات الصرف" Font-Bold="true" >
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
