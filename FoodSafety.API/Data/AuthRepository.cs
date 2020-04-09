using System;
using System.Threading.Tasks;
using FoodSafety.API.Helpers;
using FoodSafety.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodSafety.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            
            var user = await _context.Users.Include(x => x.Favourites).FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
                return null;

            var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt);
            
            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            for(int i = 0; i < passwordHash.Length ; i++)
            {
                if(passwordHash[i] != user.PasswordHash[i])
                {
                    return null;
                }
            }
            
            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordSalt, passwordHash;

            CreatePasswordHash(password, out passwordSalt, out passwordHash);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            if (await _context.SaveChangesAsync() > 0)
            {
                return null;
            }

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if ( await _context.Users.AnyAsync(x => x.Username == username))
            { 
                return true;
            }
            return false;
        }
    }
}