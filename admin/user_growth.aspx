<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="user_growth.aspx.cs" Inherits="admin_user_growth" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Monthly New User Registrations</h2>
        </div>
        <asp:Chart ID="chRegistrations" runat="server" Width="1200" Height="600">
            <Series>
                <asp:Series Name="Registrations" ChartType="Column" BorderWidth="3"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="MainArea"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>

