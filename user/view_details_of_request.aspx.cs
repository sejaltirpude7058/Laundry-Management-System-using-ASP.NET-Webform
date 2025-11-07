using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_view_details_of_request : System.Web.UI.Page
{
    string cns = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    int requestID;
    int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("/user/user_login.aspx");
        }

        userID = Convert.ToInt32(Session["userID"]);

        if (Request.QueryString["requestID"] != null)
        {
            requestID = Convert.ToInt32(Request.QueryString["requestID"]);
        }

        if (!IsPostBack)
        {
            handlePaymentuttonVisiblitiy();
            LoadRequestDetail();
            LoadInvoiceDetails();
        }



    }

    protected void handlePaymentuttonVisiblitiy()
    {
        using (SqlConnection con = new SqlConnection(cns))
        {
            string query = "SELECT PaymentStatus FROM tbllaundryreq WHERE RequestID = @RequestID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@RequestID", requestID);
            con.Open();


            string status = Convert.ToString(cmd.ExecuteScalar());


            if (!string.IsNullOrEmpty(status) && status.Trim().Equals("Paid"))
            {
                btnProceedPayment.Visible = false;
                libtnViewRecipt.Visible = true;
            }
            else
            {
                btnProceedPayment.Visible = true;
                libtnViewRecipt.Visible = false;
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
        int deliveryCharge = 0;

        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(cns))
        {
            using(SqlCommand cmd = new SqlCommand("spInvoice", con))
            {
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@requestID", requestID);


                using(SqlDataReader reader = cmd.ExecuteReader())
                {

                    dt.Load(reader);

                    
                }
            }

        }



        foreach (DataRow row in dt.Rows)
        {
            totalQuantity += row["Quantity"] != DBNull.Value ? Convert.ToInt32(row["Quantity"]) : 0;
            totalPrice += row["Total"] != DBNull.Value ? Convert.ToInt32(row["Total"]) : 0;
            otherCharges += row.Table.Columns.Contains("ExpressCharge") && row["ExpressCharge"] != DBNull.Value
                            ? Convert.ToInt32(row["ExpressCharge"])
                            : 0;
            deliveryCharge = row.Table.Columns.Contains("DeliveryCharge") && row["DeliveryCharge"] != DBNull.Value
                            ? Convert.ToInt32(row["DeliveryCharge"])
                            : 0;
        }

        rptInvoice.DataSource = dt;
        rptInvoice.DataBind();
      
        lblTotalQty.Text = "Total Quantity   " + totalQuantity.ToString();
        lblTotalPrice.Text = "Base Cloth Price   ₹" + totalPrice.ToString("0.00");


    }


    protected void btnProceedPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("/user/payment.aspx?requestID=" + requestID);
    }

    protected void libtnViewRecipt_Click(object sender, EventArgs e)
    {
        Response.Redirect("/user/reciept.aspx?requestID=" + requestID);
    }
}