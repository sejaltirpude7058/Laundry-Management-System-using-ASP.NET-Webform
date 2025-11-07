using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_service_wise_laundry_orders : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllServices();
            LoadServiceWiseOrders();
        }
    }

    protected void LoadAllServices()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spShowServiceTypes", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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

        ListItem li = new ListItem("Service Type", "");
        li.Attributes["disabled"] = "true";
        li.Selected = true;
        ddlServiceType.Items.Insert(0, li);
    }


    protected void LoadServiceWiseOrders()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using(SqlCommand cmd = new SqlCommand("spServiceOrdersReport", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DateTime fromDate;
                if (DateTime.TryParse(txtFromDate.Value, out fromDate))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
                }

                DateTime toDate;
                if (DateTime.TryParse(txtToDate.Value, out toDate))
                {
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@ServiceID", string.IsNullOrEmpty(ddlServiceType.SelectedValue) ? (object)DBNull.Value : ddlServiceType.SelectedValue);
                con.Open();

                using(SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    gvServiceWiseOrders.DataSource = dt;
                    gvServiceWiseOrders.DataBind();
                }
            }
        }
    }

    protected void btnfilterDate_Click(object sender, EventArgs e)
    {
        LoadServiceWiseOrders();
    }

    protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadServiceWiseOrders();
    }
}