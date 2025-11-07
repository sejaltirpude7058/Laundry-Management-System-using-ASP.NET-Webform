<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Public.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="pages_Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   <div class="container py-5">

        <!-- ✅ Hero Section -->
        <div class="row align-items-center gy-4">
            
            <!-- Left Text -->
            <div class="col-lg-6 col-md-6 col-sm-12 text-center text-md-start">
                <h1 class="fw-bold mb-3">Welcome to Fresh & Clean Laundry</h1>
                <p class="text-muted mb-4">
                    We make laundry day effortless. Whether you want pickup and delivery, our reliable and affordable services are just a click away.
                    Get started or Sign in and enjoy fresh, clean clothes without the hassle!
                </p>
                
                <div class="mb-4">
                    <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/user/user_registration.aspx" CssClass="btn btn-primary me-2 mb-2">Get Started</asp:HyperLink>
                    <asp:HyperLink ID="hlLogin" runat="server" CssClass="btn btn-outline-primary mb-2" NavigateUrl="~/user/user_login.aspx">
                        <i class="fa-solid fa-arrow-right-to-bracket me-1"></i> Sign in
                    </asp:HyperLink>
                </div>

                <!-- Features -->
                <div class="d-flex flex-wrap justify-content-center justify-content-md-start gap-3 mt-4">
                    <div class="text-center">
                        <div class="fs-3 text-primary"><i class="fa-regular fa-clock"></i></div>
                        <h6 class="mt-2">Quick Service</h6>
                    </div>
                    <div class="text-center">
                        <div class="fs-3 text-primary"><i class="fa-solid fa-truck-pickup"></i></div>
                        <h6 class="mt-2">Free Pickup</h6>
                    </div>
                    <div class="text-center">
                        <div class="fs-3 text-primary"><i class="fa-solid fa-ranking-star"></i></div>
                        <h6 class="mt-2">Quality Care</h6>
                    </div>
                    <div class="text-center">
                        <div class="fs-3 text-primary"><i class="fa-solid fa-headset"></i></div>
                        <h6 class="mt-2">24/7 Support</h6>
                    </div>
                </div>
            </div>

            <!-- Right Image -->
            <div class="col-lg-6 col-md-6 col-sm-12 text-center">
                <img src="/images/homepage-img.png?v=2" class="img-fluid rounded-4" alt="Laundry Service" />
            </div>

        </div>

        <!--  Our Trusted Services -->
        <div class="mt-5 text-center">
            <h4 class="fw-semibold">Our Trusted Services</h4>
            <p class="text-muted">Fresh, clean, and delivered with care.</p>
        </div>

        <!-- Services Grid -->
        <div class="row row-cols-2 row-cols-sm-3 row-cols-md-4 row-cols-lg-5 g-4 text-center mt-3">
            <div class="col">
                <div class="card border-0 shadow-sm py-3">
                    <img src="/images/washfold.png" class="card-img-top mx-auto" style="width:70px;" alt="">
                    <p class="mt-2 fw-semibold">Wash & Fold</p>
                </div>
            </div>
            <div class="col">
                <div class="card border-0 shadow-sm py-3">
                    <img src="/images/washiron.png" class="card-img-top mx-auto" style="width:70px;" alt="">
                    <p class="mt-2 fw-semibold">Wash & Iron</p>
                </div>
            </div>
            <div class="col">
                <div class="card border-0 shadow-sm py-3">
                    <img src="/images/dryclean.png" class="card-img-top mx-auto" style="width:70px;" alt="">
                    <p class="mt-2 fw-semibold">Dry Cleaning</p>
                </div>
            </div>
            <div class="col">
                <div class="card border-0 shadow-sm py-3">
                    <img src="/images/expressdelivay.png" class="card-img-top mx-auto" style="width:70px;" alt="">
                    <p class="mt-2 fw-semibold">Express Delivery</p>
                </div>
            </div>
            <div class="col">
                <div class="card border-0 shadow-sm py-3">
                    <img src="/images/household.png" class="card-img-top mx-auto" style="width:70px;" alt="">
                    <p class="mt-2 fw-semibold">Household</p>
                </div>
            </div>
            <div class="col">
                <div class="card border-0 shadow-sm py-3">
                    <img src="/images/stainremoving.png" class="card-img-top mx-auto" style="width:70px;" alt="">
                    <p class="mt-2 fw-semibold">Stain Removing</p>
                </div>
            </div>
            <div class="col">
                <div class="card border-0 shadow-sm py-3">
                    <img src="/images/carpetcleaning.png" class="card-img-top mx-auto" style="width:70px;" alt="">
                    <p class="mt-2 fw-semibold">Carpet Cleaning</p>
                </div>
            </div>
        </div>

        <!-- ✅ Carousel Section -->
        <div class="my-5">
            <div id="servicesCarousel" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">

                    <asp:Repeater ID="rptServices" runat="server">
                        <ItemTemplate>
                            <%# (Container.ItemIndex % 3 == 0 ? "<div class='carousel-item " + (Container.ItemIndex == 0 ? "active" : "") + "'><div class='row g-3'>" : "") %>

                            <div class="col-md-4">
                                <div class="card text-white bg-dark border-0 h-100">
                                    <div class="card-body text-center">
                                        <h5 class="card-title"><%# Eval("ServiceName") %></h5>
                                        <p class="card-text">Starting from ₹<%# Eval("Price") %></p>
                                    </div>
                                </div>
                            </div>

                            <%# ((Container.ItemIndex + 1) % 3 == 0 || (Container.ItemIndex + 1) == ((Repeater)Container.NamingContainer).Items.Count ? "</div></div>" : "") %>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <button class="carousel-control-prev" type="button" data-bs-target="#servicesCarousel" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon bg-primary rounded-circle p-2"></span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#servicesCarousel" data-bs-slide="next">
                    <span class="carousel-control-next-icon bg-primary rounded-circle p-2"></span>
                </button>
            </div>
        </div>

        <!-- ✅ Why Choose Us -->
        <div class="row align-items-center gy-4 mt-5">
            <div class="col-lg-6 col-md-6 col-sm-12">
                <img src="/images/aboutimg.jpg" class="img-fluid rounded-4 shadow" alt="Laundry Service" />
            </div>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <h2 class="fw-bold mb-3">Why Choose Us?</h2>
                <p class="text-muted">
                    We provide professional laundry services with quick turnaround, affordable pricing, 
                    and doorstep pickup & delivery. Save your time while we take care of your clothes.
                </p>
                <asp:HyperLink ID="hlOrderNow" runat="server" CssClass="btn btn-primary mt-3" NavigateUrl="~/user/user_login.aspx">
                    Order Your First Laundry if New
                </asp:HyperLink>
            </div>
        </div>

    </div>

</asp:Content>


