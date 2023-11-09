<%@ Page Title="Projects" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="XLookupReportSystem.Admin.Projects"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main id="main" class="main">
        <div class="pagetitle">
            <h1>Projects</h1>
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                    <li class="breadcrumb-item">Admin</li>
                    <li class="breadcrumb-item active">Projects</li>
                </ol>
            </nav>
        </div>
          <div class="section">
                     <div class="col-auto d-flex align-items-center">
                         <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#largeModal">
                            Combine
                          </button>
                         
                         <div class="modal fade" id="largeModal" tabindex="-1" aria-hidden="true" style="display: none;">
                            <div class="modal-dialog modal-sm">
                              <div class="modal-content">
                                <div class="modal-header">
                                  <h5 class="modal-title">Create Combined Project</h5>
                                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                  <p>Are you sure you want to create new combined project?</p>
                                     
                                 </div>
                                 <div class="modal-footer">
                                              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                                <div class="twoToneCenter">
                                              <asp:Button ID="Combinebtn" CssClass="btn btn-primary" runat="server" Text="Combine" OnClick="Combinebtn_Click"  />
                                                </div>
                                            </div>
                                </div>
                                
                              </div>
                            </div>
                          </div>
                     </div>

         <section class="section">
            <div class="row">
               <asp:ListView ID="listViewProjects" runat="server">
                         <EmptyDataTemplate>
                              <div id="NoRecords" runat="server">
                                No records are available.
                              </div>
                         </EmptyDataTemplate>
                    <ItemTemplate>
                        <div class="col-lg-3">
                            <asp:CheckBox ID="chkItem" runat="server" />

                        <a style="text-decoration:none;" href="ProjectView.aspx?ProjID=<%#Eval("Project_ID") %>">
                         <div class="card">
                            <img src="../../Assets/img/card.jpg" class="card-img-top" alt="..." />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("ProjectName") %></h5>
                                <p class="card-text">Semester <%# Eval("ProjectSemester") %> - <%# Eval("ProjectYear") %></p>
                                <p class="card-text"><%# Eval("ModuleCode") %></p>
                            </div>
                         </div>
                        </a>
                            </div>
                    </ItemTemplate>
                       
        </asp:ListView>
            </div>
        </section>
       <%-- <section class="section">
            <div class="row">
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Example Card</h5>
                            <p>This is an examle page with no contrnt. You can use it as a starter for your custom pages.</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">Example Card</h5>
                            <p>This is an examle page with no contrnt. You can use it as a starter for your custom pages.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>--%>
    </main>
</asp:Content>
