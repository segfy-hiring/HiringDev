using Microsoft.EntityFrameworkCore;
using YoutubeApiConsumerApp.Models;

namespace YoutubeApiConsumerApp.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {           
        }

        public DbSet<YoutubeVideoModel> Video { get; set; }
        public DbSet<YoutubeChannelModel> Channel { get; set; }

    }
}
