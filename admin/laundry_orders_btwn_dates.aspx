<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="laundry_orders_btwn_dates.aspx.cs" Inherits="admin_reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="dashboard-container  show">
      
        <div class="dashboard-head">
            <h2>Laundry Orders Between Dates </h2>
        </div>


        <div class="reports-container">
        <div class="form-container">
            <div class="alternate-number">
            <div class="form-group">
                From
            <asp:TextBox ID="txtFromDate" TextMode="DateTimeLocal" CssClass="form-control" runat="server"></asp:TextBox>
             </div>
            <div class="form-group">
                To
            <asp:TextBox ID="txtToDate" TextMode="DateTimeLocal" CssClass="form-control" runat="server"></asp:TextBox>
             </div>
             </div>
            <br />
            <div>
                Request Status
                <br />
                <br />
                 <asp:RadioButton ID="rbtnAll" runat="server"  GroupName="status" Text=" All" Value="All"/>
                 &nbsp; &nbsp;
                <asp:RadioButton ID="rbtnNew" runat="server"  GroupName="status" Text=" New" Value="New"/>
                &nbsp; &nbsp;
                <asp:RadioButton ID="rbtnAccept" runat="server" GroupName="status" Text=" Accept" Value="Accept"/>
                &nbsp; &nbsp;
                <asp:RadioButton ID="rbtnInProcess" runat="server" GroupName="status" Text=" InProcess" Value="InProcess"/>
                &nbsp; &nbsp;
                <asp:RadioButton ID="rbtnDelivered" runat="server" GroupName="status"  Text=" Delivered" Value="Delivered"/>
                &nbsp; &nbsp;
            </div>
              <br />
              <br />

            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" CssClass="form-btn" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
        </div>

        <div class="reports">
            <h4> Laundry orders between <asp:Literal ID="liDates" runat="server" Text=""></asp:Literal> </h4>
            <div class="grid">
                <asp:GridView ID="gvReportsBtwnDates"
                    runat="server"
                    AutoGenerateColumns="false"
                    HeaderStyle-CssClass="grid-header"
                    CssClass="my-grid"
                    >
                    <Columns>
                        <asp:BoundField DataField="SrNO" HeaderText="Sr No" />
                        <asp:BoundField DataField="TotalRequests" HeaderText="Total Orders" />
                        <asp:BoundField DataField="NewRequests" HeaderText="New Orders" />
                        <asp:BoundField DataField="AcceptedRequests" HeaderText="Accepted Orders" />
                        <asp:BoundField DataField="InprocessRequests" HeaderText="In Process Orders" />
                        <asp:BoundField DataField="FinishedRequests" HeaderText="Delivered Orders" />
                      
                    </Columns>
                </asp:GridView>
            </div>

                <div class="grid">
      <asp:GridView ID="gvSpecificeStatusReport"
          runat="server"
          AutoGenerateColumns="false"
          HeaderStyle-CssClass="grid-header"
          CssClass="my-grid"
          >
          <Columns>
              <asp:BoundField DataField="SrNo" HeaderText="Sr No" />
              <asp:BoundField DataField="StatusCount" HeaderText="Status" />
          </Columns>
      </asp:GridView>
  </div>
        </div>
        </div>
     
</div>     
   
</asp:Content>

