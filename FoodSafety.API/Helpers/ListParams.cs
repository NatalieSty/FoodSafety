namespace FoodSafety.API.Helpers
{
    public class ListParams
    {
        private const int MaxPageSize = 25;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize: value ; }
        }

        // public string Name { get; set; }
        // public int ZipCode { get; set; }
    }
}