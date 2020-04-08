using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodSafety.API.Models;

namespace FoodSafety.API.Data
{
    public interface IRestuarantRepository
    {
      Task<IEnumerable<Restuarant>> GetRestuarantsAsync();
      Task<IEnumerable<Inspection>> GetInspectionsAsync();
      Task<IEnumerable<Violation>> GetViolationsAsync();
    }
}