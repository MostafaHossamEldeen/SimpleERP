<%@ Page Title="فاتـــوره المبيـــعات" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="inv.aspx.cs" Inherits="VanSales.inv"  %>

<%@ Register Assembly="DevExpress.Web.v20.2, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%--<%@ Register Src="~/Controls/PopUpControlNormal.ascx" TagPrefix="ucitm" TagName="PopUpControlNormal" %>
<%@ Register Src="~/Controls/PopUpControlSearch.ascx" TagPrefix="uc1" TagName="PopUpControlSearch" %>--%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .custname {
            width: 500px;
            position: absolute;
        }

        .custinfo {
            width: 500px;
            position: absolute;
            left: 125px;
            margin-top: 80px;
        }

        .custgroup {
            margin-top: 30px;
            padding-right: 5px;
            background-color: white;
        }

        .popupstyle {
            z-index: 5656555656;
        }
    </style>
    <%--  <uc1:PopUpControlSearch runat="server" ID="PopUpControlSearch" TableName="s_inv_sel_search" DisplayFields="sinvno,sinvdocno,sinvdata" DisplayFieldsHidden="sinvpay,branchid,smanid,sinvtime,custid,custname,custvat,custadd,suser,snotes,netbvat,vatvalue,netavat,invdoc,sinvid"
        DisplayFieldsCaption="رقم الفاتوره,الرقم اليدوى,التاريخ" BindControls="txtinvno;txt_sinvdocno;sinvdata;txt_trandate;cmb_branchid;cmb_sinvpay;cmb_smanid;txt_sinvtime;txt_cusid;ctname;txt_custvat;txt_custadd;txt_custmobile;txt_suser;txt_snotes;txt_netbvat;txt_vatvalue;txt_netavat;lbl_invdoc;txt_docid;HF_sinvid" BindFields="sinvno;sinvdocno;sinvdata;trandate;branchid;sinvpay;smanid;sinvtime;custid;custname;custvat;custadd;custmobile;suser;snotes;netbvat;vatvalue;netavat;invdoc;docid;sinvid"  ApiUrl="/VanSalesService/inv/GetinvSingalData"  PkField="sinvid" />

    <ucitm:PopUpControlNormal runat="server" ID="Pop_items"   TableName="st_itemunit_sel_pop"  DisplayFields="itemcode,itemname,unitname" DisplayFieldsHidden="unitid,vat,factor,fprice,itemid,cprice" 
            DisplayFieldsCaption="كود الصنف,اسم الصنف,الوحده,سعر التكلفه" BindControls="txt_itemcode;txtitem_name;txt_unit;HF_itemid;HF_unitid;txt_price;Hf_vat;HF_factor"   BindFields="itemcode;itemname;unitname;itemid;unitid;fprice;vat;factor"  ApiUrl="/VanSalesService/items/FillPopup" PkField="itemunitid" />--%>

    <script src="../Scripts/App/sales/inv.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup" ShowMaximizeButton="true" Width="1200px" Height="700px" AllowResize="true" HeaderText=""
                CloseAction="CloseButton" AllowDragging="true" Modal="true" PopupHorizontalAlign="Center" PopupVerticalAlign="Middle" CssClass="popupstyle"
                OnUnload="ASPxPopupControl1_Unload" OnPopupWindowCommand="ASPxPopupControl1_PopupWindowCommand">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    </dx:PopupControlContentControl>
                </ContentCollection>
                <ClientSideEvents
                    CloseUp="function(s,e){   
                  gvs_invdtls.PerformCallback(lbl_invdoc.GetValue() + ',' + txt_docid.GetValue() + ',' + $('#hf_postst').val() + ',' + $('#hf_posyacc').val() + ',' + lbl_vochrno.GetValue() + ',' + lbl_sinvstatusname.GetValue());}" />
            </dx:ASPxPopupControl>
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


                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/invoice/InvDelMaster', 'HF_sinvid') }" />
                    <%--  <ClientSideEvents Click="function(s, e) {delData('/Sales/inv.aspx/Deletedata' ,'sinvid','HF_sinvid') }" />--%>

                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <%-- <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_delete_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">


                    <ClientSideEvents Click="function(s, e) {
