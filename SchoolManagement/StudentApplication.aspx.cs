using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
public partial class StudentApplication : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        DAL obj1 = new DAL();

        if (!IsPostBack)
        {
            ds1 = obj1.getschoolNames();

            DropDownList1.DataSource = ds1.Tables[0];
            DropDownList1.DataTextField = "sname";
            DropDownList1.DataValueField = "schoolid";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select School--", "0"));
        }

        Dictionary<string, string> states = new Dictionary<string, string>();
        states.Add("0", "--- Select state ---");
        states.Add("AL", "Alabama");
        states.Add("AK", "Alaska");
        states.Add("AZ", "Arizona");
        states.Add("AR", "Arkansas");
        states.Add("CA", "California");
        states.Add("CO", "Colorado");
        states.Add("CT", "Connecticut");
        states.Add("DE", "Delaware");
        states.Add("DC", "District of Columbia");
        states.Add("FL", "Florida");
        states.Add("GA", "Georgia");
        states.Add("HI", "Hawaii");
        states.Add("ID", "Idaho");
        states.Add("IL", "Illinois");
        states.Add("IN", "Indiana");
        states.Add("IA", "Iowa");
        states.Add("KS", "Kansas");
        states.Add("KY", "Kentucky");
        states.Add("LA", "Louisiana");
        states.Add("ME", "Maine");
        states.Add("MD", "Maryland");
        states.Add("MA", "Massachusetts");
        states.Add("MI", "Michigan");
        states.Add("MN", "Minnesota");
        states.Add("MS", "Mississippi");
        states.Add("MO", "Missouri");
        states.Add("MT", "Montana");
        states.Add("NE", "Nebraska");
        states.Add("NV", "Nevada");
        states.Add("NH", "New Hampshire");
        states.Add("NJ", "New Jersey");
        states.Add("NM", "New Mexico");
        states.Add("NY", "New York");
        states.Add("NC", "North Carolina");
        states.Add("ND", "North Dakota");
        states.Add("OH", "Ohio");
        states.Add("OK", "Oklahoma");
        states.Add("OR", "Oregon");
        states.Add("PA", "Pennsylvania");
        states.Add("RI", "Rhode Island");
        states.Add("SC", "South Carolina");
        states.Add("SD", "South Dakota");
        states.Add("TN", "Tennessee");
        states.Add("TX", "Texas");
        states.Add("UT", "Utah");
        states.Add("VT", "Vermont");
        states.Add("VA", "Virginia");
        states.Add("WA", "Washington");
        states.Add("WV", "West Virginia");
        states.Add("WI", "Wisconsin");
        states.Add("WY", "Wyoming");

        foreach (var row in states)
        {
            DropDownList2.Items.Add(new ListItem(row.Value.ToString(), row.Key));
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DAL obj = new DAL();
        DataSet ds = new DataSet();
        List<string> username11 = new List<string>();

        ds = obj.getUsename();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            username11.Add(ds.Tables[0].Rows[i][0].ToString());
        }

        string name = Request["name"];
        string username = Request["username"];
        string password = Request["password"];
        string cpassword = Request["cpassword"];
        string emailid = Request["emailid"];
        string phone = Request["phone"];        
        string address = Request["address"];
        string state = DropDownList2.SelectedValue;
        string city = Request["city"];
        string zip = Request["zip"];
        string schoolid = DropDownList1.SelectedValue;
        string strm = DropDownList3.SelectedValue;

        var regexItem = new Regex("^[0-9 ]*$");
        bool pass = password.Equals(cpassword);

        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(emailid);

        if (name.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter first name' )</script>", false);

        }
        else if (regexItem.IsMatch(name))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter alphabets only' )</script>", false);
        }

        else if (username.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter user name' )</script>", false);

        }

        else if (username11.Contains(username))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Username already exists' )</script>", false);

        }
        else if (password.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('please enter Password' )</script>", false);

        }

        else if (cpassword.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('please enter confirm password' )</script>", false);

        }

        else if (pass.Equals(false))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please check confirm password' )</script>", false);

        }
        else if (emailid.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter email address' )</script>", false);
        }
        else if (!(match.Success))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Email address was not in correct format' )</script>", false);
        }
        else if (phone.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter phone number' )</script>", false);
        }
        else if (!(regexItem.IsMatch(phone)))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Phone number should be numeric' )</script>", false);
        }
       
        else if (address.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter street address' )</script>", false);
        }
        else if (state == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select state' )</script>", false);
        }
        else if (city.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please enter city' )</script>", false);
        }
        else if (zip.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please Enter ZIP code' )</script>", false);
        }
        else if (!(regexItem.IsMatch(zip)))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('ZIP code should be numeric' )</script>", false);
        }
        else if (schoolid == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select school' )</script>", false);
        }
        else if (strm == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select the semester term' )</script>", false);
        }

        else
        {
            int res = obj.studentApplication(name, username, password, emailid, phone,address, state, city, zip,schoolid,strm);
            if (res > 0)
            {
               ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Your application has been created and you will receive the status of the application through email.');window.location='LoginPage.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                Response.Redirect(ResolveUrl("studentApplication.aspx"));
            }

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds2 = new DataSet();
        DAL obj2 = new DAL();
        string schoolid=DropDownList1.SelectedValue;
        ds2 = obj2.getStrm(schoolid);

        DropDownList3.DataSource = ds2.Tables[0];
        DropDownList3.DataTextField = "strm";
        DropDownList3.DataValueField = "strm";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, new ListItem("--Select semester--", "0"));
    }
}