using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_add_service : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddService_Click(object sender, EventArgs e)
    {
        using (SqlConnection cn = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spAddNewService", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.Parameters.AddWithValue("@serviceName", txtServiceName.Text.ToString().Trim());
                cmd.Parameters.AddWithValue("@serviceDescription", txtServiceDescription.Text.ToString().Trim());

                cmd.ExecuteNonQuery();
                lblMsg.Text = "New Service add successfully";
            }
        }
    }
}