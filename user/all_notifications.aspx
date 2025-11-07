<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="all_notifications.aspx.cs" Inherits="user_all_notifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="dashboard-container">
        <div class="dashboard-head">
            <h2>Notifications</h2>
        </div>
        <div class="dashboard-rowtwo">
            <div class="notification-container">
                <asp:Repeater ID="rptNotifications" runat="server" OnItemCommand="rptNotifications_ItemCommand">
                    <itemtemplate>

                        <div class='notification-item <%# Convert.ToBoolean(Eval("IsRead")) ? "notif-read" : "notif-unread" %>'>

                            <div class="notification-icon">
                                <i class="fa-solid fa-bell"></i>
                            </div>
                            <div class="notification-content">
                                <asp:HiddenField runat="server" Value='<%# Eval("NotificationID") %>' />
                                <p><%# Eval("Message") %></p>
                            </div>
                            <span class="notif-date">
                                <%# Eval("CreatedDate", "{0:dd-MMM-yyyy h:mm tt}") %>
                            </span>

                            <asp:LinkButton ID="btnDeleteNotif"  runat="server" CssClass="notification-close" CommandName="DeleteNotification" CommandArgument='<%# Eval("NotificationID") %>' OnClientClick="return confirm('Are you sure you want to delete this notification?')"><i class="fa-solid fa-xmark text-danger"></i></asp:LinkButton>

                        </div>
                    </itemtemplate>
                </asp:Repeater>


            </div>

        </div>
    </div>
</asp:Content>

