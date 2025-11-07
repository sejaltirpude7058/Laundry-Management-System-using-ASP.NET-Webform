using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_change_password : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    int userID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userID"] != null)
        {
            userID = Convert.ToInt32(Session["userID"].ToString().Trim());
        }
        else
        {
            Response.Redirect("/user/user_login.aspx");
        }

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spChangeUserPassword", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@oldPassword", txtOldPassword.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@newPassword", txtConfirmPassword.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@userID", userID);

                cmd.ExecuteNonQuery();
            }


        }

        lblMsg.Text = "Password changed successfully!";
        ClearForm();
    }

    void ClearForm()
    {
        txtOldPassword.Text = "";
        txtNewPassword.Text = "";
        txtConfirmPassword.Text = "";

    }
}