using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACEDrivingSchool.Controllers
{
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