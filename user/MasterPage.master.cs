using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_MasterPage : System.Web.UI.MasterPage
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            lblUserFullName.Text = Session["FullName"].ToString();
        }
        else
        {
            Response.Redirect("/user/user_login.aspx");
        }

        if (!IsPostBack)
        {
            LoadTopNotifications();
            LoadNotifCountOfUser();
        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/user/user_login.aspx");
            
        }
        else
        {
            Response.Redirect("/pages/home.aspx");
        }
    }

    protected void LoadTopNotifications()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("GetUserNotifications", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(Session["userID"]));

                con.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rptTopNotifications.DataSource = rdr;
                    rptTopNotifications.DataBind();
                }
            }
        }
    }


    protected void LoadNotifCountOfUser()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spCountNotifiactionOfUser", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", Convert.ToInt32(Session["userID"]));

                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar()); 
                lblNotifCount.Text = count.ToString();
            }
        }
    }

}
