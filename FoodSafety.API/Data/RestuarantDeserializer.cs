using System;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FoodSafety.API.Data
{
    public class RestuarantDeserializer
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InspectionResultEnum
        {
            [EnumMember(Value = "satisfactory")]
            Satisfactory,
            [EnumMember(Value = "complete")]
            Complete,
            [EnumMember(Value = "unsatisfactory")]
            Unsatisfactory,
            [EnumMember(Value = "incomplete")]
            Incomplete,
            [EnumMember(Value = "Not Accessible")]
            NotAccessible,
            [EnumMember(Value = "Not Ready For Inspection")]
            NotReadyForInspection,
            [EnumMember(Value = "Not Applicable")]
            NotApplicable,
            [EnumMember(Value = "Baseline Data")]
            BaselineData,
            [EnumMember(Value = "Needs Assessment")]
            NeedsAssessment,
            [EnumMember(Value = "Not In Compliance")]
            NotInCompliance,
            [EnumMember(Value = "No Longer At Location")]
            NoLongerAtLocation,
            [EnumMember(Value = "Confirmed")]

            Confirmed,
            [EnumMember(Value = "Not Confirmed")]
            NotConfirmed
        }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InspectionTypeEnum
        {
            [EnumMember(Value = "Routine Inspection/Field Review")]
            RoutineInspectionFieldReview,
            [EnumMember(Value = "Consultation/Education - Field")]
            ConsultationEducationField,
            [EnumMember(Value = "Return Inspection")]
            ReturnInspection
        }
        [JsonProperty("business_id")]
        public string BusinessID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }   

        [JsonProperty("program_identifier")]
        public string ProgramIdentifier { get; set; }

        [JsonProperty("description")]
        public string Desciption { get; set; }  

        [JsonProperty("address")]
        public string  Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip_code")]
        public int ZipCode { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("longitude")]
        public double Longtitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("inspection_date")]
        public DateTime InspectionDate { get; set; }

        [JsonProperty("inspection_business_name")]
        public string InspectionBusinessName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("inspection_type")]
        public InspectionTypeEnum InspectionType { get; set; }

        [JsonProperty("inspection_score")]
        public int InspectionScore { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("inspection_result")]
        public InspectionResultEnum InspectionResult { get; set; }

        [JsonProperty("inspection_closed_business")]
        public bool InspectionClosedBusiness { get; set; }

        [JsonProperty("inspection_serial_num")]
        public string InspectionSerialNum { get; set; }
        [JsonProperty("grade")]
        public int Grade { get; set; }
        public enum ViolationTypeEnum
        {
            [EnumMember(Value = "blue")]
            Blue,
            [EnumMember(Value = "red")]
            Red
        }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("violation_type")]
        public ViolationTypeEnum ViolationType { get; set; }

        [JsonProperty("violation_description")]
        public string ViolationDescription { get; set; }

        [JsonProperty("violation_points")]
        public int ViolationPoints { get; set; }

        [JsonProperty("violation_record_id")]
        public string ViolationRecordId { get; set; }

    }
}