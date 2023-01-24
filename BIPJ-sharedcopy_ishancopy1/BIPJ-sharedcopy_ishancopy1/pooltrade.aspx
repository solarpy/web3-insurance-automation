<%@ Page Title="" Language="C#" MasterPageFile="~/loggedinnavbar.Master" AutoEventWireup="true" CodeBehind="pooltrade.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.pooltrade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <body>
                <nav><ol class="breadcrumb"><li class="breadcrumb-item"><a href="index.aspx">Home</a></li><li class="breadcrumb-item active"><a href="wallet.aspx">Wallet</a></li><li class="breadcrumb-item active">Withdraw</li></ol></nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-3"><div class="card"><div class="card-body"><h5 class="card-title">Pool ID: <asp:Label ID="lbl_poolid" runat="server" /></h5>
                    <h5>Pool assets:</h5>
                    <p>
                        <asp:Label id="lbl_assets" runat="server" /></p>
                    <h5>Balances:                    </h5>
                    <p>
 <asp:Label ID="lbl_bal" runat="server" />
                        <br /> <asp:Label id="lbl_bal2" runat="server" /></p>
<div></div></div></div></div>
                
                <div class="col-lg-8"><div class="card"><div class="card-body"><h5 class="card-title">Pool trade</h5>
                    <p class="card-text">I am trading:</p>
                    <asp:DropDownList ID="ddl_crypto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_crypto_SelectedIndexChanged"></asp:DropDownList>
                    <asp:TextBox ID="tb_tradeamt" runat="server" OnTextChanged="tb_tradeamt_TextChanged"></asp:TextBox>
                    <asp:Label ID="lbl_selectedcrypto"  runat="server" /> = <asp:Label ID="lbl_2ndcrypto" Text="?" runat="server" />
                    
                    <asp:Button ID="btn_convert" runat="server" class="btn btn-primary" Text="Calculate" OnClick="btn_convert_Click" />
                        <asp:Button ID="btn_Confirm" class="btn btn-success" runat="server" Text="Make trade" OnClick="btn_Confirm_Click" />
                    <br />
                    <p>
                        <asp:Label ID="lbl_userbal" runat="server" /></p>
                    <br />
                    <p>
                        <asp:Label ID="lbl_status" runat="server" /></p>
                                        

                                                        </div></div></div></div>
                </section>      
    </body>
</asp:Content>
