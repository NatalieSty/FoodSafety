using System;
using System.Collections.Generic;
using FoodSafety.API.Models;

namespace FoodSafety.API.Dtos
{
    public class UsersForReturn
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int ZipCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public ICollection<Favourites> Favourites { get; set; }
    }
}