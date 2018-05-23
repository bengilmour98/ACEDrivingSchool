using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.ViewModels
{
    public class EditDetailsViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }


        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Display(Name = "Home Phone Number")]
        public string HomePhoneNumber { get; set; }

        [Required]
        [Display(Name = "Mobile Phone Number")]
        public string MobilePhoneNumber { get; set; }

        [Required]
        [Display(Name = "Driving Licence Number")]
        public string DrivingLicenceNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "0:dd-MMM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}