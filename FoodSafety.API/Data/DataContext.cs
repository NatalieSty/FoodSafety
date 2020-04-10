using FoodSafety.API.Models;
using Microsoft.EntityFrameworkCore;


namespace FoodSafety.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Restuarant> Restuarants { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Favourites> Favourites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favourites>()
            .HasKey(t => new { t.UserId, t.BusinessId });

        modelBuilder.Entity<Favourites>()
            .HasOne(pt => pt.User)
            .WithMany(p => p.Favourites)
            .HasForeignKey(pt => pt.UserId);

        modelBuilder.Entity<Favourites>()
            .HasOne(pt => pt.Restuarant)
            .WithMany(t => t.Likers)
            .HasForeignKey(pt => pt.BusinessId);
    }
        
    }

}