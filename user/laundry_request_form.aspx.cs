using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class user_laundry_request_form : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;

    int userID;
    int serviceID;
    int requestID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userID"] == null)
        {
            Response.Redirect("/user/user_login.aspx");
        }
        else
        {
            userID = Convert.ToInt32(Session["userID"].ToString());
        }

        if (!IsPostBack)
        {
            LoadServices();
            LoadDefaultAddress();

            List<SelectedCloth> clothesList = Session["ClothSelection"] as List<SelectedCloth>;
            if (clothesList != null && clothesList.Count > 0)
            {
                var filteredClothes = clothesList.Where(c => c.Quantity > 0).ToList();
                rptSelectedClothes.DataSource = filteredClothes;
                rptSelectedClothes.DataBind();
            }

            txtContactPerson.Text = Session["FullName"].ToString();

            if (Session["SelectedServiceID"] != null)
                ddlServiceType.SelectedValue = Session["SelectedServiceID"].ToString();

            
            // lblInfo.Text = "Note: Once clothes are selected, they cannot be edited here. Please click 'Select Clothes for laundry' to make changes.";
        }
    }

    protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        serviceID = Convert.ToInt32(ddlServiceType.SelectedValue.ToString());
        Session["SelectedServiceID"] = serviceID;
    }

    


    protected void LoadServices()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
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


    protected void LoadDefaultAddress()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using(SqlCommand cmd = new SqlCommand("spIsDefaultAddress", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtHouseNo.Text = reader["houseNo"].ToString();
                        txtLandmark.Text = reader["landmark"].ToString();
                        txtStreetAddress.Text = reader["streetArea"].ToString();
                        txtPinCode.Text = reader["pincode"].ToString();

                    
                        cbUseDefaultAddress.Visible = true;
                        cbUseDefaultAddress.Checked = true;

                      
                        cbDefaultAddress.Visible = false;
                    }
                    else
                    {
                        
                        cbUseDefaultAddress.Visible = false;
                        cbDefaultAddress.Visible = true;
                        cbDefaultAddress.Checked = false;
                    }
                }
            }
            con.Close();
        }
    }

     

  


    protected void btnAddClothes_Click(object sender, EventArgs e)
    {
        Session["SelectedDate"] = txtDate.Text;
        Response.Redirect("/user/cloth_selection.aspx");
    }

    protected void btnSubmitRequest_Click(object sender, EventArgs e)
    {
        List<SelectedCloth> clothList = Session["ClothSelection"] as List<SelectedCloth>;

        if (clothList == null || clothList.Count == 0 || clothList.All(c => c.Quantity == 0))
        {
            lblErrorMsg.Text = "Please select atleast one cloth before submitting";
            return;
        }
        else
        {
         

            serviceID = Convert.ToInt32(ddlServiceType.SelectedValue);

            int totalQuantitySelected = clothList.Sum(c => c.Quantity);

            using (SqlConnection con = new SqlConnection(cnstr))
            {
                string spName = "spInsertLaundryRequest";


                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@dateOfLaundry", Convert.ToDateTime(txtDate.Text.ToString()).Date);
                    cmd.Parameters.AddWithValue("@serviceID", serviceID);
                    cmd.Parameters.AddWithValue("@houseNo", txtHouseNo.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@streetArea", txtStreetAddress.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@landmark", txtLandmark.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@city", ddlCity.SelectedValue.ToString().Trim());
                    cmd.Parameters.AddWithValue("@pincode", txtPinCode.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@contactPerson", txtContactPerson.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@discription", txtDescription.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@alternateNumber", txtAlternateNumber.Text.ToString().Trim());
                    cmd.Parameters.AddWithValue("@otherCharges", 0);
                    if (cbExpService.Checked)
                    {
                        cmd.Parameters.AddWithValue("@isExpress", 1);
                    }
                   else
                   {
                    cmd.Parameters.AddWithValue("@isExpress", 0);
                    
                   }


                    SqlParameter outparam = new SqlParameter("@requestID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    cmd.Parameters.Add(outparam);

                    cmd.ExecuteNonQuery();

                    requestID = Convert.ToInt32(outparam.Value);
                  

                }

                foreach (var cloth in clothList)
                {
                    if (cloth.Quantity > 0)
                    {
                        using (SqlCommand cmd1 = new SqlCommand("spInsertRequestedClothes", con))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;

                            cmd1.Parameters.AddWithValue("@requestID", requestID);
                            cmd1.Parameters.AddWithValue("@quantity", cloth.Quantity);
                            cmd1.Parameters.AddWithValue("@clothID", cloth.ClothID);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }


                if (cbDefaultAddress.Checked)
                {
                    using (SqlCommand cmd2 = new SqlCommand("spInsertAddress", con))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@userID", userID);
                        cmd2.Parameters.AddWithValue("@houseNo", txtHouseNo.Text.ToString().Trim());
                        cmd2.Parameters.AddWithValue("@streetArea", txtStreetAddress.Text.ToString().Trim());
                        cmd2.Parameters.AddWithValue("@landmark", txtLandmark.Text.ToString().Trim());
                        cmd2.Parameters.AddWithValue("@city", ddlCity.SelectedValue.ToString().Trim());
                        cmd2.Parameters.AddWithValue("@pincode", txtPinCode.Text.ToString().Trim());
                        cmd2.Parameters.AddWithValue("@isDefaultAddress", 1);
                        cmd2.ExecuteNonQuery();

                    }

                }



            }

            
            Session["ClothSelection"] = null;

            //Response.Write("<script>alert('Laundry request submitted successfully!');</script>");

            rptSelectedClothes.DataSource = null;
            rptSelectedClothes.DataBind();

            string script = "alert('Laundry request submitted successfully!');" +
                "window.location='/user/view_details_of_request.aspx?requestID=" + requestID + "';";
            Response.Write("<script>" + script + "</script>");
            Response.End();

        }

    }

    

    protected void cbExpService_CheckedChanged(object sender, EventArgs e)
    {
        if (cbExpService.Checked)
        {
            dateFieldContainer.Visible = false;
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
        {
            dateFieldContainer.Visible = true;
            txtDate.Text = string.Empty;
        }
    }




    protected void cbUseDefaultAddress_CheckedChanged(object sender, EventArgs e)
    {
        if (cbUseDefaultAddress.Checked)
        {
            
            LoadDefaultAddress();
        }
        else
        {
          
            txtHouseNo.Text = "";
            txtLandmark.Text = "";
            txtStreetAddress.Text = "";
            txtPinCode.Text = "";

           
            cbDefaultAddress.Visible = true;
            cbDefaultAddress.Checked = false;
        }
    }
}


