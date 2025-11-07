<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="user_dashboard.aspx.cs" Inherits="user_user_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="user-dashborad-top">
            <h3>Welcome, <asp:Label ID="lblWelcomeMsg" runat="server" CssClass="user-welcome-msg" Text=""></asp:Label>!</h3>
            <p>Manage your laundry requests and track your orders</p>
           
        </div>

        <div class=" my-2 ">
 <div id="servicesCarousel" class="carousel slide service-carousel" data-bs-ride="carousel ">
    <div class="carousel-inner px-3">

        <asp:Repeater ID="rptServices" runat="server">
            <ItemTemplate>
               
                <%# (Container.ItemIndex % 3 == 0 ? "<div class='carousel-item " + (Container.ItemIndex == 0 ? "active" : "") + "'><div class='row text-center'>" : "") %>

                <div class="col-md-4">
                    <div class="card p-3 text-primary-emphasis bg-primary-subtle border border-primary-subtle rounded-3">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("ServiceName") %></h5>
                            <p class="card-text">Starting from ₹<%# Eval("Price") %></p>
                        </div>
                    </div>
                </div>

              
                <%# ((Container.ItemIndex + 1) % 3 == 0 || (Container.ItemIndex + 1) == ((Repeater)Container.NamingContainer).Items.Count ? "</div></div>" : "") %>
            </ItemTemplate>
        </asp:Repeater>

    </div>

    <!-- Controls -->
    <button class="carousel-control-prev" type="button" data-bs-target="#servicesCarousel" data-bs-slide="prev">
        <span class="carousel-control-prev-icon"></span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#servicesCarousel" data-bs-slide="next">
        <span class="carousel-control-next-icon"></span>
    </button>
</div>
</div>






            <div class="user-dashboard-about-service">
        <div class="status-card-container">
            <div class="status-new">
                <img src="/images/new-icon.png" alt="new icon" />
                <p>
                    <asp:Label ID="lblnew" runat="server" Text=""></asp:Label>
                </p>
                 <h5>New Orders</h5>

            </div>
            <div class="status-accept">
                <img src="/images/accept-icon.png" alt="accept icon" />
                <p>
                    <asp:Label ID="lblaccept" runat="server" Text=""></asp:Label>
                </p>
                <h5>Accepted Orders</h5>


            </div>
            <div class="status-inprocess">
                <img src="/images/inprocess-icon.png" alt="in process icon" />
                <p>
                    <asp:Label ID="lblinprocess" runat="server" Text=""></asp:Label>
                </p>
                <h5>In Process Orders</h5>


            </div>
            <div class="status-delivered">
                <img src="/images/delivered-icon.png" alt="delivered icon" />
                <p>
                    <asp:Label ID="lbldelivered" runat="server" Text=""></asp:Label>
                </p>
                <h5>Delivered Orders</h5>
            </div>

         

        </div>

       <div class="user-dashboard-other-info">
           <div>
               <h5>Recent Orders</h5>
               <div class="grid">
                   <asp:GridView ID="gvUserRecentOrders" runat="server" AutoGenerateColumns="false" CssClass="my-grid">
                       <Columns>
                           <asp:BoundField DataField="TokenID" HeaderText="Token"/>
                           <asp:BoundField DataField="PostingDate" HeaderText="Order Date" DataFormatString="{0: dd MMM }" HtmlEncode="false"/>
                           <asp:BoundField DataField="ServiceName" HeaderText="Service"/>
                           <asp:BoundField DataField="Status" HeaderText="Order Status"/>
                       </Columns>
                   </asp:GridView>
               </div>
               <br />
              <p class="hlViewOrders"><asp:HyperLink ID="hlViewAllOrders" runat="server" NavigateUrl="~/user/user_laundry_request_details.aspx" CssClass="actionlinks">View All Orders</asp:HyperLink></p>

           </div>
         <div>
             <h5>Quick Actions</h5>
             <div class="quick-actions-container">
                 <div ><i class="fa-solid fa-plus"></i> <asp:HyperLink ID="hlNewOrder" runat="server" CssClass="actionlinks" NavigateUrl="~/user/laundry_request_form.aspx"> New Laundry Request</asp:HyperLink></div>
                 <div ><i class="fa-regular fa-bell"></i> <asp:HyperLink ID="hlViewNotif" runat="server" NavigateUrl="~/user/all_notifications.aspx" CssClass="actionlinks">View Notications</asp:HyperLink> </div>
               
             </div>
         </div>
           <div >
               <div class="serviceinfo">
               <h5>Service Info</h5>
                 <div>
                     <h6>Operating Hours</h6>
                     <p>9:00 AM To 6:00 PM</p>
                 </div>
                  <div>
                      <h6>Express Service</h6>
                      <p>Same day delivery available</p>
                  </div>
                <div>
                 <h6>Contact Support</h6>
                     <p><i class="fa-solid fa-phone"></i>+91 990067112,&nbsp; +91 8889765042</p>
                     <p><i class="fa-solid fa-envelope"></i>&nbsp; freshandcleanlaundry@gmail.com </p>
               </div>
               </div>
           </div>
          
       </div>

  

    </div>
    </div>
</asp:Content>

