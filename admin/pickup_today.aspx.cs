using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_pickup__today : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    int entryCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CurrentPage = 1;
            LoadTodayPickup(10);
        }
    }

    private int CurrentPage
    {
        get { return ViewState["currentPage"] == null ? 1 : Convert.ToInt32(ViewState["currentPage"]); }
        set { ViewState["currentPage"] = value; }
    }

    protected void ddlEntriesLength_SelectedIndexChanged(object sender, EventArgs e)
    {
        entryCount = Convert.ToInt32(ddlEntriesLength.SelectedValue);
        CurrentPage = 1;
        LoadTodayPickup(entryCount);
    }



    protected void LoadTodayPickup(int entryCount)
    {
        using (SqlConnection cn = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spTodayPickup", cn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@entryCount", entryCount);
                cmd.Parameters.AddWithValue("@currentPage", CurrentPage);

                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable d = new DataTable();
                    adp.Fill(d);

                    gvTodayPickup.DataSource = d;
                    gvTodayPickup.DataBind();
                }
            }

            btnPrev.Enabled = CurrentPage > 1;
            lblPageNumber.Text = " Page " + CurrentPage.ToString();
            btnNext.Enabled = gvTodayPickup.Rows.Count == entryCount;
        }


    }



    protected void btnPrev_Click(object sender, EventArgs e)
    {
        if (CurrentPage > 0)
        {
            CurrentPage--;
            LoadTodayPickup(10);
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage++;
        LoadTodayPickup(10);
    }

    protected void gvTodayPickup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "Action")
        {
            int requestID = Convert.ToInt32(e.CommandArgument);

            using(SqlConnection cn = new SqlConnection(cnstr))
            {
                using (SqlCommand cmd = new SqlCommand("spMarkPickedup", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@requestID", requestID);
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        LoadTodayPickup(entryCount);
    }


}