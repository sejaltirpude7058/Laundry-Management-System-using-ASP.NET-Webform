<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="add_cloth.aspx.cs" Inherits="admin_add_cloth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Add Clothes</h2>
        </div>
        <div class="dashboard-form-container">
            <div class="form-group">
                Cloth Type Name
                <asp:TextBox ID="txtClothName" runat="server"  placeholder="Cloth Type" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClothName" runat="server" ControlToValidate="txtClothName" ErrorMessage=" Cloth Name is Required" CssClass="form-validations"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                Add Image ( Optional )
                <asp:FileUpload ID="fuClothImage" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblMsg" runat="server" CssClass="lbl-msg" Text=""></asp:Label>
                <asp:Button ID="btnAddCloth" runat="server" Text="Add" CssClass="form-btn" OnClick="btnAddCloth_Click" />
            </div>
        </div>
    </div>
</asp:Content>

