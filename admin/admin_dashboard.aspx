<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="admin_dashboard.aspx.cs" Inherits="admin_admin_dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container ">
        <div class="dashboard-head">
     <h2>Welcome Back,   <asp:Label ID="lblWelcomeMsg" runat="server" CssClass="welcome-msg" Text=""></asp:Label>!</h2>
 </div>
          
        <div class="user-dashboard-about-service">
            <div class="status-card-container">
                <div class="status-new">
                    <img src="/images/new-icon.png" alt="new icon" />
                    <p>
                        <asp:Label ID="lblnew" runat="server" Text=""></asp:Label>
                    </p>
                    <h5>New Orders</h5>

                </div>
                <div class="status-accept">
                    <img src="/images/accept-icon.png" alt="accept icon" />
                    <p>
                        <asp:Label ID="lblaccept" runat="server" Text=""></asp:Label>
                    </p>
                    <h5>Accepted Orders</h5>


                </div>
                <div class="status-inprocess">
                    <img src="/images/inprocess-icon.png" alt="in process icon" />
                    <p>
                        <asp:Label ID="lblinprocess" runat="server" Text=""></asp:Label>
                    </p>
                    <h5>In Process Orders</h5>


                </div>
                <div class="status-delivered">
                    <img src="/images/delivered-icon.png" alt="delivered icon" />
                    <p>
                        <asp:Label ID="lbldelivered" runat="server" Text=""></asp:Label>
                    </p>
                    <h5>Delivered Orders</h5>



                </div>

            </div>
        </div>
        <div class="imp-cards">
            <div class="Registrations-summary">
                <h3>Customer Registration Summary</h3>
                <table class="summary">
                    <tr>
                     <th> Today  </th>
                        <td>
                           <asp:Label ID="lblTodayRegistration" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th> This Month  </th>
                        <td> <asp:Label ID="lblThisMonthRegistration" runat="server" Text="Label"></asp:Label> </td>
                    </tr>
                    <tr>
                        <th>This Year </th>
                        <td>   <asp:Label ID="lblThisYearRegistration" runat="server" Text="Label"></asp:Label> </td>
                    </tr>
                    <tr>
                        <th> Total registered customers  </th>
                        <td> <asp:Label ID="lblTotalRegistration" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                   
                </table>
  
            </div>

            <div class="Revenue-summary">
                <h3>Revenue Summary</h3>
                <table class="summary">
                    <tr>
                        <th>Revenue Today</th>
                        <td>
                            <asp:Label ID="lblRevenueToday" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th> Revenue this month  </th>
                        <td> <asp:Label ID="lblRevenueThisMonth" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th> Revenue this year </th>
                        <td>    <asp:Label ID="lblRevenueThisYear" runat="server" Text=""></asp:Label> </td>
                    </tr>
                </table>
            </div>

            <div class="most-used-service-graph">
                <h3>Most used Service</h3>
                <div>
                    <asp:Chart ID="Chart1" runat="server" Width="500px" Height="250px">
                        <series>
                            <asp:Series Name="Series1" ChartType="Pie" XValueMember="ServiceName" YValueMembers="UsageCount" IsValueShownAsLabel="true" />
                        </series>
                        <chartareas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </chartareas>
                    </asp:Chart>
                </div>
            </div>

        </div>

    </div>
    
</asp:Content>

