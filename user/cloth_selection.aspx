<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="cloth_selection.aspx.cs" Inherits="user_cloth_selectiont" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <div>
                   <h2>Select cloths for laundry</h2>
                    <p>Select clothes for laundry by clicking the <b>&plus;</b>  button to add them.</p>
                    <p>Click <b>Continue To Laundry form</b> once selected</p>
            </div>
             <asp:Button ID="btnContinue" runat="server" CssClass="btn btn-danger" Text="Continue To Laundry form"  OnClick="btnContinue_Click"/>
        </div>
            
        <div class="clothes-card-container">
            <asp:Repeater ID="rptClothCard" runat="server" OnItemCommand="rptClothCard_ItemCommand">
                <ItemTemplate>
                    <div class="cloth-card">
                        <asp:HiddenField ID="hfdID" runat="server" Value='<%# Eval("ClothID") %>' />
                        <div class="cloths-card-head">
                            <h6><asp:Label ID="lblClothName" runat="server" Text='<%# Eval("ClothName") %>'></asp:Label></h6>
                            <asp:Image ID="imgSelect" runat="server" ImageUrl="/images/green-check.jpg" CssClass="img-select" Visible='<%# Convert.ToInt32(Eval("Quantity")) > 0 %>' />
                        </div>

                        <p>Unit Price 
                            <asp:Label ID="lblPrize" runat="server" Text='<%#  Eval("Price") %>'></asp:Label>₹</p>
                        <div class="qty-container">
                            <p>Quantity
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label></p>
                            <div class="handling-qty">
                                <asp:Button ID="btnIncreaseQty" CssClass="inc-qty-btn" runat="server" Text="+" CommandName="IncreaseQty" CommandArgument='<%# Eval("ClothID") %>' />
                                <asp:Button ID="btnDecreaseQty" CssClass="dec-qty-btn" runat="server" Text="-" CommandName="DecreaseQty"
                                    Enabled='<%# Convert.ToInt32(Eval("Quantity")) > 0 %>'
                                    CommandArgument='<%# Eval("ClothID") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
                   
        </div>
    </div>

</asp:Content>

