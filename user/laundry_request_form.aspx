<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="laundry_request_form.aspx.cs" Inherits="user_laundry_request_form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Apply for a laundry</h2>
        </div>
        <div class="laundry-request-form">
          
            <div class="form-group">
                Service Type
                <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvServiceType" ControlToValidate="ddlServiceType" runat="server" Display="Dynamic" ErrorMessage="Please select service type" CssClass="form-validations"></asp:RequiredFieldValidator>
            </div>


            <div class="select-clothes">
                <p>Select Clothes and their quantity by clicking here!  <i class="fa-solid fa-hand-point-right"></i></p>

                <asp:Button ID="btnAddClothes" runat="server" Text="Select clothes for laundry" CssClass="laundry-req-form-btn" OnClick="btnAddClothes_Click" />
            </div>
            <div class="clothes-selected">
                <span class="msg">Selected clothes will appear here</span>
                <asp:Repeater ID="rptSelectedClothes" runat="server">
                    <ItemTemplate>
                        <p><%# Eval("ClothName") %> &nbsp;  <%# Eval("Quantity") %></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="alternate-number">
                          <div class="laundry-form-expcheck">
          
              <asp:CheckBox ID="cbExpService" runat="server" Text=" Express Service (same day)" AutoPostBack="true" OnCheckedChanged="cbExpService_CheckedChanged" />
                   <p> <small>(Additional ₹60 will be charged for Express Service)</small></p>
                 </div>

                    <div id="dateFieldContainer" runat="server" class="laundry-form-group">
                        Preferred Delivery Date
                     <asp:TextBox ID="txtDate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                
              
            </div>
            <div class="alternate-number">
                <div class="laundry-form-group">
                    Contact Person Name
                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" placeholder="Contact person name"></asp:TextBox>
                </div>
                <div class="laundry-form-group">
                    Alternate Number (optional)
                    <asp:TextBox ID="txtAlternateNumber" CssClass="form-control" runat="server" placeholder="Alternate number"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revAlternateNumber" ControlToValidate="txtAlternateNumber" Display="Dynamic" ValidationExpression="^[6-9]\d{9}$" runat="server" ErrorMessage="Please enter valid 10 digit number" CssClass="form-validations"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="alternate-number">
              
                <div class="laundry-form-group">
                    Plot No / House No
               <asp:TextBox ID="txtHouseNo" runat="server" CssClass="form-control" placeholder="House no/ plot no eg: Plot No 75"></asp:TextBox>
                </div>
                <div class="laundry-form-group">
                    Landmark
               <asp:TextBox ID="txtLandmark" runat="server" CssClass="form-control" placeholder="Enter near by landmark"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                Street Area
               <asp:TextBox ID="txtStreetAddress" runat="server" CssClass="form-control" placeholder="Enter pickup address"></asp:TextBox>
            </div>

            <div class="alternate-number">
                <div class="laundry-form-group">
                    City
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Nagpur" Value="Nagpur" />
                        <asp:ListItem Text="Wardha" Value="Wardha" />
                    </asp:DropDownList>
                </div>
                <div class="laundry-form-group">
                    Pin Code
                     <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control" placeholder="Enter postal code "></asp:TextBox>
                </div>
               
            </div>
            <asp:CheckBox ID="cbUseDefaultAddress" runat="server" Text="Use Default Address" CssClass="laundry-form-check" OnCheckedChanged="cbUseDefaultAddress_CheckedChanged" AutoPostBack="true"  Visible="false"  />
            <asp:CheckBox ID="cbDefaultAddress" runat="server" Text=" Save this address as Default Address" CssClass="laundry-form-check"  Visible="false"  />

            <div class="form-group">
                Special Instructions (optional)
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Add description if any"></asp:TextBox>
            </div>

            <asp:Label ID="lblErrorMsg" runat="server" CssClass="lbl-msg-error" Text=""></asp:Label>
            <asp:Label ID="lblMsg" runat="server" Text="" CssClass="lbl-msg"></asp:Label>
            <div class="form-group">
                <asp:Button ID="btnSubmitRequest" runat="server" Text="Submit" CssClass="laundry-form-btn" OnClick="btnSubmitRequest_Click" />
            </div>
        </div>

    </div>


</asp:Content>

