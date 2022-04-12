using School_Management_System.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace School_Management_System.Controllers
{
    public class TeachersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllTeachers()
        {
            string selectQuery = @" select * from Signup ";

            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );

            SqlCommand cmd = new SqlCommand ( selectQuery, con );

            using ( var sda = new SqlDataAdapter( cmd ) )
            {
                cmd.CommandType = CommandType.Text;
                sda.Fill( dt );
            }

            return Request.CreateResponse ( HttpStatusCode.OK, dt );
        }

        [HttpDelete]
        public HttpResponseMessage DeleteTeacher(int id)
        {
            try
            {
                string deleteQuery = @" delete from Signup where id = " + id;

                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );

                SqlCommand cmd = new SqlCommand ( deleteQuery, con );

                using ( var sda = new SqlDataAdapter( cmd ) )
                {
                    cmd.CommandType = CommandType.Text;
                    sda.Fill( dt );
                }

                return Request.CreateResponse ( HttpStatusCode.OK, "deleted" );
            }
            catch ( Exception )
            {
                return Request.CreateErrorResponse ( HttpStatusCode.BadRequest, "not deleted" );
            }
        }

        [HttpGet]
        public DataTable Edit(int id)
        {
            string query = "select * from Signup where id=" + id;

            DataTable dt = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminSignup_con"].ConnectionString)) //con.Open();

            using (var cmd = new SqlCommand(query, con))

            using (var sda = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                sda.Fill(dt);
            }
            return dt;
        }



        [HttpPut]
        public string Update(TeachersModel obj, int id)
        {
            string query = "update Signup set name='" + obj.name + "',phoneNumber='" + obj.phoneNumber + "',email='" + obj.email + "' where id=" + id;

            DataTable dt = new DataTable();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminSignup_con"].ConnectionString)) //con.Open();

            using (var cmd = new SqlCommand(query, con))

            using (var sda = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                sda.Fill(dt);
            }

            return "Success";
        }


        

        //without response code

        //[HttpDelete]
        //public Response4 Delete(int id)
        //{
        //    try
        //    {
        //        string query = @" delete from tbl_AdminSignup where id = " + id;
        //        DataTable dt = new DataTable();

        //        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminSignup_con"].ConnectionString)) //con.Open();

        //        using (SqlCommand cmd = new SqlCommand(query, con))

        //        using (var sda = new SqlDataAdapter(cmd))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            sda.Fill(dt);
        //        }
        //        return new Response4 { status = "success", message = "deleted" };
        //    }
        //    catch (Exception)
        //    {
        //        return new Response4 { status = "failed", message = "Not deleted" };
        //    }
        //}
    }
}
