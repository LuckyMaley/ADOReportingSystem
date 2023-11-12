<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="XLookupReportSystem.Account.Confirmation" %>

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
  <link href="../Assets/img/ADOLogoblue.png" rel="icon" />
  <link href="../Assets/img/ADOLogoblue.png" rel="apple-touch-icon" />

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
        
</head>
<body>
    <form id="form1" runat="server">
        
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>
        <main>
            <div class="container">
                <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">
                                <div class="d-flex justify-content-center py-4"><a href="#" class="logo d-flex align-items-center w-auto">
                                    <img src="../Assets/img/ADOLogoblue.png"alt=""/>
                                    <span class="d-none d-lg-block">ADO Reporting System</span> </a></div>
                                <div class="card mb-3">
                                    <div class="card-body">
                                            <p>Your password has been changed. Click <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">here</asp:HyperLink> to login </p>
                                        </div>
                                    </div>
                                <div class="credits align-content-center">Designed by <a href="#">TechMan Solutions</a>.</div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </main>
            </ContentTemplate>
</asp:UpdatePanel>
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
