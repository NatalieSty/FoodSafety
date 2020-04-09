using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodSafety.API.Models
{
    public class Violation
    {
        public enum ViolationTypeEnum
        {
            Blue,
            Red
        }
        
        // public string InspectionSerialNum { get; set; }
        public Inspection Inspection { get; set; }
        public ViolationTypeEnum ViolationType { get; set; }
        public string ViolationDescription { get; set; }
        public int ViolationPoints { get; set; }

        [Key]
        public string ViolationRecordId { get; set; }

        
    }
}