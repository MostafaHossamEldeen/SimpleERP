<%@ Page Title="متغيرات الرواتب" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hr_salaryvarables.aspx.cs" Inherits="VanSales.HR.hr_salaryvarables" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/Public/Messages.js"></script>
    <script src="../Scripts/App/HR/hr_salaryvarables.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="متغيرات الرواتب" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/HR/salaryvarables_del', 'HF_svid') }" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <button type="button" id="PopUpControl1" data-name="var" data-tablename="hr_salaryvarables_sel_pop" data-displayfields="svno,empname,monyrname,svname,svnaturename"
                    data-displayfieldshidden="empid,vdays,vfromd,vtodate,vnotes,vnameid,vnametype,vapp,vuser,vappuser,vnature,vid"
                    data-displayfieldscaption="رقم المتغير,الموظف,الشهر/السنة,النوع,المتغير"
                    data-bindcontrols="txt_svno;txt_svdate;cmb_svtype;cmb_svnatuleid;txt_svarbalename;cmb_monyrid;txt_empid;txt_empname;ck_stopped;ck_addbsalary;txt_salary;txt_ratio;txt_days;txt_vvalue;txt_vnotes;HF_empid;HF_svid"
                    data-bindfields="svno;svdate;svtype;svnatuleid;svarbalename;monyrid;empcode;empname;stopped;addbsalary;salary;ratio;days;vvalue;vnotes;empid;svid"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="svid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>

                <br />

            </div>
            <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="رقم المتغير">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_svno" runat="server" ClientInstanceName="txt_svno" Font-Bold="True" Text="تلقائى">
                                            <ClientSideEvents KeyDown="function(s,e){preventwrite1(s,e);}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            
                            <dx:LayoutItem Caption="التاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxDateEdit ID="txt_svdate" runat="server" RightToLeft="True" ClientInstanceName="txt_svdate">
                                        </dx:ASPxDateEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="نوع المتغير">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_svtype" runat="server" ClientInstanceName="cmb_svtype"  OnCallback="cmb_svtype_Callback">
                                         <ClientSideEvents SelectedIndexChanged="function(s, e) { OnsvnatuleidChanged(s); }" TextChanged="function(s,e){OnsvnatuleidChanged(s);}" />
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                        </Items>
                    </dx:LayoutGroup>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" Caption="">
                        <Items>
                            <dx:LayoutItem Caption="طبيعة المتغير">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_svnatuleid" runat="server" ClientInstanceName="cmb_svnatuleid" OnCallback="cmb_svtype_Callback">
                                            <ClientSideEvents ValueChanged="function(s, e) {
	getempsalary()
}"
  EndCallback="OnEndCallback">
                                            </ClientSideEvents>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="إسم تفصيلي">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_svarbalename" runat="server" ClientInstanceName="txt_svarbalename" Font-Bold="True">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            
                            <dx:LayoutItem Caption="الشهر / السنة">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_monyrid" runat="server" ClientInstanceName="cmb_monyrid">
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
                                            <ClientSideEvents ValueChanged="function(s, e) {
	setEmpData(s, e)}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <button type="button" id="puop_emp" data-name="emp" onclick="createPopUp($(this))" data-tablename="hr_employees_sel_search" data-displayfields="empcode,empname,empmob,embemail"
                                            data-displayfieldshidden="empidno,empid" data-displayfieldscaption="كود الموظف,اسم الموظف" data-bindcontrols="txt_empid;txt_empname;HF_empid"
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
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                        <Paddings PaddingTop="10px" />
                        <Items>
                            <dx:LayoutItem Caption="توقف المتغير">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="ck_stopped" ClientInstanceName="ck_stopped" ToggleSwitchDisplayMode="Always" runat="server" ValueGrayed="false"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="يضاف الى الراتب الأساسي">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxCheckBox ID="ck_addbsalary" ClientInstanceName="ck_addbsalary" ToggleSwitchDisplayMode="Always" runat="server" ValueGrayed="false"></dx:ASPxCheckBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الراتب المحسوب منة">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_salary" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_salary">
                                            <ClientSideEvents KeyDown="function(s,e){preventwrite1(s,e);}"/>
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="النسبة">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxSpinEdit ID="txt_ratio" runat="server" ClientInstanceName="txt_ratio" MaxValue="100" MinValue="1">
                                            <ClientSideEvents ValueChanged="function(s, e) {
	vvalue_ratio_calc();
}"></ClientSideEvents>
                                        </dx:ASPxSpinEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="عدد الأيام">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxSpinEdit ID="txt_days" runat="server" ClientInstanceName="txt_days" MaxValue="31" MinValue="1">
                                            <ClientSideEvents ValueChanged="function(s, e) {vvalue_day_calc();}"></ClientSideEvents>
                                        </dx:ASPxSpinEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="القيمة">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxSpinEdit ID="txt_vvalue" runat="server" ClientInstanceName="txt_vvalue" MaxValue="9999999" MinValue="1" Font-Bold="true">
                                        </dx:ASPxSpinEdit>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="الملاحظات" ColumnSpan="3">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_vnotes" runat="server" ClientInstanceName="txt_vnotes" Width="100%">
                                        </dx:ASPxMemo>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>

                        </Items>
                    </dx:LayoutGroup>

                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField ID="HF_svid" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="HF_empid" ClientIDMode="Static" runat="server" />
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>