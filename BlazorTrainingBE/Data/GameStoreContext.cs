using BlazorTrainingBE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorTrainingBE.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "RPG" },
                new { Id = 2, Name = "ARPG" },
                new { Id = 3, Name = "FPS" },
                new { Id = 4, Name = "Fighting" },
                new { Id = 5, Name = "Sports" }
            );
        }
    }
}
