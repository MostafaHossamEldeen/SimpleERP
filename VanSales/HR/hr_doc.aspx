<%@ Page Title="الوثائق الرسمية" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_doc.aspx.cs" Inherits="VanSales.HR.hr_doc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/HR/hr_doc.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="الوثائق الرسمية" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                    <ClientSideEvents Click="function(s, e) {cleardata();}" />
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/HR/doc_del','HF_docid')}" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <button type="button" id="PopUpControlSearch" data-name="doc" data-tablename="hr_doc_sel_pop" data-displayfields="docno,empname,doctypname,doctynatname"
                    data-displayfieldshidden="docid,empid,empcode,doctypeid,doctynature,datetype,docexpiredate,docimg"
                    data-displayfieldscaption="رقم الوثيقة,الموظف,النوع,الطبيعة"
                    data-bindcontrols="HF_docid;txt_docno;rbl_doctynature;cmb_doctypeid;HF_empid;txt_empname;txt_empid;rbl_datetype;txt_docexpiredate;hf_imgpath"
                    data-bindfields="docid;docno;doctynature;doctypeid;empid;empname;empcode;datetype;docexpiredate;docimg"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="docid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <br />
            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="رقم المستند">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_docno" runat="server" ClientInstanceName="txt_docno" Theme="MaterialCompact" Font-Bold="True">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxRadioButtonList ID="rbl_doctynature" ClientInstanceName="rbl_doctynature" runat="server" Border-BorderStyle="None" RepeatDirection="Horizontal" AutoPostBack="true">
                                        </dx:ASPxRadioButtonList>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="نوع المستند">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_doctypeid" runat="server" ClientInstanceName="cmb_doctypeid" RightToLeft="True" TextField="mitemname" Theme="MaterialCompact">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="box" Caption="بيانات الموظف" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>
                            <dx:LayoutItem Caption="الموظف">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxTextBox ID="txt_empid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_empid" AutoPostBack="false">
                                            <ClientSideEvents ValueChanged="function(s, e) {setEmpData(s, e)}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <button type="button" id="puop_emp" data-name="emp" onclick="createPopUp($(this))" data-tablename="hr_employees_sel_search" data-displayfields="empcode,empname,empmob,embemail" data-displayfieldshidden="empidno,empid"
                                            data-displayfieldscaption="كود الموظف,اسم الموظف" data-bindcontrols="txt_empid;txt_empname;HF_empid"
                                            data-bindfields="empcode;empname;empid" data-pkfield="empid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                        </button>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                </ParentContainerStyle>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="اسم الموظف">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_empname" ClientInstanceName="txt_empname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>
                            <dx:LayoutItem Caption="نوع التاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" ClientInstanceName="rbl_doctynature" runat="server" Border-BorderStyle="None" RepeatDirection="Horizontal" AutoPostBack="true">
                                        </dx:ASPxRadioButtonList>
                                        <dx:ASPxRadioButtonList ID="rbl_datetype" runat="server" ClientInstanceName="rbl_datetype" RightToLeft="True" TextField="mitemname" Theme="MaterialCompact" AutoPostBack="true">
                                        </dx:ASPxRadioButtonList>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="تاريخ إنتهاء المستند">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_docexpiredate" runat="server" RightToLeft="True" Theme="MaterialCompact" ClientInstanceName="txt_docexpiredate"></dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="صورة الصنف ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxUploadControl ID="upd_docimg" OnFileUploadComplete="upd_docimg_FileUploadComplete" FileSystemSettings-GenerateUniqueFileNamePrefix="True" runat="server" UploadMode="Advanced" Width="100%" ShowProgressPanel="True" UploadStorage="FileSystem" ShowUploadButton="True" AutoStartUpload="True" RightToLeft="True" ValidationSettings-GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" ValidationSettings-MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد رفعها في وقت واحد (والذي تم تعيينه على {1})." ValidationSettings-MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" ValidationSettings-NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به" Theme="MaterialCompact" ShowTextBox="False" ToolTip="رفع صورة المستند">
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
                                            <FileSystemSettings UploadFolder="~\Img\Doc" />
                                        </dx:ASPxUploadControl>
                                        <dx:ASPxImage ID="img_docimg" ClientInstanceName="img_docimg" runat="server" ShowLoadingImage="true" Width="150px" Height="150px">
                                        </dx:ASPxImage>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="HF_docid" Value="0" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_empid" Value="0" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hf_imgpath" Value="0" ClientIDMode="Static" runat="server" />
        </ContentTemplate>
        <Triggers>
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>
