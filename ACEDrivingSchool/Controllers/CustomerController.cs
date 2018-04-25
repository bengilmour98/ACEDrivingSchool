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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Lesson lesson, FormCollection form)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new BookALessonViewModel
                {
                    Lesson = lesson,
                    Durations = _context.Durations.ToList(),
                    LessonTypes = _context.LessonTypes.ToList(),
                    TransmissionTypes = _context.TransmissionTypes.ToList()
                };

                return View("BookALesson", viewModel);
            }

            var nowOrLater = form["submitButton"];

            if (nowOrLater == "PayNow")
            {
                if (lesson.Id == 0)
                {
                    _context.Lessons.Add(lesson);
                    _context.SaveChanges();
                }
                else
                {
                    var lessonInDb = _context.Lessons.Single(c => c.Id == lesson.Id);

                    lessonInDb.DateTimeOfLesson = lesson.DateTimeOfLesson;
                    lessonInDb.DurationId = lesson.DurationId;
                    lessonInDb.LessonTypeId = lesson.LessonTypeId;
                    lessonInDb.TransmissionTypeId = lesson.TransmissionTypeId;
                    lessonInDb.Cost = lesson.Cost;
                    lessonInDb.Paid = lesson.Paid;


                }

                return RedirectToAction("PayLesson", "Customer");
            }

            else
            {
                if (lesson.Id == 0)
                {
                    _context.Lessons.Add(lesson);
                    _context.SaveChanges();
                }
                else
                {
                    var lessonInDb = _context.Lessons.Single(c => c.Id == lesson.Id);

                    lessonInDb.DateTimeOfLesson = lesson.DateTimeOfLesson;
                    lessonInDb.DurationId = lesson.DurationId;
                    lessonInDb.LessonTypeId = lesson.LessonTypeId;
                    lessonInDb.TransmissionTypeId = lesson.TransmissionTypeId;
                    lessonInDb.Cost = lesson.Cost;
                    lessonInDb.Paid = lesson.Paid;


                }

                return RedirectToAction("CustomerHome", "Customer");
            }

            

        }


        public ActionResult PayLesson()
        {
            return View();
        }
    }
}