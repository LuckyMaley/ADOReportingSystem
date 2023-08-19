<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CommanderWebsite.Admin.Store.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%: Page.Title %> - COMMANDER E-Commerce Website</title>
    
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="format-detection" content="telephone=no" />
   
    <meta content="" name="description" />
  <meta content="" name="keywords" />

  <!-- Favicons -->
  <link href="../Assets/img/favicon.png" rel="icon" />
  <link href="../Assets/img/apple-touch-icon.png" rel="apple-touch-icon" />

  <!-- Google Fonts -->
  <link href="https://fonts.gstatic.com" rel="preconnect" />
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />

  <!-- Vendor CSS Files -->
  <link href="../Assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
  <link href="../Assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
  <link href="../Assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
  <link href="../Assets/admin/vendor/quill/quill.snow.css" rel="stylesheet" />
  <link href="../Assets/vendor/quill/quill.bubble.css" rel="stylesheet" />
  <link href="../Assets/vendor/remixicon/remixicon.css" rel="stylesheet" />
  <link href="../Assets/vendor/simple-datatables/style.css" rel="stylesheet" />

  <!-- Main CSS File -->
  <link href="../Assets/css/style.css" rel="stylesheet" />
        <!-- Google Tag Manager -->
    <script async="async" src="https://www.googletagmanager.com/gtag/js?id=G-1T24HD2682"></script>
    <script>
      window.dataLayer = window.dataLayer || [];
      function gtag(){dataLayer.push(arguments);}
      gtag('js', new Date());

      gtag('config', 'G-1T24HD2682');
    </script>
    <!-- End Google Tag Manager -->
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <main>
            <div class="container">
                <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">
                                <div class="d-flex justify-content-center py-4"><a href="index.html" class="logo d-flex align-items-center w-auto">
                                    <img src="../Assets/img/logo.png" alt=""/>
                                    <span class="d-none d-lg-block">NiceAdmin</span> </a></div>
                                <div class="card mb-3">
                                    <div class="card-body">
                                        <div class="pt-4 pb-2">
                                            <h5 class="card-title text-center pb-0 fs-4">Login to Your Account</h5>
                                            <p class="text-center small">Enter your username &amp; password to login</p>
                                        </div>
                                        <div class="row g-3 needs-validation" novalidate="">
                                            <div class="col-12">
                                                <label for="yourUsername" class="form-label">Username</label><div class="input-group has-validation"><span class="input-group-text" id="inputGroupPrepend">@</span>
                                                    <input type="text" name="username" class="form-control" id="yourUsername" required="" /><div class="invalid-feedback">Please enter your username.</div>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <label for="yourPassword" class="form-label">Password</label>
                                                <input type="password" name="password" class="form-control" id="yourPassword" required="" /><div class="invalid-feedback">Please enter your password!</div>
                                            </div>
                                            <div class="col-12">
                                                <div class="form-check">
                                                    <input class="form-check-input" type="checkbox" name="remember" value="true" id="rememberMe" />
                                                    <label class="form-check-label" for="rememberMe">Remember me</label></div>
                                            </div>
                                            <div class="col-12">
                                                <button class="btn btn-primary w-100" type="submit">Login</button></div>
                                            <div class="col-12">
                                                <p class="small mb-0">Don't have account? <a href="Register.aspx">Create an account</a></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="credits">Designed by <a href="https://bootstrapmade.com/">BootstrapMade</a></div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </main>
        <!-- Vendor JS Files -->
  <script src="../Assets/vendor/apexcharts/apexcharts.min.js"></script>
  <script src="../Assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="../Assets/vendor/chart.js/chart.min.js"></script>
  <script src="../Assets/vendor/echarts/echarts.min.js"></script>
  <script src="../Assets/admin/vendor/quill/quill.min.js"></script>
  <script src="../Assets/vendor/simple-datatables/simple-datatables.js"></script>
  <script src="../Assets/vendor/tinymce/jquery.tinymce.min.js"></script>
  <script src="../Assets/vendor/php-email-form/validate.js"></script>

  <!-- Main JS File -->
  <script src="../Assets/js/main.js"></script>
    </div>
    </form>
</body>
</html>

