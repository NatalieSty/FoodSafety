using System.Threading.Tasks;
using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodSafety.API.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IRestuarantRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IRestuarantRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {

            var user = await _repo.GetUser(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var userToReturn = _mapper.Map<UsersForReturn>(user);
            return Ok(userToReturn);
        }
    }
}