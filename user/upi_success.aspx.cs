using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_upi_success : System.Web.UI.Page
{

    int requestID;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FullName"] == null)
        {
            Response.Redirect("/user/user_login.aspx");
        }
        if (Request.QueryString["requestID"] != null)
        {
           requestID = Convert.ToInt32(Request.QueryString["requestID"]);

        }
       


        if (!IsPostBack)
        {
            lblName.Text = Session["FullName"].ToString();
        }
    }

    protected void lbtnDownLoadReciept_Click(object sender, EventArgs e)
    {
        Response.Redirect("/user/reciept.aspx?requestID=" + requestID);
    }
}