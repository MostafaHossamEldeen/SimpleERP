<%@ Page Title="الصفحة الرئيسية" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Default.aspx.cs" Inherits="VanSales._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%--  <div class="shape">
            
       <div class="container-grid row">
          
        
     <div class="container-grid col col-12 col-sm-4 col-md-4 col-lg-4 col-xl-4">
      <ul class="list-container liste1">
        <li class="list-item-container list-item-container-1"> <a type="button" href="../Sales/inv.aspx" class="homebtn">فاتورة</a>
        </li>
        <li class="list-item-container list-item-container-9"><a type="button" href="../Sales/Rtn_inv.aspx" class="homebtn">مرتجع</a>
        </li>
        <li class="list-item-container list-item-container-3"><a type="button" href="../Stock/Items.aspx" class="homebtn">الاصناف</a>
        </li>
      </ul>
    </div>
    <div class="container-grid col col-12 col-sm-4 col-md-4 col-lg-4 col-xl-4 container-10">
      <div class="responsive-picture logo1">
        <picture><img alt="Placeholder Picture" src="assets/img/logo512.png">
        </picture>
      </div>
    </div>
		      <div class="container-grid col col-12 col-sm-4 col-md-4 col-lg-4 col-xl-4">
      <ul class="list-container">
        <li class="list-item-container list-item-container-4"><a type="button" href="../Customers/customers.aspx" class="userbtn">العملاء</a>
        </li>
          <li class="list-item-container list-item-container-6"><a type="button" href="../sman/sman.aspx" class="userbtn">المندوبين</a>
        </li>
        <li class="list-item-container list-item-container-5"><a type="button" href="../Users/users.aspx" class="userbtn">مستخدمين</a>
        </li>
      </ul>
    </div>
   
           
                
           
           <picture><img src="assets/img/man.png" alt="Placeholder Picture" class="img">
      </picture>   
           
  </div>
            
        </div>--%>

       
            <div class="row rowcback">
                <div class="col-xl-6 col-lg-12 mb-4" >
                     <div class="laptop" >
                        <img runat="server" id="imglogo" src="" class="laptopimg"/>
                          
                    </div>
                    <div class="card leftcard">
<!--left card-body-->
                        <div class="card-body" style="text-align:center;">
                            <dx:ASPxDataView ID="dvshortmenu" ClientInstanceName="dvshortmenu" ToolTip="قائمتي المختصرة" runat="server" Width="100%" Height="100%" ItemStyle-Height="100%" OnDataBinding="dvshortmenu_DataBinding" Cursor="auto">
                            <ItemTemplate>
                                <dx:ASPxHyperLink ID="hlshortmenu" ClientInstanceName="hlshortmenu" CssClass="short_menu" DisabledStyle-Cursor="" runat="server" ToolTip='<%# System.Web.HttpUtility.HtmlEncode(Eval("dbname")) %>' Text='<%# System.Web.HttpUtility.HtmlEncode(Eval("dbname")) %>' NavigateUrl='<%# System.Web.HttpUtility.HtmlEncode(Eval("dblink")) %>' Font-Bold="true" Font-Size="Medium" Font-Underline="false">
                                </dx:ASPxHyperLink>
                            </ItemTemplate>
                        </dx:ASPxDataView>
                           <%-- <a href="#" class="shortmenu">link1
                                <i class="iconsmind-Shop-4"></i>
                            </a>
                            <a href="#" class="shortmenu">link2
                                <i class="iconsmind-Shop-4"></i>
                            </a>
                            <a href="#" class="shortmenu">link3
                                <i class="iconsmind-Shop-4"></i> 
                            </a>
                            <br>
                            <br>
                            <br>
                            <a href="#" class="shortmenu">link4
                                <i class="iconsmind-Shop-4"></i> 
                            </a>
                            <a href="#" class="shortmenu">link5
                                <i class="iconsmind-Shop-4"></i> 
                            </a>
                            <a href="#" class="shortmenu">link6
                                <i class="iconsmind-Shop-4"></i> 
                            </a>
                            <br>
                            <br>
                            <br>
                            <a href="#" class="shortmenu">link7
                                <i class="iconsmind-Shop-4"></i> 
                            </a>
                            <a href="#" class="shortmenu">link8
                                <i class="iconsmind-Shop-4"></i>
                            </a>
                            <a href="#" class="shortmenu">link9
                                <i class="iconsmind-Shop-4"></i> 
                            </a> --%>
                        </div>
                    </div>
                </div>
