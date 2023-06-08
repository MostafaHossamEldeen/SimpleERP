<%@ Page Title="مرتــجع المبيــعات" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rtn_inv.aspx.cs" Inherits="VanSales.Sales.Rtn_inv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/sales/Rtn_inv.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="مرتـجع المبيــعات" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
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

                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/invoice/RtnInvDelMaster', 'HF_rtninvid') }" />
                    <%--<ClientSideEvents Click="function(s, e) {delData('/Sales/Rtn_inv.aspx/Deletedata' ,'rtninvid','HF_rtninvid') }" />--%>


                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <%--  <dx:ASPxButton ID="btn_delete" ClientInstanceName="btn_delete" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_delete_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">


                    <ClientSideEvents Click="function(s, e) {
     e.processOnServer = confirm('هل تريد الحذف؟');          
}" />
                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>--%>
                <%-- <dx:ASPxButton ID="btn_search" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="بحث">

                    <ClientSideEvents Click="function(s, e) {
Rtn_search();return false;
}" />
                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px"></Image>
                </dx:ASPxButton>--%>
                <button type="button" id="PopUpControlSearch" data-name="inv" data-tablename="s_rtn_inv_sel_search" data-displayfields="sinvno,sinvdocno,sinvdata"
                    data-displayfieldshidden="sinvpay,branchid,smanid,sinvtime,custid,custname,custvat,custadd,custmobile,suser,snotes,netbvat,vatvalue,netavat,invdoc,docid,docno,sinvid,postst,postacc,withoutinv,vochrno"
                    data-displayfieldscaption="رقم الفاتوره,الرقم اليدوى,التاريخ"
                    data-bindcontrols="txt_rtn_sinvno;txt_sinvdocno;sinvdata;cmb_branchid;dll_sinvpay;cmb_smanid;cmb_ccid;txt_sinvtime;Hf_cusid;txt_cusid;ctname;txt_custvat;txt_custadd;txt_custmobile;txt_suser;txt_snotes;txt_netbvat;txt_vatvalue;txt_netavat;lbl_invdoc;txt_invno;HF_rtninvid;HF_invid;hf_postst;hf_posyacc;ch_inv;lbl_vochrno"
                    data-bindfields="sinvno;sinvdocno;sinvdata;branchid;sinvpay;smanid;ccid;sinvtime;custid;custid;custname;custvat;custadd;custmobile;suser;snotes;netbvat;vatvalue;netavat;invdoc;docno;sinvid;docid;postst;posyacc;withoutinv;vochrno"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="sinvid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                 <dx:ASPxButton   UseSubmitBehavior="false" ID="btn_postst" runat="server" ClientInstanceName="btn_postst"  AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل مستودعات">
                    <ClientSideEvents Click="function(s,e){postRtnInvStock(s,e)}" />
                    <Image Height="20px" Url="~/img/icon/poststock.svg" Width="20px"></Image>
                </dx:ASPxButton>
                        
                 <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" runat="server" AutoPostBack="False" ClientInstanceName="btn_postacc"   Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل حسابات">
                    <ClientSideEvents Click="function(s,e){postRtnInvAcc(s,e)}" />
                     <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه" OnClick="btn_print_Click1" >

