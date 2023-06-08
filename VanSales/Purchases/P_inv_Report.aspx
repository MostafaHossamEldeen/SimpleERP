<%@ Page Title="تقرير فواتير المشتريات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="P_inv_Report.aspx.cs" Inherits="VanSales.Purchases.P_inv_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير فواتير المشتريات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
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
                    <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvs_inv.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvs_inv.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
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
                                        <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" TextField="branchname" NullText="الكل" NullTextDisplayMode="UnfocusedAndFocused" NullTextStyle-ForeColor="Black" Theme="MaterialCompact" ValueField="branchid" SelectedIndex="0">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_post_stock" runat="server" Text="مرحل مخزون" AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged" ClientInstanceName="chk_post_stock"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_post_acc" runat="server" Text="مرحل حسابات" AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged" ClientInstanceName="chk_post_acc"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_post_all" runat="server" Text="الكل" AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged" ClientInstanceName="chk_post_all"></dx:ASPxCheckBox>
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
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المورد">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_suppname" ClientInstanceName="txt_suppname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <button type="button" id="puop_supp" title="بحث" data-name="supp" onclick="createPopUp($(this),'popupModalsearch')" data-tablename="p_supplier_sel_search" data-displayfields="suppid,suppname,suppvatno,country"
                                            data-displayfieldshidden="" data-displayfieldscaption="كود المورد,إسم المورد,الرقم الضريبي,المدينة" data-bindcontrols="txt_suppid;HF_suppid;txt_suppname;txt_suppvat"
                                            data-bindfields="suppid;suppid;suppname;suppvatno" data-pkfield="suppid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                        </button>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                </ParentContainerStyle>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="Box" Caption="اعمده التقرير" Name="checkboxs">
                        <Items>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pinvno" runat="server" OnCheckedChanged="chk_pinvno_CheckedChanged" Text="رقم الفاتوره" AutoPostBack="true" Checked="true" ClientInstanceName="chk_pinvno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pinvdate" runat="server" Text="التاريخ" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_pinvdate"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pinvpayname" runat="server" Text="نوع الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_pinvpayname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_branchname" runat="server" Text="الفرع" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_branchname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_ccname" runat="server" Text="مركز التكلفه" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_ccname" class="z"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_suppname" runat="server" Text="اسم المورد" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_suppname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pinvdocno" runat="server" Text="الرقم اليدوى" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_sinvdocno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_suppid" runat="server" Text="كود المورد" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_suppid"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_suppvat" runat="server" Text="الرقم الضريبى للمورد" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_suppvat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_puser" runat="server" Text="منشئ الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_puser"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vattypename" runat="server" Text="نوع الضريبه" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_vattypename"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_netbvat" runat="server" Text="الاجمالى" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_netbvat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_netavat" runat="server" Text="الصافى" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_netavat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vatvalue" runat="server" Text="الضريبه" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_vatvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_restvalue" runat="server" Text="الباقى" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_restvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_postst" runat="server" Text="مرحل محزون" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_postst"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_postacc" runat="server" Text="مرحل حسابات" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_postacc"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_pnotes" runat="server" Text="الملاحظات" AutoPostBack="true" OnCheckedChanged="chk_pinvno_CheckedChanged" ClientInstanceName="chk_pnotes"></dx:ASPxCheckBox>
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
            <asp:HiddenField ID="HF_suppid" ClientIDMode="Static" runat="server" />
            <dx:ASPxGridView ID="gvs_inv" ClientInstanceName="gvs_inv" SettingsText-Title="تقرير فواتير المشتريات" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gvs_inv_CustomSummaryCalculate" OnDataBinding="gvs_inv_DataBinding" Width="100%" KeyFieldName="pinvid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid">
                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" ShowGroupPanel="True" />
                <SettingsDataSecurity AllowDelete="true" AllowEdit="False" AllowInsert="False" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="pnaturename" Visible="false" GroupIndex="0" SortIndex="0" ReadOnly="True" Caption=" " VisibleIndex="0" SortOrder="Ascending" Settings-AllowDragDrop="False">
                        <EditFormSettings Visible="False" />
                        <Settings AutoFilterCondition="Contains"></Settings>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                        <CellStyle HorizontalAlign="Center" VerticalAlign="Middle"></CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataHyperLinkColumn FieldName="pinvno" VisibleIndex="1" Caption="رقم الفاتوره">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="~\Purchases\P_Inv.aspx?pinvno={0}" Target="_parent" TextField="pinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>
                    </dx:GridViewDataHyperLinkColumn>
                    <dx:GridViewDataTextColumn FieldName="pinvdocno" VisibleIndex="2" Visible="false" Caption="الرقم اليدوى">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="5" PropertiesTextEdit-DisplayFormatString="{0:d}" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="6" Caption="الفرع">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="7" Visible="false" Caption="مركز التكلفه">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pinvpayname" VisibleIndex="8" Caption="نوع الفاتوره">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="suppid" VisibleIndex="9" Caption="كود المورد" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="suppname" VisibleIndex="10" Caption="اسم المورد">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="suppvat" VisibleIndex="11" Caption="الرقم الضريبى" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="puser" VisibleIndex="12" Visible="false" Caption="منشئ الفاتوره">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vattypename" VisibleIndex="16" Visible="false" Caption="نوع الضريبه">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="netbvat" VisibleIndex="17" Caption="الاجمالى">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="18" Caption="الضريبه">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="netavat" VisibleIndex="19" Caption="الصافى">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="restvalue" VisibleIndex="20" Caption="الباقى" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="pnotes" VisibleIndex="21" Caption="الملاحظات" Visible="False">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataCheckColumn FieldName="postst" Caption="مرحل مخزون" Visible="False" VisibleIndex="13">
                        <PropertiesCheckEdit AllowGrayedByClick="False" DisplayTextChecked="مرحل" DisplayTextUnchecked="غير مرحل" ConvertEmptyStringToNull="False"></PropertiesCheckEdit>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataCheckColumn FieldName="postacc" Caption="مرحل حسابات" Visible="False" VisibleIndex="15">
                        <PropertiesCheckEdit AllowGrayedByClick="False" ConvertEmptyStringToNull="False" DisplayTextChecked="مرحل" DisplayTextUnchecked="غير مرحل"></PropertiesCheckEdit>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataDateColumn FieldName="pinvdate" Caption="التاريخ" VisibleIndex="4">
                        <PropertiesDateEdit DisplayFormatString="{0:yyyy-MM-dd}"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                </Columns>
                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="pinvno" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="رقم الفاتوره"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الاجمالى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Sum" DisplayFormat=" {0}" ShowInGroupFooterColumn="الصافى"></dx:ASPxSummaryItem>
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Sum" DisplayFormat="{0}" ShowInGroupFooterColumn="الضريبه"></dx:ASPxSummaryItem>
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
                    <dx:ASPxSummaryItem FieldName="pinvno" SummaryType="Count" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Custom" DisplayFormat="{0}" />
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Header>
                </Styles>
            </dx:ASPxGridView>
            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server" FileName=" الفاتوره" GridViewID="gvs_inv" PaperKind="A4" PaperName=" الفاتوره" RightToLeft="True" Landscape="True">
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

