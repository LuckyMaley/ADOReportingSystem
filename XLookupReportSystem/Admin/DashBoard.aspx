<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="CommanderWebsite.Admin.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">	
    	
      .apexcharts-legend {	
        display: flex;	
        overflow: auto;	
        padding: 0 10px;	
      }	
      .apexcharts-legend.apx-legend-position-bottom, .apexcharts-legend.apx-legend-position-top {	
        flex-wrap: wrap	
      }	
      .apexcharts-legend.apx-legend-position-right, .apexcharts-legend.apx-legend-position-left {	
        flex-direction: column;	
        bottom: 0;	
      }	
      .apexcharts-legend.apx-legend-position-bottom.apexcharts-align-left, .apexcharts-legend.apx-legend-position-top.apexcharts-align-left, .apexcharts-legend.apx-legend-position-right, .apexcharts-legend.apx-legend-position-left {	
        justify-content: flex-start;	
      }	
      .apexcharts-legend.apx-legend-position-bottom.apexcharts-align-center, .apexcharts-legend.apx-legend-position-top.apexcharts-align-center {	
        justify-content: center;  	
      }	
      .apexcharts-legend.apx-legend-position-bottom.apexcharts-align-right, .apexcharts-legend.apx-legend-position-top.apexcharts-align-right {	
        justify-content: flex-end;	
      }	
      .apexcharts-legend-series {	
        cursor: pointer;	
        line-height: normal;	
      }	
      .apexcharts-legend.apx-legend-position-bottom .apexcharts-legend-series, .apexcharts-legend.apx-legend-position-top .apexcharts-legend-series{	
        display: flex;	
        align-items: center;	
      }	
      .apexcharts-legend-text {	
        position: relative;	
        font-size: 14px;	
      }	
      .apexcharts-legend-text *, .apexcharts-legend-marker * {	
        pointer-events: none;	
      }	
      .apexcharts-legend-marker {	
        position: relative;	
        display: inline-block;	
        cursor: pointer;	
        margin-right: 3px;	
        border-style: solid;
      }	
      	
      .apexcharts-legend.apexcharts-align-right .apexcharts-legend-series, .apexcharts-legend.apexcharts-align-left .apexcharts-legend-series{	
        display: inline-block;	
      }	
      .apexcharts-legend-series.apexcharts-no-click {	
        cursor: auto;	
      }	
      .apexcharts-legend .apexcharts-hidden-zero-series, .apexcharts-legend .apexcharts-hidden-null-series {	
        display: none !important;	
      }	
      .apexcharts-inactive-legend {	
        opacity: 0.45;	
      }</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <main id="main" class="main">
            <div class="pagetitle">
                <h1>Dashboard</h1>
                <nav>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                        <li class="breadcrumb-item active">Dashboard</li>
                    </ol>
                </nav>
            </div>
            <section class="section dashboard">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="row">
                            <div class="col-xxl-4 col-md-6">
                                <div class="card info-card sales-card">
                                    <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                        <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                            <li class="dropdown-header text-start">
                                                <h6>Filter</h6>
                                            </li>
                                            <li><a class="dropdown-item" href="#">Today</a></li>
                                            <li><a class="dropdown-item" href="#">This Month</a></li>
                                            <li><a class="dropdown-item" href="#">This Year</a></li>
                                        </ul>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Sales <span>| Today</span></h5>
                                        <div class="d-flex align-items-center">
                                            <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"><i class="bi bi-cart"></i></div>
                                            <div class="ps-3">
                                                <h6>145</h6>
                                                <span class="text-success small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">increase</span></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xxl-4 col-md-6">
                                <div class="card info-card revenue-card">
                                    <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                        <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                            <li class="dropdown-header text-start">
                                                <h6>Filter</h6>
                                            </li>
                                            <li><a class="dropdown-item" href="#">Today</a></li>
                                            <li><a class="dropdown-item" href="#">This Month</a></li>
                                            <li><a class="dropdown-item" href="#">This Year</a></li>
                                        </ul>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Revenue <span>| This Month</span></h5>
                                        <div class="d-flex align-items-center">
                                            <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"><i class="bi bi-currency-dollar"></i></div>
                                            <div class="ps-3">
                                                <h6>$3,264</h6>
                                                <span class="text-success small pt-1 fw-bold">8%</span> <span class="text-muted small pt-2 ps-1">increase</span></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xxl-4 col-xl-12">
                                <div class="card info-card customers-card">
                                    <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                        <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                            <li class="dropdown-header text-start">
                                                <h6>Filter</h6>
                                            </li>
                                            <li><a class="dropdown-item" href="#">Today</a></li>
                                            <li><a class="dropdown-item" href="#">This Month</a></li>
                                            <li><a class="dropdown-item" href="#">This Year</a></li>
                                        </ul>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Customers <span>| This Year</span></h5>
                                        <div class="d-flex align-items-center">
                                            <div class="card-icon rounded-circle d-flex align-items-center justify-content-center"><i class="bi bi-people"></i></div>
                                            <div class="ps-3">
                                                <h6>1244</h6>
                                                <span class="text-danger small pt-1 fw-bold">12%</span> <span class="text-muted small pt-2 ps-1">decrease</span></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="card">
                                    <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                        <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                            <li class="dropdown-header text-start">
                                                <h6>Filter</h6>
                                            </li>
                                            <li><a class="dropdown-item" href="#">Today</a></li>
                                            <li><a class="dropdown-item" href="#">This Month</a></li>
                                            <li><a class="dropdown-item" href="#">This Year</a></li>
                                        </ul>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Reports <span>/Today</span></h5>
                                        <div id="reportsChart" style="min-height: 365px;">
                                            
                                        </div>
                                        <script>document.addEventListener("DOMContentLoaded", () => {
                      new ApexCharts(document.querySelector("#reportsChart"), {
                        series: [{
                          name: 'Sales',
                          data: [31, 40, 28, 51, 42, 82, 56],
                        }, {
                          name: 'Revenue',
                          data: [11, 32, 45, 32, 34, 52, 41]
                        }, {
                          name: 'Customers',
                          data: [15, 11, 32, 18, 9, 24, 11]
                        }],
                        chart: {
                          height: 350,
                          type: 'area',
                          toolbar: {
                            show: false
                          },
                        },
                        markers: {
                          size: 4
                        },
                        colors: ['#4154f1', '#2eca6a', '#ff771d'],
                        fill: {
                          type: "gradient",
                          gradient: {
                            shadeIntensity: 1,
                            opacityFrom: 0.3,
                            opacityTo: 0.4,
                            stops: [0, 90, 100]
                          }
                        },
                        dataLabels: {
                          enabled: false
                        },
                        stroke: {
                          curve: 'smooth',
                          width: 2
                        },
                        xaxis: {
                          type: 'datetime',
                          categories: ["2018-09-19T00:00:00.000Z", "2018-09-19T01:30:00.000Z", "2018-09-19T02:30:00.000Z", "2018-09-19T03:30:00.000Z", "2018-09-19T04:30:00.000Z", "2018-09-19T05:30:00.000Z", "2018-09-19T06:30:00.000Z"]
                        },
                        tooltip: {
                          x: {
                            format: 'dd/MM/yy HH:mm'
                          },
                        }
                      }).render();
                    });</script>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="card recent-sales overflow-auto">
                                    <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                        <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                            <li class="dropdown-header text-start">
                                                <h6>Filter</h6>
                                            </li>
                                            <li><a class="dropdown-item" href="#">Today</a></li>
                                            <li><a class="dropdown-item" href="#">This Month</a></li>
                                            <li><a class="dropdown-item" href="#">This Year</a></li>
                                        </ul>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Recent Sales <span>| Today</span></h5>
                                        <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                                            <div class="dataTable-top">
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
                                            </div>
                                            <div class="dataTable-container">
                                                <table class="table table-borderless datatable dataTable-table">
                                                    <thead>
                                                        <tr>
                                                            <th scope="col" data-sortable="" style="width: 10.9116%;"><a href="#" class="dataTable-sorter">#</a></th>
                                                            <th scope="col" data-sortable="" style="width: 24.0331%;"><a href="#" class="dataTable-sorter">Customer</a></th>
                                                            <th scope="col" data-sortable="" style="width: 40.1934%;"><a href="#" class="dataTable-sorter">Product</a></th>
                                                            <th scope="col" data-sortable="" style="width: 9.80663%;"><a href="#" class="dataTable-sorter">Price</a></th>
                                                            <th scope="col" data-sortable="" style="width: 15.0552%;"><a href="#" class="dataTable-sorter">Status</a></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <th scope="row"><a href="#">#2457</a></th>
                                                            <td>Brandon Jacob</td>
                                                            <td><a href="#" class="text-primary">At praesentium minu</a></td>
                                                            <td>$64</td>
                                                            <td><span class="badge bg-success">Approved</span></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row"><a href="#">#2147</a></th>
                                                            <td>Bridie Kessler</td>
                                                            <td><a href="#" class="text-primary">Blanditiis dolor omnis similique</a></td>
                                                            <td>$47</td>
                                                            <td><span class="badge bg-warning">Pending</span></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row"><a href="#">#2049</a></th>
                                                            <td>Ashleigh Langosh</td>
                                                            <td><a href="#" class="text-primary">At recusandae consectetur</a></td>
                                                            <td>$147</td>
                                                            <td><span class="badge bg-success">Approved</span></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row"><a href="#">#2644</a></th>
                                                            <td>Angus Grady</td>
                                                            <td><a href="#" class="text-primar">Ut voluptatem id earum et</a></td>
                                                            <td>$67</td>
                                                            <td><span class="badge bg-danger">Rejected</span></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row"><a href="#">#2644</a></th>
                                                            <td>Raheem Lehner</td>
                                                            <td><a href="#" class="text-primary">Sunt similique distinctio</a></td>
                                                            <td>$165</td>
                                                            <td><span class="badge bg-success">Approved</span></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="dataTable-bottom">
                                                <div class="dataTable-info">Showing 1 to 5 of 5 entries</div>
                                                <nav class="dataTable-pagination">
                                                    <ul class="dataTable-pagination-list"></ul>
                                                </nav>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="card top-selling overflow-auto">
                                    <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                        <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                            <li class="dropdown-header text-start">
                                                <h6>Filter</h6>
                                            </li>
                                            <li><a class="dropdown-item" href="#">Today</a></li>
                                            <li><a class="dropdown-item" href="#">This Month</a></li>
                                            <li><a class="dropdown-item" href="#">This Year</a></li>
                                        </ul>
                                    </div>
                                    <div class="card-body pb-0">
                                        <h5 class="card-title">Top Selling <span>| Today</span></h5>
                                        <table class="table table-borderless">
                                            <thead>
                                                <tr>
                                                    <th scope="col">Preview</th>
                                                    <th scope="col">Product</th>
                                                    <th scope="col">Price</th>
                                                    <th scope="col">Sold</th>
                                                    <th scope="col">Revenue</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <th scope="row"><a href="#">
                                                        <img src="../Assets/img/product-1.jpg" alt=""/></a></th>
                                                    <td><a href="#" class="text-primary fw-bold">Ut inventore ipsa voluptas nulla</a></td>
                                                    <td>$64</td>
                                                    <td class="fw-bold">124</td>
                                                    <td>$5,828</td>
                                                </tr>
                                                <tr>
                                                    <th scope="row"><a href="#">
                                                        <img src="../Assets/img/product-2.jpg" alt=""/></a></th>
                                                    <td><a href="#" class="text-primary fw-bold">Exercitationem similique doloremque</a></td>
                                                    <td>$46</td>
                                                    <td class="fw-bold">98</td>
                                                    <td>$4,508</td>
                                                </tr>
                                                <tr>
                                                    <th scope="row"><a href="#">
                                                        <img src="../Assets/img/product-3.jpg" alt=""/></a></th>
                                                    <td><a href="#" class="text-primary fw-bold">Doloribus nisi exercitationem</a></td>
                                                    <td>$59</td>
                                                    <td class="fw-bold">74</td>
                                                    <td>$4,366</td>
                                                </tr>
                                                <tr>
                                                    <th scope="row"><a href="#">
                                                        <img src="../Assets/img/product-4.jpg" alt=""/></a></th>
                                                    <td><a href="#" class="text-primary fw-bold">Officiis quaerat sint rerum error</a></td>
                                                    <td>$32</td>
                                                    <td class="fw-bold">63</td>
                                                    <td>$2,016</td>
                                                </tr>
                                                <tr>
                                                    <th scope="row"><a href="#">
                                                        <img src="../Assets/img/product-5.jpg" alt=""/></a></th>
                                                    <td><a href="#" class="text-primary fw-bold">Sit unde debitis delectus repellendus</a></td>
                                                    <td>$79</td>
                                                    <td class="fw-bold">41</td>
                                                    <td>$3,239</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="card">
                            <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                    <li class="dropdown-header text-start">
                                        <h6>Filter</h6>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Today</a></li>
                                    <li><a class="dropdown-item" href="#">This Month</a></li>
                                    <li><a class="dropdown-item" href="#">This Year</a></li>
                                </ul>
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Recent Activity <span>| Today</span></h5>
                                <div class="activity">
                                    <div class="activity-item d-flex">
                                        <div class="activite-label">32 min</div>
                                        <i class="bi bi-circle-fill activity-badge text-success align-self-start"></i>
                                        <div class="activity-content">Quia quae rerum <a href="#" class="fw-bold text-dark">explicabo officiis</a> beatae</div>
                                    </div>
                                    <div class="activity-item d-flex">
                                        <div class="activite-label">56 min</div>
                                        <i class="bi bi-circle-fill activity-badge text-danger align-self-start"></i>
                                        <div class="activity-content">Voluptatem blanditiis blanditiis eveniet</div>
                                    </div>
                                    <div class="activity-item d-flex">
                                        <div class="activite-label">2 hrs</div>
                                        <i class="bi bi-circle-fill activity-badge text-primary align-self-start"></i>
                                        <div class="activity-content">Voluptates corrupti molestias voluptatem</div>
                                    </div>
                                    <div class="activity-item d-flex">
                                        <div class="activite-label">1 day</div>
                                        <i class="bi bi-circle-fill activity-badge text-info align-self-start"></i>
                                        <div class="activity-content">Tempore autem saepe <a href="#" class="fw-bold text-dark">occaecati voluptatem</a> tempore</div>
                                    </div>
                                    <div class="activity-item d-flex">
                                        <div class="activite-label">2 days</div>
                                        <i class="bi bi-circle-fill activity-badge text-warning align-self-start"></i>
                                        <div class="activity-content">Est sit eum reiciendis exercitationem</div>
                                    </div>
                                    <div class="activity-item d-flex">
                                        <div class="activite-label">4 weeks</div>
                                        <i class="bi bi-circle-fill activity-badge text-muted align-self-start"></i>
                                        <div class="activity-content">Dicta dolorem harum nulla eius. Ut quidem quidem sit quas</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card">
                            <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                    <li class="dropdown-header text-start">
                                        <h6>Filter</h6>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Today</a></li>
                                    <li><a class="dropdown-item" href="#">This Month</a></li>
                                    <li><a class="dropdown-item" href="#">This Year</a></li>
                                </ul>
                            </div>
                            <div class="card-body pb-0">
                                <h5 class="card-title">Budget Report <span>| This Month</span></h5>
                                <div id="budgetChart" style="min-height: 400px; user-select: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0);" class="echart" _echarts_instance_="ec_1673634820264">
                                    <div style="position: relative; width: 330px; height: 400px; padding: 0px; margin: 0px; border-width: 0px;">
                                        <canvas data-zr-dom-id="zr_0" width="412" height="500" style="position: absolute; left: 0px; top: 0px; width: 330px; height: 400px; user-select: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); padding: 0px; margin: 0px; border-width: 0px;"></canvas>
                                    </div>
                                </div>
                                <script>document.addEventListener("DOMContentLoaded", () => {
                  var budgetChart = echarts.init(document.querySelector("#budgetChart")).setOption({
                    legend: {
                      data: ['Allocated Budget', 'Actual Spending']
                    },
                    radar: {
                      // shape: 'circle',
                      indicator: [{
                          name: 'Sales',
                          max: 6500
                        },
                        {
                          name: 'Administration',
                          max: 16000
                        },
                        {
                          name: 'Information Technology',
                          max: 30000
                        },
                        {
                          name: 'Customer Support',
                          max: 38000
                        },
                        {
                          name: 'Development',
                          max: 52000
                        },
                        {
                          name: 'Marketing',
                          max: 25000
                        }
                      ]
                    },
                    series: [{
                      name: 'Budget vs spending',
                      type: 'radar',
                      data: [{
                          value: [4200, 3000, 20000, 35000, 50000, 18000],
                          name: 'Allocated Budget'
                        },
                        {
                          value: [5000, 14000, 28000, 26000, 42000, 21000],
                          name: 'Actual Spending'
                        }
                      ]
                    }]
                  });
                });</script>
                            </div>
                        </div>
                        <div class="card">
                            <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                    <li class="dropdown-header text-start">
                                        <h6>Filter</h6>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Today</a></li>
                                    <li><a class="dropdown-item" href="#">This Month</a></li>
                                    <li><a class="dropdown-item" href="#">This Year</a></li>
                                </ul>
                            </div>
                            <div class="card-body pb-0">
                                <h5 class="card-title">Website Traffic <span>| Today</span></h5>
                                <div id="trafficChart" style="min-height: 400px; user-select: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); position: relative;" class="echart" _echarts_instance_="ec_1673634820265">
                                    <div style="position: relative; width: 330px; height: 400px; padding: 0px; margin: 0px; border-width: 0px;">
                                        <canvas data-zr-dom-id="zr_0" width="412" height="500" style="position: absolute; left: 0px; top: 0px; width: 330px; height: 400px; user-select: none; -webkit-tap-highlight-color: rgba(0, 0, 0, 0); padding: 0px; margin: 0px; border-width: 0px;"></canvas>
                                    </div>
                                    <div class=""></div>
                                </div>
                                <script>document.addEventListener("DOMContentLoaded", () => {
                  echarts.init(document.querySelector("#trafficChart")).setOption({
                    tooltip: {
                      trigger: 'item'
                    },
                    legend: {
                      top: '5%',
                      left: 'center'
                    },
                    series: [{
                      name: 'Access From',
                      type: 'pie',
                      radius: ['40%', '70%'],
                      avoidLabelOverlap: false,
                      label: {
                        show: false,
                        position: 'center'
                      },
                      emphasis: {
                        label: {
                          show: true,
                          fontSize: '18',
                          fontWeight: 'bold'
                        }
                      },
                      labelLine: {
                        show: false
                      },
                      data: [{
                          value: 1048,
                          name: 'Search Engine'
                        },
                        {
                          value: 735,
                          name: 'Direct'
                        },
                        {
                          value: 580,
                          name: 'Email'
                        },
                        {
                          value: 484,
                          name: 'Union Ads'
                        },
                        {
                          value: 300,
                          name: 'Video Ads'
                        }
                      ]
                    }]
                  });
                });</script>
                            </div>
                        </div>
                        <div class="card">
                            <div class="filter"><a class="icon" href="#" data-bs-toggle="dropdown"><i class="bi bi-three-dots"></i></a>
                                <ul class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
                                    <li class="dropdown-header text-start">
                                        <h6>Filter</h6>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Today</a></li>
                                    <li><a class="dropdown-item" href="#">This Month</a></li>
                                    <li><a class="dropdown-item" href="#">This Year</a></li>
                                </ul>
                            </div>
                            <div class="card-body pb-0">
                                <h5 class="card-title">News &amp; Updates <span>| Today</span></h5>
                                <div class="news">
                                    <div class="post-item clearfix">
                                        <img src="../Assets/img/news-1.jpg" alt=""/><h4><a href="#">Nihil blanditiis at in nihil autem</a></h4>
                                        <p>Sit recusandae non aspernatur laboriosam. Quia enim eligendi sed ut harum...</p>
                                    </div>
                                    <div class="post-item clearfix">
                                        <img src="../Assets/img/news-2.jpg" alt=""/><h4><a href="#">Quidem autem et impedit</a></h4>
                                        <p>Illo nemo neque maiores vitae officiis cum eum turos elan dries werona nande...</p>
                                    </div>
                                    <div class="post-item clearfix">
                                        <img src="../Assets/img/news-3.jpg" alt=""/><h4><a href="#">Id quia et et ut maxime similique occaecati ut</a></h4>
                                        <p>Fugiat voluptas vero eaque accusantium eos. Consequuntur sed ipsam et totam...</p>
                                    </div>
                                    <div class="post-item clearfix">
                                        <img src="../Assets/img/news-4.jpg" alt=""/><h4><a href="#">Laborum corporis quo dara net para</a></h4>
                                        <p>Qui enim quia optio. Eligendi aut asperiores enim repellendusvel rerum cuder...</p>
                                    </div>
                                    <div class="post-item clearfix">
                                        <img src="../Assets/img/news-5.jpg" alt=""/><h4><a href="#">Et dolores corrupti quae illo quod dolor</a></h4>
                                        <p>Odit ut eveniet modi reiciendis. Atque cupiditate libero beatae dignissimos eius...</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </main>
        <!-- End #main -->
</asp:Content>
