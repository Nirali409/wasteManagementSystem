using System;
using System.Collections.Generic;

namespace wasteManagementSystem.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Postalcode { get; set; }
        public string Province { get; set; }
        public string EmailId { get; set; }
        public string ContactNumber { get; set; }
    }
}
