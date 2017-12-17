using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class Payments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DAL obj = new DAL();
        DataSet ds = new DataSet();
        string schoolid = Convert.ToString(Session["schoolid"]);
        ds = obj.studentPayments(schoolid);

        StringBuilder sb = new StringBuilder();
        DataTable dt = ds.Tables[0];
        if (dt != null)
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {

                    sb.Append("<tr>");
                    sb.Append("<td>");
                    sb.Append((dr["applicationid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["name"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["email"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["phone"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["courseid"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["coursename"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["strm"]));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append((dr["amount"]));
                    sb.Append("</td>");
                    sb.Append("</tr>");

                }

        ltData.Text = sb.ToString();
    }
}