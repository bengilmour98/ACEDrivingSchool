using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    public class Lesson
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date of lesson")]
        public DateTime? DateTimeOfLesson { get; set; }


        public Duration Durations { get; set; }

        [Display(Name = "Duration")]
        public int DurationId { get; set; }


        public Booking Booking { get; set; }

        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Required]
        public bool Paid { get; set; }

        
        public int InstructorId { get; set; }


        //public LessonType LessonTypes { get; set; }

        
        //[Display(Name = "Lesson Type")]
        //public int LessonTypeId { get; set; }

        
        //public TransmissionType TransmissionTypes { get; set; }

        //[Display(Name = "Transmission Type")]
        //public int TransmissionTypeId { get; set; }

        



    }
}