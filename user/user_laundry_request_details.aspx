<%@ Page Title="" Language="C#" MasterPageFile="~/user/MasterPage.master" AutoEventWireup="true" CodeFile="user_laundry_request_details.aspx.cs" Inherits="user_user_laundry_request_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- XLSX library for Excel export -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>

    <script type="text/javascript">
        function exportGridToExcel() {
            var table = document.getElementById("<%= gvLaundryRequest.ClientID %>");
            if (!table) {
                alert("Grid not found!");
                return;
            }

            var wb = XLSX.utils.book_new();
            var ws = XLSX.utils.table_to_sheet(table);

            // Auto column widths
            var wscols = [
                { wch: 15 },
                { wch: 20 },
                { wch: 20 },
                { wch: 25 },
                { wch: 20 },
                { wch: 15 }
            ];
            ws['!cols'] = wscols;

            XLSX.utils.book_append_sheet(wb, ws, "LaundryRequests");
            XLSX.writeFile(wb, "LaundryRequests.xlsx");
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="dashboard-container">
         <div class="dashboard-head">
             <h2>Laundry Requests</h2>
             <asp:Label ID="lblMessage" runat="server" role="alert"></asp:Label>
         </div>
         
         <!-- Export Button -->
         <div style="margin-bottom:10px;">
             <button type="button" onclick="exportGridToExcel()" class="btn btn-success">
                 Export to Excel
             </button>
         </div>

         <div class="grid-container">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <div class="grid-top">
                         <div>
                             Show Entries 
                             <asp:DropDownList ID="ddlEntriesLength" runat="server" CssClass="show-entries-ddl" AutoPostBack="true" OnSelectedIndexChanged="ddlEntriesLength_SelectedIndexChanged">
                                 <asp:ListItem Text="5" Value="5" />
                                 <asp:ListItem Text="10" Value="10" />
                                 <asp:ListItem Text="100" Value="100" />
                             </asp:DropDownList>
                         </div>
                         <div class="search-container">
                             <asp:TextBox ID="txtSearchDate" runat="server" CssClass="form-control" placeholder="Please enter (yyyy-mm-dd)"></asp:TextBox>
                             <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="search-btn" OnClick="btnSearch_Click" />
                         </div>
                     </div>
                    
                     <div class="grid-wrapper">
                         <asp:GridView ID="gvLaundryRequest"
                             runat="server"
                             AutoGenerateColumns="false"
                             AllowPaging="false"
                             DataKeyNames="RequestID"
                             OnRowCommand="gvLaundryRequest_RowCommand"
                             OnRowDataBound="gvLaundryRequest_RowDataBound"
                             CssClass="my-grid"
                             HeaderStyle-CssClass="grid-header"
                             AlternatingRowStyle-CssClass="alternate-grid-row">
                             <Columns>
                                 <asp:BoundField DataField="RequestID" HeaderText="SrNo" Visible="false" />
                                 <asp:BoundField DataField="TokenID" HeaderText="Token ID" />
                                 <asp:BoundField DataField="PostingDate" HeaderText="Order Date" DataFormatString="{0: d MMMM yyyy}" HtmlEncode="false" />
                                 <asp:BoundField DataField="DateOfLaundry" HeaderText="Return Date" DataFormatString="{0: d MMMM yyyy}" HtmlEncode="false" />
                                 <asp:BoundField DataField="ServiceName" HeaderText="Service Name" />
                                 <asp:BoundField DataField="Status" HeaderText="Order Status" />
                                 <asp:TemplateField HeaderText="Action" >
                                     <ItemTemplate>
                                         <asp:Button ID="btnAction" runat="server" Text="View Details" CssClass="btn btn-outline-info" CommandName="Action" CommandArgument='<%# Eval("RequestID") %>'/>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Cancel Order" >
                                     <ItemTemplate>
                                         <asp:Button ID="btnCancel" runat="server" Text="Cancel Order" CssClass="btn btn-outline-danger" CommandName="CancelOrder" CommandArgument='<%# Eval("RequestID") %>'/>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                         <br />

                         <div class="pagination-container">
                             <asp:Button ID="btnPrev" runat="server" Text="Prev" CssClass="pagination-btn" OnClick="btnPrev_Click" />
                             <asp:Label ID="lblPageNumber" runat="server" Text="Page 1" CssClass="page-number-label"></asp:Label>
                             <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="pagination-btn" OnClick="btnNext_Click" />
                         </div>

                     </div>
                 </ContentTemplate>
             </asp:UpdatePanel>
         </div>
     </div>
</asp:Content>


