<%@ Page Title="Add User" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="XLookupReportSystem.Admin.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main id="main" class="main">
        <div class="pagetitle">
            
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                    <li class="breadcrumb-item">Admin</li>
                    <li class="breadcrumb-item"><a href="Users.aspx">Users</a></li>
                    <li class="breadcrumb-item active">Add User</li>
                </ol>
            </nav>
            <h1>Add User</h1>
        </div>
        <section class="section">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">
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
                                            <label for="txtEmail" class="col-md-4 col-lg-3 col-form-label">Email</label><div class="col-md-8 col-lg-9">
                                                 <asp:TextBox ID="txtEmail" name="txtEmail" CssClass="form-control" runat="server" ></asp:TextBox></div>
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
                                        <div class="row mb-3">
                                            <label for="" runat="server" id="ErrorMessagePass" class="form-label"></label>
                                        </div>
                                        
                                        <div class="row mb-3">
                                            <label for="txtNewPassword" class="col-md-4 col-lg-3 col-form-label">New Password</label><div class="col-md-8 col-lg-9">
                                                <asp:TextBox ID="txtNewPassword" name="txtNewPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNewPassword"
                                                    CssClass="text-danger" ErrorMessage="The password field is required." />
                                                                                                                                     </div>
                                        </div>
                                        <div class="row mb-3">
                                            <label for="txtRenewPassword" class="col-md-4 col-lg-3 col-form-label">Re-enter New Password</label><div class="col-md-8 col-lg-9">
                                                <asp:TextBox ID="txtRenewPassword" name="txtRenewPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:CompareValidator runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtRenewPassword"
                                                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                                                                                                                                </div>
                                        </div>
                            <div class="text-center">
                                            <asp:Button ID="AddUserbtn" CssClass="btn btn-primary" runat="server" Text="Save Changes" OnClick="AddUserbtn_Click"  /></div>
                        </div>
                    </div>
                </div>
                
            </div>
        </section>
    </main>
</asp:Content>
