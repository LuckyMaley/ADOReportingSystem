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
                            <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#largeModal">
                            Delete
                          </button>
                         
                         <div class="modal fade" id="largeModal" tabindex="-1" aria-hidden="true" style="display: none;">
                            <div class="modal-dialog modal-sm">
                              <div class="modal-content">
                                <div class="modal-header">
                                  <h5 class="modal-title">Delete Project</h5>
                                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                  <p>Are you sure you want to delete project?</p>
                                     
                                 </div>
                                 <div class="modal-footer">
                                     
                                              <button type="button" class="btn btn-secondary" id="closeModal"  data-bs-dismiss="modal">Close</button>
                                                <div class="twoToneCenter">
                                              <asp:Button ID="Deletebtn" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="Deletebtn_Click"   />
                                                </div>
                                            </div>
                                </div>
                                
                              </div>
                            </div>
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
                        <div class="row">
                            <div class="col-xxl-4 col-md-6">
                                <div class="card info-card sales-card">
                                    
                                    <div class="card-body">
                                        <h5 class="card-title">Students</h5>
                                        <div class="d-flex align-items-center align-content-center ps-3">
                                            <h4 ><asp:Label ID="Studentslb" runat="server" Text="Label"></asp:Label></h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xxl-4 col-md-6">
                                <div class="card info-card revenue-card">
                                    
                                    <div class="card-body">
                                        <h5 class="card-title">SI Students</h5>
                                        <div class="d-flex align-items-center align-content-center ps-3">
                                                <h4 ><asp:Label ID="SIStudentlb" runat="server" Text="Label"></asp:Label></h4>         
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xxl-4 col-xl-12">
                                <div class="card info-card customers-card">
                                    
                                    <div class="card-body">
                                        <h5 class="card-title">Non-SI Students</h5>
                                        <div class="d-flex align-items-center align-content-center ps-3">
                                            <h4><asp:Label ID="NonSIStudentlb" runat="server" Text="Label"></asp:Label></h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="row">
                   <div class="col-12">
                                <div class="card recent-sales overflow-auto">
                                   <%-- <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                        <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                            <li class="dropdown-header text-start">
                                                <h6>Filter</h6>
                                            </li>
                                            <li><a class="dropdown-item" href="#">Today</a></li>
                                            <li><a class="dropdown-item" href="#">This Month</a></li>
                                            <li><a class="dropdown-item" href="#">This Year</a></li>
                                        </ul>
                                    </div>--%>
                                    <div class="card-body">
                                        <h5 class="card-title">Overview <%--<span>| Today</span>--%></h5>
                                        

                                          <!-- Bordered Tabs -->
                                          <ul class="nav nav-tabs nav-tabs-bordered" id="borderedTab" role="tablist">
                                            <li class="nav-item" role="presentation">
                                              <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#bordered-home" type="button" role="tab" aria-controls="home" aria-selected="true">Marks</button>
                                            </li>
                                            <li class="nav-item" role="presentation">
                                              <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#bordered-profile" type="button" role="tab" aria-controls="profile" aria-selected="false" tabindex="-1">Risk Codes</button>
                                            </li>
                                            <%--<li class="nav-item" role="presentation">
                                              <button class="nav-link" id="contact-tab" data-bs-toggle="tab" data-bs-target="#bordered-contact" type="button" role="tab" aria-controls="contact" aria-selected="false" tabindex="-1">Contact</button>
                                            </li>--%>
                                          </ul>
                                          <div class="tab-content pt-2" id="borderedTabContent">
                                            <div class="tab-pane fade active show" id="bordered-home" role="tabpanel" aria-labelledby="home-tab">
                                                 <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                                                <%--<div class="dataTable-top">
                                                    <div class="dataTable-dropdown">
                                                        <label>
                                                            <select class="dataTable-selector">
                                                                <option value="5">5</option>
                                                                <option value="10" selected="">10</option>
                                                                <option value="15">15</option>
                                                                <option value="20">20</option>
                                                                <option value="25">25</option>
                                                            </select>
                                                            entries per page</label></div>
                                                    <div class="dataTable-search">
                                                        <input class="dataTable-input" placeholder="Search..." type="text"/></div>
                                                </div>--%>
                                                <div class="dataTable-container">
                                                    <table class="table table-borderless datatable dataTable-table">
                                                        <thead>
                                                            <tr>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 14.9116%;"><a href="#" <%--class="dataTable-sorter"--%>>Student Number</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 20.0331%;"><a href="#" <%--class="dataTable-sorter"--%>>Firstname</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 19.1934%;"><a href="#" <%--class="dataTable-sorter"--%>>Surname</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 15.80663%;"><a href="#" <%--class="dataTable-sorter"--%>>Main Exam Mark</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 15.0552%;"><a href="#" <%--class="dataTable-sorter"--%>>Supp Exam Mark</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 15%;"><a href="#" <%--class="dataTable-sorter"--%>>Supp Exam Mark</a></th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listViewProjects" runat="server">
                                                                 <EmptyDataTemplate>
                                                                     <tr>
                                                                         <td>
                                                                     <div >
                                                                      <div id="NoRecords" class="align-items-center" runat="server">
                                                                        No records are available.
                                                                      </div>
                                                                     </div>
                                                                         </td>
                                                                     </tr>
                                                                 </EmptyDataTemplate>
                                                            <ItemTemplate>
                                                            <tr>
                                                                <th scope="row"><%#Eval("StudentNumber") %></th>
                                                                <td><%# Eval("FirstName") %></td>
                                                                <td><%# Eval("Surname") %></td>
                                                                <td><%# Eval("ITSMainExamfinalMark") %>% </td>
                                                                <td><%# Eval("SuppMark") %>%</td>
                                                                <td><%# Eval("FinalMark") %>%</td>
                                                            </tr>
                                                                </ItemTemplate>
                       
                                                               </asp:ListView>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="dataTable-bottom">
                                                    <%--<div class="dataTable-info"><a href="Projects.aspx">View more projects</a></div>
                                                    <nav class="dataTable-pagination">
                                                        <ul class="dataTable-pagination-list"></ul>
                                                    </nav>--%>
                                                </div>
                                            </div>
                                            </div>
                                            <div class="tab-pane fade" id="bordered-profile" role="tabpanel" aria-labelledby="profile-tab">
                                             <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                                                <%--<div class="dataTable-top">
                                                    <div class="dataTable-dropdown">
                                                        <label>
                                                            <select class="dataTable-selector">
                                                                <option value="5">5</option>
                                                                <option value="10" selected="">10</option>
                                                                <option value="15">15</option>
                                                                <option value="20">20</option>
                                                                <option value="25">25</option>
                                                            </select>
                                                            entries per page</label></div>
                                                    <div class="dataTable-search">
                                                        <input class="dataTable-input" placeholder="Search..." type="text"/></div>
                                                </div>--%>
                                                <div class="dataTable-container">
                                                    <table class="table table-borderless datatable dataTable-table">
                                                        <thead>
                                                            <tr>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 14.9116%;"><a href="#" <%--class="dataTable-sorter"--%>>Student Number</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 17.0331%;"><a href="#" <%--class="dataTable-sorter"--%>>Firstname</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 17.1934%;"><a href="#" <%--class="dataTable-sorter"--%>>Surname</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 10.80663%;"><a href="#" <%--class="dataTable-sorter"--%>>Risk Code</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 15.0552%;"><a href="#" <%--class="dataTable-sorter"--%>>Beginning</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 10%;"><a href="#" <%--class="dataTable-sorter"--%>>Risk Code</a></th>
                                                                <th scope="col" <%--data-sortable=""--%> style="width: 15%;"><a href="#" <%--class="dataTable-sorter"--%>>End</a></th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:ListView ID="listView1" runat="server">
                                                                 <EmptyDataTemplate>
                                                                     <tr>
                                                                         <td>
                                                                     <div >
                                                                      <div id="NoRecords" class="align-items-center" runat="server">
                                                                        No records are available.
                                                                      </div>
                                                                     </div>
                                                                         </td>
                                                                     </tr>
                                                                 </EmptyDataTemplate>
                                                            <ItemTemplate>
                                                            <tr>
                                                                <th scope="row"><%#Eval("StudentNumber") %></th>
                                                                <td><%# Eval("FirstName") %></td>
                                                                <td><%# Eval("Surname") %></td>
                                                                <td><%# Eval("Risk_Code_Beg") %> </td>
                                                                <td><%# Eval("Code_Beg") %></td>
                                                                <td><%# Eval("Risk_Code_End") %></td>
                                                                <td><%# Eval("Code_End") %></td>
                                                            </tr>
                                                                </ItemTemplate>
                       
                                                               </asp:ListView>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div class="dataTable-bottom">
                                                    <%--<div class="dataTable-info"><a href="Projects.aspx">View more projects</a></div>
                                                    <nav class="dataTable-pagination">
                                                        <ul class="dataTable-pagination-list"></ul>
                                                    </nav>--%>
                                                </div>
                                            </div>
                                            </div>
<%--                                            <div class="tab-pane fade" id="bordered-contact" role="tabpanel" aria-labelledby="contact-tab">
                                              Saepe animi et soluta ad odit soluta sunt. Nihil quos omnis animi debitis cumque. Accusantium quibusdam perspiciatis qui qui omnis magnam. Officiis accusamus impedit molestias nostrum veniam. Qui amet ipsum iure. Dignissimos fuga tempore dolor.
                                            </div>--%>
                                          </div><!-- End Bordered Tabs -->

                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
        </main>
        <!-- End #main -->
</asp:Content>
