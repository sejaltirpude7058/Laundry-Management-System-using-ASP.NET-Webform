<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="manage_price.aspx.cs" Inherits="admin_manage_price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container  show">
        <div class="dashboard-head">
            <h2>Manage Price</h2>

        </div>

        <div class="service-type">
            <div class="laundry-form-group">
                Service Type
                <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvServiceType" ControlToValidate="ddlServiceType" runat="server" Display="Dynamic" ErrorMessage="Please select service type" CssClass="form-validations"></asp:RequiredFieldValidator>
            </div>

        </div>
        <div class="clothes-container">
            <asp:Repeater ID="rptClothesContainer" runat="server" OnItemCommand="rptClothesContainer_ItemCommand1" OnItemDataBound="rptClothesContainer_ItemDataBound">
                <ItemTemplate>
                    <div class="clothes-card">
                        <div class="action-btns">
                            <asp:LinkButton ID="btnEditPrice" runat="server" class="edit-icon-btn" ToolTip="Edit price" CommandName="EditPrice" CommandArgument='<%# Eval("ID") %>'><i class="fa-solid fa-pencil"></i>  </asp:LinkButton>
                            <asp:LinkButton ID="btnSavePrice" runat="server"  Visible="false"
                                CommandName="SavePrice" CommandArgument='<%# Eval("ID") %>' class="save-icon-btn" ToolTip="Save Price"> <i class="fa-solid fa-bookmark"></i> </asp:LinkButton>
                            <asp:LinkButton ID="btnDeleteItem" runat="server" class="delete-icon-btn" ToolTip="Delete" CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>'><i class="fa-solid fa-trash"></i> </asp:LinkButton>
                        </div>
                        <div class="clothes-card-body">
                            <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "/images/clothes_img/" + Eval("ClothImage") %>' Height="50" Width="50" />
                            <div>
                                <h6>
                                    <asp:Label ID="lblClothName" runat="server" Text='<%# Eval("ClothName") %>'></asp:Label></h6>
                                <p>
                                  Price  <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" Text='<%#  Eval("Price") %>' ReadOnly="true"></asp:TextBox>

                                </p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>

