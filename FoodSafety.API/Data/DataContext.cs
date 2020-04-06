using FoodSafety.API.Models;
using Microsoft.EntityFrameworkCore;


namespace FoodSafety.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Restuarant> Restuarants { get; set; }
    }
}