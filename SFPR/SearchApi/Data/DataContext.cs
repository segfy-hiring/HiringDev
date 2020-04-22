using Microsoft.EntityFrameworkCore;
using SearchApi.Models;

namespace SearchApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<BuscaVideo> Videos { get; set; }
        public DbSet<BuscaChannel> Channels { get; set; }
        public DbSet<Busca> Buscas { get; set; }
    }
}
