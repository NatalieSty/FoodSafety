using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodSafety.API.Controllers
{
    [ApiController]
    [Route("api/Inspections")]
    public class InspectionsController : Controller
    {
        private readonly IRestuarantRepository _repo;
        private readonly IMapper mapper;

        public InspectionsController(IRestuarantRepository repo, IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetInspections()
        {
            var inspections = await _repo.GetInspectionsAsync();
            if (inspections == null)
            {
                return NotFound("Cannot get inspections");
            }

            var inspectionsToReturn = this.mapper.Map<IEnumerable<InspectionToReturn>>(inspections);
            return Ok(inspectionsToReturn);

        }

    }   
}