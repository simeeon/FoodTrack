using FoodTrack.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Food> foodsToSeed = new List<Food>()
            {
                new Food
                {
                    FoodId = 1,
                    Name = "Banana",
                    Unit = "kg",
                    Price = 2.8M
                },
            };

            modelBuilder.Entity<Food>().HasData(foodsToSeed);
        }
    }
}
