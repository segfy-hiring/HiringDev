using System;
using Microsoft.EntityFrameworkCore;
using SegFyChallenge.Persistence.Contexts;

namespace SegFyChallenge.Tests.Helpers
{
    public class ContextFactory
    {
        public static ApplicationContext CreateApplicationContext()
        {
            DbContextOptions<ApplicationContext> options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "SegFyChallengeDb_" + Guid.NewGuid())
                .Options;

            var context = new ApplicationContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
    }
}