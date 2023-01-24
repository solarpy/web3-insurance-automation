<%@ Page Title="" Language="C#" MasterPageFile="~/loggedinnavbar.Master" AutoEventWireup="true" CodeBehind="deposit.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.deposit" %>
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
        <nav><ol class="breadcrumb"><li class="breadcrumb-item"><a href="index.aspx">Home</a></li><li class="breadcrumb-item active"><a href="wallet.aspx">Wallet</a></li><li class="breadcrumb-item active">Deposit</li></ol></nav>
        <section class="section">
            <div class="row">
                <div class="col-lg-8"><div class="card"><div class="card-body"><h5 class="card-title">Deposit</h5>
            <p>Select cryptocurrency to deposit:</p>
                    <br />
                             <asp:DropDownList class="form-select" Width="50%" ID="ddl_cryptos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_cryptos_SelectedIndexChanged">
                                <asp:ListItem Value="bitcoin">Bitcoin (BTC)</asp:ListItem>
                                <asp:ListItem Value="ethereum">Ethereum (ETH)</asp:ListItem>
                                <asp:ListItem Value="dogecoin">Dogecoin (DOGE)</asp:ListItem>
                                <asp:ListItem Value="dash">Dash (DASH)</asp:ListItem>
                                <asp:ListItem Value="litecoin">Litecoin (LTC)</asp:ListItem>
                                <asp:ListItem Value="xrp">XRP</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Button ID="btn_Generate" runat="server" class="btn btn-primary" Text="Generate wallet address" OnClick="btn_Generate_Click" />
<div></div></div></div></div><div class="col-lg-4"><div class="card"><div class="card-body"><h5 class="card-title">Deposit to:</h5><asp:Label ID="lbl_Address" runat="server" Text=""></asp:Label>
<br />
<h5 class="card-title">Amount received:</h5>
    <asp:Label ID="lbl_Received" runat="server" Text="0"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btn_Refresh" class="btn btn-primary" runat="server" Text="Refresh" OnClick="btn_Refresh_Click" />
    <asp:Button ID="btn_Confirm" class="btn btn-success" runat="server" Text="Confirm deposit" OnClick="btn_Confirm_Click" />
                                                                     </div></div></div>
            </div></section>      


    </body>
</asp:Content>
