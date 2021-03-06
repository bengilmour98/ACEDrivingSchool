﻿// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 04-16-2018
//
// Last Modified By : Ben
// Last Modified On : 05-24-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEDrivingSchool.Models;

namespace ACEDrivingSchool.Controllers
{
    /// <summary>
    /// Class StaffController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class StaffController : Controller
    {
        // GET: Staff
        /// <summary>
        /// A method to navigate to the staff home. The user is checked to make sure they are part of the Staff or Admin role
        /// </summary>
        /// <returns>The staff home view if the user is a staff member, and the staff login if they are not.</returns>
        public ActionResult StaffHome()
        {
            if(User.IsInRole(RoleNameConstants.IsStaff) || User.IsInRole(RoleNameConstants.Admin))
                return View("StaffHome");

            return Redirect("/Account/StaffLogin");
        }

        /// <summary>
        /// Method to load the edit lesson prices page, with access only allowed to an admin.
        /// </summary>
        /// <returns>Edit lesson prices view</returns>
        [Authorize(Roles = RoleNameConstants.Admin)]
        public ActionResult EditLessonPrices()
        {
            return View();
        }
    }
}