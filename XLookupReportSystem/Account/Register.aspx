<%@ Page Title="Register" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="XLookupReportSystem.Account.Register" %>

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
                <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">
                                <div class="d-flex justify-content-center py-4"><a href="index.html" class="logo d-flex align-items-center w-auto">
                                    <img src="../Assets/img/logo.png" alt=""/>
                                    <span class="d-none d-lg-block">ADO Reporting System</span> </a></div>
                                <div class="card mb-3">
                                    <div class="card-body">
                                        <div class="pt-4 pb-2">
                                            <h5 class="card-title text-center pb-0 fs-4">Create an Account</h5>
                                            <p class="text-center small">Enter your personal details to create account</p>
                                        </div>
                                        <p class="text-danger">
                                            <asp:Literal runat="server" ID="ErrorMessage" />
                                        </p>
                                        <div class="row g-3 needs-validation" novalidate="">
                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="Firstnametxt" CssClass="form-label">Firstname</asp:Label>
                                                <asp:TextBox runat="server" ID="Firstnametxt" CssClass="form-control" required="" /><div class="invalid-feedback">Please, enter your Firstname!</div>
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="Surnametxt" CssClass="form-label">Surname</asp:Label>
                                                <asp:TextBox runat="server" ID="Surnametxt" CssClass="form-control" required="" /><div class="invalid-feedback">Please, enter your Surname!</div>
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="Email" CssClass="form-label">Email</asp:Label>
                                                <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="form-control" required="" /><div class="invalid-feedback">Please enter a valid Email adddress!</div>
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="Campus" CssClass="form-label">Campus</asp:Label>
                                                <asp:DropDownList ID="Campus" CssClass="form-control" runat="server">
                                                    <asp:ListItem>Westville</asp:ListItem>
                                                    <asp:ListItem>Pietermaritzburg</asp:ListItem>
                                                    <asp:ListItem>Howard</asp:ListItem>
                                                </asp:DropDownList><div class="invalid-feedback">Please enter a valid campus!</div>
                                            </div>
                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="Password" CssClass="form-label">Password</asp:Label>
                                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" required="" />
                                               <%-- <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                                    CssClass="text-danger" ErrorMessage="The password field is required." />--%><div class="invalid-feedback">Please enter your password!</div>
                                            </div>

                                            
                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="form-label">Confirm password</asp:Label>
                                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" required=""/>
                                                <div class="invalid-feedback">Please enter your password!</div>
                                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />--%>
                                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                            </div>
                                            <div class="col-12">
                                                <div class="form-check">
                                                    <input class="form-check-input" runat="server" name="terms" type="checkbox" value="" id="acceptTerms" required="" />
                                                    <label class="form-check-label" for="acceptTerms">I agree and accept the <a href="#">terms and conditions</a></label><div class="invalid-feedback">You must agree before submitting.</div>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                 <asp:Button runat="server" OnClick="CreateUser_Click" Text="Create Account" CssClass="btn btn-primary w-100" /></div>
                                            <div class="col-12">
                                                <p class="small mb-0">Already have an account? <a href="Login.aspx">Log in</a></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="credits">Designed by <a href="#">TechMan Solutions</a>.</div>
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

