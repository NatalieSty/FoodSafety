using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Dtos;
using FoodSafety.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodSafety.API.Controllers
{
    [ApiController]
    [Route("api/Violations")]
    public class ViolationsController : Controller
    {
        private readonly IRestuarantRepository repo;
        private readonly IMapper mapper;

        public ViolationsController(IRestuarantRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetViolationsAsync() 
        {
            var violations = await this.repo.GetViolationsAsync();
            if( violations == null)
            {
                return NotFound("Cannot get Violations");
            }
                
            var violationsToReturn = this.mapper.Map<IEnumerable<ViolationToReturn>>(violations);
            return Ok(violationsToReturn);
        }
    }
}