<!--right card-body-->
                <div class="col-lg-12 col-xl-6">

                    <div class="icon-cards-row">
                        <div class="owl-container">
                            <div class="owl-carousel dashboard-numbers">
                                <a href="http://localhost:44317/Sales/inv_report.aspx" class="card">
                                    <div class="card-body text-center">
                                         <i class="iconsmind-Alarm"></i>
                                         <p class="card-text mb-0">    فواتير مبيعات اليوم  </>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfDailySinv" runat="server" ClientInstanceName="lbl_NoOfDailySinv" ></dx:ASPxLabel>
                                         <p class="card-text mb-0">    اجمالى مبيعات اليوم </>
                                         <p class="lead text-center" > </p>
                                         <dx:ASPxLabel ID="lbl_TotalOfDailySinv" runat="server" ClientInstanceName="lbl_TotalOfDailySinv" ></dx:ASPxLabel>

                                    </div>
                                </a>
                                <a href="http://localhost:44317/Sales/inv_report.aspx" class="card">
                                    <div  class="card-body text-center">
                                         <i class="iconsmind-Basket-Coins"></i>
                                         <p class="card-text mb-0">فواتير مرتجع مبيعات اليوم  </p>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfDailyRtnSinv" runat="server" ClientInstanceName="lbl_NoOfDailyRtnSinv" ></dx:ASPxLabel>
                                         <p class="card-text mb-0"> اجمالى مرتجع مبيعات اليوم  </p>
                                         <p class="lead text-center" > </p>
                                         <dx:ASPxLabel ID="lbl_TotalOfDailyRtnSinv" runat="server" ClientInstanceName="lbl_TotalOfDailyRtnSinv" ></dx:ASPxLabel>

                                    </div>
                                </a>
                                 <a href="http://localhost:44317/Purchases/P_inv_Report.aspx" class="card">
                                    <div  class="card-body text-center">
                                         <i class="iconsmind-Basket-Coins"></i>
                                         <p class="card-text mb-0">فواتير مشتريات اليوم  </p>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfDailyPur" runat="server" ClientInstanceName="lbl_NoOfDailyPur" ></dx:ASPxLabel>
                                         <p class="card-text mb-0"> اجمالى مشتريات اليوم  </p>
                                         <p class="lead text-center" > </p>
                                         <dx:ASPxLabel ID="lbl_TotalOfDailyPur" runat="server" ClientInstanceName="lbl_TotalOfDailyPur" ></dx:ASPxLabel>

                                    </div>
                                </a>
                               <a href="http://localhost:44317/Purchases/P_inv_Report.aspx" class="card">
                                    <div  class="card-body text-center">
                                         <i class="iconsmind-Basket-Coins"></i>
                                         <p class="card-text mb-0">فواتير  مرتجع مشتريات اليوم  </p>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfDailyRtnPur" runat="server" ClientInstanceName="lbl_NoOfDailyRtnPur" ></dx:ASPxLabel>
                                         <p class="card-text mb-0"> اجمالى مرتجع مشتريات اليوم  </p>
                                         <p class="lead text-center" > </p>
                                         <dx:ASPxLabel ID="lbl_TotalOfDailyRtnPur" runat="server" ClientInstanceName="lbl_TotalOfDailyRtnPur" ></dx:ASPxLabel>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="icon-cards-row">
                        <div class="owl-container">
                            <div class="owl-carousel dashboard-numbers">
                                      <a href="http://localhost:44317/GL/pay_doc_report.aspx" class="card">
                                    <div class="card-body text-center">
                                         <i class="iconsmind-Alarm"></i>
                                         <p class="card-text mb-0">   مدفوعات اليوم   </>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfDailyPay" runat="server" ClientInstanceName="lbl_NoOfDailyPay" ></dx:ASPxLabel>
                                         <p class="card-text mb-0"> اجمالي مدفوعات اليوم  </>
                                         <p class="lead text-center" > </p>
                                         <dx:ASPxLabel ID="lbl_TotalOfDailyPay" runat="server" ClientInstanceName="lbl_TotalOfDailyPay" ></dx:ASPxLabel>

                                    </div>
                                </a>
                                    <a href="http://localhost:44317/GL/rec_doc_report.aspx" class="card">
                                    <div class="card-body text-center">
                                         <i class="iconsmind-Alarm"></i>
                                         <p class="card-text mb-0">   مقبوضات اليوم  </>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfDailyRec" runat="server" ClientInstanceName="lbl_NoOfDailyRec" ></dx:ASPxLabel>
                                         <p class="card-text mb-0">    اجمالى مقبوضات اليوم  </>
                                         <p class="lead text-center" > </p>
                                         <dx:ASPxLabel ID="lbl_TotalOfDailyRec" runat="server" ClientInstanceName="lbl_TotalOfDailyRec" ></dx:ASPxLabel>

                                    </div>
                                </a>
                             <a href="http://localhost:44317/Stock/st_Items_data_balances_report.aspx" class="card">
                                    <div class="card-body text-center">
                                         <i class="iconsmind-Alarm"></i>
                                         <p class="card-text mb-0">  عدداصناف وصلت لحد الطلب   </>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfItemMINQTY" runat="server" ClientInstanceName="lbl_NoOfItemMINQTY" ></dx:ASPxLabel>
                                        </div>
                                   
                                </a>
                                    <a href="http://localhost:44317/Stock/st_Items_data_balances_report.aspx" class="card">
                                    <div class="card-body text-center">
                                         <i class="iconsmind-Alarm"></i>
                                         <p class="card-text mb-0">  عدداصناف وصلت للحد الاقصي    </>
                                         <p class="lead text-center"> </p>
                                         <dx:ASPxLabel ID="lbl_NoOfItemMaxQTY" runat="server" ClientInstanceName="lbl_NoOfItemMaxQTY" ></dx:ASPxLabel>
                                        </div>
                                </a>
                            </div>
                        </div>
                           <div>
                        <img src="../vansalesthemsfile/img/emax.png" alt="" class="company_logo">
                    </div> 
                    </div>
                </div>
            </div>
        </asp:Content>