using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitulo06IdentityMVC.WEB.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerCountryViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Country { get; set; }
    }
}