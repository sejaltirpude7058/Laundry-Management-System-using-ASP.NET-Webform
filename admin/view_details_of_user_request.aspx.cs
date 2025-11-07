using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_view_details_of__users_request : System.Web.UI.Page
{
    string cns = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    int requestID;
    int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["requestID"] != null)
        {
            requestID = Convert.ToInt32(Request.QueryString["requestID"]);
        }

        if (!IsPostBack)
        {
            GetUserID();
            LoadRequestDetail();
            LoadInvoiceDetails();

        }

    }

    protected void GetUserID()
    {
        using (SqlConnection con = new SqlConnection(cns))
        {
            SqlCommand cmdUser = new SqlCommand("SELECT UserID FROM tbllaundryreq WHERE requestID = @reqid", con);
            cmdUser.Parameters.AddWithValue("@reqid", requestID);

            con.Open();
            object result = cmdUser.ExecuteScalar();
            con.Close();

            if (result != null)
            {
                userID = Convert.ToInt32(result);
            }
        }
    }


    protected void LoadRequestDetail()
    {
        using (SqlConnection cn = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("showParticularRequestAllDetails", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@requestID", requestID);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    if (dt.Rows.Count > 0)
                    {
                        // Fill the literals from the first row
                        DataRow row = dt.Rows[0];
                        DateTime date = Convert.ToDateTime(row["DateOfLaundry"]);
                        string formattedDate = date.ToString("d MMMM yyyy");
                        liDate.Text = formattedDate;
                        liServiceType.Text = row["ServiceName"].ToString();
                        liAddress.Text = row["Address"].ToString();
                        liMobileNumber.Text = row["MobileNumber"].ToString();
                        if (row["AlternateNumber"].ToString() == "")
                        {
                            liAltMobileNumber.Text = "---";
                        }
                        else
                        {
                            liAltMobileNumber.Text = row["AlternateNumber"].ToString();
                        }

                        liContactPerson.Text = row["ContactPerson"].ToString();

                        if (row["Description"].ToString() == "")
                        {
                            liDescription.Text = "---";
                        }
                        else
                        {
                            liDescription.Text = row["Description"].ToString();
                        }


                        liStatus.Text = row["Status"].ToString();

                        // Bind all rows to Repeater
                        rptClothesQuantity.DataSource = dt;
                        rptClothesQuantity.DataBind();
                    }
                }
            }
        }
    }

    protected void LoadInvoiceDetails()
    {
        int totalQuantity = 0;
        int totalPrice = 0;
        int otherCharges = 0;

        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(cns))
        {
            using (SqlCommand cmd = new SqlCommand("spInvoice", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@requestID", requestID);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    dt.Load(reader);


                }
            }

        }



        foreach (DataRow row in dt.Rows)
        {
            totalQuantity += Convert.ToInt32(row["Quantity"]);
            totalPrice += Convert.ToInt32(row["Total"]);

            otherCharges = Convert.ToInt32(row["ExpressCharge"]);

            //Session["totalPrice"] = totalPrice;
            //Session["otherCharges"] = otherCharges;
            //Session["deliveryCharge"] = row["deliveryCharge"] == DBNull.Value ? 0 : Convert.ToInt32(row["deliveryCharge"]);

        }

        rptInvoice.DataSource = dt;
        rptInvoice.DataBind();

        lblTotalQty.Text = "Total Quantity   " + totalQuantity.ToString();
        lblTotalPrice.Text = "Base Cloth Price  ₹" + totalPrice.ToString("0.00");


    }
}