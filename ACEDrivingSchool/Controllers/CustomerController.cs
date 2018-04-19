using System;
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

        public ActionResult BookALesson()
        {

            //initialises the variables that will be passed in the view model, to their corresponding values in the database
            var lessonTypes = _context.LessonTypes.ToList();
            var durations = _context.Durations.ToList();
            var transmissionTypes = _context.TransmissionTypes.ToList();
            var viewModel = new BookALessonViewModel
            {
                Lesson = new Lesson(),
                LessonTypes = lessonTypes,
                Durations = durations,
                TransmissionTypes = transmissionTypes
            };

            return View("BookALesson", viewModel);
        }

        public ActionResult Save()
        {


            return RedirectToAction("CustomerHome", "Customer");
        }
    }
}