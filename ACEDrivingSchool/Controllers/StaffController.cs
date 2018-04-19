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
        //If the user is part of the IsStaff or Admin role then they are able to view the staff home
        public ActionResult StaffHome()
        {
            if(User.IsInRole(RoleNameConstants.IsStaff) || User.IsInRole(RoleNameConstants.Admin))
                return View("StaffHome");

            return Redirect("/Account/StaffLogin");
        }
    }
}