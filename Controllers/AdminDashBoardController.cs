using School_Management_System.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace School_Management_System.Controllers
{
    [RoutePrefix("api/AdminDashBoard")]
    public class AdminDashBoardController : ApiController
    {

        [HttpGet]
        public int GetTeachers()
        { 
            int count = 0;
            string query = @" select count(*) from Signup ";

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
            SqlCommand cmd = new SqlCommand ( query, con );

            SqlDataAdapter sda = new SqlDataAdapter( cmd );
            con.Open();
            count = (int)cmd.ExecuteScalar();
            sda.Fill(dt);

            return count;
        }        

        [HttpGet]
        [Route("GetStudent")]
        public int GetStudent()
        {
            int count = 0;
            string query = @" select count(*) from tbl_Student ";
            
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection ( ConfigurationManager.ConnectionStrings["SchoolManagement_con"].ConnectionString );
            SqlCommand cmd = new SqlCommand ( query, con );

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            con.Open();
            count = (int)cmd.ExecuteScalar();
            sda.Fill(dt);

            return count;
        }
    }
}
