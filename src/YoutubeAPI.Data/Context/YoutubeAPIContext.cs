using Microsoft.EntityFrameworkCore;
using YoutubeAPI.Business.Models;
using YoutubeAPI.Data.Configurations;

namespace YoutubeAPI.Data.Context
{
    public class YoutubeAPIContext : DbContext
    {
        public YoutubeAPIContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
