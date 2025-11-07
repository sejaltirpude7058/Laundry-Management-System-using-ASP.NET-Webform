<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_login.aspx.cs" Inherits="admin_admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
   <meta name="viewport" content="width=device-width, initial-scale=1.0" />
   <link rel="stylesheet" href="/css/index.css?v=32"/>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="custom-container">
            <div class="form-container">
                <div class="form-head">
                    <p>Fresh & Clean Laundry</p>
                </div>
                <h5>Sign in</h5>
                <div class="form-group">
                    Username or email
                    <asp:TextBox ID="txtEmailOrUsername" runat="server" CssClass="form-control" placeholder="Username or Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmailOrUsername" ControlToValidate="txtEmailOrUsername" runat="server" Display="Dynamic" ErrorMessage="Username or Email is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                   Password
                   <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                     <asp:Label ID="lblMsgError" runat="server" Text="" CssClass="lbl-msg-error"></asp:Label>
                    <asp:Button ID="btnAdminLogin" runat="server" Text="Sign in"  CssClass="form-btn" OnClick="btnAdminLogin_Click"/>
                </div>
            </div>
        </div>
    </form>
       <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
