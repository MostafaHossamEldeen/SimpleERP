<%@ Page Title="تقرير اجمالى اصناف المبيعات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="total_inv_items.aspx.cs" Inherits="VanSales.Sales.total_inv_items" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير اجمالى اصناف المبيعات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
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
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvs_inv_itms.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvs_inv_itms.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
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
                           

                            <dx:LayoutItem Caption="مجموعه الاصناف">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_group" runat="server" ClientInstanceName="cmb_group" RightToLeft="True" TextField="groupname" NullText="الكل" NullTextDisplayMode="UnfocusedAndFocused" NullTextStyle-ForeColor="Black" Theme="MaterialCompact" ValueField="groupid" SelectedIndex="0">
                                            <ClearButton DisplayMode="Always"></ClearButton>

                                        </dx:ASPxComboBox>
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
                                        <dx:ASPxCheckBox ID="chk_groupname" runat="server"  OnCheckedChanged="chk_groupname_CheckedChanged" Text="مجموعه الصنف" AutoPostBack="true" Checked="true" ClientInstanceName="chk_groupname"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_itemcode" runat="server"  OnCheckedChanged="chk_groupname_CheckedChanged" Text="كود الصنف" AutoPostBack="true" Checked="true" ClientInstanceName="chk_itemcode"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_itemname" runat="server" Text="اسم الصنف" AutoPostBack="true" OnCheckedChanged="chk_groupname_CheckedChanged" Checked="true" ClientInstanceName="chk_itemname"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_invQty" runat="server" Text="كميه المبيعات" AutoPostBack="true" OnCheckedChanged="chk_groupname_CheckedChanged" Checked="true" ClientInstanceName="chk_invQty"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_invvalue" runat="server" Text="اجمالى المبيعات" AutoPostBack="true" OnCheckedChanged="chk_groupname_CheckedChanged" Checked="true" ClientInstanceName="chk_invvalue"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_rtnQty" runat="server" Text="كميه المرتجع" AutoPostBack="true" OnCheckedChanged="chk_groupname_CheckedChanged" Checked="true" ClientInstanceName="chk_rtnQty"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_rtnvalue" runat="server" Text="اجمالى المرتجع" AutoPostBack="true" OnCheckedChanged="chk_groupname_CheckedChanged" Checked="true" ClientInstanceName="chk_rtnvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_totalQty" runat="server" Text="صافى الكميه" AutoPostBack="true" OnCheckedChanged="chk_groupname_CheckedChanged" Checked="true" ClientInstanceName="chk_totalQty"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                               <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_totalvalue" runat="server" Text="صافى القيمه" AutoPostBack="true" OnCheckedChanged="chk_groupname_CheckedChanged" Checked="true" ClientInstanceName="chk_discp"></dx:ASPxCheckBox>
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
            <asp:HiddenField ID="HF_cusid" ClientIDMode="Static" runat="server" />
            <%--<asp:HiddenField ID="HF_smanid" ClientIDMode="Static" runat="server" />--%>
            
            <dx:ASPxGridView ID="gvs_inv_itms" ClientInstanceName="gvs_inv_itms" SettingsText-Title=" تقرير اجمالى مبيعات الاصناف" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gvs_inv_itms_CustomSummaryCalculate"  OnDataBinding="gvs_inv_itms_DataBinding" Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid">



                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}"  />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False"  />
                <Columns >
                    <%--<dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" Caption=" " Width="4%"></dx:GridViewCommandColumn>--%>
                    <dx:GridViewDataTextColumn FieldName="groupname" Visible="false" GroupIndex="0" SortIndex="0" ReadOnly="True" Caption=" " VisibleIndex="1" SortOrder="Ascending">
                        <EditFormSettings Visible="False" />
                        <Settings AutoFilterCondition="Contains"></Settings>

                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                     
                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle" ></CellStyle>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="2" Caption="كود الصنف" >
                       <%-- <PropertiesHyperLinkEdit NavigateUrlFormatString="~\Sales\inv.aspx?sinvno={0}" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>--%> <%--PropertiesTextEdit-DisplayFormatString="{0:d}"--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="3"  Caption="اسم الصنف" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="invQty" VisibleIndex="4" Caption="كمية المبيعات"  PropertiesTextEdit-DisplayFormatString="#.00"  >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="invvalue" VisibleIndex="5"  Caption="إجمالى المبيعات" PropertiesTextEdit-DisplayFormatString="{0:n2}" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="rtnQty" VisibleIndex="6" Caption="كميه المرتجع" PropertiesTextEdit-DisplayFormatString="{0:n2}">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="rtnvalue" VisibleIndex="7" Caption="إجمالي المرتجع" PropertiesTextEdit-DisplayFormatString="{0:n2}" >
                    </dx:GridViewDataTextColumn>
                  
                    <dx:GridViewDataTextColumn FieldName="totalQty" VisibleIndex="9" Caption="صافي الكميه" PropertiesTextEdit-DisplayFormatString="{0:n2}" >
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="totalvalue" VisibleIndex="10"   Caption="صافي القيمه" PropertiesTextEdit-DisplayFormatString="{0:n2}" >
                    </dx:GridViewDataTextColumn>                    
                </Columns>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="itemcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="كود الصنف"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="invQty" SummaryType="Sum" DisplayFormat=" {0:n2}" ShowInGroupFooterColumn="كمية المبيعات"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="invvalue" SummaryType="Sum" DisplayFormat=" {0:n2}" ShowInGroupFooterColumn="إجمالى المبيعات"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="rtnQty" SummaryType="Sum" DisplayFormat=" {0:n2}" ShowInGroupFooterColumn="كميه المرتجع"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="rtnvalue" SummaryType="Sum" DisplayFormat="{0:n2}" ShowInGroupFooterColumn="إجمالي المرتجع"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="totalQty" SummaryType="Sum" DisplayFormat="{0:n2}" ShowInGroupFooterColumn="صافي الكميه"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="totalvalue" SummaryType="Sum" DisplayFormat="{0:n2}" ShowInGroupFooterColumn="صافي القيمه"></dx:ASPxSummaryItem>
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
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="itemcode" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="invQty" SummaryType="Custom" DisplayFormat=" {0:n2}" />
                    <dx:ASPxSummaryItem FieldName="invvalue" SummaryType="Custom" DisplayFormat=" {0:n2}" />
                    <dx:ASPxSummaryItem FieldName="rtnQty" SummaryType="Custom" DisplayFormat="{0:n2}" />
                    <dx:ASPxSummaryItem FieldName="rtnvalue" SummaryType="Custom" DisplayFormat="{0:n2}" />
                    <dx:ASPxSummaryItem FieldName="totalQty" SummaryType="Custom" DisplayFormat="{0:n2}" />
                    <dx:ASPxSummaryItem FieldName="totalvalue" SummaryType="Custom" DisplayFormat="{0:n2}" />
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white" ></Header>
                </Styles>
            </dx:ASPxGridView>

            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server"  FileName=" الفاتوره" GridViewID="gvs_inv_itms" PaperKind="A4" PaperName=" الفاتوره" RightToLeft="True" Landscape="True">
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