<%--                    <ClientSideEvents Click="function(s, e) {
print_newtab1();
}" />--%>

                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
            </div>
            <br />
            <div dir="rtl">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Groove" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                    <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="5" GroupBoxDecoration="None">
                                <Items>
                                    <dx:LayoutItem Caption="رقم المرتجع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_rtnsinvno" ClientInstanceName="txt_rtn_sinvno" runat="server" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_rtn_sinvno.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="رقم يدوى للمرتجع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_sinvdocno" ClientInstanceName="txt_sinvdocno" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="نوع سداد المرتجع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_sinvpay" runat="server" ClientInstanceName="dll_sinvpay" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false"></dx:ASPxComboBox>
                                                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="9" Name="compid" Type="Int32" />
                                                        <asp:Parameter DefaultValue="sys_fillcomp" Name="table_name" Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الفرع">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_branchid" runat="server" ClientInstanceName="cmb_branchid" RightToLeft="True" TextField="branchname" Theme="MaterialCompact" ValueField="branchid" AutoPostBack="false">
                                                </dx:ASPxComboBox>
                                                <%--   <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="0" Name="compid" Type="Int32" ConvertEmptyStringToNull="true" />
                                                    <asp:Parameter DefaultValue="s_sman" Name="table_name" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="التاريخ*">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%-- <asp:RequiredFieldValidator ID="Required_V_date" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="sinvdata"></asp:RequiredFieldValidator>--%>
                                                <dx:ASPxDateEdit ID="txt_sinvdata" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="sinvdata">
                                                    <%-- <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                        <RequiredField IsRequired="true" ErrorText="*" />
                                                    </ValidationSettings>--%>
                                                </dx:ASPxDateEdit>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="مراكز التكلفه">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_ccid" runat="server" ClientInstanceName="cmb_ccid" RightToLeft="True" TextField="ccname" Theme="MaterialCompact" ValueField="ccid" AutoPostBack="false">
                                                </dx:ASPxComboBox>
                                                <%--   <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="0" Name="compid" Type="Int32" ConvertEmptyStringToNull="true" />
                                                    <asp:Parameter DefaultValue="s_sman" Name="table_name" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                      <dx:LayoutItem Caption="رقم الفاتوره">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_invno" ClientInstanceName="txt_invno" runat="server" Theme="MaterialCompact">

                                                    <ClientSideEvents TextChanged="function(s, e) {
	setInvData(s, e)
}"></ClientSideEvents>
                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                     <dx:LayoutItem Caption="" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 5px;">
                                                           <%-- <dx:ASPxButton ID="btn_search_inv" runat="server" ClientInstanceName="btn_search_inv" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="بحث">
                                                                <ClientSideEvents Click="function(s, e) {
	invsearch();return false;
}" />
                                                                <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                                </Image>
                                                            </dx:ASPxButton>--%>
                                                             <button type="button" id="btn_search_inv"  data-name="inv" data-TableName="s_inv_sel_search" data-DisplayFields="sinvno,sinvdocno,sinvdata" 
        data-DisplayFieldsHidden="custid,custname,custvat,custadd,custmobile,sinvid,smanid"
        data-DisplayFieldsCaption="رقم الفاتوره,الرقم اليدوى,التاريخ" 
        data-BindControls="txt_invno;txt_cusid;ctname;txt_custvat;txt_custadd;txt_custmobile;HF_invid;cmb_smanid"
                    data-BindFields="sinvno;custid;custname;custvat;custadd;custmobile;sinvid;smanid" 
        
        data-ApiUrl="/VanSalesService/items/FillPopup"  data-PkField="sinvid"   onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup"></button>

                                                        </td>

                                                        <td style="padding: 5px;">
                                                            <dx:ASPxCheckBox ID="chk_rtnall" runat="server" Text="ارجاع الكل" AutoPostBack="True" ClientInstanceName="chk_rtnall"></dx:ASPxCheckBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxCheckBox ID="ch_withoutinv" runat="server" Text="بدون فاتوره" ClientInstanceName="ch_inv" CheckState="Unchecked" AutoPostBack="true" OnCheckedChanged="ch_withoutinv_CheckedChanged">

                                                                <ClientSideEvents Init="function(s, e) {
	cus_validate(s, e)
}" />
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                   <%-- <dx:LayoutItem Caption="" ColumnSpan="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>--%>
                                    <dx:LayoutItem Caption="الوقت">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_sinvtime" runat="server" CssClass="auto-style2" ClientInstanceName="txt_sinvtime" Theme="MaterialCompact">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_sinvtime.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                 <%--   <dx:LayoutItem Caption="رقم الفاتوره">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_invno" ClientInstanceName="txt_invno" runat="server" Theme="MaterialCompact">

                                                    <ClientSideEvents TextChanged="function(s, e) {
	setInvData(s, e)
}"></ClientSideEvents>
                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>--%>
                              <%--      <dx:LayoutItem Caption="" ColSpan="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 5px;">
                                                            
                                                             <button type="button" id="btn_search_inv"  data-name="inv" data-TableName="s_inv_sel_search" data-DisplayFields="sinvno,sinvdocno,sinvdata" 
        data-DisplayFieldsHidden="custid,custname,custvat,custadd,custmobile,sinvid,smanid"
        data-DisplayFieldsCaption="رقم الفاتوره,الرقم اليدوى,التاريخ" 
        data-BindControls="txt_invno;txt_cusid;ctname;txt_custvat;txt_custadd;txt_custmobile;HF_invid;cmb_smanid"
                    data-BindFields="sinvno;custid;custname;custvat;custadd;custmobile;sinvid;smanid" 
        
        data-ApiUrl="/VanSalesService/items/FillPopup"  data-PkField="sinvid"   onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup"></button>

                                                        </td>

                                                        <td style="padding: 5px;">
                                                            <dx:ASPxCheckBox ID="chk_rtnall" runat="server" Text="ارجاع الكل" AutoPostBack="True" ClientInstanceName="chk_rtnall"></dx:ASPxCheckBox>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxCheckBox ID="ch_withoutinv" runat="server" Text="بدون فاتوره" ClientInstanceName="ch_inv" CheckState="Unchecked" AutoPostBack="true" OnCheckedChanged="ch_withoutinv_CheckedChanged">

                                                                <ClientSideEvents Init="function(s, e) {
	cus_validate(s, e)
}" />
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>--%>
                                    <%--             <dx:LayoutItem Caption="" ColSpan="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>--%>
                                </Items>
                            </dx:LayoutGroup>

                            <dx:LayoutGroup ColCount="4" GroupBoxDecoration="box" Caption="بيانات العميل" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                                <Paddings PaddingTop="10px" />
                                <Items>
                                    <dx:LayoutItem Caption="العميل">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_custid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_cusid">

                                                    <ClientSideEvents TextChanged="function(s, e) {
	setCustData(s, e)
}"></ClientSideEvents>
                                                </dx:ASPxTextBox>
                                                <%-- <asp:RequiredFieldValidator ID="txt_cus_id_req" runat="server" ErrorMessage="*" ControlToValidate="txt_cusid" Enabled="false" ForeColor="Red" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                 <button  type="button" id="puop_cust" data-name="cust" onclick="createPopUp($(this))"  data-TableName="s_customers_sel_search"  data-DisplayFields="custcode,custname,custadd,custmob" data-DisplayFieldsHidden="custvat,sgrpid,smanid,custid"
        data-DisplayFieldsCaption="كود العميل,إسم العميل,العنوان,التليفون" data-BindControls="txt_cusid;ctname;txt_custvat;txt_custadd;txt_custmobile;cmb_smanid;Hf_cusid"
        data-BindFields="custcode;custname;custvat;custadd;custmob;smanid;custid" data-PkField="custid" data-ApiUrl="/VanSalesService/items/FillPopup"  class="btn btn-sm btnsearchpopup"  >
                                                     </button>

                                           <%--     <dx:ASPxButton ID="btn_cus" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="بحث">
                                                    <ClientSideEvents Click="function(s, e) {
	cus_search();return false;
}" />
                                                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                    </Image>
                                                </dx:ASPxButton>--%>
                                                 
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="اسم العميل*">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_custname" ClientInstanceName="ctname" runat="server" Theme="MaterialCompact">
                                                </dx:ASPxTextBox>
                                                <%--<asp:RequiredFieldValidator ID="Required_cusname" runat="server" ErrorMessage="*" ControlToValidate="txt_cusname" Enabled="true" ForeColor="Red" SetFocusOnError="true"  ValidationGroup="formLayout"></asp:RequiredFieldValidator>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="الرقم الضريبى للعميل">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_custvat" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_custvat"></dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="عنوان العميل">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_custadd" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_custadd">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="تليفون العميل">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_custmobile" ClientInstanceName="txt_custmobile" runat="server" Theme="MaterialCompact">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="المندوب">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxComboBox ID="cmb_smanid" runat="server" DropDownStyle="DropDown" ClientInstanceName="cmb_smanid" RightToLeft="True" TextField="smanname" Theme="MaterialCompact" ValueField="smanid" AutoPostBack="false" SettingsLoadingPanel-Text="لحظه من فضلك">
                                                    <%--<Items>
                                                    <dx:ListEditItem Text="--اختر--" Value="-1" />
                                                </Items>--%>
                                                    <SettingsLoadingPanel Text="لحظه من فضلك" />
                                                </dx:ASPxComboBox>
                                                <%--    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:Parameter DefaultValue="0" Name="compid" Type="Int32" ConvertEmptyStringToNull="true" />
                                                        <asp:Parameter DefaultValue="s_sman" Name="table_name" Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>--%>
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
                                                <dx:ASPxMemo ID="txt_snotes" ClientInstanceName="txt_snotes" runat="server" Theme="MaterialCompact" Width="100%">
                                                </dx:ASPxMemo>


                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="المستند">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="FileUpload1" runat="server"  />
                                                <dx:ASPxLabel ID="lbl_invdoc" ClientInstanceName="lbl_invdoc" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="80%">
                                                </dx:ASPxLabel>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%--<asp:ImageButton ID="upload" runat="server" OnClick="upload_Click" ImageUrl="~/img/icon/import.svg" Height="30px" Width="30px" ToolTip="رفع ملف" />

                                                <asp:ImageButton ID="btn_download" runat="server" Height="30px" ImageUrl="~/img/icon/download.svg" OnClick="btn_download_Click" ToolTip="تحميل" Width="30px" />--%>
                                                
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="upload" runat="server" OnClick="upload_Click" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="رفع ملف">
                    <Image Height="20px" Url="~/img/icon/import.svg" Width="20px"></Image>
                </dx:ASPxButton>
                                           
                                        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_download" runat="server" OnClick="btn_download_Click" AutoPostBack="False" Height="30px" RenderMode="Secondary" Theme="MaterialCompact" Width="30px" ToolTip="تحميل">
                    <Image Height="20px" Url="~/img/icon/download.svg" Width="20px"></Image>
                </dx:ASPxButton>
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
                                     <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                          
                                        <dx:ASPxLabel ID="lbl_postst" runat="server" ClientInstanceName="lbl_postst" Visible="true" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxLabel ID="lbl_postacc" runat="server" ClientInstanceName="lbl_postacc" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxHyperLink ID="lbl_vochrno" runat="server" ClientInstanceName="lbl_vochrno" Font-Bold="True" ForeColor="#009933" Font-Size="Medium">                                             
                                            </dx:ASPxHyperLink>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                    </dx:ASPxFormLayout>

                    <br />
                </asp:Panel>
            </div>
            <span class="mb-0 ">
                <asp:HiddenField ID="HF_rtninvid" ClientIDMode="Static" runat="server" />
                <%--OnValueChanged="HF_rtninvid_ValueChanged"--%>
            </span>
            <asp:HiddenField ID="HF_invid" ClientIDMode="Static" runat="server" />
            <%--OnValueChanged="HF_invid_ValueChanged"--%>
            <asp:HiddenField ID="Hf_cusid" ClientIDMode="Static" runat="server"  /><%--OnValueChanged="Hfcusid_ValueChanged"--%>
           <%-- <asp:HiddenField ID="HF_invdtlID" ClientIDMode="Static" runat="server" />--%>
            <%-- OnValueChanged="HfinvdtlID_ValueChanged"--%>
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_postst" />
              <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_posyacc" />
            <asp:HiddenField ID="HFstopJS" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hf_qty" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hf_disc" runat="server" ClientIDMode="Static" />
            <br />


            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" Font-Bold="true" Direction="RightToLeft" Style="text-align: right; display: none">
                    <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                        <Items>
                            <dx:LayoutGroup ColCount="14" GroupBoxDecoration="box" Caption="اصناف الفاتوره" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف" Width="10%" ParentContainerStyle-Paddings-PaddingLeft="1" ParentContainerStyle-Paddings-PaddingRight="1">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txt_item" runat="server" ClientInstanceName="txt_itemcode" Theme="MaterialCompact" AutoPostBack="false" TabIndex="0">
                                                    <ClientSideEvents Init="function(s,e){item_readonly()}" TextChanged="function(s,e){setItemData(s,e); }" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="15" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2" Paddings-PaddingBottom="13">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%--     <dx:ASPxButton ID="btn_items" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="بحث">
                                                    <ClientSideEvents Click="function(s, e) {
	showpopup(s,e)
}" />
                                                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                    </Image>
                                                </dx:ASPxButton>--%>
                                                <button type="button" id="puop_item" data-name="items" onclick="createPopUp($(this))" data-tablename="s_rtn_invdtls_search_sel" data-displayfields="itemcode,itemname,unitname" data-displayfieldshidden="unitid,vat,factor,fprice,itemid,cprice"
                                                    data-displayfieldscaption="كود الصنف,اسم الصنف,الوحده,سعر التكلفه" data-bindcontrols="txt_itemcode;txtitem_name;txt_unit;HF_itemid;HF_unitid;txt_price;Hf_vat;HF_factor;HF_invdtlid"
                                                    data-bindfields="itemcode;itemname;unitname;itemid;unitid;fprice;vat;factor;''" data-pkfield="itemid" data-paramaternames="HF_invid" data-apiurl="/VanSalesService/items/ItemsRtn" style="margin-top: 10px" class="btn btn-sm btnsearchpopup" tabindex="1" />

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <dx:LayoutItem Caption="الصنف" Width="15%" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>

                                                <dx:ASPxTextBox ID="txtitem_name" runat="server" Theme="MaterialCompact" ClientInstanceName="txtitem_name">
                                                    <ClientSideEvents Init="function(s, e) {
	txtitem_name.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="وحده القياس" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
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


                                    <dx:LayoutItem Caption="الكميه" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact" TabIndex="2" >

                                                    <ClientSideEvents KeyUp="function(s, e) {multiply()}" GotFocus="function(s, e) {
	txt_qty.SelectAll();
}"
                                                        KeyPress="function(s, e) {
	isFloatNumber(this,event)
}"  />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="السعر" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_price" runat="server" Text="0" CssClass="auto-style2" Theme="MaterialCompact" ClientInstanceName="txt_price" TabIndex="3">
                                                      <ClientSideEvents KeyUp="function(s, e) {multiply()}" GotFocus="function(s, e) {
	txt_price.SelectAll();
}"
                                                        KeyPress="function(s, e) {
	decimale3num(s,e)
}"  />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الاجمالى" Width="8%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
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
                                    <dx:LayoutItem Caption="الخصم%" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discp" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discp" TabIndex="4">
                                                    <ClientSideEvents KeyUp="function(s, e) {multiplydis()}" KeyPress="function(s, e) {isFloatNumber(this,event)}" GotFocus="function(s, e) {
	txt_discp.SelectAll();
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم" Width="5%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discvalue" TabIndex="5">
                                                    <ClientSideEvents TextChanged="function(s,e){txt_discp.SetValue(0)}"  KeyUp="function(s, e) {calac_disc();}" KeyPress="function(s, e) {isFloatNumber(this,event)}" GotFocus="function(s, e) {
	txt_discvalue.SelectAll();
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصافى" Width="9%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_netvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_netvalue" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {Subtract(); txt_netvalue.GetInputElement().readOnly = true;  }" TextChanged="function(s, e){calac_vat()}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الضريبه" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txtitem_vatvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txtitem_vatvalue">
                                                    <ClientSideEvents Init="function(s, e) {
	txtitem_vatvalue.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="2" Paddings-PaddingTop="11" Paddings-PaddingBottom="13" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_dtls" runat="server" ClientInstanceName="btn_save_dtls" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click" TabIndex="8">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                     <ClientSideEvents Click="function(s, e) {
	validate_dtl(s, e);
}" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" TabIndex="9">
                                                    <ClientSideEvents Click="function(s, e) {clear_dtl()}" />
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف" TabIndex="10">


                                                    <ClientSideEvents Click="function(s, e) {getgvrow();delData_Detail('/VanSalesService/invoice/gRtnInvDtl', 'invdtlid', 'HF_invdtlid',gvs_invdtls); }" />


                                                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <%--      <dx:ASPxButton ID="btn_delete_dtls" runat="server" AutoPostBack="False" OnClick="btn_delete_dtls_Click"  ClientInstanceName="btn_delete_dtls" Height="20px"  RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">


                    <ClientSideEvents Click="function(s, e) {getgvrow(); delData_Dtl('/Sales/inv.aspx/Deletedatadtls','invdtlid','HF_invdtlid',gvs_invdtls) }" />
                                                 

                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>--%>


                                                <%-- <a href="#" onclick="loadinv()"><span class="fa fa-android">Quick</span><i class="fa fa-opencart"></i></a>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملاحظات" CaptionSettings-Location="Left" Width="32%" ParentContainerStyle-Paddings-PaddingLeft="3" ParentContainerStyle-Paddings-PaddingRight="3">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_itemnotes" ClientInstanceName="txt_itemnotes" runat="server" Theme="MaterialCompact" TabIndex="6"></dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملف" CaptionSettings-Location="Left" Paddings-PaddingBottom="20" Width="35%" ParentContainerStyle-Paddings-PaddingLeft="5" ParentContainerStyle-Paddings-PaddingRight="5">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="FileUpload2" runat="server" TabIndex="7" />

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                    <dx:LayoutItem Caption="" ColumnSpan="4" CaptionSettings-Location="Left" ParentContainerStyle-Paddings-PaddingLeft="10" ParentContainerStyle-Paddings-PaddingRight="176">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" ClientInstanceName="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>

                                                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="ادخال سريع" Height="20px" Width="20px">
                                                    <Image Height="20px" Url="~/img/icon/bookmark.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {
                                       loadinv()}" />

                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                </Items>
                            </dx:LayoutGroup>
                        </Items>

                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>
                    <%--  <Items>
                            <dx:LayoutGroup ColCount="14" GroupBoxDecoration="box" Caption="اصناف الفاتــوره" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                <CellStyle Font-Bold="True">
                                </CellStyle>
                                <Items>
                                    <dx:LayoutItem Caption="كود الصنف">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                
