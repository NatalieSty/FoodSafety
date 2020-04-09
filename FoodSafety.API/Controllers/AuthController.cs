using System.Threading.Tasks;
using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Dtos;
using FoodSafety.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodSafety.API.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UsersForCreation usersForCreation)
        {
            usersForCreation.Username = usersForCreation.Username.ToLower();
            var checkUserExistTask = _repo.UserExists(usersForCreation.Username);

            var user = _mapper.Map<User>(usersForCreation);
            
            if (await checkUserExistTask)
            {
                return BadRequest("User name already exists");
            }

            var registerTask = _repo.Register(user, usersForCreation.Password);
            if (registerTask != null)
            {
                var userToReturn = _mapper.Map<UsersForReturn>(user);
                return CreatedAtRoute("GetUser", new {controller = "users", id = user.Id}, userToReturn);
            }
            return BadRequest("User registration failed");
        }

        // [HttpPost("login")]
        // public async Task<IActionResult> Login(string username, string password)
        // {
        //     _repo.Login();
        // }

    }
}