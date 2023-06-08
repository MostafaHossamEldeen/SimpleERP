<%@ Page Title="القيود اليومية" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vouchers.aspx.cs" Inherits="VanSales.GL.Vouchers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/GL/Vouchers.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <style>
        .btnusedpopup {
            padding: 3px 10px 2px;
            background-color: white;
            -webkit-box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
            /* height:30px;
         width:30px*/
        }

            .btnusedpopup:before {
                content: url(../img/icon/btn_copy.svg);
                width: 20px;
                float: left;
                margin-top: 2px;
            }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="Lbl_Tittle" runat="server" Text="القيود اليومية" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">


                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" ClientInstanceName="btn_Save" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) { validate(s,e) }" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" ClientInstanceName="btn_addnew" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">

                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>


                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/Vouchers/vouchersDelMaster', 'HF_vchrid') }" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <button type="button" id="popupModalsearchdef" data-name="nav" data-tablename="GL_vouchers_sel_pop" data-displayfields="vchrno,vchrdocno,vchrdate"
                    data-displayfieldshidden="vchrtype ,postacc,vuser,vchrdesc,vrfrance,vchrid,uservchr,puser,docpath"
                    data-displayfieldscaption="رقم القيد,رقم يدوى للقيد,التاريخ" data-bindcontrols="txt_vchrno;txt_vchrdocno;txt_vchrdate;cmb_vchrtype;txt_vuser;txt_vchrdesc;HF_vchrid;hf_postacc;ch_uservchr;txt_vrfrance;txt_puser;lbl_docpath"
                    data-bindfields="vchrno;vchrdocno;vchrdate;vchrtype;vuser;vchrdesc;vchrid;postacc;uservchr;vrfrance;puser;docpath"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="vchrid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>



                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" runat="server"   AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل حسابات">
                    <ClientSideEvents Click="function(s,e){postAcc(s,e)}" />
                    <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                </dx:ASPxButton>

                <button type="button" id="popupModalusedvoch" data-name="usedvoch" data-tablename="GL_vouchers_used_sel" data-displayfields="vchrno,vchrdocno,vchrdate"
                    data-displayfieldshidden="vchrid"
                    data-displayfieldscaption="رقم القيد,رقم يدوى للقيد,التاريخ" data-bindcontrols="HF_uservchr"
                    data-bindfields="vchrid"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="vchrid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnusedpopup" title="قيد مكرر">
                </button>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه" OnClick="btn_print_Click">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />

            </div>

            <br />
            <%--<asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft" >--%>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="Box" Caption="البيانات الاساسيه">
                        <Items>
                            <dx:LayoutItem Caption="رقم القيد">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ValidationSettings-CausesValidation="true" ID="txt_vchrno" runat="server" ClientInstanceName="txt_vchrno" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">

                                            <ClientSideEvents KeyDown="function(s, e) {
	 preventwrite(s, e)
}"
                                                ValueChanged="function(s,e){Refreshdata(s,e)}"></ClientSideEvents>
                                            <ValidationSettings CausesValidation="True">
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="رقم يدوى للقيد">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_vchrdocno" ClientInstanceName="txt_vchrdocno" runat="server" Theme="MaterialCompact" Style="margin-right: 0px">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <%-- <dx:LayoutItem Caption="الفرع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="ddl_branchid" runat="server" ClientInstanceName="ddl_branchid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>--%>



                            <dx:LayoutItem Caption="التاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxDateEdit ID="txt_vchrdate" runat="server" ValidateRequestMode="Disabled" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_vchrdate">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="نوع القيد">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_vchrtype" runat="server" ClientInstanceName="cmb_vchrtype" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="المستخدم">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_vuser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_vuser">
                                            <ClientSideEvents Init="function(s, e) {
	txt_vuser.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الرقم المرجعى">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_vrfrance" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_vrfrance">
                                           <%-- <ClientSideEvents Init="function(s, e) {
	txt_vrfrance.GetInputElement().readOnly = true; 
}" />--%>
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المراجع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_puser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_puser">
                                            <ClientSideEvents Init="function(s, e) {
	txt_puser.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="ch_uservchr" runat="server" Text="قيد متكرر" ClientInstanceName="ch_uservchr" CheckState="Unchecked" AutoPostBack="false">
                                        </dx:ASPxCheckBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المستند">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
                                        <dx:ASPxLabel ID="lbl_docpath" ClientInstanceName="lbl_docpath" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="80%">
                                        </dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxButton UseSubmitBehavior="false" ID="upload" runat="server" OnClick="upload_Click" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="رفع ملف">
                                            <Image Height="20px" Url="~/img/icon/import.svg" Width="20px"></Image>
                                        </dx:ASPxButton>
                                        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_download" runat="server" OnClick="btn_download_Click" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="تحميل">
                                            <Image Height="20px" Url="~/img/icon/download.svg" Width="20px"></Image>
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="الملاحظات" ColumnSpan="4">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_vchrdesc" ClientInstanceName="txt_vchrdesc" runat="server" Theme="MaterialCompact" Width="100%">
                                        </dx:ASPxMemo>


                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>


                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />

                                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_postacc" />

                                        <dx:ASPxLabel ID="lbl_postacc" runat="server" ClientInstanceName="lbl_postacc" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>
                    <%-- <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>
                      
                        </Items>
                    </dx:LayoutGroup>--%>
                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="HF_vchrid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_uservchr" ClientIDMode="Static" runat="server" />
            <%-- </asp:Panel>--%>
            <br />
            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="display: none; text-align: right" ClientIDMode="Static">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="10" GroupBoxDecoration="box" Caption="تفاصيل القيود اليوميه " UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الحساب" Width="12%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_chartid" runat="server" Theme="MaterialCompact" AutoPostBack="false" ClientInstanceName="txt_chartid" TabIndex="0">
                                                    <ClientSideEvents TextChanged="function(s,e){setchartData(s,e)}" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="11" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer ForeColor="Red">

                                                <button type="button" id="Pop_chart" data-name="chart" onclick="createPopUp($(this))" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldshidden="chartid"
                                                    data-displayfieldscaption="كود الحساب,اسم الحساب" data-bindcontrols="txt_chartid;txt_chartname;HF_chartid"
                                                    data-bindfields="chartcode;chartname;chartid" data-pkfield="chartid" data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" style="margin-top: 15px" class="btn btn-sm btnsearchpopup" tabindex="1" />



                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="اسم الحساب" Width="15%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_chartname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_chartname">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_chartname.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="المستند" Width="10%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_ref" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_ref" TabIndex="1">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="مدين" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_debit" ClientInstanceName="txt_debit" runat="server" Text="0" Theme="MaterialCompact" TabIndex="2">

                                                    <ClientSideEvents GotFocus="function(s, e) {txt_debit.SelectAll();}"
                                                        KeyDown="function(s, e) {validate_balnce()}"
                                                        KeyPress="function(s, e) {decimale3num(s, e);}" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="دائن" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_credit" ClientInstanceName="txt_credit" runat="server" Text="0" Theme="MaterialCompact" TabIndex="3">

                                                    <ClientSideEvents GotFocus="function(s, e) {txt_credit.SelectAll();}"
                                                        KeyDown="function(s, e) {calc()}"
                                                        KeyPress="function(s, e) {decimale3num(s, e);}" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="مركز التكلفه" Width="12%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_ccid" runat="server" ClientInstanceName="cmb_ccid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false" TabIndex="4">
                                                    <ClearButton DisplayMode="Always"></ClearButton>
                                                </dx:ASPxComboBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="2" Paddings-PaddingTop="11" Paddings-PaddingBottom="13" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_save_dtls" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click" TabIndex="5">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_new_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_new_dtls" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" TabIndex="6">
                                                    <ClientSideEvents Click="function(s, e) {
	 clear_varchrt();
}"></ClientSideEvents>

                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>

                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" TabIndex="7">

                                                    <ClientSideEvents Click="function(s, e) {getgvrow();delData_Detail('/VanSalesService/Vouchers/gvouchersDtl', 'vchrdtlid', 'HF_vchrdtlid',gvs_vchrdtls) }" />
                                                    <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملاحظات" CaptionSettings-Location="Left" Width="35%" Paddings-PaddingTop="20">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_descp" ClientInstanceName="txt_descp" runat="server" Theme="MaterialCompact" TabIndex="8">
                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملف" CaptionSettings-Location="Left" Paddings-PaddingTop="20" Width="35%" ParentContainerStyle-Paddings-PaddingLeft="5" ParentContainerStyle-Paddings-PaddingRight="5">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="9" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>


                                                   <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>

                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click" TabIndex="10"></dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_fastinsert" runat="server" AutoPostBack="False" ClientInstanceName="btn_fastinsert" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="ادخال سريع" Height="20px" Width="20px" TabIndex="11">
                                                    <Image Height="20px" Url="~/img/icon/bookmark.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>

                    <asp:HiddenField ID="HF_chartid" runat="server" ClientIDMode="Static" />
                    <%--<asp:HiddenField ID="HF_balance" runat="server" ClientIDMode="Static" />--%>
                    <asp:HiddenField ID="HF_vchrdtlid" ClientIDMode="Static" runat="server" />
                    <dx:ASPxGridView ID="gvs_vchrdtls" ClientInstanceName="gvs_vchrdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" OnDataBinding="gvs_vchrdtls_DataBinding" ClientSideEvents-RowDblClick="function(s,e){Gvs_Bind_dtl(s,e)}" Width="100%" KeyFieldName="vchrdtlid" Theme="MaterialCompact" OnCustomCallback="gvs_vchrdtls_CustomCallback" OnCustomSummaryCalculate="gvs_vchrdtls_CustomSummaryCalculate" RightToLeft="True" CssClass="grid">
                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowGroupFooter="VisibleAlways" GroupFormat="{0} {1} {2}" GroupFormatForMergedGroup="{0}:{1}" ShowGroupPanel="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <SettingsPager AlwaysShowPager="True" PageSize="50">
                            <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                        </SettingsPager>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
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
                            <dx:GridViewDataTextColumn FieldName="vchrdtlid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="chartid" VisibleIndex="1" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="chartcode" VisibleIndex="2" Caption="كود الحساب" Width="10%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="chartname" VisibleIndex="3" Caption="اسم الحساب">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ref" VisibleIndex="4" Caption="رقم المستند" Width="10%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="debit" VisibleIndex="5" Caption="مدين" Width="10%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="credit" VisibleIndex="6" Caption="دائن" Width="10%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ccid" VisibleIndex="7" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="8" Caption="مركز التكلفه" Width="12%">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="descp" VisibleIndex="9" Caption="شرح الحركه">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="chartcode" ShowInColumn="كود الحساب" SummaryType="Count" DisplayFormat="العدد={0}" />
                            <dx:ASPxSummaryItem FieldName="debit" ShowInColumn="مدين" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="credit" ShowInColumn="دائن" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="ccname" ShowInColumn="مركز التكلفه" SummaryType="Custom" />
                        </TotalSummary>
                        <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                    </dx:ASPxGridView>


                    <dx:ASPxGridViewExporter ID="gvitemsExporter" runat="server" FileName="تفاصيل القيود اليومية" GridViewID="gvs_vchrdtls" PaperKind="A4" PaperName="القيود اليومية" RightToLeft="True" Landscape="True">
                        <PageHeader Center="تفاصيل القيود اليومية" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_attach" />
            <asp:PostBackTrigger ControlID="formLayout$btn_download" /> 
            <asp:PostBackTrigger ControlID="formLayout$upload" />

        </Triggers>
    </asp:UpdatePanel>





</asp:Content>