<dx:ASPxTextBox ID="txt_item" ClientInstanceName="txt_item" runat="server" Theme="MaterialCompact" OnTextChanged="txt_item_TextChanged" AutoPostBack="True" Width="100%">
                                                    <ClientSideEvents Init="function(s, e) {
      item_readonly();                                                   
	multiply()
}" />

                                                </dx:ASPxTextBox>
                                                    
                                                

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                                                              
                                                <dx:ASPxButton ID="btn_items" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="بحث">

                                                    <ClientSideEvents Click="function(s, e) { 
                                                       fillData(s, e)
                                                        
                                                       
                                                      
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
}"
                                                        ValueChanged="function(s, e) {qty_rtn_chk(s, e);}" />

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
                                                    <ClientSideEvents KeyUp="function(s, e) {multiplydis()}" KeyPress="function(s, e) {isFloatNumber(this,event)}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الخصم">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_discvalue" runat="server" Text="0" Theme="MaterialCompact" ClientInstanceName="txt_discvalue">
                                                    <ClientSideEvents KeyUp="function(s, e) {calac_disc();}" KeyPress="function(s, e) {isFloatNumber(this,event)}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الصافى" Width="9%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txt_netvalue" runat="server" Text="0"  Theme="MaterialCompact" ClientInstanceName="txt_netvalue" Font-Bold="True">
                                                    <ClientSideEvents Init="function(s, e) {Subtract(); txt_netvalue.GetInputElement().readOnly = true;  }" TextChanged="function(s, e){calac_vat()}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الضريبه">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox ID="txtitem_vatvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txtitem_vatvalue">
                                                    <ClientSideEvents Init="function(s, e) {
	txtitem_vatvalue.GetInputElement().readOnly = true; 
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
                                                <dx:ASPxButton ID="btn_save_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click" ClientInstanceName="btn_save_dtls">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" OnClick="btn_new_dtls_Click">
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton ID="btn_delete_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" OnClick="btn_delete_dtls_Click">
                                                    <ClientSideEvents Click="function(s, e) { e.processOnServer = confirm('هل تريد الحذف؟'); }" />
                                                    <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>


                                </Items>
                            </dx:LayoutGroup>
                        </Items>--%>
                    <%--   <table class="dx-justification">
                        <tr>
                            <td style="text-align: right; width: 92px;">
                                <dx:ASPxLabel ID="ASPxLabel35" runat="server" Text="كود الصنف"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_item" runat="server" Width="100%" Height="26px" Theme="MaterialCompact" OnTextChanged="txt_item_TextChanged" AutoPostBack="True">
                                    <ClientSideEvents Init="function(s, e) {
	multiply()
}" />

                                </dx:ASPxTextBox>

                            </td>
                            <td style="text-align: right">
                                <br />
                                <asp:ImageButton ID="btn_items" runat="server" CssClass="auto-style2" Height="28px" ImageUrl="~/img/icon/search.svg" Width="32px" OnClientClick="itemsearch();return false;" ToolTip="بحث" />
                            </td>
                            <td style="text-align: right; width: 143px;" class="dxeTextBoxDefaultWidthSys">
                                <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="الصنف"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_item_name" runat="server" Width="133px" Height="75%" Theme="MaterialCompact" ClientInstanceName="txt_item_name">
                                    <ClientSideEvents Init="function(s, e) {
	txt_item_name.GetInputElement().readOnly = true; 
}" />
                                </dx:ASPxTextBox>
                            </td>

                            <td style="text-align: right; width: 120px;">
                                <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="وحده القياس"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_unit" runat="server" Width="90%" Height="16px" Theme="MaterialCompact" ClientInstanceName="txt_unit">
                                    <ClientSideEvents Init="function(s, e) {
	txt_unit.GetInputElement().readOnly = true; 
}" />
                                </dx:ASPxTextBox>
                            </td>
                            <td style="text-align: right; width: 93px;">
                                <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="الكميه"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Width="90%" Text="1" Height="22px" Theme="MaterialCompact">

                                    <ClientSideEvents KeyUp="function(s, e) {multiply()}" GotFocus="function(s, e) {
	txt_qty.SelectAll();
}"
                                        KeyPress="function(s, e) {
	isFloatNumber(this,event)
}" />

                                </dx:ASPxTextBox>


                            </td>
                            <td style="text-align: right; width: 116px;">
                                <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="السعر"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_price" runat="server" Width="95%" Text="0" CssClass="auto-style2" Height="22px" Theme="MaterialCompact" ClientInstanceName="txt_price">
                                    <ClientSideEvents Init="function(s, e) {
	txt_price.GetInputElement().readOnly = true; 
}" />
                                </dx:ASPxTextBox>
                            </td>
                            <td style="text-align: right; width: 106px;">
                                <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="الاجمالى"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_value" runat="server" Width="95px" Text="0" Height="80%" Theme="MaterialCompact" ClientInstanceName="txt_value" Font-Bold="True">
                                    <ClientSideEvents Init="function(s, e) {
	txt_value.GetInputElement().readOnly = true; 
}" />
                                </dx:ASPxTextBox>
                            </td>
                            <td style="text-align: right; width: 103px;">
                                <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="الخصم%"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_discp" runat="server" Width="95px" Text="0" Height="50%" Theme="MaterialCompact" ClientInstanceName="txt_discp">
                                    <ClientSideEvents KeyUp="function(s, e) {multiplydis()}" />
                                </dx:ASPxTextBox>

                            </td>
                            <td style="text-align: right; width: 103px;">
                                <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="الخصم"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_discvalue" runat="server" Width="95px" Text="0" Height="55%" Theme="MaterialCompact" ClientInstanceName="txt_discvalue">
                                    <ClientSideEvents KeyUp="function(s, e) {calac_disc();calac_vat()}" />
                                </dx:ASPxTextBox>
                            </td>
                            <td style="text-align: right; width: 116px;">
                                <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="الصافى"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txt_netvalue" runat="server" Width="95%" Text="0" OnTextChanged="txt_netvalue_TextChanged" Height="22px" Theme="MaterialCompact" ClientInstanceName="txt_netvalue" Font-Bold="True">
                                    <ClientSideEvents Init="function(s, e) {Subtract(); txt_netvalue.GetInputElement().readOnly = true;  }" ValueChanged="function(s, e){calac_vat()}" />
                                </dx:ASPxTextBox>
                            </td>
                            <td style="text-align: right; width: 109px;">
                                <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="الضريبه"></dx:ASPxLabel>
                                <dx:ASPxTextBox ID="txtitem_vatvalue" runat="server" Width="90%" Height="22px" Theme="MaterialCompact" Text="0" ClientInstanceName="txtitem_vatvalue">
                                    <ClientSideEvents Init="function(s, e) {
	txtitem_vatvalue.GetInputElement().readOnly = true; 
}" />
                                </dx:ASPxTextBox>
                            </td>
                            <td style="text-align: right; width: 157px;">
                                <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="الملاحظات"></dx:ASPxLabel>

                                <dx:ASPxTextBox ID="txt_itemnotes" runat="server" Width="100%" Theme="MaterialCompact"></dx:ASPxTextBox>
                            </td>
                            <td style="text-align: right; width: 198px;" class="dxeTextBoxDefaultWidthSys">
                                <br />
                                <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click">
                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                </dx:ASPxButton>
                                <%--<asp:ImageButton ID="btn_new_dtls" runat="server" ImageUrl="~/img/icon/add-new.svg" Height="26px" Width="32px" ToolTip="جديد" OnClick="btn_new_dtls_Click1" />--
                                <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" OnClick="btn_new_dtls_Click1">
                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                </dx:ASPxButton>
                                <%--<asp:ImageButton ID="btn_delete_dtls" runat="server" ImageUrl="~/img/icon/delete.svg" Height="26px" Width="32px" OnClientClick='return confirm ("هل تريد الحذف")' ToolTip="حذف" OnClick="btn_delete_dtls_Click" />--
                                <dx:ASPxButton ID="ASPxButton3" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" OnClick="btn_delete_dtls_Click">
                                    <ClientSideEvents Click="function(s, e) {getrow_dtlinv();
                                       e.processOnServer = confirm('هل تريد الحذف؟');}" />
                                    <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                </dx:ASPxButton>

                            </td>
                            <td></td>
                        </tr>

                    </table>--%>
                    <asp:HiddenField ID="HF_vattype" ClientIDMode="Static" runat="server" />
                    <asp:HiddenField ID="HF_itemid" ClientIDMode="Static" runat="server" />
                    <%-- OnValueChanged="Hf_itemid_ValueChanged" />--%>
                    <asp:HiddenField ID="HF_unitid" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="Hf_vat" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_cost" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="HF_factor" runat="server" ClientIDMode="Static" />

                    <asp:HiddenField ID="HF_invdtlid" ClientIDMode="Static" runat="server" />
                    <dx:ASPxGridView ID="gvs_invdtls" runat="server" ClientInstanceName="gvs_invdtls" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="True" AccessKey=" " Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" OnDataBinding="gvs_invdtls_DataBinding" OnCustomCallback="gvs_invdtls_CustomCallback" ClientSideEvents-RowDblClick="function(s,e){Gvs_Bind_dtl(s, e)}" OnDataBound="gvs_invdtls_DataBound">

                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <Columns>
                           <%-- <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="invdtlid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="1" Visible="false">
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
                            <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="14" Visible="false">
                            </dx:GridViewDataTextColumn>

                        </Columns>
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="false" ProcessSelectionChangedOnServer="false" />
                        <ClientSideEvents RowClick="function(s, e) {onKeyPress1(s, e)}" />
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
                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="الكميه" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="value" ShowInColumn="الاجمالى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="netvalue" ShowInColumn="الصافى" SummaryType="Sum" DisplayFormat=" {0}" />
                            <dx:ASPxSummaryItem FieldName="vatvalue" ShowInColumn="الضريبه" SummaryType="Sum" DisplayFormat="{0}" />
                        </TotalSummary>
                          <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                    </dx:ASPxGridView>
                    <dx:ASPxGridViewExporter ID="gvitemsExporter" runat="server" FileName="اصناف الفاتوره" GridViewID="gvs_invdtls" PaperKind="A4" PaperName="اصناف الفاتوره" RightToLeft="True" Landscape="True">
                        <PageHeader Center="أصناف الفاتوره" Font-Bold="true">
                        </PageHeader>
                        <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                        </PageFooter>
                    </dx:ASPxGridViewExporter>

                    <%--  <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_rtn_invdtls_gv_sel" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HF_rtninvid" Name="sinvid" PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </asp:Panel>
            </div>

            <%-- </div>--%>

            <%--<div style="text-align: right" id="accordion2">
        <h1 dir="rtl">الدفع</h1>--%>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <br />
            <asp:Panel ID="p_invpay" runat="server" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none">
                <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="6" GroupBoxDecoration="box" Caption="طرق الدفــع" UseDefaultPaddings="false" Paddings-PaddingTop="10" CellStyle-Font-Bold="true">
                            <Items>
                                <dx:LayoutItem Caption="طريقه الدفع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxComboBox ID="cmb_paytype" runat="server" ClientInstanceName="cmb_paytype" AutoPostBack="true"  OnSelectedIndexChanged="cmb_paytype_SelectedIndexChanged" Theme="MaterialCompact" TextField="paytname" ValueField="paytypeid" RightToLeft="True"></dx:ASPxComboBox>

                                            <%--<asp:SqlDataSource ID="Sqldll_paytype" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="0" Name="compid" Type="Int32" />
                                                    <asp:Parameter DefaultValue="sys-paytype" Name="table_name" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>--%>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txt_cusid" Enabled="false" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="اسم الحساب">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxComboBox ID="cmb_paychartid" runat="server" ClientInstanceName="cmb_paychartid" Theme="MaterialCompact" TextField="paytname" ValueField="paytypeid" RightToLeft="True"></dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="القيمه">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_payvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txt_payvalue">
                                                <ClientSideEvents GotFocus="function(s, e) {txt_payvalue.SelectAll();}" KeyPress="function(s, e) {isFloatNumber(this,event)}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="رقم مرجعى">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_payno" ClientInstanceName="txt_payno" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>


                                <dx:LayoutItem Caption="بيانات">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_payref" ClientInstanceName="txt_payref" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>


                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_pay_Click">
                                                <Image Height="20px" Url="~/Img/Icon/save.svg" Width="20px"></Image>
                                            </dx:ASPxButton>

                                            <dx:ASPxButton UseSubmitBehavior="false" ID="brn_new_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" OnClick="brn_new_pay_Click">
                                                <ClientSideEvents Click="function(s, e) {
	Clear_pay()
}"></ClientSideEvents>
                                                <Image Height="20px" Url="~/Img/Icon/add-new.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" >
                                                <ClientSideEvents Click="function(s, e) {
    getrow();
                                                    delData_Detail('/VanSalesService/invoice/gRtnInvPay', 'invpayid', 'Hf_payid',gv_invpay)}" />
                                                <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                         <%--   <dx:ASPxButton ID="btn_delete_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" OnClick="btn_delete_pay_Click">
                                                <ClientSideEvents Click="function(s, e) {
    getrow();
	e.processOnServer = confirm('هل تريد الحذف؟');}" />
                                                <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                                            </dx:ASPxButton>--%>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                            </Items>
                        </dx:LayoutGroup>
                    </Items>
                </dx:ASPxFormLayout>
                <%--<table style="width: 100%;">
                    <tr>
                        <td class="dxeTextBoxDefaultWidthSys" style="width: 107px">
                            <dx:ASPxLabel ID="ASPxLabel27" runat="server" Text="نوع طريقه الدفع"></dx:ASPxLabel>
                        </td>
                        <td style="width: 215px">
                            <dx:ASPxComboBox ID="dll_paytype" runat="server" DataSourceID="Sqldll_paytype" Theme="MaterialCompact" Width="189px" TextField="paytname" ValueField="paytypeid" RightToLeft="True"></dx:ASPxComboBox>

                            <asp:SqlDataSource ID="Sqldll_paytype" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="0" Name="compid" Type="Int32" />
                                    <asp:Parameter DefaultValue="sys-paytype" Name="table_name" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td class="dxeTextBoxDefaultWidthSys" style="width: 48px">
                            <dx:ASPxLabel ID="ASPxLabel28" runat="server" Text="القيمه"></dx:ASPxLabel>

                        </td>
                        <td class="dxeTextBoxDefaultWidthSys" style="width: 144px">
                            <br />
                            <dx:ASPxTextBox ID="txt_payvalue" runat="server" Height="20px" Theme="MaterialCompact" Width="133px" Text="0">
                                <ClientSideEvents GotFocus="function(s, e) {txt_payvalue.SelectAll();}" />
                            </dx:ASPxTextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txt_payvalue"></asp:RequiredFieldValidator>

                        </td>
                        <td style="width: 72px">
                            <dx:ASPxLabel ID="ASPxLabel36" runat="server" Text="رقم مرجعى"></dx:ASPxLabel>
                        </td>
                        <td style="width: 175px">
                            <dx:ASPxTextBox ID="txt_payno" runat="server" Height="20px" Theme="MaterialCompact" Width="162px"></dx:ASPxTextBox>
                        </td>
                        <td style="width: 58px">
                            <dx:ASPxLabel ID="ASPxLabel30" runat="server" Text="بيانات"></dx:ASPxLabel>
                        </td>
                        <td class="dxfm-filterViewDateCell">
                            <dx:ASPxTextBox ID="txt_payref" runat="server" Height="20px" Theme="MaterialCompact" Width="284px"></dx:ASPxTextBox>
                        </td>
                        <td>

                            <dx:ASPxButton ID="btn_save_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_pay_Click">
                                <Image Height="20px" Url="~/Img/Icon/save.svg" Width="20px"></Image>
                            </dx:ASPxButton>
                            <asp:HiddenField ID="Hfpayid" runat="server" />
                            <dx:ASPxButton ID="brn_new_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px" OnClick="brn_new_pay_Click">
                                <Image Height="20px" Url="~/Img/Icon/add-new.svg" Width="20px"></Image>
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="btn_delete_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px" OnClick="btn_delete_pay_Click">
                                <ClientSideEvents Click="function(s, e) {
	return confirm (&quot;هل تريد الحذف&quot;)
}" />
                                <Image Height="20px" Url="~/Img/Icon/delete.svg" Width="20px"></Image>
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>--%>

                <%-- <dx:ASPxGridView ID="gv_invpay" runat="server" ClientInstanceName="gv_invpay" EnableRowsCache="false" AutoGenerateColumns="False" EnableCallBacks="False" DataSourceID="SqlData_pay" Width="100%" KeyFieldName="invpayid" Theme="MaterialCompact" RightToLeft="True" OnSelectionChanged="gv_invpay_SelectionChanged" OnDataBound="gv_invpay_DataBound">--%>
                <asp:HiddenField ID="Hf_payid" runat="server" ClientIDMode="Static" />
                <%-- <dx:ASPxGridView ID="gv_invpay" runat="server" ClientInstanceName="gv_invpay" AutoGenerateColumns="False" EnableCallBacks="False" DataSourceID="SqlData_pay" Width="100%" KeyFieldName="invpayid" Theme="MaterialCompact" RightToLeft="True" OnSelectionChanged="gv_invpay_SelectionChanged" OnDataBound="gv_invpay_DataBound">--%>
                <dx:ASPxGridView ID="gv_invpay" runat="server" ClientInstanceName="gv_invpay" AutoGenerateColumns="False" EnableCallBacks="False" Width="100%" KeyFieldName="invpayid" Theme="MaterialCompact" RightToLeft="True" ClientSideEvents-RowDblClick="function(s,e){Gvs_Bind_Pay(s,e)}" OnCustomCallback="gv_invpay_CustomCallback" OnDataBinding="gv_invpay_DataBinding" OnDataBound="gv_invpay_DataBound" CssClass="grid">


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
                      <Styles>
                            <Footer Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></Footer>
                        </Styles>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="SqlData_pay" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>">

                    <%-- <SelectParameters>
                       s_rtn_invpay_sel
                        <asp:ControlParameter ControlID="HF_rtninvid" Name="inv_id" PropertyName="Value" Type="Int32" />
                    </SelectParameters>--%>
                    
                </asp:SqlDataSource>


            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="Panel1$formLayout$btn_download" />
            <asp:PostBackTrigger ControlID="Panel1$formLayout$upload" />
             <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_attach" />
               <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_xlsxexport" />
        </Triggers>

    </asp:UpdatePanel>
    <%-- </div>--%>



    <%--   <script>
        function pageLoad(sender, args) {
            $(function () {
                $("#accordion").accordion({
                    collapsible: true
                });
            });
            $(function () {
                $("#accordion2").accordion({
                    collapsible: true
                });
            });
        }
   </script>--%>
    <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">--%>

    <%--   <script src="--https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="Content/Site.css" rel="stylesheet" />--%>
</asp:Content>

