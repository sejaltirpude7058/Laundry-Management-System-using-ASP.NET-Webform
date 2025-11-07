<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="view_services.aspx.cs" Inherits="admin_view_services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container  show">

        <div class="dashboard-head">
            <div>
                <h2>Services</h2>
                <p>To add more services click <b>" + Add more" </b>button.</p>
                
            </div>
            <asp:Button ID="btnAddService" runat="server" CssClass="btn btn-primary" Text=" + Add More" OnClick="btnAddService_Click" />
        </div>

        <div class="grid-container">

            <div class="grid-top">
                <div>
                    Show Entries 
                    <asp:DropDownList ID="ddlEntriesLength" runat="server" CssClass="show-entries-ddl" AutoPostBack="true" OnSelectedIndexChanged="ddlEntriesLength_SelectedIndexChanged">
                        <asp:ListItem Text="8" Value="8" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="20" Value="20" />
                    </asp:DropDownList>
                </div>
                <div class="search-container">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="search-btn" OnClick="btnSearch_Click" />
                </div>
            </div>

            <div class="grid-wrapper">

                <asp:GridView ID="gvServices"
                    runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="false"
                    CssClass="my-grid"
                    HeaderStyle-CssClass="grid-header"
                    DataKeyNames="ServiceID"
                    OnRowEditing="gvServices_RowEditing"
                    OnRowUpdating="gvServices_RowUpdating"
                    OnRowCancelingEdit="gvServices_RowCancelingEdit"
                    OnRowDeleting="gvServices_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="ServiceID" HeaderText="Service ID" ReadOnly="true" />

                        <asp:TemplateField HeaderText="Service">
                            <ItemTemplate>
                                <%# Eval("ServiceName") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtServiceName" runat="server" CssClass="form-control" Text='<%# Bind("ServiceName") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Service Description">
                            <ItemTemplate>
                                <%# Eval("ServiceDescription") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtServiceDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" Columns="6"
                                    Text='<%# Bind("ServiceDescription") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="edit_btn" />
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="delete_btn" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />

            <div class="pagination-container">
                <asp:Button ID="btnPrev" runat="server" Text="Prev" CssClass="pagination-btn" OnClick="btnPrev_Click" />
                <asp:Label ID="lblPageNumber" runat="server" Text="Page 1" CssClass="page-number-label"></asp:Label>
                <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="pagination-btn" OnClick="btnNext_Click" />
            </div>
        </div>
    </div>
</asp:Content>


