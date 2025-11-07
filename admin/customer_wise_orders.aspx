<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="customer_wise_orders.aspx.cs" Inherits="admin_customer_wise_orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Customer Wise Laundry Orders</h2>
        </div>
        <div class="grid-container">
            <div class="filter-dropdowns">
                              <div>
      Order Status: 
      <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="form-control"
          OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
        
          <asp:ListItem Text="All" Value=""></asp:ListItem>
          <asp:ListItem Text="New" Value="New"></asp:ListItem>
          <asp:ListItem Text="In Process" Value="In Process"></asp:ListItem>
          <asp:ListItem Text="Ready For Delivery" Value="Ready For Delivery"></asp:ListItem>
          <asp:ListItem Text="Delivered" Value="Delivered"></asp:ListItem>
          <asp:ListItem Text="Cancelled" Value="Cancelled"></asp:ListItem>
      </asp:DropDownList>
  </div>

                  <div>
      Service Type: 
 <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="form-control service-filter" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged">
</asp:DropDownList>
  </div>
         <div>
             Minimum Orders
             <asp:TextBox ID="txtMinOrders" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
         </div>

          <div>
              Minimum Spent
              <asp:TextBox ID="txtMinSpent" CssClass="form-control" runat="server" ></asp:TextBox>
              <asp:RegularExpressionValidator ID="reftxtMinSpent" runat="server" ControlToValidate="txtMinSpent" ValidationExpression="^\d+(\.\d{1,2})?$" CssClass="form-validations" Display="Dynamic"  ErrorMessage="Enter valid amount (e.g. 100 or 100.50)"></asp:RegularExpressionValidator>
          </div>

          <div>
              Top Customers
              <asp:TextBox ID="txtTopNCutomers" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
          </div>

           <div class="filter-dropdowns-date-filter">
             From: 
           <input id="txtFromDate" type="date" runat="server" class="form-control" />

             To:
           <input id="txtToDate" type="date" runat="server" class="form-control" />

             <asp:Button ID="btnfilterDate" runat="server" CssClass="btn btn-primary" Text="Apply filter" OnClick="btnfilterDate_Click" />
         </div>
            </div>
          
            <div class="grid-wrapper">
                <asp:GridView ID="gvCustomerWiseOrders" runat="server" AutoGenerateColumns="false" CssClass="my-grid" HeaderStyle-CssClass="grid-header">
                    <Columns>
                        <asp:BoundField DataField="FullName" HeaderText="Customer Name"  />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Customer Mobile Number" />
                        <asp:BoundField DataField="TotalOrders" HeaderText="Total Orders" />
                        <asp:BoundField DataField="TotalClothes" HeaderText="Total Clothes" />
                        <asp:BoundField DataField="TotalSpent" HeaderText="Total Spent "  DataFormatString="₹ {0:N2}"  HtmlEncode="False" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

