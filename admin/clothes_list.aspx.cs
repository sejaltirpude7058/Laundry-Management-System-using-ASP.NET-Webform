using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_clothtype_products : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadClothes();
        }
    }

    protected void LoadClothes()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spShowClothes", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    rptClothesList.DataSource = dt;
                    rptClothesList.DataBind();
                }
            }
        }
    }

    protected void DeleteCloth(int clothID)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spDeleteCloth", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clothID", clothID);
                con.Open();

                cmd.ExecuteNonQuery();

            }
        }

        LoadClothes();
    }

    protected void rptClothesList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       if(e.CommandName == "DeleteCloth")
        {
            int clothID = Convert.ToInt32(e.CommandArgument.ToString());
            DeleteCloth(clothID);

        }
    }



    protected void btnAddMoreClothes_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/add_cloth.aspx");
    }
}