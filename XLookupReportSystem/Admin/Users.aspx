<%@ Page Title="Users" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="XLookupReportSystem.Admin.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main id="main" class="main">
        <div class="pagetitle">
            
            <nav>
                <ol class="breadcrumb">
                    <li class="breadcrumb-item"><a href="DashBoard.aspx">Home</a></li>
                    <li class="breadcrumb-item">Admin</li>
                    <li class="breadcrumb-item active">Users</li>
                </ol>
            </nav>
            <div class=" row py-2 flex-wrap">
                     <div class="col-auto me-auto">
                        <h1>Users</h1>
                        
                    </div>
                     <div class="col-auto d-flex align-items-center">
                         <asp:LinkButton ID="AddUsersbtn" CssClass="btn btn-primary" runat="server" OnClick="AddUsersbtn_Click">Add User</asp:LinkButton>
                </div>
            </div>
        </div>
        <section class="section">
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
                                        <h5 class="card-title">Users <%--<span>| Today</span>--%></h5>
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
                                                            <th scope="col" <%--data-sortable=""--%> style="width: 10.9116%;"><a href="#" <%--class="dataTable-sorter"--%>></a></th>
                                                            <th scope="col" <%--data-sortable=""--%> style="width: 10.0331%;"><a href="#" <%--class="dataTable-sorter"--%>>Firstname</a></th>
                                                            <th scope="col" <%--data-sortable=""--%> style="width: 15.1934%;"><a href="#" <%--class="dataTable-sorter"--%>>Surname</a></th>
                                                            <th scope="col" <%--data-sortable=""--%> style="width: 19.80663%;"><a href="#" <%--class="dataTable-sorter"--%>>Email</a></th>
                                                            <th scope="col" <%--data-sortable=""--%> style="width: 15.0552%;"><a href="#" <%--class="dataTable-sorter"--%>>Campus</a></th>
                                                            <th scope="col" <%--data-sortable=""--%> style="width: 14.0552%;"><a href="#" <%--class="dataTable-sorter"--%>>Discipline</a></th>
                                                            <th scope="col" <%--data-sortable=""--%> style="width: 15%;"><a href="#" <%--class="dataTable-sorter"--%>>Role</a></th>
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
                                                            <th scope="row"><a  style="text-decoration:none;color:Highlight" href="EditUser.aspx?id=<%#Eval("Staff_ID") %>">Select</a></th>
                                                            <td><%# Eval("Firstname") %></td>
                                                            <td><%# Eval("Surname") %></td>
                                                            <td><%# Eval("EmailAddress") %> </td>
                                                            <td><%# Eval("Campus") %> </td>
                                                            <td><%# Eval("Discipline") %> </td>
                                                            <td><%# Eval("StaffType") %></td>
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
                                </div>
                            </div>
</div>
        </section>
    </main>
</asp:Content>
