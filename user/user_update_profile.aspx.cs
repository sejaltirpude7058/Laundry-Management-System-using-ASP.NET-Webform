using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_user_update_profile : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;

    int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            userID = Convert.ToInt32(Session["userID"].ToString());
        }
        else
        {
            Response.Redirect("/user/user_login.aspx");
        }
        if (!IsPostBack)
        {
            LoadUserProfile();
        }


    }


    protected void LoadUserProfile()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using(SqlCommand cmd = new SqlCommand("spUserProfile", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);

                con.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtUpdateName.Text = reader["FullName"].ToString();
                        txtUpdateMobile.Text = reader["MobileNumber"].ToString();
                        txtUpdateEmail.Text = reader["Email"].ToString();
                    }
                }
            }
        }
    }
    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spUpdateUserOptionalDetail", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", userID);
                cmd.Parameters.AddWithValue("@fullName", txtUpdateName.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@mobileNumber", txtUpdateMobile.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@email", txtUpdateEmail.Text.ToString().Trim());
                con.Open();
                int result = cmd.ExecuteNonQuery();

         
                    if (result > 0)
                    {
                        lblMsg.Text = "Profile updated successfully.";
                    }
                    else
                    {
                        lblMsgError.Text = "Failed to update profile.";
                    }
            }
        }
    }
}