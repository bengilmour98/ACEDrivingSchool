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
        
        public ActionResult StaffHome()
        {
            if(User.IsInRole(RoleNameConstants.IsStaff) || User.IsInRole(RoleNameConstants.Admin))
                return View("StaffHome");

            return Redirect("/Account/StaffLogin");
        }
    }
}