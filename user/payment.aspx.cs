using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_payment : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;

    int requestID;
    int userID;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] == null)
        {
            Response.Redirect("/user/user_login.aspx");
            
        }
        else
        {
            userID = Convert.ToInt32(Session["userID"]);

            if (Request.QueryString["requestID"] != null)
            {
                requestID = Convert.ToInt32(Request.QueryString["requestID"]);

            }

        }


        if (!IsPostBack)
        {
            LoadBill();
        }
       

    }

    protected void LoadBill()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            SqlCommand cmd = new SqlCommand("spGetOrderBill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@requestID", requestID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];  // first row

                int basePrice = row["BaseClothPrice"] != DBNull.Value ? Convert.ToInt32(row["BaseClothPrice"]) : 0;
                int deliveryCharge = row["DeliveryCharge"] != DBNull.Value ? Convert.ToInt32(row["DeliveryCharge"]) : 0;
                int expressCharge = row["ExpressCharge"] != DBNull.Value ? Convert.ToInt32(row["ExpressCharge"]) : 0;
                int totalAmount = row["TotalPayable"] != DBNull.Value ? Convert.ToInt32(row["TotalPayable"]) : 0;

                lblTotal.Text = "₹" + basePrice.ToString("N2");
                lblDeliveryCharge.Text = "₹" + deliveryCharge.ToString("N2");
                lblOtherCharges.Text = "₹" + expressCharge.ToString("N2");
                lblAmountPayable.Text = "₹" + totalAmount.ToString("N2");
            }
        }
    }


    protected void btnConfirmPayment_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spUpdatePaymentStatus", con))
            {
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@requestID", requestID);

                string paymentMethod = rblPaymentMethod.SelectedValue;
                string paymentStatus = "";

                if (paymentMethod == "COD")
                {
                    paymentStatus = "Pending";
                }
                else if (paymentMethod == "UPI")
                {
                    paymentStatus = "Paid";
                }

                cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                cmd.Parameters.AddWithValue("@paymentStatus", paymentStatus);

                cmd.ExecuteNonQuery();
            }
        }

        Response.Redirect("/user/upi_success.aspx?requestID=" + requestID);
    }



}