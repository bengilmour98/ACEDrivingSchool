// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 04-16-2018
//
// Last Modified By : Ben
// Last Modified On : 05-24-2018
// ***********************************************************************

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

    /// <summary>
    /// Class CustomerController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class CustomerController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        public CustomerController()
        {
            _context = new ApplicationDbContext();
            
        }

        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




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