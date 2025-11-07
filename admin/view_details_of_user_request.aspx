<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="view_details_of_user_request.aspx.cs" Inherits="admin_view_details_of__users_request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container  show">
        <div class="dashboard-head">
            <h2>Request Details</h2>
        </div>
        <div class="request-detail-container">
            <table cellspacing="0" class="request-details-table">
                <tr>
                    <th>Date of laundry </th>
                    <td>
                        <asp:Literal ID="liDate" runat="server" Text=""></asp:Literal></td>
                </tr>

                <tr>
                    <th>Clothes Selected </th>
                    <td>
                        <table style="border: none;" cellspacing="0" class="cloths-table">
                            <tr>
                                <th>Cloth Name</th>
                                <th>Quantity</th>
                            </tr>
                            <asp:Repeater ID="rptClothesQuantity" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="liClothName" runat="server" Text='<%# Eval("ClothName") %>'></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal ID="liQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </td>
                </tr>
                <tr>
                    <th>Service Type </th>
                    <td>
                        <asp:Literal ID="liServiceType" runat="server" Text=""></asp:Literal></td>
                </tr>
                <tr>
                    <th>Address</th>
                    <td>
                        <asp:Literal ID="liAddress" runat="server" Text=""></asp:Literal></td>
                </tr>
                <tr>
                    <th>Mobile Numbers</th>
                    <td>
                        <table style="border: none;" cellspacing="0" class="cloths-table">
                            <tr>
                                <th>Mobile Number</th>
                                <td>
                                    <asp:Literal ID="liMobileNumber" runat="server" Text=""></asp:Literal></td>
                            </tr>
                            <tr>
                                <th>Alternate Number</th>
                                <td>
                                    <asp:Literal ID="liAltMobileNumber" runat="server" Text=""></asp:Literal></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <th>Contact Person Name</th>
                    <td>
                        <asp:Literal ID="liContactPerson" runat="server" Text=""></asp:Literal></td>
                </tr>
                <tr>
                    <th>Description</th>
                    <td>
                        <asp:Literal ID="liDescription" runat="server" Text=""></asp:Literal></td>
                </tr>
                <tr>
                    <th>Status</th>
                    <td>
                        <asp:Literal ID="liStatus" runat="server" Text=""></asp:Literal></td>
                </tr>

            </table>


            <div class="laundry-req-invoice">
                <table class="request-details-table">
                    <tr>
                        <th>SrNo</th>
                        <th>Cloth</th>
                        <th>Quantity</th>
                        <th>Per Price</th>
                        <th>Total</th>
                    </tr>
                    <asp:Repeater ID="rptInvoice" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("SrNo") %></td>
                                <td><%# Eval("ClothName") %></td>
                                <td><%# Eval("Quantity") %></td>
                                <td><%# Eval("Price") %> </td>
                                <td><%# Eval("Total") %></td>
                            </tr>
                        </ItemTemplate>

                    </asp:Repeater>
                    <tr>
                        <th colspan="2">Total</th>
                        <td>
                            <asp:Label ID="lblTotalQty" runat="server" Text=""></asp:Label></td>
                        <td colspan="2">
                            <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>


                </table>
            </div>


        </div>


    </div>
</asp:Content>

