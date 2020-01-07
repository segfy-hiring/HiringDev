namespace WebServices.Core.DataContext
{
    using Infra.DataAccess.ORM.Context;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Database context of the WebServices.
    /// </summary>
    public class WebServicesDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebServicesDBContext"/> class.
        /// </summary>
        /// <param name="objUserIdentityProvider">the user identity provider.</param>
        /// <param name="options">the options.</param>
        public WebServicesDBContext(DbContextOptions<WebServicesDBContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// On model creating.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ReadClassesMap(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}