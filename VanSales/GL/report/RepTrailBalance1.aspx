<%@ Page Title="ميزان المراجعه رئيسي" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RepTrailBalance1.aspx.cs" Inherits="VanSales.GL.report.RepTrailBalance" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.2.Web.WebForms, Version=20.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div dir="rtl">
        <table style="width: 100%;">
            <tr>
                <td class="text-center" style="background-color: #dcdcdc">
                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="ميزان المراجعه - رئيسي" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                </td>
            </tr>
        </table>
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:HiddenField runat="server" Value="1" ClientIDMode="Static" ID="HF_legertype" />
    <div class="col-md-12" style="direction:rtl;   border: 1px Solid #DFDFDF;padding-top:10px ;">
           <div class="" style="text-align: center;padding-bottom: 3%;">
              <%--  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="استعراض">

                    <Image Height="20px" Url="~/img/icon/Btn_book.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>--%>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" AutoPostBack="False" Height="20px" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="عرض">
                    <Image Height="20px" Url="~/img/icon/search.svg" Width="20px"></Image>
               <ClientSideEvents Click="function(s,e){ASPxGridView1.PerformCallback()}"/>
                </dx:ASPxButton>
               <dx:ASPxButton UseSubmitBehavior="false" ID="btn_print" runat="server" AutoPostBack="False" Height="20px" OnClick="ASPxButton2_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="طباعه">
               <%--     <ClientSideEvents Click="function(s, e){ updateCount()}" />--%>
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
                
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" OnClick="btn_xlsxexport_Click" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ></dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_docexport" runat="server" Height="20px" Width="20px" ToolTip="Word" OnClick="btn_docexport_Click" Image-Url="~/Img/Icon/word.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary"></dx:ASPxButton>
                     <dx:ASPxButton UseSubmitBehavior="false" ID="btn_pdfexport" runat="server" Height="20px" Width="20px" ToolTip="PDF" OnClick="btn_pdfexport_Click" Image-Url="~/Img/Icon/pdf.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ></dx:ASPxButton>

                  
                <%--  <dx:ASPxButton UseSubmitBehavior="false" ID="btn_Save" runat="server" AutoPostBack="False" Height="20px" OnClick="btn_Save_Click" RenderMode="Secondary" Theme="MaterialCompact" Width="20px" ToolTip="حفظ">
 
                    <Image Height="20px" Url="~/img/icon/print.svg" Width="20px">
                    </Image>
                </dx:ASPxButton>
        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_xlsxexport" runat="server" Height="20px" Width="20px" ToolTip="استخراج البيانات فى ملف اكسيل" Image-Url="~/Img/Icon/excel.svg" AutoPostBack="False" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" OnClick="btn_xlsxexport_Click"></dx:ASPxButton>
                --%>
            </div>
<%--         <div style="border-top:solid 2px gray;margin:20px" >
             </div>--%>
 <div class="form-group form-row">
         <div class="form-group form-row">
          <label class="col-form-label">  حالة القيود</label>
               
                            <dx:ASPxComboBox ID="cmb_levelno"  runat="server">
                                
                            </dx:ASPxComboBox>
       
            
           
       
                    
        
               </div>

         <label class="col-form-label">   ميزان المراجعه رئيسي</label>
        
     
  
               
      </div>                 
      
           <div class="form-group form-row">
          <label class="col-form-label">  من</label>
               
                            <dx:ASPxDateEdit ID="dtefrom" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
       
            
           
          <label class="col-form-label" style="width:200px">  الي</label>
                
                            <dx:ASPxDateEdit ID="dteto" EditFormatString="dd/MM/yyyy" DisplayFormatString="dd/MM/yyyy" runat="server"></dx:ASPxDateEdit>
               
                    
        
               </div>

            <div class="form-group form-row">
          <label class="col-form-label">  حالة القيود</label>
               
                            <dx:ASPxComboBox ID="cmb_posted"  runat="server">
                                <Items>
                                   <dx:ListEditItem Value="0"  Text="الكل"/> 
                                    <dx:ListEditItem  Value="1" Text="مرحل"/>
                                  
                                </Items>
                            </dx:ASPxComboBox>
       
            
           
       
                    
        
               </div>
       
                   
            
                        <dx:ASPxGridView ID="ASPxGridView1" OnHtmlRowPrepared="ASPxGridView1_HtmlRowPrepared" ClientInstanceName="ASPxGridView1" OnCustomSummaryCalculate="ASPxGridView1_CustomSummaryCalculate"   runat="server" OnAfterPerformCallback="ASPxGridView1_AfterPerformCallback" OnCustomCallback="ASPxGridView1_CustomCallback" AutoGenerateColumns="False" KeyFieldName="itemunitid" OnDataBinding="ASPxGridView1_DataBinding">
                            <SettingsPager Visible="true"></SettingsPager>

                            <Settings ShowFilterRow="True" ShowFooter="true"></Settings>
                            <TotalSummary  ><dx:ASPxSummaryItem FieldName="debit"  Tag="debit" ShowInColumn="debit" SummaryType="Sum" DisplayFormat="اجمالى مدين {0}"/>
                                <dx:ASPxSummaryItem FieldName="credit" Tag="credit" ShowInColumn="credit" SummaryType="Sum" DisplayFormat="اجمالى دائن {0}" />
                                  <dx:ASPxSummaryItem FieldName="descp" ShowInColumn="descp" SummaryType="Custom" Tag="tot" />
                                  
                            </TotalSummary>
                            
                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                            <Columns>
                                <dx:GridViewDataTextColumn  FieldName="debit"  VisibleIndex="2" Caption="مدين"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="credit" VisibleIndex="3" Caption="دائن"></dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="balance"  VisibleIndex="5" Caption="الرصيد"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="vchtdate" VisibleIndex="4" Caption="التاريخ">
                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="descp" VisibleIndex="5" Caption="شرح الحركه" Width="30%"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ccname" VisibleIndex="6" Caption="مركز التكلفه" Width="30%"></dx:GridViewDataTextColumn>
                                
                                <dx:GridViewDataHyperLinkColumn FieldName="vchrno" Caption="رقم القيد" VisibleIndex="1">
                                    <PropertiesHyperLinkEdit NavigateUrlFormatString="~/GL/Vouchers.aspx?id={0}"></PropertiesHyperLinkEdit>
                                </dx:GridViewDataHyperLinkColumn>
                                
                            </Columns>
                            <Styles>
                                 <Header BackColor="#35B86B" Font-Bold="true" ForeColor="white" ></Header>
                                <Footer  BackColor="#35B86B" Font-Bold="true" ForeColor="white"></Footer>
                            </Styles>
                        </dx:ASPxGridView>
              
                 
     

        
        
        </div>
      <dx:ASPxGridViewExporter ID="gvinvExporter" runat="server"  FileName=" الفاتوره" GridViewID="ASPxGridView1" PaperKind="A4" PaperName=" رقم الصفحه" RightToLeft="True" Landscape="True">
                <PageHeader Center=" كشف حساب" Font-Bold="true" >
                </PageHeader>
                <PageFooter Center="[Pages #]" Right="[Date Printed][Time Printed]">
                </PageFooter>
                
                
            </dx:ASPxGridViewExporter>
            
            </ContentTemplate>
            <Triggers>
               <asp:PostBackTrigger ControlID="btn_xlsxexport" />
            <asp:PostBackTrigger ControlID="btn_addnew" />

                </Triggers>
            </asp:UpdatePanel>
</asp:Content>
