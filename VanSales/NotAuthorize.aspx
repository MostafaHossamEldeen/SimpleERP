<%@ Page Title="خطأ 401: عفوا لا يوجد لديك صلاحية" Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="NotAuthorize.aspx.cs" Inherits="VanSales.NotAuthorize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	  <div class="page bg-gradient-primary">
        <div class="page-main">
            <div id="notfound">
                <div class="notfound">
                    <h1><span class=""><i class="far fa-frown"></i></span>ops!</h1>
                    <h2>خطأ 401: عفوا لا يوجد لديك صلاحية دخول لهذة الصفحة</h2>
                    <a href="login/login.aspx" class="btn opsbtn mt-4">تسجيل دخول</a>
                </div>
            </div>
        </div>
    </div>
    <link href="VanSalesThemsFile/font/oops.font.style/font-awesome/css/all.min.css" rel="stylesheet" />
	</asp:Content>