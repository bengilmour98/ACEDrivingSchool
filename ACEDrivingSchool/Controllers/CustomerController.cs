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
        
        //Checks that the user is logged in as a customer before they are able to navigate to the customer home page
        [Authorize(Roles = RoleNameConstants.IsCustomer)]
        public ActionResult CustomerHome()
        {
                return View("CustomerHome");

        }

        /*public ActionResult BookALesson()
        {


        }*/
    }
}