<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="service_wise_laundry_orders.aspx.cs" Inherits="admin_service_wise_laundry_orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Service Wise Laundry Orders</h2>
        </div>
        <div class="grid-container">
            <div class="grid-top">
                <div class="filter-dropdowns-date-filter">
                    From: 
                  <input id="txtFromDate" type="date" runat="server" class="form-control" />

                    To:
                  <input id="txtToDate" type="date" runat="server" class="form-control" />

                    <asp:Button ID="btnfilterDate" runat="server" CssClass="btn btn-primary" Text="Apply filter" OnClick="btnfilterDate_Click" />
                </div>
                <div>
                    Service Type: 
      <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="form-control service-filter" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged">
      </asp:DropDownList>
                </div>
            </div>
            <div class="grid-wrapper">
                <asp:GridView ID="gvServiceWiseOrders" runat="server" AutoGenerateColumns="false" CssClass="my-grid" HeaderStyle-CssClass="grid-header">
                    <Columns>
                        <asp:BoundField DataField="ServiceID" HeaderText="" Visible="false" />
                        <asp:BoundField DataField="ServiceName" HeaderText="Service Type" />
                        <asp:BoundField DataField="TotalOrders" HeaderText="Total Orders" />
                        <asp:BoundField DataField="TotalClothes" HeaderText="Total Clothes" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

