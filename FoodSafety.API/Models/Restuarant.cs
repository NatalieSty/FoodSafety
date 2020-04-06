using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodSafety.API.Models
{
    public class Restuarant
    {
        [Key]
        public string BusinessID { get; set; }
        public string Name { get; set; }    
        public string ProgramIdentifier { get; set; }
        
        public string Desciption { get; set; }  
        public string  Address { get; set; }
        public string City { get; set; }    
        public int ZipCode { get; set; }
        public string Phone { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public int Grade { get; set; }
        public Violation[] Violations { get; set; }

        public Inspection[] Inspections { get; set; }

      
    }
}