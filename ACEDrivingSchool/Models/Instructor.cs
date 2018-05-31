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
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    /// <summary>
    /// Class Instructor.
    /// </summary>
    public class Instructor
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the type of the transmission.
        /// </summary>
        /// <value>The type of the transmission.</value>
        public TransmissionType TransmissionType { get; set; }

        /// <summary>
        /// Gets or sets the transmission type identifier.
        /// </summary>
        /// <value>The transmission type identifier.</value>
        public int TransmissionTypeId { get; set; }
        /// <summary>
        /// Gets or sets the number of students.
        /// </summary>
        /// <value>The number of students.</value>
        public int NumberOfStudents { get; set; }



    }
}