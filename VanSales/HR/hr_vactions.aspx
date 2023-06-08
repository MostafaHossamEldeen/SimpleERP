<%@ Page Title="الاجــــازات" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_vactions.aspx.cs" Inherits="VanSales.HR.hr_vactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/HR/hr_vactions.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="الاجــــازات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" ClientInstanceName="btn_Save" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) {
	validate(s, e);
}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_addnew_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">

                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/hr_vactions/VactionsDelMaster', 'HF_vid') }" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <button type="button" id="PopUpControl1" data-name="nav" data-tablename="hr_vactions_sel_search" data-displayfields="vno,vdate,empname"
                    data-displayfieldshidden="empid,vdays,vfromd,vtodate,vnotes,vnameid,vnametype,vapp,vuser,vappuser,vnature,vid"
                    data-displayfieldscaption="رقم الاجازه,التاريخ,الموظف"
                    data-bindcontrols="txt_vno;txt_vdate;txt_empname;HF_empid;txt_empid;txt_vdays;txt_vfromd;txt_vtodate;txt_vnotes;cmb_vnameid;cmb_vapp;rbl_vapp;txt_vuser;txt_vappuser;cmb_vnature;HF_vid"
                    data-bindfields="vno;vdate;empname;empid;empcode;vdays;vfromd;vtodate;vnotes;vnameid;vapp;vapp;vuser;vappuser;vnature;vid"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="vid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />

            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="رقم الاجازه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxTextBox ID="txt_vno" runat="server" ClientInstanceName="txt_vno" Theme="MaterialCompact" Font-Bold="True" Text="تلقائى">

                                            <ClientSideEvents KeyDown="function(s,e){preventwrite1(s,e);}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="طبيعه الاجازه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_vnature" runat="server" ClientInstanceName="cmb_vnature" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="تاريخ طلب الاجازه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_vdate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_vdate">
                                        </dx:ASPxDateEdit>
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
                                            <ClientSideEvents ValueChanged="function(s, e) {
	setEmpData(s, e)}" />
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
                                        <%--<dx:ASPxButton UseSubmitBehavior="false" ID="ctn_add_cus" runat="server"  AutoPostBack="False" Height="20px"   RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="اضافه عميل">

                                                <ClientSideEvents Click="function(s, e) {add_cus();}" />
                                                <Image Height="20px" Url="~/Img/Icon/add-user.svg" Width="20px">
                                                </Image>
                                          
                                            </dx:ASPxButton>  --%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                                <ParentContainerStyle>
                                    <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                </ParentContainerStyle>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="اسم الموظف">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_empname" ClientInstanceName="txt_empname" runat="server" Theme="MaterialCompact">
                                            <ClientSideEvents Init="function(s, e) {
	txt_empname.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>
                            <dx:LayoutItem Caption="تاريخ البدايه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_vfromd" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_vfromd">
                                            <ClientSideEvents ValueChanged="function(s,e){numberofdays()}" />
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="تاريخ النهايه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_vtodate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_vtodate">
                                            <ClientSideEvents ValueChanged="function(s,e){numberofdays()}" />
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="عدد الايام">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxSpinEdit ID="txt_vdays" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_vdays" Number="1">
                                        </dx:ASPxSpinEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="نوع الاجازه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_vnameid" runat="server" ClientInstanceName="cmb_vnameid" RightToLeft="True" TextField="mitemname" Theme="MaterialCompact" ValueField="mitemcode" AutoPostBack="false">
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
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <%--<dx:ASPxCheckBox ID="chk_vnametype" runat="server" Text="تخصم من الاجازه السنويه" AutoPostBack="false"  ClientInstanceName="chk_vnametype"></dx:ASPxCheckBox>--%>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="اسم صاحب الموافقه" Paddings-PaddingTop="20">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_vappuser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_vappuser">
                                            <ClientSideEvents Init="function(s, e) {
	txt_vappuser.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>


                            <dx:LayoutItem Caption="حاله الاجازه" Paddings-PaddingTop="20">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_vapp" runat="server" ClientInstanceName="cmb_vapp" RightToLeft="True" TextField="citemname"   Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                            <%--<ClientSideEvents Init="function(s, e) {
	cmb_vapp.GetInputElement().readOnly = true; 
}" />--%>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxRadioButtonList ID="rbl_vapp" ClientInstanceName="rbl_vapp" runat="server" Border-BorderStyle="None" RepeatDirection="Horizontal">
                                            <Items>
                                                <dx:ListEditItem Selected="false" Text="موافقه " Value="2"></dx:ListEditItem>
                                                <dx:ListEditItem Text="رفض" Value="1"></dx:ListEditItem>
                                            </Items>
                                        </dx:ASPxRadioButtonList>
                                        <dx:ASPxButton UseSubmitBehavior="false" ID="update_vapp" runat="server" AutoPostBack="False" Height="20px" OnClick="update_vapp_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                                            <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                        </dx:ASPxButton>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الملاحظات" ColumnSpan="3">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_vnotes" runat="server" ClientInstanceName="txt_vnotes" Theme="MaterialCompact" Width="100%">
                                        </dx:ASPxMemo>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>


                        </Items>
                    </dx:LayoutGroup>

                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="HF_vid" ClientIDMode="Static" runat="server" />
            
            <asp:HiddenField ID="HF_empid" ClientIDMode="Static" runat="server" />
        </ContentTemplate>
        <Triggers>
             <asp:PostBackTrigger ControlID="btn_print" />
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>
