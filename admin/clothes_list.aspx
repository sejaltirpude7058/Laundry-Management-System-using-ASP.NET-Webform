<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="clothes_list.aspx.cs" Inherits="admin_clothtype_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container  show">
         <div class="dashboard-head">
        <div>
            <h2>Cloth List</h2>
             <p>To add more clothes click <b>"Add more" </b> button.</p>
             
     </div>
      <asp:Button ID="btnAddMoreClothes" runat="server" CssClass="btn btn-primary" Text="Add More"  OnClick="btnAddMoreClothes_Click"/>
 </div>
        <div class="clothes-card-container">
            <asp:Repeater ID="rptClothesList" runat="server" OnItemCommand="rptClothesList_ItemCommand">
                <ItemTemplate>
                    <div class="clothes-card">
                        <div class="action-btns">
                            <asp:LinkButton ID="btnDeleteItem" runat="server" class="delete-icon-btn" ToolTip="Delete" CommandName="DeleteCloth" CommandArgument='<%# Eval("ClothID") %>'><i class="fa-solid fa-trash"></i> </asp:LinkButton>
                        </div>
                        <asp:HiddenField ID="hfClothID" runat="server" Value='<%# Eval("ClothID") %>' />
                        <asp:Image ID="imgClothImage" runat="server" ImageUrl='<%# "~/images/clothes_img/" + Eval("ClothImage") %>' Width="90" Height="90" />
                       <b><asp:Literal ID="liClothName" runat="server" Text='<%# Eval("ClothName") %>'></asp:Literal></b> 
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>

