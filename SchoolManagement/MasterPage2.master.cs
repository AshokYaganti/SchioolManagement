using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["loggedin"] != "Yes")
        {
            Response.Redirect("LoginPage.aspx");
        }
        else
        {
            DAL obj = new DAL();
            string username = Convert.ToString(Session["username"]);
            DataSet ds = obj.getSchoolDetailsbyTeacher(username);

            string schoolid = string.Empty;            

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                schoolid = ds.Tables[0].Rows[0]["schoolid"].ToString();                
            }

            Session["schoolid"] = schoolid;
            
            tname.InnerText = Convert.ToString(Session["name"]);
        }
    }
}
