namespace WebServices.Infra.DataAccess.ORM.Context
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DbContextExtensions.
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// Read all classmaps for classes in context assembly
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="modelBuilder">model builder</param>
        /// <summary>
        /// Repository constructor.
        /// </summary>
        /// <param name="context">context.</param>
        public static void ReadClassesMap(this DbContext context, ModelBuilder modelBuilder)
        {
            var typesToRegister = context.GetType()
                .Assembly.GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
