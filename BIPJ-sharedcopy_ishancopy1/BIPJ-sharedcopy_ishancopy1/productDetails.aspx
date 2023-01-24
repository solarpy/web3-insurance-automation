<%@ Page Title="" Language="C#" MasterPageFile="~/loggedinnavbar.Master" AutoEventWireup="true" CodeBehind="productDetails.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.productDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<!DOCTYPE html>
<html>
    <head>
  <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport">

  <title>Dashboard - NiceAdmin Bootstrap Template</title>
  <meta content="" name="description">
  <meta content="" name="keywords">

  <!-- Favicons -->
  <link href="assets/img/favicon.png" rel="icon">
  <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">

  <!-- Google Fonts -->
  <link href="https://fonts.gstatic.com" rel="preconnect">
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet">

  <!-- Vendor CSS Files --> 
  <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
  <link href="assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet">
  <link href="assets/vendor/quill/quill.snow.css" rel="stylesheet">
  <link href="assets/vendor/quill/quill.bubble.css" rel="stylesheet">
  <link href="assets/vendor/remixicon/remixicon.css" rel="stylesheet">
  <link href="assets/vendor/simple-datatables/style.css" rel="stylesheet">

  <!-- Template Main CSS File -->
  <link href="assets/css/style.css" rel="stylesheet">

  <!-- =======================================================
  * Template Name: NiceAdmin - v2.2.2
  * Template URL: https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/
  * Author: BootstrapMade.com
  * License: https://bootstrapmade.com/license/
  ======================================================== -->
</head>
     
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
        <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <style type="text/css">
        .header {
            width: 100%;
            height: 85px;
        }
        .footer {
            width: 100%;
            height: 85px;
        }
        .icon {
            width: 1030px;
        }
        .auto-style3 {
            height: 29px;
        }
        .auto-style4 {
            height: 29px;
            width: 418px;
        }
        .auto-style5 {
            width: 418px;
        }
        
        </style>
        <div class="px-3 py-2 text-black">
            <style type="text/css">
                .auto-style6 {
                    height: 29px;
                    margin-left: 355px;
                }
            </style>
      <div class="container">
        <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
          <a href="index.aspx" class="d-flex align-items-center my-2 my-lg-0 me-lg-auto text-black text-decoration-none">
            <asp:Image ID="logo" runat="server" Height="85px" Width="135px" ImageUrl="~/Images/demiswap1.png" ></asp:Image>
          </a>

          <ul class="nav col-12 col-lg-auto my-2 justify-content-center my-md-0 text-small">
            <li>
              <a href="debitcard.aspx" class="nav-link text-black">
                Home
              </a>
            </li>
            <li>
              <a href="cards.aspx" class="nav-link text-black">
                My Cards
              </a>
            </li>
            <li>
              <a href="products.aspx" class="nav-link text-black">
                Products
              </a>
            </li>
          </ul>
        </div>
      </div>
    </div>
</head>

<body>
    <div class="page">
        
        <div class="main">
                    
            <table class="auto-style2">
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table class="auto-style2">
        <tr>
            <td rowspan="4">
                <asp:Image ID="img_Product" runat="server" Height="274px" Width="491px" />
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ProdID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ProdName" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ProdDesc" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_Price" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    <p> 
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back" />
    </p>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/midnight.png" Width="22px" /><asp:Image ID="Image8" runat="server" ImageUrl="~/Images/crypto.png" Width="22px" />  Pay With:       
        <br />
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" CssClass="auto-style6" Width="220px">
            <asp:ListItem>DemiSwap $137</asp:ListItem>
            <asp:ListItem>Midnight Blue Card $24</asp:ListItem>
        </asp:RadioButtonList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Cashback: $0.1035 (3%)
        </div>
        <asp:Button ID="Button9384" runat="server" Text="Purchase" OnClick="Button9384_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="purchase" runat="server" Text="Purchase" OnClick="purchase_Click" />
        <div class="clear">
            <div class="row">
                <div class="col-sm-10"></div>
                <div class="col-sm-2">
                    <asp:ImageButton ID="chat" runat="server" Height="80px" Width="80px" ImageUrl="~/Images/chat (1).png" />
                </div>
            </div>
        </div>
    </div>

   

    <div class="container">
  <footer class="d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top">
    <div class="col-md-4 d-flex align-items-center">
      <a href="Home.aspx" class="mb-3 me-2 mb-md-0 text-muted text-decoration-none lh-1">
        <asp:Image ID="logo1" runat="server" Height="85px" Width="135px" ImageUrl="~/Images/demiswap.png"></asp:Image>
      </a>
      <span class="text-muted">© 2022 DemiSwap Company, Inc</span>
    </div>

    <a class="nav col-md-4 justify-content-end list-unstyled d-flex">
      <b  style="font-weight:normal;">
        <p dir="ltr" style="line-height:1.2;margin-top:0pt;margin-bottom:0pt;">
            DemiSwap<span style="font-size:10pt;font-family:Georgia;color:#000000;background-color:transparent;font-weight:400;font-style:normal;font-variant:normal;text-decoration:none;vertical-align:baseline;white-space:pre;white-space:pre-wrap;">@gmail.com</span></p>
        <p dir="ltr" style="line-height:1.2;margin-top:0pt;margin-bottom:0pt;">
            <span style="font-size:10pt;font-family:Georgia;color:#000000;background-color:transparent;font-weight:400;font-style:normal;font-variant:normal;text-decoration:none;vertical-align:baseline;white-space:pre;white-space:pre-wrap;">61234567</span></p>
        <p dir="ltr" style="line-height:1.2;margin-top:0pt;margin-bottom:0pt;">
            <span style="font-size:10pt;font-family:Georgia;color:#000000;background-color:transparent;font-weight:400;font-style:normal;font-variant:normal;text-decoration:none;vertical-align:baseline;white-space:pre;white-space:pre-wrap;">ABC Avenue 1, Singapore 123386</span></p>
        </b>
    </a>
  </footer>
</div>
   
</form>
</body>
</html>

</asp:Content>
