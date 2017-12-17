using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DAL obj=new DAL();
        string username = Request["username"];
        string password = Request["password"];

        string username11 = string.Empty;
        string password11 = string.Empty;
        string role = string.Empty;
        string name = string.Empty;
        string sname = string.Empty;

        if (username.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please ener user name or ID')</script>", false);
        }
        else if (password.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter password')</script>", false);
        }
        else
        {
            DataSet ds = obj.getLoginDetails(username);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    username11 = ds.Tables[0].Rows[0]["username"].ToString();
                    password11 = ds.Tables[0].Rows[0]["password"].ToString();
                    role = ds.Tables[0].Rows[0]["role"].ToString();
                    name = ds.Tables[0].Rows[0]["name"].ToString();
                    sname = ds.Tables[0].Rows[0]["sname"].ToString();
                }
            }

            if ((username == username11) && (password == password11) && (role == "D"))
            {
                Session["username"] = username;
                Session["role"] = role;
                Session["name"] = name;
                Session["sname"] = sname;      
                Session["loggedin"] = "Yes";
                DAL da = new DAL();               
                Response.Redirect("DirectorHome.aspx");
            }
            else if ((username == username11) && (password == password11) && (role == "S"))
            {
                Session["username"] = username;
                Session["role"] = role;
                Session["name"] = name;
                Session["loggedin"] = "Yes";
                DAL da = new DAL();                
                Response.Redirect("StudentHome.aspx");
            }
            else if ((username == username11) && (password == password11) && (role == "T"))
            {
                Session["username"] = username;
                Session["role"] = role;
                Session["name"] = name;               
                Session["loggedin"] = "Yes";
                DAL da = new DAL();              
                Response.Redirect("TeacherHome.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Username or password incorrect')</script>", false);
            }
        }
    }
}