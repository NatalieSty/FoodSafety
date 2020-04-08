using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Dtos;
using FoodSafety.API.Models;

namespace FoodSafety.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RestuarantDeserializer, Restuarant>();
            CreateMap<RestuarantDeserializer, Inspection>();
            CreateMap<RestuarantDeserializer, Violation>();
            CreateMap<Restuarant, RestuarantForDetail>();
            CreateMap<Inspection, InspectionToReturn>();
            CreateMap<Violation, ViolationToReturn>();
            CreateMap<Inspection,InspectionForDetail>();
        }
        
    }
}