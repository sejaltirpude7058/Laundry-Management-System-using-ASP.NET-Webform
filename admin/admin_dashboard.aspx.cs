using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class admin_admin_dashboard : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["AdminName"] == null)
        {
            Response.Redirect("/admin/admin_login.aspx");
            return;
        }
        else
        {
            string[] name = Session["adminName"].ToString().Split(' ');
            string fname = name[0];
            lblWelcomeMsg.Text = fname;
        }

        if (!IsPostBack)
        {
            LoadCountOfStatus();
            LoadDashboardStats();
        }

    }


    protected void LoadCountOfStatus()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spGetOrderStatusCounts", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblnew.Text = reader["NewOrders"].ToString();
                        lblaccept.Text = reader["AcceptOrders"].ToString();
                        lblinprocess.Text = reader["InProcessOrders"].ToString();
                        lbldelivered.Text = reader["DeliveredOrders"].ToString();
                    }
                }
            }
        }
    }

    protected void LoadDashboardStats()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {

            con.Open();

            using (SqlCommand cmd = new SqlCommand("spGetDashboardStats", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

               

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        lblTodayRegistration.Text = reader[0].ToString();

                    if (reader.NextResult() && reader.Read())
                        lblThisMonthRegistration.Text = reader[0].ToString();

                    if (reader.NextResult() && reader.Read())
                        lblThisYearRegistration.Text = reader[0].ToString();

                    if (reader.NextResult() && reader.Read())
                        lblTotalRegistration.Text = reader[0].ToString();

                    if (reader.NextResult() && reader.Read())
                        lblRevenueToday.Text = "₹" +  reader[0].ToString() + ".00";

                    if (reader.NextResult() && reader.Read())
                        lblRevenueThisMonth.Text = "₹" +  reader[0].ToString() + ".00";

                    if (reader.NextResult() && reader.Read())
                        lblRevenueThisYear.Text = "₹" + reader[0].ToString()  + ".00";
                }
            }

            using (SqlCommand cmd1 = new SqlCommand("spMostUsedService", con))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd1))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    Chart1.DataSource = dt;
                    Chart1.Series["Series1"].XValueMember = "ServiceName";
                    Chart1.Series["Series1"].YValueMembers = "UsageCount";
                    Chart1.DataBind();

                    //Chart1.Series["Series1"]["PieLabelStyle"] = "Outside";
                    //Chart1.Series["Series1"].BorderColor = System.Drawing.Color.Black;
                    //Chart1.Series["Series1"].BorderWidth = 1;
                    Chart1.Legends.Add("Legend1");
                    Chart1.Legends["Legend1"].Docking = Docking.Right;



                }
            }

        }
    }
}