using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YoutubeAPI.Data.Context
{
    public class YoutubeAPIContextFactory : IDesignTimeDbContextFactory<YoutubeAPIContext>
    {
        public YoutubeAPIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<YoutubeAPIContext>();
            optionsBuilder.UseNpgsql("Host=drona.db.elephantsql.com;Database=zvwmslca;Username=zvwmslca;Password=39sNFLwUCj7zEn5pJ_X-Bkf-r1NhgCK_");

            return new YoutubeAPIContext(optionsBuilder.Options);
        }
    }
}
