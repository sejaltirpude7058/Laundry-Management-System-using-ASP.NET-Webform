<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="all_request_list.aspx.cs" Inherits="admin_all_request_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container  show">
        <div class="dashboard-head">
            <h2>Customer Request List</h2>
        </div>
        <div class="grid-container">
            <div class="grid-top">
                <div>
                    Show Entries 
   <asp:DropDownList ID="ddlEntriesLength" runat="server" CssClass="show-entries-ddl" AutoPostBack="true" OnSelectedIndexChanged="ddlEntriesLength_SelectedIndexChanged">
       <asp:ListItem Text="4" Value="4" />
       <asp:ListItem Text="10" Value="10" />
       <asp:ListItem Text="50" Value="50" />
   </asp:DropDownList>
                </div>

                <div class="search-container">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search "></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="search-btn" />
                </div>
            </div>

            <div class="filter-dropdowns">
                <div>
                    Order Status: 
       <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" CssClass="form-control"
           OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">

           <asp:ListItem Text="All" Value=""></asp:ListItem>
           <asp:ListItem Text="New" Value="New"></asp:ListItem>
           <asp:ListItem Text="Accepted" Value="Accept"></asp:ListItem>
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
                    Payment Status: 
        <asp:DropDownList ID="ddlPaymentStatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentStatus_SelectedIndexChanged">
            <asp:ListItem Text="All" Value=""></asp:ListItem>
            <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
        </asp:DropDownList>

                </div>
                <div>
                    Delivery Type: 
      <asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="form-control" AutoPostBack="true"
          OnSelectedIndexChanged="ddlDeliveryType_SelectedIndexChanged">
          <asp:ListItem Text="All" Value=""></asp:ListItem>
          <asp:ListItem Text="Normal" Value="0"></asp:ListItem>
          <asp:ListItem Text="Express Delivery" Value="1"></asp:ListItem>
      </asp:DropDownList>
                </div>
                <div>
                    <div class="filter-dropdowns-date-filter">
                        From: 
         <input id="txtFromDate" type="date" runat="server" class="form-control" />

                        To:
          <input id="txtToDate" type="date" runat="server" class="form-control" />

                        <asp:Button ID="btnfilterDate" runat="server" CssClass="btn btn-primary" Text="Apply filter" OnClick="btnfilterDate_Click" />
                    </div>

                </div>

            </div>


            <div class="grid-wrapper">
                <asp:GridView ID="gvAllRequesList"
                    runat="server"
                    AutoGenerateColumns="false"
                    OnRowCommand="gvAllRequesList_RowCommand"
                    OnRowDataBound="gvAllRequesList_RowDataBound"
                    DataKeyNames="RequestID"
                    CssClass="my-grid"
                    HeaderStyle-CssClass="grid-header"
                    AllowPaging="false">
                    <Columns>

                        <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
                        <asp:BoundField DataField="RequestID" HeaderText="Request ID" Visible="False" />
                        <asp:BoundField DataField="TokenID" HeaderText="Token ID" />
                        <asp:BoundField DataField="PostingDate" HeaderText="Request submitted On" DataFormatString="{0: d MMMM yy}" HtmlEncode="false" />
                        <asp:BoundField DataField="DateOfLaundry" HeaderText="laundry Due" DataFormatString="{0: d MMMM yy}" HtmlEncode="false" />
                        <asp:BoundField DataField="FullName" HeaderText="Customer Name" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                        <asp:BoundField DataField="Status" HeaderText="Current Order Status" />
                        <asp:BoundField DataField="PaymentStatus" HeaderText="Paymemt Status" />
                        <asp:TemplateField HeaderText="View Details">
                            <ItemTemplate>
                                <asp:Button ID="btnViewRequestDetails" runat="server" Text="View Details" CssClass="btn btn-outline-secondary btn-sm" CommandName="ViewDetails" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Accept Request">
                            <ItemTemplate>
                                <asp:Button ID="btnAcceptRequest" runat="server" Text="Accept" CssClass="btn btn-outline-primary btn-sm" CommandName="AcceptRequest" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Picked up order">
                            <ItemTemplate>
                                <asp:Button ID="btnPickedUpRequest" runat="server" Text="Picked up" CssClass="btn btn-outline-success btn-sm" CommandName="PickedUpOrder" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mark In Process">
                            <ItemTemplate>
                                <asp:Button ID="btnChangeStatusToInProcess" runat="server" Text="In Process" CssClass="btn btn-outline-success btn-sm" CommandName="MarkInProcess" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ready for Delivery">
                            <ItemTemplate>
                                <asp:Button ID="btnReadyForDelivery" runat="server" Text="Ready" CssClass="btn btn-outline-warning btn-sm" CommandName="MarkReadyForDelivery" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delivered">
                            <ItemTemplate>
                                <asp:Button ID="btnDelivered" runat="server" Text="Delivered" CssClass="btn btn-outline-danger btn-sm" CommandName="MarkDelivered" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Mark Cancel">
                            <ItemTemplate>
                                <asp:Button ID="btnCancelRequest" runat="server" Text="Cancel" CssClass="btn btn-outline-secondary btn-sm" CommandName="CancelRequest" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>


                </asp:GridView>
                <br />
            </div>
            <div class="pagination-container">
                <asp:Button ID="btnPrev" runat="server" Text="Prev" CssClass="pagination-btn" OnClick="btnPrev_Click" />
                <asp:Label ID="lblPageNumber" runat="server" Text="Page 1" CssClass="page-number-label"></asp:Label>
                <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="pagination-btn" OnClick="btnNext_Click" />
            </div>
        </div>
    </div>
</asp:Content>

