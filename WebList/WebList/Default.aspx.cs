using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace WebList
{
    public partial class _Default : Page
    {
        StringBuilder table = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"data source = 172.1.254.214; initial catalog=EmployeeDB ;uid=adt_wfh;password=$pass$1234");
                // con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select [EmpID],[Emp_Name],[Designation],[State] ,[City]  FROM [EmployeeDB].[dbo].[Employee]");
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = con;

                SqlDataReader dr = cmd.ExecuteReader();
                table.Append("<table border='1'>");
                table.Append("<tr><th>Employee ID</th><th> Employee Name</th><th> Designation</th><th>State</th><th>City</th><th>Mobile</th>");
                table.Append("</tr>");

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + dr[0] + "</td>");
                        table.Append("<td>" + dr[1] + "</td>");
                        table.Append("<td>" + dr[2] + "</td>");
                        table.Append("<td>" + dr[3] + "</td>");
                        table.Append("<td>" + dr[4] + "</td>");
                        // table.Append("<td>" + dr[5] + "</td>");
                    }
                }

                table.Append("</table");
                PlaceHolder1.Controls.Add(new Literal { Text = table.ToString() });
                dr.Close();


            }
        }
    }
}