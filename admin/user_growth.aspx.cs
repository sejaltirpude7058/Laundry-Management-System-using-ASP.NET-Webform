using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class admin_user_growth : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadChart();
        }
    }

    private void LoadChart()
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            string sql = @"
            SELECT 
                CAST(YEAR(regDate) AS VARCHAR) + '-' + RIGHT('0' + CAST(MONTH(regDate) AS VARCHAR), 2) AS MonthLabel,
                COUNT(*) AS TotalRegistrations
            FROM tbluser
            GROUP BY YEAR(regDate), MONTH(regDate)
            ORDER BY YEAR(regDate), MONTH(regDate)";

            chRegistrations.ChartAreas[0].AxisX.Title = "Month";
            chRegistrations.ChartAreas[0].AxisY.Title = "Total Registrations";

            chRegistrations.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

        
            chRegistrations.Titles.Clear();
            chRegistrations.Titles.Add("User Registration Trends");


            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chRegistrations.Series[0].Name = "Registrations";
            chRegistrations.Series["Registrations"].LegendText = "Total Registrations";
            chRegistrations.Series["Registrations"].XValueMember = "MonthLabel";
            chRegistrations.Series["Registrations"].YValueMembers = "TotalRegistrations";
            chRegistrations.DataSource = dt;
            chRegistrations.DataBind();
        }
    }
}