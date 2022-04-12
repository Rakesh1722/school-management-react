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
    public class StudentSignUpController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage PostData ( StudentSignUpModel obj )
        {
            string selectQuery = @" select email from tbl_Student ";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
            SqlCommand cmd = new SqlCommand ( selectQuery, con );

            using ( var sda = new SqlDataAdapter ( cmd ) )
            {
                cmd.CommandType = CommandType.Text;
                sda.Fill( dt );
            }

            bool flag = false;
            var length = dt.Rows.Count;

            for ( int i = 0; i <= length - 1; i++ )
            {
                if ( obj.email == Convert.ToString ( dt.Rows[i].ItemArray[0] ) )
                {
                    flag = true;
                }
            }

            if ( flag == false )
            {
                string insertQuery = "insert into tbl_Student values ('" + obj.name + "', '" + obj.phoneNumber + "', '" + obj.standard + "', '" + obj.email + "',  '" + obj.password + "') ";
                DataTable dt_insert = new DataTable();
                SqlConnection con_insert = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString);
                SqlCommand cmd_insert = new SqlCommand ( insertQuery, con_insert );

                using ( var sda_insert = new SqlDataAdapter ( cmd_insert ) )
                {
                    cmd_insert.CommandType = CommandType.Text;
                    sda_insert.Fill ( dt_insert );
                }

                return Request.CreateResponse( HttpStatusCode.OK, "success" );
            }

            return Request.CreateErrorResponse( HttpStatusCode.BadRequest, "User already exists" );
        }
    }
}
