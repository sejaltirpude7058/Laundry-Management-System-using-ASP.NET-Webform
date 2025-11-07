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

public partial class admin_customer_wise_orders : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllServices();
          
        }

        LoadCustomerWiseOrders();
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

    protected void LoadCustomerWiseOrders()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spCustomerReport", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // FromDate
                DateTime fromDate;
                if (DateTime.TryParse(txtFromDate.Value, out fromDate))
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                else
                    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);

                // ToDate
                DateTime toDate;
                if (DateTime.TryParse(txtToDate.Value, out toDate))
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                else
                    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

                // ServiceID
                cmd.Parameters.AddWithValue("@ServiceID",
                    string.IsNullOrEmpty(ddlServiceType.SelectedValue)
                    ? (object)DBNull.Value
                    : Convert.ToInt32(ddlServiceType.SelectedValue));

              
                cmd.Parameters.AddWithValue("@Status",
                    string.IsNullOrEmpty(ddlStatus.SelectedValue)
                    ? (object)DBNull.Value
                    : ddlStatus.SelectedValue);

          
                cmd.Parameters.AddWithValue("@MinOrders",
    string.IsNullOrEmpty(txtMinOrders.Text)
    ? 0
    : Convert.ToInt32(txtMinOrders.Text));

cmd.Parameters.AddWithValue("@MinSpent",
    string.IsNullOrEmpty(txtMinSpent.Text)
    ? 0
    : Convert.ToDecimal(txtMinSpent.Text));
          
                cmd.Parameters.AddWithValue("@TopN",
                    string.IsNullOrEmpty(txtTopNCutomers.Text)
                    ? (object)DBNull.Value
                    : Convert.ToInt32(txtTopNCutomers.Text));

                con.Open();

                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    gvCustomerWiseOrders.EmptyDataText = "No records found";
                    gvCustomerWiseOrders.DataSource = dt;
                    gvCustomerWiseOrders.DataBind();
                }
            }
        }

      
    }



    protected void btnfilterDate_Click(object sender, EventArgs e)
    {
        LoadCustomerWiseOrders();
    }

    protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCustomerWiseOrders();
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCustomerWiseOrders();
    }
}