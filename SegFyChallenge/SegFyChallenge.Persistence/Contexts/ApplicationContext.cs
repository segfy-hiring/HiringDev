using Microsoft.EntityFrameworkCore;
using SegFyChallenge.Domain.Models;

namespace SegFyChallenge.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Channel> Channels { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

    }
}