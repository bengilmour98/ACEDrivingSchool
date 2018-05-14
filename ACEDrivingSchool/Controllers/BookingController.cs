using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEDrivingSchool.Models;
using ACEDrivingSchool.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace ACEDrivingSchool.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;
        

        public BookingController()
        {
            _context = new ApplicationDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult BookALesson()
        {
            return View("BookALesson");
        }

        
        public JsonResult GetAllLessons()
        {
            var lessons = _context.Lessons.ToList();

            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet};


        }

        public JsonResult GetLessonsByInstructorId()
        {
            var id = User.Identity.GetUserId();

            var userInDb = _context.Customers.Find(id);

            var instructorId = userInDb.AssignedInstructor;

            var lessons = _context.Lessons.Where(c => c.InstructorId == instructorId).ToList();

            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        public JsonResult GetLessonsByCustomerId()
        {

            

            var id = User.Identity.GetUserId();

            var lessons = _context.Lessons.Where(c => c.CustomerId == id);
            
            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }

        [HttpPost]
        public JsonResult SaveLesson(Lesson lesson)
        {

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

            var status = false;

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
                    status = true;

                }
            }
            else
            {
                lesson.BookingDate = DateTime.Now;
                lesson.CustomerId = currentUserId;
                lesson.InstructorId = instructorId;
                
                _context.Lessons.Add(lesson);
                status = true;
            }

            _context.SaveChanges();
            

            return new JsonResult {Data = new {status = status}};
        }

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


        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLesson(Lesson lesson)
        {
            var viewModel = new BookALessonViewModel();

            if (!ModelState.IsValid)
            {
                viewModel = new BookALessonViewModel
                {
                    Lesson = lesson,

                    Durations = _context.Durations.ToList(),
                    //LessonTypes = _context.LessonTypes.ToList(),
                    //TransmissionTypes = _context.TransmissionTypes.ToList()
                };

                return View("BookALesson", viewModel);
            }

            
            if (lesson.Id == 0)
            {
                


                _context.Lessons.Add(lesson);
                _context.SaveChanges();
            }


            viewModel = new BookALessonViewModel
            {
                Lesson = lesson,

                Durations = _context.Durations.ToList(),
                //LessonTypes = _context.LessonTypes.ToList(),
                //TransmissionTypes = _context.TransmissionTypes.ToList()
            };

            return View("BookALesson", viewModel);
            
        }*/
    }
}