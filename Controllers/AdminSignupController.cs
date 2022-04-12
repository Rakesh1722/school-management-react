using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Http;
using System.Web.Http;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    public class AdminSignupController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage PostData ( AdminSignupModel obj )
        {
            string selectQuery = @" select email from Signup ";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
            SqlCommand cmd = new SqlCommand ( selectQuery, con );

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill( dt );

            bool flag = false;
            var length = dt.Rows.Count;

            for (int i = 0; i <= length - 1; i++)
            {
                if (obj.email == Convert.ToString ( dt.Rows[i].ItemArray[0] ) )
                {
                    flag = true;
                }
            }

            /* when the entered email is unique below code will be executed */

            if (flag == false)
            {
                string insertQuery = "insert into Signup values ( '" + obj.name + "', '" + obj.email.ToLower() + "', '" + obj.phoneNumber + "', '" + obj.password + "' ) ";
                DataTable dt_insert = new DataTable();
                SqlConnection con_insert = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
                SqlCommand cmd_insert = new SqlCommand ( insertQuery, con_insert );

                SqlDataAdapter sda_insert = new SqlDataAdapter(cmd_insert);
                sda.Fill(dt_insert);

                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "email already exists");
        }
    }
}
