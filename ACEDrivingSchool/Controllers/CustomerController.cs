﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACEDrivingSchool.Controllers
{

    public class CustomerController : Controller
    {
        // GET: Customer
        
       
        [Authorize]
        public ActionResult CustomerHome()
        {

            return View();
        }
    }
}