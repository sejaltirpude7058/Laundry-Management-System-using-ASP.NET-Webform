using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_user_dashboard : System.Web.UI.Page
{

    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FullName"] == null && Session["userID"] == null)
        {
            Response.Redirect("/user/user_login.aspx");
        }

        if (!IsPostBack)
        {
            lblWelcomeMsg.Text = " " + Session["FullName"].ToString();
           
            userID = Convert.ToInt32(Session["userID"]);
            LoadCountOfStatus();
            LoadRecentOrders();
            LoadServicesStartingPrices();
        }
    }

    protected void LoadCountOfStatus()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spGetOrderStatusCountsOfParticularUser", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblnew.Text = reader["NewOrders"].ToString();
                        lblaccept.Text = reader["AcceptOrders"].ToString();
                        lblinprocess.Text = reader["InProcessOrders"].ToString();
                        lbldelivered.Text = reader["DeliveredOrders"].ToString();
                    }
                }
            }
        }
    }


    protected void LoadRecentOrders()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spRecentOrders", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    gvUserRecentOrders.DataSource = dt;
                    gvUserRecentOrders.DataBind();
                }
            }
        }
    }

    private void LoadServicesStartingPrices()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            SqlCommand cmd = new SqlCommand("spServicePrices", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            rptServices.DataSource = dt;
            rptServices.DataBind();
        }
    }


}