using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_all_request_list : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminID"] == null)
        {
            Response.Redirect("/admin/admin_login.aspx");
        }

        if (!IsPostBack)
        {
            CurrentPage = 1;
            LoadAllRequests();
            LoadAllServices();
        }
    }

    int entryCount;
    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] == null ? 1 : Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value;  }
    }

    protected void LoadAllServices()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spShowServiceTypes", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ddlServiceType.DataSource = reader;
                    ddlServiceType.DataTextField = "ServiceName";
                    ddlServiceType.DataValueField = "ServiceID";
                    ddlServiceType.DataBind();

                }
            }
           
        }

        ListItem li = new ListItem("Service Type", "");
        li.Attributes["disabled"] = "true";  
        li.Selected = true;                  
        ddlServiceType.Items.Insert(0, li);
    }

    protected void LoadAllRequests()
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString());
        LoadAllRequests(entryCount);
    }

    protected void LoadAllRequests(int entryCount)
    {
        

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spShowAllUsersRequestList", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entryCount", entryCount);
                cmd.Parameters.AddWithValue("@currentPage", CurrentPage);
                cmd.Parameters.AddWithValue("@status", string.IsNullOrEmpty(ddlStatus.SelectedValue) ? (object)DBNull.Value : ddlStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@paymentStatus", string.IsNullOrEmpty(ddlPaymentStatus.SelectedValue) ? (object)DBNull.Value : ddlPaymentStatus.SelectedValue);
                cmd.Parameters.AddWithValue("@serviceType", string.IsNullOrEmpty(ddlServiceType.SelectedValue) ? (object)DBNull.Value : ddlServiceType.SelectedValue);
                cmd.Parameters.AddWithValue("@isExpress", string.IsNullOrEmpty(ddlDeliveryType.SelectedValue) ? (object)DBNull.Value : ddlDeliveryType.SelectedValue);

                DateTime fromDate;
                if (DateTime.TryParse(txtFromDate.Value, out fromDate))
                {
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fromDate", DBNull.Value);
                }

                DateTime toDate;
                if (DateTime.TryParse(txtToDate.Value, out toDate))
                {
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@toDate", DBNull.Value);
                }
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvAllRequesList.DataSource = dt;
                    gvAllRequesList.DataBind();
                }
            }
       }

        lblPageNumber.Text = CurrentPage.ToString();

        btnPrev.Enabled = CurrentPage > 1;
        btnNext.Enabled = gvAllRequesList.Rows.Count == entryCount;
    }


    protected void UpdateStatus(string status, int requestID)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spUpdateRequestStatus", con))
            {
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@requestID", requestID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    protected void gvAllRequesList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "ViewDetails")
        {
            int requestID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("/admin/view_details_of_user_request.aspx?requestID=" + requestID);
        }
        else if (e.CommandName == "AcceptRequest" || e.CommandName == "PickedUpOrder" || e.CommandName == "MarkInProcess" || e.CommandName == "MarkDelivered" || e.CommandName == "MarkReadyForDelivery" || e.CommandName == "CancelRequest")
        {
            int requestID = Convert.ToInt32(e.CommandArgument.ToString());
            string status = "";

            if (e.CommandName == "AcceptRequest")
                status = "Accept";
            else if (e.CommandName == "PickedUpOrder")
                status = "PickedUp";
            else if (e.CommandName == "MarkInProcess")
                status = "In Process";
            else if (e.CommandName == "MarkDelivered")
                status = "Delivered";
            else if (e.CommandName == "MarkReadyForDelivery")
                status = "Ready For Delivery";
            else if (e.CommandName == "CancelRequest")
                status = "Cancelled";

                UpdateStatus(status, requestID);
            LoadAllRequests();
        }

    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
       if (CurrentPage > 1){
            CurrentPage--;
            LoadAllRequests();
        }
     
       
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage++;
        LoadAllRequests();
    }

    protected void ddlEntriesLength_SelectedIndexChanged(object sender, EventArgs e)
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString());
        LoadAllRequests(entryCount);
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAllRequests();
    }
       

    protected void ddlPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaymentStatus.SelectedValue == "0") return;
        LoadAllRequests();
    }

    protected void ddlDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDeliveryType.SelectedValue == "0") return;
        LoadAllRequests();
    }

    protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAllRequests();
    }

    protected void gvAllRequesList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

            Button btnAccept = (Button)e.Row.FindControl("btnAcceptRequest");
            Button btnInProcess = (Button)e.Row.FindControl("btnChangeStatusToInProcess");
            Button btnDelivered = (Button)e.Row.FindControl("btnDelivered");
            Button btnCancel = (Button)e.Row.FindControl("btnCancelRequest");
            Button btnReady = (Button)e.Row.FindControl("btnReadyForDelivery");
            Button btnPickedUp = (Button)e.Row.FindControl("btnPickedUpRequest");


       
            btnAccept.Visible = false;
            btnInProcess.Visible = false;
            btnDelivered.Visible = false;
            btnCancel.Visible = false;
            btnReady.Visible = false;
            btnPickedUp.Visible = false;

          
            switch (status)
            {
                case "New":
                    btnAccept.Visible = true;
                    btnCancel.Visible = true;
                    
                    break;

                case "Accept":
                    btnPickedUp.Visible = true;
                    btnCancel.Visible = true;
                    break;

                case "PickedUp":
                    btnInProcess.Visible = true;
                    break;

                case "In Process":
                    btnReady.Visible = true;
                    break;

                case "Ready For Delivery":
                    btnDelivered.Visible = true;
                    break;

                case "Delivered":
                case "Cancelled":
                case "Returned":
                   
                    break;
            }
        }
    }

    protected void btnfilterDate_Click(object sender, EventArgs e)
    {
        LoadAllRequests(Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString()));
    }
}