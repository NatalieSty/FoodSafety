using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using FoodSafety.API.Data;
using FoodSafety.API.Models;
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
        [HttpGet("{businessId}")]
        public async Task<IActionResult> GetRestuarant(string businessId)
        {
            var restuarant = _repo.GetRestuarant(businessId);
            if (await restuarant == null)
            {
                return NotFound("Cannot find restuarant");
            }
            return Ok(restuarant);

        }

        [HttpPost("{userId}/Like/{restuarantId}")]
        public async Task<IActionResult> LikeRestuarant(int userId, string restuarantId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var getLikeTask =  _repo.GetLike(userId, restuarantId);
            var getUserTask =  _repo.GetUser(userId);
            var getRestuarantTask =  _repo.GetRestuarant(restuarantId);

            var like = await getLikeTask;
            var restuarant = await getRestuarantTask;
            var user = await getUserTask;

            if( like != null )
                return BadRequest("You already liked this restaurant");
            
            if( restuarant == null)
                return NotFound();

            like = new Favourites{ UserId = userId, User = user, BusinessId = restuarantId, Restuarant = restuarant};
            _repo.Add<Favourites>(like); // not async 

            if(await _repo.SaveAll())
                return Ok();
            return BadRequest("Failed to like user.");
        }
    }


}