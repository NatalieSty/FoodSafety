using System;
using System.ComponentModel.DataAnnotations;

namespace FoodSafety.API.Models
{
    public class Inspection
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
        public string BusinessID { get; set; }
        public DateTime InspectionDate { get; set; }
        public string InspectionBusinessName { get; set; }
        public InspectionTypeEnum InspectionType { get; set; }
        public int InspectionScore { get; set; }
        public InspectionResultEnum InspectionResult { get; set; }
        public bool InspectionClosedBusiness { get; set; }
        [Key]
        public string InspectionSerialNum { get; set; }
        public int Grade { get; set; }

    }
}