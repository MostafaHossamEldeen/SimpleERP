<%@ Page Title="فواتـــير البيــــع" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="invtest.aspx.cs" Inherits="VanSales.invtest" %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <script src="../Scripts/App/sales/inv.js"></script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="فواتـــــير البيـــــع" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">
                
                <%--<asp:ImageButton ID="btn_Save" runat="server" ImageUrl="~/img/icon/save.svg" Height="33px" OnClick="btn_Save_Click" Width="40px" ToolTip="حفظ" />--%>
                <dx:ASPxButton ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
                    <ClientSideEvents Click="function(s, e) {
	validate(s, e);
}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_addnew_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد">
                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <dx:ASPxButton ID="btn_delete" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_delete_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">


                    <ClientSideEvents Click="function(s, e) {
e.processOnServer = confirm('هل تريد الحذف؟'); }" />


                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <%--<asp:Button ID="btn_delete" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_delete_Click" RenderMode="Secondary" Width="20px" ToolTip="حذف" OnClientClick="return confirm (&quot;هل تريد الحذف&quot;)" />--%>
                <dx:ASPxButton ID="btn_search" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="بحث">

                    <ClientSideEvents Click="function(s, e) {
invsearch();return false;
}" />

                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <%--<asp:ImageButton ID="btn_search" runat="server" ImageUrl="~/img/icon/search.svg" Height="33px" Width="40px" OnClientClick="invsearch();return false;" ToolTip="بحث" />--%>
                <dx:ASPxButton ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">

                    <ClientSideEvents Click="function(s, e) {
