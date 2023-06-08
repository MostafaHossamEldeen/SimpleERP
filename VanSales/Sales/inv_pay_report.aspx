<%@ Page Title="تقرير طرق دفع المبيعات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inv_pay_report.aspx.cs" Inherits="VanSales.Sales.inv_pay_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/sales/inv_report.js"></script>
 <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير طرق دفع المبيعات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_preview" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Review_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="استعراض">

                    <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">
             
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_addnew_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>
                    
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>

                   <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvs_inv_pay.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvs_inv_pay.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
       
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="">
                        <Items>

                            <dx:LayoutItem Caption="الفرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" TextField="branchname" NullText="الكل" NullTextDisplayMode="UnfocusedAndFocused" NullTextStyle-ForeColor="Black" Theme="MaterialCompact" ValueField="branchid" SelectedIndex="0">
                                            <ClearButton DisplayMode="Always"></ClearButton>

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
                           

                            <dx:LayoutItem Caption="العميل">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxTextBox ID="txt_custname" runat="server" Theme="MaterialCompact" ClientInstanceName="ctname" AutoPostBack="false">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>


                                        <button type="button" id="puop_cust" data-name="cust" onclick="createPopUp($(this))" data-tablename="s_customers_sel_search" data-displayfields="custcode,custname,custadd,custmob" data-displayfieldshidden="smanname,smanid,custid"
                                            data-displayfieldscaption="كود العميل,إسم العميل,العنوان,التليفون" data-bindcontrols="ctname;txt_smanid;HF_smanid;HF_cusid"
                                            data-bindfields="custname;smanname;smanid;custid" data-pkfield="custid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                        </button>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                </ParentContainerStyle>

                            </dx:LayoutItem>
                 
                        </Items>
                    </dx:LayoutGroup>
       
                   
                </Items>
            </dx:ASPxFormLayout>
               <div>
                            <a href="#ff" data-toggle="collapse" aria-expanded="false" class="">
                                اعمده التقرير
                            </a>
                            <div id="ff" class="collapse sidebar-submenu" style=" background-color: #f6f6f6; font-size: 1rem;">
            <dx:ASPxFormLayout runat="server" ID="FormLayoutcol" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                     <dx:LayoutGroup ColCount="6" GroupBoxDecoration="Box" Caption="اعمده التقرير" Name="checkboxs" >
                      
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_payname" runat="server"  OnCheckedChanged="chk_payname_CheckedChanged" Text="طريقه الدفع" AutoPostBack="true" Checked="true" ClientInstanceName="chk_payname"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_payvalue" runat="server" Text="القيمه" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged" Checked="true" ClientInstanceName="chk_payvalue"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_payno" runat="server" Text="الرقم المرجعى" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged"   ClientInstanceName="chk_payno"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_payref" runat="server" Text="البيانات" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged"   ClientInstanceName="chk_payref"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>                                                      
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sinvno" runat="server" Text="رقم الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged" Checked="true" ClientInstanceName="chk_sinvno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_invdate" runat="server" Text="تاريخ الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged" Checked="true" ClientInstanceName="chk_invdate"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                   <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_branchname" runat="server" Text="الفرع" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged" Checked="true" ClientInstanceName="chk_branchname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                               
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custid" runat="server" Text="كود العميل" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged" ClientInstanceName="chk_custid"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custname" runat="server" Text="اسم العميل" AutoPostBack="true" OnCheckedChanged="chk_payname_CheckedChanged" ClientInstanceName="chk_custname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                 
                         
                              <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_all" runat="server" Text="تحديد الكل" AutoPostBack="true" Font-Bold="true" OnCheckedChanged="chk_all_CheckedChanged" ClientInstanceName="chk_all"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                     </Items>
            </dx:ASPxFormLayout>
                                   </div>
                     </div>
            <asp:HiddenField ID="HF_cusid" ClientIDMode="Static" runat="server" />
            <%--<asp:HiddenField ID="HF_smanid" ClientIDMode="Static" runat="server" />--%>
            
            <dx:ASPxGridView ID="gvs_inv_pay" ClientInstanceName="gvs_inv_pay" SettingsText-Title="تقرير اصناف المبيعات" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gvs_inv_pay_CustomSummaryCalculate" OnDataBinding="gvs_inv_pay_DataBinding" Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid">



                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}"  />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False"  />
                <Columns >
                    <%--<dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" Caption=" " Width="4%"></dx:GridViewCommandColumn>--%>
                    <dx:GridViewDataTextColumn FieldName="snaturename" Visible="false" GroupIndex="0" SortIndex="0" ReadOnly="True" Caption=" " VisibleIndex="1" SortOrder="Ascending">
                        <EditFormSettings Visible="False" />
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                     
                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" ></CellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="payname" VisibleIndex="2" Caption="طريقه الدفع" >
                       <%-- <PropertiesHyperLinkEdit NavigateUrlFormatString="~\Sales\inv.aspx?sinvno={0}" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>--%> 
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="payvalue" VisibleIndex="3"  Caption="القيمه" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="payno" VisibleIndex="4" Visible="false" Caption="الرقم المرجعى"   >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="payref" VisibleIndex="5" Visible="false" Caption="البيانات" >
                    </dx:GridViewDataTextColumn>                
                    <dx:GridViewDataHyperLinkColumn FieldName="sinvno" VisibleIndex="6"   Caption="رقم الفاتوره" >
                     <%--<PropertiesHyperLinkEdit NavigateUrlFormatString="~\Sales\inv.aspx?sinvno={0}" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit> --%>
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="javascript:ShowDetailPopup('{0}');" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>
                        </dx:GridViewDataHyperLinkColumn>
                     <dx:GridViewDataTextColumn FieldName="invdate" VisibleIndex="7" Caption="التاريخ"  PropertiesTextEdit-DisplayFormatString="{0:d}"  >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="8" Visible="false"  >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="9"  Caption="الفرع" >
                    </dx:GridViewDataTextColumn>
                   
                    <dx:GridViewDataTextColumn FieldName="custid" VisibleIndex="10" Visible="false" Caption="كود العميل"   >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custname" VisibleIndex="11" Visible="false" Caption="اسم العميل" >
                    </dx:GridViewDataTextColumn>

                </Columns>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="payname" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="طريقه الدفع"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="payvalue" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="القيمه"></dx:ASPxSummaryItem>
                   
                </GroupSummary>

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
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="payname" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="payvalue" SummaryType="Custom" DisplayFormat=" {0}" />                     
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white" ></Header>
                </Styles>
            </dx:ASPxGridView>

            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server"  FileName=" الفاتوره" GridViewID="gvs_inv_pay" PaperKind="A4" PaperName=" الفاتوره" RightToLeft="True" Landscape="True">
                <PageHeader Center=" الفاتوره" Font-Bold="true" >
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

