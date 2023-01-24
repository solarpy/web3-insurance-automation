<%@ Page Title="" Language="C#" MasterPageFile="~/loggedinnavbar.Master" AutoEventWireup="true" CodeBehind="CheckoutForm3.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.CheckoutForm3" %>
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
            width: 65%;
        }
        .auto-style8 {
            height: 77px;
        }
        .auto-style9 {
            width: 128px;
        }
        .auto-style10 {
            height: 77px;
            width: 161px;
        }
        .auto-style11 {
            width: 218px;
        }
        .auto-style12 {
            height: 77px;
            width: 218px;
        }
        .auto-style13 {
            height: 33px;
        }
        .auto-style14 {
            width: 218px;
            height: 33px;
        }
        .auto-style15 {
            width: 161px;
            height: 33px;
        }
        .auto-style16 {
            height: 45px;
        }
        .auto-style17 {
            width: 218px;
            height: 45px;
        }
        .auto-style18 {
            width: 161px;
            height: 45px;
        }
        .auto-style19 {
        height: 126px;
    }
    .auto-style20 {
        height: 126px;
        width: 218px;
    }
    .auto-style21 {
        height: 126px;
        width: 161px;
    }
        .auto-style22 {
            width: 161px;
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
           <table class="auto-style3">
        <tr>
            <td>Shipping to</td>
            <td class="auto-style11">
                <asp:dropdownlist ID="ddl_ShippingTo" runat="server">
                    <asp:ListItem>Singapore </asp:ListItem>
                    <asp:ListItem>Overseas</asp:ListItem>
                </asp:dropdownlist>
            </td>
            <td class="auto-style22">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style16">Shipping To (state or province)</td>
            <td class="auto-style17">
                <asp:TextBox ID="tb_ShippingToState" runat="server" CausesValidation="True"></asp:TextBox>
            </td>
            <td class="auto-style18">
                <asp:RequiredFieldValidator ID="rfv_ShippingTo" runat="server" ControlToValidate="tb_ShippingToState" ErrorMessage="Please enter a valid Shipping State." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_ShippingToState" runat="server" ErrorMessage=" Only Alphabets are allowed!" ControlToValidate="tb_ShippingToState" ForeColor="Red" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Full Name</td>
            <td class="auto-style20">
                <asp:TextBox ID="tb_FullName" runat="server" CausesValidation="True"></asp:TextBox>
            </td>
            <td class="auto-style21">
                <asp:RequiredFieldValidator ID="rfv_FullName" runat="server" ControlToValidate="tb_FullName" ErrorMessage="Please enter your full name." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_FullName" runat="server" ErrorMessage=" Only Alphabets are allowed!" ControlToValidate="tb_FullName" ForeColor="Red" Operator="DataTypeCheck"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">Delivery Address</td>
            <td class="auto-style14">
                <asp:TextBox ID="tb_DeliveryAddress" runat="server" CausesValidation="True"></asp:TextBox>
            </td>
            <td class="auto-style15">
                <asp:RequiredFieldValidator ID="rfv_DeliveryAddress" runat="server" ErrorMessage="Please enter your delivery address" ForeColor="Red" ControlToValidate="tb_DeliveryAddress"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Postal Code</td>
            <td class="auto-style11">
                <asp:TextBox ID="tb_PostalCode" runat="server" CausesValidation="True"></asp:TextBox>
            </td>
            <td class="auto-style22">
                <asp:RequiredFieldValidator ID="rfv_PostalCode" runat="server" ErrorMessage="Please enter a valid Postal Code." ForeColor="Red" ControlToValidate="tb_PostalCode"></asp:RequiredFieldValidator>
&nbsp;<asp:CompareValidator ID="cv_PostalCode" runat="server" ControlToValidate="tb_PostalCode" ErrorMessage="Only Numeric Interger is allowed!" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Payment Method</td>
            <td class="auto-style11">
                <asp:RadioButtonList ID="rbl_PaymentMethod" runat="server">
                    <asp:ListItem>Visa</asp:ListItem>
                    <asp:ListItem>MasterCard</asp:ListItem>
                    <asp:ListItem>Paypal</asp:ListItem>
                </asp:RadioButtonList>
                &nbsp;<br />             
        <div id="smart-button-container">
      <div style="text-align: center;">
        <div id="paypal-button-container"></div>
      </div>
    </div>
    <meta name="viewport" content="width=device-width, initial-scale=1"> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 

  <div id="smart-button-container">
      <div style="text-align: center;">
        <div id="paypal-button-container"></div>
      </div>
    </div>
  <script src="https://www.paypal.com/sdk/js?client-id=AcXGRO6fpwEsnY8SETbnK1pY3TRgXHy-ShiowuQMzqIaI-XTVNL9Kd81X2WC0no2alZUFOru2yOLJKM1&enable-funding=venmo&currency=SGD" data-sdk-integration-source="button-factory"></script>
  <script>
      function initPayPalButton() {
          paypal.Buttons({
              style: {
                  shape: 'rect',
                  color: 'gold',
                  layout: 'vertical',
                  label: 'paypal',

              },

              createOrder: function (data, actions) {
                  return actions.order.create({
                      purchase_units: [{ "description": "Midnight Blue Debit Card", "amount": { "currency_code": "SGD", "value": 32.0, "breakdown": { "item_total": { "currency_code": "SGD", "value": 32 }, "shipping": { "currency_code": "SGD", "value": 0 }, "tax_total": { "currency_code": "SGD", "value": 0 } } } }]
                  });
              },

              onApprove: function (data, actions) {
                  return actions.order.capture().then(function (orderData) {

                      // Full available details
                      console.log('Capture result', orderData, JSON.stringify(orderData, null, 2));

                      // Show a success message within this page, e.g.
                      const element = document.getElementById('paypal-button-container');
                      element.innerHTML = '';
                      element.innerHTML = '<h3>Thank you for your payment!</h3>';

                      // Or go to another URL:  actions.redirect('thank_you.html');

                  });
              },

              onError: function (err) {
                  console.log(err);
              }
          }).render('#paypal-button-container');
      }
      initPayPalButton();
  </script>
                <br />
                <br />
                <br />
               

            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="rfv_PayementMethod" runat="server" ControlToValidate="rbl_PaymentMethod" ErrorMessage="Please enter a valid Payment Method" ForeColor="Red"></asp:RequiredFieldValidator>  
            </td>
        </tr>
        <tr>
            <td class="auto-style8"> Confirm Order Summary</td>
            
            <td class="auto-style12">
   
                <asp:RadioButtonList ID="rbl_OrderSummary" runat="server">
                    <asp:ListItem>$56.00</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            
            <td class="auto-style10"><asp:RequiredFieldValidator ID="rfv_OrderSummary" runat="server" ControlToValidate="rbl_OrderSummary" ErrorMessage="Please confirm your Order Summary!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td class="auto-style11">
                <br />
            &nbsp;
                <asp:Button ID="btn_ConfirmPurchase" OnClick="btn_ConfirmPurchase_Click" runat="server" Text="Confirm Purchase" Width="182px" /> &nbsp; &nbsp; 
                &nbsp; &nbsp;&nbsp;&nbsp;
                <br />
                <asp:ValidationSummary ID="vs_Checkout" runat="server" ShowMessageBox="True" />
            </td>
            <td class="auto-style22">
                &nbsp;</td>
        </tr>
    </table>
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
