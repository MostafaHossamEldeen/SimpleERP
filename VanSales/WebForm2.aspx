<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="VanSales.WebForm2" %>



<!DOCTYPE html>
<html lang="ar">

<head id="head1" runat="server">
    <meta charset="UTF-8">
    <title id="title1"><%= Page.Title %></title>
    <meta name="viewport" content="width=device-width,user-scalable=no,maximum-scale=1.0,minmum-sclae=1.0 initial-scale=1">
     
    <link rel="stylesheet" href="/vansalesthemsfile/font/iconsmind/style.css" />
    <link rel="stylesheet" href="/vansalesthemsfile/font/simple-line-icons/css/simple-line-icons.css" />
    <link href="VanSalesThemsFile/font/themify/themify.css" rel="stylesheet" />
    <link rel="stylesheet" href="/vansalesthemsfile/css/vendor/bootstrap.min.css" />
    <link rel="stylesheet" href="/vansalesthemsfile/css/vendor/perfect-scrollbar.css" />
    <link rel="stylesheet" href="/vansalesthemsfile/css/vendor/owl.carousel.min.css" />
    <link rel="stylesheet" href="/vansalesthemsfile/css/main.css" />
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.2/css/all.min.css"  integrity="sha512-HK5fgLBL+xu6dm/Ii3z4xhlSUyZgTT9tuc/hSrtw6uzJOvgRr2a9jyxxT1ely+B+xFAmJKVSTbpM/CuL7qxO8w==" crossorigin="anonymous" />--%>
   <link rel="stylesheet" href="Content/all.min.css"   />
     
    <link href="/Content/disablebtn.css" rel="stylesheet" />
    <link href="/Content/animate.css" rel="stylesheet" />
    <link href="/Content/dx.light.css" rel="stylesheet" />
    <link href="/Content/dx.common.css" rel="stylesheet" />
    <link href="/Content/accordion.css" rel="stylesheet" />
<%--    <script src="/VanSalesThemsFile/js/vendor/jquery-3.3.1.min.js"></script>--%>
    <script
  src="https://code.jquery.com/jquery-3.6.0.min.js"
  integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="
  crossorigin="anonymous"></script>
    <script src="/Scripts/jquery.cookie.js"></script>
    <script src="/Scripts/App/base/Helperjs.js"></script>
    <script src="/Scripts/App/base/ApiHelper.js"></script>
    <script src="/Scripts/App/base/DevExpressJsHelper.js"></script>
    
    <script src="/Scripts/dx.all.js"></script>
    <%--<script src="/Scripts/jquery.blockUI.js"></script>--%>
      <style>
.dxgvControl_MaterialCompact, 
.dxgvDisabled_MaterialCompact {
    font: 14px 'Roboto Regular', Helvetica, 'Droid Sans', Tahoma, Geneva, sans-serif;
    background-color: White;
    color: #484848;
    cursor: default;
    padding: 16px;
    padding: 16px;
}  


.dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused) > tr > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused):hover > td, .dx-datagrid-rowsview .dx-selection.dx-row:not(.dx-row-focused):hover > tr > td {
    background-color: #35B86B;
    color: #333;
}

 .btnsearchpopup{
         padding: 6px 13px 4px;
         background-color:white;
         -webkit-box-shadow: 0 2px 5px 0 rgb(0 0 0 / 16%), 0 2px 10px 0 rgb(0 0 0 / 12%);
        /* height:30px;
         width:30px*/
            height: 37px;
    width: 48px;

 }
 .btnsearchpopup:before {
   content: url(../img/icon/search.svg);
   width: 20px;
   float: left;
     /*margin-top: 5px;*/
    margin-left: -3px;
 }

          .dxflNestedControlCell_MaterialCompact .dxflNotFloatedElSys {
          
          padding-top:20px;
          }

          .dx-datagrid-rowsview .dx-row-focused.dx-data-row .dx-command-edit:not(.dx-focused) .dx-link, .dx-datagrid-rowsview .dx-row-focused.dx-data-row > td:not(.dx-focused), .dx-datagrid-rowsview .dx-row-focused.dx-data-row > tr > td:not(.dx-focused) {
    background-color: White;
    color: #fff;
}
          .modal-header .close {
    padding: 1rem;
    margin: -1rem -1rem -1rem;
}
    </style>
  
     <link href="/VanSalesThemsFile/spiner/css/style.css" rel="stylesheet" />

</head>

<body id="app-container" class="menu-default"> 
 <%--   <div id="emaxspiner" class="spinner spinner-1" >
        <h5 class="loading" style="position:absolute; top:25%; left:30px;">برجاء الانتظار</h5>
      </div>--%>
    <div id="emaxcontent" style="display:block">

   
  <div class="modal" onkeydown="navigategrd(event)"  id="popupModalsearchdef" style="z-index:999999999;" data-name="aaa" tabindex="-1" role="alertdialog" aria-labelledby="popupModalLabel" aria-hidden="true" dir="rtl">
    <div class="modal-dialog" role="alertdialog">
        <div class="modal-content" style = "height:400px;min-height:400px" >
        <div class="modal-header">
        <h5 class="modal-title" id="popupModalLabel">بحث</h5>
        <button type="button" class="close float-right" data-dismiss="modal" aria-label="Close">
        <span aria-hidden="true">&times;</span>
        </button>
        </div>
        <div class="modal-body" >
       <div class="container-fluid">
     
       <div class="form-group row">
        <input type="text" id="txt_search" onkeydown="searchitm(event)" autocomplete="off"   placeholder="بحث" class="form-control" style="width:80%" />
  
      
        
        <button type="button"onclick="searchItmPopUp()" style="width:10%;margin-right:10px" class="btn btn-sm btnsearchpopup form-control"></button>
       </div>
   
          </div>
        <div   style="margin-top:10px">
        <div id="grd_search"></div>


        </div>
       
       </div>
     </div>

  </div>
      </div>
     <nav class="navbar fixed-top">
        <div class="d-flex align-items-center navbar-right">
            <a class="navbar-logo" href="../default.aspx">
                 <span class="logo d-none d-xs-block"></span>
            </a>
            <a href="#" class="menu-button d-md-block" id="testpin">
                <svg class="main" viewBox="0 0 9 17">
                    <rect x="0.48" y="0.5" width="7" height="1" />
                    <rect x="0.48" y="7.5" width="7" height="1" />
                    <rect x="0.48" y="15.5" width="7" height="1" />
                </svg>
                <svg class="sub" viewBox="0 0 18 17">
                    <rect x="1.56" y="0.5" width="16" height="1" />
                    <rect x="1.56" y="7.5" width="16" height="1" />
                    <rect x="1.56" y="15.5" width="16" height="1" />
                </svg>
            </a>
            <div  class="search" data-search-path="file.default.html?q=">
                <input type="text" id="myInput" placeholder="بحث في القائمة..." title="Type in a name">
                <span class="search-icon">
                    <i class="simple-icon-magnifier"></i>
                </span>
            </div>
        </div>
        <div class="company">
            <div class="company_name">
                <asp:Label runat="server" ID="lblcompenyname" class="company_namete"></asp:Label>
                    <asp:Label runat="server" ID="lblcompney_job" class="jop_company"></asp:Label>
               <%-- <a class="jop_company">information technology</a>--%>
            </div>
            <div class="info_company">
                <span class="text">عدد المستخدمين:
                    <asp:Label ID="lblcount" runat="server" Text="Label"></asp:Label>
                </span>
                <span class="text">السنة المالية:
                    <a>2021</a>
                </span>
                <span class="text">التاريخ:
                          <asp:Label ID="lbldte" runat="server" Text="Label">1/1/2021</asp:Label>
                </span>  
            </div>
        </div>

        <div class="navbar-left">
            <div class="header-icons d-inline-block align-middle">
