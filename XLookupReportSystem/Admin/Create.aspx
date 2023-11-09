<%@ Page Title="Create" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="XLookupReportSystem.Admin.Create" %>
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
                                  <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                                            <p class="text-danger">
                                                <asp:Literal runat="server" ID="FailureText" />
                                            </p>
                                        </asp:PlaceHolder>
                                        <div class="row g-3 needs-validation" novalidate="">
                                            <div class="col-12" style="visibility:collapse;display:none;">
                                                    <asp:Label runat="server" AssociatedControlID="ProjectName" CssClass="form-label">Project Name</asp:Label>
                                                    
                                                        <asp:TextBox runat="server" ID="ProjectName" CssClass="form-control" required="" Enabled="false"/>
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please enter the Project Name.</div>
                                                   
                                            </div>

                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="SelectModuleTxt" CssClass="form-label">Module Code</asp:Label>
                                                <asp:TextBox runat="server" ID="SelectModuleTxt" CssClass="form-control" Placeholder="e.g. ISTN101" required="" OnTextChanged="SelectModuleTxt_TextChanged" />        
                                                <%--<asp:DropDownList ID="SelectModuleTxt" CssClass="form-select" runat="server" required=""></asp:DropDownList>
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please enter module code e.g ISTN101.</div>
                                                 
                                            </div>
                                            
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="SemesterCBTxt" CssClass="form-label">Select Semester</asp:Label>
                                                        <asp:DropDownList ID="SemesterCBTxt" CssClass="form-select" runat="server" required="">
                                                            <asp:ListItem Value="1">Semester 1</asp:ListItem>
                                                            <asp:ListItem Value="2">Semester 2</asp:ListItem>
                                                    </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please select Semester.</div>
                                                   
                                            </div>

                                            <div class="col-12">
                                                <asp:Label runat="server" AssociatedControlID="CampusCBTxt" CssClass="form-label">Select Campus</asp:Label>
                                                <asp:DropDownList ID="CampusCBTxt" CssClass="form-control" runat="server" required="">
                                                    <asp:ListItem>Westville</asp:ListItem>
                                                    <asp:ListItem>Pietermaritzburg</asp:ListItem>
                                                    <asp:ListItem>Howard</asp:ListItem>
                                                </asp:DropDownList><div class="invalid-feedback">Please enter a valid campus!</div>
                                            </div>

                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="SelectYearCBTxt" CssClass="form-label">Select Year</asp:Label>
                                                        <asp:DropDownList ID="SelectYearCBTxt" CssClass="form-select" runat="server" required="">
                                                            <asp:ListItem>2021</asp:ListItem>
                                                            <asp:ListItem>2022</asp:ListItem>
                                                            <asp:ListItem Selected="True">2023</asp:ListItem>
                                                            
                                                    </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please select year.</div>
                                                   
                                            </div>
                                            
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadRegister" CssClass="form-label">Upload Register</asp:Label>
                                                        <asp:FileUpload ID="UploadRegister" runat="server" CssClass="form-control"  required=""/>
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please upload a register.</div>
                                                   
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadModuleData" CssClass="form-label">Upload Main Exam Module Data</asp:Label>
                                                        <asp:FileUpload ID="UploadModuleData" runat="server" CssClass="form-control"  required=""/>
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please upload the module data.</div>
                                                   
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadSuppModuleData" CssClass="form-label">Upload Supp Exam Module Data (Optional)</asp:Label>
                                                        <asp:FileUpload ID="UploadSuppModuleData" runat="server" CssClass="form-control" />
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please upload the supp module data.</div>
                                                   
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadRiskCodeBeg" CssClass="form-label">Upload Risk Codes S2 2022</asp:Label>
                                                        <asp:FileUpload ID="UploadRiskCodeBeg" runat="server" CssClass="form-control"  required=""/>
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please upload the risk code beginning data.</div>
                                                   
                                            </div>
                                            <div class="col-12">
                                                    <asp:Label runat="server" AssociatedControlID="UploadRiskCodeEnd" CssClass="form-label">Upload Risk Codes S1 2023</asp:Label>
                                                        <asp:FileUpload ID="UploadRiskCodeEnd" runat="server" CssClass="form-control"  required=""/>
                                                        <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectName"
                                                            CssClass="text-danger" ErrorMessage="The email field is required." />--%><div class="invalid-feedback">Please upload the risk code end data.</div>
                                                   
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
                                </main>
</asp:Content>
