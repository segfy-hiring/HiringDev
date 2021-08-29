using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeTree.Domain;

namespace YoutubeTree.Data
{
    public class PessoaMapping : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.YoutubeId)
                   .HasMaxLength(80)
                   .HasColumnType("varchar(80)");
            
            builder.Property(s => s.Title)
                   .IsRequired()
                   .HasMaxLength(200)
                   .HasColumnType("varchar(200)");
            
            builder.Property(s => s.Description)
                   .IsRequired()
                   .HasMaxLength(800)
                   .HasColumnType("varchar(800)");

            builder.Property(s => s.PublishedAt)
                   .HasColumnType("timestamp");
            
            builder.Property(s => s.DefaultThumbnail)
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)");
            
            builder.Property(s => s.MediumThumbnail)
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)");

            builder.Property(s => s.HighThumbnail)
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)");
            
            builder.ToTable("subscriptions");
        }
    }
}