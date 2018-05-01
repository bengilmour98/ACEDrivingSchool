using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    public class Booking
    {
        //public int Id { get; set; }

        public DateTime BookingDate { get; set; }

        public double TotalPrice { get; set; }

        public ApplicationUser Customer { get; set; }

        
        [Key, Column(Order = 1)]
        public string CustomerId { get; set; }

        public Lesson Lesson { get; set; }

        
        [Key, Column(Order = 0)]

        public int LessonId { get; set; }

        


    }
}