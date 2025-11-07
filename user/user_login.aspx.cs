using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_user_login : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

   

    protected void btnUserLogin_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spUserLogin", con))
            {
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.ToString().Trim());

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Session["userID"] = reader["ID"];
                    Session["FullName"] = reader["FullName"];
                    Session["Email"] = reader["Email"];


                    ClearForm();
                    Response.Redirect("/user/user_dashboard.aspx");
                }
                else
                {
                    lblMsgError.Text = "Invalid Credentials, Please try again!";
                }

            }
        }

      
    }


    void ClearForm()
    {
        txtEmail.Text = "";
        txtPassword.Text = "";
    }
}