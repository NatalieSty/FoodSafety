using System.ComponentModel.DataAnnotations;

namespace FoodSafety.API.Models
{
    public class Violation
    {
        public enum ViolationTypeEnum
        {
            Blue,
            Red
        }
        public string BusinessID { get; set; }
        public ViolationTypeEnum ViolationType { get; set; }
        public string ViolationDescription { get; set; }
        public int ViolationPoints { get; set; }
        [Key]
        public string ViolationRecordId { get; set; }
    }
}