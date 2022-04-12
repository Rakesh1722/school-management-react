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
    public class LoginController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post ( Login obj )
        {
            try
            {
                string selectQuery = " select email, password, name from Signup where email = '" + obj.email + "' and password = '" + obj.password + "' ";
                DataTable dt = new DataTable ();
                SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
                SqlCommand cmd = new SqlCommand ( selectQuery, con );

                SqlDataAdapter sda = new SqlDataAdapter ( cmd );
                sda.Fill ( dt );

                return Request.CreateResponse ( HttpStatusCode.OK, Convert.ToString ( dt.Rows[0].ItemArray[2]) );
            }
            catch
            {
                Console.Write("Error occurred.");
            }

            return Request.CreateErrorResponse ( HttpStatusCode.BadRequest, "wrong details" );
        }
    }
}


//[HttpPost]
//public HttpResponseMessage Post(Login login)
//{
//    string query1 = @" select email, password, name from tbl_AdminSignup ";
//    DataTable dt = new DataTable();
//    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminSignup_con"].ConnectionString)) //con.Open();
//    using (SqlCommand cmd = new SqlCommand(query1, con))
//    using (var sda = new SqlDataAdapter(cmd))
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
//                return Request.CreateResponse(HttpStatusCode.OK, dt.Rows[i].ItemArray[2]);
//            }
//        }
//    }
//    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "wrong details");
//}
