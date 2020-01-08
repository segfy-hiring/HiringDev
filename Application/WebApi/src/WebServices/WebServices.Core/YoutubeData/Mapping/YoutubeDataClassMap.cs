namespace WebServices.Core.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WebServices.Domain.Models;

    /// <summary>
    /// Mapping class of the <see cref="Youtube"/> class.
    /// </summary>
    public class YoutubeDataClassMap : IEntityTypeConfiguration<YoutubeData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Youtube"/> class.
        /// </summary>
        /// <param name="builder">entity type builder.</param>
        public void Configure(EntityTypeBuilder<YoutubeData> builder)
        {
            builder.ToTable("YoutubeData");
            builder.HasKey(x => new { x.Id });

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.VideoId)
                .HasColumnName("VideoId")
                .IsUnicode(false);

            builder.Property(x => x.ChannelId)
                .HasColumnName("ChannelId")
                .IsUnicode(false);

            builder.Property(x => x.PublishedAt)
                .HasColumnName("PublishedAt");

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .IsUnicode(false);

            builder.Property(x => x.ThumbnailUrl)
                .HasColumnName("ThumbnailUrl")
                .IsUnicode(false);

            builder.Property(x => x.Type)
                .HasColumnName("Type");
        }
    }
}