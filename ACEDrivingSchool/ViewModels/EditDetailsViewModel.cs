// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 05-23-2018
//
// Last Modified By : Ben
// Last Modified On : 05-23-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.ViewModels
{
    /// <summary>
    /// Class EditDetailsViewModel.
    /// </summary>
    public class EditDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the second.
        /// </summary>
        /// <value>The name of the second.</value>
        [Required]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [Required]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }


        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>The postcode.</value>
        [Required]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the home phone number.
        /// </summary>
        /// <value>The home phone number.</value>
        [Display(Name = "Home Phone Number")]
        public string HomePhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone number.
        /// </summary>
        /// <value>The mobile phone number.</value>
        [Required]
        [Display(Name = "Mobile Phone Number")]
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the driving licence number.
        /// </summary>
        /// <value>The driving licence number.</value>
        [Required]
        [Display(Name = "Driving Licence Number")]
        public string DrivingLicenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "0:dd-MMM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}