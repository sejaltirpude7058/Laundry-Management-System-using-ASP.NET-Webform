<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="dashboard-container">
     <div class="dashboard-head">
         <h2>Settings</h2>
     </div>
     <div class="settings-section">
         <asp:Repeater ID="rptCategories" runat="server"  >
             <ItemTemplate>
                 <div class="settings-category">

                     <h5><%# Eval("SettingCategory") %> Settings</h5>


                     <asp:Repeater ID="rptSettings" runat="server" DataSource='<%# Eval("Settings") %>' OnItemCommand="rptSettings_ItemCommand"  OnItemDataBound="rptSettings_ItemDataBound">
                         <ItemTemplate>
                             <div class="settings-row">
                                 <h6>
                                     <label class="text-secondary"><%# Eval("SettingKey") %></label></h6>

                                 <asp:TextBox ID="txtValue" runat="server" CssClass="form-control" ReadOnly="true" 
                                     Text='<%# Eval("SettingValue") %>'
                                     Visible='<%# Eval("SettingType").ToString() == "Text" || Eval("SettingType").ToString() == "Number" %>' />

                                 <asp:TextBox ID="txtTimeValue" runat="server" CssClass="form-control" ReadOnly="true" 
                                     Text='<%# Eval("SettingValue") %>'
                                     TextMode="Time"
                                     Visible='<%# Eval("SettingType").ToString() == "Time" %>' />

                                 <asp:FileUpload ID="fuFileValue" runat="server" CssClass="form-control" 
                                     Visible='<%# Eval("SettingType").ToString() == "FilePath" %>' />

                                 <asp:HiddenField ID="hdnSettingID" runat="server" Value='<%# Eval("SettingID") %>' />


                                 <div class="update-settings-icon">
                                     <asp:LinkButton ID="btnEditSettingFields" runat="server"
                                         CssClass="btn-sm"
                                         ToolTip="Update Information"
                                         CommandName="Edit"
                                         CommandArgument='<%# Eval("SettingID") %>'>
                                         <i class="fa-solid fa-pencil"></i>
                                     </asp:LinkButton>

                                     <asp:LinkButton ID="btnSaveChange"
                                         runat="server" Visible="false"
                                         CommandName="SaveChange"
                                         CommandArgument='<%# Eval("SettingID") %>'
                                         class="save-icon-btn" ToolTip="Save Change">
                                         <i class="fa-solid fa-bookmark"></i>
                                     </asp:LinkButton>
                                 </div>


                             </div>
                         </ItemTemplate>
                     </asp:Repeater>

                 </div>
             </ItemTemplate>
         </asp:Repeater>

     </div>
 </div>
</asp:Content>

