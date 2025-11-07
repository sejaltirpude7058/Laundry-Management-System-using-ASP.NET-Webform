using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_user_laundry_request_details : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;

    int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("/user/user_login.aspx");
        }
        else
        {
            userID = Convert.ToInt32(Session["userID"].ToString());
        }

        if (!IsPostBack)
        {
            CurrentPage = 1;
            LoadParticularUserLaundryRequests();
        }
    }

    int entryCount;

    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] == null ? 1 : Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value; }
    }

    protected void LoadParticularUserLaundryRequests()
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString());
        LoadParticularUserLaundryRequests(entryCount);
    }


    protected void LoadParticularUserLaundryRequests(int entryCount)
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString().Trim());
  
        using (SqlConnection cn  = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spShowRequestDetailsToUser", cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@entryCount", entryCount);
                cmd.Parameters.AddWithValue("@currentPage", CurrentPage);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable datatbl = new DataTable();
                    adapter.Fill(datatbl);
                    gvLaundryRequest.DataSource = datatbl;
                    gvLaundryRequest.DataBind();
                }

                
            }

            cn.Close();
        }
    }

    protected void LoadRequestsFilter(DateTime searchDate)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spSearchParticularUsersLaundryReq", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dateOfLaundry",searchDate);
                cmd.Parameters.AddWithValue("@userID", userID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvLaundryRequest.DataSource = dt;
                gvLaundryRequest.DataBind();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;

        DateTime searchDate;
        if (DateTime.TryParse(txtSearchDate.Text, out searchDate))
        {
            LoadRequestsFilter(searchDate);
        }
        
    }


    protected void ddlEntriesLength_SelectedIndexChanged(object sender, EventArgs e)
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString());
        CurrentPage = 1;
        LoadParticularUserLaundryRequests(entryCount); 
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        if (CurrentPage > 1)
        {
            CurrentPage--;
            LoadParticularUserLaundryRequests();
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage++;
        LoadParticularUserLaundryRequests();
    }


    protected void CancelOrder(int requestID)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(cnstr))
            {
                using (SqlCommand cmd = new SqlCommand("spCancelOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@requestID", requestID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            lblMessage.Text = "Order Cancelled Successfully!";
            lblMessage.CssClass = "alert alert-success";

        }
        catch (SqlException ex)
        {
           
            lblMessage.Text =  ex.Errors[0].Message; ;
            lblMessage.CssClass = "alert alert-danger";
        }

       
    }
    

    protected void gvLaundryRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int requestID = Convert.ToInt32(e.CommandArgument.ToString());

        if(e.CommandName == "Action")
        {
            Session["requestID"] = requestID;

            Response.Redirect("/user/view_details_of_request.aspx?requestID=" + requestID);
        }
        else if(e.CommandName == "CancelOrder")
        {
            CancelOrder(requestID);
            LoadParticularUserLaundryRequests();
        }
    }

    protected void gvLaundryRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
            Button btnCancelOrder = (Button)e.Row.FindControl("btnCancel");

            btnCancelOrder.Visible = false;


            if (status == "PickedUp" || status == "In Process" || status == "Ready For Delivery" || status == "Delivered")
            {
                btnCancelOrder.Visible = false;
            }
            else if (status == "New" || status == "Accept")
            {
                btnCancelOrder.Visible = true;
            }
        }
    }
}