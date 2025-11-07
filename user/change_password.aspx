<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="change_password.aspx.cs" Inherits="user_change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="dashboard-container">
    <div class="dashboard-head">
        <h2>Change Password</h2>
    </div>
    <div class="dashboard-form-container">
        <div class="form-group">
            Current Password
            <asp:TextBox ID="txtOldPassword" CssClass="form-control" runat="server" placeholder="Current Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtOldPassword" Display="Dynamic" ErrorMessage="Password is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            New Password
            <asp:TextBox ID="txtNewPassword" CssClass="form-control" runat="server" placeholder="New Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" Display="Dynamic" ErrorMessage="New Password is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="revNewPassword" runat="server" ControlToValidate="txtNewPassword" Display="Dynamic" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ErrorMessage="Password must be at least 8 characters with uppercase, lowercase, digit, and special character." CssClass="form-validations"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            Confirm Password
            <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server" placeholder="Confirm Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Confirm Password is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
        </div>
        <asp:CompareValidator ID="cvPasswords" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match" CssClass="form-validations"></asp:CompareValidator>
        <div class="form-group">
            <asp:Label ID="lblMsg" runat="server" Text="" CssClass="lbl-msg"></asp:Label>
            <asp:Button ID="btnChangePassword" runat="server" Text="Change" CssClass="btn btn-primary" OnClick="btnChangePassword_Click"/>
        </div>
      </div>

</div>
</asp:Content>

