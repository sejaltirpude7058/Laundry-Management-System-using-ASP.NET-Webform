<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="view_registered_users.aspx.cs" Inherits="admin_view_registered_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container  show">
        <div class="dashboard-head">
            <h2>All Customers</h2>
        </div>
        <div class="grid-container">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="grid-top">
                        <div>
                            Show Entries 
                          <asp:DropDownList ID="ddlEntriesLength" runat="server" CssClass="show-entries-ddl" AutoPostBack="true" OnSelectedIndexChanged="ddlEntriesLength_SelectedIndexChanged">
                              <asp:ListItem Text="10" Value="10" />
                              <asp:ListItem Text="20" Value="20" />
                              <asp:ListItem Text="50" Value="50" />
                          </asp:DropDownList>
                        </div>
                        <div class="search-container">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search "></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="search-btn" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                    
                        <div class="filter-buttons">
                            <asp:Button ID="btnAllCustomers" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="All Customers" OnClick="btnAllCustomers_Click" />
                            <asp:Button ID="btnToday" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Today" OnClick="btnToday_Click" />
                            <asp:Button ID="btnWeek" runat="server" Text="This Week" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnWeek_Click" />
                            <asp:Button ID="btnMonth" runat="server" Text="This Month" CssClass="btn btn-outline-secondary btn-sm" OnClick="btnMonth_Click" />
                        </div>
                     <br />
                    <div class="grid-wrapper">
                        <asp:GridView ID="gvViewUsers"
                            runat="server"
                            AutoGenerateColumns="false"
                            AllowPaging="false"
                            OnRowEditing="gvViewUsers_RowEditing"
                            OnRowCancelingEdit="gvViewUsers_RowCancelingEdit"
                            OnRowUpdating="gvViewUsers_RowUpdating"
                            OnRowDeleting="gvViewUsers_RowDeleting"
                            DataKeyNames="ID"
                            CssClass="my-grid"
                            HeaderStyle-CssClass="grid-header"
                            HeaderStyle-BackColor="#99ccff"
                            AlternatingRowStyle-CssClass="alternate-grid-row">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                                <asp:BoundField DataField="regDate" HeaderText="Registration Date" DataFormatString="{0: d MMMM yyyy}" />
                                <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="edit_btn" />
                                <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="delete_btn" />
                            </Columns>
                        </asp:GridView>
                        <br />

                        <div class="pagination-container">
                            <asp:Button ID="btnPrev" runat="server" Text="Prev" CssClass="pagination-btn" OnClick="btnPrev_Click" />
                            <asp:Label ID="lblPageNumber" runat="server" Text="Page 1" CssClass="page-number-label"></asp:Label>
                            <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="pagination-btn" OnClick="btnNext_Click" />
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

