<%@ Page Title="سندات الصرف" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pay_doc.aspx.cs" Inherits="VanSales.GL.pay_doc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/App/GL/pay_doc.js"></script>
<script src="../Scripts/App/Public/Messages.js"></script>
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="Lbl_Tittle" runat="server" Text="سندات الصرف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center;">


                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" ClientInstanceName="btn_Save" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ" >
                    <ClientSideEvents Click="function(s, e) {
	validate(s, e);
}" />
                    <Image Height="20px" Url="~/img/icon/save.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" ClientInstanceName="btn_addnew" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="جديد" OnClick="btn_addnew_Click">

                    <Image Height="20px" Url="~/img/icon/add-new.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" AutoPostBack="False" ClientInstanceName="btn_delete" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حذف">

                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/pay/paydocDelMaster', 'HF_pdid') }" />

                    <Image Height="20px" Url="~/img/icon/delete.svg" Width="20px"></Image>
                </dx:ASPxButton>

                <button type="button" id="PopUpControl1" data-name="nav" data-tablename="pay_doc_sel_search" data-displayfields="pdno,pdbranchid,pddate"
                    data-displayfieldshidden="ccname,pddocno,branchname,pdman,paidto,ccid,pdnotes,paytypeid,paychartid,paytypename,postacc,vochrno,payref,paidchartid,paynotes,paidtype,paidtypenamem,pddocimg,pdid,vatvalue,vattype,pdbvat,pdavat,pduser"
                    data-displayfieldscaption=" رقم السند,الفرع,التاريخ" data-bindcontrols="txt_pdno;txt_pddocno;cmb_pdbranchid;txt_pddate;txt_pdman;txt_paidto;cmb_ccid;txt_pdnotes;cmb_paytypeid;HF_paychartid;HF_postacc;txt_vchrid;txt_payref;HF_paidchartid;txt_paynotes;cmb_paidtype;lbl_pddocimg;lbl_pddocimg1;HF_pdid;txt_vatvalue;rbl_vattype;txt_pdbvat;txt_pdavat;txt_pduser"
                    data-bindfields="pdno;pddocno;pdbranchid;pddate;pdman;paidto;ccid;pdnotes;paytypeid;paychartid;postacc;vochrno;payref;paidchartid;paynotes;paidtype;pddocimg;pddocimg;pdid;vatvalue;vattype;pdbvat;pdavat;pduser" 
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="pdid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>


                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_postacc" ClientInstanceName="btn_postacc" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="ترحيل حسابات">
                    <Image Height="20px" Url="~/img/icon/Unt512.png" Width="20px"></Image>
                    <ClientSideEvents Click="function(){postPayDocAcc()}" />
                </dx:ASPxButton>
                           <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه" OnClick="btn_print_Click" >
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px"></Image>
                </dx:ASPxButton>
                <br />

            </div>

            <br />

            <dx:ASPxFormLayout runat="server" ID="formLayout" SettingsItemCaptions-Location="Top" CssClass="formLayout" RightToLeft="True">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                <Items>
                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="Box" Caption="البيانات الاساسيه">
                        <Items>
                            <dx:LayoutItem Caption="رقم السند" >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ValidationSettings-CausesValidation="true" ID="txt_pdno" runat="server" ClientInstanceName="txt_pdno" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى">

                                            <ClientSideEvents KeyPress="function(s, e) {
	 preventwrite(s, e)
}"
                                                ValueChanged="function(s,e){Refreshdata(s,e)}"></ClientSideEvents>
                                            <ValidationSettings CausesValidation="True">
                                            </ValidationSettings>
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="رقم يدوى للسند">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_pddocno" ClientInstanceName="txt_pddocno" runat="server" Theme="MaterialCompact" Style="margin-right: 0px">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>

                            <dx:LayoutItem Caption="التاريخ">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxDateEdit ID="txt_pddate" runat="server" ValidateRequestMode="Disabled" RightToLeft="True" Theme="MaterialCompact" MinDate="1900-01-01" ClientInstanceName="txt_pddate">
                                        </dx:ASPxDateEdit>


                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="الفرع"  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_pdbranchid" runat="server" ClientInstanceName="cmb_pdbranchid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>




                            <dx:LayoutItem Caption="نوع الصرف">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_paidtype" runat="server" ClientInstanceName="cmb_paidtype" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                        </dx:ASPxComboBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="مركز التكلفه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxComboBox ID="cmb_ccid" runat="server" ClientInstanceName="cmb_ccid" RightToLeft="True" TextField="citemname" Theme="MaterialCompact" ValueField="citemid" AutoPostBack="false">
                                            <ClearButton DisplayMode="Always"></ClearButton>
                                        </dx:ASPxComboBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                           
                            <dx:LayoutItem Caption="حساب المدفع له" Width="25%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_paidchartid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_paidchartid">
                                         <ClientSideEvents ValueChanged="function(s, e) {setpaidchartData(s, e)}" Init="function(s, e) {chart_validate()}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" Paddings-PaddingTop="11" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0" Width="8%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ForeColor="Red">

                                        <button type="button" id="Pop_chart" data-name="chart" onclick="createPopUp($(this))" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldshidden="chartid"
                                            data-displayfieldscaption="كود الحساب,اسم الحساب" data-bindcontrols="txt_paidchartid;txt_paidchartname;HF_paidchartid"
                                            data-bindfields="chartcode;chartname;chartid" data-pkfield="chartid" data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" style="margin-top: 15px" class="btn btn-sm btnsearchpopup" />

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="اسم حساب المدفوع له">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_paidchartname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_paidchartname">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="طريقه الدفع">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxComboBox ID="cmb_paytypeid" runat="server" AutoPostBack="false" ClientInstanceName="cmb_paytypeid" Theme="MaterialCompact" TextField="paytname" ValueField="paytypeid" RightToLeft="True"></dx:ASPxComboBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>


                            <dx:LayoutItem Caption="حساب طريقه الدفع" Width="25%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_paychartid" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_paychartid">
                                         <ClientSideEvents ValueChanged="function(s, e) {setpaychartData(s, e)}" Init="function(s, e) {chart_validate()}" />
                                            </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" Paddings-PaddingTop="11" ParentContainerStyle-Paddings-PaddingLeft="0" ParentContainerStyle-Paddings-PaddingRight="0" Width="8%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer ForeColor="Red">

                                        <button type="button" id="Pop_chart2" data-name="chart" onclick="createPopUp($(this))" data-tablename="gl_chart_sel_pop" data-displayfields="chartcode,chartname" data-displayfieldshidden="chartid"
                                            data-displayfieldscaption="كود الحساب,اسم الحساب" data-bindcontrols="txt_paychartid;txt_chartname;HF_paychartid"
                                            data-bindfields="chartcode;chartname;chartid" data-pkfield="chartid" data-apiurl="/VanSalesService/Vouchers/chartSearch" data-paramaternames="HF_legertype" style="margin-top: 15px" class="btn btn-sm btnsearchpopup" />

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="اسم الحساب">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_chartname" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_chartname">
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>
                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المستلم">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_pdman" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_pdman">
                                            <%--<ClientSideEvents Init="function(s, e) {
	txt_recman.GetInputElement().readOnly = true; 
}" />--%>
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المستفيد">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_paidto" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_paidto">
                                            <%--<ClientSideEvents Init="function(s, e) {
	txt_recman.GetInputElement().readOnly = true; 
}" />--%>
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                    <%--        <dx:LayoutItem Caption="القيمه"  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_recvalue" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_recvalue">
                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e)}" />
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>--%>

                            <dx:LayoutItem Caption="رقم مرجعى">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_payref" ClientInstanceName="txt_payref" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>


                            <dx:LayoutItem Caption="بيانات">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_paynotes" ClientInstanceName="txt_paynotes" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                              <dx:LayoutItem Caption="نوع الضريبة" ColumnSpan="3" CaptionCellStyle-Paddings-PaddingTop="10">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxRadioButtonList ID="rbl_vattype" ClientInstanceName="rbl_vattype" runat="server">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e){vattype()}" />
                                            </dx:ASPxRadioButtonList>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            
                            <dx:LayoutItem Caption="السعر بدون ضريبه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_pdbvat" ClientInstanceName="txt_pdbvat" Text="" runat="server" Theme="MaterialCompact" Font-Bold="True"   Font-Size="Medium" ForeColor="Black">
                                           <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e)}" KeyUp="function(s, e) {calc()}" GotFocus="function(s, e) {txt_pdbvat.SelectAll();}" TextChanged="function(s, e) {calc()}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            
                            <dx:LayoutItem Caption="الضريبه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_vatvalue" ClientInstanceName="txt_vatvalue" Text="0" runat="server" Theme="MaterialCompact" Font-Bold="True"  Font-Size="Medium" ForeColor="Black">
                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e)}" KeyUp="function(s, e) {calc()}" GotFocus="function(s, e) {txt_vatvalue.SelectAll();}" TextChanged="function(s, e) {calc()}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            
                            <dx:LayoutItem Caption="السعر شامل الضريبه">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_pdavat" ClientInstanceName="txt_pdavat" Text="" runat="server" Theme="MaterialCompact" Font-Bold="True"   Font-Size="Medium" ForeColor="Black">
                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e)}" KeyUp="function(s, e) {calc()}" GotFocus="function(s, e) {txt_pdavat.SelectAll();}"  TextChanged="function(s, e) {calc()}" />
                                        </dx:ASPxTextBox>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المستخدم"  >
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxTextBox ID="txt_pduser" runat="server" Theme="MaterialCompact" ClientInstanceName="txt_pduser">
                                            <ClientSideEvents Init="function(s, e) {
	txt_pduser.GetInputElement().readOnly = true; 
}" />
                                        </dx:ASPxTextBox>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="رقم القيد">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>

                                        <dx:ASPxHyperLink ID="txt_vchrid" runat="server" ClientInstanceName="txt_vchrid" Font-Bold="True" ForeColor="#009933" Font-Size="Medium">
                                         <ClientSideEvents Click='function(s, e) {
	window.open("/GL/Vouchers.aspx?vchrno="+txt_vchrid.GetValue(),"_blank")
}'></ClientSideEvents>
                                        </dx:ASPxHyperLink>
                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                             <dx:LayoutItem Caption="" Paddings-PaddingTop="15">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>


                                        <dx:ASPxLabel ID="lbl_postacc" runat="server"   ClientInstanceName="lbl_postacc" Visible="true" Font-Bold="True" Font-Size="16" RightToLeft="True" Theme="MaterialCompact" ForeColor="#009933" Font-Names="Aldhabi"></dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="المستند" Width="50%">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <dx:ASPxLabel ID="lbl_pddocimg1" ClientInstanceName="lbl_pddocimg1" runat="server" Theme="MaterialCompact" ForeColor="#009933" Width="80%">
                                        </dx:ASPxLabel>

                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>
                            <dx:LayoutItem Caption="" ParentContainerStyle-Paddings-PaddingRight="1" ParentContainerStyle-Paddings-PaddingLeft="0">
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
                            <dx:LayoutItem Caption="الملاحظات" ColumnSpan="3">
                                <LayoutItemNestedControlCollection>
                                    <dx:LayoutItemNestedControlContainer>
                                        <dx:ASPxMemo ID="txt_pdnotes" ClientInstanceName="txt_pdnotes" runat="server" Theme="MaterialCompact" Width="100%">
                                        </dx:ASPxMemo>


                                    </dx:LayoutItemNestedControlContainer>
                                </LayoutItemNestedControlCollection>

                            </dx:LayoutItem>


                           


                        </Items>
                    </dx:LayoutGroup>

                </Items>
            </dx:ASPxFormLayout>
            <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_postacc" />  
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="lbl_pddocimg" />
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_paychartid" />
            <asp:HiddenField runat="server" ClientIDMode="Static" ID="HF_paidchartid" />
            <asp:HiddenField ID="HF_pdid" ClientIDMode="Static" runat="server" />
        </ContentTemplate>
        <Triggers>
 

            <asp:PostBackTrigger ControlID="formLayout$btn_download" /> 
            <asp:PostBackTrigger ControlID="formLayout$upload" />
 

        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
