using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_provider
{
    public class SchoolClass
    {
        public string City { get; set; }
        public int SchoolNumber { get; set; }
        public string Address { get; set; }
        public int SchClass { get; set; }

        public Teacher Teacher { get; set; }
        public List<string> StudentsList { get; set; }
    }

    public class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WorkExperience { get; set; }
        public DateTime Birthday { get; set; }
    }
   
}
