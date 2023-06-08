<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="VanSales.login.login" %>

<!DOCTYPE html>
<html lang="ar">
<head>
    <title>تسجيل الدخول</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
  
    <!--===============================================================================================-->
</head>
<body>
    <div class="panel">
        <%--<img src="images/back.jpg" alt="...." class="imgback">--%>
        <%--<div id="particles-js">
            <canvas class="particles-js-canvas-el" width="950" height="780" style="width: 100%; height: 100%;"></canvas>
        </div>--%>
        <div class="container-login100 " style="background-image: url('images/back.jpg'); background-repeat: no-repeat;">
            <div class="wrap-login100">
                <form class="login100-form validate-form" runat="server">
                    <span class="login100-form-logo">
                        <img src="./images/logo512.png" class="img">
                    </span>
                    <span class="login100-form-title p-b-34 p-t-27">تسجيل الدخول
                    </span>
                    <div class="wrap-input100 validate-input" data-validate="يجب ملئ هذا الحقل">
                        <asp:TextBox class="input100" runat="server" ID="UserName" name="username" placeholder="إسم المستخدم" />
                        <span class="focus-input100" data-placeholder="&#xf207;"></span>
                    </div>
                    <div class="wrap-input100 validate-input" data-validate="يجب ملئ هذا الحقل">
                        <asp:TextBox class="input100" runat="server" ID="Password" name="pass" TextMode="Password" placeholder="كلمة المرور" />
                        <span class="focus-input100" data-placeholder="&#xf191;"></span>
                    </div>
                    <div class="contact100-form-checkbox">
                        <dx:ASPxCheckBox ID="ckbremmber" runat="server" Text="تذكر بيانات تسجيل الدخول" RightToLeft="True" Theme="MaterialCompact" Cursor="pointer"></dx:ASPxCheckBox>
                    </div>
                    <div class="StatusText">
                        <asp:Literal runat="server" ID="StatusText" />
                    </div>
                    <br />
                    <div class="container-login100-form-btn">
                        <asp:Button ID="btnlogin" class="login100-form-btn" runat="server" OnClick="Btnlogin_Click" Text="تسجيل الدخول" />
                    </div>
                    <div class="text-center-p-t-115">
                        <span class="txt1"></span>
                        <a class="txt2" href="#"></a>
                    </div>
                    <div class="text-center p-t-90">
                        <a class="txt1" href="#">نسيت كلمة المرور ؟
                        </a>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/daterangepicker/moment.min.js"></script>
    <script src="vendor/daterangepicker/daterangepicker.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/countdowntime/countdowntime.js"></script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>
    <!--===============================================================================================-->
    <!-- scripts move -->
   <%-- <script src="js/particles.js"></script>
    <script src="js/app.js"></script>--%>
    <!--===============================================================================================-->
    <!-- stats.js -->
    <script src="js/lib/stats.js"></script>
</body>
</html>
