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
        
        /// <summary>
        /// A method to display the customer home. The program then checks to see if the user is part of the customer role
        /// </summary>
        /// <returns>Returns the customer home view.</returns>
        [Authorize(Roles = RoleNameConstants.IsCustomer)]
        public ActionResult CustomerHome()
        {
                return View();

        }

        


        


        
    }
}