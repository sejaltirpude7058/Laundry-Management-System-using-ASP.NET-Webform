using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_reciept : System.Web.UI.Page
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
            else
            {
                requestID = Convert.ToInt32(Session["requestID"]);


            }
        }

        if (!IsPostBack)
        {
            LoadReciptDetails();
            liRecieptNo.Text = "RNO" + (requestID).ToString();
            LoadFooterText();

        }
    }



    protected void LoadReciptDetails()
    {
        using (SqlConnection con  = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spInvoiceWithTokenRecipt", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@requestID", requestID);

                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        
                        liTokenID.Text = sdr["TokenID"].ToString();
                        liFullName.Text = sdr["FullName"].ToString();
                        liMobileNumber.Text = "+91 " + sdr["MobileNumber"].ToString();
                        liAddress.Text = sdr["Address"].ToString();
                        liOrderDate.Text = Convert.ToDateTime(sdr["PostingDate"]).ToString("d MMMM yyyy");
                        liDate.Text = Convert.ToDateTime(sdr["PostingDate"]).ToString("d MMMM yyyy");
                        liServiceSelected.Text = sdr["ServiceName"].ToString();

                        
                        if (sdr.NextResult())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(sdr); 
                            rptClothDetails.DataSource = dt;
                            rptClothDetails.DataBind();
                        }

                       
                        if (sdr.Read())
                        {
                            liTotalQuantity.Text = sdr["TotalQuantity"].ToString();
                            liDeliveryCharge.Text = "₹" + sdr["DeliveryCharge"].ToString() + ".00";
                            liOtherCharge.Text = "₹" + sdr["OtherCharge"].ToString() + ".00";
                            liGrandTotal.Text = "₹" + sdr["GrandTotal"].ToString() + ".00";
                            liPaymentMethod.Text = sdr["PaymentMethod"].ToString();
                            liPaymentStatus.Text = sdr["PaymentStatus"].ToString();
                        }
                    }

                }
            }
           
        }
    }




    protected void LoadFooterText()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        using (SqlCommand cmd = new SqlCommand("spGetFooterText", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            object result = cmd.ExecuteScalar();
            string footerText = result == null ? "" : result.ToString();

            liFooter.Text = string.IsNullOrEmpty(footerText)
                            ? "⚠ No footer returned"
                            : footerText;
        }
    }
}