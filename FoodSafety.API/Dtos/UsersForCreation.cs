using System;

namespace FoodSafety.API.Dtos
{
    public class UsersForCreation
    {   
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public int ZipCode { get; set; }
        public UsersForCreation()
        {
            Created = DateTime.Now;
        }
    }
}