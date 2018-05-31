// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 04-13-2018
//
// Last Modified By : Ben
// Last Modified On : 05-23-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    /// <summary>
    /// Class Customer.
    /// </summary>
    /// <seealso cref="ACEDrivingSchool.Models.ApplicationUser" />
    public class Customer : ApplicationUser
    {

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the name of the second.
        /// </summary>
        /// <value>The name of the second.</value>
        public string SecondName { get; set; }
        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>The postcode.</value>
        public string Postcode { get; set; }
        /// <summary>
        /// Gets or sets the home phone number.
        /// </summary>
        /// <value>The home phone number.</value>
        public string HomePhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the mobile phone number.
        /// </summary>
        /// <value>The mobile phone number.</value>
        public string MobilePhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the driving licence number.
        /// </summary>
        /// <value>The driving licence number.</value>
        public string DrivingLicenceNumber { get; set; }
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the credit.
        /// </summary>
        /// <value>The credit.</value>
        public int Credit { get; set; }
        /// <summary>
        /// Gets or sets the assigned instructor.
        /// </summary>
        /// <value>The assigned instructor.</value>
        public int AssignedInstructor { get; set; }



    }
}