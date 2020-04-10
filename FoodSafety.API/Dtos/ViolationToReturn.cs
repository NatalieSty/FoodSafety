using System.ComponentModel.DataAnnotations;

namespace FoodSafety.API.Dtos
{
    public class ViolationToReturn
    {
        public enum ViolationTypeEnum
        {
            Blue,
            Red
        }
        
        
        public ViolationTypeEnum ViolationType { get; set; }
        public string ViolationDescription { get; set; }
        public int ViolationPoints { get; set; }
        [Key]
        public string ViolationRecordId { get; set; }
        //public InspectionForDetail Inspection { get; set; }
    }
}