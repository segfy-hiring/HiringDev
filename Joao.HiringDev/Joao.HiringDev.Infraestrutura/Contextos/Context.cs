using Flunt.Notifications;
using Joao.HiringDev.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Joao.HiringDev.Infraestrutura.Contextos
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<VideoYoutube> VideosYoutube { get; set; }
        public DbSet<CanalYoutube> CanaisYoutube { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
        }
    }
}
