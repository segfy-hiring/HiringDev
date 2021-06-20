using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SegFyChallenge.Persistence.Contexts
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql("Host=HOST;Port=PORT;Database=DATABASE;Username=USERNAME;Password=PASSWORD");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}