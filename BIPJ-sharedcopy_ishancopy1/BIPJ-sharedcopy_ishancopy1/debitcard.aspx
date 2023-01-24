<%@ Page Title="" Language="C#" MasterPageFile="~/loggedinnavbar.Master" AutoEventWireup="true" CodeBehind="debitcard.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.debitcard" %>
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
<html>
    <title></title>
        <!-- CSS only -->
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
      </style>
        <div class="px-3 py-2 text-black">
            <style type="text/css">
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
          </ul>
        </div>
      </div>
    </div>
</head>

<body>
    <div class="page">
        
        <div class="main">
            
         
            <asp:GridView ID="gvCard" runat="server" AutoGenerateColumns="False" CssClass="auto-style1" Height="113px" OnSelectedIndexChanged="gvCard_SelectedIndexChanged" Width="799px">
                <Columns>
                    <asp:BoundField AccessibleHeaderText="Card Ref" DataField="Card_Id" HeaderText="Card Tier" />
                    <asp:BoundField AccessibleHeaderText="Card Name" DataField="Card_Name" HeaderText="Card Name" />
                    <asp:BoundField AccessibleHeaderText="Subscription Cost" DataField="Subscription_Cost" HeaderText="Subscription Cost" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
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
