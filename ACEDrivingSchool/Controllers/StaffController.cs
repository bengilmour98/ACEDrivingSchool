using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEDrivingSchool.Models;

namespace ACEDrivingSchool.Controllers
{
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
    }
}