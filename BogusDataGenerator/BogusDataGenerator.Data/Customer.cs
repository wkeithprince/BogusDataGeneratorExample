using System;
using System.Collections.Generic;

namespace BogusDataGenerator.Data
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string CreatedBy { get; set; }
    }
}