<!--notification-->
                <div class="position-relative d-inline-block">
                    <button class="header-icon btn btn-empty" type="button" id="notificationButton" data-toggle="dropdown"
                        aria-haspopup="true" aria-expanded="false">
                        <i class="simple-icon-bell"></i>
                        <span class="count">3</span>
                    </button>
                    <div class="dropdown-menu dropdown-menu-left mt-3 scroll position-absolute" id="notificationDropdown">
                        <div class="d-flex flex-row mb-3 pb-3 border-bottom">
                            <a href="#">
                                <img src="#" alt="Notification Image" class="img-thumbnail list-thumbnail xsmall border-0 rounded-circle" />
                            </a>
                            <div class="pl-3 pr-2">
                                <a href="#">
                                    <p class="font-weight-medium mb-1">Joisse Kaycee just sent a new comment!</p>
                                    <p class="text-muted mb-0 text-small">09.04.2018 - 12:45</p>
                                </a>
                            </div>
                        </div>
                        <div class="d-flex flex-row mb-3 pb-3 border-bottom">
                            <a href="#">
                                <img src="#" alt="Notification Image" class="img-thumbnail list-thumbnail xsmall border-0 rounded-circle" />
                            </a>
                            <div class="pl-3 pr-2">
                                <a href="#">
                                    <p class="font-weight-medium mb-1">1 item is out of stock!</p>
                                    <p class="text-muted mb-0 text-small">09.04.2018 - 12:45</p>
                                </a>
                            </div>
                        </div>
                        <div class="d-flex flex-row mb-3 pb-3 border-bottom">
                            <a href="#">
                                <img src="#" alt="Notification Image" class="img-thumbnail list-thumbnail xsmall border-0 rounded-circle" />
                            </a>
                            <div class="pl-3 pr-2">
                                <a href="#">
                                    <p class="font-weight-medium mb-1">New order received! It is total $147,20.</p>
                                    <p class="text-muted mb-0 text-small">09.04.2018 - 12:45</p>
                                </a>
                            </div>
                        </div>

                        <div class="d-flex flex-row mb-3 pb-3 ">
                            <a href="#">
                                <img src="#" alt="Notification Image" class="img-thumbnail list-thumbnail xsmall border-0 rounded-circle" />
                            </a>
                            <div class="pl-3 pr-2">
                                <a href="#">
                                    <p class="font-weight-medium mb-1">3 items just added to wish list by a user!</p>
                                    <p class="text-muted mb-0 text-small">09.04.2018 - 12:45</p>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
<!--End notification-->
                
<!--fullscreen-->
                <button class="header-icon btn btn-empty d-none d-sm-inline-block" type="button" id="fullScreenButton">
                    <i class="simple-icon-size-fullscreen"></i>
                    <i class="simple-icon-size-actual"></i>
                </button>
<!--End fullscreen-->
            </div>

<!--user-->
            <div class="user d-inline-block">
                <button class="btn btn-empty p-0" type="button" data-toggle="dropdown" aria-haspopup="true"
                    aria-expanded="false">
                   <asp:Label ID="lblname" CssClass="name" runat="server" Text="Label"></asp:Label>
                </button>
                <div class="dropdown-menu dropdown-menu-left mt-3" style="text-align:right">
                    <a class="dropdown-item" href="../Users/userresetpass.aspx">تغير كلمه المرور</a>
                    <a class="dropdown-item" href="../Sys/short_menu.aspx">قائمتي المختصرة</a>
                    <a class="dropdown-item" href="../logout.aspx">تسجيل خروج</a>
                    
                </div>
            </div>
<!--End user-->
        </div>
    </nav>
<!--sidebar-->
    <div class="sidebar">
        <div class="main-menu">
            <div class="scroll">
                <ul class="list-unstyled">
                    <li class="active">
                        <a href="#mainfiles">
                            <i class="simple-icon-layers"></i>
                            <span>الملفات الرئيسية</span>
                        </a>
                    </li>
                    <li>
                        <a href="#stock">
                            <i class="iconsmind-Shop-4"></i> المستودعات
                        </a>
                    </li>
                    <li>
                        <a href="#sales">
                            <i class="iconsmind-Full-Cart"></i> المبيعات
                        </a>
                    </li>
                      <li>
                        <a href="#purchase">
                            <i class="iconsmind-Full-Cart"></i> المشتريات
                        </a>
                    </li>
                    <li>
                        <a href="#GL">
                            <i class="iconsmind-Full-Cart"></i> الحسابات
                        </a>
                    </li> 
                    <li>
                        <a href="#Doc">
                            <i class="iconsmind-Full-Cart"></i> القبض والصرف
                        </a>
                    </li>
                    <li>
                        <a href="#setting">
                            <i class="simple-icon-equalizer"></i> الاعدادت
                        </a>
                    </li>
                </ul>
            </div>
        </div>
