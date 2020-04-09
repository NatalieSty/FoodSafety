using System.Diagnostics;
using System.Threading.Tasks;
using FoodSafety.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodSafety.API.Controllers
{
    [ApiController]
    [Route("api/Restuarants")]
    public class RestuarantsController : Controller
    {
        private readonly IRestuarantRepository _repo;

        public RestuarantsController(IRestuarantRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestuarants()
        {
            var restuarants = _repo.GetRestuarantsAsync();
            if (await restuarants == null)
            {
                return NotFound("Cannot get restuarants");
            }
            return Ok(restuarants);

        }
    }


}