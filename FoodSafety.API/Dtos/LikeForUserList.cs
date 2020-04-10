namespace FoodSafety.API.Dtos
{
    public class LikeForUserList
    {
        public int UserId { get; set; }
        public string BusinessId { get; set; }
        public RestuarantForDetail Restuarant { get; set; }
    }
}