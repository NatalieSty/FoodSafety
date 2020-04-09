using System.Threading.Tasks;
using FoodSafety.API.Helpers;
using FoodSafety.API.Models;

namespace FoodSafety.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);

        Task<User> Login(string username, string password);

        Task<bool> UserExists(string username);

    }
}