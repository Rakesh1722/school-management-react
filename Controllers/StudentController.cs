using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace School_Management_System.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllStudents ()
        {
            string selectQuery = " select * from tbl_Student ";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
            SqlCommand cmd = new SqlCommand ( selectQuery, con );

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return Request.CreateResponse( HttpStatusCode.OK, dt );
        }

        [HttpDelete]
        public HttpResponseMessage DeleteStudent ( int id )
        {
            string deleteQuery = " delete from tbl_Student where id=" + id;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
            SqlCommand cmd = new SqlCommand ( deleteQuery, con );

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return Request.CreateResponse ( HttpStatusCode.OK, " Record deleted " );
        }
    }
}
