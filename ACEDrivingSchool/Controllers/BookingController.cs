﻿using System;
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


        /// <summary>
        /// Method to load the page for booking a lesson
        /// </summary>
        /// <returns>BookALesson view</returns>
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

        public ActionResult ViewLessons()
        {
            return View();
        }

        public ActionResult PayLesson(int lessonId)
        {
            var lesson = _context.Lessons.SingleOrDefault(c => c.Id == lessonId);

            if (lesson == null)
                return HttpNotFound();

            var viewModel = new PayLessonViewModel
            {
                Lesson = lesson
            };

            return View("PayLesson", viewModel);
        }

        /// <summary>
        /// Method to retrieve all lessons from the database that match the instructor ID selected
        /// </summary>
        /// <returns>A JsonResult made up of the lessons that match a particular instructor ID</returns>
        public JsonResult GetLessonsByInstructorIdForStaff(string id)
        {
            

            var userInDb = _context.Customers.Find(id);

            var instructorId = userInDb.AssignedInstructor;

            var lessons = _context.Lessons.Where(c => c.InstructorId == instructorId).ToList();

            return new JsonResult { Data = lessons, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


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