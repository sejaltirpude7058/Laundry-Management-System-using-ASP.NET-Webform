using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class admin_manage_price : System.Web.UI.Page
{
    string cns = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    int serviceID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadServices();
            LoadClothes();
        }
    }

    protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        serviceID = Convert.ToInt32(ddlServiceType.SelectedValue);
        ViewState["serviceID"] = serviceID;
        LoadClothes();
    }

    private int? EditClothID
    {
        get { return ViewState["EditClothID"] as int?; }
        set { ViewState["EditClothID"] = value; }
    }


    protected void LoadServices()
    {
        using (SqlConnection con = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("spShowServiceTypes", con))
            {
                con.Open();

                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ddlServiceType.DataSource = reader;
                    ddlServiceType.DataTextField = "ServiceName";
                    ddlServiceType.DataValueField = "ServiceID";
                    ddlServiceType.DataBind();

                }

            }
        }

        ddlServiceType.Items.Insert(0, new ListItem("Select Service Type"));
    }

    protected void LoadClothes()
    {
        if (ViewState["serviceID"] != null)
            serviceID = Convert.ToInt32(ViewState["serviceID"]);

        using (SqlConnection con = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("spManagePriceAccordingToService", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@serviceID", serviceID);
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    rptClothesContainer.DataSource = dt;
                    rptClothesContainer.DataBind();
                }
            }
        }
    }


    protected void DeleteCloth(int clothID)
    {
        using (SqlConnection con = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("spDeleteItem", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", clothID);
                con.Open();

                cmd.ExecuteNonQuery();

            }
        }

        LoadClothes();
    }

    protected void SavePrice(int clothID, int newPrice)
    {
        using (SqlConnection con = new SqlConnection(cns))
        {
            using(SqlCommand cmd = new SqlCommand("spSetNewPrice", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", clothID);
                cmd.Parameters.AddWithValue("@price", newPrice);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        LoadClothes();
    }

    protected void rptClothesContainer_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        int clothID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "EditPrice")
        {
            EditClothID = clothID;
            LoadClothes();
        }
        else if (e.CommandName == "SavePrice")
        {
            TextBox txtPrice = (TextBox)e.Item.FindControl("txtPrice");
            int newPrice = Convert.ToInt32(txtPrice.Text);
            SavePrice(clothID, newPrice);
            EditClothID = null;
            LoadClothes();
        }
        else if (e.CommandName == "DeleteItem")
        {
            DeleteCloth(clothID);
            LoadClothes();
        }
    }

    protected void rptClothesContainer_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hfID = (HiddenField)e.Item.FindControl("hfID");
            TextBox txtPrice = (TextBox)e.Item.FindControl("txtPrice");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEditPrice");
            LinkButton btnSave = (LinkButton)e.Item.FindControl("btnSavePrice");

            if (EditClothID.HasValue && EditClothID.Value == Convert.ToInt32(hfID.Value))
            {
                txtPrice.ReadOnly = false;
                btnEdit.Visible = false;
                btnSave.Visible = true;

               
                txtPrice.Focus();
            }
            else
            {
                txtPrice.ReadOnly = true;
                btnEdit.Visible = true;
                btnSave.Visible = false;
            }
        }

    }
}