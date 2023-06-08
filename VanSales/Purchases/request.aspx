<%@ Page Title="طلبيات الشراء" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="VanSales.request.request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/request/request.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="Lbl_Tittle" runat="server" Text="طلبيات الشراء" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton ID="btn_Save" runat="server" AutoPostBack="False" ClientInstanceName="btn_Save" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ" OnClick="btn_Save_Click">
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_addnew" runat="server" UseSubmitBehavior="false" AutoPostBack="False" ClientInstanceName="btn_addnew" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_delete" runat="server" UseSubmitBehavior="false" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/P_Request/P_DelRequest','HF_reqid')}" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <button type="button" id="PopUpControl1" title="بحث" data-name="nav" data-tablename="p_request_sel_popup" data-displayfields="reqno,reqdocno,reqdate,branchname"
                    data-displayfieldshidden="reqid,branchid,reqdesc,userreq,reqcase,reqaction" data-displayfieldscaption="كود الطلبية,الكود اليدوي,التاريخ,الفرع"
                    data-bindcontrols="HF_reqid;txt_reqno;txt_reqdocno;txt_reqdate;cmb_branchid;txt_reqdesc;txt_userreq;rbl_reqcase;lbl_reqaction" data-bindfields="reqid;reqno;reqdocno;reqdate;branchid;reqdesc;userreq;reqcase;reqaction"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="reqid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                </button>
                <dx:ASPxButton ID="btn_transfer" UseSubmitBehavior="false" runat="server" AutoPostBack="False" ClientInstanceName="btn_transfer" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="إذن تحويل">
                    <ClientSideEvents Click="function(s, e) {transfer();}" />
                    <Image Height="20px" Url="~/img/icon/exchange.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton ID="btn_pinv" UseSubmitBehavior="false" runat="server" AutoPostBack="False" ClientInstanceName="btn_pinv" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="فاتورة شراء" OnClick="btn_pinv_Click">
                    <Image Height="20px" Url="~/img/icon/paid.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />
            </div>
            <br />
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="Box" Caption="البيانات الاساسيه">
                        <Items>
                            <dx:LayoutItem Caption="رقم الطلبية">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ValidationSettings-CausesValidation="true" ID="txt_reqno" runat="server" ClientInstanceName="txt_reqno" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">
                                            <ClientSideEvents KeyDown="function(s, e) {preventwrite(s, e)}" ValueChanged="function(s,e){Refreshdata(s,e)}"></ClientSideEvents>
                                        </dx:ASPxTextBox>
                                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_reqid" Value="0" />
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="رقم الطلبية اليدوي">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_reqdocno" ClientInstanceName="txt_reqdocno" runat="server" Theme="MaterialCompact" Style="margin-right: 0px">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="التاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_reqdate" runat="server" ValidateRequestMode="Disabled" RightToLeft="True" Theme="MaterialCompact" ClientInstanceName="txt_reqdate">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="الفرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="الملاحظات" ColumnSpan="4">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_reqdesc" ClientInstanceName="txt_reqdesc" runat="server" Theme="MaterialCompact" Width="100%">
                                        </dx:ASPxMemo>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المستخدم" Paddings-PaddingTop="10">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_userreq" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_userreq">
                                            <ClientSideEvents Init="function(s, e) {txt_userreq.GetInputElement().readOnly = true;}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="حالة الطلب" ParentContainerStyle-Paddings-PaddingBottom="16">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxRadioButtonList ID="rbl_reqcase" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None" RepeatLayout="OrderedList" ClientInstanceName="rbl_reqcase">
                                            <Items>
                                                <dx:ListEditItem Selected="true" Text="مفتوح" Value="True"></dx:ListEditItem>
                                                <dx:ListEditItem Text="مغلق" Value="False"></dx:ListEditItem>
                                            </Items>
                                        </dx:ASPxRadioButtonList>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" Paddings-PaddingTop="16">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxLabel ID="lbl_reqaction" runat="server" ClientInstanceName="lbl_reqaction" Font-Bold="True" Font-Size="Medium" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933"></dx:ASPxLabel>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <br />
            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none;" ClientIDMode="Static">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="12" GroupBoxDecoration="box" Caption="تفاصيل الطلبية" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemid" runat="server" Theme="MaterialCompact" AutoPostBack="false" ClientInstanceName="txt_itemid">
                                                    <ClientSideEvents TextChanged="function(s,e){setItemData(s,e)}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="20">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <button type="button" id="Pop_items" title="بحث" data-name="itm" onclick="createPopUp($(this))" data-tablename="st_itemunit_sel_pop_req" data-displayfields="itemcode,itemname,unitname,factor" data-displayfieldshidden="itemid,unitid"
                                                    data-displayfieldscaption="كود الصنف,اسم الصنف,الوحده,معامل التحويل" data-bindcontrols="txt_itemid;txt_item_name;HF_itemid;HF_factor;HF_unitid;txt_unitname"
                                                    data-bindfields="itemcode;itemname;itemid;factor;unitid;unitname" data-pkfield="itemunitid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                                </button>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصنف" Width="20%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_item_name" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_item_name">
                                                    <ClientSideEvents Init="function(s, e) {txt_item_name.GetInputElement().readOnly = true; }" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الوحدة">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_unitname" ClientInstanceName="txt_unitname" runat="server" Theme="MaterialCompact">
                                                    <ClientSideEvents Init="function(s, e) {txt_unitname.GetInputElement().readOnly = true; }" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الكميه">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact">
                                                    <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e)}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="ملاحظات" Width="20%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemnotes" ClientInstanceName="txt_itemnotes" runat="server" Theme="MaterialCompact">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btn_save_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_save_dtls" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) { validate(s,e) }" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btn_new_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_new_dtls" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px">
                                                    <ClientSideEvents Click="function(s, e) {clear_item();}"></ClientSideEvents>
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px">
                                                    <ClientSideEvents Click="function(s, e) {getgvdtlrow();delData_Detail('/VanSalesService/P_Request/P_DelRequestdtl', 'reqdtlis', 'HF_reqdtlis',gv_reqdtls) }" />
                                                    <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_unitid" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_itemid" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_factor" />
                    <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_reqdtlis" Value="0" />
                    <dx:ASPxGridView ID="gv_reqdtls" ClientInstanceName="gv_reqdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" Width="100%" KeyFieldName="reqdtlis" Theme="MaterialCompact" RightToLeft="True" OnDataBinding="gv_reqdtls_DataBinding" ClientSideEvents-RowDblClick="function(s,e){bind(s, e)}" OnCustomCallback="gv_reqdtls_CustomCallback">
                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <SettingsPager AlwaysShowPager="True" PageSize="50">
                            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                        </SettingsPager>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
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
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="reqdtlis" ReadOnly="True" VisibleIndex="0" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="itemid" Caption="كود الصنف" VisibleIndex="2">
                                <Settings FilterMode="DisplayText"></Settings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="itemname" Caption="إسم الصنف" VisibleIndex="3">
                                <Settings FilterMode="DisplayText"></Settings>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="5" Caption="الوحدة">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="7" Caption="الكمية">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="8" Caption="ملاحظات">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemcode" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="الكميه" SummaryType="Sum" DisplayFormat=" {0}" />
                        </TotalSummary>
                        <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                            <PagerBottomPanel HorizontalAlign="Center" VerticalAlign="Middle"></PagerBottomPanel>
                        </Styles>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="gvitemsExporter" runat="server" FileName="تفاصيل طلبية الشراء" GridViewID="gv_reqdtls" PaperKind="A4" PaperName="تفاصيل طلبية الشراء" RightToLeft="True" Landscape="True">
                        <PageHeader Center="تفاصيل طلبية الشراء" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>
                </asp:Panel>
            </div>
            <div class="modal" id="popupModaltransfer" style="z-index: 999999999;" data-name="aaa" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true" dir="rtl">
        <div class="modal-dialog" role="alertdialog" style="width: 100%">
            <div class="modal-content" style="height: 100%; min-height: 200px; width: 500px">
                <div class="modal-header">
                    <h5 class="modal-title" id="popupModalLabel">إنشاء إذن تحويل</h5>
                    <button type="button" class="close float-left" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="100" />
                        <Items>
                            <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="الفرع المحول منه"  HorizontalAlign="Right" VerticalAlign="Middle">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_frombranchid" runat="server" ClientInstanceName="cmb_frombranchid">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" HorizontalAlign="Left" VerticalAlign="Middle">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btn_transfer_ins" UseSubmitBehavior="false" runat="server" AutoPostBack="False" ClientInstanceName="btn_transfer_ins" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="إذن تحويل">
                                                    <ClientSideEvents Click="function(s, e) {req_trans();}" />
                                                    <Image Height="20px" Url="~/img/icon/exchange.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>
<%--                    <div class="custgroup row">
                        <div class="col-md-6" style="float: left;">
                            <label>الفرع المحول منه</label>
                            --%>
                            <%--<select id="cmb_frombranchid" class="form-control form-control-sm"></select>--%>
                        <%--</div>
                        <div class="col-md-6">
                            --%>
<%--                            <button type="button" class="btn btn-sm addcustpopup" onclick="req_trans()">
                                <img src="../img/icon/save.svg" />
                            </button>--%>
                        <%--</div>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_addnew" />
        </Triggers>
    </asp:UpdatePanel>
    <style>
     .addcustpopup {
         width: 35px;
         height: 35px;
         padding: 5px 5px 5px;
        background-color :white;
        -webkit-box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
/*        position:fixed;
        margin: 100px 550px;*/

    margin-top: 20px;
    margin-right: 90%;
        
 }

         </style>
</asp:Content>