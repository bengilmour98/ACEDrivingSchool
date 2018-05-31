// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 04-19-2018
//
// Last Modified By : Ben
// Last Modified On : 05-29-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    /// <summary>
    /// Class Lesson.
    /// </summary>
    public class Lesson
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date time of lesson.
        /// </summary>
        /// <value>The date time of lesson.</value>
        [Required]
        [Display(Name = "Date of lesson")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm A}", ApplyFormatInEditMode = true)]
        public DateTime? DateTimeOfLesson { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public Duration Duration { get; set; }

        /// <summary>
        /// Gets or sets the duration identifier.
        /// </summary>
        /// <value>The duration identifier.</value>
        [Display(Name = "Duration")]
        public int DurationId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Lesson"/> is paid.
        /// </summary>
        /// <value><c>true</c> if paid; otherwise, <c>false</c>.</value>
        [Required]
        public bool Paid { get; set; }


        /// <summary>
        /// Gets or sets the instructor identifier.
        /// </summary>
        /// <value>The instructor identifier.</value>
        public int InstructorId { get; set; }

        /// <summary>
        /// Gets or sets the booking date.
        /// </summary>
        /// <value>The booking date.</value>
        public DateTime BookingDate { get; set; }



        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public ApplicationUser Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; }


        //public LessonType LessonTypes { get; set; }

        
        //[Display(Name = "Lesson Type")]
        //public int LessonTypeId { get; set; }

        
        //public TransmissionType TransmissionTypes { get; set; }

        //[Display(Name = "Transmission Type")]
        //public int TransmissionTypeId { get; set; }

        



    }
}