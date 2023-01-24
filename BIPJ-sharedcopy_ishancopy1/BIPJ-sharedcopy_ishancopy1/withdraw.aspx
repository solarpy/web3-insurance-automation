<%@ Page Title="" Language="C#" MasterPageFile="~/loggedinnavbar.Master" AutoEventWireup="true" CodeBehind="withdraw.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.withdraw" %>
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
                <div class="col-lg-8"><div class="card"><div class="card-body"><h5 class="card-title">Withdraw</h5>
            <p>Select cryptocurrency you want to withdraw:</p>
                    <br />
                             <asp:DropDownList class="form-select" Width="50%" ID="ddl_cryptos" runat="server" AutoPostBack="True" DataSourceID="usercryptods" DataTextField="crypto" DataValueField="crypto" OnSelectedIndexChanged="ddl_cryptos_SelectedIndexChanged1">

                    </asp:DropDownList>
                                        <asp:Label ID="lbl_availerror" style="color:red" runat="server"></asp:Label>
                    <br />

                    <asp:Label ID="lbl_bal" runat="server"></asp:Label>
                    <br />
                    <p>Enter withdraw amount:</p>

                    <asp:TextBox ID="tb_withdrawamt" step="any" type="number" min="0" runat="server"></asp:TextBox>
                    <asp:SqlDataSource ID="usercryptods" runat="server" ConnectionString="<%$ ConnectionStrings:usersContext %>" SelectCommand="SELECT * FROM [Balances] WHERE ([email] = @email)">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <br />
                    <p>Enter destination wallet address:</p>
                    <asp:TextBox ID="tb_address" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btn_withdraw" runat="server" class="btn btn-primary" Text="Withdraw" OnClick="btn_withdraw_Click"/>
                    <asp:Label ID="lbl_success" runat="server"></asp:Label>
<div></div></div></div></div></section>      
    </body>
</asp:Content>
