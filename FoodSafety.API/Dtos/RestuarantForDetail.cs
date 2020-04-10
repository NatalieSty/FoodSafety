using System.Collections.Generic;
using FoodSafety.API.Models;

namespace FoodSafety.API.Dtos
{
    public class RestuarantForDetail
    {
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
        // public ICollection<Violation> Violations { get; set; }

        public ICollection<Inspection> Inspections { get; set; }
    }
}