print_newtab();
}" />

                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />
              
            </div>

            <br />
            <%--class="dx-justification"--%>
            <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="5" GroupBoxDecoration="None">
                            <Items>
                                <dx:LayoutItem Caption="رقم الفاتوره">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sinvno"   runat="server" ClientInstanceName="txtinvno" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">
                                                <ClientSideEvents KeyDown="function(s,e){preventwrite(s,e)}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="رقم يدوى للفاتوره">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sinvdocno" runat="server" Theme="MaterialCompact" Style="margin-right: 0px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="نوع سداد الفاتوره">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="dll_sinvpay" runat="server" ClientInstanceName="dll_sinvpay" DataSourceID="SqlDataSource1" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid"  AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="9" Name="compid" Type="Int32" />
                                                    <asp:Parameter DefaultValue="sys_fillcomp" Name="table_name" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>


                                <dx:LayoutItem Caption="التاريخ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="sinvdata"></asp:RequiredFieldValidator>--%>
                                            <dx:ASPxDateEdit ID="sinvdata" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="sinvdata">
                                                <%--<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />--%>
                                            </dx:ASPxDateEdit>


                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>


                                <dx:LayoutItem Caption="الوقت">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sinvtime" runat="server" CssClass="auto-style2" Enabled="False" Theme="MaterialCompact">
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                            </Items>
                        </dx:LayoutGroup>
                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="box" Caption="بيانات العميل" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_cusid" runat="server" Theme="MaterialCompact"  ClientInstanceName="txt_cusid" AutoPostBack="True" OnTextChanged="txt_cusid_TextChanged">
  
                                            </dx:ASPxTextBox>
                                            <%--<asp:RequiredFieldValidator ID="txt_cus_id_req" runat="server" ErrorMessage="*" ControlToValidate="txt_cusid" Enabled="false" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txt_cusid" Enabled="false" ForeColor="Red"></asp:RequiredFieldValidator>
                            <dx:ASPxTextBox ID="txt_cusid" runat="server"  Theme="MaterialCompact" Text="0">
                            </dx:ASPxTextBox>--%>
                                            <dx:ASPxButton ID="btn_cus" runat="server" AutoPostBack="False" Height="20px"  RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="بحث">
                                                <ClientSideEvents Click="function(s, e) {
	cus_search();return false;
}" />
                                                <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                </Image>
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="ctn_add_cus" runat="server" AutoPostBack="False" Height="20px" OnClick="ctn_add_cus_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="اضافه عميل">
                                                <ClientSideEvents Click="function(s, e) {
	add_cus();return false;
}" />
                                                <Image Height="20px" Url="~/Img/Icon/add-user.svg" Width="20px">
                                                </Image>
                                            </dx:ASPxButton>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="اسم العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_cusname" ClientInstanceName="ctname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            <%--<asp:RequiredFieldValidator ID="Required_cusname" runat="server" ErrorMessage="*" ControlToValidate="txt_cusname" Enabled="false"  ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الرقم الضريبى للعميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custvat" ClientInstanceName="txt_custvat" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="عنوان العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custadd" ClientInstanceName="txt_custadd" runat="server" Theme="MaterialCompact">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="المندوب">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="dll_sman" runat="server" DataSourceID="SqlDataSource2" RightToLeft="True" TextField="smanname" Theme="MaterialCompact" ValueField="smanid" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="0" Name="compid" Type="Int32" ConvertEmptyStringToNull="true" />
                                                    <asp:Parameter DefaultValue="s_sman" Name="table_name" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>

                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="المستخدم">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_suser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_suser">
                                                <ClientSideEvents Init="function(s, e) {
	txt_suser.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الملاحظات">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxMemo ID="txt_snotes" runat="server" Theme="MaterialCompact" Width="100%">
                                            </dx:ASPxMemo>


                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="المستند">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <dx:ASPxLabel ID="lbl_filename" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="50%">
                                            </dx:ASPxLabel>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <asp:ImageButton ID="upload" runat="server" OnClick="upload_Click" ImageUrl="~/img/icon/import.svg" Height="30px" Width="30px" ToolTip="رفع ملف" />

                                            <asp:ImageButton ID="btn_download" runat="server" Height="30px" ImageUrl="~/img/icon/download.svg" OnClick="btn_download_Click" ToolTip="تحميل" Width="30px" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>


                        <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="الصافى بدون الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_netbvat" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_netbvat" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
	txt_netbvat.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="قيمه الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_vatvalue" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_vatvalue" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
	txt_vatvalue.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الصافى شامل الضريبه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_netavat" runat="server" Text="0" Theme="MaterialCompact" Font-Bold="True" ClientInstanceName="txt_netavat" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
	txt_netavat.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="الباقى">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_restvalue" runat="server" Font-Bold="True" Text="0" Theme="MaterialCompact" Width="80%" ClientInstanceName="txt_restvalue" Font-Size="Medium" ForeColor="Black">
                                                <ClientSideEvents Init="function(s, e) {
                            
	txt_restvalue.GetInputElement().readOnly = true; 
}" />
                                            </dx:ASPxTextBox>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>

             
                <br />
            </asp:Panel>
              <dx:ASPxLabel ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="#009900" ></dx:ASPxLabel>

            <asp:HiddenField ID="HF_inv_id" ClientIDMode="Static" runat="server" OnValueChanged="HF_inv_id_ValueChanged" />
            <asp:HiddenField ID="Hfcusid" ClientIDMode="Static" runat="server" OnValueChanged="Hfcusid_ValueChanged" />
            <br />
            <%--    <div style="text-align: right" id="accordion">
        <h1 dir="rtl">اصناف الفاتوره</h1>--%>

            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" Visible="false" BorderStyle="Groove" Font-Bold="True" Direction="RightToLeft" Style="text-align: right">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="14" GroupBoxDecoration="box" Caption="اصناف الفاتوره" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_item" runat="server" Theme="MaterialCompact" OnTextChanged="txt_item_TextChanged" AutoPostBack="True">
                                                    <ClientSideEvents Init="function(s, e) {
	multiply()
}" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%--  <asp:ImageButton ID="btn_items" runat="server" CssClass="auto-style2" Height="20px" ImageUrl="~/img/icon/search.svg"  OnClientClick="itemsearch();return false;" ToolTip="بحث" />--%>
                                                <dx:ASPxButton ID="btn_items" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="بحث">
                                                    <ClientSideEvents Click="function(s, e) {
	itemsearch();return false;
}" />
                                                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                    </Image>
                                                </dx:ASPxButton>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="الصنف" Width="13%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_item_name" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_item_name">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_item_name.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="وحده القياس" Width="9%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_unit" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_unit">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_unit.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="الكميه">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact">

                                                    <ClientSideEvents KeyUp="function(s, e) {multiply()}" GotFocus="function(s, e) {
	txt_qty.SelectAll();
}"
                                                        KeyPress="function(s, e) {
	isFloatNumber(this,event)
}" />

                                                </dx:ASPxTextBox>


                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="السعر">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_price" runat="server" Text="0" CssClass="auto-style2" Theme="MaterialCompact" ClientInstanceName="txt_price">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_price.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الاجمالى" Width="8%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_value" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_value" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_value.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discp" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discp">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiplydis()}" KeyPress="function(s, e) {isFloatNumber(this,event)}" GotFocus="function(s, e) {
	txt_discp.SelectAll();
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discvalue">
                                                    <ClientSideEvents KeyUp="function(s, e) {calac_disc();}" KeyPress="function(s, e) {isFloatNumber(this,event)}" GotFocus="function(s, e) {
	txt_discvalue.SelectAll();
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصافى" Width="9%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_netvalue" runat="server" Text="0" OnTextChanged="txt_netvalue_TextChanged" Theme="MaterialCompact" ClientInstanceName="txt_netvalue" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {Subtract(); txt_netvalue.GetInputElement().readOnly = true;  }" TextChanged="function(s, e){calac_vat()}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الضريبه">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemvatvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txt_itemvatvalue">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_itemvatvalue.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملاحظات" Width="11%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemnotes" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton ID="btn_save_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" >
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" ClientSideEvents-Click="function(s,e){addGridRow('gvs_invdtls',['txt_discp','txt_price'])}">
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btn_delete_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" OnClick="btn_delete_dtls_Click">
                                                    <ClientSideEvents Click="function(s, e) {getrow_dtlinv();
                                       e.processOnServer = confirm('هل تريد الحذف؟');}" />
                                                    <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                    <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="ادخال سريع" Height="20px" Width="20px" >
                                                          <Image Height="20px" Url="~/img/icon/bookmark.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {
                                       loadinv()}" />
                                                    
                                                </dx:ASPxButton>
                                               <%-- <a href="#" onclick="loadinv()"><span class="fa fa-android">Quick</span><i class="fa fa-opencart"></i></a>--%>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                 
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>

                  
                    <asp:HiddenField ID="HfItemID" ClientIDMode="Static" runat="server" OnValueChanged="HfItemID_ValueChanged" />
                    <asp:HiddenField ID="Hfuntid" runat="server" />
                    <span class="mb-0 ">
                        <asp:HiddenField ID="Hfvat" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hf_qty" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hf_disc" runat="server" ClientIDMode="Static" />
                    </span>
                    <asp:HiddenField ID="HFsinviddtl" runat="server" ClientIDMode="Static" />
                    <dx:ASPxGridView ID="gvs_invdtls" ClientInstanceName="gvs_invdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" "  Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" OnSelectionChanged="gvs_invdtls_SelectionChanged" OnDataBound="gvs_invdtls_DataBound" CssClass="grid" OnRowInserted="gvs_invdtls_RowInserted">



                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="true"  />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="invdtlid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemcode" VisibleIndex="1" Caption="كود الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemname" VisibleIndex="2" Caption="اسم الصنف">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitid" VisibleIndex="3" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="unitname" VisibleIndex="4" Caption="الوحده">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="5" Caption="الكميه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="price" VisibleIndex="6" Caption="السعر">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="icost" VisibleIndex="7" Caption="التكلفه" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="value" VisibleIndex="8" Caption="الاجمالى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discp" VisibleIndex="9" Caption="نسبه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="discvalue" VisibleIndex="10" Caption="قيمه الخصم">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="netvalue" VisibleIndex="11" Caption="الصافى">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="vatvalue" VisibleIndex="12" Caption="الضريبه">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemnotes" VisibleIndex="13" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
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
                        <SettingsEditing Mode="Inline"></SettingsEditing>
                        <TotalSummary>
                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="الكميه" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="price" ShowInColumn="السعر" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="netvalue" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="{0}" />
                        </TotalSummary>
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_invdtls_sel" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HF_inv_id" Name="sinvid" PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </div>


            <br />

            <asp:Panel ID="p_invpay" runat="server" Visible="false" BorderStyle="Groove" Font-Bold="True" Direction="RightToLeft" Style="text-align: right">
                <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="5" GroupBoxDecoration="box" Caption="طرق الدفع" UseDefaultPaddings="false" Paddings-PaddingTop="10" CellStyle-Font-Bold="true">
                            <Paddings PaddingTop="10px" />
                            <CellStyle Font-Bold="True">
                            </CellStyle>
                            <Items>
                                <dx:LayoutItem Caption="طريقه الدفع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxComboBox ID="dll_paytype" runat="server" DataSourceID="Sqldll_paytype" Theme="MaterialCompact" TextField="paytname" ValueField="paytypeid" RightToLeft="True"></dx:ASPxComboBox>

                                            <asp:SqlDataSource ID="Sqldll_paytype" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="0" Name="compid" Type="Int32" />
                                                    <asp:Parameter DefaultValue="sys-paytype" Name="table_name" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txt_cusid" Enabled="false" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>


                                <dx:LayoutItem Caption="القيمه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_payvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txt_payvalue">
                                                <ClientSideEvents GotFocus="function(s, e) {txt_payvalue.SelectAll();}" KeyPress="function(s, e) {isFloatNumber(this,event)}"  />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="رقم مرجعى">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_payno" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>


                                <dx:LayoutItem Caption="بيانات">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_payref" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>


                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton ID="btn_save_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_pay_Click">
                                                <Image Height="20px" Url="~/Img/Icon/save.svg" Width="20px"></Image>
                                            </dx:ASPxButton>

                                            <dx:ASPxButton ID="brn_new_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" OnClick="brn_new_pay_Click">
                                                <Image Height="20px" Url="~/Img/Icon/add-new.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btn_delete_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" OnClick="btn_delete_pay_Click">
                                                <ClientSideEvents Click="function(s, e) {
    getrow();
	e.processOnServer = confirm('هل تريد الحذف؟');}" />
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

                
                <asp:HiddenField ID="Hfpayid" runat="server" ClientIDMode="Static"/>
                <dx:ASPxGridView ID="gv_invpay" runat="server" ClientInstanceName="gv_invpay" AutoGenerateColumns="False" EnableCallBacks="False" DataSourceID="SqlData_pay" Width="100%" KeyFieldName="invpayid" Theme="MaterialCompact" RightToLeft="True" OnSelectionChanged="gv_invpay_SelectionChanged" OnDataBound="gv_invpay_DataBound" CssClass="grid">

                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                    <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                    <Columns>
                        <dx:GridViewDataTextColumn FieldName="invpayid" ReadOnly="True" VisibleIndex="0" Visible="false">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="invid" VisibleIndex="1" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="paytypeid" VisibleIndex="2" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payname" VisibleIndex="3" Caption="طريقه الدفع">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="paychartid" VisibleIndex="4" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payvalue" VisibleIndex="5" Caption="القيمه">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payno" VisibleIndex="6" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="payref" VisibleIndex="7" Caption="البيانات">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="branchid" VisibleIndex="8" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataDateColumn FieldName="invdate" VisibleIndex="9" Visible="false">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataTextColumn FieldName="natureinv" VisibleIndex="10" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custid" VisibleIndex="11" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="sinvno" VisibleIndex="12" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="custname" VisibleIndex="13" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="branchname" VisibleIndex="14" Visible="false">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="fyear" VisibleIndex="15" Visible="false">
                        </dx:GridViewDataTextColumn>
                    </Columns>
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
                        <dx:ASPxSummaryItem FieldName="payvalue" ShowInColumn="القيمه" SummaryType="Sum" DisplayFormat=" {0}" />

                    </TotalSummary>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlData_pay" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_invpay_sel" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HF_inv_id" Name="inv_id" PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

            </asp:Panel>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Panel1$formLayout$btn_download" />
            <asp:PostBackTrigger ControlID="Panel1$formLayout$upload" />


        </Triggers>
    </asp:UpdatePanel>



    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup" ShowMaximizeButton="true" Width="1200px" Height="700px" AllowResize="true" HeaderText="" 
        CloseAction="CloseButton" AllowDragging="true" Modal="true" PopupHorizontalAlign="Center" PopupVerticalAlign="Middle">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
 
</asp:Content>
