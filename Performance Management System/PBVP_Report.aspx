<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PBVP_Report.aspx.vb" Inherits="Performance_Management_System.PBVP_Report" %>




<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <style>
        body {
            background-color: #1e2b36;
            color: white;
        }
        .dashboard-section {
            padding: 20px;
        }
        .card {
            background-color: #2e3b4e;
            border: none;
            margin-bottom: 20px;
        }
        .chart-container {
            position: relative;
            height: 300px;
        }
        .table-dark td, .table-dark th {
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <!-- Financial Section -->
                <div class="col-md-6 dashboard-section">
                    <div class="card p-3">
                        <h4>Liens</h4>
                        <div class="d-flex justify-content-around text-center">
                            <div>$1,098<br /><small>Apr 2011</small></div>
                            <div>$8,210<br /><small>Jun 2012</small></div>
                            <div>$590<br /><small>Jan 2013</small></div>
                            <div>$1,700<br /><small>Feb 2013</small></div>
                            <div>$3,000<br /><small>May 2013</small></div>
                        </div>
                    </div>

                    <div class="card p-3">
                        <h4>Value of Total Public Assets</h4>
                        <div class="chart-container">
                            <canvas id="assetValueChart"></canvas>
                        </div>
                    </div>

                    <div class="card p-3">
                        <h4>Properties</h4>
                        <table class="table table-dark table-sm">
                            <thead>
                                <tr>
                                    <th>City</th>
                                    <th>Address</th>
                                    <th>Names</th>
                                    <th>Purchase Date</th>
                                    <th>Sold Date</th>
                                    <th>Events</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>New York</td>
                                    <td>127 73rd St</td>
                                    <td>Peter Jones</td>
                                    <td>Feb 2, 2010</td>
                                    <td>Dec 3, 2012</td>
                                    <td>Mortgage, Refinancing, 2 Liens</td>
                                </tr>
                                <tr>
                                    <td>Long Island</td>
                                    <td>1 Mulch St</td>
                                    <td>Peter & Beaty Jones</td>
                                    <td>Jan 3, 2013</td>
                                    <td>Not sold</td>
                                    <td>Mortgage, 3 Liens</td>
                                </tr>
                                <tr>
                                    <td>Niagara Falls</td>
                                    <td>3053 Lincoln St</td>
                                    <td>Beaty Jones</td>
                                    <td>Mar 2, 2017</td>
                                    <td>Not sold</td>
                                    <td>-</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- Political Section -->
                <div class="col-md-6 dashboard-section">
                    <div class="card p-3">
                        <h4>Political Donations</h4>
                        <div class="chart-container">
                            <canvas id="donationChart"></canvas>
                        </div>
                    </div>
                    <div class="card p-3">
                        <h4>Partisan Leanings</h4>
                        <div class="chart-container">
                            <canvas id="leaningChart"></canvas>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        // Asset Value Chart
        new Chart(document.getElementById('assetValueChart'), {
            type: 'line',
            data: {
                labels: [2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016],
                datasets: [{
                    label: 'Asset Value',
                    data: [1200000, 800000, 500000, 600000, 950000, 1100000, 750000, 800000, 850000, 900000, 1000000, 1300000],
                    borderColor: '#00bcd4',
                    backgroundColor: 'transparent'
                }]
            }
        });

        // Donations Bar Chart
        new Chart(document.getElementById('donationChart'), {
            type: 'bar',
            data: {
                labels: [1990, 1992, 1994, 1996, 1998, 2000, 2002, 2004, 2006, 2008, 2010, 2012, 2014, 2016],
                datasets: [
                    {
                        label: 'Democrat',
                        data: [0, 0, 0, 0, 5000, 15000, 25000, 35000, 45000, 40000, 35000, 30000, 20000, 25000],
                        backgroundColor: '#00e5ff'
                    },
                    {
                        label: 'Republican',
                        data: [0, 0, 0, 0, 4000, 12000, 22000, 30000, 37000, 30000, 25000, 20000, 10000, 18000],
                        backgroundColor: '#ff4081'
                    },
                    {
                        label: 'PACs',
                        data: [0, 0, 0, 0, 2000, 5000, 10000, 12000, 18000, 25000, 30000, 32000, 35000, 37000],
                        backgroundColor: '#ce93d8'
                    }
                ]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        stacked: true
                    },
                    y: {
                        stacked: true
                    }
                }
            }
        });

        // Partisan Leaning Pie Chart
        new Chart(document.getElementById('leaningChart'), {
            type: 'doughnut',
            data: {
                labels: ['Republican', 'Democrat', 'PACs'],
                datasets: [{
                    data: [32, 45, 23],
                    backgroundColor: ['#29b6f6', '#ab47bc', '#ffd54f']
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'bottom',
                        labels: { color: 'white' }
                    }
                }
            }
        });
    </script>
</body>
</html>
