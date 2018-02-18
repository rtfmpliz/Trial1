using System;
using System.Collections.Generic;


namespace trial1.Models
{
    public class Truck
    {
        public int ID { get; set; }
        public string NoPol { get; set; }
        public Boolean Status { get; set; }
        public float Tonase {get;set;}
        // public DateTime EnrollmentDate { get; set; }

        // public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Kirim> Kirims { get; set; }
    }
}