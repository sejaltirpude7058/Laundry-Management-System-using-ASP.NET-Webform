using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class user_user_registration : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUserSignup_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(cnstr))
            {
                using (SqlCommand cmd = new SqlCommand("spUserRegistration", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@mobileNumber", txtMobile.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.ToString().Trim());

                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "Registered Successfully!";
                    ClearForm();

                }
            }

        }
        catch (SqlException ex)
        {
            lblMsg.Text = ex.Message; 
        }

        

        
    }


    void ClearForm()
    {
        txtFullName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtPassword.Text = "";
       
    }
}