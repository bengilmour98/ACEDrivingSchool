// ***********************************************************************
// Assembly         : ACEDrivingSchool
// Author           : Ben
// Created          : 05-23-2018
//
// Last Modified By : Ben
// Last Modified On : 05-29-2018
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEDrivingSchool.Models;
using ACEDrivingSchool.ViewModels;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;
using Nexmo.Api;
using Stripe;
using Configuration = System.Configuration.Configuration;

namespace ACEDrivingSchool.Controllers
{
    /// <summary>
    /// Class BookingController.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BookingController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class.
        /// </summary>
        public BookingController()
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
        /// Method to load the page for booking a lesson
        /// </summary>
        /// <returns>BookALesson view</returns>
        [Authorize(Roles = RoleNameConstants.IsCustomer)]
        public ActionResult BookALesson()
        {
            var durations = _context.Durations.ToList();
            var customers = _context.Customers.ToList();

            var model = new BookALessonViewModel
            {
                Lesson = new Lesson(),
                Durations = durations,
                Customers = customers
            };

            

            return View("BookALesson", model);
        }


        /// <summary>
        /// Method to load the staff page for booking a lesson
        /// </summary>
        /// <returns>ActionResult.</returns>
        [Authorize(Roles = RoleNameConstants.IsStaff + "," + RoleNameConstants.Admin)]
        public ActionResult StaffBookALesson()
        {
            var durations = _context.Durations.ToList();
            var customers = _context.Customers.ToList();

            var model = new BookALessonViewModel
            {
                Lesson = new Lesson(),
                Durations = durations,
                Customers = customers
            };


            return View("StaffBookALesson", model);
            
        }


        /// <summary>
        /// Method to retrieve all lessons from the database
        /// </summary>
        /// <returns>A JsonResult of all lessons in the database</returns>
        public JsonResult GetAllLessons()
        {
            var lessons = _context.Lessons.ToList();

            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet};


        }

        /// <summary>
        /// Method to retrieve all lessons from the database that match the instructor ID selected
        /// </summary>
        /// <returns>A JsonResult made up of the lessons that match a particular instructor ID</returns>
        public JsonResult GetLessonsByInstructorId()
        {
            var id = User.Identity.GetUserId();

            var userInDb = _context.Customers.Find(id);

            var instructorId = userInDb.AssignedInstructor;

            var lessons = _context.Lessons.Where(c => c.InstructorId == instructorId).ToList();

            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        /// <summary>
        /// Method to retrieve all lessons from the database that match the customer ID selected
        /// </summary>
        /// <returns>A JsonResult made up of the lessons that match a particular customer ID</returns>
        public JsonResult GetLessonsByCustomerId()
        {
            var id = User.Identity.GetUserId();

            var lessons = _context.Lessons.Where(c => c.CustomerId == id);
            
            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        /// <summary>
        /// Method to save a lesson to the database
        /// </summary>
        /// <param name="lesson">A model passed in by the form on the book a lesson view</param>
        /// <returns>Returns a status to the book a lesson view</returns>
        [HttpPost]
        public JsonResult SaveLesson(Lesson lesson)
        {
            var status = false;
            var currentUserId = User.Identity.GetUserId();
            var customer = _context.Customers.Find(currentUserId);
            var instructorId = 0;
            

            if (customer == null)
            {
                
                currentUserId = lesson.CustomerId;

                var customerInDb = _context.Customers.Find(currentUserId);

                instructorId = customerInDb.AssignedInstructor;

                
            }
            else
            {
                instructorId = customer.AssignedInstructor;
                
            }

            

            if (lesson.Id > 0)
            {
                var v = _context.Lessons.Where(l => l.Id == lesson.Id).FirstOrDefault();
                if (v != null)
                {
                    //v.BookingDate = DateTime.Now;
                    v.DateTimeOfLesson = lesson.DateTimeOfLesson;
                    //v.CustomerId = currentUserId;
                    //v.InstructorId = instructorId;
                    //v.Paid = lesson.Paid;
                    v.DurationId = lesson.DurationId;
                    

                }
            }
            else
            {
                lesson.BookingDate = DateTime.Now;
                lesson.CustomerId = currentUserId;
                lesson.InstructorId = instructorId;
                
                _context.Lessons.Add(lesson);
                
            }

            _context.SaveChanges();
            status = true;

           

            

            return new JsonResult {Data = new {status = status}};

        }

        /// <summary>
        /// Method to delete a lesson from the database
        /// </summary>
        /// <param name="lessonId">Takes in a lessonId to delete from the database</param>
        /// <returns>Returns a status to the book a lesson view</returns>
        [HttpPost]
        public JsonResult DeleteLesson(int lessonId)
        {
            var status = false;

            var v = _context.Lessons.Where(l => l.Id == lessonId).FirstOrDefault();
            if (v != null)
            {
                _context.Lessons.Remove(v);
                _context.SaveChanges();
                status = true;
            }

            return new JsonResult {Data = new {status = status}};
        }

        /// <summary>
        /// Method to load the view lessons page
        /// </summary>
        /// <returns>ActionResult.</returns>
        [Authorize(Roles = RoleNameConstants.IsCustomer)]
        public ActionResult ViewLessons()
        {
            return View();
        }

        /// <summary>
        /// Method to navigate to the pay lesson page
        /// </summary>
        /// <param name="id">Passes the lessonId that the customer has selected to pay</param>
        /// <returns>ActionResult.</returns>
        [Authorize(Roles = RoleNameConstants.IsCustomer)]
        public ActionResult PayLesson(int id)
        {
            //retrieves the selected lesson from the database
            var lesson = _context.Lessons.Include(c => c.Duration).SingleOrDefault(c => c.Id == id);

            //if there is no lesson then it will return an error
            if (lesson == null)
                return HttpNotFound();


            var viewModel = new PayLessonViewModel
            {
                Lesson = lesson,

            };

            //retrieves values to be used in the stripe payment method
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;

            TempData["Price"] = lesson.Duration.Price*100;
            TempData["lessonId"] = lesson.Id;
           
            return View("PayLesson", viewModel);
        }

        /// <summary>
        /// Method to retrieve all lessons from the database that match the instructor ID selected
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A JsonResult made up of the lessons that match a particular instructor ID</returns>
        public JsonResult GetLessonsByInstructorIdForStaff(string id)
        {
            

            var userInDb = _context.Customers.Find(id);

            var instructorId = userInDb.AssignedInstructor;

            var lessons = _context.Lessons.Where(c => c.InstructorId == instructorId).ToList();

            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        /// <summary>
        /// Adds a charge to stripe so that the customer is billed
        /// </summary>
        /// <param name="stripeEmail">The stripe email.</param>
        /// <param name="stripeToken">The stripe token.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            //retrieves the amount to be charged based on the price of the lesson, which was set in the PayLesson ActionResult using tempdata
            int newAmount = 0;

            int oldValue = int.Parse(TempData["Price"].ToString());

            if (oldValue == 4000)
            {
                newAmount = 4000;
            }
            else
            {
                newAmount = 2000;
            }

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            //creates a new charge that will bill the customer the amount that their lesson costs
            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = newAmount,
                Description = "Lessons",
                Currency = "gbp",
                CustomerId = customer.Id

            });

            //will set the value of the lesson to paid once it has been paid for
            var id = TempData["lessonId"];

            var lesson = _context.Lessons.Find(id);
            lesson.Paid = true;
            _context.SaveChanges();

            return View("LessonPaid");

        }

        
        
    }
}