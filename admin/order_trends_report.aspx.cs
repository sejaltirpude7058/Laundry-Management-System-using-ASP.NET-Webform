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

public partial class admin_order_trends_report : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrderReports();
        }
    }

    protected void LoadOrderReports()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        using (SqlCommand cmd = new SqlCommand("spOrdersReport", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

           
            liTodayOrders.Text = ds.Tables[0].Rows[0]["TodayOrders"].ToString();
            liThisWeekOrders.Text = ds.Tables[1].Rows[0]["ThisWeekOrders"].ToString();
            liThisMonthOrders.Text = ds.Tables[2].Rows[0]["OrdersThisMonth"].ToString();
            liThisYearOrders.Text = ds.Tables[3].Rows[0]["OrdersThisYear"].ToString();

            chPostingDateOrderTrend.Series["OrderProgressAnalysis"].XValueMember = "OrderDate";
            chPostingDateOrderTrend.Series["OrderProgressAnalysis"].YValueMembers = "OrdersCount";
            chPostingDateOrderTrend.DataSource = ds.Tables[4];
            chPostingDateOrderTrend.DataBind();
            chPostingDateOrderTrend.Titles.Clear();
            chPostingDateOrderTrend.Titles.Add("Daily Orders Trend");

         
            chPostingDateOrderTrend.ChartAreas[0].AxisX.Title = "Order Date";
            chPostingDateOrderTrend.ChartAreas[0].AxisY.Title = "Number of Orders";


            chMonthlyOrderTrend.Series["MonthlyOrderTrends"].XValueMember = "MonthLabel";
            chMonthlyOrderTrend.Series["MonthlyOrderTrends"].YValueMembers = "TotalLaundryOrders";
            chMonthlyOrderTrend.DataSource = ds.Tables[5];
            chMonthlyOrderTrend.DataBind();
            chMonthlyOrderTrend.Titles.Clear();
            chMonthlyOrderTrend.Titles.Add("Monthly Orders Trend");

            chMonthlyOrderTrend.ChartAreas[0].AxisX.Title = "Month";
            chMonthlyOrderTrend.ChartAreas[0].AxisY.Title = "Total Orders";

         
            liRevenueToday.Text = ds.Tables[6].Rows.Count > 0 && ds.Tables[6].Rows[0][0] != DBNull.Value
                ? "₹" + ds.Tables[6].Rows[0][0].ToString() + ".00"
                : "0";

            liRevenueThisWeek.Text = ds.Tables[7].Rows.Count > 0 && ds.Tables[7].Rows[0][0] != DBNull.Value
                ? "₹" + ds.Tables[7].Rows[0][0].ToString() + ".00"
                : "0";

            liRevenueThisMonth.Text = ds.Tables[8].Rows.Count > 0 && ds.Tables[8].Rows[0][0] != DBNull.Value
                ? "₹" + ds.Tables[8].Rows[0][0].ToString() + ".00"
                : "0";

            liRevenueThisYear.Text = ds.Tables[9].Rows.Count > 0 && ds.Tables[9].Rows[0][0] != DBNull.Value
                ? "₹" + ds.Tables[9].Rows[0][0].ToString() + ".00"
                : "0";
        }
    }


}