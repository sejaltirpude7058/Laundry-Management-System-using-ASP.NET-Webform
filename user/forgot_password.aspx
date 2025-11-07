<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgot_password.aspx.cs" Inherits="user_forgot_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/css/index.css?v=30" />
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="custom-container">
            <div class="form-container">
                <h5>Reset Password</h5>
                <div class="form-group">
                    Email
              <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter registered email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server" Display="Dynamic" ErrorMessage="Email is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    Set New Password
              <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="New Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="lbl-msg-error"></asp:Label>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="form-btn" OnClick="btnSubmit_Click" />

                    <hr />
                    <p>Go to <a href="/user/user_login.aspx">Login</a></p>

                </div>
            </div>
        </div>
    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
