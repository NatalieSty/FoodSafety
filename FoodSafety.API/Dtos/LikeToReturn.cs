namespace FoodSafety.API.Dtos
{
    public class LikeToReturn
    {
        public int UserId { get; set; }
        public UsersForReturn User { get; set; }

        public string BusinessId { get; set; }
        public RestuarantForDetail Restuarant { get; set; }
    }
}