using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_all_notifications : System.Web.UI.Page
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
            LoadNotifications();
        }
    }


    protected void LoadNotifications()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("getUserNotifications", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                rptNotifications.DataSource = rdr;
                rptNotifications.DataBind();
            }
        }
    }

    protected void DeleteNotification(int notifID)
    {
        using(SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spdeleteNotification", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@notifID", notifID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }

 
  
        
    

    protected void rptNotifications_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "DeleteNotification")
        {
            int notifID = Convert.ToInt32(e.CommandArgument.ToString());
            DeleteNotification(notifID);
        }


        LoadNotifications();
    }
}