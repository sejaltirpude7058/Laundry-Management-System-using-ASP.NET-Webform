<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="add_service.aspx.cs" Inherits="admin_add_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-container">
       <div class="dashboard-head">
         <h2>Add new service</h2>
       </div>
        <div class="dashboard-form-container">
            <div class="form-group">
                Service Name
                <asp:TextBox ID="txtServiceName" runat="server" CssClass="form-control" placeholder="Add new service name"></asp:TextBox>
            </div>
            <div class="form-group">
                Service Description
                <asp:TextBox ID="txtServiceDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" placeholder="Add service description"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="lbl-msg"></asp:Label>
                <asp:Button ID="btnAddService" runat="server" Text="Add Service"  CssClass="form-btn" OnClick="btnAddService_Click"/>
            </div>
        </div>
        
    </div>
</asp:Content>

