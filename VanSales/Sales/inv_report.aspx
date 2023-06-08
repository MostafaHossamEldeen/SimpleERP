<%@ Page Title="تقرير فواتير المبيعات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inv_report.aspx.cs" Inherits="VanSales.Sales.inv_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/sales/inv_report.js"></script>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="تقرير فواتير المبيعات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_preview" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="استعراض">

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
                        <ClientSideEvents Click="function(s, e) {if (this.ToolTip == &quot;اظهار الكل&quot;) {gvs_inv.CollapseAll();this.ToolTip = &quot;اخفاء الكل&quot;;}else {gvs_inv.ExpandAll();this.ToolTip = &quot;اظهار الكل&quot;;}}"></ClientSideEvents>
                    </dx:ASPxButton>
                <%--  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
 
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                --%>
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
                         <%--   <dx:LayoutGroup ColCount="10" GroupBoxDecoration="Box" Caption="">
                        <Items>--%>
                            
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_post_stock" runat="server" Text="مرحل مخزون"  AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged" ClientInstanceName="chk_post_stock"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0"> 
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxCheckBox ID="chk_post_acc" runat="server" Text="مرحل حسابات" AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged"  ClientInstanceName="chk_post_acc"></dx:ASPxCheckBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                 <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                          <dx:ASPxCheckBox ID="chk_post_all" runat="server" Text="الكل" AutoPostBack="True" OnCheckedChanged="chk_post_stock_CheckedChanged" ClientInstanceName="chk_post_all"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                        <%--</Items>
                    </dx:LayoutGroup>--%>
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
                            <dx:LayoutItem Caption="المندوب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <%--  <dx:ASPxComboBox ID="cmb_smanid" runat="server"  ClientInstanceName="cmb_smanid" RightToLeft="True" TextField="smanname" Theme="MaterialCompact" ValueField="smanid" AutoPostBack="false">
                                            </dx:ASPxComboBox>--%>
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

                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
          <%--          <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" Caption="">
                         
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
                                        <dx:ASPxCheckBox ID="chk_sinvno" runat="server"  OnCheckedChanged="chk_sinvno_CheckedChanged" Text="رقم الفاتوره" AutoPostBack="true" Checked="true" ClientInstanceName="chk_sinvno" class="z" ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sinvdata" runat="server" Text="التاريخ" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_sinvdata" class="z"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sinvpayname" runat="server" Text="نوع الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_sinvpayname" class="z"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_branchname" runat="server" Text="الفرع" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged"  ClientInstanceName="chk_branchname" class="z"  ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_ccname" runat="server" Text="مركز التكلفه" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged"  ClientInstanceName="chk_ccname" class="z" ></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custname" runat="server" Text="اسم العميل" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_custname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" FieldName="checkb">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sinvdocno" runat="server" Text="الرقم اليدوى" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_sinvdocno"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" FieldName="checkb">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_sinvtime" runat="server" Text="الوقت" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_sinvtime"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custid" runat="server" Text="كود العميل" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged"  ClientInstanceName="chk_custid"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custvat" runat="server" Text="الرقم الضريبى للعميل" AutoPostBack="true"  OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_custvat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custadd" runat="server" Text=" عنوان العميل" AutoPostBack="true"  OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_custadd"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_custmobile" runat="server" Text="جوال العميل" AutoPostBack="true"  OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_custmobile"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_suser" runat="server" Text="منشئ الفاتوره" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_suser"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_smanid" runat="server" Text="كود المندوب" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_smanid"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_smanname" runat="server" Text="اسم المندوب" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged"   ClientInstanceName="chk_smanname"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_netbvat" runat="server" Text="الاجمالى" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_netbvat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_netavat" runat="server" Text="الصافى" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_netavat"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_vatvalue" runat="server" Text="الضريبه" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_vatvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_restvalue" runat="server" Text="الباقى" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" Checked="true" ClientInstanceName="chk_restvalue"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_postst" runat="server" Text="مرحل محزون" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_postst"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_posyacc" runat="server" Text="مرحل حسابات" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_posyacc"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="chk_snotes" runat="server" Text="الملاحظات" AutoPostBack="true" OnCheckedChanged="chk_sinvno_CheckedChanged" ClientInstanceName="chk_snotes"></dx:ASPxCheckBox>
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
            <asp:HiddenField ID="HF_smanid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_countchked" ClientIDMode="Static" runat="server" />
            <dx:ASPxGridView ID="gvs_inv" ClientInstanceName="gvs_inv" SettingsText-Title="تقرير فواتير المبيعات" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " OnCustomSummaryCalculate="gvs_inv_CustomSummaryCalculate" OnDataBinding="gvs_inv_DataBinding" Width="100%" KeyFieldName="sinvid" Theme="MaterialCompact" RightToLeft="True" CssClass="grid">



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

