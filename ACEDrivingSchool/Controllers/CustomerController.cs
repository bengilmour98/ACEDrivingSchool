using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEDrivingSchool.Models;
using ACEDrivingSchool.ViewModels;

namespace ACEDrivingSchool.Controllers
{

    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        

        public CustomerController()
        {
            _context = new ApplicationDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        // GET: Customer
        
        //Checks that the user is logged in as a customer before they are able to navigate to the customer home page
        [Authorize(Roles = RoleNameConstants.IsCustomer)]
        public ActionResult CustomerHome()
        {
                return View();

        }

        


        


        
    }
}