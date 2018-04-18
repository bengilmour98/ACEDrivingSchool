using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEDrivingSchool.Models;

namespace ACEDrivingSchool.Controllers
{

    public class CustomerController : Controller
    {
        // GET: Customer
        
       
        
        public ActionResult CustomerHome()
        {
            if (User.IsInRole(RoleNameConstants.IsCustomer))
                return View("CustomerHome");

            return Redirect("/Account/Login");
            
        }
    }
}