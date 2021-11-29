using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using FakeTube.Domain.Entities;
using System;
using System.Diagnostics;

namespace FakeTube.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : this(false) { }
        public DatabaseContext(bool tests)
        {
            Tests = tests;
        }

        private bool Tests { get; }
        private SqliteConnection TestsSqliteConnection { get; set; }

        public override void Dispose()
        {
            base.Dispose();
            if (TestsSqliteConnection != null)
            {
                TestsSqliteConnection.Close();
                TestsSqliteConnection.Dispose();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Tests)
            {
                TestsSqliteConnection = new SqliteConnection("Data Source=:memory:");
                TestsSqliteConnection.Open();

                optionsBuilder.UseSqlite(TestsSqliteConnection);
            }
            else
            {
                optionsBuilder.UseMySQL(
                    $"server={ConfigManager.DatabaseHost};" +
                    $"port={ConfigManager.DatabasePort};" +
                    $"database={ConfigManager.DatabaseSchema};" +
                    $"user={ConfigManager.DatabaseUser};" +
                    $"password={ConfigManager.DatabasePwd}");
            }

            optionsBuilder.UseLazyLoadingProxies();

            EnableLogWhenDebugging(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<YoutubeItem>();
            builder.ToTable("YoutubeItem");
            builder.HasKey(o => o.Id);
        }

        [Conditional("DEBUG")]
        private static void EnableLogWhenDebugging(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}
