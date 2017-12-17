using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class TChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DAL obj = new DAL();

        string teacherid = Convert.ToString(Session["username"]);

        string password = Request["password"];
        string cpassword = Request["cpassword"];

        bool pass = password.Equals(cpassword);


        if (password.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('please enter new password' )</script>", false);

        }

        else if (cpassword.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('please enter confirm password' )</script>", false);

        }

        else if (pass.Equals(false))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('New password and confirm password do not match' )</script>", false);

        }
        else
        {
            int res = obj.changePassword(teacherid, password);
            if (res > 0)
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Your password has been saved successfully.');window.location='TChangePassword.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                Response.Redirect(ResolveUrl("TChangePassword.aspx"));
            }

        }
    }
}