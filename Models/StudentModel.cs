using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Management_System.Models
{
    public class StudentModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public string standard { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}