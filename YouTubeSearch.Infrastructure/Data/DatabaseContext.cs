using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using YouTubeSearch.Core.Entities;

namespace YouTubeSearch.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Video> Video { get; set; }
        public DbSet<Channel> Channel { get; set; }
    }
}
