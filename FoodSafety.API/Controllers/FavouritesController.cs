using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Dtos;
using FoodSafety.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodSafety.API.Controllers
{
    [ApiController]
    [Route("api/Favourites")]
    public class FavouritesController : Controller
    {
        private readonly IRestuarantRepository _repo;
        private readonly IMapper _mapper;

        public FavouritesController(IRestuarantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLikesForUser(int userId)
        {

            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var likes = await _repo.GetLikes(userId);

            if (likes == null)
                return NotFound();

            var likesToReturn = _mapper.Map<IEnumerable<LikeForUserList>>(likes);
            return Ok(likesToReturn);

        }

        

        [HttpDelete("{userId}/Unlike/{restuarantId}")]
        public async Task<IActionResult> UnlikeRestuarant(int userId, string restuarantId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var like = await _repo.GetLike(userId, restuarantId);

            if( like == null ){
                return BadRequest("You have not liked this restaurant");
            }

            if(await _repo.GetRestuarant(restuarantId) == null)
                return NotFound();

            _repo.Delete<Favourites>(like); // not async 

            if(await _repo.SaveAll())
                return Ok();
            return BadRequest("Failed to like user.");
        }
    }
}