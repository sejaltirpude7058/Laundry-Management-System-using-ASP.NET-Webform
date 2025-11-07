<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_login.aspx.cs" Inherits="user_user_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 <link rel="stylesheet" href="/css/index.css?v=31"/>
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
                       Email
                     <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server" Display="Dynamic" ErrorMessage="Email is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
                   </div>
                   <div class="form-group">
                      <div class="pass-fpass-lebal"><label>Password</label> <asp:HyperLink ID="hlForgotPassword" runat="server" NavigateUrl="~/user/forgot_password.aspx">Forgot Password</asp:HyperLink></div>
                     <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvPassword" runat="server"  ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
                   </div>
                   <div class="form-group">
                       <asp:Label ID="lblMsgError" runat="server" Text="" CssClass="lbl-msg-error"></asp:Label>
                     <asp:Button ID="btnUserLogin" runat="server" Text="Sign in" CssClass="form-btn" OnClick="btnUserLogin_Click"/>
                   
                     <hr />
                     <p>Don't have an account <a href="/user/user_registration.aspx">Sign up</a></p>
                      
                   </div>
              </div>
         </div>
    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
