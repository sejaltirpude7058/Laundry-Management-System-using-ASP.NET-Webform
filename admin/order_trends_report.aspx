<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="order_trends_report.aspx.cs" Inherits="admin_order_trends_report" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Laundry Order Reports</h2>
        </div>
        <div class="order-report-container">
            <div class="order-report-container--rowone">
                <div class="postingdate_order_trends">
                    <h5>Order Dates Trends</h5>
                    <asp:Chart ID="chPostingDateOrderTrend" runat="server" Width="1000" >
                        <Series>
                            <asp:Series Name="OrderProgressAnalysis" ChartType="Column" BorderWidth="3"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="MainArea"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                <div class="order-count-summary">
                    <h5>Total Orders</h5>
                    <table class="summary">
                        <tr>
                            <th>Today </th>
                            <td>
                                <asp:Literal ID="liTodayOrders" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>This Week </th>
                            <td>
                                <asp:Literal ID="liThisWeekOrders" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>This Month </th>
                            <td>
                                <asp:Literal ID="liThisMonthOrders" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>This Year </th>
                            <td>
                                <asp:Literal ID="liThisYearOrders" runat="server"></asp:Literal></td>
                        </tr>

                    </table>
                </div>
            </div>
            <div class="order-report-container--rowtwo">
                <div class="order-monthly-trend">
                       <h5>Monthly order Trends</h5>
                    <asp:Chart ID="chMonthlyOrderTrend" runat="server" Width="600" >
                        <Series>
                            <asp:Series Name="MonthlyOrderTrends" ChartType="Column" BorderWidth="3"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="MainArea"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                <div class="revenue-summary">
                    <h5>Revenue Summary</h5>
                    <table class="summary">
                        <tr>
                            <th>Revenue Today</th>
                            <td>

                                <asp:Literal ID="liRevenueToday" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>This Week</th>
                            <td>
                                <asp:Literal ID="liRevenueThisWeek" runat="server"></asp:Literal></td>
                        </tr>
                        <tr>
                            <th>Revenue this month  </th>
                            <td>
                                <asp:Literal ID="liRevenueThisMonth" runat="server"></asp:Literal>
                        </tr>
                        <tr>
                            <th>Revenue this year </th>
                            <td>
                                <asp:Literal ID="liRevenueThisYear" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

