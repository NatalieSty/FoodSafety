using System.Threading.Tasks;
using AutoMapper;
using FoodSafety.API.Data;
using FoodSafety.API.Dtos;
using FoodSafety.API.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;

namespace FoodSafety.API.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IMapper mapper, IConfiguration config)
        {
            _repo = repo;
            _mapper = mapper;
            _config = config;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLogin userForLogin)
        {


            var user = await _repo.Login(userForLogin.Username.ToLower(), userForLogin.Password);
            if ( user == null)
            {
                return Unauthorized("Fail to login");
            }
            // build token to return
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            var userToReturn = _mapper.Map<UsersForReturn>(user);

            return Ok(new {
                token = tokenHandler.WriteToken(token),
                userToReturn
            });
        }

    }
}