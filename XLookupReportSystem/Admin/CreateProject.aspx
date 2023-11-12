<%@ Page Title="Create" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="XLookupReportSystem.Admin.CreateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
        
        <div class="pagetitle">
                <nav>
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                                <li class="breadcrumb-item">Admin</li>
                                <li class="breadcrumb-item active">Create</li>
                            </ol>
                        </nav>
            <div class="col-auto me-auto">
                        <h1>Create</h1>
                        
                    </div></div>
         <div class="row py-2 flex-wrap">
             
                <div class="col-12">
        <div class="card">
            <div class="card-body pt-4">
                                  <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                            <p class="text-danger">
                                                <asp:Literal runat="server" ID="FailureText" />
                                            </p>
                                        </asp:PlaceHolder>
                                        
                                            <div class="col-12 mb-3">
                                                    <span class="form-label">Project Name:</span> <asp:Label runat="server" AssociatedControlID="" ID="ProjectNamelb" CssClass="form-label"></asp:Label>
                                                        
                                                   &nbsp;
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadRegister" CssClass="form-label">Upload Register</asp:Label>
                                                        <asp:FileUpload ID="UploadRegister" runat="server" CssClass="form-control"  />
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UploadRegister"
                                                            CssClass="text-danger" ErrorMessage="The upload register field is required." />
                                                   
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadModuleData" CssClass="form-label">Upload Main Exam Module Data</asp:Label>
                                                        <asp:FileUpload ID="UploadModuleData" runat="server" CssClass="form-control" />
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UploadModuleData"
                                                            CssClass="text-danger" ErrorMessage="The Upload Module Data field is required." />
                                                   
                                            </div>
                                            <div class="col-12 mb-4">
                                                    <asp:Label runat="server" AssociatedControlID="UploadSuppModuleData" CssClass="form-label">Upload Supp Exam Module Data (Optional)</asp:Label>
                                                        <asp:FileUpload ID="UploadSuppModuleData" runat="server" CssClass="form-control" />
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%>
                                                   
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadRiskCodeBeg" ID="riskbeglb" CssClass="form-label">Upload Risk Codes S2 2022</asp:Label>
                                                        <asp:FileUpload ID="UploadRiskCodeBeg" runat="server" CssClass="form-control"  />
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UploadRiskCodeBeg"
                                                            CssClass="text-danger" ErrorMessage="The Upload Risk Code Beginning field is required." />
                                                   
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadRiskCodeEnd" ID="riskendlb"  CssClass="form-label">Upload Risk Codes S1 2023</asp:Label>
                                                        <asp:FileUpload ID="UploadRiskCodeEnd" runat="server" CssClass="form-control" />
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UploadRiskCodeEnd"
                                                            CssClass="text-danger" ErrorMessage="The Upload Risk Code End field is required." />
                                                   
                                            </div>

                                            <div class="">
                                             
                                                <div class="twoToneCenter">
                                              <asp:Button ID="Createbtn" CssClass="btn btn-primary createbtn" runat="server" Text="Create" OnClick="Createbtn_Click" />
                                                    <%--<div class="spinner" id="loadingSpinner"></div>--%>
                                                    <asp:HiddenField ID="hideSpinnerFlag" runat="server" />
                                                    <script type="text/javascript">
                                                        save_btn = document.querySelector(".createbtn");
                                                        save_btn.onclick = function showLoadingSpinner() {
                                                            console.log("showLoadingSpinner called");
                                                                // Show the loading spinner
                                                                //document.getElementById("loadingSpinner").style.display = "block";

                                                                // Optionally, disable the button to prevent multiple clicks
                                                                save_btn.disabled = true;
                                                                save_btn.value = "Please wait...";
                                                                
                                                                
                                                                __doPostBack('<%= Createbtn.UniqueID %>', '');
                                                                var fileUploadControlReg = document.getElementById('<%= UploadRegister.ClientID %>');
                                                            var fileUploadControlModData = document.getElementById('<%= UploadModuleData.ClientID %>');
                                                            var fileUploadControlSuppData = document.getElementById('<%= UploadSuppModuleData.ClientID %>');
                                                            var fileUploadControlRiskCodeBeg = document.getElementById('<%= UploadRiskCodeBeg.ClientID %>');
                                                            var fileUploadControlRiskCodeEnd = document.getElementById('<%= UploadRiskCodeEnd.ClientID %>');
                                                            fileUploadControlReg.disabled = true;
                                                            fileUploadControlModData.disabled = true;
                                                            fileUploadControlSuppData.disabled = true;
                                                            fileUploadControlRiskCodeBeg.disabled = true;
                                                            fileUploadControlRiskCodeEnd.disabled = true;
                                                            }

                                                            //function hideLoadingSpinner() {
                                                            //    //var hideSpinnerFlag = document.getElementById("hideSpinnerFlag").value;
                                                            //    console.log("hideLoadingSpinner called");
                                                            //    if (hideSpinnerFlag === "true") {
                                                            //        // Hide the loading spinner
                                                            //        //document.getElementById("loadingSpinner").style.display = "none";
                                                            //        save_btn.disabled = false;
                                                            //    }
                                                            //    // Re-enable the button
                                                                
                                                            //}


                                                    </script>
                                                </div>
                                            </div>
                                        </div>
            </div>
        </div>
             </div>
                                </main>
</asp:Content>
