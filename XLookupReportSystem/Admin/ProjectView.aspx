<%@ Page Title="Project View" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ProjectView.aspx.cs" Inherits="XLookupReportSystem.Admin.ProjectView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main" class="main">
            <div class="pagetitle">
                <nav>
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                                <li class="breadcrumb-item">Admin</li>
                                <li class="breadcrumb-item"><a href="Projects.aspx">Projects</a></li>
                                <li class="breadcrumb-item active"><%= Request.QueryString["projID"] %></li>
                            </ol>
                        </nav>
                <div class=" row py-2 flex-wrap">
                     <div class="col-auto me-auto">
                        <h1><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
                         
                        
                    </div>
                     <div class="col-auto py-2 d-flex align-items-center">
                         <div class="">
                            <asp:Button ID="CreateProjbtn" CssClass="btn btn-primary" runat="server" Text="Create" OnClick="CreateProjbtn_Click" />
                         </div>
                         &nbsp;
                         <div class="">
                            <asp:Button ID="Downloadbtn" CssClass="btn btn-success" runat="server" Text="Export" OnClick="Downloadbtn_Click"/>
                         </div>
                </div>
            </div>
                </div>
                <section>
                    <div>

                    </div>
                </section>
        </main>
        <!-- End #main -->
</asp:Content>
