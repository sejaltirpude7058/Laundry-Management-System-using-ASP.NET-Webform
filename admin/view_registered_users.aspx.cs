using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_view_registered_users : System.Web.UI.Page
{

    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CurrentPage = 1;
            LoadAllUsers();
        }
    }

    int entryCount;
   
    private int CurrentPage
    {
        get { return ViewState["CurrentPage"] == null ? 1 : Convert.ToInt32(ViewState["CurrentPage"]);  }
        set { ViewState["CurrentPage"] = value; }
    }
    protected void LoadAllUsers()
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString());
        LoadAllUsers(entryCount);
    }


    protected void LoadAllUsers(int entryCount)
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString());
        
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spViewUsers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entryCount", entryCount);
                cmd.Parameters.AddWithValue("@currentPage", CurrentPage);
                con.Open();
                
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvViewUsers.DataSource = dt;
                    gvViewUsers.DataBind();
                }
            }
        }

        lblPageNumber.Text = CurrentPage.ToString();

        btnPrev.Enabled = CurrentPage > 1;
        btnNext.Enabled = gvViewUsers.Rows.Count == entryCount;
    }

    protected void gvViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvViewUsers.EditIndex = e.NewEditIndex;
        LoadAllUsers();
    }

    protected void gvViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvViewUsers.EditIndex = -1;
        LoadAllUsers();
    }

    protected void gvViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userID = Convert.ToInt32(gvViewUsers.DataKeys[e.RowIndex].Value.ToString());
        string fullName = ((TextBox)gvViewUsers.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();
        string email = ((TextBox)gvViewUsers.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString();
        string mobileNumber = ((TextBox)gvViewUsers.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spUpdateUserDetail", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobileNumber", mobileNumber);

                cmd.ExecuteNonQuery();
            }
        }

        gvViewUsers.EditIndex = -1;
        LoadAllUsers();
    }

   
    protected void gvViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userID = Convert.ToInt32(gvViewUsers.DataKeys[e.RowIndex].Value.ToString());

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spDeleteUser", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.ExecuteNonQuery();
            }
        }

        gvViewUsers.EditIndex = -1;
        LoadAllUsers();
    }

    protected void LoadUsersFilter(string searchTxt)
    {
        using (SqlConnection con  = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spSearchUser", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@search", "%" + searchTxt + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvViewUsers.DataSource = dt;
                gvViewUsers.DataBind();
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        LoadUsersFilter(txtSearch.Text.ToString().Trim());
    }

    protected void ddlEntriesLength_SelectedIndexChanged(object sender, EventArgs e)
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue.ToString());
        CurrentPage = 1; 
        LoadAllUsers(entryCount); 
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        if(CurrentPage > 1)
        {
            CurrentPage--;
            LoadAllUsers();
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage++;
        LoadAllUsers();
    }


    protected void LoadNewUsers(string filterType, int entryCount)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("GetUserRegistrations", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FilterType", filterType);
                cmd.Parameters.AddWithValue("@entryCount", entryCount);
                cmd.Parameters.AddWithValue("@currentPage", CurrentPage);
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gvViewUsers.DataSource = dt;
                    gvViewUsers.DataBind();

                }
            }
            lblPageNumber.Text = CurrentPage.ToString();

            btnPrev.Enabled = CurrentPage > 1;
            btnNext.Enabled = gvViewUsers.Rows.Count == entryCount;
        }
    }

    protected void btnToday_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        LoadNewUsers("Today", Convert.ToInt32(ddlEntriesLength.SelectedValue));
    }

    protected void btnWeek_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        LoadNewUsers("ThisWeek", Convert.ToInt32(ddlEntriesLength.SelectedValue));

    }

    protected void btnMonth_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        LoadNewUsers("ThisMonth", Convert.ToInt32(ddlEntriesLength.SelectedValue)); ;
    }

    protected void btnAllCustomers_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        LoadAllUsers();
    }
}