e.processOnServer = confirm('هل تريد الحذف؟'); }"   />


                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>--%>
                <%-- <dx:ASPxButton UseSubmitBehavior="false" ID="btn_search" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="بحث">

                    <ClientSideEvents Click="function(s, e) { showpopupSearch(s, e)
 
}" />

                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px"></Image>
                </dx:ASPxButton>--%>
                <button type="button" id="PopUpControlSearch" data-name="inv" data-tablename="s_inv_sel_search" data-displayfields="sinvno,sinvdocno,sinvdata"
                    data-displayfieldshidden="sinvpay,branchid,smanid,sinvtime,custid,custname,custvat,custadd,custmobile,suser,snotes,netbvat,vatvalue,netavat,invdoc,sinvid,postst,postacc,vochrid,vochrno,ccid,sinvstatusname,sinvstatusid"
                    data-displayfieldscaption="رقم الفاتوره,الرقم اليدوى,التاريخ"
                    data-bindcontrols="txtinvno;txt_sinvdocno;sinvdata;cmb_branchid;cmb_sinvpay;cmb_smanid;txt_sinvtime;txt_cusid;ctname;txt_custvat;txt_custadd;txt_custmobile;txt_suser;txt_snotes;txt_netbvat;txt_vatvalue;txt_netavat;lbl_invdoc;txt_docid;HF_sinvid;hf_postst;hf_posyacc;lbl_vochrno;cmb_ccid;lbl_sinvstatusname;hf_sinvstatusid"
                    data-bindfields="sinvno;sinvdocno;sinvdata;branchid;sinvpay;smanid;sinvtime;custid;custname;custvat;custadd;custmobile;suser;snotes;netbvat;vatvalue;netavat;invdoc;docno;sinvid;postst;posyacc;vochrno;ccid;sinvstatusname;sinvstatusid"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="sinvid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postst" runat="server" ClientInstanceName="btn_postst" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل مستودعات">
                    <ClientSideEvents Click="function(s,e){postInvStock(s,e)}" />
                    <Image Height="20px" Url="~/img/icon/poststock.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" runat="server" ClientInstanceName="btn_postacc" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل حسابات">
                    <ClientSideEvents Click="function(s,e){postInvAcc(s,e)}" />
                    <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">

                    <%--                    <ClientSideEvents Click="function(s, e) {
print_newtab();
}" />--%>

                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print_paydoc" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_print_paydoc_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه صرف بضاعه">

                    <%--                    <ClientSideEvents Click="function(s, e) {
