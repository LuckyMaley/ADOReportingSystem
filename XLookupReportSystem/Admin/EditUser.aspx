<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="XLookupReportSystem.Admin.EditUser" %>
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
     <main id="main" class="main">
        <div class="pagetitle">
            
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                    <li class="breadcrumb-item">Admin</li>
                    <li class="breadcrumb-item"><a href="Users.aspx">Users</a></li>
                    <li class="breadcrumb-item active">Edit User</li>
                </ol>
            </nav>
            <div class=" row py-2 flex-wrap">
                     <div class="col-auto me-auto">
                        <h1>Edit User</h1>
                        
                    </div>
                     <div class="col-auto d-flex align-items-center">
                         <div class="">
                            <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#largeModal">
                            Delete
                          </button>
                         
                         <div class="modal fade" id="largeModal" tabindex="-1" aria-hidden="true" style="display: none;">
                            <div class="modal-dialog modal-sm">
                              <div class="modal-content">
                                <div class="modal-header">
                                  <h5 class="modal-title">Delete User</h5>
                                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                  <p>Are you sure you want to delete user?</p>
                                     
                                 </div>
                                 <div class="modal-footer">
                                     
                                              <button type="button" class="btn btn-secondary" id="closeModal"  data-bs-dismiss="modal">Close</button>
                                                <div class="twoToneCenter">
                                              <asp:Button ID="Deletebtn" CssClass="btn btn-danger" runat="server" Text="Delete User" OnClick="Deletebtn_Click"   />
                                                </div>
                                            </div>
                                </div>
                                
                              </div>
                            </div>
                         </div>
                </div>
            </div>
        </div>
        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
                            <!-- Bordered Tabs -->
                                          <ul class="nav nav-tabs nav-tabs-bordered" id="borderedTab" role="tablist">
                                            <li class="nav-item" role="presentation">
                                              <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#bordered-home" type="button" role="tab" aria-controls="home" aria-selected="true">Edit Details</button>
                                            </li>
                                            <li class="nav-item" role="presentation">
                                              <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#bordered-profile" type="button" role="tab" aria-controls="profile" aria-selected="false" tabindex="-1">Change Password</button>
                                            </li>
                                            <%--<li class="nav-item" role="presentation">
                                              <button class="nav-link" id="contact-tab" data-bs-toggle="tab" data-bs-target="#bordered-contact" type="button" role="tab" aria-controls="contact" aria-selected="false" tabindex="-1">Contact</button>
                                            </li>--%>
                                          </ul>
                                          <div class="tab-content pt-2" id="borderedTabContent">
                                            <div class="tab-pane fade active show" id="bordered-home" role="tabpanel" aria-labelledby="home-tab">
                                                <div class="row mb-3">
                                            <label  runat="server" id="ErrorMessage" visible="false" class="form-label"></label>
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
                                        <div class="row mb-3">
                                            <label for="DisciplineCBTxt" class="col-md-4 col-lg-3 col-form-label">Discipline</label>
                                            <div class="col-md-8 col-lg-9">
                                                <asp:DropDownList ID="DisciplineCBTxt" name="DisciplineCBTxt" CssClass="form-control" runat="server">
                                                    <asp:ListItem>IS&T</asp:ListItem>
                                                    <asp:ListItem>LAW</asp:ListItem>
                                                    <asp:ListItem>Accounting</asp:ListItem>
                                                    <asp:ListItem>Finance</asp:ListItem>
                                                    <asp:ListItem>Economics</asp:ListItem>
                                                    <asp:ListItem>Management</asp:ListItem>
                                                    <asp:ListItem>Governance</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="txtEmail" class="col-md-4 col-lg-3 col-form-label">Email</label><div class="col-md-8 col-lg-9">
                                                 <asp:TextBox ID="txtEmail" name="txtEmail" CssClass="form-control" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox></div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="RoleList" class="col-md-4 col-lg-3 col-form-label">Role</label>
                                            <div class="col-md-8 col-lg-9">
                                                <asp:DropDownList ID="RoleList" name="RoleList" CssClass="form-control" runat="server">
                                                    <asp:ListItem>Member</asp:ListItem>
                                                    <asp:ListItem>Owner</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="text-center">
                                            <asp:Button ID="btnEditProfile" CssClass="btn btn-primary" runat="server" Text="Save Changes" OnClick="btnEditProfile_Click" /></div>
                        </div>
                                              <div class="tab-pane fade" id="bordered-profile" role="tabpanel" aria-labelledby="profile-tab">
                                                    <div>
                                        <div class="row mb-3">
                                            <label for="" runat="server" id="ErrorMessagePass" class="form-label"></label>
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
    </main>
</asp:Content>
