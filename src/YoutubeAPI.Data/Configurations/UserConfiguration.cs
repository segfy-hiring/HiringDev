using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeAPI.Business.Models;

namespace YoutubeAPI.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.HasMany(p => p.Favorites)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}
