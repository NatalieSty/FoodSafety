using System;
using System.ComponentModel.DataAnnotations;

namespace FoodSafety.API.Dtos
{
    public class UsersForCreation
    {   
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(12, MinimumLength=4, ErrorMessage="You must specify password between 4 and 12 characters")]

        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        [Required]
        public int ZipCode { get; set; }
        public UsersForCreation()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}