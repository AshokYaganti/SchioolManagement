using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Enroll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string courseid = Request.QueryString["courseid"];
        string teacherid = Request.QueryString["teacherid"];
        string amount = Request.QueryString["amount"];
        string studentusername = Convert.ToString(Session["username"]);

        TextBox1.Text = courseid;
        TextBox2.Text = teacherid;
        TextBox3.Text = studentusername;
        Amounttxt.Text = amount;
    }
    protected void Button1_Click(object sender, EventArgs e)
    { 
        string username = Convert.ToString(Session["username"]);
        string courseid = TextBox1.Text;
        string teacherid = TextBox2.Text;
        string amount = Amounttxt.Text;

        string cardnumber = Request["cardnumber"];
        string month = Request["month"];
        string year = Request["year"];
        string cardtype = DropDownList5.SelectedValue;
        string securitycode = Request["code"];

        DAL obj = new DAL();
        if (cardnumber.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter card number' )</script>", false);

        }
        else if ((cardnumber.Length < 16) || (cardnumber.Length > 16))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter 16 card numberdigits ' )</script>", false);
        }
        if (month.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter month' )</script>", false);

        }
        if (Convert.ToInt32(month)>12)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Invalid month' )</script>", false);

        }
        if (year.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter year' )</script>", false);

        }
        if (Convert.ToInt32(year) < 2017)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Invalid year' )</script>", false);

        }
        else if (cardtype == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select the card Type' )</script>", false);

        }

        else if (securitycode.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please input three digit security code' )</script>", false);
        }
        else if ((securitycode.Length < 3) || (securitycode.Length > 3))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Invalid security code' )</script>", false);
        }
        else
        {

            int res = obj.enrollment(username, courseid, teacherid, amount);

            if (res > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('You have successfully enrolled to the course.');window.location='StudentHome.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                Response.Redirect(ResolveUrl("StudentHome.aspx"));
            }
        }
    }
}