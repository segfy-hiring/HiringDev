using Microsoft.EntityFrameworkCore;
using RTube.Models;

namespace RTube.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<YouTubeItem> Items { get; set; }
    }
}
