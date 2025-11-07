using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_reports : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
    }





    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        gvReportsBtwnDates.Visible = false;
        gvSpecificeStatusReport.Visible = false;
        gvReportsBtwnDates.DataSource = null;
        gvSpecificeStatusReport.DataSource = null;
        gvReportsBtwnDates.DataBind();
        gvSpecificeStatusReport.DataBind();

        DateTime fromDate = Convert.ToDateTime(txtFromDate.Text).Date;
        DateTime toDate = Convert.ToDateTime(txtToDate.Text).Date;

        liDates.Text = " Dates: " + fromDate.ToString("d MMM yyyy") + " and " + toDate.ToString("d MMM yyyy");

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            if (rbtnAll.Checked)
            {
                using (SqlCommand cmd = new SqlCommand("spRequestBetweenDatesAllStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    con.Open();

                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        gvReportsBtwnDates.DataSource = dt;
                        gvReportsBtwnDates.DataBind();
                        gvReportsBtwnDates.Visible = true;
                    }
                }
            }
            else
            {
                string status = "";
                if (rbtnNew.Checked) status = "New";
                else if (rbtnAccept.Checked) status = "Accept";
                else if (rbtnInProcess.Checked) status = "In Process";
                else if (rbtnDelivered.Checked) status = "Delivered";

                using (SqlCommand cmd = new SqlCommand("spRequestReportsSpecificStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);
                    cmd.Parameters.AddWithValue("@status", status);
                    con.Open();

                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        gvSpecificeStatusReport.DataSource = dt;
                        gvSpecificeStatusReport.DataBind();
                        gvSpecificeStatusReport.Visible = true;
                    }
                }
            }
        }
    }

}