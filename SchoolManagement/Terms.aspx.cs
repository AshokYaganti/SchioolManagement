using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class Terms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string schoolid = Convert.ToString(Session["schoolid"]);
        DAL obj = new DAL();
        DataSet ds = obj.getTermDetails(schoolid);
        StringBuilder sb = new StringBuilder();
        DataTable dt = ds.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append((dr["strm"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["sdate"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["edate"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["created_at"]));
                    sb.Append("</td>"); 
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string schoolid = Convert.ToString(Session["schoolid"]);
        DAL obj = new DAL();

        DataSet ds = new DataSet();
        List<string> strm11 = new List<string>();

        ds = obj.getStrm(schoolid);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            strm11.Add(ds.Tables[0].Rows[i][0].ToString());
        }

        string term = DropDownList1.SelectedValue;
        string year = DropDownList3.SelectedValue;
        string sdate=Request["sdate"];
        string edate = Request["edate"];
        DateTime today = DateTime.Now;
        string strm = term + "" + year;
        if (term == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select term' )</script>", false);
        }
        else if (year == "0")
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select year' )</script>", false);
        }
        else if (strm11.Contains(strm))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Semester term already exists' )</script>", false);

        }
        else if (sdate.Length==0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please select start date' )</script>", false);
        }
        else if (Convert.ToDateTime(sdate) < today)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Start date should be greater than today date' )</script>", false);
        }
        else if (edate.Length == 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Please end start date' )</script>", false);
        }
        else if (Convert.ToDateTime(edate) < Convert.ToDateTime(sdate))
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('End date should be greater than start date' )</script>", false);
        }
        else
        {
            int res = obj.termDetails(strm,sdate,edate,schoolid);

            if (res > 0)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Semester term has been created');window.location='Terms.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ss", "<script>alert('Something went wrong with this request. Please try agin later.')</script>", false);
                Response.Redirect(ResolveUrl("Terms.aspx"));
            }
        }

    }
}