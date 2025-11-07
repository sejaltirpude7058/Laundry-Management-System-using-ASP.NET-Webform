<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="upi_success.aspx.cs" Inherits="user_upi_success" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-container">
        <div class="success-msg-container">
           
            <div>
                   <asp:Image ID="imgDone" runat="server" ImageUrl="/images/green-check.jpg" Width="150"/>
                <h5 runat="server">

                    Thank you! <span runat="server">
                        <asp:Label ID="lblName" runat="server" CssClass="lbl-name" Text=""></asp:Label><br /> </span> Order Placed.<br /> <small> We'll process your laundry soon.</small>
                </h5>
                <p>Please download the reciept by clicking this button</p>
                <asp:LinkButton ID="lbtnDownLoadReciept" CssClass="btn btn-success btn-lg" runat="server" OnClick="lbtnDownLoadReciept_Click">Download Reciept</asp:LinkButton>
            </div>
        </div>

        <div>

        </div>
    </div>
</asp:Content>

