﻿<%@ Page Title="Forgot Password" Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="XLookupReportSystem.Account.ForgotPassword1" %>

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
                                <div class="d-flex justify-content-center py-4">
                                    <a href="#" class="logo d-flex align-items-center w-auto">
                                        <img src="../Assets/img/ADOLogoblue.png" alt="" />
                                        <span class="d-none d-lg-block">ADO Reporting System</span> </a>
                                </div>
                                <div class="card mb-3">
                                    <div class="card-body">
                                         <div class="row g-3">
                                        <asp:PlaceHolder ID="loginForm" runat="server">
                                            <div >
                                                <div class="pt-4 pb-2">
                                                <h5 class="card-title text-center pb-0 fs-4">Forgot your password?</h5>
                                                <p class="text-center small">Enter your email</p>
                                            </div>
                                                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                                    <p class="text-danger">
                                                        <asp:Literal runat="server" ID="FailureText" />
                                                    </p>
                                                </asp:PlaceHolder>
                                                <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                                                    <div >
                                                        <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />
                                                    </div>
                                                </div>
                                                <div class="col-12">
                                                    <div>
                                                        <asp:Button runat="server" ID="ForgotBtn" OnClick="Forgot" Text="Email Link" CssClass="btn btn-primary w-100 forgotbtn" />
                                                        <%--<script type="text/javascript">
                                                        save_btn = document.querySelector(".forgotbtn");
                                                        save_btn.onclick = function showLoadingSpinner() {
                                                            
                                                            //console.log("showLoadingSpinner called");
                                                                // Show the loading spinner
                                                                //document.getElementById("loadingSpinner").style.display = "block";

                                                                // Optionally, disable the button to prevent multiple clicks
                                                                save_btn.disabled = true;
                                                                save_btn.value = "Please wait...";
                                                                 __doPostBack('<%= ForgotBtn.UniqueID %>', '');
                                                            }

                                                            function hideLoadingSpinner() {
                                                                var hideSpinnerFlag = document.getElementById("hideSpinnerFlag").value;
                                                                console.log("hideLoadingSpinner called");
                                                                if (hideSpinnerFlag === "true") {
                                                                    // Hide the loading spinner
                                                                    document.getElementById("loadingSpinner").style.display = "none";
                                                                }

                                                                // Re-enable the button
                                                                save_btn.disabled = false;

                                                                return true;
                                                            }


                                                    </script>--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                                            <p class="text-info">
                                                Please check your email to reset your password.
                                            </p>
                                        </asp:PlaceHolder>
                                    </div>
                            </div>
                                </div>
                                <a href="Login.aspx">Back to Login</a>
                                <div class="credits">Designed by <a href="#">TechMan Solutions</a>.</div>
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

