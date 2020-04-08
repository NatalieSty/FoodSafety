using System;
using System.ComponentModel.DataAnnotations;

namespace FoodSafety.API.Dtos
{
    public class InspectionForDetail
    {
        public enum InspectionResultEnum
        {
            Satisfactory,
            Complete,
            Unsatisfactory
        }
        public enum InspectionTypeEnum
        {
            RoutineInspectionFieldReview,
            ConsultationEducationField,
            Unsatisfactory
        }
        //public string BusinessID { get; set; }
        
        public int InspectionScore { get; set; }
        public InspectionResultEnum InspectionResult { get; set; }
 
        [Key]
        public string InspectionSerialNum { get; set; }
        public int Grade { get; set; }
        
    }
}