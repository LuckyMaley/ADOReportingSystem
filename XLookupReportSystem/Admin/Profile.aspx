<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="XLookupReportSystem.Admin.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
       // Function to trigger click event for the specific anchor
       function triggerSpecificAnchorClick(anchorId) {
           var anchor = document.getElementById(anchorId);
           if (anchor) {
               anchor.click();
           }
       }
    </script>
    
<style>
   /* Style for the container div */
    .custom-file-upload-button {
        display: inline-block;
        position: relative;
        overflow: hidden;
        margin: 0;
        padding: 0;
        cursor: pointer;
    }

    /* Style for the input element */
    .custom-file-upload-button input[type="file"] {
        position: absolute;
        font-size: 100px;
        right: 0;
        top: 0;
        opacity: 0;
        cursor: pointer;
    }

    /* Button styles */
    .custom-file-upload-button button {
        display: inline-block;
        padding: 10px 20px;
        background-color: #3498db; /* Button background color */
        color: #fff; /* Button text color */
        border: none;
        border-radius: 4px; /* Rounded corners */
        cursor: pointer;
    }

    /* Optional hover effect */ /*
    .custom-file-upload-button:hover {
        background-color: #2980b9; 
    } */

    #custom-button {
  padding: 10px;
  color: white;
  background-color: #009578;
  border: 1px solid #000;
  border-radius: 5px;
  cursor: pointer;
}

#custom-button:hover {
  background-color: #00b28f;
}

#custom-text {
  margin-left: 10px;
  font-family: sans-serif;
  color: #aaa;
}
</style>


    
   
    <main id="main" class="main">
        <div class="pagetitle">
            
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                    <li class="breadcrumb-item">Admin</li>
                    <li class="breadcrumb-item active">Profile</li>
                </ol>
            </nav>
            <h1>Profile</h1>
        </div>
        <section class="section profile">
            <div class="row">
                <div class="col-xl-4">
                    <div class="card">
                        <div class="card-body profile-card pt-4 d-flex flex-column align-items-center">
                            <asp:Image ID="ProfileImg" CssClass="rounded-circle" ImageUrl="../Assets/img/defaultImg.png" style="height:120px;width:120px;" AlternateText="Profile" runat="server" /><h2>
                                <asp:Label ID="username" runat="server" Text=""></asp:Label></h2>
                            <h3><asp:Label ID="usertype" runat="server" Text=""></asp:Label></h3>
