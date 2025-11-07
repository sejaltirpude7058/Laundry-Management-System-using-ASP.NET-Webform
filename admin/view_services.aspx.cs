using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_view_services : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    int entryCount;

    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] == null ? 1 : Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CurrentPage = 1;
            LoadServices();
        }
    }

    protected void LoadServices()
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue);

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            SqlCommand cmd;
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                cmd = new SqlCommand("spShowServices", con);
                cmd.Parameters.AddWithValue("@entryCount", entryCount);
                cmd.Parameters.AddWithValue("@currentPage", CurrentPage);
            }
            else
            {
                cmd = new SqlCommand("spSearchService", con);
                cmd.Parameters.AddWithValue("@entryCount", entryCount);
                cmd.Parameters.AddWithValue("@currentPage", CurrentPage);
                cmd.Parameters.AddWithValue("@search", txtSearch.Text.Trim());
            }

            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            gvServices.DataSource = dt;
            gvServices.DataBind();
        }

        lblPageNumber.Text = "Page " + CurrentPage.ToString();
        btnPrev.Enabled = CurrentPage > 1;
        btnNext.Enabled = gvServices.Rows.Count == entryCount;
    }

    protected void gvServices_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvServices.EditIndex = e.NewEditIndex;
        LoadServices();
    }

    protected void gvServices_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvServices.EditIndex = -1;
        LoadServices();
    }

    protected void gvServices_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int serviceID = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);
        string serviceName = ((TextBox)gvServices.Rows[e.RowIndex].FindControl("txtServiceName")).Text.Trim();
        string serviceDesc = ((TextBox)gvServices.Rows[e.RowIndex].FindControl("txtServiceDescription")).Text.Trim();

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            SqlCommand cmd = new SqlCommand("spUpdaterService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@serviceID", serviceID);
            cmd.Parameters.AddWithValue("@serviceName", serviceName);
            cmd.Parameters.AddWithValue("@serviceDescription", serviceDesc);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        gvServices.EditIndex = -1;
        LoadServices();
    }

    protected void gvServices_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int serviceID = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            SqlCommand cmd = new SqlCommand("spDeleteService", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@serviceID", serviceID);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        LoadServices();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        LoadServices();
    }

    protected void ddlEntriesLength_SelectedIndexChanged(object sender, EventArgs e)
    {
        CurrentPage = 1;
        LoadServices();
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        if (CurrentPage > 1)
        {
            CurrentPage--;
            LoadServices();
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage++;
        LoadServices();
    }

    protected void btnAddService_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/add_service.aspx");
    }
}
