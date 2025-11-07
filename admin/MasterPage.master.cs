using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminName"] == null )
        {
            Response.Redirect("/admin/admin_login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
               
                lblAdminFullName.Text = Session["adminName"].ToString();
            }
        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        if (Session["adminID"] != null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/admin/admin_login.aspx");
        }
    }

 
}