<%--                            <div class="social-links mt-2"><a href="#" class="twitter"><i class="bi bi-twitter"></i></a><a href="#" class="facebook"><i class="bi bi-facebook"></i></a><a href="#" class="instagram"><i class="bi bi-instagram"></i></a><a href="#" class="linkedin"><i class="bi bi-linkedin"></i></a></div>--%>
                        </div>
                    </div>
                </div>
                <div class="col-xl-8">
                    <div class="card">
                        <div class="card-body pt-3">
                            <ul class="nav nav-tabs nav-tabs-bordered" role="tablist">
                                <li class="nav-item" role="presentation">
                                    <a class="nav-link active " id="overviewAnchor"  data-bs-toggle="tab" runat="server" data-bs-target="#profile-overview" aria-selected="true" href="?tab=profile-overview"  role="tab">Overview</a>
                                </li>
                                <li class="nav-item" role="presentation">
                                    <a class="nav-link " id="EditAnchor"  data-bs-toggle="tab" data-bs-target="#profile-edit" aria-selected="false" tabindex="-1" href="?tab=profile-edit"   role="tab">Edit Profile</a>
                                </li>
                                <%--<li class="nav-item" role="presentation">
                                    <button class="nav-link" type="button" data-bs-toggle="tab" data-bs-target="#profile-settings" aria-selected="false" tabindex="-1" role="tab">Settings</button>
                                    </li>--%>
                                <li class="nav-item" role="presentation">
                                    <a class="nav-link " id="ChangePassAnchor"  data-bs-toggle="tab" data-bs-target="#profile-change-password" aria-selected="false" href="?tab=profile-change-password"  tabindex="-1" role="tab">Change Password</a>
                                </li>
                            </ul>
                            <div class="tab-content pt-2" style="min-height:400px">
                                <div class="tab-pane fade show active profile-overview" id="profile-overview" role="tabpanel">
                                    <h5 class="card-title">Profile Details</h5>
                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label ">First Name</div>
                                        <div class="col-lg-9 col-md-8">
                                            <asp:Label ID="lbFirstName" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label ">Surname</div>
                                        <div class="col-lg-9 col-md-8"><asp:Label ID="lbSurname" runat="server" Text=""></asp:Label></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label">Campus</div>
                                        <div class="col-lg-9 col-md-8"><asp:Label ID="lbCampus" runat="server" Text=""></asp:Label></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3 col-md-4 label">Email</div>
                                        <div class="col-lg-9 col-md-8"><asp:Label ID="LbEmailAddress" runat="server" Text=""></asp:Label></div>
                                    </div>
                                    
                                </div>
                                <div class="tab-pane fade profile-edit pt-3 " id="profile-edit" role="tabpanel">
                                    <div>
                                        <div class="row mb-3">
                                            <label  runat="server" id="ErrorMessage" visible="false" class="form-label"></label>
                                        </div>
                                        <script>
                                            
                                            const realFileBtn = document.getElementById("<%:realFileUpload.ClientID%>");
                                            const customBtn = document.getElementById("<%:customButton.ClientID%>");
                                            const customTxt = document.getElementById("custom-text");

                                            customBtn.addEventListener("click", function () {
                                                realFileBtn.click();
                                            });

                                            realFileBtn.addEventListener("change", function () {
                                                if (realFileBtn.value) {
                                                    customTxt.innerHTML = realFileBtn.value.match(
                                                      /[\/\\]([\w\d\s\.\-\(\)]+)$/
                                                    )[1];
                                                } else {
                                                    customTxt.innerHTML = "No file chosen, yet.";
                                                }
                                            });

                                            function updateButtonText() {
                                                var fileInput = document.getElementById("<%:realFileUpload.ClientID%>");
                                                var textSpan = document.getElementById("textSpan");

                                                if (fileInput.files.length > 0) {
                                                    textSpan.innerText = "File Selected: " + fileInput.files[0].name;
                                                } else {
                                                    textSpan.innerText = "No File Selected yet";
                                                }
                                            }

                                                                  </script>
                                        
                                        <div class="row mb-3">
                                            

                                            <label for="profileImage" class="col-md-4 col-lg-3 col-form-label">Profile Image</label><div class="col-md-8 col-lg-9">
                                                <asp:Image ID="profileEditImg" ImageUrl="../Assets/img/defaultImg.png" style="height:120px;width:120px;" AlternateText="Profile" runat="server" CssClass="rounded-circle" />
                                                <div class="pt-2">
                                                    <div class="custom-file-upload-button" style="width: 400px;white-space: nowrap;overflow: hidden;text-overflow: ellipsis; ">
                                                <button id="customButton" runat="server" class="btn btn-primary btn-sm"><i class="bi bi-upload"></i> Upload Image</button>
                                                <asp:FileUpload runat="server" name="fileInput" ID="realFileUpload" onchange="updateButtonText();" />
                                                        <div></div>
                                                <span id="textSpan" style="display:flex">No file chosen, yet.</span><%--<i class="bi bi-upload"></i>--%>
                                            </div>
                                                    <br />
                                                    <asp:LinkButton ID="LinkButtonRemoveImg" CssClass="btn btn-danger btn-sm" title="Remove my profile image" runat="server" OnClick="LinkButtonRemoveImg_Click"><i class="bi bi-trash"></i> Remove Image</asp:LinkButton>
                                                    </div>
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            
                                        </div>
                                        <div class="row mb-3">
                                            <label for="txtFirstName" class="col-md-4 col-lg-3 col-form-label">First Name</label><div class="col-md-8 col-lg-9">
                                                <asp:TextBox ID="TxtFirstName" name="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox></div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="txtSurname" class="col-md-4 col-lg-3 col-form-label">Surname</label><div class="col-md-8 col-lg-9">
                                                <asp:TextBox ID="txtSurname" name="txtSurname" CssClass="form-control" runat="server"></asp:TextBox></div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="CampusCBTxt" class="col-md-4 col-lg-3 col-form-label">Campus</label>
                                            <div class="col-md-8 col-lg-9">
                                                <asp:DropDownList ID="CampusCBTxt" name="CampusCBTxt" CssClass="form-control" runat="server">
                                                    <asp:ListItem>Westville</asp:ListItem>
                                                    <asp:ListItem>Pietermaritzburg</asp:ListItem>
                                                    <asp:ListItem>Howard</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                       <%-- <div class="row mb-3">
                                            <label for="txtEmail" class="col-md-4 col-lg-3 col-form-label">Email</label><div class="col-md-8 col-lg-9">
                                                 <asp:TextBox ID="txtEmail" name="txtEmail" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox></div>
                                        </div>--%>
                                        
                                        <%--<div class="row mb-3">
                                            <label for="Twitter" class="col-md-4 col-lg-3 col-form-label">Twitter Profile</label><div class="col-md-8 col-lg-9">
                                                <input name="twitter" type="text" class="form-control" id="Twitter" value="https://twitter.com/#" /></div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="Facebook" class="col-md-4 col-lg-3 col-form-label">Facebook Profile</label><div class="col-md-8 col-lg-9">
                                                <input name="facebook" type="text" class="form-control" id="Facebook" value="https://facebook.com/#" /></div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="Instagram" class="col-md-4 col-lg-3 col-form-label">Instagram Profile</label><div class="col-md-8 col-lg-9">
                                                <input name="instagram" type="text" class="form-control" id="Instagram" value="https://instagram.com/#" /></div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="Linkedin" class="col-md-4 col-lg-3 col-form-label">Linkedin Profile</label><div class="col-md-8 col-lg-9">
                                                <input name="linkedin" type="text" class="form-control" id="Linkedin" value="https://linkedin.com/#" /></div>
                                        </div>--%>
                                        <div class="text-center">
                                            <asp:Button ID="btnEditProfile" CssClass="btn btn-primary" runat="server" Text="Save Changes" OnClick="btnEditProfile_Click" /></div>
                                    </div>
                                </div>
                                <%--<div class="tab-pane fade pt-3" id="profile-settings" role="tabpanel">
                                    <div>
                                        <div class="row mb-3">
                                            <label for="fullName" class="col-md-4 col-lg-3 col-form-label">Email Notifications</label><div class="col-md-8 col-lg-9">
                                                <div class="form-check">
                                                    <input class="form-check-input" runat="server" type="checkbox" id="changesMade" checked="" />
                                                    <label class="form-check-label" for="changesMade">Changes made to your account </label>
                                                </div>
                                                
                                                <div class="form-check">
                                                    <input class="form-check-input" runat="server" type="checkbox" id="securityNotify" checked="" disabled="" />
                                                    <label class="form-check-label" for="securityNotify">Security alerts </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="text-center">
                                            <asp:Button ID="btnProfileSettings" CssClass="btn btn-primary" runat="server" Text="Save Changes" OnClick="btnProfileSettings_Click"/></div>
                                    </div>
                                </div>--%>
                                <div class="tab-pane fade pt-3 " id="profile-change-password" role="tabpanel">
                                    <div>
                                        <div class="row mb-3">
                                            <label for="" runat="server" id="ErrorMessagePass" class="form-label"></label>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="txtCurrentPassword" class="col-md-4 col-lg-3 col-form-label">Current Password</label><div class="col-md-8 col-lg-9">
                                                <asp:TextBox ID="txtCurrentPassword" name="txtCurrentPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCurrentPassword"
                                                    CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                                                                                                                                             </div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="txtNewPassword" class="col-md-4 col-lg-3 col-form-label">New Password</label><div class="col-md-8 col-lg-9">
                                                <asp:TextBox ID="txtNewPassword" name="txtNewPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPassword"
                                                    CssClass="text-danger" ErrorMessage="The password field is required." />--%>
                                                                                                                                     </div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="txtRenewPassword" class="col-md-4 col-lg-3 col-form-label">Re-enter New Password</label><div class="col-md-8 col-lg-9">
                                                <asp:TextBox ID="txtRenewPassword" name="txtRenewPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <%--<asp:CompareValidator runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtRenewPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />--%>
                                                                                                                                                </div>
                                        </div>
                                        <div class="text-center">
                                            <asp:Button ID="ProfileChangePassword" CssClass="btn btn-primary" runat="server" Text="Save Changes" OnClick="ProfileChangePassword_Click" /></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main><!-- End #main -->
</asp:Content>
