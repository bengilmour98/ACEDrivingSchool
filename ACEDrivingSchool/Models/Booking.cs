using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    public class Booking
    {
        public byte Id { get; set; }

        public DateTime BookingDate { get; set; }

        public double TotalPrice { get; set; }

        public Lesson Lessons { get; set; }

        public byte LessonId { get; set; }


    }
}