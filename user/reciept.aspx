<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="reciept.aspx.cs" Inherits="user_reciept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <div>
                 <h2>Download receipt</h2>
            </div>
            
            
        </div>
        <div class="recipt-container">
         
            <div class="reciept">

                <div class="reciept-head">
                    <div>
                        <div class="heading">
                            <asp:Image ID="Imglogo" runat="server" ImageUrl="/images/washiron.png" Width="50" />
                            <h3>Fresh & Clean Laundry</h3>
                        </div>
                        <p>Example Nagar, Behind Exaami Mall, Nagpur - 400021</p>
                        <p><i class="fa-solid fa-phone"></i>+91 990067112,&nbsp; +91 8889765042</p>
                        <p><i class="fa-solid fa-envelope"></i>&nbsp; loremlaundry@gmail.com </p>
                    </div>
                    <div>
                        <p>Date:  <asp:Literal ID="liDate" runat="server"></asp:Literal> </p>
                        <p>
                            Receipt No: 
                            <asp:Label ID="liRecieptNo" runat="server" Text="Label"></asp:Label>
                        <p>
                    </div>
                </div>

                <table class="reciept-table">


                    <tr>
                        <th>Token ID :
                        </th>
                        <td>
                            <strong>
                                <asp:Literal ID="liTokenID" runat="server"></asp:Literal></strong>
                        </td>
                    </tr>
                    <tr>
                        <th>Customer Name :
                        </th>
                        <td>
                            <asp:Literal ID="liFullName" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Mobile Number : 
                        </th>
                        <td>
                            <asp:Literal ID="liMobileNumber" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Address : 
                        </th>
                        <td>
                            <asp:Literal ID="liAddress" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Order Date :
                        </th>
                        <td>
                            <asp:Literal ID="liOrderDate" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Selected Service :
                        </th>
                        <td>
                            <asp:Literal ID="liServiceSelected" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Selected Clothes Details :
                        </th>
                        <td>
                            <table>
                                <thead>
                                    <tr>
                                        <th>Sr.</th>
                                        <th>Cloth</th>
                                        <th>Qty</th>
                                        <th>Unit Price</th>
                                        <th>Total</th>

                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptClothDetails" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("SrNo") %></td>
                                                <td><%# Eval("ClothName") %></td>
                                                <td><%# Eval("Quantity") %></td>
                                                <td><%# "₹" + Eval("Price") + ".00"  %> </td>
                                                <td><%# "₹" + Eval("Total") + ".00"  %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th>Total Quantity : </th>
                        <td>
                            <asp:Literal ID="liTotalQuantity" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Delivery charge : </th>
                        <td>
                            <asp:Literal ID="liDeliveryCharge" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <th>Other Charge : 
                        </th>
                        <td>
                            <asp:Literal ID="liOtherCharge" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Grand Total : 
                        </th>
                        <td>
                            <asp:Literal ID="liGrandTotal" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Payment Method : 
                        </th>
                        <td>
                            <asp:Literal ID="liPaymentMethod" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <th>Payment Status : 
                        </th>
                        <td>
                            <asp:Literal ID="liPaymentStatus" runat="server"></asp:Literal>
                        </td>
                    </tr>
             
                </table>
               <div class="reciept-foot">
                   <asp:Label ID="liFooter" CssClass="reciept-foot-msg" runat="server"></asp:Label>

               </div>
            </div>
            
        </div>
         <div>
       <div class="download-btn">
           <button class="no-print btn btn-danger btn-lg" onclick="window.print()">Download / Print Receipt</button>
       </div>
 </div>
    </div>
</asp:Content>

