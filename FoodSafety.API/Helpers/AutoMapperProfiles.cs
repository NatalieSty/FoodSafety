using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Models;

namespace FoodSafety.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RestuarantDeserializer, Restuarant>();
        }
        
    }
}