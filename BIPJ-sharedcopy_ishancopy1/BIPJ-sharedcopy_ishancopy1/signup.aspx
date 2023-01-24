<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="css/fontstyle.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    
    <!-- Style -->
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <form id="form1" runat="server">
  <div class="content">
    <div class="container">
      <div class="row">
        <div class="col-md-6">
          <img src="assets\img\undraw_remotely_2j6y.svg" alt="Image" class="img-fluid">
        </div>
        <div class="col-md-6 contents">
          <div class="row justify-content-center">
            <div class="col-md-8">
              <div class="mb-4">
              <h3>Sign Up</h3>
              <p class="mb-4"></p>
            </div>
            <form action="#" method="post">
              <div class="form-group first">
                  <asp:TextBox placeholder="Username" style="font-size:12px;" ID="tb_email" runat="server" class="form-control"></asp:TextBox>

              </div>
              <div class="form-group last mb-4">
                  <asp:TextBox ID="tb_password" placeholder="Password" style="font-size:12px;" runat="server" type="password" class="form-control"></asp:TextBox>
                <br />
                  <asp:TextBox ID="tb_confirm" placeholder="Confirm Password" style="font-size:12px;" runat="server" type="password" class="form-control"></asp:TextBox>

              </div>                  <asp:Label ID="lbl_Error" runat="server" style="color:red"></asp:Label>
                 

              
                <asp:Button ID="btn_Signup" runat="server" class="btn btn-block btn-primary" Text="Sign Up" OnClick="btn_Signup_Click"/>
                <br />
                          <div class="d-flex mb-5 align-items-center">
                  <span class="caption" style="margin-left:42%"><a href="login.aspx">Log in</a></span>

              </div>  
    </form>
                </form>
</body>
</html>
