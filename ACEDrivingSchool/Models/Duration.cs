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
    /// Class Duration.
    /// </summary>
    public class Duration
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the duration of lesson.
        /// </summary>
        /// <value>The duration of lesson.</value>
        public string DurationOfLesson { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public double Price { get; set; }

    }
}