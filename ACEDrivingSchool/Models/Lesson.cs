using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    public class Lesson
    {
        public byte Id { get; set; }

        [Display(Name = "Date of lesson")]
        public DateTime? DateOfLesson { get; set; }

        [Display(Name = "Time of lesson")]
        public DateTime? TimeOfLesson { get; set; }

        public Duration Durations { get; set; }

        [Display(Name = "Duration")]
        public byte DurationId { get; set; }

        public LessonType LessonTypes { get; set; }

        [Display(Name = "Lesson Type")]
        public byte LessonTypeId { get; set; }

        public TransmissionType TransmissionTypes { get; set; }

        [Display(Name = "Transmission Type")]
        public byte TransmissionTypeId { get; set; }

        public Double Cost { get; set; }

        public bool Paid { get; set; }



    }
}