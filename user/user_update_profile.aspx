<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="user_update_profile.aspx.cs" Inherits="user_user_update_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Update Profile</h2>
        </div>
        <div class="dashboard-form-container">
            <div class="update-form-group">
                Full Name
               <div>
                   <asp:TextBox ID="txtUpdateName" runat="server" CssClass="update-form-ctrl" Text=""></asp:TextBox>
                   <asp:Label ID="lblName" runat="server" CssClass="lbl-edit-price" AssociatedControlID="txtUpdateName"> <i class="fa-solid fa-pencil"></i></asp:Label>
               </div>
                <asp:RegularExpressionValidator ID="revAdminName" ControlToValidate="txtUpdateName" ValidationExpression="^[A-Za-z .'-]{2,50}$" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid name (letters only)" CssClass="form-validations"></asp:RegularExpressionValidator>
            </div>

            <div class="update-form-group">
                Mobile Number
               <div>
                   <asp:TextBox ID="txtUpdateMobile" runat="server" CssClass="update-form-ctrl" Text=""></asp:TextBox>
                   <asp:Label ID="lblMobile" runat="server" CssClass="lbl-edit-price" AssociatedControlID="txtUpdateMobile"> <i class="fa-solid fa-pencil"></i></asp:Label>
               </div>
                <asp:RegularExpressionValidator ID="revMobile" ControlToValidate="txtUpdateMobile" ValidationExpression="^[6-9]\d{9}$" Display="Dynamic" runat="server" ErrorMessage="Enter a valid 10-digit mobile number." CssClass="form-validations"></asp:RegularExpressionValidator>

            </div>
            <div class="update-form-group">
                Email
               <div>
                   <asp:TextBox ID="txtUpdateEmail" runat="server" CssClass="update-form-ctrl" Text=""></asp:TextBox>
                   <asp:Label ID="lblEmail" runat="server" CssClass="lbl-edit-price" AssociatedControlID="txtUpdateEmail"> <i class="fa-solid fa-pencil"></i></asp:Label>
               </div>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtUpdateEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Enter a valid email address." CssClass="form-validations"></asp:RegularExpressionValidator>
            </div>
            <div class="update-form-group">

                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="lbl-msg"></asp:Label>
                <asp:Label ID="lblMsgError" runat="server" Text="" CssClass="lbl-msg-error"></asp:Label>
                <asp:Button ID="btnUpdateProfile" CssClass="btn btn-primary" runat="server" Text="Update" OnClick="btnUpdateProfile_Click" />
            </div>
        </div>
    </div>
</asp:Content>

