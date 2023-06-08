<%@ Page Title="الســـلف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_loans.aspx.cs" Inherits="VanSales.HR.hr_loans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
     <script src="../Scripts/App/HR/hr_loans.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="الســلف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">   
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_addnew_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">

                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/hr_loans/LoansDelMaster', 'HF_loanid') }" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <button type="button" id="PopUpControl1" data-name="nav" data-tablename="hr_loans_sel_search" data-displayfields="loanno,loandate,empname,lvalue"
                    data-displayfieldshidden="empid,lcrditcahrtid,postacc,vochrid,ltype,lnature,salarydeduct,loanid,loannotes"
                    data-displayfieldscaption="رقم السلفه,التاريخ,الموظف,المبلغ"
                    data-bindcontrols="txt_loanno;txt_loandate;txt_empname;HF_empid;txt_empid;txt_chartname;txt_chartid;txt_lvalue;HF_lcrditcahrtid;HF_postacc;txt_vochrid;cmb_ltype;cmb_lnature;HF_lnature;ch_salarydeduct;HF_loanid;txt_loannotes"
                    data-bindfields="loanno;loandate;empname;empid;empcode;chartname;chartcode;lvalue;lcrditcahrtid;postacc;vochrid;ltype;lnature;lnature;salarydeduct;loanid;loannotes"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="loanid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                      <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل حسابات">
                    <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                </dx:ASPxButton>
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
                            <dx:LayoutItem Caption="رقم السلفه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxTextBox ID="txt_loanno" runat="server" ClientInstanceName="txt_loanno" Theme="MaterialCompact" Font-Bold="True" Text="تلقائى">

                                            <ClientSideEvents KeyDown="function(s,e){preventwrite1(s,e);}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                          
                            <dx:LayoutItem Caption="نوع السلفه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_ltype" runat="server" ClientInstanceName="cmb_ltype" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false" >
                                        <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCountryChanged(s); }" />
                                            </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="تاريخ السلفه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_loandate" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_loandate">
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
                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="box" Caption="بيانات الحساب" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>
                        <dx:LayoutItem Caption="كود الحساب"  >
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_chartid"  runat="server" Theme="MaterialCompact" AutoPostBack="false" ClientInstanceName="txt_chartid" TabIndex="0" >
                                                    <ClientSideEvents TextChanged="function(s,e){setchartData(s,e)}"/>

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                             <dx:LayoutItem Caption=""   ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection >
                                            <dx:LayoutItemNestedControlContainer  >
                                                
                                                   <button  type="button" id="Pop_chart" data-name="chart" onclick="createPopUp($(this))" data-TableName="gl_chart_sel_pop"  data-DisplayFields="chartcode,chartname" data-DisplayFieldsHidden="chartid"
        data-DisplayFieldsCaption="كود الحساب,اسم الحساب" data-BindControls="txt_chartid;txt_chartname;HF_lcrditcahrtid"
        data-BindFields="chartcode;chartname;chartid" data-PkField="chartid" data-ApiUrl="/VanSalesService/Vouchers/chartSearch" data-ParamaterNames="HF_legertype"   class="btn btn-sm btnsearchpopup" tabindex="1" />
                                                      

                                            
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                           <dx:LayoutItem Caption="اسم الحساب" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="0">
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

                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>



                            <dx:LayoutItem Caption="قيمه السلفه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxSpinEdit ID="txt_lvalue" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_lvalue" Number="1" MinValue="1" MaxValue="999999">
                                        </dx:ASPxSpinEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>



                            <dx:LayoutItem Caption="طبيعه السلفه" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_lnature" runat="server" ClientInstanceName="cmb_lnature" OnCallback="cmb_lnature_Callback" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                      <ClientSideEvents EndCallback=" OnEndCallback" />
                                            </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>



                            <dx:LayoutItem Caption="" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="ch_salarydeduct" runat="server" Text="تخصم من الراتب" ClientInstanceName="ch_salarydeduct" CheckState="Unchecked" AutoPostBack="false">
                                        </dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                                    <dx:LayoutItem Caption="الملاحظات" ColumnSpan="3">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_loannotes" runat="server" ClientInstanceName="txt_loannotes" Theme="MaterialCompact" Width="100%">
                                        </dx:ASPxMemo>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                                   <dx:LayoutItem Caption="رقم القيد" Paddings-PaddingTop="10" >
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                       <%--     <dx:ASPxTextBox ID="txt_vochrid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_vochrid">
                                                <ClientSideEvents Init="function(s, e) {
	txt_vochrid.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>--%>
                                               <dx:ASPxHyperLink ID="txt_vochrid" runat="server" ClientInstanceName="txt_vochrid">
                                        </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" Paddings-PaddingTop="10">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                                           <dx:ASPxLabel ID="lbl_postacc" runat="server" ClientInstanceName="lbl_postacc" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>
     
                                            </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>

                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="HF_loanid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_empid" ClientIDMode="Static" runat="server" />
             <asp:HiddenField ID="HF_lnature" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_lcrditcahrtid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_postacc" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_legertype" ClientIDMode="Static" runat="server" Value="1" />
        </ContentTemplate>
        <Triggers>
        </Triggers>

    </asp:UpdatePanel>
</asp:Content>
