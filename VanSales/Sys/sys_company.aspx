<%@ Page Title="الشركه" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sys_company.aspx.cs" Inherits="VanSales.Sys.sys_company"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .zoom {
            transition: transform .3s; /* Animation */
        }

            .zoom:hover {
                -ms-transform: scale(2.5); /* IE 9 */
                -webkit-transform: scale(2.5); /* Safari 3-8 */
                transform: scale(2.5); /* (150% zoom - Note: if the zoom is too large, it will go outside of the viewport) */
            }
    </style>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="الشــــركـه" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div dir="rtl" style="text-align: center;">
        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" CssClass="btn_save" Height="35px" Width="50px" OnClick="btn_Save_Click" ToolTip="حفظ">
            <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
        </dx:ASPxButton>
        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_cancel" CssClass="btn_cancel" Height="35px" Width="50px" runat="server" AutoPostBack="False" OnClick="btn_cancel_Click" ToolTip="إلغاء">
        </dx:ASPxButton>
    </div>
    <br />
    <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
        <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
            <Items>
                <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                    <Items>
                        <dx:LayoutItem Caption="اسم الشركه">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compname" runat="server" Theme="MaterialCompact" Style="margin-right: 0px" ClientInstanceName="txt_compname">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="النشاط">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compact" ClientInstanceName="txt_compact" runat="server" CssClass="auto-style2" Theme="MaterialCompact">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="السنه الماليه">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compyear" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_compyear">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="الشكل القانوى">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_complegal" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_complegal">
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="التليفون/الفاكس">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_comptel" ClientInstanceName="txt_comptel" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="الجوال">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compmob" ClientInstanceName="txt_compmob" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="العنوان">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compadd" ClientInstanceName="txt_compadd" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="الموقع الالكترونى">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compweb" ClientInstanceName="txt_compweb" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="البريد الإلكترونى">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compemail" ClientInstanceName="txt_compemail" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="المدير العام">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compmanager" ClientInstanceName="txt_compmanager" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="رقم الملف الضريبى">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox ID="txt_compvatno" ClientInstanceName="txt_compvatno" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="شعار الشركه">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxUploadControl ID="upd_complogo" OnFileUploadComplete="upd_complogo_FileUploadComplete" FileSystemSettings-GenerateUniqueFileNamePrefix="True" runat="server" UploadMode="Advanced" Width="100%" ShowProgressPanel="True" UploadStorage="FileSystem" ShowUploadButton="True" AutoStartUpload="True" RightToLeft="True" ValidationSettings-GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" ValidationSettings-MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد رفعها في وقت واحد (والذي تم تعيينه على {1})." ValidationSettings-MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" ValidationSettings-NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به" Theme="MaterialCompact" ShowTextBox="False" ToolTip="رفع صورة الصنف">
                                        <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .png" GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد تحميلها في وقت واحد (والذي تم تعيينه على {1})." MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" MultiSelectionErrorText="انتباه! {0} من الملفات غير صالحة ولن يتم رفعها. الأسباب المحتملة هي: أنها تتجاوز حجم الملف المسموح به ({1}) ، أو امتداداتها غير مسموح بها ، أو تحتوي أسماء ملفاتها على أحرف غير صالحة. تمت إزالة هذه الملفات من التحديد: {2}" NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به">
                                        </ValidationSettings>
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
                                        <FileSystemSettings UploadFolder="~\Img\Icon" />
                                    </dx:ASPxUploadControl>
                                    <dx:ASPxImage ID="Image1" ClientInstanceName="Image1" runat="server" ShowLoadingImage="true" Width="150px" Height="150px">
                                        <EmptyImage Url="../Img/Icon/no-image.png" Width="150px" Height="150px"></EmptyImage>
                                    </dx:ASPxImage>
                                    <%--<asp:Image ID="Image1" runat="server" Width="90px" CssClass="zoom" />--%>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="الملاحظات">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxMemo ID="txt_compnotes" ClientInstanceName="txt_compnotes" runat="server" Theme="MaterialCompact" Width="100%"></dx:ASPxMemo>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
        </dx:ASPxFormLayout>
        <div dir="rtl" style="text-align: center;">
            <br />
        </div>
    </asp:Panel>
       </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(100)
                        .height(100);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
        function validate(s, e) {
            if (txt_compname.GetValue() == "" || txt_compname.GetValue() == null) {
                sweetinfo("برجاء ادخال اسم الشركه");
                txt_compname.Focus();
                e.txt_compname.Focus();
                return;
            }
            if (txt_compvatno.GetValue() == "" || txt_compvatno.GetValue() == null) {
                sweetinfo("برجاء ادخال رقم الملف الضريبى");
                txt_compvatno.Focus();
                e.txt_compvatno.Focus();
                return;
            }
        }
    </script>
</asp:Content>
