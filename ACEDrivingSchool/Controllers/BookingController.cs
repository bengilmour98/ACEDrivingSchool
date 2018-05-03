using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACEDrivingSchool.Models;
using ACEDrivingSchool.ViewModels;

namespace ACEDrivingSchool.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;
        private List<Lesson> addedLessons;

        public BookingController()
        {
            _context = new ApplicationDbContext();
            addedLessons = new List<Lesson>();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult BookALesson()
        {




            //initialises the variables that will be passed in the view model, to their corresponding values in the database
            var lessonTypes = _context.LessonTypes.ToList();
            var durations = _context.Durations.ToList();
            //var transmissionTypes = _context.TransmissionTypes.ToList();
            var viewModel = new BookALessonViewModel
            {
                Lesson = new Lesson(),

                //LessonTypes = lessonTypes,
                Durations = durations,
                //TransmissionTypes = transmissionTypes
            };

            return View("BookALesson", viewModel);
        }

        [HttpPost]
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
                addedLessons.Add(lesson);


                /*_context.Lessons.Add(lesson);
                _context.SaveChanges();*/
            }


            viewModel = new BookALessonViewModel
            {
                Lesson = lesson,

                Durations = _context.Durations.ToList(),
                //LessonTypes = _context.LessonTypes.ToList(),
                //TransmissionTypes = _context.TransmissionTypes.ToList()
            };

            return View("BookALesson", viewModel);
            
        }
    }
}