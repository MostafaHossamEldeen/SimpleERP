<%@ Page Title="تقرير بيانات و أرصدة الأصناف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Stock/st_Items_data_balances_report.aspx.cs" Inherits="VanSales.Stock.st_Items_data_balances_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/stock/st_Items_data_balances_report.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير بيانات و أرصدة الأصناف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Review" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Review_Click" RenderMode="Secondary" Width="20px" ToolTip="استعراض">
                    <ClientSideEvents Click="function(s, e) {
	if (nullToEmpty(rbl_report.GetValue()) == &quot;&quot;) {
        sweetinfo(&quot;برجاء إختيار نوع التقرير&quot;);
        rbl_report.Focus();
        e.rbl_report.Focus();
        return;
    }
}"></ClientSideEvents>
                    <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Width="20px" ToolTip="طباعه">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_clear" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_clear_Click" RenderMode="Secondary" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/eraser-clear.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_docexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_pdfexport_Click"></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxbtnexpandcollapse" runat="server" Height="20px" Width="20px" ToolTip="إظهار التفاصيل" Image-Url="~/Img/Icon/expand.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gv_stItemdata.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gv_stItemdata.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout0" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="">
                        <Items>

                            <dx:LayoutItem Caption="الفرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" NullText="الكل">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="المجموعة">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_groupid" runat="server" ClientInstanceName="cmb_groupid" RightToLeft="True" NullText="المجموعة">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="1" GroupBoxDecoration="Box" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxRadioButtonList ID="rbl_report" ClientInstanceName="rbl_report" runat="server" Border-BorderStyle="None" RepeatDirection="Horizontal">
                                            <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}" Init="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            <Items>
                                                <dx:ListEditItem Text="أرصدة" Value="1"></dx:ListEditItem>
                                                <dx:ListEditItem Text="أصناف وصلت لحد الطلب" Value="2"></dx:ListEditItem>
                                                <dx:ListEditItem Text="أصناف وصلت للحد الأقصى" Value="3"></dx:ListEditItem>
                                                <dx:ListEditItem Text="أرصدة بالتكلفة" Value="4"></dx:ListEditItem>
                                                <dx:ListEditItem Text="أرصدة بسعر البيع" Value="5"></dx:ListEditItem>
                                                <dx:ListEditItem Text="بيانات الأصناف" Value="6"></dx:ListEditItem>
                                            </Items>
                                        </dx:ASPxRadioButtonList>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <asp:Panel ID="PData" runat="server" Font-Bold="True" ForeColor="Black" Direction="RightToLeft" ClientIDMode="Static">
                <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="6" GroupBoxDecoration="Box" Caption="اعمده التقرير" Name="checkboxs">
                            <Items>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemcode" runat="server" OnCheckedChanged="chk_itemcode_CheckedChanged" Text="كود الصنف" AutoPostBack="true" Checked="true" ClientInstanceName="chk_itemcode" class="z">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemcode2" runat="server" Text="كود الصنف 2" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemcode2" class="z">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemcode3" runat="server" Text="كود المورد" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemcode3" class="z">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itembarcode" runat="server" Text="باركود الصنف" AutoPostBack="true"  OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itembarcode" class="z">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itembarcode2" runat="server" Text="باركود الصنف 2" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itembarcode2" class="z">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemname" runat="server" Text="إسم الصنف ع" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemname">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" FieldName="checkb">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemename" runat="server" Text="إسم الصنف E" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemename">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" FieldName="checkb">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemdesc" runat="server" Text="وصف الصنف" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemdesc">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_unitname" runat="server" Text="الوحدة الأساسية" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_unitname">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_groupname" runat="server" Text="المجموعة" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_groupname">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemtypename" runat="server" Text="نوع الصنف" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged"  ClientInstanceName="chk_itemtypename">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_suppname" runat="server" Text="المورد" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_suppname">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemstopname" runat="server" Text="إيقاف الصنف" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemstopname">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_minqty" runat="server" Text="أقل كمية" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_minqty">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_maxqty" runat="server" Text="أكثر كمية" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_maxqty">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_pprice" runat="server" Text="سعر الشراء" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_pprice">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_cprice" runat="server" Text="سعر التكلفة" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_cprice">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_sprice" runat="server" Text="سعر البيع" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_sprice">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_vat" runat="server" Text="الضريبة %" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged"  ClientInstanceName="chk_vat">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_vprice" runat="server" Text="السعر شامل الضريبة" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_vprice">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_fprice" runat="server" Text="سعر الفاتورة" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" Checked="true" ClientInstanceName="chk_fprice">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_descp" runat="server" Text="نسبة الخصم" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_descp">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itempic" runat="server" Text="صورة الصنف" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itempic">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemfield1" runat="server" Text="بيان إضافي 1" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemfield1">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemfield2" runat="server" Text="بيان إضافي 2" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemfield2">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemcatname1" runat="server" Text="تصنيف 1" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemcatname1">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_itemcatname2" runat="server" Text="تصنيف 2" AutoPostBack="true" OnCheckedChanged="chk_itemcode_CheckedChanged" ClientInstanceName="chk_itemcatname2">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxCheckBox ID="chk_all" runat="server" Text="تحديد الكل" AutoPostBack="true" Font-Bold="true" OnCheckedChanged="chk_all_CheckedChanged" ClientInstanceName="chk_all">
                                                <ClientSideEvents ValueChanged="function(s, e) {repotype(s.e);}"></ClientSideEvents>
                                            </dx:ASPxCheckBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
            </asp:Panel>
            <dx:ASPxGridView ID="gv_stItemdata" ClientInstanceName="gv_stItemdata" SettingsText-Title="" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gv_stItemdata_CustomSummaryCalculate" OnDataBinding="gv_stItemdata_DataBinding" KeyFieldName="itemid" Width="100%" RightToLeft="True" CssClass="grid" Visible="false">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="0" Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="1" Caption="كود الصنف">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="2" Caption="إسم الصنف">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="3" Caption="الوحدة">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="balance" VisibleIndex="4" Caption="الرصيد">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="col1" VisibleIndex="5" Caption=""  Visible="false">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="col2" VisibleIndex="6" Caption=""  Visible="false">
                    </dx:GridViewDataTextColumn>
                </Columns>

                <%--<GroupSummary>
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
                <%--<TotalSummary>
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="sinvno" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Custom" DisplayFormat="{0}" />
                </TotalSummary>--%>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridView ID="gv_stItemdatarepo" ClientInstanceName="gv_stItemdatarepo" SettingsText-Title="" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gv_stItemdatarepo_CustomSummaryCalculate" OnDataBinding="gv_stItemdatarepo_DataBinding" Width="100%" RightToLeft="True" CssClass="grid" KeyFieldName="itemid" Visible="false">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupPanel="true" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="0" ReadOnly="True" Visible="False">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="1" Caption="كود الصنف"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemcode2" VisibleIndex="2" Caption="كود الصنف 2" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemcode3" VisibleIndex="3" Caption="كود المورد" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itembarcode" VisibleIndex="4" Visible="false" Caption="باركود الصنف"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itembarcode2" VisibleIndex="5" Caption="باركود الصنف 2" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="6" Visible="false" Caption="إسم الصنف ع"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemename" VisibleIndex="7" Visible="false" Caption="إسم الصنف E" ></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemdesc" VisibleIndex="8" Caption="الوصف" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="10" Caption="الوحدة الأساسية"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="groupname" VisibleIndex="12" Caption="المجموعة"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemtypename" VisibleIndex="14" Visible="false" Caption="نوع الصنف"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="suppname" VisibleIndex="16" Caption="المورد" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemstopname" VisibleIndex="18" Caption="إيقاف الصنف" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="minqty" VisibleIndex="19" Caption="أقل كمية"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="maxqty" VisibleIndex="20" Caption="أقصى كمية"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pprice" VisibleIndex="21" Caption="سعر الشراء"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cprice" VisibleIndex="22" Caption="سعر التكلفة" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sprice" VisibleIndex="23" Caption="سعر البيع"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vat" VisibleIndex="24" Visible="false" Caption="الضريبة %"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vprice" VisibleIndex="25" Caption="السعر شامل الضريبة" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="fprice" VisibleIndex="26" Caption="سعر الفاتورة"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="descp" VisibleIndex="29" Caption="نسبة الخصم" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataImageColumn FieldName="itempic" VisibleIndex="32" Caption="الصورة" CellStyle-CssClass="zoom" Visible="false">
                                <PropertiesImage AlternateTextField="itemname" DescriptionUrlField="itemdesc" ImageAlign="Middle" ImageHeight="50px" ImageWidth="50px" ShowLoadingImage="True">
                                </PropertiesImage>
                                <Settings AllowGroup="False" AllowAutoFilter="False" ShowFilterRowMenu="False" />
                    </dx:GridViewDataImageColumn>
                    <dx:GridViewDataTextColumn FieldName="itemfield1" VisibleIndex="33" Caption="بيان إضافي 1" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemfield2" VisibleIndex="34" Caption="بيان إضافي 2" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemcatname1" VisibleIndex="36" Caption="تصنيف 1" Visible="false"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="itemcatname2" VisibleIndex="38" Caption="تصنيف 2" Visible="false"></dx:GridViewDataTextColumn>
                </Columns>

                <%--<GroupSummary>
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
                <%--<TotalSummary>
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="sinvno" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Custom" DisplayFormat="{0}" />
                </TotalSummary>--%>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvempsalaryExporter" runat="server" FileName="تقرير بيانات و أرصدة الأصناف" PaperKind="A4" PaperName="تقرير بيانات و أرصدة الأصناف" RightToLeft="True" Landscape="True">
                <PageHeader Center="" Font-Bold="true">
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