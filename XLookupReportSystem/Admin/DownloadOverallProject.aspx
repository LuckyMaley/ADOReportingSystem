<%@ Page Title="Download Overall Project" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DownloadOverallProject.aspx.cs" Inherits="XLookupReportSystem.Admin.DownloadOverallProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main id="main" class="main">
         <script>
    window.onload = function () {
        // Function to be called after a delay
        function triggerButtonClick() {
            // Simulate a button click
            document.getElementById('<%:LinkButton1.ClientID%>').click();
        }

        // Wait for 5000 milliseconds (5 seconds) and then trigger the button click
        setTimeout(triggerButtonClick, 5000);
    };
</script>
        <%--<div class="pagetitle">
            <h1>Download</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                    <li class="breadcrumb-item">Pages</li>
                    <li class="breadcrumb-item active">Download</li>
                </ol>
            </nav>
        </div>--%>
        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card" style="min-height: 500px;">
                        <div class="card-body profile-card pt-4 d-flex flex-column align-items-center align-content-center">
                            <div style="min-height:200px"></div>
                            <p>The file will be downloaded automatically in a moment. If nothing happens, please click the below to download manually</p>
                             <div class="profile-card__edit">
                                 <asp:LinkButton ID="LinkButton1" runat="server"  OnClick="LinkButton1_Click">Download</asp:LinkButton></div>
<%--                            <div class="social-links mt-2"><a href="#" class="twitter"><i class="bi bi-twitter"></i></a><a href="#" class="facebook"><i class="bi bi-facebook"></i></a><a href="#" class="instagram"><i class="bi bi-instagram"></i></a><a href="#" class="linkedin"><i class="bi bi-linkedin"></i></a></div>--%>
                        </div>
                    </div>
                    
                </div>
            </div>
        </section>
    </main>
</asp:Content>
