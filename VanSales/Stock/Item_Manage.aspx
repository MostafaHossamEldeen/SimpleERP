<%@ Page Title="إدارة الاصناف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Item_Manage.aspx.cs" Inherits="VanSales.Stock.Item_Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <%--<link rel="stylesheet" href="../content/jquery-ui.css" />--%>
    <script src="../Scripts/jquery-ui.min.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="إدارة الأصــنــاف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center; padding-bottom: 20px;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_addnew_Click">
                    <ClientSideEvents Click="function(s, e) {cleardata();}" />
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save" OnClick="btn_save_Click" runat="server" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" AutoPostBack="true" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ValidationGroup="A">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                </dx:ASPxButton>
                <button type="button" title="بحث" id="PopUpControlSearch" data-name="inv" data-tablename="st_item_sel_pop" data-displayfields="itemcode,itembarcode,itemname"
                    data-displayfieldshidden="pinvid,pinvpay,branchid,ccid,suppid,suppname,suppvat,puser,pnotes,netbvat,vatvalue,netavat,docid,docno,invpic,vattype"
                    data-displayfieldscaption="كود الصنف,باركود الصنف,اسم الصنف"
                    data-bindcontrols="hf_itemid;txt_itemcode;txt_itemcode2;txt_itemcode3;txt_itembarcode;txt_itembarcode2;txt_itemname;txt_itemename;txt_itemdesc;cmb_unitid;cmb_groupid;cmb_itemtypeid;cmb_suppid;cmb_itemstop;txt_minqty;txt_maxqty;txt_pprice;txt_cprice;txt_sprice;txt_vat;txt_vprice;txt_fprice;hf_imgpath;cmb_itemcat1;cmb_itemcat2;txt_itemfield1;txt_itemfield2"
                    data-bindfields="itemid;itemcode;itemcode2;itemcode3;itembarcode;itembarcode2;itemname;itemename;itemdesc;unitid;groupid;itemtypeid;suppid;itemstop;minqty;maxqty;pprice;cprice;sprice;vat;vprice;fprice;itempic;itemcat1;itemcat2;itemfield1;itemfield2"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="itemid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/Item/item_manage_del','hf_itemid')}" />
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btnback" runat="server" Height="20px" Width="20px" ToolTip="للخلف" Image-Url="~/Img/Icon/back.svg" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) { location ='/stock/items'}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <div class="accordion" id="accordion1">
                    <h1 class="accordion__item__header accordion__item__header " style="width: 100%;">
                        البيانات الأساسية للصنف
                    </h1>
                    <div class="" >
                        <asp:Panel ID="Panel1" runat="server" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                            <dx:ASPxFormLayout AlignItemCaptionsInAllGroups="true" AlignItemCaptions="true" SettingsItemCaptions-HorizontalAlign="Right"  runat="server" ID="formLayout" RightToLeft="True">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                                <Items>
                                    <dx:LayoutGroup ColCount="5" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="كود الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemcode" ClientInstanceName="txt_itemcode" runat="server" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى" ClientSideEvents-KeyPress="function(s,e){preventwriteitemcode1(s,e);}">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="كود الصنف 2 ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemcode2" ClientInstanceName="txt_itemcode2" AutoCompleteType="Disabled" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="كود المورد ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemcode3" ClientInstanceName="txt_itemcode3" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="باركود الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itembarcode" ClientInstanceName="txt_itembarcode" AutoCompleteType="Disabled" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="باركود الصنف 2 ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itembarcode2" ClientInstanceName="txt_itembarcode2" AutoCompleteType="Disabled" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="10" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem ColumnSpan="3" Caption="إسم الصنف ع ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemname" ClientInstanceName="txt_itemname" runat="server" Theme="MaterialCompact" Font-Bold="true">
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_itemname" ClientIDMode="Static" runat="server" ControlToValidate="txt_itemname" Display="Dynamic" ErrorMessage="برجاء إدخال إسم الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem ColumnSpan="3" Caption="إسم الصنف E ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemename" ClientInstanceName="txt_itemename" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem ColumnSpan="4" Caption="الوصف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxMemo ID="txt_itemdesc" ClientInstanceName="txt_itemdesc" runat="server" Theme="MaterialCompact"></dx:ASPxMemo>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="الوحدة الأساسية ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_unitid" ClientInstanceName="cmb_unitid" runat="server" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_unitid" ClientIDMode="Static" runat="server" ControlToValidate="cmb_unitid" Display="Dynamic" ErrorMessage="برجاء إختيار وحدة الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="المجموعة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_groupid" ClientInstanceName="cmb_groupid" runat="server" ValueType="System.String" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_groupid" ClientIDMode="Static" runat="server" ControlToValidate="cmb_groupid" Display="Dynamic" ErrorMessage="برجاء إختيار مجموعة الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="نوع الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_itemtypeid" ClientInstanceName="cmb_itemtypeid" runat="server" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_itemtypeid" ClientIDMode="Static" runat="server" ControlToValidate="cmb_itemtypeid" Display="Dynamic" ErrorMessage="برجاء إختيار نوع الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="المورد ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_suppid" ClientInstanceName="cmb_suppid" runat="server" ValueType="System.String" Theme="MaterialCompact" RightToLeft="True" ClearButton-DisplayMode="Always"></dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="إيقاف الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_itemstop" ClientInstanceName="cmb_itemstop" runat="server" ValueType="System.String" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_itemstop" ClientIDMode="Static" runat="server" ControlToValidate="cmb_itemstop" Display="Dynamic" ErrorMessage="برجاء إختيار نوع إيقاف الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="أقل كمية ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_minqty" AutoCompleteType="Disabled" ClientInstanceName="txt_minqty" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="أقصى كمية ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_maxqty" AutoCompleteType="Disabled" ClientInstanceName="txt_maxqty" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر الشراء ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_pprice" AutoCompleteType="Disabled" ClientInstanceName="txt_pprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_pprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_pprice" Display="Dynamic" ErrorMessage="برجاء إدخال سعر الشراء" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر التكلفة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_cprice" AutoCompleteType="Disabled" ClientInstanceName="txt_cprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر البيع ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_sprice" AutoCompleteType="Disabled" runat="server" ClientInstanceName="txt_sprice" Theme="MaterialCompact" MaxLength="12">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}" KeyUp="function(s, e) {mastercalcVat(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_sprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_sprice" Display="Dynamic" ErrorMessage="برجاء إدخال سعر البيع" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="الضريبة % ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxSpinEdit ID="txt_vat" ClientInstanceName="txt_vat" runat="server" Theme="MaterialCompact" MaxValue="100">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}" KeyUp="function(s, e) {mastercalcVat(s, e);}" ButtonClick="function(s, e) {mastercalcVat(s, e);}" NumberChanged="function(s, e) {mastercalcVat(s, e);}" ValueChanged="function(s, e) {mastercalcVat(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxSpinEdit>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_vat" ClientIDMode="Static" runat="server" ControlToValidate="txt_vat" Display="Dynamic" ErrorMessage="برجاء إدخال قيمة الضريبة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="السعر شامل الضريبة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_vprice" AutoCompleteType="Disabled" ClientInstanceName="txt_vprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {preventwrite(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_vprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_vprice" Display="Dynamic" ErrorMessage="برجاء إدخال السعر شامل الضريبة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر الفاتورة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_fprice" AutoCompleteType="Disabled" ClientInstanceName="txt_fprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_fprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_fprice" Display="Dynamic" ErrorMessage="برجاء إدخال سعر الفاتورة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="صورة الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxUploadControl ID="upd_itempic" OnFileUploadComplete="upd_itempic_FileUploadComplete" FileSystemSettings-GenerateUniqueFileNamePrefix="True" runat="server" UploadMode="Advanced" Width="100%" ShowProgressPanel="True" UploadStorage="FileSystem" ShowUploadButton="True" AutoStartUpload="True" RightToLeft="True" ValidationSettings-GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" ValidationSettings-MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد رفعها في وقت واحد (والذي تم تعيينه على {1})." ValidationSettings-MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" ValidationSettings-NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به" Theme="MaterialCompact" ShowTextBox="False" ToolTip="رفع صورة الصنف">
                                                            <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .png" GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد تحميلها في وقت واحد (والذي تم تعيينه على {1})." MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" MultiSelectionErrorText="انتباه! {0} من الملفات غير صالحة ولن يتم رفعها. الأسباب المحتملة هي: أنها تتجاوز حجم الملف المسموح به ({1}) ، أو امتداداتها غير مسموح بها ، أو تحتوي أسماء ملفاتها على أحرف غير صالحة. تمت إزالة هذه الملفات من التحديد: {2}" NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به">
                                                            </ValidationSettings>
                                                            <ClientSideEvents FileUploadComplete="function(s, e) {updmsg(s,e);ASPxUploadItemPic.SetVisible = false;}"></ClientSideEvents>
                                                            <RemoveButton Text="حذف" Image-Url="~/Img/Icon/delete.svg" Image-ToolTip="حذف" Image-Width="20" Image-Height="20" Image-AlternateText="حذف">
                                                                <Image AlternateText="حذف" Height="20px" ToolTip="حذف" Url="~/Img/Icon/delete.svg" Width="20px">
                                                                </Image>
                                                            </RemoveButton>
                                                            <UploadButton Text="رفع الصورة" Image-Url="~/Img/Icon/import.svg" Image-ToolTip="رفع الصورة" Image-Height="20" Image-Width="20" Image-AlternateText="رفع الصورة">
                                                                <Image AlternateText="رفع الصورة" Height="20px" ToolTip="رفع الصورة" Url="~/Img/Icon/import.svg" Width="20px">
                                                                </Image>
                                                            </UploadButton>
                                                            <CancelButton Text="إلغاء" Image-Url="~/Img/Icon/cancel.svg" Image-ToolTip="إلغاء" Image-Width="20" Image-Height="20" Image-AlternateText="إلغاء">
                                                                <Image AlternateText="إلغاء" Height="20px" ToolTip="إلغاء" Url="~/Img/Icon/cancel.svg" Width="20px">
                                                                </Image>
                                                            </CancelButton>
                                                            <AdvancedModeSettings DropZoneText="قم برفع الصور أو سحبها و إفلاتها هنا"></AdvancedModeSettings>
                                                            <FileSystemSettings UploadFolder="~\Img\Item" />
                                                        </dx:ASPxUploadControl>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxImage ID="img_itempic" ClientInstanceName="img_itempic" runat="server" ShowLoadingImage="true" Width="150px" Height="150px">
                                                            <EmptyImage Url="../Img/Icon/no-image.png" Width="150px" Height="150px"></EmptyImage>
                                                        </dx:ASPxImage>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <asp:ValidationSummary ID="ValidationSummary" ClientIDMode="Static" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="A" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                            </dx:ASPxFormLayout>
                        </asp:Panel>
                        <asp:HiddenField ID="hf_itemid" ClientIDMode="Static" runat="server" Value="0" />
                        <asp:HiddenField ID="hf_sysvatvalue" ClientIDMode="Static" runat="server" Value="0" />
                        <asp:HiddenField ID="hf_imgpath" ClientIDMode="Static" runat="server" Value="0" />
                    </div>
               </div>
                <div class="accordion" id="accordion">
                    <h1 class="accordion__item__header">
                        البيانات الإضافية للصنف
                    </h1>
                    <div class="">
                        <dx:ASPxFormLayout runat="server" AlignItemCaptions="true" AlignItemCaptionsInAllGroups="true" SettingsItemCaptions-HorizontalAlign="Right" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                            <Items>
                                <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem Caption="بيان إضافي 1 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_itemfield1" AutoCompleteType="Disabled" ClientInstanceName="txt_itemfield1" runat="server" Theme="MaterialCompact" Font-Bold="True">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="بيان إضافي 2 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_itemfield2" AutoCompleteType="Disabled" ClientInstanceName="txt_itemfield2" runat="server" Theme="MaterialCompact" Font-Bold="True">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="تصنيف 1 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_itemcat1" ClientInstanceName="cmb_itemcat1" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True" ClearButton-DisplayMode="Always">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="تصنيف 2 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_itemcat2" ClientInstanceName="cmb_itemcat2" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True" ClearButton-DisplayMode="Always">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                    </div>
                    <h1 class="accordion__item__header">
                        وحدات الصنف
                    </h1>
                    <div class="">
                        <dx:ASPxGridView ID="gvitemunit" ClientIDMode="Static" OnDataBinding="gvitemunit_DataBinding" OnRowInserting="gvitemunit_RowInserting" OnRowDeleting="gvitemunit_RowDeleting" OnRowUpdating="gvitemunit_RowUpdating"  ClientInstanceName="gvitemunit" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="itemunitid" OnInitNewRow="gvitemunit_InitNewRow" OnCustomCallback="gvitemunit_CustomCallback">
                            <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}"  CustomButtonClick="function(s,e){OnCustomButtonClick(s,e)}" />
                            <SettingsPager AlwaysShowPager="True" PageSize="20">
                                <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                            </SettingsPager>
                            <SettingsEditing Mode="PopupEditForm">
                            </SettingsEditing>
                            <Settings ShowFilterRowMenu="True"  ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                            <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                            <SettingsCommandButton RenderMode="Image" >
                                <CustomizationDialogCloseButton>
                                    <Image ToolTip="إغلاق" Url="~/Img/Icon/close.svg" Width="20" Height="20" AlternateText="إغلاق" />
                                </CustomizationDialogCloseButton>
                                <NewButton RenderMode="Image">
                                    <Image ToolTip="جديد" Url="~/Img/Icon/add-new.svg" Width="20" Height="20" AlternateText="جديد" />
                                </NewButton>
                                <EditButton RenderMode="Image">
                                    <Image ToolTip="تعديل" Url="~/Img/Icon/edit.svg" Width="20" Height="20" AlternateText="تعديل" />
                                </EditButton>
                                <UpdateButton RenderMode="Image">
                                    <Image ToolTip="حفظ" Url="~/Img/Icon/save.svg" Width="20" Height="20" AlternateText="حفظ" />
                                </UpdateButton>
                                <CancelButton RenderMode="Image">
                                    <Image ToolTip="إلغاء" Url="~/Img/Icon/cancel.svg" Width="20" Height="20" AlternateText="إلغاء" />
                                </CancelButton>
                                <DeleteButton RenderMode="Image">
                                    <Image ToolTip="حذف" Url="~/Img/Icon/delete.svg" Width="20" Height="20" AlternateText="حذف" />
                                </DeleteButton>
                                <ClearFilterButton RenderMode="Image">
                                    <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                </ClearFilterButton>
                                <SearchPanelClearButton RenderMode="Image">
                                    <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                </SearchPanelClearButton>
                            </SettingsCommandButton>
                            <SettingsPopup>
                                <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                    <SettingsAdaptivity VerticalAlign="WindowCenter" />
                                </EditForm>
                                <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                            </SettingsPopup>
                            <SettingsSearchPanel ShowClearButton="True" />
                            <SettingsExport PaperKind="A4" FileName="customers" PaperName="customers" RightToLeft="True">
                                <PageHeader>
                                    <Font Bold="True" Size="Medium"></Font>
                                </PageHeader>
                            </SettingsExport>
                            <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                            <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                            <StylesPopup>
                                <HeaderFilter>
                                    <Footer HorizontalAlign="Center">
                                    </Footer>
                                </HeaderFilter>
                            </StylesPopup>
                            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
                            <SettingsBehavior AllowEllipsisInText="false" />
                            <EditFormLayoutProperties>
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                            </EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn  VisibleIndex="0" ShowNewButtonInHeader="True" ShowEditButton="True">
                                    <CustomButtons>
                                         <dx:GridViewCommandColumnCustomButton ID="deleteButton" Text=" " Image-Url="~/Img/Icon/delete.svg" Image-Width="20" Image-Height="20"/>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="itemunitid" ReadOnly="True" VisibleIndex="1" Caption="كود" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="barcode1" VisibleIndex="5" Caption="باركود">
                                    <PropertiesTextEdit MaxLength="50">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="barcode2" VisibleIndex="6" Caption="باركود 2"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn  FieldName="factor" VisibleIndex="14" Caption="معامل التحويل">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="fact" MaxLength="50">
                                        <ClientSideEvents KeyUp="function(s, e) {factsprice(s, e);calcVat(s,e);}" KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="sprice" VisibleIndex="20" Caption="سعر البيع">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="sprice" MaxLength="12">
                                        <ClientSideEvents KeyUp="function(s, e) {calcVat(s,e);}" KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="pprice" VisibleIndex="24" Caption="سعر الشراء">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="pprice" >
                                        <ClientSideEvents KeyUp="function(s, e) {calcVat(s,e);}" KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="cprice" VisibleIndex="25" Caption="سعر التكلفة">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="cprice" MaxLength="12" >
                                        <ClientSideEvents KeyUp="function(s, e) {calcVat(s,e);}" KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="vat" VisibleIndex="21" Caption="الضريبة">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="vatvalue" MaxLength="6">
                                        <ClientSideEvents KeyUp="function(s, e) {calcVat(s,e);}" KeyPress="function(s, e) {preventwrite(s, e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic">
                                            <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,3}(\.\d{1,3})?$"></RegularExpression>
                                            <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="vprice" VisibleIndex="22" Caption="السعر شامل">
                                    <PropertiesTextEdit ClientInstanceName="vatprice" MaxLength="12">
                                        <ClientSideEvents KeyPress="function(s, e) {preventwrite(s, e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="fprice" VisibleIndex="23" Caption="سعر الفاتورة">
                                    <PropertiesTextEdit ClientInstanceName="fpricevalue" MaxLength="12">
                                        <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="unitid" Caption="الوحدة" VisibleIndex="12">
                                    <PropertiesComboBox>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <SettingsPopup>
                                <EditForm Width="730">
                                    <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                                </EditForm>
                            </SettingsPopup>
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="unitid" ShowInColumn="unitid" ShowInGroupFooterColumn="unitid" SummaryType="Count" DisplayFormat="العدد : {0}" />
                            </TotalSummary>
                            <GroupSummary>
                                <dx:ASPxSummaryItem FieldName="unitid" ShowInColumn="unitid" ShowInGroupFooterColumn="unitid" SummaryType="Count" DisplayFormat="العدد : {0}" />
                            </GroupSummary>
                            <Styles>
                                <Footer Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle">
                                </Footer>
                                <GroupFooter HorizontalAlign="Right" VerticalAlign="Middle"></GroupFooter>
                                <GroupPanel HorizontalAlign="Right">
                                </GroupPanel>
                                <PagerBottomPanel HorizontalAlign="Center">
                                </PagerBottomPanel>
                            </Styles>
                        </dx:ASPxGridView>
                    </div>
                    <h1 class="accordion__item__header">
                        فروع الصنف
                    </h1>
                    <div class="">
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="None" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                                <Items>
                                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="box" Caption="" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                        <CellStyle Font-Bold="True">
                                        </CellStyle>
                                        <Items>
                                            <dx:LayoutItem Caption="الفرع">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTokenBox ID="tkb_branchid" ClientInstanceName="tkb_branchid" runat="server" ItemValueType="System.String" TextField="citemname" ValueField="citemid" Width="100%" AllowCustomTokens="false" AnimationType="Fade" Cursor="pointer" NullText="برجاء إختار الفروع" ShowShadow="true" DropDownRows="5" OnCallback="tkb_branchid_Callback"></dx:ASPxTokenBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addbranch" OnClick="btn_addbranch_Click" runat="server" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" AutoPostBack="true" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function(s, e) { validate_branch(s,e) }"></dx:ASPxButton>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="B" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                                <SettingsItemCaptions Location="Top" />
                            </dx:ASPxFormLayout>
                        </asp:Panel>
                        <table class="w-100" style="width: 100%">
                            <tr>
                                <td style="text-align: center"></td>
                                <td>
                                    <dx:ASPxGridView ID="gv_itemwh" OnCustomCallback="gv_itemwh_CustomCallback" OnDataBinding="gv_itemwh_DataBinding" KeyFieldName="itemwhid" ClientInstanceName="gv_itemwh" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
                                        <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                                        <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
                                        <SettingsEditing BatchEditSettings-EditMode="Cell" UseFormLayout="False"></SettingsEditing>
                                        <SettingsBehavior AllowEllipsisInText="true" AllowGroup="False" />
                                        <SettingsCommandButton RenderMode="Image">
                                            <CustomizationDialogCloseButton>
                                                <Image ToolTip="إغلاق" Url="~/Img/Icon/close.svg" Width="20" Height="20" AlternateText="إغلاق" />
                                            </CustomizationDialogCloseButton>
                                            <NewButton RenderMode="Image">
                                                <Image ToolTip="جديد" Url="~/Img/Icon/add-new.svg" Width="20" Height="20" AlternateText="جديد" />
                                            </NewButton>
                                            <EditButton RenderMode="Image">
                                                <Image ToolTip="تعديل" Url="~/Img/Icon/edit.svg" Width="20" Height="20" AlternateText="تعديل" />
                                            </EditButton>
                                            <UpdateButton RenderMode="Image">
                                                <Image ToolTip="حفظ" Url="~/Img/Icon/save.svg" Width="20" Height="20" AlternateText="حفظ" />
                                            </UpdateButton>
                                            <CancelButton RenderMode="Image">
                                                <Image ToolTip="إلغاء" Url="~/Img/Icon/cancel.svg" Width="20" Height="20" AlternateText="إلغاء" />
                                            </CancelButton>
                                            <DeleteButton RenderMode="Image">
                                                <Image ToolTip="حذف" Url="~/Img/Icon/delete.svg" Width="20" Height="20" AlternateText="حذف" />
                                            </DeleteButton>
                                            <ClearFilterButton RenderMode="Image">
                                                <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                            </ClearFilterButton>
                                            <SearchPanelClearButton RenderMode="Image">
                                                <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                            </SearchPanelClearButton>
                                        </SettingsCommandButton>
                                        <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                        <SettingsPopup>
                                            <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                                <SettingsAdaptivity VerticalAlign="WindowCenter" />
                                            </EditForm>
                                            <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </SettingsPopup>
                                        <SettingsFilterControl ShowAllDataSourceColumns="True">
                                        </SettingsFilterControl>
                                        <SettingsExport PaperKind="A4" FileName="permissions" PaperName="permissions" RightToLeft="True">
                                            <PageHeader>
                                                <Font Bold="True" Size="Medium"></Font>
                                            </PageHeader>
                                        </SettingsExport>
                                        <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                                        <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                                        <EditFormLayoutProperties>
                                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                                        </EditFormLayoutProperties>
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="itemwhid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                                <EditFormSettings Visible="False"></EditFormSettings>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="1" Caption=" كود الصنف" ReadOnly="True" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="branchid" Caption="الفرع" VisibleIndex="3">
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="4" Caption="الكميه"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="whminqty" VisibleIndex="5" Caption="اقل كميه"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="whmaxqty" VisibleIndex="6" Caption="اكثر كميه"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="whplase" VisibleIndex="7" Caption="مكان التخزين"></dx:GridViewDataTextColumn>
                                        </Columns>
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="branchid" ShowInColumn="branchid" ShowInGroupFooterColumn="branchid" SummaryType="Count" DisplayFormat="العدد : {0}" />
                                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="qty" ShowInGroupFooterColumn="qty" SummaryType="Sum" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                                        </TotalSummary>
                                        <Styles>
                                            <Footer Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle">
                                            </Footer>
                                            <GroupFooter Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle">
                                            </GroupFooter>
                                            <GroupPanel HorizontalAlign="Right"></GroupPanel>
                                            <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                                        </Styles>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
            </div>
        </ContentTemplate>
        <Triggers><asp:AsyncPostBackTrigger ControlID="btn_save" /></Triggers>
    </asp:UpdatePanel>
    <script src="../Scripts/App/stock/Item_Manage.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
        <script src="../Scripts/accordion.js"></script>
    <script>
        function OnCustomButtonClick(s, e) {
            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: true
            })
            swalWithBootstrapButtons.fire({
                title: 'تأكيد الحذف',
                text: "هل تريد حذف البيانات",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: ' نعم, تأكيد',
                cancelButtonText: 'لا, إلغاء ',
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {

                    gvitemunit.DeleteRow(e.visibleIndex)
                    //gv_hr_employees.GetSelectedFieldValues("emppic", onvaluechanged);
                } else if (
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'إلغاء',
                        'تم إلغاء عملية الحذف',
                        'error'
                    )
                }
            })
        }
    </script>
</asp:Content>