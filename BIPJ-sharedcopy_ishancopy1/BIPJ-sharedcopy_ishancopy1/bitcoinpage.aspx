<%@ Page Title="" Language="C#" MasterPageFile="~/loggedinnavbar.Master" AutoEventWireup="true" CodeFile="bitcoinpage.aspx.cs" Inherits="BIPJ_sharedcopy_ishancopy1.bitcoinpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!DOCTYPE html>
<script runat="server">

</script>

<html>

<head>
  <meta charset="utf-8">
  <meta content="width=device-width, initial-scale=1.0" name="viewport">

  <title>Demiswap Bitcoin</title>
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
    <style type="text/css">
        .auto-style1 {
            width: 94px;
            height: 36px;
        }
        .auto-style2 {
            width: 94px;
            height: 38px;
        }
    </style>
</head>

<body>


  <!-- ======= Header ======= -->
  <header id="header" class="header fixed-top d-flex align-items-center">

    <div class="d-flex align-items-center justify-content-between">
      <a href="index.html" class="logo d-flex align-items-center">
        <img src="assets/img/demiswap.png" width="40" height="40" /><span class="d-none d-lg-block">DEMISWAP</span>
      </a>
      <i class="bi bi-list toggle-sidebar-btn"></i>
    </div><!-- End Logo -->

    <div class="search-bar">
        <input type="text" name="query" placeholder="Search" title="Enter search keyword">
        <button type="submit" title="Search"><i class="bi bi-search"></i></button>
    </div><!-- End Search Bar -->

    <nav class="header-nav ms-auto">
      <ul class="d-flex align-items-center">

        <li class="nav-item d-block d-lg-none">
          <a class="nav-link nav-icon search-bar-toggle " href="CryptoList.aspx">
            <i class="bi bi-search"></i>
          </a>
        </li><!-- End Search Icon-->
         </ul> 
      
    </nav>

  </header><!-- End Header -->

  <!-- ======= Sidebar ======= -->
  <aside id="sidebar" class="sidebar">

    <ul class="sidebar-nav" id="sidebar-nav">

      <li class="nav-item">
        <a class="nav-link collapsed" href="CryptoList.aspx">
          <i class="bi bi-grid"></i>
          <span>Cryptocurrencies</span>
        </a>
          
      </li><!-- End Dashboard Nav --></ul>
        </aside>


    </body>
    </html>

<main id="main" class="main">

    <div class="pagetitle">
        <h1 style="font-size:60px">Bitcoin</h1>
    </div>

    <section class="section dashboard">
        <div class="row">

            <!-- Left side columns -->
        <div class="col-lg-8">
          <div class="row">
              <div class="card info-card sales-card">

              <!-- Information -->

              <div class="col-xxl-10 col-md-8">
                  <div class="card-body">
                      <h5 class="card-title">Current Rank: #1</h5>

                    <div class="d-flex align-items-center">
                        <div><img src="assets/img/bitcoin.png" width="80" height="80">
                         </div>
                        <div class="ps-3">
                            <h2>
                                <asp:Label ID="lbl_bal" runat="server"><%# Eval("crypto") %></asp:Label>
                            </h2>
                        </div>
                        <div class="ps-3">
                            <h2>Estimated Users: 54,330</h2>
                        </div>

                    </div>
                  </div>

              </div>



                  </div>
              </div>
            </div>

        </div>



    </section>
    <!-- End Information -->

    <section>

        <!-- Volume and Supply -->

        <div class="col-xxl-8 col-xl-6">

              <div class="card info-card customers-card">


                <div class="card-body">
                  <h2 class="card-title">Volume and Supply</h2>
                    </div>
                  <div class="ps-3">
                      <h2>Current Volume: 30,123,892,736 USD</h2>
                  </div>
                  <div class="ps-3">
                      <h2>Current Supply: 18,925,000 BTC</h2>
                  </div>
                </div>

                    <!-- End Volume and Supply -->
            </div>
    </section>

     <section class="section">
      <div class="row">

        <div class="col-lg-6">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">Bitcoin Value Overtime (2022)</h5>

              <!-- Line Chart -->
              <canvas id="lineChart" style="max-height: 400px;"></canvas>
              <script>
                document.addEventListener("DOMContentLoaded", () => {
                  new Chart(document.querySelector('#lineChart'), {
                    type: 'line',
                    data: {
                      labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
                      datasets: [{
                        label: 'Line Chart',
                        data: [47686.81, 38743.27, 44354.64, 46281.64, 38469.09, 29799.08, 19269.17],
                        fill: false,
                        borderColor: 'rgb(75, 192, 192)',
                        tension: 0.1
                      }]
                    },
                    options: {
                      scales: {
                        y: {
                          beginAtZero: true
                        }
                      }
                    }
                  });
                });
              </script>
              <!-- End Line CHart -->

            </div>
          </div>
        </div>
          </div>
         </section>


    <!-- Purchase Bitcoin -->
    <section>

        <div class="col-lg-8">
          <div class="row">
              <div class="card info-card sales-card">

              <!-- Information -->

              <div class="col-xxl-10 col-md-8">
                  <div class="card-body">
                      <h5 class="card-title">Wallet Value: 40,487 USD (1.37 BTC)</h5>

                    <div class="d-flex align-items-center">
                        <div><img src="assets/img/bitcoin.png" width="80" height="80">
                         </div>
                        <form>
                        <div class="ps-3">
                            
                            <p>
                                <input type="button" value="Sell" class="auto-style1" />
                                </p>
                            
                        </div>
                        <div class="ps-3">
                            <p>
                               <input type="button" value="Buy" class="auto-style2" />
                                </p>
                        </div>
                     </form>

                    </div>
                     
                  </div>

              </div>



                  </div>
              </div>
            </div>

        </div>

    </section>

</main>



<script src="assets/vendor/apexcharts/apexcharts.min.js"></script>
<script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
<script src="assets/vendor/chart.js/chart.min.js"></script>
<script src="assets/vendor/echarts/echarts.min.js"></script>
<script src="assets/vendor/quill/quill.min.js"></script>
<script src="assets/vendor/simple-datatables/simple-datatables.js"></script>
<script src="assets/vendor/tinymce/tinymce.min.js"></script>
<script src="assets/vendor/php-email-form/validate.js"></script>

     <script src="assets/js/main.js"></script>
      <script type="text/javascript">
          var xmlhttp = new XMLHttpRequest();
          var url = "https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD";

          xmlhttp.onreadystatechange = function () {
              if (this.readyState == 4 && this.status == 200) {
                  var json = JSON.parse(this.responseText);
                  parseJson(json);
              }
          };

          xmlhttp.open("GET", url, true);
          xmlhttp.send();

          function parseJson(json) {
              var time = "<b>Last Updated : " + json["USD"] + "</b>";
              var usdValue = "1 BTC equals to $" + json["JPY"];


              document.getElementById("firstcurrency").innerHTML = time +
                  "<br /><br />" + usdValue
              ipt >   }; 
          var a = document.getElementById("decimal").innerHTML;
          a = (Math.round(num * 100 / 100)).toFixed(2);
          document.getElementById("decimal").innerHTML = a;
      </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
