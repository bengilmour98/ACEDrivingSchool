using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    public class Customer : ApplicationUser
    {
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Postcode { get; set; }
        public string HomePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Credit { get; set; }
        public int AssignedInstructor { get; set; }



    }
}