<!--sub menu-->
        <div class="sub-menu">
                   <div>
                <!-- onclick="hideMenu();" -->
                <a class="pin" type="button">   
                    <i id = "freeze" class="ti-pin2"></i>
                </a>
            </div>
            <div class="scroll">
     <!--file_master sub menu-->
                <ul class="list-unstyled" data-link="mainfiles">
                    <li class="active">
                        <a href="../Sys/sys_company.aspx">الشركة
                            <i class="iconsmind-Hotel"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Sys/Branch.aspx">الفروع
                            <i class="iconsmind-Vector-3"></i>
                        </a>
                    </li>
                    <li>
                        <a href="../Sys/CostCenter.aspx">مراكز التكلفة
                            <i class="iconsmind-Bank"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Sys/payment_type.aspx">طرق الدفع
                            <i class="iconsmind-Money-2"></i> 
                        </a>
                    </li>
                     <li>
                        <a href="../Sys/Years.aspx">السنوات المالية
                            <i class="simple-icon-calendar"></i> 
                        </a>
                    </li>
                </ul>
     <!--stock sub menu-->
                <ul class="list-unstyled" data-link="stock">
                    <li>
                        <a href="../unit/unit.aspx">الوحدات
                            <i class="iconsmind-Shoutwire"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Group/ItemGroups.aspx">مجموعات الاصناف
                            <i class="simple-icon-organization"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Stock/Items.aspx">الاصناف
                            <i class="iconsmind-Basket-Items"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Stock/st_itemwh.aspx">اصناف الفروع
                            <i class="simple-icon-book-open"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Stock/st_Edit_add_ord.aspx">أذون الاضافة
                            <i class="iconsmind-File-Download"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Stock/st_edit_issord.aspx">أذون الصرف
                            <i class="iconsmind-File-Upload"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Stock/st_Trans_ord.aspx">أذون التحويل
                            <i class="iconsmind-File-Share"></i> 
                        </a>
                    </li> 
                    <li>
                        <a href="../Stock/st_Receipt_transfer.aspx">أذون الاستلام
                            <i class="iconsmind-File-Download"></i> 
                        </a>
                    </li>
                          <li>
                        <a href="../Stock/Inventory_Manage.aspx">سندات الجرد
                            <i class="fas fa-search"></i> 
                        </a>
                    </li>
                </ul>
     <!--sales sub menu-->                
                <ul class="list-unstyled" data-link="sales">
                    <li>
                        <a href="../Group/CustGroup.aspx">مجموعات العملاء
                            <i class="simple-icon-organization"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Customers/customers.aspx">العملاء
                            <i class="iconsmind-Business-Mens"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../sman/sman.aspx">المندوبين
                            <i class="iconsmind-Mens"></i> 
                        </a>
                    </li>
                      <li>
                        <a href="../Sales/s_quote_order.aspx">عرض أسعار 
                            <i class="iconsmind-Billing"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Sales/S_order.aspx">أمر البيع
                            <i class="iconsmind-Billing"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Sales/inv.aspx">فاتورة البيع
                            <i class="iconsmind-Billing"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Sales/Rtn_inv.aspx">مرتجع الفواتير
                            <i class="iconsmind-File-Refresh"></i> 
                        </a>
                    </li>
                </ul>

                 <ul class="list-unstyled" data-link="purchase">
                    <li>
                        <a href="../Group/SuppGroup.aspx">مجموعات الموردين
                            <i class="simple-icon-organization"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Supplier/Supplier.aspx">الموردين
                            <i class="iconsmind-Business-Mens"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../request/request.aspx">طلبيات الشراء
                            <i class="iconsmind-Mens"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Purchases/Orders.aspx">أمر الشراء
                            <i class="iconsmind-Billing"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Purchases/P_Inv.aspx">فاتورة الشراء
                            <i class="iconsmind-Billing"></i> 
                        </a>
                    </li>
                    <li>
                        <a href="../Purchases/Rtn_P_Inv.aspx">مرتجع الفواتير
                            <i class="iconsmind-File-Refresh"></i> 
                        </a>
                    </li>
                </ul>
                <!--GL sub menu-->
                <ul class="list-unstyled" data-link="GL">
                      <li>
                        <a href="../GL/Chart.aspx">دليل الحسابات
                            <i class="simple-icon-people"></i> 
                        </a>
                          <li>
                        <a href="../GL/Vouchers.aspx">القيود اليومية
                            <i class="simple-icon-people"></i> 
                        </a>
                    </li>                   
                </ul>
                   <!--Doc sub menu-->
                <ul class="list-unstyled" data-link="Doc">
                      <li>
                        <a href="../GL/rec_doc.aspx"> سندات القبض
                            <i class="simple-icon-people"></i> 
                        </a>
                          <li>
                        <a href="../GL/pay_doc.aspx">سندات الصرف
                            <i class="simple-icon-people"></i> 
                        </a>
                    </li>                
                </ul>
     <!--setting sub menu-->
                <ul class="list-unstyled" data-link="setting">
                      <li>
                        <a href="../sys/sys_settings.aspx">اعدادات النظام
                            <i class="simple-icon-people"></i> 
                        </a>
                    </li> 
                    <li>
                        <a href="../Users/users.aspx">المستخدمين
                            <i class="simple-icon-people"></i> 
                        </a>
                    </li> 
                   <li>
                        <a href="../GL/AccPay.aspx">حسابات طرق الدفع
                            <i class="simple-icon-people"></i> 
                        </a>
                    </li> 
                    <li>
                        <a href="../GL/AccBranchs.aspx">ربط الحسابات الرئيسية
                            <i class="simple-icon-people"></i> 
                        </a>
                    </li> 
                       
                </ul>
<!--end sub menu-->
            </div>
        </div>
    </div>
