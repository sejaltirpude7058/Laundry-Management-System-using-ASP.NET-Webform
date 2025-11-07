using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_admin_login : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAdminLogin_Click(object sender, EventArgs e)
    {
       using (SqlConnection con = new SqlConnection(cnstr))
       {
            using (SqlCommand cmd = new SqlCommand("spLoginAdmin", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                cmd.Parameters.AddWithValue("@usernameoremail", txtEmailOrUsername.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.ToString().Trim());

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Session["adminID"] = reader["ID"];
                        Session["AdminName"] = reader["AdminName"];
                        Session["Email"] = reader["Email"];

                        ClearForm();

                        Response.Redirect("/admin/admin_dashboard.aspx");

                    }
                    else
                    {
                        lblMsgError.Text = "Invalid Credentials!";
                    }
                }
            }
       }
    }

    void ClearForm()
    {
        txtEmailOrUsername.Text = "";
        txtPassword.Text = "";
    }
}