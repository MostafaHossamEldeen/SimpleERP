<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_cus.aspx.cs" Inherits="VanSales.Customers.add_cus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <script src="../Scripts/bootstrap.min.js"></script>
    <style>
        .custname{
            width: 500px;
            position: absolute;
           
        }
        .custinfo{
            width: 500px;
            position: absolute;
            left: 125px;
            margin-top: 80px;
        }
        .custgroup{
            margin-top: 30px;
            padding-right: 5px;
            background-color: white;
        }

    </style>

     
</head>
<body>
   
    <form id="form1" runat="server">
                <div class="custgroup">

                   <%-- <h6>كود العميل</h6>
                   
                    <input  type="text" id="txt_custcode"/>--%>
                <div class="custname">
                    <div style="float:right;">
                        <h6>اسم العميل</h6>
                        <input  type="text" id="txt_cusname"  />
                    </div>
                    <div  style="float:left;">
                        <h6>عنوان العميل</h6>
                        <input  type="text" id="txt_cusadd"  />
                    </div>
                </div>
                <div class="custinfo">
                     <div  style="float:right;">
                        <h6>تليفون العميل</h6>
                        <input  type="text" id="txt_cusmob"  />
                    </div>
                    <div  style="float:left;">
                        <h6>الرقم الضريبى</h6>
                        <input  type="text" id="txt_cusvat"  />
                    </div>
                   
                </div>
                    </div>
           <%-- <dx:ASPxFormLayout runat="server" ID="formLayout55" CssClass="formLayout" RightToLeft="True"  >
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="900" />
                    <Items>
              <dx:LayoutGroup ColCount="2" GroupBoxDecoration="box" Caption="بيانات العميل" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                            <Paddings PaddingTop="10px" />
                            <Items>
                                <dx:LayoutItem Caption="كودالعميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>

                                            <dx:ASPxTextBox ID="txt_custid5" runat="server" Theme="MaterialCompact" ReadOnly="false"  ClientInstanceName="txt_cusid5" AutoPostBack="false" >
 
                                            </dx:ASPxTextBox>
                                      </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>

                                </dx:LayoutItem>

                                <dx:LayoutItem Caption="اسم العميل">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <dx:ASPxTextBox ID="txt_custname" ClientInstanceName="txt_custname" runat="server" Theme="MaterialCompact"></dx:ASPxTextBox>
                                         
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
                                
                            </Items>
                        </dx:LayoutGroup>
                         </Items>
                </dx:ASPxFormLayout>--%>

  
    </form>
   
</body>
</html>
