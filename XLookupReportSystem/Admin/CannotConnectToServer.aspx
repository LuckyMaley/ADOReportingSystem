<%@ Page Title="Cannot Connect To Server" Language="C#" AutoEventWireup="true" CodeBehind="CannotConnectToServer.aspx.cs" Inherits="XLookupReportSystem.Admin.CannotConnectToServer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%: Page.Title %> - ADO Reporting System</title>
    
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
  <link href="../Assets/vendor/quill/quill.snow.css" rel="stylesheet" />
  <link href="../Assets/vendor/quill/quill.bubble.css" rel="stylesheet" />
  <link href="../Assets/vendor/remixicon/remixicon.css" rel="stylesheet" />
  <link href="../Assets/vendor/simple-datatables/style.css" rel="stylesheet" />

  <!-- Main CSS File -->
  <link href="../Assets/css/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <main>
            <div class="container">
                <section class="section error-404 min-vh-100 d-flex flex-column align-items-center justify-content-center">
                    <h1>Error</h1>
                    <h2>Cannot connect to the Server</h2>
                    <a class="btn" href="../Account/Login.aspx">Back to home</a>
                    <img src="../Assets/img/not-found.svg" class="img-fluid py-5" alt="Error Occured" /><div class="credits">Designed by <a href="#">TechMan Solutions</a>.</div>
                </section>
            </div>
        </main>
        <!-- Vendor JS Files -->
  <script src="../Assets/vendor/apexcharts/apexcharts.min.js"></script>
  <script src="../Assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="../Assets/vendor/chart.js/chart.min.js"></script>
  <script src="../Assets/vendor/echarts/echarts.min.js"></script>
  <script src="../Assets/vendor/quill/quill.min.js"></script>
  <script src="../Assets/vendor/simple-datatables/simple-datatables.js"></script>
  <script src="../Assets/vendor/tinymce/jquery.tinymce.min.js"></script>
  <script src="../Assets/vendor/php-email-form/validate.js"></script>

  <!-- Main JS File -->
  <script src="../Assets/js/main.js"></script>
    </div>
    </form>
</body>
</html>
