using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    public class StudentLoginController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(Login obj)
        {
            try
            {
                string selectQuery = " select email, password from tbl_Student where email= '" + obj.email + "' and password='" + obj.password + "' ";
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString);
                SqlCommand cmd = new SqlCommand(selectQuery, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                return Request.CreateResponse(HttpStatusCode.OK, Convert.ToString(dt.Rows[0].ItemArray[2]));
            }
            catch
            {
                Console.Write("Error occurred.");
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "wrong details");
        }

        //[HttpPost]
        //public HttpResponseMessage PostData(Login login)
        //{
        //    string selectQuery = @" select email, password from tbl_Student ";
        //    DataTable dt = new DataTable();
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminSignup_con"].ConnectionString );
        //    SqlCommand cmd = new SqlCommand ( selectQuery, con );
        //    using ( var sda = new SqlDataAdapter ( cmd ) )
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        sda.Fill(dt);
        //    }
        //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //    {
        //        if (login.email == Convert.ToString(dt.Rows[i].ItemArray[0]))
        //        {
        //            if (login.password == Convert.ToString(dt.Rows[i].ItemArray[1]))
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, "logged in");
        //            }
        //        }
        //    }
        //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "wrong details");
        //}
    }
}
