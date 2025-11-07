<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_registration.aspx.cs" Inherits="user_user_registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/css/index.css?v=12"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
         <div class="custom-container">
     <div class="form-container">
         <div class="form-head">
         <p>Fresh & Clean Laundry</p>
        </div>
         <h5>Create Account</h5>
         <div class="form-group">
             Full Name
             <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvFullName" ControlToValidate="txtFullName" runat="server" Display="Dynamic" ErrorMessage="Name is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revFullName" ControlToValidate="txtFullName" ValidationExpression="^[A-Za-z .'-]{2,50}$" Display="Dynamic" runat="server" ErrorMessage="Please enter a valid name (letters only)" CssClass="form-validations"></asp:RegularExpressionValidator>
         </div> 
         <div class="form-group">
             Mobile Number
             <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvMobile" ControlToValidate="txtMobile" runat="server" Display="Dynamic" ErrorMessage="Mobile Number is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revMobile" ControlToValidate="txtMobile" ValidationExpression="^[6-9]\d{9}$" Display="Dynamic" runat="server" ErrorMessage="Enter a valid 10-digit mobile number." CssClass="form-validations"></asp:RegularExpressionValidator>
         </div> 
         <div class="form-group">
             Email
             <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server" Display="Dynamic" ErrorMessage="Email is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"  ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Enter a valid email address." CssClass="form-validations"></asp:RegularExpressionValidator>
         </div>
         <div class="form-group">
             Password
             <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is required!" CssClass="form-validations"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$" ErrorMessage="Password must be at least 8 characters with uppercase, lowercase, digit, and special character." CssClass="form-validations"></asp:RegularExpressionValidator>
         </div>
         <div class="form-group">
             <asp:Label ID="lblMsg" runat="server" Text="" CssClass="lbl-msg"></asp:Label>
             <asp:Button ID="btnUserSignup" runat="server" Text="Sign up" CssClass="form-btn" OnClick="btnUserSignup_Click"/>
            
             <hr />
             <p>Already have an account <a href="/user/user_login.aspx">Login</a></p>
         </div>
     </div>
 </div>
    </form>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
