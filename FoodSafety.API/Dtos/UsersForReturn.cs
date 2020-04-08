using System;

namespace FoodSafety.API.Dtos
{
    public class UsersForReturn
    {
        public int Id { get; set; }
        public int Username { get; set; }
        public int ZipCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
    }
}