print_newtab();
}" />--%>

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
                        <dx:LayoutGroup ColCount="5" GroupBoxDecoration="Box" Caption="البيانات الاساسيه">
                            <Items>
                                <dx:LayoutItem Caption="رقم الفاتوره">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_sinvno" runat="server" ClientInstanceName="txtinvno" Theme="MaterialCompact" Font-Bold="True" Text="تلقائى">
                                                <%-- <ClientSideEvents KeyDown="function(s,e){preventwrite(s,e)}"  />--%>
                                                <ClientSideEvents KeyDown="function(s,e){preventwrite1(s,e);}" />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="رقم يدوى للفاتوره">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sinvdocno" runat="server" ClientInstanceName="txt_sinvdocno" Theme="MaterialCompact" Style="margin-right: 0px">
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="نوع سداد الفاتوره">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxComboBox ID="cmb_sinvpay" runat="server" ClientInstanceName="cmb_sinvpay" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                            <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
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

                                <dx:LayoutItem Caption="التاريخ">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="sinvdata"></asp:RequiredFieldValidator>--%>
                                            <dx:ASPxDateEdit ID="txt_sinvdata" runat="server" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="sinvdata">
                                                <%--<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />--%>
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
                                <dx:LayoutItem Caption="امر البيع/عرض اسعار" Paddings-PaddingTop="13">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxHyperLink ID="txt_docid" runat="server" ClientInstanceName="txt_docid">
                                            </dx:ASPxHyperLink>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ColumnSpan="2">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxLabel ID="lbl_sinvstatusname" ClientInstanceName="lbl_sinvstatusname" runat="server" CssClass="auto-style2" ForeColor="#009933" Font-Names="Aldhabi" Font-Bold="true" Font-Size="16" Theme="MaterialCompact">
                                            </dx:ASPxLabel>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="الوقت">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_sinvtime" ClientInstanceName="txt_sinvtime" runat="server" CssClass="auto-style2" Theme="MaterialCompact">
                                                <ClientSideEvents Init="function(s, e) {
	txt_sinvtime.GetInputElement().readOnly = true; 
}" />
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

                                            <dx:ASPxTextBox ID="txt_custid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_cusid" AutoPostBack="false">
                                                <ClientSideEvents ValueChanged="function(s, e) {
	setCustData(s, e)
}"
                                                    Init="function(s, e) {cus_validate()}" />
                                            </dx:ASPxTextBox>
                                            <%--<asp:RequiredFieldValidator ID="txt_cus_id_req" runat="server" ErrorMessage="*" ControlToValidate="txt_cusid" Enabled="false" ValidateRequestMode="Enabled" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>


                                            <button type="button" id="puop_cust" data-name="cust" onclick="createPopUp($(this))" data-tablename="s_customers_sel_search" data-displayfields="custcode,custname,custadd,custmob" data-displayfieldshidden="custvat,sgrpid,smanid,custid"
                                                data-displayfieldscaption="كود العميل,إسم العميل,العنوان,التليفون" data-bindcontrols="txt_cusid;ctname;txt_custvat;txt_custadd;txt_custmobile;cmb_smanid;Hf_cusid"
                                                data-bindfields="custcode;custname;custvat;custadd;custmob;smanid;custid" data-pkfield="custid" data-apiurl="/VanSalesService/items/FillPopup" class="btn btn-sm btnsearchpopup">
                                            </button>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="ctn_add_cus" runat="server" AutoPostBack="False" Height="20px" OnClick="ctn_add_cus_Click1" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="اضافه عميل">

                                                <ClientSideEvents Click="function(s, e) {add_cus();}" />
                                                <Image Height="20px" Url="~/Img/Icon/add-user.svg" Width="20px">
                                                </Image>

                                            </dx:ASPxButton>
                                            <%--     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_cus" runat="server" AutoPostBack="False" Height="20px"  RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="بحث">
                                                <ClientSideEvents Click="function(s, e) {
	cus_search();return false;
}" />
                                                <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                </Image>
                                            </dx:ASPxButton>--%>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                    <ParentContainerStyle>
                                        <Paddings PaddingLeft="0px" PaddingRight="0px" />
                                    </ParentContainerStyle>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="اسم العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custname" ClientInstanceName="ctname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
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
                                            <dx:ASPxComboBox ID="cmb_smanid" runat="server" ClientInstanceName="cmb_smanid" RightToLeft="True" TextField="smanname" Theme="MaterialCompact" ValueField="smanid" AutoPostBack="false">
                                            </dx:ASPxComboBox>
                                            <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
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
                                            <dx:ASPxMemo ID="txt_snotes" runat="server" ClientInstanceName="txt_snotes" Theme="MaterialCompact" Width="100%">
                                            </dx:ASPxMemo>


                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="المستند">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <dx:ASPxLabel ID="lbl_invdoc" ClientInstanceName="lbl_invdoc" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="80%">
                                            </dx:ASPxLabel>

                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <%--  <asp:ImageButton ID="upload" runat="server" OnClick="upload_Click" ImageUrl="~/img/icon/import.svg" Height="30px" Width="30px" ToolTip="رفع ملف" />--%>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="upload" runat="server" OnClick="upload_Click" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="رفع ملف">
                                                <Image Height="20px" Url="~/img/icon/import.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                            <%-- <asp:ImageButton  ID="btn_download" runat="server" Height="30px" ImageUrl="~/img/icon/download.svg" OnClick="btn_download_Click" ToolTip="تحميل" Width="30px" />--%>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="btn_download" runat="server" OnClick="btn_download_Click" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="تحميل">
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
                                                <%-- <ClientSideEvents Click='function(s, e) {
	window.open("/GL/Vouchers.aspx?vchrno="+lbl_vochrno.GetValue(),"_blank")
}'></ClientSideEvents>--%>
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
            <%-- <dx:ASPxLabel ID="lbl_msg" runat="server" Font-Bold="True" ForeColor="#009900" ></dx:ASPxLabel>--%>

            <asp:HiddenField ID="HF_sinvid" ClientIDMode="Static" runat="server" />
            <%--OnValueChanged="HF_inv_id_ValueChanged" />--%>
            <asp:HiddenField ID="Hf_cusid" ClientIDMode="Static" runat="server" />
            <%--OnValueChanged="Hfcusid_ValueChanged" />--%>
            <asp:HiddenField ID="HF_vattype" ClientIDMode="Static" runat="server" />
            <asp:HiddenField ID="hf_netbvat" ClientIDMode="Static" runat="server" />
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_postst" />
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_posyacc" />
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hf_sinvstatusid" />
            <br />
            <%--    <div style="text-align: right" id="accordion">
        <h1 dir="rtl">اصناف الفاتوره</h1>--%>

            <div dir="rtl">
                <asp:Panel ID="PDetiles" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none;">
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

                                                <dx:ASPxTextBox UseSubmitBehavior="true" ID="txt_item" runat="server" ClientInstanceName="txt_itemcode" Theme="MaterialCompact" AutoPostBack="false" TabIndex="0">
                                                    <ClientSideEvents TextChanged="function(s,e){setItemData(s,e); }" />

                                                </dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" Paddings-PaddingTop="15" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2" Paddings-PaddingBottom="13">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%--      <dx:ASPxButton UseSubmitBehavior="false" ID="btn_items" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="0%" ToolTip="بحث">
                                                    <ClientSideEvents Click="function(s, e) {
	showpopup(s,e)
}" />
                                                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px">
                                                    </Image>
                                                </dx:ASPxButton>--%>
                                                <button type="button" id="puop_item" data-name="items" onclick="createPopUp($(this))" data-tablename="st_itemunit_inv_sel_pop" data-displayfields="itemcode,itemname,unitname" data-displayfieldshidden="unitid,vat,factor,fprice,cprice,itemid,descp"
                                                data-displayfieldscaption="كود الصنف,اسم الصنف,الوحده" data-bindcontrols="txt_itemcode;txtitem_name;txt_discp;txt_unit;HF_itemid;HF_unitid;txt_price;Hf_vat;HF_factor;HF_invdtlid"
                                                data-bindfields="itemcode;itemname;descp;unitname;itemid;unitid;fprice;vat;factor;''" data-pkfield="itemunitid" data-apiurl="/VanSalesService/items/FillPopup" style="margin-top: 10px" class="btn btn-sm btnsearchpopup" tabindex="1" />

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
                                                <dx:ASPxTextBox ID="txt_qty" ClientInstanceName="txt_qty" runat="server" Text="1" Theme="MaterialCompact" TabIndex="2">

                                                    <ClientSideEvents KeyUp="function(s, e) {multiply()}" GotFocus="function(s, e) {
	txt_qty.SelectAll();
}"
                                                        KeyPress="function(s, e) {
	decimale3num(s,e)
}" />

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
                                                        KeyDown="function(s, e) {

	priceKeyPress(s,e)
                                                        
}"
                                                        KeyPress="function(s,e){  decimale3num(s, e)}" />
                                                    <%--                                                    <ClientSideEvents Init="function(s, e) {
