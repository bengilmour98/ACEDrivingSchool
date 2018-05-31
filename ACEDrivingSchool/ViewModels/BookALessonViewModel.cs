// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 05-23-2018
//
// Last Modified By : Ben
// Last Modified On : 05-29-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACEDrivingSchool.Models;

namespace ACEDrivingSchool.ViewModels
{
    /// <summary>
    /// Class BookALessonViewModel.
    /// </summary>
    public class BookALessonViewModel
    {
        /// <summary>
        /// Gets or sets the lesson.
        /// </summary>
        /// <value>The lesson.</value>
        public Lesson Lesson { get; set; }
        /// <summary>
        /// Gets or sets the durations.
        /// </summary>
        /// <value>The durations.</value>
        public IEnumerable<Duration> Durations { get; set; }
        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>The customers.</value>
        public IEnumerable<Customer> Customers { get; set; }

        


    }
}