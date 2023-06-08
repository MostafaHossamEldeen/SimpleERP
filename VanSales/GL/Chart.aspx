<%@ Page Title="دليل الحسابات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="VanSales.GL.Chart" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/GL/Chart.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="Lbl_Tittle" runat="server" Text="دليل الحسابات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton ID="btn_Save" runat="server" AutoPostBack="False" ClientInstanceName="btn_Save" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ" OnClick="btn_Save_Click">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_addnew" runat="server" AutoPostBack="False" ClientInstanceName="btn_addnew" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {delchart();}" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <button type="button" id="PopUpchartid" title="بحث" data-name="chart" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldscaption="كود الحساب,إسم الحساب"
                    data-displayfieldshidden="chartid" data-bindcontrols="hf_chartid" data-bindfields="chartid"
                    data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="hf_legertype" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <asp:HiddenField runat="server" Value="3" ClientIDMode="Static" ID="hf_legertype" />
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_excel" runat="server" Height="20px" Width="20px" ToolTip="تصدير Excel" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_excel_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_word" runat="server" Height="20px" Width="20px" ToolTip="تصدير وورد" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_word_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdf" runat="server" Height="20px" Width="20px" ToolTip="تصدير PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdf_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" Height="20px" Width="20px" ToolTip="طباعة" Image-Url="~/Img/Icon/print.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_print_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {trlchart.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {trlchart.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                </dx:ASPxButton>
                <script type="text/javascript">
                    function InitPopupMenuHandler(s, e) {
                        imgButton.addEventListener('contextmenu', function (evt) { ASPxClientUtils.PreventEventAndBubble(evt) });
                    }
                </script>
                <dx:ASPxPopupMenu ID="ASPxPopupMenu1" runat="server" ClientInstanceName="ASPxPopupMenuClientControl" PopupElementID="btn_addnew" ShowPopOutImages="True" PopupHorizontalAlign="RightSides" PopupVerticalAlign="Below" PopupAction="MouseOver" OnItemClick="ASPxPopupMenu1_ItemClick">
                    <Items>
                        <dx:MenuItem Text="رئيسي" Name="primary">
                        </dx:MenuItem>
                        <dx:MenuItem Text="تابع" Name="child">
                        </dx:MenuItem>
                    </Items>
                </dx:ASPxPopupMenu>
                <br />
            </div>
            <br />
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                        <Items>

                            <dx:LayoutItem Caption="" ColumnSpan="2">
                                <LayoutItemNestedControlCollection >
                                    <dx:LayoutItemNestedControlContainer BorderStyle="Solid" BorderWidth="1px">
                                    <%--    <div style="border:1px Solid #DFDFDF; padding:5px">
                                                             <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="رفع الحسابات النهائيه"></dx:ASPxLabel>
                                                <asp:FileUpload ID="FileUpload2" runat="server" />
 
                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>
                                            </div>--%>

                                        <dx:ASPxTreeList ID="trlchart"  SettingsBehavior-AllowFocusedNode="true" ClientInstanceName="trlchart" runat="server" AutoGenerateColumns="False" OnDataBinding="trlchart_DataBinding" KeyFieldName="chartid" ParentFieldName="nodeid" DataCacheMode="Disabled" Cursor="pointer" ToolTip="دليل الحسابات" ClientSideEvents-NodeDblClick="function(s,e){trlchart_Bind_dtl(s,e);}" OnCustomCallback="trlchart_CustomCallback" KeyboardSupport="true" OnHtmlRowPrepared="trlchart_HtmlRowPrepared" OnHtmlDataCellPrepared="trlchart_HtmlDataCellPrepared" Settings-GridLines="Both" EnableCallbacks="False" Images-ExpandedButton-Url="~/Img/Icon/ExpandedButton.svg" Images-ExpandedButton-Width="15" Images-CollapsedButton-Url="~/Img/Icon/CollapsedButton.svg" Images-CollapsedButton-Width="15" Images-ExpandedButtonRtl-Url="~/Img/Icon/ExpandedButton.svg" Images-ExpandedButtonRtl-Width="15" Images-CollapsedButtonRtl-Url="~/Img/Icon/CollapsedButton.svg" Images-CollapsedButtonRtl-Width="15">
                                            <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                                            <SettingsPager AlwaysShowPager="True" PageSize="20">
                                                <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                                            </SettingsPager>
                                            <SettingsBehavior EnableCustomizationWindow="True" AllowFocusedNode="True" />
                                            <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                                            <Columns>
                                                <dx:TreeListTextColumn FieldName="chartid" AutoFilterCondition="Default" ShowInFilterControl="Default" VisibleIndex="0" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="chartcode" AutoFilterCondition="Default" ShowInFilterControl="Default" VisibleIndex="1" Caption="كود الحساب">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="chartname" AutoFilterCondition="Default" ShowInFilterControl="Default" VisibleIndex="2" Caption="إسم الحساب">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="nodeid" AutoFilterCondition="Default" ShowInFilterControl="Default" VisibleIndex="3" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:TreeListTextColumn>
                                                <dx:TreeListTextColumn FieldName="balance" AutoFilterCondition="Default" ShowInFilterControl="Default" VisibleIndex="4" Caption="الرصيد">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </dx:TreeListTextColumn>
                                            </Columns>
                                            <Styles>
                                                <Footer Font-Bold="True">
                                                </Footer>
                                                <GroupFooter Font-Bold="False">
                                                </GroupFooter>
                                                <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                                            </Styles>
                                            <SettingsPager Mode="ShowPager"></SettingsPager>
                                            <SettingsSelection Enabled="True" AllowSelectAll="false" Recursive="false"></SettingsSelection>
                                        </dx:ASPxTreeList>
                                        <dx:ASPxTreeListExporter ID="trlchartExporter" TreeListID="trlchart" runat="server" FileName="دليل الحسابات" Settings-PageSettings-PaperKind="A4" Settings-RightToLeft="True" Settings-AutoWidth="False" OnRenderBrick="trlchartExporter_RenderBrick"></dx:ASPxTreeListExporter>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="كود الحساب"></dx:ASPxLabel>
                                        <asp:HiddenField ID="hf_chartid" runat="server" ClientIDMode="Static" Value="0" />
                                        <dx:ASPxTextBox ID="txt_chartcode" ClientInstanceName="txt_chartcode" runat="server" Width="100%">
                                            <ClientSideEvents KeyPress="function(s, e) {numonly(s, e);}" GotFocus="function(s, e) {txt_chartcode.SelectAll();}" />
                                        </dx:ASPxTextBox>
                                        <br />
                                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="إسم الحساب"></dx:ASPxLabel>
                                        <dx:ASPxTextBox ID="txt_chartname" ClientInstanceName="txt_chartname" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <br />
                                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="إسم الحساب E"></dx:ASPxLabel>
                                        <dx:ASPxTextBox ID="txt_chartename" ClientInstanceName="txt_chartename" runat="server" Width="100%"></dx:ASPxTextBox>
                                        <br />
                                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="يتبع حساب"></dx:ASPxLabel>
                                        <button type="button" id="PopUpNodeid" title="بحث" data-name="node" data-tablename="gl_chart_sel_nodeid" data-displayfields="chartcode,chartname"
                                            data-displayfieldscaption="كود الحساب,إسم الحساب" data-displayfieldshidden="chartid,chartnamedisplay,acctype,accnature,newlevel;sys_chartlvl"
                                            data-bindcontrols="hf_nodeid;txt_nodecode;cmb_acctype;cmb_accnature;cmb_levelno;hf_sys_chartlvl" data-bindfields="chartid;chartnamedisplay;acctype;accnature;newlevel;sys_chartlvl"
                                            data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="chartid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                                        </button>
                                        <br />
                                        <br />
                                        <asp:HiddenField ID="hf_nodeid" runat="server" ClientIDMode="Static" />
                                        <asp:HiddenField ID="hf_sys_chartlvl" runat="server" ClientIDMode="Static" />
                                        <dx:ASPxTextBox ID="txt_nodecode" ClientInstanceName="txt_nodecode" runat="server" Width="100%" ClientReadOnly="true">
                                            <ClientSideEvents Init="function(s, e) {NodeValidate();}" />
                                        </dx:ASPxTextBox>
                                        <br />
                                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="نوع الحساب"></dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="cmb_acctype" ClientInstanceName="cmb_acctype" runat="server" Width="100%"></dx:ASPxComboBox>
                                        <br />
                                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="طبيعة الحساب"></dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="cmb_accnature" ClientInstanceName="cmb_accnature" runat="server" Width="100%"></dx:ASPxComboBox>
                                        <br />
                                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="مستوى الحساب"></dx:ASPxLabel>
                                        <dx:ASPxLabel ID="lblfinallevel" ClientInstanceName="lblfinallevel" runat="server" Style="padding-right: 50px" ForeColor="#009933" Font-Names="Aldhabi" Font-Size="14"></dx:ASPxLabel>
                                        <dx:ASPxComboBox ID="cmb_levelno" ClientInstanceName="cmb_levelno" runat="server" Width="100%" ClientReadOnly="true" AutoPostBack="true">
                                        </dx:ASPxComboBox>
                                        <br />
                                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="الرصيد"></dx:ASPxLabel>
                                        <dx:ASPxTextBox ID="txt_balance" ClientInstanceName="txt_balance" runat="server" Width="100%" ClientReadOnly="true" Text="0.00">
                                        </dx:ASPxTextBox>
                                        <br />
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <div dir="rtl">
                    <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True" >
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="رفع الاكسيل">
                            <Items>
                                <dx:LayoutItem Caption="" ColumnSpan="2" CaptionSettings-Location="Left"  >
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                   <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="رفع الحسابات النهائيه"></dx:ASPxLabel>
                                                <asp:FileUpload ID="FileUpload2" runat="server" />
 
                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                    
 </Items>
                            </dx:LayoutGroup>
                        </Items>
                    
                    </dx:ASPxFormLayout>
                </div>
         <%--       <div style="border:1px Solid #DFDFDF; padding:5px" dir="ltr">
                                                             <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="رفع الحسابات النهائيه"></dx:ASPxLabel>
                                                <asp:FileUpload ID="FileUpload2" runat="server" />
 
                                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>
                                            </div>--%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_word" />
            <asp:PostBackTrigger ControlID="btn_pdf" />
            <asp:PostBackTrigger ControlID="btn_excel" />
            <asp:PostBackTrigger ControlID="btn_print" />
            <asp:PostBackTrigger ControlID="ASPxFormLayout1$btn_attach" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>