txt_price.GetInputElement().readOnly = true; 
}" />--%>
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
                                                    <ClientSideEvents KeyUp="function(s, e) {calac_disc();}" KeyPress="function(s, e) {isFloatNumber(this,event)}" GotFocus="function(s, e) {
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
                                                <dx:ASPxTextBox ID="txtitem_vatvalue" runat="server" Theme="MaterialCompact" Text="0" ClientInstanceName="txt_itemvatvalue">
                                                    <ClientSideEvents Init="function(s, e) {
	txt_itemvatvalue.GetInputElement().readOnly = true; 
}" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="" ColumnSpan="2" Paddings-PaddingTop="11" Paddings-PaddingBottom="13" ParentContainerStyle-Paddings-PaddingLeft="2" ParentContainerStyle-Paddings-PaddingRight="2">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حفظ" Height="20px" Width="20px" OnClick="btn_save_dtls_Click" TabIndex="6">
                                                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {
	validate_dtl(s, e);
}" />
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_new_dtls" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="جديد" Height="20px" Width="20px">
                                                    <ClientSideEvents Click="function(s, e) {clear_dtl()}" />
                                                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete_dtls" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">


                                                    <ClientSideEvents Click="function(s, e) {getgvrow();delData_Detail('/VanSalesService/invoice/DelinvDetail', 'invdtlid', 'HF_invdtlid',gvs_invdtls) }" />


                                                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                                                </dx:ASPxButton>
                                                <%--       <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_dtls" runat="server" AutoPostBack="False" OnClick="btn_delete_dtls_Click"  ClientInstanceName="btn_delete_dtls" Height="20px"  RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">


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
                                                <dx:ASPxTextBox ID="txt_itemnotes" ClientInstanceName="txt_itemnotes" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>
                                    <dx:LayoutItem Caption="الملف" CaptionSettings-Location="Left" Paddings-PaddingBottom="20" Width="35%" ParentContainerStyle-Paddings-PaddingLeft="5" ParentContainerStyle-Paddings-PaddingRight="5">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <asp:FileUpload ID="FileUpload2" runat="server" />

                                                <%-- <dx:ASPxLabel ID="lbl_itemsfile" ClientInstanceName="lbl_itemsfile" Visible="false" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="10%">
                                            </dx:ASPxLabel>--%>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                    <%--<dx:LayoutItem Caption=""  CaptionSettings-Location="Left"  ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%--<asp:ImageButton ID="btn_attach" runat="server" OnClick="btn_attach_Click" ImageUrl="~/img/icon/import.svg" Height="30px" Width="30px" ToolTip="رفع ملف" /> 
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>--%>
                                    <dx:LayoutItem Caption="" ColumnSpan="4" CaptionSettings-Location="Left" ParentContainerStyle-Paddings-PaddingLeft="10" ParentContainerStyle-Paddings-PaddingRight="176">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <%--<asp:ImageButton ID="btn_attach" runat="server" OnClick="btn_attach_Click" ImageUrl="~/img/icon/import.svg" Height="30px" Width="30px" ToolTip="رفع ملف" />--%>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_attach" runat="server" Height="20px" Width="20px" ToolTip="رفع ملف" Image-Url="~/img/icon/import.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_attach_Click"></dx:ASPxButton>

                                                <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxButton1" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="ادخال سريع" Height="20px" Width="20px">
                                                    <Image Height="20px" Url="~/img/icon/bookmark.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {
                                       loadinv()}" />

                                                </dx:ASPxButton>
                                                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>

                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>

                                    </dx:LayoutItem>

                                </Items>
                            </dx:LayoutGroup>
                        </Items>
                        <SettingsItemCaptions Location="Top" />
                    </dx:ASPxFormLayout>


                    <asp:HiddenField ID="HF_itemid" ClientIDMode="Static" runat="server" />
                    <%-- OnValueChanged="Hf_itemid_ValueChanged" />--%>
                    <asp:HiddenField ID="HF_unitid" runat="server" ClientIDMode="Static" />
                    <span class="mb-0 ">
                        <asp:HiddenField ID="Hf_vat" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hf_qty" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="HF_cost" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="HF_factor" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hf_disc" runat="server" ClientIDMode="Static" />
                    </span>
                    <asp:HiddenField ID="HF_invdtlid" runat="server" ClientIDMode="Static" />
                    <dx:ASPxGridView ID="gvs_invdtls" ClientInstanceName="gvs_invdtls" runat="server" AutoGenerateColumns="False" EnableCallBacks="False" KeyboardSupport="true" AccessKey=" " Width="100%" KeyFieldName="invdtlid" Theme="MaterialCompact" RightToLeft="True" ClientSideEvents-RowDblClick="function(s,e){Gvs_Bind_dtl(s,e)}" OnDataBinding="gvs_invdtls_DataBinding" OnDataBound="gvs_invdtls_DataBound" OnCustomCallback="gvs_invdtls_CustomCallback" CssClass="grid">



                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                        <Columns>
                            <%--<dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="AllPages" VisibleIndex="0"></dx:GridViewCommandColumn>--%>
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
                            <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="14" Visible="false">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="15" Visible="false">
                            </dx:GridViewDataTextColumn>
                        </Columns>
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
                    <%--  <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_invdtls_sel" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="HF_sinvid" Name="sinvid" PropertyName="Value" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>
                </asp:Panel>
            </div>


            <br />

            <asp:Panel ID="p_invpay" runat="server" BorderStyle="None" Font-Bold="True" Direction="RightToLeft" Style="text-align: right; display: none">
                <dx:ASPxFormLayout SettingsItemCaptions-Location="Top" runat="server" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
                        <dx:LayoutGroup ColCount="6" GroupBoxDecoration="box" Caption="طرق الدفع" UseDefaultPaddings="false" Paddings-PaddingTop="10" CellStyle-Font-Bold="true">
                            <Paddings PaddingTop="10px" />
                            <CellStyle Font-Bold="True">
                            </CellStyle>
                            <Items>
                                <dx:LayoutItem Caption="طريقه الدفع">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxComboBox ID="cmb_paytype" runat="server" AutoPostBack="true" ClientInstanceName="cmb_paytype" Theme="MaterialCompact" TextField="paytname" ValueField="paytypeid" RightToLeft="True"></dx:ASPxComboBox>

                                            <%--<asp:SqlDataSource ID="Sqldll_paytype" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="sys_fillcomp_sel" SelectCommandType="StoredProcedure">
                                               OnSelectedIndexChanged="cmb_paytype_SelectedIndexChanged" 
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

                                            <dx:ASPxButton UseSubmitBehavior="false" ID="brn_new_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" OnClick="brn_new_pay_Click" ToolTip="جديد" Height="20px" Width="20px">
                                                <ClientSideEvents Click="function(s, e) {
	Clear_pay()
}"></ClientSideEvents>

                                                <Image Height="20px" Url="~/Img/Icon/add-new.svg" Width="20px"></Image>
                                            </dx:ASPxButton>
                                            <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete_pay" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="حذف" Height="20px" Width="20px">
                                                <ClientSideEvents Click="function(s, e) {
    getrow();
                                                    delData_Detail('/VanSalesService/invoice/gInvPay', 'invpayid', 'Hf_invpayid',gv_invpay)}" />
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


                <asp:HiddenField ID="Hf_invpayid" runat="server" ClientIDMode="Static" />
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
                        <dx:GridViewDataTextColumn FieldName="chartname" VisibleIndex="16" Visible="false">
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
                <%--       <asp:SqlDataSource ID="SqlData_pay" runat="server" ConnectionString="<%$ ConnectionStrings:VanSales %>" SelectCommand="s_invpay_sel" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="HF_sinvid" Name="inv_id" PropertyName="Value" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
            </asp:Panel>

        </ContentTemplate>
        <Triggers>

            <asp:PostBackTrigger ControlID="Panel1$formLayout$btn_download" />
            <asp:PostBackTrigger ControlID="Panel1$formLayout$upload" />
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_attach" />
            <asp:PostBackTrigger ControlID="PDetiles$ASPxFormLayout1$btn_xlsxexport" />


            <%--<asp:AsyncPostBackTrigger ControlID="btn_attach" EventName="Click" />--%>
        </Triggers>

    </asp:UpdatePanel>
    <style>
        .addcustpopup {
            width: 35px;
            height: 35px;
            padding: 5px 5px 5px;
            background-color: white;
            -webkit-box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
            /*        position:fixed;
        margin: 100px 550px;*/

            margin-top: 20px;
            margin-right: 90%;
        }
    </style>
    <div class="modal" id="popupModaladdcust" style="z-index: 999999999;" data-name="aaa" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true" dir="rtl">
        <div class="modal-dialog" role="alertdialog" style="width: 100%">
            <div class="modal-content" style="height: 100%; min-height: 300px; width: 650px">
                <div class="modal-header">
                    <h5 class="modal-title" id="popupModalLabel">اضافه عميل</h5>
                    <button type="button" class="close float-left" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <%--    <div class="form-group row">
       <%-- <div class="col-md-10">
        <%--<input type="text" id="txt_search" onkeydown="searchitm(event)" autocomplete="off"   placeholder="بحث" class="form-control" />
        </div>
        <div class="col-md-2">

        </div>
        </div>--%>




                    <div class="custgroup row">

                        <%-- <h6>كود العميل</h6>
                   
                    <input  type="text" id="txt_custcode"/>--%>
                        <%--   <div class="custname col-md-6">--%>
                        <div class="col-md-6" style="float: right;">
                            <label class="form-label">اسم العميل</label>
                            <input type="text" id="txt_cusname" class="form-control form-control-sm" />
                        </div>
                        <div class="col-md-6" style="float: left;">
                            <label class="form-label">عنوان العميل</label>
                            <input type="text" id="txt_cusadd" class="form-control form-control-sm" />
                        </div>
                        <%--</div>--%>
                        <%--   <div class="custinfo">--%>
                        <div class="col-md-6" style="float: right;">
                            <%--<h6>تليفون العميل</h6>
                        <input  type="text" id="txt_cusmob" class="form-control form-control-sm"  />--%>
                            <label class="form-label">تليفون العميل</label>
                            <input type="text" id="txt_cusmob" class="form-control form-control-sm" />
                        </div>
                        <div class="col-md-6" style="float: left;">
                            <%--  <h6>الرقم الضريبى</h6>
                        <input  type="text" id="txt_cusvat" class="form-control form-control-sm"  />--%>
                            <label class="form-label">الرقم الضريبى</label>
                            <input type="text" id="txt_cusvat" class="form-control form-control-sm" />
                        </div>
                        <div class="col-md-6" style="float: left;">
                            <label>المجموعه</label>
                            <select id="cmb_cusgroup" class="form-control form-control-sm"></select>
                        </div>

                        <div class="col-md-6 ">

                            <button type="button" class="btn btn-sm addcustpopup " onclick="postCustData()">
                                <img src="../img/icon/save.svg" />
                            </button>

                        </div>


                    </div>
                </div>


            </div>

        </div>

    </div>

</asp:Content>
