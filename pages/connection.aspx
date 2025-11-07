<%@ Page Language="C#" AutoEventWireup="true" CodeFile="connection.aspx.cs" Inherits="pages_connection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Connection</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CN %>" ProviderName="<%$ ConnectionStrings:CN.ProviderName %>" SelectCommand="SELECT * FROM [tbladmin]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