<!--End sidebar-->
     

    <main>
        <div class="container-fluid" >
        <%--          <div class="cir" id="crlogo">
                <div class="Ellipse_1" id="test">
                    <img src="../vansalesthemsfile/img/emax.png" alt="" class="userlogo">
                </div>
            </div>--%>
          <%--  <a class="logobottom bto" id="cor" onclick="cirlogo();"><i class="simple-icon-arrow-up"></i></a>--%>
              <%--  <div class="laptop" id="moduleerp"></div>--%>
                                <div class="">
                                    <!---->
                                    <form runat="server" id="mainfrm" class="mainformstyle">
                                    <%--    <asp:ScriptManager runat="server">
                                            <Scripts>
                                             
                                                <asp:ScriptReference Name="MsAjaxBundle" />
                                               
                                                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                                                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                                                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                                                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                                                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                                                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                                                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                                                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                                                <asp:ScriptReference Name="WebFormsBundle" />
                                               
                                               

                                               
                                            </Scripts>
                                        </asp:ScriptManager> 
                                        <script type="text/javascript" lang="javascript">
                                            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
                                            function EndRequestHandler(sender, args) {
                                                if (args.get_error() != undefined) {
                                                    args.set_errorHandled(true);
                                                }
                                            } </script>

                                             
                                        <asp:ContentPlaceHolder ID="MainContent" runat="server">
                                       
                                        </asp:ContentPlaceHolder>--%>


                                         <div dir="rtl">
                <table style="width: 100%;">
                    <tr>
                        <td class="text-center" style="background-color: #dcdcdc">
                            <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="إدارة الأصــنــاف" Font-Bold="True" Font-Size="XX-Large" RightToLeft="True" Theme="MaterialCompact" ForeColor="#35B86B"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div dir="rtl" style="text-align: center; padding-bottom: 20px;">
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addnew" runat="server" Height="20px" Width="20px" ToolTip="جديد" Image-Url="~/Img/Icon/add-new.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {cleardata();}" />
                </dx:ASPxButton>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_save" OnClick="btn_save_Click" runat="server" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" AutoPostBack="true" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ValidationGroup="A">
                    <ClientSideEvents Click="function(s, e) {validate(s, e);}" />
                </dx:ASPxButton>
                <button type="button" title="بحث" id="PopUpControlSearch" data-name="inv" data-tablename="st_item_sel_pop" data-displayfields="itemcode,itembarcode,itemname"
                    data-displayfieldshidden="pinvid,pinvpay,branchid,ccid,suppid,suppname,suppvat,puser,pnotes,netbvat,vatvalue,netavat,docid,docno,invpic,vattype"
                    data-displayfieldscaption="كود الصنف,باركود الصنف,اسم الصنف"
                    data-bindcontrols="hf_itemid;txt_itemcode;txt_itemcode2;txt_itemcode3;txt_itembarcode;txt_itembarcode2;txt_itemname;txt_itemename;txt_itemdesc;cmb_unitid;cmb_groupid;cmb_itemtypeid;cmb_suppid;cmb_itemstop;txt_minqty;txt_maxqty;txt_pprice;txt_cprice;txt_sprice;txt_vat;txt_vprice;txt_fprice;hf_imgpath;cmb_itemcat1;cmb_itemcat2;txt_itemfield1;txt_itemfield2"
                    data-bindfields="itemid;itemcode;itemcode2;itemcode3;itembarcode;itembarcode2;itemname;itemename;itemdesc;unitid;groupid;itemtypeid;suppid;itemstop;minqty;maxqty;pprice;cprice;sprice;vat;vprice;fprice;itempic;itemcat1;itemcat2;itemfield1;itemfield2"
                    data-apiurl="/VanSalesService/items/FillPopup" data-pkfield="itemid" onclick="createPopUp($(this),'popupModalsearch')" class="btn btn-sm btnsearchpopup">
                </button>
                <dx:ASPxButton UseSubmitBehavior="false" ID="btn_delete" runat="server" Height="20px" Width="20px" ToolTip="حذف" Image-Url="~/Img/Icon/delete.svg" AutoPostBack="false" Image-Width="20px" Image-Height="20px" RenderMode="Secondary">
                    <ClientSideEvents Click="function(s, e) {DelData_Master('/VanSalesService/Item/item_manage_del','hf_itemid')}" />
                </dx:ASPxButton>
            </div>
            <div class="accordion">
                <div class="accordion__item">
                    <div class="accordion__item__header active">
                        البيانات الأساسية للصنف
                    </div>
                    <div class="accordion__item__content" style="display: block;">
                        <asp:Panel ID="Panel1" runat="server" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                            <dx:ASPxFormLayout AlignItemCaptionsInAllGroups="true" AlignItemCaptions="true" SettingsItemCaptions-HorizontalAlign="Left" runat="server" ID="formLayout" RightToLeft="True">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                                <Items>
                                    <dx:LayoutGroup ColCount="5" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="كود الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemcode" ClientInstanceName="txt_itemcode" runat="server" Theme="MaterialCompact" Font-Bold="True" ForeColor="Black" Text="تلقائى" ClientSideEvents-KeyDown="function(s,e){preventwriteitemcode1(s,e);}">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="كود الصنف 2 ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemcode2" ClientInstanceName="txt_itemcode2" AutoCompleteType="Disabled" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="كود المورد ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemcode3" ClientInstanceName="txt_itemcode3" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="باركود الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itembarcode" ClientInstanceName="txt_itembarcode" AutoCompleteType="Disabled" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="باركود الصنف 2 ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itembarcode2" ClientInstanceName="txt_itembarcode2" AutoCompleteType="Disabled" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="10" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem ColumnSpan="3" Caption="إسم الصنف ع ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemname" ClientInstanceName="txt_itemname" runat="server" Theme="MaterialCompact" Font-Bold="true">
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_itemname" ClientIDMode="Static" runat="server" ControlToValidate="txt_itemname" Display="Dynamic" ErrorMessage="برجاء إدخال إسم الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem ColumnSpan="3" Caption="إسم الصنف E ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_itemename" ClientInstanceName="txt_itemename" runat="server" Theme="MaterialCompact">
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem ColumnSpan="4" Caption="الوصف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxMemo ID="txt_itemdesc" ClientInstanceName="txt_itemdesc" runat="server" Theme="MaterialCompact"></dx:ASPxMemo>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="الوحدة الأساسية ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_unitid" ClientInstanceName="cmb_unitid" runat="server" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_unitid" ClientIDMode="Static" runat="server" ControlToValidate="cmb_unitid" Display="Dynamic" ErrorMessage="برجاء إختيار وحدة الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="المجموعة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_groupid" ClientInstanceName="cmb_groupid" runat="server" ValueType="System.String" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_groupid" ClientIDMode="Static" runat="server" ControlToValidate="cmb_groupid" Display="Dynamic" ErrorMessage="برجاء إختيار مجموعة الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="نوع الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_itemtypeid" ClientInstanceName="cmb_itemtypeid" runat="server" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_itemtypeid" ClientIDMode="Static" runat="server" ControlToValidate="cmb_itemtypeid" Display="Dynamic" ErrorMessage="برجاء إختيار نوع الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="المورد ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_suppid" ClientInstanceName="cmb_suppid" runat="server" ValueType="System.String" Theme="MaterialCompact" RightToLeft="True" ClearButton-DisplayMode="Always"></dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="إيقاف الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cmb_itemstop" ClientInstanceName="cmb_itemstop" runat="server" ValueType="System.String" Theme="MaterialCompact" RightToLeft="True"></dx:ASPxComboBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcmb_itemstop" ClientIDMode="Static" runat="server" ControlToValidate="cmb_itemstop" Display="Dynamic" ErrorMessage="برجاء إختيار نوع إيقاف الصنف" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="أقل كمية ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_minqty" AutoCompleteType="Disabled" ClientInstanceName="txt_minqty" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="أقصى كمية ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_maxqty" AutoCompleteType="Disabled" ClientInstanceName="txt_maxqty" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر الشراء ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_pprice" AutoCompleteType="Disabled" ClientInstanceName="txt_pprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_pprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_pprice" Display="Dynamic" ErrorMessage="برجاء إدخال سعر الشراء" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر التكلفة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_cprice" AutoCompleteType="Disabled" ClientInstanceName="txt_cprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر البيع ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_sprice" AutoCompleteType="Disabled" runat="server" ClientInstanceName="txt_sprice" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}" KeyUp="function(s, e) {mastercalcVat(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_sprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_sprice" Display="Dynamic" ErrorMessage="برجاء إدخال سعر البيع" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="الضريبة % ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_vat" AutoCompleteType="Disabled" ClientInstanceName="txt_vat" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}" KeyUp="function(s, e) {mastercalcVat(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_vat" ClientIDMode="Static" runat="server" ControlToValidate="txt_vat" Display="Dynamic" ErrorMessage="برجاء إدخال قيمة الضريبة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="السعر شامل الضريبة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_vprice" AutoCompleteType="Disabled" ClientInstanceName="txt_vprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {preventwrite(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_vprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_vprice" Display="Dynamic" ErrorMessage="برجاء إدخال السعر شامل الضريبة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="سعر الفاتورة ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="txt_fprice" AutoCompleteType="Disabled" ClientInstanceName="txt_fprice" runat="server" Theme="MaterialCompact">
                                                            <ClientSideEvents KeyPress="function(s, e) {decimale3num(s, e);}"></ClientSideEvents>
                                                        </dx:ASPxTextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxt_fprice" ClientIDMode="Static" runat="server" ControlToValidate="txt_fprice" Display="Dynamic" ErrorMessage="برجاء إدخال سعر الفاتورة" ForeColor="Red" SetFocusOnError="True" Text="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="None">
                                        <Items>
                                            <dx:LayoutItem Caption="صورة الصنف ">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxUploadControl ID="upd_itempic" OnFileUploadComplete="upd_itempic_FileUploadComplete" FileSystemSettings-GenerateUniqueFileNamePrefix="True" runat="server" UploadMode="Advanced" Width="100%" ShowProgressPanel="True" UploadStorage="FileSystem" ShowUploadButton="True" AutoStartUpload="True" RightToLeft="True" ValidationSettings-GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" ValidationSettings-MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد رفعها في وقت واحد (والذي تم تعيينه على {1})." ValidationSettings-MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" ValidationSettings-NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به" Theme="MaterialCompact" ShowTextBox="False" ToolTip="رفع صورة الصنف">
                                                            <ValidationSettings AllowedFileExtensions=".jpg, .jpeg, .png" GeneralErrorText="فشل رفع الملف بسبب خطأ خارجي" MaxFileCountErrorText="تمت إزالة {0} ملف (ملفات) من التحديد لأنها تتجاوز حد الملفات المراد تحميلها في وقت واحد (والذي تم تعيينه على {1})." MaxFileSizeErrorText="يتجاوز حجم الملف الحد الأقصى للحجم المسموح به ، وهو {0} بايت" MultiSelectionErrorText="انتباه! {0} من الملفات غير صالحة ولن يتم رفعها. الأسباب المحتملة هي: أنها تتجاوز حجم الملف المسموح به ({1}) ، أو امتداداتها غير مسموح بها ، أو تحتوي أسماء ملفاتها على أحرف غير صالحة. تمت إزالة هذه الملفات من التحديد: {2}" NotAllowedFileExtensionErrorText="امتداد الملف هذا غير مسموح به">
                                                            </ValidationSettings>
                                                            <ClientSideEvents FilesUploadComplete="function(s, e) {updmsg(s,e);ASPxUploadItemPic.SetVisible = false;}"></ClientSideEvents>
                                                            <RemoveButton Text="حذف" Image-Url="~/Img/Icon/delete.svg" Image-ToolTip="حذف" Image-Width="20" Image-Height="20" Image-AlternateText="حذف">
                                                                <Image AlternateText="حذف" Height="20px" ToolTip="حذف" Url="~/Img/Icon/delete.svg" Width="20px">
                                                                </Image>
                                                            </RemoveButton>
                                                            <UploadButton Text="رفع الصورة" Image-Url="~/Img/Icon/import.svg" Image-ToolTip="رفع الصورة" Image-Height="20" Image-Width="20" Image-AlternateText="رفع الصورة">
                                                                <Image AlternateText="رفع الصورة" Height="20px" ToolTip="رفع الصورة" Url="~/Img/Icon/import.svg" Width="20px">
                                                                </Image>
                                                            </UploadButton>
                                                            <CancelButton Text="إلغاء" Image-Url="~/Img/Icon/cancel.svg" Image-ToolTip="إلغاء" Image-Width="20" Image-Height="20" Image-AlternateText="إلغاء">
                                                                <Image AlternateText="إلغاء" Height="20px" ToolTip="إلغاء" Url="~/Img/Icon/cancel.svg" Width="20px">
                                                                </Image>
                                                            </CancelButton>
                                                            <AdvancedModeSettings DropZoneText="قم برفع الصور أو سحبها و إفلاتها هنا"></AdvancedModeSettings>
                                                            <FileSystemSettings UploadFolder="~\Img\Item" />
                                                        </dx:ASPxUploadControl>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxImage ID="img_itempic" ClientInstanceName="img_itempic" runat="server" ShowLoadingImage="true" Width="150px" Height="150px">
                                                        </dx:ASPxImage>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <asp:ValidationSummary ID="ValidationSummary" ClientIDMode="Static" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="A" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                            </dx:ASPxFormLayout>
                        </asp:Panel>
                        <asp:HiddenField ID="hf_itemid" ClientIDMode="Static" runat="server" Value="0" />
                        <asp:HiddenField ID="hf_imgpath" ClientIDMode="Static" runat="server" Value="0" />
                    </div>
                </div>
                <div class="accordion__item">
                    <div class="accordion__item__header">
                        البيانات الإضافية للصنف
                    </div>
                    <div class="accordion__item__content">
                        <dx:ASPxFormLayout runat="server" AlignItemCaptions="true" AlignItemCaptionsInAllGroups="true" SettingsItemCaptions-HorizontalAlign="Left" ID="ASPxFormLayout1" CssClass="formLayout" RightToLeft="True">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                            <Items>
                                <dx:LayoutGroup ColCount="4" GroupBoxDecoration="None">
                                    <Items>
                                        <dx:LayoutItem Caption="بيان إضافي 1 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_itemfield1" AutoCompleteType="Disabled" ClientInstanceName="txt_itemfield1" runat="server" Theme="MaterialCompact" Font-Bold="True">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="بيان إضافي 2 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxTextBox ID="txt_itemfield2" AutoCompleteType="Disabled" ClientInstanceName="txt_itemfield2" runat="server" Theme="MaterialCompact" Font-Bold="True">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="تصنيف 1 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_itemcat1" ClientInstanceName="cmb_itemcat1" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True" ClearButton-DisplayMode="Always">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                    <Items>
                                        <dx:LayoutItem Caption="تصنيف 2 ">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer>
                                                    <dx:ASPxComboBox ID="cmb_itemcat2" ClientInstanceName="cmb_itemcat2" runat="server" Theme="MaterialCompact" Font-Bold="True" RightToLeft="True" ClearButton-DisplayMode="Always">
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                    </div>
                </div>
                <div class="accordion__item">
                    <div class="accordion__item__header">
                        وحدات الصنف
                    </div>
                    <div class="accordion__item__content">
                        <dx:ASPxGridView ID="gvitemunit" ClientIDMode="Static" OnDataBinding="gvitemunit_DataBinding" OnRowInserting="gvitemunit_RowInserting" OnRowDeleting="gvitemunit_RowDeleting" OnRowUpdating="gvitemunit_RowUpdating" ClientInstanceName="gvitemunit" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image" KeyFieldName="itemunitid" OnInitNewRow="gvitemunit_InitNewRow" OnCustomCallback="gvitemunit_CustomCallback">
                            <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                            <SettingsPager AlwaysShowPager="True" PageSize="20">
                                <Summary EmptyText="لا توجد بيانات لترقيم الصفحات" Position="Inside" Text="صفحة {0} من {1} ({2} عنصر)" />
                            </SettingsPager>
                            <SettingsEditing Mode="PopupEditForm">
                            </SettingsEditing>
                            <Settings ShowFilterRowMenu="True" ShowFooter="True" ShowFilterRowMenuLikeItem="True" ShowGroupedColumns="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                            <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                            <SettingsCommandButton RenderMode="Image">
                                <CustomizationDialogCloseButton>
                                    <Image ToolTip="إغلاق" Url="~/Img/Icon/close.svg" Width="20" Height="20" AlternateText="إغلاق" />
                                </CustomizationDialogCloseButton>
                                <NewButton RenderMode="Image">
                                    <Image ToolTip="جديد" Url="~/Img/Icon/add-new.svg" Width="20" Height="20" AlternateText="جديد" />
                                </NewButton>
                                <EditButton RenderMode="Image">
                                    <Image ToolTip="تعديل" Url="~/Img/Icon/edit.svg" Width="20" Height="20" AlternateText="تعديل" />
                                </EditButton>
                                <UpdateButton RenderMode="Image">
                                    <Image ToolTip="حفظ" Url="~/Img/Icon/save.svg" Width="20" Height="20" AlternateText="حفظ" />
                                </UpdateButton>
                                <CancelButton RenderMode="Image">
                                    <Image ToolTip="إلغاء" Url="~/Img/Icon/cancel.svg" Width="20" Height="20" AlternateText="إلغاء" />
                                </CancelButton>
                                <DeleteButton RenderMode="Image">
                                    <Image ToolTip="حذف" Url="~/Img/Icon/delete.svg" Width="20" Height="20" AlternateText="حذف" />
                                </DeleteButton>
                                <ClearFilterButton RenderMode="Image">
                                    <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                </ClearFilterButton>
                                <SearchPanelClearButton RenderMode="Image">
                                    <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                </SearchPanelClearButton>
                            </SettingsCommandButton>
                            <SettingsPopup>
                                <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                    <SettingsAdaptivity VerticalAlign="WindowCenter" />
                                </EditForm>
                                <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                            </SettingsPopup>
                            <SettingsSearchPanel ShowClearButton="True" />
                            <SettingsExport PaperKind="A4" FileName="customers" PaperName="customers" RightToLeft="True">
                                <PageHeader>
                                    <Font Bold="True" Size="Medium"></Font>
                                </PageHeader>
                            </SettingsExport>
                            <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                            <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                            <StylesPopup>
                                <HeaderFilter>
                                    <Footer HorizontalAlign="Center">
                                    </Footer>
                                </HeaderFilter>
                            </StylesPopup>
                            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="2"></SettingsAdaptivity>
                            <SettingsBehavior AllowEllipsisInText="false" />
                            <EditFormLayoutProperties>
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                            </EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0" ShowNewButtonInHeader="True" Width="20%" ShowEditButton="True"></dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="itemunitid" ReadOnly="True" VisibleIndex="1" Caption="كود" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="2" Visible="False"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="barcode1" VisibleIndex="5" Width="15%" Caption="باركود">
                                    <PropertiesTextEdit MaxLength="50">
                                        <ValidationSettings Display="Dynamic">
                                            <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="barcode2" VisibleIndex="6" Caption="باركود 2" Width="15%"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="factor" VisibleIndex="14" Width="10%" Caption="معامل التحويل">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="fact" MaxLength="50">
                                        <ClientSideEvents KeyUp="function(s, e) {factsprice(s, e);calcVat(s,e);}" KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="sprice" Width="10%" VisibleIndex="20" Caption="سعر البيع">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="sprice" MaxLength="12">
                                        <ClientSideEvents KeyUp="function(s, e) {calcVat(s,e);}" KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="vat" Width="10%" VisibleIndex="21" Caption="الضريبة">
                                    <PropertiesTextEdit ClientSideEvents-ValueChanged="function(s,e){calcVat(s,e);}" ClientInstanceName="vatvalue" MaxLength="5">
                                        <ClientSideEvents KeyUp="function(s, e) {calcVat(s,e);}" KeyPress="function(s, e) {preventwrite(s, e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic">
                                            <RegularExpression ErrorText="قيمة غير صحيحة" ValidationExpression="^\d{0,3}(\.\d{1,2})?$"></RegularExpression>
                                            <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="vprice" Width="10%" VisibleIndex="22" Caption="السعر شامل">
                                    <PropertiesTextEdit ClientInstanceName="vatprice" MaxLength="12">
                                        <ClientSideEvents KeyPress="function(s, e) {preventwrite(s, e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField IsRequired="True" ErrorText="يجب ملئ الحقل"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="fprice" Width="10%" VisibleIndex="23" Caption="سعر الفاتورة">
                                    <PropertiesTextEdit ClientInstanceName="fpricevalue" MaxLength="12">
                                        <ClientSideEvents KeyPress="function(s, e) {decimale3num(s,e);}"></ClientSideEvents>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True">
                                            <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="unitid" Width="10%" Caption="الوحدة" VisibleIndex="12">
                                    <PropertiesComboBox>
                                        <ValidationSettings Display="Dynamic" SetFocusOnError="True" ErrorDisplayMode="ImageWithTooltip">
                                            <RequiredField ErrorText="يجب ملئ الحقل" IsRequired="True" />
                                        </ValidationSettings>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <SettingsPopup>
                                <EditForm Width="730">
                                    <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="1000" />
                                </EditForm>
                            </SettingsPopup>
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="unitid" ShowInColumn="unitid" ShowInGroupFooterColumn="unitid" SummaryType="Count" DisplayFormat="العدد : {0}" />
                            </TotalSummary>
                            <GroupSummary>
                                <dx:ASPxSummaryItem FieldName="unitid" ShowInColumn="unitid" ShowInGroupFooterColumn="unitid" SummaryType="Count" DisplayFormat="العدد : {0}" />
                            </GroupSummary>
                            <Styles>
                                <Footer Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle">
                                </Footer>
                                <GroupFooter HorizontalAlign="Right" VerticalAlign="Middle"></GroupFooter>
                                <GroupPanel HorizontalAlign="Right">
                                </GroupPanel>
                                <PagerBottomPanel HorizontalAlign="Center">
                                </PagerBottomPanel>
                            </Styles>
                        </dx:ASPxGridView>
                    </div>
                </div>
                <div class="accordion__item">
                    <div class="accordion__item__header">
                        فروع الصنف
                    </div>
                    <div class="accordion__item__content">
                        <asp:Panel ID="Panel2" runat="server" BorderStyle="None" Font-Bold="True" ForeColor="Black" Direction="RightToLeft">
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout2" CssClass="formLayout" RightToLeft="True">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                                <Items>
                                    <dx:LayoutGroup ColCount="3" GroupBoxDecoration="box" Caption="" UseDefaultPaddings="false" CellStyle-Font-Bold="true">
                                        <CellStyle Font-Bold="True">
                                        </CellStyle>
                                        <Items>
                                            <dx:LayoutItem Caption="الفرع">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTokenBox ID="tkb_branchid" ClientInstanceName="tkb_branchid" runat="server" ItemValueType="System.String" TextField="citemname" ValueField="citemid" Width="100%" AllowCustomTokens="false" AnimationType="Fade" Cursor="pointer" NullText="برجاء إختار الفروع" ShowShadow="true" DropDownRows="5" OnCallback="tkb_branchid_Callback"></dx:ASPxTokenBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxButton UseSubmitBehavior="false" ID="btn_addbranch" OnClick="btn_addbranch_Click" runat="server" Height="20px" Width="20px" ToolTip="حفظ" Image-Url="~/Img/Icon/save.svg" AutoPostBack="true" Image-Width="20px" Image-Height="20px" RenderMode="Secondary" ClientSideEvents-Click="function(s, e) { validate_branch(s,e) }"></dx:ASPxButton>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <dx:LayoutItem Caption="">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" ValidationGroup="B" />
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                        </Items>
                                    </dx:LayoutGroup>
                                </Items>
                                <SettingsItemCaptions Location="Top" />
                            </dx:ASPxFormLayout>
                        </asp:Panel>
                        <table class="w-100" style="width: 100%">
                            <tr>
                                <td style="text-align: center"></td>
                                <td>
                                    <dx:ASPxGridView ID="gv_itemwh" OnCustomCallback="gv_itemwh_CustomCallback" OnDataBinding="gv_itemwh_DataBinding" KeyFieldName="itemwhid" ClientInstanceName="gv_itemwh" runat="server" AutoGenerateColumns="False" RightToLeft="True" Width="100%" EnableTheming="True" Theme="MaterialCompact" ButtonRenderMode="Image">
                                        <ClientSideEvents EndCallback="function(s,e){GetError(s,e)}" />
                                        <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" ShowPreview="True" ShowTitlePanel="True" UseFixedTableLayout="True" />
                                        <SettingsBehavior AllowSelectByRowClick="True" EnableCustomizationWindow="True" EnableRowHotTrack="True" ConfirmDelete="True" />
                                        <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" AllowHideDataCellsByColumnMinWidth="true" AdaptiveDetailColumnCount="4"></SettingsAdaptivity>
                                        <SettingsEditing BatchEditSettings-EditMode="Cell" UseFormLayout="False"></SettingsEditing>
                                        <SettingsBehavior AllowEllipsisInText="true" AllowGroup="False" />
                                        <SettingsCommandButton RenderMode="Image">
                                            <CustomizationDialogCloseButton>
                                                <Image ToolTip="إغلاق" Url="~/Img/Icon/close.svg" Width="20" Height="20" AlternateText="إغلاق" />
                                            </CustomizationDialogCloseButton>
                                            <NewButton RenderMode="Image">
                                                <Image ToolTip="جديد" Url="~/Img/Icon/add-new.svg" Width="20" Height="20" AlternateText="جديد" />
                                            </NewButton>
                                            <EditButton RenderMode="Image">
                                                <Image ToolTip="تعديل" Url="~/Img/Icon/edit.svg" Width="20" Height="20" AlternateText="تعديل" />
                                            </EditButton>
                                            <UpdateButton RenderMode="Image">
                                                <Image ToolTip="حفظ" Url="~/Img/Icon/save.svg" Width="20" Height="20" AlternateText="حفظ" />
                                            </UpdateButton>
                                            <CancelButton RenderMode="Image">
                                                <Image ToolTip="إلغاء" Url="~/Img/Icon/cancel.svg" Width="20" Height="20" AlternateText="إلغاء" />
                                            </CancelButton>
                                            <DeleteButton RenderMode="Image">
                                                <Image ToolTip="حذف" Url="~/Img/Icon/delete.svg" Width="20" Height="20" AlternateText="حذف" />
                                            </DeleteButton>
                                            <ClearFilterButton RenderMode="Image">
                                                <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                            </ClearFilterButton>
                                            <SearchPanelClearButton RenderMode="Image">
                                                <Image ToolTip="تفريغ" Url="~/Img/Icon/eraser-clear.svg" Width="20" Height="20" AlternateText="تفريغ" />
                                            </SearchPanelClearButton>
                                        </SettingsCommandButton>
                                        <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                                        <SettingsPopup>
                                            <EditForm AllowResize="True" HorizontalAlign="WindowCenter" Modal="True" PopupAnimationType="Auto" ShowShadow="True" VerticalAlign="WindowCenter">
                                                <SettingsAdaptivity VerticalAlign="WindowCenter" />
                                            </EditForm>
                                            <CustomizationWindow HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </SettingsPopup>
                                        <SettingsFilterControl ShowAllDataSourceColumns="True">
                                        </SettingsFilterControl>
                                        <SettingsExport PaperKind="A4" FileName="permissions" PaperName="permissions" RightToLeft="True">
                                            <PageHeader>
                                                <Font Bold="True" Size="Medium"></Font>
                                            </PageHeader>
                                        </SettingsExport>
                                        <SettingsLoadingPanel ImagePosition="Right" Text="جاري تحميل البيانات&amp;hellip;" />
                                        <SettingsText CommandCancel=" " CommandDelete=" " CommandEdit=" " CommandNew=" " CommandSelect="تحديد" CommandUpdate=" " ConfirmDelete="تأكيد الحذف" EmptyDataRow="لا توجد بيانات لعرضها" PopupEditFormCaption="شاشة الإضافة و التحديث" CommandClearSearchPanelFilter=" " GroupPanel="اسحب العمود هنا للتجميع حسب هذا العمود" SearchPanelEditorNullText="أدخل النص للبحث..." CommandClearFilter=" " FilterBarClear="حذف التصفية" FilterBarCreateFilter="إنشاء تصفية" FilterControlPopupCaption="منشئ التصفية" HeaderFilterCancelButton="إلغاء" />
                                        <EditFormLayoutProperties>
                                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="600" />
                                        </EditFormLayoutProperties>
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="itemwhid" ReadOnly="True" VisibleIndex="0" Visible="false">
                                                <EditFormSettings Visible="False"></EditFormSettings>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="itemid" VisibleIndex="1" Caption=" كود الصنف" ReadOnly="True" Visible="false">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataComboBoxColumn FieldName="branchid" Caption="الفرع" VisibleIndex="3">
                                                <CellStyle HorizontalAlign="Center"></CellStyle>
                                            </dx:GridViewDataComboBoxColumn>
                                            <dx:GridViewDataTextColumn FieldName="qty" VisibleIndex="4" Caption="الكميه"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="whminqty" VisibleIndex="5" Caption="اقل كميه"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="whmaxqty" VisibleIndex="6" Caption="اكثر كميه"></dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="whplase" VisibleIndex="7" Caption="مكان التخزين"></dx:GridViewDataTextColumn>
                                        </Columns>
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="branchid" ShowInColumn="branchid" ShowInGroupFooterColumn="branchid" SummaryType="Count" DisplayFormat="العدد : {0}" />
                                            <dx:ASPxSummaryItem FieldName="qty" ShowInColumn="qty" ShowInGroupFooterColumn="qty" SummaryType="Sum" DisplayFormat="{0}"></dx:ASPxSummaryItem>
                                        </TotalSummary>
                                        <Styles>
                                            <Footer Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle">
                                            </Footer>
                                            <GroupFooter Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Middle">
                                            </GroupFooter>
                                            <GroupPanel HorizontalAlign="Right"></GroupPanel>
                                            <PagerBottomPanel HorizontalAlign="Center"></PagerBottomPanel>
                                        </Styles>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                </div>
            </div>
                                                 <dx:ASPxTextBox ID="txt_sinvno"   runat="server" ClientInstanceName="txtinvno" Theme="MaterialCompact" Font-Bold="True"  Text="تلقائى">
                                               <%-- <ClientSideEvents KeyDown="function(s,e){preventwrite(s,e)}"  />--%>
                                              <ClientSideEvents  />
                                            </dx:ASPxTextBox>
                                        <dx:ASPxButton UseSubmitBehavior="false" ID="ASPxButton21" runat="server" AutoPostBack="False" RenderMode="Secondary" Theme="MaterialCompact" ToolTip="ادخال سريع" Height="20px" Width="20px" >
                                                          <Image Height="20px" Url="~/img/icon/bookmark.svg" Width="20px"></Image>
                                                    <ClientSideEvents Click="function(s, e) {
                                       loadinv()}" />
                                                    </dx:ASPxButton>
                                             <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup"  ShowMaximizeButton="true" Width="1200px" Height="700px" AllowResize="true" HeaderText="" 
        CloseAction="CloseButton" AllowDragging="true" Modal="true" PopupHorizontalAlign="Center" PopupVerticalAlign="Middle" CssClass="popupstyle">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
                                    </form>
                                </div>

                        </div>
    </main>
    </div>
           <script src="../Scripts/App/stock/Item_Manage.js"></script>
    <script src="../Scripts/App/Public/Messages.js"></script>
    <%--<script src="../Scripts/accordion.js"></script>--%>
    <script src="../Scripts/sweetalert2.js"></script>
    <script src="../vansalesthemsfile/js/vendor/bootstrap.bundle.min.js"></script>
   <script src="../vansalesthemsfile/js/vendor/perfect-scrollbar.min.js"></script>
    <script src="../vansalesthemsfile/js/vendor/owl.carousel.min.js"></script>
    <script src="../vansalesthemsfile/js/dore.script.js"></script>
    <script src="../vansalesthemsfile/js/scripts.js"></script>
 <script src="../VanSalesThemsFile/js/Custome.js"></script>
    <script src="Scripts/App/sales/inv.js"></script>
         
                                                    
                                        

</body>

</html>
<script>
    $(function () {
        if ($(".accordion__item__header").length > 0) {
            let active = "active";
            $(".accordion__item__header").click(function () {
                $(this).toggleClass(active);
                $(this).next("div").slideToggle(200);
            });
        }
    })
</script>