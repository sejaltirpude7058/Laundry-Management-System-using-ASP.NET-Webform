using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class settings : System.Web.UI.Page
{
    string cnstr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSettings();
        }
    }

    protected int? EditSettingID
    {
        get { return Convert.ToInt32(ViewState["EditSettingID"]); }
        set { ViewState["EditSettingID"] = value; }
    }

    protected void SaveSetting(int settingID, string newValue)
    {
        using (SqlConnection con = new SqlConnection(cnstr))
        {
            using (SqlCommand cmd = new SqlCommand("spUpdateSetting", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SettingID", settingID);
                cmd.Parameters.AddWithValue("@SettingValue", newValue);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }


    void LoadSettings()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(cnstr))
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblsettings ORDER BY SettingCategory", con);
            da.Fill(dt);
        }

        // Group by category
        var grouped = dt.AsEnumerable()
            .GroupBy(r => r.Field<string>("SettingCategory"))
            .Select(g => new
            {
                SettingCategory = g.Key,
                Settings = g.CopyToDataTable()
            }).ToList();

        rptCategories.DataSource = grouped;
        rptCategories.DataBind();
    }



    protected void rptSettings_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int settingID = Convert.ToInt32(e.CommandArgument);

        if (e.CommandName == "Edit")
        {
            EditSettingID = settingID;
            LoadSettings();
        }
        else if (e.CommandName == "SaveChange")
        {
            TextBox txtValue = (TextBox)e.Item.FindControl("txtValue");
            TextBox timeValue = (TextBox)e.Item.FindControl("txtTimeValue");
            FileUpload fileValue = (FileUpload)e.Item.FindControl("fuFileValue");

            string newValue = "";

            if (txtValue != null && txtValue.Visible) newValue = txtValue.Text;
            else if (timeValue != null && timeValue.Visible) newValue = timeValue.Text;
            else if (fileValue != null && fileValue.Visible && fileValue.HasFile) newValue = fileValue.FileName;

            SaveSetting(settingID, newValue);

            EditSettingID = null;
            LoadSettings();
        }
    }

    protected void rptSettings_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hdnSettingID = (HiddenField)e.Item.FindControl("hdnSettingID");
            LinkButton btnEdit = (LinkButton)e.Item.FindControl("btnEditSettingFields");
            LinkButton btnSave = (LinkButton)e.Item.FindControl("btnSaveChange");

            TextBox txtValue = (TextBox)e.Item.FindControl("txtValue");
            TextBox timeValue = (TextBox)e.Item.FindControl("txtTimeValue");
            FileUpload fileValue = (FileUpload)e.Item.FindControl("fuFileValue");

            if (EditSettingID.HasValue && hdnSettingID != null &&
                  EditSettingID.Value == Convert.ToInt32(hdnSettingID.Value))
            {
                btnEdit.Visible = false;
                btnSave.Visible = true;

                
                string settingType = DataBinder.Eval(e.Item.DataItem, "SettingType").ToString();

                if (settingType == "Text")
                {
                    txtValue.ReadOnly = false;
                    txtValue.Focus();
                }
                else if (settingType == "Time")
                {
                    timeValue.ReadOnly = false;
                    timeValue.Focus();
                }
                else if (settingType == "File")
                {
                   
                    fileValue.Focus();
                }
            }
            else
            {
                btnEdit.Visible = true;
                btnSave.Visible = false;

                if (txtValue != null) txtValue.ReadOnly = true;
                if (timeValue != null) timeValue.ReadOnly = true;
                
            }

        }
    }

}