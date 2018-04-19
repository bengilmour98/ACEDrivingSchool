using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    public class Lesson
    {
        public byte Id { get; set; }

        public DateTime DateOfLesson { get; set; }

        public DateTime TimeOfLesson { get; set; }

        public int Duration { get; set; }

        public Double Cost { get; set; }

        public bool Paid { get; set; }



    }
}