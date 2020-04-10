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

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {

            var users = await _repo.GetUsers();
            if (users == null)
            {
                return NotFound("Users not found");
            }
            var usersToReturn = _mapper.Map<IEnumerable<UsersForReturn>>(users);
            return Ok(usersToReturn);
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

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdate userForUpdate)
        {
            var userFromRepo = await _repo.GetUser(id);
            if(userFromRepo == null)
            {
                return NotFound("User not found");
            }

            _mapper.Map<UserForUpdate, User>(userForUpdate, userFromRepo);
            if (await _repo.SaveAll())
            {
                return Ok("Updated User");
            }
            return BadRequest("Failed to update user");
        }
    }
}