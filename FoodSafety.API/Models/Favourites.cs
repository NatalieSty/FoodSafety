namespace FoodSafety.API.Models
{
    public class Favourites
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string BusinessId { get; set; }
        public Restuarant Restuarant { get; set; }
    }
}