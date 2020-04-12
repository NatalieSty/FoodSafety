using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoodSafety.API.Dtos;

namespace FoodSafety.API.Models
{
    public class Inspection
    {
        public enum InspectionResultEnum
        {
            Satisfactory,
            Complete,
            Unsatisfactory,
            NotAccessible,
            NotReadyForInspection,
            NotApplicable,
            BaselineData,
            NeedsAssessment,
            NotInCompliance,
            NoLongerAtLocation,
            Confirmed,
            NotConfirmed
        }
        public enum InspectionTypeEnum
        {
            RoutineInspectionFieldReview,
            ConsultationEducationField,
            Unsatisfactory,
            ReturnInspection
        }
        //public string BusinessID { get; set; }
        public DateTime InspectionDate { get; set; }
        public string InspectionBusinessName { get; set; }
        public InspectionTypeEnum InspectionType { get; set; }
        public int InspectionScore { get; set; }
        public InspectionResultEnum InspectionResult { get; set; }
        public bool InspectionClosedBusiness { get; set; }
        [Key]
        public string InspectionSerialNum { get; set; }
        public int Grade { get; set; }
        public ICollection<Violation> Violations { get; set; }
        public Restuarant Restuarant { get; set; }
    }
}