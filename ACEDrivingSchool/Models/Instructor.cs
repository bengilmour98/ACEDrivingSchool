using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACEDrivingSchool.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public TransmissionType TransmissionType { get; set; }

        public int TransmissionTypeId { get; set; }
        public int NumberOfStudents { get; set; }



    }
}