<%--                    <dx:GridViewDataHyperLinkColumn FieldName="sinvno" VisibleIndex="2" Caption="رقم الفاتوره"   >
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="~\Sales\inv.aspx?sinvno={0}" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>
                    </dx:GridViewDataHyperLinkColumn>--%>
                    
                    <dx:GridViewDataHyperLinkColumn FieldName="sinvno" VisibleIndex="2" Caption="رقم الفاتوره"   >
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="javascript:ShowDetailPopup('{0}');" Target="_parent" TextField="sinvno">
                            <Style Font-Bold="True"></Style>
                        </PropertiesHyperLinkEdit>
                    </dx:GridViewDataHyperLinkColumn>
                    <dx:GridViewDataTextColumn FieldName="sinvdocno" VisibleIndex="3"  Caption="الرقم اليدوى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sinvdata" VisibleIndex="4" Caption="التاريخ" PropertiesTextEdit-DisplayFormatString="{0:d}"  >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sinvtime" VisibleIndex="5" Visible="false" Caption="الوقت" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="6" Visible="false" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="7" Visible="false" Caption="الفرع" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="8" Visible="false" Caption="مركز التكلفه" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="sinvpayname" VisibleIndex="9"  Caption="نوع الفاتوره" >
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="custid" VisibleIndex="10" Visible="false" Caption="كود العميل" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custname" VisibleIndex="11" Visible="false" Caption="اسم العميل" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custvat" VisibleIndex="12" Visible="false" Caption="الرقم الضريبى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custadd" VisibleIndex="13" Visible="false" Caption="عنوان العميل" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="custmobile" VisibleIndex="14" Visible="false" Caption="جوال العميل" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="smanid" VisibleIndex="15"  Caption="كود المندوب" Visible="false" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="smanname" VisibleIndex="16" Visible="false" Caption="المندوب"   >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="suser" VisibleIndex="17" Visible="false" Caption="منشئ الفاتوره" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="postst" VisibleIndex="18" Visible="false" Caption="مرحل مخزون" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="posyacc" VisibleIndex="19" Visible="false" Caption="مرحل حسابات" >
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn FieldName="netbvat" VisibleIndex="20" Caption="الاجمالى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="21" Caption="الضريبه" >
                    </dx:GridViewDataTextColumn> 
                    <dx:GridViewDataTextColumn FieldName="netavat" VisibleIndex="22" Caption="الصافى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="restvalue" VisibleIndex="23"  Caption="الباقى" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="snotes" VisibleIndex="24" Visible="false" Caption="الملاحظات" >
                    </dx:GridViewDataTextColumn>
          <%--           <dx:GridViewDataTextColumn FieldName="sinvid" VisibleIndex="24" Visible="false" >
                    </dx:GridViewDataTextColumn>--%>
                </Columns>

                <GroupSummary>
                    <dx:ASPxSummaryItem FieldName="sinvno" SummaryType="Count" DisplayFormat="العدد = 0" ShowInGroupFooterColumn="رقم الفاتوره"></dx:ASPxSummaryItem>
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
                    <dx:ASPxSummaryItem SummaryType="Count" FieldName="sinvno" DisplayFormat="العدد الكلي = 0" />
                    <dx:ASPxSummaryItem FieldName="netbvat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="netavat" SummaryType="Custom" DisplayFormat=" {0}" />
                    <dx:ASPxSummaryItem FieldName="vatvalue" SummaryType="Custom" DisplayFormat="{0}" />
                </TotalSummary>
                <Styles>
                    <GroupRow Font-Bold="True" ForeColor="#000000"></GroupRow>
                    <GroupFooter Font-Bold="True" Font-Size="Medium" ForeColor="#000066"></GroupFooter>
                    <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                    <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white" ></Header>
                </Styles>
            </dx:ASPxGridView>

            <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server"  FileName=" الفاتوره" GridViewID="gvs_inv" PaperKind="A4" PaperName=" الفاتوره" RightToLeft="True" Landscape="True">
                <PageHeader Center=" الفاتوره" Font-Bold="true" >
                </PageHeader>
                <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                </PageFooter>
                
                
            </dx:ASPxGridViewExporter>
            <%--   <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup" Width="800px" Height="800px">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>--%>
        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_docexport" />
            <asp:PostBackTrigger ControlID="btn_pdfexport" />
            <%--<asp:PostBackTrigger ControlID="btn_print" />--%>

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
