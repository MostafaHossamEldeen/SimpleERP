<%@ Page Title="إدارة 555الموظفين" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_employees.aspx.cs" Inherits="VanSales.hr_employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--    <link rel="stylesheet" href="../content/jquery-ui.css" />
    <script src="../Scripts/jquery-ui.min.js"></script>--%>
    <script src="../Scripts/App/Public/Messages.js"></script>
   <script src="../Scripts/accordion.js"></script>
    <script src="../Scripts/App/HR/hr_employees.js"></script>
    <script>
        var lastCountry = null;
        function OnCountryChanged(cmbCountry) {
            if (cmb_paychartid.InCallback())
                lastCountry = cmb_branchid.GetValue().toString() + ',' + cmb_paytypeid.GetValue().toString()
            else
                cmb_paychartid.PerformCallback(cmb_branchid.GetValue().toString() + ',' + cmb_paytypeid.GetValue().toString());
        }
        function OnEndCallback(s, e) {
            if (lastCountry) {
                cmbCity.PerformCallback(lastCountry);
                lastCountry = null;
            }
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="إدارة الـمـوظـفـيـن" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center; padding-bottom: 20px;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <%--<ClientSideEvents Click="function(s, e) {cleardata();}" />--%>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save" runat="server" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" AutoPostBack="true" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_save_Click">
                    <%--<ClientSideEvents Click="function(s, e) {validate(s, e);}" />--%>
                </dx:ASPxButton>
                <%--<button type="button" title="بحث" id="PopUpControlSearch" data-name="inv" data-tablename="st_item_sel_pop" data-displayfields="itemcode,itembarcode,itemname"
                    data-displayfieldshidden="pinvid,pinvpay,branchid,ccid,suppid,suppname,suppvat,puser,pnotes,netbvat,vatvalue,netavat,docid,docno,invpic,vattype"
                    data-displayfieldscaption="كود الصنف,باركود الصنف,اسم الصنف"
                    data-bindcontrols="hf_itemid;txt_itemcode;txt_itemcode2;txt_itemcode3;txt_itembarcode;txt_itembarcode2;txt_itemname;txt_itemename;txt_itemdesc;cmb_unitid;cmb_groupid;cmb_itemtypeid;cmb_suppid;cmb_itemstop;txt_minqty;txt_maxqty;txt_pprice;txt_cprice;txt_sprice;txt_vat;txt_vprice;txt_fprice;hf_imgpath;cmb_itemcat1;cmb_itemcat2;txt_itemfield1;txt_itemfield2"
                    data-bindfields="itemid;itemcode;itemcode2;itemcode3;itembarcode;itembarcode2;itemname;itemename;itemdesc;unitid;groupid;itemtypeid;suppid;itemstop;minqty;maxqty;pprice;cprice;sprice;vat;vprice;fprice;itempic;itemcat1;itemcat2;itemfield1;itemfield2"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="itemid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>--%>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <%--<ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/Item/item_manage_del','hf_itemid')}" />--%>
                </dx:ASPxButton>
            </div>
            <div class="accordion" id="accordion">

                <h1 class="accordion__item__header">البيانات الأساسية
                </h1>
                <div class="">
                    <asp:Panel ID="Panel1" runat="server" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                        <dx:ASPxFormLayout AlignItemCaptionsInAllGroups="true" AlignItemCaptions="true" SettingsItemCaptions-HorizontalAlign="Left" runat="server" ID="formLayout" RightToLeft="True">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                            <Items>
                                <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem Caption="كود الموظف ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_empcode" ClientInstanceName="txt_empcode" runat="server" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="إسم الموظف ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_empname" ClientInstanceName="txt_empname" runat="server" Theme="MaterialCompact">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem RowSpan="3" Caption="صورة الموظف">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxImage ID="img_itempic" ClientInstanceName="img_itempic" runat="server" ShowLoadingImage="true" Width="150px" Height="150px">
                                                    </dx:ASPxImage>
                                                    <dx:ASPxUploadControl ID="upd_emppic" OnFileUploadComplete="upd_emppic_FileUploadComplete" FileSystemSettings-GenerateUniqueFileNamePrefix="True" runat="server" UploadMode="Advanced" Width="100%" ShowProgressPanel="True" UploadStorage="FileSystem" ShowUploadButton="True" AutoStartUpload="True" RightToLeft="True" ValidationSettings-GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" ValidationSettings-MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد رفعها في وقت واحد (والذي تم تعيينه على {1})." ValidationSettings-MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" ValidationSettings-NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به" Theme="MaterialCompact" ShowTextBox="False" ToolTip="رفع صورة الموظف">
                                                        <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .png" GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد تحميلها في وقت واحد (والذي تم تعيينه على {1})." MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" MultiSelectionErrorText="انتباه! {0} من الملفات غير صالحة ولن يتم رفعها. الأسباب المحتملة هي: أنها تتجاوز حجم الملف المسموح به ({1}) ، أو امتداداتها غير مسموح بها ، أو تحتوي أسماء ملفاتها على أحرف غير صالحة. تمت إزالة هذه الملفات من التحديد: {2}" NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به">
                                                        </ValidationSettings>
                                                        <ClientSideEvents FilesUploadComplete="function(s, e) {updmsg(s,e);ASPxUploadItemPic.SetVisible = false;}"></ClientSideEvents>
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
                                                        <FileSystemSettings UploadFolder="~\Img\Emp" />
                                                    </dx:ASPxUploadControl>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="رقم الجوال ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_empmob" ClientInstanceName="txt_empmob" runat="server" Theme="MaterialCompact">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="البريد الإلكتروني ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_embemail" ClientInstanceName="txt_embemail" runat="server" Theme="MaterialCompact">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="العنوان ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_empadd" ClientInstanceName="txt_empadd"  runat="server" Theme="MaterialCompact">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="رقم الهوية ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_empidno" ClientInstanceName="txt_empidno" runat="server" Theme="MaterialCompact" Font-Bold="true">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="تاريخ الميلاد ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxDateEdit ID="txt_empbdate" ClientInstanceName="txt_empbdate" runat="server" Theme="MaterialCompact">
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="المؤهل الدراسي ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_eduname" ClientInstanceName="txt_eduname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="ملاحظات ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxMemo ID="txt_empnotes" ClientInstanceName="txt_empnotes" runat="server" Theme="MaterialCompact"></dx:ASPxMemo>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                    </asp:Panel>
                    <asp:HiddenField ID="hf_empid" ClientIDMode="Static" runat="server" Value="0" />
                </div>
                <h1 class="accordion__item__header">البيانات الوظيفية
                </h1>
                <div class="">
                    <dx:ASPxFormLayout runat="server" AlignItemCaptions="true" AlignItemCaptionsInAllGroups="true" SettingsItemCaptions-HorizontalAlign="Left" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                                <Items>
                                    <dx:LayoutItem Caption="الفرع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                
                                                <dx:ASPxComboBox ID="cmb_branchid"  ClientInstanceName="cmb_branchid" runat="server" Theme="MaterialCompact" Font-Bold="True" >
                                                   
                                                           <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCountryChanged(s); }" />
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="مركز التكلفة ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_ccid"  ClientInstanceName="cmb_ccid" runat="server" Theme="MaterialCompact" Font-Bold="True">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="الجنسية ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_nationid" ClientInstanceName="cmb_nationid" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="الوظيفة ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_jobid" ClientInstanceName="cmb_jobid" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="حالة الموظف ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_empstatus" ClientInstanceName="cmb_empstatus" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True">
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>
                </div>
                <h1 class="accordion__item__header">البيانات المالية
                </h1>
                <div class="">
                    <dx:ASPxFormLayout runat="server" AlignItemCaptions="true" AlignItemCaptionsInAllGroups="true" SettingsItemCaptions-HorizontalAlign="Left" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                                <Items>
                                    <dx:LayoutItem Caption="الراتب الأساسي">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_basicsalary" ClientInstanceName="txt_basicsalary" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="راتب التأمينات ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_insursalary" ClientInstanceName="txt_insursalary" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="تاريخ بداية العمل ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxDateEdit ID="txt_empworkdate" ClientInstanceName="txt_empworkdate" runat="server" Theme="MaterialCompact"></dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="طريقة صرف الراتب ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_paytypeid" ClientInstanceName="cmb_paytypeid" runat="server" Theme="MaterialCompact" AutoPostBack="true">
                                                       <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCountryChanged(s); }" />
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="رقم حساب طريقة صرف الراتب ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_paychartid" ClientInstanceName="cmb_paychartid" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True" OnCallback="cmb_paychartid_Callback"
                                                    >
                                                     <ClientSideEvents EndCallback=" OnEndCallback" />
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="بنك الموظف ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_empbankname" ClientInstanceName="txt_empbankname" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="رقم حساب بنك الموظف ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_empbankid" ClientInstanceName="txt_empbankid" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="رصيد الأجازات السنوية ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_annualvaction" ClientInstanceName="txt_annualvaction" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                                <Items>
                                    <dx:LayoutItem Caption="رقم حساب الموظف ">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_empchatid" ClientInstanceName="txt_empchatid" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>
                </div>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
