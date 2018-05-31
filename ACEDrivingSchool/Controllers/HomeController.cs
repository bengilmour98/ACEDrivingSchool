// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 05-29-2018
//
// Last Modified By : Ben
// Last Modified On : 05-29-2018
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACEDrivingSchool.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class HomeController : Controller
    {

        /// <summary>
        /// A method to display the index page of the web app.
        /// </summary>
        /// <returns>The index view for the web app.</returns>
        public ActionResult Index()
        {
            return View();
        }

        

        
    }
}