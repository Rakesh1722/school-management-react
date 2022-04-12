using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Management_System.Models
{
    public class Register 
    {
        public int id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public int phoneNumber { get; set; }
        public string password { get; set; }
    }
}