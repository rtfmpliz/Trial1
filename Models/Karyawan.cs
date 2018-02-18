
using System;
using System.Collections.Generic;

namespace trial1.Models
{
        public enum Gender
    {
        Male, Female
    }
    public class Karyawan
    {
        
        public string ID {get;set;}
        public string Nama {get;set;}
        public Gender? Gender { get; set; }

        public ICollection<Kirim> Kirims { get; set; }
    }
}