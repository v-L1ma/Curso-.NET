using Microsoft.EntityFrameworkCore;

namespace VideoGameWebApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "Spider-Man ",
                    Platform = "PS5",
                    Developer = "Insomaniac Games",
                    Publisher = "Sony",
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Black 2",
                    Platform = "PS5",
                    Developer = "Seila",
                    Publisher = "Feira",
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "CS2",
                    Platform = "PC",
                    Developer = "Valve",
                    Publisher = "Steam"
                }
            );

        }
    }
    
    
}