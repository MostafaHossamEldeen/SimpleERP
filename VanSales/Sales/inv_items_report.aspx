<%@ Page Title="تقرير اصناف المبيعات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inv_items_report.aspx.cs" Inherits="VanSales.Sales.inv_items_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/sales/inv_report.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير اصناف المبيعات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
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
                       
                            
                      <%--      <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_post_stock" runat="server" Text="مرحل مخزون"  AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged" ClientInstanceName="chk_post_stock"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>--%>
                        <%--    <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0"> 
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxCheckBox ID="chk_post_acc" runat="server" Text="مرحل حسابات" AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged"  ClientInstanceName="chk_post_acc"></dx:ASPxCheckBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>--%>
                           <%--      <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                          <dx:ASPxCheckBox ID="chk_post_all" runat="server" Text="الكل" AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged" ClientInstanceName="chk_post_all"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>--%>
                      
                            <dx:LayoutItem Caption="من">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxDateEdit ID="txt_fromdate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_fromdate">
                                        </dx:ASPxDateEdit>


                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                         <%--   <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>--%>
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
                      <%--      <dx:LayoutItem Caption="المندوب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                  
                                        <dx:ASPxTextBox ID="txt_smanid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_smanid" AutoPostBack="false">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>


                                        <button type="button" id="puop_sman" data-name="cust" onclick="createPopUp($(this))" data-tablename="s_sman_sel_search" data-displayfields="smanid,smanname,smanmob" data-displayfieldshidden="smantype"
                                            data-displayfieldscaption="كود المندوب,إسم المندوب,التليفون" data-bindcontrols="txt_smanid;HF_smanid"
                                            data-bindfields="smanname;smanid" data-pkfield="smanid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                        </button>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                </ParentContainerStyle>

                            </dx:LayoutItem>--%>
                        </Items>
                    </dx:LayoutGroup>
               <%--     <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" Caption="">
                       
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>--%>
                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="Box" Caption="اعمده التقرير" Name="checkboxs" >
                        <%--ParentContainerStyle-Paddings-PaddingRight="500"--%>
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_itemcode" runat="server"  OnCheckedChanged="chk_itemcode_CheckedChanged" Text="كود الصنف" AutoPostBack="true" Checked="true" ClientInstanceName="chk_itemcode"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_itemname" runat="server" Text="اسم الصنف" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_itemname"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_unitname" runat="server" Text="الوحده" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged"  ClientInstanceName="chk_unitname"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_qty" runat="server" Text="الكميه" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_qty"   ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_price" runat="server" Text="السعر" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged"  ClientInstanceName="chk_price"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_value" runat="server" Text="الاجمالى" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_value"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_discvalue" runat="server" Text="الخصم" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged"  ClientInstanceName="chk_discvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                               <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_discp" runat="server" Text="نسبه الخصم" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_discp"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_netvalue" runat="server" Text="الصافى" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_netvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vatvalue" runat="server" Text="الضريبه" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_vatvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sinvno" runat="server" Text="رقم الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_sinvno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_invdate" runat="server" Checked="true" Text="تاريخ الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_invdate"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custid" runat="server" Text="كود العميل" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_custid"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custname" runat="server" Text="اسم العميل" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_custname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_branchname" runat="server" Text="الفرع" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_branchname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_icost" runat="server" Text="التكلفه" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_icost"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_itemnotes" runat="server" Text="الملاحظات" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged"    ClientInstanceName="chk_itemnotes"></dx:ASPxCheckBox>
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
            
            <dx:ASPxGridView ID="gvs_inv_itms" ClientInstanceName="gvs_inv_itms" SettingsText-Title="تقرير اصناف المبيعات" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gvs_inv_itms_CustomSummaryCalculate" OnDataBinding="gvs_inv_itms_DataBinding" Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid">



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

                    <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="2" Caption="كود الصنف" >
                       <%-- <PropertiesHyperLinkEdit NavigateUrlFormatString="~\Sales\inv.aspx?sinvno={0}" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>--%> <%--PropertiesTextEdit-DisplayFormatString="{0:d}"--%>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="3"  Caption="اسم الصنف" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="unitname" Visible="false" VisibleIndex="4" Caption="الوحده"   >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="5"  Caption="الكمية" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="price" Visible="false" VisibleIndex="6" Caption="السعر" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="value" VisibleIndex="7" Caption="الاجمالى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="discp" VisibleIndex="8"  Visible="false" Caption="نسبه الخصم" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="discvalue" Visible="false" VisibleIndex="9" Caption="الخصم" >
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="netvalue" VisibleIndex="10"   Caption="الصافى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="11" Caption="الضريبة" >
                    </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="icost" VisibleIndex="12" Visible="false" Caption="التكلفه" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataHyperLinkColumn FieldName="sinvno" VisibleIndex="13"   Caption="رقم الفاتوره" >
                   <%--<PropertiesHyperLinkEdit NavigateUrlFormatString="~\Sales\inv.aspx?sinvno={0}" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>--%>
                         <PropertiesHyperLinkEdit NavigateUrlFormatString="javascript:ShowDetailPopup('{0}');" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>
                        </dx:GridViewDataHyperLinkColumn>
                     <dx:GridViewDataTextColumn FieldName="invdate" VisibleIndex="14" Caption="التاريخ"   PropertiesTextEdit-DisplayFormatString="{0:d}" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="15" Visible="false"  >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="16" Visible="false" Caption="الفرع" >
                    </dx:GridViewDataTextColumn>
                   
                    <dx:GridViewDataTextColumn FieldName="custid" VisibleIndex="17" Visible="false" Caption="كود العميل"   >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custname" VisibleIndex="18" Visible="false" Caption="اسم العميل" >
                    </dx:GridViewDataTextColumn>
                

                    <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="19" Visible="false" Caption="الملاحظات" >
                    </dx:GridViewDataTextColumn>
          <%--           <dx:GridViewDataTextColumn FieldName="sinvid" VisibleIndex="24" Visible="false" >
                    </dx:GridViewDataTextColumn>--%>
                </Columns>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="itemcode" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="كود الصنف"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="qty" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الكمية"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="value" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الاجمالى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="netvalue" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الصافى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Sum" DisplayFormat="{0}" ShowInGroupFooterColumn="الضريبة"></dx:ASPxSummaryItem>
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
                    <dx:ASPxSummaryItem FieldName="qty" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="value" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="netvalue" SummaryType="Custom" DisplayFormat="{0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Custom" DisplayFormat="{0}" />
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
