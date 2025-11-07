using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class admin_add_cloth : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddCloth_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spAddNewCloth", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("clothName", txtClothName.Text.ToString().Trim());


                string clothImagePath = "";

                if (fuClothImage.HasFile)
                {
                    string fileName = Path.GetFileName(fuClothImage.FileName);

                    clothImagePath = "~/images/clothes_img/" + fileName;

                    fuClothImage.SaveAs(Server.MapPath(clothImagePath));

                    cmd.Parameters.AddWithValue("@clothImage", fileName);
                }

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        lblMsg.Text = "Cloth added succesfully";
    }
}