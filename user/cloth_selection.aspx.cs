using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class user_cloth_selectiont : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;


    int serviceID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SelectedServiceID"] != null)
        {
            serviceID = Convert.ToInt32(Session["SelectedServiceID"]);
        }
        if (!IsPostBack)
        {
            LoadClothes();
        }
    }

    protected void LoadClothes()
    {
        using (SqlConnection con = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("spClothesList", con))
            {

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serviceID", serviceID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    List<SelectedCloth> clothes = new List<SelectedCloth>();
                    while (reader.Read())
                    {
                        clothes.Add(new SelectedCloth
                        {
                            ClothID = Convert.ToInt32(reader["ClothID"]),
                            ClothName = reader["ClothName"].ToString(),
                            Price = Convert.ToInt32(reader["Price"]),
                            Quantity = 0
                        });
                    }

                    Session["SelectedClothes"] = clothes;
                    rptClothCard.DataSource = clothes;
                    rptClothCard.DataBind();
                }



            }
        }
    }


    protected void rptClothCard_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        List<SelectedCloth> clothList = Session["SelectedClothes"] as List<SelectedCloth>;

        int clothID = Convert.ToInt32(e.CommandArgument);

        if (clothList != null)
        {
            var cloth = clothList.FirstOrDefault(c => c.ClothID == clothID);
            if (cloth != null)
            {
                if (e.CommandName == "IncreaseQty")
                {
                    cloth.Quantity++;
                }
                else if(e.CommandName == "DecreaseQty" && cloth.Quantity > 0)
                {
                    cloth.Quantity--;
                }

                Session["ClothSelection"] = clothList;
                rptClothCard.DataSource = clothList;
                rptClothCard.DataBind();


            }
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("/user/laundry_request_form.aspx");
    }
}