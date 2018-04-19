using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACEDrivingSchool.Models;

namespace ACEDrivingSchool.ViewModels
{
    public class BookALessonViewModel
    {
        public Lesson Lesson { get; set; }

        public IEnumerable<Duration> Durations { get; set; }
        public IEnumerable<LessonType> LessonTypes { get; set; }
        public IEnumerable<TransmissionType> TransmissionTypes { get; set; }


    }
}