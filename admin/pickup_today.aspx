<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="pickup_today.aspx.cs" Inherits="admin_pickup__today" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container  show">
        <div class="dashboard-head">
            <h2>Pickup List for <%: DateTime.Now.ToString("dd-MMM-yyyy") %></h2>
        </div>
        <div class="grid-container">
            <div class="grid-top">
                <div>
                    Show Entries
            <asp:DropDownList ID="ddlEntriesLength" runat="server" CssClass="show-entries-ddl" AutoPostBack="true" OnSelectedIndexChanged="ddlEntriesLength_SelectedIndexChanged">
                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                <asp:ListItem Value="20" Text="20"></asp:ListItem>
                <asp:ListItem Value="50" Text="50"></asp:ListItem>
            </asp:DropDownList>
                </div>
            </div>

            <div class="grid-wrapper">
                <asp:GridView ID="gvTodayPickup"
                    runat="server"
                    AutoGenerateColumns="false"
                    OnRowCommand="gvTodayPickup_RowCommand"
                    CssClass="my-grid"
                    HeaderStyle-CssClass="grid-header">
                    <Columns>
                        <asp:BoundField DataField="TokenID" HeaderText="Token ID" />
                        <asp:BoundField DataField="PostingDate" HeaderText="Return Date" DataFormatString="{0: d MMMM yy}" HtmlEncode="false" />
                        <asp:BoundField DataField="FullName" HeaderText="Customer Name" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Contact Number" />
                        <asp:BoundField DataField="ServiceName" HeaderText="Service Applied For" />
                        <asp:BoundField DataField="Address" HeaderText="Customer Address" />
                        <asp:BoundField DataField="TotalQuantity" HeaderText="Total Clothes Quantity" />
                        <asp:BoundField DataField="Status" HeaderText="Order Status" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="btnPickedUp" runat="server" Text="Picked Up" CssClass="btn btn-sm btn-outline-primary" CommandName="Action" CommandArgument='<%# Eval("RequestID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <div class="pagination-container">
                    <asp:Button ID="btnPrev" runat="server" Text="Prev" CssClass="pagination-btn" OnClick="btnPrev_Click" />
                    <asp:Label ID="lblPageNumber" runat="server" Text="Page 1" CssClass="page-number-label"></asp:Label>
                    <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="pagination-btn" OnClick="btnNext_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

