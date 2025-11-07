<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="user_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Payment</h2>
           
        </div>
        <div class="payment-container">
        <div runat="server" class="amount-container">
           <div>
               <p>Base Cloth Price </p>
               <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
           </div>
            <div>
              <p>Delivery Charge </p>
                 <asp:Label ID="lblDeliveryCharge" runat="server" Text=""></asp:Label>
            </div>
           <div>
               <p>Other or Express Service Charge </p>
               <asp:Label ID="lblOtherCharges" runat="server" Text=""></asp:Label>
           </div>
            <hr />
            <div>
                <p>Total Amount Payable</p>
                <asp:Label ID="lblAmountPayable" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div class="form-container-payment">
            <h3>Select a Payment method</h3>
            <div class="form-group">
                <asp:RadioButtonList ID="rblPaymentMethod" runat="server">
                    <asp:ListItem Text=" Pay by any UPI App" Value="UPI"></asp:ListItem>
                   <asp:ListItem Text=" Cash On Delivery" Value="COD"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblMsg" runat="server" Text="" CssClass="lbl-msg"></asp:Label>
                <asp:Button ID="btnConfirmPayment" runat="server" CssClass="form-btn" Text="Confirm Payment" OnClick="btnConfirmPayment_Click" />
            </div>

        </div>
      </div>
    </div>
</asp:Content>

